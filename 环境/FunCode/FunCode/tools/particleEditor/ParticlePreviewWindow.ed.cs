//------------------------------------------------------------------------------
// Torque Game Builder
// Copyright (C) GarageGames.com, Inc.
//------------------------------------------------------------------------------

function ParticlePreviewWindow::onAdd(%this)
{
   t2dAssert(%this.getClassName() $= "t2dSceneWindow",
             "ParticlePreviewWindow::onAdd - This is not a t2dSceneWindow!");
   
   %this.scenegraph = new t2dSceneGraph();
   %this.sprite = new t2dParticleEffect() { scenegraph = %this.scenegraph; };
   %this.sprite.setName("ParticlePreviewTest");
   %this.sprite.setSize( "15 15" );
   %this.sprite.setPosition( "0 0" );
   %this.baseDimension = 100;
   %this.Particle = "";
   %this.setFillBackGround( true, 128, 128, 128 );
   
   %this.setSceneGraph(%this.scenegraph);
}

/// void(ParticlePreviewWindow this)
/// Cleans up data allocated for this window.
/// @param this The ParticlePreviewWindow.
function ParticlePreviewWindow::onRemove(%this)
{
   if (isObject(%this.scenegraph))
      %this.scenegraph.delete();
      
   if (isObject(%this.sprite))
      %this.sprite.delete();
}

/// void(ParticlePreviewWindow this)
/// Called when the window is first shown to make sure things are properly
/// sized.
/// @param this The ParticlePreviewWindow.
function ParticlePreviewWindow::onWake(%this)
{
   %this.onExtentChange(%this.position SPC %this.extent);
}

/// void(ParticlePreviewWindow this, RectF newDimensions)
/// Resizes the scenegraphs camera to maintain the correct aspect ratio.
/// @param this The ParticlePreviewWindow.
/// @param newDimensions The new position and size of the window.
function ParticlePreviewWindow::onExtentChange(%this, %newDimensions)
{
   %width = getWord(%newDimensions, 2);
   %height = getWord(%newDimensions, 3);
   
   %dimensions = resolveAspectRatio(%width / %height, %this.baseDimension);
   %cameraWidth = getWord(%dimensions, 0);
   %cameraHeight = getWord(%dimensions, 1);
   
   %this.setCurrentCameraPosition(0, 0, %cameraWidth, %cameraHeight);
}

/// void(ParticlePreviewWindow this, t2dImageMapDatablock imageMap)
/// Displays the specified image map in this window.
/// @param this The ParticlePreviewWindow.
/// @param Particle The Particle to display.
function ParticlePreviewWindow::display(%this, %Particle)
{   
   %this.Particle = %Particle;
   %this.update();
}

/// void(ParticlePreviewWindow this)
/// Clears the display.
/// @param this The ParticlePreviewWindow.
function ParticlePreviewWindow::clear(%this)
{
   %this.Particle = "";
   %this.update();
}

/// void(ParticlePreviewWindow this)
/// Updates the displayed Particle.
/// @param this The ParticlePreviewWindow.
/// @todo This doesn't take advantage of width or height when displaying
/// non-square Particles.
function ParticlePreviewWindow::update(%this)
{
   if ( %this.Particle $= "" )
   {
      %this.sprite.setVisible(false);
      return;
   }
   
   %this.sprite.setVisible(true);
   
   // Frame size.   
   %width = getWord( %this.extent, 0 );
   %height = getWord( %this.extent, 1 );
   
   // Camera size.
   %cameraSize = %this.getCurrentCameraSize();
   %cameraWidth = getWord(%cameraSize, 0);
   %cameraHeight = getWord(%cameraSize, 1);
   
   // Determine the amount to scale the sprite so it fills the camera.
   %widthScale = %cameraWidth / %width;
   %heightScale = %cameraHeight / %height;
   %scale = %widthScale < %heightScale ? %widthScale : %heightScale;
   
   %width *= %scale;
   %height *= %scale;   
      
   %file = expandFileName("resources/particles/") @ %this.Particle @ ".eff";
   
   %this.sprite.loadEffect( %file ); 
   %this.sprite.setPosition( "0 0" );  
   %this.sprite.setSize( %width SPC %height );//
   %this.sprite.setEffectLifeMode("CYCLE", 3.0);   
   %this.sprite.playEffect();
}
