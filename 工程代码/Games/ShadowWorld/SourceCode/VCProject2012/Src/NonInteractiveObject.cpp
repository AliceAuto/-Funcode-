
#include "headers\NonInteractiveObject .h"

// 构造函数
NonInteractiveObject::NonInteractiveObject(float initialX, float initialY)
    : Entity(initialX, initialY) {
    // 可以在此初始化非交互对象的特有属性
}

// 虚析构函数
NonInteractiveObject::~NonInteractiveObject() {
    // 清理非交互对象的资源
}
void NonInteractiveObject::Init(const std::string & bag){
		this->resourceBagPtr->LoadFromJson(bag);
		this->resourceBagPtr->GetResource<CAnimateSprite>("Entity").get()->SetSpritePosition(posX,posY);
		
}
// 更新状态的默认实现
void NonInteractiveObject::UpdateState() {
    // 可以在此实现状态更新的默认逻辑
    // 调用基类 Entity 的 UpdateState 方法（如果有）

}

// 更新动画的默认实现
void NonInteractiveObject::UpdateAnimation() {
    // 可以在此实现动画更新的默认逻辑
    // 调用基类 Entity 的 UpdateAnimation 方法（如果有）

}

// 更新声音的默认实现
void NonInteractiveObject::UpdateSound() {
    // 可以在此实现声音更新的默认逻辑
    // 调用基类 Entity 的 UpdateSound 方法（如果有）

}
