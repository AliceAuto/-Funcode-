
$LoadedFunCodeResource = false;

//-----------------------------------------------------------
//
function ExecFunCodeResource()
{
   if( $LoadedFunCodeResource )
      return;
      
   $LoadedFunCodeResource = true;
      
   ExecFunCodeDataBlocks( 1 );
   //
   %resPath = expandFileName("resources");
   for( %iLoop = 1; %iLoop < 1000; %iLoop++ )
   {
      %resFile =  %resPath @ "/" @ "datablocks" @ %iLoop @ ".cs";
      if( !isFile( %resFile ) )
         break;
         
      exec( %resFile );
   }
   //
   ExecFunCodeDataBlocks( 0 );
}

//----------------------------------------------------------
//
function ReleaseFunCodeResource()
{
   if( !$LoadedFunCodeResource )
      return;
      
   $LoadedFunCodeResource = false;
   
   %datablocks = getFunCodeDatablockSet();
   %datablockCount = %datablocks.getCount();
   %iLoop = 0;
   while( %datablockCount > 0 && %iLoop < 10000 )
   {
      %iLoop++;
      %datablock = %datablocks.getObject(0);
      %datablock.delete();
      %datablockCount = %datablocks.getCount();
   }
      
   FunCodeImageList.clearItems();
   FunCodeAnimationList.clearItems();
}

//----------------------------------------------------------
//
function FunCodeCopyImageDataBlock( %db, %UpdateSideBar )
{
   if( !isObject( %db ) )
      return false;
      
   if( getT2DDatablockSet().isMemberSameName( %db ) )
      return true;
      
   %fileName      =  expandFileName( %db.imageName );
   %fileOnlyName  = fileName( %fileName );
   %fileWithXXX   =  %fileOnlyName;
     
   %fileExtXXX = fileExt( %fileName );
   if( %fileExtXXX $= ".dds" || %fileExtXXX $= ".jpg" || %fileExtXXX $= ".png" || %fileExtXXX $= ".bmp" )
   {
      %fileWithXXX  = fileName( %fileName );
      %fileOnlyName =  fileBase( %fileName );
   }
   else
   {
      if( isFile( %fileName @ ".dds" ) )
      {
         %fileName   =  %fileName @ ".dds";
         %fileWithXXX = %fileWithXXX @ ".dds";
      }
      else if( isFile( %fileName @ ".jpg" ) )
      {
         %fileName   =  %fileName @ ".jpg";
         %fileWithXXX = %fileWithXXX @ ".jpg";
      }
      else if( isFile( %fileName @ ".png" ) )
      {
         %fileName   =  %fileName @ ".png";
         %fileWithXXX = %fileWithXXX @ ".png";
      }
      else if( isFile( %fileName @ ".bmp" ) )
      {
         %fileName   =  %fileName @ ".bmp";
         %fileWithXXX = %fileWithXXX @ ".bmp";
      }
      else
         return false;
   }
         
   %newFileName  = expandFilename( "^game/data/images/" ) @ %fileWithXXX; 
    pathCopy( %fileName, %newFileName, false );
   
   if( !isFile( %newFileName ) )
      return false;
      
   %db.imageName = %newFileName;
      
   getT2DDatablockSet().add( %db );
   LBProjectObj.addDatablock( %db, true );
   getFunCodeDatablockSet().remove( %db );
   
   // Update object library
   if( %UpdateSideBar )
      GuiFormManager::SendContentMessage($LBCreateSiderBar, %this, "refreshAll 1");
      
   return true;
}

//----------------------------------------------------------
//
function FunCodeCopyAnimationDataBlock( %db, %UpdateSideBar )
{
   if( !isObject( %db ) )
      return false;
      
   if( getT2DDatablockSet().isMemberSameName( %db ) )
      return true;
      
   getT2DDatablockSet().add( %db );
   LBProjectObj.addDatablock( %db, true );
   getFunCodeDatablockSet().remove( %db );
   
   // Update object library
   if( %UpdateSideBar )
      GuiFormManager::SendContentMessage( $LBCAnimatedSprite, %this, "refresh 1" );
      
   return true;
}

//----------------------------------------------------------
//
function LaunchFunCodeImage()
{
   // Trail Version
   //MessageBoxOk("感谢使用", "试用版不支持该功能，请购买正式版。");
   //return;
   
   ExecFunCodeResource();

   Canvas.pushDialog(FunCodeImageGui);
   
   FunCodeImagePreviewWindow.clear();
   FunCodeImagePreviewWindow.setShowCell( true );
   FunCodeImageList.clearItems();
   %datablocks = getFunCodeDatablockSet();
   %datablockCount = %datablocks.getCount();
   for (%i = 0; %i < %datablockCount; %i++)
   {      
      %datablock = %datablocks.getObject(%i);
      if (%datablock.getClassName() !$= "t2dImageMapDatablock")
         continue;
      
      if ($ignoredDatablockSet.isMember(%datablock))
         continue;
            
      %name = %datablock.getName();
      FunCodeImageList.addItem(%name);
   }
}


function FunCodeImageGui::onSelect(%this)
{
   %imageMap = FunCodeImageList.getItemText(FunCodeImageList.getSelectedItem());
   
   if( !isObject( %imageMap ) )
      return;
   
   FunCodeCopyImageDataBlock( %imageMap, true );
   
   //
   FunCodeImageList.deleteItem(FunCodeImageList.getSelectedItem());
   FunCodeImagePreviewWindow.clear();
}

function FunCodeImageGui::cancel(%this)
{   
   Canvas.popDialog(%this);
}

function FunCodeImageList::onSelect(%this, %id, %text)
{
   %db = %this.getItemText(%this.getSelectedItem());
   FunCodeImagePreviewWindow.display(%db);
}

function FunCodeImageGui::OnSleep(%this)
{   
   FunCodeImagePreviewWindow.clear();
   if( $levelEditor::FunCodeReleaseResBtn )
   {
      ReleaseFunCodeResource();
   }
}