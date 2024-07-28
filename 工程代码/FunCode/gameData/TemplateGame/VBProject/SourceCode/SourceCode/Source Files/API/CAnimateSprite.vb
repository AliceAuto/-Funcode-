﻿'/ <summary>
'/ 类：CAnimateSprite
'/ 动态精灵(带图片动画)，从CSprite精灵基类继承下来，比基类多了几个控制图片动画的函数
'/ </summary>
Public Class CAnimateSprite
    Inherits CSprite
    '/ <summary>
    '/ 构造函数 
    '/ </summary>
    Public Sub New(ByVal szName As String)
        MyBase.New(szName)
    End Sub

    '/ <summary>
    '/ SetAnimateSpriteFrame：设置动态精灵的动画帧数
    '/ 参数 iFrame：动画帧数
    '/ </summary>
    Public Sub SetAnimateSpriteFrame(ByVal iFrame As Integer)
        CommonAPI.dSetAnimateSpriteFrame(GetName(), iFrame)
    End Sub

    '/ <summary>
    '/ GetAnimateSpriteAnimationName：获取动态精灵当前动画名字
    '/ 返回值：动画名字
    '/ </summary>
    Public Function GetAnimateSpriteAnimationName() As String
        Return CommonAPI.dGetAnimateSpriteAnimationName(GetName())
    End Function

    '/ <summary>
    '/ GetAnimateSpriteAnimationTime：获取动画精灵当前动画时间长度
    '/ 返回值：长度，单位秒
    '/ </summary>
    Public Function GetAnimateSpriteAnimationTime() As Single
        Return CommonAPI.dGetAnimateSpriteAnimationTime(GetName())
    End Function

    '/ <summary>
    '/ IsAnimateSpriteAnimationFinished：判断动态精灵当前动画是否播放完毕，只针对非循环动画而言
    '/ 返回值：true 完毕 false 未完毕
    '/ </summary>
    Public Function IsAnimateSpriteAnimationFinished() As Boolean
        Return CommonAPI.dIsAnimateSpriteAnimationFinished(GetName())
    End Function

    '/ <summary>
    '/ AnimateSpritePlayAnimation：动画精灵播放动画
    '/ 参数 szAnim：动画名字
    '/ 参数 bRestore：播放完毕后是否恢复当前动画
    '/ 返回值：是否播放成功
    '/ </summary>
    Public Function AnimateSpritePlayAnimation(ByVal szAnim As String, ByVal bRestore As Boolean) As Boolean
        Return (CommonAPI.dAnimateSpritePlayAnimation(GetName(), szAnim, bRestore))
    End Function
End Class
