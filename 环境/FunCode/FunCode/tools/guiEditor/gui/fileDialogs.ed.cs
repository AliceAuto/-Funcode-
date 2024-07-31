//---------------------------------------------------------------------------------------------
// Torque Game Builder
// Copyright (C) GarageGames.com, Inc.
//---------------------------------------------------------------------------------------------

$GUI::FileSpec = "Torque Gui Files (*.gui)|*.gui|All Files (*.*)|*.*|";

/// GuiBuilder::getSaveName - Open a Native File dialog and retrieve the
///  location to save the current document.
/// @arg defaultFileName   The FileName to default in the field and to be selected when a path is opened
function GuiBuilder::getSaveName( %defaultFileName )
{
   // if we're editing a game, we want to default to the games dir.
   // if we're not, then we default to the tools directory or the base.
   if( %defaultFileName !$= "" && isScriptPathExpando("project"))
      %prefix = "^project";
   else if(isScriptPathExpando("game"))
      %prefix = "^game";
   else if( isScriptPathExpando("tools"))
      %prefix = "^tools";
   else
      %prefix = "";
      
   if( %defaultFileName $= "" )
      %defaultFileName = expandFilename(%prefix @ "/gui/untitled.gui");
   else 
      %defaultFileName = expandFilename(%prefix @ "/" @ %defaultFileName);
      
   %path = filePath(%defaultFileName) @ "/";
   %dlg = new SaveFileDialog()
   {
      Filters           = $GUI::FileSpec;
      DefaultPath       = %path;
      DefaultFile       = %defaultFileName;
      ChangePath        = false;
      OverwritePrompt   = true;
   };
         
   if(%dlg.Execute())
   {
      $Pref::GuiEditor::LastPath = filePath( %dlg.FileName );
      %filename = %dlg.FileName;
      
      // make sure we have a .gui extension
      if (fileExt(%dlg.FileName) !$= ".gui")
      {
         // strip the extension just in case
         %temp = fileBase(%dlg.FileName);
         %filename =  $Pref::GuiEditor::LastPath @ "/" @ %temp @ ".gui";
      }
   }
   else
      %filename = "";
      
   %dlg.delete();
   
   return %filename;
}

function GuiBuilder::getOpenName( %defaultFileName )
{
   if( %defaultFileName $= "" )
      %defaultFileName = expandFilename("^game/gui/untitled.gui");
   
   %dlg = new OpenFileDialog()
   {
      Filters        = $GUI::FileSpec;
      DefaultPath    = $Pref::GuiEditor::LastPath;
      DefaultFile    = %defaultFileName;
      ChangePath     = false;
      MustExist      = true;
   };
         
   if(%dlg.Execute())
   {
      $Pref::GuiEditor::LastPath = filePath( %dlg.FileName );
      %filename = %dlg.FileName;      
      %dlg.delete();
      return %filename;
   }
   
   %dlg.delete();
   return "";   
}
