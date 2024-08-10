#include "Entity.h"

Entity::Entity(float initialX, float initialY, ResourceBag* resourceBagPtr)
    : posX(initialX), posY(initialY), velocityX(0), velocityY(0), resourceBagPtr(resourceBagPtr) {}

Entity::~Entity() {
    // 假设 ResourceBag 是由外部管理的，这里不需要删除
}

void Entity::Update() {
    // 调用子类实现的更新逻辑
    UpdateState();
    UpdateAnimation();
    UpdateSound();
}

void Entity::LoadResources(ResourceBag* resourceBagPtr) {
    this->resourceBagPtr = resourceBagPtr;
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
