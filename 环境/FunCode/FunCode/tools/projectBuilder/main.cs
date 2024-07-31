//-----------------------------------------------------------------------------
// Torque2D Packaging Utility
// Copyright (C) GarageGames.com, Inc.
//-----------------------------------------------------------------------------

function initializeProjectBuilder()
{
   exec("./projectBuilder.ed.gui");
   
   // default the company and product to the config info
   ProjectBuilderCompanyText.setText($Project::Game::CompanyName);
   ProjectBuilderProductText.setText($Project::Game::ProductName);
   
   // default the startup scene to the config info
   ProjectBuilderSceneText.setText($Project::Game::DefaultScene);
   
   // default the output directory to something reasonable
   ProjectBuilderDirectoryText.setText(getUserHomeDirectory());
   
   // list the available platforms
   ProjectBuilderPlatformList.add("Windows", 0);
   ProjectBuilderPlatformList.add("Mac", 1);
   //ProjectBuilderPlatformList.add("Linux", 2);
   ProjectBuilderPlatformList.setSelected(0);
}

function destroyProjectBuilder()
{
}

function buildProject()
{
   Canvas.pushDialog(ProjectBuilderGui);
}

function isDirectory(%directory)
{
   %dirName = fileName(%directory);
   %dirPath = filePath(%directory);
   
   %dirList = getDirectoryList(%dirPath);
   if (isInFieldList(%dirName, %dirList))
      return true;
   
   return false;
}

function deleteFiles(%pattern)
{
   %path = filePath(%pattern);
   addresPath(%path);
   for (%file = findFirstFile(%pattern); %file !$= ""; %file = findNextFile(%pattern))
      fileDelete(%file);
   
   removeResPath(%path);
}

//[neo, 5/11/2007]
function deleteDirectory( %path )
{     
   // Get a list of direct sub-directories in directory if any
   // (We do this recursively so depth is set to 0)
   %dirs = getDirectoryList( %path, 0 );   
   %cnt  = getWordCount( %dirs );
   
   // First handle sub dirs
   for( %i = 0; %i < %cnt; %i++ )
   {
      // Get the directory path
      %dir = %path @ "/" @ getWord( %dirs, %i );
      
      // Recursively delete it      
      deleteDirectory( %dir );
         //return false;
   }
      
   // Delete all files in directory
   deleteFiles( %path @ "/*.*" );
      
   // Delete the dir
   return fileDelete( %path );
}

function compileFiles(%pattern)
{  
   %path = filePath(%pattern);

   %saveDSO    = $Scripts::OverrideDSOPath;
   %saveIgnore = $Scripts::ignoreDSOs;
   
   $Scripts::OverrideDSOPath  = %path;
   $Scripts::ignoreDSOs       = false;
   
   addresPath(%path);
   for (%file = findFirstFile(%pattern); %file !$= ""; %file = findNextFile(%pattern))
      compile(%file);
   
   removeResPath(%path);

   $Scripts::OverrideDSOPath  = %saveDSO;
   $Scripts::ignoreDSOs       = %saveIgnore;
   
}

function ProjectBuilderBuildButton::onClick(%this)
{
   // make sure certain things are valid before performing the action
   %haveError = false;
   
   %haveError = ProjectBuilderCompanyText.getText() $= "";
   if (%haveError)
   {
      messageBox("Project Bulder", "You must specify a company name!", "Ok", "Stop");
      return;
   }
   
   %haveError = ProjectBuilderProductText.getText() $= "";
   if (%haveError)
   {
      messageBox("Project Bulder", "You must specify a product name!", "Ok", "Stop");
      return;
   }
   
   %haveError = !ProjectBuilderSceneText.isValidLocation();
   if (%haveError)
   {
      messageBox("Project Builder", "An invalid scene was specified for the 'Startup Scene'!", "Ok", "Stop");
      return;
   }
   
   %haveError = ProjectBuilderDirectoryText.getText() $= "";
   if (%haveError)
   {
      messageBox("Project Builder", "An invalid path was specified for the 'Output Directory'!", "Ok", "Stop");
      return;
   }
   
   
   //-----------------------------------------------------------------------------
   
   
   %platform = ProjectBuilderPlatformList.getText();
   %includeGameScripts = ProjectBuilderIncludeScriptCheckBox.getValue();
   
   %binary["Windows"] = "exe";
   %binary["Mac"] = "app";
   %binary["Linux"] = "bin";
   
   %fileList["Windows"] = "glu2d3d.dll" TAB "opengl2d3d.dll" TAB "OpenAl32.dll" TAB "unicows.dll";
   %fileList["Mac"] = "";
   %fileList["Linux"] = "";
   
   %gamePath = LBProjectObj.gamePath;
   %binPath = "gameData/T2DProject/";
   
   // rdbnote: use the product name for the executable, etc., not the game path
   %gameName = ProjectBuilderProductText.getText();//fileName(%gamePath);
   
   %outputDir = ProjectBuilderDirectoryText.getText() @ "/" @ %gameName;
   
   if (isFile(%outputDir) || isDirectory(%outputDir))
   {
      %result = messageBox("Warning", "The output directory already exists. Overwrite?", "YesNo", "Question");
      if (%result == $MRCancel)
         return;
   }
   
   // Copy base game data.
   createPath(%outputDir @ "/");
   pathCopy(%binPath @ "TGBGame." @ %binary[%platform], %outputDir @ "/" @ %gameName @ "." @ %binary[%platform], false);
   
   %fileCount = getFieldCount(%fileList[%platform]);
   for (%i = 0; %i < %fileCount; %i++)
   {
      %file = getField(%fileList[%platform], %i);
      pathCopy(%binPath @ %file, %outputDir @ "/" @ %file, false);
   }
   
   // Save the XML config information
   _saveGameConfigurationData(%gamePath @ "/common/commonConfig.xml");
   
   pathCopy(%gamePath @ "/common", %outputDir @ "/common", false);
   pathCopy(%gamePath @ "/game", %outputDir @ "/game", false);
   pathCopy(%gamePath @ "/resources", %outputDir @ "/resources", false);
   pathCopy(%gamePath @ "/main.cs", %outputDir @ "/main.cs", false);
   
   if (%includeGameScripts)
   {
      deleteFiles(%outputDir @ "/common/*.dso");
      deleteFiles(%outputDir @ "/game/*.dso");
      deleteFiles(%outputDir @ "/resources/*.dso");
   }
   else
   {
      compileFiles(%outputDir @ "/common/*.cs");
      compileFiles(%outputDir @ "/common/*.gui");
      compileFiles(%outputDir @ "/game/*.cs");
      compileFiles(%outputDir @ "/game/*.gui");
      compileFiles(%outputDir @ "/resources/*.cs");
      compileFiles(%outputDir @ "/resources/*.gui");
      
      deleteFiles(%outputDir @ "/common/*.cs");
      deleteFiles(%outputDir @ "/common/*.gui");
      deleteFiles(%outputDir @ "/game/*.cs");
      deleteFiles(%outputDir @ "/game/*.gui");
      deleteFiles(%outputDir @ "/resources/*.cs");
      deleteFiles(%outputDir @ "/resources/*.gui");
   }
   
   openFolder( %outputDir );
   
   Canvas.popDialog(ProjectBuilderGui);
}

function ProjectBuilderSceneBrowseButton::onClick(%this)
{
   // this is going to be a relative path, we need to
   // secretly expand it out to a full path
   %currentFile = ProjectBuilderSceneText.getText();
   
   if( %currentFile !$= "" )
      %levelRelativePath = %currentFile;
   else
      %levelRelativePath = "~/data/levels/untitled.t2d";

   // expand out to the full game path
   %openPath = expandGameScriptFilename(%levelRelativePath);
   if (%openPath $= "") // just stomp what they have there, if we have trouble
      %openPath = "~/data/levels/untitled.t2d";
   
   %dlg = new OpenFileDialog()
   {
      Filters        = $T2D::LevelSpec;
      DefaultPath    = filePath(%openPath);
      DefaultFile    = %openPath;
      ChangePath     = false;
      MustExist      = true;
   };
   
   if (%dlg.Execute())
   {
      // this is going to be a full path, we need to
      // secretly break it down to a relative path
      %newFile = collapseFilename(%dlg.FileName);
      ProjectBuilderSceneText.setText(%newFile);
   }
   
   %dlg.delete();
}

function ProjectBuilderSceneText::isValidLocation(%this)
{
   %isInError = false;
   
   %currentFile = %this.getText();
   if (%currentFile $= "")
      %isInError = true;
   
   if (!%isInError)
   {
      %testPath = expandGameScriptFilename(%currentFile);
      if (%testPath $= "")
         %isInError = true;
      else
         %isInError = !isFile(%testPath);
   }
   
   return !%isInError;
}

function ProjectBuilderBrowseButton::onClick(%this)
{
   %currentFile = ProjectBuilderDirectoryText.getText();
   %dlg = new OpenFolderDialog()
   {
      DefaultPath = %currentFile;
   };
      
   if(%dlg.Execute())
      ProjectBuilderDirectoryText.setText(%dlg.FileName);
   
   %dlg.delete();
}
