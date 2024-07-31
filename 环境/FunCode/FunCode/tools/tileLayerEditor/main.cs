//-----------------------------------------------------------------------------
// Torque Game Builder
// Copyright (C) GarageGames.com, Inc.
//-----------------------------------------------------------------------------

$TileEditor::NewLayerFileName = "newLayer.lyr";

function initializeTileLayerEditor()
{
   echo(" % - Initializing TileMap Builder");
   
   exec("./fileDialogs.ed.cs");
   
   new ScriptObject(ActiveBrush)
   {
      class = TileBrush;
   };
   
   ActiveBrush.setBrush(" ");
   
   $tileScriptSet = new SimSet();
   TileEditSet::addText($tileScriptSet, "None");
   TileEditSet::addText($tileScriptSet, "No Change");
   $customDataSet = new SimSet();
   TileEditSet::addText($customDataSet, "None");
   TileEditSet::addText($customDataSet, "No Change");
}

function destroyTileLayerEditor()
{
   LBProjectObj.persistToDisk( false, false, false, true );
   
   ActiveBrush.delete();
   
   if(isObject($brushSet))
   {
      %count = $brushSet.getCount();
      for (%i = 0; %i < %count; %i++)
      {
         %brush = $brushSet.getObject(0);
         %brush.delete();
      }
      
      $brushSet.delete();
   }
   
   if(isObject($tileScriptSet))
      $tileScriptSet.delete();
   
   if(isObject($customDataSet))
      $customDataSet.delete();
}

$tileEditor::layerToSave = "";
$tileEditor::postSaveCallback = "";
function TileEditor::saveLayer( %layer, %callback, %forceSaveAs )
{
   $tileEditor::layerToSave = %layer;
   $tileEditor::postSaveCallback = %callback;
   
   if( %forceSaveAs $= "" )
      %forceSaveAs = false;
   
   // Safeguard against the rare case when the filename gets set to ".../.lyr"
   // which apparently is a writeable filename, but isn't writeable.
   if( fileBase( %layer.layerFile ) $= "" )
      %forceSaveAs = true;
      
   %fileName = %layer.LayerFile;
   
   // if the layer file name is in the object lib, then we need to get a different file name.
   %objectLib = expandFileName("^tools/levelEditor/scripts/forms/objectLibrary/");
   if( strstr(%fileName, %objectLib) >= 0 )
   {
      %fileName = "";
      %forceSaveAs = true;
   }
 
   if( %forceSaveAs || !( isFile( %fileName ) && ( filename( %fileName ) !$= $TileEditor::NewLayerFileName ) ))
      %fileName = T2DTileLayer::getLevelSaveName( %fileName );

   // No file, we canceled or something went wrong, abort.
   if( %fileName $= "" )
      return;
        
   if( ToolManager.getActiveTool() == LevelEditorTileMapEditTool.getId() )
      LevelEditorTileMapEditTool.resetAutoPanSettings();
      
   %layerObject = $tileEditor::layerToSave;
      
   %layerObject.saveTileLayer( %fileName );
   %layerObject.onLayerSaved();
   %layerObject.loadTileLayer( %fileName );
   
      
   if( ToolManager.getActiveTool() == LevelEditorTileMapEditTool.getId() )
      LevelEditorTileMapEditTool.setAutoPanSettings();
      
   if( $tileEditor::postSaveCallback !$= "" )
      eval( $tileEditor::postSaveCallback );
}

function TileBuilder::sizeObjectToLayer()
{
   %objects = ToolManager.getAcquiredObjects();
   if( %objects.getCount() != 1 )
      return;
      
   %layer = %objects.getObject( 0 );
   if( %layer.getClassName() !$= "t2dTileLayer" )
      return;
   
   %undo = new UndoScriptAction()
   {
      class = UndoLayerResize;
      layer = %layer;
      oldSize = %layer.getSize();
      oldPosition = %layer.getPosition();
   };
   
   %xSize = %layer.getTileCountX() * %layer.getTileSizeX();
   %ySize = %layer.getTileCountY() * %layer.getTileSizeY();
   
   %upperLeft = %layer.getAreaMin();
   %lowerRight = t2dVectorAdd( %upperLeft, %xSize SPC %ySize );
   
   %layer.setArea( %upperLeft, %lowerRight );
   %layer.setPosition( %layer.getPosition() );
   ToolManager.onObjectSpatialChanged( %layer );
   
   %undo.newSize = %layer.getSize();
   %undo.newPosition = %layer.getPosition();
   %undo.addToManager(LevelBuilderUndoManager);
}

function UndoLayerResize::undo( %this )
{
   %this.layer.setSize( %this.oldSize );
   %this.layer.setPosition( %this.oldPosition );
   ToolManager.onObjectSpatialChanged( %this.layer );
}

function UndoLayerResize::redo( %this )
{
   %this.layer.setSize( %this.newSize );
   %this.layer.setPosition( %this.newPosition );
   ToolManager.onObjectSpatialChanged( %this.layer );
}

function LevelEditorTileMapEditTool::onActivate(%this)
{
   $TileEditor::QuickEditPane.refresh();
}

function LevelEditorTileMapEditTool::onDeactivate(%this)
{
   $TileEditor::QuickEditPane.schedule(0, refresh);
}

function hideFrameQuickEdit()
{
   %image = ActiveBrush.getImage();
   
   if (!isObject(%image))
      return true;
      
   if (%image.getClassName() !$= "t2dImageMapDatablock")
      return true;
      
   if (%image.getFrameCount() < 2)
      return true;
      
   return false;
}

function LevelEditorTileMapEditTool::onTilePicked(%this, %layer, %tile)
{
   %tileType = %layer.getTileType(%tile);
   ActiveBrush.setImage(getWord(%tileType, 1));
   if (getWord(%tileType, 0) $= "static")
      ActiveBrush.setFrame(getWord(%tileType, 2));
   
   %flipX = getWord( %layer.getTileFlip( %tile ), 0 );
   %flipY = getWord( %layer.getTileFlip( %tile ), 1 );
   
   ActiveBrush.setTileScript(%layer.getTileScript(%tile));
   ActiveBrush.setCustomData(%layer.getTileCustomData(%tile));
   ActiveBrush.setFlipX( %flipX );
   ActiveBrush.setFlipY( %flipY );
   %collision = %layer.getTileCollision(%tile);
   %collisionActive = getWord(%collision, 0);
   ActiveBrush.setCollision(%collisionActive);
   
   
   if( %collisionActive && ( getWordCount(%collision) > 4 ) )
   {
      %poly = getWords( %collision, 4, getWordCount( %collision ) - 1 );
      %count = getWordCount( %poly );
      %newPoly = "";
      for( %i = 0; %i < %count - 1; %i += 2 )
      {
         %x = getWord( %poly, %i );
         %y = getWord( %poly, %i + 1 );
         if( %flipX )
            %x = -%x;
         if( %flipY )
            %y = -%y;
         
         %newPoly = %newPoly SPC %x SPC %y;
      }
      
      ActiveBrush.setCollisionPoly( trim( %newPoly ) );
   }
      
   LevelEditorTileMapEditTool.paintTool.performClick();
         
   $TileEditor::QuickEditPane.refresh();
}

function TileBuilder::editSelectedTileLayer()
{
   if (isObject(ToolManager))
   {
      if (ToolManager.getAcquiredObjectCount() > 0)
      {
         %layer = ToolManager.getAcquiredObjects().getObject(0);
         if (%layer.getClassName() $= "t2dTileLayer")
            ToolManager.editTileLayer(%layer);
      }
   }
}

function LBQETileLayerClass::refresh(%this)
{
   %this.hiddenStack1.updateFields();
   %this.hiddenStack2.updateFields();
   %this.brushesRollout.syncQuickEdit(ActiveBrush);
}

function TileEditSet::addText(%this, %text)
{
   %count = %this.getCount();
   for (%i = 0; %i < %count; %i++)
   {
      %object = %this.getObject(%i);
      if (%object.text $= %text)
         return;
   }
   
   %so = new ScriptObject()
   {
      displayName = %text;
      text = %text;
   };
   
   %this.add(%so);
}

function TileBrush::apply(%this)
{
   LevelEditorTileMapEditTool.applyToSelection();
}

function TileBrush::save(%this, %name)
{
   %name = validateDatablockName(%name);
   %brush = %name;
   if (!isObject(%name))
   {
      %brush = new ScriptObject(%name)
      {
         class = TileBrush;
         displayName = %name;
      };
   }
   
   %brush.copy(%this);
   LBProjectObj.addBrush(%brush, true);
   %this.setBrush(%brush.getName());
   $TileEditor::QuickEditPane.refresh();
}

function ActiveBrush::deleteBrush(%this)
{
   %brush = %this.getBrush();
   if (isObject(%brush))
   {
      LBProjectObj.removeBrush(%brush, true);
      %brush.delete();
      %this.setBrush(" ");
   }
}

function TileBrush::copy(%this, %tileBrush)
{
   %this.setImage(%tileBrush.getImage());
   %this.setFrame(%tileBrush.getFrame());
   %this.setTileScript(%tileBrush.getTileScript());
   %this.setCustomData(%tileBrush.getCustomData());
   %this.setFlipX(%tileBrush.getFlipX());
   %this.setFlipY(%tileBrush.getFlipY());
   %this.setCollision(%tileBrush.getCollision());
   %this.setCollisionPoly(%tileBrush.getCollisionPoly());
}

function ActiveBrush::getTileSize()
{
   return LevelEditorTileMapEditTool.getTileSize();
}

function ActiveBrush::setBrush(%this, %brush)
{
   if ((%brush !$= " ") && (%brush !$= "") && (%brush !$= "None"))
      %this.copy(%brush);
   else
   {
      %this.setImage("No Change");
      %this.setFrame(0);
      %this.setTileScript("None");
      %this.setCustomData("None");
      %this.setFlipX("-1");
      %this.setFlipY("-1");
      %this.setCollision("-1");
      %this.setCollisionPoly("");
   }
      
   %this.brush = %brush;
   
   if (isObject($TileEditor::QuickEditPane))
      $TileEditor::QuickEditPane.refresh();
}

function ActiveBrush::getBrush(%this)
{
   return %this.brush;
}

function ActiveBrush::setImage(%this, %image)
{
   if (%image $= "None")
      %image = "";
   else if (%image $= "No Change")
      %image = "-";
   
   Parent::setImage(%this, %image);
   LevelEditorTileMapEditTool.setImage(%image);
   
   if( isObject( $TileEditor::QuickEditPane ) )
      $TileEditor::QuickEditPane.refresh();
}

function TileBrush::setImage(%this, %image)
{
   %this.setFrame(0);
   %this.image = %image;
}

function TileBrush::getImage(%this)
{
   if (%this.image $= "-")
      return "No Change";
   else if (%this.image $= "")
      return "None";
      
   return %this.image;
}

function TileBrush::getImageMap( %this )
{
   if( isObject( %this.image ) && ( %this.image.getClassName() $= "t2dImageMapDatablock" ) )
      return %this.image;
   
   return 0;
}

function TileBrush::getAnimation( %this )
{
   if( isObject( %this.image ) && ( %this.image.getClassName() $= "t2dAnimationDatablock" ) )
      return %this.image;
   
   return 0;
}

function ActiveBrush::setFrame(%this, %frame)
{
   if (!isObject(%this.getImageMap()))
   {
      Parent::setFrame(%this, %frame);
      return;
   }

   %frames = %this.getImage().getFrameCount();
   if (%this.frame >= %this.getImage().getFrameCount())
      %this.frame = %this.getImage().getFrameCount() - 1;
   else if (%this.frame < 0)
      %this.frame = 0;
   
   Parent::setFrame(%this, %frame);
   LevelEditorTileMapEditTool.setFrame(%frame);
   $TileEditor::QuickEditPane.refresh();
}

function TileBrush::setFrame(%this, %frame)
{
   %this.frame = %frame;
}

function TileBrush::getFrame(%this, %frame)
{
   if (isObject(%this.getImage()) && (%this.getImage().getClassName() $= "t2dImageMapDatablock"))
   {
      if (%this.frame >= %this.getImage().getFrameCount())
         %this.frame = 0;
   }
   
   return %this.frame;
}

function ActiveBrush::setTileScript(%this, %script)
{
   if (%script $= "NONE")
      %script = "";
   else if (%script $= "NO CHANGE")
      %script = "-";
   
   Parent::setTileScript(%this, %script);
   LevelEditorTileMapEditTool.setTileScript(%script);
}

function TileBrush::setTileScript(%this, %script)
{
   %this.script = %script;
}

function TileBrush::getTileScript(%this)
{
   if (%this.script $= "")
      return "None";
   else if (%this.script $= "-")
      return "No Change";
      
   return %this.script;
}

function ActiveBrush::setCustomData(%this, %data)
{
   if (%data $= "None")
      %data = "";
   else if (%data $= "No Change")
      %data = "-";
   
   Parent::setCustomData(%this, %data);
   LevelEditorTileMapEditTool.setCustomData(%data);
}

function TileBrush::setCustomData(%this, %data)
{
   %this.customData = %data;
}

function TileBrush::getCustomData(%this)
{
   if (%this.customData $= "")
      return "None";
   else if (%this.customData $= "-")
      return "No Change";
      
   return %this.customData;
}

function ActiveBrush::setFlipX(%this, %flip)
{
   Parent::setFlipX(%this, %flip);
   LevelEditorTileMapEditTool.setFlipX(%flip);
   
   if( isObject( $TileEditor::QuickEditPane ) )
      $TileEditor::QuickEditPane.refresh();
}

function TileBrush::setFlipX(%this, %flip)
{
   %this.flipX = %flip;
}

function TileBrush::getFlipX(%this)
{
   return %this.flipX;
}

function ActiveBrush::setFlipY(%this, %flip)
{
   Parent::setFlipY(%this, %flip);
   LevelEditorTileMapEditTool.setFlipY(%flip);
   
   if( isObject( $TileEditor::QuickEditPane ) )
      $TileEditor::QuickEditPane.refresh();
}

function TileBrush::setFlipY(%this, %flip)
{
   %this.flipY = %flip;
}

function TileBrush::getFlipY(%this)
{
   return %this.flipY;
}

function ActiveBrush::setCollision(%this, %enabled)
{
   Parent::setCollision(%this, %enabled);
   LevelEditorTileMapEditTool.setCollision(%enabled);
   
   if( isObject( $TileEditor::QuickEditPane ) )
      $TileEditor::QuickEditPane.refresh();
}

function TileBrush::setCollision(%this, %enabled)
{
   %this.collision = %enabled;
}

function TileBrush::getCollision(%this)
{
   return %this.collision;
}

function ActiveBrush::setCollisionPoly(%this, %poly)
{
   Parent::setCollisionPoly(%this, %poly);
   LevelEditorTileMapEditTool.setCollisionPoly(getWordCount(%poly) / 2, %poly);
   
   if( isObject( $TileEditor::QuickEditPane ) )
      $TileEditor::QuickEditPane.refresh();
}

function TileBrush::findPolyPoint(%this, %x, %y)
{
   if (%this.getFlipX() == 1)
      %x = -%x;
   if (%this.getFlipY() == 1)
      %y = -%y;
   
   %poly = %this.getCollisionPoly();
   %count = getWordCount(%poly);
   for (%i = 0; %i < %count; %i += 2)
   {
      %polyX = getWord(%poly, %i);
      %polyY = getWord(%poly, %i + 1);
      if (mAbs(%x - %polyX) < 0.1)
      {
         if (mAbs(%y - %polyY) < 0.1)
            return %i;
      }
   }
   
   return -1;
}

function TileBrush::addPolyPoint(%this, %x, %y)
{
   if (%this.getFlipX() == 1)
      %x = -%x;
   if (%this.getFlipY() == 1)
      %y = -%y;
   
   %poly = %this.getCollisionPoly();
   %count = getWordCount(%poly);
   
   %newPoly = trim(%x SPC %y SPC %poly);
   if (LevelEditorPolyTool.checkConvexPoly(%newPoly))
   {
      %this.setCollisionPoly(%newPoly);
      return 0;
   }

   for (%i = 2; %i < %count; %i += 2)
   {
      %first = getWords(%poly, 0, %i - 1);
      %last = getWords(%poly, %i, %count - 1);
      %newPoly = trim(%first SPC %x SPC %y SPC %last);
      if (LevelEditorPolyTool.checkConvexPoly(%newPoly))
      {
         %this.setCollisionPoly(%newPoly);
         return %i;
      }
   }
   
   return -1;
}

function TileBrush::movePolyPoint(%this, %point, %x, %y)
{
   if (%this.getFlipX() == 1)
      %x = -%x;
   if (%this.getFlipY() == 1)
      %y = -%y;
   
   %poly = %this.getCollisionPoly();
   
   %newPoly = setWord(%poly, %point, %x);
   %newPoly = setWord(%newPoly, %point + 1, %y);
   if (LevelEditorPolyTool.checkConvexPoly(%newPoly))
      %this.setCollisionPoly(%newPoly);
}

function TileBrush::removePolyPoint(%this, %x, %y)
{
   %poly = %this.getCollisionPoly();
   %index = %this.findPolyPoint(%x, %y);
   if (%index >= 0)
   {
      %poly = removeWord(%poly, %index);
      %poly = removeWord(%poly, %index);
      %this.setCollisionPoly(trim(%poly));
   }
}

function TileBrush::setCollisionPoly(%this, %poly)
{
   %this.collisionPoly = %poly;
}

function TileBrush::getCollisionPoly(%this)
{
   return %this.collisionPoly;
}
