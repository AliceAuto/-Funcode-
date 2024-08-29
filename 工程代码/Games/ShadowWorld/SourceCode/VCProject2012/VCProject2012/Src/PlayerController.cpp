#include "PlayerController.h"
#include "Logger.h"

//____________________________________________________________________________________________________________________________________________________________
//============================================================================================================================================================





// [说明]
// 构造函数：初始化玩家控制器，包括初始位置和资源包名称
// 初始化玩家控制器的具体逻辑
//____________________________________________________________________________________________________________
PlayerController::PlayerController(float initialX, float initialY, const std::string& resourceBagName)
    : CharacterController(initialX, initialY, resourceBagName), isListenerRegistered(false) 
{
    // 初始化玩家控制器的具体逻辑
}
//____________________________________________________________________________________________________________




// [说明]
// 析构函数：用于清理玩家控制器的资源（如果需要）
//_______________________________________________
PlayerController::~PlayerController() 
{
    // 清理资源的逻辑（如果需要）
}
//_______________________________________________






// [说明]
// 初始化函数：调用父类的初始化函数，并注册鼠标监听器
//___________________________________________________
void PlayerController::Init()
{
    CharacterController::Init();
    this->RegisterMouseListener();
}
//__________________________________________________





// [说明]
// 资源清理函数：调用父类的资源清理函数，并注销鼠标监听器
//____________________________________________
void PlayerController::breakdown()
{
    CharacterController::breakdown();
    this->UnregisterMouseListener();
}
//____________________________________________






// [说明]
// 注册鼠标监听器：如果监听器未注册，则注册鼠标和键盘事件的监听器
//_________________________________________________________________________________________
void PlayerController::RegisterMouseListener()
{
    if (!this->isListenerRegistered)
    {
        // 注册鼠标输入事件的监听器
        EventManager::Instance().RegisterListener(
            EventType::MouseInput, Entity::ID + "player_mouse_info",
            [this](const Event& event) 
            { 
                this->ProcessInput(static_cast<const MouseInputEvent&>(event)); 
            }
        );
        LogManager::Log("成功注册一个鼠标监听");

        // 注册键盘输入事件的监听器
        EventManager::Instance().RegisterListener(
            EventType::KeyboardInput, Entity::ID + "player_keyboard_info",
            [this](const Event& event) 
            { 
                this->ProcessInput(static_cast<const KeyboardInputEvent&>(event)); 
            }
        );
        LogManager::Log("成功注册一个键盘监听");

        this->isListenerRegistered = true;
    }
}
//_________________________________________________________________________________________






// [说明]
// 注销鼠标监听器：如果监听器已注册，则注销鼠标和键盘事件的监听器
//_______________________________________________________________________________________________________________________
void PlayerController::UnregisterMouseListener() 
{
    if (this->isListenerRegistered)
    {
        // 注销鼠标输入事件的监听器
        EventManager::Instance().RemoveListener(EventType::MouseInput, Entity::ID + "player_mouse_info");
        LogManager::Log("成功注销一个鼠标监听");

        // 注销键盘输入事件的监听器
        EventManager::Instance().RemoveListener(EventType::KeyboardInput, Entity::ID + "player_keyboard_info");
        LogManager::Log("成功注销一个键盘监听");

        this->isListenerRegistered = false;
    }
}
//_______________________________________________________________________________________________________________________









//____________________________________________________________________________________________________________________________________________________________
//============================================================================================================================================================
