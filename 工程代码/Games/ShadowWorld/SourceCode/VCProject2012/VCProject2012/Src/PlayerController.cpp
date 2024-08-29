#include "PlayerController.h"
#include "Logger.h"

//____________________________________________________________________________________________________________________________________________________________
//============================================================================================================================================================





// [˵��]
// ���캯������ʼ����ҿ�������������ʼλ�ú���Դ������
// ��ʼ����ҿ������ľ����߼�
//____________________________________________________________________________________________________________
PlayerController::PlayerController(float initialX, float initialY, const std::string& resourceBagName)
    : CharacterController(initialX, initialY, resourceBagName), isListenerRegistered(false) 
{
    // ��ʼ����ҿ������ľ����߼�
}
//____________________________________________________________________________________________________________




// [˵��]
// ��������������������ҿ���������Դ�������Ҫ��
//_______________________________________________
PlayerController::~PlayerController() 
{
    // ������Դ���߼��������Ҫ��
}
//_______________________________________________






// [˵��]
// ��ʼ�����������ø���ĳ�ʼ����������ע����������
//___________________________________________________
void PlayerController::Init()
{
    CharacterController::Init();
    this->RegisterMouseListener();
}
//__________________________________________________





// [˵��]
// ��Դ�����������ø������Դ����������ע����������
//____________________________________________
void PlayerController::breakdown()
{
    CharacterController::breakdown();
    this->UnregisterMouseListener();
}
//____________________________________________






// [˵��]
// ע���������������������δע�ᣬ��ע�����ͼ����¼��ļ�����
//_________________________________________________________________________________________
void PlayerController::RegisterMouseListener()
{
    if (!this->isListenerRegistered)
    {
        // ע����������¼��ļ�����
        EventManager::Instance().RegisterListener(
            EventType::MouseInput, Entity::ID + "player_mouse_info",
            [this](const Event& event) 
            { 
                this->ProcessInput(static_cast<const MouseInputEvent&>(event)); 
            }
        );
        LogManager::Log("�ɹ�ע��һ��������");

        // ע����������¼��ļ�����
        EventManager::Instance().RegisterListener(
            EventType::KeyboardInput, Entity::ID + "player_keyboard_info",
            [this](const Event& event) 
            { 
                this->ProcessInput(static_cast<const KeyboardInputEvent&>(event)); 
            }
        );
        LogManager::Log("�ɹ�ע��һ�����̼���");

        this->isListenerRegistered = true;
    }
}
//_________________________________________________________________________________________






// [˵��]
// ע�����������������������ע�ᣬ��ע�����ͼ����¼��ļ�����
//_______________________________________________________________________________________________________________________
void PlayerController::UnregisterMouseListener() 
{
    if (this->isListenerRegistered)
    {
        // ע����������¼��ļ�����
        EventManager::Instance().RemoveListener(EventType::MouseInput, Entity::ID + "player_mouse_info");
        LogManager::Log("�ɹ�ע��һ��������");

        // ע�����������¼��ļ�����
        EventManager::Instance().RemoveListener(EventType::KeyboardInput, Entity::ID + "player_keyboard_info");
        LogManager::Log("�ɹ�ע��һ�����̼���");

        this->isListenerRegistered = false;
    }
}
//_______________________________________________________________________________________________________________________









//____________________________________________________________________________________________________________________________________________________________
//============================================================================================================================================================
