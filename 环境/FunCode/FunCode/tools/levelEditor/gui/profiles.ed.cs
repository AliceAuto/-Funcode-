if(!isObject(LVLSceneWindowProfile)) new GuiControlProfile (LVLSceneWindowProfile : EditorFontHL )
{
   tab = true;
   canKeyFocus = true;
   hasBitmapArray = false;
   mouseOverSelected = false;

   // fill color
   opaque = false;
   fillColor = ($platform $= "macos") ? "211 211 211" : "192 192 192";
   fillColorHL = ($platform $= "macos") ? "244 244 244" : "220 220 220";
   fillColorNA = ($platform $= "macos") ? "244 244 244" : "220 220 220";

   // border color
   border = 0;
   borderColor   = "40 40 40 100";
   borderColorHL = "128 128 128";
   borderColorNA = "64 64 64";

   // bitmap information
   bitmap = ($platform $= "macos") ? "common/ui/osxWindow" : "common/ui/darkWindow";
   bitmapBase = "";
   textOffset = "0 0";

   // used by guiTextControl
   modal = true;
   justify = "left";
   autoSizeWidth = false;
   autoSizeHeight = false;
   returnTab = false;
   numbersOnly = false;
   cursorColor = "0 0 0 255";

   // sounds
   soundButtonDown = "";
   soundButtonOver = "";
};


//-----------------------------------------------------------------------------
// Object Library Profiles
//-----------------------------------------------------------------------------
if(!isObject(ObjectBrowserThumbProfileMedium)) new GuiControlProfile (ObjectBrowserThumbProfileMedium : EditorButton)
{
   bitmap = expandFilename("./images/objectLibraryThumb");
   fontType    = "Arial Bold";
   fontSize    = "20";
   fontColor = "255 255 255";  
};

if(!isObject(ObjectBrowserThumbProfileDark)) new GuiControlProfile (ObjectBrowserThumbProfileDark : EditorButton)
{
   bitmap = expandFilename("./images/objectLibraryThumbDark");
   fontType    = "Arial Bold";
   fontSize    = "20";
   fontColor = "255 255 255";  
};

if(!isObject(ObjectBrowserThumbProfileLight)) new GuiControlProfile (ObjectBrowserThumbProfileLight : EditorButton)
{
   bitmap = expandFilename("./images/objectLibraryThumbLight");
   fontType    = "Arial Bold";
   fontSize    = "20";
   fontColor = "255 255 255";  
};


// Controls Widget Border Appearance
if(!isObject(LBSceneWindow)) new GuiControlProfile(LBSceneWindow : EditorButton)
{
   canKeyFocus = true;
   tab         = true;
   
};

$LevelBuilder::GuiPath = filePath(expandFilename("./profiles.cs"));