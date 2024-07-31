// Create the editor object for namespace usage
new ScriptObject(ImageEditor);

// --------------------------------------------------------------------
// setupImageMapEditor()
//
// This will initiate the image map editor base settings, such as 
// populating menu options.
// --------------------------------------------------------------------
function setupImageMapEditor(%link)
{
   if(%link $= "")
      %link = false;
   
   // Hide the Cell and Linked ImageMap options
   ImageEditorCellOptionsPanel.setVisible(false);
   ImageEditorLinkOptionsPanel.setVisible(false);
   
   ImageEditorComFilterMode.clear();
   
   // Add the Filter Modes
   ImageEditorComFilterMode.add("SMOOTH", 0); 
   ImageEditorComFilterMode.add("NONE", 1); 
   
   ImageEditorComImageMode.clear();
   
   // Add the Image Modes
   // If we are editing an already LINK image map
   // then we don't want to load the FULL and CELL
   if(!%link)
   {
      ImageEditorComImageMode.add("FULL", 0);
      ImageEditorComImageMode.add("CELL", 1);
      //ImageEditorComImageMode.add("KEY", 3);
   } else
   {
      ImageEditorComImageMode.add("LINK", 2);
   }
   
   $ImageEditorScene = new t2dSceneGraph(ImageEditorScene);
}

// --------------------------------------------------------------------
// ImageEditor::reCreateImage()
//
// re-creates the image for the image, this does a majority of the work
// it will loop through and set each imagemap setting appropriately
// based on image mode.  It will also set some defaults and some fail 
// safes to make sure people cannot set invalid values.
// --------------------------------------------------------------------
function ImageEditor::reCreateImage(%this)
{
   %imageMap = %this.selectedImage;

   if(!isObject(%imageMap))
      return;
   
   %image = %imageMap.getSrcBitmapName();
   
   %imageName = prevT2DImageMap;
   %this.imageName = ImageEditorTxtImageName.getValue();
   
   %this.imageName = validateDatablockName( %this.imageName );
   
   if(isObject(%this.sourceDB))
   {
      %sourceName = %this.sourceDB.getName();
   } else
   {
      %sourceName = %this.imageName;
   }
   
   // Check to make sure we aren't conflicting with another object's name
   if((ImageEditor.prevName !$= %this.imageName && isObject(%this.imageName)) && %this.imageName !$= %sourceName)
   {
      %newName = %sourceName;
      ImageBuilderNameWarning.setVisible(true);            
      ImageEditorTxtImageName.setText(%newName);
      ImageBuilderNameWarning.schedule(2000, "setVisible", false);
      %this.imageName = %newName;
   }

   if(%imageName $= "")
      %imageName = "image" @ $imageCount;
      $imageCount++;
   
   %imageFilterMode = ImageEditorComFilterMode.getValue();
   %imageFilterPad = ImageEditorCheckBoxFilterPad.getValue();
   %imagePreferPerf = ImageEditorCheckBoxPreferPerf.getValue();
   %imagePreload = ImageEditorCheckBoxPreload.getValue();
   %imageAllowUnload = ImageEditorCheckBoxAllowUnload.getValue();
   %imageForce16Bit = ImageEditorCheckBoxForce16Bit.getValue();
   %imageMode = ImageEditorComImageMode.getValue();
   
   switch$ (%imageMode)
   {
      case "FULL":
         
         %imageMap.setName(%imageName);
         %imageMap.imageName = %image;
         %imageMap.filterMode = %imageFilterMode;
         %imageMap.filterPad = %imageFilterPad;
         %imageMap.preferPerf = %imagePreferPerf;
         %imageMap.preload = %imagePreload;
         %imageMap.allowUnload = %imageAllowUnload;
         %imageMap.force16Bit = %imageForce16Bit;
         %imageMap.imageMode = %imageMode;
         
      case "KEY":
         
         %imageMap.setName(%imageName);
         %imageMap.imageName = %image;
         %imageMap.filterMode = %imageFilterMode;
         %imageMap.filterPad = %imageFilterPad;
         %imageMap.preferPerf = %imagePreferPerf;
         %imageMap.preload = %imagePreload;
         %imageMap.allowUnload = %imageAllowUnload;
         %imageMap.force16Bit = %imageForce16Bit;         
         %imageMap.imageMode = %imageMode;
      
      case "CELL":
      
         %cellCountX = ImageEditorCellCountX.getValue();
         %cellCountY = ImageEditorCellCountY.getValue();
         %cellHeight = ImageEditorCellHeight.getValue();
         %cellWidth = ImageEditorCellWidth.getValue();
         %cellOffsetX = ImageEditorCellOffsetX.getValue();
         %cellOffsetY = ImageEditorCellOffsetY.getValue();
         %cellStrideX = ImageEditorCellStrideX.getValue();
         %cellStrideY = ImageEditorCellStrideY.getValue();
         %cellRowOrder = ImageEditorCheckboxCellRowOrder.getValue();
         
         %datablock = "datablock t2dImageMapDatablock(sizeImage)\n";
         %datablock = %datablock SPC "{\n";
         %datablock = %datablock SPC "imageName = " @ "\"" @ %image @ "\"" @ ";\n";
         %datablock = %datablock SPC "imageMode = FULL;\n";
         %datablock = %datablock SPC "};";
         
         eval(%datablock);
         
         %srcSize = sizeImage.getSrcBitmapSize();
         
         sizeImage.delete();
         
         %sizeX = getWord(%srcSize, 0);
         %sizeY = getWord(%srcSize, 1);
         
         %xCheck = %sizeX / 16;
         %yCheck = %sizeY / 16;
         
         // first we check the cell width and height for
         // reasonable values
         if(%cellWidth == 0)
         {
           %cellWidth = %sizeX / 2;  
         } else if(%cellWidth < %xCheck)
         {
           %cellWidth = %xCheck;
         }
         
         if(%cellHeight == 0)
         {  
            %cellHeight = %sizeY / 2;  
         }else if(%cellHeight < %yCheck)
         {
           %cellHeight = %yCheck;
         }
         
         // then we check the stride X and Y
         if(mAbs(%cellStrideX) < %xCheck && %cellStrideX != 0)
         {
           %cellStrideX = %xCheck;
         }
         
         if(mAbs(%cellStrideY) < %yCheck && %cellStrideY != 0)
         {
           %cellStrideY = %yCheck;
         }
         
         if(%cellCountX == 0)
         {
            %cellCountX = -1;
         }
         
         if(%cellCountY == 0)
         {
            %cellCountY = -1;
         }
         
         if(%cellCountX != -1)
         {
            %div = %sizeX / %cellWidth;
            if( ImageEditor.CountExtentOverride $= "Extent" )
               %cellCountX = %div;
            else
            {
               %cellWidth = %sizeX / %cellCountX;
               if( %cellWidth >= 2048 )
                  %cellWidth = %sizeX;
               else if( %cellWidth <= 0 )
                  %cellWidth = 16;
            }
         }
         
         if(%cellCountY != -1)
         {
            %div = %sizeY / %cellHeight;
            if( ImageEditor.CountExtentOverride $= "Extent" )
               %cellCountY = %div;
            else
            {
               %cellHeight = %sizeY / %cellCountY;
               if( %cellHeight >= 2048 )
                  %cellHeight = %sizeY;
               else if( %cellHeight <= 0 )
                  %cellHeight = 16;
            }
         }
         
         %imageMap.setName(%imageName);
         %imageMap.imageName = %image;
         %imageMap.filterMode = %imageFilterMode;
         %imageMap.filterPad = %imageFilterPad;
         %imageMap.preferPerf = %imagePreferPerf;
         %imageMap.preload = %imagePreload;
         %imageMap.allowUnload = %imageAllowUnload;
         %imageMap.force16Bit = %imageForce16Bit;         
         %imageMap.imageMode = %imageMode;

         %imageMap.cellCountX = %cellCountX;
         %imageMap.cellCountY = %cellCountY;
         %imageMap.cellHeight = %cellHeight;
         %imageMap.cellWidth = %cellWidth;
         %imageMap.cellOffsetX = %cellOffsetX;
         %imageMap.cellOffsetY = %cellOffsetY;
         %imageMap.cellStrideX = %cellStrideX;
         %imageMap.cellStrideY = %cellStrideY;
         %imageMap.cellRowOrder = %cellRowOrder;
      
      case "LINK":

         %linkCount = ImageEditorListLinkedImageMaps.getItemCount();
   
         for(%i=0;%i<%linkCount;%i++)
         {
            %link = ImageEditorListLinkedImageMaps.getItemText(%i);   
               
            if(%linkImageMaps $= "")
            {
               %linkImageMaps = %link;
            } else
            {
               %linkImageMaps = %linkImageMaps SPC %link;   
            }
         }
         
         %imageMap.setName(%imageName);
         %imageMap.filterMode = %imageFilterMode;
         %imageMap.filterPad = %imageFilterPad;
         %imageMap.preferPerf = %imagePreferPerf;
         %imageMap.preload = %imagePreload;
         %imageMap.allowUnload = %imageAllowUnload;
         %imageMap.force16Bit = %imageForce16Bit;         
         %imageMap.imageMode = %imageMode;
         
         %imageMap.linkImageMaps = %linkImageMaps;   
   }
   
   ImageEditor.prevName = %this.imageName;
   ImageEditor.selectedImage = %imageName;
   
   %imageName.compile();   
}

// --------------------------------------------------------------------
// loadImageMapSettings()
//
// This is the first function that will load all of the base image map 
// settings, it will then check which image mode it is and call an
// image mode specific function to load the mode type settings, if
// the image is in full mode then it doesn't need to call anything else.
// --------------------------------------------------------------------
function loadImageMapSettings(%imageMap)
{  
   ImageEditor.loadingSettings = true;
   
   $ImageEditorSelectedImage = %imageMap;
   
   %imageMapName = ImageEditor.imageName;
   
   %filterMode = %imageMap.getFilterMode();
   
   if(%filterMode $= "SMOOTH")
   {
      %filterMode = 0;
   } else
   {
      %filterMode = 1;
   }
   
   %imageMode = %imageMap.getImageMapMode();
   
   if(%imageMode $= "FULL")
   {
      %imageMode = 0;
   } else if(%imageMode $= "CELL")
   {
      %imageMode = 1;
   } else if(%imageMode $= "KEY")
   {
      %imageMode = 3;
   } else
   {
      %imageMode = 2;
   }
   
   %filterMode = %imageMap.getFilterMode();
   
   %filterPad = %imageMap.filterPad;
   %preferPerf = %imageMap.preferPerf;
   %preload = %imageMap.preload;
   %allowUnload = %imageMap.allowUnload;
   %force16Bit = %imageMap.getForce16Bit();
   
   ImageEditorTxtImageName.setText(%imageMapName);
   ImageEditorComFilterMode.setSelected(%filterMode);
   ImageEditorComImageMode.setSelected(%imageMode);
   ImageEditorCheckBoxFilterPad.setValue(%filterPad);
   ImageEditorCheckBoxPreferPerf.setvalue(%preferPerf);
   ImageEditorCheckBoxPreload.setValue(%preload);
   ImageEditorCheckBoxAllowUnload.setValue(%allowUnload);
   ImageEditorCheckBoxForce16Bit.setValue(%force16Bit);
   
   if(%imageMode == 1)
   {
      loadImageMapCellSettings(%imageMap);      
   } else if(%imageMode == 2)
   {
      loadImageMapLinkSettings(%imageMap);      
   }

   ImageEditor.loadingSettings = false;
}

// --------------------------------------------------------------------
// ImageEditorComImageMode::onSelect()
//
// The image mode on select callback, it checks which mode was selected
// and calls the appropriate load function as well as auto apply.
// --------------------------------------------------------------------
function ImageEditorComImageMode::onSelect(%this, %id, %text)
{   
   switch$ (%text)
   {
      case "FULL":
         ImageEditorCellOptionsPanel.setVisible(false);
         ImageEditorLinkOptionsPanel.setVisible(false);
         
      case "KEY":
         ImageEditorCellOptionsPanel.setVisible(false);
         ImageEditorLinkOptionsPanel.setVisible(false);
         
      case "CELL":
         loadImageMapCellSettings(ImageEditor.selectedImage);
         
      case "LINK":
         loadImageMapLinkSettings(ImageEditor.selectedImage);
      
   }
   
   ImageEditorAutoApply();
}

// --------------------------------------------------------------------
// loadImageMapCellSettings()
//
// The will load the cell specific settings from the image map selected.
// --------------------------------------------------------------------
function loadImageMapCellSettings(%imageMap)
{
   ImageEditorCellOptionsPanel.setVisible(true);
   ImageEditorLinkOptionsPanel.setVisible(false);  
   
   %cellCountX = %imageMap.cellCountX;
   %cellCountY = %imageMap.cellCountY;
   %cellHeight = %imageMap.cellHeight;
   %cellWidth = %imageMap.cellWidth;
   %cellOffsetX = %imageMap.cellOffsetX;
   %cellOffsetY = %imageMap.cellOffsetY;
   %cellStrideX = %imageMap.cellStrideX;
   %cellStrideY = %imageMap.cellStrideY;
   %cellRowOrder = %imageMap.cellRowOrder;
   
   ImageEditorCellCountX.setText(%cellCountX);
   ImageEditorCellCountY.setText(%cellCountY);
   ImageEditorCellHeight.setText(%cellHeight);
   ImageEditorCellWidth.setText(%cellWidth);
   ImageEditorCellOffsetX.setText(%cellOffsetX);
   ImageEditorCellOffsetY.setText(%cellOffsetY);
   ImageEditorCellStrideX.setText(%cellStrideX);
   ImageEditorCellStrideY.setText(%cellStrideY);
   ImageEditorCheckboxCellRowOrder.setValue(%cellRowOrder); 
}

// --------------------------------------------------------------------
// loadimageMapLinkSettings()
//
// The will load the link specific settings from the image map selected.
// --------------------------------------------------------------------
function loadimageMapLinkSettings(%imageMap)
{
   ImageEditorLinkOptionsPanel.setVisible(true);
   ImageEditorCellOptionsPanel.setVisible(false);
   
   ImageEditorListLinkedImageMaps.clearItems();
   ImageEditorComImageMapList.clear();
   
   %linkList = %imageMap.linkImageMaps;
   
   %linkCount = getWordCount(%linkList);
   
   for(%i=0;%i<%linkCount;%i++)
   {
      %link = getWord(%linkList, %i);
      
      ImageEditorListLinkedImageMaps.addItem(%link);      
   }
   
   %datablockSet = getT2DDatablockSet();
   %datablockCount = %datablockSet.getCount();
   
   %sourceDBName = "";
   if (isObject(ImageEditor.sourceDB))
      %sourceDBName = ImageEditor.sourceDB.getName();
   
   for(%i=0;%i<%datablockCount;%i++)
   {
      %db = %datablockSet.getObject(%i);
      
      // dont include ignored datablocks or non image maps
      if(!$ignoredDatablockSet.isMember(%db) && %db.getClassName() $= "t2dImageMapDatablock")
      {
         // rdbhack: also don't allow any datablocks named prevT2DImageMap or
         //  any datablocks with the same name as the sourcedb
         %dbName = %db.getName();
         
         if (%dbName !$= "prevT2DImageMap" && %dbName !$= %sourceDBName)
         {
            if( %db.preload )
               ImageEditorComImageMapList.add(%db.getName(), %i);
         }
      }
   }
}

// --------------------------------------------------------------------
// imageEditorRemoveSelected()
//
// The will remove the selected images from the link list.
// --------------------------------------------------------------------
function imageEditorRemoveSelected() 
{
   %objList = ImageEditorListLinkedImageMaps.getSelectedItems();
   %objCount = getWordCount(%objList);
   
   for(%i=%objCount-1;%i>=0;%i--)
   {
      if(ImageEditorListLinkedImageMaps.getItemCount() <= 2)
      {
         ImageBuilderLinkWarning.setVisible(true);            
         ImageBuilderLinkWarning.schedule(2000, "setVisible", false);
         break;
      }
      %obj = getWord(%objList, %i);
      ImageEditorListLinkedImageMaps.deleteItem(%obj);
   }
   
   ImageEditorAutoApply(); 
}

// --------------------------------------------------------------------
// ImageEditorComImageMapList::onSelect()
//
// This is the image map pop up select callback, it then passes it to
// the add to link list function.
// --------------------------------------------------------------------
function ImageEditorComImageMapList::onSelect(%this, %id, %text)
{
   imageEditorAddImageMapToLink(%text);     
   ImageEditorAutoApply();   
}

// --------------------------------------------------------------------
// imageEditorAddImageMapToLink()
//
// This will add the image map to the linked list.
// --------------------------------------------------------------------
function imageEditorAddImageMapToLink(%imageMap)
{
   if(%imageMap !$= ImageEditor.selectedImage)
   {
      // don't add the image if its already in the list
      %foundValue = ImageEditorListLinkedImageMaps.findItemText(%imageMap);
      if (%foundValue == -1)
         ImageEditorListLinkedImageMaps.addItem(%imageMap);
   }
}

// --------------------------------------------------------------------
// ImageEditorAutoApply()
//
// This is the auto apply funcion called by almost every editable control
// in the Image Builder, it makes sure the image editor is loaded
// and that we aren't currently loading a preview (otherwise it re-loads
// everything a number of extra times bogging the builder down).
// --------------------------------------------------------------------
function ImageEditorAutoApply()
{   
   if(!ImageEditor.loadingPreview && $ImageEditorLoaded)
   {
      ImageEditor.reCreateImage();
      ImageEditor.loadPreview(ImageEditor.selectedImage);   
   }
}

// --------------------------------------------------------------------
// Image Editor Settings Auto Apply Commands
//
// These all get called when you edit any base setting Image Builder 
// field.  Most do nothing more than call the auto apply, though a 
// few will check the values and/or store them for builder usage.
// --------------------------------------------------------------------
function ImageEditorImageName()
{
   %name = ImageEditorTxtImageName.getValue();
   
   if(%name $= "")
      return;
      
   %name = validateDatablockName( %name );
   
   ImageEditorAutoApply();
}

function ImageEditorFilterMode()
{
   ImageEditorAutoApply();
}

function ImageEditorFilterPad()
{
   %value = ImageEditorCheckBoxFilterPad.getValue();
   
   if($lastFilterPadValue $= "" || %value != $lastFilterPadvalue)
   {
      $lastFilterPadValue = %value;
      ImageEditorAutoApply();
   }
}

function ImageEditorPreferPerf()
{   
   %value = ImageEditorCheckBoxPreferPerf.getValue();
   
   if($lastPreferPerfValue $= "" || %value != $lastPreferPerfValue)
   {
      $lastPreferPerfValue = %value;
      ImageEditorAutoApply();
   }
}

function ImageEditorAllowUnload()
{
   %value = ImageEditorCheckBoxAllowUnload.getValue();
   
   if($lastAllowUnloadValue $= "" || %value != $lastAllowUnloadValue)
   {
      $lastAllowUnloadValue = %value;
      ImageEditorAutoApply();
   }
}

function ImageEditorForce16Bit()
{
   %value = ImageEditorCheckBoxForce16Bit.getValue();
   
   if($lastForce16BitValue $= "" || %value != $lastForce16BitValue)
   {
      $lastForce16BitValue = %value;
      ImageEditorAutoApply();
   }
}

function ImageEditorPreload()
{
   %value = ImageEditorCheckBoxPreload.getValue();
   
   if($lastPreloadValue $= "" || %value != $lastPreloadValue)
   {
      $lastPreloadValue = %value;
      ImageEditorAutoApply();
   }
}

function ImageEditorImageMode()
{
   %imageMode = ImageEditorComImageMode.getValue();
   ImageEditor.selectedImage.imageMode = %imageMode;
   
   if(%imageMode !$= "FULL")
      ImageEditorCheckBoxFilterPad.setValue(true);
   
   ImageEditorAutoApply();
}

// --------------------------------------------------------------------
// Image Editor Cell Settings Auto Apply Commands
//
// These all get called when you edit a cell specific Image Builder 
// field.  Most do nothing more than call the auto apply, though a 
// few will check the values and/or store them for builder usage.
// --------------------------------------------------------------------
function ImageEditorApplyCountX()
{
   ImageEditor.CountExtentOverride = "";
   ImageEditorAutoApply();  
}

function ImageEditorApplyCountY()
{
   ImageEditor.CountExtentOverride = "";
   ImageEditorAutoApply();
}

function ImageEditorApplyCellHeight()
{
   ImageEditor.CountExtentOverride = "Extent";
   ImageEditorAutoApply();
}

function ImageEditorApplyCellWidth()
{
   ImageEditor.CountExtentOverride = "Extent";
   ImageEditorAutoApply();
}

function ImageEditorApplyOffsetY()
{
   ImageEditorAutoApply();
}

function ImageEditorApplyOffsetX()
{
   ImageEditorAutoApply();
}

function ImageEditorApplyStrideX()
{
   ImageEditorAutoApply();
}

function ImageEditorApplyStrideY()
{
   ImageEditorAutoApply();
}

function ImageEditorCellRowOrder()
{
   ImageEditorAutoApply();
}