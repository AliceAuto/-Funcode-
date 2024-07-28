

'/ <summary>
'/ 游戏总管类。负责处理游戏主循环、游戏初始化、结束等工作
'/ 大体的程序流程为：GameMainLoop函数为主循环函数，在引擎每帧刷新屏幕图像之后，都会被调用一次。
'/ </summary>
Public Class CGameMain

    Shared m_Instance As CGameMain = Nothing  ' 本类静态实例 

    Dim m_iGameState As Integer = 1  ' 游戏状态，0 -- 游戏结束等待开始状态；1 -- 初始化游戏；2 -- 游戏进行中


    '/ <summary>
    '/ 构造函数
    '/ </summary>
    Public Sub New()
    End Sub

    ' Get方法
    Function GetGameState() As Integer
        Return m_iGameState
    End Function


    Public Shared ReadOnly Property GetInstance() As CGameMain
        Get
            If m_Instance Is Nothing Then
                m_Instance = New CGameMain
            End If
            Return m_Instance
        End Get
    End Property


    ' Set方法
    Sub SetGameState(ByVal iState As Integer)
        m_iGameState = iState
    End Sub



    '/ <summary>
    '/ 游戏主循环，此函数将被不停的调用，引擎每刷新一次屏幕，此函数即被调用一次
    '/ 用以处理游戏的开始、进行中、结束等各种状态. 
    '/ 函数参数fDeltaTime : 上次调用本函数到此次调用本函数的时间间隔，单位：秒
    '/ </summary>
    Public Sub GameMainLoop(ByVal fDeltaTime As Single)

        Select Case GetGameState()
            ' 初始化游戏，清空上一局相关数据
            Case 1
                GameInit()
                SetGameState(2) ' 初始化之后，将游戏状态设置为进行中

                ' 游戏进行中，处理各种游戏逻辑
            Case 2
                ' TODO 修改此处游戏循环条件，完成正确游戏逻辑
                If True Then
                    GameRun(fDeltaTime)
                Else ' 游戏结束。调用游戏结算函数，并把游戏状态修改为结束状态
                    SetGameState(0)
                    GameEnd()
                End If

                ' 游戏结束/等待按空格键开始
            Case 0

        End Select
    End Sub

    '/ <summary>
    '/ 每局开始前进行初始化，清空上一局相关数据 
    '/ </summary>
    Sub GameInit()

    End Sub

    '/ <summary>
    '/ 每局游戏进行中
    '/ </summary>
    Sub GameRun(ByVal fDeltaTime As Single)

    End Sub

    '/ <summary>
    '/ 本局游戏结束
    '/ </summary>
    Sub GameEnd()

    End Sub

End Class
