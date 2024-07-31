//-----------------------------------------------------------------------------
// Torque Game Builder
// Copyright (C) GarageGames.com, Inc.
//-----------------------------------------------------------------------------

// Called to setup the base expandos
function setupBaseExpandos()
{
   setScriptPathExpando("tools", getMainDotCsDir() @ "/tools", true);
   setScriptPathExpando("tool", getMainDotCsDir() , true);
   setScriptPathExpando("toolResources", getMainDotCsDir() @ "/resources", true);
   
   setScriptPathExpando("common", getMainDotCsDir() @ "/common", true);
   
   // Remove the game expando so we can use this to reset expandos
   removeScriptPathExpando("game");
}
