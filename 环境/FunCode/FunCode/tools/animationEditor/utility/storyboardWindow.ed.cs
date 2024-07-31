

function StoryboardWindow::onAdd(%this)
{
   %this.scenegraph = new t2dSceneGraph();
   %this.staticSpriteGroup = new SimGroup();
   %this.height = 10;
   
   %this.setSceneGraph(%this.scenegraph);
   %this.scenegraph.setDebugOn(1);
   %this.useObjectMouseEvents = true;
}

function StoryboardWindow::onRemove(%this)
{
   if (isObject(%this.scenegraph))
      %this.scenegraph.delete();
      
   if (isObject(%this.staticSpriteGroup))
      %this.staticSpriteGroup.delete();
}

function ImageMapStoryboardWindow::update(%this, %imageMap, %frames)
{
   %this.staticSpriteGroup.deleteContents();
   
   %count = getWordCount(%frames);
   %spacing = %imageMap.getFrameSize(0) / 4;
   
   %height = %imageMap.getFrameSize(0);
   %width = %spacing;
   for (%i = 0; %i < %count; %i++)
   {
      %frame = getWord(%frames, %i);
      %sprite = new t2dStaticSprite()
      {
         scenegraph = %this.scenegraph;
         class = "ImageMapStoryboardSprite";
         imageMap = %imageMap;
         frame = %frame;
         size = %imageMap.getFrameSize(0);
         useMouseEvents = true;
         frameNumber = %i;
         window = %this;
      };
      
      %this.staticSpriteGroup.add(%sprite);
      
      %spriteWidth = getWord(%sprite.size, 0);
      %sprite.position = %width + (%spriteWidth / 2) SPC "0";
      %width += %spriteWidth + %spacing;
      
      %newHeight = getWord(%sprite.size, 1);
      if (%newHeight > %height)
         %height = %newHeight;
   }
   
   %dropSpot = new t2dSceneObject()
   {
      scenegraph = %this.scenegraph;
      size = %imageMap.getFrameSize(0);
   };
   %this.staticSpriteGroup.add(%dropSpot);
   %dropSpot.position = %width + (getWord(%dropSpot.size, 0) / 2) SPC "0";
   
   %width += %imageMap.getFrameSize(0);
   %this.setCurrentCameraArea(0, 0 - (%height / 2), %width, %height / 2);
   %ar = %width / %height;
   %windowHeight = getWord(%this.extent, 1);
   %windowSize = resolveAspectRatio(%ar, %windowHeight);
   %windowWidth = mFloatLength(getWord(%windowSize, 0), 0);
   %this.setExtent(%windowWidth, %windowHeight);
   
   %this.objectWidth = getWord(%imageMap.getFrameSize(0), 0);
   %this.spacing = %spacing;
}

function ImageMapStoryboardSprite::onMouseDragged(%this, %modifier, %position, %clicks)
{
   %upperLeft = getWords(%this.getArea(), 0, 1);
   %windowPos = %this.window.getWindowPoint(%upperLeft);
   %spritePosition = %this.window.getCanvasPoint(%windowPos);
   %windowPos = %this.window.getWindowPoint(%position);
   %mousePosition = %this.window.getCanvasPoint(%windowPos);
   
   %origin = %this.window.getWindowPoint("0 0");
   %size = %this.window.getWindowPoint(%this.size);
   %size = t2dVectorSub(%size, %origin);
   
   // Round these off.
   %spritePosition = mFloatLength(getWord(%spritePosition, 0), 0) SPC mFloatLength(getWord(%spritePosition, 1), 0);
   %mousePosition = mFloatLength(getWord(%mousePosition, 0), 0) SPC mFloatLength(getWord(%mousePosition, 1), 0);
   %size = mFloatLength(getWord(%size, 0), 0) SPC mFloatLength(getWord(%size, 1), 0);
   
   AnimationBuilder.createDraggingControl(%this, %spritePosition, %mousePosition, %size);
}
