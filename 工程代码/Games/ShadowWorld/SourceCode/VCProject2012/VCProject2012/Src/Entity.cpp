#include "Entity.h"
#include <iostream>







Entity::Entity(float initialX, float initialY)
    : posX(initialX), posY(initialY), velocityX(0), velocityY(0), resourceBagPtr(new ResourceBag) {

}

Entity::~Entity() {
    delete resourceBagPtr; // ÊÍ·Å ResourceBag ÊµÀý
}

void Entity::Update() {
    UpdateState();
    UpdateAnimation();
    UpdateSound();
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
