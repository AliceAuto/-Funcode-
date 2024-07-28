'/ <summary>
'/ 类：CSSound
'/ 播放声音的类，定义一个对象实例，调用播放函数即可实现声音的播放
'/ </summary>
Public Class CSound
    Private m_szName As String  ' 声音名() As 
    Private m_iSoundId As Integer ' 引擎播放声音的时候，返回的ID() As 
    Private m_bLoop As Boolean '  : 是否循环播放。如果为循环音效，则在CSound实例析构的时候，自动调用StopSound停止此声音的播放() As m_bLoop
    Private m_fVolume As Single  ' 音量大小，0-1。1为声音文件的原声大小() As 


    '/ <summary>
    '/ 构造函数
    '/ 参数 szName：声音的路径及名称，具体值请在编辑器的资源 -> 添加声音那里查看本项目里的声音资源，完整按照那个路径值填写即可
    '/ 参数 bLoop：是否循环播放。如果是循环播放的声音，需要手动调用API停止播放
    '/ 参数 fVolume：音量大小，0-1。1为声音文件的原声大小
    '/ </summary>
    Public Sub New(ByVal szName As String, ByVal bLoop As Boolean, ByVal fVolume As Single)
        m_bLoop = bLoop
        m_fVolume = fVolume
        m_iSoundId = 0
        m_szName = szName
    End Sub

    '/ <summary>
    '/ GetName：获取声音名字
    '/ </summary>
    Public Function GetName() As String
        Return m_szName
    End Function

    '/ <summary>
    '/ PlaySound：播放该声音
    '/ </summary>
    Public Sub PlaySound()
        If m_bLoop And 0 <> m_iSoundId Then
            StopSound()
        End If

        m_iSoundId = CommonAPI.dPlaySound(GetName(), m_bLoop, m_fVolume)
    End Sub

    '/ <summary>
    '/ StopSound：停止该声音的播放
    '/ 非循环的播放完之后将自动停止，所以一般不需要调用此函数。只有循环的声音才需要调用。对于循环音效，在析构函数里也会自动调用此函数 
    '/ </summary>
    Public Sub StopSound()
        CommonAPI.dStopSound(m_iSoundId)

        m_iSoundId = 0
    End Sub

    '/ <summary>
    '/ StopAllSound：停止播放所有声音
    '/ 静态函数，可以以此种方式调用：CSound::StopAllSound，以停止游戏中所有正在播放的声音
    '/ </summary>
    Public Shared Sub StopAllSound()
        CommonAPI.dStopAllSound()
    End Sub
End Class
