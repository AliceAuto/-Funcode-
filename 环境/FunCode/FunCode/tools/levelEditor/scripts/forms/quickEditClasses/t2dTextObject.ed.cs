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
   %rollout = %base.createRolloutStack("文字精灵", true);
   
   %fonts = enumerateFonts();
   %rollout.createListBox( "font", true, "字体", %fonts );
   
   %rollout.createListBox("textAlign", true, "对齐方式", "Left\tRight\tCenter\tJustify", "", false);
   %rollout.createTextEditProperty("lineHeight", "3", "文字高度", "", true);
   %rollout.createTextEditProperty("lineSpacing", "3", "线段间隔", "");
   %rollout.createTextEditProperty("characterSpacing", "3", "文字间隔", "");
   %rollout.createTextEditProperty("aspectRatio", "3", "水平缩放", "", true);
   %rollout.createCheckBox("wordWrap", "字体卷盖模式", "", "", "", "", true);
   %rollout.createCheckBox("hideOverflow", "隐藏超出边界的", "", "", "", "", true);
   %rollout.createCheckBox("bilinearFilter", "双线性过滤", "开启或者关闭双线性过滤插值", "", "", "", true);
   %rollout.createCheckBox("snapToIntegerPos", "对齐整数大小", "对齐整数大小，不允许出现半个像素大小", "", "", "", true);
   //%rollout.createCheckBox("noUnicode", "非Unicode(如中文等)", "不允许输入unicode字符", "", "", "", true);
   
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
