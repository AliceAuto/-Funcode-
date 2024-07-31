//---------------------------------------------------------------------------------------------
// Torque Game Builder
// Copyright (C) GarageGames.com, Inc.
//---------------------------------------------------------------------------------------------

//---------------------------------------------------------------------------------------------
// initializeCommon
// Initializes common game functionality.
//---------------------------------------------------------------------------------------------
function initializeCommon()
{
   // Not Reentrant
   if( $commonInitialized == true )
      return;
      
   // Common keybindings.
   // [neo, 5/24/2007 - #2986]
   // GlobalActionMap doesn't get preference anymore so need special sequence to toggle console.
   // This also allows ~ to be used in the console now ;p   
   GlobalActionMap.bind(keyboard, "ctrl tilde", toggleConsole);
   GlobalActionMap.bind(keyboard, "ctrl p", doScreenShot);
   GlobalActionMap.bindcmd(keyboard, "alt k", "cls();",  "");
   
   // Very basic functions used by everyone.
   exec("./audio.cs");
   exec("./canvas.cs");
   exec("./cursor.cs");

   // Seed the random number generator.
   setRandomSeed();
   // Set up networking.
   setNetPort(0);
   // Initialize the canvas.
   initializeCanvas("FunCode");
   // Start up the audio system.
   initializeOpenAL();
   
   // Content.
   exec("~/gui/profiles.cs");
   exec("~/gui/cursors.cs");

   // Common Guis.
   exec("~/gui/options.gui");
   exec("~/gui/remap.gui");
   exec("~/gui/console.gui");
   
   // Gui Helper Scripts.
   exec("~/gui/help.cs");


   // Random Scripts.
   exec("./screenshot.cs");
   exec("./metrics.cs");
   exec("./scriptDoc.cs");
   exec("./keybindings.cs");
   exec("./options.cs");
   exec("./levelManagement.cs");
   exec("./align.cs");
   
   // Behaviors
   exec("./helperfuncs.cs");
   exec("./behaviorManagement.cs");

   
   // Set a default cursor.
   Canvas.setCursor(DefaultCursor);
   
   activatePackage(KeybindPackage);
   loadKeybindings();
   deactivatePackage(KeybindPackage);

   $commonInitialized = true;

}

//---------------------------------------------------------------------------------------------
// shutdownCommon
// Shuts down common game functionality.
//---------------------------------------------------------------------------------------------
function shutdownCommon()
{      
   shutdownOpenAL();
}

//---------------------------------------------------------------------------------------------
// dumpKeybindings
// Saves of all keybindings.
//---------------------------------------------------------------------------------------------
function dumpKeybindings()
{
   // Loop through all the binds.
   for (%i = 0; %i < $keybindCount; %i++)
   {
      // If we haven't dealt with this map yet...
      if (isObject($keybindMap[%i]))
      {
         // Save and delete.
         $keybindMap[%i].save(getPrefsPath("bind.cs"), %i == 0 ? false : true);
         $keybindMap[%i].delete();
      }
   }
}
