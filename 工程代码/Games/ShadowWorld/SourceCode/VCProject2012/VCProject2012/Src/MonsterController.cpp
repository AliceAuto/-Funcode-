#include "MonsterController.h"

// 构造函数
MonsterController::MonsterController(float initialX, float initialY,const ResourceBag * resourceBagPtr)
    : CharacterController(initialX,initialY,resourceBagPtr) {}

// 析构函数
MonsterController::~MonsterController() {}

// 处理输入
void MonsterController::ProcessInput(const Event& event) {
    // 自定义怪物的输入处理逻辑
}

// 更新状态
void MonsterController::Update() {
    CharacterController::Update(); // 调用基类的 Update 方法
    // 其他更新逻辑
}

void MonsterController::UpdateState() {
    // 更新怪物状态的具体实现
    UpdateCommonState();
}

void MonsterController::UpdateAnimation() {
    // 更新怪物动画的具体实现
    UpdateCommonAnimation();
}

void MonsterController::UpdateSound() {
    // 更新怪物音效的具体实现
    UpdateCommonSound();
}
