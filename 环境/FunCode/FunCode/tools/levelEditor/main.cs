//-----------------------------------------------------------------------------
// Torque Game Builder
// Copyright (C) GarageGames.com, Inc.
//-----------------------------------------------------------------------------

$LevelBuilder::Version = "v1.7.5";

function initializeLevelEditor()
{   
   echo(" % - Initializing Scene Editor");
   
   // Load Preferences.
   exec("./preferences/defaultPrefs.ed.cs");
   execPrefs("levelEditorPrefs.cs");  
   
   // Create Form Content Library.
   GuiFormManager::RegisterLibrary("LevelBuilder", "levelBuilder/layouts" );
   GuiFormManager::RegisterLibrary("LevelBuilderToolProperties", "levelBuilder/layouts" );
   GuiFormManager::RegisterLibrary("LevelBuilderSidebar", "levelBuilder/layouts" );
      GuiFormManager::RegisterLibrary("LevelBuilderSidebarLeft", "levelBuilder/layouts" );
   GuiFormManager::RegisterLibrary("LevelBuilderSidebarEdit", "levelBuilder/layouts" );
   GuiFormManager::RegisterLibrary("LevelBuilderSidebarCreate", "levelBuilder/layouts" );
   GuiFormManager::RegisterLibrary("LevelBuilderQuickEditClasses" );

   // Make Sure Default Layout always exists.
   exec("./data/layouts/Default.ed.cs");
   
   // Load Up Available Layouts.
   GuiFormManager::InitLayouts( "LevelBuilder" );
   
   // Load scripts.
   exec("./gui/profiles.ed.cs");

   // Form Contents.
   loadDirectory( expandFileName("./core") , "ed.cs", "edso" );
   loadDirectory( expandFileName("./scripts") , "ed.cs", "edso" );
   loadDirectory( expandFileName("./scripts") , "ed.gui", "edso" );
   
   // Load guis.
   exec("./gui/LevelBuilderBase.ed.gui");
   exec("./gui/options.ed.gui");
   exec("./gui/TGBInsider.ed.gui");
   exec("./gui/TGBInsider.ed.cs");
   exec("./gui/SetStartVCGUI.ed.gui"); 
   //exec("./gui/SetVCVersionGUI.ed.gui");    
   exec("./gui/CreateProjectGUI.ed.gui");   
   exec("./gui/SelectProjectCreateGui.ed.gui");
   exec("./gui/CreateOtherProjectGUI.ed.gui");
   exec("./gui/SelectUserTemplateGUI.ed.gui");
   exec("./gui/SaveUserTemplateGUI.ed.gui");
   exec("./gui/SetEclipsePathGUI.ed.gui");    
   exec("./gui/SetServerIP.ed.gui");  
   
   OptionsTabBook.add(LevelEditorOptionsPage);
   OptionsTabBook.selectPage(0);
   
   // Build LevelBuilder Menu
   new BehaviorComponent(LevelBuilderMenu);
   LevelBuilderMenu.initialize();

   // Create Tool Manager.
   if (!isObject(ToolManager))
   {
      new LevelBuilderSceneEdit( ToolManager );
      LevelBuilderToolManager::initializeTools( ToolManager );
   }
 
   applyLevelEdOptions();

   // Activate Default Layout
      if( GuiFormManager::FindLayout( "LevelBuilder", "User" ) )
         GuiFormManager::ActivateLayout( "LevelBuilder", "User", levelBuilderViewContainer );
      else
   GuiFormManager::ActivateLayout( "LevelBuilder", "Default", levelBuilderViewContainer );
   
   // Set Creator Panel Content
   %contentObj = GuiFormManager::FindFormContent( "LevelBuilder", "SideBar" );
   if( %contentObj == 0 )
      GuiFormClass::ClearControlContent( sideBarContentContainer, "LevelBuilder" );
   else
      GuiFormClass::SetControlContent( sideBarContentContainer, "LevelBuilder", %contentObj );
      
   // Set Creator Panel Content
   %contentObj = GuiFormManager::FindFormContent( "LevelBuilder", "SideBarLeft" );
   if( %contentObj == 0 )
      GuiFormClass::ClearControlContent( sideBarContentContainerLeft, "LevelBuilder" );
   else
      GuiFormClass::SetControlContent( sideBarContentContainerLeft, "LevelBuilder", %contentObj );
      
   // Level editor hotkey.
   GlobalActionMap.bindCmd(keyboard, "f9", "toggleLevelEditor();", "");
   
   // Create the default config datablock. This is used to mask
   // the saving of unchanged scene object fields.
   setDefaultSceneObjectDatablock(new t2dSceneObjectDatablock());
     
   // Show Start Page
   //Canvas.setContent( TGBStartPage );
   Canvas.setContent( FunCodeStartPage );
   
}

function destroyLevelEditor()
{
   if( $FunCodeCreate_NotExit == 1 )
      $FunCodeCreate_NotExit = 0;
   else
      $levelEditor::levelBuilderContentColums = levelBuilderContentFrame.getRawColumnOffsets();

   // Export Preferences.
   echo("Exporting Scene Editor preferences.");
   export("$levelEditor::*", "levelEditorPrefs.cs", false);
   
   // Destroy RSS News Updater
   RSSUpdate::destroy();
}

//function LevelBuilderMenu::initialize( %this )
//{
   //Parent::initialize( %this );
   //
   ////-----------------------------------------------------------------------------
   //// File Menu
   ////-----------------------------------------------------------------------------
   //%this.addMenu("File");
   //%this.addMenuItem("File", "New Level...", "LBProjectObj.newLevel();", "Ctrl N"); // "newLevel();"
   //%this.addMenuItem("File", "Open Level...", "LBProjectObj.openLevel();", "Ctrl O"); // "getLevelOpenName(loadLevelCallback);"
   //%this.addMenuItem("File", "-");
   //%this.addMenuItem("File", "New Project...", "newProject();");
   //%this.addMenuItem("File", "Open Project...", "TGBWorkspace.OpenProject();");
   //%this.addMenuItem("File", "Build Project...", "togglePackagingUtility();");
   //%this.addMenuItem("File", "-");
   //%this.addMenuItem("File", "Save", "LBProjectObj.saveLevel();", "Ctrl S");
   //%this.addMenuItem("File", "Save As...", "LBProjectObj.saveLevelAs();");
   //%this.addMenuItem("File", "-");
   //%this.addMenuItem("File", "Quit", "quit();");
//
   ////-----------------------------------------------------------------------------
   //// Edit Menu
   ////-----------------------------------------------------------------------------
   //%this.addMenu("Edit", %menuCount);
   //%this.addMenuItem("Edit", "Undo", "levelBuilderUndo(1);");
   //%this.addMenuItem("Edit", "Redo", "levelBuilderRedo(1);");
   //%this.addMenuItem("Edit", "-");
   //%this.addMenuItem("Edit", "Cut", "levelBuilderCut(1);");
   //%this.addMenuItem("Edit", "Copy", "levelBuilderCopy(1);");
   //%this.addMenuItem("Edit", "Paste", "levelBuilderPaste(1);");
   //%this.addMenuItem("Edit", "-");
   //%this.addMenuItem("Edit", "Group Objects", "ToolManager.groupObjects();");
   //%this.addMenuItem("Edit", "Ungroup Objects", "ToolManager.breakApart();");
   //%this.addMenuItem("Edit", "-");
   //%this.addMenuItem("Edit", "Send to back", "sendToBack(true);", "Ctrl B");
   //%this.addMenuItem("Edit", "Bring to front", "bringToFront(true);", "Ctrl F");
   //%this.addMenuItem("Edit", "-");
   //%this.addMenuItem("Edit", "Preferences...", "Canvas.pushDialog(optionsDlg);");
//
   ////-----------------------------------------------------------------------------
   //// Project Menu
   ////-----------------------------------------------------------------------------
   //%this.addMenu("Project", %menuCount);
   //%this.addMenuItem("Project", "Run Game", "runGame();");
   //%this.addMenuItem("Project", "-");
   //%this.addMenuItem("Project", "GUI Builder...", "GuiEdit();");
   //%this.addMenuItem("Project", "-");
   //%this.addMenuItem("Project", "Image Map Builder...", "launchNewImageMap();");
   //%this.addMenuItem("Project", "Animation Builder...", "launchAnimationEditor();");
   //%this.addMenuItem("Project", "-");
   //%this.addMenuItem("Project", "Refresh Object Library", "GuiFormManager::SendContentMessage($LBCreateSiderBar, %this, \"refreshall 0\");");
   //%this.addMenuItem("Project", "Reload Textures", "reloadImageMaps();");
   //%this.addMenuItem("Project", "-");
   //%this.addMenuItem("Project", "Resources...", "Canvas.pushDialog(projectOptionsDlg);", "Ctrl R");
//
   ////-----------------------------------------------------------------------------
   //// View Menu
   ////-----------------------------------------------------------------------------
   //%this.addMenu("View", %menuCount);
   //%this.addMenuItem("View", "Home", "levelBuilderHomeView(1);");
   //%this.addMenuItem("View", "Show All", "levelBuilderZoomToFit(1);");
   //%this.addMenuItem("View", "Show Selected", "levelBuilderZoomToSelected(1);");
   //%this.addMenuItem("View", "-");
   //%this.addMenuItem("View", "Zoom 25%", "levelBuilderZoomView(0.25);");
   //%this.addMenuItem("View", "Zoom 50%", "levelBuilderZoomView(0.5);");
   //%this.addMenuItem("View", "Zoom 100%", "levelBuilderZoomView(1.0);");
   //%this.addMenuItem("View", "Zoom 200%", "levelBuilderZoomView(2.0);");
   //%this.addMenuItem("View", "Zoom 400%", "levelBuilderZoomView(4.0);");
//
   ////-----------------------------------------------------------------------------
   //// Help Menu
   ////-----------------------------------------------------------------------------
   //%this.addMenu("Help", %menuCount);
   //%this.addMenuItem("Help", "Documentation", "shellExecute(\"" @ expandFilename("^tools/help.html") @ "\");");
   //%this.addMenuItem("Help", "-");
   //%this.addMenuItem("Help", "GarageGames Community Page", "gotoWebpage(\"http://www.torquepowered.com/community\");");
   //%this.addMenuItem("Help", "TGB Developer Forums", "gotoWebpage(\"http://www.torquepowered.com/community/forums/28\");");
   //%this.addMenuItem("Help", "GarageGames News", "RSSUpdate::showNews();");
   //%this.addMenuItem("Help", "-");
   //%this.addMenuItem("Help", "About...", "TGBInsiderDlg.showAbout();");
//}
//
//function GuiMenuBar::onMenuItemSelect(%this, %menuId, %menu, %itemId, %item)
//{
   //if(%this.scriptCommand[%menu, %itemId] !$= "")
      //eval(%this.scriptCommand[%menu, %itemId]);
//}

// --------------------------------------------------------------------
// Show Scene Editor.
// --------------------------------------------------------------------

$LevelEditorWindow::lockMask = -1;
$LevelEditorWindow::hideMask = -1;
$LevelBuilder::lastCameraPosition = "";
$LevelBuilder::lastCameraSize = "";
$LevelBuilder::lastCameraZoom = "";
function showLevelEditor()
{  
   if( getWordCount( $levelEditor::levelBuilderContentColums ) == 3 && getWord($levelEditor::levelBuilderContentColums, 1) > 50 && getWord($levelEditor::levelBuilderContentColums, 2) > 50 )
      levelBuilderContentFrame.columns = $levelEditor::levelBuilderContentColums;
      
   Canvas.setContent(LevelBuilderBase);
      
   applyLevelEdOptions();
   levelEditorMap.push();
   
   // Set Scene-Editor State.
   $LevelEditorActive = true;
     
   LevelBuilderToolManager::setTool(LevelEditorSelectionTool);
     
   %sceneWindow = ToolManager.getLastWindow();
   
   if( !isObject( %sceneWindow ) )
      return;
      
   %scenegraph = %sceneWindow.getSceneGraph();
   %cameraPosition = "0 0";
   %cameraSize = $levelEditor::DefaultCameraSize;
   %cameraZoom = 1.0;
   if (%scenegraph.cameraPosition)
      %cameraPosition = %scenegraph.cameraPosition;
   if (%scenegraph.cameraSize)
      %cameraSize = %scenegraph.cameraSize;
   if( $LevelBuilder::lastCameraPosition !$= "" )
      %cameraPosition = $LevelBuilder::lastCameraPosition;
   if( $LevelBuilder::lastCameraSize !$= "" )
      %cameraSize = $LevelBuilder::lastCameraSize;
   if( $LevelBuilder::lastCameraZoom !$= "" )
      %cameraZoom = $LevelBuilder::lastCameraZoom;
      
   %sceneWindow.setCurrentCameraPosition(%cameraPosition, %cameraSize);
   %sceneWindow.setCurrentCameraZoom(%cameraZoom);
   
   // Check for RSS News updates.
   //if( $levelEditor::checkRSSFeeds $= true )
   //   RSSUpdate::initialize( "RSSUpdate::onNewNewsItems" );
   //else if( $levelEditor::checkRSSFeeds $= "" )
   //   TGBInsiderDlg.showFirstRun();
   
   %sceneWindow.setLayerMask( $LevelEditorWindow::lockMask );
   %sceneWindow.setRenderMasks( $LevelEditorWindow::hideMask );
   
   GuiFormManager::SendContentMessage( $LBQuickEdit, 0, "inspectUpdate" );
}

// --------------------------------------------------------------------
// Hide Scene Editor.
// --------------------------------------------------------------------
function hideLevelEditor()
{
   if(! isObject(mainScreenGui))
      return;
      
   %window = ToolManager.getLastWindow();
   $LevelEditorWindow::lockMask = %window.getLayerMask();
   $LevelEditorWindow::hideMask = %window.getRenderLayerMask();
        
   // Set Scene-Editor State.
   $LevelEditorActive = false;

   levelEditorMap.pop();
}

// --------------------------------------------------------------------
// Toggle Scene Editor.
// --------------------------------------------------------------------
$LevelEditorActive = false;
function toggleLevelEditor()
{
   // Toggle Scene-Editor.
   if ($LevelEditorActive)
      hideLevelEditor();
   else
      showLevelEditor();
}
