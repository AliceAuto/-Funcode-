/**
 * @(#)EngineAPI.java
 *
 * EngineAPI application
 *
 * @author
 * @version 1.00
 */

 package FunCode;

 import FunCode.EngineCall;

public class EngineAPI
{
	/**
	 * CursorOff：关闭鼠标不显示。此API隐藏的是整个Windows的鼠标，除非调用开启鼠标的API CursorOn，否则鼠标将一直不显示
	 */
	public static native void		CursorOff();

	/**
	 * CursorOn：开启鼠标显示。将API CursorOff关闭的鼠标重新开启显示
	 */
	public static native void		CursorOn();
	/**
	 * IsCursorOn：当前鼠标是开启还是关闭。对应的是用API CursorOff和CursorOn开启或者关闭的操作
	 * @return 返回值：true为开启状态，false为关闭状
	 */
	public static native boolean	IsCursorOn();
	/**
	 * ShowCursor：隐藏/显示鼠标。此API只是隐藏本程序窗口内的鼠标，移动到窗口外的时候，鼠标还是会显示
	 * @param 参数 bShow：true 为显示，false 为隐藏
	 */
	public static native void		ShowCursor( boolean bShow );
	/**
	 * IsShowCursor：当前鼠标是显示还是隐藏。对应的是用API ShowCursor隐藏或者显示的操作
	 * @return 返回值：true为开启状态，false为关闭状态
	 */
	public static native boolean	IsShowCursor();
	/**
	 * SetWindowTitle：设置窗口名字/标题
	 * @param 参数 szTitle：非空字符串
	 */
	public static native void		SetWindowTitle( String szTitle );
	/**
	 * ResizeWindow：更改窗口大
	 * @param 参数 iWidth：宽度，大于0小于等于1920
	 * @param 参数 iHeight：高度，大于0小于等于1080
	 */
	public static native void		ResizeWindow(int iWidth, int iHeight);
	/**
	 * Random：获取一个大于等于0的随机数
	 * @return 返回值：int，范围0 - 2147483648
	 */
	public static native int		Random();
	/**
	 * RandomRange：获取一个位于参数1到参数2之间的随机数
	 * @param 参数 iMin：小于iMax的整数
	 * @param 参数 iMax：大于iMin的整数
	 * @return 返回值：int，范围iMin - iMax
	 */
	public static native int		RandomRange( int iMin, int iMax );
	/**
	 * CalLineRotation：计算两点连线的直线的旋转角度
	 * @param 参数 fStartX：起始坐标X
	 * @param 参数 fStartY：起始坐标Y
	 * @param 参数 fEndX：终点坐标X
	 * @param 参数 fEndY：终点坐标Y
	 * @return 返回值：角度，范围0 - 360
	 */
	public static native float	CalLineRotation( float fStartX, float fStartY, float fEndX, float fEndY );
	/**
	 * RotationToVectorX：计算某个角度对应的直线向量的X方向
	 * @param 参数 fRotation：角度，范围0 - 360
	 * @return 返回值 ：该直线向量的X值
	 */
	public static native float	RotationToVectorX( float fRotation );
	/**
	 * RotationToVectorY：计算某个角度对应的直线向量的Y方向
	 * @param 参数 fRotation：角度，范围0 - 360
	 * @return 返回值 ：该直线向量的Y值
	 */
	public static native float	RotationToVectorY( float fRotation );
	/**
	 * DrawLine：在两点之间画一条线
	 * @param 参数 fStartX：起始坐标X
	 * @param 参数 fStartY：起始坐标Y
	 * @param 参数 fEndX：终点坐标X
	 * @param 参数 fEndY：终点坐标Y
	 * @param 参数 fLineWidth：线的粗细，大于等于1
	 * @param 参数 iLayer：改线所在的层，与编辑器里设置的精灵的层级是同一个概念。范围0 - 31
	 * @param 参数 iRed : 红绿蓝三原色的颜色值，范围 0 - 255
	 * @param 参数 iGreen : 红绿蓝三原色的颜色值，范围 0 - 255
	 * @param 参数 iBlue : 红绿蓝三原色的颜色值，范围 0 - 255
	 * @param 参数 iAlpha：线的透明度，范围0-255. 0为全透明，255为不透明
	 */
	public static native void		DrawLine( float fStartX, float fStartY, float fEndX, float fEndY, float fLineWidth, int iLayer, int iRed, int iGreen, int iBlue, int iAlpha );
	/**
	 * DrawTriangle：画一个三角形
	 * @param 参数 fX1：三角形上三个点的X坐标
	 * @param 参数 fY1：三角形上三个点的Y坐标
	 * @param 参数 fX2：三角形上三个点的X坐标
	 * @param 参数 fY2：三角形上三个点的Y坐标
	 * @param 参数fX3：三角形上三个点的X坐标
	 * @param 参数 fY3：三角形上三个点的Y坐标
	 * @param 参数 fLineWidth：线的粗细，大于等于1
	 * @param 参数 iLayer：该三角形所在的层，与编辑器里设置的精灵的层级是同一个概念。范围0 - 31。
	 * @param 参数 iRed : 红绿蓝三原色的颜色值，范围 0 - 255
	 * @param 参数 iGreen : 红绿蓝三原色的颜色值，范围 0 - 255
	 * @param 参数 iBlue : 红绿蓝三原色的颜色值，范围 0 - 255
	 * @param 参数 iAlpha：三角形的透明度，范围0-255. 0为全透明，255为不透明
	 */
	public static native void		DrawTriangle( float fX1, float fY1, float fX2, float fY2, float fX3, float fY3, float fLineWidth, int iLayer, int iRed, int iGreen, int iBlue, int iAlpha );
	/**
	 * DrawRect：画一个矩形
	 * @param 参数 fUpperX：左上角坐标X
	 * @param 参数 fUpperY：左上角坐标Y
	 * @param 参数 fLowerX：右下角坐标X
	 * @param 参数 fLowerY：右下角坐标Y
	 * @param 参数 fLineWidth：线的粗细，大于等于1
	 * @param 参数 iLayer：该矩形所在的层，与编辑器里设置的精灵的层级是同一个概念。范围0 - 31。
	 * @param 参数 iRed : 红绿蓝三原色的颜色值，范围 0 - 255
	 * @param 参数 iGreen : 红绿蓝三原色的颜色值，范围 0 - 255
	 * @param 参数 iBlue : 红绿蓝三原色的颜色值，范围 0 - 255
	 * @param 参数 iAlpha：矩形的透明度，范围0-255. 0为全透明，255为不透明
	 */
	public static native void		DrawRect( float fUpperX, float fUpperY, float fLowerX, float fLowerY, float fLineWidth, int iLayer, int iRed, int iGreen, int iBlue, int iAlpha );
	/**
	 * DrawCircle：画一个圆
	 * @param 参数 fCenterX：圆心坐标X
	 * @param 参数 fCenterY：圆心坐标Y
	 * @param 参数 fRadius：圆的半径
	 * @param 参数 iSegment：圆弧段数，范围4-72. 比如传入6，将得到一个6边形，段数越大越圆滑，但是画图效率越低
	 * @param 参数 fLineWidth：线的粗细，大于等于1
	 * @param 参数 iLayer：该圆所在的层，与编辑器里设置的精灵的层级是同一个概念。范围0 - 31。
	 * @param 参数 iRed : 红绿蓝三原色的颜色值，范围 0 - 255
	 * @param 参数  iGreen : 红绿蓝三原色的颜色值，范围 0 - 255
	 * @param 参数 iBlue : 红绿蓝三原色的颜色值，范围 0 - 255
	 * @param 参数 iAlpha：圆的透明度，范围0-255. 0为全透明，255为不透明
	 */
	public static native void		DrawCircle( float fCenterX, float fCenterY, float fRadius, int iSegment, float fLineWidth, int iLayer, int iRed, int iGreen, int iBlue, int iAlpha );
	/**
	 * GetScreenLeft：获取世界边界之左边X坐标
	 * @return 返回值：左边界X坐标
	 */
	public static native float	GetScreenLeft();
	/**
	 * GetScreenTop：获取世界边界之上边Y坐标
	 * @return 返回值：上边界Y坐标
	 */
	public static native float	GetScreenTop();

	/**
	 * GetScreenRight：获取世界边界之右边X坐标
	 * @return 返回值：右边界X坐标
	 */
	public static native float	GetScreenRight();

	/**
	 * GetScreenBottom：获取世界边界之下边Y坐标
	 * @return 返回值：下边界Y坐标
	 */
	public static native float	GetScreenBottom();

	/**
	 * LoadMap：载入新场景。注意，载入新场景的时候，旧场景的所有精灵都将被引擎删除掉，所以所有在程序中创建、复制出来的精灵都必须在调用本API之前先删除掉
	 * @param 参数 szName：场景名字。即新建场景保存的时候取的名字，必须带小写的后缀 -- xxx.t2d。不用带路径
	 */
	public static native void		LoadMap( String szName );

	/**
	 * CloneSprite：复制(创建)一个精灵。精灵的创建方式：先在地图中摆放一个精灵做为模板，设置好各项参数，然后在代码里使用此函数克隆一个实例
	 * @param 参数 szSrcName：地图中用做模板的精灵名字
	 * @param 参数 szMyName：新的精灵名字
	 * @return 返回值：true表示克隆成功，false克隆失败。失败的原因可能是在地图中未找到对应名字的精灵
	 */
	public static native boolean	CloneSprite( String szSrcName, String szMyName );

	/**
	 * DeleteSprite：在地图中删除一个精灵
	 * @param 参数 szName：要删除的精灵名字
	 */
	public static native void	DeleteSprite( String szName );

	/**
	 * SetSpriteVisible：设置精灵隐藏或者显示(可见不可见)
	 * @param 参数 szName：精灵名字
	 * @param 参数 bVisible：true 可见 false不可见
	 */
	public static native void	SetSpriteVisible( String szName, boolean bVisible );

	/**
	 * IsSpriteVisible：获取该精灵当前是否可见
	 * @param 参数 szName：精灵名字
	 * @return 返回值 true可见 false不可见
	 */
	public static native boolean	IsSpriteVisible( String szName );

	/**
	 * SetSpriteEnable：禁止或者启用该精灵。被禁止的精灵将不参与任何响应，包括不移动，没有碰撞等，仅仅是在地图中显示
	 * @param 参数 szName：精灵名字
	 * @param 参数 bEnable：true启用 false禁止
	 */
	public static native void		SetSpriteEnable( String szName, boolean bEnable );

	/**
	 * SetSpriteScale：设置精灵的缩放值
	 * @param 参数 szName：精灵名字
	 * @param 参数 fScale：缩放值。大于0的值
	 */
	public static native void		SetSpriteScale( String szName, float fScale );

	/**
	 * IsPointInSprite：判断某个坐标点是否位于精灵内部
	 * @param 参数 szName：精灵名字
	 * @param 参数 fPosX：X坐标点
	 * @param 参数 fPosY：Y坐标点
	 * @return 返回值 true 在 false 不在
	 */
	public static native boolean 	IsPointInSprite( String szName, float fPosX, float fPosY );

	/**
	 * SetSpritePosition：设置精灵位置
	 * @param 参数 szName：精灵名字
	 * @param 参数 fPosX：X坐标
	 * @param 参数 fPosY：Y坐标
	 */
	public static native void		SetSpritePosition( String szName, float fPosX, float fPosY );

	/**
	 * SetSpritePositionX：只设置精灵X坐标
	 * @param 参数 szName：精灵名字
	 * @param 参数 fPosX：X坐标
	 */
	public static native void		SetSpritePositionX( String szName, float fPosX );
	
	/**
	 * SetSpritePositionY：只设置精灵Y坐标
	 * @param 参数 szName：精灵名字
	 * @param 参数 fPosY：Y坐标
	 */
	public static native void		SetSpritePositionY( String szName, float fPosY );

	/**
	 * GetSpritePositionX：获取精灵X坐标
	 * @param 参数 szName：精灵名字
	 * @return 返回值：精灵的X坐标
	 */
	public static native float	GetSpritePositionX( String szName );

	/**
	 * GetSpritePositionY：获取精灵Y坐标
	 * @param 参数 szName：精灵名字
	 * @return 返回值：精灵的Y坐标
	 */
	public static native float	GetSpritePositionY( String szName );

	/**
	 * GetSpriteLinkPointPosX：获取精灵链接点X坐标。链接点是依附于精灵的一个坐标点，可以在编辑器里增加或者删除
	 * @param 参数 szName：精灵名字
	 * @param 参数 iId：链接点序号，第一个为1，后面依次递加
	 * @return 精灵链接点X坐标
	 */
	public static native float	GetSpriteLinkPointPosX( String szName, int iId );

	/**
	 * GetSpriteLinkPointPosY：获取精灵链接点Y坐标。链接点是依附于精灵的一个坐标点，可以在编辑器里增加或者删除
	 * @param 参数 szName：精灵名字
	 * @param 参数 iId：链接点序号，第一个为1，后面依次递加
	 * @return 精灵链接点Y坐标
	 */
	public static native float	GetSpriteLinkPointPosY( String szName,  int iId );

	/**
	 * SetSpriteRotation：设置精灵的旋转角度
	 * @param 参数 szName：精灵名字
	 * @param 参数 fRot：旋转角度，范围0 - 360
	 */
	public static native void		SetSpriteRotation( String szName,  float fRot );
	/**
	 * GetSpriteRotation：获取精灵的旋转角度
	 * @param 参数 szName：精灵名字
	 * @return 精灵的旋转角度
	 */
	public static native float	GetSpriteRotation( String szName );

	/**
	 * SetSpriteAutoRot：设置精灵按照指定速度自动旋转
	 * @param szName：精灵名字
	 * @param fRotSpeed：旋转速度
	 */
	public static native void 	SetSpriteAutoRot( String szName,  float fRotSpeed );

	/**
	 * SetSpriteWidth：设置精灵外形宽度
	 * @param 参数 szName：精灵名字
	 * @param 参数 fWidth：宽度值，大于0
	 */
	public static native void		SetSpriteWidth( String szName,  float fWidth );

	/**
	 * GetSpriteWidth：获取精灵外形宽度
	 * @param 参数 szName：精灵名字
	 * @return 返回值：精灵宽度值
	 */
	public static native float	GetSpriteWidth( String szName );

	/**
	 * SetSpriteHeight：设置精灵外形高度
	 * @param 参数 szName：精灵名字
	 * @param 参数 fHeight：精灵高度值
	 */
	public static native void		SetSpriteHeight( String szName, float fHeight );

	/**
	 * GetSpriteHeight：获取精灵外形高度
	 * @param 参数 szName：精灵名字
	 * @return 返回值：精灵高度值
	 */
	public static native float	GetSpriteHeight( String szName );

	/**
	 * SetSpriteFlipX：设置精灵图片X方向翻转显示
	 * @param 参数 szName：精灵名字
	 * @param 参数 bFlipX：true 翻转 false不翻转(恢复原来朝向)
	 */
	public static native void		SetSpriteFlipX( String szName, boolean bFlipX );

	/**
	 * GetSpriteFlipX：获取当前精灵图片X方向是否是翻转显示
	 * @param 参数 szName：精灵名字
	 * @return 返回值：true 翻转 false不翻转
	 */
	public static native boolean		GetSpriteFlipX( String szName );

	/**
	 * SetSpriteFlipY：设置精灵图片Y方向翻转显示
	 * @param 参数 szName：精灵名字
	 * @param 参数bFlipY:true 翻转 false不翻转(恢复原来朝向)
	 */
	
	public static native void		SetSpriteFlipY( String szName, boolean bFlipY );

	/**
	 * GetSpriteFlipY：获取当前精灵图片Y方向是否是翻转显示
	 * @param 参数 szName：精灵名字
	 * @return 返回值：true 翻转 false不翻转
	 */
	public static native boolean	GetSpriteFlipY( String szName );

	/**
	 * SetSpriteFlip：同时设置精灵翻转X及Y方向
	 * @param 参数 szName：精灵名字
	 * @param bFlipX
	 * @param bFlipY
	 */
	public static native void		SetSpriteFlip( String szName, boolean bFlipX, boolean bFlipY );

	/**
	 * SetSpriteLifeTime：设置精灵的生命时长，时间到了之后将自动被删除
	 * @param 参数 szName：精灵名字
	 * @param 参数 fLifeTime：生命时长，单位 秒
	 */
	public static native void		SetSpriteLifeTime( String szName, float fLifeTime );

	/**
	 * GetSpriteLifeTime：获取精灵生命时长
	 * @param 参数 szName：精灵名字
	 * @return 返回值：生命时长，单位 秒
	 */
	public static native float	GetSpriteLifeTime( String szName );

	/**
	 * SpriteMoveTo：让精灵按照给定速度移动到给定坐标点
	 * @param 参数 szName：精灵名字
	 * @param 参数 fPosX：移动的目标X坐标值
	 * @param 参数 fPosY：移动的目标Y坐标值
	 * @param 参数 fSpeed：移动速度
	 * @param 参数 bAutoStop：移动到终点之后是否自动停止, true 停止 false 不停止
	 */
	public static native void		SpriteMoveTo( String szName, float fPosX, float fPosY,  float fSpeed,  boolean bAutoStop );

	/**
	 * SpriteRotateTo：让精灵按照给定速度旋转到给定的角度
	 * @param 参数 szName：精灵名字
	 * @param 参数 fRotation：给定的目标旋转值
	 * @param 参数 fRotSpeed：旋转速度
	 * @param 参数 bAutoStop：旋转到终点之后是否自动停止, true 停止 false 不停止
	 */
	public static native void		SpriteRotateTo( String szName,  float fRotation,  float fRotSpeed,  boolean bAutoStop );

	/**
	 * SetSpriteWorldLimit：设置精灵的世界边界坐标限制及碰撞模式
	 * @param 参数 szName：精灵名字
	 * @param 参数 Limit：碰撞到世界边界之后的响应模式，如果为OFF，则是关闭世界边界碰撞。其它值见 EWorldLimit 定义
	 * @param 参数 fLeft：边界的左边X坐标
	 * @param 参数 fTop：边界的上边Y坐标
	 * @param 参数 fRight：边界的右边X坐标
	 * @param 参数 fBottom：边界的下边Y坐标
	 */
	public static native void		SetSpriteWorldLimit( String szName,  int Limit,  float fLeft,  float fTop,  float fRight,  float fBottom );

	/**
	 * SetSpriteWorldLimitMode：设置精灵的世界边界碰撞模式
	 * @param 参数 szName：精灵名字
	 * @param 参数 Limit：碰撞到世界边界之后的响应模式，如果为OFF，则是关闭世界边界碰撞。其它值见 EWorldLimit 定义
	 */
	public static native void		SetSpriteWorldLimitMode( String szName,  int Limit );

	/**
	 * SetSpriteWorldLimitMin：设置精灵的世界边界上边及左边坐标限制
	 * @param 参数 szName：精灵名字
	 * @param 参数 fLeft：边界的左边X坐标
	 * @param 参数 fTop：边界的上边Y坐标
	 */
	public static native void		SetSpriteWorldLimitMin( String szName,  float fLeft,  float fTop );

	/**
	 * SetSpriteWorldLimitMax：设置精灵的世界边界下边及右边坐标限制
	 * @param 参数 szName：精灵名字
	 * @param 参数 fBottom：边界的下边Y坐标
	 * @param 参数 fBottom：边界的下边Y坐标
	 */
	public static native void		SetSpriteWorldLimitMax( String szName,  float fRight,  float fBottom );

	/**
	 * GetSpriteWorldLimitLeft：获取精灵世界边界左边界限制
	 * @param 参数 szName：精灵名字
	 * @return 精灵世界边界左边界限制
	 */
	public static native float		GetSpriteWorldLimitLeft( String szName );

	/**
	 * GetSpriteWorldLimitTop：获取精灵世界边界上边界限制
	 * @param 参数 szName：精灵名字
	 * @return 精灵世界边界上边界限制
	 */
	public static native float		GetSpriteWorldLimitTop( String szName );

	/**
	 * GetSpriteWorldLimitRight：获取精灵世界边界右边界限制
	 * @param 参数 szName：精灵名字
	 * @return 精灵世界边界右边界限制
	 */
	public static native float		GetSpriteWorldLimitRight( String szName );

	/**
	 * GetSpriteWorldLimitBottom：获取精灵世界边界下边界限制
	 * @param 参数 szName：精灵名字
	 * @return 精灵世界边界下边界限制
	 */
	public static native float		GetSpriteWorldLimitBottom( String szName );

	/**
	 * SetSpriteCollisionSend：设置精灵是否可以发送(产生)碰撞
	 * 精灵的碰撞方式为：当A移动中碰上B时，如果A是可以产生碰撞的，B是可以接受碰撞的，则这2个物体会产生碰撞，精灵碰撞的API将被调用。否则无碰撞发生
	 * @param 参数 szName：精灵名字
	 * @param 参数 bSend：true 可以产生 false 不产生
	 */
	public static native void 	SetSpriteCollisionSend( String szName,  boolean bSend );

	/**
	 * SetSpriteCollisionReceive：设置精灵是否可以接受碰撞
	 * 精灵的碰撞方式为：当A移动中碰上B时，如果A是可以产生碰撞的，B是可以接受碰撞的，则这2个物体会产生碰撞，精灵碰撞的API将被调用。否则无碰撞发生
	 * @param 参数 szName：精灵名字
	 * @param 参数 bReceive：true 可以接受 false 不接受
	 */
	public static native void 	SetSpriteCollisionReceive( String szName,  boolean bReceive );

	/**
	 * SetSpriteCollisionActive：同时设置精灵是否可以产生及接受碰撞
	 * 精灵的碰撞方式为：当A移动中碰上B时，如果A是可以产生碰撞的，B是可以接受碰撞的，则这2个物体会产生碰撞，精灵碰撞的API将被调用。否则无碰撞发生
	 * @param 参数 szName：精灵名字
	 * @param 参数 bSend：true 可以产生 false 不产生
	 * @param 参数 bReceive：true 可以接受 false 不接受
	 */
	public static native void 	SetSpriteCollisionActive( String szName,  boolean bSend,  boolean bReceive );

	/**
	 * SetSpriteCollisionPhysicsSend：设置精灵是否可以发送(产生)物理碰撞
	 * @param szName
	 * @param 参数 bSend：true 可以产生 false 不产生
	 */
	public static native void	SetSpriteCollisionPhysicsSend( String szName,  boolean bSend );

	/**
	 * SetSpriteCollisionPhysicsReceive：设置精灵是否可以接受物理碰撞
	 * @param szName
	 * @param 参数 bReceive：true 可以接受 false 不接受
	 */
	public static native void	SetSpriteCollisionPhysicsReceive( String szName,  boolean bReceive );

	/**
	 * GetSpriteCollisionSend：获取精灵当前是否是可以产生碰撞
	 * @param 参数 szName：精灵名字
	 * @return 返回值：true 可以产生 false 不产生
	 */
	public static native boolean 	GetSpriteCollisionSend( String szName );

	/**
	 * GetSpriteCollisionReceive：获取精灵当前是否是可以接受碰撞
	 * @param 参数 szName：精灵名字
	 * @return 返回值：true 可以接受 false 不接受
	 */
	public static native boolean 	GetSpriteCollisionReceive( String szName );

	/**
	 * SetSpriteCollisionResponse：设置精灵与精灵的碰撞响应模式
	 * @param 参数 szName：精灵名字
	 * @param 参数 Response：响应模式，如果为OFF，则为关闭碰撞响应，碰撞API将不会被调用。其它值见 ECollisionResponse 定义
	 */
	public static native void		SetSpriteCollisionResponse( String szName,  int Response );

	/**
	 * SetSpriteCollisionMaxIterations：设置精灵碰撞之后的最大反弹次数
	 * @param 参数 szName：精灵名字
	 * @param 参数 iTimes：反弹次数
	 */
	public static native void		SetSpriteCollisionMaxIterations( String szName,  int iTimes );

	/**
	 * SetSpriteForwardMovementOnly：设置精灵是否只能朝前移动
	 * @param 参数 szName：精灵名字
	 * @param 参数 bForward：true 只能朝前移动 false 可以朝其他方向移动
	 */
	public static native void		SetSpriteForwardMovementOnly( String szName,  boolean bForward );

	/**
	 * GetSpriteForwardMovementOnly：获取精灵当前是否只能朝前移动
	 * @param 参数 szName：精灵名字
	 * @return 返回值：true 只能朝前移动 false 可以朝其它方向移动
	 */
	public static native boolean		GetSpriteForwardMovementOnly( String szName );

	/**
	 * SetSpriteForwardSpeed：设置精灵向前的速度
	 * @param 参数 szName：精灵名字
	 * @param 参数 fSpeed：速度
	 */
	public static native void		SetSpriteForwardSpeed( String szName,  float fSpeed );

	/**
	 * SetSpriteImpulseForce：设置精灵瞬间推力
	 * @param 参数 szName：精灵名字
	 * @param 参数 fForceX：X方向推力大小
	 * @param 参数 fForceY：Y方向推力大小
	 * @param 参数 bGravitic：是否计算重力 : true 计算，false不计算
	 */
	public static native void 	SetSpriteImpulseForce( String szName,  float fForceX,  float fForceY,  boolean bGravitic );

	/**
	 * SetSpriteImpulseForcePolar：按角度朝向设置精灵瞬间推力
	 * @param 参数 szName：精灵名字
	 * @param 参数 fPolar：角度朝向
	 * @param 参数 fForce：推力大小
	 * @param 参数 bGravitic：是否计算重力 : true 计算，false不计算
	 */
	public static native void 	SetSpriteImpulseForcePolar( String szName,  float fPolar,  float fForce,  boolean bGravitic );

	/**
	 * SetSpriteConstantForceX：设置精灵X方向常量推力
	 * @param 参数 szName：精灵名字
	 * @param 参数 fForceX：X方向推力大小
	 */
	public static native void 	SetSpriteConstantForceX(String szName,  float fForceX );

	/**
	 * SetSpriteConstantForceY：设置精灵Y方向常量推力
	 * @param 参数 szName：精灵名字
	 * @param 参数 fForceY：Y方向推力大小
	 */
	public static native void 	SetSpriteConstantForceY(String szName,  float fForceY );

	/**
	 * SetSpriteConstantForceGravitic：精灵在计算常量推力的时候，是否计算重力
	 * @param 参数 szName：精灵名字
	 * @param 参数 bGravitic：是否计算重力 : true 计算 false不计算
	 */
	public static native void 	SetSpriteConstantForceGravitic(String szName,  boolean bGravitic );

	/**
	 * SetSpriteConstantForce：设置精灵常量推力
	 * @param 参数 szName：精灵名字
	 * @param 参数 fForceX：X方向推力大小
	 * @param 参数 fForceY：Y方向推力大小
	 * @param 参数 bGravitic：是否计算重力 : true 计算 false不计算
	 */
	public static native void 	SetSpriteConstantForce(String szName,  float fForceX,  float fForceY,  boolean bGravitic );

	/**
	 * SetSpriteConstantForcePolar：按角度朝向设置精灵常量推力
	 * @param 参数 szName：精灵名字
	 * @param 参数 fPolar：角度朝向
	 * @param 参数 fForce：推力大小
	 * @param 参数 bGravitic：是否计算重力 : true 计算 false不计算
	 */
	public static native void 	SetSpriteConstantForcePolar(String szName,  float fPolar,  float fForce,  boolean bGravitic );

	/**
	 * StopSpriteConstantForce：停止精灵常量推力
	 * @param 参数 szName：精灵名字
	 */
	public static native void 	StopSpriteConstantForce(String szName);

	/**
	 * SetSpriteForceScale：按倍数缩放精灵当前受的推力
	 * @param 参数 szName：精灵名字
	 * @param 参数 fScale：缩放值
	 */
	public static native void 	SetSpriteForceScale(String szName,  float fScale );

	/**
	 * SetSpriteAtRest：暂停/继续精灵的各种受力计算
	 * @param 参数 szName：精灵名字
	 * @param 参数 bRest：true 暂停 false 继续
	 */
	public static native void 	SetSpriteAtRest(String szName,  boolean bRest );

	/**
	 * GetSpriteAtRest：获取精灵当前是否在暂停中
	 * @param 参数 szName：精灵名字
	 * @return 返回值：true 暂停中 false 正常
	 */
	public static native boolean	GetSpriteAtRest(String szName );

	/**
	 * SetSpriteFriction：设置精灵摩擦力
	 * @param 参数 szName：精灵名字
	 * @param 参数 fFriction：摩擦力大小
	 */
	public static native void 	SetSpriteFriction( String szName,  float fFriction );

	/**
	 * SetSpriteRestitution：设置精灵弹力
	 * @param 参数 szName：精灵名字
	 * @param 参数 fRestitution：弹力值大小
	 */
	public static native void 	SetSpriteRestitution( String szName,  float fRestitution );

	/**
	 * SetSpriteMass：设置精灵质量
	 * @param 参数 szName：精灵名字
	 * @param 参数 fMass：质量大小
	 */
	public static native void 	SetSpriteMass( String szName, float fMass );

	/**
	 * GetSpriteMass：获取精灵质量
	 * @param 参数 szName：精灵名字
	 * @return 返回值 ：质量大小
	 */
	public static native float 	GetSpriteMass( String szName );

	/**
	 * SetSpriteAutoMassInertia：开启或者关闭精灵惯性
	 * @param 参数 szName：精灵名字
	 * @param 参数 bStatus：true 开启 false 关闭
	 */
	public static native void 	SetSpriteAutoMassInertia( String szName,  boolean bStatus );

	/**
	 * SetSpriteInertialMoment：设置精灵惯性大小
	 * @param 参数 szName：精灵名字
	 * @param 参数 fInert：惯性大小
	 */
	public static native void 	SetSpriteInertialMoment( String szName,  float fInert );

	/**
	 * SetSpriteDamping：设置精灵衰减值
	 * @param 参数 szName：精灵名字
	 * @param 参数 fDamp：衰减值大小
	 */
	public static native void 	SetSpriteDamping( String szName,  float fDamp );

	/**
	 * SetSpriteImmovable：设置精灵是否不可移动
	 * @param 参数 szName：精灵名字
	 * @param 参数 bImmovable：true 不可以移动 false 可以移动
	 */
	public static native void 	SetSpriteImmovable( String szName,  boolean bImmovable );

	/**
	 * GetSpriteImmovable：获取精灵当前是否不可以移动
	 * @param 参数 szName：精灵名字
	 * @return 返回值：true 不可以移动 false 可以移动
	 */
	public static native boolean 	GetSpriteImmovable( String szName );

	/**
	 * SetSpriteLinearVelocity：设置精灵移动速度
	 * @param 参数 szName：精灵名字
	 * @param 参数 fVelX：X方向速度
	 * @param 参数 fVelY：Y方向速度
	 */
	public static native void 	SetSpriteLinearVelocity( String szName,  float fVelX,  float fVelY );

	/**
	 * SetSpriteLinearVelocityX：设置精灵X方向移动速度
	 * @param 参数 szName：精灵名字
	 * @param 参数 fVelX：X方向速度
	 */
	public static native void 	SetSpriteLinearVelocityX( String szName,  float fVelX );

	/**
	 * SetSpriteLinearVelocityY：设置精灵Y方向移动速度
	 * @param 参数 szName：精灵名字
	 * @param 参数 fVelY：Y方向速度
	 */
	public static native void 	SetSpriteLinearVelocityY( String szName,  float fVelY );

	/**
	 * SetSpriteLinearVelocityPolar：按角度朝向设置精灵移动速度
	 * @param 参数 szName：精灵名字
	 * @param 参数 fSpeed：移动速度
	 * @param 参数 fPolar：角度朝向
	 */
	public static native void 	SetSpriteLinearVelocityPolar( String szName,  float fSpeed,  float fPolar );

	/**
	 * SetSpriteAngularVelocity：设置精灵角度旋转速度
	 * @param 参数 szName：精灵名字
	 * @param 参数 fAngular：角度旋转速度
	 */
	public static native void 	SetSpriteAngularVelocity( String szName,  float fAngular );

	/**
	 * SetSpriteMinLinearVelocity：设置精灵最小速度
	 * @param 参数 szName：精灵名字
	 * @param 参数 fMin：最小速度值
	 */
	public static native void 	SetSpriteMinLinearVelocity( String szName,  float fMin );

	/**
	 * SetSpriteMaxLinearVelocity：设置精灵最大速度
	 * @param 参数 szName：精灵名字
	 * @param 参数 fMax：最大速度值
	 */
	public static native void 	SetSpriteMaxLinearVelocity( String szName,  float fMax );

	/**
	 * SetSpriteMinAngularVelocity：设置精灵最小角速度
	 * @param 参数 szName：精灵名字
	 * @param 参数 fMin：最小角速度
	 */
	public static native void 	SetSpriteMinAngularVelocity( String szName,  float fMin );

	/**
	 * SetSpriteMaxAngularVelocity：设置精灵最大角速度
	 * @param 参数 szName：精灵名字
	 * @param 参数 fMax：最大角速度
	 */
	public static native void 	SetSpriteMaxAngularVelocity( String szName,  float fMax );

	/**
	 * GetSpriteLinearVelocityX：获取精灵X方向速度
	 * @param 参数 szName：精灵名字
	 * @return 返回值：X方向速度
	 */
	public static native float 	GetSpriteLinearVelocityX( String szName );

	/**
	 * GetSpriteLinearVelocityY：获取精灵Y方向速度
	 * @param 参数 szName：精灵名字
	 * @return 返回值：Y方向速度
	 */
	public static native float 	GetSpriteLinearVelocityY( String szName );

	/**
	 * SpriteMountToSprite：将一个精灵绑定到另一个精灵上，暂时的成为另一个精灵的一部分，跟随其运动等
	 * @param 参数 szSrcName：要绑定的精灵名字
	 * @param 参数 szDstName：承载绑定的母体精灵名
	 * @param 参数 fOffSetX：绑定偏移X
	 * @param 参数 fOffsetY：绑定偏移Y
	 * @return 返回值：返回一个绑定ID
	 */
	public static native int		SpriteMountToSprite( String szSrcName, String szDstName,  float fOffSetX,  float fOffsetY );

	/**
	 * SpriteMountToSpriteLinkPoint：将一个精灵绑定到另一个精灵上，绑定位置为指定的链接点，暂时的成为另一个精灵的一部分，跟随其运动等
	 * @param 参数 szSrcName：要绑定的精灵名字
	 * @param 参数 szDstName：承载绑定的母体精灵名字
	 * @param 参数 iPointId：链接点序号
	 * @return 返回值：返回一个绑定ID
	 */
	public static native int		SpriteMountToSpriteLinkPoint( String szSrcName, String szDstName,  int iPointId );

	/**
	 * SetSpriteMountRotation：设置精灵的绑定朝向，即相对于母体的朝向
	 * @param 参数 szName：精灵名字
	 * @param 参数 fRot：角度朝向，0 - 360
	 */
	public static native void		SetSpriteMountRotation( String szName,  float fRot );

	/**
	 * GetSpriteMountRotation：获取精灵的绑定朝向，即相对于母体的朝向
	 * @param 参数 szName：精灵名字
	 * @return 返回值：角度朝向
	 */
	public static native float	GetSpriteMountRotation( String szName );

	/**
	 * SetSpriteAutoMountRotation：设置精灵绑定之后自动旋转
	 * @param 参数 szName：精灵名字
	 * @param 参数 fRot：旋转速度
	 */
	public static native void		SetSpriteAutoMountRotation( String szName,  float fRot );

	/**
	 * GetSpriteAutoMountRotation：获取精灵绑定之后的自动旋转值
	 * @param 参数 szName：精灵名字
	 * @return 返回值：旋转速度
	 */
	public static native float	GetSpriteAutoMountRotation( String szName );

	/**
	 * SetSpriteMountForce：绑定至另一个精灵时，附加的作用力
	 * @param 参数 szName：精灵名字
	 * @param 参数 fFroce：作用力
	 */
	public static native void		SetSpriteMountForce( String szName,  float fForce );

	/**
	 * SetSpriteMountTrackRotation：绑定的精灵是否跟随母体旋转
	 * @param 参数 szName：精灵名字
	 * @param 参数 bTrackRotation：true 跟随 false 不跟随
	 */
	public static native void		SetSpriteMountTrackRotation( String szName,  boolean bTrackRotation );

	/**
	 * SetSpriteMountOwned：母体被删除的时候，绑定的精灵是否也跟着被删除
	 * @param 参数 szName：精灵名字
	 * @param 参数 bMountOwned：true 跟着 false 不跟着
	 */
	public static native void		SetSpriteMountOwned( String szName,  boolean bMountOwned );

	/**
	 * SetSpriteMountInheritAttributes：绑定的时候，是否继承母体的属性
	 * @param 参数 szName：精灵名字
	 * @param 参数 bInherAttr：true 继承 false 不继承
	 */
	public static native void		SetSpriteMountInheritAttributes( String szName,  boolean bInherAttr );

	/**
	 * SpriteDismount：将已经绑定的精灵进行解绑
	 * @param 参数 szName：精灵名字
	 */
	public static native void		SpriteDismount( String szName );

	/**
	 * GetSpriteIsMounted：判断精灵是否绑定在另一个精灵上
	 * @param 参数 szName：精灵名字
	 * @return 返回值：true 绑定 false 不绑定
	 */
	public static native boolean		GetSpriteIsMounted( String szName );

	/**
	 * GetSpriteMountedParent：获取绑定的母体精灵的名字
	 * @param 参数 szName：精灵名字
	 * @return 返回值：母体精灵名字，如果未绑定，则返回空字符串
	 */
	public static native String	GetSpriteMountedParent( String szName );

	/**
	 * SetSpriteColorRed：更改精灵显示颜色中的红色。默认精灵的红绿蓝三颜色的值均为255，修改其中一项将可以改变其颜色
	 * @param 参数 szName：精灵名字
	 * @param 参数 iCol：颜色范围 0 - 255
	 */
	public static native void		SetSpriteColorRed( String szName,  int iCol );

	/**
	 * SetSpriteColorGreen：更改精灵显示颜色中的绿色。默认精灵的红绿蓝三颜色的值均为255，修改其中一项将可以改变其颜色
	 * @param 参数 szName：精灵名字
	 * @param 参数 iCol：颜色范围 0 - 255
	 */
	public static native void		SetSpriteColorGreen( String szName,  int iCol );

	/**
	 * SetSpriteColorBlue：更改精灵显示颜色中的蓝色。默认精灵的红绿蓝三颜色的值均为255，修改其中一项将可以改变其颜色
	 * @param 参数 szName：精灵名字
	 * @param 参数 iCol：颜色范围 0 - 255
	 */
	public static native void		SetSpriteColorBlue( String szName,  int iCol );

	/**
	 * SetSpriteColorAlpha：设置精灵透明度
	 * @param 参数 szName：精灵名字
	 * @param 参数 iCol：透明度，值0 - 255，从完全透明至完全不透明
	 */
	public static native void		SetSpriteColorAlpha( String szName,  int iCol );

	/**
	 * GetSpriteColorRed：获取精灵显示颜色中的红色值
	 * @param 参数 szName：精灵名字
	 * @return 返回值：颜色值
	 */
	public static native int		GetSpriteColorRed( String szName );

	/**
	 * GetSpriteColorGreen：获取精灵显示颜色中的绿色值
	 * @param 参数 szName：精灵名字
	 * @return 返回值：颜色值
	 */
	public static native int		GetSpriteColorGreen( String szName );

	/**
	 * GetSpriteColorBlue：获取精灵显示颜色中的蓝色值
	 * @param 参数 szName：精灵名字
	 * @return 返回值：颜色值
	 */
	public static native int		GetSpriteColorBlue( String szName );

	/**
	 * GetSpriteColorAlpha：获取精灵透明度
	 * @param 参数 szName：精灵名字
	 * @return 返回值：透明度
	 */ 
	public static native int		GetSpriteColorAlpha( String szName );

	/**
	 * SetStaticSpriteImage：设置/更改静态精灵的显示图片
	 * @param 参数 szName：精灵名字
	 * @param 参数 szImageName：图片名字
	 * @param 参数 iFrame：该图片的显示帧数。为编辑器预览图里显示的1/N，范围为 0 到 N - 1
	 */
	public static native void		SetStaticSpriteImage( String szName, String szImageName,  int iFrame );

	/**
	 * SetStaticSpriteFrame：设置静态精灵当前图片的显示帧数
	 * @param 参数 szName：精灵名字
	 * @param 参数 iFrame：该图片的显示帧数。为编辑器预览图里显示的1/N，范围为 0 到 N - 1
	 */
	public static native void		SetStaticSpriteFrame( String szName,  int iFrame );

	/**
	 * GetStaticSpriteImage：获取精灵当前显示的图片名字
	 * @param 参数 szName：精灵名字
	 * @return 返回值：图片名字
	 */
	public static native String GetStaticSpriteImage( String szName );

	/**
	 * GetStaticSpriteFrame：获取精灵当前显示的图片帧数
	 * @param 参数 szName：精灵名字
	 * @return 返回值：帧数
	 */
	public static native int		GetStaticSpriteFrame( String szName );

	/**
	 * SetAnimateSpriteFrame：设置动态精灵的动画帧数
	 * @param 参数 szName：精灵名字
	 * @param 参数 iFrame：动画帧数
	 */
	public static native void		SetAnimateSpriteFrame( String szName,  int iFrame );

	/**
	 * IsAnimateSpriteAnimationFinished：判断动态精灵当前动画是否播放完毕，只针对非循环动画而言
	 * @param 参数 szName：精灵名字
	 * @return 返回值：true 完毕 false 未完毕
	 */
	public static native boolean		IsAnimateSpriteAnimationFinished( String szName);

	/**
	 * GetAnimateSpriteAnimationName：获取动态精灵当前动画名字
	 * @param 参数 szName：精灵名字
	 * @return 返回值：动画名字
	 */
	public static native String GetAnimateSpriteAnimationName( String szName );

	/**
	 * GetAnimateSpriteAnimationTime：获取动画精灵当前动画时间长度
	 * @param 参数 szName：精灵名字
	 * @return 返回值：长度，单位秒
	 */
	public static native float	GetAnimateSpriteAnimationTime( String szName );

	/**
	 * AnimateSpritePlayAnimation：动画精灵播放动画
	 * @param 参数 szName：精灵名字
	 * @param 参数 szAnim：动画名字
	 * @param 参数 bRestore：播放完毕后是否恢复当前动画. true 恢复 false 不恢复
	 * @return 返回值：是否播放成功, true : 成功 false ：不成功
	 */
	public static native boolean		AnimateSpritePlayAnimation( String szName, String szAnim,  boolean bRestore );

	/**
	 * SetTextValue：文字精灵显示某个数值
	 * @param 参数 szName：精灵名字
	 * @param 参数 iValue：要显示的数值
	 */
	public static native void		SetTextValue( String szName, int iValue );

	/**
	 * SetTextValueFloat：文字精灵显示某个浮点数值
	 * @param 参数 szName：精灵名字
	 * @param 参数 fValue：要显示的数值
	 */
	public static native void		SetTextValueFloat( String szName, float fValue );

	/**
	 * SetTextString：文字精灵显示某个字符串文字
	 * @param 参数 szName：精灵名字
	 * @param 参数 szStr：要显示的字符串
	 */
	public static native void		SetTextString( String szName, String szStr );

	/**
	 * PlaySound：播放声音
	 * @param 参数 szName：声音的路径及名称，具体值请在编辑器的资源 -> 添加声音那里查看本项目里的声音资源，完整按照那个路径值填写即可
	 * @param 参数 bLoop：是否循环播放 true 循环 false 不循环。循环播放的声音，需要手动停止，请使用返回的ID，调用API停止该声音的播放。非循环的播放完之后将自动停止
	 * @param 参数 fVolume：音量大小，0-1。1为声音文件的原声大小
	 * @return 返回值：声音ID，循环播放的声音需要该ID来停止播放
	 */
	public static native int		PlaySound(String szName,  boolean bLoop,  float fVolume );

	/**
	 * StopSound：停止声音的播放
	 * @param 参数 iSoundId：API PlaySound 播放声音的时候返回的声音ID
	 */
	public static native void		StopSound(  int iSoundId );

	/**
	 * StopAllSound：停止播放所有声音
	 */
	public static native void		StopAllSound();

	/**
	 * PlayEffect：播放一个不循环的特效，播放完毕之后该特效自动删除
	 * @param 参数 szSrcName：预先摆放在地图中的特效模板名字
	 * @param 参数 fLifeTime：生命时长，时间到了之后将被自动删除
	 * @param 参数 fPosX：播放的X坐标
	 * @param 参数 fPosY：播放的Y坐标
	 * @param 参数 fRotation：播放的角度朝向
	 */
	public static native void		PlayEffect(String szSrcName,  float fLifeTime,  float fPosX,  float fPosY,  float fRotation);

	/**
	 * PlayLoopEffect：播放一个循环特效，不需要该特效的时候，需要自己调用API进行删除
	 * @param 参数 szSrcName：预先摆放在地图中的特效模板名字
	 * @param 参数 szMyName：新特效名字，要删除该特效的时候用到
	 * @param 参数 fCycleTime：循环时长，时间到了之后将重头播放
	 * @param 参数 fPosX：播放的X坐标
	 * @param 参数 fPosY：播放的Y坐标
	 * @param 参数 fRotation：播放的角度朝向
	 */
	public static native void		PlayLoopEffect(String szSrcName, String szMyName,  float fCycleTime,  float fPosX,  float fPosY,  float fRotation);

	/**
	 * DeleteEffect：删除一个正在播放的特效，只有循环特效才需要手动删除
	 * @param 参数 szName：特效名字
	 */
	public static native void		DeleteEffect(String szName);

	//////////////////////////////////////////////////////////////////////////////////////////
	//
	// 以下API为系统API，请勿自己调用
	//
	//////////////////////////////////////////////////////////////////////////////////////////

	// GetTimeDelta：获取两次调用本函数之间的时间差
	// 返回值：float，单位 秒
	//

	public static native float		GetTimeDelta();

	// 引
    public static native boolean	EngineMainLoop();
    public static native boolean	InitGameEngine( EngineCall MethodObj, String[] args );
    public static native void		ShutdownGameEngine();

    static
    {
    	boolean bSuccess	=	false;
    	try{
    		System.loadLibrary("src/API/FunCode/EngineAPI");
    		//System.out.println("Loaded 32 bit dll.");
    		bSuccess	=	true;
    	}
    	catch(Throwable ex)
    	{
    		//System.out.println("Load DLL Exception：" + ex.getMessage());
    	}

    	if( !bSuccess )
    	{
    		try{
    			System.loadLibrary("src/API/FunCode/EngineAPI_64");
    			//System.out.println("Loaded 64 bit dll.");
    		}
			catch(Throwable ex)
			{
				//System.out.println("Load DLL Exception：" + ex.getMessage());
			}
    	}
    }
}
