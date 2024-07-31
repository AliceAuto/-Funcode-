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
   
   %scriptingRollout = %base.createRolloutStack("程序接口");
   
   %hiddenCheck = %base @ ".object.getClassName() $= \"t2dTileLayer\"";
   %hiddenCheck = %hiddenCheck @ ";";
   //%hidden = %scriptingRollout.createHideableStack( %hiddenCheck );
   //%hidden.createCheckBox("Persistent", "保留至每个地图", "保留该物体至每个新建的地图.");
   
   //%scriptingRollout.createT2DDatablockList("ConfigDatablock", "配置数据块(DataBlock)", "t2dSceneObjectdatablock", "给该物体设置一个默认数据块");   
   %scriptingRollout.createTextEdit("Name", "TEXT", "名字", "程序中使用的名字");
   //%scriptingRollout.createTextEdit("ClassNamespace", "TEXT", "类别(可选)", "归类作用");
   //%scriptingRollout.createTextEdit("SuperClassNamespace", "TEXT", "父类别(可选)", "可以由父类别继承下来");
   //%scriptingRollout.createCheckBox("UseMouseEvents", "使用鼠标事件", "允许该物体与鼠标交互.");
   
   %sceneObjectRollout = %base.createRolloutStack("基本属性", true);
   %sceneObjectRollout.createTextEdit2("PositionX", "PositionY", 3, "位置", "X", "Y", "位置", true);
   %sceneObjectRollout.createTextEdit2("Width", "Height", 3, "大小", "宽", "高", "大小", true);
   
   %hiddenCheck = %base @ ".object.getClassName() $= \"t2dPath\"";
   %hiddenCheck = %hiddenCheck @ " || " @ %base @ ".object.getClassName() $= \"t2dShape3D\"";
   %hiddenCheck = %hiddenCheck @ ";";
   %hidden = %sceneObjectRollout.createHideableStack( %hiddenCheck );
   %hidden.createTextEdit ("rotation", 3, "朝向", "旋转角度", true);
   %hidden.createTextEdit ("autorotation", 3, "自动旋转", "自动旋转速度");

   %hiddenCheck = %base @ ".object.getClassName() $= \"t2dTileLayer\"";
   %hiddenCheck = %hiddenCheck @ " || " @ %base @ ".object.getClassName() $= \"t2dParticleEffect\"";
   %hiddenCheck = %hiddenCheck @ " || " @ %base @ ".object.getClassName() $= \"t2dTrigger\"";
   %hiddenCheck = %hiddenCheck @ " || " @ %base @ ".object.getClassName() $= \"t2dPath\"";
   %hiddenCheck = %hiddenCheck @ " || " @ %base @ ".object.getClassName() $= \"t2dShape3D\"";
   %hiddenCheck = %hiddenCheck @ ";";
   %hidden = %sceneObjectRollout.createHideableStack( %hiddenCheck );
   %hidden.createCheckBox ("FlipX", "水平翻转", "水平翻转", true);
   %hidden.createCheckBox ("FlipY", "垂直翻转", "垂直翻转", true);
   
   //%sceneObjectRollout.createTextEdit2("SortPointX", "SortPointY", 3, "排序点", "X", "Y", "图片显示顺序的排序依据.", true);
   %sceneObjectRollout.createLeftRightEdit("Layer", "0;", "31;", 1, "层", "显示的层级");
   //%sceneObjectRollout.createLeftRightEdit("GraphGroup", "0;", "31;", 1, "组", "图像组");
   %sceneObjectRollout.createLeftRight("moveBackwardInLayer", "moveForwardInLayer", "后置/前置", "在同一层级中进行前置或后置.");
   %sceneObjectRollout.createCheckBox ("Visible", "可见", "显示或者隐藏");
   
   %hiddenCheck = %base @ ".object.getClassName() $= \"t2dParticleEffect\"";
   %hiddenCheck = %hiddenCheck @ " || " @ %base @ ".object.getClassName() $= \"t2dTileLayer\"";
   %hiddenCheck = %hiddenCheck @ " || " @ %base @ ".object.getClassName() $= \"t2dPath\"";
   %hiddenCheck = %hiddenCheck @ ";";
   %hidden = %sceneObjectRollout.createHideableStack( %hiddenCheck );
   %hidden.createTextEdit ("Lifetime", 3, "生命周期", "生命周期结束自动删除，单位秒");
   
   //%alignRollout = %base.createRolloutStack( "对齐", false );
   //%alignRollout.createAlignTools( true );
      
   %pathNodeCountCommand = %base @ ".object.getAttachedToPath().getNodeCount() - 1;";
   %pathedStack = %base.createHideableStack("!" @ %base @ ".object.getAttachedToPath();");
   %pathedRollout = %pathedStack.createRolloutStack("寻路");
   %pathedRollout.createLeftRightEdit("PathStartNode", "0;", %pathNodeCountCommand, 1, "起始点", "该精灵寻路的起始点.");
   %pathedRollout.createLeftRightEdit("PathEndNode", "0;", %pathNodeCountCommand, 1, "终止点", "该精灵寻路的终止点.");
   %pathedRollout.createTextEdit("PathSpeed", 3, "速度", "跟随路径移动的速度.");
   %pathedRollout.createCheckBox("PathMoveForward", "向前移动", "直接向前移动.");
   %pathedRollout.createCheckBox("PathOrient", "朝向该路径", "旋转该精灵至与路径方向一致.");
   %pathedRollout.createTextEdit("PathRotationOffset", 3, "旋转偏移", "在路径上旋转的偏移.");
   %pathedRollout.createTextEdit("PathLoops", 0, "循环移动", "循环移动次数.");
   %pathedRollout.createEnumList("PathFollowMode", false, "跟随模式", "移动到终点的跟随路径模式.", "t2dPath", "pathModeEnum");
   
   %hiddenCheck = %base @ ".object.getClassName() $= \"t2dPath\"";
   %hiddenCheck = %hiddenCheck @ ";";
   %hidden = %base.createHideableStack( %hiddenCheck );
   %collisionRollout = %hidden.createRolloutStack("碰撞");
   
   %hiddenCheck = %base @ ".object.getClassName() $= \"t2dTileLayer\"";
   %hiddenCheck = %hiddenCheck @ ";";
   %hidden = %collisionRollout.createHideableStack( %hiddenCheck );
   %hidden.createCheckBox("collisionActiveSend", "发送碰撞", "与其它精灵接触时，将主动与别的精灵产生碰撞.");
   
   %collisionRollout.createCheckBox("collisionActiveReceive", "接受碰撞", "与其它精灵接触时，将接受别的精灵发送的碰撞.");
   %collisionRollout.createCheckBox("collisionPhysicsSend", "发送物理碰撞", "与其它精灵接触时，将使用物理主动与别的精灵产生碰撞.");
   %collisionRollout.createCheckBox("collisionPhysicsReceive", "接受物理碰撞", "与其它精灵接触时，将接受别的精灵发送的物理碰撞.");
   //%collisionRollout.createCheckBox("collisionCallback", "碰撞响应", "接收脚本碰撞响应.");
   
   //%hiddenCheck = %base @ ".object.getClassName() $= \"t2dTileLayer\"";
   //%hiddenCheck = %hiddenCheck @ ";";
   //%hidden = %collisionRollout.createHideableStack( %hiddenCheck );
   //%collisionDectionList = %hidden.createEnumList("collisionDetection", false, "碰撞检测模式", "模式：全部、圆形、多边形、自定义", "t2dSceneObject", "collisionDetectionMode");
      
   %circleCollisionContainer = %collisionRollout.createHideableStack(%base @ ".object.getCollisionDetection() !$= \"CIRCLE\";");
   %circleCollisionContainer.addControlDependency(%collisionDectionList);
   //%circleCollisionContainer.createTextEdit("collisionCircleScale", 3, "循环缩放", "循环缩放碰撞.");
   //%circleCollisionContainer.createCheckBox("collisionCircleSuperscribed", "圆形碰撞", "沿着边界合周围进行碰撞.");
   
   %collisionRollout.createDropDownList("collisionResponse", "物理碰撞反应", "", "OFF\tCLAMP\tBOUNCE\tSTICKY\tKILL\tRIGID\tCUSTOM","分别为：关闭、停渐、反弹、静止、删除、刚体、自定义");
   %collisionRollout.createMask        ("CollisionLayers", "碰撞的层级", 0, 31, "更改此精灵可以进行碰撞的层级.");
   //%collisionRollout.createMask        ("CollisionGroups", "碰撞的组", 0, 31, "更改此物体可以进行碰撞的组.");

   %hiddenCheck = %base @ ".object.getClassName() $= \"t2dPath\"";
   %hiddenCheck = %hiddenCheck @ ";";
   %hidden = %base.createHideableStack( %hiddenCheck );
   %physicsRollout = %hidden.createRolloutStack("物理");
   
   %physicsRollout.createTextEdit2("linearVelocityX", "linearVelocityY", 3, "速度", "X", "Y", "直线速度");
   %physicsRollout.createTextEdit2("minLinearVelocity", "maxLinearVelocity", 3, "", "最小", "最大", "最小直线速度");
   %physicsRollout.createTextEdit ("AngularVelocity", 3, "角速度", "按角度旋转速度");
   %physicsRollout.createTextEdit2("minAngularVelocity", "maxAngularVelocity", 3, "", "最小", "最大", "最小角速度");
   //%physicsRollout.createCheckBox ("immovable", "不可移动", "是否允许该物体移动.");
   //%physicsRollout.createCheckBox ("forwardMovementOnly", "只允许向前移动", "该物体只能朝前面移动.");
   %physicsRollout.createTextEdit2("constantForceX", "constantForceY", 3, "常力", "X", "Y", "一直作用于此精灵的力量");
   //%physicsRollout.createCheckBox ("graviticConstantForce", "重力", "该物体所受的重力常量.");
   //%physicsRollout.createTextEdit ("forceScale", 3, "受力缩放", "对自身受的作用力进行大小缩放.");
   
   //%autoMassInertiaCheck = %physicsRollout.createCheckBox ("autoMassInertia", "计算质量与惯性", "要求引擎根据大小与密度计算质量与惯性.");
   
   //%autoMassInertiaContainer = %physicsRollout.createHideableStack(%base @ ".object.getAutoMassInertia();");
   //%autoMassInertiaContainer.addControlDependency(%autoMassInertiaCheck);
   //%autoMassInertiaContainer.createTextEdit("mass", 3, "质量", "质量");
   //%autoMassInertiaContainer.createTextEdit("inertialMoment", 3, "惯性", "惯性力");
   
   //%physicsRollout.createTextEdit("density", 3, "密度", "密度");
   //%physicsRollout.createTextEdit("damping", 3, "衰减", "衰减");
   //%physicsRollout.createTextEdit("friction", 3, "摩擦力", "摩擦力");
   //%physicsRollout.createTextEdit("restitution", 3, "回复力", "回复力");
   
   %mountingRollout = %base.createRolloutStack("挂接");
   %mountingRollout.createTextEdit("mountRotation", 3, "朝向", "挂接朝向");
   %mountingRollout.createTextEdit("autoMountRotation", 3, "自动旋转", "在挂接点自动旋转");
   
   %mountingContainer = %mountingRollout.createHideableStack("!" @ %base @ ".object.getIsMounted();");
   //%mountingContainer.createTextEdit("mountForce", 3, "挂接作用力", "给挂接者额外的作用力");
   %mountingContainer.createCheckBox("mountTrackRotation", "跟随旋转", "跟随挂接者旋转.");
   %mountingContainer.createCheckBox("mountOwned", "由挂接者控制", "被控制，如挂接者消失，其跟着消失.");
   %mountingContainer.createCheckBox("mountInheritAttributes", "继承属性", "继承挂接者的属性.");
   
   %worldLimitRollout = %base.createRolloutStack("世界边界限制");
   %worldLimitList = %worldLimitRollout.createDropDownList("worldLimitMode", "限制模式", "", "OFF\tNULL\tCLAMP\tBOUNCE\tSTICKY\tKILL", "分别为：关闭、自定义、渐停、反弹、静止、删除");
   
	  %worldLimitContainer = %worldLimitRollout.createHideableStack("(" @ %base @ ".object.getWorldLimitMode() $= \"OFF\");");
   %worldLimitContainer.addControlDependency(%worldLimitList);
   %worldLimitContainer.createTextEdit2("WorldLimitMinX", "WorldLimitMinY", 3, "边界左上角坐标", "X", "Y", "世界边界的左侧和上方的坐标值", true);
   %worldLimitContainer.createTextEdit2("WorldLimitMaxX", "WorldLimitMaxY", 3, "边界右下角坐标", "X", "Y", "世界边界的右侧和下方的坐标值", true);
   //%worldLimitContainer.createCheckBox ("WorldLimitCallback", "响应", "接受边界碰撞的脚本响应.");
   
   %hiddenCheck = %base @ ".object.getClassName() $= \"t2dPath\"";
   %hiddenCheck = %hiddenCheck @ " || " @ %base @ ".object.getClassName() $= \"t2dParticleEffect\"";
   %hiddenCheck = %hiddenCheck @ " || " @ %base @ ".object.getClassName() $= \"t2dTrigger\"";
   %hiddenCheck = %hiddenCheck @ ";";
   %hidden = %base.createHideableStack( %hiddenCheck );
   %blendingRollout = %hidden.createRolloutStack("后期颜色处理");
   %blendingEnabledCheck = %blendingRollout.createCheckBox("BlendingStatus", "开启", "开启后期颜色处理");
   
   %blendingContainer = %blendingRollout.createHideableStack("!" @ %base @ ".object.getBlendingStatus();");
   %blendingContainer.addControlDependency(%blendingEnabledCheck);
   %blendingContainer.createEnumList("SrcBlendFactor", false, "源混合因子", "源混合因子", "t2dSceneObject", "srcBlendFactor");
   %blendingContainer.createEnumList("DstBlendFactor", false, "目标混合因子", "目标混合因子", "t2dSceneObject", "dstBlendFactor");
   %blendingContainer.createColorPicker("BlendColor", "后期颜色处理", "后期颜色处理");
   
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
