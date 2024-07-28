# -*- coding: utf-8 -*-

import ctypes
from CommonAPI import *
from Sprite import *

#/ <summary>
#/ StatiSprite
#/ 静态精灵(静态图片显示)，从Sprite精灵基类继承下来，比基类多了几个控制精灵图片显示的函数
#/ </summary>
class StaticSprite(Sprite):
    #
    def __init__( self, szName ):
        Sprite.__init__(self, szName)

    #/ <summary>
    #/ SetStatiSpriteImage：设置/更改静态精灵的显示图片
    #/ 参数 szImageName：图片名字
    #/ 参数 iFrame：该图片的显示帧数。为编辑器预览图里显示的1/N，范围为 0 到 N - 1
    #/ </summary>
    #/ <param name="szImageName"></param>
    #/ <param name="iFrame"></param>
    def SetStatiSpriteImage( self, szImageName,  iFrame ):
        CommonAPI.GetAPI().dSetStatiSpriteImage( super(StaticSprite, self).GetNameAnsi(), szImageName.encode("ascii"), iFrame )

    #/ <summary>
    #/ SetStatiSpriteFrame：设置静态精灵当前图片的显示帧数
    #/ 参数 iFrame：该图片的显示帧数。为编辑器预览图里显示的1/N，范围为 0 到 N - 1
    #/ </summary>
    #/ <param name="iFrame"></param>
    def SetStatiSpriteFrame( self,  iFrame ):
        CommonAPI.GetAPI().dSetStatiSpriteFrame( super(StaticSprite, self).GetNameAnsi(), iFrame )

    #/ <summary>
    #/ GetStatiSpriteImage：获取精灵当前显示的图片名字
    #/ 返回值：图片名字
    #/ </summary>
    #/ <returns></returns>
    def GetStatiSpriteImage( self):
        return CommonAPI.GetAPI().dGetStatiSpriteImage( super(StaticSprite, self).GetNameAnsi() ).decode("ascii")

    #/ <summary>
    #/ GetStatiSpriteFrame：获取精灵当前显示的图片帧数
    #/ 返回值：帧数
    #/ </summary>
    #/ <returns></returns>
    def GetStatiSpriteFrame( self):
        return CommonAPI.GetAPI().dGetStatiSpriteFrame( super(StaticSprite, self).GetNameAnsi() )

