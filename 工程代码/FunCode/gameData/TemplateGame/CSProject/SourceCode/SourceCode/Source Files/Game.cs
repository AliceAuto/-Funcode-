using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

/// <summary>
/// 
/// </summary>
public class Game
{
    /// <summary>
    /// 主函数入口 
    /// </summary>
    static void Main(string[] args)
    {
        // 初始化游戏引擎
        if ( !CSystem.InitGameEngine(""))
            return;

        // 设置鼠标键盘回调函数 
        CommonAPI.OnMouseMoveDelegate(OnMouseMove);
        CommonAPI.OnMouseClickDelegate(OnMouseClick);
        CommonAPI.OnMouseUpDelegate(OnMouseUp);
        CommonAPI.OnKeyDownDelegate(OnKeyDown);
        CommonAPI.OnKeyUpDelegate(OnKeyUp);
        CommonAPI.OnSpriteColSpriteDelegate(OnSpriteColSprite);
        CommonAPI.OnSpriteColWorldLimitDelegate(OnSpriteColWorldLimit);


        // 在此使用API更改窗口标题
        CSystem.SetWindowTitle("Lesson");

        // 引擎主循环，处理屏幕图像刷新等工作
        while (CSystem.EngineMainLoop())
        {
            // 获取两次调用之间的时间差，传递给游戏逻辑处理
            float fTimeDelta = CSystem.GetTimeDelta();

            // 执行游戏主循环
            CGameMain.GetInstance().GameMainLoop(fTimeDelta);
        };

        // 关闭游戏引擎
        CSystem.ShutdownGameEngine();
    }

    /// <summary>
    /// 引擎捕捉鼠标移动消息后，将调用到本函数
    /// </summary>
    static void OnMouseMove(float fMouseX, float fMouseY)
    {
        // 可以在此添加游戏需要的响应函数
    }

    /// <summary>
    /// 引擎捕捉鼠标点击消息后，将调用到本函数
    /// </summary>
    static void OnMouseClick(int iMouseType, float fMouseX, float fMouseY)
    {
        // 可以在此添加游戏需要的响应函数
    }

    /// <summary>
    /// 引擎捕捉鼠标弹起消息后，将调用到本函数
    /// </summary>
    static void OnMouseUp(int iMouseType, float fMouseX, float fMouseY)
    {
        // 可以在此添加游戏需要的响应函数
    }

    /// <summary>
    /// 引擎捕捉键盘按下消息后，将调用到本函数
    /// iAltPress iShiftPress iCtrlPress 分别为判断Shift，Alt，Ctrl当前是否也处于按下状态。比如可以判断Ctrl+E组合键
    /// </summary>
    static void OnKeyDown(int iKey, int iAltPress, int iShiftPress, int iCtrlPress)
    {
        // 可以在此添加游戏需要的响应函数
    }

    /// <summary>
    /// 引擎捕捉键盘弹起消息后，将调用到本函数
    /// </summary>
    static void OnKeyUp(int iKey)
    {
        // 可以在此添加游戏需要的响应函数
    }

    /// <summary>
    /// 引擎捕捉到精灵与精灵碰撞之后，调用此函数
    /// </summary>
    static void OnSpriteColSprite(string szSrcName, string szTarName)
    {
        // 可以在此添加游戏需要的响应函数
    }

    /// <summary>
    /// 引擎捕捉到精灵与世界边界碰撞之后，调用此函数.
    /// iColSide : 0 左边，1 右边，2 上边，3 下边
    /// </summary>
    static void OnSpriteColWorldLimit(string szName, int iColSide)
    {
        // 可以在此添加游戏需要的响应函数
    }
}
