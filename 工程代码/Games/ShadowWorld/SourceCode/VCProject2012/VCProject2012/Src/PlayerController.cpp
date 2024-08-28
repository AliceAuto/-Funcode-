#include "PlayerController.h"
#include "Logger.h"

//====================================================================================
/*
    玩家对象实现
*/
//====================================================================================

// 构造函数
PlayerController::PlayerController(float initialX, float initialY,const std::string& resourceBagName)
    : CharacterController(initialX, initialY, resourceBagName),isListenerRegistered(false) {
		
    // 初始化玩家控制器的具体逻辑
}

// 析构函数
PlayerController::~PlayerController() {
    // 清理资源的逻辑（如果需要）
}

void PlayerController::Init(){
	CharacterController::Init();
	this->RegisterMouseListener();
}
void PlayerController::breakdown(){
	CharacterController::breakdown();
	this->UnregisterMouseListener();
}
void PlayerController::RegisterMouseListener()
{
	if(!this->isListenerRegistered)
	{
    EventManager::Instance().RegisterListener
		(
		EventType::MouseInput,Entity::ID+"player_mouse_info", 
        [this](const Event& event) 
	{ 
		this->ProcessInput(static_cast<const MouseInputEvent&>(event)); 
	}
		);
	LogManager::Log("成功注册一个鼠标监听");
		 EventManager::Instance().RegisterListener
		(
		EventType::KeyboardInput,Entity::ID+"player_keyboard_info", 
        [this](const Event& event) 
	{ 
		this->ProcessInput(static_cast<const KeyboardInputEvent&>(event)); 
	}
		);
	LogManager::Log("成功注册一个键盘监听");

	}
	
}

void PlayerController::UnregisterMouseListener() 
{
	if(this->isListenerRegistered)
	{
    EventManager::Instance().RemoveListener(EventType::MouseInput,Entity::ID+"player_mouse_info");
	LogManager::Log("成功注销一个鼠标监听");

	EventManager::Instance().RemoveListener(EventType::KeyboardInput,Entity::ID+"player_keyboard_info");
	LogManager::Log("成功注销一个键盘监听");

	}}
