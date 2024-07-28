# -*- coding: utf-8 -*-

import ctypes
from CommonAPI import *
from Sprite import *

#/ <summary>
#/ 类：Effect
#/ 特效精灵，属于精灵中的一种。用法和文字精灵一样，先在地图里摆放一个特效做为模板，并命名
#/ 然后在代码里定义一个特效精灵的对象实例即可使用
#/ </summary>
class Effect(Sprite):
    m_szCloneName = None		# 在地图中预先摆放好的用做克隆的特效名字
    m_fTime	= None		# 非循环特效：生命时长；循环特效：循环时长

    #/ <summary>
    #/ 构造函数
    #/ 参数 szCloneName：地图里摆放好的特效名字
    #/ 参数 szMyName：新的特效名字。注意：如果是循环特效，那么必须一个循环特效就定义一个对象实例，用不同的名字
    #/                否则如果一个同名的循环特效被播放多次，在删除的时候会出问题。非循环特效则可以用一个实例多次播放
    #/ 参数 fTime：非循环特效：生命时长；循环特效：循环时长
    #/ </summary>
    def __init__(self, szCloneName, szMyName, fTime):
        Sprite.__init__(self,szMyName)
        self.m_szCloneName = szCloneName
        self.m_fTime = fTime

    #/ <summary>
    #/ GetCloneName：获取用做克隆的特效名字
    #/ </summary>
    def GetCloneName(self):
        return self.m_szCloneName

    #/ <summary>
    #/ GetTime：返回特效循环时长或者生命时长
    #/ </summary>
    def GetTime(self):
        return self.m_fTime

    #/ <summary>
    #/ PlayEffect：播放一个不循环的特效，播放完毕之后该特效自动删除
    #/ 播放非循环特效的时候，可以使用一个Effect的对象实例，播放多个特效
    #/ 参数 fPosX：播放的X坐标
    #/ 参数 fPosY：播放的Y坐标
    #/ 参数 fRotation：播放的角度朝向
    #/ </summary>
    def PlayEffect(self,  fPosX,  fPosY,  fRotation):
        CommonAPI.GetAPI().dPlayEffect(self.GetCloneName().encode("ascii"), self.GetTime(), fPosX, fPosY, fRotation)

    #/ <summary>
    #/ PlayLoopEffect：播放一个循环特效，不需要该特效的时候，需要自己调用API进行删除
    #/ 参数 fPosX：播放的X坐标
    #/ 参数 fPosY：播放的Y坐标
    #/ 参数 fRotation：播放的角度朝向
    #/ </summary>
    def PlayLoopEffect(self,  fPosX,  fPosY,  fRotation):
        CommonAPI.GetAPI().dPlayLoopEffect(self.GetCloneName().encode("ascii"), super(Effect, self).GetNameAnsi(), self.GetTime(), fPosX, fPosY, fRotation)

    #/ <summary>
    #/ DeleteEffect：删除一个正在播放的特效，只有循环特效才需要手动删除
    #/ </summary>
    def DeleteEffect(self):
        CommonAPI.GetAPI().dDeleteEffect(super(Effect, self).GetNameAnsi())
