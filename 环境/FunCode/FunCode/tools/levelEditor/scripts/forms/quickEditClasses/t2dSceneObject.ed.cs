//-----------------------------------------------------------------------------
// LevelBuilder Quick Edit t2dSceneObject Class
// Copyright (C) GarageGames.com, Inc.
//-----------------------------------------------------------------------------

//-----------------------------------------------------------------------------
// Register Form Content.
//-----------------------------------------------------------------------------
GuiFormManager::AddFormContent( "LevelBuilderQuickEditClasses", "t2dSceneObject", "LBQESceneObject::CreateContent", "LBQESceneObject::SaveContent", 2 );

//-----------------------------------------------------------------------------
// Form Content Creation Function
//-----------------------------------------------------------------------------
function LBQESceneObject::CreateContent( %contentCtrl, %quickEditObj )
{
   %base = %contentCtrl.createBaseStack("LBQESceneObjectClass", %quickEditObj);
   
   %scriptingRollout = %base.createRolloutStack("����ӿ�");
   
   %hiddenCheck = %base @ ".object.getClassName() $= \"t2dTileLayer\"";
   %hiddenCheck = %hiddenCheck @ ";";
   //%hidden = %scriptingRollout.createHideableStack( %hiddenCheck );
   //%hidden.createCheckBox("Persistent", "������ÿ����ͼ", "������������ÿ���½��ĵ�ͼ.");
   
   //%scriptingRollout.createT2DDatablockList("ConfigDatablock", "�������ݿ�(DataBlock)", "t2dSceneObjectdatablock", "������������һ��Ĭ�����ݿ�");   
   %scriptingRollout.createTextEdit("Name", "TEXT", "����", "������ʹ�õ�����");
   //%scriptingRollout.createTextEdit("ClassNamespace", "TEXT", "���(��ѡ)", "��������");
   //%scriptingRollout.createTextEdit("SuperClassNamespace", "TEXT", "�����(��ѡ)", "�����ɸ����̳�����");
   //%scriptingRollout.createCheckBox("UseMouseEvents", "ʹ������¼�", "�������������꽻��.");
   
   %sceneObjectRollout = %base.createRolloutStack("��������", true);
   %sceneObjectRollout.createTextEdit2("PositionX", "PositionY", 3, "λ��", "X", "Y", "λ��", true);
   %sceneObjectRollout.createTextEdit2("Width", "Height", 3, "��С", "��", "��", "��С", true);
   
   %hiddenCheck = %base @ ".object.getClassName() $= \"t2dPath\"";
   %hiddenCheck = %hiddenCheck @ " || " @ %base @ ".object.getClassName() $= \"t2dShape3D\"";
   %hiddenCheck = %hiddenCheck @ ";";
   %hidden = %sceneObjectRollout.createHideableStack( %hiddenCheck );
   %hidden.createTextEdit ("rotation", 3, "����", "��ת�Ƕ�", true);
   %hidden.createTextEdit ("autorotation", 3, "�Զ���ת", "�Զ���ת�ٶ�");

   %hiddenCheck = %base @ ".object.getClassName() $= \"t2dTileLayer\"";
   %hiddenCheck = %hiddenCheck @ " || " @ %base @ ".object.getClassName() $= \"t2dParticleEffect\"";
   %hiddenCheck = %hiddenCheck @ " || " @ %base @ ".object.getClassName() $= \"t2dTrigger\"";
   %hiddenCheck = %hiddenCheck @ " || " @ %base @ ".object.getClassName() $= \"t2dPath\"";
   %hiddenCheck = %hiddenCheck @ " || " @ %base @ ".object.getClassName() $= \"t2dShape3D\"";
   %hiddenCheck = %hiddenCheck @ ";";
   %hidden = %sceneObjectRollout.createHideableStack( %hiddenCheck );
   %hidden.createCheckBox ("FlipX", "ˮƽ��ת", "ˮƽ��ת", true);
   %hidden.createCheckBox ("FlipY", "��ֱ��ת", "��ֱ��ת", true);
   
   //%sceneObjectRollout.createTextEdit2("SortPointX", "SortPointY", 3, "�����", "X", "Y", "ͼƬ��ʾ˳�����������.", true);
   %sceneObjectRollout.createLeftRightEdit("Layer", "0;", "31;", 1, "��", "��ʾ�Ĳ㼶");
   //%sceneObjectRollout.createLeftRightEdit("GraphGroup", "0;", "31;", 1, "��", "ͼ����");
   %sceneObjectRollout.createLeftRight("moveBackwardInLayer", "moveForwardInLayer", "����/ǰ��", "��ͬһ�㼶�н���ǰ�û����.");
   %sceneObjectRollout.createCheckBox ("Visible", "�ɼ�", "��ʾ��������");
   
   %hiddenCheck = %base @ ".object.getClassName() $= \"t2dParticleEffect\"";
   %hiddenCheck = %hiddenCheck @ " || " @ %base @ ".object.getClassName() $= \"t2dTileLayer\"";
   %hiddenCheck = %hiddenCheck @ " || " @ %base @ ".object.getClassName() $= \"t2dPath\"";
   %hiddenCheck = %hiddenCheck @ ";";
   %hidden = %sceneObjectRollout.createHideableStack( %hiddenCheck );
   %hidden.createTextEdit ("Lifetime", 3, "��������", "�������ڽ����Զ�ɾ������λ��");
   
   //%alignRollout = %base.createRolloutStack( "����", false );
   //%alignRollout.createAlignTools( true );
      
   %pathNodeCountCommand = %base @ ".object.getAttachedToPath().getNodeCount() - 1;";
   %pathedStack = %base.createHideableStack("!" @ %base @ ".object.getAttachedToPath();");
   %pathedRollout = %pathedStack.createRolloutStack("Ѱ·");
   %pathedRollout.createLeftRightEdit("PathStartNode", "0;", %pathNodeCountCommand, 1, "��ʼ��", "�þ���Ѱ·����ʼ��.");
   %pathedRollout.createLeftRightEdit("PathEndNode", "0;", %pathNodeCountCommand, 1, "��ֹ��", "�þ���Ѱ·����ֹ��.");
   %pathedRollout.createTextEdit("PathSpeed", 3, "�ٶ�", "����·���ƶ����ٶ�.");
   %pathedRollout.createCheckBox("PathMoveForward", "��ǰ�ƶ�", "ֱ����ǰ�ƶ�.");
   %pathedRollout.createCheckBox("PathOrient", "�����·��", "��ת�þ�������·������һ��.");
   %pathedRollout.createTextEdit("PathRotationOffset", 3, "��תƫ��", "��·������ת��ƫ��.");
   %pathedRollout.createTextEdit("PathLoops", 0, "ѭ���ƶ�", "ѭ���ƶ�����.");
   %pathedRollout.createEnumList("PathFollowMode", false, "����ģʽ", "�ƶ����յ�ĸ���·��ģʽ.", "t2dPath", "pathModeEnum");
   
   %hiddenCheck = %base @ ".object.getClassName() $= \"t2dPath\"";
   %hiddenCheck = %hiddenCheck @ ";";
   %hidden = %base.createHideableStack( %hiddenCheck );
   %collisionRollout = %hidden.createRolloutStack("��ײ");
   
   %hiddenCheck = %base @ ".object.getClassName() $= \"t2dTileLayer\"";
   %hiddenCheck = %hiddenCheck @ ";";
   %hidden = %collisionRollout.createHideableStack( %hiddenCheck );
   %hidden.createCheckBox("collisionActiveSend", "������ײ", "����������Ӵ�ʱ�����������ľ��������ײ.");
   
   %collisionRollout.createCheckBox("collisionActiveReceive", "������ײ", "����������Ӵ�ʱ�������ܱ�ľ��鷢�͵���ײ.");
   %collisionRollout.createCheckBox("collisionPhysicsSend", "����������ײ", "����������Ӵ�ʱ����ʹ�������������ľ��������ײ.");
   %collisionRollout.createCheckBox("collisionPhysicsReceive", "����������ײ", "����������Ӵ�ʱ�������ܱ�ľ��鷢�͵�������ײ.");
   //%collisionRollout.createCheckBox("collisionCallback", "��ײ��Ӧ", "���սű���ײ��Ӧ.");
   
   //%hiddenCheck = %base @ ".object.getClassName() $= \"t2dTileLayer\"";
   //%hiddenCheck = %hiddenCheck @ ";";
   //%hidden = %collisionRollout.createHideableStack( %hiddenCheck );
   //%collisionDectionList = %hidden.createEnumList("collisionDetection", false, "��ײ���ģʽ", "ģʽ��ȫ����Բ�Ρ�����Ρ��Զ���", "t2dSceneObject", "collisionDetectionMode");
      
   %circleCollisionContainer = %collisionRollout.createHideableStack(%base @ ".object.getCollisionDetection() !$= \"CIRCLE\";");
   %circleCollisionContainer.addControlDependency(%collisionDectionList);
   //%circleCollisionContainer.createTextEdit("collisionCircleScale", 3, "ѭ������", "ѭ��������ײ.");
   //%circleCollisionContainer.createCheckBox("collisionCircleSuperscribed", "Բ����ײ", "���ű߽����Χ������ײ.");
   
   %collisionRollout.createDropDownList("collisionResponse", "������ײ��Ӧ", "", "OFF\tCLAMP\tBOUNCE\tSTICKY\tKILL\tRIGID\tCUSTOM","�ֱ�Ϊ���رա�ͣ������������ֹ��ɾ�������塢�Զ���");
   %collisionRollout.createMask        ("CollisionLayers", "��ײ�Ĳ㼶", 0, 31, "���Ĵ˾�����Խ�����ײ�Ĳ㼶.");
   //%collisionRollout.createMask        ("CollisionGroups", "��ײ����", 0, 31, "���Ĵ�������Խ�����ײ����.");

   %hiddenCheck = %base @ ".object.getClassName() $= \"t2dPath\"";
   %hiddenCheck = %hiddenCheck @ ";";
   %hidden = %base.createHideableStack( %hiddenCheck );
   %physicsRollout = %hidden.createRolloutStack("����");
   
   %physicsRollout.createTextEdit2("linearVelocityX", "linearVelocityY", 3, "�ٶ�", "X", "Y", "ֱ���ٶ�");
   %physicsRollout.createTextEdit2("minLinearVelocity", "maxLinearVelocity", 3, "", "��С", "���", "��Сֱ���ٶ�");
   %physicsRollout.createTextEdit ("AngularVelocity", 3, "���ٶ�", "���Ƕ���ת�ٶ�");
   %physicsRollout.createTextEdit2("minAngularVelocity", "maxAngularVelocity", 3, "", "��С", "���", "��С���ٶ�");
   //%physicsRollout.createCheckBox ("immovable", "�����ƶ�", "�Ƿ�����������ƶ�.");
   //%physicsRollout.createCheckBox ("forwardMovementOnly", "ֻ������ǰ�ƶ�", "������ֻ�ܳ�ǰ���ƶ�.");
   %physicsRollout.createTextEdit2("constantForceX", "constantForceY", 3, "����", "X", "Y", "һֱ�����ڴ˾��������");
   //%physicsRollout.createCheckBox ("graviticConstantForce", "����", "���������ܵ���������.");
   //%physicsRollout.createTextEdit ("forceScale", 3, "��������", "�������ܵ����������д�С����.");
   
   //%autoMassInertiaCheck = %physicsRollout.createCheckBox ("autoMassInertia", "�������������", "Ҫ��������ݴ�С���ܶȼ������������.");
   
   //%autoMassInertiaContainer = %physicsRollout.createHideableStack(%base @ ".object.getAutoMassInertia();");
   //%autoMassInertiaContainer.addControlDependency(%autoMassInertiaCheck);
   //%autoMassInertiaContainer.createTextEdit("mass", 3, "����", "����");
   //%autoMassInertiaContainer.createTextEdit("inertialMoment", 3, "����", "������");
   
   //%physicsRollout.createTextEdit("density", 3, "�ܶ�", "�ܶ�");
   //%physicsRollout.createTextEdit("damping", 3, "˥��", "˥��");
   //%physicsRollout.createTextEdit("friction", 3, "Ħ����", "Ħ����");
   //%physicsRollout.createTextEdit("restitution", 3, "�ظ���", "�ظ���");
   
   %mountingRollout = %base.createRolloutStack("�ҽ�");
   %mountingRollout.createTextEdit("mountRotation", 3, "����", "�ҽӳ���");
   %mountingRollout.createTextEdit("autoMountRotation", 3, "�Զ���ת", "�ڹҽӵ��Զ���ת");
   
   %mountingContainer = %mountingRollout.createHideableStack("!" @ %base @ ".object.getIsMounted();");
   //%mountingContainer.createTextEdit("mountForce", 3, "�ҽ�������", "���ҽ��߶����������");
   %mountingContainer.createCheckBox("mountTrackRotation", "������ת", "����ҽ�����ת.");
   %mountingContainer.createCheckBox("mountOwned", "�ɹҽ��߿���", "�����ƣ���ҽ�����ʧ���������ʧ.");
   %mountingContainer.createCheckBox("mountInheritAttributes", "�̳�����", "�̳йҽ��ߵ�����.");
   
   %worldLimitRollout = %base.createRolloutStack("����߽�����");
   %worldLimitList = %worldLimitRollout.createDropDownList("worldLimitMode", "����ģʽ", "", "OFF\tNULL\tCLAMP\tBOUNCE\tSTICKY\tKILL", "�ֱ�Ϊ���رա��Զ��塢��ͣ����������ֹ��ɾ��");
   
	  %worldLimitContainer = %worldLimitRollout.createHideableStack("(" @ %base @ ".object.getWorldLimitMode() $= \"OFF\");");
   %worldLimitContainer.addControlDependency(%worldLimitList);
   %worldLimitContainer.createTextEdit2("WorldLimitMinX", "WorldLimitMinY", 3, "�߽����Ͻ�����", "X", "Y", "����߽�������Ϸ�������ֵ", true);
   %worldLimitContainer.createTextEdit2("WorldLimitMaxX", "WorldLimitMaxY", 3, "�߽����½�����", "X", "Y", "����߽���Ҳ���·�������ֵ", true);
   //%worldLimitContainer.createCheckBox ("WorldLimitCallback", "��Ӧ", "���ܱ߽���ײ�Ľű���Ӧ.");
   
   %hiddenCheck = %base @ ".object.getClassName() $= \"t2dPath\"";
   %hiddenCheck = %hiddenCheck @ " || " @ %base @ ".object.getClassName() $= \"t2dParticleEffect\"";
   %hiddenCheck = %hiddenCheck @ " || " @ %base @ ".object.getClassName() $= \"t2dTrigger\"";
   %hiddenCheck = %hiddenCheck @ ";";
   %hidden = %base.createHideableStack( %hiddenCheck );
   %blendingRollout = %hidden.createRolloutStack("������ɫ����");
   %blendingEnabledCheck = %blendingRollout.createCheckBox("BlendingStatus", "����", "����������ɫ����");
   
   %blendingContainer = %blendingRollout.createHideableStack("!" @ %base @ ".object.getBlendingStatus();");
   %blendingContainer.addControlDependency(%blendingEnabledCheck);
   %blendingContainer.createEnumList("SrcBlendFactor", false, "Դ�������", "Դ�������", "t2dSceneObject", "srcBlendFactor");
   %blendingContainer.createEnumList("DstBlendFactor", false, "Ŀ��������", "Ŀ��������", "t2dSceneObject", "dstBlendFactor");
   %blendingContainer.createColorPicker("BlendColor", "������ɫ����", "������ɫ����");
   
   //%dynamicFieldRollout = %base.createRolloutStack("Dynamic Fields");
   //%dynamicFieldRollout.createDynamicFieldStack();
   
   // Return Ref to Base.
   return %base;
}

//-----------------------------------------------------------------------------
// Form Content Save Function
//-----------------------------------------------------------------------------
function LBQESceneObject::SaveContent( %contentCtrl )
{
   // Nothing.
}

function t2dSceneObject::getWorldLimitMode(%this)
{
   %worldLimit = %this.getWorldLimit();
   return getWord(%worldLimit, 0);
}

function t2dSceneObject::setWorldLimitMode(%this, %mode)
{
   %worldLimit = %this.getWorldLimit();
   %this.setWorldLimit(%mode, %this.getWorldLimitMinX(), %this.getWorldLimitMinY(), %this.getWorldLimitMaxX(), %this.getWorldLimitMaxY(), %this.getWorldLimitCallback());
}

function t2dSceneObject::getWorldLimitMinX(%this)
{
   %worldLimit = %this.getWorldLimit();
   return getWord(%worldLimit, 1);
}

function t2dSceneObject::setWorldLimitMinX(%this, %val)
{
   %worldLimit = %this.getWorldLimit();
   %this.setWorldLimit(%this.getWorldLimitMode(), %val, %this.getWorldLimitMinY(), %this.getWorldLimitMaxX(), %this.getWorldLimitMaxY(), %this.getWorldLimitCallback());
}

function t2dSceneObject::getWorldLimitMinY(%this)
{
   %worldLimit = %this.getWorldLimit();
   return getWord(%worldLimit, 2);
}

function t2dSceneObject::setWorldLimitMinY(%this, %val)
{
   %worldLimit = %this.getWorldLimit();
   %this.setWorldLimit(%this.getWorldLimitMode(), %this.getWorldLimitMinX(), %val, %this.getWorldLimitMaxX(), %this.getWorldLimitMaxY(), %this.getWorldLimitCallback());
}

function t2dSceneObject::getWorldLimitMaxX(%this)
{
   %worldLimit = %this.getWorldLimit();
   return getWord(%worldLimit, 3);
}

function t2dSceneObject::setWorldLimitMaxX(%this, %val)
{
   %worldLimit = %this.getWorldLimit();
   %this.setWorldLimit(%this.getWorldLimitMode(), %this.getWorldLimitMinX(), %this.getWorldLimitMinY(), %val, %this.getWorldLimitMaxY(), %this.getWorldLimitCallback());
}

function t2dSceneObject::getWorldLimitMaxY(%this)
{
   %worldLimit = %this.getWorldLimit();
   return getWord(%worldLimit, 4);
}

function t2dSceneObject::setWorldLimitMaxY(%this, %val)
{
   %worldLimit = %this.getWorldLimit();
   %this.setWorldLimit(%this.getWorldLimitMode(), %this.getWorldLimitMinX(), %this.getWorldLimitMinY(), %this.getWorldLimitMaxX(), %val, %this.getWorldLimitCallback());
}

function t2dSceneObject::getWorldLimitCallback(%this)
{
   %worldLimit = %this.getWorldLimit();
   return getWord(%worldLimit, 5);
}

function t2dSceneObject::setWorldLimitCallback(%this, %callback)
{
   %worldLimit = %this.getWorldLimit();
   %this.setWorldLimit(%this.getWorldLimitMode(), %this.getWorldLimitMinX(), %this.getWorldLimitMinY(), %this.getWorldLimitMaxX(), %this.getWorldLimitMaxY(), %callback);
}

function t2dSceneObject::setPathStartNode(%this, %value)
{
   if (%this.getAttachedToPath())
      %this.getAttachedToPath().setStartNode(%this, %value);
}

function t2dSceneObject::getPathStartNode(%this)
{
   if (%this.getAttachedToPath())
      return %this.getAttachedToPath().getStartNode(%this);
   else
      return 0;
}

function t2dSceneObject::setPathEndNode(%this, %value)
{
   if (%this.getAttachedToPath())
      %this.getAttachedToPath().setEndNode(%this, %value);
}

function t2dSceneObject::getPathEndNode(%this)
{
   if (%this.getAttachedToPath())
      return %this.getAttachedToPath().getEndNode(%this);
   else
      return 0;
}

function t2dSceneObject::setPathSpeed(%this, %value)
{
   if (%this.getAttachedToPath())
      %this.getAttachedToPath().setSpeed(%this, %value);
}

function t2dSceneObject::getPathSpeed(%this)
{
   if (%this.getAttachedToPath())
      return %this.getAttachedToPath().getSpeed(%this);
   else
      return 0;
}

function t2dSceneObject::setPathMoveForward(%this, %value)
{
   if (%this.getAttachedToPath())
      %this.getAttachedToPath().setMoveForward(%this, %value);
}

function t2dSceneObject::getPathMoveForward(%this)
{
   if (%this.getAttachedToPath())
      return %this.getAttachedToPath().getMoveForward(%this);
   else
      return 0;
}

function t2dSceneObject::setPathOrient(%this, %value)
{
   if (%this.getAttachedToPath())
      %this.getAttachedToPath().setOrient(%this, %value);
}

function t2dSceneObject::getPathOrient(%this)
{
   if (%this.getAttachedToPath())
      return %this.getAttachedToPath().getOrient(%this);
   else
      return 0;
}

function t2dSceneObject::setPathRotationOffset(%this, %value)
{
   if (%this.getAttachedToPath())
      %this.getAttachedToPath().setRotationOffset(%this, %value);
}

function t2dSceneObject::getPathRotationOffset(%this)
{
   if (%this.getAttachedToPath())
      return %this.getAttachedToPath().getRotationOffset(%this);
   else
      return 0;
}

function t2dSceneObject::setPathLoops(%this, %value)
{
   if (%this.getAttachedToPath())
      %this.getAttachedToPath().setLoops(%this, %value);
}

function t2dSceneObject::getPathLoops(%this)
{
   if (%this.getAttachedToPath())
      return %this.getAttachedToPath().getLoops(%this);
   else
      return 0;
}

function t2dSceneObject::setPathFollowMode(%this, %value)
{
   if (%this.getAttachedToPath())
      %this.getAttachedToPath().setFollowMode(%this, %value);
}

function t2dSceneObject::getPathFollowMode(%this)
{
   if (%this.getAttachedToPath())
      return %this.getAttachedToPath().getFollowMode(%this);
   else
      return 0;
}

function t2dSceneObject::moveForwardInLayer(%this)
{
   %scenegraph = ToolManager.getLastWindow().getSceneGraph();
   return %scenegraph.setLayerDrawOrder(%this, "FORWARD");
}

function t2dSceneObject::moveBackwardInLayer(%this)
{
   %scenegraph = ToolManager.getLastWindow().getSceneGraph();
   return %scenegraph.setLayerDrawOrder(%this, "BACKWARD");
}
