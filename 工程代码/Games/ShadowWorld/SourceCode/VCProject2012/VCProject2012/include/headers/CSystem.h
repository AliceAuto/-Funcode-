#ifndef CSYSTEM_H
#define CSYSTEM_H

#include <windows.h>
////////////////////////////////////////////////////////////////////////////////
//
// 类：CSystem
// 系统相关功能的类. 函数调用方法 CSystem::函数名();
//
class CSystem
{
public:
	CSystem();
	~CSystem();

	// OnMouseMove：鼠标移动后将被调用的函数，可在此函数体里(Main.cpp)增加自己的响应代码
	// 参数 fMouseX, fMouseY：为鼠标当前坐标
	//
	static void		OnMouseMove( const float fMouseX, const float fMouseY );

	// OnMouseClick：鼠标按下后将被调用的函数，可在此函数体里(Main.cpp)增加自己的响应代码
	// 参数 iMouseType：鼠标按键值，见 enum MouseTypes 定义
	// 参数 fMouseX, fMouseY：为鼠标当前坐标
	//
	static void		OnMouseClick( const int iMouseType, const float fMouseX, const float fMouseY );

	// OnMouseUp：鼠标按下后将被调用的函数，可在此函数体里(Main.cpp)增加自己的响应代码
	// 参数 iMouseType：鼠标按键值，见 enum MouseTypes 定义
	// 参数 fMouseX, fMouseY：为鼠标当前坐标
	//
	static void		OnMouseUp( const int iMouseType, const float fMouseX, const float fMouseY );

	// OnKeyDown：键盘被按下后将被调用的函数，可在此函数体里(Main.cpp)增加自己的响应代码
	// 参数 iKey：被按下的键，值见 enum KeyCodes 宏定义
	// 参数 bAltPress, bShiftPress，bCtrlPress：键盘上的功能键Alt，Ctrl，Shift当前是否也处于按下状态
	//
	static void		OnKeyDown( const int iKey, const bool bAltPress, const bool bShiftPress, const bool bCtrlPress );

	// OnKeyUp：键盘按键弹起后将被调用的函数，可在此函数体里(Main.cpp)增加自己的响应代码
	// 参数 iKey：弹起的键，值见 enum KeyCodes 宏定义
	//
	static void		OnKeyUp( const int iKey );

	// OnSpriteColSprite：精灵与精灵碰撞后将被调用的函数，可在此函数体里(Main.cpp)增加自己的响应代码
	// 精灵之间要产生碰撞，必须在编辑器或者代码里设置精灵发送及接受碰撞
	// 参数 szSrcName：发起碰撞的精灵名字
	// 参数 szTarName：被碰撞的精灵名字
	//
	static void		OnSpriteColSprite( const char *szSrcName, const char *szTarName );

	// OnSpriteColWorldLimit：精灵与世界边界碰撞后将被调用的函数，可在此函数体里(Main.cpp)增加自己的响应代码
	// 精灵之间要产生碰撞，必须在编辑器或者代码里设置精灵的世界边界限制
	// 参数 szName：碰撞到边界的精灵名字
	// 参数 iColSide：碰撞到的边界 0 左边，1 右边，2 上边，3 下边
	//
	static void		OnSpriteColWorldLimit( const char *szName, const int iColSide );

	// MakeSpriteName: 将前面的字符串与后面的数字整合成一个字符串。
	// 参数 szPrev：一个非空字符串，最长不能超过20个英文字符。名字前面的字符。
	// 参数 iId：一个数字
	// 返回值：返回一个字符串，比如传入("xxx", 2),则返回"xxx2"
	//
	static char* MakeSpriteName(const char *szPrev, const int iId);

	// CursorOff：关闭鼠标不显示。此API隐藏的是整个Windows的鼠标，除非调用开启鼠标的API dCursorOn，否则鼠标将一直不显示
	//
	static void		CursorOff();

	// CursorOn：开启鼠标显示。将API dCursorOff关闭的鼠标重新开启显示
	//
	static void		CursorOn();

	// IsCursorOn：当前鼠标是开启还是关闭。对应的是用API dCursorOff和dCursorOn开启或者关闭的操作
	// 返回值：true为开启状态，false为关闭状态
	//
	static bool		IsCursorOn();

	// ShowCursor：隐藏/显示鼠标。此API只是隐藏本程序窗口内的鼠标，移动到窗口外的时候，鼠标还是会显示
	// 参数 bShow：true 为显示，false 为隐藏
	//
	static void		ShowCursor( const bool bShow );

	// IsShowCursor：当前鼠标是显示还是隐藏。对应的是用API ShowCursor隐藏或者显示的操作
	// 返回值：true为开启状态，false为关闭状态
	//
	static bool		IsShowCursor();

	// SetWindowTitle：设置窗口名字/标题
	// 参数 szTitle：非空字符串
	//
	static void		SetWindowTitle( const char *szTitle );

	// ResizeWindow：更改窗口大小
	// 参数 iWidth：宽度，大于0小于等于1920
	// 参数 iHeight：高度，大于0小于等于1080
	//
	static void		ResizeWindow(int iWidth, int iHeight);

	// GetHwnd：获取窗口句柄
	// 返回值：窗口句柄
	//
	static void		*GetHwnd();

	// Random：获取一个大于等于0的随机数
	// 返回值：int，范围0 - 2147483648
	//
	static int		Random();

	// RandomRange：获取一个位于参数1到参数2之间的随机数
	// 返回值：int，范围iMin - iMax
	// 参数 iMin：小于iMax的整数
	// 参数 iMax：大于iMin的整数
	//
	static int		RandomRange( const int iMin, const int iMax );

	// CalLineRotation：计算两点连线的直线的旋转角度
	// 返回值：角度，范围0 - 360
	// 参数 fStartX：起始坐标X
	// 参数 fStartY：起始坐标Y
	// 参数 fEndX：终点坐标X
	// 参数 fEndY：终点坐标Y
	//
	static float	CalLineRotation( const float fStartX, const float fStartY, const float fEndX, const float fEndY );

	// RotationToVectorX：计算某个角度对应的直线向量的X方向
	// 参数 fRotation：角度，范围0 - 360
	// 返回值 ：该直线向量的X值
	//
	static float	RotationToVectorX( const float fRotation );

	// RotationToVectorY：计算某个角度对应的直线向量的Y方向
	// 参数 fRotation：角度，范围0 - 360
	// 返回值 ：该直线向量的Y值
	//
	static float	RotationToVectorY( const float fRotation );

	// DrawLine：在两点之间画一条线
	// 参数 fStartX：起始坐标X
	// 参数 fStartY：起始坐标Y
	// 参数 fEndX：终点坐标X
	// 参数 fEndY：终点坐标Y
	// 参数 fLineWidth：线的粗细，大于等于1
	// 参数 iLayer：改线所在的层，与编辑器里设置的精灵的层级是同一个概念。范围0 - 31。
	// 参数 iRed, iGreen, iBlue : 红绿蓝三原色的颜色值，范围 0 - 255
	// 参数 iAlpha：线的透明度，范围0-255. 0为全透明，255为不透明
	//
	static void		DrawLine( const float fStartX, const float fStartY, const float fEndX, const float fEndY, const float fLineWidth, const int iLayer, const int iRed, const int iGreen, const int iBlue, const int iAlpha );

	// DrawTriangle：画一个三角形
	// 参数 fX1,fX2,fX3：三角形上三个点的X坐标
	// 参数 fY1,fY2,fY3：三角形上三个点的Y坐标
	// 参数 fLineWidth：线的粗细，大于等于1
	// 参数 iLayer：该三角形所在的层，与编辑器里设置的精灵的层级是同一个概念。范围0 - 31。
	// 参数 iRed, iGreen, iBlue : 红绿蓝三原色的颜色值，范围 0 - 255
	// 参数 iAlpha：三角形的透明度，范围0-255. 0为全透明，255为不透明
	//
	static void		DrawTriangle( const float fX1, const float fY1, const float fX2, const float fY2, const float fX3, const float fY3, const float fLineWidth, const int iLayer, const int iRed, const int iGreen, const int iBlue, const int iAlpha );

	// DrawRect：画一个矩形
	// 参数 fUpperX：左上角坐标X
	// 参数 fUpperY：左上角坐标Y
	// 参数 fLowerX：右下角坐标X
	// 参数 fLowerY：右下角坐标Y
	// 参数 fLineWidth：线的粗细，大于等于1
	// 参数 iLayer：该矩形所在的层，与编辑器里设置的精灵的层级是同一个概念。范围0 - 31。
	// 参数 iRed, iGreen, iBlue : 红绿蓝三原色的颜色值，范围 0 - 255
	// 参数 iAlpha：矩形的透明度，范围0-255. 0为全透明，255为不透明
	//
	static void		DrawRect( const float fUpperX, const float fUpperY, const float fLowerX, const float fLowerY, const float fLineWidth, const int iLayer, const int iRed, const int iGreen, const int iBlue, const int iAlpha );

	// DrawCircle：画一个圆
	// 参数 fCenterX：圆心坐标X
	// 参数 fCenterY：圆心坐标Y
	// 参数 fRadius：圆的半径
	// 参数 iSegment：圆弧段数，范围4-72. 比如传入6，将得到一个6边形，段数越大越圆滑，但是画图效率越低
	// 参数 fLineWidth：线的粗细，大于等于1
	// 参数 iLayer：该圆所在的层，与编辑器里设置的精灵的层级是同一个概念。范围0 - 31。
	// 参数 iRed, iGreen, iBlue : 红绿蓝三原色的颜色值，范围 0 - 255
	// 参数 iAlpha：圆的透明度，范围0-255. 0为全透明，255为不透明
	//
	static void		DrawCircle( const float fCenterX, const float fCenterY, const float fRadius, const int iSegment, const float fLineWidth, const int iLayer, const int iRed, const int iGreen, const int iBlue, const int iAlpha );

	// GetScreenLeft：获取世界边界之左边X坐标
	// 返回值：左边界X坐标
	//
	static float	GetScreenLeft();

	// GetScreenTop：获取世界边界之上边Y坐标
	// 返回值：上边界Y坐标
	//
	static float	GetScreenTop();

	// GetScreenRight：获取世界边界之右边X坐标
	// 返回值：右边界X坐标
	//
	static float	GetScreenRight();

	// GetScreenBottom：获取世界边界之下边Y坐标
	// 返回值：下边界Y坐标
	//
	static float	GetScreenBottom();

	// LoadMap：载入新场景。注意，载入新场景的时候，旧场景的所有精灵都将被引擎删除掉，所以所有在程序中创建、复制出来的精灵都必须在调用本API之前先删除掉
	// 参数 szName：场景名字。即新建场景保存的时候取的名字，必须带小写的后缀 -- xxx.t2d。不用带路径
	//
	static void		LoadMap( const char *szName );

	//////////////////////////////////////////////////////////////////////////////////////////
	//
	// 以下API为系统API，请勿自己调用
	//
	//////////////////////////////////////////////////////////////////////////////////////////

	// GetTimeDelta：获取两次调用本函数之间的时间差
	// 返回值：float，单位 秒
	//
	static float	GetTimeDelta();
	// EngineMainLoop：引擎主循环函数。请勿自己调用
	//
	static bool		EngineMainLoop();
	// InitGameEngine：初始化引擎，请勿自己调用
	//
	static bool		InitGameEngine( HINSTANCE hInstance, LPSTR lpCmdLine );
	static bool		InitGameEngineEx( HINSTANCE hInstance, LPSTR lpCmdLine );
	// ShutdownGameEngine：关闭引擎，请勿自己调用
	//
	static void		ShutdownGameEngine();
};



#endif