#include "EntityManager.h"
#include "PlayerController.h"
<<<<<<< Updated upstream

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
=======
#include "headers\NonInteractiveObject .h"
#include "Button.h"

EntityManager::EntityManager() {
    RegisterEventListeners();
}

EntityManager::~EntityManager() {
    UnregisterEventListeners();

    for (auto& pair : spriteNameToEntity) {
        delete pair.second;
    }
    spriteNameToEntity.clear(); // 清理精灵名称到实体的映射
}

void EntityManager::RegisterEventListeners() {
    if (!listenersRegistered) {
        // 你可以在这里添加注册的具体实现
        listenersRegistered = true;
    }
}

void EntityManager::UnregisterEventListeners() {
    if (listenersRegistered) {
        // 你可以在这里添加注销的具体实现
        listenersRegistered = false;
    }
}

std::string EntityManager::CreateEntity(const std::string& jsonString) {
    Entity* entity = nullptr;
   
    Json::Reader reader;
    Json::Value root;

    // 解析 JSON 字符串
    if (reader.parse(jsonString, root)) {  
        std::string typeName = root.get("TypeName", "").asString();

    

        if (typeName == "Player") {
            entity = CreateEntityInstance("Player", root);
        } else if (typeName == "PhysicalObstacle") {
            entity = CreateEntityInstance("PhysicalObstacle", root);
        } else if (typeName == "FixeObstacle") {
            entity = CreateEntityInstance("FixeObstacle", root);
        } else if (typeName == "Bullet") {
            LogManager::Log("*/*/*/*/*/*/*/*/*/*/*/*/");
            entity = CreateEntityInstance("Bullet", root);
        } else if (typeName == "Button") { // 处理按钮类型
            LogManager::Log("Creating Button entity.");
            entity = CreateEntityInstance("Button", root);
        }

        if (entity) {
            entity->Init();
            std::string name = entity->resourceBagPtr->GetResource<CSprite>("Entity").get()->GetName();
            spriteNameToEntity[name] = entity; // 存储精灵名称与实体的映射
            return name;
        }
    } else {
        LogManager::Log("资源加载失败");
    }

    return "";
}

Entity* EntityManager::CreateEntityInstance(const std::string& type, Json::Value root) {
    // 玩家
    if (type == "Player") {
        float posX = static_cast<float>(root.get("posX", 0.0).asDouble());
        float posY = static_cast<float>(root.get("posY", 0.0).asDouble());
		std::string resourceBag = root.get("resourceBag", "").asString();
        return new PlayerController(posX, posY,resourceBag);
    }
    // 物理碰撞体
    else if (type == "PhysicalObstacle") {
        float posX = static_cast<float>(root.get("posX", 0.0).asDouble());
        float posY = static_cast<float>(root.get("posY", 0.0).asDouble());
		std::string resourceBag = root.get("resourceBag", "").asString();
        return new PhysicalCollisionBody(posX, posY,resourceBag);
    }
    // 固定障碍物
    else if (type == "FixeObstacle") {
        float posX = static_cast<float>(root.get("posX", 0.0).asDouble());
        float posY = static_cast<float>(root.get("posY", 0.0).asDouble());
		std::string resourceBag = root.get("resourceBag", "").asString();
        return new FixedObstacle(posX, posY,resourceBag);
    }
    // 子弹
    else if (type == "Bullet") {
        float posX = static_cast<float>(root.get("posX", 0.0).asDouble());
        float posY = static_cast<float>(root.get("posY", 0.0).asDouble());
        float velocityX = static_cast<float>(root.get("velocityX", 0.0).asDouble());
        float velocityY = static_cast<float>(root.get("velocityY", 0.0).asDouble());
		std::string resourceBag = root.get("resourceBag", "").asString();
        return new Bullet(posX, posY, velocityX, velocityY, resourceBag);
    }
    // 按钮
    else if (type == "Button") {
		float posX = static_cast<float>(root.get("posX", 0.0).asDouble());
        float posY = static_cast<float>(root.get("posY", 0.0).asDouble());
		std::string resourceBag = root.get("resourceBag", "").asString();
		std::string label = root.get("label", "").asString();
        return new Button(label,posX,posY,resourceBag); // 创建按钮实例
    }

    return nullptr;
}

Entity* EntityManager::GetEntity(const std::string& name) {
    auto it = spriteNameToEntity.find(name);
    if (it != spriteNameToEntity.end()) {
>>>>>>> Stashed changes
        return it->second;
    }
    return nullptr;
}

<<<<<<< Updated upstream
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
=======
Entity* EntityManager::GetEntityBySpriteName(const std::string& spriteName) {
    auto it = spriteNameToEntity.find(spriteName);
    if (it != spriteNameToEntity.end()) {
        return it->second;
    }
    std::cerr << "Entity with sprite name: " << spriteName << " not found." << std::endl;
    return nullptr;
}

void EntityManager::DeleteEntity(const std::string& name) {
    auto it = spriteNameToEntity.find(name);
    if (it != spriteNameToEntity.end()) {
        // 从精灵名称映射中删除
        for (auto spriteIt = spriteNameToEntity.begin(); spriteIt != spriteNameToEntity.end(); ++spriteIt) {
            if (spriteIt->second == it->second) {
                spriteNameToEntity.erase(spriteIt);
                break;
            }
        }
        delete it->second;
        spriteNameToEntity.erase(it);
    } else {
        std::cerr << "Entity with name: " << name << " not found." << std::endl;
    }
}

void EntityManager::UpdateAllEntities() {
    for (auto& pair : spriteNameToEntity) {
>>>>>>> Stashed changes
        pair.second->Update();
    }
}

