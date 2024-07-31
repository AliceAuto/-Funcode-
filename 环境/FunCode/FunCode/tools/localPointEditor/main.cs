//------------------------------------------------------------------------------
// Torque Game Builder
// Copyright (C) GarageGames.com, Inc.
//------------------------------------------------------------------------------

exec("./localPointPrefs.cs");
exec("./gui/LocalPointEditor.ed.gui");
exec("./localPointEditor.ed.cs");
exec("./localPointMouse.ed.cs");
exec("./localPointDragAndDrop.ed.cs");
exec("./linkpointEditor.ed.cs");
exec("./collisionPolyEditor.ed.cs");
exec("./shapeVectorEditor.ed.cs");
exec("./behaviorPolyEditor.ed.cs");
exec("./behaviorLocalPointListEditor.ed.cs");


function initializeLocalPointEditor()
{
   if (!isObject(LinkpointEditor))
   {
      new ScriptObject(LinkpointEditor) {
         class = LocalPointEditor;
         showEditObject = true;
         showPolygon = false;
         showHull = false;
         showConvexViolations = false;
         clampToBounds = false;
         insertBetweenMode = false;
         showBackground = false;
         zoomEnable = true;
         polyControlsEnable = false;
         title = "Á´½Ó(¹Ò½Ó)µã±à¼­Æ÷";
      };
   }
   
   if (!isObject(CollisionPolyEditor))
   {
      new ScriptObject(CollisionPolyEditor) {
         class = LocalPointEditor;
         showEditObject = true;
         showPolygon = true;
         showHull = true;
         showConvexViolations = true;
         clampToBounds = true;
         insertBetweenMode = true;
         showBackground = false;
         zoomEnable = false;
         polyControlsEnable = true;
         title = "Åö×²±à¼­Æ÷";
      };
   }

   if (!isObject(ShapeVectorEditor))
   {
      new ScriptObject(ShapeVectorEditor) {
         class = LocalPointEditor;
         showEditObject = false;
         showPolygon = true;
         showHull = false;
         showConvexViolations = false;
         clampToBounds = true;
         insertBetweenMode = false;
         showBackground = false;
         zoomEnable = false;
         polyControlsEnable = true;
         title = "¶à±ßÐÎ±à¼­Æ÷";
      };
   }

   if (!isObject(BehaviorPolyEditor))
   {
      new ScriptObject(BehaviorPolyEditor) {
         class = LocalPointEditor;
         showEditObject = true;
         showPolygon = true;
         showHull = false;
         showConvexViolations = false;
         clampToBounds = true;
         insertBetweenMode = false;
         showBackground = false;
         zoomEnable = false;
         polyControlsEnable = true;
         title = "¶à±ßÐÎÐÐÎª±à¼­Æ÷";
      };
   }

   if (!isObject(BehaviorLocalPointListEditor))
   {
      new ScriptObject(BehaviorLocalPointListEditor) {
         class = LocalPointEditor;
         showEditObject = true;
         showPolygon = false;
         showHull = false;
         showConvexViolations = false;
         clampToBounds = false;
         insertBetweenMode = false;
         showBackground = false;
         zoomEnable = true;
         polyControlsEnable = false;
         title = "±¾µØ×ø±êÁÐ±í±à¼­Æ÷";
      };
   }
}

function destroyLocalPointEditor()
{
   if (isObject(LinkpointEditor))
   {
      // close it down, if it's open.
      if (LinkpointEditor.open)
         LinkpointEditor.close();
         
      // clean up the object.
      LinkpointEditor.delete();
   }

   if (isObject(CollisionPolyEditor))
   {
      // close it down, if it's open.
      if (CollisionPolyEditor.open)
         CollisionPolyEditor.close();
         
      // clean up the object.
      CollisionPolyEditor.delete();
   }

   if (isObject(ShapeVectorEditor))
   {
      // close it down, if it's open.
      if (ShapeVectorEditor.open)
         ShapeVectorEditor.close();
         
      // clean up the object.
      ShapeVectorEditor.delete();
   }

   if (isObject(BehaviorPolyEditor))
   {
      // close it down, if it's open.
      if (BehaviorPolyEditor.open)
         BehaviorPolyEditor.close();
         
      // clean up the object.
      BehaviorPolyEditor.delete();
   }

   if (isObject(BehaviorLocalPointListEditor))
   {
      // close it down, if it's open.
      if (BehaviorLocalPointListEditor.open)
         BehaviorLocalPointListEditor.close();
         
      // clean up the object.
      BehaviorLocalPointListEditor.delete();
   }
}


