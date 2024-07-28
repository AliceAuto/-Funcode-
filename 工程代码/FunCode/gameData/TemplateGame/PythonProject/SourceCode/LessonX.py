# -*- coding: utf-8 -*-

from sys import path
path.append(r'./API')

import os
import sys
import ctypes
import struct
import operator
from System import *
from CommonDefines import *
from Sprite import *
from AnimateSprite import *
from Effect import *
from Sound import *
from StaticSprite import *
from TextSprite import *


#==============================================================================
#
# 大体的程序流程为：GameMainLoop函数为主循环函数，在引擎每帧刷新屏幕图像之后，都会被调用一次。

class GameMain(object):
    __m_iGameState = None

    #==============================================================================
    #
    # 构造函数
    def __init__(self):
        self.__m_iGameState = 0


    # 获取本类的实例，供外部调用
    @staticmethod
    def GetInstance():
        return g_GameMain

    #
    def __SetGameState(self, iState):
        self.m_iGameState = iState

    #==============================================================================
    #
    # 游戏主循环，此函数将被不停的调用，引擎每刷新一次屏幕，此函数即被调用一次
    # 用以处理游戏的开始、进行中、结束等各种状态. 
    # 函数参数fDeltaTime : 上次调用本函数到此次调用本函数的时间间隔，单位：秒
    def GameMainLoop( self, fDeltaTime ):
        
        # 初始化游戏，清空上一局相关数据
        if( 1 == self.__m_iGameState ):
            self.__GameInit();
            self.__SetGameState(2); # 初始化之后，将游戏状态设置为进行中
            
        # 游戏进行中，处理各种游戏逻辑
        elif( 2 == self.__m_iGameState ):
            
            # TODO 修改此处游戏循环条件，完成正确游戏逻辑
            if( True ):
                self.__GameRun( fDeltaTime )
                    
            else: # 游戏结束。调用游戏结算函数，并把游戏状态修改为结束状态
                self.__SetGameState(0)
                self.__GameEnd()
    
        else: # 游戏结束、等待按空格键开始

            pass


    #=============================================================================
    #
    # 每局开始前进行初始化，清空上一局相关数据
    def __GameInit(self):

        pass

    #=============================================================================
    #
    # 每局游戏进行中
    def __GameRun(self, fDeltaTime ):

        pass

    #=============================================================================
    #
    # 本局游戏结束
    def __GameEnd(self):
        
        pass

    #/ <summary>
    #/ 引擎捕捉鼠标移动消息后，将调用到本函数
    #/ </summary>
    def OnMouseMove( self, fMouseX, fMouseY):
        # 可以在此添加游戏需要的响应函数

        pass
        
    #/ <summary>
    #/ 引擎捕捉鼠标点击消息后，将调用到本函数
    #/ </summary>
    def OnMouseClick( self, iMouseType, fMouseX, fMouseY):
        # 可以在此添加游戏需要的响应函数

        pass


    #/ <summary>
    #/ 引擎捕捉鼠标弹起消息后，将调用到本函数
    #/ </summary>
    def OnMouseUp( self, iMouseType, fMouseX, fMouseY):
        # 可以在此添加游戏需要的响应函数

        pass


    #/ <summary>
    #/ 引擎捕捉键盘按下消息后，将调用到本函数
    #/ iAltPress iShiftPress iCtrlPress 分别为判断Shift，Alt，Ctrl当前是否也处于按下状态。比如可以判断Ctrl+E组合键
    #/ </summary>
    def OnKeyDown( self, iKey, iAltPress, iShiftPress, iCtrlPress):
        # 可以在此添加游戏需要的响应函数

        pass
        

    #/ <summary>
    #/ 引擎捕捉键盘弹起消息后，将调用到本函数
    #/ </summary>
    def OnKeyUp( self, iKey):
        # 可以在此添加游戏需要的响应函数

        pass

    #/ <summary>
    #/ 引擎捕捉到精灵与精灵碰撞之后，调用此函数
    #/ </summary>
    def OnSpriteColSprite( self, szSrcName, szTarName):
        # 可以在此添加游戏需要的响应函数

        pass

    #/ <summary>
    #/ 引擎捕捉到精灵与世界边界碰撞之后，调用此函数.
    #/ iColSide : 0 左边，1 右边，2 上边，3 下边
    #/ </summary>
    def OnSpriteColWorldLimit( self, szName, iColSide):
        # 可以在此添加游戏需要的响应函数

        pass

g_GameMain = GameMain()
