//-----------------------------------------------------------------------------
// Gui SceneGraphEditCtrl Form Content
// Copyright (C) GarageGames.com, Inc.
//-----------------------------------------------------------------------------
if( !isObject( testTextureImageMap ) ) 
{
   new t2dImageMapDatablock( testTextureImageMap )
   {
      imageName = "./testTexture";
      imageMode = "FULL";
      filterMode = "SMOOTH";
      filterPad = "0";
      preferPerf = "1";
      preload = "1";
      allowUnload = "0";
      force16Bit = "0";
   };
   if( isObject( $ignoredDatablockSet ) )
      $ignoredDatablockSet.add( testTextureImageMap );   
}


//-----------------------------------------------------------------------------
// Register Form Content.
//-----------------------------------------------------------------------------
$LBCParticleEffect = GuiFormManager::AddFormContent( "LevelBuilderSidebarCreate", "ParticleEffects", "LBCParticleEffect::CreateForm", "LBCParticleEffect::SaveForm", 2 );

//-----------------------------------------------------------------------------
// Form Content Creation Function
//-----------------------------------------------------------------------------
function LBCParticleEffect::CreateForm( %contentCtrl )
{    

   // Create necessary objects.
   %base = ObjectLibraryBaseType::CreateContent( %contentCtrl, "LBOTParticleEffect" );
   %base.sortOrder = 4;

   // Set Caption.
   %base.caption = "Á£×ÓÌØÐ§";//Particle Effects

   // Return Base.
   return %base;

}

//-----------------------------------------------------------------------------
// Form Content Save Function
//-----------------------------------------------------------------------------
function LBCParticleEffect::SaveForm( %formCtrl, %contentObj )
{
   %formCtrl.sSpritesExpanded = %contentObj.sSpritesExpanded;
}
   
function LBOTParticleEffect::refresh( %this, %resize )
{
   %this.destroy();
   
   %this.scenegraph = new t2dSceneGraph();
   
   $LB::ObjectLibraryGroup.add( %this.scenegraph );
   
   // Find objectList
   %objectList = %this.findObjectByInternalName("ObjectList");

   // Add Empty Effect
   %defaultEffectFile = expandFilename("./newEffect.eff");
   %particleEffect = new t2dStaticSprite()
   {
      scenegraph = %this.SceneGraph;
      imageMap = particleEffectIconImageMap;
   };
   %objectList.AddT2DObject( %particleEffect, %defaultEffectFile, "t2dParticleEffect", fileBase( %defaultEffectFile ) );
   
   %objectsAdded = 0;
   
   
   %path = expandFileName( "^game/data/particles/" );
   removeResPath( %path @ "*" );
   addResPath( %path );
   
   %fileSpec = %path @ "*.eff";
   for (%file = findFirstFile(%fileSpec); %file !$= ""; %file = findNextFile(%fileSpec))
   {

	   // Create Effect Object
      %particleEffect = new t2dParticleEffect()  { scenegraph = %this.SceneGraph; };
      %particleEffect.loadEffect( %file );
      %particleEffect.setSize( "15 15" );
      %particleEffect.moveEffectTo(2.0, 0.5);
      %particleEffect.setEffectLifeMode("CYCLE", 2.0);
      %particleEffect.setPaused(true);


      %objectList.AddT2DObject( %particleEffect, %file, "t2dParticleEffect", fileBase( %file ) );
      
      %objectsAdded++;
   }
   
   if( %resize )
   {
      if( %objectsAdded > 0 )
         %this.sizeToContents();
      else
         %this.instantCollapse();
   }
}


function LBOTParticleEffect::onRemove( %this )
{
   // I don't understand this, but sometimes in onSleep 
   // for this content, the %this object is bad. :(
   if( !isObject( %this ) )
      return;
      
   %this.destroy();
}

function LBOTParticleEffect::destroy( %this )
{
   if (isObject(%this.scenegraph))
      %this.scenegraph.delete();
      
   // Find objectList
   %objectList = %this.findObjectByInternalName("ObjectList");

   if( !isObject( %objectList ) )
      return;

   while( %objectList.getCount() > 0 )
   {
      %object = %objectList.getObject( 0 );
      if( isObject( %object ) )
         %object.delete();
      else
         %objectList.remove( %object );
   }
}

function LBOTParticleEffect::onContentMessage(%this, %sender, %message)
{
   %messageCommand = GetWord( %message, 0 );
   switch$( %messageCommand )
   {
      case "refresh":
         %this.refresh();
         
      case "destroy":
         %this.destroy();
   }
}
