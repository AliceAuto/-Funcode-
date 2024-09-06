
#include <Stdio.h>
#include "CGameMain.h"
#include "headers\PlayerController.h"
#include "Setting.h"
#include "Logger.h"
#include "headers\SceneStates.h"
#include "headers\StateMachine.h"
#include "Device.h"

//============================================================
/*
						游戏框架系统实现
*/
//============================================================

















////////////////////////////////////////////////////////////////////////////////
//
//



//==============================================================================
//
// 大体的程序流程为：GameMainLoop函数为主循环函数，在引擎每帧刷新屏幕图像之后，都会被调用一次。

//==============================================================================
//
// 构造函数
CGameMain::CGameMain()
{
	m_iGameState			=	1;
	

}
//==============================================================================
//
// 析构函数
CGameMain::~CGameMain()
{
}

//==============================================================================
//
// 游戏主循环，此函数将被不停的调用，引擎每刷新一次屏幕，此函数即被调用一次
// 用以处理游戏的开始、进行中、结束等各种状态. 
// 函数参数fDeltaTime : 上次调用本函数到此次调用本函数的时间间隔，单位：秒
void CGameMain::GameMainLoop( float	fDeltaTime )
{
	switch( GetGameState() )
	{
		// 初始化游戏，清空上一局相关数据
	case 1:
		{
			GameInit();
			SetGameState(2); // 初始化之后，将游戏状态设置为进行中
		}
		break;

		// 游戏进行中，处理各种游戏逻辑
	case 2:
		{
			// TODO 修改此处游戏循环条件，完成正确游戏逻辑
			if( true )
			{
				GameRun( fDeltaTime );
			}
			else // 游戏结束。调用游戏结算函数，并把游戏状态修改为结束状态
			{				
				SetGameState(0);
				GameEnd();
			}
		}
		break;

		// 游戏结束/等待按空格键开始
	case 0:
	default:
		break;
	};
}

//==============================================================================
void CGameMain::GameInit()
{
      // 加载资源

	 stateMachine = new StateMachine;
    // 添加状态
    stateMachine->AddState("MainMenu", std::unique_ptr<MainMenuState>(new MainMenuState()));
    stateMachine->AddState("Game", std::unique_ptr<GameState>(new GameState()));
    stateMachine->AddState("Settings", std::unique_ptr<SettingsMenuState>(new SettingsMenuState()));
    stateMachine->AddState("PauseMenu", std::unique_ptr<PauseMenuState>(new PauseMenuState()));
    stateMachine->AddState("Exit", std::unique_ptr<ExitMenuState>(new ExitMenuState()));
    stateMachine->AddState("HighScore", std::unique_ptr<HighScoreState>(new HighScoreState()));
    stateMachine->SetCurrentState("MainMenu");

}	

//==============================================================================
void CGameMain::GameRun(float fDeltaTime)
{

  stateMachine->Update(fDeltaTime);

}

//=============================================================================
//
// 本局游戏结束
void CGameMain::GameEnd()
{
}
//==========================================================================
//
// 鼠标移动
// 参数 fMouseX, fMouseY：为鼠标当前坐标
void CGameMain::OnMouseMove( const float fMouseX, const float fMouseY )
{
	 
    
   

    // 日志记录
    LogManager::Log("鼠标移动: (" + std::to_string(fMouseX) + ", " + std::to_string(fMouseY) + ")");
	Mouse::Instance().x=fMouseX;
	Mouse::Instance().y = fMouseY;
	MouseInputEvent mouseEvent(Mouse::Instance().x, Mouse::Instance().y , Mouse::Instance().leftPressed,Mouse::Instance().middlePressed, Mouse::Instance().rightPressed); 
	// 分发事件
    EventManager::Instance().DispatchEvent(mouseEvent);
}
//==========================================================================
//
// 鼠标点击
// 参数 iMouseType：鼠标按键值，见 enum MouseTypes 定义
// 参数 fMouseX, fMouseY：为鼠标当前坐标
void CGameMain::OnMouseClick( const int iMouseType, const float fMouseX, const float fMouseY )
{

	if (iMouseType ==0){Mouse::Instance().leftPressed=true;
	}
	else if (iMouseType ==1){Mouse::Instance().middlePressed=true;
	}
	else if (iMouseType ==2){Mouse::Instance().rightPressed=true;
	}
    // 创建鼠标点击事件
    MouseInputEvent mouseEvent(Mouse::Instance().x, Mouse::Instance().y, Mouse::Instance().leftPressed, Mouse::Instance().middlePressed, Mouse::Instance().rightPressed);
    
    // 分发事件
    EventManager::Instance().DispatchEvent(mouseEvent);
	
    // 日志记录
    LogManager::Log("鼠标点击: 类型=" + std::to_string(iMouseType) + " 坐标=(" + std::to_string(fMouseX) + ", " + std::to_string(fMouseY) + ")");

}
//==========================================================================
//
// 鼠标弹起
// 参数 iMouseType：鼠标按键值，见 enum MouseTypes 定义
// 参数 fMouseX, fMouseY：为鼠标当前坐标
void CGameMain::OnMouseUp( const int iMouseType, const float fMouseX, const float fMouseY )
{
	if (iMouseType ==0){Mouse::Instance().leftPressed=false;
	}
	else if (iMouseType ==1){Mouse::Instance().middlePressed=false;
	}
	else if (iMouseType ==2){Mouse::Instance().rightPressed=false;
	}
	 MouseInputEvent mouseEvent(Mouse::Instance().x, Mouse::Instance().y, Mouse::Instance().leftPressed, Mouse::Instance().middlePressed, Mouse::Instance().rightPressed);
    
    // 分发事件
    EventManager::Instance().DispatchEvent(mouseEvent);
}
//==========================================================================
//
// 键盘按下
// 参数 iKey：被按下的键，值见 enum KeyCodes 宏定义
// 参数 iAltPress, iShiftPress，iCtrlPress：键盘上的功能键Alt，Ctrl，Shift当前是否也处于按下状态(0未按下，1按下)
void CGameMain::OnKeyDown( const int iKey, const bool bAltPress, const bool bShiftPress, const bool bCtrlPress )
{	
		// 创建事件并分发
    KeyboardInputEvent keyboardEvent(iKey,	KeyboardInputEvent::KeyState::KEY_ON);	//分发	按键按下事件 <Key, State>


	//触发事件
    EventManager::Instance().DispatchEvent(keyboardEvent); //			触发键盘事件的		<xxx监听器>
	
		
	//日志记录
    LogManager::Log("<"+std::to_string(iKey)+","+std::to_string(bShiftPress)+"> 键盘按下");//格式	<Key, ShiftState>
}
//==========================================================================
//
// 键盘弹起
// 参数 iKey：弹起的键，值见 enum KeyCodes 宏定义
void CGameMain::OnKeyUp( const int iKey )
{
			
	// 创建事件并分发
    KeyboardInputEvent keyboardEvent(iKey,	KeyboardInputEvent::KeyState::KEY_OFF);	//分发	按键按下事件 <Key, State>


	//触发事件
    EventManager::Instance().DispatchEvent(keyboardEvent); //			触发键盘事件的		<xxx监听器>

		
	//日志记录
    LogManager::Log("<"+std::to_string(iKey)+"> 键盘弹起");//格式	<Key, ShiftState>


}
//===========================================================================
//
// 精灵与精灵碰撞
// 参数 szSrcName：发起碰撞的精灵名字
// 参数 szTarName：被碰撞的精灵名字
void CGameMain::OnSpriteColSprite( const char *szSrcName, const char *szTarName )
{

	
	Object* spriteA =static_cast<GameState*>(stateMachine->currentState_)->objectManager->GetObjectBySpriteName(szSrcName);
    Object* spriteB = static_cast<GameState*>(stateMachine->currentState_)->objectManager->GetObjectBySpriteName(szTarName);
	if (spriteA||spriteB){
	spriteA->ifCollision(spriteB);
	spriteB->ifCollision(spriteA);
	}
}
//===========================================================================
//
// 精灵与世界边界碰撞
// 参数 szName：碰撞到边界的精灵名字
// 参数 iColSide：碰撞到的边界 0 左边，1 右边，2 上边，3 下边
void CGameMain::OnSpriteColWorldLimit( const char *szName, const int iColSide )
{
	
}








