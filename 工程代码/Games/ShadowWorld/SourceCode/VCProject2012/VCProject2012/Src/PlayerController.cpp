#include "PlayerController.h"

// ���캯��
PlayerController::PlayerController(float initialX, float initialY,const ResourceBag * resourceBagPtr)
    : CharacterController(initialX,initialY,resourceBagPtr) {

	


}

// ��������
PlayerController::~PlayerController() {}

// ���������¼�
void PlayerController::ProcessInput(const Event& event) {
	LogManager::Log("��⵽�����¼�");
    CharacterController::ProcessInput(event); // ���û�������봦���߼�
    // ��������������������봦���߼�
}

// ����״̬
void PlayerController::UpdateState() {
    // �������״̬�ľ���ʵ��
	
    UpdateCommonState();
    // �����������������״̬�����߼�
}

// ���¶���
void PlayerController::UpdateAnimation() {
    // ������Ҷ����ľ���ʵ��
    UpdateCommonAnimation();
    // ��������������������������߼�
}

// ������Ч
void PlayerController::UpdateSound() {

    // ���������Ч�ľ���ʵ��
    UpdateCommonSound();

    // �������������������Ч�����߼�
}



