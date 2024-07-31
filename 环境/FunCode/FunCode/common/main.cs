//---------------------------------------------------------------------------------------------
// Torque Game Builder
// Copyright (C) GarageGames.com, Inc.
//---------------------------------------------------------------------------------------------

//---------------------------------------------------------------------------------------------
// CommonPackage
// Adds functionality for this mod to some standard functions.
//---------------------------------------------------------------------------------------------
package CommonPackage
{
//---------------------------------------------------------------------------------------------
// onStart
// Called when the engine is starting up. Initializes this mod.
//---------------------------------------------------------------------------------------------
function onStart()
{
   Parent::onStart();
      
   // Load preferences.
   exec("./preferences/defaultPrefs.cs");
   execPrefs("commonPrefs.cs");
   
   // Initialise stuff.
   exec("./gameScripts/common.cs");
   initializeCommon();

	exec("./Help.cs");
   
   echo(" % - Initialized Common");
   
}

//---------------------------------------------------------------------------------------------
// onExit
// Called when the engine is shutting down. Shutdowns this mod.
//---------------------------------------------------------------------------------------------
function onExit()
{   
   // THB: I'm not sure that we should really be exporting prefs in common, since they get exported
   // by the various mods so this is just pointless duplicate data.
   echo("Exporting TGB preferences.");
   export("$pref::*", "commonPrefs.cs", false);
   
   // Shutdown stuff.
   shutdownCommon();

   Parent::onExit();
}

function loadKeybindings()
{
   $keybindCount = 0;
   // Load up the active projects keybinds.
   if(isFunction("setupKeybinds"))
      setupKeybinds();
}

//---------------------------------------------------------------------------------------------
// displayHelp
// Prints the command line options available for this mod.
//---------------------------------------------------------------------------------------------
function displayHelp() {
   // Let the parent do its stuff.
   Parent::displayHelp();

   error("Common Mod options:\n" @
         "  -fullscreen            Starts game in full screen mode\n" @
         "  -windowed              Starts game in windowed mode\n" @
         "  -autoVideo             Auto detect video, but prefers OpenGL\n" @
         "  -openGL                Force OpenGL acceleration\n" @
         "  -directX               Force DirectX acceleration\n" @
         "  -voodoo2               Force Voodoo2 acceleration\n" @
         "  -prefs <configFile>    Exec the config file\n");
}

//---------------------------------------------------------------------------------------------
// parseArgs
// Parses the command line arguments and processes those valid for this mod.
//---------------------------------------------------------------------------------------------
function parseArgs()
{
   // Let the parent grab the arguments it wants first.
   // [neo, 28/6/2007]
   // root main.cs checks for if( parseArgs() ) so we should return something
   if( !Parent::parseArgs() )
      return false;

   // Loop through the arguments.
   for (%i = 1; %i < $Game::argc; %i++)
   {
      %arg = $Game::argv[%i];
      %nextArg = $Game::argv[%i+1];
      %hasNextArg = $Game::argc - %i > 1;
   
      switch$ (%arg)
      {
         case "-fullscreen":
            $pref::Video::fullScreen = 1;
            $argUsed[%i]++;

         case "-windowed":
            $pref::Video::fullScreen = 0;
            $argUsed[%i]++;

         case "-openGL":
            $pref::Video::displayDevice = "OpenGL";
            $argUsed[%i]++;

         case "-directX":
            $pref::Video::displayDevice = "D3D";
            $argUsed[%i]++;

         case "-voodoo2":
            $pref::Video::displayDevice = "Voodoo2";
            $argUsed[%i]++;

         case "-autoVideo":
            $pref::Video::displayDevice = "";
            $argUsed[%i]++;

         case "-prefs":
            $argUsed[%i]++;
            if (%hasNextArg) {
               exec(%nextArg, true, true);
               $argUsed[%i+1]++;
               %i++;
            }
            else
               error("Error: Missing Command Line argument. Usage: -prefs <path/script.cs>");
      }
   }
   
   // [neo, 28/6/2007]
   // root main.cs checks for if( parseArgs() ) so we should return something
   return true;
}

};

activatePackage(CommonPackage);

