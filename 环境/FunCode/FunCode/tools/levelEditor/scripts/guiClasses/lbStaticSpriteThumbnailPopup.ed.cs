//-----------------------------------------------------------------------------
// LevelBuilder Static Sprite Thumbmnail Popup
// Copyright (C) GarageGames.com, Inc.
//-----------------------------------------------------------------------------
//
// Object Hierarchy for guiThumbnailPopup - Quick Ref
//
// [%scriptObject] ScriptObject (GuiThumbnailPopup)
//   .superClass (ContextDialogContainer)
// (%scriptObject)->[%dialogCtrl] 
//                 | GuiScrollCtrl [%scrollCtrl] (GuiThumbnailArray)
//                 | GuiDynamicCtrlArrayCtrl [%objectList] (GuiThumbnailCreator)
//                   .superClass ( listType )
//                   .thumbType = %thumbType
//                   .base = %this
// 
function LBObjectThumbnail::createStaticSpritePopup( %parent )
{
   %MyContextDialog = new ScriptObject() 
   {
      class           = GuiThumbnailPopup;
      superClass      = ContextDialogContainer;
      listType        = "LBStaticSpritesList";
      thumbType       = "GuiStaticSpriteThumbnail";
      thumbSizeX      = "58";
      thumbSizeY      = "58";
      parentControl   = %parent;
      label           = "¾²Ì¬¾«Áé(Sprites)...";
   };
   return %MyContextDialog;   
}

function LBObjectThumbnail::createImageMapFramePopup( %parent )
{
   %MyContextDialog = new ScriptObject() 
   {
      class           = GuiThumbnailPopup;
      superClass      = ContextDialogContainer;
      listType        = "LBImageMapFrameList";
      thumbType       = "GuiImageMapFrameThumbnail";
      thumbSizeX      = "58";
      thumbSizeY      = "58";
      parentControl   = %parent;
      object          = "";
      label           = "Ö¡...";
   };
   return %MyContextDialog;   
}

//-----------------------------------------------------------------------------
// Static Sprite Thumbnail List Logic
//-----------------------------------------------------------------------------

function GuiThumbnailCreator::onAdd( %this )
{
   %this.scenegraph = new t2dSceneGraph();
}

function GuiThumbnailCreator::onRemove( %this )
{
   if( isObject( %this.sceneGraph ) )
      %this.sceneGraph.delete();
}

function GuiThumbnailCreator::onWake( %this )
{
   %this.schedule( 10, refreshList );
}

function GuiThumbnailCreator::onSleep( %this )
{
   %this.schedule( 10, destroyList );
}

function LBStaticSpritesList::refreshList(%this)
{
   %this.destroyList();
   
   %datablockSet = getT2DDatablockSet();
   %datablockCount = %datablockSet.getCount();

   for (%i = 0; %i < %datablockCount; %i++ )
   {
      %object = %datablockSet.getObject( %i );
      if( %object.getClassName() $= "t2dImageMapDatablock" )
      {
	      // Create Sprite Object
         %staticSprite = new t2dStaticSprite()  { scenegraph = %this.SceneGraph; };
         %staticSprite.setImageMap( %object.getName() );
         %staticSprite.setSize( %object.getFrameSize(0) );
         %this.AddObject( %staticSprite, %object.getName(), %object.getName() );
      }
   }
   
   %this.refresh();
}

function LBStaticSpritesList::destroyList( %this )
{
   while( %this.getCount() > 0 )
   {
      %object = %this.getObject( 0 );
      %object.delete();
   }
}

function LBStaticSpritesList::AddObject( %this, %object, %data, %tooltip )
{
   // Don't forget the parent!
   %container = Parent::AddObject( %this, %object, %data, %tooltip );

   if (!isObject( %container ) )
      return;
           
   // -- render control
   %t2dContainer = new guiT2DObjectCtrl()
   {
      Profile = ObjectBrowserThumbProfile @ $levelEditor::ObjectLibraryBackgroundColor;
      RenderMargin = 3;
      extent = %this.base.thumbSizeX SPC %this.base.thumbSizeY;
      position = "0 0";
      visible = true;
      toolTipProfile = EditorToolTipProfile;
      tooltip = %toolTip; // Special Tag - Identifies the tooltip to show when hovering this item.
      data = %data; // Special Tag - Data associated with this item
      class = %this.thumbType; // Special Tag - Identifies the namespace to callback for object creation
      base = %this.base; // Special Tag - Identifies Context Container Class
      listObj = %this; // Special Tag - Identifies Object List for selection callbacks     
   };
   %t2dContainer.setSceneObject( %object );

   // Add to container
   %container.add( %t2dContainer );  
   
}

//
// Click to change button functionality
//
function LBStaticSpritesButton::onClick( %this )
{
   %this.base.popupDlg.show( GetWord( %this.getGlobalPosition(), 0) - GetWord( %this.base.popupDlg.Dialog.getExtent(), 0), GetWord( %this.getGlobalPosition(), 1) );
}



function LBImageMapFrameList::refreshList(%this)
{
   %this.destroyList();
   
   %imagemap = %this.base.object.getImageMap();
   %frames = 0;
   if( isObject( %imagemap ) && ( %imageMap.getClassName() $= "t2dImageMapDatablock" ) )
      %frames = %imageMap.getFrameCount();

   for (%i = 0; %i < %frames; %i++ )
   {
      // Create Sprite Object
      %staticSprite = new t2dStaticSprite()  { scenegraph = %this.SceneGraph; };
      %staticSprite.setImageMap( %imageMap );
      %staticSprite.setSize( %imageMap.getFrameSize(0) );
      %staticSprite.setFrame( %i );
      %this.AddObject( %staticSprite, %imageMap.getName(), %i, %imageMap.getName() );
   }
   
   %this.refresh();
}

function LBImageMapFrameList::destroyList( %this )
{
   while( %this.getCount() > 0 )
   {
      %object = %this.getObject( 0 );
      %object.delete();
   }
}

function LBImageMapFrameList::AddObject( %this, %object, %data, %frame, %tooltip )
{
   // Don't forget the parent!
   %container = Parent::AddObject( %this, %object, %data, %tooltip );

   if (!isObject( %container ) )
      return;
           
   // -- render control
   %t2dContainer = new guiT2DObjectCtrl()
   {
      Profile = ObjectBrowserThumbProfile @ $levelEditor::ObjectLibraryBackgroundColor;
      RenderMargin = 3;
      extent = %this.base.thumbSizeX SPC %this.base.thumbSizeY;
      position = "0 0";
      visible = true;
      toolTipProfile = EditorToolTipProfile;
      tooltip = %toolTip; // Special Tag - Identifies the tooltip to show when hovering this item.
      data = %data; // Special Tag - Data associated with this item
      class = %this.thumbType; // Special Tag - Identifies the namespace to callback for object creation
      superclass = GuiDefaultThumbnail;
      base = %this.base; // Special Tag - Identifies Context Container Class
      listObj = %this; // Special Tag - Identifies Object List for selection callbacks     
      frameNumber = %frame;
   };
   %t2dContainer.setSceneObject( %object );

   // Add to container
   %container.add( %t2dContainer );  
   
}

function GuiImageMapFrameThumbnail::onClick( %this )
{
   ActiveBrush.setFrame( %this.frameNumber );
   Parent::onClick( %this );
}
