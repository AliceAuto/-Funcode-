#include "CharacterControllerManager.h"
#include "PlayerController.h"  // 假设你有一个 PlayerController 类

/**
 * @brief 构造函数，初始化 nextID。
 */
CharacterControllerManager::CharacterControllerManager()
    : nextID(0) // 初始化 ID 计数器
{
}

/**
 * @brief 析构函数，清理所有控制器的内存。
 */
CharacterControllerManager::~CharacterControllerManager()
{
    for (auto& pair : controllers) {
        delete pair.second;
    }
    controllers.clear();
}

/**
 * @brief 创建一个新的 CharacterController 实例并存储在管理器中。
 * @param type 控制器的类型（例如 "Player"）。
 * @param initialX 控制器的初始 X 坐标。
 * @param initialY 控制器的初始 Y 坐标。
 * @param resourceBag 用于加载资源的资源包。
 * @return 新创建的控制器的 ID。
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
 * @brief 根据控制器类型创建一个新的控制器实例。
 * @param type 控制器的类型（例如 "Player"）。
 * @param initialX 控制器的初始 X 坐标。
 * @param initialY 控制器的初始 Y 坐标。
 * @param resourceBag 用于加载资源的资源包。
 * @return 创建的控制器实例指针。
 */
CharacterController* CharacterControllerManager::CreateControllerInstance(const std::string& type, float initialX, float initialY, const ResourceBag * resourceBagPtr)
{
    if (type == "Player") {
        return new PlayerController(initialX, initialY,resourceBagPtr);
    }
    // 如果有其他控制器类型，可以在这里添加
    return nullptr;
}

/**
 * @brief 获取指定 ID 的控制器。
 * @param id 控制器的 ID。
 * @return 找到的控制器指针，若未找到则返回 nullptr。
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
 * @brief 删除指定 ID 的控制器，并释放其内存。
 * @param id 要删除的控制器 ID。
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
 * @brief 更新所有控制器。
 */
void CharacterControllerManager::UpdateAllControllers()
{

    for (auto& pair : controllers) {
        pair.second->Update();
		
    }
}

/**
 * @brief 渲染所有控制器。
 */
void CharacterControllerManager::RenderAllControllers()
{
    for (auto& pair : controllers) {
        pair.second->Render();
    }
}
