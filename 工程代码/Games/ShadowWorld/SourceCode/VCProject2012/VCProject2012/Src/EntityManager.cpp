#include "EntityManager.h"
#include "PlayerController.h"

EntityManager::EntityManager()
    : nextID(0)
{
}

EntityManager::~EntityManager()
{
    for (auto& pair : entities) {
        delete pair.second;
    }
    entities.clear();
}

std::string EntityManager::CreateEntity(const std::string& type, float initialX, float initialY, ResourceBag* resourceBagPtr)
{
    Entity* entity = CreateEntityInstance(type, initialX, initialY, resourceBagPtr);
    if (entity) {
        std::string id = "Entity_" + std::to_string(nextID++);
        entities[id] = entity;
        return id;
    }
    return "";
}

Entity* EntityManager:: CreateEntityInstance(const std::string& type, float initialX, float initialY, ResourceBag* resourceBagPtr)
{
    if (type == "Player") {
        return new PlayerController(initialX, initialY, resourceBagPtr);
    }
    // 可以添加更多的实体类型
    return nullptr;
}

Entity* EntityManager::GetEntity(const std::string& id)
{
    auto it = entities.find(id);
    if (it != entities.end()) {
        return it->second;
    }
    return nullptr;
}

void EntityManager::DeleteEntity(const std::string& id)
{
    auto it = entities.find(id);
    if (it != entities.end()) {
        delete it->second;
        entities.erase(it);
    }
}

void EntityManager::UpdateAllEntities()
{
    for (auto& pair : entities) {
        pair.second->Update();
    }
}
