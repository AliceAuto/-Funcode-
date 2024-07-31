//-----------------------------------------------------------------------------
// Torque Game Builder
// Copyright (C) GarageGames.com, Inc.
//-----------------------------------------------------------------------------

// Default. Text field.
BehaviorEditor::registerFieldType("default", "createDefaultGui");

function BehaviorFieldStack::createDefaultGui(%this, %behavior, %fieldIndex)
{
   %fieldInfo = %behavior.template.getBehaviorField(%fieldIndex);
   %name = getField(%fieldInfo, 0);
   %description = %behavior.template.getBehaviorFieldDescription(%fieldIndex);
   
   %control = %this.createTextEditProperty(%name, "TEXT", %name, %description);
   %editField = %control.findObjectByInternalName(%name @ "TextEdit");
   %editField.object = %behavior;
}

// Int. Text field validated to a whole number.
BehaviorEditor::registerFieldType("int", "createIntGui");

function BehaviorFieldStack::createIntGui(%this, %behavior, %fieldIndex)
{
   %fieldInfo = %behavior.template.getBehaviorField(%fieldIndex);
   %name = getField(%fieldInfo, 0);
   %description = %behavior.template.getBehaviorFieldDescription(%fieldIndex);
   
   %control = %this.createTextEditProperty(%name, 0, %name, %description);
   %editField = %control.findObjectByInternalName(%name @ "TextEdit");
   %editField.object = %behavior;
}

// Float. Text field validated to a number with 3 digits of precision.
BehaviorEditor::registerFieldType("float", "createFloatGui");

function BehaviorFieldStack::createFloatGui(%this, %behavior, %fieldIndex)
{
   %fieldInfo = %behavior.template.getBehaviorField(%fieldIndex);
   %name = getField(%fieldInfo, 0);
   %description = %behavior.template.getBehaviorFieldDescription(%fieldIndex);
   
   %control = %this.createTextEditProperty(%name, 3, %name, %description);
   %editField = %control.findObjectByInternalName(%name @ "TextEdit");
   %editField.object = %behavior;
}

// Point2F. Two text edits validated to a number with 3 digits of precision.
BehaviorEditor::registerFieldType("Point2F", "createPoint2FGui");

function BehaviorFieldStack::createPoint2FGui(%this, %behavior, %fieldIndex)
{
   %fieldInfo = %behavior.template.getBehaviorField(%fieldIndex);
   %name = getField(%fieldInfo, 0);
   %description = %behavior.template.getBehaviorFieldDescription(%fieldIndex);
   
   %control = %this.createTextEdit2(%name, %name, 3, %name, "X", "Y", %description);
   %edit1 = %control.findObjectByInternalName(%name @ "TextEdit0");
   %edit2 = %control.findObjectByInternalName(%name @ "TextEdit1");
   %edit1.isProperty = true;
   %edit2.isProperty = true;
   %edit1.object = %behavior;
   %edit2.object = %behavior;
}

// Bool. Check box.
BehaviorEditor::registerFieldType("bool", "createBoolGui");

function BehaviorFieldStack::createBoolGui(%this, %behavior, %fieldIndex)
{
   %fieldInfo = %behavior.template.getBehaviorField(%fieldIndex);
   %name = getField(%fieldInfo, 0);
   %description = %behavior.template.getBehaviorFieldDescription(%fieldIndex);
   
   %control = %this.createCheckBox(%name, %name, %description, "", "", "", true);
   %editField = %control.findObjectByInternalName(%name @ "CheckBox");
   %editField.object = %behavior;
}

// Enum. Drop down list.
BehaviorEditor::registerFieldType("enum", "createEnumGui");

function BehaviorFieldStack::createEnumGui(%this, %behavior, %fieldIndex)
{
   %fieldInfo = %behavior.template.getBehaviorField(%fieldIndex);
   %name = getField(%fieldInfo, 0);
   %description = %behavior.template.getBehaviorFieldDescription(%fieldIndex);
   %list = %behavior.template.getBehaviorFieldUserData(%fieldIndex);
   
   %control = %this.createDropDownList(%name, %name, "", %list, %description, true, true);
   %listCtrl = %control.findObjectByInternalName(%name @ "DropDown");
   %listCtrl.object = %behavior;
}

// Object. Drop down list containing named objects of a specified type.
BehaviorEditor::registerFieldType("Object", "createObjectGui");

function BehaviorFieldStack::createObjectGui(%this, %behavior, %fieldIndex)
{
   %fieldInfo = %behavior.template.getBehaviorField(%fieldIndex);
   %name = getField(%fieldInfo, 0);
   %description = %behavior.template.getBehaviorFieldDescription(%fieldIndex);
   %objectType = %behavior.template.getBehaviorFieldUserData(%fieldIndex);
   
   // Everything we could possibly want should be contained in either the
   // scenegraph or the managed datablock set.
   
   %scenegraph = ToolManager.getLastWindow().getSceneGraph();
   %count = %scenegraph.getSceneObjectCount();
   %list = "None";
   for( %i = 0; %i < %count; %i++ )
   {
      %sceneObject = %scenegraph.getSceneObject( %i );
      if( !%sceneObject.isMemberOfClass( %objectType ) )
         continue;
      
      if( %sceneObject.getName() $= "" )
         continue;
         
      %list = %list TAB %sceneObject.getName();
   }
   
   %count = $managedDatablockSet.getCount();
   for( %i = 0; %i < %count; %i++ )
   {
      %object = $managedDatablockSet.getObject( %i );
      if( !%object.isMemberOfClass( %objectType ) )
         continue;
      
      if( %object.getName() $= "" )
         continue;
         
      %list = %list TAB %object.getName();
   }
   
   %control = %this.createDropDownList(%name, %name, "", %list, %description, true, true);
   %listCtrl = %control.findObjectByInternalName(%name @ "DropDown");
   %listCtrl.object = %behavior;
}

// Enum. Drop down list.
BehaviorEditor::registerFieldType("keybind", "createKeybindGui");

function BehaviorFieldStack::createKeybindGui(%this, %behavior, %fieldIndex)
{
   %fieldInfo = %behavior.template.getBehaviorField(%fieldIndex);
   %name = getField(%fieldInfo, 0);
   %description = %behavior.template.getBehaviorFieldDescription(%fieldIndex);
   
   %control = %this.createKeybindList(%name, %name, %description, true, true);
   %listCtrl = %control.findObjectByInternalName(%name @ "DropDown");
   %listCtrl.object = %behavior;
}

// Int. Text field validated to a whole number.
BehaviorEditor::registerFieldType("color", "createColorGui");

function BehaviorFieldStack::createColorGui(%this, %behavior, %fieldIndex)
{
   %fieldInfo = %behavior.template.getBehaviorField(%fieldIndex);
   %name = getField(%fieldInfo, 0);
   %description = %behavior.template.getBehaviorFieldDescription(%fieldIndex);
   
   %control = %this.createColorPicker(%name, %name, %description);
   %editField = %control.findObjectByInternalName("QuickEditColorPicker");
   %editField.object = %behavior;
   %editField.isProperty = true;
}

// Polygon Editor
BehaviorEditor::registerFieldType("polygon", "createPolygonGui");

function BehaviorFieldStack::createPolygonGui(%this, %behavior, %fieldIndex)
{
   %fieldInfo = %behavior.template.getBehaviorField(%fieldIndex);
   %name = getField(%fieldInfo, 0);
   %description = %behavior.template.getBehaviorFieldDescription(%fieldIndex);

   %control = %this.createCommandButton("EditBehaviorPolygon(" @ %behavior.owner @ ", "
                                                               @ %behavior @ ", "
                                                               @ %name @ ");",
                                        %name @ " - Edit Polygon");
}

// Polygon Editor
BehaviorEditor::registerFieldType("localpointlist", "createLocalPointListGui");

function BehaviorFieldStack::createLocalPointListGui(%this, %behavior, %fieldIndex)
{
   %fieldInfo = %behavior.template.getBehaviorField(%fieldIndex);
   %name = getField(%fieldInfo, 0);
   %description = %behavior.template.getBehaviorFieldDescription(%fieldIndex);

   %control = %this.createCommandButton("EditBehaviorLocalPointList(" @ %behavior.owner @ ", "
                                                                      @ %behavior @ ", "
                                                                      @ %name @ ");",
                                        %name @ " - Edit Local Point List");
}
