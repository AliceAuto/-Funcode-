//------------------------------------------------------------------------------
// Torque Game Builder
// Copyright (C) GarageGames.com, Inc.
//------------------------------------------------------------------------------

function AnimationBuilder::open(%this)
{
   if(!isObject(%this.animation))
   {
      warn("AnimationBuilder::open - no animation to edit.");
      return;
   }
   
   activatePackage(AnimationBuilderPackage);
   %this.updateGui();
   ABImageMapPreviewWindow.display(%this.animation.imageMap);
   Canvas.pushDialog(AnimationBuilderGui);
}

function AnimationBuilder::close(%this)
{
   Canvas.popDialog(AnimationBuilderGui);
   ABImageMapPreviewWindow.clear();
   %this.newAnimation = false;
   %this.animation = "";
   deactivatePackage(AnimationBuilderPackage);
   
   // [Neo, 15/7/2007 - #3232]
   //GuiFormManager::SendContentMessage($TXAnimatedSprite, %this, "refresh 1");
   GuiFormManager::SendContentMessage( $LBCAnimatedSprite, %this, "refresh 1" );
}

function AnimationBuilder::updateGui(%this)
{
   ABStoryboardWindow.update(%this.animation.imageMap, %this.animation.animationFrames);
   ABCycleAnimationCheck.setValue(%this.animation.animationCycle);
   ABPingPongAnimationCheck.setValue(%this.animation.animationPingPong);
   ABReverseAnimationCheck.setValue(%this.animation.animationReverse);
   ABNameField.setText(%this.animation.getName());
   ABRandomCheck.setValue(%this.animation.randomStart);
   ABStartFrameField.setText(%this.animation.startFrame);
   
   %this.animation.calculateAnimation();
   
   if (%this.animation.getFrameCount() > 0)
   {
      ABFPSField.setText(%this.animation.getFrameCount() / %this.animation.animationTime);
      ABAnimationPreviewWindow.display(%this.animation);
   }
   else
   {
      ABFPSField.setText(%this.defaultFPS);
      ABAnimationPreviewWindow.clear();
   }
}

function AnimationBuilder::validateCycleAnimation(%this)
{
   %this.animation.animationCycle = ABCycleAnimationCheck.getValue();
}


function AnimationBuilder::validatePingPongAnimation(%this)
{
   %this.animation.animationPingPong = ABPingPongAnimationCheck.getValue();
}


function AnimationBuilder::validateReverseAnimation(%this)
{
   %this.animation.animationReverse = ABReverseAnimationCheck.getValue();
}

function AnimationBuilder::validateFPS(%this)
{
   %fps = ABFPSField.getText();
   %fps = clamp(%fps, %this.minFPS, %this.maxFPS);
   ABFPSField.setText(%fps);
   
   if (%this.animation.getFrameCount() < 1)
      return;
   
   %this.animation.animationTime = %this.animation.getFrameCount() / %fps;
   %this.animation.calculateAnimation();
   %this.updateGui();
}

function AnimationBuilder::validateName(%this)
{
   %name = ABNameField.getText();
   if (%name $= %this.animation.getName() )
      return;
      
   %name = validateObjectName(%name);
   %this.animation.setName(%name);
   ABNameField.setText(%name);
}

function AnimationBuilder::validateRandom(%this)
{
   %this.animation.randomStart = ABRandomCheck.getValue();
}

function AnimationBuilder::validateStartFrame(%this)
{
   %startFrame = ABStartFrameField.getText();
   %frameCount = %this.animation.getFrameCount();
   if (%frameCount == 0)
      %startFrame = 0;
   else
   {
      %startFrame = mFloatLength(%startFrame, 0);
      %startFrame = clamp(%startFrame, 0, %frameCount - 1);
   }
   
   %this.animation.startFrame = %startFrame;
   ABStartFrameField.setText(%startFrame);
}

function AnimationBuilder::insertFrame(%this, %frame, %position)
{
   %frames = %this.animation.animationFrames;
   %frameCount = getWordCount(%frames);
   if (%position > %frameCount)
      %position = %frameCount;
   else if (%position < 0)
      %position = 0;
   
   %this.animation.animationTime = (%frameCount + 1) / ABFPSField.getText();
   
   %newFrames = "";
   for (%i = 0; %i <= %frameCount; %i++)
   {
      if (%i == %position)
         %newFrames = %newFrames SPC %frame;
      
      if (%i < %frameCount)
         %newFrames = %newFrames SPC getWord(%frames, %i);
   }
   
   %this.animation.animationFrames = trim(%newFrames);
   %this.animation.calculateAnimation();
   %this.updateGui();
   
   %scrollCtrl = ABStoryboardWindow.getParent();
   %worldWidth = ABStoryboardWindow.objectWidth + ABStoryboardWindow.spacing;
   %windowWidth = getWord(ABStoryboardWindow.getWindowSize(%worldWidth SPC 0), 0);
   %scrollCtrl.setScrollPosition(%windowWidth * %position, 0);
}

function AnimationBuilder::removeFrame(%this, %position)
{
   %frames = %this.animation.animationFrames;
   %frameCount = getWordCount(%frames);
   
   %this.animation.animationTime = (%frameCount - 1) / ABFPSField.getText();
   
   %newFrames = "";
   for (%i = 0; %i < %frameCount; %i++)
   {
      if (%i != %position)
         %newFrames = %newFrames SPC getWord(%frames, %i);
   }
   
   %this.animation.animationFrames = trim(%newFrames);
   %this.animation.calculateAnimation();
   %this.updateGui();
}

function AnimationBuilder::appendFrame(%this, %frame)
{
   %this.insertFrame(%frame, %this.animation.getFrameCount());
}

function AnimationBuilder::setAllFrames(%this)
{
   %this.clearFrames();
   %frameCount = %this.animation.imageMap.getFrameCount();
   for (%i = 0; %i < %frameCount; %i++)
      %this.appendFrame(%i);
}

function AnimationBuilder::clearFrames(%this)
{
   // rdbnote: we're clearing frames from the animation
   ///   not the frames from the image map...
   //%frameCount = %this.animation.imageMap.getFrameCount();
   
   %frameCount = %this.animation.getFrameCount();
   for (%i = 0; %i < %frameCount; %i++)
      %this.removeFrame(0);
}

/// void(AnimationBuilderGui this, GuiControl control, Point2F position)
/// Catch all in case there's something that catches drag and drops beneath us.
/// @param this The gui.
/// @param control The control that was dropped.
/// @param position The position the control was dropped at.
function AnimationBuilderGui::onControlDropped( %this, %control, %position)
{
   if (%control.sceneObject.spriteClass $= "ImageMapStoryboardSprite")
      AnimationBuilder.removeFrame(%control.sceneObject.frameNumber);
}

function AnimationBuilder::createDraggingControl(%this, %sprite, %spritePosition, %mousePosition, %size)
{
   // Create the drag and drop control.
   %dragControl = new GuiDragAndDropControl()
   {
      Profile = "GuiDragAndDropProfile";
      Position = %spritePosition;
      Extent = %size;
      deleteOnMouseUp = true;
   };
   
   // Create the t2d object control. This must be modeless.
   %t2dControl = new guiT2DObjectCtrl()
   {
      Profile = "GuiModelessDialogProfile";
      Extent = %size;
   };
   
   // And the sprite to display.
   %sceneObject = new t2dStaticSprite()
   {
      scenegraph = %this.draggingScenegraph;
      size = %sprite.size;
      imageMap = %sprite.imageMap;
      frame = %sprite.frame;
      frameNumber = %sprite.frameNumber;
      spriteClass = %sprite.class;
   };
   
   // Place the guis.
   AnimationBuilderGui.add(%dragControl);
   %t2dControl.setSceneObject(%sceneObject);
   %dragControl.add(%t2dControl);
   
   // Figure the position to place the control relative to the mouse.
   %xOffset = getWord(%mousePosition, 0) - getWord(%spritePosition, 0);
   %yOffset = getWord(%mousePosition, 1) - getWord(%spritePosition, 1);
   
   %dragControl.startDragging(%xOffset, %yOffset);
}

function ABStoryboardWindow::onControlDropped(%this, %control, %position)
{
   if (%control.sceneObject.spriteClass $= "ImageMapStoryboardSprite")
      return;
      
   %position = %this.getMousePosition();
   %worldX = getWord(%position, 0);
   %sizeX = %this.objectWidth + %this.spacing;
   
   %index = mFloor((%worldX / %sizeX) + 0.5);
   AnimationBuilder.insertFrame( %control.sceneObject.frame, %index );
}
