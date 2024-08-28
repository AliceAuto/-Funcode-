#include "PlayerController.h"
#include "Logger.h"

//====================================================================================
/*
    ��Ҷ���ʵ��
*/
//====================================================================================

// ���캯��
PlayerController::PlayerController(float initialX, float initialY,const std::string& resourceBagName)
    : CharacterController(initialX, initialY, resourceBagName),isListenerRegistered(false) {
		
    // ��ʼ����ҿ������ľ����߼�
}

// ��������
PlayerController::~PlayerController() {
    // ������Դ���߼��������Ҫ��
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
	LogManager::Log("�ɹ�ע��һ��������");
		 EventManager::Instance().RegisterListener
		(
		EventType::KeyboardInput,Entity::ID+"player_keyboard_info", 
        [this](const Event& event) 
	{ 
		this->ProcessInput(static_cast<const KeyboardInputEvent&>(event)); 
	}
		);
	LogManager::Log("�ɹ�ע��һ�����̼���");

	}
	
}

void PlayerController::UnregisterMouseListener() 
{
	if(this->isListenerRegistered)
	{
    EventManager::Instance().RemoveListener(EventType::MouseInput,Entity::ID+"player_mouse_info");
	LogManager::Log("�ɹ�ע��һ��������");

	EventManager::Instance().RemoveListener(EventType::KeyboardInput,Entity::ID+"player_keyboard_info");
	LogManager::Log("�ɹ�ע��һ�����̼���");

	}}
