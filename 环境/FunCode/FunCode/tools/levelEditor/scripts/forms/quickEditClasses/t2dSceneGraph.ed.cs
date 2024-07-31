//-----------------------------------------------------------------------------
// LevelBuilder Quick Edit t2dStaticSprite Class
// Copyright (C) GarageGames.com, Inc.
//-----------------------------------------------------------------------------

//-----------------------------------------------------------------------------
// Register Form Content.
//-----------------------------------------------------------------------------
GuiFormManager::AddFormContent( "LevelBuilderQuickEditClasses", "t2dSceneGraph", "LBQESceneGraph::CreateContent", "LBQESceneGraph::SaveContent", 2 );

//-----------------------------------------------------------------------------
// Form Content Creation Function
//-----------------------------------------------------------------------------
function LBQESceneGraph::CreateContent( %contentCtrl, %quickEditObj )
{
   %base = %contentCtrl.createBaseStack("LBQESceneObjectClass", %quickEditObj);
   %rollout = %base.createRolloutStack("屏幕", true);
   %rollout.createTextEdit2("CameraPositionX", "CameraPositionY", 3, "屏幕位置", "X", "Y", "设置屏幕位置");
   %rollout.createTextEdit2("CameraSizeX", "CameraSizeY", 3, "", "宽", "高", "设置屏幕大小");
   %rollout.createTextEdit2("DesignResolutionX", "DesignResolutionY", 0, "窗口大小", "X", "Y", "设置窗口大小");
   
   //%scriptingRollout = %base.createRolloutStack("Scene Graph Scripting");
   //%scriptingRollout.createTextEdit("Name", "TEXT", "Name", "Name the Object for Referencing in Script");
   //%scriptingRollout.createTextEdit("Class", "TEXT", "Class", "Link this Object to a Class");
   //%scriptingRollout.createTextEdit("SuperClass", "TEXT", "Super Class", "Link this Object to a Parent Class");
   
   //%sortRollout = %base.createRolloutStack("层级管理");
   //%sortRollout.createCheckBox("UseLayerSorting", "Use Layer Sorting", "Enables sorting of objects before the layer is rendered.");
   //%sortRollout.createLabel("Layer      L   H       Sort Mode");
   //for ( %i = 0; %i < 32; %i++ )
   //   %sortRollout.createLayerManager( %i );

   %debugRollout = %base.createRolloutStack("显示选项");
   %debugRollout.createCheckBox("ShowBoundingBoxes", "边界盒", "显示精灵边界盒");
   %debugRollout.createCheckBox("ShowLinkPoints", "链接点", "显示精灵链接点");
   %debugRollout.createCheckBox("ShowWorldLimits", "世界边界限制", "显示精灵世界边界限制");
   %debugRollout.createCheckBox("ShowCollisionBounds", "碰撞盒", "显示精灵碰撞盒");
   //%debugRollout.createCheckBox("ShowContactHistory", "Contact History", "Show Object Collision Contact History");
   %debugRollout.createCheckBox("ShowSortPoints", "排序点", "显示精灵排序点");
   //%debugRollout.createCheckBox("ShowDebugBanner", "Debug Banner", "Show Scene Debug Banner with Statistics");
   
   //%dynamicFieldRollout = %base.createRolloutStack("Dynamic Fields");
   //%dynamicFieldRollout.createDynamicFieldStack();
   
   // Return Ref to Base.
   return %base;

}



//-----------------------------------------------------------------------------
// Form Content Save Function
//-----------------------------------------------------------------------------
function LBQESceneGraph::SaveContent( %contentCtrl )
{
   // Nothing.
}

function t2dSceneGraph::setCameraPositionX(%this, %value)
{
   %oldPos = %this.cameraPosition;
   %oldSize = %this.cameraSize;
   
   %this.cameraPosition = %value SPC %this.getCameraPositionY();
   if (ToolManager.getActiveTool().getID() == LevelEditorCameraTool.getID())
      LevelEditorCameraTool.setCameraPosition(%this.cameraPosition);
   
   %newPos = %this.cameraPosition;
   %newSize = %this.cameraSize;
   ToolManager.onCameraChanged( %oldPos, %oldSize, %newPos, %newSize );
}

function t2dSceneGraph::setCameraPositionY(%this, %value)
{
   %oldPos = %this.cameraPosition;
   %oldSize = %this.cameraSize;
   
   %this.cameraPosition = %this.getCameraPositionX() SPC %value;
   if (ToolManager.getActiveTool().getID() == LevelEditorCameraTool.getID())
      LevelEditorCameraTool.setCameraPosition(%this.cameraPosition);
   
   %newPos = %this.cameraPosition;
   %newSize = %this.cameraSize;
   ToolManager.onCameraChanged( %oldPos, %oldSize, %newPos, %newSize );
}

function t2dSceneGraph::getCameraPositionX(%this)
{
   return getWord(%this.cameraPosition, 0);
}

function t2dSceneGraph::getCameraPositionY(%this)
{
   return getWord(%this.cameraPosition, 1);
}

function t2dSceneGraph::setCameraSizeX(%this, %value)
{
   %oldPos = %this.cameraPosition;
   %oldSize = %this.cameraSize;
   
   %this.cameraSize = %value SPC %this.getCameraSizeY();
   if (ToolManager.getActiveTool().getID() == LevelEditorCameraTool.getID())
      LevelEditorCameraTool.setCameraSize(%this.cameraSize);
   
   %newPos = %this.cameraPosition;
   %newSize = %this.cameraSize;
   ToolManager.onCameraChanged( %oldPos, %oldSize, %newPos, %newSize );
}

function t2dSceneGraph::setCameraSizeY(%this, %value)
{
   %oldPos = %this.cameraPosition;
   %oldSize = %this.cameraSize;
   
   %this.cameraSize = %this.getCameraSizeX() SPC %value;
   if (ToolManager.getActiveTool().getID() == LevelEditorCameraTool.getID())
      LevelEditorCameraTool.setCameraSize(%this.cameraSize);
   
   %newPos = %this.cameraPosition;
   %newSize = %this.cameraSize;
   ToolManager.onCameraChanged( %oldPos, %oldSize, %newPos, %newSize );
}

function t2dSceneGraph::getCameraSizeX(%this)
{
   return getWord(%this.cameraSize, 0);
}

function t2dSceneGraph::getCameraSizeY(%this)
{
   return getWord(%this.cameraSize, 1);
}

function t2dSceneGraph::setClass(%this, %class)
{
   %this.class = %class;
}

function t2dSceneGraph::getClass(%this, %class)
{
   return %this.class;
}

function t2dSceneGraph::setSuperClass(%this, %class)
{
   %this.superClass = %class;
}

function t2dSceneGraph::getSuperClass(%this, %class)
{
   return %this.superClass;
}

function t2dSceneGraph::setUseLayerSorting(%this, %enable)
{
   %this.useLayerSorting = %enable;
}

function t2dSceneGraph::getUseLayerSorting(%this)
{
   return %this.useLayerSorting;
}


// ----------------------------------------------------------------------------------
// Debug Rendering.
// ----------------------------------------------------------------------------------

function t2dSceneGraph::setShowDebugBanner(%this, %value)
{
   if (%value)
      %this.setDebugOn(0);
   else
      %this.setDebugOff(0);
}


function t2dSceneGraph::setShowBoundingBoxes(%this, %value)
{
   if (%value)
      %this.setDebugOn(1);
   else
      %this.setDebugOff(1);
}

function t2dSceneGraph::setShowLinkPoints(%this, %value)
{
   if (%value)
      %this.setDebugOn(2);
   else
      %this.setDebugOff(2);
}

function t2dSceneGraph::setShowWorldLimits(%this, %value)
{
   if (%value)
      %this.setDebugOn(4);
   else
      %this.setDebugOff(4);
}

function t2dSceneGraph::setShowCollisionBounds(%this, %value)
{
   if (%value)
      %this.setDebugOn(5);
   else
      %this.setDebugOff(5);
}

function t2dSceneGraph::setShowContactHistory(%this, %value)
{
   if (%value)
      %this.setDebugOn(6);
   else
      %this.setDebugOff(6);
}


function t2dSceneGraph::setShowSortPoints(%this, %value)
{
   if (%value)
      %this.setDebugOn(7);
   else
      %this.setDebugOff(7);
}

function t2dSceneGraph::getShowDebugBanner(%this)
{
   return %this.getDebugOn(0);
}

function t2dSceneGraph::getShowBoundingBoxes(%this)
{
   return %this.getDebugOn(1);
}

function t2dSceneGraph::getShowLinkPoints(%this)
{
   return %this.getDebugOn(2);
}

function t2dSceneGraph::getShowWorldLimits(%this)
{
   return %this.getDebugOn(4);
}

function t2dSceneGraph::getShowCollisionBounds(%this)
{
   return %this.getDebugOn(5);
}

function t2dSceneGraph::getShowContactHistory(%this)
{
   return %this.getDebugOn(6);
}

function t2dSceneGraph::getShowSortPoints(%this)
{
   return %this.getDebugOn(7);
}
