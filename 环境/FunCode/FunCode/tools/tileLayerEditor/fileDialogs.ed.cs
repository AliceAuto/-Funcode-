//---------------------------------------------------------------------------------------------
// Torque Game Builder
// Copyright (C) GarageGames.com, Inc.
//---------------------------------------------------------------------------------------------

/// T2DProject::getLevelSaveName - Open a Native File dialog and retrieve the
///  location to save the current document.  *NOTE* this will change soon to
///  accomodate a document aware project interface that can be easily expanded
///  upon and customized by a 3rd party developer or someone else who might be
///  generally worth supporting with good API's :)
///
/// @arg defaultFileName   The FileName to default in the field and to be selected when a path is opened

$T2D::LayerSpec = "TGB Tile Layers (*.lyr)|*.lyr|All Files (*.*)|*.*|";

function T2DTileLayer::getLevelSaveName( %defaultFileName )
{
   if( %defaultFileName $= "" )
      %defaultFileName = expandFilename("^game/data/tilemaps/untitled.lyr");
   
   %dlg = new SaveFileDialog()
   {
      Filters           = $T2D::LayerSpec;
      DefaultPath       = filePath(%defaultFileName);
      DefaultFile       = %defaultFileName;
      ChangePath        = false;
      OverwritePrompt   = true;
   };
   
   if(%dlg.Execute())
   {
      %filename = %dlg.FileName;
      %filespec = $T2D::LayerSpec;
      
      %ext = strstr( %filespec, "." );
      %extEnd = strstr( %filespec, ")" );
      if( %extEnd != -1 )
         %ext = getSubStr( %filespec, %ext, %extEnd - %ext );
         
      if( fileExt( %filename ) !$= %ext )
         %filename = %filename @ %ext;
      
      %dlg.delete();
      
      return %filename;
   }
   
   %dlg.delete();
   
   return "";
}

function T2DTileLayer::getLevelOpenName( %defaultFileName )
{
   if( %defaultFileName $= "" )
      %defaultFileName = expandFilename("^game/data/tilemaps/untitled.lyr");
   
   %dlg = new OpenFileDialog()
   {
      Filters        = $T2D::LayerSpec;
      DefaultFile    = %defaultFileName;
      DefaultPath    = filePath( %defaultFileName );
      ChangePath     = false;
      MustExist      = true;
   };

   if(%dlg.Execute())
   {
      %filename = %dlg.FileName;
      %dlg.delete();
      return %filename;
   }
   
   %dlg.delete();
   return "";
}
