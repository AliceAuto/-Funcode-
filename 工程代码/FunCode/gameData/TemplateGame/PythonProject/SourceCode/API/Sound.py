# -*- coding: utf-8 -*-

import ctypes
from CommonAPI import *

#/ <summary>
#/ 类：Sound
#/ 播放声音的类，定义一个对象实例，调用播放函数即可实现声音的播放
#/ </summary>
class Sound(object):
    m_szName = None	# 声音名
    m_iSoundId = None	# 引擎播放声音的时候，返回的ID
    m_bLoop = None	# bLoop : 是否循环播放。如果为循环音效，则在Sound实例析构的时候，自动调用StopSound停止此声音的播放
    m_fVolume = None	# 音量大小，0-1。1为声音文件的原声大小

    #/ <summary>
    #/ 构造函数
    #/ 参数 szName：声音的路径及名称，具体值请在编辑器的资源 -> 添加声音那里查看本项目里的声音资源，完整按照那个路径值填写即可
    #/ 参数 bLoop：是否循环播放。如果是循环播放的声音，需要手动调用API停止播放
    #/ 参数 fVolume：音量大小，0-1。1为声音文件的原声大小
    #/ </summary>
    def __init__( self, szName,  bLoop,  fVolume ):
        self.m_bLoop	=	bLoop
        self.m_fVolume	=	fVolume
        self.m_iSoundId	=	0
        self.m_szName	=	szName

    #/ <summary>
    #/ GetName：获取声音名字
    #/ </summary>
    def GetName(self):
        return self.m_szName

    #/ <summary>
    #/ PlaySound：播放该声音
    #/ </summary>
    def PlaySound(self):
        if( self.m_bLoop and 0 != self.m_iSoundId ):
            StopSound()
            
        self.m_iSoundId = CommonAPI.GetAPI().dPlaySound(self.GetName().encode("ascii"), self.m_bLoop, self.m_fVolume)

    #/ <summary>
    #/ StopSound：停止该声音的播放
    #/ 非循环的播放完之后将自动停止，所以一般不需要调用此函数。只有循环的声音才需要调用。对于循环音效，在析构函数里也会自动调用此函数 
    #/ </summary>
    def StopSound(self):
        CommonAPI.GetAPI().dStopSound( self.m_iSoundId )
        self.m_iSoundId = 0

    #/ <summary>
    #/ StopAllSound：停止播放所有声音
    #/ 静态函数，可以以此种方式调用：Sound::StopAllSound，以停止游戏中所有正在播放的声音
    #/ </summary>
    @staticmethod
    def StopAllSound():
        CommonAPI.GetAPI().dStopAllSound()
