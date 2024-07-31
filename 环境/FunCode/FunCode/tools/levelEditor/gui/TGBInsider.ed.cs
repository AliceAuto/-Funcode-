function TGBInsiderDlg::addAddon( %this, %addonName )
{
   %addonList = %this.findObjectByInternalName("addonList",true);

   // Generate resource file path
   %addonLocation = $Tools::resourcePath @ "resources/" @ %addonName;

   %addonList.addItem( %addonName @ " - " @ %addonLocation );

}
function TGBInsiderDlg::closeDialog( %this )
{
   Canvas.popDialog( TGBInsiderDlg );
}

function TGBInsiderDlg::showAbout( %this ) 
{
   Canvas.pushDialog( TGBInsiderDlg );
   %book = %this.findObjectByInternalName("insiderTabBook", true );
   %book.selectPage( 2 );
}

function TGBInsiderDlg::showFirstRun( %this )
{
   Canvas.pushDialog( TGBInsiderDlg );

   %rssBox = %this.findObjectByInternalName( "rssCheckbox", true );
   if ( $levelEditor::checkRSSFeeds $= "" )
      %rssBox.setValue( true );

   %book = %this.findObjectByInternalName("insiderTabBook", true );
   %book.selectPage( 0 );  
}

function TGBInsiderDlg::onWake( %this )
{
   // Find Credits ML Text Control
   // Note : -> is equivelent to .findObjectByInternalName(CreditsMLText, false)
   //      :--> is equivelent to .findObjectByInternalName(CreditsMLText, true)
   %cml = %this-->CreditsMLText;

   // Credits Styling (Platform Specific changes go here)
   
   %headerFontBold = "Arial Bold";
   %headerFont = "Arial";
   %headerFontSize = 15;
   %headerFontColor = "FFFFFF";
   %headerFontBoldStyle = "<font:" @ %headerFontBold @ ":" @ %headerFontSize @ "><color:" @ %headerFontColor @ ">";
   %headerFontStyle = "<font:" @ %headerFont @ ":" @ %headerFontSize @ "><color:" @ %headerFontColor @ ">";
   %pageBreak = "<br><br><br><br><br><br><br><br><br><br><br>";
   %br = " <br>";

   

   // Header Font
   %cml.addText( %headerFontStyle ,false );
   %cml.addText( "<just:right>" , false );
   %cml.addText( "<br><br><br><br><br>", false );
   %cml.addText( %headerFontStyle @ "Torque2D Version :" SPC getT2DVersion() @ %br ,false);
   %cml.addText( %headerFontStyle @ "Torque Game Builder Version :" SPC $LevelBuilder::Version @ %br ,false);
   %cml.addText( %pageBreak, false );


   //
   // Dedication (Thanks Josh/Melv)
   //   
   %cml.addText( %headerFontStyle @ "<just:center>Torque Game Builder is dedicated to " @
                  "Josh Williams and Melvyn May for having the vision " @
                  "to bring a truly powerful 2D game engine to the hands " @
                  "of every developer with an idea and enough drive to see it through." @ %br ,false);
   %cml.addText( %br @ %br @ %br, false );                  
   
   //
   // Torque Game Builder
   //   
   %cml.addText( %headerFontBoldStyle @ "Producer/Project Manager" @ %br ,false);   
   %cml.addText( %headerFontStyle, false );
   %cml.addText( "Justin DuJardin" @ %br, false );
   %cml.addText( %br @ %br @ %br, false );

   %cml.addText( %headerFontBoldStyle @ "Programming Lead" @ %br ,false);   
   %cml.addText( %headerFontStyle, false );
   %cml.addText( "Adam Larson" @ %br, false );
   %cml.addText( %br @ %br @ %br, false );

   %cml.addText( %headerFontBoldStyle @ "Programming" @ %br ,false);   
   %cml.addText( %headerFontStyle, false );
   %cml.addText( "Justin DuJardin" @ %br, false );
   %cml.addText( "Matt Langley" @ %br, false );
   %cml.addText( "Paul Scott" @ %br, false );
   %cml.addText( "Tom Bampton" @ %br, false );
   %cml.addText( "Pat Wilson" @ %br, false );
   %cml.addText( "Josh Williams" @ %br, false );
   %cml.addText( "Melvyn May" @ %br, false );
   %cml.addText( %br @ %br @ %br, false );

   %cml.addText( %headerFontBoldStyle @ "T2D Engine Programming" @ %br ,false);   
   %cml.addText( %headerFontStyle, false );
   %cml.addText( "Josh Williams" @ %br, false );
   %cml.addText( "Melvyn May" @ %br, false );
   %cml.addText( "Justin DuJardin" @ %br, false );
   %cml.addText( "Adam Larson" @ %br, false );
   %cml.addText( "Pat Wilson" @ %br, false );
   %cml.addText( "Ben Garney" @ %br, false );
   %cml.addText( "Robert Blanchet Jr." @ %br, false );
   %cml.addText( %br @ %br @ %br, false );

   //
   // Docs and Demos
   //   
   %cml.addText( %headerFontBoldStyle @ "Docs and Demos Lead" @ %br ,false);   
   %cml.addText( %headerFontStyle, false );
   %cml.addText( "Matt Langley" @ %br, false );
   %cml.addText( %br @ %br @ %br, false );
   
   %cml.addText( %headerFontBoldStyle @ "Docs and Demos" @ %br ,false);
   
   %cml.addText( %headerFontStyle, false );
   %cml.addText( "Joe Maruschak" @ %br, false );
   %cml.addText( "Thomas Eastman" @ %br, false );
   %cml.addText( "Alex Swanson" @ %br, false );
   %cml.addText( "Nate Feyma" @ %br, false );
   %cml.addText( "Mark McCoy" @ %br, false );
   %cml.addText( "Thomas Buscaglia" @ %br, false );
   %cml.addText( "Dan Maruschak" @ %br, false );
   %cml.addText( "Ivan 'Spider' DelSol" @ %br, false );
   %cml.addText( %br @ %br @ %br, false );

   //
   // Art
   //   
   %cml.addText( %headerFontBoldStyle @ "Art" @ %br ,false);
   
   %cml.addText( %headerFontStyle, false );
   %cml.addText( "Alex Swanson" @ %br, false );
   %cml.addText( "Nate Feyma" @ %br, false );
   %cml.addText( "Mark McCoy" @ %br, false );
   %cml.addText( %headerFontBoldStyle @ "Icons by <a:www.famfamfam.com>FamFamFam </a>" @ %br , false );
   %cml.addText( %br @ %br @ %br, false );

   //
   // QA
   //   
   %cml.addText( %headerFontBoldStyle @ "Quality Assurance" @ %br ,false);
   
   %cml.addText( %headerFontStyle, false );
   %cml.addText( "Ken Holst" @ %br, false );
   %cml.addText( "The GarageGames Community" @ %br, false );
   %cml.addText( %br @ %br @ %br, false );

   //
   // Marketing/Sales
   //   
   %cml.addText( %headerFontBoldStyle @ "Marketing/Sales" @ %br ,false);
   
   %cml.addText( %headerFontStyle, false );
   %cml.addText( "Eric Fritz" @ %br, false );
   %cml.addText( "The GarageGames Community" @ %br, false );
   %cml.addText( %br @ %br @ %br, false );

   //
   // Special Thanks
   //   
   %cml.addText( %headerFontBoldStyle @ "Special Thanks" @ %br ,false);
   
   %cml.addText( %headerFontStyle, false );
   %cml.addText( "The GarageGames Community" @ %br, false );
   %cml.addText( "Jay Moore" @ %br, false );
   %cml.addText( "Julie Moore" @ %br, false );
   %cml.addText( "Benjamin Bradley" @ %br, false );
   %cml.addText( "Cara Bradley" @ %br, false );
   %cml.addText( "Everyone that Contributed and is not listed" @ %br @ %br, false );
   %cml.addText( %br @ %br @ %br, false );
   
   //
   // GarageGames
   //   
   %cml.addText( %headerFontBoldStyle @ "GarageGames" @ %br ,false);
   %cml.addText( %headerFontStyle, false );   
   %cml.addText( "Robert Blanchet Jr." @ %br, false );
   %cml.addText( "Timothy Aste" @ %br, false );
   %cml.addText( "Michael Blenden" @ %br, false );
   %cml.addText( "Thomas Buscaglia" @ %br, false );
   %cml.addText( "Chris Calef" @ %br, false );
   %cml.addText( "Joshua Dallman" @ %br, false );
   %cml.addText( "Justin DuJardin" @ %br, false );
   %cml.addText( "Clark Fagot" @ %br, false );
   %cml.addText( "Matt Fairfax" @ %br, false );
   %cml.addText( "Nate Feyma" @ %br, false );
   %cml.addText( "Jacob Fike" @ %br, false );
   %cml.addText( "Eric Fritz" @ %br, false );
   %cml.addText( "Mark Frohnmayer" @ %br, false );
   %cml.addText( "Ben Garney" @ %br, false );
   %cml.addText( "Tim Gift" @ %br, false );
   %cml.addText( "Kenneth Holst" @ %br, false );
   %cml.addText( "Davey Jackson" @ %br, false );
   %cml.addText( "Channa Langley" @ %br, false );
   %cml.addText( "Matthew Langley" @ %br, false );
   %cml.addText( "Trevor Lanz" @ %br, false );
   %cml.addText( "Adam Larson" @ %br, false );
   %cml.addText( "Joe Maruschak" @ %br, false );
   %cml.addText( "Mark McCoy" @ %br, false );
   %cml.addText( "Rick Overman" @ %br, false );
   %cml.addText( "Karen Peal" @ %br, false );
   %cml.addText( "John Quigley" @ %br, false );
   %cml.addText( "Brian Ramage" @ %br, false );
   %cml.addText( "Dylan Romero" @ %br, false );
   %cml.addText( "Paul Scott" @ %br, false );
   %cml.addText( "Brett Seyler" @ %br, false );
   %cml.addText( "Sean Sullivan" @ %br, false );
   %cml.addText( "Alex Swanson" @ %br, false );
   %cml.addText( "Jeff Tunnell" @ %br, false );
   %cml.addText( "James Wiley" @ %br, false );
   %cml.addText( "Josh Williams" @ %br, false );
   %cml.addText( "Pat Wilson" @ %br, false );
   %cml.addText( "David \"Fulcrum\" Wyand" @ %br, false );
   %cml.addText( "Zachary Zadell" @ %br, false );
   %cml.addText( "Stephen Zepp" @ %br, false );
   %cml.addText( %br @ %br @ %br, false );

   %cml.addText( %pageBreak, false );

   // Flow the Credits
   %cml.forceReflow();
   
   
   
   %addonList = %this.findObjectByInternalName("addonList",true);
   if( isObject( %addonList ) )
      %addonList.clearItems();
      
   // Check for RSS News updates.
   if( $levelEditor::checkRSSFeeds $= true )
      RSSUpdate::initialize( "RSSUpdate::onNewNewsItems" );
   
   %addonList = %this.findObjectByInternalName("addonList",true);
   %addonList.clearItems();
   %addons = ResourceFinder::enumActiveAddons( "TGBInsiderDlg.addAddon" );   
}

