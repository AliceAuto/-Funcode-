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
   %rollout = %base.createRolloutStack("多边形向量", true);
   
   %rollout.createCommandButton("shapeVectorEditor.open(" @ %quickEditObj @ ");", "编辑多边形");
   %rollout.createColorPicker("LineColor", "线条颜色", "线条颜色");
   %rollout.createCheckBox("FillMode", "填充多边形", "", "", "", "", false);
   %rollout.createColorPicker("FillColor", "填充色", "填充色");
   %rollout.createCommandButton("shapeVectorEditor.open(" @ %quickEditObj @ "); shapeVectorEditor.saveHullAsCollisionPoly();", "使用凸面体作为多边形碰撞");
   
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
