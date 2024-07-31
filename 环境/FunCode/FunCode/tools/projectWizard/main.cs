//---------------------------------------------------------------------------------------------
// Torque Game Builder
// Copyright (C) GarageGames.com, Inc.
//---------------------------------------------------------------------------------------------

$templatesDirectory = expandFilename("^tool/gameData/T2DProject/templates/");
$resourcesDirectory = expandFilename("^tool/resources/");

// completely empty game
$newProjectTemplate["<Empty Game>"] = $templatesDirectory @ "base";

// empty games w/ some resource
$newProjectTemplate["Checkers"] = $templatesDirectory @ "base";
$newProjectTemplate["Fish"] = $templatesDirectory @ "base";
$newProjectTemplate["Puzzle"] = $templatesDirectory @ "base";

function initializeProjectWizard()
{
   exec("./gui/newProjectDlg.ed.gui");
   exec("./gui/newProjectDlg.ed.cs");
   exec("./gui/openProjectDlg.ed.gui");
   exec("./gui/projectOptionsDlg.ed.gui");
   exec("./gui/projectOptionsDlg.ed.cs");
   exec("./gui/superTooltipDlg.ed.cs");
   exec("./gui/superTooltipDlg.ed.gui");
}

function destroyProjectWizard()
{
}

function newProject()
{
   Canvas.pushDialog(NewProjectDlg);
   
   templateListBox.clear();
   templateListBox.add("<Empty Game>", 0);
   templateListBox.add("Checkers", 2);
   templateListBox.add("Fish", 1);
   templateListBox.add("Puzzle", 3);
   
   %templates = getDirectoryList( $templatesDirectory );
   %templateCount = getWordCount( %templates );
   %num = 3;
   for( %i = 0; %i < %templateCount; %i++ )
   {
      %template = getWord( %templates, %i );
      %name = %template;
      if( (%index = strrchr( %name, "/" )) !$= "")
         %name = getSubStr( %name, %index );
      
      if( %name !$= "base" )
      {
         templateListBox.add( %name, %num );
         $newProjectTemplate[%name] = $templatesDirectory @ %name;
         %num++;
      }
   }
   
   templateListBox.sort();
   templateListBox.setSelected( 0 );
}

function browseForProjectDir()
{
   %currentFile = newProjectLocationText.getText();
   %dlg = new OpenFolderDialog()
   {
      DefaultPath = %currentFile;
   };
      
   if(%dlg.Execute())
   {
      newProjectLocationText.setText(%dlg.FileName);
      $Pref::UserGamesFolder = %dlg.FileName;
   }
   
   %dlg.delete();
}

// Return true/false
function findProject( %name ) 
{
   %projects = getDirectoryList( "/" );
   %projectCount = getWordCount( %projects );
   
   for( %i = 0; %i < %projectCount; %i++ )
   {
      if( getWord( %projects, %i ) $= %name )
         return true;
   }
   
   return false;
}

function createNewProject(%location, %name, %template)
{
   // The name must not be empty
   if( %location $= "")
   {
      MessageBoxOK("Error Creating Project", "Please choose a folder for the project" );
      return false;
   }   
   
   %gameLocation = %location @ "/" @ %name @ "/";
   
   if( isFile( %gameLocation @ "project.funProj" ) )
   {
      %result = messageBox( "Invalid Name", "A game already exists at this location. Choose a new name or delete the old game before continuing.", "Ok" );
      return false;
   }
      
   // Template Hierarchy
   //  force overwrite
   if(!pathCopy($newProjectTemplate[%template], %gameLocation @ "game/", false))
   {
      messageBox( "Error Creating Project", "An error occurred while trying to create your project.\n\nCould not create the output path, Access Denied.", "Ok", "Error" );
      return;
   }
   
   // Any resources
   copyResourceIncludes(%gameLocation, %template);
   
   
   // Pop this dialog
   Canvas.popDialog(NewProjectDlg);
   
   // Common Hierarchy
   //  force overwrite
   pathCopy( expandFilename("^tool/gameData/T2DProject/common"), %gameLocation @ "common/", false );
   // Main Script
   pathCopy( expandFileName("^tool/gameData/T2DProject/main.cs"), %gameLocation @ "main.cs" );
   
   // [neo, 5/30/2007 - #3167]
   // If the user selected the check box, copy over the game binaries to the project root
   // and rename the game exe to the project name.      
   %cbCopy = NewProjectDlg-->cbCopyBinaries;
   
   if( isObject( %cbCopy ) && %cbCopy.getValue() == true )
      copyProjectGameBinaries( %gameLocation, %name );
      
   // Torsion default project (will check for platform stuff etc)
   t2dTorsion::copyProject( %gameLocation, %name, %cbCopy.getValue() );
   
   %projectFile = %gameLocation @ "project.funProj";
   
   // Post Create Project
   Projects::GetEventManager().postEvent( "_ProjectCreate", %projectFile );   
  
   // Post Open Event
   if(! LBProjectObj.isActive())
      Projects::GetEventManager().postEvent( "_ProjectOpen", %projectFile );
   else 
   {
      $pref::lastProject = $pref::startupProject = %projectFile;
      reloadProject();
   }
}

// [neo, 6/1/2007 - #3167]
// Copy over game executable and any other binaries needed for a project
// Rename the game executable so it matches the project name (non mac only)
function copyProjectGameBinaries( %gameLocation, %name )
{
   if( $platform $= "macos" )
   {
      pathCopy( expandFileName( "^tool/gameData/T2DProject/TGBGame.app" ), %gameLocation );
   }
   else
   {
      %exename = %gameLocation @ %name @ ".exe";
      %srcpath = expandFileName( "^tool/gameData/T2DProject/" );
      
      pathCopy( %srcpath @ "TGBGame.exe",    %exename, false );
      pathCopy( %srcpath @ "Opengl2d3d.dll", %gameLocation @ "Opengl2d3d.dll" );
      pathCopy( %srcpath @ "glu2d3d.dll",    %gameLocation @ "glu2d3d.dll" );
      pathCopy( %srcpath @ "unicows.dll",    %gameLocation @ "unicows.dll" );
      pathCopy( %srcpath @ "openAL32.dll",   %gameLocation @ "openAL32.dll" );
   }
}

function copyResourceIncludes(%gameLocation, %template)
{
   %resInclude = expandFilename($templatesDirectory @ %template @ ".ggres");
   if (!isFile(%resInclude))
      return;
      
   %outputDir = %gameLocation @ "resources/";
   
   %fileObject = new FileObject();
   %blah = %fileObject.openForRead(%resInclude);

   while(!%fileObject.isEOF())
   {
      %resource = %fileObject.readLine();
      if (%resource $= "")
         continue;
      
      %resourceDir = expandFilename($resourcesDirectory @ %resource);
      if(!pathCopy(%resourceDir, %outputDir @ %resource, false))
      {
         %errorMsg = "An error occurred while trying to copy some resources to your project.\n\nCould not find the resource <" SPC %resource SPC ">!";
         messageBox( "Error Copying Resources", %errorMsg, "Ok", "Error" );
         continue;
      }
   }

   %fileObject.close();
   %fileObject.delete();
}

function isValidProject(%project)
{
   // Should be more robust check.
   return isFile(%project @ "/project.funProj");
}