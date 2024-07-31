//-----------------------------------------------------------------------------
// LevelBuilder Quick Edit t2dTileLayer Class
// Copyright (C) GarageGames.com, Inc.
//-----------------------------------------------------------------------------

//-----------------------------------------------------------------------------
// Register Form Content.
//-----------------------------------------------------------------------------
GuiFormManager::AddFormContent( "LevelBuilderQuickEditClasses", "t2dTileLayer", "LBQETileLayer::CreateContent", "LBQETileLayer::SaveContent", 2 );

//-----------------------------------------------------------------------------
// Form Content Creation Function
//-----------------------------------------------------------------------------
function LBQETileLayer::CreateContent( %contentCtrl, %quickEditObj )
{
   %base = %contentCtrl.createBaseStack("LBQETileLayerClass", %quickEditObj);
   %rollout = %base.createRolloutStack("平铺图", true);
   %rollout.createTextEdit2("autoPanX", "autoPanY", 3, "自动平铺", "X", "Y", "自动平铺", true);
   %rollout.createTextEdit2("panPositionX", "panPositionY", 3, "平铺坐标", "X", "Y", "平铺坐标", true);
   %rollout.createCheckBox("wrapX", "卷盖 X");
   %rollout.createCheckBox("wrapY", "卷盖 Y");
   %rollout.createTextEdit2("tileCountXAndWarn", "tileCountYAndWarn", 0, "平铺数量", "X", "Y", "平铺数量");
   %rollout.createTextEdit2("tileSizeX", "tileSizeY", 0, "平铺大小", "X", "Y", "平铺大小");
   %rollout.createCommandButton("TileBuilder::sizeObjectToLayer();", "精灵大小与层级一致");
   %rollout.createSpacer( 16 );
   
   %hiddenTest = "ToolManager.getActiveTool().getId() == LevelEditorTileMapEditTool.getId();";
   %hidden = %rollout.createHideableStack(%hiddenTest);
   %hidden.createCommandButton("TileBuilder::editSelectedTileLayer();", "编辑平铺层级");
   
   %hiddenBrushesTest = "ToolManager.getActiveTool().getId() != LevelEditorTileMapEditTool.getId();";
   %hiddenBrushes = %rollout.createHideableStack(%hiddenBrushesTest);
   %brushRollout = %hiddenBrushes.createBrushStack("平铺图编辑", true);
   
   // Create Layer Persistence Buttons
   %brushRollout.createLayerPersistence();
   
   %toolbar = %brushRollout.createToolbar();
   %toolbar.addSpacer();
   %toolbar.addTool("选择", "LevelEditorTileMapEditTool.setSelectTool();", "^tools/tileLayerEditor/selectTool");
   LevelEditorTileMapEditTool.paintTool = %toolbar.addTool("喷涂", "LevelEditorTileMapEditTool.setPaintTool();", "^tools/tileLayerEditor/paintTool");
   %toolbar.addTool("填充满", "LevelEditorTileMapEditTool.setFloodTool();", "^tools/tileLayerEditor/floodTool");
   %toolbar.addTool("吸取图片", "LevelEditorTileMapEditTool.setEyeTool();", "^tools/tileLayerEditor/eyeTool");
   %toolbar.addTool("橡皮擦", "LevelEditorTileMapEditTool.setEraserTool();", "^tools/tileLayerEditor/eraserTool");
   %toolbar.addSpacer();
   
   LevelEditorTileMapEditTool.paintTool.performClick();
   
   %brushRollout.createDropDownList("brush", "笔刷", $brushSet, "BLANK", "", false);
   %brushRollout.createT2DDatablockList("image", "图片", "t2dImageMapDatablock t2dAnimationDatablock", "", "No Change\tNone", false);
   
   %frameStack = %brushRollout.createHideableStack("hideFrameQuickEdit();");
   %frameStack.createT2DFramePicker( "frame", "帧数", "", false );
   
   %brushRollout.createDropDownEditList("tileScript", "平铺图脚本", $tileScriptSet, "", "", false);
   %brushRollout.createDropDownEditList("customData", "自定义数据", $customDataSet, "", "", false);
   %brushRollout.createCheckBox("flipX", "水平翻转", "", "", true, false);
   %brushRollout.createCheckBox("flipY", "垂直翻转", "", "", true, false);
   %brushRollout.createCheckBox("collision", "开启碰撞", "", "", true, false);
   %brushRollout.createSpacer(6);
   %brushRollout.createBrushPreview();
   %brushRollout.createSpacer(16);
   %brushRollout.createCommandButton("ActiveBrush.apply();", "应用至选择的图块");
   %brushRollout.createSpacer(16);
   %brushRollout.createTextCommandButton("ActiveBrush.save", "保存笔刷", "ActiveBrush.getBrush();");
   %brushRollout.createCommandButton("ActiveBrush.deleteBrush();", "删除笔刷", "", 148, 78);
   
   // Return Ref to Base.
   %base.hiddenStack1 = %hidden;
   %base.hiddenStack2 = %hiddenBrushes;
   %base.brushesRollout = %brushRollout;
   $TileEditor::QuickEditPane = %base;
   return %base;
}

//-----------------------------------------------------------------------------
// Form Content Save Function
//-----------------------------------------------------------------------------
function LBQETileLayer::SaveContent( %contentCtrl )
{
   // Nothing.
}

$TileEditor::RequestedTileCountX = -1;
function t2dTileLayer::setTileCountXAndWarn(%this, %count)
{
   %currentCount = %this.getTileCountX();
   if (%count < %currentCount)
   {
      $TileEditor::RequestedTileCountX = %count;
      MessageBoxOKCancel("警告", "减少平铺数量将删除层级边界外的平铺图，此操作不可逆，继续?",
                         "doSetTileCountX(" @ %this @ ", " @ %count @ ");", "refreshTileCount();");
   }
   
   else
      doSetTileCountX(%this, %count);
}

function doSetTileCountX(%layer, %count)
{
   $TileEditor::RequestedTileCountX = -1;
   %layer.setTileCountX(%count);
}

function t2dTileLayer::getTileCountXAndWarn(%this)
{
   %count = $TileEditor::RequestedTileCountX;
   if (%count < 0)
      %count = %this.getTileCountX();
   return %count;
}

$TileEditor::RequestedTileCountY = -1;
function t2dTileLayer::setTileCountYAndWarn(%this, %count)
{
   %currentCount = %this.getTileCountY();
   if (%count < %currentCount)
   {
      $TileEditor::RequestedTileCountY = %count;
      MessageBoxOKCancel("警告", "减少平铺数量将删除层级边界外的平铺图，此操作不可逆，继续?",
                         "doSetTileCountY(" @ %this @ ", " @ %count @ ");", "refreshTileCount();");
   }
   
   else
      doSetTileCountY(%this, %count);
}

function doSetTileCountY(%layer, %count)
{
   $TileEditor::RequestedTileCountY = -1;
   %layer.setTileCountY(%count);
}

function t2dTileLayer::getTileCountYAndWarn(%this)
{
   %count = $TileEditor::RequestedTileCountY;
   if (%count < 0)
      %count = %this.getTileCountY();
      
   return %count;
}

function refreshTileCount()
{
   $TileEditor::RequestedTileCountY = -1;
   $TileEditor::RequestedTileCountX = -1;
   GuiFormManager::SendContentMessage( $LBQuickEdit, "", "inspectUpdate" );
}
