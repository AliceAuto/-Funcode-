//------------------------------------------------------------------------------
// Torque Game Builder
// Copyright (C) GarageGames.com, Inc.
//------------------------------------------------------------------------------

/// @todo Implement calling of the onChanged callback.
/// @todo Use internal names for the controls in the gui.

exec("./utility/main.ed.cs");
exec("./ABImageMapPreviewWindow.ed.cs");
exec("./gui/AnimationBuilder.ed.gui");
exec("./gui/FunCodeAnimation.ed.gui");
exec("./gui.ed.cs");

$IMAGE_MAP_FILTER_FULL = BIT(0);
$IMAGE_MAP_FILTER_CELL = BIT(1);
$IMAGE_MAP_FILTER_LINK = BIT(2);
$IMAGE_MAP_FILTER_KEY  = BIT(3);

function initializeAnimationEditor()
{
   if (!isObject(AnimationBuilder))
      new ScriptObject(AnimationBuilder);
}

function destroyAnimationEditor()
{
   if (isObject(AnimationBuilder))
      AnimationBuilder.delete();
}

function AnimationBuilder::onAdd(%this)
{
   %this.animation = "";
   %this.newAnimation = false;
   %this.oldAnimationData = new SimObject();
   
   // Default animation values.
   %this.defaultFPS = 30;
   %this.defaultAnimationCycle = true;
   %this.defaultPingPong = false;
   %this.defaultReverse = false;
   %this.defaultRandomStart = false;
   %this.defaultStartFrame = 0;
   %this.defaultName = "Animation";
   %this.defaultImageMapName = "ImageMap";
   
   // Bounds
   %this.maxFPS = 60;
   %this.minFPS = 1;
   
   // The scenegraph to use for the drag and drop controls.
   %this.draggingScenegraph = new t2dSceneGraph();
}

function AnimationBuilder::onRemove(%this)
{
   if (isObject(%this.oldAnimationData))
      %this.oldAnimationData.delete();
   
   if (isObject(%this.draggingSceneGraph))
      %this.draggingSceneGraph.delete();
}

function AnimationBuilder::createAnimation(%this)
{
   // we want celled and linked image maps
   %filter = $IMAGE_MAP_FILTER_CELL | $IMAGE_MAP_FILTER_LINK | $IMAGE_MAP_FILTER_KEY;
   ImageMapSelectGui.getImageMap("Ñ¡ÔñÍ¼Æ¬×ÊÔ´", %filter, %this @ ".newAnimation");
}

function AnimationBuilder::newAnimation(%this, %imageMap, %edit)
{
   if (!isObject(%imageMap))
      return;
   
   // Default values.
   if(%edit $= "") %edit = true;
   
   // Create the animation.
   %animation = new t2dAnimationDatablock()
   {
      imageMap = %imageMap;
      animationFrames = "";
      animationCycle = %this.defaultAnimationCycle;
      animationPingPong = %this.defaultAnimationPingPong;
      animationReverse = %this.defaultAnimationReverse;
      randomStart = %this.defaultRandomStart;
      startFrame = %this.defaultStartFrame;
   };
   
   // Prune the image map tag from the name.
   %baseName = %imageMap;
   %imapTag = strstr(%imageMap, %this.defaultImageMapName);
   if(%imapTag != -1)
      %baseName = getSubStr(%imageMap, 0, %imapTag);
   
   %name = validateObjectName(%baseName @ %this.defaultName);  
   %animation.setName(%name);
   %animation.calculateAnimation();
   
   if(%edit)
   {
      %this.newAnimation = true;
      %this.editAnimation(%animation);
   }
   else
   {
      // [Neo, 15/7/2007 - #3232]
      //TorqueXWorkspace.addDatablock(%animation);      
      LBProjectObj.addDatablock( %animation );
      
      // [Neo, 15/7/2007 - #3232]
      //GuiFormManager::SendContentMessage($TXAnimatedSprite, %this, "refresh 1");
      GuiFormManager::SendContentMessage( $LBCAnimatedSprite, %this, "refresh 1" );
   }
}

function AnimationBuilder::editAnimation(%this, %animation)
{
   %this.animation = %animation.getId();
   %this.copyData(%animation, %this.oldAnimationData, false);
   %this.open();
}

function AnimationBuilder::deleteAnimation(%this, %animation)
{
   %scenegraph = ToolManager.getLastWindow().getSceneGraph();
   %referenceList = new SimSet();
   %referenceCount = %scenegraph.getAnimationReferenceList(%animation, %referenceList);
   
   %message = "Do you really want to delete this animation?";
   if(%referenceCount > 0)
   {
      %message = getCountString("There {are} {count} object{s}", %referenceCount) @ " referencing this animation. If the" NL
                                "animation is deleted, the objects will also be deleted. Continue?";
   }
   
   %result = messageBox("Delete Animation", %message, "OkCancel", "Question");
   
   if(%result == $MROk)
   {
      // [Neo, 15/7/2007 - #3232]
      //TorqueXWorkspace.removeDatablock(%animation);
      LBProjectObj.removeDatablock( %animation );
      
      %referenceList.deleteContents();
      
      %animation.delete();
      
      // [Neo, 15/7/2007 - #3232]
      //GuiFormManager::SendContentMessage($TXAnimatedSprite, %this, "refresh 1");
      GuiFormManager::SendContentMessage( $LBCAnimatedSprite, %this, "refresh 1" );
   }
   
   %referenceList.delete();
}

function AnimationBuilder::save(%this)
{
   if (%this.newAnimation)
      //TorqueXWorkspace.addDatablock(%this.animation);
      LBProjectObj.addDatablock(%this.animation, true);
   else
      //TorqueXWorkspace.onEditDatablock(%this.animation);
      LBProjectObj.persistToDisk(true);
   
   GuiFormManager::SendContentMessage($LBCAnimatedSprite, %this, "refresh");
   %this.close();
}

function AnimationBuilder::cancel(%this)
{
   if (%this.newAnimation)
      %this.animation.delete();
   else
   {
      %this.copyData(%this.oldAnimationData, %this.animation, true);
      %this.animation.calculateAnimation();
   }
   
   %this.close();
}

function AnimationBuilder::copyData(%this, %copyFrom, %copyTo, %setName)
{
   if (%setName)
      %copyTo.setName(%copyFrom.name);
   else
      %copyTo.name = %copyFrom.getName();
   
   %copyTo.imageMap = %copyFrom.imageMap;
   %copyTo.animationFrames = %copyFrom.animationFrames;
   %copyTo.animationTime = %copyFrom.animationTime;
   %copyTo.animationCycle = %copyFrom.animationCycle;
   %copyTo.animationPingPong = %copyFrom.animationPingPong;
   %copyTo.animationReverse = %copyFrom.animationReverse;
   %copyTo.randomStart = %copyFrom.randomStart;
   %copyTo.startFrame = %copyFrom.startFrame;
}

package AnimationBuilderPackage
{

function t2dAnimationDatablock::getFrameCount(%this)
{
   return getWordCount(%this.animationFrames);
}

};
