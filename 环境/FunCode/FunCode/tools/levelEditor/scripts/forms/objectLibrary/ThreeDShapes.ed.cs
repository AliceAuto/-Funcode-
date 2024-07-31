//-----------------------------------------------------------------------------
// Gui SceneGraphEditCtrl Form Content
// Copyright (C) GarageGames.com, Inc.
//-----------------------------------------------------------------------------

//-----------------------------------------------------------------------------
// Register Form Content.
//-----------------------------------------------------------------------------
//$LBC3DShape = GuiFormManager::AddFormContent( "LevelBuilderSidebarCreate", "3D Shapes", "LBC3DShape::CreateForm", "LBC3DShape::SaveForm", 2 );

//-----------------------------------------------------------------------------
// Form Content Creation Function
//-----------------------------------------------------------------------------
function LBC3DShape::CreateForm( %contentCtrl )
{    

   // Create necessary objects.
   %base = ObjectLibraryBaseType::CreateContent( %contentCtrl, "LBOT3DShape" );
   %base.sortOrder = 6;

   // Set Caption.
   %base.caption = "3D Shapes";

   // Return Base.
   return %base;

}

//-----------------------------------------------------------------------------
// Form Content Save Function
//-----------------------------------------------------------------------------
function LBC3DShape::SaveForm( %formCtrl, %contentObj )
{
   %formCtrl.sSpritesExpanded = %contentObj.sSpritesExpanded;
}

function LBOT3DShape::refresh( %this, %resize )
{
   %this.destroy();
   
   %this.scenegraph = new t2dSceneGraph();
   
   
   $LB::ObjectLibraryGroup.add( %this.scenegraph );
   
   // Find objectList
   %objectList = %this.findObjectByInternalName("ObjectList");
   %objectsAdded = 0;
     
   // Refresh in resource manager
   %path = expandFileName( "^game/data/shapes/" );
   removeResPath( %path @ "*" );
   addResPath( %path );
   
   %fileSpec = %path @ "*.dts";

   for (%file = findFirstFile(%fileSpec); %file !$= ""; %file = findNextFile(%fileSpec))
   {
	   // Create Shape Object
      %shape3DObject = new t2dShape3D()  { scenegraph = %this.SceneGraph; };
      %shape3DObject.setShape( %file );
      %shape3DObject.setSize( "10 10" );

      %objectList.AddT2DObject( %shape3DObject, %file, "t2dShape3D" );
      %objectsAdded ++;
   }
   
   if( %resize )
   {
      if( %objectsAdded > 0 )
         %this.sizeToContents();
      else
         %this.instantCollapse();
   }
}


function LBOT3DShape::onRemove( %this )
{
   // I don't understand this, but sometimes in onSleep 
   // for this content, the %this object is bad. :(
   if( !isObject( %this ) )
      return;

   %this.destroy();
}

function LBOT3DShape::destroy( %this )
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

function LBOT3DShape::onContentMessage(%this, %sender, %message)
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
