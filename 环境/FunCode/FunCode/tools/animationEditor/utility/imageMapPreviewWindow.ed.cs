//------------------------------------------------------------------------------
// Torque Game Builder
// Copyright (C) GarageGames.com, Inc.
//------------------------------------------------------------------------------

/// @class ImageMapPreviewWindow
/// This class is a t2dSceneWindow that displays a single image map. It will
/// automatically manage displaying each of the frames in a different sprite
/// at the correct aspect ratio. After creating a t2dSceneWindow and assigning
/// it this class, call ImageMapPreviewWindow::display, passing it the image
/// map you would like to display. To update the display in the case of a
/// property change on the image map, call ImageMapPreviewWindow::update.
/// 
/// Sprites in the window have mouse events enabled, as does the window itself.
/// The sprites can be assigned a class by setting the 'spriteClass' field on
/// the window. The sprites also have a reference to the window that created
/// them so positional data can be properly extracted. This is on the 'window'
/// field. This should allow any sort of custom funniness that needs to go
/// on within the window.
/// 
/// @field scenegraph The scenegraph that renders the preview.
/// @field staticSpriteGroup A SimGroup that stores the t2dStaticSprites that
/// display the frames of the image.
/// @field spacing The amount of space between each frame of the image map.
/// @field baseDimension The length of the shorter side of the camera.
/// @field imageMap The image map being displayed display.

/// void(ImageMapPreviewWindow this)
/// Initializes various properties necessary for the window.
/// @param this The ImageMapPreviewWindow.
function ImageMapPreviewWindow::onAdd(%this)
{
   t2dAssert(%this.getClassName() $= "t2dSceneWindow",
             "ImageMapPreviewWindow::onAdd - This is not a t2dSceneWindow!");
   
   %this.scenegraph = new t2dSceneGraph();
   %this.staticSpriteGroup = new SimGroup();
   %this.spacing = 2;
   %this.baseDimension = 100;
   %this.imageMap = "";
   %this.useObjectMouseEvents = true;
   %this.useWindowMouseEvents = true;
   %this.spriteClass = "";
   %this.showCell = false;
   %this.setFillBackGround( true, 128, 128, 128 );
   
   %this.setSceneGraph(%this.scenegraph);
}

/// void(ImageMapPreviewWindow this)
/// Cleans up data allocated for this window.
/// @param this The ImageMapPreviewWindow.
function ImageMapPreviewWindow::onRemove(%this)
{
   if (isObject(%this.scenegraph))
      %this.scenegraph.delete();
      
   if (isObject(%this.staticSpriteGroup))
      %this.staticSpriteGroup.delete();
}

/// void(ImageMapPreviewWindow this)
/// Called when the window is first shown to make sure things are properly
/// sized.
/// @param this The ImageMapPreviewWindow.
function ImageMapPreviewWindow::onWake(%this)
{
   // rdbnote: this doesn't actually do anything because we don't have an image
   %this.updateSize();
}

/// void(ImageMapPreviewWindow this, RectF newDimensions)
/// Resizes the scenegraphs camera to maintain the correct aspect ratio.
/// @param this The ImageMapPreviewWindow.
/// @param newDimensions The new position and size of the window.
function ImageMapPreviewWindow::onExtentChange(%this, %newDimensions)
{
   %this.updateSize();
}

function ImageMapPreviewWindow::setShowCell(%this, %show)
{
   %this.showCell = %show;
}

/// void(ImageMapPreviewWindow this, t2dImageMapDatablock imageMap)
/// Displays the specified image map in this window.
/// @param this The ImageMapPreviewWindow.
/// @param imageMap The image map to display.
function ImageMapPreviewWindow::display(%this, %imageMap)
{
   t2dAssert(isObject(%imageMap) && (%imageMap.getClassName() $= "t2dImageMapDatablock"),
             "ImageMapPreviewWindow::display - Object is not an image map!");
   
   %this.imageMap = %imageMap;
   %this.update();
}

/// void(ImageMapPreviewWindow this)
/// Clears the display.
/// @param this The ImageMapPreviewWindow.
function ImageMapPreviewWindow::clear(%this)
{
   %this.imageMap = "";
   %this.update();
}

/// void(ImageMapPreviewWindow this)
/// Updates the displayed image.
/// @param this The ImageMapPreviewWindow.
/// @todo This currently does not handle "LINK" or "KEY" mode image maps.
/// @todo This doesn't take advantage of width or height when displaying
/// non-square image maps.
function ImageMapPreviewWindow::update(%this)
{
   // Clear out the old stuff.
   %this.staticSpriteGroup.deleteContents();
   
   %imageMap = %this.imageMap;
   %scenegraph = %this.scenegraph;
   
   // Nothing doing if we don't have an image.
   if (!isObject(%imageMap))
      return;
      
   // because we need to make sure the camera size is right
   %this.updateSize();
   
   // Render the bounding boxes when not in full mode.
   if (%imageMap.imageMode $= "FULL" || (%imageMap.imageMode $= "CELL" && %this.showCell) )
      %scenegraph.setDebugOff(1);
   else
      %scenegraph.setDebugOn(1);
   
   %cameraSize = %this.getCurrentCameraSize();
   %maxWidth = getWord(%cameraSize, 0) - 1;
   %maxHeight = getWord(%cameraSize, 1) - 1;
   
   if (%imageMap.imageMode $= "FULL" || (%imageMap.imageMode $= "CELL" && %this.showCell) )
   {
      %imageSize = %imageMap.getSrcBitmapSize();
      %imgWidth = getWord(%imageSize, 0);
      %imgHeight = getWord(%imageSize, 1);
           
      if( (%imageMap.imageMode $= "CELL" && %this.showCell) )
      {
         %imgWidth = %imageMap.cellWidth;
         %imgHeight = %imageMap.cellHeight;
      }
      
      if (%imgWidth > %imgHeight)
      {
         %ratio = %imgHeight / %imgWidth;
         %imgWidth = %maxWidth;
         %imgHeight = %maxHeight * %ratio;
      }
      else if(%imgHeight > %imgWidth)
      {
         %ratio = %imgWidth / %imgHeight;
         %imgWidth = %maxWidth * %ratio;
         %imgHeight = %maxHeight;
      }
      else
      {
         %imgWidth = %maxWidth;
         %imgHeight = %maxHeight;
      }
      
      %sprite = new t2dStaticSprite()
      {
         class = %this.spriteClass;
         superClass = ImageMapPreviewSprite;
         sceneGraph = %scenegraph;
         imageMap = %imageMap;
         useMouseEvents = true;
         window = %this;
      };
      
      %sprite.setPosition("0 0");
      %sprite.setSize(%imgWidth SPC %imgHeight);
      
      // Add it to the cleanup group.
      %this.staticSpriteGroup.add(%sprite);
   }
   else
   {
      %baseX = 0;
      %baseY = 0;
      %frameCount = %imageMap.getFrameCount();
      
      %sqrt = mSqrt(%frameCount);
      %div = mCeil(%sqrt);
      
      %rowSpace = (%maxWidth / %div) * 0.05;
      %colSpace = (%maxHeight / %div) * 0.05;
      if (%rowSpace < 1.5)
         %rowSpace = 1.5;
      if (%colSpace < 1.5)
         %colSpace = 1.5;
         
      %objWidth = (%maxWidth / %div) - (%rowSpace + %this.spacing);
      %objHeight = (%maxHeight / %div) - (%colSpace + %this.spacing);
      
      %baseX += %this.spacing;
      %baseY += %this.spacing;
      
      %posX = %baseX - (%maxWidth / 2) + (%objWidth / 2);
      %posY = %baseY - (%maxHeight / 2) + (%objHeight / 2);
      
      %rowCount = 0;
      %colCount = 0;
      
      for (%i = 0; %i < %frameCount; %i++)
      {
         %sprite = new t2dStaticSprite()
         {
            class = %this.spriteClass;
            superClass = ImageMapPreviewSprite;
            scenegraph = %scenegraph;
            useMouseEvents = true;
            window = %this;
         };
         
         %sprite.setImageMap(%imageMap, %i);
         %sprite.setPosition(%posX, %posY);
         %sprite.setSize(%objWidth, %objHeight);
         
         %this.staticSpriteGroup.add(%sprite);
         
         if (%colCount >= %div - 1)
         {
            %rowCount++;
            %colCount = 0;
            %posX = %baseX - (%maxWidth / 2) + (%objWidth / 2);
            %posY = %baseY - (%maxHeight / 2) + (%objHeight / 2) + ((%objHeight + %rowSpace + %this.spacing) * %rowCount);
         }
         else
         {
            %colCount++;
            %posX = %baseX - (%maxWidth / 2) + (%objWidth / 2) + ((%objWidth + %colSpace + %this.spacing) * %colCount);
         }
      }
   }
}

/// void()
/// Updates the camera size to display images at the correct aspect ratio.
function ImageMapPreviewWindow::updateSize(%this)
{
   if(!isObject(%this.imageMap))
      return;
   
   if (%this.imageMap.imageMode $= "LINK")
   {
      // if we are in link mode, then getSrcBitmapSize is going
      // to return a "0 0" value, which will throw the normal
      // calculation way way off
      
      // grab the extent
      %extent = %this.getExtent();
      %this.setCurrentCameraPosition("0 0" SPC %extent);
   }
   else
   {
      // Grab some size info.
      %windowSize = %this.getExtent();
      %imageSize = %this.imageMap.getSrcBitmapSize();
      
      %windowAR = getWord(%windowSize, 0) /  getWord(%windowSize, 1);
      %imageAR = getWord(%imageSize, 0) / getWord(%imageSize, 1);
      
      // Basically, instead of sizing the images correctly, we're sizing the
      // camera at the inverse of the image's aspect ratio, thereby achieving the
      // same affect.
      %newSize = resolveAspectRatio(%windowAR / %imageAR, %this.baseDimension);
      %this.setCurrentCameraPosition("0 0", %newSize);
   }
}
