
// open create save import export
function TGBWorkspace::createProject( %this )
{
   newProject();
}

function TGBWorkspace::openProject( %this )
{
   %dlg = new OpenFileDialog()
   {
      Title = "";
      DefaultPath = $Pref::Dialogs::LastProjectPath;
      Filters = " (*.funProj)|*.funProj|All Files (*.*)|*.*";
      MustExist = true;
      MultipleFiles = false;
      ChangePath = false;
   };
   
   if(%dlg.Execute())
   {
      $Pref::Dialogs::LastProjectPath = filePath( %dlg.FileName );
      if(! LBProjectObj.isActive())
         Projects::GetEventManager().postEvent( "_ProjectOpen", %dlg.FileName );
      else 
      {
         $pref::startupProject = %dlg.FileName;
         reloadProject();
      }
   }

}

function TGBWorkspace::importProject( %this )
{ 
   import11XGames();
}

function TGBWorkspace::saveProject( %this )
{
}

if( !isObject(TGBWorkspace) )
   new ScriptMsgListener(TGBWorkspace);
   
function TGBStartPage::onWake( %this )
{
   tgbBetaText.text = getT2DVersion();   
}
