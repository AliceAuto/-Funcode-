datablock t2dImageMapdatablock(ImageBuilderBackgroundImageMap)
{
	imageName = "~/imageEditor/data/Images/background";
	imageMode = full;
	filterPad = false;
};

datablock t2dImageMapdatablock(ImageBuilderBorderLineImageMap)
{
	imageName = "~/imageEditor/data/Images/borderLine";
	imageMode = full;
	filterPad = false;
};


if(!isObject(ImageBuilderZoomCursor)) new GuiCursor(ImageBuilderZoomCursor)
{
   hotSpot = "1 1";
   bitmapName = expandFilename("^tools/levelEditor/gui/images/iconZoom");
};
   
if(!isObject(ImageBuilderZoomInCursor)) new GuiCursor(ImageBuilderZoomInCursor)
{
   hotSpot = "1 1";
   bitmapName = expandFilename("^tools/levelEditor/gui/images/iconZoomIn");
}; 
    
if(!isObject(ImageBuilderZoomOutCursor)) new GuiCursor(ImageBuilderZoomOutCursor)
{
   hotSpot = "1 1";
   bitmapName = expandFilename("^tools/levelEditor/gui/images/iconZoomOut");
};

$ignoredDatablockSet.add(ImageBuilderBackgroundImageMap);
$ignoredDatablockSet.add(ImageBuilderBorderLineImageMap);