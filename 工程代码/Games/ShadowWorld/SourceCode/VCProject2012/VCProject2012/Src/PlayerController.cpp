#include "PlayerController.h"

// 构造函数
PlayerController::PlayerController(float initialX, float initialY,const ResourceBag * resourceBagPtr)
    : CharacterController(initialX,initialY,resourceBagPtr) {

	


}

// 析构函数
PlayerController::~PlayerController() {}

// 处理输入事件
void PlayerController::ProcessInput(const Event& event) {
	LogManager::Log("检测到键盘事件");
    CharacterController::ProcessInput(event); // 调用基类的输入处理逻辑
    // 可以在这里加入额外的输入处理逻辑
}

// 更新状态
void PlayerController::UpdateState() {
    // 更新玩家状态的具体实现
	
    UpdateCommonState();
    // 可以在这里加入其他状态更新逻辑
}

// 更新动画
void PlayerController::UpdateAnimation() {
    // 更新玩家动画的具体实现
    UpdateCommonAnimation();
    // 可以在这里加入其他动画更新逻辑
}

// 更新音效
void PlayerController::UpdateSound() {

    // 更新玩家音效的具体实现
    UpdateCommonSound();

    // 可以在这里加入其他音效更新逻辑
}



