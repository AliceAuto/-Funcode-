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
   %rollout = %base.createRolloutStack("ƽ��ͼ", true);
   %rollout.createTextEdit2("autoPanX", "autoPanY", 3, "�Զ�ƽ��", "X", "Y", "�Զ�ƽ��", true);
   %rollout.createTextEdit2("panPositionX", "panPositionY", 3, "ƽ������", "X", "Y", "ƽ������", true);
   %rollout.createCheckBox("wrapX", "��� X");
   %rollout.createCheckBox("wrapY", "��� Y");
   %rollout.createTextEdit2("tileCountXAndWarn", "tileCountYAndWarn", 0, "ƽ������", "X", "Y", "ƽ������");
   %rollout.createTextEdit2("tileSizeX", "tileSizeY", 0, "ƽ�̴�С", "X", "Y", "ƽ�̴�С");
   %rollout.createCommandButton("TileBuilder::sizeObjectToLayer();", "�����С��㼶һ��");
   %rollout.createSpacer( 16 );
   
   %hiddenTest = "ToolManager.getActiveTool().getId() == LevelEditorTileMapEditTool.getId();";
   %hidden = %rollout.createHideableStack(%hiddenTest);
   %hidden.createCommandButton("TileBuilder::editSelectedTileLayer();", "�༭ƽ�̲㼶");
   
   %hiddenBrushesTest = "ToolManager.getActiveTool().getId() != LevelEditorTileMapEditTool.getId();";
   %hiddenBrushes = %rollout.createHideableStack(%hiddenBrushesTest);
   %brushRollout = %hiddenBrushes.createBrushStack("ƽ��ͼ�༭", true);
   
   // Create Layer Persistence Buttons
   %brushRollout.createLayerPersistence();
   
   %toolbar = %brushRollout.createToolbar();
   %toolbar.addSpacer();
   %toolbar.addTool("ѡ��", "LevelEditorTileMapEditTool.setSelectTool();", "^tools/tileLayerEditor/selectTool");
   LevelEditorTileMapEditTool.paintTool = %toolbar.addTool("��Ϳ", "LevelEditorTileMapEditTool.setPaintTool();", "^tools/tileLayerEditor/paintTool");
   %toolbar.addTool("�����", "LevelEditorTileMapEditTool.setFloodTool();", "^tools/tileLayerEditor/floodTool");
   %toolbar.addTool("��ȡͼƬ", "LevelEditorTileMapEditTool.setEyeTool();", "^tools/tileLayerEditor/eyeTool");
   %toolbar.addTool("��Ƥ��", "LevelEditorTileMapEditTool.setEraserTool();", "^tools/tileLayerEditor/eraserTool");
   %toolbar.addSpacer();
   
   LevelEditorTileMapEditTool.paintTool.performClick();
   
   %brushRollout.createDropDownList("brush", "��ˢ", $brushSet, "BLANK", "", false);
   %brushRollout.createT2DDatablockList("image", "ͼƬ", "t2dImageMapDatablock t2dAnimationDatablock", "", "No Change\tNone", false);
   
   %frameStack = %brushRollout.createHideableStack("hideFrameQuickEdit();");
   %frameStack.createT2DFramePicker( "frame", "֡��", "", false );
   
   %brushRollout.createDropDownEditList("tileScript", "ƽ��ͼ�ű�", $tileScriptSet, "", "", false);
   %brushRollout.createDropDownEditList("customData", "�Զ�������", $customDataSet, "", "", false);
   %brushRollout.createCheckBox("flipX", "ˮƽ��ת", "", "", true, false);
   %brushRollout.createCheckBox("flipY", "��ֱ��ת", "", "", true, false);
   %brushRollout.createCheckBox("collision", "������ײ", "", "", true, false);
   %brushRollout.createSpacer(6);
   %brushRollout.createBrushPreview();
   %brushRollout.createSpacer(16);
   %brushRollout.createCommandButton("ActiveBrush.apply();", "Ӧ����ѡ���ͼ��");
   %brushRollout.createSpacer(16);
   %brushRollout.createTextCommandButton("ActiveBrush.save", "�����ˢ", "ActiveBrush.getBrush();");
   %brushRollout.createCommandButton("ActiveBrush.deleteBrush();", "ɾ����ˢ", "", 148, 78);
   
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
      MessageBoxOKCancel("����", "����ƽ��������ɾ���㼶�߽����ƽ��ͼ���˲��������棬����?",
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
      MessageBoxOKCancel("����", "����ƽ��������ɾ���㼶�߽����ƽ��ͼ���˲��������棬����?",
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
