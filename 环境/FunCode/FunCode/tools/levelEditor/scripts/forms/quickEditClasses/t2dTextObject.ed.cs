//-----------------------------------------------------------------------------
// LevelBuilder Quick Edit t2dStaticSprite Class
// Copyright (C) GarageGames.com, Inc.
//-----------------------------------------------------------------------------

//-----------------------------------------------------------------------------
// Register Form Content.
//-----------------------------------------------------------------------------
GuiFormManager::AddFormContent( "LevelBuilderQuickEditClasses", "t2dTextObject", "LBQETextObject::CreateContent", "LBQETextObject::SaveContent", 2 );

//-----------------------------------------------------------------------------
// Form Content Creation Function
//-----------------------------------------------------------------------------
function LBQETextObject::CreateContent( %contentCtrl, %quickEditObj )
{
   %base = %contentCtrl.createBaseStack("LBQETextObjectClass", %quickEditObj);
   %rollout = %base.createRolloutStack("���־���", true);
   
   %fonts = enumerateFonts();
   %rollout.createListBox( "font", true, "����", %fonts );
   
   %rollout.createListBox("textAlign", true, "���뷽ʽ", "Left\tRight\tCenter\tJustify", "", false);
   %rollout.createTextEditProperty("lineHeight", "3", "���ָ߶�", "", true);
   %rollout.createTextEditProperty("lineSpacing", "3", "�߶μ��", "");
   %rollout.createTextEditProperty("characterSpacing", "3", "���ּ��", "");
   %rollout.createTextEditProperty("aspectRatio", "3", "ˮƽ����", "", true);
   %rollout.createCheckBox("wordWrap", "������ģʽ", "", "", "", "", true);
   %rollout.createCheckBox("hideOverflow", "���س����߽��", "", "", "", "", true);
   %rollout.createCheckBox("bilinearFilter", "˫���Թ���", "�������߹ر�˫���Թ��˲�ֵ", "", "", "", true);
   %rollout.createCheckBox("snapToIntegerPos", "����������С", "����������С����������ְ�����ش�С", "", "", "", true);
   //%rollout.createCheckBox("noUnicode", "��Unicode(�����ĵ�)", "����������unicode�ַ�", "", "", "", true);
   
   // Return Ref to Base.
   return %base;

}

//-----------------------------------------------------------------------------
// Form Content Save Function
//-----------------------------------------------------------------------------
function LBQETextObject::SaveContent( %contentCtrl )
{
   // Nothing.
}
