//
// <TorsionProject>
//    <Name>MyGameName</Name>
//    <WorkingDir/>
//    <EntryScript>main.cs</EntryScript>
//    <Mods/>
//    <ScannerExts>cs; gui</ScannerExts>
//    <Configs>
//       <Config>
//          <Name>Release</Name>
//          <Executable>TGBGame.exe</Executable>
//          <Arguments/>
//          <HasExports>true</HasExports>
//          <Precompile>true</Precompile>
//          <InjectDebugger>true</InjectDebugger>
//          <UseSetModPaths>false</UseSetModPaths>
//       </Config>
//    </Configs>
//    <SearchURL/>
//    <SearchProduct>TGB</SearchProduct>
//    <SearchVersion>HEAD</SearchVersion>
//    <ExecModifiedScripts>true</ExecModifiedScripts>
// </TorsionProject>

function t2dTorsion::copyProject( %path, %projectName, %projectBinaries )
{
   // Make sure we do nothing on macs as Torsion doesn't run on there
   if( $platform $= "macos" )
      return;
      
   // Torsion project filename   
   %fname = %path @ "Game.torsion";
   
   // Lets not waste a perfectly good xml object just write out xml by hand
   if( isWriteableFileName( %fname ) )
   {
      // Open file for writing
      %fs = new FileObject();
      
      if( %fs.openForWrite( %fname ) )
      {
         // If we are copying game binaries to project dir we rename 
         // the game exe to the game name so tell torsion to use that.
         %exeName = %projectBinaries ? %projectName : "TGBGame";
         %exeName = %exeName @ ".exe";
         
         // Write the project xml
         %fs.writeLine( "<TorsionProject>" );
         %fs.writeLine( "<Name>" @ %projectName @ "</Name>" );
         %fs.writeLine( "<WorkingDir/>" );
         %fs.writeLine( "<EntryScript>main.cs</EntryScript>" );
         %fs.writeLine( "<Mods/>" );
         %fs.writeLine( "<ScannerExts>cs; gui</ScannerExts>" );
         %fs.writeLine( "<Configs>" );
         %fs.writeLine( "<Config>" );
         %fs.writeLine( "<Name>Release</Name>" );
         %fs.writeLine( "<Executable>" @ %exeName @ "</Executable>" );
         %fs.writeLine( "<Arguments/>" );
         %fs.writeLine( "<HasExports>true</HasExports>" );
         %fs.writeLine( "<Precompile>true</Precompile>" );
         %fs.writeLine( "<InjectDebugger>true</InjectDebugger>" );
         %fs.writeLine( "<UseSetModPaths>false</UseSetModPaths>" );
         %fs.writeLine( "</Config>" );
         %fs.writeLine( "</Configs>" );
         %fs.writeLine( "<SearchURL/>" );
         %fs.writeLine( "<SearchProduct>TGB</SearchProduct>" );
         %fs.writeLine( "<SearchVersion>HEAD</SearchVersion>" );
         %fs.writeLine( "<ExecModifiedScripts>true</ExecModifiedScripts>" );
         %fs.writeLine( "</TorsionProject>" );

         
         %fs.close();
      }
      
      %fs.delete();
   }
}