//------------------------------------------------------------------------------
// Torque Game Builder
// Copyright (C) GarageGames.com, Inc.
//------------------------------------------------------------------------------

function LinkpointEditor::getLocalPoints(%this)
{
   %linkpointIDs = %this.baseObject.getAllLinkpointIDs();
   
   for (%i=0; %i<%this.baseObject.getLinkCount(); %i++)
   {
      %lpID = getWord(%linkpointIDs, %i);
      %point = %this.createNewLocalPoint(getWords(%this.baseObject.linkPoints, 2*%i, 2*%i+1));
      %point.mountChildren = %this.baseObject.getChildrenOfLinkpoint(%lpID);
   }
}

function LinkpointEditor::save(%this)
{
   // record undo info.
   %oldLinkpoints = %this.baseObject.linkpoints;
   %oldLinkpointIDs = %this.baseObject.getAllLinkpointIDs();
   for (%i=0; %i<getWordCount(%oldLinkpointIDs); %i++)
   {
      %id = getWord(%oldLinkpointIDs, %i);
      %children = %this.baseObject.getChildrenOfLinkpoint(%id);
      %oldChildren = setField(%oldChildren, %i, %children);
   }
   for (%i=0; %i<getWordCount(%this.localPoints); %i++)
   {
      %lp = getWord(%this.localPoints, %i);
      %newLinkpoints = setWord(%newLinkpoints, %i*2, getWord(%lp.position, 0));
      %newLinkpoints = setWord(%newLinkpoints, %i*2+1, getWord(%lp.position, 1));
      %newChildren = setField(%newChildren, %i, %lp.mountChildren);
   }
   %undo = new UndoScriptAction()
   {
      class = LinkpointEditorUndo;
      superClass = LocalPointUndo;
      actionName = "Modify Linkpoint";
      object = %this.baseObject;
      newLinkpoints = %newLinkpoints;
      newChildren = %newChildren;
      oldLinkpoints = %oldLinkpoints;
      oldChildren = %oldChildren;
   };
   %undo.addToManager(LevelBuilderUndoManager);
      

   for (%i=0; %i<getWordCount(%this.dismountList); %i++)
   {
      %obj = getWord(%this.dismountList, %i);
      %obj.dismount();
   }

   for (%i=0; %i<getWordCount(%this.localPoints); %i++)
   {
      %lp = getWord(%this.localPoints, %i);
      for (%j=0; %j<getWordCount(%lp.mountChildren); %j++)
      {
         %child = getWord(%lp.mountChildren, %j);
         %child.dismount();
      }
   }

   %this.baseObject.removeAllLinkpoints();

   for (%i=0; %i<getWordCount(%this.localPoints); %i++)
   {
      %obj = getWord(%this.localPoints, %i);
      %id = %this.baseObject.addLinkPoint(%obj.position);
      for (%c=0; %c<getWordCount(%obj.mountChildren); %c++)
      {
         %child = getWord(%obj.mountChildren, %c);
         %child.mountToLinkpoint(%this.baseObject, %id);
      }
   }

   %this.close();
}

function LinkpointEditor::deletePoint(%this, %point)
{
   if (getWordCount(%point.mountChildren) > 0)
   {
      MessageBoxYesNo("删减物体?", 
                      "链接点正在使用中，删除此链接点及其子节点?", 
                      %this @ ".confirmDelete(" @ %point @ ");",
                      %this @ ".cancelDelete(" @ %point @ ");");
   }
   else
   {
      %this.confirmDelete(%point);
   }
}

function LinkpointEditor::cancelDelete(%this)
{
}

function LinkpointEditor::confirmDelete(%this, %point)
{
   %undo = new UndoScriptAction()
   {
      class = LinkpointEditorUndo;
      superClass = LocalPointUndo;
      actionName = "Delete Point";
      editor = %this;
      position = %point.position;
      index = %point.index;
      mountChildren = %point.mountChildren;
   };
   %undo.addToManager(%this.undoManager);

   for (%i=0; %i<getWordCount(%point.mountChildren); %i++)
   {
      %this.dismountList = setWord(%this.dismountList, getWordCount(%this.dismountList), getWord(%point.mountChildren, %i));
   }
   %point.cleanUp();
}

function LinkpointEditorUndo::undo(%this)
{
   if (%this.actionName $= "Delete Point")
   {
      %lp = %this.editor.createNewLocalPoint(%this.position);
      %this.editor.movePoint(%lp.index, %this.index);
      if (%this.mountChildren !$= "")
      {
         %lp.mountChildren = %this.mountChildren;
         for (%i=0; %i<getWordCount(%this.mountChildren); %i++)
         {
            %child = getWord(%this.mountChildren, %i);
            for (%j=0; %j<getWordCount(%this.editor.dismountList); %j++)
            {
               %listObj = getWord(%this.editor.dismountList, %j);
               if (%child == %listObj)
               {
                  %this.editor.dismountList = removeWord(%this.editor.dismountList, %j);
                  break;
               }
            }
         }
      }
   }
   else if (%this.actionName $= "Modify Linkpoint")
   {
      // dismount new children.
      for (%i=0; %i<getFieldCount(%this.newChildren); %i++)
      {
         %children = getField(%this.newChildren, %i);
         for (%j=0; %j<getWordCount(%children); %j++)
         {
            %child = getWord(%children, %j);
            %child.dismount();
         }
      }
      
      // clear linkpoints.
      %this.object.removeAllLinkpoints();
      
      // recreate old linkpoints and remount old children.
      for (%i=0; %i<getFieldCount(%this.oldChildren); %i++)
      {
         %children = getField(%this.oldChildren, %i);
         %pos = getWords(%this.oldLinkpoints, %i*2, %i*2+1);
         %id = %this.object.addLinkpoint(%pos);
         for (%j=0; %j<getWordCount(%children); %j++)
         {
            %child = getWord(%children, %j);
            %child.mountToLinkpoint(%this.object, %id);
         }
      }
   }
   else
   {
      Parent::undo(%this);
   }      
}

function LinkpointEditorUndo::redo(%this)
{
   if (%this.actionName $= "Delete Point")
   {
      for (%i=0; %i<getWordCount(%this.mountChildren); %i++)
      {
         %this.editor.dismountList = setWord(%this.editor.dismountList, getWordCount(%this.editor.dismountList), getWord(%this.mountChildren, %i));
      }
      %lp = getWord(%this.editor.localPoints, %this.index);
      %lp.cleanUp();
   }
   else if (%this.actionName $= "Modify Linkpoint")
   {
      // dismount old children.
      for (%i=0; %i<getFieldCount(%this.oldChildren); %i++)
      {
         %children = getField(%this.oldChildren, %i);
         for (%j=0; %j<getWordCount(%children); %j++)
         {
            %child = getWord(%children, %j);
            %child.dismount();
         }
      }
      
      // clear linkpoints.
      %this.object.removeAllLinkpoints();
      
      // recreate old linkpoints and remount old children.
      for (%i=0; %i<getFieldCount(%this.newChildren); %i++)
      {
         %children = getField(%this.newChildren, %i);
         %pos = getWords(%this.newLinkpoints, %i*2, %i*2+1);
         %id = %this.object.addLinkpoint(%pos);
         for (%j=0; %j<getWordCount(%children); %j++)
         {
            %child = getWord(%children, %j);
            %child.mountToLinkpoint(%this.object, %id);
         }
      }
   }
   else
   {
      Parent::redo(%this);
   }      
}
