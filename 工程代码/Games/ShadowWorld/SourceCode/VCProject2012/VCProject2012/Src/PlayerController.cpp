#include "PlayerController.h"
#include "Logger.h"

//====================================================================================
/*
    ��Ҷ���ʵ��
*/
//====================================================================================

// ���캯��
PlayerController::PlayerController(float initialX, float initialY)
    : CharacterController(initialX, initialY) {
		  eventManager.RegisterListener(EventType::KeyboardInput, std::bind(&PlayerController::ProcessInput, this, std::placeholders::_1));
    // ��ʼ����ҿ������ľ����߼�
}

// ��������
PlayerController::~PlayerController() {
    // ������Դ���߼��������Ҫ��
}

