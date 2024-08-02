
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


#include "CSprite.h"
#include "CSystem.h"
#include "CGameMain.h"



///////////////////
#include "EC.h" //	调试配置
#ifdef WIN    //
///////////////

// 主函数入口



int PASCAL WinMain(HINSTANCE hInstance,
                   HINSTANCE hPrevInstance,
                   LPSTR     lpCmdLine,
                   int       nCmdShow)
{
	// 初始化游戏引擎
	if( !CSystem::InitGameEngine( hInstance, lpCmdLine ) )
		return 0;

	// To do : 在此使用API更改窗口标题
	CSystem::SetWindowTitle("LessonX");

	// 引擎主循环，处理屏幕图像刷新等工作
	while( CSystem::EngineMainLoop() )
	{
		// 获取两次调用之间的时间差，传递给游戏逻辑处理
		float	fTimeDelta	=	CSystem::GetTimeDelta();

		// 执行游戏主循环
		g_GameMain.GameMainLoop( fTimeDelta );
	};

	// 关闭游戏引擎
	CSystem::ShutdownGameEngine();
	return 0;
}

#endif