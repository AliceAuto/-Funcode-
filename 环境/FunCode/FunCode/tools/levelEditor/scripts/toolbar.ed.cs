//---------------------------------------------------------------------------------------------
// Torque Game Builder
// Copyright (C) GarageGames.com, Inc.
//---------------------------------------------------------------------------------------------
//
$LB::ToolBarGroup = "LBToolBarGroup";


if( !isObject( $LB::ToolBarGroup ) )
   new SimGroup( $LB::ToolBarGroup );
   
function LevelBuilderToolManager::onRemove(%this)
{
   %this.destroyTools();
}


function LevelBuilderToolManager::addButtonToBar( %bar, %texture, %command, %toolTip, %addSpacer, %spacerInvisible, %className )
{
   // Create a button for this tool
   %button = new GuiIconButtonCtrl() 
   {
      canSaveDynamicFields = "0";
      Profile = "EditorButtonToolbar";
      HorizSizing = "right";
      VertSizing = "bottom";
      position = "0 0";
      Extent = "24 24";
      MinExtent = "8 2";
      canSave = "1";
      visible = "1";
      Command = "ToolManager.getLastWindow().setFirstResponder();" SPC %command;
      tooltipprofile = "GuiToolTipProfile";
      ToolTip = %toolTip;
      hovertime = "100";
      class = %className;
      textLocation = "None";
      textMargin = "4";
      buttonMargin = "4 4";     
      groupNum = "1338";
      buttonType = "Button";
      iconBitmap = $LevelBuilder::GuiPath @ "/images/" @ %texture;
   };

   // Add to toolbar
   %bar.add( %button );

   // Link tool to button
   %tool.button = %button;
   
   // Find Properties Spacer
   %propertiesSpacer = %bar.findObjectByInternalName("propertiesSpacer");

   if( isObject( %propertiesSpacer ))
   {
      // Place After Spacer
      %bar.reorderChild( %button, %propertiesSpacer );
   }

   // Return the button.
   if( !%addSpacer )
      return %button;

   // Add Spacer 
   %spacer = new GuiSeparatorCtrl() 
   {
      canSaveDynamicFields = "0";
      Profile = "GuiSeparatorProfile";
      HorizSizing = "right";
      VertSizing = "bottom";
      Position = "0 0";
      Extent = "14 24";
      MinExtent = "8 2";
      canSave = "1";
      Visible = "1";
      hovertime = "1000";
      type = "Vertical";
      Invisible = %spacerInvisible;
      BorderMargin = "3";
      LeftMargin = "0";
   };

   // Add spacer to toolbar
   %bar.add( %spacer );

   // Place Before Button
   %bar.reorderChild( %spacer, %button );

   // Place After Button
   %bar.reorderChild( %button, %spacer );

   // Force Stack to Reposition it's children according to our new order.
   %bar.updateStack();

}


function LevelBuilderToolManager::addToolToBar( %tool, %addSpacer, %spacerInvisible )
{
   if( !isObject( %tool ) || %tool.getToolName() $= "" )
   {
      error("LevelBuilderToolManager::addToolToBar - Invalid Tool or Nameless Tool!");
      return;
   }

   // Create a button for this tool
   %button = new GuiIconButtonCtrl() 
   {
      canSaveDynamicFields = "0";
      Profile = "EditorButtonToolbar";
      HorizSizing = "right";
      VertSizing = "bottom";
      position = "0 0";
      Extent = "24 24";
      MinExtent = "8 2";
      canSave = "1";
      visible = "1";
      Command = "LevelBuilderToolManager::setTool(" @ %tool.getID() @ ");";
      tooltipprofile = "GuiToolTipProfile";
      ToolTip = %tool.getToolDisplayName();
      hovertime = "100";
      text = %tool.getToolDisplayName();
      textLocation = "None";
      textMargin = "4";
      buttonMargin = "4 4";     
      groupNum = "1338";
      buttonType = "RadioButton";
      iconBitmap = $LevelBuilder::GuiPath @ "/images/" @ %tool.getToolTexture();
   };

   // Add to toolbar
   LevelBuilderToolBar.add( %button );

   // Link tool to button
   %tool.button = %button;
   
   // Find Properties Spacer
   %propertiesSpacer = LevelBuilderToolBar.findObjectByInternalName("propertiesSpacer");

   if( isObject( %propertiesSpacer ))
   {
      // Place After Spacer
      LevelBuilderToolBar.reorderChild( %button, %propertiesSpacer );
   }

   // Return the button.
   if( !%addSpacer )
      return %button;

   // Add Spacer 
   %spacer = new GuiSeparatorCtrl() 
   {
      canSaveDynamicFields = "0";
      Profile = "GuiSeparatorProfile";
      HorizSizing = "right";
      VertSizing = "bottom";
      Position = "0 0";
      Extent = "12 24";
      MinExtent = "8 2";
      canSave = "1";
      Visible = "1";
      hovertime = "1000";
      type = "Vertical";
      Invisible = %spacerInvisible;
      BorderMargin = "3";
      LeftMargin = "0";
   };

   // Add spacer to toolbar
   LevelBuilderToolBar.add( %spacer );

   // Place Before Button
   LevelBuilderToolBar.reorderChild( %spacer, %button );

   // Place After Button
   LevelBuilderToolBar.reorderChild( %button, %spacer );

   // Force Stack to Reposition it's children according to our new order.
   LevelBuilderToolBar.updateStack();

}

function LevelBuilderToolManager::addTextToBar( %bar, %profile, %extent, %text )
{
   // Create a button for this tool
   %button = new GuiTextCtrl() 
   {
      canSaveDynamicFields = "0";
      Profile = %profile;
      HorizSizing = "width";
      VertSizing = "height";
      Position = "10 0";
      Extent = %extent;
      MinExtent = "8 2";
      canSave = "1";
      Visible = "1";
      hovertime = "100";
      text = %text;
      maxLength = "1024";
   };

   // Add to toolbar
   %bar.add( %button );
}

function LevelBuilderToolManager::setToolPropertiesOnBar( %toolID )
{
   // Find Properties Spacer
   %propertiesSpacer = LevelBuilderToolBar.findObjectByInternalName("propertiesSpacer");

   if( !isObject( %propertiesSpacer ))
   {
      error("LevelBuilderToolManager::setToolPropertiesOnBar - Unable to find properties Spacer!");
      return;
   }

   %contentObj = GuiFormManager::FindFormContent( "LevelBuilderToolProperties", %toolID.getToolName() );
   if( %contentObj == 0 )
      GuiFormClass::ClearControlContent( LevelBuilderToolBar, "LevelBuilderToolProperties" );
   else
      GuiFormClass::SetControlContent( LevelBuilderToolBar, "LevelBuilderToolProperties", %contentObj );

}

function LevelBuilderSceneEdit::onToolActivate(%this, %toolObject)
{  
   LevelBuilderToolManager::setToolPropertiesOnBar( %toolObject );

   if (isObject(%toolObject.button))
      %toolObject.button.setStateOn( true );
      
   if (%toolObject.isMethod("onActivate"))
      %toolObject.onActivate();
}

function LevelBuilderSceneEdit::onToolDeactivate(%this, %tool)
{
   if (%tool.isMemberOfClass("LevelBuilderCreateTool"))
      GuiFormManager::SendContentMessage($LBCreateSiderBar, %this, "clearSelections");
   
   if (%tool.isMethod("onDeactivate"))
      %tool.onDeactivate();
}


function LevelBuilderToolManager::initializeTools(%toolManager)
{
   
   
   //---------------------------------------------------------------------------------------------
   // Toolbar Buttons - Utility
   //---------------------------------------------------------------------------------------------
   // New Level
   LevelBuilderToolManager::addButtonToBar( LevelBuilderToolBar, $LevelBuilder::GuiPath @ "/images/iconNew", "LBPRojectObj.newLevel();",  "创建一个新的场景" );
   // Open Level
   LevelBuilderToolManager::addButtonToBar( LevelBuilderToolBar, $LevelBuilder::GuiPath @ "/images/iconOpen", "LBPRojectObj.openLevel();",  "打开一个现有场景" );
   // Save Level
   LevelBuilderToolManager::addButtonToBar( LevelBuilderToolBar, $LevelBuilder::GuiPath @ "/images/iconSave", "LBPRojectObj.saveLevel();",  "保存当前场景所做更改", true );
   
   //Luma: Project Build Buttons
   //if($platform $= "macos")
   //{
      //LevelBuilderToolManager::addButtonToBar( LevelBuilderToolBar, $LevelBuilder::GuiPath @ "/images/iconCompile", "openXCodeProject();", "生成游戏安装包",true );
   //}
   //else if($platform $= "windows")
   //{
      //LevelBuilderToolManager::addButtonToBar( LevelBuilderToolBar, $LevelBuilder::GuiPath @ "/images/iconCompile2005", "openVS2005Project();", "打开VC2005工程",true );      
      //LevelBuilderToolManager::addButtonToBar( LevelBuilderToolBar, $LevelBuilder::GuiPath @ "/images/iconCompile2008", "openVS2008Project();", "打开VC2008工程",true );      
   //}

   // Cut
   LevelBuilderToolManager::addButtonToBar( LevelBuilderToolBar, $LevelBuilder::GuiPath @ "/images/iconCut", "levelBuilderCut(1);",  "剪切选中的精灵至剪贴板" );
   // Copy
   LevelBuilderToolManager::addButtonToBar( LevelBuilderToolBar, $LevelBuilder::GuiPath @ "/images/iconCopy", "levelBuilderCopy(1);",  "复制选中的精灵至剪贴板" );
   // Paste
   LevelBuilderToolManager::addButtonToBar( LevelBuilderToolBar, $LevelBuilder::GuiPath @ "/images/iconPaste", "levelBuilderPaste(1);",  "粘贴剪贴板里的精灵", true );


   // Add Undo Button
   LevelBuilderToolManager::addButtonToBar( LevelBuilderToolBar, $LevelBuilder::GuiPath @ "/images/iconUndo", "levelBuilderUndo(1);",  "撤销上次操作" );
   // Add Redo Button
   LevelBuilderToolManager::addButtonToBar( LevelBuilderToolBar, $LevelBuilder::GuiPath @ "/images/iconRedo", "levelBuilderRedo(1);",  "重做上次操作", true );

   // Add Layer Up Buitton
   //LevelBuilderToolManager::addButtonToBar( LevelBuilderToolBar, $LevelBuilder::GuiPath @ "/images/iconLayerUp", "layerSelectionUp(1);", "选中的物体前置一级" );
   // Add Layer Down Buitton
   //LevelBuilderToolManager::addButtonToBar( LevelBuilderToolBar, $LevelBuilder::GuiPath @ "/images/iconLayerDown", "layerSelectionDown(1);", "选中的物体后置一级", true );

   // Add Play Level Buitton
   LevelBuilderToolManager::addButtonToBar( LevelBuilderToolBar, $LevelBuilder::GuiPath @ "/images/iconPlay", "runGame();", "运行游戏" );
  
   //---------------------------------------------------------------------------------------------
   // Tools
   //---------------------------------------------------------------------------------------------
   if (!isObject(LevelEditorSelectionTool))
   {
      %tool = new LevelBuilderSelectionTool(LevelEditorSelectionTool);
      %tool.setToolTexture("iconSelectionTool");
      %toolManager.addTool(LevelEditorSelectionTool, true);
      LevelBuilderToolManager::addToolToBar( %tool, true, true );
   }
   $LB::ToolBarGroup.add( %tool );
   
   // Buttons for display when mousing over a selected object.
   %widget = new SelectionToolWidget() { priority = 5; position = 0; showClasses = false;
                                       callback = "editCollisionPoly";
                                       tooltip = "编辑此精灵的碰撞体"; };
   %widget.setTexture($LevelBuilder::GuiPath @ "/images/iconPathTool");
   LevelEditorSelectionTool.addWidget(%widget);
   
   $LB::ToolBarGroup.add( %widget );
   
   %widget = new SelectionToolWidget() { priority = 5; position = 0; showClasses = false;
                                       callback = "editLinkPoints";
                                       tooltip = "编辑此精灵的链接点"; };
   %widget.setTexture($LevelBuilder::GuiPath @ "/images/iconLinkTool");
   LevelEditorSelectionTool.addWidget(%widget);
   
   $LB::ToolBarGroup.add( %widget );
   
   %widget = new SelectionToolWidget() { priority = 5; position = 0; showClasses = false;
                                       callback = "editSortPoint";
                                       tooltip = "编辑此精灵的中心点"; };
   %widget.setTexture($LevelBuilder::GuiPath @ "/images/iconSortTool");
   LevelEditorSelectionTool.addWidget(%widget);
   
   $LB::ToolBarGroup.add( %widget );
                                                                              
   %widget = new SelectionToolWidget() { priority = 5; position = 1; showClasses = false;
                                       callback = "mountObject";
                                       tooltip = "绑定此精灵至另一个精灵"; };
   %widget.setTexture($LevelBuilder::GuiPath @ "/images/iconMount");
   %widget.setDisplayRule("Unmounted");
   %widget.setDisplayRule("Unpathed");
   LevelEditorSelectionTool.addWidget(%widget);
   
   $LB::ToolBarGroup.add( %widget );
                                       
   %widget = new SelectionToolWidget() { priority = 5; position = 1; showClasses = false;
                                       callback = "dismountObject";
                                       tooltip = "解绑此精灵之前所做的绑定"; };
   %widget.setTexture($LevelBuilder::GuiPath @ "/images/iconDismount");
   %widget.setDisplayRule("Mounted");
   LevelEditorSelectionTool.addWidget(%widget);
   
   $LB::ToolBarGroup.add( %widget );
                                       
   %widget = new SelectionToolWidget() { priority = 5; position = 1; showClasses = false;
                                       callback = "dismountObject";
                                       tooltip = "解绑此精灵之前所做的绑定"; };
   %widget.setTexture($LevelBuilder::GuiPath @ "/images/iconDismount");
   %widget.setDisplayRule("Pathed");
   LevelEditorSelectionTool.addWidget(%widget);
   
   $LB::ToolBarGroup.add( %widget );
                                       
   %widget = new SelectionToolWidget() { priority = 5; position = 2; showClasses = false;
                                       callback = "editWorldLimit";
                                       tooltip = "更改此精灵的世界边界限制"; };
   %widget.setTexture($LevelBuilder::GuiPath @ "/images/iconWorldLimit");
   LevelEditorSelectionTool.addWidget(%widget);
                                    
   $LB::ToolBarGroup.add( %widget );
   
   %widget = new SelectionToolWidget() { priority = 10; position = 1; showClasses = true;
                                       callback = "editPath";
                                       tooltip = "编辑此路径"; };
   %widget.addClass("t2dPath");
   %widget.setTexture($LevelBuilder::GuiPath @ "/images/iconPathTool");
   LevelEditorSelectionTool.addWidget(%widget);
   
   $LB::ToolBarGroup.add( %widget );
                                       
   //%widget = new SelectionToolWidget() { priority = 10; position = 1; showClasses = true;
   //                                    callback = "editImageMap";
   //                                    tooltip = "编辑此图片"; };
   //%widget.addClass("t2dStaticSprite");
   //%widget.setTexture($LevelBuilder::GuiPath @ "/images/iconImage");
   //LevelEditorSelectionTool.addWidget(%widget);
   
   //$LB::ToolBarGroup.add( %widget );
   
   //%widget = new SelectionToolWidget() { priority = 10; position = 1; showClasses = true;
   //                                    callback = "editAnimation";
   //                                    tooltip = "编辑此动画"; };                                       
   //%widget.addClass("t2dAnimatedSprite");
   //%widget.setTexture($LevelBuilder::GuiPath @ "/images/iconViewStoryboard");
   //LevelEditorSelectionTool.addWidget(%widget);
   
   //$LB::ToolBarGroup.add( %widget );
   
   %widget = new SelectionToolWidget() { priority = 10; position = 1; showClasses = true;
                                       callback = "editTileLayer";
                                       tooltip = "编辑此平铺图"; };                                       
   %widget.addClass("t2dTileLayer");
   %widget.setTexture($LevelBuilder::GuiPath @ "/images/iconImage");
   LevelEditorSelectionTool.addWidget(%widget);
   
   $LB::ToolBarGroup.add( %widget );
   
   %widget = new SelectionToolWidget() { priority = 10; position = 1; showClasses = true;
                                       callback = "editTextObject";
                                       tooltip = "编辑此文字"; };                                       
   %widget.addClass("t2dTextObject");
   %widget.setTexture($LevelBuilder::GuiPath @ "/images/iconTextEditTool");
   LevelEditorSelectionTool.addWidget(%widget);
   
   $LB::ToolBarGroup.add( %widget );
   
   %widget = new SelectionToolWidget() { priority = 10; position = 1; showClasses = true;
                                       callback = "editShapeVector";
                                       tooltip = "编辑此多边形"; };
   %widget.addClass("t2dShapeVector");
   %widget.setTexture($LevelBuilder::GuiPath @ "/images/iconShapeVectorTool");
   LevelEditorSelectionTool.addWidget(%widget);
   
   $LB::ToolBarGroup.add( %widget);
   
   
   if( !isObject( LevelEditorTextEditTool ) )
   {
      %tool = new LevelBuilderTextEditTool(LevelEditorTextEditTool);
      %tool.setToolTexture("iconTextEditTool");
      %toolManager.addTool(LevelEditorTextEditTool);
      LevelBuilderToolManager::addToolToBar( %tool, false, true );
   }
   
   if (!isObject(LevelEditorPolyTool))
   {
      %tool = new LevelBuilderPolyTool(LevelEditorPolyTool);
      %toolManager.addTool(LevelEditorPolyTool);
      $LB::ToolBarGroup.add( %tool );

   }

   if (!isObject(LevelEditorLinkPointTool))
   {
      %tool = new LevelBuilderLinkPointTool(LevelEditorLinkPointTool);
      %toolManager.addTool(LevelEditorLinkPointTool);
      $LB::ToolBarGroup.add( %tool );
   }

   if (!isObject(LevelEditorSortPointTool))
   {
      %tool = new LevelBuilderSortPointTool(LevelEditorSortPointTool);
      %toolManager.addTool(LevelEditorSortPointTool);
      $LB::ToolBarGroup.add( %tool );
   }

   if (!isObject(LevelEditorCameraTool))
   {
      %tool = new LevelBuilderCameraTool(LevelEditorCameraTool);
      %toolManager.addTool(LevelEditorCameraTool);
      %tool.setToolTexture("iconCameraTool");
      LevelBuilderToolManager::addToolToBar( %tool );
      $LB::ToolBarGroup.add( %tool );
   }

   if (!isObject(LevelEditorWorldLimitTool))
   {
      %tool = new LevelBuilderWorldLimitTool(LevelEditorWorldLimitTool);
      %toolManager.addTool(LevelEditorWorldLimitTool);
      $LB::ToolBarGroup.add( %tool );
   }
   
   if (!isObject(LevelEditorPathEditTool))
   {
      %tool = new LevelBuilderPathEditTool(LevelEditorPathEditTool);
      %toolManager.addTool(LevelEditorPathEditTool);
      $LB::ToolBarGroup.add( %tool );
   }
   
   // Non Visual (No Toolbar Button) Tools.    
   if (!isObject(LevelEditorStaticSpriteTool))
   {
      %tool = new LevelBuilderStaticSpriteTool(LevelEditorStaticSpriteTool);
      %toolManager.addTool(LevelEditorStaticSpriteTool);
      $LB::ToolBarGroup.add( %tool );
   }
    
   if (!isObject(LevelEditorSceneObjectTool))
   {
      %tool = new LevelBuilderSceneObjectTool(LevelEditorSceneObjectTool);
      %toolManager.addTool(LevelEditorSceneObjectTool);
      $LB::ToolBarGroup.add( %tool );
   }
   
   if (!isObject(LevelEditorTextObjectTool))
   {
      %tool = new LevelBuilderTextObjectTool(LevelEditorTextObjectTool);
      %toolManager.addTool(LevelEditorTextObjectTool);
      $LB::ToolBarGroup.add( %tool );
   }
    
   if (!isObject(LevelEditorTriggerTool))
   {
      %tool = new LevelBuilderTriggerTool(LevelEditorTriggerTool);
      %toolManager.addTool(LevelEditorTriggerTool);
      $LB::ToolBarGroup.add( %tool );
   }

   if (!isObject(LevelEditorShapeVectorTool))
   {
      %tool = new LevelBuilderShapeVectorTool(LevelEditorShapeVectorTool);
      %toolManager.addTool(LevelEditorShapeVectorTool);
      $LB::ToolBarGroup.add( %tool );
   }
    
   if (!isObject(LevelEditor3DShapeTool))
   {
      %tool = new LevelBuilder3DShapeTool(LevelEditor3DShapeTool);
      %toolManager.addTool(LevelEditor3DShapeTool);
      $LB::ToolBarGroup.add( %tool );
   }
    
   if (!isObject(LevelEditorParticleTool))
   {
      %tool = new LevelBuilderParticleTool(LevelEditorParticleTool);
      %toolManager.addTool(LevelEditorParticleTool);
      $LB::ToolBarGroup.add( %tool );
   }
    
   if (!isObject(LevelEditorTileMapTool))
   {
      %tool = new LevelBuilderTileMapTool(LevelEditorTileMapTool);
      %toolManager.addTool(LevelEditorTileMapTool);
      $LB::ToolBarGroup.add( %tool );
   }
    
   if (!isObject(LevelEditorScrollerTool))
   {
      %tool = new LevelBuilderScrollerTool(LevelEditorScrollerTool);
      %toolManager.addTool(LevelEditorScrollerTool);
      $LB::ToolBarGroup.add( %tool );
   }
    
   if (!isObject(LevelEditorAnimatedSpriteTool))
   {
      %tool = new LevelBuilderAnimatedSpriteTool(LevelEditorAnimatedSpriteTool);
      %toolManager.addTool(LevelEditorAnimatedSpriteTool);
      $LB::ToolBarGroup.add( %tool );
   }
    
   if (!isObject(LevelEditorChunkedSpriteTool))
   {
      %tool = new LevelBuilderChunkedSpriteTool(LevelEditorChunkedSpriteTool);
      %toolManager.addTool(LevelEditorChunkedSpriteTool);
      $LB::ToolBarGroup.add( %tool );
   }
    
   if (!isObject(LevelEditorMountTool))
   {
      %tool = new LevelBuilderMountTool(LevelEditorMountTool);
      %toolManager.addTool(LevelEditorMountTool);
      $LB::ToolBarGroup.add( %tool );
   }
    
   if (!isObject(LevelEditorPathTool))
   {
      %tool = new LevelBuilderPathTool(LevelEditorPathTool);
      %toolManager.addTool(LevelEditorPathTool);
      
      $LB::ToolBarGroup.add( %tool );
   }
   
   if (!isObject(LevelEditorTileMapEditTool))
   {
      %tool = new LevelBuilderTileMapEditTool(LevelEditorTileMapEditTool);
      %toolManager.addTool(LevelEditorTileMapEditTool);
      LevelEditorTileMapEditTool.setIconBitmap(expandFileName("^tools/tileLayerEditor/tileicons"));
      
      $LB::ToolBarGroup.add( %tool );
   }  
   
    // Trail Version 
   if( $IsTrailVersion )
   {
      %WidthHeight = $TrailVersionTipWidth @ " 20";
      LevelBuilderToolManager::addTextToBar( LevelBuilderToolBar, EditorFontTrailVersion, %WidthHeight, $TrailVersionTip );  
   }
    
}

function LevelBuilderToolManager::destroyTools(%toolManager)
{
   if (isObject(LevelEditorSelectionTool))
   {
      %toolManager.removeTool(LevelEditorSelectionTool);
      LevelEditorSelectionTool.delete();
   }
    
   if (isObject(LevelEditorMountTool))
   {
      %toolManager.removeTool(LevelEditorMountTool);
      LevelEditorMountTool.delete();
   }
    
   if (isObject(LevelEditorPathEditTool))
   {
      %toolManager.removeTool(LevelEditorPathEditTool);
      LevelEditorPathEditTool.delete();
   }
    
   if (isObject(LevelEditorStaticSpriteTool))
   {
      %toolManager.removeTool(LevelEditorStaticSpriteTool);
      LevelEditorStaticSpriteTool.delete();
   }
    
   if (isObject(LevelEditorParticleTool))
   {
      %toolManager.removeTool(LevelEditorParticleTool);
      LevelEditorParticleTool.delete();
   }
    
   if (isObject(LevelEditorTileMapTool))
   {
      %toolManager.removeTool(LevelEditorTileMapTool);
      LevelEditorTileMapTool.delete();
   }
    
   if (isObject(LevelEditorTriggerTool))
   {
      %toolManager.removeTool(LevelEditorTriggerTool);
      LevelEditorTriggerTool.delete();
   }
    
   if (isObject(LevelEditorSceneObjectTool))
   {
      %toolManager.removeTool(LevelEditorSceneObjectTool);
      LevelEditorSceneObjectTool.delete();
   }
   
   if (isObject(LevelEditorTextObjectTool))
   {
      %toolManager.removeTool(LevelEditorTextObjectTool);
      LevelEditorTextObjectTool.delete();
   }
    
   if (isObject(LevelEditor3DShapeTool))
   {
      %toolManager.removeTool(LevelEditor3DShapeTool);
      LevelEditor3DShapeTool.delete();
   }
    
   if (isObject(LevelEditorPathTool))
   {
      %toolManager.removeTool(LevelEditorPathTool);
      LevelEditorPathTool.delete();
   }
    
   if (isObject(LevelEditorScrollerTool))
   {
      %toolManager.removeTool(LevelEditorScrollerTool);
      LevelEditorScrollerTool.delete();
   }
    
   if (isObject(LevelEditorChunkedSpriteTool))
   {
      %toolManager.removeTool(LevelEditorChunkedSpriteTool);
      LevelEditorChunkedSpriteTool.delete();
   }
    
   if (isObject(LevelEditorAnimatedSpriteTool))
   {
      %toolManager.removeTool(LevelEditorAnimatedSpriteTool);
      LevelEditorAnimatedSpriteTool.delete();
   }

   if (isObject(LevelEditorPolyTool))
   {
      %toolManager.removeTool(LevelEditorPolyTool);
      LevelEditorPolyTool.delete();
   }

   if (isObject(LevelEditorMountTool))
   {
      %toolManager.removeTool(LevelEditorMountTool);
      LevelEditorMountTool.delete();
   }
   
   if (isObject(LevelEditorCameraTool))
   {
      %toolManager.removeTool(LevelEditorCameraTool);
      LevelEditorCameraTool.delete();
   }
   
   if (isObject(LevelEditorWorldLimitTool))
   {
      %toolManager.removeTool(LevelEditorWorldLimitTool);
      LevelEditorWorldLimitTool.delete();
   }
   
   if (isObject(LevelEditorTileMapEditTool))
   {
      %toolManager.removeTool(LevelEditorTileMapEditTool);
      LevelEditorTileMapEditTool.delete();
   }
}

function LevelBuilderToolManager::setTool( %toolId )
{
   if (!ToolManager.setActiveTool(%toolId) && ToolManager.getActiveTool() != 0 )
   {
      if (isObject(ToolManager.getActiveTool().button))
         ToolManager.getActiveTool().button.setStateOn( true );
   }
}

function LevelBuilderToolManager::setCreateTool( %type )
{
   $selectedCreateType = %type;
   switch$ ($selectedCreateType)
   {
      case "t2dStaticSprite":
         ToolManager.setActiveTool(LevelEditorStaticSpriteTool);
      case "t2dAnimatedSprite":
         ToolManager.setActiveTool(LevelEditorAnimatedSpriteTool);
      case "t2dChunkedSprite":
         ToolManager.setActiveTool(LevelEditorChunkedSpriteTool);
      case "t2dScroller":
         ToolManager.setActiveTool(LevelEditorScrollerTool);
      case "t2dTileLayer":
         ToolManager.setActiveTool(LevelEditorTileMapTool);
         LevelEditorTileMapTool.setTileMap(LevelBuilderToolManager::getGlobalTileMap());
      case "t2dParticleEffect":
         ToolManager.setActiveTool(LevelEditorParticleTool);
      case "t2dShape3D":
         ToolManager.setActiveTool(LevelEditor3DShapeTool);
      case "t2dSceneObject":
         ToolManager.setActiveTool(LevelEditorSceneObjectTool);
      case "t2dTextObject":
         ToolManager.setActiveTool(LevelEditorTextObjectTool);
      case "t2dTrigger":
         ToolManager.setActiveTool(LevelEditorTriggerTool);
      case "t2dShapeVector":
         ToolManager.setActiveTool(LevelEditorShapeVectorTool);
      case "t2dPath":
         ToolManager.setActiveTool(LevelEditorPathTool);
   }
   if (isObject(ToolManager.getActiveTool().button))
      ToolManager.getActiveTool().button.setStateOn( true );
      
   // Update Class/SuperClass Links
   LevelBuilderToolManager::updateClassLink( ToolManager.classLink );
   LevelBuilderToolManager::updateSuperClassLink( ToolManager.superClassLink );
   LevelBuilderToolManager::updateConfigDatablockLink( ToolManager.configDatablockLink );
   
}

function LevelBuilderToolManager::getGlobalTileMap()
{
   %scenegraph = ToolManager.getLastWindow().getSceneGraph();
   if (isObject(%scenegraph))
      return %scenegraph.getGlobalTileMap();
   
   return 0;
}

//---------------------------------------------------------------------------------------------
// Update link of Class Namespace with Active Tool
//---------------------------------------------------------------------------------------------
function LevelBuilderToolManager::updateClassLink( %newLink )
{
   ToolManager.classLink = %newLink;
   
   %tool = ToolManager.getActiveTool();
   
   // Update Create Tool Link
   if( %tool.isMemberOfClass("LevelBuilderCreateTool") )
      %tool.setClassName( %newLink );
}

//---------------------------------------------------------------------------------------------
// Update link of SuperClass Namespace with Active Tool
//---------------------------------------------------------------------------------------------
function LevelBuilderToolManager::updateSuperClassLink( %newLink )
{
   ToolManager.superClassLink = %newLink;
   
   %tool = ToolManager.getActiveTool();
   
   // Update Create Tool Link
   if( %tool.isMemberOfClass("LevelBuilderCreateTool") )
      %tool.setSuperClassName( %newLink );
}

//---------------------------------------------------------------------------------------------
// Update link of Config Datablock with Active Tool
//---------------------------------------------------------------------------------------------
function LevelBuilderToolManager::updateConfigDatablockLink( %newLink )
{
   ToolManager.configDatablockLink = %newLink;
   
   %tool = ToolManager.getActiveTool();
   
   // Update Create Tool Link
   if( %tool.isMemberOfClass("LevelBuilderCreateTool") )
      %tool.setConfigDatablock( %newLink );
}

function LevelBuilderSceneWindow::onEscapeTool( %this )
{
   ToolManager.setActiveTool( LevelEditorSelectionTool );
} 