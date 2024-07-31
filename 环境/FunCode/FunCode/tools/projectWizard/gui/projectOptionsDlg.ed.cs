// Defines functionality for project options dialog window

// The dialog becomes active - fill resources lists.
function projectOptionsDlg::onWake( %this )
{
   // Add dependent Resources to list  
   %this.addDependentResources();
   
   // Clear unused resource list
   projectAvailableResources.clearItems();
   
   // Add All unused resources
   ResourceFinder::enumResources( %this @ ".addResource" );
}

function projectOptionsDlg::addResource( %this, %resource )
{
   if( projectDependentResourcesList.findItemText( %resource ) == -1 &&
       projectAvailableResources.findItemText( %resource ) == -1 )
      projectAvailableResources.addItem( %resource );
}

function projectOptionsDlg::addDependentResources( %this )
{
   projectDependentResourcesList.clearItems();
   // Load Resources used by this project.
   if( isObject( $dependentResourceGroup ) )
   {
      for( %i = 0; %i < $dependentResourceGroup.getCount(); %i++ )
      {
         %resourceLink = $dependentResourceGroup.getObject( %i );
         if( !isObject( %resourceLink ) )
            continue;
         
         // Resource Name Exists
         if( %resourceLink.Name !$= "" && projectDependentResourcesList.findItemText( %resourceLink.Name) == -1 )
            projectDependentResourcesList.addItem( %resourceLink.Name );
      }
   }   
}

// Save project resource list and apply
function saveProjectResourcesButton::onClick( %this )
{
   %resources = ResourceFinder::getAvailableResources();
   %resourceCount = getFieldCount( %resources );
   %resourcesPath = expandFilename( "^tool/resources/" );

   for( %i = 0; %i < %resourceCount; %i++ )
   {
      %resource = getField( %resources, %i );
      
      // Remove the resource if it is in the available resources list and loaded.
      %listIndex = projectAvailableResources.findItemText( %resource );
      %validResource = ResourceFinder::isActive( %resource );
      if( %validResource && ( %listIndex != -1 ) )
      {
         LBProjectObj.removeResource( %resource, false );
         ResourceObject::Unload( %resource );
         
         // [Neo, 5/11/2007 - #2981]
         // We need to delete the resource directory as well or it will be reloaded on startup!
         deleteGameResourceDirectory( %resource );
         
         continue;
      }
      
      // Add the resource if it is in the dependent resources list and not loaded.
      %listIndex = projectDependentResourcesList.findItemText( %resource );
      %validResource = ResourceFinder::isActive( %resource );
      if( !%validResource && ( %listIndex != -1 ) )
      {
         %result = ResourceObject::load( %resourcesPath @ %resource );
         if( isObject( %result ) )
         {
            %resNameLink = new ScriptObject() { Name = %result.Name; };
            LBProjectObj.addResource( %resNameLink, false );
         }
         else
         {
         }
         continue;
      }         
   }
   
   // Persist Resources
   LBProjectObj.persistToDisk( false, true, false );
   GuiFormManager::BroadcastContentMessage( "LevelBuilderSidebarCreate", 0, "refresh" );
   
   // Pop Resource Dialog
   Canvas.popDialog( projectOptionsDlg );
}

// User canceled, merely cleanup and exit
function cancelProjectResourcesButton::onClick( %this )
{
   Canvas.popDialog( projectOptionsDlg );
}

// Add an inactive resource to the projects used resources list
function setResourceActiveButton::onClick( %this )
{
   // Get selected item.
   %selItems = projectAvailableResources.getSelectedItems();
   %count = getWordCount( %selItems );
   
   // Convert to item names so they can be deleted without thrashing the ids.
   %selNames = "";
   for( %i = 0; %i < %count; %i++ )
      %selNames = %selNames SPC projectAvailableResources.getItemText( getWord( %selItems, %i ) );
      
   %selNames = trim( %selNames );
   
   // Add items to the dependent list.
   for( %i = 0; %i < %count; %i++ )
   {
      // Grab Resource Name
      %resName = getWord( %selNames, %i );
      
      // Grab the item.
      %selItem = projectAvailableResources.findItemText( %resName );
      
      // Remove from active resource list.
      projectAvailableResources.deleteItem( %selItem );   
      
      // Add to used list.
      if( projectDependentResourcesList.findItemText( %resName ) == -1 )
         projectDependentResourcesList.addItem( %resName );
   }
}

// Remove an active resource from the project and move to unused list
function setResourceInactiveButton::onClick( %this )
{
   // Get selected item.
   %selItems = projectDependentResourcesList.getSelectedItems();
   %count = getWordCount( %selItems );
   
   // Convert to item names so they can be deleted without thrashing the ids.
   %selNames = "";
   for( %i = 0; %i < %count; %i++ )
      %selNames = %selNames SPC projectDependentResourcesList.getItemText( getWord( %selItems, %i ) );
      
   %selNames = trim( %selNames );
      
   for( %i = 0; %i < %count; %i++ )
   {
      // Grab Resource Name
      %resName = getWord( %selNames, %i );
      
      // Grab Resource Name
      %selItem = projectDependentResourcesList.findItemText( %resName );
      
      // Remove from active resource list.
      projectDependentResourcesList.deleteItem( %selItem );   
      
      // Add to used list.
      if( projectAvailableResources.findItemText( %resName ) == -1 )
         projectAvailableResources.addItem( %resName );
   }
}


function projectAvailableResources::onDoubleClick( %this )
{
   setResourceActiveButton.onClick();
}

function projectDependentResourcesList::onDoubleClick( %this )
{
   setResourceInactiveButton.onClick();
}

// [Neo, 5/11/2007 - #2981]
// Delete a game resource directory and all sub directories
//       
function deleteGameResourceDirectory( %resource )
{
   // Base resource directory 
   %gameResourcePath = expandFilename("^project/resources/" @ %resource );
          
   // Delete the dir and all sub dirs including all files
   deleteDirectory( %gameResourcePath );
}
