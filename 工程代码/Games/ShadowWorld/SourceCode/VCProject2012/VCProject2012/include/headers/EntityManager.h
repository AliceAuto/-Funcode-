#ifndef ENTITYMANAGER_H
#define ENTITYMANAGER_H

#include <string>
#include <unordered_map>
#include "Entity.h"
#include "json/json.h"

//==========================================================================================================
class EntityManager {
public:
    EntityManager();
    ~EntityManager();

    // 创建新的 Entity 实例，并返回其唯一标识符
	//json读取可变参数
    std::string CreateEntity(const std::string& jsonString);

    // 获取指定 ID 的 Entity
    Entity* GetEntity(const std::string& id);

    // 根据精灵名称获取 Entity
    Entity* GetEntityBySpriteName(const std::string& spriteName);

    // 删除指定 ID 的 Entity
    void DeleteEntity(const std::string& id);

    // 更新所有 Entity，包括更新和渲染
    void Update();
	//加载所有实体
	void EntityManager::LoadAllEntitys();
	void EntityManager::breakDownAllEntitys();


private:
    // 根据控制器类型创建新的控制器实例
    Entity* CreateEntityInstance(const std::string& type, Json::Value root);

	long long Id_couter;
    // 存储精灵名称到 Entity 的映射
    std::unordered_map<std::string, Entity*> spriteNameToEntity;
    // 生成唯一 ID
};
//==========================================================================================================

#endif // ENTITYMANAGER_H
