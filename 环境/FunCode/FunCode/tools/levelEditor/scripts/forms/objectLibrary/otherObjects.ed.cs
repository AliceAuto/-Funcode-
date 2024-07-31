//-----------------------------------------------------------------------------
// Gui SceneGraphEditCtrl Form Content
// Copyright (C) GarageGames.com, Inc.
//-----------------------------------------------------------------------------

//-----------------------------------------------------------------------------
// Register Form Content.
//-----------------------------------------------------------------------------
$LBCOther = GuiFormManager::AddFormContent( "LevelBuilderSidebarCreate", "Other", "LBCOther::CreateForm", "LBCOther::SaveForm", 2 );

//-----------------------------------------------------------------------------
// Form Content Creation Function
//-----------------------------------------------------------------------------
function LBCOther::CreateForm( %contentCtrl )
{    
   // Create necessary objects.
   %base = ObjectLibraryBaseType::CreateContent( %contentCtrl, "LBOTOther" );
   %base.sortOrder = 7;

   // Set Caption.
   %base.caption = "其它";//Other

   // Return Base.
   return %base;

}

//-----------------------------------------------------------------------------
// Form Content Save Function
//-----------------------------------------------------------------------------
function LBCOther::SaveForm( %formCtrl, %contentObj )
{
   %formCtrl.sOtherExpanded = %contentObj.sOtherExpanded;
}

function LBOTOther::refresh( %this, %resize )
{
   %this.destroy();
   
   %this.scenegraph = new t2dSceneGraph();
   
   $LB::ObjectLibraryGroup.add( %this.scenegraph );
   
   // Find objectList
   %objectList = %this.findObjectByInternalName("ObjectList");
   
   //%sceneObject = new t2dStaticSprite() { scenegraph = %this.SceneGraph; imageMap = sceneObjectImageMap; };
   //%objectList.AddT2DObject(%sceneObject, "Scene Object", "t2dSceneObject","场景物体");
   
   %sceneObject = new t2dStaticSprite() { scenegraph = %this.SceneGraph; imageMap = triggerObjectImageMap; };
   %objectList.AddT2DObject(%sceneObject, "Trigger", "t2dTrigger", "触发器");
   
   %sceneObject = new t2dStaticSprite() { scenegraph = %this.SceneGraph; imageMap = pathObjectImageMap; };
   %objectList.AddT2DObject(%sceneObject, "Path", "t2dPath", "路径");
   
   %sceneObject = new t2dStaticSprite() { scenegraph = %this.SceneGraph; imageMap = textObjectImageMap; };
   %objectList.AddT2DObject(%sceneObject, "Text", "t2dTextObject", "文字");

   %sceneObject = new t2dStaticSprite() { scenegraph = %this.SceneGraph; imageMap = shapeVectorImageMap; };
   %objectList.AddT2DObject(%sceneObject, "Polygon", "t2dShapeVector", "多边形");
}


function LBOTOther::onRemove( %this )
{
   // I don't understand this, but sometimes in onSleep 
   // for this content, the %this object is bad. :(
   if( !isObject( %this ) )
      return;

   %this.destroy();
}

function LBOTOther::destroy( %this )
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

function LBOTOther::onContentMessage(%this, %sender, %message)
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
