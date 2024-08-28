

#include "headers\NonInteractiveObject .h"

// �ǽ���������ʵ��

// ���캯��
NonInteractiveObject::NonInteractiveObject(float initialX, float initialY, const std::string& resourceBagName)
    : Entity(initialX, initialY, resourceBagName) {
    // ��ʼ���ǽ����������������
}

// ����������
NonInteractiveObject::~NonInteractiveObject() {
    // ����ǽ����������Դ
}

void NonInteractiveObject::Init() {
	this->Entity::Init();
}
void NonInteractiveObject::breakdown(){
	//������������г�ʼ��
	this->Entity::breakdown();
}

// ����״̬��Ĭ��ʵ��
void NonInteractiveObject::UpdateState() {
    // ʵ��״̬���µ�Ĭ���߼�
}

// ���¶�����Ĭ��ʵ��
void NonInteractiveObject::UpdateAnimation() {
    // ʵ�ֶ������µ�Ĭ���߼�
}

// ����������Ĭ��ʵ��
void NonInteractiveObject::UpdateSound() {
    // ʵ���������µ�Ĭ���߼�
}












// ������ʵ����ʵ��

// ���캯��
PhysicalObject::PhysicalObject(float initialX, float initialY, const std::string& resourceBagName)
    : NonInteractiveObject(initialX, initialY, resourceBagName), velocityX(0), velocityY(0) {
    // ��ʼ��������ʵ�����������
}

// ����������
PhysicalObject::~PhysicalObject() {
    // ����������ʵ�����Դ
}
void PhysicalObject::Init(){
    this->NonInteractiveObject::Init();
}
void PhysicalObject::breakdown(){
	//������������г�ʼ��
	this->NonInteractiveObject::breakdown();
}

void PhysicalObject::UpdateState() {
    ApplyPhysics();
    NonInteractiveObject::UpdateState();
}

void PhysicalObject::UpdateAnimation() {
    // ��������״̬���¶���
    NonInteractiveObject::UpdateAnimation();
}

void PhysicalObject::UpdateSound() {
    // ��������״̬��������
    NonInteractiveObject::UpdateSound();
}

void PhysicalObject::ApplyPhysics() {
    // Ӧ����������
    posX += velocityX;
    posY += velocityY;
}















// �ϰ���ʵ����ʵ��

// ���캯��
ObstacleObject::ObstacleObject(float initialX, float initialY, const std::string& resourceBagName)
    : NonInteractiveObject(initialX, initialY, resourceBagName) {
    // ��ʼ���ϰ���ʵ�����������
}
void ObstacleObject::Init()
{
	this->NonInteractiveObject::Init();
}
void ObstacleObject::breakdown(){
	//������������г�ʼ��
	this->NonInteractiveObject::breakdown();
}

// ����������
ObstacleObject::~ObstacleObject() {
    // �����ϰ���ʵ�����Դ
}

void ObstacleObject::UpdateState() {
    // �ϰ����λ�ò��䣬����Ҫ����λ��
    NonInteractiveObject::UpdateState();
}
