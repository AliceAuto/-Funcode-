
#include "headers\NonInteractiveObject .h"

// ���캯��
NonInteractiveObject::NonInteractiveObject(float initialX, float initialY)
    : Entity(initialX, initialY) {
    // �����ڴ˳�ʼ���ǽ����������������
}

// ����������
NonInteractiveObject::~NonInteractiveObject() {
    // ����ǽ����������Դ
}

// ����״̬��Ĭ��ʵ��
void NonInteractiveObject::UpdateState() {
    // �����ڴ�ʵ��״̬���µ�Ĭ���߼�
    // ���û��� Entity �� UpdateState ����������У�
    UpdateState();
}

// ���¶�����Ĭ��ʵ��
void NonInteractiveObject::UpdateAnimation() {
    // �����ڴ�ʵ�ֶ������µ�Ĭ���߼�
    // ���û��� Entity �� UpdateAnimation ����������У�
    UpdateAnimation();
}

// ����������Ĭ��ʵ��
void NonInteractiveObject::UpdateSound() {
    // �����ڴ�ʵ���������µ�Ĭ���߼�
    // ���û��� Entity �� UpdateSound ����������У�
    UpdateSound();
}
