'/ <summary>
'/ 类：CEffect
'/ 特效精灵，属于精灵中的一种。用法和文字精灵一样，先在地图里摆放一个特效做为模板，并命名
'/ 然后在代码里定义一个特效精灵的对象实例即可使用
'/ </summary>
Public Class CEffect
    Inherits CSprite
    Private m_szCloneName As String  ' 在地图中预先摆放好的用做克隆的特效名字() As 
    Private m_fTime As Single  ' 非循环特效：生命时长；循环特效：循环时长() As 

    '/ <summary>
    '/ 构造函数
    '/ 参数 szCloneName：地图里摆放好的特效名字
    '/ 参数 szMyName：新的特效名字。注意：如果是循环特效，那么必须一个循环特效就定义一个对象实例，用不同的名字
    '/                否则如果一个同名的循环特效被播放多次，在删除的时候会出问题。非循环特效则可以用一个实例多次播放
    '/ 参数 fTime：非循环特效：生命时长；循环特效：循环时长
    '/ </summary>
    Public Sub New(ByVal szCloneName As String, ByVal szMyName As String, ByVal fTime As Single)
        MyBase.New(szMyName)
        m_szCloneName = szCloneName
        m_fTime = fTime
    End Sub

    '/ <summary>
    '/ GetCloneName：获取用做克隆的特效名字
    '/ </summary>
    Public Function GetCloneName() As String
        Return m_szCloneName
    End Function

    '/ <summary>
    '/ GetTime：返回特效循环时长或者生命时长
    '/ </summary>
    Public Function GetTime() As Single
        Return m_fTime
    End Function

    '/ <summary>
    '/ PlayEffect：播放一个不循环的特效，播放完毕之后该特效自动删除
    '/ 播放非循环特效的时候，可以使用一个CEffect的对象实例，播放多个特效
    '/ 参数 fPosX：播放的X坐标
    '/ 参数 fPosY：播放的Y坐标
    '/ 参数 fRotation：播放的角度朝向
    '/ </summary>
    Public Sub PlayEffect(ByVal fPosX As Single, ByVal fPosY As Single, ByVal fRotation As Single)
        CommonAPI.dPlayEffect(GetCloneName(), GetTime(), fPosX, fPosY, fRotation)
    End Sub

    '/ <summary>
    '/ PlayLoopEffect：播放一个循环特效，不需要该特效的时候，需要自己调用API进行删除
    '/ 参数 fPosX：播放的X坐标
    '/ 参数 fPosY：播放的Y坐标
    '/ 参数 fRotation：播放的角度朝向
    '/ </summary>
    Public Sub PlayLoopEffect(ByVal fPosX As Single, ByVal fPosY As Single, ByVal fRotation As Single)
        CommonAPI.dPlayLoopEffect(GetCloneName(), GetName(), GetTime(), fPosX, fPosY, fRotation)
    End Sub

    '/ <summary>
    '/ DeleteEffect：删除一个正在播放的特效，只有循环特效才需要手动删除
    '/ </summary>
    Public Sub DeleteEffect()
        CommonAPI.dDeleteEffect(GetName())
    End Sub
End Class
