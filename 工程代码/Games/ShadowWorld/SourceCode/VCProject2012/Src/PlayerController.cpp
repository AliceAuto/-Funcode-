#include "PlayerController.h"
#include "Logger.h"

// 构造函数
<<<<<<< Updated upstream
PlayerController::PlayerController(float initialX, float initialY,ResourceBag* resourceBagPtr)
    : CharacterController(initialX, initialY, resourceBagPtr) {
=======
PlayerController::PlayerController(float initialX, float initialY,std::string & resourceBag)
    : CharacterController(initialX, initialY, resourceBag) {
    RegisterListeners();
>>>>>>> Stashed changes
    // 初始化玩家控制器的具体逻辑
}

// 析构函数
PlayerController::~PlayerController() {
    UnregisterListeners();
    // 清理资源的逻辑（如果需要）
}



void PlayerController::RegisterListeners() 
{
    // 注册键盘输入事件监听器
    EventManager::Instance().RegisterListener(EventType::KeyboardInput,
        std::bind(&PlayerController::ProcessInput, this, std::placeholders::_1));
    // 注册鼠标输入事件监听器
    EventManager::Instance().RegisterListener(EventType::MouseInput,
        std::bind(&PlayerController::ProcessInput, this, std::placeholders::_1));
    LogManager::Log("事件监听器已注册");
}

void PlayerController::UnregisterListeners() 
{
    // 注销键盘输入事件监听器
    EventManager::Instance().RemoveListener(EventType::KeyboardInput,
        std::bind(&PlayerController::ProcessInput, this, std::placeholders::_1));
    // 注销鼠标输入事件监听器
    EventManager::Instance().RemoveListener(EventType::MouseInput,
        std::bind(&PlayerController::ProcessInput, this, std::placeholders::_1));
    LogManager::Log("事件监听器已注销");
}
