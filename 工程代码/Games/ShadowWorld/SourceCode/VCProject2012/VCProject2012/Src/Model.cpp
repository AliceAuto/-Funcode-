
//======================================================================
//				此文件为	Window入口		为项目总入口			   //	
//======================================================================

	//========================================
	/*				注意					//
	//										//
	//	使用单元测试通道时要修改 "EC.h"		//
	//   配置文件中 宏定义为   #define	MIN	//
	//										//
	*/										//
	//=======================================

///////////////////
#include "EC.h" //	调试配置
#ifdef WIN    //
///////////////

// 主函数入口


#include <windows.h>
#include "Logger.h"
#include "CSprite.h"
#include "CSystem.h"
#include "CGameMain.h"
#include "EventDrivenSystem.h"
#include "CharacterController.h"
#include "MonsterController.h"
#include "PlayerController.h"
#include "StateMachine.h"
#include "States.h"
#include "json\json.h"
#include "Setting.h"





















// 声明事件处理函数
void onMouseInput(const Event& event);
void onKeyboardInput(const Event& event);

// 主函数入口
int PASCAL WinMain(HINSTANCE hInstance,
                   HINSTANCE hPrevInstance,
                   LPSTR     lpCmdLine,
                   int       nCmdShow)
{
    // 初始化游戏引擎
    if (!CSystem::InitGameEngine(hInstance, lpCmdLine))
        return 0;

    // 设置窗口标题
    CSystem::SetWindowTitle("影之界");

    // 加载资源
   
    

    // 启动日志记录
    LogManager::StartLogging("logfile.txt");
    LogManager::Log("下面是程序日志:");

    // 创建状态机并添加状态
    StateMachine sm;
    sm.AddState("MainMenu", MainMenuState::CreateState());
    sm.AddState("Game", GameState::CreateState());
    sm.AddState("Settings", SettingsMenuState::CreateState());
    sm.AddState("PauseMenu", PauseMenuState::CreateState());
    sm.AddState("Exit", ExitMenuState::CreateState());

    // 引擎主循环
    while (CSystem::EngineMainLoop())
    {
        // 获取时间差
        float fTimeDelta = CSystem::GetTimeDelta();

        // 更新游戏主循环
        g_GameMain.GameMainLoop(fTimeDelta);

        // 更新控制器
    }

    // 关闭游戏引擎
    CSystem::ShutdownGameEngine();

    // 停止日志记录
    LogManager::StopLogging();

    return 0;
}
#endif