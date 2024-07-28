Imports System.Runtime.InteropServices
Imports System.Reflection

'=================================================================================
'
' Sprite精灵与世界边界碰撞响应定义( 碰撞之后API OnSpriteColWorldLimit 将被调用 )
Public Enum EWorldLimit
    WORLD_LIMIT_OFF
    ' 关闭与世界边界的碰撞
    WORLD_LIMIT_NULL
    ' 碰撞之后引擎不做任何处理，由各游戏自己处理响应
    WORLD_LIMIT_RIGID
    ' 刚性物理碰撞反应
    WORLD_LIMIT_BOUNCE
    ' 反弹模式
    WORLD_LIMIT_CLAMP
    ' 小幅反弹，逐渐停止模式(比如篮球落地)
    WORLD_LIMIT_STICKY
    ' 碰撞之后静止
    WORLD_LIMIT_KILL
    ' 碰撞之后精灵将被删除

    WORLD_LIMIT_INVALID
    '	无效值
End Enum

'================================================================================
'
'/ 精灵与精灵之间、精灵与地图中其它精灵之间的碰撞响应( 碰撞之后API OnSpriteColSprite 将被调用 )
Public Enum ECollisionResponse
    COL_RESPONSE_OFF
    '	关闭碰撞响应(不调用OnSpriteColSprite)
    COL_RESPONSE_RIGID
    '	刚性物理碰撞响应
    COL_RESPONSE_BOUNCE
    '	反弹模式
    COL_RESPONSE_CLAMP
    '	小幅反弹，逐渐停止模式(比如篮球落地)
    COL_RESPONSE_STICKY
    '	碰撞之后静止
    COL_RESPONSE_KILL
    '	碰撞之后精灵将被删除
    COL_RESPONSE_CUSTOM
    '	碰撞之后引擎不做任何处理，由各游戏自己处理响应

    COL_RESPONSE_INVALID
    '	无效值
End Enum

'================================================================================
'
' 鼠标按键值定义
Public Enum MouseTypes
    MOUSE_LEFT = 0
    ' 左键
    MOUSE_RIGHT = 1
    ' 右键
    MOUSE_MIDDLE = 2        ' 中键
End Enum

'================================================================================
'
' 键盘KEY值定义
Public Enum KeyCodes
    KEY_NULL = 0
    KEY_BACKSPACE = 1
    KEY_TAB = 2
    KEY_ENTER = 3
    KEY_CONTROL = 4
    KEY_ALT = 5
    KEY_SHIFT = 6
    KEY_PAUSE = 7
    KEY_CAPSLOCK = 8
    KEY_ESCAPE = 9
    KEY_SPACE = 10
    KEY_PAGE_DOWN = 11
    KEY_PAGE_UP = 12
    KEY_END = 13
    KEY_HOME = 14
    KEY_LEFT = 15
    KEY_UP = 16
    KEY_RIGHT = 17
    KEY_DOWN = 18
    KEY_PRINT = 19
    KEY_INSERT = 20
    KEY_DELETE = 21
    KEY_HELP = 22

    KEY_0 = 23
    KEY_1 = 24
    KEY_2 = 25
    KEY_3 = 26
    KEY_4 = 27
    KEY_5 = 28
    KEY_6 = 29
    KEY_7 = 30
    KEY_8 = 31
    KEY_9 = 32

    KEY_A = 33
    KEY_B = 34
    KEY_C = 35
    KEY_D = 36
    KEY_E = 37
    KEY_F = 38
    KEY_G = 39
    KEY_H = 40
    KEY_I = 41
    KEY_J = 42
    KEY_K = 43
    KEY_L = 44
    KEY_M = 45
    KEY_N = 46
    KEY_O = 47
    KEY_P = 48
    KEY_Q = 49
    KEY_R = 50
    KEY_S = 51
    KEY_T = 52
    KEY_U = 53
    KEY_V = 54
    KEY_W = 55
    KEY_X = 56
    KEY_Y = 57
    KEY_Z = 58

    KEY_TILDE = 59
    KEY_MINUS = 60
    KEY_EQUALS = 61
    KEY_LBRACKET = 62
    KEY_RBRACKET = 63
    KEY_BACKSLASH = 64
    KEY_SEMICOLON = 65
    KEY_APOSTROPHE = 66
    KEY_COMMA = 67
    KEY_PERIOD = 68
    KEY_SLASH = 69
    KEY_NUMPAD0 = 70
    KEY_NUMPAD1 = 71
    KEY_NUMPAD2 = 72
    KEY_NUMPAD3 = 73
    KEY_NUMPAD4 = 74
    KEY_NUMPAD5 = 75
    KEY_NUMPAD6 = 76
    KEY_NUMPAD7 = 77
    KEY_NUMPAD8 = 78
    KEY_NUMPAD9 = 79
    KEY_MULTIPLY = 80
    KEY_ADD = 81
    KEY_SEPARATOR = 82
    KEY_SUBTRACT = 83
    KEY_DECIMAL = 84
    KEY_DIVIDE = 85
    KEY_NUMPADENTER = 86

    KEY_F1 = 87
    KEY_F2 = 88
    KEY_F3 = 89
    KEY_F4 = 90
    KEY_F5 = 91
    KEY_F6 = 92
    KEY_F7 = 93
    KEY_F8 = 94
    KEY_F9 = 95
    KEY_F10 = 96
    KEY_F11 = 97
    KEY_F12 = 98
    KEY_F13 = 99
    KEY_F14 = 100
    KEY_F15 = 101
    KEY_F16 = 102
    KEY_F17 = 103
    KEY_F18 = 104
    KEY_F19 = 105
    KEY_F20 = 106
    KEY_F21 = 107
    KEY_F22 = 108
    KEY_F23 = 109
    KEY_F24 = 110

    KEY_NUMLOCK = 111
    KEY_SCROLLLOCK = 112
    KEY_LCONTROL = 113
    KEY_RCONTROL = 114
    KEY_LALT = 115
    KEY_RALT = 116
    KEY_LSHIFT = 117
    KEY_RSHIFT = 118
    KEY_WIN_LWINDOW = 119
    KEY_WIN_RWINDOW = 120
    KEY_WIN_APPS = 121
    KEY_OEM_102 = 128

    KEY_MAC_OPT = 144
    KEY_MAC_LOPT = 145
    KEY_MAC_ROPT = 146

    KEY_BUTTON0 = 256
    KEY_BUTTON1 = 257
    KEY_BUTTON2 = 258
    KEY_BUTTON3 = 259
    KEY_BUTTON4 = 260
    KEY_BUTTON5 = 261
    KEY_BUTTON6 = 262
    KEY_BUTTON7 = 263
    KEY_BUTTON8 = 264
    KEY_BUTTON9 = 265
    KEY_BUTTON10 = 266
    KEY_BUTTON11 = 267
    KEY_BUTTON12 = 268
    KEY_BUTTON13 = 269
    KEY_BUTTON14 = 270
    KEY_BUTTON15 = 271
    KEY_BUTTON16 = 272
    KEY_BUTTON17 = 273
    KEY_BUTTON18 = 274
    KEY_BUTTON19 = 275
    KEY_BUTTON20 = 276
    KEY_BUTTON21 = 277
    KEY_BUTTON22 = 278
    KEY_BUTTON23 = 279
    KEY_BUTTON24 = 280
    KEY_BUTTON25 = 281
    KEY_BUTTON26 = 282
    KEY_BUTTON27 = 283
    KEY_BUTTON28 = 284
    KEY_BUTTON29 = 285
    KEY_BUTTON30 = 286
    KEY_BUTTON31 = 287
    KEY_ANYKEY = 65534

End Enum


'/ <summary>
'/ 请不要直接使用此类，用封装好的CSprite，CSystem等类库进行API调用 
'/ </summary>
Public Class CommonAPI

    ' dCursorOff：关闭鼠标不显示。此API隐藏的是整个Windows的鼠标，除非调用开启鼠标的API dCursorOn，否则鼠标将一直不显示
    '
    <DllImport("CommonAPI.dll")> _
    Public Shared Sub dCursorOff()

    End Sub

    ' dCursorOn：开启鼠标显示。将API dCursorOff关闭的鼠标重新开启显示
    '
    <DllImport("CommonAPI.dll")> _
    Public Shared Sub dCursorOn()

    End Sub

    ' dIsCursorOn：当前鼠标是开启还是关闭。对应的是用API dCursorOff和dCursorOn开启或者关闭的操作
    ' 返回值：1为开启状态，0为关闭状态
    '
    <DllImport("CommonAPI.dll")> _
    Public Shared Function dIsCursorOn() As Integer

    End Function

    ' dShowCursor：隐藏/显示鼠标。此API只是隐藏本程序窗口内的鼠标，移动到窗口外的时候，鼠标还是会显示
    ' 参数 iShow：1 为显示，0 为隐藏
    '
    <DllImport("CommonAPI.dll")> _
    Public Shared Sub dShowCursor(ByVal iShow As Integer)

    End Sub

    ' dIsShowCursor：当前鼠标是显示还是隐藏。对应的是用API dShowCursor隐藏或者显示的操作
    ' 返回值：1为开启状态，0为关闭状态
    '
    <DllImport("CommonAPI.dll")> _
    Public Shared Function dIsShowCursor() As Integer

    End Function

    ' dSetWindowTitle：设置窗口名字/标题
    ' 参数 szTitle：非空字符串
    '
    <DllImport("CommonAPI.dll")> _
    Public Shared Sub dSetWindowTitle(ByVal szTitle As String)

    End Sub

    ' dResizeWindow：更改窗口大小
    ' 参数 iWidth：宽度，大于0小于等于1920
    ' 参数 iHeight：高度，大于0小于等于1080
    '
    <DllImport("CommonAPI.dll")> _
    Public Shared Sub dResizeWindow(ByVal iWidth As Integer, ByVal iHeight As Integer)

    End Sub

    ' dRandom：获取一个大于等于0的随机数
    ' 返回值：int，范围0 - 2147483648
    '
    <DllImport("CommonAPI.dll")> _
    Public Shared Function dRandom() As Integer

    End Function

    ' dRandomRange：获取一个位于参数1到参数2之间的随机数
    ' 返回值：int，范围iMin - iMax
    ' 参数 iMin：小于iMax的整数
    ' 参数 iMax：大于iMin的整数
    '
    <DllImport("CommonAPI.dll")> _
    Public Shared Function dRandomRange(ByVal iMin As Integer, ByVal iMax As Integer) As Integer

    End Function

    ' dCalLineRotation：计算两点连线的直线的旋转角度
    ' 返回值：角度，范围0 - 360
    ' 参数 fStartX：起始坐标X
    ' 参数 fStartY：起始坐标Y
    ' 参数 fEndX：终点坐标X
    ' 参数 fEndY：终点坐标Y
    '
    <DllImport("CommonAPI.dll")> _
    Public Shared Function dCalLineRotation(ByVal fStartX As Single, ByVal fStartY As Single, ByVal fEndX As Single, ByVal fEndY As Single) As Single

    End Function

    ' dRotationToVectorX：计算某个角度对应的直线向量的X方向
    ' 参数 fRotation：角度，范围0 - 360
    ' 返回值 ：该直线向量的X值
    '
    <DllImport("CommonAPI.dll")> _
    Public Shared Function dRotationToVectorX(ByVal fRotation As Single) As Single

    End Function

    ' dRotationToVectorY：计算某个角度对应的直线向量的Y方向
    ' 参数 fRotation：角度，范围0 - 360
    ' 返回值 ：该直线向量的Y值
    '
    <DllImport("CommonAPI.dll")> _
    Public Shared Function dRotationToVectorY(ByVal fRotation As Single) As Single

    End Function

    ' dDrawLine：在两点之间画一条线
    ' 参数 fStartX：起始坐标X
    ' 参数 fStartY：起始坐标Y
    ' 参数 fEndX：终点坐标X
    ' 参数 fEndY：终点坐标Y
    ' 参数 fLineWidth：线的粗细，大于等于1
    ' 参数 iLayer：该线所在的层，与编辑器里设置的精灵的层级是同一个概念。范围0 - 31。
    ' 参数 iRed, iGreen, iBlue : 红绿蓝三原色的颜色值，范围 0 - 255
    ' 参数 iAlpha：线的透明度，范围0-255. 0为全透明，255为不透明
    '
    <DllImport("CommonAPI.dll")> _
    Public Shared Sub dDrawLine(ByVal fStartX As Single, ByVal fStartY As Single, ByVal fEndX As Single, ByVal fEndY As Single, ByVal fLineWidth As Single, ByVal iLayer As Integer, ByVal iRed As Integer, ByVal iGreen As Integer, ByVal iBlue As Integer, ByVal iAlpha As Integer)

    End Sub

    ' dDrawTriangle：画一个三角形
    ' 参数 fX1,fX2,fX3：三角形上三个点的X坐标
    ' 参数 fY1,fY2,fY3：三角形上三个点的Y坐标
    ' 参数 fLineWidth：线的粗细，大于等于1
    ' 参数 iLayer：该三角形所在的层，与编辑器里设置的精灵的层级是同一个概念。范围0 - 31。
    ' 参数 iRed, iGreen, iBlue : 红绿蓝三原色的颜色值，范围 0 - 255
    ' 参数 iAlpha：三角形的透明度，范围0-255. 0为全透明，255为不透明
    '
    <DllImport("CommonAPI.dll")> _
    Public Shared Sub dDrawTriangle(ByVal fX1 As Single, ByVal fY1 As Single, ByVal fX2 As Single, ByVal fY2 As Single, ByVal fX3 As Single, ByVal fY3 As Single, ByVal fLineWidth As Single, ByVal iLayer As Integer, ByVal iRed As Integer, ByVal iGreen As Integer, ByVal iBlue As Integer, ByVal iAlpha As Integer)

    End Sub

    ' dDrawRect：画一个矩形
    ' 参数 fUpperX：左上角坐标X
    ' 参数 fUpperY：左上角坐标Y
    ' 参数 fLowerX：右下角坐标X
    ' 参数 fLowerY：右下角坐标Y
    ' 参数 fLineWidth：线的粗细，大于等于1
    ' 参数 iLayer：该矩形所在的层，与编辑器里设置的精灵的层级是同一个概念。范围0 - 31。
    ' 参数 iRed, iGreen, iBlue : 红绿蓝三原色的颜色值，范围 0 - 255
    ' 参数 iAlpha：矩形的透明度，范围0-255. 0为全透明，255为不透明
    '
    <DllImport("CommonAPI.dll")> _
    Public Shared Sub dDrawRect(ByVal fUpperX As Single, ByVal fUpperY As Single, ByVal fLowerX As Single, ByVal fLowerYv As Single, ByVal fLineWidth As Single, ByVal iLayer As Integer, ByVal iRed As Integer, ByVal iGreen As Integer, ByVal iBlue As Integer, ByVal iAlpha As Integer)

    End Sub

    ' dDrawCircle：画一个圆
    ' 参数 fCenterX：圆心坐标X
    ' 参数 fCenterY：圆心坐标Y
    ' 参数 fRadius：圆的半径
    ' 参数 iSegment：圆弧段数，范围4-72. 比如传入6，将得到一个6边形，段数越大越圆滑，但是画图效率越低
    ' 参数 fLineWidth：线的粗细，大于等于1
    ' 参数 iLayer：该圆所在的层，与编辑器里设置的精灵的层级是同一个概念。范围0 - 31。
    ' 参数 iRed, iGreen, iBlue : 红绿蓝三原色的颜色值，范围 0 - 255
    ' 参数 iAlpha：圆的透明度，范围0-255. 0为全透明，255为不透明
    '
    <DllImport("CommonAPI.dll")> _
    Public Shared Sub dDrawCircle(ByVal fCenterX As Single, ByVal fCenterY As Single, ByVal fRadius As Single, ByVal iSegment As Integer, ByVal fLineWidth As Single, ByVal iLayer As Integer, ByVal iRed As Integer, ByVal iGreen As Integer, ByVal iBlue As Integer, ByVal iAlpha As Integer)

    End Sub

    ' dGetScreenLeft：获取世界边界之左边X坐标
    ' 返回值：左边界X坐标
    '
    <DllImport("CommonAPI.dll")> _
    Public Shared Function dGetScreenLeft() As Single

    End Function

    ' dGetScreenTop：获取世界边界之上边Y坐标
    ' 返回值：上边界Y坐标
    '
    <DllImport("CommonAPI.dll")> _
    Public Shared Function dGetScreenTop() As Single

    End Function

    ' dGetScreenRight：获取世界边界之右边X坐标
    ' 返回值：右边界X坐标
    '
    <DllImport("CommonAPI.dll")> _
    Public Shared Function dGetScreenRight() As Single

    End Function

    ' dGetScreenBottom：获取世界边界之下边Y坐标
    ' 返回值：下边界Y坐标
    '
    <DllImport("CommonAPI.dll")> _
    Public Shared Function dGetScreenBottom() As Single

    End Function

    ' dCloneSprite：复制(创建)一个精灵。精灵的创建方式：先在地图中摆放一个精灵做为模板，设置好各项参数，然后在代码里使用此函数克隆一个实例
    ' 返回值：1表示克隆成功，0克隆失败。失败的原因可能是在地图中未找到对应名字的精灵
    ' 参数 szSrcName：地图中用做模板的精灵名字
    ' 参数 szMyName：新的精灵名字
    '
    '<DllImport("CommonAPI.dll")> _ 
    Public Shared Function dCloneSprite(ByVal szSrcName As String, ByVal szMyName As String) As Integer

    End Function

    ' dDeleteSprite：在地图中删除一个精灵
    ' 参数 szName：要删除的精灵名字
    '
    <DllImport("CommonAPI.dll")> _
    Public Shared Sub dDeleteSprite(ByVal szName As String)

    End Sub

    ' dSetSpriteVisible：设置精灵隐藏或者显示(可见不可见)
    ' 参数 szName：精灵名字
    ' 参数 iVisible：1 可见 0不可见

    <DllImport("CommonAPI.dll")> _
    Public Shared Sub dSetSpriteVisible(ByVal szName As String, ByVal iVisible As Integer)

    End Sub

    ' dIsSpriteVisible：获取该精灵当前是否可见
    ' 返回值 1可见 0不可见
    ' 参数 szName：精灵名字
    '
    <DllImport("CommonAPI.dll")> _
    Public Shared Function dIsSpriteVisible(ByVal szName As String) As Integer

    End Function

    ' dSetSpriteEnable：禁止或者启用该精灵。被禁止的精灵将不参与任何响应，包括不移动，没有碰撞等，仅仅是在地图中显示
    ' 参数 szName：精灵名字
    ' 参数 iEnable：1启用 0禁止
    '
    <DllImport("CommonAPI.dll")> _
    Public Shared Sub dSetSpriteEnable(ByVal szName As String, ByVal iEnable As Integer)

    End Sub

    ' dSetSpriteScale：设置精灵的缩放值
    ' 参数 szName：精灵名字
    ' 参数 fScale：缩放值。大于0的值
    '
    <DllImport("CommonAPI.dll")> _
    Public Shared Sub dSetSpriteScale(ByVal szName As String, ByVal fScale As Single)

    End Sub

    ' dIsPointInSprite：判断某个坐标点是否位于精灵内部
    ' 返回值 1 在 0 不在
    ' 参数 szName：精灵名字
    ' 参数 fPosX：X坐标点
    ' 参数 fPosY：Y坐标点
    '
    <DllImport("CommonAPI.dll")> _
    Public Shared Function dIsPointInSprite(ByVal szName As String, ByVal fPosX As Single, ByVal fPosY As Single) As Integer

    End Function

    ' dSetSpritePosition：设置精灵位置
    ' 参数 szName：精灵名字
    ' 参数 fPosX：X坐标
    ' 参数 fPosY：Y坐标
    '
    <DllImport("CommonAPI.dll")> _
    Public Shared Sub dSetSpritePosition(ByVal szName As String, ByVal fPosX As Single, ByVal fPosY As Single)

    End Sub

    ' dSetSpritePositionX：只设置精灵X坐标
    ' 参数 szName：精灵名字
    ' 参数 fPosX：X坐标
    '
    <DllImport("CommonAPI.dll")> _
    Public Shared Sub dSetSpritePositionX(ByVal szName As String, ByVal fPosX As Single)

    End Sub

    ' dSetSpritePositionY：只设置精灵Y坐标
    ' 参数 szName：精灵名字
    ' 参数 fPosY：Y坐标
    '
    <DllImport("CommonAPI.dll")> _
    Public Shared Sub dSetSpritePositionY(ByVal szName As String, ByVal fPosY As Single)

    End Sub

    ' dGetSpritePositionX：获取精灵X坐标
    ' 参数 szName：精灵名字
    ' 返回值：精灵的X坐标
    '
    <DllImport("CommonAPI.dll")> _
    Public Shared Function dGetSpritePositionX(ByVal szName As String) As Single

    End Function

    ' dGetSpritePositionY：获取精灵Y坐标
    ' 参数 szName：精灵名字
    ' 返回值：精灵的Y坐标
    '
    <DllImport("CommonAPI.dll")> _
    Public Shared Function dGetSpritePositionY(ByVal szName As String) As Single

    End Function

    ' dGetSpriteLinkPointPosX：获取精灵链接点X坐标。链接点是依附于精灵的一个坐标点，可以在编辑器里增加或者删除
    ' 参数 szName：精灵名字
    ' 参数 iId：链接点序号，第一个为1，后面依次递加
    '
    <DllImport("CommonAPI.dll")> _
    Public Shared Function dGetSpriteLinkPointPosX(ByVal szName As String, ByVal iId As Integer) As Single

    End Function

    ' dGetSpriteLinkPointPosY：获取精灵链接点Y坐标。链接点是依附于精灵的一个坐标点，可以在编辑器里增加或者删除
    ' 参数 szName：精灵名字
    ' 参数 iId：链接点序号，第一个为1，后面依次递加
    '
    <DllImport("CommonAPI.dll")> _
    Public Shared Function dGetSpriteLinkPointPosY(ByVal szName As String, ByVal iId As Integer) As Single

    End Function

    ' dSetSpriteRotation：设置精灵的旋转角度
    ' 参数 szName：精灵名字
    ' 参数 fRot：旋转角度，范围0 - 360
    '
    <DllImport("CommonAPI.dll")> _
    Public Shared Sub dSetSpriteRotation(ByVal szName As String, ByVal fRot As Single)

    End Sub

    ' dGetSpriteRotation：获取精灵的旋转角度
    ' 参数 szName：精灵名字
    ' 返回值：精灵的旋转角度
    '
    <DllImport("CommonAPI.dll")> _
    Public Shared Function dGetSpriteRotation(ByVal szName As String) As Single

    End Function

    ' dSetSpriteAutoRot：设置精灵按照指定速度自动旋转
    ' 参数 szName：精灵名字
    ' 参数 fRotSpeed：旋转速度
    '
    <DllImport("CommonAPI.dll")> _
    Public Shared Sub dSetSpriteAutoRot(ByVal szName As String, ByVal fRotSpeed As Single)

    End Sub

    ' dSetSpriteWidth：设置精灵外形宽度
    ' 参数 szName：精灵名字
    ' 参数 fWidth：宽度值，大于0
    '
    <DllImport("CommonAPI.dll")> _
    Public Shared Sub dSetSpriteWidth(ByVal szName As String, ByVal fWidth As Single)

    End Sub

    ' dGetSpriteWidth：获取精灵外形宽度
    ' 参数 szName：精灵名字
    ' 返回值：精灵宽度值
    '
    <DllImport("CommonAPI.dll")> _
    Public Shared Function dGetSpriteWidth(ByVal szName As String) As Single

    End Function

    ' dSetSpriteHeight：设置精灵外形高度
    ' 参数 szName：精灵名字
    ' 参数 fHeight：精灵高度值
    '
    <DllImport("CommonAPI.dll")> _
    Public Shared Sub dSetSpriteHeight(ByVal szName As String, ByVal fHeight As Single)

    End Sub

    ' dGetSpriteHeight：获取精灵外形高度
    ' 参数 szName：精灵名字
    ' 返回值：精灵高度值
    '
    <DllImport("CommonAPI.dll")> _
    Public Shared Function dGetSpriteHeight(ByVal szName As String) As Single

    End Function

    ' dSetSpriteFlipX：设置精灵图片X方向翻转显示
    ' 参数 szName：精灵名字
    ' 参数 iFlipX：1 翻转 0不翻转(恢复原来朝向)
    '
    <DllImport("CommonAPI.dll")> _
    Public Shared Sub dSetSpriteFlipX(ByVal szName As String, ByVal iFlipX As Integer)

    End Sub

    ' dGetSpriteFlipX：获取当前精灵图片X方向是否是翻转显示
    ' 参数 szName：精灵名字
    ' 返回值：1 翻转 0不翻转
    '
    <DllImport("CommonAPI.dll")> _
    Public Shared Function dGetSpriteFlipX(ByVal szName As String) As Integer

    End Function

    ' dSetSpriteFlipY：设置精灵图片Y方向翻转显示
    ' 参数 szName：精灵名字
    ' 参数 iFlipY：1 翻转 0不翻转(恢复原来朝向)
    '
    <DllImport("CommonAPI.dll")> _
    Public Shared Sub dSetSpriteFlipY(ByVal szName As String, ByVal iFlipY As Integer)

    End Sub

    ' dGetSpriteFlipY：获取当前精灵图片Y方向是否是翻转显示
    ' 参数 szName：精灵名字
    ' 返回值：1 翻转 0不翻转
    '
    <DllImport("CommonAPI.dll")> _
    Public Shared Function dGetSpriteFlipY(ByVal szName As String) As Integer

    End Function

    ' dSetSpriteFlip：同时设置精灵翻转X及Y方向
    ' 参数 szName：精灵名字
    ' 参数 iFlipX：1 翻转 0不翻转(恢复原来朝向)
    ' 参数 iFlipY：1 翻转 0不翻转(恢复原来朝向)
    '
    <DllImport("CommonAPI.dll")> _
    Public Shared Sub dSetSpriteFlip(ByVal szName As String, ByVal iFlipX As Integer, ByVal iFlipY As Integer)

    End Sub

    ' dSetSpriteLifeTime：设置精灵的生命时长，时间到了之后将自动被删除
    ' 参数 szName：精灵名字
    ' 参数 fLifeTime：生命时长，单位 秒
    '
    <DllImport("CommonAPI.dll")> _
    Public Shared Sub dSetSpriteLifeTime(ByVal szName As String, ByVal fLifeTime As Single)

    End Sub

    ' dGetSpriteLifeTime：获取精灵生命时长
    ' 参数 szName：精灵名字
    ' 返回值：生命时长，单位 秒
    '
    <DllImport("CommonAPI.dll")> _
    Public Shared Function dGetSpriteLifeTime(ByVal szName As String) As Single

    End Function

    ' dSpriteMoveTo：让精灵按照给定速度移动到给定坐标点
    ' 参数 szName：精灵名字
    ' 参数 fPosX：移动的目标X坐标值
    ' 参数 fPosY：移动的目标Y坐标值
    ' 参数 fSpeed：移动速度
    ' 参数 iAutoStop：移动到终点之后是否自动停止, 1 停止 0 不停止
    '
    <DllImport("CommonAPI.dll")> _
    Public Shared Sub dSpriteMoveTo(ByVal szName As String, ByVal fPosX As Single, ByVal fPosY As Single, ByVal fSpeed As Single, ByVal iAutoStop As Integer)

    End Sub

    ' dSpriteRotateTo：让精灵按照给定速度旋转到给定的角度
    ' 参数 szName：精灵名字
    ' 参数 fRotation：给定的目标旋转值
    ' 参数 fRotSpeed：旋转速度
    ' 参数 iAutoStop：旋转到终点之后是否自动停止, 1 停止 0 不停止
    '
    <DllImport("CommonAPI.dll")> _
    Public Shared Sub dSpriteRotateTo(ByVal szName As String, ByVal fRotation As Single, ByVal fRotSpeed As Single, ByVal iAutoStop As Integer)

    End Sub

    ' dSetSpriteWorldLimit：设置精灵的世界边界坐标限制及碰撞模式
    ' 参数 szName：精灵名字
    ' 参数 Limit：碰撞到世界边界之后的响应模式，如果为OFF，则是关闭世界边界碰撞。其它值见 EWorldLimit
    ' 参数 fLeft：边界的左边X坐标
    ' 参数 fTop：边界的上边Y坐标
    ' 参数 fRight：边界的右边X坐标
    ' 参数 fBottom：边界的下边Y坐标
    '
    <DllImport("CommonAPI.dll")> _
    Public Shared Sub dSetSpriteWorldLimit(ByVal szName As String, ByVal Limit As EWorldLimit, ByVal fLeft As Single, ByVal fTop As Single, ByVal fRight As Single, ByVal fBottom As Single)

    End Sub

    ' dSetSpriteWorldLimitMode：设置精灵的世界边界碰撞模式
    ' 参数 szName：精灵名字
    ' 参数 Limit：碰撞到世界边界之后的响应模式，如果为OFF，则是关闭世界边界碰撞。其它值见 EWorldLimit
    '
    <DllImport("CommonAPI.dll")> _
    Public Shared Sub dSetSpriteWorldLimitMode(ByVal szName As String, ByVal Limit As EWorldLimit)

    End Sub

    ' dSetSpriteWorldLimitMin：设置精灵的世界边界上边及左边坐标限制
    ' 参数 szName：精灵名字
    ' 参数 fLeft：边界的左边X坐标
    ' 参数 fTop：边界的上边Y坐标
    '
    <DllImport("CommonAPI.dll")> _
    Public Shared Sub dSetSpriteWorldLimitMin(ByVal szName As String, ByVal fLeft As Single, ByVal fTop As Single)

    End Sub

    ' dSetSpriteWorldLimitMax：设置精灵的世界边界下边及右边坐标限制
    ' 参数 szName：精灵名字
    ' 参数 fRight：边界的右边X坐标
    ' 参数 fBottom：边界的下边Y坐标
    '
    <DllImport("CommonAPI.dll")> _
    Public Shared Sub dSetSpriteWorldLimitMax(ByVal szName As String, ByVal fRight As Single, ByVal fBottom As Single)

    End Sub

    ' dGetSpriteWorldLimitLeft：获取精灵世界边界左边界限制
    ' 参数 szName：精灵名字
    '
    <DllImport("CommonAPI.dll")> _
    Public Shared Function dGetSpriteWorldLimitLeft(ByVal szName As String) As Single

    End Function

    ' dGetSpriteWorldLimitTop：获取精灵世界边界上边界限制
    ' 参数 szName：精灵名字
    '
    <DllImport("CommonAPI.dll")> _
    Public Shared Function dGetSpriteWorldLimitTop(ByVal szName As String) As Single

    End Function

    ' dGetSpriteWorldLimitRight：获取精灵世界边界右边界限制
    ' 参数 szName：精灵名字
    '
    <DllImport("CommonAPI.dll")> _
    Public Shared Function dGetSpriteWorldLimitRight(ByVal szName As String) As Single

    End Function

    ' dGetSpriteWorldLimitBottom：获取精灵世界边界下边界限制
    '
    <DllImport("CommonAPI.dll")> _
    Public Shared Function dGetSpriteWorldLimitBottom(ByVal szName As String) As Single

    End Function

    ' dSetSpriteCollisionSend：设置精灵是否可以发送(产生)碰撞
    ' 精灵的碰撞方式为：当A移动中碰上B时，如果A是可以产生碰撞的，B是可以接受碰撞的，则这2个物体会产生碰撞，精灵碰撞的API将被调用。否则无碰撞发生
    ' 参数 szName：精灵名字
    ' 参数 iSend：1 可以产生 0 不产生
    '
    <DllImport("CommonAPI.dll")> _
    Public Shared Sub dSetSpriteCollisionSend(ByVal szName As String, ByVal iSend As Integer)

    End Sub

    ' dSetSpriteCollisionReceive：设置精灵是否可以接受碰撞
    ' 精灵的碰撞方式为：当A移动中碰上B时，如果A是可以产生碰撞的，B是可以接受碰撞的，则这2个物体会产生碰撞，精灵碰撞的API将被调用。否则无碰撞发生
    ' 参数 szName：精灵名字
    ' 参数 iReceive：1 可以接受 0 不接受
    '
    <DllImport("CommonAPI.dll")> _
    Public Shared Sub dSetSpriteCollisionReceive(ByVal szName As String, ByVal iReceive As Integer)

    End Sub

    ' dSetSpriteCollisionPhysicsSend：设置精灵是否可以发送(产生)物理碰撞
    ' 参数 iSend：1 可以产生 0 不产生
    '
    <DllImport("CommonAPI.dll")> _
    Public Shared Sub dSetSpriteCollisionPhysicsSend(ByVal szName As String, ByVal iSend As Integer)

    End Sub

    ' dSetSpriteCollisionPhysicsReceive：设置精灵是否可以接受物理碰撞
    ' 参数 iReceive：1 可以接受 0 不接受
    '
    <DllImport("CommonAPI.dll")> _
    Public Shared Sub dSetSpriteCollisionPhysicsReceive(ByVal szName As String, ByVal iReceive As Integer)

    End Sub

    ' dSetSpriteCollisionActive：同时设置精灵是否可以产生及接受碰撞
    ' 精灵的碰撞方式为：当A移动中碰上B时，如果A是可以产生碰撞的，B是可以接受碰撞的，则这2个物体会产生碰撞，精灵碰撞的API将被调用。否则无碰撞发生
    ' 参数 szName：精灵名字
    ' 参数 iSend：1 可以产生 0 不产生
    ' 参数 iReceive：1 可以接受 0 不接受
    '
    <DllImport("CommonAPI.dll")> _
    Public Shared Sub dSetSpriteCollisionActive(ByVal szName As String, ByVal iSend As Integer, ByVal iReceive As Integer)

    End Sub

    ' dGetSpriteCollisionSend：获取精灵当前是否是可以产生碰撞
    ' 参数 szName：精灵名字
    ' 返回值：1 可以产生 0 不产生
    '
    <DllImport("CommonAPI.dll")> _
    Public Shared Function dGetSpriteCollisionSend(ByVal szName As String) As Integer

    End Function

    ' dGetSpriteCollisionReceive：获取精灵当前是否是可以接受碰撞
    ' 参数 szName：精灵名字
    ' 返回值：1 可以接受 0 不接受
    '
    <DllImport("CommonAPI.dll")> _
    Public Shared Function dGetSpriteCollisionReceive(ByVal szName As String) As Integer

    End Function

    ' dSetSpriteCollisionResponse：设置精灵与精灵的碰撞响应模式
    ' 参数 szName：精灵名字
    ' 参数 Response：响应模式，如果为OFF，则为关闭碰撞响应，碰撞API将不会被调用。其它值见 ECollisionResponse
    '
    <DllImport("CommonAPI.dll")> _
    Public Shared Sub dSetSpriteCollisionResponse(ByVal szName As String, ByVal Response As ECollisionResponse)

    End Sub

    ' dSetSpriteCollisionMaxIterations：设置精灵碰撞之后的最大反弹次数
    ' 参数 szName：精灵名字
    ' 参数 iTimes：反弹次数
    '
    <DllImport("CommonAPI.dll")> _
    Public Shared Sub dSetSpriteCollisionMaxIterations(ByVal szName As String, ByVal iTimes As Integer)

    End Sub

    ' dSetSpriteForwardMovementOnly：设置精灵是否只能朝前移动
    ' 参数 szName：精灵名字
    ' 参数 iForward：1 只能朝前移动 0 可以朝其他方向移动
    '
    <DllImport("CommonAPI.dll")> _
    Public Shared Sub dSetSpriteForwardMovementOnly(ByVal szName As String, ByVal iForward As Integer)

    End Sub

    ' dGetSpriteForwardMovementOnly：获取精灵当前是否只能朝前移动
    ' 参数 szName：精灵名字
    ' 返回值：1 只能朝前移动 0 可以朝其它方向移动
    '
    <DllImport("CommonAPI.dll")> _
    Public Shared Function dGetSpriteForwardMovementOnly(ByVal szName As String) As Integer

    End Function

    ' dSetSpriteForwardSpeed：设置精灵向前的速度
    ' 参数 szName：精灵名字
    ' 参数 fSpeed：速度
    '
    <DllImport("CommonAPI.dll")> _
    Public Shared Sub dSetSpriteForwardSpeed(ByVal szName As String, ByVal fSpeed As Single)

    End Sub

    ' dSetSpriteImpulseForce：设置精灵瞬间推力
    ' 参数 szName：精灵名字
    ' 参数 fForceX：X方向推力大小
    ' 参数 fForceY：Y方向推力大小
    ' 参数 iGravitic：是否计算重力 : 1 计算，0不计算
    '
    <DllImport("CommonAPI.dll")> _
    Public Shared Sub dSetSpriteImpulseForce(ByVal szName As String, ByVal fForceX As Single, ByVal fForceY As Single, ByVal iGravitic As Integer)

    End Sub

    ' dSetSpriteImpulseForcePolar：按角度朝向设置精灵瞬间推力
    ' 参数 szName：精灵名字
    ' 参数 fPolar：角度朝向
    ' 参数 fForce：推力大小
    ' 参数 iGravitic：是否计算重力 : 1 计算，0不计算
    '
    <DllImport("CommonAPI.dll")> _
    Public Shared Sub dSetSpriteImpulseForcePolar(ByVal szName As String, ByVal fPolar As Single, ByVal fForce As Single, ByVal iGravitic As Integer)

    End Sub

    ' dSetSpriteConstantForceX：设置精灵X方向常量推力
    ' 参数 szName：精灵名字
    ' 参数 fForceX：X方向推力大小
    '
    <DllImport("CommonAPI.dll")> _
    Public Shared Sub dSetSpriteConstantForceX(ByVal szName As String, ByVal fForceX As Single)

    End Sub

    ' dSetSpriteConstantForceY：设置精灵Y方向常量推力
    ' 参数 szName：精灵名字
    ' 参数 fForceY：Y方向推力大小
    '
    <DllImport("CommonAPI.dll")> _
    Public Shared Sub dSetSpriteConstantForceY(ByVal szName As String, ByVal fForceY As Single)

    End Sub

    ' dSetSpriteConstantForceGravitic：精灵在计算常量推力的时候，是否计算重力
    ' 参数 szName：精灵名字
    ' 参数 iGravitic：是否计算重力 : 1 计算 0不计算
    '
    <DllImport("CommonAPI.dll")> _
    Public Shared Sub dSetSpriteConstantForceGravitic(ByVal szName As String, ByVal iGravitic As Integer)

    End Sub

    ' dSetSpriteConstantForce：设置精灵常量推力
    ' 参数 szName：精灵名字
    ' 参数 fForceX：X方向推力大小
    ' 参数 fForceY：Y方向推力大小
    ' 参数 iGravitic：是否计算重力 : 1 计算 0不计算
    '
    <DllImport("CommonAPI.dll")> _
    Public Shared Sub dSetSpriteConstantForce(ByVal szName As String, ByVal fForceX As Single, ByVal fForceY As Single, ByVal iGravitic As Integer)

    End Sub

    ' dSetSpriteConstantForcePolar：按角度朝向设置精灵常量推力
    ' 参数 szName：精灵名字
    ' 参数 fPolar：角度朝向
    ' 参数 fForce：推力大小
    ' 参数 iGravitic：是否计算重力 : 1 计算 0不计算
    '
    <DllImport("CommonAPI.dll")> _
    Public Shared Sub dSetSpriteConstantForcePolar(ByVal szName As String, ByVal fPolar As Single, ByVal fForce As Single, ByVal iGravitic As Integer)

    End Sub

    ' dStopSpriteConstantForce：停止精灵常量推力
    ' 参数 szName：精灵名字
    '
    <DllImport("CommonAPI.dll")> _
    Public Shared Sub dStopSpriteConstantForce(ByVal szName As String)

    End Sub

    ' dSetSpriteForceScale：按倍数缩放精灵当前受的推力
    ' 参数 szName：精灵名字
    ' 参数 fScale：缩放值
    '
    <DllImport("CommonAPI.dll")> _
    Public Shared Sub dSetSpriteForceScale(ByVal szName As String, ByVal fScale As Single)

    End Sub

    ' dSetSpriteAtRest：暂停/继续精灵的各种受力计算
    ' 参数 szName：精灵名字
    ' 参数 iRest：1 暂停 0 继续
    '
    <DllImport("CommonAPI.dll")> _
    Public Shared Sub dSetSpriteAtRest(ByVal szName As String, ByVal iRest As Integer)

    End Sub

    ' dGetSpriteAtRest：获取精灵当前是否在暂停中
    ' 参数 szName：精灵名字
    ' 返回值：1 暂停中 0 正常
    '
    <DllImport("CommonAPI.dll")> _
    Public Shared Function dGetSpriteAtRest(ByVal szName As String) As Integer

    End Function

    ' dSetSpriteFriction：设置精灵摩擦力
    ' 参数 szName：精灵名字
    ' 参数 fFriction：摩擦力大小
    '
    <DllImport("CommonAPI.dll")> _
    Public Shared Sub dSetSpriteFriction(ByVal szName As String, ByVal fFriction As Single)

    End Sub

    ' dSetSpriteRestitution：设置精灵弹力
    ' 参数 szName：精灵名字
    ' 参数 fRestitution：弹力值大小
    '
    <DllImport("CommonAPI.dll")> _
    Public Shared Sub dSetSpriteRestitution(ByVal szName As String, ByVal fRestitution As Single)

    End Sub

    ' dSetSpriteMass：设置精灵质量
    ' 参数 szName：精灵名字
    ' 参数 fMass：质量大小
    '
    <DllImport("CommonAPI.dll")> _
    Public Shared Sub dSetSpriteMass(ByVal szName As String, ByVal fMass As Single)

    End Sub

    ' dGetSpriteMass：获取精灵质量
    ' 参数 szName：精灵名字
    ' 返回值 ：质量大小
    '
    <DllImport("CommonAPI.dll")> _
    Public Shared Function dGetSpriteMass(ByVal szName As String) As Single

    End Function

    ' dSetSpriteAutoMassInertia：开启或者关闭精灵惯性
    ' 参数 szName：精灵名字
    ' 参数 iStatus：1 开启 0 关闭
    '
    <DllImport("CommonAPI.dll")> _
    Public Shared Sub dSetSpriteAutoMassInertia(ByVal szName As String, ByVal iStatus As Integer)

    End Sub

    ' dSetSpriteInertialMoment：设置精灵惯性大小
    ' 参数 szName：精灵名字
    ' 参数 fInert：惯性大小
    '
    <DllImport("CommonAPI.dll")> _
    Public Shared Sub dSetSpriteInertialMoment(ByVal szName As String, ByVal fInert As Single)

    End Sub

    ' dSetSpriteDamping：设置精灵衰减值
    ' 参数 szName：精灵名字
    ' 参数 fDamp：衰减值大小
    '
    <DllImport("CommonAPI.dll")> _
    Public Shared Sub dSetSpriteDamping(ByVal szName As String, ByVal fDamp As Single)

    End Sub

    ' dSetSpriteImmovable：设置精灵是否不可移动
    ' 参数 szName：精灵名字
    ' 参数 iImmovable：1 不可以移动 0 可以移动
    '
    <DllImport("CommonAPI.dll")> _
    Public Shared Sub dSetSpriteImmovable(ByVal szName As String, ByVal iImmovable As Integer)

    End Sub

    ' dGetSpriteImmovable：获取精灵当前是否不可以移动
    ' 参数 szName：精灵名字
    ' 返回值：1 不可以移动 0 可以移动
    '
    <DllImport("CommonAPI.dll")> _
    Public Shared Function dGetSpriteImmovable(ByVal szName As String) As Integer

    End Function

    ' dSetSpriteLinearVelocity：设置精灵移动速度
    ' 参数 szName：精灵名字
    ' 参数 fVelX：X方向速度
    ' 参数 fVelY：Y方向速度
    '
    <DllImport("CommonAPI.dll")> _
    Public Shared Sub dSetSpriteLinearVelocity(ByVal szName As String, ByVal fVelX As Single, ByVal fVelY As Single)

    End Sub

    ' dSetSpriteLinearVelocityX：设置精灵X方向移动速度
    ' 参数 szName：精灵名字
    ' 参数 fVelX：X方向速度
    '
    <DllImport("CommonAPI.dll")> _
    Public Shared Sub dSetSpriteLinearVelocityX(ByVal szName As String, ByVal fVelX As Single)

    End Sub

    ' dSetSpriteLinearVelocityY：设置精灵Y方向移动速度
    ' 参数 szName：精灵名字
    ' 参数 fVelY：Y方向速度
    '
    <DllImport("CommonAPI.dll")> _
    Public Shared Sub dSetSpriteLinearVelocityY(ByVal szName As String, ByVal fVelY As Single)

    End Sub

    ' dSetSpriteLinearVelocityPolar：按角度朝向设置精灵移动速度
    ' 参数 szName：精灵名字
    ' 参数 fSpeed：移动速度
    ' 参数 fPolar：角度朝向
    '
    <DllImport("CommonAPI.dll")> _
    Public Shared Sub dSetSpriteLinearVelocityPolar(ByVal szName As String, ByVal fSpeed As Single, ByVal fPolar As Single)

    End Sub

    ' dSetSpriteAngularVelocity：设置精灵角度旋转速度
    ' 参数 szName：精灵名字
    ' 参数 fAngular：角度旋转速度
    '
    <DllImport("CommonAPI.dll")> _
    Public Shared Sub dSetSpriteAngularVelocity(ByVal szName As String, ByVal fAngular As Single)

    End Sub

    ' dSetSpriteMinLinearVelocity：设置精灵最小速度
    ' 参数 szName：精灵名字
    ' 参数 fMin：最小速度值
    '
    <DllImport("CommonAPI.dll")> _
    Public Shared Sub dSetSpriteMinLinearVelocity(ByVal szName As String, ByVal fMin As Single)

    End Sub

    ' dSetSpriteMaxLinearVelocity：设置精灵最大速度
    ' 参数 szName：精灵名字
    ' 参数 fMax：最大速度值
    '
    <DllImport("CommonAPI.dll")> _
    Public Shared Sub dSetSpriteMaxLinearVelocity(ByVal szName As String, ByVal fMax As Single)

    End Sub

    ' dSetSpriteMinAngularVelocity：设置精灵最小角速度
    ' 参数 szName：精灵名字
    ' 参数 fMin：最小角速度
    '
    <DllImport("CommonAPI.dll")> _
    Public Shared Sub dSetSpriteMinAngularVelocity(ByVal szName As String, ByVal fMin As Single)

    End Sub

    ' dSetSpriteMaxAngularVelocity：设置精灵最大角速度
    ' 参数 szName：精灵名字
    ' 参数 fMax：最大角速度
    '
    <DllImport("CommonAPI.dll")> _
    Public Shared Sub dSetSpriteMaxAngularVelocity(ByVal szName As String, ByVal fMax As Single)

    End Sub

    ' dGetSpriteLinearVelocityX：获取精灵X方向速度
    ' 参数 szName：精灵名字
    ' 返回值：X方向速度
    '
    <DllImport("CommonAPI.dll")> _
    Public Shared Function dGetSpriteLinearVelocityX(ByVal szName As String) As Single

    End Function

    ' dGetSpriteLinearVelocityY：获取精灵Y方向速度
    ' 参数 szName：精灵名字
    ' 返回值：Y方向速度
    '
    <DllImport("CommonAPI.dll")> _
    Public Shared Function dGetSpriteLinearVelocityY(ByVal szName As String) As Single

    End Function

    ' dSpriteMountToSprite：将一个精灵绑定到另一个精灵上，暂时的成为另一个精灵的一部分，跟随其运动等
    ' 参数 szSrcName：要绑定的精灵名字
    ' 参数 szDstName：承载绑定的母体精灵名字
    ' 参数 fOffSetX：绑定偏移X
    ' 参数 fOffsetY：绑定偏移Y
    ' 返回值：返回一个绑定ID
    '
    <DllImport("CommonAPI.dll")> _
    Public Shared Function dSpriteMountToSprite(ByVal szSrcName As String, ByVal szDstName As String, ByVal fOffSetX As Single, ByVal fOffsetY As Single) As Integer

    End Function

    ' dSpriteMountToSpriteLinkPoint：将一个精灵绑定到另一个精灵上，绑定位置为指定的链接点，暂时的成为另一个精灵的一部分，跟随其运动等
    ' 参数 szSrcName：要绑定的精灵名字
    ' 参数 szDstName：承载绑定的母体精灵名字
    ' 参数 iPointId：链接点序号
    ' 返回值：返回一个绑定ID
    '
    <DllImport("CommonAPI.dll")> _
    Public Shared Function dSpriteMountToSpriteLinkPoint(ByVal szSrcName As String, ByVal szDstName As String, ByVal iPointId As Integer) As Integer

    End Function

    ' dSetSpriteMountRotation：设置精灵的绑定朝向，即相对于母体的朝向
    ' 参数 szName：精灵名字
    ' 参数 fRot：角度朝向，0 - 360
    '
    <DllImport("CommonAPI.dll")> _
    Public Shared Sub dSetSpriteMountRotation(ByVal szName As String, ByVal fRot As Single)

    End Sub

    ' dGetSpriteMountRotation：获取精灵的绑定朝向，即相对于母体的朝向
    ' 参数 szName：精灵名字
    ' 返回值：角度朝向
    '
    <DllImport("CommonAPI.dll")> _
    Public Shared Function dGetSpriteMountRotation(ByVal szName As String) As Single

    End Function

    ' dSetSpriteAutoMountRotation：设置精灵绑定之后自动旋转
    ' 参数 szName：精灵名字
    ' 参数 fRot：旋转速度
    '
    <DllImport("CommonAPI.dll")> _
    Public Shared Sub dSetSpriteAutoMountRotation(ByVal szName As String, ByVal fRot As Single)

    End Sub

    ' dGetSpriteAutoMountRotation：获取精灵绑定之后的自动旋转值
    ' 参数 szName：精灵名字
    ' 返回值：旋转速度
    '
    <DllImport("CommonAPI.dll")> _
    Public Shared Function dGetSpriteAutoMountRotation(ByVal szName As String) As Single

    End Function

    ' dSetSpriteMountForce：绑定至另一个精灵时，附加的作用力
    ' 参数 szName：精灵名字
    ' 参数 fFroce：作用力
    '
    <DllImport("CommonAPI.dll")> _
    Public Shared Sub dSetSpriteMountForce(ByVal szName As String, ByVal fForce As Single)

    End Sub

    ' dSetSpriteMountTrackRotation：绑定的精灵是否跟随母体旋转
    ' 参数 szName：精灵名字
    ' 参数 iTrackRotation：1 跟随 0 不跟随
    '
    <DllImport("CommonAPI.dll")> _
    Public Shared Sub dSetSpriteMountTrackRotation(ByVal szName As String, ByVal iTrackRotation As Integer)

    End Sub

    ' dSetSpriteMountOwned：母体被删除的时候，绑定的精灵是否也跟着被删除
    ' 参数 szName：精灵名字
    ' 参数 iMountOwned：1 跟着 0 不跟着
    '
    <DllImport("CommonAPI.dll")> _
    Public Shared Sub dSetSpriteMountOwned(ByVal szName As String, ByVal iMountOwned As Integer)

    End Sub

    ' dSetSpriteMountInheritAttributes：绑定的时候，是否继承母体的属性
    ' 参数 szName：精灵名字
    ' 参数 iInherAttr：1 继承 0 不继承
    '
    <DllImport("CommonAPI.dll")> _
    Public Shared Sub dSetSpriteMountInheritAttributes(ByVal szName As String, ByVal iInherAttrv As Integer)

    End Sub

    ' dSpriteDismount：将已经绑定的精灵进行解绑
    ' 参数 szName：精灵名字
    '
    <DllImport("CommonAPI.dll")> _
    Public Shared Sub dSpriteDismount(ByVal szName As String)

    End Sub

    ' dGetSpriteIsMounted：判断精灵是否绑定在另一个精灵上
    ' 参数 szName：精灵名字
    ' 返回值：1 绑定 0 不绑定
    '
    <DllImport("CommonAPI.dll")> _
    Public Shared Function dGetSpriteIsMounted(ByVal szName As String) As Integer

    End Function

    ' dGetSpriteMountedParent：获取绑定的母体精灵的名字
    ' 参数 szName：精灵名字
    ' 返回值：母体精灵名字，如果未绑定，则返回空字符串
    '
    <DllImport("CommonAPI.dll")> _
    Public Shared Function dGetSpriteMountedParent(ByVal szName As String) As String

    End Function

    ' dSetSpriteColorRed：更改精灵显示颜色中的红色。默认精灵的红绿蓝三颜色的值均为255，修改其中一项将可以改变其颜色
    ' 参数 szName：精灵名字
    ' 参数 iCol：颜色范围 0 - 255
    '
    <DllImport("CommonAPI.dll")> _
    Public Shared Sub dSetSpriteColorRed(ByVal szName As String, ByVal iCol As Integer)

    End Sub

    ' dSetSpriteColorGreen：更改精灵显示颜色中的绿色。默认精灵的红绿蓝三颜色的值均为255，修改其中一项将可以改变其颜色
    ' 参数 szName：精灵名字
    ' 参数 iCol：颜色范围 0 - 255
    '
    <DllImport("CommonAPI.dll")> _
    Public Shared Sub dSetSpriteColorGreen(ByVal szName As String, ByVal iCol As Integer)

    End Sub

    ' dSetSpriteColorBlue：更改精灵显示颜色中的蓝色。默认精灵的红绿蓝三颜色的值均为255，修改其中一项将可以改变其颜色
    ' 参数 szName：精灵名字
    ' 参数 iCol：颜色范围 0 - 255
    '
    <DllImport("CommonAPI.dll")> _
    Public Shared Sub dSetSpriteColorBlue(ByVal szName As String, ByVal iCol As Integer)

    End Sub

    ' dSetSpriteColorAlpha：设置精灵透明度
    ' 参数 szName：精灵名字
    ' 参数 iCol：透明度，值0 - 255，从完全透明至完全不透明
    '
    <DllImport("CommonAPI.dll")> _
    Public Shared Sub dSetSpriteColorAlpha(ByVal szName As String, ByVal iCol As Integer)

    End Sub

    ' dGetSpriteColorRed：获取精灵显示颜色中的红色值
    ' 参数 szName：精灵名字
    ' 返回值：颜色值
    '
    <DllImport("CommonAPI.dll")> _
    Public Shared Function dGetSpriteColorRed(ByVal szName As String) As Integer

    End Function

    ' dGetSpriteColorGreen：获取精灵显示颜色中的绿色值
    ' 参数 szName：精灵名字
    ' 返回值：颜色值
    '
    <DllImport("CommonAPI.dll")> _
    Public Shared Function dGetSpriteColorGreen(ByVal szName As String) As Integer

    End Function

    ' dGetSpriteColorBlue：获取精灵显示颜色中的蓝色值
    ' 参数 szName：精灵名字
    ' 返回值：颜色值
    '
    <DllImport("CommonAPI.dll")> _
    Public Shared Function dGetSpriteColorBlue(ByVal szName As String) As Integer

    End Function

    ' dGetSpriteColorAlpha：获取精灵透明度
    ' 参数 szName：精灵名字
    ' 返回值：透明度
    '
    <DllImport("CommonAPI.dll")> _
    Public Shared Function dGetSpriteColorAlpha(ByVal szName As String) As Integer

    End Function

    ' dSetStaticSpriteImage：设置/更改静态精灵的显示图片
    ' 参数 szName：精灵名字
    ' 参数 szImageName：图片名字
    ' 参数 iFrame：该图片的显示帧数。为编辑器预览图里显示的1/N，范围为 0 到 N - 1
    '
    <DllImport("CommonAPI.dll")> _
    Public Shared Sub dSetStaticSpriteImage(ByVal szName As String, ByVal szImageName As String, ByVal iFrame As Integer)

    End Sub

    ' dSetStaticSpriteFrame：设置静态精灵当前图片的显示帧数
    ' 参数 szName：精灵名字
    ' 参数 iFrame：该图片的显示帧数。为编辑器预览图里显示的1/N，范围为 0 到 N - 1
    '
    <DllImport("CommonAPI.dll")> _
    Public Shared Sub dSetStaticSpriteFrame(ByVal szName As String, ByVal iFrame As Integer)

    End Sub

    ' dGetStaticSpriteImage：获取精灵当前显示的图片名字
    ' 参数 szName：精灵名字
    ' 返回值：图片名字
    '
    <DllImport("CommonAPI.dll")> _
    Public Shared Function dGetStaticSpriteImage(ByVal szName As String) As String

    End Function

    ' dGetStaticSpriteFrame：获取精灵当前显示的图片帧数
    ' 参数 szName：精灵名字
    ' 返回值：帧数
    '
    <DllImport("CommonAPI.dll")> _
    Public Shared Function dGetStaticSpriteFrame(ByVal szName As String) As Integer

    End Function

    ' dSetAnimateSpriteFrame：设置动态精灵的动画帧数
    ' 参数 szName：精灵名字
    ' 参数 iFrame：动画帧数
    '
    <DllImport("CommonAPI.dll")> _
    Public Shared Sub dSetAnimateSpriteFrame(ByVal szName As String, ByVal iFrame As Integer)

    End Sub

    ' dIsAnimateSpriteAnimationFinished：判断动态精灵当前动画是否播放完毕，只针对非循环动画而言
    ' 参数 szName：精灵名字
    ' 返回值：1 完毕 0 未完毕
    '
    <DllImport("CommonAPI.dll")> _
    Public Shared Function dIsAnimateSpriteAnimationFinished(ByVal szName As String) As Integer

    End Function

    ' dGetAnimateSpriteAnimationName：获取动态精灵当前动画名字
    ' 参数 szName：精灵名字
    ' 返回值：动画名字
    '
    <DllImport("CommonAPI.dll")> _
    Public Shared Function dGetAnimateSpriteAnimationName(ByVal szName As String) As String

    End Function

    ' dGetAnimateSpriteAnimationTime：获取动画精灵当前动画时间长度
    ' 参数 szName：精灵名字
    ' 返回值：长度，单位秒
    '
    <DllImport("CommonAPI.dll")> _
    Public Shared Function dGetAnimateSpriteAnimationTime(ByVal szName As String) As Single

    End Function

    ' dAnimateSpritePlayAnimation：动画精灵播放动画
    ' 参数 szName：精灵名字
    ' 参数 szAnim：动画名字
    ' 参数 iRestore：播放完毕后是否恢复当前动画. 1 恢复 0 不恢复
    ' 返回值：是否播放成功, 1 : 成功 0 ：不成功
    '
    <DllImport("CommonAPI.dll")> _
    Public Shared Function dAnimateSpritePlayAnimation(ByVal szName As String, ByVal szAnim As String, ByVal iRestore As Integer) As Integer

    End Function

    ' dSetTextValue：文字精灵显示某个数值
    ' 参数 szName：精灵名字
    ' 参数 iValue：要显示的数值
    '
    <DllImport("CommonAPI.dll")> _
    Public Shared Sub dSetTextValue(ByVal szName As String, ByVal iValue As Integer)

    End Sub

    ' dSetTextValueFloat：文字精灵显示某个浮点数值
    ' 参数 szName：精灵名字
    ' 参数 fValue：要显示的数值
    '
    <DllImport("CommonAPI.dll")> _
    Public Shared Sub dSetTextValueFloat(ByVal szName As String, ByVal fValue As Single)

    End Sub

    ' dSetTextstring：文字精灵显示某个字符串文字
    ' 参数 szName：精灵名字
    ' 参数 szStr：要显示的字符串
    '
    <DllImport("CommonAPI.dll")> _
    Public Shared Sub dSetTextstring(ByVal szName As String, ByVal szStr As String)

    End Sub

    ' dSetTextChar：文字精灵显示某个字符
    ' 参数 szChar：要显示的字符
    '
    <DllImport("CommonAPI.dll")> _
    Public Shared Sub dSetTextChar(ByVal szName As String, ByVal szChar As Char)

    End Sub

    ' dLoadMap：载入新场景。注意，载入新场景的时候，旧场景的所有精灵都将被引擎删除掉，所以所有在程序中创建、复制出来的精灵都必须在调用本API之前先删除掉
    ' 参数 szName：场景名字。即新建场景保存的时候取的名字，必须带小写的后缀 -- xxx.t2d。不用带路径
    '
    <DllImport("CommonAPI.dll")> _
    Public Shared Sub dLoadMap(ByVal szName As String)

    End Sub

    ' dPlaySound：播放声音
    ' 参数 szName：声音的路径及名称，具体值请在编辑器的资源 -> 添加声音那里查看本项目里的声音资源，完整按照那个路径值填写即可
    ' 参数 iLoop：是否循环播放 1 循环 0 不循环。循环播放的声音，需要手动停止，请使用返回的ID，调用API停止该声音的播放。非循环的播放完之后将自动停止
    ' 参数 fVolume：音量大小，0-1。1为声音文件的原声大小
    ' 返回值：声音ID，循环播放的声音需要该ID来停止播放
    '
    <DllImport("CommonAPI.dll")> _
    Public Shared Function dPlaySound(ByVal szName As String, ByVal iLoop As Integer, ByVal fVolume As Single) As Integer

    End Function

    ' dStopSound：停止声音的播放
    ' 参数 iSoundId：API dPlaySound 播放声音的时候返回的声音ID
    '
    <DllImport("CommonAPI.dll")> _
    Public Shared Sub dStopSound(ByVal iSoundId As Integer)

    End Sub

    ' dStopAllSound：停止播放所有声音
    '
    <DllImport("CommonAPI.dll")> _
    Public Shared Sub dStopAllSound()

    End Sub

    ' dPlayEffect：播放一个不循环的特效，播放完毕之后该特效自动删除
    ' 参数 szSrcName：预先摆放在地图中的特效模板名字
    ' 参数 fLifeTime：生命时长，时间到了之后将被自动删除
    ' 参数 fPosX：播放的X坐标
    ' 参数 fPosY：播放的Y坐标
    ' 参数 fRotation：播放的角度朝向
    '
    <DllImport("CommonAPI.dll")> _
    Public Shared Sub dPlayEffect(ByVal szSrcName As String, ByVal fLifeTime As Single, ByVal fPosX As Single, ByVal fPosY As Single, ByVal fRotation As Single)

    End Sub

    ' dPlayLoopEffect：播放一个循环特效，不需要该特效的时候，需要自己调用API进行删除
    ' 参数 szSrcName：预先摆放在地图中的特效模板名字
    ' 参数 szMyName：新特效名字，要删除该特效的时候用到
    ' 参数 fCycleTime：循环时长，时间到了之后将重头播放
    ' 参数 fPosX：播放的X坐标
    ' 参数 fPosY：播放的Y坐标
    ' 参数 fRotation：播放的角度朝向
    '
    <DllImport("CommonAPI.dll")> _
    Public Shared Sub dPlayLoopEffect(ByVal szSrcName As String, ByVal szMyName As String, ByVal fCycleTime As Single, ByVal fPosX As Single, ByVal fPosY As Single, ByVal fRotation As Single)

    End Sub

    ' dDeleteEffect：删除一个正在播放的特效，只有循环特效才需要手动删除
    ' 参数 szName：特效名字
    '
    <DllImport("CommonAPI.dll")> _
    Public Shared Sub dDeleteEffect(ByVal szName As String)

    End Sub

    '////////////////////////////////////////////////////////////////////////////////////////
    '
    ' 以下API为系统API，请勿自己调用
    '
    '////////////////////////////////////////////////////////////////////////////////////////

    ' dGetTimeDelta：获取两次调用本函数之间的时间差
    ' 返回值：float，单位 秒
    '
    <DllImport("CommonAPI.dll")> _
    Public Shared Function dGetTimeDelta() As Single

    End Function
    ' dEngineMainLoop：引擎主循环函数。请勿自己调用
    '
    <DllImport("CommonAPI.dll")> _
    Public Shared Function dEngineMainLoop() As Integer
    End Function
    ' dInitGameEngine：初始化引擎，请勿自己调用
    '
    <DllImport("CommonAPI.dll")> _
    Public Shared Function dInitGameEngine2(ByVal lpCmdLine As String) As Integer
    End Function
    ' dShutdownGameEngine：关闭引擎，请勿自己调用
    '
    <DllImport("CommonAPI.dll")> _
    Public Shared Sub dShutdownGameEngine()

    End Sub

    '<UnmanagedFunctionPointer(CallingConvention.StdCall)> _ 
    Public Delegate Sub Engine_OnMouseMove(ByVal fMouseX As Single, ByVal fMouseY As Single)
    <DllImport("CommonAPI.dll")> _
    Public Shared Sub OnMouseMoveDelegate(ByVal Func As Engine_OnMouseMove)
    End Sub

    '<UnmanagedFunctionPointer(CallingConvention.StdCall)> _
    Public Delegate Sub Engine_OnMouseClick(ByVal iMouseType As Integer, ByVal fMouseX As Single, ByVal fMouseY As Single)
    <DllImport("CommonAPI.dll")> _
    Public Shared Sub OnMouseClickDelegate(ByVal Func As Engine_OnMouseClick)
    End Sub

    '<UnmanagedFunctionPointer(CallingConvention.StdCall)> _
    Public Delegate Sub Engine_OnMouseUp(ByVal iMouseType As Integer, ByVal fMouseX As Single, ByVal fMouseY As Single)
    <DllImport("CommonAPI.dll")> _
    Public Shared Sub OnMouseUpDelegate(ByVal Func As Engine_OnMouseUp)
    End Sub

    '<UnmanagedFunctionPointer(CallingConvention.StdCall)> _
    Public Delegate Sub Engine_OnKeyDown(ByVal iKey As Integer, ByVal iAltPress As Integer, ByVal iShiftPress As Integer, ByVal iCtrlPress As Integer)
    <DllImport("CommonAPI.dll")> _
    Public Shared Sub OnKeyDownDelegate(ByVal Func As Engine_OnKeyDown)
    End Sub

    '<UnmanagedFunctionPointer(CallingConvention.StdCall)> _
    Public Delegate Sub Engine_OnKeyUp(ByVal iKey As Integer)
    <DllImport("CommonAPI.dll")> _
    Public Shared Sub OnKeyUpDelegate(ByVal Func As Engine_OnKeyUp)
    End Sub

    '<UnmanagedFunctionPointer(CallingConvention.StdCall)> _
    Public Delegate Sub Engine_OnSpriteColSprite(ByVal szSrcName As String, ByVal szTarName As String)
    <DllImport("CommonAPI.dll")> _
    Public Shared Sub OnSpriteColSpriteDelegate(ByVal Func As Engine_OnSpriteColSprite)
    End Sub

    '<UnmanagedFunctionPointer(CallingConvention.StdCall)> _
    Public Delegate Sub Engine_OnSpriteColWorldLimit(ByVal szName As String, ByVal iColSide As Integer)
    <DllImport("CommonAPI.dll")> _
    Public Shared Sub OnSpriteColWorldLimitDelegate(ByVal Func As Engine_OnSpriteColWorldLimit)
    End Sub


End Class

