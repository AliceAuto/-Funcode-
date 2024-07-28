# -*- coding: utf-8 -*-

import ctypes
from CommonAPI import *
from Sprite import *

#/ <summary>
#/ 类：AnimateSprite
#/ 动态精灵(带图片动画)，从Sprite精灵基类继承下来，比基类多了几个控制图片动画的函数
#/ </summary>
class AnimateSprite(Sprite):

    #/ <summary>
    #/ 构造函数 
    #/ </summary>
    def __init__(self, szName):
        Sprite.__init__(self, szName)
    
    
	#/ <summary>
	#/ SetAnimateSpriteFrame：设置动态精灵的动画帧数
    #/ 参数 iFrame：动画帧数
	#/ </summary>
    def SetAnimateSpriteFrame( self, iFrame ):
        CommonAPI.GetAPI().dSetAnimateSpriteFrame( super(AnimateSprite,self).GetNameAnsi(), iFrame )

	#/ <summary>
    #/ GetAnimateSpriteAnimationName：获取动态精灵当前动画名字
    #/ 返回值：动画名字
	#/ </summary>
    def GetAnimateSpriteAnimationName(self):
        return CommonAPI.GetAPI().dGetAnimateSpriteAnimationName(super(AnimateSprite,self).GetNameAnsi()).decode("ascii")

	#/ <summary>
    #/ GetAnimateSpriteAnimationTime：获取动画精灵当前动画时间长度
    #/ 返回值：长度，单位秒
	#/ </summary>
    def GetAnimateSpriteAnimationTime(self):
        return CommonAPI.GetAPI().dGetAnimateSpriteAnimationTime(super(AnimateSprite,self).GetNameAnsi())

	#/ <summary>
    #/ IsAnimateSpriteAnimationFinished：判断动态精灵当前动画是否播放完毕，只针对非循环动画而言
    #/ 返回值：true 完毕 false 未完毕
	#/ </summary>
    def IsAnimateSpriteAnimationFinished(self):
        return CommonAPI.GetAPI().dIsAnimateSpriteAnimationFinished(super(AnimateSprite,self).GetNameAnsi())
    
	#/ <summary>
    #/ AnimateSpritePlayAnimation：动画精灵播放动画
    #/ 参数 szAnim：动画名字
    #/ 参数 bRestore：播放完毕后是否恢复当前动画
    #/ 返回值：是否播放成功
	#/ </summary>
    def AnimateSpritePlayAnimation( self, szAnim, bRestore):
        return CommonAPI.GetAPI().dAnimateSpritePlayAnimation(super(AnimateSprite,self).GetNameAnsi(), szAnim.encode("ascii"), bRestore)

