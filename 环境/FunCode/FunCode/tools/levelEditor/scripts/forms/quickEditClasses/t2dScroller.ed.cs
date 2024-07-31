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
   %rollout = %base.createRolloutStack("滚动图", true);
   %rollout.createT2DDatablockList("ImageMap", "图片", "t2dImageMapDatablock", "该精灵的显示图片");
   //%srcRectList = %rollout.createDropDownList("UseSourceRect", "使用贴图区域", "","NO\tYES", "是否只使用该图片的部分区域.");
   //%srcRectValue = %rollout.createTextEdit("SpriteSourceRect", "TEXT", "贴图区域", "四个值 - 图片的左上角XY坐标，和图片的宽高");
   %rollout.createTextEdit2("RepeatX", "RepeatY", 3, "重复", "X", "Y", "图片的重复次数");
   %rollout.createTextEdit2("ScrollX", "ScrollY", 3, "滚动速度", "X", "Y", "图片的滚动速度");
   //%rollout.createTextEdit2("ScrollPositionX", "ScrollPositionY", 3, "滚动坐标", "X", "Y", "图片的滚动坐标");
   
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
