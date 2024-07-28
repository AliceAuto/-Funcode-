'/ <summary>
'/ 类：CSSystem
'/ 系统相关功能的类. 函数调用方法 CSSystem::函数名();
'/ </summary>
Public Class CSystem
    '/ <summary>
    '/ CursorOff：关闭鼠标不显示。此API隐藏的是整个Windows的鼠标，除非调用开启鼠标的API dCursorOn，否则鼠标将一直不显示
    '/ </summary>
    Public Shared Sub CursorOff()
        CommonAPI.dCursorOff()
    End Sub

    '/ <summary>
    '/ CursorOn：开启鼠标显示。将API dCursorOff关闭的鼠标重新开启显示
    '/ </summary>
    Public Shared Sub CursorOn()
        CommonAPI.dCursorOn()
    End Sub

    '/ <summary>
    '/ IsCursorOn：当前鼠标是开启还是关闭。对应的是用API dCursorOff和dCursorOn开启或者关闭的操作
    '/ 返回值：true为开启状态，false为关闭状态
    '/ </summary>
    '/ <returns></returns>
    Public Shared Function IsCursorOn() As Boolean
        Return CommonAPI.dIsCursorOn()
    End Function

    '/ <summary>
    '/ ShowCursor：隐藏/显示鼠标。此API只是隐藏本程序窗口内的鼠标，移动到窗口外的时候，鼠标还是会显示
    '/ 参数 bShow：true 为显示，false 为隐藏
    '/ </summary>
    '/ <param name="bShow"></param>
    Public Shared Sub ShowCursor(ByVal bShow As Boolean)
        CommonAPI.dShowCursor(bShow)
    End Sub

    '/ <summary>
    '/ IsShowCursor：当前鼠标是显示还是隐藏。对应的是用API ShowCursor隐藏或者显示的操作
    '/ 返回值：true为开启状态，false为关闭状态
    '/ </summary>
    '/ <returns></returns>
    Public Shared Function IsShowCursor() As Boolean
        Return CommonAPI.dIsShowCursor()
    End Function

    '/ <summary>
    '/ SetWindowTitle：设置窗口名字/标题
    '/ 参数 szTitle：非空字符串
    '/ </summary>
    '/ <param name="szTitle"></param>
    Public Shared Sub SetWindowTitle(ByVal szTitle As String)
        CommonAPI.dSetWindowTitle(szTitle)
    End Sub

    '/ <summary>
    '/ ResizeWindow：更改窗口大小
    '/ 参数 iWidth：宽度，大于0小于等于1920
    '/ 参数 iHeight：高度，大于0小于等于1080
    '/ </summary>
    '/ <param name="iWidth"></param>
    '/ <param name="iHeight"></param>
    Public Shared Sub ResizeWindow(ByVal iWidth As Integer, ByVal iHeight As Integer)
        CommonAPI.dResizeWindow(iWidth, iHeight)
    End Sub

    '/ <summary>
    '/ Random：获取一个大于等于0的随机数
    '/ 返回值：int，范围0 - 2147483648
    '/ </summary>
    '/ <returns></returns>
    Public Shared Function Random() As Integer
        Return CommonAPI.dRandom()
    End Function

    '/ <summary>
    '/ RandomRange：获取一个位于参数1到参数2之间的随机数
    '/ 返回值：int，范围iMin - iMax
    '/ 参数 iMin：小于iMax的整数
    '/ 参数 iMax：大于iMin的整数
    '/ </summary>
    '/ <param name="iMin"></param>
    '/ <param name="iMax"></param>
    '/ <returns></returns>
    Public Shared Function RandomRange(ByVal iMin As Integer, ByVal iMax As Integer) As Integer
        Return CommonAPI.dRandomRange(iMin, iMax)
    End Function

    '/ <summary>
    '/ CalLineRotation：计算两点连线的直线的旋转角度
    '/ 返回值：角度，范围0 - 360
    '/ 参数 fStartX：起始坐标X
    '/ 参数 fStartY：起始坐标Y
    '/ 参数 fEndX：终点坐标X
    '/ 参数 fEndY：终点坐标Y
    '/ </summary>
    '/ <param name="fStartX"></param>
    '/ <param name="fStartY"></param>
    '/ <param name="fEndX"></param>
    '/ <param name="fEndY"></param>
    '/ <returns></returns>
    Public Shared Function CalLineRotation(ByVal fStartX As Single, ByVal fStartY As Single, ByVal fEndX As Single, ByVal fEndY As Single) As Single
        Return CommonAPI.dCalLineRotation(fStartX, fStartY, fEndX, fEndY)
    End Function

    '/ <summary>
    '/ RotationToVectorX：计算某个角度对应的直线向量的X方向
    '/ 参数 fRotation：角度，范围0 - 360
    '/ 返回值 ：该直线向量的X值
    '/ </summary>
    '/ <param name="fRotation"></param>
    '/ <returns></returns>
    Public Shared Function RotationToVectorX(ByVal fRotation As Single) As Single
        Return CommonAPI.dRotationToVectorX(fRotation)
    End Function

    '/ <summary>
    '/ RotationToVectorY：计算某个角度对应的直线向量的Y方向
    '/ 参数 fRotation：角度，范围0 - 360
    '/ 返回值 ：该直线向量的Y值
    '/ </summary>
    '/ <param name="fRotation"></param>
    '/ <returns></returns>
    Public Shared Function RotationToVectorY(ByVal fRotation As Single) As Single
        Return CommonAPI.dRotationToVectorY(fRotation)
    End Function

    '/ <summary>
    '/ DrawLine：在两点之间画一条线
    '/ 参数 fStartX：起始坐标X
    '/ 参数 fStartY：起始坐标Y
    '/ 参数 fEndX：终点坐标X
    '/ 参数 fEndY：终点坐标Y
    '/ 参数 fLineWidth：线的粗细，大于等于1
    '/ 参数 iLayer：改线所在的层，与编辑器里设置的精灵的层级是同一个概念。范围0 - 31。
    '/ 参数 iRed, iGreen, iBlue : 红绿蓝三原色的颜色值，范围 0 - 255
    '/ 参数 iAlpha：线的透明度，范围0-255. 0为全透明，255为不透明
    '/ </summary>
    Public Shared Sub DrawLine(ByVal fStartX As Single, ByVal fStartY As Single, ByVal fEndX As Single, ByVal fEndY As Single, ByVal fLineWidth As Single, ByVal iLayer As Integer, ByVal iRed As Integer, ByVal iGreen As Integer, ByVal iBlue As Integer, ByVal iAlpha As Integer)
        CommonAPI.dDrawLine(fStartX, fStartY, fEndX, fEndY, fLineWidth, iLayer, iRed, iGreen, iBlue, iAlpha)
    End Sub

    '/ DrawTriangle：画一个三角形
    '/ 参数 fX1,fX2,fX3：三角形上三个点的X坐标
    '/ 参数 fY1,fY2,fY3：三角形上三个点的Y坐标
    '/ 参数 fLineWidth：线的粗细，大于等于1
    '/ 参数 iLayer：该三角形所在的层，与编辑器里设置的精灵的层级是同一个概念。范围0 - 31。
    '/ 参数 iRed, iGreen, iBlue : 红绿蓝三原色的颜色值，范围 0 - 255
    '/ 参数 iAlpha：三角形的透明度，范围0-255. 0为全透明，255为不透明<summary>
    '/ 
    '/ </summary>
    Public Shared Sub DrawTriangle(ByVal fX1 As Single, ByVal fY1 As Single, ByVal fX2 As Single, ByVal fY2 As Single, ByVal fX3 As Single, ByVal fY3 As Single, ByVal fLineWidth As Single, ByVal iLayer As Integer, ByVal iRed As Integer, ByVal iGreen As Integer, ByVal iBlue As Integer, ByVal iAlpha As Integer)
        CommonAPI.dDrawTriangle(fX1, fY1, fX2, fY2, fX3, fY3, fLineWidth, iLayer, iRed, iGreen, iBlue, iAlpha)
    End Sub

    '/ <summary>
    '/ DrawRect：画一个矩形
    '/ 参数 fUpperX：左上角坐标X
    '/ 参数 fUpperY：左上角坐标Y
    '/ 参数 fLowerX：右下角坐标X
    '/ 参数 fLowerY：右下角坐标Y
    '/ 参数 fLineWidth：线的粗细，大于等于1
    '/ 参数 iLayer：该矩形所在的层，与编辑器里设置的精灵的层级是同一个概念。范围0 - 31。
    '/ 参数 iRed, iGreen, iBlue : 红绿蓝三原色的颜色值，范围 0 - 255
    '/ 参数 iAlpha：矩形的透明度，范围0-255. 0为全透明，255为不透明
    '/ </summary>
    Public Shared Sub DrawRect(ByVal fUpperX As Single, ByVal fUpperY As Single, ByVal fLowerX As Single, ByVal fLowerY As Single, ByVal fLineWidth As Single, ByVal iLayer As Integer, ByVal iRed As Integer, ByVal iGreen As Integer, ByVal iBlue As Integer, ByVal iAlpha As Integer)
        CommonAPI.dDrawRect(fUpperX, fUpperY, fLowerX, fLowerY, fLineWidth, iLayer, iRed, iGreen, iBlue, iAlpha)
    End Sub

    '/ <summary>
    '/ DrawCircle：画一个圆
    '/ 参数 fCenterX：圆心坐标X
    '/ 参数 fCenterY：圆心坐标Y
    '/ 参数 fRadius：圆的半径
    '/ 参数 iSegment：圆弧段数，范围4-72. 比如传入6，将得到一个6边形，段数越大越圆滑，但是画图效率越低
    '/ 参数 fLineWidth：线的粗细，大于等于1
    '/ 参数 iLayer：该圆所在的层，与编辑器里设置的精灵的层级是同一个概念。范围0 - 31。
    '/ 参数 iRed, iGreen, iBlue : 红绿蓝三原色的颜色值，范围 0 - 255
    '/ 参数 iAlpha：圆的透明度，范围0-255. 0为全透明，255为不透明
    '/ </summary>
    Public Shared Sub DrawCircle(ByVal fCenterX As Single, ByVal fCenterY As Single, ByVal fRadius As Single, ByVal iSegment As Integer, ByVal fLineWidth As Single, ByVal iLayer As Integer, ByVal iRed As Integer, ByVal iGreen As Integer, ByVal iBlue As Integer, ByVal iAlpha As Integer)
        CommonAPI.dDrawCircle(fCenterX, fCenterY, fRadius, iSegment, fLineWidth, iLayer, iRed, iGreen, iBlue, iAlpha)
    End Sub

    '/ <summary>
    '/ GetScreenLeft：获取世界边界之左边X坐标
    '/ 返回值：左边界X坐标
    '/ </summary>
    '/ <returns></returns>
    Public Shared Function GetScreenLeft() As Single
        Return CommonAPI.dGetScreenLeft()
    End Function

    '/ <summary>
    '/ GetScreenTop：获取世界边界之上边Y坐标
    '/ 返回值：上边界Y坐标
    '/ </summary>
    '/ <returns></returns>
    Public Shared Function GetScreenTop() As Single
        Return CommonAPI.dGetScreenTop()
    End Function

    '/ <summary>
    '/ GetScreenRight：获取世界边界之右边X坐标
    '/ 返回值：右边界X坐标
    '/ </summary>
    '/ <returns></returns>
    Public Shared Function GetScreenRight() As Single
        Return CommonAPI.dGetScreenRight()
    End Function

    '/ <summary>
    '/ GetScreenBottom：获取世界边界之下边Y坐标
    '/ 返回值：下边界Y坐标
    '/ </summary>
    '/ <returns></returns>
    Public Shared Function GetScreenBottom() As Single
        Return CommonAPI.dGetScreenBottom()
    End Function

    '/ <summary>
    '/ LoadMap：载入新场景。注意，载入新场景的时候，旧场景的所有精灵都将被引擎删除掉，所以所有在程序中创建、复制出来的精灵都必须在调用本API之前先删除掉
    '/ 参数 szName：场景名字。即新建场景保存的时候取的名字，必须带小写的后缀 -- xxx.t2d。不用带路径
    '/ </summary>
    '/ <param name="szName"></param>
    Public Shared Sub LoadMap(ByVal szName As String)
        CommonAPI.dLoadMap(szName)
    End Sub

    '////////////////////////////////////////////////////////////////////////////////////////
    '
    ' 以下API为系统API，请勿自己调用
    '
    '////////////////////////////////////////////////////////////////////////////////////////

    ' GetTimeDelta：获取两次调用本函数之间的时间差
    ' 返回值：float，单位 秒
    '
    Public Shared Function GetTimeDelta() As Single
        Return CommonAPI.dGetTimeDelta()
    End Function
    ' EngineMainLoop：引擎主循环函数。请勿自己调用
    '
    Public Shared Function EngineMainLoop() As Boolean
        Return CommonAPI.dEngineMainLoop()
    End Function
    ' InitGameEngine：初始化引擎，请勿自己调用
    '
    Public Shared Function InitGameEngine(ByVal szArgs As String) As Boolean
        Return CommonAPI.dInitGameEngine2(szArgs)
    End Function
    ' ShutdownGameEngine：关闭引擎，请勿自己调用
    '
    Public Shared Sub ShutdownGameEngine()
        CommonAPI.dShutdownGameEngine()
    End Sub
End Class

