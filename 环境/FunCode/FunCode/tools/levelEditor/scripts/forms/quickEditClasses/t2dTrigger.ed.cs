//-----------------------------------------------------------------------------
// LevelBuilder Quick Edit t2dSceneObject Class
// Copyright (C) GarageGames.com, Inc.
//-----------------------------------------------------------------------------

//-----------------------------------------------------------------------------
// Register Form Content.
//-----------------------------------------------------------------------------
GuiFormManager::AddFormContent( "LevelBuilderQuickEditClasses", "t2dTrigger", "LBQETrigger::CreateContent", "LBQETrigger::SaveContent", 2 );

//-----------------------------------------------------------------------------
// Form Content Creation Function
//-----------------------------------------------------------------------------
function LBQETrigger::CreateContent( %contentCtrl, %quickEditObj )
{
   %base = %contentCtrl.createBaseStack("LBQETriggerClass", %quickEditObj);
   %rollout = %base.createRolloutStack("触发器", true);  
   //%rollout.createCheckBox("enterCallback", "Enter Callback", "Receive Notifications of Objects Entering The Trigger Area");
   //%rollout.createCheckBox("stayCallback", "Stay Callback", "Receive Notifications of Objects Staying in The Trigger Area");
   //%rollout.createCheckBox("leaveCallback", "Leave Callback", "Receive Notifications of Objects Leaving The Trigger Area");
   %rollout.createCheckBox("enterCallback", "进入时触发", "当有精灵进入触发器内部时，触发对应功能");
   %rollout.createCheckBox("stayCallback", "停留时触发", "当有精灵停留在触发器内部时，触发对应功能");
   %rollout.createCheckBox("leaveCallback", "离开时触发", "当有精灵离开触发器时，触发对应功能");
   
   // Return Ref to Base.
   return %base;
}

//-----------------------------------------------------------------------------
// Form Content Save Function
//-----------------------------------------------------------------------------
function LBQETrigger::SaveContent( %contentCtrl )
{
   // Nothing.
}
