//---------------------------------------------------------------------------------------------
// Torque Game Builder
// Copyright (C) GarageGames.com, Inc.
//---------------------------------------------------------------------------------------------

// The name of the company. Used to form the path to save preferences. Defaults to GarageGames
// if not specified.
// The name of the game. Used to form the path to save preferences. Defaults to C++ engine define TORQUE_GAME_NAME
// if not specified.
setCompanyAndProduct("FunCode", "FunCode");


$Scripts::ignoreDSOs = false;

//---------------------------------------------------------------------------------------------
// displayHelp, parseArgs, onStart, and onExit should be redefined by mod packages that need to
// display help information, handle command line arguments, or hook into the startup and
// shutdown of the engine.
//---------------------------------------------------------------------------------------------
function onStart()
{
}

function onExit()
{
}

function parseArgs()
{
   for (%i = 1; %i < $Game::argc; %i++)
   {
      // Grab the argument.
      %arg = $Game::argv[%i];
      // Grab the next argument for those args that require parameters.
      %nextArg = $Game::argv[%i + 1];
      // Check if there is another argument.
      %hasNextArg = $Game::argc - %i > 1;

      // Handle the argument.
      switch$ (%arg)
      {
         // Dump the console docs.
         case "-dumpDocs":
            $argUsed[%i]++;
            if (%hasNextArg)
            {
               $dumpDocs = %nextArg;
               $argUsed[%i + 1]++;
               %i++;
               
               return true; //
            }
            else
               error("Error: Missing Command Line argument. Usage: -dumpDocs <filename>");
         
         // Set the console logging mode.
         case "-log":
            $argUsed[%i]++;
            if (%hasNextArg)
            {
               if (%nextArg != 0)
                  %nextArg += 4;

               setLogMode(%nextArg);
               $logModeSpecified = true;
               $argUsed[%i + 1]++;
               %i++;
            }
            else
               error("Error: Missing Command Line argument. Usage: -log <Mode: 0,1,2>");


         // Add an additional mod.
         case "-mod":
            // Handled by the setupMods function.

         case "-remove":  
            if( $platform $= "windows" )
            {
               %tgbr = new TGBRegistryManager();
               if( isObject( %tgbr ) )
               {
                  %tgbr.removeFileAssociations();            
                  %tgbr.unregisterExecutablePaths();
                  %tgbr.delete();
               }
            }
            quit();
            return false;
         // Change the default game.         
         case "-game":         
            $argUsed[%i]++;
            if (%hasNextArg)
            {              
               $Pref::startupProject = %nextArg;
               $startupProject = %nextArg;
               $argUsed[%i + 1]++;
               %i++;
            }
            else
               error("Error: Missing Command Line argument. Usage: -game <game_name>");
               
         case "-project":  // [neo, 6/3/2007 - #3168]         
            $argUsed[%i]++;
            if (%hasNextArg)
            {              
               $Pref::startupProject = %nextArg;
               $startupProject = %nextArg;
               $argUsed[%i + 1]++;
               %i++;
            }
            else
               error("Error: Missing Command Line argument. Usage: -project <game_name>");

      
         // Start up with a console window.
         case "-console":
            enableWinConsole(true);
            $argUsed[%i]++;

         // Save a journal of this run of the engine.
         case "-jSave":
            $argUsed[%i]++;
            if (%hasNextArg)
            {
               echo("Saving event log to journal: " @ %nextArg);
               saveJournal(%nextArg);
               $argUsed[%i + 1]++;
               %i++;
            }
            else
               error("Error: Missing Command Line argument. Usage: -jSave <journal_name>");


         // Play back a previously recorded journal.
         case "-jPlay":
            $argUsed[%i]++;
            if (%hasNextArg)
            {
               playJournal(%nextArg, false);
               $argUsed[%i+1]++;
               %i++;
            }
            else
               error("Error: Missing Command Line argument. Usage: -jPlay <journal_name>");


         // Play back a previously recorded journal in debug mode.
         case "-jDebug":
            $argUsed[%i]++;
            if (%hasNextArg)
            {
               playJournal(%nextArg, true);
               $argUsed[%i + 1]++;
               %i++;
            }
            else
               error("Error: Missing Command Line argument. Usage: -jDebug <journal_name>");


         // Display the command line help.
         case "-help":
            $displayHelp = true;
            $argUsed[%i]++;
      }
   }
   
   return true;
}

package Help
{
   function onExit()
   {
      // When the help is being displayed, the game never started up, so with this we make sure
      // no superfluous shutdown and cleanup takes place.
   }
};

function displayHelp()
{
   // Activate the Help Package.
   activatePackage(Help);

   error(
   "TGB command line options:\n"@
   "  -dumpDocs <filename>   Dump the console docs to the specified file\n"@
   "  -log <logmode>         Logging behavior; see main.cs comments for details\n"@
   "  -game <game_name>      Reset list of mods to only contain <game_name>\n"@
   "  -mod <mod_name>        Add <mod_name> to list of mods\n"@
   "  -console               Open a separate console\n"@
   "  -jSave  <file_name>    Record a journal\n"@
   "  -jPlay  <file_name>    Play back a journal\n"@
   "  -jDebug <file_name>    Play back a journal and issue an int3 at the end\n"@
   "  -help                  Display this help message\n"
   );
}

// Defaults that command line arguments may overwrite.
$displayHelp = false;
$logModeSpecified = false;
$dumpDocs = "";

$Scripts::OverrideDSOPath = expandFilename( "" );
//---------------------------------------------------------------------------------------------
// Load the paths we need access to
//---------------------------------------------------------------------------------------------
function loadPath( %path )
{
   addResPath( %path );
   exec(%path @ "/main.cs");

}
loadPath( "common" );
loadPath( "tools" );

//---------------------------------------------------------------------------------------------
// Always log mode 6 for now   
//---------------------------------------------------------------------------------------------
setLogMode(6);

if( parseArgs() )
{
   
   if ($dumpDocs !$= "")
   {
      // To get the script docs dumped, we need to first exec the scripts, but
      // this is going to require some careful handling, so commenting out for now.
      //%spec = "*.cs";
      //for (%file = findFirstFile(%spec); %file !$= ""; %file = findNextFile(%spec))
         //exec(%file);
      
      new ConsoleLogger(logger, $dumpDocs, false);
      dumpConsoleFunctions();
      dumpConsoleClasses();
      logger.delete();
      quit();
   }

   //---------------------------------------------------------------------------------------------
   // Either display the help message or startup the application.
   //---------------------------------------------------------------------------------------------
   else if ($displayHelp)
   {
      enableWinConsole(true);
      displayHelp();
      quit();
   }
   else
   {
      onStart();
      echo("\nFunCode (" @ getT2DVersion() @ ") initialized...");
            
      if( isFile( %projectFile ) )
      {
         Projects::GetEventManager().postEvent( "_ProjectOpen", $pref::startupProject );
         $pref::startupProject = "";
      }      
      else 
      // [neo, 6/3/2007 - #3168]                        
      if( $startupProject !$= "" ) 
      {         
         Projects::GetEventManager().postEvent( "_ProjectOpen", $startupProject );
         $startupProject = "";
      }
      else if($pref::startupProject !$= "")
      {
         Projects::GetEventManager().postEvent( "_ProjectOpen", $Pref::startupProject );
         $pref::startupProject = "";
      }
      else 
      //[neo, 4/6/2007 - #3192]
      // Need to tell it to reload too
      if( $pref::loadLastProject || $pref::reloadLastProject && ($pref::lastProject !$= ""))
      {
         Projects::GetEventManager().postEvent( "_ProjectOpen", $pref::lastProject );
         
         //[neo, 4/6/2007 - #3192]
         $pref::reloadLastProject = false;
      }
   }
}
else
   quit();


// Script Override path may not be set until we hit this point or it will be erased, by design.
$Scripts::OverrideDSOPath = "";


function MainOpenProject(%projectFile)
{
   Projects::GetEventManager().postEvent( "_ProjectOpen", %projectFile);
}

