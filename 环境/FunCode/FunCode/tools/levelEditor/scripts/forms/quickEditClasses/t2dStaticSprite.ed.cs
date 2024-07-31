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
   %rollout = %base.createRolloutStack("静态精灵", true);
   %imageMapList = %rollout.createT2DDatablockList("ImageMap", "图片", "t2dImageMapDatablock", "该精灵的显示图片");
   //%srcRectList = %rollout.createDropDownList("UseSourceRect", "使用贴图区域", "","NO\tYES", "是否只使用该图片的部分区域.");
   //%srcRectValue = %rollout.createTextEdit("SpriteSourceRect", "TEXT", "贴图区域", "四个值 - 图片的左上角XY坐标，和图片的宽高");
   %frameContainer = %rollout.createHideableStack(%base @ ".object.getImageMap().getFrameCount() < 2;");
   %frameContainer.addControlDependency(%imageMapList);
   %frameContainer.createLeftRightEdit("Frame", "0;", %base @ ".object.getImageMap().getFrameCount() - 1;", 1, "帧", "图片帧数");
   
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
