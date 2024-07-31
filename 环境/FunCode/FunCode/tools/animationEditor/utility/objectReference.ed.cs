//------------------------------------------------------------------------------
// Torque Game Builder
// Copyright (C) GarageGames.com, Inc.
//------------------------------------------------------------------------------

function t2dSceneGraph::getImageMapReferenceList(%this, %imageMap, %referenceList, %animations, %sprites, %animatedSprites, %scrollers)
{
   if(%animations $= "") %animations = true;
   if(%sprites $= "") %sprites = true;
   if(%animatedSprites $= "") %animatedSprites = true;
   if(%scrollers $= "") %scrollers = true;
   
   %objectCount = %this.getSceneObjectCount();
   for(%i = 0; %i < %objectCount; %i++)
   {
      %object = %this.getSceneObject(%i);
      
      %className = %object.getClassName();
      if(((%className $= "t2dStaticSprite") && %sprites) ||
         ((%className $= "t2dScroller") && %scrollers))
      {
         %testImageMap = %object.getImageMap();
         if(%testImageMap.getId() == %imageMap.getId())
            %referenceList.add(%object);
      }
      
      else if((%className $= "t2dAnimatedSprite") && %animatedSprites)
      {
         if(%object.animationName.imageMap.getId() == %imageMap.getId())
            %referenceList.add(%object);
      }
   } 
   
   %datablocks = getT2DDatablockSet();
   %datablockCount = %datablocks.getCount();
   for(%i = 0; %i < %datablockCount; %i++)
   {
      %datablock = %datablocks.getObject(%i);
      %className = %datablock.getClassName();
      if((%className $= "t2dAnimationDatablock") && %animations)
      {
         if(%datablock.imageMap.getId() == %imageMap.getId())
            %referenceList.add(%datablock);
      }
      else if((%className $= "t2dImageMapDatablock"))
      {
         // if this is a link image map, loop through the links and see if
         // the image map being deleted is listed, if it is, add a reference
         if (%datablock.imageMode $= "LINK")
         {
            %linkCount = getWordCount(%datablock.linkImageMaps);
            for (%linkItr = 0; %linkItr < %linkcount; %linkItr++)
            {
               %linkImageMap = getWord(%datablock.linkImageMaps, %linkItr);
               if (!isObject(%linkImageMap))
                  continue;
               
               if (%linkImageMap.getId() == %imageMap.getId())
               {
                  // only need to add once
                  %referenceList.add(%datablock);
                  break;
               }
            }
         }
      }
   }
   
   return %referenceList.getCount();
}

function t2dSceneGraph::getAnimationReferenceList(%this, %animation, %referenceList)
{
   %objectCount = %this.getSceneObjectCount();
   for(%i = 0; %i < %objectCount; %i++)
   {
      %object = %this.getSceneObject(%i);
      if(%object.getClassName() $= "t2dAnimatedSprite")
      {
         if(%object.animationName.getId() == %animation.getId())
            %referenceList.add(%object);
      }
   }
   
   return %referenceList.getCount();
}
