
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
void NonInteractiveObject::Init(const std::string & bag){
		this->resourceBagPtr->LoadFromJson(bag);
		this->resourceBagPtr->GetResource<CAnimateSprite>("Entity").get()->SetSpritePosition(posX,posY);
		
}
// ����״̬��Ĭ��ʵ��
void NonInteractiveObject::UpdateState() {
    // �����ڴ�ʵ��״̬���µ�Ĭ���߼�
    // ���û��� Entity �� UpdateState ����������У�

}

// ���¶�����Ĭ��ʵ��
void NonInteractiveObject::UpdateAnimation() {
    // �����ڴ�ʵ�ֶ������µ�Ĭ���߼�
    // ���û��� Entity �� UpdateAnimation ����������У�

}

// ����������Ĭ��ʵ��
void NonInteractiveObject::UpdateSound() {
    // �����ڴ�ʵ���������µ�Ĭ���߼�
    // ���û��� Entity �� UpdateSound ����������У�

}
