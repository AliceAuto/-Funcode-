#include "headers\NonInteractiveObject .h"

// NonInteractiveObject ���ʵ��

// ���캯��
<<<<<<< Updated upstream
NonInteractiveObject::NonInteractiveObject(float initialX, float initialY,  ResourceBag* resourceBagPtr)
    : Entity(initialX, initialY, resourceBagPtr) {
    // �����ڴ˳�ʼ���ǽ����������������
=======
NonInteractiveObject::NonInteractiveObject(float initialX, float initialY,std::string & resourceBag)
    : Entity(initialX, initialY,resourceBag) {
    // ��ʼ���ǽ����������е����ԣ�����У�
>>>>>>> Stashed changes
}

// ����������
NonInteractiveObject::~NonInteractiveObject() {
    // ����ǽ����������Դ������У�
}
<<<<<<< Updated upstream

// ����״̬��Ĭ��ʵ��
void NonInteractiveObject::UpdateState() {
    // �����ڴ�ʵ��״̬���µ�Ĭ���߼�
    // ���û��� Entity �� UpdateState ����������У�
    UpdateState();
=======
void NonInteractiveObject::Init(){
Entity::Init();
}
// ����״̬��Ĭ��ʵ��
void NonInteractiveObject::UpdateState() {
    // ����״̬��Ĭ���߼�

>>>>>>> Stashed changes
}

// ���¶�����Ĭ��ʵ��
void NonInteractiveObject::UpdateAnimation() {
<<<<<<< Updated upstream
    // �����ڴ�ʵ�ֶ������µ�Ĭ���߼�
    // ���û��� Entity �� UpdateAnimation ����������У�
    UpdateAnimation();
=======
    // ���¶�����Ĭ���߼�

>>>>>>> Stashed changes
}

// ����������Ĭ��ʵ��
void NonInteractiveObject::UpdateSound() {
<<<<<<< Updated upstream
    // �����ڴ�ʵ���������µ�Ĭ���߼�
    // ���û��� Entity �� UpdateSound ����������У�
    UpdateSound();
=======
 // ���û���ķ����������Ҫ
}

// PhysicalCollisionBody ���ʵ��

PhysicalCollisionBody::PhysicalCollisionBody(float initialX, float initialY,std::string & resourceBag)
    : NonInteractiveObject(initialX, initialY,resourceBag) {
    // ��ʼ��������ײ�����е����ԣ�����У�
}

PhysicalCollisionBody::~PhysicalCollisionBody() {
    // ����������ײ�����Դ������У�
}

void PhysicalCollisionBody::Init() {
    // ��ʼ����Դ�������þ���λ��
    NonInteractiveObject::Init();
    
}

// Bullet ���ʵ��

Bullet::Bullet(float initialX, float initialY, float speedX, float speedY,std::string & resourceBag)
    : PhysicalCollisionBody(initialX, initialY,resourceBag), speedX(speedX), speedY(speedY) {
    // ��ʼ���ӵ����е�����
}

Bullet::~Bullet() {
    // �����ӵ����е���Դ������У�
}

void Bullet::UpdateState() {
    // �����ӵ�λ��
    posX += speedX;
    posY += speedY;

    // ����ӵ��Ƿ񳬳���Ļ�����Ŀ����߼�
    // �����ڴ���Ӷ�����߼��������ӵ����ٻ�����Ŀ��
}
void Bullet::UpdateAnimation(){}
void Bullet::UpdateSound(){}

void Bullet::Init() {
    // ���û���ĳ�ʼ������
    PhysicalCollisionBody::Init();
}

// FixedObstacle ���ʵ��

FixedObstacle::FixedObstacle(float initialX, float initialY,std::string & resourceBag)
    : PhysicalCollisionBody(initialX, initialY,resourceBag) {
    // ��ʼ���̶��ϰ������е����ԣ�����У�
}

FixedObstacle::~FixedObstacle() {
    // ����̶��ϰ������Դ������У�
}

void FixedObstacle::Init() {
    // ��ʼ����Դ�������þ���λ��
    PhysicalCollisionBody::Init();
   
>>>>>>> Stashed changes
}
