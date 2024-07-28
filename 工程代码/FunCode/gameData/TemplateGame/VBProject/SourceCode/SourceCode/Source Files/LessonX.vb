

'/ <summary>
'/ ��Ϸ�ܹ��ࡣ��������Ϸ��ѭ������Ϸ��ʼ���������ȹ���
'/ ����ĳ�������Ϊ��GameMainLoop����Ϊ��ѭ��������������ÿ֡ˢ����Ļͼ��֮�󣬶��ᱻ����һ�Ρ�
'/ </summary>
Public Class CGameMain

    Shared m_Instance As CGameMain = Nothing  ' ���ྲ̬ʵ�� 

    Dim m_iGameState As Integer = 1  ' ��Ϸ״̬��0 -- ��Ϸ�����ȴ���ʼ״̬��1 -- ��ʼ����Ϸ��2 -- ��Ϸ������


    '/ <summary>
    '/ ���캯��
    '/ </summary>
    Public Sub New()
    End Sub

    ' Get����
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


    ' Set����
    Sub SetGameState(ByVal iState As Integer)
        m_iGameState = iState
    End Sub



    '/ <summary>
    '/ ��Ϸ��ѭ�����˺���������ͣ�ĵ��ã�����ÿˢ��һ����Ļ���˺�����������һ��
    '/ ���Դ�����Ϸ�Ŀ�ʼ�������С������ȸ���״̬. 
    '/ ��������fDeltaTime : �ϴε��ñ��������˴ε��ñ�������ʱ��������λ����
    '/ </summary>
    Public Sub GameMainLoop(ByVal fDeltaTime As Single)

        Select Case GetGameState()
            ' ��ʼ����Ϸ�������һ���������
            Case 1
                GameInit()
                SetGameState(2) ' ��ʼ��֮�󣬽���Ϸ״̬����Ϊ������

                ' ��Ϸ�����У����������Ϸ�߼�
            Case 2
                ' TODO �޸Ĵ˴���Ϸѭ�������������ȷ��Ϸ�߼�
                If True Then
                    GameRun(fDeltaTime)
                Else ' ��Ϸ������������Ϸ���㺯����������Ϸ״̬�޸�Ϊ����״̬
                    SetGameState(0)
                    GameEnd()
                End If

                ' ��Ϸ����/�ȴ����ո����ʼ
            Case 0

        End Select
    End Sub

    '/ <summary>
    '/ ÿ�ֿ�ʼǰ���г�ʼ���������һ��������� 
    '/ </summary>
    Sub GameInit()

    End Sub

    '/ <summary>
    '/ ÿ����Ϸ������
    '/ </summary>
    Sub GameRun(ByVal fDeltaTime As Single)

    End Sub

    '/ <summary>
    '/ ������Ϸ����
    '/ </summary>
    Sub GameEnd()

    End Sub

End Class
