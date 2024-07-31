//-----------------------------------------------------------------------------
// LevelBuilder Quick Edit t2dStaticSprite Class
// Copyright (C) GarageGames.com, Inc.
//-----------------------------------------------------------------------------

//-----------------------------------------------------------------------------
// Register Form Content.
//-----------------------------------------------------------------------------
GuiFormManager::AddFormContent( "LevelBuilderQuickEditClasses", "t2dScroller", "LBQEScroller::CreateContent", "LBQEScroller::SaveContent", 2 );

//-----------------------------------------------------------------------------
// Form Content Creation Function
//-----------------------------------------------------------------------------
function LBQEScroller::CreateContent( %contentCtrl, %quickEditObj )
{
   %base = %contentCtrl.createBaseStack("LBQEScrollerClass", %quickEditObj);
   %rollout = %base.createRolloutStack("����ͼ", true);
   %rollout.createT2DDatablockList("ImageMap", "ͼƬ", "t2dImageMapDatablock", "�þ������ʾͼƬ");
   //%srcRectList = %rollout.createDropDownList("UseSourceRect", "ʹ����ͼ����", "","NO\tYES", "�Ƿ�ֻʹ�ø�ͼƬ�Ĳ�������.");
   //%srcRectValue = %rollout.createTextEdit("SpriteSourceRect", "TEXT", "��ͼ����", "�ĸ�ֵ - ͼƬ�����Ͻ�XY���꣬��ͼƬ�Ŀ��");
   %rollout.createTextEdit2("RepeatX", "RepeatY", 3, "�ظ�", "X", "Y", "ͼƬ���ظ�����");
   %rollout.createTextEdit2("ScrollX", "ScrollY", 3, "�����ٶ�", "X", "Y", "ͼƬ�Ĺ����ٶ�");
   //%rollout.createTextEdit2("ScrollPositionX", "ScrollPositionY", 3, "��������", "X", "Y", "ͼƬ�Ĺ�������");
   
   // Return Ref to Base.
   return %base;

}

//-----------------------------------------------------------------------------
// Form Content Save Function
//-----------------------------------------------------------------------------
function LBQEScroller::SaveContent( %contentCtrl )
{
   // Nothing.
}
