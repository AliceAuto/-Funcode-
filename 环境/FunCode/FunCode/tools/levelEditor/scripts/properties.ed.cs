//
// Save config data
//
function _saveGameConfigurationData( %projectFile )
{
   %xml = new ScriptObject() { class = "XML"; };
   if( %xml.beginWrite( %projectFile ) )
   {
      %xml.writeClassBegin( "TorqueGameConfiguration" );
         %xml.writeField( "Company", $Project::Game::CompanyName );
         %xml.writeField( "GameName", $Project::Game::ProductName );
         %xml.writeField( "Resolution", $Project::Game::Resolution );
         %xml.writeField( "FullScreen", $Project::Game::FullScreen );
         %xml.writeField( "CommonVer", $Project::Game::CommonVersion );
         //%xml.writeField( "ConsoleKey", $Project::Game::ConsoleBind );
         %xml.writeField( "ScreenShotKey", $Project::Game::ScreenshotBind );
         %xml.writeField( "FullscreenKey", $Project::Game::FullscreenBind );
         %xml.writeField( "UsesNetwork", $Project::Game::UsesNetwork );
         %xml.writeField( "UsesAudio", $Project::Game::UsesAudio );
         %xml.writeField( "DefaultScene", $Project::Game::DefaultScene );
      %xml.writeClassEnd();
      %xml.endWrite();
   }   
   else
   {
      error( "saveGameConfigurationData - Failed to write to file: " @ %projectFile );
      return false;
   }
   
   // Delete the object
   %xml.delete();
   
   return true;
}

//
// Load config data
//
function _loadGameConfigurationData( %projectFile )
{
   %xml = new ScriptObject() { class = "XML"; };
   if( %xml.beginRead( %projectFile ) )
   {
      if( %xml.readClassBegin( "TorqueGameConfiguration" ) )
      {
         $Project::Game::CompanyName    = %xml.readField( "Company" );
         $Project::Game::ProductName    = %xml.readField( "GameName" );

         $Project::Game::Resolution     = %xml.readField( "Resolution" );
         $Project::Game::FullScreen     = %xml.readField( "FullScreen" );

         $Project::Game::CommonVersion  = %xml.readField( "CommonVer" );

         //$Project::Game::ConsoleBind    = %xml.readField( "ConsoleKey" );
         $Project::Game::ScreenshotBind = %xml.readField( "ScreenShotKey" );
         $Project::Game::FullscreenBind = %xml.readField( "FullscreenKey" );

         $Project::Game::UsesNetwork    = %xml.readField( "UsesNetwork" );
         $Project::Game::UsesAudio      = %xml.readField( "UsesAudio" );

         $Project::Game::DefaultScene   = %xml.readField( "DefaultScene" );
         %xml.readClassEnd();
      }
      else
         _defaultGameConfiguration();
         
      %xml.endRead();
   }
   else
      _defaultGameConfigurationData();
   
   // Delete the object
   %xml.delete();
}

//
// Load config data
//
function _defaultGameConfigurationData()
{
   $Project::Game::CompanyName      = "Independent";
   $Project::Game::ProductName      = "Untitled Game";
   $Project::Game::Resolution       = "800 600 32";
   $Project::Game::FullScreen       = "false";
   $Project::Game::ConsoleBind      = "ctrl tilde"; // [neo, 5/24/2007 - #2986]
   $Project::Game::ScreenshotBind   = "ctrl p";
   $Project::Game::FullscreenBind   = "alt enter";
   $Project::Game::UsesNetwork      = false;
   $Project::Game::UsesAudio        = true;
   $Project::Game::DefaultScene     = "~/data/levels/untitled.t2d";
}
