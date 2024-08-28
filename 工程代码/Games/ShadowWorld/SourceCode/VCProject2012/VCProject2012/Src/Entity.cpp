#include "Entity.h"
#include <iostream>







Entity::Entity(float initialX, float initialY,const std::string& resourceBagName)
    : posX(initialX), posY(initialY), velocityX(0), velocityY(0),ResourceBagName(resourceBagName),ID(""),resourceBagPtr(nullptr) {
}

Entity::~Entity() {

}
void Entity::Init() 

{  
	if(!resourceBagPtr){
		resourceBagPtr =new ResourceBag(ID);
		this->resourceBagPtr->LoadFromJson(ResourceBagName);
        this->resourceBagPtr->GetResource<CSprite>("Entity")->SetSpritePosition(this->posX, this->posY);
	}
 
}
void Entity::breakdown() 
{  
	if(resourceBagPtr){
		delete resourceBagPtr;
	} // ÊÍ·Å ResourceBag ÊµÀý
 
}
void Entity::Update() {
    UpdateState();
    UpdateAnimation();
    UpdateSound();
}

void Entity::ifCollision(Entity * otherEntity){
LogManager::Log("======================Åö============================================================================");
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
