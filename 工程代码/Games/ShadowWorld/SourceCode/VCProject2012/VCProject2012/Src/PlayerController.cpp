#include "PlayerController.h"
#include "Logger.h"

//====================================================================================
/*
    ��Ҷ���ʵ��
*/
//====================================================================================

// ���캯��
PlayerController::PlayerController(float initialX, float initialY,ResourceBag* resourceBagPtr)
    : CharacterController(initialX, initialY, resourceBagPtr) {
    // ��ʼ����ҿ������ľ����߼�
}

// ��������
PlayerController::~PlayerController() {
    // ������Դ���߼��������Ҫ��
}

