'/ <summary>
'/ CStaticSprite
'/ 静态精灵(静态图片显示)，从CSprite精灵基类继承下来，比基类多了几个控制精灵图片显示的函数
'/ </summary>
Public Class CStaticSprite
    Inherits CSprite
    Public Sub New(ByVal szName As String)
        MyBase.New(szName)
    End Sub

    '/ <summary>
    '/ SetStaticSpriteImage：设置/更改静态精灵的显示图片
    '/ 参数 szImageName：图片名字
    '/ 参数 iFrame：该图片的显示帧数。为编辑器预览图里显示的1/N，范围为 0 到 N - 1
    '/ </summary>
    '/ <param name="szImageName"></param>
    '/ <param name="iFrame"></param>
    Public Sub SetStaticSpriteImage(ByVal szImageName As String, ByVal iFrame As Integer)
        CommonAPI.dSetStaticSpriteImage(GetName(), szImageName, iFrame)
    End Sub

    '/ <summary>
    '/ SetStaticSpriteFrame：设置静态精灵当前图片的显示帧数
    '/ 参数 iFrame：该图片的显示帧数。为编辑器预览图里显示的1/N，范围为 0 到 N - 1
    '/ </summary>
    '/ <param name="iFrame"></param>
    Public Sub SetStaticSpriteFrame(ByVal iFrame As Integer)
        CommonAPI.dSetStaticSpriteFrame(GetName(), iFrame)
    End Sub

    '/ <summary>
    '/ GetStaticSpriteImage：获取精灵当前显示的图片名字
    '/ 返回值：图片名字
    '/ </summary>
    '/ <returns></returns>
    Public Function GetStaticSpriteImage() As String
        Return CommonAPI.dGetStaticSpriteImage(GetName())
    End Function

    '/ <summary>
    '/ GetStaticSpriteFrame：获取精灵当前显示的图片帧数
    '/ 返回值：帧数
    '/ </summary>
    '/ <returns></returns>
    Public Function GetStaticSpriteFrame() As Integer
        Return CommonAPI.dGetStaticSpriteFrame(GetName())
    End Function
End Class

