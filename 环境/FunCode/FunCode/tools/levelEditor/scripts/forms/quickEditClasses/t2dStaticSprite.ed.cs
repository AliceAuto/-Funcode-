//-----------------------------------------------------------------------------
// LevelBuilder Quick Edit t2dStaticSprite Class
// Copyright (C) GarageGames.com, Inc.
//-----------------------------------------------------------------------------

//-----------------------------------------------------------------------------
// Register Form Content.
//-----------------------------------------------------------------------------
GuiFormManager::AddFormContent( "LevelBuilderQuickEditClasses", "t2dStaticSprite", "LBQEStaticSprite::CreateContent", "LBQEStaticSprite::SaveContent", 2 );

//-----------------------------------------------------------------------------
// Form Content Creation Function
//-----------------------------------------------------------------------------
function LBQEStaticSprite::CreateContent( %contentCtrl, %quickEditObj )
{
   %base = %contentCtrl.createBaseStack("LBQEStaticSpriteClass", %quickEditObj);
   %rollout = %base.createRolloutStack("��̬����", true);
   %imageMapList = %rollout.createT2DDatablockList("ImageMap", "ͼƬ", "t2dImageMapDatablock", "�þ������ʾͼƬ");
   //%srcRectList = %rollout.createDropDownList("UseSourceRect", "ʹ����ͼ����", "","NO\tYES", "�Ƿ�ֻʹ�ø�ͼƬ�Ĳ�������.");
   //%srcRectValue = %rollout.createTextEdit("SpriteSourceRect", "TEXT", "��ͼ����", "�ĸ�ֵ - ͼƬ�����Ͻ�XY���꣬��ͼƬ�Ŀ��");
   %frameContainer = %rollout.createHideableStack(%base @ ".object.getImageMap().getFrameCount() < 2;");
   %frameContainer.addControlDependency(%imageMapList);
   %frameContainer.createLeftRightEdit("Frame", "0;", %base @ ".object.getImageMap().getFrameCount() - 1;", 1, "֡", "ͼƬ֡��");
   
   // Return Ref to Base.
   return %base;

}

//-----------------------------------------------------------------------------
// Form Content Save Function
//-----------------------------------------------------------------------------
function LBQEStaticSprite::SaveContent( %contentCtrl )
{
   // Nothing.
}
