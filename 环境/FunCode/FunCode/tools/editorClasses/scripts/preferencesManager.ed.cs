//-----------------------------------------------------------------------------
// Torque2D Editor Classes
// Copyright (C) GarageGames.com, Inc.
//-----------------------------------------------------------------------------

//*** Initializes the Preferences Manager
function initPreferencesManager()
{
   //*** Create the Preferences Manager singleton
   %pm = new PreferencesManager(pref);
   registerPreferencesManager(%pm.getId());
}
