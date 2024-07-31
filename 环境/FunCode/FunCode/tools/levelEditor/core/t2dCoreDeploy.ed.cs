// Subscribe to dragDrop events
if( isObject( LBProjectObj ) )
{
   Projects::GetEventManager().subscribe( LBProjectObj, "ProjectDeploy" );
}

function T2DProject::onProjectDeploy( %this, %deployPath )
{
   //error("% ProjectDeploy - Deploy to" SPC %deployPath );
   
   // Update Game Configuration XML
   %this.updateGameConfig();
      
   // Update Game Resources
   //%this.updateGameResources();
}

//// ////
 //   //  Game Configuration
//// ////


function T2DProject::updateGameConfig( %this )
{
   %gameConfig = expandFilename("^project/common/commonConfig.xml");
   if( !isfile( %gameConfig ) )
      return false;
   
   %xmlGame = new SimXMLDocument(GameConfigXML) {};
   
   if(!%xmlGame.loadFile( %gameConfig ))
   {
      %xmlGame.delete();
      return false;
   }
   
   if( %xmlGame.pushFirstChildElement( "TorqueGameConfiguration" ) )
   {
      
      %xmlGame.writeField("DefaultScene", collapseFilename(%this.currentLevelFile));
      %xmlGame.writeField("Resolution", $levelEditor::DesignResolutionX SPC $levelEditor::DesignResolutionY SPC "32");
   }
   
   // Remove
   %xmlGame.saveFile( %gameConfig );
   %xmlGame.delete();
   
}
