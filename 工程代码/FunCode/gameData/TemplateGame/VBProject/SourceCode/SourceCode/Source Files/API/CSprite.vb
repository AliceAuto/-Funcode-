'/ <summary>
'/ 类：CSprite
'/ 所有精灵的基类。包括下面的静态精灵，动态精灵，文字，特效等均由此类继承下去
'/ 一般的图片精灵从本类继承下去即可。只有特殊的精灵，比如带动画的精灵，才需要从动态精灵继承下去
'/ </summary>
Public Class CSprite
    Private m_szName As String ' 精灵名字() 

    '/ <summary>
    '/ 构造函数，需要传入一个非空的精灵名字字符串。如果传入的是地图里摆放好的精灵名字，则此类即与地图里的精灵绑定
    '/ 如果传入的是一个新的精灵名字，则需要调用成员函数 CloneSprite，复制一份精灵对象实例，才与实际的地图精灵关联起来
    '/ </summary>
    Public Sub New(ByVal szName As String)
        m_szName = szName
    End Sub

    '/ <summary>
    '/ GetName
    '/ 返回值：返回精灵名字
    '/ </summary>
    Public Function GetName() As String
        Return m_szName
    End Function

    '/ <summary>
    '/ CloneSprite：复制(创建)一个精灵。精灵的创建方式：先在地图中摆放一个精灵做为模板，设置好各项参数，然后在代码里使用此函数克隆一个实例
    '/ 返回值：true表示克隆成功，false克隆失败。失败的原因可能是在地图中未找到对应名字的精灵
    '/ 参数 szSrcName：地图中用做模板的精灵名字
    '/ </summary>
    Public Function CloneSprite(ByVal szSrcName As String) As Boolean
        Return CommonAPI.dCloneSprite(szSrcName, GetName())
    End Function

    '/ <summary>
    '/ DeleteSprite：在地图中删除与本对象实例关联的精灵
    '/ </summary>
    Public Sub DeleteSprite()
        CommonAPI.dDeleteSprite(GetName())
    End Sub

    '/ <summary>
    '/ SetSpriteVisible：设置精灵隐藏或者显示(可见不可见)
    '/ 参数 bVisible：true 可见 false不可见
    '/ </summary>
    Public Sub SetSpriteVisible(ByVal bVisible As Boolean)
        CommonAPI.dSetSpriteVisible(GetName(), bVisible)
    End Sub

    '/ <summary>
    '/ IsSpriteVisible：获取该精灵当前是否可见
    '/ </summary>
    Public Function IsSpriteVisible() As Boolean
        Return CommonAPI.dIsSpriteVisible(GetName())
    End Function

    '/ <summary>
    '/ SetSpriteEnable：禁止或者启用该精灵。被禁止的精灵将不参与任何响应，包括不移动，没有碰撞等，仅仅是在地图中显示
    '/ 参数 bEnable：true启用 false禁止
    '/ </summary>
    Public Sub SetSpriteEnable(ByVal bEnable As Boolean)
        CommonAPI.dSetSpriteEnable(GetName(), bEnable)
    End Sub

    '/ <summary>
    '/ SetSpriteScale：设置精灵的缩放值
    '/ 参数 fScale：缩放值。大于0的值
    '/ </summary>
    Public Sub SetSpriteScale(ByVal fScale As Single)
        CommonAPI.dSetSpriteScale(GetName(), fScale)
    End Sub

    '/ <summary>
    '/ IsPointInSprite：判断某个坐标点是否位于精灵内部
    '/ 参数 fPosX：X坐标点
    '/ 参数 fPosY：Y坐标点
    '/ </summary>
    Public Function IsPointInSprite(ByVal fPosX As Single, ByVal fPosY As Single) As Boolean
        Return CommonAPI.dIsPointInSprite(GetName(), fPosX, fPosY)
    End Function

    '/ <summary>
    '/ SetSpritePosition：设置精灵位置
    '/ 参数 fPosX：X坐标
    '/ 参数 fPosY：Y坐标
    '/ </summary>
    Public Sub SetSpritePosition(ByVal fPosX As Single, ByVal fPosY As Single)
        CommonAPI.dSetSpritePosition(GetName(), fPosX, fPosY)
    End Sub

    '/ <summary>
    '/ SetSpritePositionX：只设置精灵X坐标
    '/ 参数 fPosX：X坐标
    '/ </summary>
    Public Sub SetSpritePositionX(ByVal fPosX As Single)
        CommonAPI.dSetSpritePositionX(GetName(), fPosX)
    End Sub

    '/ <summary>
    '/ SetSpritePositionY：只设置精灵Y坐标
    '/ 参数 fPosY：Y坐标
    '/ </summary>
    Public Sub SetSpritePositionY(ByVal fPosY As Single)
        CommonAPI.dSetSpritePositionY(GetName(), fPosY)
    End Sub

    '/ <summary>
    '/ GetSpritePositionX：获取精灵X坐标
    '/ 返回值：精灵的X坐标
    '/ </summary>
    Public Function GetSpritePositionX() As Single
        Return CommonAPI.dGetSpritePositionX(GetName())
    End Function

    '/ <summary>
    '/ GetSpritePositionY：获取精灵Y坐标
    '/ 返回值：精灵的Y坐标
    '/ </summary>
    Public Function GetSpritePositionY() As Single
        Return CommonAPI.dGetSpritePositionY(GetName())
    End Function

    '/ <summary>
    '/ GetSpriteLinkPointPosX：获取精灵链接点X坐标。链接点是依附于精灵的一个坐标点，可以在编辑器里增加或者删除
    '/ 参数 iId：链接点序号，第一个为1，后面依次递加
    '/ </summary>
    Public Function GetSpriteLinkPointPosX(ByVal iId As Integer) As Single
        Return CommonAPI.dGetSpriteLinkPointPosX(GetName(), iId)
    End Function

    '/ <summary>
    '/ GetSpriteLinkPointPosY：获取精灵链接点Y坐标。链接点是依附于精灵的一个坐标点，可以在编辑器里增加或者删除
    '/ 参数 iId：链接点序号，第一个为1，后面依次递加
    '/ </summary>
    Public Function GetSpriteLinkPointPosY(ByVal iId As Integer) As Single
        Return CommonAPI.dGetSpriteLinkPointPosY(GetName(), iId)
    End Function

    '/ <summary>
    '/ SetSpriteRotation：设置精灵的旋转角度
    '/ 参数 fRot：旋转角度，范围0 - 360
    '/ </summary>
    Public Sub SetSpriteRotation(ByVal fRot As Single)
        CommonAPI.dSetSpriteRotation(GetName(), fRot)
    End Sub

    '/ <summary>
    '/ GetSpriteRotation：获取精灵的旋转角度
    '/ 返回值：精灵的旋转角度
    '/ </summary>
    Public Function GetSpriteRotation() As Single
        Return CommonAPI.dGetSpriteRotation(GetName())
    End Function

    '/ <summary>
    '/ SetSpriteAutoRot：设置精灵按照指定速度自动旋转
    '/ 参数 fRotSpeed：旋转速度
    '/ </summary>
    Public Sub SetSpriteAutoRot(ByVal fRotSpeed As Single)
        CommonAPI.dSetSpriteAutoRot(GetName(), fRotSpeed)
    End Sub

    '/ <summary>
    '/ SetSpriteWidth：设置精灵外形宽度
    '/ 参数 fWidth：宽度值，大于0
    '/ </summary>
    Public Sub SetSpriteWidth(ByVal fWidth As Single)
        CommonAPI.dSetSpriteWidth(GetName(), fWidth)
    End Sub

    '/ <summary>
    '/ GetSpriteWidth：获取精灵外形宽度
    '/ 返回值：精灵宽度值
    '/ </summary>
    Public Function GetSpriteWidth() As Single
        Return CommonAPI.dGetSpriteWidth(GetName())
    End Function

    '/ <summary>
    '/ SetSpriteHeight：设置精灵外形高度
    '/ 参数 fHeight：精灵高度值
    '/ </summary>
    Public Sub SetSpriteHeight(ByVal fHeight As Single)
        CommonAPI.dSetSpriteHeight(GetName(), fHeight)
    End Sub

    '/ <summary>
    '/ GetSpriteHeight：获取精灵外形高度
    '/ 返回值：精灵高度值
    '/ </summary>
    Public Function GetSpriteHeight() As Single
        Return CommonAPI.dGetSpriteHeight(GetName())
    End Function

    '/ <summary>
    '/ SetSpriteFlipX：设置精灵图片X方向翻转显示
    '/ 参数 bFlipX：true 翻转 false不翻转(恢复原来朝向)
    '/ </summary>
    Public Sub SetSpriteFlipX(ByVal bFlipX As Boolean)
        CommonAPI.dSetSpriteFlipX(GetName(), bFlipX)
    End Sub

    '/ <summary>
    '/ GetSpriteFlipX：获取当前精灵图片X方向是否是翻转显示
    '/ 返回值：true 翻转 false不翻转
    '/ </summary>
    Public Function GetSpriteFlipX() As Boolean
        Return CommonAPI.dGetSpriteFlipX(GetName())
    End Function
    '/ <summary>
    '/ SetSpriteFlipY：设置精灵图片Y方向翻转显示
    '/ 参数 bFlipY：true 翻转 false不翻转(恢复原来朝向)
    '/ </summary>
    Public Sub SetSpriteFlipY(ByVal bFlipY As Boolean)
        CommonAPI.dSetSpriteFlipY(GetName(), bFlipY)
    End Sub

    '/ <summary>
    '/ GetSpriteFlipY：获取当前精灵图片Y方向是否是翻转显示
    '/ 返回值：true 翻转 false不翻转
    '/ </summary>
    Public Function GetSpriteFlipY() As Boolean
        Return CommonAPI.dGetSpriteFlipY(GetName())
    End Function

    '/ <summary>
    '/ SetSpriteFlip：同时设置精灵翻转X及Y方向
    '/ 参数 bFlipX：true 翻转 false不翻转(恢复原来朝向)
    '/ 参数 bFlipY：true 翻转 false不翻转(恢复原来朝向)
    '/ </summary>
    Public Sub SetSpriteFlip(ByVal bFlipX As Boolean, ByVal bFlipY As Boolean)
        CommonAPI.dSetSpriteFlip(GetName(), bFlipX, bFlipY)
    End Sub

    '/ <summary>
    '/ SetSpriteLifeTime：设置精灵的生命时长，时间到了之后将自动被删除
    '/ 参数 fLifeTime：生命时长，单位 秒
    '/ </summary>
    Public Sub SetSpriteLifeTime(ByVal fLifeTime As Single)
        CommonAPI.dSetSpriteLifeTime(GetName(), fLifeTime)
    End Sub

    '/ <summary>
    '/ GetSpriteLifeTime：获取精灵生命时长
    '/ 返回值：生命时长，单位 秒
    '/ </summary>
    Public Function GetSpriteLifeTime() As Single
        Return CommonAPI.dGetSpriteLifeTime(GetName())
    End Function

    '/ <summary>
    '/ SpriteMoveTo：让精灵按照给定速度移动到给定坐标点
    '/ 参数 fPosX：移动的目标X坐标值
    '/ 参数 fPosY：移动的目标Y坐标值
    '/ 参数 fSpeed：移动速度
    '/ 参数 bAutoStop：移动到终点之后是否自动停止
    '/ </summary>
    Public Sub SpriteMoveTo(ByVal fPosX As Single, ByVal fPosY As Single, ByVal fSpeed As Single, ByVal bAutoStop As Boolean)
        CommonAPI.dSpriteMoveTo(GetName(), fPosX, fPosY, fSpeed, bAutoStop)
    End Sub

    '/ <summary>
    '/ SpriteRotateTo：让精灵按照给定速度旋转到给定的角度
    '/ 参数 fRotation：给定的目标旋转值
    '/ 参数 fRotSpeed：旋转速度
    '/ 参数 bAutoStop：旋转到终点之后是否自动停止
    '/ </summary>
    Public Sub SpriteRotateTo(ByVal fRotation As Single, ByVal fRotSpeed As Single, ByVal bAutoStop As Boolean)
        CommonAPI.dSpriteRotateTo(GetName(), fRotation, fRotSpeed, bAutoStop)
    End Sub

    '/ <summary>
    '/ SetSpriteWorldLimit：设置精灵的世界边界坐标限制及碰撞模式
    '/ 参数 Limit：碰撞到世界边界之后的响应模式，如果为OFF，则是关闭世界边界碰撞。其它值见 EWorldLimit
    '/ 参数 fLeft：边界的左边X坐标
    '/ 参数 fTop：边界的上边Y坐标
    '/ 参数 fRight：边界的右边X坐标
    '/ 参数 fBottom：边界的下边Y坐标
    '/ </summary>
    Public Sub SetSpriteWorldLimit(ByVal Limit As EWorldLimit, ByVal fLeft As Single, ByVal fTop As Single, ByVal fRight As Single, ByVal fBottom As Single)
        CommonAPI.dSetSpriteWorldLimit(GetName(), Limit, fLeft, fTop, fRight, fBottom)
    End Sub

    '/ <summary>
    '/ SetSpriteWorldLimitMode：设置精灵的世界边界碰撞模式
    '/ 参数 Limit：碰撞到世界边界之后的响应模式，如果为OFF，则是关闭世界边界碰撞。其它值见 EWorldLimit
    '/ </summary>
    Public Sub SetSpriteWorldLimitMode(ByVal Limit As EWorldLimit)
        CommonAPI.dSetSpriteWorldLimitMode(GetName(), Limit)
    End Sub

    '/ <summary>
    '/ SetSpriteWorldLimitMin：设置精灵的世界边界上边及左边坐标限制
    '/ 参数 fLeft：边界的左边X坐标
    '/ 参数 fTop：边界的上边Y坐标
    '/ </summary>
    Public Sub SetSpriteWorldLimitMin(ByVal fLeft As Single, ByVal fTop As Single)
        CommonAPI.dSetSpriteWorldLimitMin(GetName(), fLeft, fTop)
    End Sub

    '/ <summary>
    '/ SetSpriteWorldLimitMax：设置精灵的世界边界下边及右边坐标限制
    '/ 参数 fRight：边界的右边X坐标
    '/ 参数 fBottom：边界的下边Y坐标
    '/ </summary>
    Public Sub SetSpriteWorldLimitMax(ByVal fRight As Single, ByVal fBottom As Single)
        CommonAPI.dSetSpriteWorldLimitMax(GetName(), fRight, fBottom)
    End Sub

    '/ <summary>
    '/ GetSpriteWorldLimitLeft：获取精灵世界边界左边界限制
    '/ </summary>
    Public Function floatGetSpriteWorldLimitLeft() As Single
        Return CommonAPI.dGetSpriteWorldLimitLeft(GetName())
    End Function

    '/ <summary>
    '/ GetSpriteWorldLimitLeft：获取精灵世界边界上边界限制
    '/ </summary>
    Public Function GetSpriteWorldLimitTop() As Single
        Return CommonAPI.dGetSpriteWorldLimitTop(GetName())
    End Function

    '/ <summary>
    '/ GetSpriteWorldLimitLeft：获取精灵世界边界右边界限制
    '/ </summary>
    Public Function GetSpriteWorldLimitRight() As Single
        Return CommonAPI.dGetSpriteWorldLimitRight(GetName())
    End Function

    '/ <summary>
    '/ GetSpriteWorldLimitLeft：获取精灵世界边界下边界限制
    '/ </summary>
    Public Function GetSpriteWorldLimitBottom() As Single
        Return CommonAPI.dGetSpriteWorldLimitBottom(GetName())
    End Function

    '/ <summary>
    '/ SetSpriteCollisionSend：设置精灵是否可以发送(产生)碰撞
    '/ 精灵的碰撞方式为：当A移动中碰上B时，如果A是可以产生碰撞的，B是可以接受碰撞的，则这2个物体会产生碰撞，精灵碰撞的API将被调用。否则无碰撞发生
    '/ 参数 bSend：true 可以产生 false 不产生
    '/ </summary>
    Public Sub SetSpriteCollisionSend(ByVal bSend As Boolean)
        CommonAPI.dSetSpriteCollisionSend(GetName(), bSend)
    End Sub

    '/ <summary>
    '/ SetSpriteCollisionReceive：设置精灵是否可以接受碰撞
    '/ 精灵的碰撞方式为：当A移动中碰上B时，如果A是可以产生碰撞的，B是可以接受碰撞的，则这2个物体会产生碰撞，精灵碰撞的API将被调用。否则无碰撞发生
    '/ 参数 bReceive：true 可以接受 false 不接受
    '/ </summary>
    Public Sub SetSpriteCollisionReceive(ByVal bReceive As Boolean)
        CommonAPI.dSetSpriteCollisionReceive(GetName(), bReceive)
    End Sub

    '/ <summary>
    '/ SetSpriteCollisionActive：同时设置精灵是否可以产生及接受碰撞
    '/ 精灵的碰撞方式为：当A移动中碰上B时，如果A是可以产生碰撞的，B是可以接受碰撞的，则这2个物体会产生碰撞，精灵碰撞的API将被调用。否则无碰撞发生
    '/ 参数 bSend：true 可以产生 false 不产生
    '/ 参数 bReceive：true 可以接受 false 不接受
    '/ </summary>
    Public Sub SetSpriteCollisionActive(ByVal bSend As Boolean, ByVal bReceive As Boolean)
        CommonAPI.dSetSpriteCollisionActive(GetName(), bSend, bReceive)
    End Sub

    '/ <summary>
    '/ SetSpriteCollisionPhysicsSend：设置精灵是否可以发送(产生)碰撞
    '/ 参数 bSend：true 可以产生 false 不产生
    '/ </summary>
    Public Sub SetSpriteCollisionPhysicsSend(ByVal bSend As Boolean)
        CommonAPI.dSetSpriteCollisionPhysicsSend(GetName(), bSend)
    End Sub

    '/ <summary>
    '/ SetSpriteCollisionPhysicsReceive：设置精灵是否可以接受碰撞
    '/ 参数 bReceive：true 可以接受 false 不接受
    '/ </summary>
    Public Sub SetSpriteCollisionPhysicsReceive(ByVal bReceive As Boolean)
        CommonAPI.dSetSpriteCollisionPhysicsReceive(GetName(), bReceive)
    End Sub

    '/ <summary>
    '/ GetSpriteCollisionSend：获取精灵当前是否是可以产生碰撞
    '/ 返回值：true 可以产生 false 不产生
    '/ </summary>
    Public Function GetSpriteCollisionSend() As Boolean
        Return CommonAPI.dGetSpriteCollisionSend(GetName())
    End Function

    '/ <summary>
    '/ GetSpriteCollisionReceive：获取精灵当前是否是可以接受碰撞
    '/ 返回值：true 可以接受 false 不接受
    '/ </summary>
    Public Function GetSpriteCollisionReceive() As Boolean
        Return CommonAPI.dGetSpriteCollisionReceive(GetName())
    End Function

    '/ <summary>
    '/ SetSpriteCollisionResponse：设置精灵与精灵的碰撞响应模式
    '/ 参数 Response：响应模式，如果为OFF，则为关闭碰撞响应，碰撞API将不会被调用。其它值见 ECollisionResponse
    '/ </summary>
    Public Sub SetSpriteCollisionResponse(ByVal Response As ECollisionResponse)
        CommonAPI.dSetSpriteCollisionResponse(GetName(), Response)
    End Sub

    '/ <summary>
    '/ SetSpriteCollisionMaxIterations：设置精灵碰撞之后的最大反弹次数
    '/ 参数 iTimes：反弹次数
    '/ </summary>
    '/ <param name="iTimes"></param>
    Public Sub SetSpriteCollisionMaxIterations(ByVal iTimes As Integer)
        CommonAPI.dSetSpriteCollisionMaxIterations(GetName(), iTimes)
    End Sub

    '/ <summary>
    '/ SetSpriteForwardMovementOnly：设置精灵是否只能朝前移动
    '/ 参数 bForward：true 只能朝前移动 false 可以朝其他方向移动
    '/ </summary>
    '/ <param name="bForward"></param>
    Public Sub SetSpriteForwardMovementOnly(ByVal bForward As Boolean)
        CommonAPI.dSetSpriteForwardMovementOnly(GetName(), bForward)
    End Sub

    '/ <summary>
    '/ GetSpriteForwardMovementOnly：获取精灵当前是否只能朝前移动
    '/ 返回值：true 只能朝前移动 false 可以朝其它方向移动
    '/ </summary>
    '/ <returns></returns>
    Public Function GetSpriteForwardMovementOnly() As Boolean
        Return CommonAPI.dGetSpriteForwardMovementOnly(GetName())
    End Function

    '/ <summary>
    '/ SetSpriteForwardSpeed：设置精灵向前的速度
    '/ 参数 fSpeed：速度
    '/ </summary>
    '/ <param name="fSpeed"></param>
    Public Sub SetSpriteForwardSpeed(ByVal fSpeed As Single)
        CommonAPI.dSetSpriteForwardSpeed(GetName(), fSpeed)
    End Sub

    '/ <summary>
    '/ SetSpriteImpulseForce：设置精灵瞬间推力
    '/ 参数 fForceX：X方向推力大小
    '/ 参数 fForceY：Y方向推力大小
    '/ 参数 bGravitic：是否计算重力
    '/ </summary>
    '/ <param name="fForceX"></param>
    '/ <param name="fForceY"></param>
    '/ <param name="bGravitic"></param>
    Public Sub SetSpriteImpulseForce(ByVal fForceX As Single, ByVal fForceY As Single, ByVal bGravitic As Boolean)
        CommonAPI.dSetSpriteImpulseForce(GetName(), fForceX, fForceY, bGravitic)
    End Sub

    '/ <summary>
    '/ SetSpriteImpulseForcePolar：按角度朝向设置精灵瞬间推力
    '/ 参数 fPolar：角度朝向
    '/ 参数 fForce：推力大小
    '/ 参数 bGravitic：是否计算重力
    '/ </summary>
    '/ <param name="fPolar"></param>
    '/ <param name="fForce"></param>
    '/ <param name="bGravitic"></param>
    Public Sub SetSpriteImpulseForcePolar(ByVal fPolar As Single, ByVal fForce As Single, ByVal bGravitic As Boolean)
        CommonAPI.dSetSpriteImpulseForcePolar(GetName(), fPolar, fForce, bGravitic)
    End Sub

    '/ <summary>
    '/ SetSpriteConstantForceX：设置精灵X方向常量推力
    '/ 参数 fForceX：X方向推力大小
    '/ </summary>
    '/ <param name="fForceX"></param>
    Public Sub SetSpriteConstantForceX(ByVal fForceX As Single)
        CommonAPI.dSetSpriteConstantForceX(GetName(), fForceX)
    End Sub

    '/ <summary>
    '/ SetSpriteConstantForceY：设置精灵Y方向常量推力
    '/ 参数 fForceY：Y方向推力大小
    '/ </summary>
    '/ <param name="fForceY"></param>
    Public Sub SetSpriteConstantForceY(ByVal fForceY As Single)
        CommonAPI.dSetSpriteConstantForceY(GetName(), fForceY)
    End Sub

    '/ <summary>
    '/ SetSpriteConstantForceGravitic：精灵在计算常量推力的时候，是否计算重力
    '/ 参数 bGravitic：是否计算重力
    '/ </summary>
    '/ <param name="bGravitic"></param>
    Public Sub SetSpriteConstantForceGravitic(ByVal bGravitic As Boolean)
        CommonAPI.dSetSpriteConstantForceGravitic(GetName(), bGravitic)
    End Sub

    '/ <summary>
    '/ SetSpriteConstantForce：设置精灵常量推力
    '/ 参数 fForceX：X方向推力大小
    '/ 参数 fForceY：Y方向推力大小
    '/ 参数 bGravitic：是否计算重力
    '/ </summary>
    '/ <param name="fForceX"></param>
    '/ <param name="fForceY"></param>
    '/ <param name="bGravitic"></param>
    Public Sub SetSpriteConstantForce(ByVal fForceX As Single, ByVal fForceY As Single, ByVal bGravitic As Boolean)
        CommonAPI.dSetSpriteConstantForce(GetName(), fForceX, fForceY, bGravitic)
    End Sub

    '/ <summary>
    '/ SetSpriteConstantForcePolar：按角度朝向设置精灵常量推力
    '/ 参数 fPolar：角度朝向
    '/ 参数 fForce：推力大小
    '/ 参数 bGravitic：是否计算重力
    '/ </summary>
    '/ <param name="fPolar"></param>
    '/ <param name="fForce"></param>
    '/ <param name="bGravitic"></param>
    Public Sub SetSpriteConstantForcePolar(ByVal fPolar As Single, ByVal fForce As Single, ByVal bGravitic As Boolean)
        CommonAPI.dSetSpriteConstantForcePolar(GetName(), fPolar, fForce, bGravitic)
    End Sub

    '/ <summary>
    '/ StopSpriteConstantForce：停止精灵常量推力
    '/ </summary>
    Public Sub StopSpriteConstantForce()
        CommonAPI.dStopSpriteConstantForce(GetName())
    End Sub

    '/ <summary>
    '/ SetSpriteForceScale：按倍数缩放精灵当前受的推力
    '/ 参数 fScale：缩放值
    '/ </summary>
    '/ <param name="fScale"></param>
    Public Sub SetSpriteForceScale(ByVal fScale As Single)
        CommonAPI.dSetSpriteForceScale(GetName(), fScale)
    End Sub

    '/ <summary>
    '/ SetSpriteAtRest：暂停/继续精灵的各种受力计算
    '/ 参数 bRest：true 暂停 false 继续
    '/ </summary>
    '/ <param name="bRest"></param>
    Public Sub SetSpriteAtRest(ByVal bRest As Boolean)
        CommonAPI.dSetSpriteAtRest(GetName(), bRest)
    End Sub

    '/ <summary>
    '/ GetSpriteAtRest：获取精灵当前是否在暂停中
    '/ 返回值：true 暂停中 false 正常
    '/ </summary>
    '/ <returns></returns>
    Public Function GetSpriteAtRest() As Boolean
        Return CommonAPI.dGetSpriteAtRest(GetName())
    End Function

    '/ <summary>
    '/ SetSpriteFriction：设置精灵摩擦力
    '/ 参数 fFriction：摩擦力大小
    '/ </summary>
    '/ <param name="fFriction"></param>
    Public Sub SetSpriteFriction(ByVal fFriction As Single)
        CommonAPI.dSetSpriteFriction(GetName(), fFriction)
    End Sub

    '/ <summary>
    '/ SetSpriteRestitution：设置精灵弹力
    '/ 参数 fRestitution：弹力值大小
    '/ </summary>
    '/ <param name="fRestitution"></param>
    Public Sub SetSpriteRestitution(ByVal fRestitution As Single)
        CommonAPI.dSetSpriteRestitution(GetName(), fRestitution)
    End Sub

    '/ <summary>
    '/ SetSpriteMass：设置精灵质量
    '/ 参数 fMass：质量大小
    '/ </summary>
    '/ <param name="fMass"></param>
    Public Sub SetSpriteMass(ByVal fMass As Single)
        CommonAPI.dSetSpriteMass(GetName(), fMass)
    End Sub

    '/ <summary>
    '/ GetSpriteMass：获取精灵质量
    '/ 返回值 ：质量大小
    '/ </summary>
    '/ <returns></returns>
    Public Function GetSpriteMass() As Single
        Return CommonAPI.dGetSpriteMass(GetName())
    End Function

    '/ <summary>
    '/ SetSpriteAutoMassInertia：开启或者关闭精灵惯性
    '/ 参数 bStatus：true 开启 false 关闭
    '/ </summary>
    '/ <param name="bStatus"></param>
    Public Sub SetSpriteAutoMassInertia(ByVal bStatus As Boolean)
        CommonAPI.dSetSpriteAutoMassInertia(GetName(), bStatus)
    End Sub

    '/ <summary>
    '/ SetSpriteInertialMoment：设置精灵惯性大小
    '/ 参数 fInert：惯性大小
    '/ </summary>
    '/ <param name="fInert"></param>
    Public Sub SetSpriteInertialMoment(ByVal fInert As Single)
        CommonAPI.dSetSpriteInertialMoment(GetName(), fInert)
    End Sub

    '/ <summary>
    '/ SetSpriteDamping：设置精灵衰减值
    '/ 参数 fDamp：衰减值大小
    '/ </summary>
    '/ <param name="fDamp"></param>
    Public Sub SetSpriteDamping(ByVal fDamp As Single)
        CommonAPI.dSetSpriteDamping(GetName(), fDamp)
    End Sub

    '/ <summary>
    '/ SetSpriteImmovable：设置精灵是否不可移动
    '/ 参数 bImmovable：true 不可以移动 false 可以移动
    '/ </summary>
    '/ <param name="bImmovable"></param>
    Public Sub SetSpriteImmovable(ByVal bImmovable As Boolean)
        CommonAPI.dSetSpriteImmovable(GetName(), bImmovable)
    End Sub

    '/ <summary>
    '/ GetSpriteImmovable：获取精灵当前是否不可以移动
    '/ 返回值：true 不可以移动 false 可以移动
    '/ </summary>
    '/ <returns></returns>
    Public Function GetSpriteImmovable() As Boolean
        Return CommonAPI.dGetSpriteImmovable(GetName())
    End Function

    '/ <summary>
    '/ SetSpriteLinearVelocity：设置精灵移动速度
    '/ 参数 fVelX：X方向速度
    '/ 参数 fVelY：Y方向速度
    '/ </summary>
    '/ <param name="fVelX"></param>
    '/ <param name="fVelY"></param>
    Public Sub SetSpriteLinearVelocity(ByVal fVelX As Single, ByVal fVelY As Single)
        CommonAPI.dSetSpriteLinearVelocity(GetName(), fVelX, fVelY)
    End Sub

    '/ <summary>
    '/ SetSpriteLinearVelocityX：设置精灵X方向移动速度
    '/ 参数 fVelX：X方向速度
    '/ </summary>
    '/ <param name="fVelX"></param>
    Public Sub SetSpriteLinearVelocityX(ByVal fVelX As Single)
        CommonAPI.dSetSpriteLinearVelocityX(GetName(), fVelX)
    End Sub

    '/ <summary>
    '/ SetSpriteLinearVelocityY：设置精灵Y方向移动速度
    '/ 参数 fVelY：Y方向速度
    '/ </summary>
    '/ <param name="fVelY"></param>
    Public Sub SetSpriteLinearVelocityY(ByVal fVelY As Single)
        CommonAPI.dSetSpriteLinearVelocityY(GetName(), fVelY)
    End Sub

    '/ <summary>
    '/ SetSpriteLinearVelocityPolar：按角度朝向设置精灵移动速度
    '/ 参数 fSpeed：移动速度
    '/ 参数 fPolar：角度朝向
    '/ </summary>
    '/ <param name="fSpeed"></param>
    '/ <param name="fPolar"></param>
    Public Sub SetSpriteLinearVelocityPolar(ByVal fSpeed As Single, ByVal fPolar As Single)
        CommonAPI.dSetSpriteLinearVelocityPolar(GetName(), fSpeed, fPolar)
    End Sub

    '/ <summary>
    '/ SetSpriteAngularVelocity：设置精灵角度旋转速度
    '/ 参数 fAngular：角度旋转速度
    '/ </summary>
    '/ <param name="fAngular"></param>
    Public Sub SetSpriteAngularVelocity(ByVal fAngular As Single)
        CommonAPI.dSetSpriteAngularVelocity(GetName(), fAngular)
    End Sub

    '/ <summary>
    '/ SetSpriteMinLinearVelocity：设置精灵最小速度
    '/ 参数 fMin：最小速度值
    '/ </summary>
    '/ <param name="fMin"></param>
    Public Sub SetSpriteMinLinearVelocity(ByVal fMin As Single)
        CommonAPI.dSetSpriteMinLinearVelocity(GetName(), fMin)
    End Sub

    '/ <summary>
    '/ SetSpriteMaxLinearVelocity：设置精灵最大速度
    '/ 参数 fMax：最大速度值
    '/ </summary>
    '/ <param name="fMax"></param>
    Public Sub SetSpriteMaxLinearVelocity(ByVal fMax As Single)
        CommonAPI.dSetSpriteMaxLinearVelocity(GetName(), fMax)
    End Sub

    '/ <summary>
    '/ SetSpriteMinAngularVelocity：设置精灵最小角速度
    '/ 参数 fMin：最小角速度
    '/ </summary>
    '/ <param name="fMin"></param>
    Public Sub SetSpriteMinAngularVelocity(ByVal fMin As Single)
        CommonAPI.dSetSpriteMinAngularVelocity(GetName(), fMin)
    End Sub

    '/ <summary>
    '/ SetSpriteMaxAngularVelocity：设置精灵最大角速度
    '/ 参数 fMax：最大角速度
    '/ </summary>
    '/ <param name="fMax"></param>
    Public Sub SetSpriteMaxAngularVelocity(ByVal fMax As Single)
        CommonAPI.dSetSpriteMaxAngularVelocity(GetName(), fMax)
    End Sub

    '/ <summary>
    '/ GetSpriteLinearVelocityX：获取精灵X方向速度
    '/ 返回值：X方向速度
    '/ </summary>
    '/ <returns></returns>
    Public Function GetSpriteLinearVelocityX() As Single
        Return CommonAPI.dGetSpriteLinearVelocityX(GetName())
    End Function

    '/ <summary>
    '/ GetSpriteLinearVelocityY：获取精灵Y方向速度
    '/ 返回值：Y方向速度
    '/ </summary>
    '/ <returns></returns>
    Public Function GetSpriteLinearVelocityY() As Single
        Return CommonAPI.dGetSpriteLinearVelocityY(GetName())
    End Function

    '/ <summary>
    '/ SpriteMountToSprite：将一个精灵绑定到另一个精灵上，暂时的成为另一个精灵的一部分，跟随其运动等
    '/ 参数 szDstName：承载绑定的母体精灵名字
    '/ 参数 fOffSetX：绑定偏移X
    '/ 参数 fOffsetY：绑定偏移Y
    '/ 返回值：返回一个绑定ID
    '/ </summary>
    '/ <param name="szDstName"></param>
    '/ <param name="fOffSetX"></param>
    '/ <param name="fOffsetY"></param>
    '/ <returns></returns>
    Public Function SpriteMountToSprite(ByVal szDstName As String, ByVal fOffSetX As Single, ByVal fOffsetY As Single) As Integer
        Return CommonAPI.dSpriteMountToSprite(GetName(), szDstName, fOffSetX, fOffsetY)
    End Function

    '/ <summary>
    '/ SpriteMountToSpriteLinkPoint：将一个精灵绑定到另一个精灵上，绑定位置为指定的链接点，暂时的成为另一个精灵的一部分，跟随其运动等
    '/ 参数 szDstName：承载绑定的母体精灵名字
    '/ 参数 iPointId：链接点序号
    '/ 返回值：返回一个绑定ID
    '/ </summary>
    '/ <param name="szDstName"></param>
    '/ <param name="iPointId"></param>
    '/ <returns></returns>
    Public Function SpriteMountToSpriteLinkPoint(ByVal szDstName As String, ByVal iPointId As Integer) As Integer
        Return CommonAPI.dSpriteMountToSpriteLinkPoint(GetName(), szDstName, iPointId)
    End Function

    '/ <summary>
    '/ SetSpriteMountRotation：设置精灵的绑定朝向，即相对于母体的朝向
    '/ 参数 fRot：角度朝向，0 - 360
    '/ </summary>
    '/ <param name="fRot"></param>
    Public Sub SetSpriteMountRotation(ByVal fRot As Single)
        CommonAPI.dSetSpriteMountRotation(GetName(), fRot)
    End Sub

    '/ <summary>
    '/ GetSpriteMountRotation：获取精灵的绑定朝向，即相对于母体的朝向
    '/ 返回值：角度朝向
    '/ </summary>
    '/ <returns></returns>
    Public Function GetSpriteMountRotation() As Single
        Return CommonAPI.dGetSpriteMountRotation(GetName())
    End Function

    '/ <summary>
    '/ SetSpriteAutoMountRotation：设置精灵绑定之后自动旋转
    '/ 参数 fRot：旋转速度
    '/ </summary>
    '/ <param name="fRot"></param>
    Public Sub SetSpriteAutoMountRotation(ByVal fRot As Single)
        CommonAPI.dSetSpriteAutoMountRotation(GetName(), fRot)
    End Sub

    '/ <summary>
    '/ GetSpriteAutoMountRotation：获取精灵绑定之后的自动旋转值
    '/ 返回值：旋转速度
    '/ </summary>
    '/ <returns></returns>
    Public Function GetSpriteAutoMountRotation() As Single
        Return CommonAPI.dGetSpriteAutoMountRotation(GetName())
    End Function

    '/ <summary>
    '/ SetSpriteMountForce：绑定至另一个精灵时，附加的作用力
    '/ 参数 fFroce：作用力
    '/ </summary>
    '/ <param name="fForce"></param>
    Public Sub SetSpriteMountForce(ByVal fForce As Single)
        CommonAPI.dSetSpriteMountForce(GetName(), fForce)
    End Sub

    '/ <summary>
    '/ SetSpriteMountTrackRotation：绑定的精灵是否跟随母体旋转
    '/ 参数 bTrackRotation：true 跟随 false 不跟随
    '/ </summary>
    '/ <param name="bTrackRotation"></param>
    Public Sub SetSpriteMountTrackRotation(ByVal bTrackRotation As Boolean)
        CommonAPI.dSetSpriteMountTrackRotation(GetName(), bTrackRotation)
    End Sub

    '/ <summary>
    '/ SetSpriteMountOwned：母体被删除的时候，绑定的精灵是否也跟着被删除
    '/ 参数 bMountOwned：true 跟着 false 不跟着
    '/ </summary>
    '/ <param name="bMountOwned"></param>
    Public Sub SetSpriteMountOwned(ByVal bMountOwned As Boolean)
        CommonAPI.dSetSpriteMountOwned(GetName(), bMountOwned)
    End Sub

    '/ <summary>
    '/ SetSpriteMountInheritAttributes：绑定的时候，是否继承母体的属性
    '/ 参数 bInherAttr：true 继承 false 不继承
    '/ </summary>
    '/ <param name="bInherAttr"></param>
    Public Sub SetSpriteMountInheritAttributes(ByVal bInherAttr As Boolean)
        CommonAPI.dSetSpriteMountInheritAttributes(GetName(), bInherAttr)
    End Sub

    '/ <summary>
    '/ SpriteDismount：将已经绑定的精灵进行解绑
    '/ </summary>
    Public Sub SpriteDismount()
        CommonAPI.dSpriteDismount(GetName())
    End Sub

    '/ <summary>
    '/ GetSpriteIsMounted：判断精灵是否绑定在另一个精灵上
    '/ 返回值：true 绑定 false 不绑定
    '/ </summary>
    '/ <returns></returns>
    Public Function GetSpriteIsMounted() As Boolean
        Return CommonAPI.dGetSpriteIsMounted(GetName())
    End Function

    '/ <summary>
    '/ GetSpriteMountedParent：获取绑定的母体精灵的名字
    '/ 返回值：母体精灵名字，如果未绑定，则返回空字符串
    '/ </summary>
    '/ <returns></returns>
    Public Function GetSpriteMountedParent() As String
        Return CommonAPI.dGetSpriteMountedParent(GetName())
    End Function

    '/ <summary>
    '/ SetSpriteColorRed：更改精灵显示颜色中的红色。默认精灵的红绿蓝三颜色的值均为255，修改其中一项将可以改变其颜色
    '/ 参数 iCol：颜色范围 0 - 255
    '/ </summary>
    '/ <param name="iCol"></param>
    Public Sub SetSpriteColorRed(ByVal iCol As Integer)
        CommonAPI.dSetSpriteColorRed(GetName(), iCol)
    End Sub

    '/ <summary>
    '/ SetSpriteColorGreen：更改精灵显示颜色中的绿色。默认精灵的红绿蓝三颜色的值均为255，修改其中一项将可以改变其颜色
    '/ 参数 iCol：颜色范围 0 - 255
    '/ </summary>
    '/ <param name="iCol"></param>
    Public Sub SetSpriteColorGreen(ByVal iCol As Integer)
        CommonAPI.dSetSpriteColorGreen(GetName(), iCol)
    End Sub

    '/ <summary>
    '/ SetSpriteColorBlue：更改精灵显示颜色中的蓝色。默认精灵的红绿蓝三颜色的值均为255，修改其中一项将可以改变其颜色
    '/ 参数 iCol：颜色范围 0 - 255
    '/ </summary>
    '/ <param name="iCol"></param>
    Public Sub SetSpriteColorBlue(ByVal iCol As Integer)
        CommonAPI.dSetSpriteColorBlue(GetName(), iCol)
    End Sub

    '/ <summary>
    '/ SetSpriteColorAlpha：设置精灵透明度
    '/ 参数 iCol：透明度，值0 - 255，从完全透明至完全不透明
    '/ </summary>
    '/ <param name="iCol"></param>
    Public Sub SetSpriteColorAlpha(ByVal iCol As Integer)
        CommonAPI.dSetSpriteColorAlpha(GetName(), iCol)
    End Sub

    '/ <summary>
    '/ GetSpriteColorRed：获取精灵显示颜色中的红色值
    '/ 返回值：颜色值
    '/ </summary>
    '/ <returns></returns>
    Public Function GetSpriteColorRed() As Integer
        Return CommonAPI.dGetSpriteColorRed(GetName())
    End Function

    '/ <summary>
    '/ GetSpriteColorGreen：获取精灵显示颜色中的绿色值
    '/ 返回值：颜色值
    '/ </summary>
    '/ <returns></returns>
    Public Function GetSpriteColorGreen() As Integer
        Return CommonAPI.dGetSpriteColorGreen(GetName())
    End Function

    '/ <summary>
    '/ GetSpriteColorBlue：获取精灵显示颜色中的蓝色值
    '/ 返回值：颜色值
    '/ </summary>
    '/ <returns></returns>
    Public Function GetSpriteColorBlue() As Integer
        Return CommonAPI.dGetSpriteColorBlue(GetName())
    End Function

    '/ <summary>
    '/ GetSpriteColorAlpha：获取精灵透明度
    '/ 返回值：透明度
    '/ </summary>
    '/ <returns></returns>
    Public Function GetSpriteColorAlpha() As Integer
        Return CommonAPI.dGetSpriteColorAlpha(GetName())
    End Function
End Class

