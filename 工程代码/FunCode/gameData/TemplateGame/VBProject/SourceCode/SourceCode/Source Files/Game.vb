
'/ <summary>
'/ 
'/ </summary>
Public Module Game
    '/ <summary>
    '/ 主函数入口 
    '/ </summary>
    Sub Main(ByVal args() As String)
        ' 初始化游戏引擎
        If Not CSystem.InitGameEngine("") Then
            Return
        End If


        ' 设置鼠标键盘回调函数 
        CommonAPI.OnMouseMoveDelegate(AddressOf OnMouseMove)
        CommonAPI.OnMouseClickDelegate(AddressOf OnMouseClick)
        CommonAPI.OnMouseUpDelegate(AddressOf OnMouseUp)
        CommonAPI.OnKeyDownDelegate(AddressOf OnKeyDown)
        CommonAPI.OnKeyUpDelegate(AddressOf OnKeyUp)
        CommonAPI.OnSpriteColSpriteDelegate(AddressOf OnSpriteColSprite)
        CommonAPI.OnSpriteColWorldLimitDelegate(AddressOf OnSpriteColWorldLimit)


        ' 在此使用API更改窗口标题
        CSystem.SetWindowTitle("Lesson")

        ' 引擎主循环，处理屏幕图像刷新等工作
        While CSystem.EngineMainLoop()
            ' 获取两次调用之间的时间差，传递给游戏逻辑处理
            Dim fTimeDelta As Single = CSystem.GetTimeDelta()

            ' 执行游戏主循环
            CGameMain.GetInstance().GameMainLoop(fTimeDelta)
        End While


        ' 关闭游戏引擎
        CSystem.ShutdownGameEngine()
    End Sub

    '/ <summary>
    '/ 引擎捕捉鼠标移动消息后，将调用到本函数
    '/ </summary>
    Sub OnMouseMove(ByVal fMouseX As Single, ByVal fMouseY As Single)
        ' 可以在此添加游戏需要的响应函数
    End Sub

    '/ <summary>
    '/ 引擎捕捉鼠标点击消息后，将调用到本函数
    '/ </summary>
    Sub OnMouseClick(ByVal iMouseType As Integer, ByVal fMouseX As Single, ByVal fMouseY As Single)
        ' 可以在此添加游戏需要的响应函数
    End Sub

    '/ <summary>
    '/ 引擎捕捉鼠标弹起消息后，将调用到本函数
    '/ </summary>
    Sub OnMouseUp(ByVal iMouseType As Integer, ByVal fMouseX As Single, ByVal fMouseY As Single)
        ' 可以在此添加游戏需要的响应函数
    End Sub

    '/ <summary>
    '/ 引擎捕捉键盘按下消息后，将调用到本函数
    '/ iAltPress iShiftPress iCtrlPress 分别为判断Shift，Alt，Ctrl当前是否也处于按下状态。比如可以判断Ctrl+E组合键
    '/ </summary>
    Sub OnKeyDown(ByVal iKey As Integer, ByVal iAltPress As Integer, ByVal iShiftPress As Integer, ByVal iCtrlPress As Integer)
        ' 可以在此添加游戏需要的响应函数
    End Sub

    '/ <summary>
    '/ 引擎捕捉键盘弹起消息后，将调用到本函数
    '/ </summary>
    Sub OnKeyUp(ByVal iKey As Integer)
        ' 可以在此添加游戏需要的响应函数
    End Sub

    '/ <summary>
    '/ 引擎捕捉到精灵与精灵碰撞之后，调用此函数
    '/ </summary>
    Sub OnSpriteColSprite(ByVal szSrcName As String, ByVal szTarName As String)
        ' 可以在此添加游戏需要的响应函数
    End Sub

    '/ <summary>
    '/ 引擎捕捉到精灵与世界边界碰撞之后，调用此函数.
    '/ iColSide : 0 左边，1 右边，2 上边，3 下边
    '/ </summary>
    Sub OnSpriteColWorldLimit(ByVal szName As String, ByVal iColSide As Integer)
        ' 可以在此添加游戏需要的响应函数
    End Sub
End Module
