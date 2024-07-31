//-----------------------------------------------------------------------------
// Gui SceneGraphEditCtrl Form Content
// Copyright (C) GarageGames.com, Inc.
//-----------------------------------------------------------------------------

//-----------------------------------------------------------------------------
// Register Form Content.
//-----------------------------------------------------------------------------
$LBCStaticSprite = GuiFormManager::AddFormContent( "LevelBuilderSidebarCreate", "StaticSprites", "LBCStaticSprite::CreateForm", "LBCStaticSprite::SaveForm", 2 );

//-----------------------------------------------------------------------------
// Form Content Creation Function
//-----------------------------------------------------------------------------
function LBCStaticSprite::CreateForm( %contentCtrl )
{    
   // Create necessary objects.
   %base = ObjectLibraryBaseType::CreateContent( %contentCtrl, "LBOTStaticSprite" );
   %base.sortOrder = 1;

   // Set Caption.
   %base.caption = "¾²Ì¬¾«Áé(Sprites)";//Static Sprites

   // Return Base.
   return %base;

}

//-----------------------------------------------------------------------------
// Form Content Save Function
//-----------------------------------------------------------------------------
function LBCStaticSprite::SaveForm( %formCtrl, %contentObj )
{
   %formCtrl.sSpritesExpanded = %contentObj.sSpritesExpanded;
}

function LBOTStaticSprite::refresh(%this, %resize)
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
      if( %object.getClassName() $= "t2dImageMapDatablock" )
      {
	      // Create Sprite Object
         %staticSprite = new t2dStaticSprite()  { scenegraph = %this.SceneGraph; };
         %staticSprite.setImageMap( %object.getName() );
         %staticSprite.setSize( %object.getFrameSize(0) );

         %caption = "";
         %imageMode = %object.getImageMapMode();
         if( (%imageMode $= "CELL") || (%imageMode $= "LINK") || (%imageMode $= "KEY") )
         {
            %totalFrames  = %object.getFrameCount();
            %caption = "1/" @ %totalFrames;
         }

         %objectList.AddT2DObject( %staticSprite, %object.getName(), "t2dStaticSprite", %caption );
         %objectsAdded++;
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

function LBOTStaticSprite::onRemove( %this )
{
   // I don't understand this, but sometimes in onSleep 
   // for this content, the %this object is bad. :(
   if( !isObject( %this ) )
      return;

   %this.destroy();
}

function LBOTStaticSprite::destroy(%this)
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

function LBOTStaticSprite::onContentMessage(%this, %sender, %message)
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
