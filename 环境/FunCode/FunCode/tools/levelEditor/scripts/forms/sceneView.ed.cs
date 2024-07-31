//-----------------------------------------------------------------------------
// Gui SceneGraphEditCtrl Form Content
// Copyright (C) GarageGames.com, Inc.
//-----------------------------------------------------------------------------

//-----------------------------------------------------------------------------
// Register Form Content.
//-----------------------------------------------------------------------------
$LBSceneViewContent = GuiFormManager::AddFormContent( "LevelBuilder", "Scene View", "LBSceneWindow::CreateForm", "LBSceneWindow::SaveForm", 2 );

//-----------------------------------------------------------------------------
// Form Content Creation Function
//-----------------------------------------------------------------------------
function LBSceneWindow::CreateForm( %formCtrl )
{    
   %base = new LevelBuilderSceneWindow() 
   {
      class = "LevelBuilderSceneView";
      canSaveDynamicFields = "0";
      Profile = "LBSceneWindow";
      HorizSizing = "width";
      VertSizing = "height";
      position = "0 32";
      Extent = "668 543";
      MinExtent = "10 10";
      canSave = "0";
      visible = "1";
      internalName = "LevelBuilderSceneView";
      tooltipprofile = "GuiInputCtrlProfile";
      hovertime = "0";
      lockMouse = "0";
      useWindowMouseEvents = "1";
      useObjectMouseEvents = "0";
      bob = "your uncle";
   };
   %formCtrl.add(%base);
   %formCtrl.canSaveDynamicFields = 0;

   // Propagate Saved State Settings.
   if( %formCtrl.lastCameraZoom !$= "" )
      %base.setCurrentCameraZoom( %formCtrl.lastCameraZoom );
   if( %formCtrl.lastCameraPosition !$= "" )
      %base.setCurrentCameraPosition( %formCtrl.lastCameraPosition );

   if( %formCtrl.lastSceneGraph !$= "" && isObject( %formCtrl.lastSceneGraph ) && %formCtrl.lastSceneGraph.getClassName() $= "t2dSceneGraph" )
      %base.setSceneGraph( %formCtrl.lastSceneGraph );
   else if (isObject($currentSceneGraph))
      %base.setSceneGraph($currentSceneGraph);
   else
      // Request Notification of Active SceneGraph
      GuiFormManager::SendContentMessage( $LBSceneViewContent, %base, "getSceneGraph" );
      
  if (!isObject(ToolManager.getActiveTool()))
      LevelBuilderToolManager::setTool(LevelEditorSelectionTool);

      
   // Resize as appropriate.
   if( %formCtrl.isMethod("sizeContentsToFit") )
      %formctrl.sizeContentsToFit(%base, %formCtrl.contentID.margin);

   //*** Return back the base control to indicate we were successful
   return %base;

}

//-----------------------------------------------------------------------------
// Form Content Save Function
//-----------------------------------------------------------------------------
function LBSceneWindow::SaveForm( %formCtrl, %contentObj )
{
   %formCtrl.lastCameraZoom = %contentObj.getCurrentCameraZoom();
   %formCtrl.lastCameraPosition = %contentObj.getCurrentCameraPosition();
   %formCtrl.lastSceneGraph = %contentObj.getSceneGraph();
}

//-----------------------------------------------------------------------------
// Form Content Save Function
//-----------------------------------------------------------------------------
function LevelBuilderSceneView::onContentMessage( %this, %sender, %message )
{

   %command = GetWord( %message, 0 );
   %value   = GetWord( %message, 1 );

   switch$( %command )
   {
      case "updateScenegraph":
         // Update scenegraph to %value's scenegraph.
         if( isObject( %value ) )
            %this.setSceneGraph( %value );
      case "getSceneGraph":
         // Update sibling view with our scenegraph.
         if( %this.getSceneGraph() )
            %sender.onContentMessage( %this, "updateScenegraph " @ %this.getSceneGraph() );
      case "playScene":
         %this.testScene();
      case "pauseScene":
         %this.endTestScene();
   }
}

//-----------------------------------------------------------------------------
// Form Content Functionality
//-----------------------------------------------------------------------------
function LevelBuilderSceneView::onAdd(%this)
{
   if (!isObject(ToolManager))
      error("LevelBuilderSceneWindow::onAdd() - No ToolManager Found!");
   else
      %this.setSceneEdit(ToolManager);
}

function LevelBuilderSceneView::onRightMouseDown(%this, %modifier, %position, %clicks)
{
   %this.rightMouseDownPosition = %position;
}

function LevelBuilderSceneView::onRightMouseDragged(%this, %modifier, %position, %clicks)
{
   // NewPosition = OldPosition + (MouseDownPosition - MousePosition)
   %movement = t2dVectorSub(%this.rightMouseDownPosition, %position);
   %newPosition = t2dVectorAdd(%this.getCurrentCameraPosition(), %movement);
   
   %this.setCurrentCameraPosition(%newPosition);
}

function LevelBuilderSceneView::onMouseWheelDown(%this, %modifier, %position, %clicks)
{
   %zoom = %this.getCurrentCameraZoom();
   %amount = -120 * 0.0005 * %zoom;
   %this.setCurrentCameraZoom(%zoom + %amount);
}

function LevelBuilderSceneView::onMouseWheelUp(%this, %modifier, %position, %clicks)
{
   %zoom = %this.getCurrentCameraZoom();
   %amount = 120 * 0.0005 * %zoom;
   %this.setCurrentCameraZoom(%zoom + %amount);
}

function LevelBuilderSceneView::onControlDropped(%this, %control, %position)
{
   if (isObject(%control.sceneObject))
   {
      
      %datablockName = %control.datablockName;
      %toolType      = %control.toolType;
   
      switch$( %toolType )
      {
         case "t2dStaticSprite":
               %object = %control.getSceneObject();
               %imageMode = %datablockName.getImageMapMode();
               if( (%imageMode $= "CELL") || (%imageMode $= "LINK") || (%imageMode $= "KEY") )
               {
                  %currentFrame = %object.getFrame();
                  levelEditorStaticSpriteTool.setImageMap( %datablockName, %currentFrame );   
               }    
               else
                  levelEditorStaticSpriteTool.setImageMap( %datablockName, 0 );
               $selectedStaticSprite = %datablockName;
         case "t2dAnimatedSprite":
            $selectedAnimatedSprite = %datablockName;
            levelEditorAnimatedSpriteTool.setAnimation( %datablockName );
         case "t2dChunkedSprite":
            $selectedChunkedSprite = %datablockName;
            levelEditorChunkedSpriteTool.setImageMap( %datablockName );        
         case "t2dScroller":
            $selectedScroller = %datablockName;
            levelEditorScrollerTool.setImageMap( %datablockName );
         case "t2dTileLayer":
            $selectedTileMap = %datablockName;
            levelEditorTileMapTool.setTileLayerFile( %datablockName );
         case "t2dParticleEffect":
            $selectedParticleEffect = %datablockName;
            levelEditorParticleTool.setEffect( %datablockName );
         case "t2dShape3D":
            $selectedShape3D = %datablockName;
            levelEditor3DShapeTool.setShape( %datablockName );
         case "t2dSceneObject":
         case "t2dTextObject":
            LevelEditorTextObjectTool.setFontDB(defaultFontDB);
         case "t2dTrigger":
         case "t2dVector":
         case "t2dObjectTemplate":
            LevelBuilder::loadObjectTemplate( %datablockName, %this.getWorldPoint(t2dVectorSub(%position, %this.getGlobalPosition())) );
            return;
      }
   
      // Set the proper tool for this object.
      LevelBuilderToolManager::setCreateTool( %toolType );
      
      ToolManager.getActiveTool().createObject(%this, %this.getWorldPoint(t2dVectorSub(%position, %this.getGlobalPosition())));
   }
}
