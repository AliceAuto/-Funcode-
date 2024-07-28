# -*- coding: utf-8 -*-

from sys import path
path.append(r'./API')

import os
import sys
import ctypes
import struct
from System import *
from CommonDefines import *
from LessonX import *

###############################################################################
#/ <summary>
#/ 引擎捕捉鼠标移动消息后，将调用到本函数
#/ </summary>
def OnMouseMove( fMouseX, fMouseY):
    # 可以在此添加游戏需要的响应函数
    GameMain.GetInstance().OnMouseMove( fMouseX, fMouseY )
    
    
#/ <summary>
#/ 引擎捕捉鼠标点击消息后，将调用到本函数
#/ </summary>
def OnMouseClick( iMouseType, fMouseX, fMouseY):
    # 可以在此添加游戏需要的响应函数
    GameMain.GetInstance().OnMouseClick(iMouseType, fMouseX, fMouseY)
    


#/ <summary>
#/ 引擎捕捉鼠标弹起消息后，将调用到本函数
#/ </summary>
def OnMouseUp( iMouseType, fMouseX, fMouseY):
    # 可以在此添加游戏需要的响应函数
    GameMain.GetInstance().OnMouseUp( iMouseType, fMouseX, fMouseY)
    


#/ <summary>
#/ 引擎捕捉键盘按下消息后，将调用到本函数
#/ iAltPress iShiftPress iCtrlPress 分别为判断Shift，Alt，Ctrl当前是否也处于按下状态。比如可以判断Ctrl+E组合键
#/ </summary>
def OnKeyDown( iKey, iAltPress, iShiftPress, iCtrlPress):
    # 可以在此添加游戏需要的响应函数
    GameMain.GetInstance().OnKeyDown( iKey, iAltPress, iShiftPress, iCtrlPress)
    pass
    

#/ <summary>
#/ 引擎捕捉键盘弹起消息后，将调用到本函数
#/ </summary>
def OnKeyUp( iKey):
    # 可以在此添加游戏需要的响应函数
    GameMain.GetInstance().OnKeyUp( iKey)
    

#/ <summary>
#/ 引擎捕捉到精灵与精灵碰撞之后，调用此函数
#/ </summary>
def OnSpriteColSprite( szSrcName, szTarName):
    # 可以在此添加游戏需要的响应函数
    GameMain.GetInstance().OnSpriteColSprite( szSrcName, szTarName)
    

#/ <summary>
#/ 引擎捕捉到精灵与世界边界碰撞之后，调用此函数.
#/ iColSide : 0 左边，1 右边，2 上边，3 下边
#/ </summary>
def OnSpriteColWorldLimit( szName, iColSide):
    # 可以在此添加游戏需要的响应函数
    GameMain.GetInstance().OnSpriteColWorldLimit( szName, iColSide)
    


# 下面为注册鼠标键盘事件回调接口，请略过 
pOnMouseMoveFv = ctypes.CFUNCTYPE(None, ctypes.c_float, ctypes.c_float)
pOnMouseMoveHandle = pOnMouseMoveFv(OnMouseMove)
#
pOnMouseClickFv = ctypes.CFUNCTYPE(None, ctypes.c_int, ctypes.c_float, ctypes.c_float)
pOnMouseClickHandle = pOnMouseClickFv(OnMouseClick)
#
pOnMouseUpFv = ctypes.CFUNCTYPE(None, ctypes.c_int, ctypes.c_float, ctypes.c_float)
pOnMouseUpHandle = pOnMouseUpFv(OnMouseUp)
#
pOnKeyDownFv = ctypes.CFUNCTYPE(None, ctypes.c_int, ctypes.c_int, ctypes.c_int, ctypes.c_int)
pOnKeyDownHandle = pOnKeyDownFv(OnKeyDown)
#
pOnKeyUpFv = ctypes.CFUNCTYPE(None, ctypes.c_int)
pOnKeyUpHandle = pOnKeyUpFv(OnKeyUp)
#
pOnSpriteColSpriteFv = ctypes.CFUNCTYPE(None, ctypes.c_wchar_p, ctypes.c_wchar_p)
pOnSpriteColSpriteHandle = pOnSpriteColSpriteFv(OnSpriteColSprite)
#
pOnSpriteColWorldLimitFv = ctypes.CFUNCTYPE(None, ctypes.c_wchar_p, ctypes.c_int)
pOnSpriteColWorldLimitHandle = pOnSpriteColWorldLimitFv(OnSpriteColWorldLimit)
###############################################################################

#
# 主函数入口
#

# 初始化游戏引擎
System.InitGameEngine('')

# 设置鼠标键盘回调函数 
System.OnMouseMoveDelegate(pOnMouseMoveHandle)
System.OnMouseClickDelegate(pOnMouseClickHandle)
System.OnMouseUpDelegate(pOnMouseUpHandle)
System.OnKeyDownDelegate(pOnKeyDownHandle)
System.OnKeyUpDelegate(pOnKeyUpHandle)
System.OnSpriteColSpriteDelegate(pOnSpriteColSpriteHandle)
System.OnSpriteColWorldLimitDelegate(pOnSpriteColWorldLimitHandle)

# 在此使用API更改窗口标题
System.SetWindowTitle("Lesson");


# 引擎主循环，处理屏幕图像刷新等工作
while System.EngineMainLoop():
    # 获取两次调用之间的时间差，传递给游戏逻辑处理
    deltaTime = System.GetTimeDelta()

    # 无限while循环过程中，如果Python编辑器无响应，可以开启此行print代码
    #print 'test'

    # 执行游戏主循环
    GameMain.GetInstance().GameMainLoop(deltaTime);


# 关闭游戏引擎，结束 
System.ShutdownGameEngine()


