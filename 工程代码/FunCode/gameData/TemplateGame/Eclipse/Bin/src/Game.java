/**
 * @(#)Game.java
 *
 *
 * @author 
 * @version 1.00
 */
import FunCode.JSystem;

public class Game 
{
	// 程序入口
    public static void main(String[] args) 
    {    	
    	// 定义一个实例，用于响应引擎的接口回调
		EngineInterface g_EngineInterface = new EngineInterface();

		// 初始化游戏引擎
		if( !JSystem.InitGameEngine( g_EngineInterface, args ) )
			return;
			
		// 在此使用API更改窗口标题
		JSystem.SetWindowTitle("Lesson");	
			
		// 引擎主循环，处理屏幕图像刷新等工作
		while( JSystem.EngineMainLoop() )
		{
			// 获取两次调用之间的时间差，传递给游戏逻辑处理
			float	fTimeDelta	=	JSystem.GetTimeDelta();
	
			// 执行游戏主循环
			CGameMain.g_GameMain.GameMainLoop( fTimeDelta );
		};
		
		// 关闭游戏引擎
		JSystem.ShutdownGameEngine();
    }
    
}

