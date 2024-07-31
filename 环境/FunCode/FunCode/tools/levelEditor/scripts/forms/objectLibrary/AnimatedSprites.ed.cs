//-----------------------------------------------------------------------------
// Gui SceneGraphEditCtrl Form Content
// Copyright (C) GarageGames.com, Inc.
//-----------------------------------------------------------------------------

//-----------------------------------------------------------------------------
// Register Form Content.
//-----------------------------------------------------------------------------
$LBCAnimatedSprite = GuiFormManager::AddFormContent( "LevelBuilderSidebarCreate", "AnimatedSprites", "LBCAnimatedSprite::CreateForm", "LBCAnimatedSprite::SaveForm", 2 );

//-----------------------------------------------------------------------------
// Form Content Creation Function
//-----------------------------------------------------------------------------
function LBCAnimatedSprite::CreateForm( %contentCtrl )
{    

   // Create necessary objects.
   %base = ObjectLibraryBaseType::CreateContent( %contentCtrl, "LBOTAnimatedSprite" );
   %base.sortOrder = 2;

   // Set Caption.
   %base.caption = "¶¯»­¾«Áé(Sprites)";//Animated Sprites

   // Return Base.
   return %base;

}

//-----------------------------------------------------------------------------
// Form Content Save Function
//-----------------------------------------------------------------------------
function LBCAnimatedSprite::SaveForm( %formCtrl, %contentObj )
{
   %formCtrl.sSpritesExpanded = %contentObj.sSpritesExpanded;
}

function LBOTAnimatedSprite::refresh( %this, %resize )
{
   %this.destroy();
   
   %this.scenegraph = new t2dSceneGraph();
   
   $LB::ObjectLibraryGroup.add( %this.scenegraph );
   
   %datablockSet = getT2DDatablockSet();
   %datablockCount = %datablockSet.getCount();
   
   // Find objectList
   %objectList = %this.findObjectByInternalName("ObjectList");
   %objectsAdded = 0;
   
   for (%i = 0; %i < %datablockCount; %i++ )
   {
      %object = %datablockSet.getObject( %i );
      if( %object.getClassName() $= "t2dAnimationDatablock" )
      {
	      // Create Sprite Object
         %staticSprite = new t2dAnimatedSprite()  { scenegraph = %this.SceneGraph; };
         %staticSprite.playAnimation( %object.getName() );
         %staticSprite.setSize( %object.getName().imageMap.getFrameSize(0) );

         %objectList.AddT2DObject( %staticSprite, %object.getName(), "t2dAnimatedSprite" );
         %objectsAdded ++;
      }
   }
   
   if( %resize )
   {
      if( %objectsAdded > 0 )
         %this.sizeToContents();
      else
         %this.instantCollapse();
   }
}


function LBOTAnimatedSprite::onRemove( %this )
{
   // I don't understand this, but sometimes in onSleep 
   // for this content, the %this object is bad. :(
   if( !isObject( %this ) )
      return;
      
   %this.destroy();
}

function LBOTAnimatedSprite::destroy( %this )
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

function LBOTAnimatedSprite::onContentMessage(%this, %sender, %message)
{
   %messageCommand = GetWord( %message, 0 );
   switch$( %messageCommand )
   {
      case "refresh":
         %this.refresh();
         GuiFormManager::SendContentMessage($LBCreateSiderBar, %this, "refresh");
         
      case "destroy":
         %this.destroy();
   }
}
