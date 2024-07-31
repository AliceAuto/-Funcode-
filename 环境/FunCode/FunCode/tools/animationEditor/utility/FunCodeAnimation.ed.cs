


//----------------------------------------------------------
//
function LaunchFunCodeAnimation()
{
   // Trail Version
   //MessageBoxOk("感谢使用", "试用版不支持该功能，请购买正式版。");
   //return;
   
   ExecFunCodeResource();

   Canvas.pushDialog(FunCodeAnimationGui);
   
   FunCodeAnimationPreviewWindow.clear();   
   FunCodeAnimationList.clearItems();
   %datablocks = getFunCodeDatablockSet();
   %datablockCount = %datablocks.getCount();
   for (%i = 0; %i < %datablockCount; %i++)
   {      
      %datablock = %datablocks.getObject(%i);
      if (%datablock.getClassName() !$= "t2dAnimationDatablock")
         continue;
      
      if ($ignoredDatablockSet.isMember(%datablock))
         continue;
            
      %name = %datablock.getName();
      FunCodeAnimationList.addItem(%name);
   }
}


function FunCodeAnimationGui::onSelect(%this)
{
   %animation = FunCodeAnimationList.getItemText(FunCodeAnimationList.getSelectedItem());
   
   if( !isObject( %animation ) )
      return;
   
   if( FunCodeCopyImageDataBlock( %animation.imageMap, true ) )
   {
      FunCodeCopyAnimationDataBlock( %animation, true );
   }
   
   //
   FunCodeAnimationList.deleteItem(FunCodeAnimationList.getSelectedItem());
   FunCodeAnimationPreviewWindow.clear();
}

function FunCodeAnimationGui::cancel(%this)
{   
   Canvas.popDialog(%this);
}

function FunCodeAnimationList::onSelect(%this, %id, %text)
{
   %db = %this.getItemText(%this.getSelectedItem());
   FunCodeAnimationPreviewWindow.display(%db);
}

function FunCodeAnimationGui::OnSleep(%this)
{   
   FunCodeAnimationPreviewWindow.clear();
   if( $levelEditor::FunCodeReleaseResBtn )
   {
      ReleaseFunCodeResource();
   }
}