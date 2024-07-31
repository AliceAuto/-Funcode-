


//----------------------------------------------------------
//
function LaunchFunCodeParticle()
{
    // Trail Version
   //MessageBoxOk("感谢使用", "试用版不支持该功能，请购买正式版。");
   //return;
     
   ExecFunCodeResource();

   Canvas.pushDialog(FunCodeParticleGui);
   
   FunCodeParticlePreviewWindow.clear();   
   FunCodeParticleList.clearItems();
   
   %resPath = expandFileName("resources/particles/");
   %gamePath = expandFileName( "^game/data/particles/" );
   %fileSpec = %resPath @ "*.eff";
   for (%file = findFirstFile(%fileSpec); %file !$= ""; %file = findNextFile(%fileSpec))
   {
      %fileNameExt = fileName( %file );
      if( isFile( %gamePath @ %fileNameExt ) )
         continue;
      %onlyFileName  =  fileBase( %file );
      FunCodeParticleList.addItem(%onlyFileName);
   }
}


function FunCodeParticleGui::onSelect(%this)
{
   %Particle = FunCodeParticleList.getItemText(FunCodeParticleList.getSelectedItem());
   
   if( %Particle $= "" )
      return;
      
   FunCodeParticlePreviewWindow.display(%Particle);
   %imageDataBlocks  =  FunCodeParticlePreviewWindow.sprite.getImageDataBlocks();
   %AnimDataBlocks  =  FunCodeParticlePreviewWindow.sprite.getAnimationDataBlocks();
   
   %iCount  =  getWordCount( %imageDataBlocks );
   for( %iLoop = 0; %iLoop < %iCount; %iLoop++ )
   {
      %db   =  getWord( %imageDataBlocks, %iLoop );
      if( !isObject( %db ) )
         continue;
         
      FunCodeCopyImageDataBlock( %db, true );
   }
   
   %iCount  =  getWordCount( %AnimDataBlocks );
   for( %iLoop = 0; %iLoop < %iCount; %iLoop++ )
   {
      %db   =  getWord( %AnimDataBlocks, %iLoop );
      if( !isObject( %db ) )
         continue;
         
      FunCodeCopyAnimationDataBlock( %db, true );
   }
   
   %fileName = expandFileName("resources/particles/") @ %Particle @ ".eff";
   %newFileName  = expandFileName( "^game/data/particles/" ) @ %Particle @ ".eff"; 
   pathCopy( %fileName, %newFileName, false );
   
   GuiFormManager::SendContentMessage( $LBCParticleEffect, %this, "refresh 1" );
   
   //
   FunCodeParticleList.deleteItem(FunCodeParticleList.getSelectedItem());
   FunCodeParticlePreviewWindow.clear();
}

function FunCodeParticleGui::cancel(%this)
{   
   Canvas.popDialog(%this);
}

function FunCodeParticleList::onSelect(%this, %id, %text)
{
   %db = %this.getItemText(%this.getSelectedItem());
   FunCodeParticlePreviewWindow.display(%db);
}

function FunCodeParticleGui::OnSleep(%this)
{   
   FunCodeParticlePreviewWindow.clear();
   if( $levelEditor::FunCodeReleaseResBtn )
   {
      ReleaseFunCodeResource();
   }
}