function ImageEditor::previewWindowInit(%this)
{
   // lets store the layer for the highlight and the preview box
   %this.highLightLayer = 4;
   %this.previewZoomlayer = 3;
   
   // set the zoom out button to false and the zoom in buttons to true
   ImageEditorZoomOutButton.setVisible(false);
   ImageEditorZoomInButton.setVisible(true);
   ImageEditorZoomInSelectionButton.setVisible(true);
   
   // reset this value to empty
   ImageEditor.previousHighlightedObj = "";
   
   // set all of the zoom bools to false
   %this.zoomToggled = false;
   %this.zoomedIn = false;
   %this.zoomIn = false;
   %this.zoomInSelection = false;
   
   // if we haven't already, create the selection highlight box
   if(!isObject(%this.selectionHighlight))
   {
      %this.selectionHighlight = new t2dStaticSprite()
      {
         sceneGraph = $ImageEditorScene;    
         border = true;     
      };
      
      %this.selectionHighlight.setLayer(%this.highLightLayer);
      %this.selectionHighlight.setImageMap(ImageBuilderBackgroundImageMap);
      %this.selectionHighlight.setBlendColor(1, 0, 0, 0.45);
   }
   
   %this.selectionHighlight.setVisible(false);
      
   // hide the highlight box
   %this.setHighlight(true);
   
   // if we haven't already, create the selection preview box
   if(!isObject(%this.selectionPreview))
   {
      %this.selectionPreview = %this.createImageBorder();
      %this.selectionPreview.leftLine.setLayer(%this.previewZoomLayer);
      %this.selectionPreview.rightLine.setLayer(%this.previewZoomLayer);
      %this.selectionPreview.topLine.setLayer(%this.previewZoomLayer);
      %this.selectionPreview.bottomLine.setLayer(%this.previewZoomLayer);
   }
   
   %this.setPreviewColor("0 0 1 0.5");
      
   // hide the preview box
   %this.hidePreview();
   %this.setPreview(true);
}

function ImageEditor::previewCleanup(%this)
{
   %this.selectionHighlight.safeDelete();
   %this.selectionPreview.safeDelete();   
}

function ImageEditor::setHighlight(%this, %highlight)
{
   // set the bool show highlight value
   %this.showHighlight = %highlight;   
}

function ImageEditor::updateHighlight(%this, %pos, %size)
{
   // first we toggle the highlight to visible
   %this.selectionHighlight.setVisible(true);
   
   // next we set its size and position
   %this.selectionHighlight.setSize(%size);
   %this.selectionHighlight.setPosition(%pos);
   
   // reset its alpha to 0 and trigger a fade to 0.45
   %this.selectionHighlight.setBlendAlpha(0);
   %this.selectionHighlight.fadeToAlpha(3, 0.45, 20);   
}

function ImageEditor::hideHighlight(%this)
{
   // set the highlight to be invisible
   %this.selectionHighlight.setVisible(false);   
}

function ImageEditor::setPreviewColor(%this, %color)
{
   // set all of the line colors to the color passed
   %this.selectionPreview.leftLine.setBlendColor(%color);
   %this.selectionPreview.rightLine.setBlendColor(%color);
   %this.selectionPreview.topLine.setBlendColor(%color);
   %this.selectionPreview.bottomLine.setBlendColor(%color);   
}

function ImageEditor::hidePreview(%this)
{
   // set the selection preview to invisible and all of the lines
   %this.selectionPreview.setVisible(false); 
   %this.selectionPreview.leftLine.setVisible(false);
   %this.selectionPreview.rightLine.setVisible(false);
   %this.selectionPreview.topLine.setVisible(false);
   %this.selectionPreview.bottomLine.setVisible(false);
}

function ImageEditor::unhidePreview(%this)
{
   // set the preview to visible and all of the lines
   %this.selectionPreview.setVisible(true); 
   %this.selectionPreview.leftLine.setVisible(true);
   %this.selectionPreview.rightLine.setVisible(true);
   %this.selectionPreview.topLine.setVisible(true);
   %this.selectionPreview.bottomLine.setVisible(true);
}

function ImageEditor::setPreview(%this, %preview)
{
   // set the bool show preview  value
   %this.showPreview = %preview;   
}

function ImageEditor::updatePreview(%this, %pos)
{
   // first lets unhide the preview box in case it was hidden
   %this.unhidePreview();
   
   // now lets get the dimensions that we'd zoom into
   // if we were to click at this point
   %dimensions = %this.getZoomIntoDimensions(0.25, %pos);
   %width = getWord(%dimensions, 0);
   %height = getWord(%dimensions, 1);
   
   %size = %width SPC %height;
   
   // get a relative padding size (this controls line width for the border box)
   %div = 40;
   %wDiv = %width / %div;
   %hDiv = %hieght / %div;
   
   %padding = %wDiv + %hDiv;
   
   // now lets resize the border to show a preview of where to zoom
   %this.resizeImageBorder(%this.selectionPreview, %pos, %size, %padding);
}

function ImageBuilderImageSceneWindow::onMouseEnter( %this, %mod, %worldPos, %mouseClicks )
{
   // we only need to do something if a zoom is toggled
   if(ImageEditor.zoomToggled)
   {
      // yes the cursor will be set
      %this.cursorSet = true;
      
      // set the appropriate cursor
      if(ImageEditor.zoomInSelection)
      {
         Canvas.setCursor(ImageBuilderZoomCursor);            
      } else if(ImageEditor.zoomIn)
      {
         Canvas.setCursor(ImageBuilderZoomInCursor);
      }
   }
}

function ImageBuilderImageSceneWindow::onMouseLeave( %this, %mod, %worldPos, %mouseClicks )
{
   // check if the cursor was set
   if(%this.cursorSet)
   {
      // set the cursor to the default, then set cursor set to false
      Canvas.setCursor(DefaultCursor);
      %this.cursorSet = false;
      
      // this will make sure both the highlight and preview boxes are hidden
      ImageEditor.hideHighlight();
      ImageEditor.hidePreview();
   }    
}

function ImageBuilderImageSceneWindow::onMouseUp( %this, %mod, %worldPos, %mouseClicks )
{
   // check if the zoom is toggled
   if(ImageEditor.zoomToggled)
   {
      // get an object list and count at this position
      %objList = $ImageEditorScene.pickPoint(%worldPos);
      %objCount = getWordCount(%objList);
      
      // loop through and grab a non border object
      for(%i=0;%i<%objCount;%i++)
      {
         %obj = getWord(%objList, %i);
         if(!%obj.border)       
         {
            break;            
         }
      }
      
      // toggle the proper zoom states
      if(%obj !$= "" && !%obj.border && !ImageEditor.zoomedIn && ImageEditor.zoomInSelection)
      {
         ImageEditor.zoomIntoObject(%obj);      
      } else if(ImageEditor.zoomIn)
      {
         ImageEditor.zoomIntoPoint(%worldPos);
      } else
      {
         ImageEditor.zoomOut();
      }
   
   }
}

function ImageBuilderImageSceneWindow::onMouseMove( %this, %mod, %worldPos, %mouseClicks )
{
   // grab an object list and count of all object's at this point
   %objList = $ImageEditorScene.pickPoint(%worldPos);
   %objCount = getWordCount(%objList);
      
   // loop through the objects and break once we find a non border
   for(%i=0;%i<%objCount;%i++)
   {
      %obj = getWord(%objList, %i);
      if(!%obj.border)       
      {
         break;            
      }
   }
      
   // check to make sure there is an object and it isn't a border
   if(%obj !$= "" && !%obj.border)
   {  
      // get the source image size
      %srcSize = ImageEditor.selectedImage.getSrcBitmapSize();
      %srcWidth = getWord(%srcSize, 0);
      %srcHeight = getWord(%srcSize, 1); 
      
      // divide up the X and Y position   
      %mousePosX = getWord(%worldPos, 0);
      %mousePosY = getWord(%worldPos, 1);
        
      // grab the object's size that we're move over
      %objSize = %obj.getSize();
      %objWidth = getWord(%objSize, 0);
      %objHeight = getWord(%objSize, 1);
      
      if(ImageEditor.imageMode $= "FULL")
      {
         // this must be a full image, a lot less calcs can be done to 
         // figure out where on the source image our mouse is
      
         %mouseX = %mousePosX + (%objWidth / 2);
         %mouseY = %mousePosY + (%objHeight / 2);
      
         %widthRatio = %srcWidth / %objWidth;
         %heightRatio = %srcHeight / %objHeight;
         
         %srcMousePosX = %mouseX * %widthRatio;
         %srcMousePosY = %mouseY * %heightRatio;
      
         %srcMousePosX = trimAfter(%srcMousePosX, ".");
         %srcMousePosY = trimAfter(%srcMousePosY, ".");
      
         ImageEditorPreviewSrcPosition.setText("X =" SPC %srcMousePosX SPC "Y =" SPC %srcMousePosY);  
      } else if(ImageEditor.imageMode $= "CELL" || ImageEditor.imageMode $= "KEY")
      {
         // this must be a cell image, we have to take the borders
         // and padding into account to calc where our mouse is
         // on the source image
         
         %row = %obj.row;
         %col = %obj.col;
         
         %totalRowPadding = %rowPadding * %row;
         %totalColPadding = %colPadding * %col;
         
         %totalObjWidth = %objWidth * %col;
         %totalObjHeight = %objHeight * %row;
         
         %frameCount = ImageEditor.selectedImage.getFrameCount();
                  
         %sqrt = mSqrt(%frameCount);
         %div = mCeil(%sqrt);
         
         %totalObjWidthSize = %div * %objWidth;
         %totalObjHeightSize = %div * %objHeight;
         
         %objectSpanX = %mousePosX - (%obj.getPositionX() - (%objWidth/2));
         %objectSpanY = %mousePosY - (%obj.getPositionY() - (%objHeight/2));
         
         %widthRatio = %srcWidth / %totalObjWidthSize;
         %heightRatio = %srcHeight / %totalObjHeightSize;
         
         %srcMousePosX = %totalColPadding + %totalObjWidth + %objectSpanX;
         %srcMousePosY = %totalRowPadding + %totalObjHeight + %objectSpanY;
         
         %srcMousePosX *= %widthRatio;
         %srcMousePosY *= %heightRatio;
         
         %srcMousePosX = trimAfter(%srcMousePosX, ".");
         %srcMousePosY = trimAfter(%srcMousePosY, ".");

         ImageEditorPreviewSrcPosition.setText("X =" SPC %srcMousePosX SPC "Y =" SPC %srcMousePosY);  
      }
   }
   
   if(ImageEditor.zoomToggled)
   {
      if(ImageEditor.zoomInSelection)
      {
         ImageEditor.hidePreview();
         
         if(!%obj.border && ImageEditor.showHighlight)
         {
            if(%obj != ImageEditor.previousHighlightedObj)
            {
               ImageEditor.updateHighlight(%obj.getPosition(), %obj.getSize());
               ImageEditor.previousHighlightedObj = %obj;
            }
         } else
         {
            ImageEditor.hideHighlight();           
         }
      } else if(ImageEditor.zoomIn)
      {   
         ImageEditor.updatePreview(%worldPos);
      } else
      {
         ImageEditor.hidePreview();
      }
   }
}

function ImageEditor::toggleForZoomSelection(%this)
{
   if(!%this.zoomInSelection)
   {
      // set zoomToggled and zooomInSelection to true, the rest to false
      %this.zoomToggled = true;
      %this.zoomedIn = false; 
      %this.zoomIn = false;  
      %this.zoomInSelection = true;
   } else if(%this.zoomInSelection)
   {
      // set all to false
      %this.zoomToggled = false;
      %this.zoomedIn = false; 
      %this.zoomIn = false;  
      %this.zoomInSelection = false;   
   }
}

function ImageEditor::toggleForZoom(%this)
{
   if(!%this.zoomIn)
   {
      // set zoomToggled and zoomIn to true, the rest false
      %this.zoomToggled = true;
      %this.zoomedIn = false; 
      %this.zoomIn = true;  
      %this.zoomInSelection = false;
   } else if(%this.zoomIn)
   {
      // set all to false
      %this.zoomToggled = false;
      %this.zoomedIn = false; 
      %this.zoomIn = false;  
      %this.zoomInSelection = false;         
   }
}

function ImageEditor::zoomIntoObject(%this, %obj)
{
   // hide the highlight and set it to not be shown
   %this.hideHighlight();
   %this.setHighlight(false);
   
   // set zoomedIn to true
   %this.zoomedIn = true;
   
   // get the objects position and size
   %pos = %obj.getPosition();
   %posX = getWord(%pos, 0);
   %posY = getWord(%pos, 1);
   
   %size = %obj.getSize();
   %sizeX = getWord(%size, 0);
   %sizeY = getWord(%size, 1);
   
   // set the camera's target position and size to that of the
   // object and start the move
   ImageBuilderImageSceneWindow.setTargetCameraPosition(%pos SPC %size);     
   ImageBuilderImageSceneWindow.startCameraMove(1.5);
   
   ImageEditorZoomInSelectionButton.setVisible(false);
   ImageEditorZoomInButton.setVisible(false);
   ImageEditorZoomOutButton.setVisible(true);
}

function ImageEditor::zoomIntoPoint(%this, %pos)
{   
   // get the zoom to dimensions
   %dimensions = %this.getZoomIntoDimensions(0.25, %pos);
   %width = getWord(%dimensions, 0);
   %height = getWord(%dimensions, 1);
   
   // set the target camera position and start the move
   ImageBuilderImageSceneWindow.setTargetCameraPosition(%pos SPC %width SPC %height);     
   ImageBuilderImageSceneWindow.startCameraMove(1);
   
   // set the selection button to false and make sure
   // the zoom in and out buttons are visible
   ImageEditorZoomInSelectionButton.setVisible(false);
   ImageEditorZoomInButton.setVisible(true);
   ImageEditorZoomOutButton.setVisible(true);
}

function ImageEditor::getZoomIntoDimensions(%this, %zoomDiv, %pos)
{
   // get the camera position and area
   %cameraPos = ImageBuilderImageSceneWindow.getCurrentCameraPosition();
   %cameraArea = ImageBuilderImageSceneWindow.getCurrentCameraArea();
   
   // calculate the camera width and height
   %width = mAbs(getWord(%cameraArea, 2) - getWord(%cameraArea, 0));
   %height = mAbs(getWord(%cameraArea, 3) - getWord(%cameraArea, 1));
   
   // change the width and height to the zoomDiv of what it was
   %width *= (1 - %zoomDiv);
   %height *= (1 - %zoomDiv);
   
   return %width SPC %height;   
}

function ImageEditor::zoomOut(%this)
{   
   // toggle the highlight and preview boxes to true and hide them
   %this.setHighlight(true);
   %this.setPreview(true);
   %this.hidePreview();
   %this.hideHighlight();
   ImageEditor.previousHighlightedObj = "";
   
   // set all of the zoom bools to false
   %this.zoomToggled = false;
   %this.zoomedIn = false;
   %this.zoomIn = false;
   %this.zoomInSelection = false;
   
   // set the target position and width to the default one and start the camera move
   ImageBuilderImageSceneWindow.setTargetCameraPosition(%this.baseX SPC %this.baseY SPC %this.maxWidth SPC %this.maxHeight);     
   ImageBuilderImageSceneWindow.startCameraMove(1.5);
   
   // set the zoom out button to false and the zoom in buttons to true
   ImageEditorZoomOutButton.setVisible(false);
   ImageEditorZoomInButton.setVisible(true);
   ImageEditorZoomInSelectionButton.setVisible(true);
}


// --------------------------------------------------------------------
// ImageEditor::setupPreviewWindow()
//
// This sets up the preview window
// --------------------------------------------------------------------
function ImageEditor::setupPreviewWindow(%this)
{  
   // store the background, border, and preview layers
   %this.backgroundLayer = 10;
   %this.borderLayer = 5;
   %this.previewLayer = 5;
   
   // set all of the background info GUIs to not be visible
   ImageBuilderBackgroundInfoWindow.setVisible(false);
   ImageBuilderBackgroundInfoControl.setVisible(false);
   ImageBuilderBackgroundColorPickerControl.setVisible(false);
   ImageBuilderObjectBorderColorPickerControl.setVisible(false);
   
   // set the more options text
   ImageBuilderColorPickerButton.setText("More Options");
   ImageBuilderObjectBorderColorPickerButton.setText("More Options");
   
   // set the extents of the background info
   ImageBuilderBackgroundInfoControl.setExtent(338, 151);
   ImageBuilderBackgroundInfoWindow.setExtent(347, 181);
    
    // get the extent of the preview window
   %extent = ImageBuilderImageSceneWindow.getExtent();
   
   // set the border padding (this will also effect the image
   // border line size
   %this.borderPadding = 3;
   
   // grab the width and height of the extent
   %this.maxWidth = getWord(%extent, 0);
   %this.maxHeight = getWord(%extent, 1);
  
   // calculate out the rowspace
   %this.rowSpace = %this.maxHeight * 0.015;
   %this.colSpace = %this.maxWidth * 0.015;
   
   // store the base X and Y positions
   %this.baseX = 0;
   %this.baseY = 0;
   
   // set the scenegraph and the camera position
   ImageBuilderImageSceneWindow.setSceneGraph( $ImageEditorScene );
   ImageBuilderImageSceneWindow.setCurrentCameraPosition(%this.baseX SPC %this.baseY SPC %this.maxWidth SPC %this.maxHeight);   
   
   // create and store the background sprite, this is for color manipulation
   %this.backgroundSprite = new t2dStaticSprite() { sceneGraph = $ImageEditorScene; };
   %this.backgroundSprite.setSize(%this.maxWidth, %this.maxHeight);
   %this.backgroundSprite.setPosition(%this.baseX, %this.baseY);
   %this.backgroundSprite.setLayer(%this.backgroundLayer);
   %this.backgroundSprite.setImageMap(ImageBuilderBackgroundImageMap);
   %this.backgroundSprite.border = true;
   %this.backgroundSprite.setBlendColor($pref::ImageBuilder::backgroundPreviewColor); 
   
   %this.previewWindowInit();
}

// --------------------------------------------------------------------
// ImageEditor::loadPreview()
//
// This basically does all of the preview loading funcitonality.  It
// checks which mode the image map is in and loads the preview images
// appropriately.
// --------------------------------------------------------------------
function ImageEditor::loadPreview(%this, %imageMap)
{  
   // do some sanity checks
   if(!isObject(%imageMap) || %imageMap.getDatablockClassName() !$= "t2dImageMapDatablock")
      return;
      
   if(!$ImageEditorLoaded)
      $ImageEditorLoaded = true;
      
   // we are now loading the preview (this is to prevent this
   // function from being called recursively from the autoApply)
   %this.loadingPreview = true;   

   // store the selected image
   %this.selectedImage = %imageMap;

   // grab the max width and height
   %maxWidth = %this.maxWidth;
   %maxHeight = %this.maxHeight;
   
   // grab the base x and y
   %baseX = %this.baseX;
   %baseY = %this.baseY;
   
   // grab the rowspace and colspace
   %rowSpace = %this.rowSpace;
   %colSpace = %this.colSpace;

   // get the image mode
   %imageMode = %imageMap.getImageMapMode();
   
   // default cleared to be false, this is an efficiency check
   // for reuse of static sprites
   %cleared = false;
   
   // first make sure that we have an object as our selected image
   if(isObject(%this.selectedImage))
   {
      // if our image mode has changed then just completely clear
      // the preview
      if((%imageMode !$= %this.imageMode) && (%imageMode $= "FULL" || %this.imageMode $= "FULL"))
      {
         %this.clearPreview();
         %cleared = true;
      } else if(%imageMode $= "CELL" || %imageMode $= "LINK" || %imageMode $= "KEY")
      {
         // if our image mode is the same and we're in cell mode
         // then check if our previous frame count is greater
         // than our current framecount, if so we can clear
         // those frames & borders that will be un-used
         if(%this.frameCount > %imageMap.getFrameCount())
         {
            %this.clearPreview(%imageMap.getFrameCount());
         }
      }
   } 
   
   // store this image mode for a comparisson next preview load
   %this.imageMode = %imageMode;
   
   // grab the source image size
   %srcSize = %imageMap.getSrcBitmapSize();
   %srcWidth = getWord(%srcSize, 0);
   %srcHeight = getWord(%srcSize, 1);
  
   if(%imageMode $= "FULL")
   {
      // calculate out the size of the full image to still be
      // in ratio to the source image's ratio
      if(%srcWidth > %srcHeight)
      {
         %ratio = %srcHeight / %srcWidth;
         %srcHeight = %maxHeight * %ratio;
         %srcWidth = %maxWidth; 
      } else if(%srcHeight > %srcWidth)
      {
         %ratio = %srcWidth / %srcHeight;
         %srcWidth = %maxWidth * %ratio;
         %srcHeight = %maxHeight; 
      } else
      {
         %srcWidth = %maxWidth; 
         %srcHeight = %maxHeight;
      } 

      // set the size text
      ImageEditorPreviewImageSize.setText(getWord(%srcSize, 0) SPC "x" SPC getWord(%srcSize, 1));
      
      if(%cleared || !isObject(%this.sprite))
      {
         %this.sprite = new t2dStaticSprite() { sceneGraph = $ImageEditorScene; imageMap = %imageMap;};
         %this.sprite.setPosition(%baseX SPC %baseY);
         %this.sprite.setSize(%srcWidth SPC %srcHeight);
         %this.sprite.setLayer(%this.previewLayer);
      
         %this.cleanUp.add(%this.sprite);
      }
   } else if(%imageMode $= "CELL" || %imageMode $= "LINK" || %imageMode $= "KEY")
   {
      // set the size text
      ImageEditorPreviewImageSize.setText(getWord(%srcSize, 0) SPC "x" SPC getWord(%srcSize, 1));
 
      %frameCount = %imageMap.getFrameCount();
      %this.frameCount = %frameCount;
         
      %sqrt = mSqrt(%frameCount);
      %div = mCeil(%sqrt);

      %rowSpace = (%maxWidth / %div) * 0.05;
      %colSpace = (%maxHeight / %div) * 0.05;
      
      %this.rowSpace = %rowSpace;
      %this.colSpace = %colSpace;

      if(%rowSpace < 1.5)
         %rowSpace = 1.5;
         
      if(%colSpace < 1.5)
         %colSpace = 1.5;

      %objWidth = (%maxWidth / %div) - (%rowSpace + %this.borderPadding);
      %objHeight = (%maxHeight / %div) - (%colSpace + %this.borderPadding);
         
      %baseX += %this.borderPadding;
      %baseY += %this.borderPadding;   
         
      %posX = %baseX - (%maxWidth/2) + (%objWidth/2);
      %posY = %baseY - (%maxHeight/2) + (%objHeight/2);
         
      %colCount = 0;
      %rowCount = 0;
         
      for(%i=0;%i<%frameCount;%i++)
      {
         if(%cleared || !isObject(%this.sprite[%i]))
         {
            %this.sprite[%i] = new t2dStaticSprite() { sceneGraph = $ImageEditorScene; };
            %this.border[%i] = %this.createImageBorder();
         } 
         
         %this.sprite[%i].setSize(%objWidth, %objHeight);
         %this.sprite[%i].setPosition(%posX, %posY);
         %this.sprite[%i].setLayer(%this.previewLayer);
         %this.sprite[%i].setImageMap(%imageMap, %i);
         %this.sprite[%i].row = %rowCount;
         %this.sprite[%i].col = %colCount;
         
         %this.resizeImageBorder(%this.border[%i], %this.sprite[%i].getPosition(), %this.sprite[%i].getSize(), %this.borderPadding);
            
         if(%colCount >= %div-1)
         {
            %rowCount++;
            %colCount = 0;
            %posX = %baseX - (%maxWidth/2) + (%objWidth/2);
            %posY = %baseY - (%maxHeight/2) + (%objHeight/2) + ((%objHeight + %rowSpace + %this.borderPadding) * %rowCount);            
         } else
         {
            %colCount++;
            %posX = %baseX - (%maxWidth/2) + (%objWidth/2) + ((%objWidth + %colSpace + %this.borderPadding) * %colCount);
         }
      }
   }
   
   loadImageMapSettings(%imageMap);
   
   ImageEditor.loadingPreview = false;
}

function ImageEditor::createImageBorder(%this)
{  
   %borderObj = new t2dSceneObject()
   {
      sceneGraph = $ImageEditorScene;
      border = true;
   };
   
   %borderObj.leftLine = %this.createBorderLine();
   %borderObj.rightLine = %this.createBorderLine();
   %borderObj.topLine = %this.createBorderLine();
   %borderObj.bottomLine = %this.createBorderLine();
   
   return %borderObj;
}

function ImageEditor::createBorderLine(%this)
{
   %line = new t2dStaticSprite()
   {
      sceneGraph = $ImageEditorScene;
      border = true;
   };
   
   %line.setLayer(%this.borderLayer);
   %line.setImageMap(ImageBuilderBackgroundImageMap);
   %line.setBlendColor($pref::ImageBuilder::borderPreviewColor);
   %line.setVisible(false);
   
   return %line;   
}

function ImageEditor::safeDeleteBorder(%this, %border)
{
   %border.leftLine.safeDelete();   
   %border.rightLine.safeDelete();
   %border.topLine.safeDelete();
   %border.bottomLine.safeDelete();
   %border.safeDelete();
}

function ImageEditor::resizeImageBorder(%this, %borderObj, %pos, %size, %borderPadding)
{
   %sizeX = getWord(%size, 0);   
   %sizeY = getWord(%size, 1);
   
   %borderSizeX = %sizeX + %borderPadding;
   %borderSizeY = %sizeY + %borderPadding;
   %borderSize = %borderSizeX SPC %borderSizeY;   
   
   %borderObj.setSize(%borderSize);
   //%borderObj.mount(%obj);

   %objPosX = getWord(%pos, 0);
   %objPosY = getWord(%pos, 1);
   
   %lineWidth = %borderPadding / 2;
   %lineHeight = %borderPadding / 2;
   
   %borderObj.leftLine.setSize(%lineWidth, %sizeY + (%lineHeight * 2));
   %borderObj.rightLine.setSize(%lineWidth, %sizeY + (%lineHeight * 2));
   %borderObj.topLine.setSize(%sizeX + (%lineWidth * 2), %lineHeight);
   %borderObj.bottomLine.setSize(%sizeX + (%lineWidth * 2), %lineHeight);
   
   %borderObj.leftLine.setPosition((%objPosX - (%lineWidth / 2) - (%sizeX / 2)), (%objPosY));
   %borderObj.rightLine.setPosition((%objPosX + (%sizeX / 2) + (%lineWidth / 2)),(%objPosY));
   %borderObj.topLine.setPosition((%objPosX),(%objPosY - (%lineHeight / 2) - (%sizeY / 2)));
   %borderObj.bottomLine.setPosition((%objPosX),(%objPosY + (%sizeY / 2) + (%lineHeight / 2)));
   
   %borderObj.leftLine.setVisible(true);
   %borderObj.rightLine.setVisible(true);
   %borderObj.topLine.setVisible(true);
   %borderObj.bottomLine.setVisible(true);
}

// --------------------------------------------------------------------
// ImageEditor::clearPreview()
//
// This will clear out the preview appropriately based on the image mode.
// --------------------------------------------------------------------
function ImageEditor::clearPreview(%this, %fromFrame)
{
   %imageMap = %this.selectedImage;
   %imageMode = %this.imageMode;
   %frameCount = %this.frameCount;
   
   if(%imageMode $= "FULL")
   {
      %this.sprite.safeDelete();
   
      ImageEditorPreviewImageSize.setText("");
   } else 
   {
      ImageEditorPreviewImageSize.setText("");
      
      if(%fromFrame $= "")
      {
         %start = 0;
      } else
      {
         %start = %fromFrame;
      }
      
      for(%i=%start;%i<%frameCount;%i++)
      {
         if(isObject(%this.sprite[%i]))
            %this.sprite[%i].safeDelete();  
            
         if(isObject(%this.border[%i]))   
            %this.safeDeleteBorder(%this.border[%i]);
      }
   
   }   
}

function ImageEditor::toggleBackgroundInfo(%this)
{
   if(ImageBuilderBackgroundInfoControl.isVisible())
   {
      %this.BackgroundInfoToggled = false;
      ImageBuilderBackgroundInfoControl.setVisible(false);  
      ImageBuilderBackgroundInfoWindow.setVisible(false);    
   } else
   {
      ImageBuilderBackgroundInfoControl.selectPage(0);
      %this.BackgroundInfoToggled = true;
      ImageBuilderBackgroundInfoControl.setVisible(true);
      ImageBuilderBackgroundInfoWindow.setVisible(true);
      ImageEditor.setupBackgroundBasicColors();
      ImageEditor.setupObjectBorderBasicColors();
      
      ImageBuilderBackgroundInfoControl.selectPage(0);
   }
}

function ImageEditor::setupBackgroundBasicColors(%this)
{
   %this.backgroundBasicColorWindow = ImageBuilderBackgroundBasicColorSceneWindow;
   
   %extent = %this.backgroundBasicColorWindow.getExtent();
   
   %this.basicColorsborderPadding = 3;
   
   %this.basicColorsMaxWidth = getWord(%extent, 0);
   %this.basicColorsMaxHeight = getWord(%extent, 1);
  
   %this.basicColorscolSpace = %this.basicColorsmaxWidth * 0.015;
   
   %this.basicColorsbaseX = 2000;
   %this.basicColorsbaseY = 2000;
   
   %this.backgroundBasicColorWindow.setSceneGraph( $ImageEditorScene );
   %this.backgroundBasicColorWindow.setCurrentCameraPosition(%this.basicColorsbaseX SPC %this.basicColorsbaseY SPC 
                                                         %this.basicColorsmaxWidth SPC %this.basicColorsmaxHeight);   
                                                         
   %colors = 6;
   %color[0] = "1 0 0";
   %color[1] = "0 1 0";
   %color[2] = "0 0 1";
   %color[3] = "0 0 0";
   %color[4] = "0.5 0.5 0.5";
   %color[5] = "1 1 1";
   
   %colSpace = (%this.basicColorsmaxWidth / %colors) * 0.05;

   if(%colSpace < 1.5)
      %colSpace = 1.5;

   %maxWidth = %this.basicColorsmaxWidth;
   %maxheight = %this.basicColorsmaxHeight;

   %objWidth = (%maxWidth / %colors) - (%colSpace + %this.basicColorsborderPadding);
   %objHeight = (%maxHeight) - (%this.basicColorsborderPadding);
   %objHeight = %objWidth;
   
   %baseX = %this.basicColorsbaseX;
   %baseY = %this.basicColorsbaseY;
         
   %baseX += %this.basicColorsborderPadding;
   %baseY += %this.basicColorsborderPadding;   
         
   %posY = %baseY - (%maxHeight/2) + (%objHeight/2);
   
   for(%i=0;%i<%colors;%i++)
   {
      %posX = %baseX - (%maxWidth/2) + (%objWidth/2) + ((%objWidth + %colSpace + %this.basicColorsborderPadding) * %i);
      
      %colorBox = new t2dStaticSprite()
      {
         sceneGraph = $ImageEditorScene;
      };
      
      %colorBox.setSize(%objWidth, %objHeight);
      %colorBox.setPosition(%posX, %posY);
      %colorBox.setImageMap(ImageBuilderBackgroundImageMap);
      %colorBox.setBlendColor(%color[%i]);
   }
}

function ImageEditor::setupObjectBorderBasicColors(%this)
{
   %this.objectBorderBasicColorWindow = ImageBuilderObjectBorderBasicColorSceneWindow;
   
   %extent = %this.objectBorderBasicColorWindow.getExtent();
   
   %this.objectBorderbasicColorsborderPadding = 3;
   
   %this.objectBorderbasicColorsMaxWidth = getWord(%extent, 0);
   %this.objectBorderbasicColorsMaxHeight = getWord(%extent, 1);
  
   %this.objectBorderbasicColorscolSpace = %this.objectBorderbasicColorsmaxWidth * 0.015;
   
   %this.objectBorderbasicColorsbaseX = 3000;
   %this.objectBorderbasicColorsbaseY = 3000;
   
   %this.objectBorderBasicColorWindow.setSceneGraph( $ImageEditorScene );
   %this.objectBorderBasicColorWindow.setCurrentCameraPosition(%this.objectBorderbasicColorsbaseX SPC %this.objectBorderbasicColorsbaseY SPC 
                                                         %this.objectBorderbasicColorsmaxWidth SPC %this.objectBorderbasicColorsmaxHeight);   
                                                         
   %colors = 6;
   %color[0] = "1 0 0";
   %color[1] = "0 1 0";
   %color[2] = "0 0 1";
   %color[3] = "0 0 0";
   %color[4] = "0.5 0.5 0.5";
   %color[5] = "1 1 1";
   
   %colSpace = (%this.objectBorderbasicColorsmaxWidth / %colors) * 0.05;

   if(%colSpace < 1.5)
      %colSpace = 1.5;

   %maxWidth = %this.objectBorderbasicColorsmaxWidth;
   %maxheight = %this.objectBorderbasicColorsmaxHeight;

   %objWidth = (%maxWidth / %colors) - (%colSpace + %this.objectBorderbasicColorsborderPadding);
   %objHeight = (%maxHeight) - (%this.objectBorderbasicColorsborderPadding);
   %objHeight = %objWidth;
   
   %baseX = %this.objectBorderbasicColorsbaseX;
   %baseY = %this.objectBorderbasicColorsbaseY;
         
   %baseX += %this.objectBorderbasicColorsborderPadding;
   %baseY += %this.objectBorderbasicColorsborderPadding;   
         
   %posY = %baseY - (%maxHeight/2) + (%objHeight/2);
   
   for(%i=0;%i<%colors;%i++)
   {
      %posX = %baseX - (%maxWidth/2) + (%objWidth/2) + ((%objWidth + %colSpace + %this.objectBorderbasicColorsborderPadding) * %i);
      
      %colorBox = new t2dStaticSprite()
      {
         sceneGraph = $ImageEditorScene;
      };
      
      %colorBox.setSize(%objWidth, %objHeight);
      %colorBox.setPosition(%posX, %posY);
      %colorBox.setImageMap(ImageBuilderBackgroundImageMap);
      %colorBox.setBlendColor(%color[%i]);
   }
}

function ImageBuilderBackgroundInfoControl::onTabSelected(%this, %text)
{
   if(%text $= "Background Color")
   {
      ImageEditor.toggleBackgroundTab();
   } else
   {
      ImageEditor.toggleObjectBorderTab();
   }
}


function ImageEditor::toggleBackgroundTab(%this)
{
   if(!ImageBuilderGui.isAwake())
      return;
   
   if(%this.backgroundColorPickerToggled)
   {
      %this.unHideBackgroundColorPicker();            
   } else
   {
      %this.hideBackgroundColorPicker();      
   }
}

function ImageEditor::toggleObjectBorderTab(%this)
{
   if(!ImageBuilderGui.isAwake())
      return;
   
   if(%this.ObjectBorderColorPickerToggled)
   {
      %this.unHideObjectBorderColorPicker();            
   } else
   {
      %this.hideObjectBorderColorPicker();      
   }
}

function ImageEditor::hideBackgroundColorPicker(%this)
{
   ImageBuilderBackgroundColorPickerControl.setVisible(false);
      
   ImageBuilderBackgroundInfoControl.setExtent(338, 151);
   ImageBuilderBackgroundInfoWindow.setExtent(347, 181);
   ImageBuilderBackgroundTabPage.setExtent(331, 127);
      
   ImageBuilderColorPickerButton.setText("More Options");
      
   %this.backgroundColorPickerToggled = false;   
}

function ImageEditor::unHideBackgroundColorPicker(%this)
{
   ImageBuilderBackgroundColorPickerControl.setVisible(true);
      
   ImageBuilderBackgroundInfoControl.setExtent(338, 314);
   ImageBuilderBackgroundInfoWindow.setExtent(347, 348);   
    
   ImageBuilderColorPickerButton.setText("Less Options");
   %this.backgroundColorPickerToggled = true;   
}

function ImageEditor::toggleBackgroundColorPicker(%this)
{
   if(ImageBuilderBackgroundColorPickerControl.isVisible())
   {
      %this.hideBackgroundColorPicker();
   } else
   {
      %this.unHideBackgroundColorPicker();
   }
}

function ImageEditor::hideObjectBorderColorPicker(%this)
{
   ImageBuilderObjectBorderColorPickerControl.setVisible(false);   
      
   ImageBuilderBackgroundInfoControl.setExtent(338, 151);
   ImageBuilderBackgroundInfoWindow.setExtent(347, 181);
   ImageBuilderObjectBorderTabPage.setExtent(331, 127);
      
   ImageBuilderObjectBorderColorPickerButton.setText("More Options");
      
   %this.objectBorderColorPickerToggled = false;    
}

function ImageEditor::unHideObjectBorderColorPicker(%this)
{
   ImageBuilderObjectBorderColorPickerControl.setVisible(true);
      
   ImageBuilderBackgroundInfoControl.setExtent(338, 314);
   ImageBuilderBackgroundInfoWindow.setExtent(347, 348); 
      
   ImageBuilderObjectBorderColorPickerButton.setText("Less Options");
      
   %this.objectBorderColorPickerToggled = true;  
}

function ImageEditor::toggleObjectBorderColorPicker(%this)
{
   if(ImageBuilderObjectBorderColorPickerControl.isVisible())
   {
      %this.hideObjectBorderColorPicker();
   } else
   {
      %this.unHideObjectBorderColorPicker();
   }
}

function ImageEditor::selectBasicColor(%this, %color)
{ 
   $pref::ImageBuilder::backgroundPreviewColor = %color;
   %this.backgroundSprite.fadeToColor(5, %color, 20);   
}

function ImageEditor::selectBasicColorObjectBorder(%this, %color)
{
   %this.setAllBorderColorFade(5, %color, 20);   
}

function ImageEditor::setAllBorderBasicColor(%this, %color)
{
   $pref::ImageBuilder::borderPreviewColor = %color;
   
   %frameCount = %this.selectedImage.getFrameCount();

   for(%i=0;%i<%frameCount;%i++)
   {
      %this.setBorderBasicColor(%this.border[%i], %color);      
   }
}

function ImageEditor::setBorderBasicColor(%this, %border, %color)
{
   if(!isObject(%border))
      return;
 
   $pref::ImageBuilder::borderPreviewColor = %color;
   
   %border.leftLine.setBlendColor(%color);      
   %border.rightLine.setBlendColor(%color);
   %border.topLine.setBlendColor(%color);
   %border.bottomLine.setBlendColor(%color);
}

function ImageEditor::setAllBorderColorFade(%this, %time, %color, %inc)
{
   $pref::ImageBuilder::borderPreviewColor = %color;
   
   %frameCount = %this.selectedImage.getFrameCount();
   
   for(%i=0;%i<%frameCount;%i++)
   {
      %this.setBorderColorFade(%this.border[%i], %time, %color, %inc);      
   }
}

function ImageEditor::setBorderColorFade(%this, %border, %time, %color, %inc)
{
   if(!isObject(%border.leftLine) && !isObject(%border.rightLine) && !isObject(%border.topLine) && !isObject(%border.bottomLine))
      return;
   
   %border.leftLine.fadeToColor(%time, %color, %inc);      
   %border.rightLine.fadeToColor(%time, %color, %inc);
   %border.topLine.fadeToColor(%time, %color, %inc);
   %border.bottomLine.fadeToColor(%time, %color, %inc);
}

function ImageBuilderBackgroundBasicColorSceneWindow::onMouseUp( %this, %mod, %worldPos, %mouseClicks )
{
   if(ImageEditor.BackgroundInfoToggled)
   {
      %objList = $ImageEditorScene.pickPoint(%worldPos);
      %objCount = getWordCount(%objList);
      
      for(%i=0;%i<%objCount;%i++)
      {
         if(!%obj.border)       
         {
            %obj = getWord(%objList, %i);
            break;            
         }
      }
      
      if(%obj !$= "")
      {
         ImageEditor.selectBasicColor(%obj.getBlendColor());
      }
   }
}

function ImageBuilderObjectBorderBasicColorSceneWindow::onMouseUp( %this, %mod, %worldPos, %mouseClicks )
{
   if(ImageEditor.BackgroundInfoToggled)
   {
      %objList = $ImageEditorScene.pickPoint(%worldPos);
      %objCount = getWordCount(%objList);
      
      for(%i=0;%i<%objCount;%i++)
      {
         if(!%obj.border)       
         {
            %obj = getWord(%objList, %i);
            break;            
         }
      }
      
      if(%obj !$= "")
      {
         ImageEditor.selectBasicColorObjectBorder(%obj.getBlendColor());
      }
   }
}

function ImageEditor::onColorPicked(%this, %val)
{
   if(!%val)
   {
      %color = ImageBuilderBackgroundColorPicker.pickColor;
   
      $pref::ImageBuilder::backgroundPreviewColor = %color;
      %this.backgroundSprite.setBlendColor(%color);   
   } else
   {
      %color = ImageBuilderObjectBorderColorPicker.pickColor; 
      
      %this.setAllBorderBasicColor(%color);
   }
}

function t2dSceneObject::fadeToColor(%this, %time, %red, %green, %blue, %inc)
{
   // store the starting color
   %this.startColorBeforeFade = %this.getBlendColor();
   
   // grab the starting colors
   %startRed = getWord(%this.startColorBeforeFade, 0);      
   %startGreen = getWord(%this.startColorBeforeFade, 1);
   %startBlue = getWord(%this.startColorBeforeFade, 2);
   
   // this will allow you to pass in a target color as "0.5 0.5 0.5" as well as "0.5, 0.5, 0.5"
   if(getWord(%red, 2) !$= "")
   {
      %inc = %green;
      %green = getWord(%red, 1);
      %blue = getWord(%red, 2);      
      %red = getWord(%red, 0);
   }
 
   // if our target colors and  our present colors are the same then we need to do nothing
   if((%startRed == %red) && (%startGreen == %green) && (%startBlue == %blue))
      return;
 
   // if we are already doing a color change then cancel it out
   if(isEventPending(%this.colorFadeSchedule))
      cancel(%this.colorFadeSchedule);
 
   
   // how many time incriments do we want
   if(%inc $= "" || %inc < 1 || %inc > 100)
      %inc = 10;
   
   // divide out what each time inc will be
   %timeInc = (%time * 100) / %inc;
   
   // get the different between starting and ending colors
   %redDiff = %red - %startRed;
   %greenDiff = %green - %startGreen;
   %blueDiff = %blue - %startBlue;
   
   // get the ammount we must inc each color each scheduled change
   %redInc = %redDiff / %inc;
   %greenInc = %greenDiff / %inc;
   %blueInc = %blueDiff / %inc;
   
   // call the color change
   %this.fadingColor(%inc, %timeInc, %redInc, %greenInc, %blueInc);
}

function t2dSceneObject::fadingColor(%this, %inc, %timeInc, %redInc, %greenInc, %blueInc, %count)
{
   // init the count if not specified
   if(%count $= "")
      %count = 0;
   
   // grab the current color
   %color = %this.getBlendColor();
   
   // divide up the colors and inc them
   %red = getWord(%color, 0) + %redInc;      
   %green = getWord(%color, 1) + %greenInc;
   %blue = getWord(%color, 2) + %blueInc;
   
   // set the new colors
   %this.setBlendColor(%red, %green, %blue);
   
   // inc the count
   %count++;
   
   // if the count is less than the planned incs then schedule this to be called again
   if(%count < %inc)
      %this.colorFadeSchedule = %this.schedule(%timeInc, "fadingColor", %inc, %timeInc, %redInc, %greenInc, %blueInc, %count);
}

function t2dSceneObject::fadeToAlpha(%this, %time, %alpha, %inc, %callback)
{
   // store the starting color
   %this.startAlphaBeforeFade = %this.getBlendAlpha();
   
   // grab the starting colors
   %startAlpha = %this.startAlphaBeforeFade;    

   // if our target alpha and our present alpha is the same then we need to do nothing
   if(%startAlpha == %alpha)
      return;
 
   // if we are already doing a color change then cancel it out
   if(isEventPending(%this.alphaFadeSchedule))
      cancel(%this.alphaFadeSchedule);
   
   // how many time incriments do we want
   if(%inc $= "" || %inc < 1 || %inc > 100)
      %inc = 10;
   
   // divide out what each time inc will be
   %timeInc = (%time * 100) / %inc;
   
   // get the different between starting and ending colors
   %alphaDiff = %alpha - %startAlpha;
   
   // get the ammount we must inc each color each scheduled change
   %alphaInc = %alphaDiff / %inc;
   
   // call the color change
   %this.fadingAlpha(%inc, %timeInc, %alphaInc, "", %callback);
}

function t2dSceneObject::fadingAlpha(%this, %inc, %timeInc, %alphaInc, %count, %callback)
{
   // init the count if not specified
   if(%count $= "")
      %count = 0;
   
   // grab the current color
   %alpha = %this.getBlendAlpha();
   
   // divide up the colors and inc them
   %alpha = %alpha + %alphaInc;      
   
   // set the new colors
   %this.setBlendAlpha(%alpha);
   
   // inc the count
   %count++;
   
   // if the count is less than the planned incs then schedule this to be called again
   if(%count < %inc)
   {
      %this.alphaFadeSchedule = %this.schedule(%timeInc, "fadingAlpha", %inc, %timeInc, %alphaInc, %count, %callback);
   } else
   {   
      schedule(0, %this, "eval", %callback);
   }
}

function trimAfter(%string, %char)
{
   %strCount = strLen(%string);

   for(%i=0;%i<%strCount;%i++)
	  {
      %charToCheck = getSubStr(%string, %i, 1);

      if(%charToCheck $= %char)
      {
         break;
      } else
      {
         %stringToReturn = %stringToReturn @ %charToCheck;   
      }
   }	

   return %stringToReturn;
}