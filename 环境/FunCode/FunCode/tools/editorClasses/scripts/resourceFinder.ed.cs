//---------------------------------------------------------------------------------------------
// Torque Game Builder
// Copyright (C) GarageGames.com, Inc.
//---------------------------------------------------------------------------------------------

//---------------------------------------------------------------------------------------------
// Load a resource object into the active resource tree
//---------------------------------------------------------------------------------------------
function ResourceFinder::enumResources( %callback )
{
   // Generate resource file path
   %resourcesPath = expandFilename( "^tool/resources/" );
   %resourcesList = getDirectoryList( %resourcesPath );
   
   %wordCount = getFieldCount( %resourcesList );
   for( %i = 0; %i < %wordCount; %i++ )
   {
      %resource = getField( %resourcesList, %i );
      if( isFile( %resourcesPath @ %resource @ "/resourceDatabase.cs") )
         eval( %callback @ "(" @ %resource @ ");" );
   }
   
   %resourcesPath = "resources/";
   %resourcesList = getDirectoryList( %resourcesPath );
   
   %wordCount = getFieldCount( %resourcesList );
   for( %i = 0; %i < %wordCount; %i++ )
   {
      %resource = getField( %resourcesList, %i );
      if( isFile( %resourcesPath @ %resource @ "/resourceDatabase.cs") )
         eval( %callback @ "(" @ %resource @ ");" );
   }

}

function ResourceFinder::enumActiveAddons( %callback )
{
   // Generate resource file path
   %resourcesPath = $Tools::resourcePath @ "resources/";
   %resourcesList = getDirectoryList( %resourcesPath );
   
   %wordCount = getFieldCount( %resourcesList );
   for( %i = 0; %i < %wordCount; %i++ )
   {
      %resource = getField( %resourcesList, %i );
      if( isFile( %resourcesPath @ %resource @ "/resourceDatabase.cs") && ResourceFinder::isActive( %resource ) )
         eval( %callback @ "(" @ %resource @ ");" );
   }
}

function ResourceFinder::getAvailableResources()
{
   $availableResources = "";
   ResourceFinder::enumResources( "ResourceFinder::addAvailableResource" );
   return $availableResources;
}

function ResourceFinder::getActiveAddons()
{
   $availableResources = "";
   ResourceFinder::enumActiveAddons( "ResourceFinder::addAvailableResource" );
   return $availableResources;
}

function ResourceFinder::addAvailableResource( %resource )
{
   $availableResources = trim( $availableResources TAB %resource );
}

function ResourceFinder::isActive( %resourceName )
{
   return isObject( ResourceFinder::getResource( %resourceName ) );
}

function ResourceFinder::getResource( %resourceName )
{
   if( !isObject( $resourceGroup ) )
      return 0;
      
   for( %i = 0; %i < $resourceGroup.getCount(); %i++ )
   {
      %resourceObject = $resourceGroup.getObject( %i );
      if( !isObject( %resourceObject ) )
         continue;
      
      if( %resourceObject.Name $= %resourceName )         
         return %resourceObject;
   }

   return 0;

}

