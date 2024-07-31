//---------------------------------------------------------------------------------------------
// Torque Game Builder
// Copyright (C) GarageGames.com, Inc.
//---------------------------------------------------------------------------------------------

$Gui::clipboardFile = expandFilename("./clipboard.gui");

if (!isObject(GuiEditorClassProfile)) new GuiControlProfile (GuiEditorClassProfile)
{
   opaque = true;
   fillColor = "232 232 232";
   border = 1;
   borderColor   = "40 40 40 140";
   borderColorHL = "127 127 127";
   fontColor = "0 0 0";
   fontColorHL = "32 100 100";
   fixedExtent = true;
   justify = "center";
   bitmap = "common/gui/images/scrollBar";
   hasBitmapArray = true;
};

if (!isObject(GuiBackFillProfile)) new GuiControlProfile (GuiBackFillProfile)
{
   opaque = true;
   fillColor = "0 94 94";
   border = true;
   borderColor = "255 128 128";
   fontType = "Arial";
   fontSize = 12;
   fontColor = "0 0 0";
   fontColorHL = "32 100 100";
   fixedExtent = true;
   justify = "center";
};

if (!isObject(GuiControlListPopupProfile)) new GuiControlProfile (GuiControlListPopupProfile)
{
   opaque = true;
   fillColor = "255 255 255";
   fillColorHL = "128 128 128";
   border = true;
   borderColor = "0 0 0";
   fontColor = "0 0 0";
   fontColorHL = "255 255 255";
   fontColorNA = "128 128 128";
   textOffset = "0 2";
   autoSizeWidth = false;
   autoSizeHeight = true;
   tab = true;
   canKeyFocus = true;
   bitmap = "common/gui/images/scrollBar";
   hasBitmapArray = true;
};

if (!isObject(GuiSceneGraphEditProfile)) new GuiControlProfile(GuiSceneGraphEditProfile)
{
   canKeyFocus = true;
   tab = true;
};

if(!isObject(GuiInspectorTextEditProfile)) new GuiControlProfile ("GuiInspectorTextEditProfile")
{
   // Transparent Background
   opaque = true;
   fillColor = "0 0 0 0";
   fillColorHL = "255 255 255";

   // No Border (Rendered by field control)
   border = false;

   tab = true;
   canKeyFocus = true;

   // font
   fontType = "Arial";
   fontSize = 14;

   fontColor = "0 0 0";
   fontColorSEL = "43 107 206";
   fontColorHL = "244 244 244";
   fontColorNA = "100 100 100";
};


if (!isObject(GuiInspectorTextEditRightProfile)) new GuiControlProfile (GuiInspectorTextEditRightProfile : GuiInspectorTextEditProfile)
{
   justify = right;
};

if (!isObject(GuiInspectorGroupProfile)) new GuiControlProfile (GuiInspectorGroupProfile )
{
   fontType    = "Arial";
   fontSize    = "14";
   
   fontColor = "0 0 0 150";
   fontColorHL = "25 25 25 220";
   fontColorNA = "128 128 128";
   
   justify = "left";
   opaque = false;
   border = false;
  
   bitmap = "tools/editorclasses/gui/images/rollout";
   
   textOffset = "30 -2";

};

if (!isObject(GuiInspectorFieldProfile)) new GuiControlProfile (GuiInspectorFieldProfile)
{
   // fill color
   opaque = false;
   fillColor = "255 255 255";
   fillColorHL = "128 128 128";
   fillColorNA = "244 244 244";

   // border color
   border = false;
   borderColor   = "190 190 190";
   borderColorHL = "156 156 156";
   borderColorNA = "64 64 64";
   
   bevelColorHL = "255 255 255";
   bevelColorLL = "0 0 0";

   // font
   fontType = "Arial";
   fontSize = 14;

   fontColor = "32 32 32";
   fontColorHL = "32 100 100";
   fontColorNA = "0 0 0";

   tab = true;
   canKeyFocus = true;
};

if (!isObject(GuiInspectorBackgroundProfile)) new GuiControlProfile (GuiInspectorBackgroundProfile : GuiInspectorFieldProfile)
{
   border = 5;
   cankeyfocus=true;
   tab = true;
};

if (!isObject(GuiInspectorTypeFileNameProfile)) new GuiControlProfile (GuiInspectorTypeFileNameProfile)
{
   // Transparent Background
   opaque = false;

   // No Border (Rendered by field control)
   border = 5;

   tab = true;
   canKeyFocus = true;

   // font
   fontType = "Arial";
   fontSize = 14;
   
   // Center text
   justify = "center";

   fontColor = "32 32 32";
   fontColorHL = "32 100 100";
   fontColorNA = "0 0 0";

   fillColor = "255 255 255";
   fillColorHL = "128 128 128";
   fillColorNA = "244 244 244";

   borderColor   = "190 190 190";
   borderColorHL = "156 156 156";
   borderColorNA = "64 64 64";
};

if (!isObject(InspectorTypeEnumProfile)) new GuiControlProfile (InspectorTypeEnumProfile : GuiInspectorFieldProfile)
{
   mouseOverSelected = true;
   bitmap = "common/gui/images/scrollBar";
   hasBitmapArray = true;
   opaque=true;
   border=true;
   textOffset = "4 0";
};

if (!isObject(InspectorTypeCheckboxProfile)) new GuiControlProfile (InspectorTypeCheckboxProfile : GuiInspectorFieldProfile)
{
   bitmap = "common/gui/images/checkBox";
   hasBitmapArray = true;
   opaque=false;
   border=false;
};

if (!isObject(GuiToolboxButtonProfile)) new GuiControlProfile (GuiToolboxButtonProfile : GuiWindowProfile)
{
   justify = "center";
   fontColor = "0 0 0";
   border = 0;
   textOffset = "0 0";   
};

if (!isObject(T2DDatablockDropDownProfile)) new GuiControlProfile (T2DDatablockDropDownProfile : GuiPopUpMenuProfile);

if (!isObject(GuiDirectoryTreeProfile)) new GuiControlProfile (GuiDirectoryTreeProfile : GuiTreeViewProfile)
{
   fontColor = "40 40 40";
   fontColorSEL= "250 250 250 175"; 
   fillColorHL = "0 60 150";
   fontColorNA = "240 240 240";
   fontType = "Arial";
   fontSize = 14;
};

if (!isObject(GuiDirectoryFileListProfile)) new GuiControlProfile (GuiDirectoryFileListProfile)
{
   fontColor = "40 40 40";
   fontColorSEL= "250 250 250 175"; 
   fillColorHL = "0 60 150";
   fontColorNA = "240 240 240";
   fontType = "Arial";
   fontSize = 14;
};

if (!isObject(GuiDragAndDropProfile)) new GuiControlProfile(GuiDragAndDropProfile)
{
};
