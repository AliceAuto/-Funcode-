// Subscribe to dragDrop events
if( isObject( LBProjectObj ) )
{
   Input::GetEventManager().subscribe( LBProjectObj, "BeginDropFiles" );
   Input::GetEventManager().subscribe( LBProjectObj, "DropFile" );
   Input::GetEventManager().subscribe( LBProjectObj, "EndDropFiles" );
}

function T2DProject::onBeginDropFiles( %this, %fileCount )
{   
   //error("% DragDrop - Beginning file dropping of" SPC %fileCount SPC " files.");
}
function T2DProject::onDropFile( %this, %filePath )
{
   // Check imagemap extension
   %fileExt = fileExt( %filePath );
   if( (%fileExt $= ".dds") || (%fileExt $= ".png") || (%fileExt $= ".jpg") || (%fileExt $= ".bmp") )
      %this.onDropImageFile(%filePath);
   
   else if (%fileExt $= ".zip")
      %this.onDropZipFile(%filePath);
}

function T2DProject::onDropZipFile(%this, %filePath)
{
   %zip = new ZipObject();
   %zip.openArchive(%filePath);
   %count = %zip.getFileEntryCount();
   for (%i = 0; %i < %count; %i++)
   {
      %fileEntry = %zip.getFileEntry(%i);
      %fileFrom = getField(%fileEntry, 0);
      
      // For now, if it's a .cs file, we'll assume it's a behavior.
      if (fileExt(%fileFrom) !$= ".cs")
         continue;
      
      %fileTo = expandFilename("^game/behaviors/") @ fileName(%fileFrom);
      %zip.extractFile(%fileFrom, %fileTo);
      exec(%fileTo);
   }
}

function T2DProject::onDropImageFile(%this, %filePath)
{
   // File Information madness
   %fileName         = %filePath;
   %fileOnlyName     = fileName( %fileName );
   %fileBase         = validateDatablockName(fileBase( %fileName ) @ "ImageMap");
   
   // [neo, 5/17/2007 - #3117]
   // Check if the file being dropped is already in data/images or a sub dir by checking if
   // the file path up to length of check path is the same as check path.
   %checkPath    = expandFilename( "^game/data/images/" );
   %fileOnlyPath = filePath( expandFileName( %filePath ) );
   %fileBasePath = getSubStr( %fileOnlyPath, 0, strlen( %checkPath ) );
   
   if( %checkPath !$= %fileBasePath )
   {
      // No match so file is from outside images directory and we need to copy it in
      %fileNewLocation = expandFilename("^game/data/images/") @ fileBase( %fileName ) @ fileExt( %fileName );
   
      // Move to final location
      if( !pathCopy( %filePath, %fileNewLocation ) )
         return;
   }
   else 
   {  
      // Already in images path somewhere so just link to it
      %fileNewLocation = %filePath;
   }
   
   addResPath( filePath( %fileNewLocation ) );
      
   // Create Datablock
   %imap = new t2dImageMapDatablock();
   %imap.setName( %fileBase );
   %imap.imageName = %fileNewLocation;
   %imap.imageMode = "FULL";
   %imap.filterPad = false;
   %imap.compile();
         
   // Bad Creation!
   if( !isObject( %imap ) )
      return;
      
   %this.addDatablock( %fileBase, false );
}

function T2DProject::onEndDropFiles( %this, %fileCount )
{
   //error("% DragDrop - Completed file dropping");

   %this.persistToDisk( true, false, false );
   
   // Update object library
   GuiFormManager::SendContentMessage($LBCreateSiderBar, %this, "refreshAll 1");

}