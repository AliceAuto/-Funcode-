// RSSUpdate::initialize( "RSSUpdate::onNewNewsItems" );

function RSSUpdate::onNewNewsItems( %hdlCollection, %newItems )
{
   // Udpate UI
   if( !isObject( TGBInsiderDlg ) || %hdlCollection.getCount() == 0 )
      return;
   
   %newsDisplay = TGBInsiderDlg.findObjectByInternalName("newsDisplay", true);
   
   if( %newItems )
      newRSSNewsLabel.setVisible(true);
   
   %newsDisplay.setText("");
   
   // Add these backwards so the newest is first
   for( %i = %hdlCollection.getCount() - 1; %i >= 0 ; %i-- )
   {
      %hdl = %hdlCollection.getObject( %i );
      %newsDisplay.addText("<color:00000088>" @ %hdl.getHeadline() @ " \n<linkcolorhl:88888888><linkcolor:00008888><a:" @ getSubstr(%hdl.getLink(), 7, 1000) @ ">" @ "[ Read more... ] </a>\n\n", false);
   }
            
   // Force the textbox to resize itself vertically.
   //%newsDisplay.forceReflow();
            
}

function RSSNewsDlg::onWake( %this ) 
{
   %containerContainer = RSSFrame.findObjectByInternalName( "containerContainer" );
   %newsContainer = %containerContainer.findObjectByInternalName( "newsContainer" );
   %newsDisplay = %newsContainer.findObjectByInternalName("newsDisplay");
   %newsDisplay.forceReflow();
   
   newRSSNewsLabel.setVisible(false);   
   
}

function RSSGuiCloseButton::onClick( %this )
{
   Canvas.popDialog( RSSNewsDlg );
}

function RSSUpdate::showNews( )
{
   Canvas.pushDialog( TGBInsiderDlg );
   %book = TGBInsiderDlg.findObjectByInternalName("insiderTabBook", true );
   %book.selectPage( 1 );
}