//-----------------------------------------------------------------------------
// Object Library Base Type Utilities
// Copyright (C) GarageGames.com, Inc.
//-----------------------------------------------------------------------------
$LB::ObjectLibraryGroup = "LBObjectLibraryGroup";


if( !isObject( $LB::ObjectLibraryGroup ) )
   new SimGroup( $LB::ObjectLibraryGroup );

//-----------------------------------------------------------------------------
// Form Content Creation Function
//-----------------------------------------------------------------------------
function ObjectLibraryBaseType::CreateContent( %contentCtrl, %class )
{    
   %base = new GuiRolloutCtrl() 
   {
      canSaveDynamicFields = "0";
      Profile = "EditorRolloutProfile";
      superClass = "ObjectLibraryBaseClass";
      HorizSizing = "width";
      VertSizing = "height";
      Position = "0 0";
      Extent = "358 20";
      MinExtent = "8 2";
      canSave = "1";
      Visible = "1";
      hovertime = "1000";
      Margin = "8 8";
      DefaultHeight = "64";
      class = %class;
      DragSizable = false;
   };
   %objectList = new GuiDynamicCtrlArrayControl() 
   {
            canSaveDynamicFields = "0";
            Profile = "EditorTransparentScrollProfile";
            class = "ObjectLibraryBaseType";
            HorizSizing = "width";
            VertSizing = "height";
            Position = "0 0";
            Extent = "358 20";
            MinExtent = "64 64";
            canSave = "1";
            Visible = "1";
            internalName = "objectList";
            hovertime = "1000";
            colCount = "0";
            colSize = "58";
            rowSize = "78";
            rowSpacing = "2";
            colSpacing = "2";
   };
   %base.add(%objectList);
   %contentCtrl.add(%base);
  
   return %base;

}

//-----------------------------------------------------------------------------
//
// Library Manipulation Functions
//
//-----------------------------------------------------------------------------
function ObjectLibraryBaseType::ClearLibrary( %this )
{
   // Clear our Scenegraph
   if( isObject( %this.SceneGraph ) )
      %this.SceneGraph.clearScene();

   %objectScroll = %this.findObjectByInternalName("objectScroll");
   %objectList = %objectScroll.findObjectByInternalName("ObjectList");

   while( %objectList.getCount() > 0 )
   {
      %object = %objectList.getObject( 0 );
      if( isObject( %object ) )
         %object.delete();
      else
         %objectList.remove( %object );
   }

}

function ObjectLibraryBaseClass::clearSelections( %this )
{
   %objectList = %this.findObjectByInternalName("ObjectList");
   %count = %objectList.getCount();
   for (%i = 0; %i < %count; %i++)
      %objectList.getObject(%i).button.setStateOn(false);
}

function ObjectLibraryBaseClass::changeProfiles( %this, %color )
{
   %objectList = %this.findObjectByInternalName("ObjectList");
   %count = %objectList.getCount();
   for (%i = 0; %i < %count; %i++)
   {
      %object = %objectList.getObject(%i).getObject(1);
      %object.profile = "ObjectBrowserThumbProfile" @ %color;
   }
}

function ObjectLibraryBaseClass::destroy( %this )
{
   if (isObject(%this.scenegraph))
      %this.scenegraph.delete();
      
   // Find objectList
   %objectList = %this.findObjectByInternalName("ObjectList");

   if( !isObject( %objectList ) )
      return;

   while( %objectList.getCount() > 0 )
   {
      %object = %objectList.getObject( 0 );
      if( isObject( %object ) )
         %object.delete();
      else
         %objectList.remove( %object );
   }
}

//-----------------------------------------------------------------------------
// Add a T2D Object to the Object List
//-----------------------------------------------------------------------------
function ObjectLibraryBaseType::AddT2DObject( %this, %t2dObject, %datablockName, %toolType, %caption )
{
   // Validate Object (Should check to make sure it's a t2d object?)
   if( !isObject( %t2dObject ) )
   {
      error("ObjectBrowserDlg::AddT2DObject - Invalid Object!");
      return;
   }
   
   $LB::ObjectLibraryGroup.add( %t2dObject );
   
   if (isObject(%datablockName) && $ignoredDatablockSet.isMember(%datablockName))
      return;
      
   // Build T2D Object Container
   if( %caption !$= "" )
      %container = new GuiButtonCtrl() { class = ObjectBrowserItemCaption; profile = EditorButton; };
   else
      %container = new GuiControl() { profile = GuiTransparentProfile; };
   
   // -- object caption
   %containerCaption = new GuiTextCtrl() 
   {
      profile = EditorDecorativeTextHLCenter12;
      position = "0 58";
      extent = "58 20";      
      text = %caption;
      tooltipProfile = EditorToolTipProfile;
      toolTip = %caption;
      hovertime = 100;
   };
   %container.add( %containerCaption );
   
   
   // -- render control
   %t2dContainer = new guiT2DObjectCtrl()
   {
      class = "ObjectBrowserItem";
      Profile = ObjectBrowserThumbProfile @ $levelEditor::ObjectLibraryBackgroundColor;
      RenderMargin = 3;
      groupNum = 1337;
      extent = "58 58";
      position = "0 0";
      datablockName = %datablockName;
      toolType = %toolType;
      caption = %containerCaption;
      tooltip = %caption;//%datablockName;
      toolTipProfile = EditorToolTipProfile;
   };
   %t2dContainer.setSceneObject( %t2dObject );
   %container.add( %t2dContainer );
   
   %container.button = %t2dContainer;
   
   // Add to list.
   %this.add( %container );
}


function ObjectBrowserItemCaption::onClick( %this )
{
   %datablockName = %this.button.datablockName;
   %toolType      = %this.button.toolType;

   if( %datablockName $= "" )
   {
      error("ObjectBrowserItem::onClick - Invalid datablock specified!" SPC %datablockName );
      return;
   }

   switch$( %toolType )
   {
      case "t2dStaticSprite":
         %object = %this.button.getSceneObject();
         %imageMode = %datablockName.getImageMapMode();
         if( (%imageMode $= "CELL") || (%imageMode $= "LINK") || (%imageMode $= "KEY") )
         {
            %currentFrame = %object.getFrame();
            %totalFrames  = %datablockName.getFrameCount();
            if( %currentFrame >= ( %totalFrames - 1 ) )
               %nextFrame = 0;
            else
               %nextFrame = %currentFrame + 1;
               
            %caption = (%nextFrame + 1) @ "/" @ %totalFrames;
            if( isObject( %this.button.caption ) )
               %this.button.caption.setText( %caption );
               
            %currentFrame = %nextFrame;
         }
         else
            %currentFrame = 0;
            
         levelEditorStaticSpriteTool.setImageMap( %datablockName, %currentFrame );   
         %object.setImageMap( %datablockName, %currentFrame );
         %object.setSize( %datablockName.getFrameSize( %currentFrame ) );
               
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
      case "t2dTrigger":
   }
   // Set the proper tool for this object.
   LevelBuilderToolManager::setCreateTool( %toolType );
   
   
}

function ObjectBrowserItemCaption::onRightClick( %this )
{
   %datablockName = %this.button.datablockName;
   %toolType      = %this.button.toolType;

   if( %datablockName $= "" )
   {
      error("ObjectBrowserItem::onRightClick - Invalid datablock specified!" SPC %datablockName );
      return;
   }

   switch$( %toolType )
   {
      case "t2dStaticSprite":
         %object = %this.button.getSceneObject();
         %imageMode = %datablockName.getImageMapMode();
         if( (%imageMode $= "CELL") || (%imageMode $= "LINK") || (%imageMode $= "KEY") )
         {
            %currentFrame = %object.getFrame();
            %totalFrames  = %datablockName.getFrameCount();
            if( %currentFrame <= 0 )
               %nextFrame = %totalFrames - 1;
            else
               %nextFrame = %currentFrame - 1;
               
            %caption = (%nextFrame + 1) @ "/" @ %totalFrames;
            if( isObject( %this.button.caption ) )
               %this.button.caption.setText( %caption );
               
            %currentFrame = %nextFrame;
         }
         else
            %currentFrame = 0;
            
         levelEditorStaticSpriteTool.setImageMap( %datablockName, %currentFrame );   
         %object.setImageMap( %datablockName, %currentFrame );
         %object.setSize( %datablockName.getFrameSize( %currentFrame ) );
               
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
      case "t2dTrigger":
   }
   // Set the proper tool for this object.
   LevelBuilderToolManager::setCreateTool( %toolType );
   
   
}

//-----------------------------------------------------------------------------
// Object Browser Item Default Behaviors
//-----------------------------------------------------------------------------
function ObjectBrowserItem::onMouseLeave( %this )
{
   %datablockName = %this.datablockName;
   %toolType      = %this.toolType;

   switch$( %toolType )
   {
      case "t2dStaticSprite":
      case "t2dAnimatedSprite":
      case "t2dChunkedSprite":
      case "t2dScroller":
         %object = %this.getSceneObject();
         %object.setScroll(0,0);
      case "t2dTileLayer":
      case "t2dParticleEffect":
         %object = %this.getSceneObject();
         %object.setPaused(true);
      case "t2dShape3D":
         levelEditor3DShapeTool.setShape( %datablockName );
      case "t2dSceneObject":
      case "t2dTrigger":
   }

}

function ObjectBrowserItem::onMouseDragged( %this )
{
   %this.createDraggingControl(%this.getGlobalPosition(), Canvas.getCursorPos());
   
   %datablockName = %this.datablockName;
   %toolType      = %this.toolType;

   %this.onMouseLeave();
}

function ObjectBrowserItem::createDraggingControl(%this, %position, %offset)
{
   %root = Canvas.getContent();
   
   %dragControl = new GuiDragAndDropControl() {
      canSaveDynamicFields = "0";
      Profile = "GuiDefaultProfile";
      HorizSizing = "right";
      VertSizing = "bottom";
      Position = %position;
      Extent = %this.getExtent();
      MinExtent = "8 2";
      canSave = "1";
      Visible = "1";
      hovertime = "1000";
      deleteOnMouseUp = true;
   };

   %t2dControl = new guiT2DObjectCtrl() {
      canSaveDynamicFields = "0";
      Profile = "GuiModelessDialogProfile";
      HorizSizing = "right";
      VertSizing = "bottom";
      Position = "0 0";
      Extent = %this.getExtent();
      MinExtent = "8 2";
      canSave = "1";
      Visible = "1";
      hovertime = "1000";
      groupNum = "-1";
      buttonType = "RadioButton";
      renderMargin = "0";
      datablockName = %this.datablockName;
      toolType      = %this.toolType;
      
   };
   %t2dControl.setSceneObject(%this.getSceneObject());
   
   %dragControl.add(%t2dControl);
   
   %root.add(%dragControl);
   %xOffset = getWord(%offset, 0) - getWord(%position, 0);
   %yOffset = getWord(%offset, 1) - getWord(%position, 1);
   %dragControl.startDragging(%xOffset, %yOffset);
}

function ObjectBrowserItem::onMouseEnter( %this )
{
   %datablockName = %this.datablockName;
   %toolType      = %this.toolType;

   switch$( %toolType )
   {
      case "t2dStaticSprite":
      case "t2dAnimatedSprite":
      case "t2dChunkedSprite":
      case "t2dScroller":
         %object = %this.getSceneObject();
         %object.setScroll(%object.getWidth() * 0.5, 0);
      case "t2dTileLayer":
      case "t2dParticleEffect":
         %object = %this.getSceneObject();
         %object.setPaused(false);
      case "t2dShape3D":
      case "t2dSceneObject":
      case "t2dTrigger":
   }

}

function ObjectBrowserItem::onClick( %this )
{
   %datablockName = %this.datablockName;
   %toolType      = %this.toolType;

   if( %datablockName $= "" )
   {
      error("ObjectBrowserItem::onClick - Invalid datablock specified!" SPC %datablockName );
      return;
   }

   switch$( %toolType )
   {
      case "t2dStaticSprite":
         //
         // If the object is already selected and it's a CELL image map, move to the next FRAME.
         //
            %object = %this.getSceneObject();
            %imageMode = %datablockName.getImageMapMode();
            if( (%imageMode $= "CELL") || (%imageMode $= "LINK") || (%imageMode $= "KEY") )
               %currentFrame = %object.getFrame();
            else
               %currentFrame = 0;

            $selectedStaticSprite = %datablockName;
            levelEditorStaticSpriteTool.setImageMap( %datablockName, %currentFrame );
      case "t2dAnimatedSprite":
         %object = %this.getSceneObject();
         %object.playAnimation(%object.getAnimation(),0,0);
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
      case "t2dTrigger":
   }

   // rdbnote: don't do this, because we don't want to create objects by
   // having something selected. they should physically drag and drop the
   // item, this also fixes a problem with selecting an object that is
   // already created after having selected an object in the create sidebar
   // Set the proper tool for this object.
   //LevelBuilderToolManager::setCreateTool( %toolType );
}


function ObjectBrowserItem::onDoubleClick( %this )
{  
   %datablockName = %this.datablockName;
   %toolType      = %this.toolType;

   if( %datablockName $= "" )
   {
      //error("ObjectBrowserItem::onDoubleClick - Invalid datablock specified!" SPC %datablockName );
      return;
   }

   switch$( %toolType )
   {
      case "t2dScroller":
         launchEditImageMap(%datablockName);
      case "t2dStaticSprite":
         launchEditImageMap(%datablockName);
      case "t2dAnimatedSprite":
         AnimationBuilder.editAnimation(%datablockName);
   }
}
