#ifndef CHARACTERCONTROLLERMANAGER_H
#define CHARACTERCONTROLLERMANAGER_H

#include <string>
#include <unordered_map>
#include "Entity.h"
<<<<<<< Updated upstream
=======
#include "json/json.h"
>>>>>>> Stashed changes

class EntityManager {
public:
    // 构造函数
    EntityManager();

    // 析构函数
    ~EntityManager();

<<<<<<< Updated upstream
    // 创建新的 CharacterController 实例
    std::string CreateEntity(const std::string& type, float initialX, float initialY, ResourceBag* resourceBagPtr);
=======
    // 创建新的 Entity 实例，并返回其唯一标识符
    std::string CreateEntity(const std::string& jsonString);
>>>>>>> Stashed changes

    // 获取指定 ID 的 CharacterController
    Entity * GetEntity(const std::string& id);

    // 删除指定 ID 的 CharacterController
    void DeleteEntity(const std::string& id);

    // 更新所有控制器，包括更新和渲染
    void UpdateAllEntities();

    // 注册事件监听器
    void RegisterEventListeners();

    // 注销事件监听器
    void UnregisterEventListeners();

private:
    // 根据控制器类型创建新的控制器实例
    Entity * CreateEntityInstance(const std::string& type, float initialX, float initialY, ResourceBag* resourceBagPtr);

<<<<<<< Updated upstream
    std::unordered_map<std::string, Entity *> entities;
    int nextID;
=======
    bool listenersRegistered;  // 标记事件监听器是否已注册

    // 存储精灵名称到 Entity 的映射
    std::unordered_map<std::string, Entity*> spriteNameToEntity;
>>>>>>> Stashed changes
};

#endif // CHARACTERCONTROLLERMANAGER_H
