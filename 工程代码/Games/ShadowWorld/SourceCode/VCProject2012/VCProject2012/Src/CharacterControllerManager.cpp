#include "CharacterControllerManager.h"
#include "PlayerController.h"  // ��������һ�� PlayerController ��

/**
 * @brief ���캯������ʼ�� nextID��
 */
CharacterControllerManager::CharacterControllerManager()
    : nextID(0) // ��ʼ�� ID ������
{
}

/**
 * @brief �����������������п��������ڴ档
 */
CharacterControllerManager::~CharacterControllerManager()
{
    for (auto& pair : controllers) {
        delete pair.second;
    }
    controllers.clear();
}

/**
 * @brief ����һ���µ� CharacterController ʵ�����洢�ڹ������С�
 * @param type �����������ͣ����� "Player"����
 * @param initialX �������ĳ�ʼ X ���ꡣ
 * @param initialY �������ĳ�ʼ Y ���ꡣ
 * @param resourceBag ���ڼ�����Դ����Դ����
 * @return �´����Ŀ������� ID��
 */
std::string CharacterControllerManager::CreateCharacterController(const std::string& type, float initialX, float initialY, const ResourceBag * resourceBagPtr)
{
    CharacterController* controller = CreateControllerInstance(type, initialX, initialY, resourceBagPtr);
    if (controller) {
        std::string id = "Controller_" + std::to_string(nextID++);
        controllers[id] = controller;
        return id;
    }
    return "";
}

/**
 * @brief ���ݿ��������ʹ���һ���µĿ�����ʵ����
 * @param type �����������ͣ����� "Player"����
 * @param initialX �������ĳ�ʼ X ���ꡣ
 * @param initialY �������ĳ�ʼ Y ���ꡣ
 * @param resourceBag ���ڼ�����Դ����Դ����
 * @return �����Ŀ�����ʵ��ָ�롣
 */
CharacterController* CharacterControllerManager::CreateControllerInstance(const std::string& type, float initialX, float initialY, const ResourceBag * resourceBagPtr)
{
    if (type == "Player") {
        return new PlayerController(initialX, initialY,resourceBagPtr);
    }
    // ������������������ͣ��������������
    return nullptr;
}

/**
 * @brief ��ȡָ�� ID �Ŀ�������
 * @param id �������� ID��
 * @return �ҵ��Ŀ�����ָ�룬��δ�ҵ��򷵻� nullptr��
 */
CharacterController* CharacterControllerManager::GetCharacterController(const std::string& id)
{
    auto it = controllers.find(id);
    if (it != controllers.end()) {
        return it->second;
    }
    return nullptr;
}

/**
 * @brief ɾ��ָ�� ID �Ŀ����������ͷ����ڴ档
 * @param id Ҫɾ���Ŀ����� ID��
 */
void CharacterControllerManager::DeleteCharacterController(const std::string& id)
{
    auto it = controllers.find(id);
    if (it != controllers.end()) {
        delete it->second;
        controllers.erase(it);
    }
}

/**
 * @brief �������п�������
 */
void CharacterControllerManager::UpdateAllControllers()
{

    for (auto& pair : controllers) {
        pair.second->Update();
		
    }
}

/**
 * @brief ��Ⱦ���п�������
 */
void CharacterControllerManager::RenderAllControllers()
{
    for (auto& pair : controllers) {
        pair.second->Render();
    }
}
