#include "Entity.h"

<<<<<<< Updated upstream
Entity::Entity(float initialX, float initialY, ResourceBag* resourceBagPtr)
    : posX(initialX), posY(initialY), velocityX(0), velocityY(0), resourceBagPtr(resourceBagPtr) {}
=======






Entity::Entity(float initialX, float initialY,std::string & resourceBag)
    : posX(initialX), posY(initialY), velocityX(0), velocityY(0), resourceBagPtr(new ResourceBag) {
		this->resourceBagPtr->LoadFromJson(resourceBag);
}
>>>>>>> Stashed changes

Entity::~Entity() {
    // ���� ResourceBag �����ⲿ����ģ����ﲻ��Ҫɾ��
}

void Entity::Update() {
    // ��������ʵ�ֵĸ����߼�
    UpdateState();
    UpdateAnimation();
    UpdateSound();
}

void Entity::LoadResources(ResourceBag* resourceBagPtr) {
    this->resourceBagPtr = resourceBagPtr;
}
void Entity::Init(){
	this->resourceBagPtr->GetResource<CAnimateSprite>("Entity").get()->SetSpritePosition(posX, posY);
}
float Entity::GetPosX() const {
    return posX;
}

float Entity::GetPosY() const {
    return posY;
}

float Entity::GetVelocityX() const {
    return velocityX;
}

float Entity::GetVelocityY() const {
    return velocityY;
}

void Entity::SetPosition(float x, float y) {
    posX = x;
    posY = y;
}

void Entity::SetVelocity(float vx, float vy) {
    velocityX = vx;
    velocityY = vy;
}
