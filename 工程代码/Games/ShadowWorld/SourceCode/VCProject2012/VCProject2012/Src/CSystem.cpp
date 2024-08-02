
#include "CSystem.h"
#include "CGameMain.h"
//==========================================================================
//
// 引擎捕捉鼠标移动消息后，将调用到本函数
// 参数 fMouseX, fMouseY：为鼠标当前坐标
//
void CSystem::OnMouseMove( const float fMouseX, const float fMouseY )
{
	// 可以在此添加游戏需要的响应函数
	g_GameMain.OnMouseMove(fMouseX, fMouseY);
}
//==========================================================================
//
// 引擎捕捉鼠标点击消息后，将调用到本函数
// 参数 iMouseType：鼠标按键值，见 enum MouseTypes 定义
// 参数 fMouseX, fMouseY：为鼠标当前坐标
//
void CSystem::OnMouseClick( const int iMouseType, const float fMouseX, const float fMouseY )
{
	// 可以在此添加游戏需要的响应函数
	g_GameMain.OnMouseClick(iMouseType, fMouseX, fMouseY);
}
//==========================================================================
//
// 引擎捕捉鼠标弹起消息后，将调用到本函数
// 参数 iMouseType：鼠标按键值，见 enum MouseTypes 定义
// 参数 fMouseX, fMouseY：为鼠标当前坐标
//
void CSystem::OnMouseUp( const int iMouseType, const float fMouseX, const float fMouseY )
{
	// 可以在此添加游戏需要的响应函数
	g_GameMain.OnMouseUp(iMouseType, fMouseX, fMouseY);
}
//==========================================================================
//
// 引擎捕捉键盘按下消息后，将调用到本函数
// 参数 iKey：被按下的键，值见 enum KeyCodes 宏定义
// 参数 iAltPress, iShiftPress，iCtrlPress：键盘上的功能键Alt，Ctrl，Shift当前是否也处于按下状态(0未按下，1按下)
//
void CSystem::OnKeyDown( const int iKey, const bool bAltPress, const bool bShiftPress, const bool bCtrlPress )
{
	// 可以在此添加游戏需要的响应函数
	g_GameMain.OnKeyDown(iKey, bAltPress, bShiftPress, bCtrlPress);
}
//==========================================================================
//
// 引擎捕捉键盘弹起消息后，将调用到本函数
// 参数 iKey：弹起的键，值见 enum KeyCodes 宏定义
//
void CSystem::OnKeyUp( const int iKey )
{
	// 可以在此添加游戏需要的响应函数
	g_GameMain.OnKeyUp(iKey);
}

//===========================================================================
//
// 引擎捕捉到精灵与精灵碰撞之后，调用此函数
// 精灵之间要产生碰撞，必须在编辑器或者代码里设置精灵发送及接受碰撞
// 参数 szSrcName：发起碰撞的精灵名字
// 参数 szTarName：被碰撞的精灵名字
//
void CSystem::OnSpriteColSprite( const char *szSrcName, const char *szTarName )
{
	// 可以在此添加游戏需要的响应函数
	g_GameMain.OnSpriteColSprite(szSrcName, szTarName);
}

//===========================================================================
//
// 引擎捕捉到精灵与世界边界碰撞之后，调用此函数.
// 精灵之间要产生碰撞，必须在编辑器或者代码里设置精灵的世界边界限制
// 参数 szName：碰撞到边界的精灵名字
// 参数 iColSide：碰撞到的边界 0 左边，1 右边，2 上边，3 下边
//
void CSystem::OnSpriteColWorldLimit( const char *szName, const int iColSide )
{
	// 可以在此添加游戏需要的响应函数
	g_GameMain.OnSpriteColWorldLimit(szName, iColSide);

}

