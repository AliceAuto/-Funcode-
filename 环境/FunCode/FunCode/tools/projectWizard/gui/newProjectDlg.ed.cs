function TGBWorkspace::getGamesFolder( %this )
{
   if( $Pref::UserGamesFolder $= "" )
      return getUserHomeDirectory() @ "/MyGames";
   
   return $Pref::UserGamesFolder;
}


function NewProjectDlg::onWake( %this )
{      
   NewProjectLocationText.Text = TGBWorkspace.getGamesFolder();
}