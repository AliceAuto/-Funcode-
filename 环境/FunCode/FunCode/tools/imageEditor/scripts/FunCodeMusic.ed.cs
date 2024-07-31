

//----------------------------------------------------------
//
function LaunchFunCodeMusic()
{
    // Trail Version
   //MessageBoxOk("感谢使用", "试用版不支持该功能，请购买正式版。");
   //return;
     
   Canvas.pushDialog(FunCodeMusicGui);
   
   FunCodeMusicList.clearItems();
   FunCodeProjectMusicList.clearItems();
   
   %resPath = expandFileName("resources/audio/");
   %gamePath = expandFileName( "^game/data/audio/" );
   %fileSpec = %resPath @ "*.ogg";
   for (%file = findFirstFile(%fileSpec); %file !$= ""; %file = findNextFile(%fileSpec))
   {
      %fileNameExt = fileName( %file );
      if( isFile( %gamePath @ %fileNameExt ) )
         continue;
      
      FunCodeMusicList.addItem(%fileNameExt);
   }  
   %fileSpec = %resPath @ "*.wav";
   for (%file = findFirstFile(%fileSpec); %file !$= ""; %file = findNextFile(%fileSpec))
   {
      %fileNameExt = fileName( %file );
      if( isFile( %gamePath @ %fileNameExt ) )
         continue;
      
      FunCodeMusicList.addItem(%fileNameExt);
   }  

   %fileSpec = %gamePath @ "*.ogg";
   for (%file = findFirstFile(%fileSpec); %file !$= ""; %file = findNextFile(%fileSpec))
   {
      %fileNameExt = fileName( %file );
      
      FunCodeProjectMusicList.addItem("game/data/audio/" @ %fileNameExt);
   }  
   %fileSpec = %gamePath @ "*.wav";
   for (%file = findFirstFile(%fileSpec); %file !$= ""; %file = findNextFile(%fileSpec))
   {
      %fileNameExt = fileName( %file );
      
      FunCodeProjectMusicList.addItem("game/data/audio/" @ %fileNameExt);
   } 
}


function FunCodeMusicGui::onSelect(%this)
{
   if( FunCodeMusicList.getSelectedItem() < 0 )
      return;
      
   %music = FunCodeMusicList.getItemText(FunCodeMusicList.getSelectedItem());
      
   %fileName = expandFileName("resources/audio/") @ %music;
   %newFileName  = expandFileName( "^game/data/audio/" ) @ %music; 
   pathCopy( %fileName, %newFileName, false );
   
   //
   FunCodeMusicList.deleteItem(FunCodeMusicList.getSelectedItem());
   FunCodeProjectMusicList.addItem("game/data/audio/" @ %music);
}

function FunCodeMusicGui::onDelFromProject(%this)
{
   if( FunCodeProjectMusicList.getSelectedItem() < 0 )
      return;
      
   %music = FunCodeProjectMusicList.getItemText(FunCodeProjectMusicList.getSelectedItem());      
      
   %fileName = fileName( %music );
   if( %fileName $= "" )
      return;  
   
   %delFileName  = expandFileName( "^game/data/audio/" ) @ %fileName; 
   fileDelete( %delFileName );   
   
   //
   FunCodeMusicList.addItem( %fileName );
   FunCodeProjectMusicList.deleteItem(FunCodeProjectMusicList.getSelectedItem());
}

$T2D::SupportAudioSpec = "All Supported Music (*.ogg;*.wav)|*.ogg;*.wav|";
function FunCodeMusicGui::onImport(%this)
{
   %dlg = new OpenFileDialog()
   {
      Filters = $T2D::SupportAudioSpec;
      ChangePath = false;
      MustExist = true;
      MultipleFiles = false;
   };
   
   %dlg.DefaultPath = $Pref::Dialogs::LastImportMusicPath;
      
   if(%dlg.Execute())
   {    
      // Store last path
      $Pref::Dialogs::LastImportMusicPath = filePath( %dlg.files[0] );
      
      %fileName     = %dlg.FileName;
      %fileOnlyName = fileName( %fileName ); 
      
      %newFileLocation = "resources/audio/" @ %fileOnlyName;
      pathCopy( %fileName, %newFileLocation );  
      
      if( FunCodeMusicList.findItemText( %fileOnlyName ) == -1 && FunCodeProjectMusicList.findItemText( "game/data/audio/" @ %fileOnlyName ) == -1 )
      {
         FunCodeMusicList.addItem( %fileOnlyName );
      }

      // Update object library
      GuiFormManager::SendContentMessage($LBCreateSiderBar, %this, "refreshAll 1");

   }
   %dlg.delete();
}

$FunCodeLastPlayMusic   =  0;
function FunCodePlaySelectedMusic()
{
   %music = "";
   if( FunCodeMusicList.getSelectedItem() >= 0 )
      %music = expandFileName("resources/audio/") @ FunCodeMusicList.getItemText(FunCodeMusicList.getSelectedItem());
   else if( FunCodeProjectMusicList.getSelectedItem() >= 0 )
   {
      %file = fileName( FunCodeProjectMusicList.getItemText(FunCodeProjectMusicList.getSelectedItem()) );
      %music = expandFileName( "^game/data/audio/" ) @ %file;
   }
   else
      return;
      
   FunCodeStopMusic();
   $FunCodeLastPlayMusic = FunCodePlaySound( %music );
}

function FunCodeStopMusic()
{
   if( $FunCodeLastPlayMusic > 0 )
   {
      FunCodeStopSound( $FunCodeLastPlayMusic );
      
      $FunCodeLastPlayMusic = 0;
   }
}

function FunCodeMusicGui::cancel(%this)
{   
   Canvas.popDialog(%this);
}

function FunCodeMusicList::onSelect(%this, %id, %text)
{
   FunCodeProjectMusicList.clearSelection();
}

function FunCodeProjectMusicList::onSelect(%this, %id, %text)
{
   FunCodeMusicList.clearSelection();
}