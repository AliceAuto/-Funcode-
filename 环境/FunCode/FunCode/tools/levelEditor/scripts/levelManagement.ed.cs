//---------------------------------------------------------------------------------------------
// Torque Game Builder
// Copyright (C) GarageGames.com, Inc.
//---------------------------------------------------------------------------------------------

$currentSceneGraph = "";

$T2D::LevelSpec = "Scene Files (*.t2d)|*.t2d|All Files (*.*)|*.*|";

//---------------------------------------------------------------------------------------------
// New Level 
// Will create a new level after verifying changes to existing level if any.
//---------------------------------------------------------------------------------------------
function T2DProject::newLevel( %this )
{
   if( LevelBuilderUndoManager.getUndoCount() > 0 || LevelBuilderUndoManager.getRedoCount() > 0 )
   {
      %mbResult = checkSaveChanges( fileName(%this.currentLevelFile), true );
      if( %mbResult $= $MRCancel )
         return false;
         
      if( %mbResult $= $MROk )
      {
         if( !isFile( %this.currentLevelFile ) )
            %this.saveLevelAs();
         else
            %this.saveLevel();
      }
   }  

   // Generate valid filename (does not already exist)
   %levelPath = expandFilename("^game/data/levels/");
   %levelName = "untitled";
   if( isFile( %levelPath @ %levelName @ ".t2d" ) )
   {
      // Add numbers starting with 1 until we find a valid one
      %i = 1;
      %fileBase = %levelPath @ %levelName;
      while( isFile( %fileBase @ %i @ ".t2d" ) )
         %i++;
      %levelName = %levelName @ %i;
   }
   %fileName = %levelPath @ %levelName @ ".t2d";
   
   // Make sure we're on selection tool (deactivate active tool so it cleans up)
   LevelBuilderToolManager::setTool( LevelEditorSelectionTool );
   
   // Open the Current SceneGraph, if any.
   %lastWindow = ToolManager.getLastWindow();
   if( ! isObject( %lastWindow ) )
   {
      MessageBoxOk("错误","无法创建新场景，没有场景视窗" );
      return false;
   }
   
   %lastWindow.endLevel();
   
   %oldPosition = "0 0";
   %oldSize = "0 0";
   if( isObject( %lastWindow.getScenegraph() ) )
   {
      %oldPosition = %lastWindow.getScenegraph().cameraPosition;
      %oldSize = %lastWindow.getScenegraph().cameraSize;
   }
   

      
   %lastWindow.scenegraph = new t2dSceneGraph();
   %lastWindow.scenegraph.cameraPosition = "0 0";
   %lastWindow.scenegraph.cameraSize = $levelEditor::DefaultCameraSize;
   %lastWindow.setSceneGraph(%lastWindow.scenegraph);
   
   %lastWindow.setCurrentCameraPosition(%lastWindow.scenegraph.cameraPosition,
                                                   %lastWindow.scenegraph.cameraSize);

   ToolManager.onCameraChanged( %oldPosition, %oldSize, %lastWindow.scenegraph.cameraPosition, %lastWindow.scenegraph.cameraSize );

   $currentSceneGraph = %lastWindow.scenegraph;
   %this.currentLevelFile = %fileName;
   
   // Load the XML config information
   _loadGameConfigurationData(%this.gamePath @ "/common/commonConfig.xml");
                                                   
   // Notify Views of Load
   GuiFormManager::SendContentMessage( $LBSceneViewContent, 0, "updateScenegraph " @ %lastWindow.scenegraph );
   // Notify TreeView of Load
   GuiFormManager::SendContentMessage( $LBTreeViewContent, 0, "openCurrentGraph" );

   %ProjectFullName = expandFileName("^project/");
   %ProjectFullName = filePath(%ProjectFullName);
   %ProjectFullName = filePath(%ProjectFullName);
   setCanvasTitle( fileName(%fileName) @ " - " @ Utf8ToAnsi( %ProjectFullName ) );

   LevelBuilderUndoManager.clearAll();
   
   GuiFormManager::SendContentMessage( $LBQuickEdit, %this, "inspect" );
}

function T2DProject::doSave( %this )
{
   // Open the Current SceneGraph, if any.
   %lastWindow = ToolManager.getLastWindow();
   if( !isObject( %lastWindow ) || !isObject( %lastWindow.getScenegraph() ) )
      return false;
      
   // JDD - Defaulting to Save for this build... I don't get why it 
   //       shouldn't save as part of your level, ideally it wouldn't but
   //       it causes our users more harm to remind them of that inadequacy
   //       by prompting them to say yes to something they have no choice over
   //       if they want their layers and effects in their game.  
   //       [/soapbox]
   if( LevelEditor::getLayerNeedsSave() || LevelEditor::getEffectNeedsSave() )
   {
      // Save 
      LevelEditor::saveAllLayersAndEffects();
      // And Refresh
      GuiFormManager::BroadcastContentMessage( "LevelBuilderSidebarCreate", 0, "refresh" );
   }
   
   // write the font cache
   // rdbhack: this is a hack because its going to force the tool to write
   //   both the tools font cache, and the fonts used for the game when
   //   really all we need to do is write out the fonts the game needs
   populateAllFontCacheRange(32, 255);
   writeFontCache();

   %sceneGraph = %lastWindow.getScenegraph();
   
   // Persist Objects
   if( isObject( $persistentObjectSet ) )
   {
      %count = $persistentObjectSet.getCount();
      for (%i = 0; %i < %count; %i++)
      {
         %obj = $persistentObjectSet.getObject(%i);
         %scenegraph.removeFromScene(%obj);
      }
   }
   
   // Save the Level
   if( isWriteableFileName( %this.currentLevelFile ) )
   {
      %fo = new FileObject();
      if( %fo.openForWrite(%this.currentLevelFile) )
      {
         %fo.writeObject(%scenegraph, "%levelContent = ");
         %fo.close();
      }
      %fo.delete();
   }

   if( isObject( $persistentObjectSet ) )
   {
      // Reload
      %count = $persistentObjectSet.getCount();
      for (%i = 0; %i < %count; %i++)
      {
         %obj = $persistentObjectSet.getObject(%i);
         %scenegraph.addToScene(%obj);
         %obj.setPosition(%obj.getPosition());
      }
   }
   
   // Save the XML config information
   _saveGameConfigurationData(%this.gamePath @ "/common/commonConfig.xml");
   
   $levelEditor::LastLevel = %this.currentLevelFile;
   %this.SaveProject( %this.projectFile );
   
   %ProjectFullName = expandFileName("^project/");
   %ProjectFullName = filePath(%ProjectFullName);
   %ProjectFullName = filePath(%ProjectFullName);
   setCanvasTitle( fileName(%this.currentLevelFile) @ " - " @ Utf8ToAnsi( %ProjectFullName) );
   return true;
}

function T2DProject::saveLevel( %this )
{
   // Make sure we're on selection tool (deactivate active tool so it cleans up)
   LevelBuilderToolManager::setTool( LevelEditorSelectionTool );
      
   if( !isFile( %this.currentLevelFile ) )
   {
      // Try to get a name
      %levelName = %this.getLevelSaveName(%this.currentLevelFile);
      if( %levelName $= "" ) 
         return false;
         
      // Store
      %this.currentLevelFile = %levelName;      
   }
   
   // Save it.
   return %this.doSave();
}

function T2DProject::saveLevelAs( %this )
{
   // Make sure we're on selection tool (deactivate active tool so it cleans up)
   LevelBuilderToolManager::setTool( LevelEditorSelectionTool );
      
   // Try to get a name
   %levelName = %this.getLevelSaveName(%this.currentLevelFile);
   if( %levelName $= "" ) 
      return false;
      
   // Store
   %this.currentLevelFile = %levelName;
   
   // Save it.
   return %this.doSave();
}

function T2DProject::openLevel( %this, %levelName )
{
   // Try to get a name
   if( %levelName $= "" ) 
      %levelName = %this.getLevelOpenName( %this.currentLevelFile );
   if( %levelName $= "" )
   {
      echo("Open level error, level name is empty : " @ %this.currentLevelFile); 
      return false;
   }
      
   %lastWindow = ToolManager.getLastWindow();
   if( !isObject( %lastWindow ) )
      return false;
 
    // Prompt to save changes
   if( LevelBuilderUndoManager.getUndoCount() > 0 || LevelBuilderUndoManager.getRedoCount() > 0 )
   {
      %mbResult = checkSaveChanges( fileName(%this.currentLevelFile), true );
      if( %mbResult $= $MRCancel )
         return false;
         
      if( %mbResult $= $MROk )
         %this.saveLevel();
   }
   
   // Make sure we're on selection tool (deactivate active tool so it cleans up)
   LevelBuilderToolManager::setTool( LevelEditorSelectionTool );  
   
   %oldPosition = "0 0";
   %oldSize = "0 0";
   if( isObject( %lastWindow.getScenegraph() ) )
   {
      %oldPosition = %lastWindow.getScenegraph().cameraPosition;
      %oldSize = %lastWindow.getScenegraph().cameraSize;
   }

   %scenegraph = %lastWindow.loadLevel(%levelName);
   
   if (isObject(%scenegraph))
   {
      %this.currentLevelFile = %levelName;
      %this.currentSceneGraph = %scenegraph;
      $currentSceneGraph = %scenegraph;

      // Notify Views of Load
      GuiFormManager::SendContentMessage( $LBSceneViewContent, 0, "updateScenegraph " @ %scenegraph );
      // Notify TreeView of Load
      GuiFormManager::SendContentMessage( $LBTreeViewContent, 0, "openCurrentGraph" );
      
      showTriggers(%scenegraph);
   }
   else
      return false;
   
   // Load the XML config information
   _loadGameConfigurationData(%this.gamePath @ "/common/commonConfig.xml");
   
   $levelEditor::LastLevel = %this.currentLevelFile;

   LevelBuilderUndoManager.clearAll();
   
   ToolManager.onCameraChanged( %oldPosition, %oldSize, %scenegraph.cameraPosition, %scenegraph.cameraSize );
   
   
   %ProjectFullName = expandFileName("^project/");
   %ProjectFullName = filePath(%ProjectFullName);
   %ProjectFullName = filePath(%ProjectFullName);
   setCanvasTitle( fileName( %this.currentLevelFile ) @ " - " @ Utf8ToAnsi( %ProjectFullName ) );   
   GuiFormManager::SendContentMessage( $LBQuickEdit, %this, "inspect" );
   
   return true;
}

function addToLevelCallback(%filename)
{
   %lastWindow = ToolManager.getLastWindow();
   if( !isObject( %lastWindow ) )
   {
      error("loadLevelCallback - No Valid Window!");
      return false;
   }

   %scenegraph = %lastWindow.addToLevel(%filename);

   // Notify TreeView of Load
   GuiFormManager::SendContentMessage( $LBTreeViewContent, 0, "openCurrentGraph" );
   
   showTriggers(%scenegraph);
}

function showTriggers(%scenegraph)
{
   %count = %scenegraph.getSceneObjectCount();
   for (%i = 0; %i < %count; %i++)
   {
      %obj = %scenegraph.getSceneObject(%i);
      if( !isObject( %obj ) ) 
         continue;
      if ((%obj.getClassName() $= "t2dSceneObject") || (%obj.getClassName() $= "t2dTrigger") || (%obj.getClassname() $= "t2dPath"))
         %obj.setDebugOn(1);
   }
}

function onExecuteDone(%thing)
{   
   $runningGame = false;
   
   if( $FunCodeProjectType !$= "JAVA" )
      restoreWindow();
   
   // position the cursor at the center of the editor
   %centerPos = levelBuilderContentFrame.getCenter();
   %posX = getWord(%centerPos, 0);
   %posY = getWord(%centerPos, 1);
   
   // rdbnote: this will prevent the re-launch bug
   // change the cursor position
   Canvas.setCursorPos(%posX, %posY);  
   
   // rdbnote: keeping this here since it may help prevent
   // the user from double clicking the play button
   schedule( 1000, 0, "resetPlayButton" );
}

function resetPlayButton()
{
   $PlayGameButton.setActive( true );
}

// [neo, 4/6/2007 - #3167]
// Get the project name from the project path
function getProjectNameFromPath()
{
   // As name is not stored but implicit in path we just rip it from there
   %path = LBProjectObj.gamePath;
   
   if( %path !$= "" )
   {      
      // Replace forward slashes with spaces so we can use getWord but
      // first replace spaces with invalid/unlikely character sequence
      // in case we have spaces in the path or project name and just 
      // restore spaces after (if any). Rather pedantic but this will
      // catch irregular paths and filenames as well as those with spaces.
      %tmp = strreplace( %path, " ", "&$" );
      %tmp = strreplace( %tmp, "/", " " );      
      %cnt = getWordCount( %tmp );   
      %n   = getWord( %tmp, %cnt - 1 );
      %n   = strreplace( %n, "&$", " " );
   }
   else
      %n = "";
   
   return %n;
}

// [neo, 4/6/2007 - #3167]
// Return the player file to execute
function getGameExecutableFile()
{  
   // Don't look for custom game on mac
   if( $platform !$= "macos" )
   {
      %gname = "Game";//getProjectNameFromPath();      
      %gfile = expandFileName( "^project/" @ %gname @ ".exe" );
         
      // If it exists use it...
      if( isFile( %gfile ) )
         return %gfile;
   }
   
   return $LB::PlayerExecutable;
}

function getGameExecutableFileBat()
{  
   // Don't look for custom game on mac
   if( $platform !$= "macos" )
   {
      %gname = "Game";//getProjectNameFromPath();      
      %gfile = expandFileName( "^project/" @ %gname @ ".bat" );
         
      // If it exists use it...
      if( isFile( %gfile ) )
         return %gfile;
   }
   
   return $LB::PlayerExecutable;
}

function runGame()
{
   if(! isObject(LBProjectObj))
   {
      error("runGame - No project loaded");
      echo("RunGame Error 1");
      return;
   }
   
   if( $FunCodeProjectType $= JAVA )
   {       
      %playerExecutable = getGameExecutableFileBat();
      
      if( %playerExecutable $= "" || !isFile( %playerExecutable ) )
      {
         messageBox("运行游戏", "无法找到执行文件:" NL %playerExecutable, "确定", "停止");
         echo("RunGame Error 2");
         return;
      }
   }
   else
   {   
      // [neo, 4/6/2007 - #3167]
      // If a game executable exists in the game path run that, otherwise
      // run the default game executable. (Not on mac though)   
      %playerExecutable = getGameExecutableFile();
         
      if( %playerExecutable $= "" || !isFile( %playerExecutable ) )
      {
         messageBox("运行游戏", "无法找到执行文件:" NL %playerExecutable, "确定", "停止");
         echo("RunGame Error 3");
         return;
      }
   }

   if( LevelBuilderUndoManager.getUndoCount() > 0 || LevelBuilderUndoManager.getRedoCount() > 0 )
   {
      if( !LBProjectObj.saveLevel() )
      {
         echo("RunGame Error 4");
         return false;
      }
   }
   
   // check for out of date project
   //if (!LBprojectObj.promptUpdate())
   //   return false;
           
   // Post pre-run deploy event 
   Projects::GetEventManager().postEvent( "ProjectDeploy", expandFileName( "^project" ) );
      
   $runningGame = true;
   
   if( $FunCodeProjectType !$= "JAVA" )
      minimizeWindow();
   
   //[neo, 4/6/2007 - #3208]
   // Make sure that any button mouse events or mouselock is not actioned again
   // afterwards for some reason.
   $ThisControl.setActive( false );
   
   $PlayGameButton = $ThisControl;
   
   // Stop Sim entirely?
   //$timeScale = 0.0;
   //setT2DSimTimeScale( 0.0 );
   
   %args = "-project" SPC "\"" @ expandFilename("^project/") @ "\"";
   
   echo("RunGame Exe : " @ %playerExecutable @ ", Args : " @ %args);
   
   if( !shellExecute( %playerExecutable, %args, expandFilename("^project/")) )
      echo("RunGame Error 5");

}


$runningGame = false;
$ScriptErrorMessageHash = 999;
function checkForScriptErrors()
{
   if ($levelEditor::DisplayScriptErrors == false)
   {
      $ScriptErrorMessageHash = $ScriptErrorHash;
      return;
   }
      
   if (($ScriptErrorHash != $ScriptErrorMessageHash) && ($ScriptErrorHash != 0))
   {
      %count = getFieldCount($ScriptError);
      %numErrors = $ScriptErrorHash - $ScriptErrorMessageHash;
      %errorString = "";
      for (%i = 0; %i < %numErrors; %i++)
      {
         %field = %count - %numErrors + %i;
         if (%errorString !$= "")
            %errorString = %errorString @ "\n" @ getField($ScriptError, %field);
         else
            %errorString = getField($ScriptError, %field);
      }
      MessageBoxOK("脚本运行错误!", %errorString @ "\n\n" @ "按('~')键查看详细错误.");
         
      $ScriptErrorMessageHash = $ScriptErrorHash;
   }
}

function saveSelectedGroup()
{
   if (isObject(ToolManager.getAcquiredGroup()))
   {
      %dialog       =  SaveFileDlgEx;
      %filterList   =  %dialog.findObjectByInternalName("FilterList", true);

      %name = ToolManager.getAcquiredGroup().name;
      %currentFile = expandFileName( "^game/data/levels/group.t2d" );
   
      // Clear Filters
      %dialog.ClearFilters();
      
      // Add Filters
      %filter = %dialog.AddFilter("*.t2d","Scene Files");
    
      // Select Filter.
      %filterList.setSelected( %filter );
      
      getSaveFileName($T2D::LevelSpec, saveSelectedGroupCallback, %currentFile);   
         
   }
}

function saveSelectedGroupCallback(%filename)
{
   %group = ToolManager.getAcquiredGroup();
   if (isObject(%group))
   {
      %fo = new FileObject();
      %fo.openForWrite(%filename);
      %fo.writeObject(%group, "%levelContent = ");
      %fo.close();
      %fo.delete();
   }
}

function saveSelectedObjects()
{
   if (ToolManager.getAcquiredObjectCount() > 0)
   {
      %dialog       =  SaveFileDlgEx;
      %filterList   =  %dialog.findObjectByInternalName("FilterList", true);

//      getSaveFilename("*.t2d", saveSelectedGroupCallback);
      %currentFile = expandFilename("^game/data/levels/selected.t2d");
   
      // Clear Filters
      %dialog.ClearFilters();
      
      // Add Filters
      %filter = %dialog.AddFilter("*.t2d","Scene Files");
    
      // Select Filter.
      %filterList.setSelected( %filter );

      getSaveFilename($T2D::LevelSpec, saveSelectedObjectsCallback, %currentFile);
   }
}

function saveSelectedObjectsCallback(%filename)
{
   %group = ToolManager.getAcquiredGroup();
   if (isObject(%group))
   {
      saveSelectedGroupCallback(%filename);
      return;
   }
   
   %objects = ToolManager.getAcquiredObjects();
   
   if (!isObject(%objects))
      return;

   if( isFile( %fileName @ ".dso" ) )
      fileDelete( %fileName @ ".dso" );

   %count = %objects.getCount();
   // A single object can just be saved out on its own.
   if (%count == 1)
   {
      %object = %objects.getObject(0);
      %fo = new FileObject();
      %fo.openForWrite(%filename);
      %fo.writeObject(%object, "%levelContent = ");
      %fo.close();
      %fo.delete();
   }
   
   // Multiple objects we're going to put in a single group for saving.
   else if (%count > 1)
   {
      // Create a group to house the selected objects.
      %set = new t2dSceneObjectSet();
      
      // Temporarily move stuff to the new group.
      for (%i = 0; %i < %count; %i++)
      {
         %object = %objects.getObject(%i);
         %set.add(%object);
      }
      
      %fo = new FileObject();
      %fo.openForWrite(%filename);
      %fo.writeObject(%set, "%levelContent = ");
      %fo.close();
      %fo.delete();
      
      // Kill the new group.
      %set.delete();
   }
}

$layerToSave = -1;
function saveLayer(%layer)
{
   $layerToSave = %layer;
   getSaveFilename("", saveLayerCallback);
}

function saveLayerCallback(%filename)
{
   // Create a group to house the selected objects.
   %newGroup = new t2dSceneObjectGroup();

   // Open the Current SceneGraph, if any.
   %lastWindow = ToolManager.getLastWindow();
   if( !isObject( %lastWindow ) || !isObject( %lastWindow.getScenegraph() ) )
   {
      error("SaveGraphGroup - No Valid SceneGraph Found!");
      return;
   }
   %sceneGraph = %lastWindow.getScenegraph();

   %count = %scenegraph.getSceneObjectCount();   
   // Temporarily move stuff to the new group.
   for (%i = 0; %i < %count; %i++)
   {
      %object = %scenegraph.getSceneObject(%i);
      
      if (%object.getLayer() == $layerToSave)
      {
         %oldGroup[%i] = %object.getGroup();
         %newGroup.add(%object);
      }
   }
   
   // Save the new group.
   if (%newGroup.getCount() > 0)
   {
      %fo = new FileObject();
      %fo.openForWrite(%filename);
      %fo.writeObject(%newGroup, "%levelContent = ");
      %fo.close();
      %fo.delete();
   }
   
   // And move stuff back to its original group, or at least out of the new group.
   for (%i = 0; %i < %count; %i++)
   {
      %object = %scenegraph.getSceneObject(%i);
      
      if (%object.getLayer() == $layerToSave)
      {
         %newGroup.remove(%object);
         if (isObject(%oldGroup[%i]))
            %oldGroup[%i].add(%object);
      }
   }
   
   // Kill the new group.
   %newGroup.delete();
   $layerToSave = -1;
}

$graphGroupToSave = -1;
function saveGraphGroup(%graphGroup)
{
   $graphGroupToSave = %graphGroup;
   getSaveFilename("", saveGraphGroupCallback);
}

function saveGraphGroupCallback(%filename)
{
   // Create a group to house the selected objects.
   %newGroup = new t2dSceneObjectGroup();

   // Open the Current SceneGraph, if any.
   %lastWindow = ToolManager.getLastWindow();
   if( !isObject( %lastWindow ) || !isObject( %lastWindow.getScenegraph() ) )
   {
      error("SaveGraphGroup - No Valid SceneGraph Found!");
      return;
   }
   %sceneGraph = %lastWindow.getScenegraph();

   %count = %scenegraph.getSceneObjectCount();   
   // Temporarily move stuff to the new group.
   for (%i = 0; %i < %count; %i++)
   {
      %object = %scenegraph.getSceneObject(%i);
      
      if (%object.getGraphGroup() == $groupToSave)
      {
         %oldGroup[%i] = %object.getGroup();
         %newGroup.add(%object);
      }
   }
   
   // Save the new group.
   if (%newGroup.getCount() > 0)
   {
      %fo = new FileObject();
      %fo.openForWrite(%filename);
      %fo.writeObject(%newGroup, "%levelContent = ");
      %fo.close();
      %fo.delete();
   }
   
   // And move stuff back to its original group, or at least out of the new group.
   for (%i = 0; %i < %count; %i++)
   {
      %object = %scenegraph.getSceneObject(%i);
      
      if (%object.getGraphGroup() == $groupToSave)
      {
         %newGroup.remove(%object);
         if (isObject(%oldGroup[%i]))
            %oldGroup[%i].add(%object);
      }
   }
   
   // Kill the new group.
   %newGroup.delete();
   $graphGroupToSave = -1;
}