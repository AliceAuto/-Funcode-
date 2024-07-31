//-----------------------------------------------------------------------------
// LevelBuilder Quick Edit t2dSceneObject Class
// Copyright (C) GarageGames.com, Inc.
//-----------------------------------------------------------------------------

//-----------------------------------------------------------------------------
// Register Form Content.
//-----------------------------------------------------------------------------
GuiFormManager::AddFormContent( "LevelBuilderQuickEditClasses", "t2dSceneObjectGroup", "LBQESceneObjectGroup::CreateContent", "LBQESceneObjectGroup::SaveContent", 2 );

//-----------------------------------------------------------------------------
// Form Content Creation Function
//-----------------------------------------------------------------------------
function LBQESceneObjectGroup::CreateContent( %contentCtrl, %quickEditObj )
{
   %base = %contentCtrl.createBaseStack("LBQESceneObjectClass", %quickEditObj);
   
   %scriptingRollout = %base.createRolloutStack("Scripting");
   %scriptingRollout.createTextEdit("Name", "TEXT", "Name", "Name the Object for Referencing in Script");
   %scriptingRollout.createTextEdit("Class", "TEXT", "Class", "Link this Object to a Class");
   %scriptingRollout.createTextEdit("SuperClass", "TEXT", "Super Class", "Link this Object to a Parent Class");
   
   //%dynamicFieldRollout = %base.createRolloutStack("Dynamic Fields");
   //%dynamicFieldRollout.createDynamicFieldStack();
   
   // Return Ref to Base.
   return %base;
}

//-----------------------------------------------------------------------------
// Form Content Save Function
//-----------------------------------------------------------------------------
function LBQESceneObjectGroup::SaveContent( %contentCtrl )
{
   // Nothing.
}

function t2dSceneObjectGroup::setClass(%this, %class)
{
   %this.class = %class;
}

function t2dSceneObjectGroup::getClass(%this, %class)
{
   return %this.class;
}

function t2dSceneObjectGroup::setSuperClass(%this, %class)
{
   %this.superClass = %class;
}

function t2dSceneObjectGroup::getSuperClass(%this, %class)
{
   return %this.superClass;
}
