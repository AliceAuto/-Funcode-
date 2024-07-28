'/ <summary>
'/ 类：CSTextSprite
'/ 文字精灵，亦属于精灵中的一种。基本用法：在地图里摆放一个“文字”物体，起个名字
'/ 然后在代码里定义一个文字精灵的对象实例，将此名字做为构造函数的参数，然后调用对应的成员函数更新文字显示即可
'/ </summary>
Public Class CTextSprite
    Inherits CSprite
    Public Sub New(ByVal szName As String)
        MyBase.New(szName)
    End Sub

    '/ <summary>
    '/ SetTextValue：文字精灵显示某个数值
    '/ 参数 iValue：要显示的数值
    '/ </summary>
    '/ <param name="iValue"></param>
    Public Sub SetTextValue(ByVal iValue As Integer)
        CommonAPI.dSetTextValue(GetName(), iValue)
    End Sub

    '/ <summary>
    '/ SetTextValueFloat：文字精灵显示某个浮点数值
    '/ 参数 fValue：要显示的数值
    '/ </summary>
    '/ <param name="fValue"></param>
    Public Sub SetTextValueFloat(ByVal fValue As Single)
        CommonAPI.dSetTextValueFloat(GetName(), fValue)
    End Sub

    '/ <summary>
    '/ SetTextstring：文字精灵显示某个字符串文字
    '/ 参数 szStr：要显示的字符串
    '/ </summary>
    '/ <param name="szStr"></param>
    Public Sub SetTextstring(ByVal szStr As String)
        CommonAPI.dSetTextstring(GetName(), szStr)
    End Sub
End Class
