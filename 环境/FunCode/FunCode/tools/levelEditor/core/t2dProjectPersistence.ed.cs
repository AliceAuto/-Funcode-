//---------------------------------------------------------------------------------------------
// Torque Game Builder
// Copyright (C) GarageGames.com, Inc.
//---------------------------------------------------------------------------------------------

exec( expandFilename( "^tools/persistence/xml.ed.cs" ) );

//
// Save the project
//
function T2DProject::SaveProject( %this, %projectFile )
{
   %projectDir = expandFilename("^project/");
   %lastLevel = getSubStr(%this.currentLevelFile, strlen(%projectDir), strlen(%this.currentLevelFile));
   
   %xml = new ScriptObject() { class = "XML"; };
   if( %xml.beginWrite( %projectFile ) )
   {
      %xml.writeClassBegin( "TorqueProject" );
         %xml.writeField( "Type", "T2DProject" );
         %xml.writeField( "Version", getT2DVersion() );
         %xml.writeField( "MinVersion", "v1.1.4"); // Depends on ATLEAST 1.1.4 projects
         %xml.writeField( "Creator", "Torque Game Builder" );
         %xml.writeField( "LastLevel", "Bin/" @ %lastLevel );
         %xml.writeField( "ProjectName", $FunCodeProjectName );
         %xml.writeField( "ProjectType", $FunCodeProjectType );
	 %xml.writeField( "JavaDevVersion", $levelEditor::DevJAVAVersion );      
         %xml.writeClassEnd();
      %xml.endWrite();
   }
   
   else
   {
      error( "T2DProject::SaveProject - Failed to write to file: " @ %projectFile );
      return false;
   }
   
   // Delete the object
   %xml.delete();
   
   // store the version number
   %this.projectVersion = getT2DVersion();
   
   return true;
}

//
// Load the project
//
function T2DProject::LoadProject( %this, %projectFile )
{
   %JavaDevVersion = "";
   %xml = new ScriptObject() { class = "XML"; };
   if( %xml.beginRead( %projectFile ) )
   {
      if( %xml.readClassBegin( "TorqueProject" ) )
      {
         %type = %xml.readField( "Type" );
         %version = %xml.readField( "Version" );
         %minVersion = %xml.readField( "MinVersion" );
         %creator = %xml.readField( "Creator" );
         %lastLevel = %xml.readField( "LastLevel" );
         $FunCodeProjectName = %xml.readField( "ProjectName" );
         $FunCodeProjectType = %xml.readField( "ProjectType" );
	 %JavaDevVersion = %xml.readField( "JavaDevVersion" );
         %xml.readClassEnd();
      }
      %xml.endRead();
   }
   
   // Delete the object
   %xml.delete();
   
   if( $FunCodeProjectName $= "" )
   {
      $FunCodeProjectName = "DefaultProject";
   }   
   if( $FunCodeProjectType $= "" )
   {
      $FunCodeProjectType = "C";
   }
   
   //
   if( $FunCodeProjectType $= "JAVA" )
   {
      $levelEditor::DevJAVAVersion = %JavaDevVersion;
      //JCreator Eclipse不共存，所以更改启动工程
      if( $levelEditor::DevJAVAVersion $= "JCreator" )
         $levelEditor::StartJAVAVersion = "JCreator";
      else
         $levelEditor::StartJAVAVersion = "Eclipse";

      MainStartProjectBtn.text = "启动Java工程";
      MainSetStartProjectBtn.Visible = 0;
      MainCreateOtherBtn.Visible = 0;
      MainPanelSeparator1.Visible = 0;
   }
   else
   {
      MainStartProjectBtn.text = "启动VC工程";
      MainSetStartProjectBtn.text = "设置启动VC工程";
      MainCreateOtherBtn.text = "创建VC工程";
      MainCreateOtherBtn.Visible = 1;
      MainSetStartProjectBtn.Visible = 1;
      MainPanelSeparator1.Visible = 1;
   }
   
   //error( "T2DProject::LoadProject - Invalid project file: " @ %projectFile );
   if( %type !$= "T2DProject" )
      return false;
   
   //error( "T2DProject::LoadProject - Invalid version number: " @ %version );
   if( %this.compareVersions( %version ,getT2DVersion() ) == -1 )
      return false;

   %this.lastLevel = "";
   if (%lastLevel !$= "")
      %this.lastLevel = filePath(%projectFile) @ "/" @ %lastLevel;
   
   %this.projectFile = %projectFile;
   %this.projectVersion = %version;

   return true;
}


//
// Compare two versions and return  
// -1 indicates the first version is greater
//  0 indicated the versions are identical
//  1 indicated the second version is greater
function T2DProject::CompareVersions( %this,  %version1, %version2 )
{
   %ver1Period = strpos( %version1, "." );
   %ver2Period = strpos( %version2, "." );
   
   if( %ver1Period == -1 || %ver2Period == -1 )
      return 0;
   
   %ver1Float = getSubStr( %version1, %ver1Period + 1, 16 );
   %ver2Float = getSubStr( %version2, %ver2Period + 1, 16 );
   
   if( %ver1Float > %ver2Float )
      return -1;
   else if( %ver1Float < %ver2Float )
      return 1;
   else if( %ver1Float == %ver2Float )
      return 0;
   
   // Call them the same..?
   return 0;
}
//
// Persist managed to disk
//
function T2DProject::persistToDisk( %this, %bDatablocks, %bResources, %bPersistent, %bBrushes )
{
   // Save Persistent Objects  
   if( %bDatablocks == true  )
   {
      %datablocksFile = expandFileName("^game/managed/datablocks.cs");
      %validFiles     = %this.validateManagedSet( $managedDatablockSet, "Datablocks" );
      if( %validFiles &&  isWriteableFileName( %datablocksFile ) )
      {
         %fo = new FileObject();
         if( %fo.openForWrite( %datablocksFile ) )
         {      
            %fo.writeObject($managedDatablockSet, "$managedDatablockSet = ");
            %fo.close();
         }
         %fo.delete();
      }
   }

   if( %bResources == true )
   {
      %resourcePath = expandFilename("^project/resources/");
      %toolsResPath = expandFileName("^tool/resources/");
      %resCount = $dependentResourceGroup.getCount();
      for( %i =0; %i < %resCount; %i++ )
      {
         %resObj = $dependentResourceGroup.getObject( %i );
         
         %gamesSourcePath = %resourcePath @ %resObj.Name;
         %toolsSourcePath = %toolsResPath @ %resObj.Name;
         if( !isFile( %gamesSourcePath @ "/resourceDatabase.cs" ) )
         {
            // Ensure games resource path exists
            createPath( %gamesSourcePath ); 
            // Copy it over
            pathCopy( %toolsSourcePath , %gamesSourcePath );
         }
      }
   }

   if( %bPersistent == true )
   {
      %persistentFiles = expandFileName("^game/managed/persistent.cs");
      %validFiles     = %this.validateManagedSet( $persistentObjectSet, "Persistent" );
      if( %validFiles &&  isWriteableFileName( %persistentFiles ) )
      {
         %fo = new FileObject();
         if( %fo.openForWrite( %persistentFiles ) )
         {      
            %fo.writeObject($persistentObjectSet, "$persistentObjectSet = ");
            %fo.close();
         }
         %fo.delete();
      }
   }
   
   if( %bBrushes == true )
   {
      %brushesFile = expandFileName("^game/managed/brushes.cs");
      %validFile = %this.validateManagedSet( $brushSet, "Brushes" );
      if( %validFile && isWriteableFileName( %brushesFile ) )
      {
         %fo = new FileObject();
         if( %fo.openForWrite( %brushesFile ) )
         {      
            %fo.writeObject($brushSet, "$brushSet = ");
            %fo.close();
         }
         %fo.delete();
      }
   }
}

//
// Validate a managed set
//
function T2DProject::validateManagedSet( %this, %object, %type )
{
   // Must Exist
   if( !isObject( %object ) ) 
      return false;
           
   // Correct Token Type?
   if( %object.setType !$= %type )
      return false;
   
   // Success, it's valid.
   return true;
}


//
// Force a valid token
//
function T2DProject::createValidatorToken( %this, %object, %type )
{
   // Must Exist
   if( !isObject( %object ) ) 
      return false;
   
   // Tag as valid. - This should be improved at some point - JDD
   %object.setType = %type;
   
   // Success, it's now valid.
   return true;
}


function T2DProject::LoadProjectData( %this )
{
   // Managed File Paths
   %resFile = expandFilename("^game/managed/resources.cs");
   %dbFile = expandFilename("^game/managed/datablocks.cs");
   %persistFile = expandFilename("^game/managed/persistent.cs");
   %brushFile = expandFilename("^game/managed/brushes.cs");
   %userDatablockFile = expandFilename("^game/gameScripts/datablocks.cs");
   %userGUIProfileFile = expandFilename("^game/gameScripts/guiProfiles.cs");
   %behaviorsDirectory = expandFilename("^game/behaviors");
   
   // Need to know about various data files.
   addResPath(expandFilename("^game/data"));
   
   //---------------------------------------------------------------------------   
   // Project Resources
   //---------------------------------------------------------------------------
   // --  This MUST be done BEFORE datablocks and persistent objects are loaded.
   %resPath = expandFileName("^project/resources/");
   
   if( !isObject( $dependentResourceGroup ) )
      $dependentResourceGroup = new SimGroup();
   
   %resList = getDirectoryList( %resPath, 0 );
   %resCount = getFieldCount( %resList );
   for( %i = 0; %i < %resCount; %i++ )
   {
      %resName = getField( %resList, %i );
      %resObject = ResourceObject::load( %resPath @ %resName );
      if( !isObject( %resObject ) )
      {
         error(" % Game Resources : FAILED Loading Resource" SPC %resName );
         continue;
      }
      else
         echo(" % Game Resources : Loaded Resource" SPC %resName);
         
      // Create a dependentResourcegroup object
      %entry = new ScriptObject() { Name = %resName; };
      $dependentResourceGroup.add( %entry );
   }
      
   // Mark Set Valid   
   %this.createValidatorToken( $dependentResourceGroup, "Resources" );
   
   //---------------------------------------------------------------------------
   // Managed Datablocks
   //---------------------------------------------------------------------------
   if ( isFile( %dbFile ) || isFile( %dbFile @ ".dso" ) )
      exec( %dbFile );
      
   if( !isObject( $managedDatablockSet ) )   
      $managedDatablockSet = new SimSet();
      
   %this.createValidatorToken( $managedDatablockSet, "Datablocks" );


   //---------------------------------------------------------------------------
   // Managed Persistent Objects
   //---------------------------------------------------------------------------
   if ( isFile( %persistFile ) || isFile( %persistFile @ ".dso" ) )
      exec( %persistFile );
      
   if( !isObject( $persistentObjectSet ) )   
      $persistentObjectSet = new SimSet();
      
   // Mark Set Valid   
   %this.createValidatorToken( $persistentObjectSet, "Persistent" );

   //---------------------------------------------------------------------------
   // Managed Brushes
   //---------------------------------------------------------------------------
   if ( isFile( %brushFile ) || isFile( %brushFile @ ".dso" ) )
      exec( %brushFile );
   
   if( !isObject( $brushSet ) )   
      $brushSet = new SimSet();
      
   // Mark Set Valid   
   %this.createValidatorToken( $brushSet, "Brushes" );
   
   //---------------------------------------------------------------------------
   // Behaviors
   //---------------------------------------------------------------------------
   addResPath(%behaviorsDirectory);

   // Compile all the cs files.
   %behaviorsSpec = %behaviorsDirectory @ "/*.cs";
   for (%file = findFirstFile(%behaviorsSpec); %file !$= ""; %file = findNextFile(%behaviorsSpec))
      exec(%file);
   
   //---------------------------------------------------------------------------
   // User Defined Datablocks to expose to the editor
   //---------------------------------------------------------------------------
   addResPath( %userDatablockFile );   
   if( isFile( %userDatablockFile ) )
      exec( %userDatablockFile );
   
   %this.validateDatablocks();
   
   //---------------------------------------------------------------------------
   // User Defined GUI Profiles to expose to the editor
   //---------------------------------------------------------------------------
   addResPath( %userGUIProfileFile );   
   if( isFile( %userGUIProfileFile ) )
      exec( %userGUIProfileFile );
}

function T2DProject::validateDatablocks(%this)
{
   %killGroup = new SimGroup();
   %count = $managedDatablockSet.getCount();
   for(%i = %count - 1; %i >= 0; %i--)
   {
      %datablock = $managedDatablockSet.getObject(%i);
      if(%datablock.isMethod("getIsValid") && !%datablock.getIsValid())
         %killGroup.add(%datablock);
   }
   
   %count = %killGroup.getCount();
   if(%count > 0)
   {
      %badString = %killGroup.getObject(0).getName();
      for(%i = 1; %i < %count; %i++)
         %badString = %badString NL %killGroup.getObject(%i).getName();
      
      %string = getCountString("This project contains {count} invalid datablock{s}.", %count);
      //messageBox("Invalid Project Data", %string SPC "This is likely because a referenced image file" NL
      //           "was deleted from the project directory. The invalid datablocks are:\n" NL %badString, "Ok");
   }
   
   %killGroup.delete();
}

//
// Datablock Set Manipulators
//

function T2DProject::addDatablock( %this, %datablock, %persistNow )
{
   if ( !isObject($managedDatablockSet) )
      return false;
      
   if( !%this.validateManagedSet( $managedDatablockSet, "Datablocks" ) )
      return false;
      
   if( !$managedDatablockSet.isMember( %datablock ) )
      $managedDatablockSet.add( %datablock );
      
   // Persist if desired
   if( %persistNow == true )
      %this.persistToDisk( true, false, false );

   // Success      
   return true;
}

function T2DProject::removeDatablock( %this, %datablock, %persistNow )
{
   if ( !isObject($managedDatablockSet) )
      return false;
      
   if( !%this.validateManagedSet( $managedDatablockSet, "Datablocks" ) )
      return false;
      
   if( $managedDatablockSet.isMember( %datablock ) )
      $managedDatablockSet.remove( %datablock );
      
   // Persist if desired
   if( %persistNow == true )
      %this.persistToDisk( true, false, false );

   // Success      
   return true;
}

function T2DProject::addBrush( %this, %brush, %persistNow )
{
   if ( !isObject($brushSet) )
      return false;
      
   if ( !%this.validateManagedSet( $brushSet, "Brushes" ) )
      return false;
   
   if ( !$brushSet.isMember( %brush ) )
      $brushSet.add( %brush );
      
   if (%persistNow == true )
      %this.persistToDisk( false, false, false, true );
      
   return true;
}

function T2DProject::removeBrush( %this, %brush, %persistNow )
{
   if ( !isObject($brushSet) )
      return false;
      
   if ( !%this.validateManagedSet( $brushSet, "Brushes" ) )
      return false;
   
   if ( $brushSet.isMember( %brush ) )
      $brushSet.remove( %brush );
      
   if (%persistNow == true )
      %this.persistToDisk( false, false, false, true );
      
   return true;
}


//
// Resources Set Manipulators
//

function T2DProject::addResource( %this, %datablock, %persistNow )
{
   if ( !isObject($dependentResourceGroup) )
      return false;
      
   if( !%this.validateManagedSet( $dependentResourceGroup, "Resources" ) )
      return false;
      
   if( !$dependentResourceGroup.isMember( %datablock ) )
      $dependentResourceGroup.add( %datablock );
      
   // Persist if desired
   if( %persistNow == true )
      %this.persistToDisk( false, true, false );

   // Success      
   return true;

}

function T2DProject::removeResource( %this, %name, %persistNow )
{
   if ( !isObject($dependentResourceGroup) )
      return false;
      
   if( !%this.validateManagedSet( $dependentResourceGroup, "Resources" ) )
      return false;
      
   // Find the object with the specified name.
   %count = $dependentResourceGroup.getCount();
   %object = "";
   for( %i = 0; %i < %count; %i++ )
   {
      %object = $dependentResourceGroup.getObject( %i );
      if( %object.Name $= %name )
         break;
   }
   
   if( isObject( %object) && $dependentResourceGroup.isMember( %object ) )
      $dependentResourceGroup.remove( %object );
      
   // Persist if desired
   if( %persistNow == true )
      %this.persistToDisk( false, true, false );

   // Success      
   return true;   
}

//
// Persistent Object Set Manipulators
//
function T2DProject::addPersistent( %this, %datablock, %persistNow )
{
   if ( !isObject($persistentObjectSet) )
      return false;
      
   if( !%this.validateManagedSet( $persistentObjectSet, "Persistent" ) )
      return false;
      
   if( !$persistentObjectSet.isMember( %datablock ) )
      $persistentObjectSet.add( %datablock );
      
   // Persist if desired
   if( %persistNow == true )
      %this.persistToDisk( false, false, true );

   // Success      
   return true;

}

function T2DProject::removePersistent( %this, %datablock, %persistNow )
{
   if ( !isObject($persistentObjectSet) )
      return false;
      
   if( !%this.validateManagedSet( $persistentObjectSet, "Persistent" ) )
      return false;
      
   if( $persistentObjectSet.isMember( %datablock ) )
      $persistentObjectSet.remove( %datablock );
      
   // Persist if desired
   if( %persistNow == true )
      %this.persistToDisk( false, false, true );

   // Success      
   return true;   
}


function t2dSceneObject::setPersistent(%this, %value)
{
   if( %this.getClassName() $= "t2dTileLayer" )
      return;
   
   if (%value)
      LBProjectObj.addPersistent(%this, true);
   else
      LBProjectObj.removePersistent(%this, true);
}

function t2dSceneObject::getPersistent(%this, %value)
{
   
   if ( !isObject($persistentObjectSet) )
      return false;
      
   if( !LBProjectObj.validateManagedSet( $persistentObjectSet, "Persistent" ) )
      return false;
        
   if ($persistentObjectSet.isMember(%this))
      return true;
   
   return false;
}