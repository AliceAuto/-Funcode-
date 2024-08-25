#include "headers\NonInteractiveObject .h"

// NonInteractiveObject 类的实现

// 构造函数
<<<<<<< Updated upstream
NonInteractiveObject::NonInteractiveObject(float initialX, float initialY,  ResourceBag* resourceBagPtr)
    : Entity(initialX, initialY, resourceBagPtr) {
    // 可以在此初始化非交互对象的特有属性
=======
NonInteractiveObject::NonInteractiveObject(float initialX, float initialY,std::string & resourceBag)
    : Entity(initialX, initialY,resourceBag) {
    // 初始化非交互对象特有的属性（如果有）
>>>>>>> Stashed changes
}

// 虚析构函数
NonInteractiveObject::~NonInteractiveObject() {
    // 清理非交互对象的资源（如果有）
}
<<<<<<< Updated upstream

// 更新状态的默认实现
void NonInteractiveObject::UpdateState() {
    // 可以在此实现状态更新的默认逻辑
    // 调用基类 Entity 的 UpdateState 方法（如果有）
    UpdateState();
=======
void NonInteractiveObject::Init(){
Entity::Init();
}
// 更新状态的默认实现
void NonInteractiveObject::UpdateState() {
    // 更新状态的默认逻辑

>>>>>>> Stashed changes
}

// 更新动画的默认实现
void NonInteractiveObject::UpdateAnimation() {
<<<<<<< Updated upstream
    // 可以在此实现动画更新的默认逻辑
    // 调用基类 Entity 的 UpdateAnimation 方法（如果有）
    UpdateAnimation();
=======
    // 更新动画的默认逻辑

>>>>>>> Stashed changes
}

// 更新声音的默认实现
void NonInteractiveObject::UpdateSound() {
<<<<<<< Updated upstream
    // 可以在此实现声音更新的默认逻辑
    // 调用基类 Entity 的 UpdateSound 方法（如果有）
    UpdateSound();
=======
 // 调用基类的方法，如果需要
}

// PhysicalCollisionBody 类的实现

PhysicalCollisionBody::PhysicalCollisionBody(float initialX, float initialY,std::string & resourceBag)
    : NonInteractiveObject(initialX, initialY,resourceBag) {
    // 初始化物理碰撞体特有的属性（如果有）
}

PhysicalCollisionBody::~PhysicalCollisionBody() {
    // 清理物理碰撞体的资源（如果有）
}

void PhysicalCollisionBody::Init() {
    // 初始化资源包并设置精灵位置
    NonInteractiveObject::Init();
    
}

// Bullet 类的实现

Bullet::Bullet(float initialX, float initialY, float speedX, float speedY,std::string & resourceBag)
    : PhysicalCollisionBody(initialX, initialY,resourceBag), speedX(speedX), speedY(speedY) {
    // 初始化子弹特有的属性
}

Bullet::~Bullet() {
    // 清理子弹特有的资源（如果有）
}

void Bullet::UpdateState() {
    // 更新子弹位置
    posX += speedX;
    posY += speedY;

    // 检查子弹是否超出屏幕或击中目标等逻辑
    // 可以在此添加额外的逻辑，例如子弹销毁或命中目标
}
void Bullet::UpdateAnimation(){}
void Bullet::UpdateSound(){}

void Bullet::Init() {
    // 调用基类的初始化方法
    PhysicalCollisionBody::Init();
}

// FixedObstacle 类的实现

FixedObstacle::FixedObstacle(float initialX, float initialY,std::string & resourceBag)
    : PhysicalCollisionBody(initialX, initialY,resourceBag) {
    // 初始化固定障碍物特有的属性（如果有）
}

FixedObstacle::~FixedObstacle() {
    // 清理固定障碍物的资源（如果有）
}

void FixedObstacle::Init() {
    // 初始化资源包并设置精灵位置
    PhysicalCollisionBody::Init();
   
>>>>>>> Stashed changes
}
