
#include "CSystem.h"//					引擎接口文件
#include "CGameMain.h"//				引用时游戏逻辑系统需要这个
#include "headers\EventDrivenSystem.h"	//	包的构建与监听需要这个
#include "Logger.h"	//					用来记录程序的运行日志
#include <string>//						用来强制转化类型为string
#include "Setting.h"//					会用到里面的一些枚举体





//==========================================================================
/*
								游戏框架实现
*/
//==========================================================================





















//==========================================================================
void CSystem::OnMouseMove( const float fMouseX, const float fMouseY )
{
	// 可以在此添加游戏需要的响应函数
	CGameMain::GetInstance().OnMouseMove(fMouseX, fMouseY);
	
	/*
	// 创建事件并分发
    MouseInputEvent mouseEvent(fMouseX, fMouseY);		//分发	鼠标移动事件 <fMouseX, fMouseY>


	//触发事件
    eventManager.DispatchEvent(mouseEvent); //			触发鼠标事件的		<xxx监听器>

		
	//日志记录
    LogManager::Log("<"+std::to_string(fMouseY)+","+std::to_string(fMouseY)+">");//格式	<fMouseX, fMouseY>
	*/
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
	CGameMain::GetInstance().OnMouseClick(iMouseType, fMouseX, fMouseY);
	
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
	CGameMain::GetInstance().OnMouseUp(iMouseType, fMouseX, fMouseY);
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
	CGameMain::GetInstance().OnKeyDown(iKey, bAltPress, bShiftPress, bCtrlPress);

	




}
//==========================================================================
//
// 引擎捕捉键盘弹起消息后，将调用到本函数
// 参数 iKey：弹起的键，值见 enum KeyCodes 宏定义
//
void CSystem::OnKeyUp( const int iKey )
{
	// 可以在此添加游戏需要的响应函数
	CGameMain::GetInstance().OnKeyUp(iKey);






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
	CGameMain::GetInstance().OnSpriteColSprite(szSrcName, szTarName);
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
	CGameMain::GetInstance().OnSpriteColWorldLimit(szName, iColSide);

}

