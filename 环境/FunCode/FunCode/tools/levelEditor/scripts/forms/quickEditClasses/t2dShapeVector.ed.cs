//-----------------------------------------------------------------------------
// LevelBuilder Quick Edit t2dStaticSprite Class
// Copyright (C) GarageGames.com, Inc.
//-----------------------------------------------------------------------------

//-----------------------------------------------------------------------------
// Register Form Content.
//-----------------------------------------------------------------------------
GuiFormManager::AddFormContent( "LevelBuilderQuickEditClasses", "t2dShapeVector", "LBQEShapeVector::CreateContent", "LBQEShapeVector::SaveContent", 2 );

//-----------------------------------------------------------------------------
// Form Content Creation Function
//-----------------------------------------------------------------------------
function LBQEShapeVector::CreateContent( %contentCtrl, %quickEditObj )
{
   %base = %contentCtrl.createBaseStack("LBQEShapeVectorClass", %quickEditObj);
   %rollout = %base.createRolloutStack("���������", true);
   
   %rollout.createCommandButton("shapeVectorEditor.open(" @ %quickEditObj @ ");", "�༭�����");
   %rollout.createColorPicker("LineColor", "������ɫ", "������ɫ");
   %rollout.createCheckBox("FillMode", "�������", "", "", "", "", false);
   %rollout.createColorPicker("FillColor", "���ɫ", "���ɫ");
   %rollout.createCommandButton("shapeVectorEditor.open(" @ %quickEditObj @ "); shapeVectorEditor.saveHullAsCollisionPoly();", "ʹ��͹������Ϊ�������ײ");
   
   // Return Ref to Base.
   return %base;

}

//-----------------------------------------------------------------------------
// Form Content Save Function
//-----------------------------------------------------------------------------
function LBQEShapeVector::SaveContent( %contentCtrl )
{
   // Nothing.
}
