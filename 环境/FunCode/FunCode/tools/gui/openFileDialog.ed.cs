//------------------------------------------------------------------------------
// ex: getLoadFilename("~/stuff/*.*", openStuff);
//     -- calls 'openStuff(%filename)' on dblclick or ok
//------------------------------------------------------------------------------

function getLoadFilename(%filespec, %callback, %currentFile)
{
   %dlg = new OpenFileDialog()
   {
      Filters = %filespec @ "|" @ %filespec;
      DefaultFile = %currentFile;
      ChangePath = false;
      MustExist = true;
      MultipleFiles = false;
   };
   if(filePath( %currentFile ) !$= "")
      %dlg.DefaultPath = filePath(%currentFile);
   else
      %dlg.DefaultPath = getCurrentDirectory();
      
   if(%dlg.Execute())
      eval(%callback @ "(\"" @ %dlg.FileName @ "\");");
   
   %dlg.delete();
}

function getLoadFilenameold(%filespec, %callback, %currentFile)
{
   %dialog       =  OpenFileDlgEx;
   %dirTree      =  %dialog.findObjectByInternalName("DirectoryTree", true);
   %fileList     =  %dialog.findObjectByInternalName("FileList", true);
   %filterList   =  %dialog.findObjectByInternalName("FilterList", true);
   
   // Check for functionality Components.
   if( !isObject( %dirTree ) || !isObject( %fileList ) || !isObject( %filterList ) )
   {
      error("getLoadFileName - Corrupted File Dialog!");
      return;
   }
     
   OpenFileDlgEx.SuccessCallback = %callback;
   
   Canvas.pushDialog(%dialog, 99);
      
   // If we have a current path, set the tree to it
   if( filePath( %currentFile ) !$= "" )
      %dirTree.setSelectedPath( filePath( %currentFile ) );
      
   // Update our file view to reflect the changes
   %fileList.setPath( %dirTree.getSelectedPath(), %filespec );
   
   // Update File List to be selected on current item.   
   %fileExists = %fileList.findItemText( fileName( %currentFile ), false );
   if( %fileExists != -1 )
      %fileList.setCurSel( %fileExists );
   
}