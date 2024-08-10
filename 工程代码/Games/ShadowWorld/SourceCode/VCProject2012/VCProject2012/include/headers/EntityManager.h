#ifndef CHARACTERCONTROLLERMANAGER_H
#define CHARACTERCONTROLLERMANAGER_H

#include <string>
#include <unordered_map>
#include "Entity.h"

class EntityManager {
public:
    EntityManager();
    ~EntityManager();

    // 创建新的 CharacterController 实例
    std::string CreateEntity(const std::string& type, float initialX, float initialY, ResourceBag* resourceBagPtr);

    // 获取指定 ID 的 CharacterController
    Entity * GetEntity(const std::string& id);

    // 删除指定 ID 的 CharacterController
    void DeleteEntity(const std::string& id);

    // 更新所有控制器，包括更新和渲染
    void UpdateAllEntities();

private:
    // 根据控制器类型创建新的控制器实例
    Entity * CreateEntityInstance(const std::string& type, float initialX, float initialY, ResourceBag* resourceBagPtr);

    std::unordered_map<std::string, Entity *> entities;
    int nextID;
};

#endif // CHARACTERCONTROLLERMANAGER_H
