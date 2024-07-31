//-----------------------------------------------------------------------------
// Torque Game Builder
// Copyright (C) GarageGames.com, Inc.
//-----------------------------------------------------------------------------

function initializeBehaviorEditor()
{   
   echo(" % - Initializing T2D Behavior Editor");
   
//   execPrefs("behaviorEditorPrefs.cs");
   
   exec("./scripts/behaviorEditor.ed.cs");
   exec("./scripts/behaviorList.ed.cs");
   exec("./scripts/behaviorStack.ed.cs");
   exec("./scripts/undo.ed.cs");
   exec("./scripts/fieldTypes.ed.cs");
}

function destroyBehaviorEditor()
{
   // not much to do here
}
