//-----------------------------------------------------------------------------
// Gui SceneGraphEditCtrl Form Content
// Copyright (C) GarageGames.com, Inc.
//-----------------------------------------------------------------------------

//-----------------------------------------------------------------------------
// Register Form Content.
//-----------------------------------------------------------------------------
$LBCTileMap = GuiFormManager::AddFormContent( "LevelBuilderSidebarCreate", "TileMaps", "LBCTileMap::CreateForm", "LBCTileMap::SaveForm", 2 );

//-----------------------------------------------------------------------------
// Form Content Creation Function
//-----------------------------------------------------------------------------
function LBCTileMap::CreateForm( %contentCtrl )
{    

   // Create necessary objects.
   %base = ObjectLibraryBaseType::CreateContent( %contentCtrl, "LBOTTileMap" );
   %base.sortOrder = 5;

   // Set Caption.
   %base.caption = "Æ½ÆÌÍ¼";//Tilemaps

   // Return Base.
   return %base;

}

//-----------------------------------------------------------------------------
// Form Content Save Function
//-----------------------------------------------------------------------------
function LBCTileMap::SaveForm( %formCtrl, %contentObj )
{
   %formCtrl.sSpritesExpanded = %contentObj.sSpritesExpanded;
}

function LBOTTileMap::refresh( %this, %resize )
{
   %this.destroy();
   
   %this.scenegraph = new t2dSceneGraph();
   %this.tilemap = new t2dTileMap() { scenegraph = %this.scenegraph; };
   
   $LB::ObjectLibraryGroup.add( %this.scenegraph );
   $LB::ObjectLibraryGroup.add( %this.tilemap );
   
   // Find objectList
   %objectList = %this.findObjectByInternalName("ObjectList");
   %objectsAdded = 0;
   // Add Empty Layer
   %defaultLayerFile = expandFilename("./newLayer.lyr");
   %tileLayer = new t2dStaticSprite()
   {
      scenegraph = %this.SceneGraph;
      imageMap = tileLayerIconImageMap;
   };
   %objectList.AddT2DObject( %tileLayer, %defaultLayerFile, "t2dTileLayer", fileName( %defaultLayerFile ));
   
   
   // Refresh in resource manager
   %path = expandFileName( "^game/data/tilemaps/" );
   removeResPath( %path @ "*" );
   addResPath( %path );
   
   %fileSpec = %path @ "*.lyr";
   
   for (%file = findFirstFile(%fileSpec); %file !$= ""; %file = findNextFile(%fileSpec))
   {
      %tilelayer = %this.tilemap.createTileLayer(1, 1, 1, 1);
      %tilelayer.loadTileLayer(%file);
      %tileLayer.setSize( %tileLayer.getTileCountX() * %tileLayer.getTileSizeX(),
                          %tileLayer.getTileCountY() * %tileLayer.getTileSizeY() );

      %objectList.AddT2DObject( %tilelayer, %file, "t2dTileLayer", fileName( %file ) );
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


function LBOTTileMap::onRemove( %this )
{
   // I don't understand this, but sometimes in onSleep 
   // for this content, the %this object is bad. :(
   if( !isObject( %this ) )
      return;

   %this.destroy();
}

function LBOTTileMap::destroy(%this)
{
   if (isObject(%this.scenegraph))
   {
      %this.tilemap.delete();
      %this.scenegraph.delete();
   }
      
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

function LBOTTileMap::onContentMessage(%this, %sender, %message)
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
