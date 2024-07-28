# -*- coding: utf-8 -*-

import os
import sys
import struct
import ctypes


#############################################
#
# 系统API，请勿自己调用
#
#############################################
class CommonAPI(object):
    #
    API=None
    #
    @staticmethod
    def	InitLibrary():
        dllname='../Bin/API/CommonAPI2_64.dll'
        ver = struct.calcsize("P") * 8
        #print ver
        if ver == 32:
            dllname='../Bin/API/CommonAPI2.dll'

        CommonAPI.API=ctypes.windll.LoadLibrary(dllname)
        CommonAPI.API.dGetTimeDelta.restype = ctypes.c_float
        CommonAPI.API.dCalLineRotation.restype = ctypes.c_float
        CommonAPI.API.dCalLineRotation.argtypes = (ctypes.c_float, ctypes.c_float, ctypes.c_float, ctypes.c_float)
        CommonAPI.API.dRotationToVectorX2.restype = ctypes.c_float
        CommonAPI.API.dRotationToVectorX2.argtypes = (ctypes.c_float, ctypes.c_float)
        CommonAPI.API.dRotationToVectorY2.restype = ctypes.c_float
        CommonAPI.API.dRotationToVectorY2.argtypes = (ctypes.c_float, ctypes.c_float)
        CommonAPI.API.dDrawLine.argtypes = (ctypes.c_float, ctypes.c_float, ctypes.c_float, ctypes.c_float, ctypes.c_float, ctypes.c_int, ctypes.c_int, ctypes.c_int, ctypes.c_int, ctypes.c_int)
        CommonAPI.API.dDrawTriangle.argtypes = (ctypes.c_float, ctypes.c_float, ctypes.c_float, ctypes.c_float, ctypes.c_float, ctypes.c_float, ctypes.c_float, ctypes.c_int, ctypes.c_int, ctypes.c_int, ctypes.c_int, ctypes.c_int)
        CommonAPI.API.dDrawRect.argtypes = (ctypes.c_float, ctypes.c_float, ctypes.c_float, ctypes.c_float, ctypes.c_float, ctypes.c_int, ctypes.c_int, ctypes.c_int, ctypes.c_int, ctypes.c_int)
        CommonAPI.API.dDrawCircle.argtypes = (ctypes.c_float, ctypes.c_float, ctypes.c_float, ctypes.c_int, ctypes.c_float, ctypes.c_int, ctypes.c_int, ctypes.c_int, ctypes.c_int, ctypes.c_int)
        CommonAPI.API.dGetScreenLeft.restype = ctypes.c_float
        CommonAPI.API.dGetScreenTop.restype = ctypes.c_float
        CommonAPI.API.dGetScreenRight.restype = ctypes.c_float
        CommonAPI.API.dGetScreenBottom.restype = ctypes.c_float
        CommonAPI.API.dSetSpriteScale.argtypes = (ctypes.c_char_p, ctypes.c_float)
        CommonAPI.API.dIsPointInSprite.argtypes = (ctypes.c_char_p, ctypes.c_float, ctypes.c_float)
        CommonAPI.API.dSetSpritePosition.argtypes = (ctypes.c_char_p, ctypes.c_float, ctypes.c_float)
        CommonAPI.API.dSetSpritePositionX.argtypes = (ctypes.c_char_p, ctypes.c_float)
        CommonAPI.API.dSetSpritePositionY.argtypes = (ctypes.c_char_p, ctypes.c_float)
        CommonAPI.API.dGetSpritePositionX.restype = ctypes.c_float
        CommonAPI.API.dGetSpritePositionY.restype = ctypes.c_float
        CommonAPI.API.dGetSpriteLinkPointPosX.restype = ctypes.c_float
        CommonAPI.API.dGetSpriteLinkPointPosY.restype = ctypes.c_float
        CommonAPI.API.dSetSpriteRotation.argtypes = (ctypes.c_char_p, ctypes.c_float)
        CommonAPI.API.dGetSpriteRotation.restype = ctypes.c_float
        CommonAPI.API.dSetSpriteAutoRot.argtypes = (ctypes.c_char_p, ctypes.c_float)
        CommonAPI.API.dSetSpriteWidth.argtypes = (ctypes.c_char_p, ctypes.c_float)
        CommonAPI.API.dGetSpriteWidth.restype = ctypes.c_float
        CommonAPI.API.dSetSpriteHeight.argtypes = (ctypes.c_char_p, ctypes.c_float)
        CommonAPI.API.dGetSpriteHeight.restype = ctypes.c_float
        CommonAPI.API.dSetSpriteLifeTime.argtypes = (ctypes.c_char_p, ctypes.c_float)
        CommonAPI.API.dGetSpriteLifeTime.restype = ctypes.c_float
        CommonAPI.API.dSpriteMoveTo.argtypes = (ctypes.c_char_p, ctypes.c_float, ctypes.c_float, ctypes.c_float, ctypes.c_int)
        CommonAPI.API.dSpriteRotateTo.argtypes = (ctypes.c_char_p, ctypes.c_float, ctypes.c_float, ctypes.c_int)
        CommonAPI.API.dSetSpriteWorldLimit.argtypes = (ctypes.c_char_p, ctypes.c_int, ctypes.c_float, ctypes.c_float, ctypes.c_float, ctypes.c_float)
        CommonAPI.API.dSetSpriteWorldLimitMode.argtypes = (ctypes.c_char_p, ctypes.c_int)
        CommonAPI.API.dSetSpriteWorldLimitMin.argtypes = (ctypes.c_char_p, ctypes.c_float, ctypes.c_float)
        CommonAPI.API.dSetSpriteWorldLimitMax.argtypes = (ctypes.c_char_p, ctypes.c_float, ctypes.c_float)
        CommonAPI.API.dGetSpriteWorldLimitLeft.restype = ctypes.c_float
        CommonAPI.API.dGetSpriteWorldLimitTop.restype = ctypes.c_float
        CommonAPI.API.dGetSpriteWorldLimitRight.restype = ctypes.c_float
        CommonAPI.API.dGetSpriteWorldLimitBottom.restype = ctypes.c_float
        CommonAPI.API.dSetSpriteCollisionResponse.argtypes = (ctypes.c_char_p, ctypes.c_int)
        CommonAPI.API.dSetSpriteForwardSpeed.argtypes = (ctypes.c_char_p, ctypes.c_float)
        CommonAPI.API.dSetSpriteImpulseForce.argtypes = (ctypes.c_char_p, ctypes.c_float, ctypes.c_float, ctypes.c_int)
        CommonAPI.API.dSetSpriteImpulseForcePolar.argtypes = (ctypes.c_char_p, ctypes.c_float, ctypes.c_float, ctypes.c_int)
        CommonAPI.API.dSetSpriteConstantForceX.argtypes = (ctypes.c_char_p, ctypes.c_float)
        CommonAPI.API.dSetSpriteConstantForceY.argtypes = (ctypes.c_char_p, ctypes.c_float)
        CommonAPI.API.dSetSpriteConstantForce.argtypes = (ctypes.c_char_p, ctypes.c_float, ctypes.c_float, ctypes.c_int)
        CommonAPI.API.dSetSpriteConstantForcePolar.argtypes = (ctypes.c_char_p, ctypes.c_float, ctypes.c_float, ctypes.c_int)
        CommonAPI.API.dSetSpriteForceScale.argtypes = (ctypes.c_char_p, ctypes.c_float)
        CommonAPI.API.dSetSpriteFriction.argtypes = (ctypes.c_char_p, ctypes.c_float)
        CommonAPI.API.dSetSpriteRestitution.argtypes = (ctypes.c_char_p, ctypes.c_float)
        CommonAPI.API.dSetSpriteMass.argtypes = (ctypes.c_char_p, ctypes.c_float)
        CommonAPI.API.dGetSpriteMass.restype = ctypes.c_float
        CommonAPI.API.dSetSpriteInertialMoment.argtypes = (ctypes.c_char_p, ctypes.c_float)
        CommonAPI.API.dSetSpriteDamping.argtypes = (ctypes.c_char_p, ctypes.c_float)
        CommonAPI.API.dSetSpriteLinearVelocity.argtypes = (ctypes.c_char_p, ctypes.c_float, ctypes.c_float)
        CommonAPI.API.dSetSpriteLinearVelocityX.argtypes = (ctypes.c_char_p, ctypes.c_float)
        CommonAPI.API.dSetSpriteLinearVelocityY.argtypes = (ctypes.c_char_p, ctypes.c_float)
        CommonAPI.API.dSetSpriteLinearVelocityPolar.argtypes = (ctypes.c_char_p, ctypes.c_float, ctypes.c_float)
        CommonAPI.API.dSetSpriteAngularVelocity.argtypes = (ctypes.c_char_p, ctypes.c_float)
        CommonAPI.API.dSetSpriteMinLinearVelocity.argtypes = (ctypes.c_char_p, ctypes.c_float)
        CommonAPI.API.dSetSpriteMaxLinearVelocity.argtypes = (ctypes.c_char_p, ctypes.c_float)
        CommonAPI.API.dSetSpriteMinAngularVelocity.argtypes = (ctypes.c_char_p, ctypes.c_float)
        CommonAPI.API.dSetSpriteMaxAngularVelocity.argtypes = (ctypes.c_char_p, ctypes.c_float)
        CommonAPI.API.dGetSpriteLinearVelocityX.restype = ctypes.c_float
        CommonAPI.API.dGetSpriteLinearVelocityY.restype = ctypes.c_float
        CommonAPI.API.dSpriteMountToSprite.argtypes = (ctypes.c_char_p, ctypes.c_char_p, ctypes.c_float, ctypes.c_float)
        CommonAPI.API.dSetSpriteMountRotation.argtypes = (ctypes.c_char_p, ctypes.c_float)
        CommonAPI.API.dGetSpriteMountRotation.restype = ctypes.c_float
        CommonAPI.API.dSetSpriteAutoMountRotation.argtypes = (ctypes.c_char_p, ctypes.c_float)
        CommonAPI.API.dGetSpriteAutoMountRotation.restype = ctypes.c_float
        CommonAPI.API.dSetSpriteMountForce.argtypes = (ctypes.c_char_p, ctypes.c_float)
        CommonAPI.API.dGetAnimateSpriteAnimationTime.restype = ctypes.c_float
        CommonAPI.API.dSetTextValueFloat.argtypes = (ctypes.c_char_p, ctypes.c_float)
        CommonAPI.API.dPlaySound.argtypes = (ctypes.c_char_p, ctypes.c_int, ctypes.c_float)
        CommonAPI.API.dPlayEffect.argtypes = (ctypes.c_char_p, ctypes.c_float, ctypes.c_float, ctypes.c_float, ctypes.c_float)
        CommonAPI.API.dPlayLoopEffect.argtypes = (ctypes.c_char_p, ctypes.c_char_p, ctypes.c_float, ctypes.c_float, ctypes.c_float, ctypes.c_float)
        CommonAPI.API.dGetAnimateSpriteAnimationName.restype = ctypes.c_char_p
        CommonAPI.API.dGetStaticSpriteImage.restype = ctypes.c_char_p
        CommonAPI.API.dGetSpriteMountedParent.restype = ctypes.c_char_p
        
    #
    @staticmethod
    def GetAPI():
        return CommonAPI.API
