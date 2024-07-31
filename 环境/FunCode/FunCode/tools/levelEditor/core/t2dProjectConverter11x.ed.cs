function import11XGames() 
{
   messageBox( "Please Excuse our Dust", "This functionality is currently disabled, we apologize for any inconvenience.", "Ok", "Information");
   return;
   %dlg = new OpenFileDialog()
   {
      Title = "Import 1.1.X Installation";
      DefaultFile = expandFilename("^game/TGB.exe");
      Filters = "TGB 1.1.x Executable (TGB.exe)|TGB.exe|All Executables (*.exe)|*.exe|";
      MustExist = true;
      MultipleFiles = false;
   };
 
   %dlg.DefaultPath = getCurrentDirectory();
      
   %cancel = ( !%dlg.Execute() );
   if( %cancel == false ) 
      %file = %dlg.FileName;
      
   %dlg.delete();
   
   if( %cancel )
      return false;

   %basePath = filePath( %file );
   
   // Add this path as a resource path to be accesible
   %pathExpr = %basePath @ "/*";
   addResPath( %pathExpr );
   
   // Set our expando
   setScriptPathExpando("_pcBasePath", %basePath, true);
         
   %projects = getDirectoryList( %basePath );
   %projectCount = getFieldCount( %projects );
   
   for( %i = 0; %i < %projectCount; %i++ )
   {
      %projectName = getfield( %projects, %i );
      %projectPath = expandFilename("^_pcBasePath/" @ %projectName );
            
      %projectObject = Projects::GetProjectByPath( %projectPath, %projectName );
      
      // If this project is identified, convert it
      if( isObject( %projectObject ) )
         %projectObject.ConvertToCurrent();
   }
   
   // Remove the expando
   removeScriptPathExpando("_pcBasePath");

   // Remove Res Path
   removeResPath(%pathExpr);
}


function Projects::GetProjectByPath( %fullPath, %projectName )
{
   // Testing - JDD
   return new ScriptObject() 
   { 
      class = "ProjectObject"; 
      ProjectType="T2DProject"; 
      fullPath = %fullPath;
      projectName = %projectName;
   };   
}

// A user may register as many project types as they like of the same name to support
// multiple version compliance of the same type.  However, a register will fail if you
// attempt to register a type with the same name and version, even if you specify a 
// different type factory
function Projects::RegisterProjectType( %projectTypeName, 
                                        %projectTypeFactory,
                                        %projectVersion )
{
   error("Empty Body");
}

function Projects::GetProjectByFile( %fullPathToFile )
{  
   error("Empty Body"); 
}

function ProjectObject::ConvertToCurrent( %this )
{
   // Hardcoded 113 type for testing
   if( %this.ProjectType !$= "T2DProject" )
      return false;
      
   %projectFile = %this.fullPath @ "/managed/project.t2d";
   %datablockFile = %this.fullPath @ "/managed/datablocks.cs";
   
   // project.t2d and datablocks.cs must exist
   if( !isFile( %projectFile ) || !isFile( %datablockFile ) )
      return false;

   // Resolve paths from 1.1.x conventions
   %this.ResolveDatablockPaths( %datablockFile, %this.projectName );
   
   // force overwrite
   %ok = pathCopy( %this.fullPath , %this.fullPath @ "/game/", false);
   if(! %ok)
      return false;
      
   // delete the source file.
   %ok = fileDelete( %this.fullPath );
   if(! %ok)
      return false;
   
   %templates = expandFilename("^tools/projectWizard/templates/");
   %gameLocation = %this.fullPath @ "/";
   
   // Common Hierarchy
   //  force overwrite
   pathCopy( expandFilename("^tool/common"), %gameLocation @ "common/", false );
   // Main Script
   pathCopy( %templates @ "main_template.cs", %gameLocation @ "main.cs" );
   // Project
   
   //pathCopy( %templates @ "project.funProj", %gameLocation @ "project.funProj" );
   // Player
   pathCopy( %templates @ "TGBGame.exe" , %gameLocation @ %this.projectName @ ".exe" );
   // Audio
   pathCopy( expandFileName("^tool/OpenAL32.dll"), %gameLocation @ "OpenAL32.dll" );
   // Video
   if( isDebugBuild() )
   {
      pathCopy( expandFileName("^tool/glu2d3d_Debug.dll"), %gameLocation @ "glu2d3d_Debug.dll" );
      pathCopy( expandFileName("^tool/opengl2d3d_Debug.dll"), %gameLocation @ "opengl2d3d_Debug.dll" );          
   }
   else
   {
      pathCopy( expandFileName("^tool/glu2d3d.dll"), %gameLocation @ "glu2d3d.dll" );
      pathCopy( expandFileName("^tool/opengl2d3d.dll"), %gameLocation @ "opengl2d3d.dll" );          
   }        
   
   return true;
   
}

///
function ProjectObject::ResolveDatablockPaths( %this, %datablockFile, %projectName )
{
   %fileObject = new FileObject();
   %fileObject.openForRead( %datablockFile );
   
   // Iterate over 11x lines which stored image paths relative to root directory
   // root directory is now variable so we just replace with ../
   //
   // From : GameName/Data/
   // To   : ../Data/
   %lines = 0;
   %projectName = fileBase( %projectName );
   while( !%fileObject.isEOF() )
   {
      %line = %fileObject.readLine();
      %newFileLines[ %lines++ ] = strreplace( %line, "= \"" @ %projectName @ "/", "= \"../" );
   }
   
   %fileObject.close();
   %fileObject.delete();
   
   // Backup Old file
   //  force overwrite
   pathCopy( %datablockFile, %datablockFile @ ".backup", false );

   %fileObject = new FileObject();
   %fileObject.openForWrite( %datablockFile );

   // Write new file
   for( %i = 0; %i < %lines + 1; %i++ )
      %fileObject.writeLine( %newFileLines[%i] );
      
   %fileObject.close();
   %fileObject.delete();
      
}

///
function ProjectObject::ResolveLevelPaths( %this, %datablockFile, %projectName )
{
   %fileObject = new FileObject();
   %fileObject.openForRead( %datablockFile );
   
   // Iterate over 11x lines which stored image paths relative to root directory
   // root directory is now variable so we just replace with ../
   //
   // From : GameName/Data/
   // To   : ../Data/
   %lines = 0;
   %projectName = %projectName;
   while( !%fileObject.isEOF() )
   {
      %line = %fileObject.readLine();
      %newFileLines[ %lines++ ] = strreplace( %line, "= \"" @ %projectName @ "/", "= \"../" );
   }
   
   %fileObject.close();
   %fileObject.delete();
   
   // Backup Old file
   //  force overwrite
   pathCopy( %datablockFile, %datablockFile @ ".backup", false );

   %fileObject = new FileObject();
   %fileObject.openForWrite( %datablockFile );

   // Write new file
   for( %i = 0; %i < %lines; %i++ )
      %fileObject.writeLine( %newFileLines[%i] );
      
   %fileObject.close();
   %fileObject.delete();
      
}