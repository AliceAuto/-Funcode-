/**
 * @(#)JSprite.java
 *
 * JSprite application
 *
 * @author
 * @version 1.00
 */

 package FunCode;

 import FunCode.EngineAPI;
/**
 * 类：JSprite
 * 所有精灵的基类。包括下面的静态精灵，动态精灵，文字，特效等均由此类继承下去
 * 一般的图片精灵从本类继承下去即可。只有特殊的精灵，比如带动画的精灵，才需要从动态精灵继承下去
 * @author root
 *
 */
public class JSprite
{
	private	String		m_szName;		// 精灵名字

	/**
	 * 构造函数，需要传入一个非空的精灵名字字符串。如果传入的是地图里摆放好的精灵名字，则此类即与地图里的精灵绑定
	 * 如果传入的是一个新的精灵名字，则需要调用成员函数 CloneSprite，复制一份精灵对象实例，才与实际的地图精灵关联起来
	 * @param 参数szName:精灵名字
	 */
	public JSprite( String szName )
	{
		m_szName = szName;
	}

	/**
	 * GetName
	 * @return 返回值：返回精灵名字
	 */
	public String GetName()
	{
		return m_szName;
	}

	/**
	 * CloneSprite：复制(创建)一个精灵。精灵的创建方式：先在地图中摆放一个精灵做为模板，设置好各项参数，然后在代码里使用此函数克隆一个实例
	 * @param 参数 szSrcName：地图中用做模板的精灵名字
	 * @return 返回值：true表示克隆成功，false克隆失败。失败的原因可能是在地图中未找到对应名字的精灵
	 */
	public boolean		CloneSprite( String szSrcName )
	{
		return EngineAPI.CloneSprite( szSrcName, GetName() );
	}

	/**
	 * DeleteSprite：在地图中删除与本对象实例关联的精灵
	 */
	public void		DeleteSprite()
	{
		EngineAPI.DeleteSprite( GetName() );
	}

	/**
	 * SetSpriteVisible：设置精灵隐藏或者显示(可见不可见)
	 * @param 参数 bVisible：true 可见 false不可见
	 */
	public void		SetSpriteVisible( boolean bVisible )
	{
		EngineAPI.SetSpriteVisible( GetName(), bVisible );
	}

	/**
	 * IsSpriteVisible：获取该精灵当前是否可见
	 * @return true：可见  false：不可见
	 */
	public boolean		IsSpriteVisible()
	{
		return EngineAPI.IsSpriteVisible( GetName() );
	}

	/**
	 * SetSpriteEnable：禁止或者启用该精灵。被禁止的精灵将不参与任何响应，包括不移动，没有碰撞等，仅仅是在地图中显示
	 * @param 参数 bEnable：true启用 false禁止
	 */
	public void		SetSpriteEnable( boolean bEnable )
	{
		EngineAPI.SetSpriteEnable( GetName(), bEnable );
	}

	/**
	 * SetSpriteScale：设置精灵的缩放值
	 * @param 参数 fScale：缩放值。大于0的值
	 */
	public void		SetSpriteScale(  float fScale )
	{
		EngineAPI.SetSpriteScale( GetName(), fScale );
	}

	/**
	 * IsPointInSprite：判断某个坐标点是否位于精灵内部
	 * @param 参数 fPosX：X坐标点
	 * @param 参数 fPosY：Y坐标点
	 * @return
	 */
	public boolean 		IsPointInSprite(  float fPosX,  float fPosY )
	{
		return EngineAPI.IsPointInSprite( GetName(), fPosX, fPosY );
	}

	/**
	 * SetSpritePosition：设置精灵位置
	 * @param 参数 fPosX：X坐标
	 * @param 参数 fPosY：Y坐标
	 */
	public void		SetSpritePosition(  float fPosX,  float fPosY )
	{
		EngineAPI.SetSpritePosition( GetName(), fPosX, fPosY );
	}

	/**
	 * SetSpritePositionX：只设置精灵X坐标
	 * @param 参数 fPosX：X坐标
	 */
	public void		SetSpritePositionX(  float fPosX )
	{
		EngineAPI.SetSpritePositionX( GetName(), fPosX );
	}

	/**
	 * SetSpritePositionY：只设置精灵Y坐标
	 * @param 参数 fPosY：Y坐标
	 */
	public void		SetSpritePositionY(  float fPosY )
	{
		EngineAPI.SetSpritePositionY( GetName(), fPosY );
	}

	/**
	 * GetSpritePositionX：获取精灵X坐标
	 * @return 返回值：精灵的X坐标
	 */
	public float		GetSpritePositionX()
	{
		return EngineAPI.GetSpritePositionX( GetName() );
	}

	/**
	 * GetSpritePositionY：获取精灵Y坐标
	 * 返回值：精灵的Y坐标
	 */
	public float		GetSpritePositionY()
	{
		return EngineAPI.GetSpritePositionY( GetName() );
	}

	/**
	 * GetSpriteLinkPointPosX：获取精灵链接点X坐标。链接点是依附于精灵的一个坐标点，可以在编辑器里增加或者删除
	 * @param 参数 iId：链接点序号，第一个为1，后面依次递加
	 * @return 链接点X坐标
	 */
	public float		GetSpriteLinkPointPosX(  int iId )
	{
		return EngineAPI.GetSpriteLinkPointPosX( GetName(), iId );
	}

	/**
	 * GetSpriteLinkPointPosY：获取精灵链接点Y坐标。链接点是依附于精灵的一个坐标点，可以在编辑器里增加或者删除
	 * @param 参数 iId：链接点序号，第一个为1，后面依次递加
	 * @return 链接点Y坐标
	 */
	public float		GetSpriteLinkPointPosY(  int iId )
	{
		return EngineAPI.GetSpriteLinkPointPosY( GetName(), iId );
	}

	/**
	 * SetSpriteRotation：设置精灵的旋转角度
	 * @param 参数 fRot：旋转角度，范围0 - 360
	 */
	public void		SetSpriteRotation(  float fRot )
	{
		EngineAPI.SetSpriteRotation( GetName(), fRot );
	}

	/**
	 * GetSpriteRotation：获取精灵的旋转角度
	 * @return 返回值：精灵的旋转角度
	 */
	public float		GetSpriteRotation()
	{
		return EngineAPI.GetSpriteRotation( GetName() );
	}

	/**
	 * SetSpriteAutoRot：设置精灵按照指定速度自动旋转
	 * @param 参数 fRotSpeed：旋转速度
	 */
	public void 		SetSpriteAutoRot(  float fRotSpeed )
	{
		EngineAPI.SetSpriteAutoRot( GetName(), fRotSpeed );
	}

	/**
	 * SetSpriteWidth：设置精灵外形宽度
	 * @param 参数 fWidth：宽度值，大于0
	 */
	public void		SetSpriteWidth(  float fWidth )
	{
		EngineAPI.SetSpriteWidth( GetName(), fWidth );
	}

	/**
	 * GetSpriteWidth：获取精灵外形宽度
	 * @return 返回值：精灵宽度值
	 */
	public float		GetSpriteWidth()
	{
		return EngineAPI.GetSpriteWidth( GetName() );
	}

	/**
	 * SetSpriteHeight：设置精灵外形高度
	 * @param 参数 fHeight：精灵高度值
	 */
	public void		SetSpriteHeight(  float fHeight )
	{
		EngineAPI.SetSpriteHeight( GetName(), fHeight );
	}

	/**
	 * GetSpriteHeight：获取精灵外形高度
	 * @return 返回值：精灵高度值
	 */
	public float		GetSpriteHeight()
	{
		return EngineAPI.GetSpriteHeight( GetName() );
	}

	/**
	 * SetSpriteFlipX：设置精灵图片X方向翻转显示
	 * @param 参数 bFlipX：true 翻转 false不翻转(恢复原来朝向)
	 */
	public void		SetSpriteFlipX( boolean bFlipX )
	{
		EngineAPI.SetSpriteFlipX( GetName(), bFlipX );
	}
	
	/**
	 * GetSpriteFlipX：获取当前精灵图片X方向是否是翻转显示
	 * @return 返回值：true 翻转 false不翻转
	 */
	public boolean		GetSpriteFlipX()
	{
		return EngineAPI.GetSpriteFlipX( GetName() );
	}

	/**
	 * SetSpriteFlipY：设置精灵图片Y方向翻转显示
	 * @param 参数 bFlipY：true 翻转 false不翻转(恢复原来朝向)
	 */
	public void		SetSpriteFlipY( boolean bFlipY )
	{
		EngineAPI.SetSpriteFlipY( GetName(), bFlipY );
	}

	/**
	 * GetSpriteFlipY：获取当前精灵图片Y方向是否是翻转显示
	 * @return 返回值：true 翻转 false不翻转
	 */
	public boolean		GetSpriteFlipY()
	{
		return EngineAPI.GetSpriteFlipY( GetName() );
	}

	/**
	 * SetSpriteFlip：同时设置精灵翻转X及Y方向
	 * @param 参数 bFlipX：true 翻转 false不翻转(恢复原来朝向)
	 * @param 参数 bFlipY：true 翻转 false不翻转(恢复原来朝向)
	 */
	public void		SetSpriteFlip( boolean bFlipX, boolean bFlipY )
	{
		EngineAPI.SetSpriteFlip( GetName(), bFlipX, bFlipY );
	}

	/**
	 * SetSpriteLifeTime：设置精灵的生命时长，时间到了之后将自动被删除
	 * @param 参数 fLifeTime：生命时长，单位 秒
	 */
	public void		SetSpriteLifeTime(  float fLifeTime )
	{
		EngineAPI.SetSpriteLifeTime( GetName(), fLifeTime );
	}

	/**
	 * GetSpriteLifeTime：获取精灵生命时长
	 * @return 返回值：生命时长，单位 秒
	 */
	public float		GetSpriteLifeTime()
	{
		return EngineAPI.GetSpriteLifeTime( GetName() );
	}

	/**
	 * SpriteMoveTo：让精灵按照给定速度移动到给定坐标点
	 * @param 参数 fPosX：移动的目标X坐标值
	 * @param 参数 fPosY：移动的目标Y坐标值
	 * @param 参数 fSpeed：移动速度
	 * @param 参数 bAutoStop：移动到终点之后是否自动停止
	 */
	public void		SpriteMoveTo(  float fPosX,  float fPosY,  float fSpeed, boolean bAutoStop )
	{
		EngineAPI.SpriteMoveTo( GetName(), fPosX, fPosY, fSpeed, bAutoStop );
	}

	/**
	 * SpriteRotateTo：让精灵按照给定速度旋转到给定的角度
	 * @param 参数 fRotation：给定的目标旋转值
	 * @param 参数 fRotSpeed：旋转速度
	 * @param 参数 bAutoStop：旋转到终点之后是否自动停止
	 */
	public void		SpriteRotateTo(  float fRotation,  float fRotSpeed, boolean bAutoStop )
	{
		EngineAPI.SpriteRotateTo( GetName(), fRotation, fRotSpeed, bAutoStop );
	}

	/**
	 * SetSpriteWorldLimit：设置精灵的世界边界坐标限制及碰撞模式
	 * @param 参数 Limit：碰撞到世界边界之后的响应模式，如果为OFF，则是关闭世界边界碰撞。其它值见 EWorldLimit
	 * @param 参数 fLeft：边界的左边X坐标
	 * @param 参数 fTop：边界的上边Y坐标
	 * @param 参数 fRight：边界的右边X坐标
	 * @param 参数 fBottom：边界的下边Y坐标
	 */
	public void		SetSpriteWorldLimit(  int Limit,  float fLeft,  float fTop,  float fRight,  float fBottom )
	{
		EngineAPI.SetSpriteWorldLimit( GetName(), (int)Limit, fLeft, fTop, fRight, fBottom );
	}

	/**
	 * SetSpriteWorldLimitMode：设置精灵的世界边界碰撞模式
	 * @param 参数 Limit：碰撞到世界边界之后的响应模式，如果为OFF，则是关闭世界边界碰撞。其它值见 EWorldLimit
	 */
	public void		SetSpriteWorldLimitMode(  int Limit )
	{
		EngineAPI.SetSpriteWorldLimitMode( GetName(), (int)Limit );
	}

	/**
	 * SetSpriteWorldLimitMin：设置精灵的世界边界上边及左边坐标限制
	 * @param 参数 fLeft：边界的左边X坐标
	 * @param 参数 fTop：边界的上边Y坐标
	 */
	public void		SetSpriteWorldLimitMin(  float fLeft,  float fTop )
	{
		EngineAPI.SetSpriteWorldLimitMin( GetName(), fLeft, fTop );
	}

	/**
	 * SetSpriteWorldLimitMax：设置精灵的世界边界下边及右边坐标限制
	 * @param 参数 fRight：边界的右边X坐标
	 * @param 参数 fBottom：边界的下边Y坐标
	 */
	public void		SetSpriteWorldLimitMax(  float fRight,  float fBottom )
	{
		EngineAPI.SetSpriteWorldLimitMax( GetName(), fRight, fBottom );
	}

	/**
	 * GetSpriteWorldLimitLeft：获取精灵世界边界左边界限制
	 * @return 精灵世界边界的左边界限制 值
	 */
	public float GetSpriteWorldLimitLeft()
	{
		return EngineAPI.GetSpriteWorldLimitLeft(GetName());
	}

	/**
	 * GetSpriteWorldLimitLeft：获取精灵世界边界上边界限制
	 * @return 精灵世界边界的上边界限制值
	 */
	public float GetSpriteWorldLimitTop()
	{
		return EngineAPI.GetSpriteWorldLimitTop(GetName());
	}

	/**
	 * GetSpriteWorldLimitLeft：获取精灵世界边界右边界限制
	 * @return 精灵世界边界的右边界限制值
	 */
	public float GetSpriteWorldLimitRight()
	{
		return EngineAPI.GetSpriteWorldLimitRight(GetName());
	}

	/**
	 * GetSpriteWorldLimitLeft：获取精灵世界边界下边界限制
	 * @return 精灵世界边界的下边界限制值
	 */
	public float GetSpriteWorldLimitBottom()
	{
		return EngineAPI.GetSpriteWorldLimitBottom(GetName());
	}

	/**
	 * SetSpriteCollisionSend：设置精灵是否可以发送(产生)碰撞
	 * 精灵的碰撞方式为：当A移动中碰上B时，如果A是可以产生碰撞的，B是可以接受碰撞的，则这2个物体会产生碰撞，精灵碰撞的API将被调用。否则无碰撞发生
	 * @param 参数 bSend：true 可以产生 false 不产生
	 */
	public void 		SetSpriteCollisionSend( boolean bSend )
	{
		EngineAPI.SetSpriteCollisionSend( GetName(), bSend );
	}

	/**
	 * SetSpriteCollisionReceive：设置精灵是否可以接受碰撞
	 * 精灵的碰撞方式为：当A移动中碰上B时，如果A是可以产生碰撞的，B是可以接受碰撞的，则这2个物体会产生碰撞，精灵碰撞的API将被调用。否则无碰撞发生
	 * @param 参数 bReceive：true 可以接受 false 不接受
	 */
	public void 		SetSpriteCollisionReceive( boolean bReceive )
	{
		EngineAPI.SetSpriteCollisionReceive( GetName(), bReceive );
	}

	/**
	 * SetSpriteCollisionActive：同时设置精灵是否可以产生及接受碰撞
	 * 精灵的碰撞方式为：当A移动中碰上B时，如果A是可以产生碰撞的，B是可以接受碰撞的，则这2个物体会产生碰撞，精灵碰撞的API将被调用。否则无碰撞发生
	 * @param 参数 bSend：true 可以产生 false 不产生
	 * @param 参数 bReceive：true 可以接受 false 不接受
	 */
	public void 		SetSpriteCollisionActive( boolean bSend, boolean bReceive )
	{
		EngineAPI.SetSpriteCollisionActive( GetName(), bSend, bReceive );
	}

	/**
	 * SetSpriteCollisionPhysicsSend：设置精灵是否可以发送(产生)碰撞
	 * @param 参数 bSend：true 可以产生 false 不产生
	 */
	public void 		SetSpriteCollisionPhysicsSend( boolean bSend )
	{
		EngineAPI.SetSpriteCollisionPhysicsSend( GetName(), bSend );
	}

	/**
	 * SetSpriteCollisionPhysicsReceive：设置精灵是否可以接受碰撞
	 * @param 参数 bReceive：true 可以接受 false 不接受
	 */
	public void 		SetSpriteCollisionPhysicsReceive( boolean bReceive )
	{
		EngineAPI.SetSpriteCollisionPhysicsReceive( GetName(), bReceive );
	}

	/**
	 * GetSpriteCollisionSend：获取精灵当前是否是可以产生碰撞
	 * @return 返回值：true 可以产生 false 不产生
	 */
	public boolean 		GetSpriteCollisionSend()
	{
		return EngineAPI.GetSpriteCollisionSend( GetName() );
	}

	/**
	 * GetSpriteCollisionReceive：获取精灵当前是否是可以接受碰撞
	 * @return 返回值：true 可以接受 false 不接受
	 */
	public boolean 		GetSpriteCollisionReceive()
	{
		return EngineAPI.GetSpriteCollisionReceive( GetName() );
	}

	/**
	 * SetSpriteCollisionResponse：设置精灵与精灵的碰撞响应模式
	 * @param 参数 Response：响应模式，如果为OFF，则为关闭碰撞响应，碰撞API将不会被调用。其它值见 ECollisionResponse
	 */
	public void		SetSpriteCollisionResponse(  int Response )
	{
		EngineAPI.SetSpriteCollisionResponse( GetName(), (int)Response );
	}

	/**
	 * SetSpriteCollisionMaxIterations：设置精灵碰撞之后的最大反弹次数
	 * @param 参数 iTimes：反弹次数
	 */
	public void		SetSpriteCollisionMaxIterations(  int iTimes )
	{
		EngineAPI.SetSpriteCollisionMaxIterations( GetName(), iTimes );
	}

	/**
	 * SetSpriteForwardMovementOnly：设置精灵是否只能朝前移动
	 * @param 参数 bForward：true 只能朝前移动 false 可以朝其他方向移动
	 */
	public void		SetSpriteForwardMovementOnly( boolean bForward )
	{
		EngineAPI.SetSpriteForwardMovementOnly( GetName(), bForward );
	}

	/**
	 * GetSpriteForwardMovementOnly：获取精灵当前是否只能朝前移动
	 * @return 返回值：true 只能朝前移动 false 可以朝其它方向移动
	 */
	public boolean		GetSpriteForwardMovementOnly()
	{
		return EngineAPI.GetSpriteForwardMovementOnly( GetName() );
	}

	/**
	 * SetSpriteForwardSpeed：设置精灵向前的速度
	 * @param 参数 fSpeed：速度
	 */
	public void		SetSpriteForwardSpeed(  float fSpeed )
	{
		EngineAPI.SetSpriteForwardSpeed( GetName(), fSpeed );
	}

	/**
	 * SetSpriteImpulseForce：设置精灵瞬间推力
	 * @param 参数 fForceX：X方向推力大小
	 * @param 参数 fForceY：Y方向推力大小
	 * @param 参数 bGravitic：是否计算重力
	 */
	public void 		SetSpriteImpulseForce(  float fForceX,  float fForceY, boolean bGravitic )
	{
		EngineAPI.SetSpriteImpulseForce( GetName(), fForceX, fForceY, bGravitic );
	}

	/**
	 * SetSpriteImpulseForcePolar：按角度朝向设置精灵瞬间推力
	 * @param 参数 fPolar：角度朝向
	 * @param 参数 fForce：推力大小
	 * @param 参数 bGravitic：是否计算重力
	 */
	public void 		SetSpriteImpulseForcePolar(  float fPolar,  float fForce, boolean bGravitic )
	{
		EngineAPI.SetSpriteImpulseForcePolar( GetName(), fPolar, fForce, bGravitic );
	}

	/**
	 * SetSpriteConstantForceX：设置精灵X方向常量推力
	 * @param 参数 fForceX：X方向推力大小
	 */
	public void 		SetSpriteConstantForceX(  float fForceX )
	{
		EngineAPI.SetSpriteConstantForceX( GetName(), fForceX );
	}

	/**
	 * SetSpriteConstantForceY：设置精灵Y方向常量推力
	 * @param 参数 fForceY：Y方向推力大小
	 */
	public void 		SetSpriteConstantForceY(  float fForceY )
	{
		EngineAPI.SetSpriteConstantForceY( GetName(), fForceY );
	}

	/**
	 * SetSpriteConstantForceGravitic：精灵在计算常量推力的时候，是否计算重力
	 * @param 参数 bGravitic：是否计算重力
	 */
	public void 		SetSpriteConstantForceGravitic( boolean bGravitic )
	{
		EngineAPI.SetSpriteConstantForceGravitic( GetName(), bGravitic );
	}

	/**
	 * SetSpriteConstantForce：设置精灵常量推力
	 * @param 参数 fForceX：X方向推力大小
	 * @param 参数 fForceY：Y方向推力大小
	 * @param 参数 bGravitic：是否计算重力
	 */
	public void 		SetSpriteConstantForce(  float fForceX,  float fForceY, boolean bGravitic )
	{
		EngineAPI.SetSpriteConstantForce( GetName(), fForceX, fForceY, bGravitic );
	}

	/**
	 * SetSpriteConstantForcePolar：按角度朝向设置精灵常量推力
	 * @param 参数 fPolar：角度朝向
	 * @param 参数 fForce：推力大小
	 * @param 参数 bGravitic：是否计算重力
	 */
	public void 		SetSpriteConstantForcePolar(  float fPolar,  float fForce, boolean bGravitic )
	{
		EngineAPI.SetSpriteConstantForcePolar( GetName(), fPolar, fForce, bGravitic );
	}

	/**
	 * StopSpriteConstantForce：停止精灵常量推力
	 */
	public void 		StopSpriteConstantForce()
	{
		EngineAPI.StopSpriteConstantForce( GetName() );
	}

	/**
	 * SetSpriteForceScale：按倍数缩放精灵当前受的推力
	 * @param 参数 fScale：缩放值
	 */
	public void 		SetSpriteForceScale(  float fScale )
	{
		EngineAPI.SetSpriteForceScale( GetName(), fScale );
	}

	/**
	 * SetSpriteAtRest：暂停/继续精灵的各种受力计算
	 * @param 参数 bRest：true 暂停 false 继续
	 */
	public void 		SetSpriteAtRest( boolean bRest )
	{
		EngineAPI.SetSpriteAtRest( GetName(), bRest );
	}

	/**
	 * GetSpriteAtRest：获取精灵当前是否在暂停中
	 * @return 返回值：true 暂停中 false 正常
	 */
	public boolean 		GetSpriteAtRest( )
	{
		return EngineAPI.GetSpriteAtRest( GetName() );
	}

	/**
	 * SetSpriteFriction：设置精灵摩擦力
	 * @param 参数 fFriction：摩擦力大小
	 */
	public void 		SetSpriteFriction(  float fFriction )
	{
		EngineAPI.SetSpriteFriction( GetName(), fFriction );
	}

	/**
	 * SetSpriteRestitution：设置精灵弹力
	 * @param 参数 fRestitution：弹力值大小
	 */
	public void 		SetSpriteRestitution(  float fRestitution )
	{
		EngineAPI.SetSpriteRestitution( GetName(), fRestitution );
	}

	/**
	 * SetSpriteMass：设置精灵质量
	 * @param 参数 fMass：质量大小
	 */
	public void 		SetSpriteMass(  float fMass )
	{
		EngineAPI.SetSpriteMass( GetName(), fMass );
	}

	/**
	 * GetSpriteMass：获取精灵质量
	 * @return 返回值 ：质量大小
	 */
	public float 		GetSpriteMass()
	{
		return EngineAPI.GetSpriteMass( GetName() );
	}

	/**
	 * SetSpriteAutoMassInertia：开启或者关闭精灵惯性
	 * @param 参数 bStatus：true 开启 false 关闭
	 */
	public void 		SetSpriteAutoMassInertia( boolean bStatus )
	{
		EngineAPI.SetSpriteAutoMassInertia( GetName(), bStatus );
	}

	/**
	 * SetSpriteInertialMoment：设置精灵惯性大小
	 * @param 参数 fInert：惯性大小
	 */
	public void 		SetSpriteInertialMoment(  float fInert )
	{
		EngineAPI.SetSpriteInertialMoment( GetName(), fInert );
	}

	/**
	 * SetSpriteDamping：设置精灵衰减值
	 * @param 参数 fDamp：衰减值大小
	 */
	public void 		SetSpriteDamping(  float fDamp )
	{
		EngineAPI.SetSpriteDamping( GetName(), fDamp );
	}

	/**
	 * SetSpriteImmovable：设置精灵是否不可移动
	 * @param 参数 bImmovable：true 不可以移动 false 可以移动
	 */
	public void 		SetSpriteImmovable( boolean bImmovable )
	{
		EngineAPI.SetSpriteImmovable( GetName(), bImmovable );
	}

	/**
	 * GetSpriteImmovable：获取精灵当前是否不可以移动
	 * @return 返回值：true 不可以移动 false 可以移动
	 */
	public boolean 		GetSpriteImmovable()
	{
		return EngineAPI.GetSpriteImmovable( GetName() );
	}

	/**
	 * SetSpriteLinearVelocity：设置精灵移动速度
	 * @param 参数 fVelX：X方向速度
	 * @param 参数 fVelY：Y方向速度
	 */
	public void 		SetSpriteLinearVelocity(  float fVelX,  float fVelY )
	{
		EngineAPI.SetSpriteLinearVelocity( GetName(), fVelX, fVelY );
	}

	/**
	 * SetSpriteLinearVelocityX：设置精灵X方向移动速度
	 * @param 参数 fVelX：X方向速度
	 */
	public void 		SetSpriteLinearVelocityX(  float fVelX )
	{
		EngineAPI.SetSpriteLinearVelocityX( GetName(), fVelX );
	}

	/**
	 * SetSpriteLinearVelocityY：设置精灵Y方向移动速度
	 * @param 参数 fVelY：Y方向速度
	 */
	public void 		SetSpriteLinearVelocityY(  float fVelY )
	{
		EngineAPI.SetSpriteLinearVelocityY( GetName(), fVelY );
	}

	/**
	 * SetSpriteLinearVelocityPolar：按角度朝向设置精灵移动速度
	 * @param 参数 fSpeed：移动速度
	 * @param 参数 fPolar：角度朝向
	 */
	public void 		SetSpriteLinearVelocityPolar(  float fSpeed,  float fPolar )
	{
		EngineAPI.SetSpriteLinearVelocityPolar( GetName(), fSpeed, fPolar );
	}

	/**
	 * SetSpriteAngularVelocity：设置精灵角度旋转速度
	 * @param 参数 fAngular：角度旋转速度
	 */
	public void 		SetSpriteAngularVelocity(  float fAngular )
	{
		EngineAPI.SetSpriteAngularVelocity( GetName(), fAngular );
	}

	/**
	 * SetSpriteMinLinearVelocity：设置精灵最小速度
	 * @param 参数 fMin：最小速度值
	 */
	public void 		SetSpriteMinLinearVelocity(  float fMin )
	{
		EngineAPI.SetSpriteMinLinearVelocity( GetName(), fMin );
	}

	/**
	 * SetSpriteMaxLinearVelocity：设置精灵最大速度
	 * @param 参数 fMax：最大速度值
	 */
	public void 		SetSpriteMaxLinearVelocity(  float fMax )
	{
		EngineAPI.SetSpriteMaxLinearVelocity( GetName(), fMax );
	}

	/**
	 * SetSpriteMinAngularVelocity：设置精灵最小角速度
	 * @param 参数 fMin：最小角速度
	 */
	public void 		SetSpriteMinAngularVelocity(  float fMin )
	{
		EngineAPI.SetSpriteMinAngularVelocity( GetName(), fMin );
	}

	/**
	 * SetSpriteMaxAngularVelocity：设置精灵最大角速度
	 * @param 参数 fMax：最大角速度
	 */
	public void 		SetSpriteMaxAngularVelocity(  float fMax )
	{
		EngineAPI.SetSpriteMaxAngularVelocity( GetName(), fMax );
	}

	/**
	 * GetSpriteLinearVelocityX：获取精灵X方向速度
	 * @return 返回值：X方向速度
	 */
	public float 		GetSpriteLinearVelocityX()
	{
		return EngineAPI.GetSpriteLinearVelocityX( GetName() );
	}

	/**
	 * GetSpriteLinearVelocityY：获取精灵Y方向速度
	 * @return 返回值：Y方向速度
	 */
	public float 		GetSpriteLinearVelocityY()
	{
		return EngineAPI.GetSpriteLinearVelocityY( GetName() );
	}

	/**
	 * SpriteMountToSprite：将一个精灵绑定到另一个精灵上，暂时的成为另一个精灵的一部分，跟随其运动等
	 * @param 参数 szDstName：承载绑定的母体精灵名字
	 * @param 参数 fOffSetX：绑定偏移X
	 * @param 参数 fOffsetY：绑定偏移Y
	 * @return 返回值：返回一个绑定ID
	 */
	public int			SpriteMountToSprite( String szDstName,  float fOffSetX,  float fOffsetY )
	{
		return EngineAPI.SpriteMountToSprite( GetName(), szDstName, fOffSetX, fOffsetY );
	}

	/**
	 * SpriteMountToSpriteLinkPoint：将一个精灵绑定到另一个精灵上，绑定位置为指定的链接点，暂时的成为另一个精灵的一部分，跟随其运动等
	 * @param 参数 szDstName：承载绑定的母体精灵名字
	 * @param 参数 iPointId：链接点序号
	 * @return 返回值：返回一个绑定ID
	 */
	public int			SpriteMountToSpriteLinkPoint( String szDstName,  int iPointId )
	{
		return EngineAPI.SpriteMountToSpriteLinkPoint( GetName(), szDstName, iPointId );
	}

	/**
	 * SetSpriteMountRotation：设置精灵的绑定朝向，即相对于母体的朝向
	 * @param 参数 fRot：角度朝向，0 - 360
	 */
	public void		SetSpriteMountRotation(  float fRot )
	{
		EngineAPI.SetSpriteMountRotation( GetName(), fRot );
	}

	/**
	 * GetSpriteMountRotation：获取精灵的绑定朝向，即相对于母体的朝向
	 * @return 返回值：角度朝向
	 */
	public float		GetSpriteMountRotation()
	{
		return EngineAPI.GetSpriteMountRotation( GetName() );
	}

	/**
	 * SetSpriteAutoMountRotation：设置精灵绑定之后自动旋转
	 * @param 参数 fRot：旋转速度
	 */
	public void		SetSpriteAutoMountRotation(  float fRot )
	{
		EngineAPI.SetSpriteAutoMountRotation( GetName(), fRot );
	}

	/**
	 * GetSpriteAutoMountRotation：获取精灵绑定之后的自动旋转值
	 * @return 返回值：旋转速度
	 */
	public float		GetSpriteAutoMountRotation()
	{
		return EngineAPI.GetSpriteAutoMountRotation( GetName() );
	}

	/**
	 * SetSpriteMountForce：绑定至另一个精灵时，附加的作用力
	 * @param 参数 fFroce：作用力
	 */
	public void		SetSpriteMountForce(  float fForce )
	{
		EngineAPI.SetSpriteMountForce( GetName(), fForce );
	}

	/**
	 * SetSpriteMountTrackRotation：绑定的精灵是否跟随母体旋转
	 * @param 参数 bTrackRotation：true 跟随 false 不跟随
	 */
	public void		SetSpriteMountTrackRotation( boolean bTrackRotation )
	{
		EngineAPI.SetSpriteMountTrackRotation( GetName(), bTrackRotation );
	}

	/**
	 * SetSpriteMountOwned：母体被删除的时候，绑定的精灵是否也跟着被删除
	 * @param 参数 bMountOwned：true 跟着 false 不跟着
	 */
	public void		SetSpriteMountOwned( boolean bMountOwned )
	{
		EngineAPI.SetSpriteMountOwned( GetName(), bMountOwned );
	}

	/**
	 * SetSpriteMountInheritAttributes：绑定的时候，是否继承母体的属性
	 * @param 参数 bInherAttr：true 继承 false 不继承
	 */
	public void		SetSpriteMountInheritAttributes( boolean bInherAttr )
	{
		EngineAPI.SetSpriteMountInheritAttributes( GetName(), bInherAttr );
	}

	/**
	 * SpriteDismount：将已经绑定的精灵进行解绑
	 */
	public void		SpriteDismount()
	{
		EngineAPI.SpriteDismount( GetName() );
	}

	/**
	 * GetSpriteIsMounted：判断精灵是否绑定在另一个精灵上
	 * @return 返回值：true 绑定 false 不绑定
	 */
	public boolean		GetSpriteIsMounted()
	{
		return EngineAPI.GetSpriteIsMounted( GetName() );
	}

	/**
	 * GetSpriteMountedParent：获取绑定的母体精灵的名字
	 * @return 返回值：母体精灵名字，如果未绑定，则返回空字符串
	 */
	public String	GetSpriteMountedParent()
	{
		return EngineAPI.GetSpriteMountedParent( GetName() );
	}

	/**
	 * SetSpriteColorRed：更改精灵显示颜色中的红色。默认精灵的红绿蓝三颜色的值均为255，修改其中一项将可以改变其颜色
	 * @param 参数 iCol：颜色范围 0 - 255
	 */
	public void		SetSpriteColorRed(  int iCol )
	{
		EngineAPI.SetSpriteColorRed( GetName(), iCol );
	}

	/**
	 * SetSpriteColorGreen：更改精灵显示颜色中的绿色。默认精灵的红绿蓝三颜色的值均为255，修改其中一项将可以改变其颜色
	 * @param 参数 iCol：颜色范围 0 - 255
	 */
	public void		SetSpriteColorGreen(  int iCol )
	{
		EngineAPI.SetSpriteColorGreen( GetName(), iCol );
	}

	/**
	 * SetSpriteColorBlue：更改精灵显示颜色中的蓝色。默认精灵的红绿蓝三颜色的值均为255，修改其中一项将可以改变其颜色
	 * @param 参数 iCol：颜色范围 0 - 255
	 */
	public void		SetSpriteColorBlue(  int iCol )
	{
		EngineAPI.SetSpriteColorBlue( GetName(), iCol );
	}

	/**
	 * SetSpriteColorAlpha：设置精灵透明度
	 * @param 参数 iCol：透明度，值0 - 255，从完全透明至完全不透明
	 */
	public void		SetSpriteColorAlpha(  int iCol )
	{
		EngineAPI.SetSpriteColorAlpha(  GetName(), iCol );
	}

	/**
	 * GetSpriteColorRed：获取精灵显示颜色中的红色值
	 * @return 返回值：颜色值
	 */
	public int			GetSpriteColorRed()
	{
		return EngineAPI.GetSpriteColorRed( GetName() );
	}

	/**
	 * GetSpriteColorGreen：获取精灵显示颜色中的绿色值
	 * @return 返回值：颜色值
	 */
	public int			GetSpriteColorGreen()
	{
		return EngineAPI.GetSpriteColorGreen( GetName() );
	}

	/**
	 * GetSpriteColorBlue：获取精灵显示颜色中的蓝色值
	 * @return 返回值：颜色值
	 */
	public int			GetSpriteColorBlue()
	{
		return EngineAPI.GetSpriteColorBlue( GetName() );
	}

	/**
	 * GetSpriteColorAlpha：获取精灵透明度
	 * @return 返回值：透明度
	 */
	public int			GetSpriteColorAlpha()
	{
		return EngineAPI.GetSpriteColorAlpha( GetName() );
	}
};