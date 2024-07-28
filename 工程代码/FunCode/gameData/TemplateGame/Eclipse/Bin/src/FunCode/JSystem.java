/**
 * @(#)JSystem.java
 *
 * JSystem application
 *
 * @author
 * @version 1.00
 */

 package FunCode;

 import FunCode.EngineCall;
 import FunCode.EngineAPI;

/**
 * 类：JSystem
 * 系统相关功能的类. 函数调用方法 CSystem::函数名();
 * @author root
 *
 */
public class JSystem
{

	/**
	 * CursorOff：关闭鼠标不显示。此API隐藏的是整个Windows的鼠标，除非调用开启鼠标的API dCursorOn，否则鼠标将一直不显示
	 */
	public	static void		CursorOff()
	{
		EngineAPI.CursorOff();
	}

	/**
	 * CursorOn：开启鼠标显示。将API dCursorOff关闭的鼠标重新开启显示
	 */
	public	static void		CursorOn()
	{
		EngineAPI.CursorOn();
	}

	/**
	 * IsCursorOn：当前鼠标是开启还是关闭。对应的是用API dCursorOff和dCursorOn开启或者关闭的操作
	 * @return 返回值：true为开启状态，false为关闭状态
	 */
	public	static boolean		IsCursorOn()
	{
		return EngineAPI.IsCursorOn();
	}

	/**
	 * ShowCursor：隐藏/显示鼠标。此API只是隐藏本程序窗口内的鼠标，移动到窗口外的时候，鼠标还是会显示
	 * @param 参数 bShow：true 为显示，false 为隐藏
	 */
	public	static void		ShowCursor(  boolean bShow )
	{
		EngineAPI.ShowCursor( bShow );
	}

	/**
	 * IsShowCursor：当前鼠标是显示还是隐藏。对应的是用API ShowCursor隐藏或者显示的操作
	 * @return 返回值：true为开启状态，false为关闭状态
	 */
	public	static boolean		IsShowCursor()
	{
		return EngineAPI.IsShowCursor();
	}

	/**
	 * SetWindowTitle：设置窗口名字/标题
	 * @param 参数 szTitle：非空字符串
	 */
	public	static void		SetWindowTitle( String szTitle )
	{
		EngineAPI.SetWindowTitle( szTitle );
	}

	/**
	 * ResizeWindow：更改窗口大小
	 * @param 参数 iWidth：宽度，大于0小于等于1920
	 * @param 参数 iHeight：高度，大于0小于等于1080
	 */
	public	static void		ResizeWindow(int iWidth, int iHeight)
	{
		EngineAPI.ResizeWindow( iWidth, iHeight);
	}

	/**
	 * Random：获取一个大于等于0的随机数
	 * @return 返回值：int，范围0 - 2147483648
	 */
	public	static int		Random()
	{
		return EngineAPI.Random();
	}

	/**
	 * RandomRange：获取一个位于参数1到参数2之间的随机数
	 * @param 参数 iMin：小于iMax的整数
	 * @param 参数 iMax：大于iMin的整数
	 * @return 返回值：int，范围iMin - iMax
	 */
	public	static int		RandomRange(  int iMin,  int iMax )
	{
		return EngineAPI.RandomRange( iMin, iMax );
	}

	/**
	 * CalLineRotation：计算两点连线的直线的旋转角度
	 * @param 参数 fStartX：起始坐标X
	 * @param 参数 fStartY：起始坐标Y
	 * @param 参数 fEndX：终点坐标X
	 * @param 参数 fEndY：终点坐标Y
	 * @return 返回值：角度，范围0 - 360
	 */
	public	static float	CalLineRotation(  float fStartX,  float fStartY,  float fEndX,  float fEndY )
	{
		return EngineAPI.CalLineRotation( fStartX, fStartY, fEndX, fEndY );
	}

	/**
	 * RotationToVectorX：计算某个角度对应的直线向量的X方向
	 * @param 参数 fRotation：角度，范围0 - 360
	 * @return 返回值 ：该直线向量的X值
	 */
	public	static float	RotationToVectorX(  float fRotation )
	{
		return EngineAPI.RotationToVectorX( fRotation );
	}

	/**
	 * RotationToVectorY：计算某个角度对应的直线向量的Y方向
	 * @param 参数 fRotation：角度，范围0 - 360
	 * @return 返回值 ：该直线向量的Y值
	 */
	public	static float	RotationToVectorY(  float fRotation )
	{
		return EngineAPI.RotationToVectorY( fRotation );
	}

	/**
	 * DrawLine：在两点之间画一条线
	 * @param 参数 fStartX：起始坐标X
	 * @param 参数 fStartY：起始坐标Y
	 * @param 参数 fEndX：终点坐标X
	 * @param 参数 fEndY：终点坐标Y
	 * @param 参数 fLineWidth：线的粗细，大于等于1
	 * @param 参数 iLayer：改线所在的层，与编辑器里设置的精灵的层级是同一个概念。范围0 - 31。
	 * @param 参数 iRed : 红绿蓝三原色的颜色值，范围 0 - 255
	 * @param 参数 iGreen : 红绿蓝三原色的颜色值，范围 0 - 255
	 * @param 参数iBlue : 红绿蓝三原色的颜色值，范围 0 - 255
	 * @param 参数 iAlpha：线的透明度，范围0-255. 0为全透明，255为不透明
	 */
	public	static void		DrawLine(  float fStartX,  float fStartY,  float fEndX,  float fEndY,  float fLineWidth,  int iLayer,  int iRed,  int iGreen,  int iBlue,  int iAlpha )
	{
		EngineAPI.DrawLine( fStartX, fStartY, fEndX, fEndY, fLineWidth, iLayer, iRed, iGreen, iBlue, iAlpha );
	}

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
	public	static void		DrawTriangle(  float fX1,  float fY1,  float fX2,  float fY2,  float fX3,  float fY3,  float fLineWidth,  int iLayer,  int iRed,  int iGreen,  int iBlue,  int iAlpha )
	{
		EngineAPI.DrawTriangle( fX1, fY1, fX2, fY2, fX3, fY3, fLineWidth, iLayer, iRed, iGreen, iBlue, iAlpha );
	}

	/**
	 * DrawRect：画一个矩形
	 * @param 参数 fUpperX：左上角坐标X
	 * @param 参数 fUpperY：左上角坐标Y
	 * @param 参数 fLowerX：右下角坐标X
	 * @param 参数 fLowerY：右下角坐标Y
	 * @param 参数 fLineWidth：线的粗细，大于等于1
	 * @param 参数 iLayer：该矩形所在的层，与编辑器里设置的精灵的层级是同一个概念。范围0 - 31
	 * @param 参数 iRed : 红绿蓝三原色的颜色值，范围 0 - 255
	 * @param 参数 iGreen : 红绿蓝三原色的颜色值，范围 0 - 255
	 * @param 参数 iBlue : 红绿蓝三原色的颜色值，范围 0 - 255
	 * @param 参数 iAlpha：矩形的透明度，范围0-255. 0为全透明，255为不透明
	 */
	public	static void		DrawRect(  float fUpperX,  float fUpperY,  float fLowerX,  float fLowerY,  float fLineWidth,  int iLayer,  int iRed,  int iGreen,  int iBlue,  int iAlpha )
	{
		EngineAPI.DrawRect( fUpperX, fUpperY, fLowerX, fLowerY, fLineWidth, iLayer, iRed, iGreen, iBlue, iAlpha );
	}

	/**
	 * DrawCircle：画一个圆
	 * @param 参数 fCenterX：圆心坐标X
	 * @param 参数 fCenterY：圆心坐标Y
	 * @param 参数 fRadius：圆的半径
	 * @param 参数 iSegment：圆弧段数，范围4-72. 比如传入6，将得到一个6边形，段数越大越圆滑，但是画图效率越低
	 * @param 参数 fLineWidth：线的粗细，大于等于1
	 * @param 参数 iLayer：该圆所在的层，与编辑器里设置的精灵的层级是同一个概念。范围0 - 31
	 * @param 参数 iRed : 红绿蓝三原色的颜色值，范围 0 - 255
	 * @param 参数 iGreen : 红绿蓝三原色的颜色值，范围 0 - 255
	 * @param 参数  iBlue : 红绿蓝三原色的颜色值，范围 0 - 255
	 * @param 参数 iAlpha：圆的透明度，范围0-255. 0为全透明，255为不透明
	 */
	public	static void		DrawCircle(  float fCenterX,  float fCenterY,  float fRadius,  int iSegment,  float fLineWidth,  int iLayer,  int iRed,  int iGreen,  int iBlue,  int iAlpha )
	{
		EngineAPI.DrawCircle( fCenterX, fCenterY, fRadius, iSegment, fLineWidth, iLayer, iRed, iGreen, iBlue, iAlpha );
	}

	/**
	 * GetScreenLeft：获取世界边界之左边X坐标
	 * @return 返回值：左边界X坐标
	 */
	public	static float	GetScreenLeft()
	{
		return EngineAPI.GetScreenLeft();
	}

   /**
    * GetScreenTop：获取世界边界之上边Y坐标
    * @return 返回值：上边界Y坐标
    */
	public	static float	GetScreenTop()
	{
		return EngineAPI.GetScreenTop();
	}

	/**
	 * GetScreenRight：获取世界边界之右边X坐标
	 * @return 返回值：右边界X坐标
	 */
	public	static float	GetScreenRight()
	{
		return EngineAPI.GetScreenRight();
	}

	/**
	 * GetScreenBottom：获取世界边界之下边Y坐标
	 * @return 返回值：下边界Y坐标
	 */
	public	static float	GetScreenBottom()
	{
		return EngineAPI.GetScreenBottom();
	}

	/**
	 * LoadMap：载入新场景。注意，载入新场景的时候，旧场景的所有精灵都将被引擎删除掉，所以所有在程序中创建、复制出来的精灵都必须在调用本API之前先删除掉
	 * @param 参数 szName：场景名字。即新建场景保存的时候取的名字，必须带小写的后缀 -- xxx.t2d。不用带路径
	 */
	public	static void		LoadMap( String szName )
	{
		EngineAPI.LoadMap( szName );
	}

	//////////////////////////////////////////////////////////////////////////////////////////
	//
	// 以下API为系统API，请勿自己调用
	//
	//////////////////////////////////////////////////////////////////////////////////////////


	/**
	 * GetTimeDelta：获取两次调用本函数之间的时间差
	 * @return 返回值：float，单位 秒
	 */
	public	static float	GetTimeDelta()
	{
		return EngineAPI.GetTimeDelta();
	}
	
	/**
	 * EngineMainLoop：引擎主循环函数。请勿自己调用
	 * @return
	 */
	public	static boolean		EngineMainLoop()
	{
		return EngineAPI.EngineMainLoop();
	}
	
	/**
	 * InitGameEngine：初始化引擎，请勿自己调用
	 * @param MethodObj
	 * @param args
	 * @return
	 */
	public	static boolean		InitGameEngine( EngineCall MethodObj, String[] args )
	{
		return EngineAPI.InitGameEngine( MethodObj, args );
	}
	
	/**
	 * ShutdownGameEngine：关闭引擎，请勿自己调用
	 */
	public	static void		ShutdownGameEngine()
	{
		EngineAPI.ShutdownGameEngine();
	}
};