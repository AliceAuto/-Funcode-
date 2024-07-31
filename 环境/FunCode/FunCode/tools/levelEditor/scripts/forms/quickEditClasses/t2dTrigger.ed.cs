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
   %rollout = %base.createRolloutStack("������", true);  
   //%rollout.createCheckBox("enterCallback", "Enter Callback", "Receive Notifications of Objects Entering The Trigger Area");
   //%rollout.createCheckBox("stayCallback", "Stay Callback", "Receive Notifications of Objects Staying in The Trigger Area");
   //%rollout.createCheckBox("leaveCallback", "Leave Callback", "Receive Notifications of Objects Leaving The Trigger Area");
   %rollout.createCheckBox("enterCallback", "����ʱ����", "���о�����봥�����ڲ�ʱ��������Ӧ����");
   %rollout.createCheckBox("stayCallback", "ͣ��ʱ����", "���о���ͣ���ڴ������ڲ�ʱ��������Ӧ����");
   %rollout.createCheckBox("leaveCallback", "�뿪ʱ����", "���о����뿪������ʱ��������Ӧ����");
   
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
