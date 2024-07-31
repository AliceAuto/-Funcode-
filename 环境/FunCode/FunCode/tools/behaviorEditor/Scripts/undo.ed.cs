//-----------------------------------------------------------------------------
// Torque Game Builder
// Copyright (C) GarageGames.com, Inc.
//-----------------------------------------------------------------------------

function UndoAddBehavior::undo(%this)
{
   %this.object.removeBehavior(%this.behavior, false);
   schedule(0, 0, updateQuickEdit);
}

function UndoAddBehavior::redo(%this)
{
   %this.object.addBehavior(%this.behavior);
   schedule(0, 0, updateQuickEdit);
}

function UndoRemoveBehavior::undo(%this)
{
   %this.object.addBehavior(%this.behavior);
   schedule(0, 0, updateQuickEdit);
}

function UndoRemoveBehavior::redo(%this)
{
   %this.object.removeBehavior(%this.behavior, false);
   schedule(0, 0, updateQuickEdit);
}
