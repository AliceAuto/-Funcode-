//-----------------------------------------------------------------------------
// Editor Classes Debug Console Output
// Copyright (C) GarageGames.com, Inc.
//-----------------------------------------------------------------------------

//-----------------------------------------------------------------------------
// DEbug conditional console error
//-----------------------------------------------------------------------------
function editorDebugError( %errorString )
{
   if( !isDebugBuild() )
      return;
      
   // Show it if we're in debug.
   error( %errorString );
}