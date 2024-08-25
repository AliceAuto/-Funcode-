#include "EntityManager.h"
#include "PlayerController.h"
#include <iostream>
#include "headers\NonInteractiveObject .h"
// 构造函数初始化
EntityManager::EntityManager()

{
}

// 析构函数，释放所有资源
EntityManager::~EntityManager()
{
    for (auto& pair : spriteNameToEntity) {
        delete pair.second;
    }

    spriteNameToEntity.clear(); // 清理精灵名称到实体的映射
}

// 创建新的实体实例，并返回其唯一标识符
std::string EntityManager::CreateEntity(const std::string& jsonString)
{
	  Entity* entity = nullptr;
	  std::string resourceBag;
    Json::Reader reader;
    Json::Value root;

    // 解析 JSON 字符串
    if (reader.parse(jsonString, root)) {  
        std::string typeName = root.get("TypeName", "").asString();
        resourceBag = root.get("resourceBag", "").asString();
		LogManager::Log("************************"+resourceBag+"************************");
        if (typeName == "Player") {
			

            entity = CreateEntityInstance("Player", root);
        } else if (typeName == "Obstacle") {
			

            entity = CreateEntityInstance("Obstacle", root);
        }

        if (entity) {
            entity->Init(resourceBag);
            std::string name = entity->resourceBagPtr->GetResource<CSprite>("Entity").get()->GetName();
            spriteNameToEntity[name] = entity; // 存储精灵名称与实体的映射
            return name;
        }
    } 
	else{LogManager::Log("资源加载失败");}

    return "";

}

// 根据控制器类型创建新的实体实例
Entity* EntityManager::CreateEntityInstance(const std::string& type, Json::Value root)
{    //玩家
    if (type == "Player") {
		float posX = static_cast<float>(root.get("posX", 0.0).asDouble());
		float posY = static_cast<float>(root.get("posY", 0.0).asDouble());
		

        return new PlayerController(posX, posY);
    }
    //规则障碍方块
	else if (type == "Obstacle") {
		float posX = static_cast<float>(root.get("posX", 0.0).asDouble());
		float posY = static_cast<float>(root.get("posY", 0.0).asDouble());
        return new NonInteractiveObject(posX, posY);
    }

    return nullptr;
}

// 获取指定 ID 的实体
Entity* EntityManager::GetEntity(const std::string& name)
{
    auto it =  spriteNameToEntity.find(name);
    if (it !=  spriteNameToEntity.end()) {
        return it->second;
    }
    std::cerr << "Entity with ID: " << name << " not found." << std::endl;
    return nullptr;
}

// 根据精灵名称获取实体
Entity* EntityManager::GetEntityBySpriteName(const std::string& spriteName)
{
    auto it = spriteNameToEntity.find(spriteName);
    if (it != spriteNameToEntity.end()) {
        return it->second;
    }
    std::cerr << "Entity with sprite name: " << spriteName << " not found." << std::endl;
    return nullptr;
}

// 删除指定 ID 的实体
void EntityManager::DeleteEntity(const std::string& name)
{
    auto it = spriteNameToEntity.find(name);
    if (it !=spriteNameToEntity.end()) {
        // 从精灵名称映射中删除
        for (auto spriteIt = spriteNameToEntity.begin(); spriteIt != spriteNameToEntity.end(); ++spriteIt) {
            if (spriteIt->second == it->second) {
                spriteNameToEntity.erase(spriteIt);
                break;
            }
        }
        delete it->second;
       spriteNameToEntity.erase(it);
    }
    else {
        
    }
}

// 更新所有实体
void EntityManager::UpdateAllEntities()
{
    for (auto& pair : spriteNameToEntity) {
        pair.second->Update();
        // 可以在这里添加更多的更新逻辑
    }
}
