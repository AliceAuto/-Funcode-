#include "MonsterController.h"

// ���캯��
MonsterController::MonsterController(float initialX, float initialY,const ResourceBag * resourceBagPtr)
    : CharacterController(initialX,initialY,resourceBagPtr) {}

// ��������
MonsterController::~MonsterController() {}

// ��������
void MonsterController::ProcessInput(const Event& event) {
    // �Զ����������봦���߼�
}

// ����״̬
void MonsterController::Update() {
    CharacterController::Update(); // ���û���� Update ����
    // ���������߼�
}

void MonsterController::UpdateState() {
    // ���¹���״̬�ľ���ʵ��
    UpdateCommonState();
}

void MonsterController::UpdateAnimation() {
    // ���¹��ﶯ���ľ���ʵ��
    UpdateCommonAnimation();
}

void MonsterController::UpdateSound() {
    // ���¹�����Ч�ľ���ʵ��
    UpdateCommonSound();
}
