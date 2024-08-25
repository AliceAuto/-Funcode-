#include "PlayerController.h"
#include "Logger.h"

//====================================================================================
/*
    玩家对象实现
*/
//====================================================================================

// 构造函数
PlayerController::PlayerController(float initialX, float initialY)
    : CharacterController(initialX, initialY) {
		  eventManager.RegisterListener(EventType::KeyboardInput, std::bind(&PlayerController::ProcessInput, this, std::placeholders::_1));
    // 初始化玩家控制器的具体逻辑
}

// 析构函数
PlayerController::~PlayerController() {
    // 清理资源的逻辑（如果需要）
}

