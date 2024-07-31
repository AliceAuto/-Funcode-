//-----------------------------------------------------------------------------
// Gui Form Content Controller
// Copyright (C) GarageGames.com, Inc.
//-----------------------------------------------------------------------------

// Declare the Project Target
Projects::DeclareProjectTarget( T2DProject, LBProjectObj );

// Set Mod Paths.
%thisResPath = expandFilename("^tool/gameData/T2DProject/");
addResPath( %thisResPath );

// Deal with non-Windows platforms
if($platform $= "windows")
   $LB::PlayerExecutable = expandFilename("^tool/gameData/T2DProject/SampleGame.exe");

if($platform $= "macos")
   $LB::PlayerExecutable = expandFilename("^tool/gameData/T2DProject/TGBGame.app/Contents/MacOS/TGBGame");



function T2DProject::onAdd( %this )
{
   Parent::onAdd( %this );
   
   // Set flag to true to always persist objects when we're deleted
   %this.persistOnRemove = false;
   
}

function T2DProject::onRemove( %this ) 
{   
   // Persist at option
   if( %this.persistOnRemove == true )
      %this.persistToDisk( true, true, true );
      
   Parent::onRemove( %this );

}

///
/// ProjectOpen Event Handler
/// - %data is the project object to be opened
function T2DProject::onProjectOpen( %this, %data )
{   
   echo("% Opening Project " @ %data @ " ...");
   
   // Load Project Data
   %this.LoadProjectData();
   
   showLevelEditor();
   
   if ($pref::loadLastLevel && isFile(%this.lastLevel))
      %this.openLevel(%this.lastLevel);
   else
   {
      //If we have no last scene, we might as well load the default scene (it seems unused anyway)
      if($Game::DefaultScene !$= "" && isFile((expandFilename($Game::DefaultScene))))
      {
        %this.openLevel(expandFilename($Game::DefaultScene));
      }
      else
      {
         //No default, so try open the existing empty level, 
         if(isFile(expandFilename("^game/data/levels/emptyLevel.t2d")))
         {
             %this.openLevel(expandFilename("^game/data/levels/emptyLevel.t2d"));
         }
         else
         {
            //Still no luck? then just make a new level.
            %this.newLevel();
         }
      }
	}
   
   // Update object library
   GuiFormManager::SendContentMessage($LBCreateSiderBar, %this, "refreshAll 1");
   
   return true;
}

///
/// ProjectClose Event Handler
///
function T2DProject::onProjectClose( %this, %data )
{
   error("onProjectClose Handler not implemented for class -" SPC %this.class );   
}

///
/// ProjectAddFile Event Handler
///
function T2DProject::onProjectAddFile( %this, %data )
{
   error("onProjectAddFile Handler not implemented for class -" SPC %this.class );
}

///
/// ProjectRemoveFile Event Handler
///
function T2DProject::onProjectRemoveFile( %this, %data )
{
   error("onProjectRemoveFile Handler not implemented for class -" SPC %this.class );
}

/// Legacy Code Below, used only to prevent code changes to a currently stable base for now - JDD

//
// Open a project from the levelBuilder - returns True/False
//

function T2DProject::open( %this, %projectName )
{
   error("Deprecated LBProjectObj.open");
   if(%projectName $= "")
      return false;
}



