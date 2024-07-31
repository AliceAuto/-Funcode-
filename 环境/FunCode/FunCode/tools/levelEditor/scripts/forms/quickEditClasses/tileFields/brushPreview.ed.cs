function LBQuickEditContent::createBrushPreview(%this)
{
   %container = new GuiControl() {
      canSaveDynamicFields = "0";
      Profile = "EditorContainerProfile";
      HorizSizing = "right";
      VertSizing = "bottom";
      Position = "0 0";
      Extent = "300 138";
      MinExtent = "8 2";
      canSave = "1";
      Visible = "1";
      hovertime = "100";
   };
   
   %scenegraph = new t2dSceneGraph();
   
   // -- render control
   %t2dContainer = new guiT2DObjectCtrl()
   {
      class = "QuickEditBrushPreview";
      Profile = ObjectBrowserThumbProfile @ $levelEditor::ObjectLibraryBackgroundColor;
      RenderMargin = 6;
      extent = "128 128";
      position = "10 5";
      toolTipProfile = EditorToolTipProfile;
      scenegraph = %scenegraph;
   };
   
   %mouseEvent = new GuiMouseEventCtrl()
   {
      class = "QuickEditCollisionPoly";
      extent = "128 128";
      position = "10 5";
      dragPoint = "-1";
   };
   
   %t2dContainer.mouseEvent = %mouseEvent;
   %container.add( %t2dContainer );
   %container.add( %mouseEvent );
   
   %this.addProperty(%t2dContainer);
   %this.addProperty(%mouseEvent);
   %this.add(%container);
   return %container;
}

function QuickEditBrushPreview::setProperty(%this)
{
   %image = ActiveBrush.getImage();
   %frame = ActiveBrush.getFrame();
   %flipX = ActiveBrush.getFlipX() > 0;
   %flipY = ActiveBrush.getFlipY() > 0;
   %collision = ActiveBrush.getCollision() > 0;
   
   %object = "";
   
   if (isObject(%image))
   {
      if (%image.getClassName() $= "t2dAnimationDatablock")
      {
         %object = new t2dAnimatedSprite()
         {
            scenegraph = %this.scenegraph;
            animationName = %image;
         };
      }
         
      else if (%image.getClassName() $= "t2dImageMapDatablock")
      {
         %object = new t2dStaticSprite()
         {
            scenegraph = %this.scenegraph;
            imageMap = %image;
            frame = %frame;
         };
      }
   }
   
   else
   {
      %object = new t2dSceneObject()
      {
         scenegraph = %this.scenegraph;
      };
   }
   
   if (%object !$= "")
   {
      %object.setCollisionActive(false, %collision);
      %object.setFlip(%flipX, %flipY);
      %object.setPosition(%object.getPosition());
      %object.setDebugOn(5);
   }
   
   %oldObject = %this.getSceneObject();
   if (isObject(%oldObject))
      %oldObject.delete();
   
   if (isObject(%object))
   {
      %size = ActiveBrush.getTileSize();
      %ar = getWord( %size, 0 ) / getWord( %size, 1 );
      %x = 20;
      %y = 20;
      if( %ar > 1 )
         %y /= %ar;
      else if( %ar < 1 )
         %x *= %ar;
         
      %object.setSize( %x SPC %y );
   }
   
   %this.mouseEvent.sceneobject = %object;
   %this.setSceneObject( %object );
}

function QuickEditCollisionPoly::onMouseDown(%this, %modifier, %mousePoint, %clickCount)
{
   if (!isObject(%this.sceneobject))
      return;
      
   if (ActiveBrush.getCollision() != 1)
      return;
   
   %point = %this.getLocalPoint( %mousePoint );
   %x = getWord(%point, 0);
   %y = getWord(%point, 1);
   
   %this.dragPoint = ActiveBrush.findPolyPoint(%x, %y);
   if (%this.dragPoint < 0)
      %this.dragPoint = ActiveBrush.addPolyPoint(%x, %y);
      
   %this.setProperty();
}

function QuickEditCollisionPoly::onMouseDragged(%this, %modifier, %mousePoint, %clickCount)
{
   if (!isObject(%this.sceneobject))
      return;
      
   if (ActiveBrush.getCollision() != 1)
      return;
   
   %point = %this.getLocalPoint( %mousePoint );
   %x = getWord(%point, 0);
   %y = getWord(%point, 1);
   
   if (%this.dragPoint >= 0)
   {
      ActiveBrush.movePolyPoint(%this.dragPoint, %x, %y);
      %this.setProperty();
   }
}

function QuickEditCollisionPoly::onRightMouseDown(%this, %modifier, %mousePoint, %clickCount)
{
   if (!isObject(%this.sceneobject))
      return;
      
   if (ActiveBrush.getCollision() != 1)
      return;
   
   %point = %this.getLocalPoint( %mousePoint );
   %x = getWord(%point, 0);
   %y = getWord(%point, 1);
   
   ActiveBrush.removePolyPoint(%x, %y);
   %this.setProperty();
}

function QuickEditCollisionPoly::setProperty(%this)
{
   if (!isObject(%this.sceneobject))
      return;
      
   if (ActiveBrush.getCollision() != 1)
      return;
      
   %poly = ActiveBrush.getCollisionPoly();
   %count = getWordCount(%poly);
   if (%count > 0)
      %this.sceneobject.setCollisionPolyCustom(getWordCount(%poly) / 2, %poly);
}

function QuickEditCollisionPoly::getLocalPoint( %this, %mousePoint )
{
   %tileSize = ActiveBrush.getTileSize();
   %tileWidth = getWord( %tileSize, 0 );
   %tileHeight = getWord( %tileSize, 1 );
   %ar = %tileWidth / %tileHeight;
   
   %posX = getWord(%this.getGlobalPosition(), 0) + 6;
   %posY = getWord(%this.getGlobalPosition(), 1) + 6;
   %sizeX = getWord(%this.getExtent(), 0) - 12;
   %sizeY = getWord(%this.getExtent(), 1) - 12;
   
   // Width greater than height.
   if( %ar > 1 )
   {
      %newSizeY = %sizeY / %ar;
      %posY += ( %sizeY - %newSizeY ) / 2;
      %sizeY = %newSizeY;
   }

   // Height greater than width.   
   else if( %ar < 1 )
   {
      %newSizeX = %sizeX * %ar;
      %posX += ( %sizeX - %newSizeX ) / 2;
      %sizeX = %newSizeX;
   }
   
   %x = getWord(%mousePoint, 0);
   %y = getWord(%mousePoint, 1);
   
   %x = %x - (%posX + (%sizeX / 2));
   %y = %y - (%posY + (%sizeY / 2));
   
   %x /= (%sizeX / 2);
   %y /= (%sizeY / 2);
   
   if( %x > 1 )
      %x = 1;
   else if( %x < -1 )
      %x = -1;
   
   if( %y > 1 )
      %y = 1;
   else if( %y < -1 )
      %y = -1;
      
   return %x SPC %y;
}
