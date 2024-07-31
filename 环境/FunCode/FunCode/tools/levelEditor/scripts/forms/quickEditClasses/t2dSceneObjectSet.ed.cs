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
   
   %sceneObjectRollout = %base.createRolloutStack("ѡ�еľ��鼯", true);
   %sceneObjectRollout.createTextEdit2("PositionX", "PositionY", 3, "����", "X", "Y", "�������ĵ�����", true);
   %sceneObjectRollout.createTextEdit2("Width", "Height", 3, "��С", "��", "��", "��С", true);
   %sceneObjectRollout.createTextEdit ("rotation", 3, "����", "����ĳ���", true);
   %sceneObjectRollout.createCheckBox ("FlipX", "ˮƽ��ת", "ˮƽ��ת", true);
   %sceneObjectRollout.createCheckBox ("FlipY", "��ֱ��ת", "��ֱ��ת", true);
   %sceneObjectRollout.createLeftRightEdit("Layer", "0;", "31;", 1, "��", "��ʾ�Ĳ㼶");
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
