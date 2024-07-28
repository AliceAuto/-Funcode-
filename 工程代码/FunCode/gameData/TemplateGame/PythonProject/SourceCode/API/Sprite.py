# -*- coding: utf-8 -*-

import ctypes
from CommonAPI import *

#/ <summary>
#/ 类：CSSprite
#/ 所有精灵的基类。包括下面的静态精灵，动态精灵，文字，特效等均由此类继承下去
#/ 一般的图片精灵从本类继承下去即可。只有特殊的精灵，比如带动画的精灵，才需要从动态精灵继承下去
#/ </summary>
class Sprite(object):
    m_szName = None		# 精灵名字
    m_szNameAnsi = None

	#/ <summary>
    #/ 构造函数，需要传入一个非空的精灵名字字符串。如果传入的是地图里摆放好的精灵名字，则此类即与地图里的精灵绑定
	#/ 如果传入的是一个新的精灵名字，则需要调用成员函数 CloneSprite，复制一份精灵对象实例，才与实际的地图精灵关联起来
    #/ </summary>
    def __init__( self, szName ):
        self.m_szName = szName
        self.m_szNameAnsi = szName.encode("ascii")

    #/ <summary>
    #/ GetName
	#/ 返回值：返回精灵名字
    #/ </summary>
    def GetName(self):
        return self.m_szName

    def GetNameAnsi(self):
        return self.m_szNameAnsi
    
	#/ <summary>
	#/ CloneSprite：复制(创建)一个精灵。精灵的创建方式：先在地图中摆放一个精灵做为模板，设置好各项参数，然后在代码里使用此函数克隆一个实例
	#/ 返回值：true表示克隆成功，false克隆失败。失败的原因可能是在地图中未找到对应名字的精灵
	#/ 参数 szSrcName：地图中用做模板的精灵名字
	#/ </summary>
    def CloneSprite( self, szSrcName):
        return CommonAPI.GetAPI().dCloneSprite( szSrcName.encode("ascii"), self.GetNameAnsi() )

	#/ <summary>
	#/ DeleteSprite：在地图中删除与本对象实例关联的精灵
	#/ </summary>
    def	DeleteSprite( self):
        CommonAPI.GetAPI().dDeleteSprite( self.GetNameAnsi() )

	#/ <summary>
	#/ SetSpriteVisible：设置精灵隐藏或者显示(可见不可见)
    #/ 参数 bVisible：true 可见 false不可见
	#/ </summary>
    def SetSpriteVisible( self, bVisible):
        CommonAPI.GetAPI().dSetSpriteVisible( self.GetNameAnsi(), bVisible )

	#/ <summary>
	#/ IsSpriteVisible：获取该精灵当前是否可见
	#/ </summary>
    def IsSpriteVisible( self):
        return CommonAPI.GetAPI().dIsSpriteVisible( self.GetNameAnsi() )

	#/ <summary>
	#/ SetSpriteEnable：禁止或者启用该精灵。被禁止的精灵将不参与任何响应，包括不移动，没有碰撞等，仅仅是在地图中显示
	#/ 参数 bEnable：true启用 false禁止
	#/ </summary>
    def SetSpriteEnable( self, bEnable):
        CommonAPI.GetAPI().dSetSpriteEnable( self.GetNameAnsi(), bEnable )

	#/ <summary>
	#/ SetSpriteScale：设置精灵的缩放值
	#/ 参数 fScale：缩放值。大于0的值
	#/ </summary>
    def SetSpriteScale( self,   fScale ):
        CommonAPI.GetAPI().dSetSpriteScale( self.GetNameAnsi(), fScale )

	#/ <summary>
	#/ IsPointInSprite：判断某个坐标点是否位于精灵内部
	#/ 参数 fPosX：X坐标点
	#/ 参数 fPosY：Y坐标点
	#/ </summary>
    def IsPointInSprite( self, fPosX,  fPosY):
        return CommonAPI.GetAPI().dIsPointInSprite( self.GetNameAnsi(), fPosX, fPosY )

	#/ <summary>
	#/ SetSpritePosition：设置精灵位置
	#/ 参数 fPosX：X坐标
	#/ 参数 fPosY：Y坐标
	#/ </summary>
    def SetSpritePosition( self,   fPosX,   fPosY ):
        CommonAPI.GetAPI().dSetSpritePosition( self.GetNameAnsi(), fPosX, fPosY )

	#/ <summary>
	#/ SetSpritePositionX：只设置精灵X坐标
	#/ 参数 fPosX：X坐标
	#/ </summary>
    def SetSpritePositionX( self,   fPosX ):
        CommonAPI.GetAPI().dSetSpritePositionX( self.GetNameAnsi(), fPosX )

	#/ <summary>
	#/ SetSpritePositionY：只设置精灵Y坐标
	#/ 参数 fPosY：Y坐标
	#/ </summary>
    def SetSpritePositionY(  self,  fPosY ):
        CommonAPI.GetAPI().dSetSpritePositionY( self.GetNameAnsi(), fPosY )

	#/ <summary>
	#/ GetSpritePositionX：获取精灵X坐标
	#/ 返回值：精灵的X坐标
	#/ </summary>
    def GetSpritePositionX( self):
        return CommonAPI.GetAPI().dGetSpritePositionX( self.GetNameAnsi() )

	#/ <summary>
	#/ GetSpritePositionY：获取精灵Y坐标
	#/ 返回值：精灵的Y坐标
	#/ </summary>
    def GetSpritePositionY( self):
        return CommonAPI.GetAPI().dGetSpritePositionY( self.GetNameAnsi() )

	#/ <summary>
	#/ GetSpriteLinkPointPosX：获取精灵链接点X坐标。链接点是依附于精灵的一个坐标点，可以在编辑器里增加或者删除
	#/ 参数 iId：链接点序号，第一个为1，后面依次递加
	#/ </summary>
    def GetSpriteLinkPointPosX( self,   iId ):
        return CommonAPI.GetAPI().dGetSpriteLinkPointPosX( self.GetNameAnsi(), iId )

	#/ <summary>
	#/ GetSpriteLinkPointPosY：获取精灵链接点Y坐标。链接点是依附于精灵的一个坐标点，可以在编辑器里增加或者删除
	#/ 参数 iId：链接点序号，第一个为1，后面依次递加
	#/ </summary>
    def GetSpriteLinkPointPosY( self,   iId ):
        return CommonAPI.GetAPI().dGetSpriteLinkPointPosY( self.GetNameAnsi(), iId )

	#/ <summary>
	#/ SetSpriteRotation：设置精灵的旋转角度
	#/ 参数 fRot：旋转角度，范围0 - 360
	#/ </summary>
    def SetSpriteRotation( self,   fRot ):
        CommonAPI.GetAPI().dSetSpriteRotation( self.GetNameAnsi(), fRot )

	#/ <summary>
	#/ GetSpriteRotation：获取精灵的旋转角度
	#/ 返回值：精灵的旋转角度
	#/ </summary>
    def GetSpriteRotation( self):
        return CommonAPI.GetAPI().dGetSpriteRotation( self.GetNameAnsi() )

	#/ <summary>
	#/ SetSpriteAutoRot：设置精灵按照指定速度自动旋转
	#/ 参数 fRotSpeed：旋转速度
	#/ </summary>
    def SetSpriteAutoRot(  self,  fRotSpeed ):
        CommonAPI.GetAPI().dSetSpriteAutoRot( self.GetNameAnsi(), fRotSpeed )

	#/ <summary>
	#/ SetSpriteWidth：设置精灵外形宽度
	#/ 参数 fWidth：宽度值，大于0
	#/ </summary>
    def SetSpriteWidth(   self, fWidth ):
        CommonAPI.GetAPI().dSetSpriteWidth( self.GetNameAnsi(), fWidth )

	#/ <summary>
	#/ GetSpriteWidth：获取精灵外形宽度
	#/ 返回值：精灵宽度值
	#/ </summary>
    def GetSpriteWidth( self):
        return CommonAPI.GetAPI().dGetSpriteWidth( self.GetNameAnsi() )

	#/ <summary>
	#/ SetSpriteHeight：设置精灵外形高度
	#/ 参数 fHeight：精灵高度值
	#/ </summary>
    def SetSpriteHeight(  self,  fHeight ):
        CommonAPI.GetAPI().dSetSpriteHeight( self.GetNameAnsi(), fHeight )

	#/ <summary>
	#/ GetSpriteHeight：获取精灵外形高度
	#/ 返回值：精灵高度值
	#/ </summary>
    def GetSpriteHeight( self):
        return CommonAPI.GetAPI().dGetSpriteHeight( self.GetNameAnsi() )

	#/ <summary>
	#/ SetSpriteFlipX：设置精灵图片X方向翻转显示
	#/ 参数 bFlipX：true 翻转 false不翻转(恢复原来朝向)
	#/ </summary>
    def SetSpriteFlipX(  self, bFlipX ):
        CommonAPI.GetAPI().dSetSpriteFlipX( self.GetNameAnsi(), bFlipX )

	#/ <summary>
	#/ GetSpriteFlipX：获取当前精灵图片X方向是否是翻转显示
	#/ 返回值：true 翻转 false不翻转
	#/ </summary>
    def GetSpriteFlipX( self):
        return CommonAPI.GetAPI().dGetSpriteFlipX( self.GetNameAnsi() )

	#/ <summary>
	#/ SetSpriteFlipY：设置精灵图片Y方向翻转显示
	#/ 参数 bFlipY：true 翻转 false不翻转(恢复原来朝向)
	#/ </summary>
    def SetSpriteFlipY(  self, bFlipY ):
        CommonAPI.GetAPI().dSetSpriteFlipY( self.GetNameAnsi(), bFlipY )

	#/ <summary>
	#/ GetSpriteFlipY：获取当前精灵图片Y方向是否是翻转显示
	#/ 返回值：true 翻转 false不翻转
	#/ </summary>
    def GetSpriteFlipY( self):
        return CommonAPI.GetAPI().dGetSpriteFlipY(self.GetNameAnsi())

	#/ <summary>
	#/ SetSpriteFlip：同时设置精灵翻转X及Y方向
	#/ 参数 bFlipX：true 翻转 false不翻转(恢复原来朝向)
	#/ 参数 bFlipY：true 翻转 false不翻转(恢复原来朝向)
	#/ </summary>
    def SetSpriteFlip(  self, bFlipX,  bFlipY ):
        CommonAPI.GetAPI().dSetSpriteFlip(self.GetNameAnsi(), bFlipX, bFlipY)

	#/ <summary>
	#/ SetSpriteLifeTime：设置精灵的生命时长，时间到了之后将自动被删除
	#/ 参数 fLifeTime：生命时长，单位 秒
	#/ </summary>
    def SetSpriteLifeTime(  self,  fLifeTime ):
        CommonAPI.GetAPI().dSetSpriteLifeTime( self.GetNameAnsi(), fLifeTime )

	#/ <summary>
	#/ GetSpriteLifeTime：获取精灵生命时长
	#/ 返回值：生命时长，单位 秒
	#/ </summary>
    def GetSpriteLifeTime( self):
        return CommonAPI.GetAPI().dGetSpriteLifeTime( self.GetNameAnsi() )
    
	#/ <summary>
	#/ SpriteMoveTo：让精灵按照给定速度移动到给定坐标点
	#/ 参数 fPosX：移动的目标X坐标值
	#/ 参数 fPosY：移动的目标Y坐标值
	#/ 参数 fSpeed：移动速度
	#/ 参数 bAutoStop：移动到终点之后是否自动停止
	#/ </summary>
    def SpriteMoveTo(  self,  fPosX,   fPosY,   fSpeed,  bAutoStop ):
        CommonAPI.GetAPI().dSpriteMoveTo(self.GetNameAnsi(), fPosX, fPosY, fSpeed, bAutoStop)

	#/ <summary>
	#/ SpriteRotateTo：让精灵按照给定速度旋转到给定的角度
	#/ 参数 fRotation：给定的目标旋转值
	#/ 参数 fRotSpeed：旋转速度
	#/ 参数 bAutoStop：旋转到终点之后是否自动停止
	#/ </summary>
    def SpriteRotateTo(  self,  fRotation,   fRotSpeed,  bAutoStop ):
        CommonAPI.GetAPI().dSpriteRotateTo(self.GetNameAnsi(), fRotation, fRotSpeed, bAutoStop)

	#/ <summary>
	#/ SetSpriteWorldLimit：设置精灵的世界边界坐标限制及碰撞模式
	#/ 参数 Limit：碰撞到世界边界之后的响应模式，如果为OFF，则是关闭世界边界碰撞。其它值见 EWorldLimit
	#/ 参数 fLeft：边界的左边X坐标
	#/ 参数 fTop：边界的上边Y坐标
	#/ 参数 fRight：边界的右边X坐标
	#/ 参数 fBottom：边界的下边Y坐标
	#/ </summary>
    def SetSpriteWorldLimit( self,  Limit,   fLeft,   fTop,   fRight,   fBottom ):
        CommonAPI.GetAPI().dSetSpriteWorldLimit( self.GetNameAnsi(), Limit, fLeft, fTop, fRight, fBottom )

	#/ <summary>
	#/ SetSpriteWorldLimitMode：设置精灵的世界边界碰撞模式
	#/ 参数 Limit：碰撞到世界边界之后的响应模式，如果为OFF，则是关闭世界边界碰撞。其它值见 EWorldLimit
	#/ </summary>
    def SetSpriteWorldLimitMode(  self, Limit ):
        CommonAPI.GetAPI().dSetSpriteWorldLimitMode( self.GetNameAnsi(), Limit )

	#/ <summary>
	#/ SetSpriteWorldLimitMin：设置精灵的世界边界上边及左边坐标限制
	#/ 参数 fLeft：边界的左边X坐标
	#/ 参数 fTop：边界的上边Y坐标
	#/ </summary>
    def SetSpriteWorldLimitMin(   self, fLeft,   fTop ):
        CommonAPI.GetAPI().dSetSpriteWorldLimitMin( self.GetNameAnsi(), fLeft, fTop )
    
	#/ <summary>
	#/ SetSpriteWorldLimitMax：设置精灵的世界边界下边及右边坐标限制
	#/ 参数 fRight：边界的右边X坐标
	#/ 参数 fBottom：边界的下边Y坐标
	#/ </summary>
    def SetSpriteWorldLimitMax(  self,  fRight,   fBottom ):
        CommonAPI.GetAPI().dSetSpriteWorldLimitMax( self.GetNameAnsi(), fRight, fBottom )

	#/ <summary>
	#/ GetSpriteWorldLimitLeft：获取精灵世界边界左边界限制
	#/ </summary>
    def GetSpriteWorldLimitLeft( self):
        return CommonAPI.GetAPI().dGetSpriteWorldLimitLeft(self.GetNameAnsi())

	#/ <summary>
	#/ GetSpriteWorldLimitLeft：获取精灵世界边界上边界限制
	#/ </summary>
    def GetSpriteWorldLimitTop( self):
        return CommonAPI.GetAPI().dGetSpriteWorldLimitTop(self.GetNameAnsi())

	#/ <summary>
	#/ GetSpriteWorldLimitLeft：获取精灵世界边界右边界限制
	#/ </summary>
    def GetSpriteWorldLimitRight( self):
        return CommonAPI.GetAPI().dGetSpriteWorldLimitRight(self.GetNameAnsi())

	#/ <summary>
	#/ GetSpriteWorldLimitLeft：获取精灵世界边界下边界限制
	#/ </summary>
    def GetSpriteWorldLimitBottom( self):
        return CommonAPI.GetAPI().dGetSpriteWorldLimitBottom(self.GetNameAnsi())

	#/ <summary>
	#/ SetSpriteCollisionSend：设置精灵是否可以发送(产生)碰撞
	#/ 精灵的碰撞方式为：当A移动中碰上B时，如果A是可以产生碰撞的，B是可以接受碰撞的，则这2个物体会产生碰撞，精灵碰撞的API将被调用。否则无碰撞发生
	#/ 参数 bSend：true 可以产生 false 不产生
	#/ </summary>
    def SetSpriteCollisionSend(  self, bSend ):
        CommonAPI.GetAPI().dSetSpriteCollisionSend(self.GetNameAnsi(), bSend)

	#/ <summary>
	#/ SetSpriteCollisionReceive：设置精灵是否可以接受碰撞
	#/ 精灵的碰撞方式为：当A移动中碰上B时，如果A是可以产生碰撞的，B是可以接受碰撞的，则这2个物体会产生碰撞，精灵碰撞的API将被调用。否则无碰撞发生
	#/ 参数 bReceive：true 可以接受 false 不接受
	#/ </summary>
    def SetSpriteCollisionReceive(  self, bReceive ):
        CommonAPI.GetAPI().dSetSpriteCollisionReceive(self.GetNameAnsi(), bReceive)

	#/ <summary>
	#/ SetSpriteCollisionActive：同时设置精灵是否可以产生及接受碰撞
	#/ 精灵的碰撞方式为：当A移动中碰上B时，如果A是可以产生碰撞的，B是可以接受碰撞的，则这2个物体会产生碰撞，精灵碰撞的API将被调用。否则无碰撞发生
	#/ 参数 bSend：true 可以产生 false 不产生
	#/ 参数 bReceive：true 可以接受 false 不接受
	#/ </summary>
    def SetSpriteCollisionActive(  self, bSend,  bReceive ):
        CommonAPI.GetAPI().dSetSpriteCollisionActive(self.GetNameAnsi(), bSend, bReceive)

	#/ <summary>
	#/ SetSpriteCollisionPhysicsSend：设置精灵是否可以发送(产生)碰撞
	#/ 参数 bSend：true 可以产生 false 不产生
	#/ </summary>
    def SetSpriteCollisionPhysicsSend( self,  bSend ):
        CommonAPI.GetAPI().dSetSpriteCollisionPhysicsSend(self.GetNameAnsi(), bSend)

	#/ <summary>
	#/ SetSpriteCollisionPhysicsReceive：设置精灵是否可以接受碰撞
	#/ 参数 bReceive：true 可以接受 false 不接受
	#/ </summary>
    def SetSpriteCollisionPhysicsReceive(  self, bReceive ):
        CommonAPI.GetAPI().dSetSpriteCollisionPhysicsReceive(self.GetNameAnsi(), bReceive)

	#/ <summary>
	#/ GetSpriteCollisionSend：获取精灵当前是否是可以产生碰撞
	#/ 返回值：true 可以产生 false 不产生
	#/ </summary>
    def GetSpriteCollisionSend( self):
        return CommonAPI.GetAPI().dGetSpriteCollisionSend( self.GetNameAnsi() )

	#/ <summary>
	#/ GetSpriteCollisionReceive：获取精灵当前是否是可以接受碰撞
	#/ 返回值：true 可以接受 false 不接受
	#/ </summary>
    def GetSpriteCollisionReceive( self):
        return CommonAPI.GetAPI().dGetSpriteCollisionReceive(self.GetNameAnsi())

	#/ <summary>
	#/ SetSpriteCollisionResponse：设置精灵与精灵的碰撞响应模式
	#/ 参数 Response：响应模式，如果为OFF，则为关闭碰撞响应，碰撞API将不会被调用。其它值见 ECollisionResponse
	#/ </summary>
    def SetSpriteCollisionResponse(  self, Response ):
        CommonAPI.GetAPI().dSetSpriteCollisionResponse( self.GetNameAnsi(), Response )

	#/ <summary>
	#/ SetSpriteCollisionMaxIterations：设置精灵碰撞之后的最大反弹次数
	#/ 参数 iTimes：反弹次数
	#/ </summary>
	#/ <param name="iTimes"></param>
    def SetSpriteCollisionMaxIterations(  self,  iTimes ):
        CommonAPI.GetAPI().dSetSpriteCollisionMaxIterations( self.GetNameAnsi(), iTimes )

	#/ <summary>
	#/ SetSpriteForwardMovementOnly：设置精灵是否只能朝前移动
	#/ 参数 bForward：true 只能朝前移动 false 可以朝其他方向移动
	#/ </summary>
	#/ <param name="bForward"></param>
    def SetSpriteForwardMovementOnly(  self, bForward ):
        CommonAPI.GetAPI().dSetSpriteForwardMovementOnly(self.GetNameAnsi(), bForward)

	#/ <summary>
	#/ GetSpriteForwardMovementOnly：获取精灵当前是否只能朝前移动
	#/ 返回值：true 只能朝前移动 false 可以朝其它方向移动
	#/ </summary>
	#/ <returns></returns>
    def GetSpriteForwardMovementOnly( self):
        return CommonAPI.GetAPI().dGetSpriteForwardMovementOnly(self.GetNameAnsi())

	#/ <summary>
	#/ SetSpriteForwardSpeed：设置精灵向前的速度
	#/ 参数 fSpeed：速度
	#/ </summary>
	#/ <param name="fSpeed"></param>
    def SetSpriteForwardSpeed(  self,  fSpeed ):
        CommonAPI.GetAPI().dSetSpriteForwardSpeed( self.GetNameAnsi(), fSpeed )

	#/ <summary>
	#/ SetSpriteImpulseForce：设置精灵瞬间推力
	#/ 参数 fForceX：X方向推力大小
	#/ 参数 fForceY：Y方向推力大小
	#/ 参数 bGravitic：是否计算重力
	#/ </summary>
	#/ <param name="fForceX"></param>
	#/ <param name="fForceY"></param>
	#/ <param name="bGravitic"></param>
    def SetSpriteImpulseForce(  self,  fForceX,   fForceY,  bGravitic ):
        CommonAPI.GetAPI().dSetSpriteImpulseForce(self.GetNameAnsi(), fForceX, fForceY, bGravitic)

	#/ <summary>
	#/ SetSpriteImpulseForcePolar：按角度朝向设置精灵瞬间推力
	#/ 参数 fPolar：角度朝向
	#/ 参数 fForce：推力大小
	#/ 参数 bGravitic：是否计算重力
	#/ </summary>
	#/ <param name="fPolar"></param>
	#/ <param name="fForce"></param>
	#/ <param name="bGravitic"></param>
    def SetSpriteImpulseForcePolar(  self,  fPolar,   fForce,  bGravitic ):
        CommonAPI.GetAPI().dSetSpriteImpulseForcePolar(self.GetNameAnsi(), fPolar, fForce, bGravitic)

	#/ <summary>
	#/ SetSpriteConstantForceX：设置精灵X方向常量推力
	#/ 参数 fForceX：X方向推力大小
	#/ </summary>
	#/ <param name="fForceX"></param>
    def SetSpriteConstantForceX(  self,  fForceX ):
        CommonAPI.GetAPI().dSetSpriteConstantForceX( self.GetNameAnsi(), fForceX )

	#/ <summary>
	#/ SetSpriteConstantForceY：设置精灵Y方向常量推力
	#/ 参数 fForceY：Y方向推力大小
	#/ </summary>
	#/ <param name="fForceY"></param>
    def SetSpriteConstantForceY(  self,  fForceY ):
        CommonAPI.GetAPI().dSetSpriteConstantForceY( self.GetNameAnsi(), fForceY )

	#/ <summary>
	#/ SetSpriteConstantForceGravitic：精灵在计算常量推力的时候，是否计算重力
	#/ 参数 bGravitic：是否计算重力
	#/ </summary>
	#/ <param name="bGravitic"></param>
    def SetSpriteConstantForceGravitic(  self, bGravitic ):
        CommonAPI.GetAPI().dSetSpriteConstantForceGravitic(self.GetNameAnsi(), bGravitic)

	#/ <summary>
	#/ SetSpriteConstantForce：设置精灵常量推力
	#/ 参数 fForceX：X方向推力大小
	#/ 参数 fForceY：Y方向推力大小
	#/ 参数 bGravitic：是否计算重力
	#/ </summary>
	#/ <param name="fForceX"></param>
	#/ <param name="fForceY"></param>
	#/ <param name="bGravitic"></param>
    def SetSpriteConstantForce(  self,  fForceX,   fForceY,  bGravitic ):
        CommonAPI.GetAPI().dSetSpriteConstantForce(self.GetNameAnsi(), fForceX, fForceY, bGravitic)

	#/ <summary>
	#/ SetSpriteConstantForcePolar：按角度朝向设置精灵常量推力
	#/ 参数 fPolar：角度朝向
	#/ 参数 fForce：推力大小
	#/ 参数 bGravitic：是否计算重力
	#/ </summary>
	#/ <param name="fPolar"></param>
	#/ <param name="fForce"></param>
	#/ <param name="bGravitic"></param>
    def SetSpriteConstantForcePolar(  self,  fPolar,   fForce,  bGravitic ):
        CommonAPI.GetAPI().dSetSpriteConstantForcePolar(self.GetNameAnsi(), fPolar, fForce, bGravitic)

	#/ <summary>
	#/ StopSpriteConstantForce：停止精灵常量推力
	#/ </summary>
    def StopSpriteConstantForce( self):
        CommonAPI.GetAPI().dStopSpriteConstantForce( self.GetNameAnsi() )

	#/ <summary>
	#/ SetSpriteForceScale：按倍数缩放精灵当前受的推力
	#/ 参数 fScale：缩放值
	#/ </summary>
	#/ <param name="fScale"></param>
    def SetSpriteForceScale(   self, fScale ):
        CommonAPI.GetAPI().dSetSpriteForceScale( self.GetNameAnsi(), fScale )

	#/ <summary>
	#/ SetSpriteAtRest：暂停/继续精灵的各种受力计算
	#/ 参数 bRest：true 暂停 false 继续
	#/ </summary>
	#/ <param name="bRest"></param>
    def SetSpriteAtRest(  self, bRest ):
        CommonAPI.GetAPI().dSetSpriteAtRest(self.GetNameAnsi(), bRest)

	#/ <summary>
	#/ GetSpriteAtRest：获取精灵当前是否在暂停中
	#/ 返回值：true 暂停中 false 正常
	#/ </summary>
	#/ <returns></returns>
    def GetSpriteAtRest(  self):
        return CommonAPI.GetAPI().dGetSpriteAtRest(self.GetNameAnsi())

	#/ <summary>
	#/ SetSpriteFriction：设置精灵摩擦力
	#/ 参数 fFriction：摩擦力大小
	#/ </summary>
	#/ <param name="fFriction"></param>
    def SetSpriteFriction(  self,  fFriction ):
        CommonAPI.GetAPI().dSetSpriteFriction( self.GetNameAnsi(), fFriction )

	#/ <summary>
	#/ SetSpriteRestitution：设置精灵弹力
	#/ 参数 fRestitution：弹力值大小
	#/ </summary>
	#/ <param name="fRestitution"></param>
    def SetSpriteRestitution(  self,  fRestitution ):
        CommonAPI.GetAPI().dSetSpriteRestitution( self.GetNameAnsi(), fRestitution )

	#/ <summary>
	#/ SetSpriteMass：设置精灵质量
	#/ 参数 fMass：质量大小
	#/ </summary>
	#/ <param name="fMass"></param>
    def SetSpriteMass(  self,  fMass ):
        CommonAPI.GetAPI().dSetSpriteMass( self.GetNameAnsi(), fMass )

	#/ <summary>
	#/ GetSpriteMass：获取精灵质量
	#/ 返回值 ：质量大小
	#/ </summary>
	#/ <returns></returns>
    def GetSpriteMass( self):
        return CommonAPI.GetAPI().dGetSpriteMass( self.GetNameAnsi() )

	#/ <summary>
	#/ SetSpriteAutoMassInertia：开启或者关闭精灵惯性
	#/ 参数 bStatus：true 开启 false 关闭
	#/ </summary>
	#/ <param name="bStatus"></param>
    def SetSpriteAutoMassInertia( self,  bStatus ):
        CommonAPI.GetAPI().dSetSpriteAutoMassInertia(self.GetNameAnsi(), bStatus)

	#/ <summary>
	#/ SetSpriteInertialMoment：设置精灵惯性大小
	#/ 参数 fInert：惯性大小
	#/ </summary>
	#/ <param name="fInert"></param>
    def SetSpriteInertialMoment(  self,  fInert ):
        CommonAPI.GetAPI().dSetSpriteInertialMoment( self.GetNameAnsi(), fInert )

	#/ <summary>
	#/ SetSpriteDamping：设置精灵衰减值
	#/ 参数 fDamp：衰减值大小
	#/ </summary>
	#/ <param name="fDamp"></param>
    def SetSpriteDamping(  self,  fDamp ):
        CommonAPI.GetAPI().dSetSpriteDamping( self.GetNameAnsi(), fDamp )

	#/ <summary>
	#/ SetSpriteImmovable：设置精灵是否不可移动
	#/ 参数 bImmovable：true 不可以移动 false 可以移动
	#/ </summary>
	#/ <param name="bImmovable"></param>
    def SetSpriteImmovable(  self, bImmovable ):
        CommonAPI.GetAPI().dSetSpriteImmovable(self.GetNameAnsi(), bImmovable)

	#/ <summary>
	#/ GetSpriteImmovable：获取精灵当前是否不可以移动
	#/ 返回值：true 不可以移动 false 可以移动
	#/ </summary>
	#/ <returns></returns>
    def GetSpriteImmovable( self):
        return CommonAPI.GetAPI().dGetSpriteImmovable(self.GetNameAnsi())

	#/ <summary>
	#/ SetSpriteLinearVelocity：设置精灵移动速度
	#/ 参数 fVelX：X方向速度
	#/ 参数 fVelY：Y方向速度
	#/ </summary>
	#/ <param name="fVelX"></param>
	#/ <param name="fVelY"></param>
    def SetSpriteLinearVelocity(  self,  fVelX,   fVelY ):
        CommonAPI.GetAPI().dSetSpriteLinearVelocity( self.GetNameAnsi(), fVelX, fVelY )

	#/ <summary>
	#/ SetSpriteLinearVelocityX：设置精灵X方向移动速度
	#/ 参数 fVelX：X方向速度
	#/ </summary>
	#/ <param name="fVelX"></param>
    def SetSpriteLinearVelocityX(  self,  fVelX ):
        CommonAPI.GetAPI().dSetSpriteLinearVelocityX( self.GetNameAnsi(), fVelX )

	#/ <summary>
	#/ SetSpriteLinearVelocityY：设置精灵Y方向移动速度
	#/ 参数 fVelY：Y方向速度
	#/ </summary>
	#/ <param name="fVelY"></param>
    def SetSpriteLinearVelocityY(  self,  fVelY ):
        CommonAPI.GetAPI().dSetSpriteLinearVelocityY( self.GetNameAnsi(), fVelY )

	#/ <summary>
	#/ SetSpriteLinearVelocityPolar：按角度朝向设置精灵移动速度
	#/ 参数 fSpeed：移动速度
	#/ 参数 fPolar：角度朝向
	#/ </summary>
	#/ <param name="fSpeed"></param>
	#/ <param name="fPolar"></param>
    def SetSpriteLinearVelocityPolar(  self,  fSpeed,   fPolar ):
        CommonAPI.GetAPI().dSetSpriteLinearVelocityPolar( self.GetNameAnsi(), fSpeed, fPolar )
 
	#/ <summary>
	#/ SetSpriteAngularVelocity：设置精灵角度旋转速度
	#/ 参数 fAngular：角度旋转速度
	#/ </summary>
	#/ <param name="fAngular"></param>
    def SetSpriteAngularVelocity(  self,  fAngular ):
        CommonAPI.GetAPI().dSetSpriteAngularVelocity( self.GetNameAnsi(), fAngular )

	#/ <summary>
	#/ SetSpriteMinLinearVelocity：设置精灵最小速度
	#/ 参数 fMin：最小速度值
	#/ </summary>
	#/ <param name="fMin"></param>
    def SetSpriteMinLinearVelocity(   self, fMin ):
        CommonAPI.GetAPI().dSetSpriteMinLinearVelocity( self.GetNameAnsi(), fMin )

	#/ <summary>
	#/ SetSpriteMaxLinearVelocity：设置精灵最大速度
	#/ 参数 fMax：最大速度值
	#/ </summary>
	#/ <param name="fMax"></param>
    def SetSpriteMaxLinearVelocity(  self,  fMax ):
        CommonAPI.GetAPI().dSetSpriteMaxLinearVelocity( self.GetNameAnsi(), fMax )

	#/ <summary>
	#/ SetSpriteMinAngularVelocity：设置精灵最小角速度
	#/ 参数 fMin：最小角速度
	#/ </summary>
	#/ <param name="fMin"></param>
    def SetSpriteMinAngularVelocity(  self,  fMin ):
        CommonAPI.GetAPI().dSetSpriteMinAngularVelocity( self.GetNameAnsi(), fMin )

	#/ <summary>
	#/ SetSpriteMaxAngularVelocity：设置精灵最大角速度
	#/ 参数 fMax：最大角速度
	#/ </summary>
	#/ <param name="fMax"></param>
    def SetSpriteMaxAngularVelocity(  self,  fMax ):
        CommonAPI.GetAPI().dSetSpriteMaxAngularVelocity( self.GetNameAnsi(), fMax )

	#/ <summary>
	#/ GetSpriteLinearVelocityX：获取精灵X方向速度
	#/ 返回值：X方向速度
	#/ </summary>
	#/ <returns></returns>
    def GetSpriteLinearVelocityX( self):
        return CommonAPI.GetAPI().dGetSpriteLinearVelocityX( self.GetNameAnsi() )

	#/ <summary>
	#/ GetSpriteLinearVelocityY：获取精灵Y方向速度
	#/ 返回值：Y方向速度
	#/ </summary>
	#/ <returns></returns>
    def GetSpriteLinearVelocityY( self):
        return CommonAPI.GetAPI().dGetSpriteLinearVelocityY( self.GetNameAnsi() )

	#/ <summary>
	#/ SpriteMountToSprite：将一个精灵绑定到另一个精灵上，暂时的成为另一个精灵的一部分，跟随其运动等
	#/ 参数 szDstName：承载绑定的母体精灵名字
	#/ 参数 fOffSetX：绑定偏移X
	#/ 参数 fOffsetY：绑定偏移Y
	#/ 返回值：返回一个绑定ID
	#/ </summary>
	#/ <param name="szDstName"></param>
	#/ <param name="fOffSetX"></param>
	#/ <param name="fOffsetY"></param>
	#/ <returns></returns>
    def SpriteMountToSprite(  self,szDstName,  fOffSetX,  fOffsetY):
        return CommonAPI.GetAPI().dSpriteMountToSprite( self.GetNameAnsi(), szDstName.encode("ascii"), fOffSetX, fOffsetY )

	#/ <summary>
	#/ SpriteMountToSpriteLinkPoint：将一个精灵绑定到另一个精灵上，绑定位置为指定的链接点，暂时的成为另一个精灵的一部分，跟随其运动等
	#/ 参数 szDstName：承载绑定的母体精灵名字
	#/ 参数 iPointId：链接点序号
	#/ 返回值：返回一个绑定ID
	#/ </summary>
	#/ <param name="szDstName"></param>
	#/ <param name="iPointId"></param>
	#/ <returns></returns>
    def SpriteMountToSpriteLinkPoint( self, szDstName,  iPointId):
        return CommonAPI.GetAPI().dSpriteMountToSpriteLinkPoint( self.GetNameAnsi(), szDstName.encode("ascii"), iPointId )

	#/ <summary>
	#/ SetSpriteMountRotation：设置精灵的绑定朝向，即相对于母体的朝向
	#/ 参数 fRot：角度朝向，0 - 360
	#/ </summary>
	#/ <param name="fRot"></param>
    def SetSpriteMountRotation(  self,  fRot ):
        CommonAPI.GetAPI().dSetSpriteMountRotation( self.GetNameAnsi(), fRot )

	#/ <summary>
	#/ GetSpriteMountRotation：获取精灵的绑定朝向，即相对于母体的朝向
	#/ 返回值：角度朝向
	#/ </summary>
	#/ <returns></returns>
    def GetSpriteMountRotation( self):
        return CommonAPI.GetAPI().dGetSpriteMountRotation( self.GetNameAnsi() )

	#/ <summary>
	#/ SetSpriteAutoMountRotation：设置精灵绑定之后自动旋转
	#/ 参数 fRot：旋转速度
	#/ </summary>
	#/ <param name="fRot"></param>
    def SetSpriteAutoMountRotation(  self,  fRot ):
        CommonAPI.GetAPI().dSetSpriteAutoMountRotation( self.GetNameAnsi(), fRot )

	#/ <summary>
	#/ GetSpriteAutoMountRotation：获取精灵绑定之后的自动旋转值
	#/ 返回值：旋转速度
	#/ </summary>
	#/ <returns></returns>
    def GetSpriteAutoMountRotation( self):
        return CommonAPI.GetAPI().dGetSpriteAutoMountRotation( self.GetNameAnsi() )

	#/ <summary>
	#/ SetSpriteMountForce：绑定至另一个精灵时，附加的作用力
	#/ 参数 fFroce：作用力
	#/ </summary>
	#/ <param name="fForce"></param>
    def SetSpriteMountForce(  self,  fForce ):
        CommonAPI.GetAPI().dSetSpriteMountForce( self.GetNameAnsi(), fForce )

	#/ <summary>
	#/ SetSpriteMountTrackRotation：绑定的精灵是否跟随母体旋转
	#/ 参数 bTrackRotation：true 跟随 false 不跟随
	#/ </summary>
	#/ <param name="bTrackRotation"></param>
    def SetSpriteMountTrackRotation( self,  bTrackRotation ):
        CommonAPI.GetAPI().dSetSpriteMountTrackRotation(self.GetNameAnsi(), bTrackRotation)

	#/ <summary>
	#/ SetSpriteMountOwned：母体被删除的时候，绑定的精灵是否也跟着被删除
	#/ 参数 bMountOwned：true 跟着 false 不跟着
	#/ </summary>
	#/ <param name="bMountOwned"></param>
    def SetSpriteMountOwned(  self, bMountOwned ):
        CommonAPI.GetAPI().dSetSpriteMountOwned(self.GetNameAnsi(), bMountOwned)

	#/ <summary>
	#/ SetSpriteMountInheritAttributes：绑定的时候，是否继承母体的属性
	#/ 参数 bInherAttr：true 继承 false 不继承
	#/ </summary>
	#/ <param name="bInherAttr"></param>
    def SetSpriteMountInheritAttributes(  self, bInherAttr ):
        CommonAPI.GetAPI().dSetSpriteMountInheritAttributes(self.GetNameAnsi(), bInherAttr)

	#/ <summary>
	#/ SpriteDismount：将已经绑定的精灵进行解绑
	#/ </summary>
    def SpriteDismount( self):
        CommonAPI.GetAPI().dSpriteDismount( self.GetNameAnsi() )

	#/ <summary>
	#/ GetSpriteIsMounted：判断精灵是否绑定在另一个精灵上
	#/ 返回值：true 绑定 false 不绑定
	#/ </summary>
	#/ <returns></returns>
    def GetSpriteIsMounted( self):
        return CommonAPI.GetAPI().dGetSpriteIsMounted(self.GetNameAnsi())

	#/ <summary>
	#/ GetSpriteMountedParent：获取绑定的母体精灵的名字
	#/ 返回值：母体精灵名字，如果未绑定，则返回空字符串
	#/ </summary>
	#/ <returns></returns>
    def GetSpriteMountedParent( self):
        return CommonAPI.GetAPI().dGetSpriteMountedParent( self.GetNameAnsi() ).decode("ascii")

	#/ <summary>
	#/ SetSpriteColorRed：更改精灵显示颜色中的红色。默认精灵的红绿蓝三颜色的值均为255，修改其中一项将可以改变其颜色
	#/ 参数 iCol：颜色范围 0 - 255
	#/ </summary>
	#/ <param name="iCol"></param>
    def SetSpriteColorRed(  self,  iCol ):
        CommonAPI.GetAPI().dSetSpriteColorRed( self.GetNameAnsi(), iCol )

	#/ <summary>
	#/ SetSpriteColorGreen：更改精灵显示颜色中的绿色。默认精灵的红绿蓝三颜色的值均为255，修改其中一项将可以改变其颜色
	#/ 参数 iCol：颜色范围 0 - 255
	#/ </summary>
	#/ <param name="iCol"></param>
    def SetSpriteColorGreen(  self,  iCol ):
        CommonAPI.GetAPI().dSetSpriteColorGreen( self.GetNameAnsi(), iCol )

	#/ <summary>
	#/ SetSpriteColorBlue：更改精灵显示颜色中的蓝色。默认精灵的红绿蓝三颜色的值均为255，修改其中一项将可以改变其颜色
	#/ 参数 iCol：颜色范围 0 - 255
	#/ </summary>
	#/ <param name="iCol"></param>
    def SetSpriteColorBlue(  self,  iCol ):
        CommonAPI.GetAPI().dSetSpriteColorBlue( self.GetNameAnsi(), iCol )

	#/ <summary>
	#/ SetSpriteColorAlpha：设置精灵透明度
	#/ 参数 iCol：透明度，值0 - 255，从完全透明至完全不透明
	#/ </summary>
	#/ <param name="iCol"></param>
    def SetSpriteColorAlpha(  self,  iCol ):
        CommonAPI.GetAPI().dSetSpriteColorAlpha(  self.GetNameAnsi(), iCol )

	#/ <summary>
	#/ GetSpriteColorRed：获取精灵显示颜色中的红色值
	#/ 返回值：颜色值
	#/ </summary>
	#/ <returns></returns>
    def GetSpriteColorRed( self):
        return CommonAPI.GetAPI().dGetSpriteColorRed( self.GetNameAnsi() )

	#/ <summary>
	#/ GetSpriteColorGreen：获取精灵显示颜色中的绿色值
	#/ 返回值：颜色值
	#/ </summary>
	#/ <returns></returns>
    def GetSpriteColorGreen( self):
        return CommonAPI.GetAPI().dGetSpriteColorGreen( self.GetNameAnsi() )

	#/ <summary>
	#/ GetSpriteColorBlue：获取精灵显示颜色中的蓝色值
	#/ 返回值：颜色值
	#/ </summary>
	#/ <returns></returns>
    def GetSpriteColorBlue( self):
        return CommonAPI.GetAPI().dGetSpriteColorBlue( self.GetNameAnsi() )

	#/ <summary>
	#/ GetSpriteColorAlpha：获取精灵透明度
	#/ 返回值：透明度
	#/ </summary>
	#/ <returns></returns>
    def GetSpriteColorAlpha( self):
        return CommonAPI.GetAPI().dGetSpriteColorAlpha( self.GetNameAnsi() )
