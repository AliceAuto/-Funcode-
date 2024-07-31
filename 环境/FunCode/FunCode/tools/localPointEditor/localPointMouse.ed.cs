//------------------------------------------------------------------------------
// Torque Game Builder
// Copyright (C) GarageGames.com, Inc.
//------------------------------------------------------------------------------

function LocalPointVisualEdit::onRightMouseDown(%this, %modifier, %worldPosition, %clicks)
{
   // find the editor we're serving.
   %editor = LocalPointEditorGui.editorObject;

   %pickedObjects = %this.getScenegraph().pickpoint(%worldPosition, 0x1);
   
   %selected = NULL;
   for (%i=0; %i<getWordCount(%pickedObjects); %i++)
   {
      %candidateObject = getWord(%pickedObjects, %i);
      if ((!isObject(%selected)) || (t2dVectorDistance(%candidateObject.position, %worldPosition) <
                                     t2dVectorDistance(%selected.position, %worldPosition)))
      {
         %selected = %candidateObject;
      }
   }

   if ((isObject(%selected)) && (isObject(%selected.lpobject)))
   {
      // clicked a dot, delete it!
      %editor.deletePoint(%selected.lpobject);
      %this.activeDot = NULL;
   }
}

function LocalPointVisualEdit::onMouseDown(%this, %modifier, %worldPosition, %clicks)
{
   // find the editor we're serving.
   %editor = LocalPointEditorGui.editorObject;

   // get all objects from group 0 (i.e. the graphical dots)
   %pickedObjects = %this.getScenegraph().pickpoint(%worldPosition, BIT($LocalPointEditor::selectGroup));
   
   %selected = NULL;
   for (%i=0; %i<getWordCount(%pickedObjects); %i++)
   {
      %candidateObject = getWord(%pickedObjects, %i);
      if ((!isObject(%selected)) || (t2dVectorDistance(%candidateObject.position, %worldPosition) <
                                     t2dVectorDistance(%selected.position, %worldPosition)))
      {
         %selected = %candidateObject;
      }
   }

   if (isObject(%selected))
   {
      %this.activeDot = %selected;
   }
   else
   {
      %localPosition = %editor.SceneSpaceToLocalSpace(%worldPosition);
      %this.activeDot = (%editor.newLocalPoint(%localPosition)).dot;
   }
}

function LocalPointVisualEdit::onMouseUp(%this, %modifier, %worldPosition, %clicks)
{
   // find the editor we're serving.
   %editor = LocalPointEditorGui.editorObject;

   if (isObject(%this.activeDot))
   {
      %this.activeDot.lpObject.setPosition(%editor.SceneSpaceToLocalSpace(%worldPosition), true);
   }
   %this.activeDot = NULL;
}

function LocalPointVisualEdit::onMouseDragged(%this, %modifier, %worldPosition, %clicks)
{
   // find the editor we're serving.
   %editor = LocalPointEditorGui.editorObject;

   if (isObject(%this.activeDot))
   {
      %this.activeDot.lpObject.setPosition(%editor.SceneSpaceToLocalSpace(%worldPosition));      
   }
}

function LocalPointVisualEdit::onMouseLeave(%this, %modifier, %worldPosition, %clicks)
{
   %this.onMouseUp(%modifier, %worldPosition, %clicks);
}
