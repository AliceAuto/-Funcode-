//------------------------------------------------------------------------------
// ex: getSaveFilenameEx("~/stuff/*.*", saveStuff);
//     -- calls 'saveStuff(%filename)' on ok
//------------------------------------------------------------------------------

function getSaveFilename(%filespec, %callback, %currentFile)
{
   %dlg = new SaveFileDialog()
   {
      Filters = %filespec @ "|" @ %filespec;
      DefaultFile = %currentFile;
      ChangePath = false;
      OverwritePrompt = true;
   };
   
   if(filePath( %currentFile ) !$= "")
      %dlg.DefaultPath = filePath(%currentFile);
   else
      %dlg.DefaultPath = getCurrentDirectory();
      
   if(%dlg.Execute())
   {
      %ext = strstr( %filespec, "." );
      %extEnd = strstr( %filespec, ")" );

      if( %extEnd == -1 )
         %extEnd = strstr( %filespec, "|");

      if( %extEnd == -1 )
         %extEnd = strlen(%filespec);

      %ext = getSubStr( %filespec, %ext, %extEnd - %ext );

      %filename = %dlg.FileName;
      
      eval(%callback @ "(\"" @ %filename @ "\");");
   }
   
   %dlg.delete();
}

function getSaveFilenameold(%filespec, %callback, %currentFile)
{
   %dialog       =  SaveFileDlgEx;
   %dirTree      =  %dialog.findObjectByInternalName("DirectoryTree", true);
   %fileList     =  %dialog.findObjectByInternalName("FileList", true);
   %filterList   =  %dialog.findObjectByInternalName("FilterList", true);
   %fileName     =  %dialog.findObjectByInternalName("fileName", true);
   
   // Check for functionality Components.
   if( !isObject( %dirTree ) || !isObject( %fileList ) || !isObject( %filterList ) )
   {
      error("getLoadFileName - Corrupted File Dialog!");
      return;
   }
   

   %dialog.SuccessCallback = %callback;
   
   Canvas.pushDialog(%dialog, 99);
      
   // If we have a current path, set the tree to it
   if( filePath( %currentFile ) !$= "" )
      %dirTree.setSelectedPath( filePath( %currentFile ) );
      
   // Update our file view to reflect the changes
   %fileList.setPath( %dirTree.getSelectedPath(), %filespec );

   if( %currentFile $= "" )
      return;

   // Update File List to be selected on current item.   
   %fileExists = %fileList.findItemText( fileName( %currentFile ), false );
   if( %fileExists != -1 )
      %fileList.setCurSel( %fileExists );
      
   // Set current file name
   if( isObject( %fileName ) )
      %fileName.setText( fileName( %currentFile ) );
}