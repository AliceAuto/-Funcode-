using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//////////////////////////////////////////////////////////////////////////////
//
//////////////////////////////////////////////////////////////////////////////

/// <summary>
/// 类：CSprite
/// 所有精灵的基类。包括下面的静态精灵，动态精灵，文字，特效等均由此类继承下去
/// 一般的图片精灵从本类继承下去即可。只有特殊的精灵，比如带动画的精灵，才需要从动态精灵继承下去
/// </summary>
public class CSprite
{
    private string m_szName;		// 精灵名字

	/// <summary>
    /// 构造函数，需要传入一个非空的精灵名字字符串。如果传入的是地图里摆放好的精灵名字，则此类即与地图里的精灵绑定
	/// 如果传入的是一个新的精灵名字，则需要调用成员函数 CloneSprite，复制一份精灵对象实例，才与实际的地图精灵关联起来
    /// </summary>
    public CSprite(string szName)
	{
		m_szName = szName;
	}

    /// <summary>
    /// GetName
	/// 返回值：返回精灵名字
    /// </summary>
    public string GetName()
	{
		return m_szName;
	}
    
	/// <summary>
	/// CloneSprite：复制(创建)一个精灵。精灵的创建方式：先在地图中摆放一个精灵做为模板，设置好各项参数，然后在代码里使用此函数克隆一个实例
	/// 返回值：true表示克隆成功，false克隆失败。失败的原因可能是在地图中未找到对应名字的精灵
	/// 参数 szSrcName：地图中用做模板的精灵名字
	/// </summary>
    public bool CloneSprite(string szSrcName)
	{
		return CommonAPI.dCloneSprite( szSrcName, GetName() ) == 0 ? false : true;
	}

	/// <summary>
	/// DeleteSprite：在地图中删除与本对象实例关联的精灵
	/// </summary>
	public void		DeleteSprite()
	{
		CommonAPI.dDeleteSprite( GetName() );
	}

	/// <summary>
	/// SetSpriteVisible：设置精灵隐藏或者显示(可见不可见)
    /// 参数 bVisible：true 可见 false不可见
	/// </summary>
    public void SetSpriteVisible(bool bVisible)
	{
		CommonAPI.dSetSpriteVisible( GetName(), bVisible ? 1 : 0 );
	}

	/// <summary>
	/// IsSpriteVisible：获取该精灵当前是否可见
	/// </summary>
    public bool IsSpriteVisible()
	{
		return CommonAPI.dIsSpriteVisible( GetName() ) == 0 ? false : true;
	}

	/// <summary>
	/// SetSpriteEnable：禁止或者启用该精灵。被禁止的精灵将不参与任何响应，包括不移动，没有碰撞等，仅仅是在地图中显示
	/// 参数 bEnable：true启用 false禁止
	/// </summary>
    public void SetSpriteEnable(bool bEnable)
	{
		CommonAPI.dSetSpriteEnable( GetName(), bEnable ? 1 : 0 );
	}

	/// <summary>
	/// SetSpriteScale：设置精灵的缩放值
	/// 参数 fScale：缩放值。大于0的值
	/// </summary>
	public void		SetSpriteScale(  float fScale )
	{
		CommonAPI.dSetSpriteScale( GetName(), fScale );
	}

	/// <summary>
	/// IsPointInSprite：判断某个坐标点是否位于精灵内部
	/// 参数 fPosX：X坐标点
	/// 参数 fPosY：Y坐标点
	/// </summary>
    public bool IsPointInSprite(float fPosX, float fPosY)
	{
		return CommonAPI.dIsPointInSprite( GetName(), fPosX, fPosY ) == 0 ? false : true;
	}

	/// <summary>
	/// SetSpritePosition：设置精灵位置
	/// 参数 fPosX：X坐标
	/// 参数 fPosY：Y坐标
	/// </summary>
	public void		SetSpritePosition(  float fPosX,  float fPosY )
	{
		CommonAPI.dSetSpritePosition( GetName(), fPosX, fPosY );
	}

	/// <summary>
	/// SetSpritePositionX：只设置精灵X坐标
	/// 参数 fPosX：X坐标
	/// </summary>
	public void		SetSpritePositionX(  float fPosX )
	{
		CommonAPI.dSetSpritePositionX( GetName(), fPosX );
	}

	/// <summary>
	/// SetSpritePositionY：只设置精灵Y坐标
	/// 参数 fPosY：Y坐标
	/// </summary>
	public void		SetSpritePositionY(  float fPosY )
	{
		CommonAPI.dSetSpritePositionY( GetName(), fPosY );
	}

	/// <summary>
	/// GetSpritePositionX：获取精灵X坐标
	/// 返回值：精灵的X坐标
	/// </summary>
	public float		GetSpritePositionX()
	{
		return CommonAPI.dGetSpritePositionX( GetName() );
	}

	/// <summary>
	/// GetSpritePositionY：获取精灵Y坐标
	/// 返回值：精灵的Y坐标
	/// </summary>
	public float		GetSpritePositionY()
	{
		return CommonAPI.dGetSpritePositionY( GetName() );
	}

	/// <summary>
	/// GetSpriteLinkPointPosX：获取精灵链接点X坐标。链接点是依附于精灵的一个坐标点，可以在编辑器里增加或者删除
	/// 参数 iId：链接点序号，第一个为1，后面依次递加
	/// </summary>
	public float		GetSpriteLinkPointPosX(  int iId )
	{
		return CommonAPI.dGetSpriteLinkPointPosX( GetName(), iId );
	}

	/// <summary>
	/// GetSpriteLinkPointPosY：获取精灵链接点Y坐标。链接点是依附于精灵的一个坐标点，可以在编辑器里增加或者删除
	/// 参数 iId：链接点序号，第一个为1，后面依次递加
	/// </summary>
	public float		GetSpriteLinkPointPosY(  int iId )
	{
		return CommonAPI.dGetSpriteLinkPointPosY( GetName(), iId );
	}

	/// <summary>
	/// SetSpriteRotation：设置精灵的旋转角度
	/// 参数 fRot：旋转角度，范围0 - 360
	/// </summary>
	public void		SetSpriteRotation(  float fRot )
	{
		CommonAPI.dSetSpriteRotation( GetName(), fRot );
	}

	/// <summary>
	/// GetSpriteRotation：获取精灵的旋转角度
	/// 返回值：精灵的旋转角度
	/// </summary>
	public float		GetSpriteRotation()
	{
		return CommonAPI.dGetSpriteRotation( GetName() );
	}

	/// <summary>
	/// SetSpriteAutoRot：设置精灵按照指定速度自动旋转
	/// 参数 fRotSpeed：旋转速度
	/// </summary>
	public void 		SetSpriteAutoRot(  float fRotSpeed )
	{
		CommonAPI.dSetSpriteAutoRot( GetName(), fRotSpeed );
	}

	/// <summary>
	/// SetSpriteWidth：设置精灵外形宽度
	/// 参数 fWidth：宽度值，大于0
	/// </summary>
	public void		SetSpriteWidth(  float fWidth )
	{
		CommonAPI.dSetSpriteWidth( GetName(), fWidth );
	}

	/// <summary>
	/// GetSpriteWidth：获取精灵外形宽度
	/// 返回值：精灵宽度值
	/// </summary>
	public float		GetSpriteWidth()
	{
		return CommonAPI.dGetSpriteWidth( GetName() );
	}

	/// <summary>
	/// SetSpriteHeight：设置精灵外形高度
	/// 参数 fHeight：精灵高度值
	/// </summary>
	public void		SetSpriteHeight(  float fHeight )
	{
		CommonAPI.dSetSpriteHeight( GetName(), fHeight );
	}

	/// <summary>
	/// GetSpriteHeight：获取精灵外形高度
	/// 返回值：精灵高度值
	/// </summary>
	public float		GetSpriteHeight()
	{
		return CommonAPI.dGetSpriteHeight( GetName() );
	}

	/// <summary>
	/// SetSpriteFlipX：设置精灵图片X方向翻转显示
	/// 参数 bFlipX：true 翻转 false不翻转(恢复原来朝向)
	/// </summary>
	public void		SetSpriteFlipX( bool bFlipX )
	{
		CommonAPI.dSetSpriteFlipX( GetName(), bFlipX ? 1 : 0 );
	}

	/// <summary>
	/// GetSpriteFlipX：获取当前精灵图片X方向是否是翻转显示
	/// 返回值：true 翻转 false不翻转
	/// </summary>
	public bool		GetSpriteFlipX()
	{
		return CommonAPI.dGetSpriteFlipX( GetName() ) == 0 ? false : true;
	}
	/// <summary>
	/// SetSpriteFlipY：设置精灵图片Y方向翻转显示
	/// 参数 bFlipY：true 翻转 false不翻转(恢复原来朝向)
	/// </summary>
	public void		SetSpriteFlipY( bool bFlipY )
	{
		CommonAPI.dSetSpriteFlipY( GetName(), bFlipY ? 1 : 0 );
	}

	/// <summary>
	/// GetSpriteFlipY：获取当前精灵图片Y方向是否是翻转显示
	/// 返回值：true 翻转 false不翻转
	/// </summary>
	public bool		GetSpriteFlipY()
	{
        return CommonAPI.dGetSpriteFlipY(GetName()) == 0 ? false : true;
	}

	/// <summary>
	/// SetSpriteFlip：同时设置精灵翻转X及Y方向
	/// 参数 bFlipX：true 翻转 false不翻转(恢复原来朝向)
	/// 参数 bFlipY：true 翻转 false不翻转(恢复原来朝向)
	/// </summary>
	public void		SetSpriteFlip( bool bFlipX, bool bFlipY )
	{
        CommonAPI.dSetSpriteFlip(GetName(), bFlipX ? 1 : 0, bFlipY ? 1 : 0);
	}

	/// <summary>
	/// SetSpriteLifeTime：设置精灵的生命时长，时间到了之后将自动被删除
	/// 参数 fLifeTime：生命时长，单位 秒
	/// </summary>
	public void		SetSpriteLifeTime(  float fLifeTime )
	{
		CommonAPI.dSetSpriteLifeTime( GetName(), fLifeTime );
	}

	/// <summary>
	/// GetSpriteLifeTime：获取精灵生命时长
	/// 返回值：生命时长，单位 秒
	/// </summary>
	public float		GetSpriteLifeTime()
	{
		return CommonAPI.dGetSpriteLifeTime( GetName() );
	}
    
	/// <summary>
	/// SpriteMoveTo：让精灵按照给定速度移动到给定坐标点
	/// 参数 fPosX：移动的目标X坐标值
	/// 参数 fPosY：移动的目标Y坐标值
	/// 参数 fSpeed：移动速度
	/// 参数 bAutoStop：移动到终点之后是否自动停止
	/// </summary>
	public void		SpriteMoveTo(  float fPosX,  float fPosY,  float fSpeed, bool bAutoStop )
	{
        CommonAPI.dSpriteMoveTo(GetName(), fPosX, fPosY, fSpeed, bAutoStop ? 1 : 0);
	}

	/// <summary>
	/// SpriteRotateTo：让精灵按照给定速度旋转到给定的角度
	/// 参数 fRotation：给定的目标旋转值
	/// 参数 fRotSpeed：旋转速度
	/// 参数 bAutoStop：旋转到终点之后是否自动停止
	/// </summary>
	public void		SpriteRotateTo(  float fRotation,  float fRotSpeed, bool bAutoStop )
	{
        CommonAPI.dSpriteRotateTo(GetName(), fRotation, fRotSpeed, bAutoStop ? 1 : 0);
	}

	/// <summary>
	/// SetSpriteWorldLimit：设置精灵的世界边界坐标限制及碰撞模式
	/// 参数 Limit：碰撞到世界边界之后的响应模式，如果为OFF，则是关闭世界边界碰撞。其它值见 EWorldLimit
	/// 参数 fLeft：边界的左边X坐标
	/// 参数 fTop：边界的上边Y坐标
	/// 参数 fRight：边界的右边X坐标
	/// 参数 fBottom：边界的下边Y坐标
	/// </summary>
	public void		SetSpriteWorldLimit(  EWorldLimit Limit,  float fLeft,  float fTop,  float fRight,  float fBottom )
	{
		CommonAPI.dSetSpriteWorldLimit( GetName(), Limit, fLeft, fTop, fRight, fBottom );
	}

	/// <summary>
	/// SetSpriteWorldLimitMode：设置精灵的世界边界碰撞模式
	/// 参数 Limit：碰撞到世界边界之后的响应模式，如果为OFF，则是关闭世界边界碰撞。其它值见 EWorldLimit
	/// </summary>
	public void		SetSpriteWorldLimitMode(  EWorldLimit Limit )
	{
		CommonAPI.dSetSpriteWorldLimitMode( GetName(), Limit );
	}

	/// <summary>
	/// SetSpriteWorldLimitMin：设置精灵的世界边界上边及左边坐标限制
	/// 参数 fLeft：边界的左边X坐标
	/// 参数 fTop：边界的上边Y坐标
	/// </summary>
	public void		SetSpriteWorldLimitMin(  float fLeft,  float fTop )
	{
		CommonAPI.dSetSpriteWorldLimitMin( GetName(), fLeft, fTop );
	}
    
	/// <summary>
	/// SetSpriteWorldLimitMax：设置精灵的世界边界下边及右边坐标限制
	/// 参数 fRight：边界的右边X坐标
	/// 参数 fBottom：边界的下边Y坐标
	/// </summary>
	public void		SetSpriteWorldLimitMax(  float fRight,  float fBottom )
	{
		CommonAPI.dSetSpriteWorldLimitMax( GetName(), fRight, fBottom );
	}

	/// <summary>
	/// GetSpriteWorldLimitLeft：获取精灵世界边界左边界限制
	/// </summary>
	public float floatGetSpriteWorldLimitLeft()
	{
		return CommonAPI.dGetSpriteWorldLimitLeft(GetName());
	}

	/// <summary>
	/// GetSpriteWorldLimitLeft：获取精灵世界边界上边界限制
	/// </summary>
	public float GetSpriteWorldLimitTop()
	{
		return CommonAPI.dGetSpriteWorldLimitTop(GetName());
	}

	/// <summary>
	/// GetSpriteWorldLimitLeft：获取精灵世界边界右边界限制
	/// </summary>
	public float GetSpriteWorldLimitRight()
	{
		return CommonAPI.dGetSpriteWorldLimitRight(GetName());
	}

	/// <summary>
	/// GetSpriteWorldLimitLeft：获取精灵世界边界下边界限制
	/// </summary>
	public float GetSpriteWorldLimitBottom()
	{
		return CommonAPI.dGetSpriteWorldLimitBottom(GetName());
	}

	/// <summary>
	/// SetSpriteCollisionSend：设置精灵是否可以发送(产生)碰撞
	/// 精灵的碰撞方式为：当A移动中碰上B时，如果A是可以产生碰撞的，B是可以接受碰撞的，则这2个物体会产生碰撞，精灵碰撞的API将被调用。否则无碰撞发生
	/// 参数 bSend：true 可以产生 false 不产生
	/// </summary>
	public void 		SetSpriteCollisionSend( bool bSend )
	{
        CommonAPI.dSetSpriteCollisionSend(GetName(), bSend ? 1 : 0);
	}

	/// <summary>
	/// SetSpriteCollisionReceive：设置精灵是否可以接受碰撞
	/// 精灵的碰撞方式为：当A移动中碰上B时，如果A是可以产生碰撞的，B是可以接受碰撞的，则这2个物体会产生碰撞，精灵碰撞的API将被调用。否则无碰撞发生
	/// 参数 bReceive：true 可以接受 false 不接受
	/// </summary>
	public void 		SetSpriteCollisionReceive( bool bReceive )
	{
        CommonAPI.dSetSpriteCollisionReceive(GetName(), bReceive ? 1 : 0);
	}

	/// <summary>
	/// SetSpriteCollisionActive：同时设置精灵是否可以产生及接受碰撞
	/// 精灵的碰撞方式为：当A移动中碰上B时，如果A是可以产生碰撞的，B是可以接受碰撞的，则这2个物体会产生碰撞，精灵碰撞的API将被调用。否则无碰撞发生
	/// 参数 bSend：true 可以产生 false 不产生
	/// 参数 bReceive：true 可以接受 false 不接受
	/// </summary>
	public void 		SetSpriteCollisionActive( bool bSend, bool bReceive )
	{
        CommonAPI.dSetSpriteCollisionActive(GetName(), bSend ? 1 : 0, bReceive ? 1 : 0);
	}

	/// <summary>
	/// SetSpriteCollisionPhysicsSend：设置精灵是否可以发送(产生)碰撞
	/// 参数 bSend：true 可以产生 false 不产生
	/// </summary>
	public void 		SetSpriteCollisionPhysicsSend( bool bSend )
	{
        CommonAPI.dSetSpriteCollisionPhysicsSend(GetName(), bSend ? 1 : 0);
	}

	/// <summary>
	/// SetSpriteCollisionPhysicsReceive：设置精灵是否可以接受碰撞
	/// 参数 bReceive：true 可以接受 false 不接受
	/// </summary>
	public void 		SetSpriteCollisionPhysicsReceive( bool bReceive )
	{
        CommonAPI.dSetSpriteCollisionPhysicsReceive(GetName(), bReceive ? 1 : 0);
	}

	/// <summary>
	/// GetSpriteCollisionSend：获取精灵当前是否是可以产生碰撞
	/// 返回值：true 可以产生 false 不产生
	/// </summary>
	public bool 		GetSpriteCollisionSend()
	{
		return CommonAPI.dGetSpriteCollisionSend( GetName() ) == 0 ? false : true;
	}

	/// <summary>
	/// GetSpriteCollisionReceive：获取精灵当前是否是可以接受碰撞
	/// 返回值：true 可以接受 false 不接受
	/// </summary>
	public bool 		GetSpriteCollisionReceive()
	{
        return CommonAPI.dGetSpriteCollisionReceive(GetName()) == 0 ? false : true;
	}

	/// <summary>
	/// SetSpriteCollisionResponse：设置精灵与精灵的碰撞响应模式
	/// 参数 Response：响应模式，如果为OFF，则为关闭碰撞响应，碰撞API将不会被调用。其它值见 ECollisionResponse
	/// </summary>
	public void		SetSpriteCollisionResponse(  ECollisionResponse Response )
	{
		CommonAPI.dSetSpriteCollisionResponse( GetName(), Response );
	}

	/// <summary>
	/// SetSpriteCollisionMaxIterations：设置精灵碰撞之后的最大反弹次数
	/// 参数 iTimes：反弹次数
	/// </summary>
	/// <param name="iTimes"></param>
	public void		SetSpriteCollisionMaxIterations(  int iTimes )
	{
		CommonAPI.dSetSpriteCollisionMaxIterations( GetName(), iTimes );
	}

	/// <summary>
	/// SetSpriteForwardMovementOnly：设置精灵是否只能朝前移动
	/// 参数 bForward：true 只能朝前移动 false 可以朝其他方向移动
	/// </summary>
	/// <param name="bForward"></param>
	public void		SetSpriteForwardMovementOnly( bool bForward )
	{
        CommonAPI.dSetSpriteForwardMovementOnly(GetName(), bForward ? 1 : 0);
	}

	/// <summary>
	/// GetSpriteForwardMovementOnly：获取精灵当前是否只能朝前移动
	/// 返回值：true 只能朝前移动 false 可以朝其它方向移动
	/// </summary>
	/// <returns></returns>
	public bool		GetSpriteForwardMovementOnly()
	{
        return CommonAPI.dGetSpriteForwardMovementOnly(GetName()) == 0 ? false : true;
	}

	/// <summary>
	/// SetSpriteForwardSpeed：设置精灵向前的速度
	/// 参数 fSpeed：速度
	/// </summary>
	/// <param name="fSpeed"></param>
	public void		SetSpriteForwardSpeed(  float fSpeed )
	{
		CommonAPI.dSetSpriteForwardSpeed( GetName(), fSpeed );
	}

	/// <summary>
	/// SetSpriteImpulseForce：设置精灵瞬间推力
	/// 参数 fForceX：X方向推力大小
	/// 参数 fForceY：Y方向推力大小
	/// 参数 bGravitic：是否计算重力
	/// </summary>
	/// <param name="fForceX"></param>
	/// <param name="fForceY"></param>
	/// <param name="bGravitic"></param>
	public void 		SetSpriteImpulseForce(  float fForceX,  float fForceY, bool bGravitic )
	{
        CommonAPI.dSetSpriteImpulseForce(GetName(), fForceX, fForceY, bGravitic ? 1 : 0);
	}

	/// <summary>
	/// SetSpriteImpulseForcePolar：按角度朝向设置精灵瞬间推力
	/// 参数 fPolar：角度朝向
	/// 参数 fForce：推力大小
	/// 参数 bGravitic：是否计算重力
	/// </summary>
	/// <param name="fPolar"></param>
	/// <param name="fForce"></param>
	/// <param name="bGravitic"></param>
	public void 		SetSpriteImpulseForcePolar(  float fPolar,  float fForce, bool bGravitic )
	{
        CommonAPI.dSetSpriteImpulseForcePolar(GetName(), fPolar, fForce, bGravitic ? 1 : 0);
	}

	/// <summary>
	/// SetSpriteConstantForceX：设置精灵X方向常量推力
	/// 参数 fForceX：X方向推力大小
	/// </summary>
	/// <param name="fForceX"></param>
	public void 		SetSpriteConstantForceX(  float fForceX )
	{
		CommonAPI.dSetSpriteConstantForceX( GetName(), fForceX );
	}

	/// <summary>
	/// SetSpriteConstantForceY：设置精灵Y方向常量推力
	/// 参数 fForceY：Y方向推力大小
	/// </summary>
	/// <param name="fForceY"></param>
	public void 		SetSpriteConstantForceY(  float fForceY )
	{
		CommonAPI.dSetSpriteConstantForceY( GetName(), fForceY );
	}

	/// <summary>
	/// SetSpriteConstantForceGravitic：精灵在计算常量推力的时候，是否计算重力
	/// 参数 bGravitic：是否计算重力
	/// </summary>
	/// <param name="bGravitic"></param>
	public void 		SetSpriteConstantForceGravitic( bool bGravitic )
	{
        CommonAPI.dSetSpriteConstantForceGravitic(GetName(), bGravitic ? 1 : 0);
	}

	/// <summary>
	/// SetSpriteConstantForce：设置精灵常量推力
	/// 参数 fForceX：X方向推力大小
	/// 参数 fForceY：Y方向推力大小
	/// 参数 bGravitic：是否计算重力
	/// </summary>
	/// <param name="fForceX"></param>
	/// <param name="fForceY"></param>
	/// <param name="bGravitic"></param>
	public void 		SetSpriteConstantForce(  float fForceX,  float fForceY, bool bGravitic )
	{
        CommonAPI.dSetSpriteConstantForce(GetName(), fForceX, fForceY, bGravitic ? 1 : 0);
	}

	/// <summary>
	/// SetSpriteConstantForcePolar：按角度朝向设置精灵常量推力
	/// 参数 fPolar：角度朝向
	/// 参数 fForce：推力大小
	/// 参数 bGravitic：是否计算重力
	/// </summary>
	/// <param name="fPolar"></param>
	/// <param name="fForce"></param>
	/// <param name="bGravitic"></param>
	public void 		SetSpriteConstantForcePolar(  float fPolar,  float fForce, bool bGravitic )
	{
        CommonAPI.dSetSpriteConstantForcePolar(GetName(), fPolar, fForce, bGravitic ? 1 : 0);
	}

	/// <summary>
	/// StopSpriteConstantForce：停止精灵常量推力
	/// </summary>
	public void 		StopSpriteConstantForce()
	{
		CommonAPI.dStopSpriteConstantForce( GetName() );
	}

	/// <summary>
	/// SetSpriteForceScale：按倍数缩放精灵当前受的推力
	/// 参数 fScale：缩放值
	/// </summary>
	/// <param name="fScale"></param>
	public void 		SetSpriteForceScale(  float fScale )
	{
		CommonAPI.dSetSpriteForceScale( GetName(), fScale );
	}

	/// <summary>
	/// SetSpriteAtRest：暂停/继续精灵的各种受力计算
	/// 参数 bRest：true 暂停 false 继续
	/// </summary>
	/// <param name="bRest"></param>
	public void 		SetSpriteAtRest( bool bRest )
	{
        CommonAPI.dSetSpriteAtRest(GetName(), bRest ? 1 : 0);
	}

	/// <summary>
	/// GetSpriteAtRest：获取精灵当前是否在暂停中
	/// 返回值：true 暂停中 false 正常
	/// </summary>
	/// <returns></returns>
	public bool 		GetSpriteAtRest( )
	{
        return CommonAPI.dGetSpriteAtRest(GetName()) == 0 ? false : true;
	}

	/// <summary>
	/// SetSpriteFriction：设置精灵摩擦力
	/// 参数 fFriction：摩擦力大小
	/// </summary>
	/// <param name="fFriction"></param>
	public void 		SetSpriteFriction(  float fFriction )
	{
		CommonAPI.dSetSpriteFriction( GetName(), fFriction );
	}

	/// <summary>
	/// SetSpriteRestitution：设置精灵弹力
	/// 参数 fRestitution：弹力值大小
	/// </summary>
	/// <param name="fRestitution"></param>
	public void 		SetSpriteRestitution(  float fRestitution )
	{
		CommonAPI.dSetSpriteRestitution( GetName(), fRestitution );
	}

	/// <summary>
	/// SetSpriteMass：设置精灵质量
	/// 参数 fMass：质量大小
	/// </summary>
	/// <param name="fMass"></param>
	public void 		SetSpriteMass(  float fMass )
	{
		CommonAPI.dSetSpriteMass( GetName(), fMass );
	}

	/// <summary>
	/// GetSpriteMass：获取精灵质量
	/// 返回值 ：质量大小
	/// </summary>
	/// <returns></returns>
	public float 		GetSpriteMass()
	{
		return CommonAPI.dGetSpriteMass( GetName() );
	}

	/// <summary>
	/// SetSpriteAutoMassInertia：开启或者关闭精灵惯性
	/// 参数 bStatus：true 开启 false 关闭
	/// </summary>
	/// <param name="bStatus"></param>
	public void 		SetSpriteAutoMassInertia( bool bStatus )
	{
        CommonAPI.dSetSpriteAutoMassInertia(GetName(), bStatus ? 1 : 0);
	}

	/// <summary>
	/// SetSpriteInertialMoment：设置精灵惯性大小
	/// 参数 fInert：惯性大小
	/// </summary>
	/// <param name="fInert"></param>
	public void 		SetSpriteInertialMoment(  float fInert )
	{
		CommonAPI.dSetSpriteInertialMoment( GetName(), fInert );
	}

	/// <summary>
	/// SetSpriteDamping：设置精灵衰减值
	/// 参数 fDamp：衰减值大小
	/// </summary>
	/// <param name="fDamp"></param>
	public void 		SetSpriteDamping(  float fDamp )
	{
		CommonAPI.dSetSpriteDamping( GetName(), fDamp );
	}
    	
	/// <summary>
	/// SetSpriteImmovable：设置精灵是否不可移动
	/// 参数 bImmovable：true 不可以移动 false 可以移动
	/// </summary>
	/// <param name="bImmovable"></param>
	public void 		SetSpriteImmovable( bool bImmovable )
	{
        CommonAPI.dSetSpriteImmovable(GetName(), bImmovable ? 1 : 0);
	}

	/// <summary>
	/// GetSpriteImmovable：获取精灵当前是否不可以移动
	/// 返回值：true 不可以移动 false 可以移动
	/// </summary>
	/// <returns></returns>
	public bool 		GetSpriteImmovable()
	{
        return CommonAPI.dGetSpriteImmovable(GetName()) == 0 ? false : true;
	}

	/// <summary>
	/// SetSpriteLinearVelocity：设置精灵移动速度
	/// 参数 fVelX：X方向速度
	/// 参数 fVelY：Y方向速度
	/// </summary>
	/// <param name="fVelX"></param>
	/// <param name="fVelY"></param>
	public void 		SetSpriteLinearVelocity(  float fVelX,  float fVelY )
	{
		CommonAPI.dSetSpriteLinearVelocity( GetName(), fVelX, fVelY );
	}

	/// <summary>
	/// SetSpriteLinearVelocityX：设置精灵X方向移动速度
	/// 参数 fVelX：X方向速度
	/// </summary>
	/// <param name="fVelX"></param>
	public void 		SetSpriteLinearVelocityX(  float fVelX )
	{
		CommonAPI.dSetSpriteLinearVelocityX( GetName(), fVelX );
	}

	/// <summary>
	/// SetSpriteLinearVelocityY：设置精灵Y方向移动速度
	/// 参数 fVelY：Y方向速度
	/// </summary>
	/// <param name="fVelY"></param>
	public void 		SetSpriteLinearVelocityY(  float fVelY )
	{
		CommonAPI.dSetSpriteLinearVelocityY( GetName(), fVelY );
	}

	/// <summary>
	/// SetSpriteLinearVelocityPolar：按角度朝向设置精灵移动速度
	/// 参数 fSpeed：移动速度
	/// 参数 fPolar：角度朝向
	/// </summary>
	/// <param name="fSpeed"></param>
	/// <param name="fPolar"></param>
	public void 		SetSpriteLinearVelocityPolar(  float fSpeed,  float fPolar )
	{
		CommonAPI.dSetSpriteLinearVelocityPolar( GetName(), fSpeed, fPolar );
	}
 
	/// <summary>
	/// SetSpriteAngularVelocity：设置精灵角度旋转速度
	/// 参数 fAngular：角度旋转速度
	/// </summary>
	/// <param name="fAngular"></param>
	public void 		SetSpriteAngularVelocity(  float fAngular )
	{
		CommonAPI.dSetSpriteAngularVelocity( GetName(), fAngular );
	}

	/// <summary>
	/// SetSpriteMinLinearVelocity：设置精灵最小速度
	/// 参数 fMin：最小速度值
	/// </summary>
	/// <param name="fMin"></param>
	public void 		SetSpriteMinLinearVelocity(  float fMin )
	{
		CommonAPI.dSetSpriteMinLinearVelocity( GetName(), fMin );
	}

	/// <summary>
	/// SetSpriteMaxLinearVelocity：设置精灵最大速度
	/// 参数 fMax：最大速度值
	/// </summary>
	/// <param name="fMax"></param>
	public void 		SetSpriteMaxLinearVelocity(  float fMax )
	{
		CommonAPI.dSetSpriteMaxLinearVelocity( GetName(), fMax );
	}

	/// <summary>
	/// SetSpriteMinAngularVelocity：设置精灵最小角速度
	/// 参数 fMin：最小角速度
	/// </summary>
	/// <param name="fMin"></param>
	public void 		SetSpriteMinAngularVelocity(  float fMin )
	{
		CommonAPI.dSetSpriteMinAngularVelocity( GetName(), fMin );
	}

	/// <summary>
	/// SetSpriteMaxAngularVelocity：设置精灵最大角速度
	/// 参数 fMax：最大角速度
	/// </summary>
	/// <param name="fMax"></param>
	public void 		SetSpriteMaxAngularVelocity(  float fMax )
	{
		CommonAPI.dSetSpriteMaxAngularVelocity( GetName(), fMax );
	}
    	
	/// <summary>
	/// GetSpriteLinearVelocityX：获取精灵X方向速度
	/// 返回值：X方向速度
	/// </summary>
	/// <returns></returns>
	public float 		GetSpriteLinearVelocityX()
	{
		return CommonAPI.dGetSpriteLinearVelocityX( GetName() );
	}

	/// <summary>
	/// GetSpriteLinearVelocityY：获取精灵Y方向速度
	/// 返回值：Y方向速度
	/// </summary>
	/// <returns></returns>
	public float 		GetSpriteLinearVelocityY()
	{
		return CommonAPI.dGetSpriteLinearVelocityY( GetName() );
	}
    
	/// <summary>
	/// SpriteMountToSprite：将一个精灵绑定到另一个精灵上，暂时的成为另一个精灵的一部分，跟随其运动等
	/// 参数 szDstName：承载绑定的母体精灵名字
	/// 参数 fOffSetX：绑定偏移X
	/// 参数 fOffsetY：绑定偏移Y
	/// 返回值：返回一个绑定ID
	/// </summary>
	/// <param name="szDstName"></param>
	/// <param name="fOffSetX"></param>
	/// <param name="fOffsetY"></param>
	/// <returns></returns>
    public int SpriteMountToSprite(string szDstName, float fOffSetX, float fOffsetY)
	{
		return CommonAPI.dSpriteMountToSprite( GetName(), szDstName, fOffSetX, fOffsetY );
	}

	/// <summary>
	/// SpriteMountToSpriteLinkPoint：将一个精灵绑定到另一个精灵上，绑定位置为指定的链接点，暂时的成为另一个精灵的一部分，跟随其运动等
	/// 参数 szDstName：承载绑定的母体精灵名字
	/// 参数 iPointId：链接点序号
	/// 返回值：返回一个绑定ID
	/// </summary>
	/// <param name="szDstName"></param>
	/// <param name="iPointId"></param>
	/// <returns></returns>
    public int SpriteMountToSpriteLinkPoint(string szDstName, int iPointId)
	{
		return CommonAPI.dSpriteMountToSpriteLinkPoint( GetName(), szDstName, iPointId );
	}

	/// <summary>
	/// SetSpriteMountRotation：设置精灵的绑定朝向，即相对于母体的朝向
	/// 参数 fRot：角度朝向，0 - 360
	/// </summary>
	/// <param name="fRot"></param>
	public void		SetSpriteMountRotation(  float fRot )
	{
		CommonAPI.dSetSpriteMountRotation( GetName(), fRot );
	}

	/// <summary>
	/// GetSpriteMountRotation：获取精灵的绑定朝向，即相对于母体的朝向
	/// 返回值：角度朝向
	/// </summary>
	/// <returns></returns>
	public float		GetSpriteMountRotation()
	{
		return CommonAPI.dGetSpriteMountRotation( GetName() );
	}

	/// <summary>
	/// SetSpriteAutoMountRotation：设置精灵绑定之后自动旋转
	/// 参数 fRot：旋转速度
	/// </summary>
	/// <param name="fRot"></param>
	public void		SetSpriteAutoMountRotation(  float fRot )
	{
		CommonAPI.dSetSpriteAutoMountRotation( GetName(), fRot );
	}

	/// <summary>
	/// GetSpriteAutoMountRotation：获取精灵绑定之后的自动旋转值
	/// 返回值：旋转速度
	/// </summary>
	/// <returns></returns>
	public float		GetSpriteAutoMountRotation()
	{
		return CommonAPI.dGetSpriteAutoMountRotation( GetName() );
	}

	/// <summary>
	/// SetSpriteMountForce：绑定至另一个精灵时，附加的作用力
	/// 参数 fFroce：作用力
	/// </summary>
	/// <param name="fForce"></param>
	public void		SetSpriteMountForce(  float fForce )
	{
		CommonAPI.dSetSpriteMountForce( GetName(), fForce );
	}

	/// <summary>
	/// SetSpriteMountTrackRotation：绑定的精灵是否跟随母体旋转
	/// 参数 bTrackRotation：true 跟随 false 不跟随
	/// </summary>
	/// <param name="bTrackRotation"></param>
	public void		SetSpriteMountTrackRotation( bool bTrackRotation )
	{
        CommonAPI.dSetSpriteMountTrackRotation(GetName(), bTrackRotation ? 1 : 0);
	}

	/// <summary>
	/// SetSpriteMountOwned：母体被删除的时候，绑定的精灵是否也跟着被删除
	/// 参数 bMountOwned：true 跟着 false 不跟着
	/// </summary>
	/// <param name="bMountOwned"></param>
	public void		SetSpriteMountOwned( bool bMountOwned )
	{
        CommonAPI.dSetSpriteMountOwned(GetName(), bMountOwned ? 1 : 0);
	}

	/// <summary>
	/// SetSpriteMountInheritAttributes：绑定的时候，是否继承母体的属性
	/// 参数 bInherAttr：true 继承 false 不继承
	/// </summary>
	/// <param name="bInherAttr"></param>
	public void		SetSpriteMountInheritAttributes( bool bInherAttr )
	{
        CommonAPI.dSetSpriteMountInheritAttributes(GetName(), bInherAttr ? 1 : 0);
	}

	/// <summary>
	/// SpriteDismount：将已经绑定的精灵进行解绑
	/// </summary>
	public void		SpriteDismount()
	{
		CommonAPI.dSpriteDismount( GetName() );
	}

	/// <summary>
	/// GetSpriteIsMounted：判断精灵是否绑定在另一个精灵上
	/// 返回值：true 绑定 false 不绑定
	/// </summary>
	/// <returns></returns>
	public bool		GetSpriteIsMounted()
	{
        return CommonAPI.dGetSpriteIsMounted(GetName()) == 0 ? false : true;
	}

	/// <summary>
	/// GetSpriteMountedParent：获取绑定的母体精灵的名字
	/// 返回值：母体精灵名字，如果未绑定，则返回空字符串
	/// </summary>
	/// <returns></returns>
    public string GetSpriteMountedParent()
	{
		return CommonAPI.dGetSpriteMountedParent( GetName() );
	}

	/// <summary>
	/// SetSpriteColorRed：更改精灵显示颜色中的红色。默认精灵的红绿蓝三颜色的值均为255，修改其中一项将可以改变其颜色
	/// 参数 iCol：颜色范围 0 - 255
	/// </summary>
	/// <param name="iCol"></param>
	public void		SetSpriteColorRed(  int iCol )
	{
		CommonAPI.dSetSpriteColorRed( GetName(), iCol );
	}

	/// <summary>
	/// SetSpriteColorGreen：更改精灵显示颜色中的绿色。默认精灵的红绿蓝三颜色的值均为255，修改其中一项将可以改变其颜色
	/// 参数 iCol：颜色范围 0 - 255
	/// </summary>
	/// <param name="iCol"></param>
	public void		SetSpriteColorGreen(  int iCol )
	{
		CommonAPI.dSetSpriteColorGreen( GetName(), iCol );
	}

	/// <summary>
	/// SetSpriteColorBlue：更改精灵显示颜色中的蓝色。默认精灵的红绿蓝三颜色的值均为255，修改其中一项将可以改变其颜色
	/// 参数 iCol：颜色范围 0 - 255
	/// </summary>
	/// <param name="iCol"></param>
	public void		SetSpriteColorBlue(  int iCol )
	{
		CommonAPI.dSetSpriteColorBlue( GetName(), iCol );
	}

	/// <summary>
	/// SetSpriteColorAlpha：设置精灵透明度
	/// 参数 iCol：透明度，值0 - 255，从完全透明至完全不透明
	/// </summary>
	/// <param name="iCol"></param>
	public void		SetSpriteColorAlpha(  int iCol )
	{
		CommonAPI.dSetSpriteColorAlpha(  GetName(), iCol );
	}

	/// <summary>
	/// GetSpriteColorRed：获取精灵显示颜色中的红色值
	/// 返回值：颜色值
	/// </summary>
	/// <returns></returns>
	public int			GetSpriteColorRed()
	{
		return CommonAPI.dGetSpriteColorRed( GetName() );
	}

	/// <summary>
	/// GetSpriteColorGreen：获取精灵显示颜色中的绿色值
	/// 返回值：颜色值
	/// </summary>
	/// <returns></returns>
	public int			GetSpriteColorGreen()
	{
		return CommonAPI.dGetSpriteColorGreen( GetName() );
	}

	/// <summary>
	/// GetSpriteColorBlue：获取精灵显示颜色中的蓝色值
	/// 返回值：颜色值
	/// </summary>
	/// <returns></returns>
	public int			GetSpriteColorBlue()
	{
		return CommonAPI.dGetSpriteColorBlue( GetName() );
	}

	/// <summary>
	/// GetSpriteColorAlpha：获取精灵透明度
	/// 返回值：透明度
	/// </summary>
	/// <returns></returns>
	public int			GetSpriteColorAlpha()
	{
		return CommonAPI.dGetSpriteColorAlpha( GetName() );
	}
};