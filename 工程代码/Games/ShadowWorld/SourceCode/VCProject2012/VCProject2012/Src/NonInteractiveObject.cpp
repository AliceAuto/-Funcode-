

#include "headers\NonInteractiveObject .h"

// 非交互对象类实现

// 构造函数
NonInteractiveObject::NonInteractiveObject(float initialX, float initialY, const std::string& resourceBagName)
    : Entity(initialX, initialY, resourceBagName) {
    // 初始化非交互对象的特有属性
}

// 虚析构函数
NonInteractiveObject::~NonInteractiveObject() {
    // 清理非交互对象的资源
}

void NonInteractiveObject::Init() {
	this->Entity::Init();
}
void NonInteractiveObject::breakdown(){
	//对物理人物进行初始化
	this->Entity::breakdown();
}

// 更新状态的默认实现
void NonInteractiveObject::UpdateState() {
    // 实现状态更新的默认逻辑
}

// 更新动画的默认实现
void NonInteractiveObject::UpdateAnimation() {
    // 实现动画更新的默认逻辑
}

// 更新声音的默认实现
void NonInteractiveObject::UpdateSound() {
    // 实现声音更新的默认逻辑
}












// 物理性实体类实现

// 构造函数
PhysicalObject::PhysicalObject(float initialX, float initialY, const std::string& resourceBagName)
    : NonInteractiveObject(initialX, initialY, resourceBagName), velocityX(0), velocityY(0) {
    // 初始化物理性实体的特有属性
}

// 虚析构函数
PhysicalObject::~PhysicalObject() {
    // 清理物理性实体的资源
}
void PhysicalObject::Init(){
    this->NonInteractiveObject::Init();
}
void PhysicalObject::breakdown(){
	//对物理人物进行初始化
	this->NonInteractiveObject::breakdown();
}

void PhysicalObject::UpdateState() {
    ApplyPhysics();
    NonInteractiveObject::UpdateState();
}

void PhysicalObject::UpdateAnimation() {
    // 根据物理状态更新动画
    NonInteractiveObject::UpdateAnimation();
}

void PhysicalObject::UpdateSound() {
    // 根据物理状态更新声音
    NonInteractiveObject::UpdateSound();
}

void PhysicalObject::ApplyPhysics() {
    // 应用物理运算
    posX += velocityX;
    posY += velocityY;
}















// 障碍物实体类实现

// 构造函数
ObstacleObject::ObstacleObject(float initialX, float initialY, const std::string& resourceBagName)
    : NonInteractiveObject(initialX, initialY, resourceBagName) {
    // 初始化障碍物实体的特有属性
}
void ObstacleObject::Init()
{
	this->NonInteractiveObject::Init();
}
void ObstacleObject::breakdown(){
	//对物理人物进行初始化
	this->NonInteractiveObject::breakdown();
}

// 虚析构函数
ObstacleObject::~ObstacleObject() {
    // 清理障碍物实体的资源
}

void ObstacleObject::UpdateState() {
    // 障碍物的位置不变，不需要更新位置
    NonInteractiveObject::UpdateState();
}
