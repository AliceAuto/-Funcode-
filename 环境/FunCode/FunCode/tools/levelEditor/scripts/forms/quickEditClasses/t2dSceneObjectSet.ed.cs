//-----------------------------------------------------------------------------
// LevelBuilder Quick Edit t2dSceneObject Class
// Copyright (C) GarageGames.com, Inc.
//-----------------------------------------------------------------------------

//-----------------------------------------------------------------------------
// Register Form Content.
//-----------------------------------------------------------------------------
GuiFormManager::AddFormContent( "LevelBuilderQuickEditClasses", "t2dSceneObjectSet", "LBQESceneObjectSet::CreateContent", "LBQESceneObjectSet::SaveContent", 2 );

//-----------------------------------------------------------------------------
// Form Content Creation Function
//-----------------------------------------------------------------------------
function LBQESceneObjectSet::CreateContent( %contentCtrl, %quickEditObj )
{
   %base = %contentCtrl.createBaseStack("LBQESceneObjectClass", %quickEditObj);
   
   %sceneObjectRollout = %base.createRolloutStack("选中的精灵集", true);
   %sceneObjectRollout.createTextEdit2("PositionX", "PositionY", 3, "坐标", "X", "Y", "整体中心的坐标", true);
   %sceneObjectRollout.createTextEdit2("Width", "Height", 3, "大小", "宽", "高", "大小", true);
   %sceneObjectRollout.createTextEdit ("rotation", 3, "朝向", "整体的朝向", true);
   %sceneObjectRollout.createCheckBox ("FlipX", "水平翻转", "水平翻转", true);
   %sceneObjectRollout.createCheckBox ("FlipY", "垂直翻转", "垂直翻转", true);
   %sceneObjectRollout.createLeftRightEdit("Layer", "0;", "31;", 1, "层", "显示的层级");
   //%sceneObjectRollout.createLeftRightEdit("GraphGroup", "0;", "31;", 1, "Group", "Graph Group");
   
   //%alignRollout = %base.createRolloutStack( "Align", true );
   //%alignRollout.createAlignTools( false );
   
   // Return Ref to Base.
   return %base;
}

//-----------------------------------------------------------------------------
// Form Content Save Function
//-----------------------------------------------------------------------------
function LBQESceneObjectSet::SaveContent( %contentCtrl )
{
   // Nothing.
}
