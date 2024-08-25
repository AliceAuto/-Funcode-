#include "PlayerController.h"
#include "Logger.h"

// ���캯��
<<<<<<< Updated upstream
PlayerController::PlayerController(float initialX, float initialY,ResourceBag* resourceBagPtr)
    : CharacterController(initialX, initialY, resourceBagPtr) {
=======
PlayerController::PlayerController(float initialX, float initialY,std::string & resourceBag)
    : CharacterController(initialX, initialY, resourceBag) {
    RegisterListeners();
>>>>>>> Stashed changes
    // ��ʼ����ҿ������ľ����߼�
}

// ��������
PlayerController::~PlayerController() {
    UnregisterListeners();
    // ������Դ���߼��������Ҫ��
}



void PlayerController::RegisterListeners() 
{
    // ע����������¼�������
    EventManager::Instance().RegisterListener(EventType::KeyboardInput,
        std::bind(&PlayerController::ProcessInput, this, std::placeholders::_1));
    // ע����������¼�������
    EventManager::Instance().RegisterListener(EventType::MouseInput,
        std::bind(&PlayerController::ProcessInput, this, std::placeholders::_1));
    LogManager::Log("�¼���������ע��");
}

void PlayerController::UnregisterListeners() 
{
    // ע�����������¼�������
    EventManager::Instance().RemoveListener(EventType::KeyboardInput,
        std::bind(&PlayerController::ProcessInput, this, std::placeholders::_1));
    // ע����������¼�������
    EventManager::Instance().RemoveListener(EventType::MouseInput,
        std::bind(&PlayerController::ProcessInput, this, std::placeholders::_1));
    LogManager::Log("�¼���������ע��");
}
