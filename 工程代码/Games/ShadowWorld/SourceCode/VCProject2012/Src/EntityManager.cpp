#include "EntityManager.h"
#include "PlayerController.h"
#include <iostream>
#include "headers\NonInteractiveObject .h"
// ���캯����ʼ��
EntityManager::EntityManager()

{
}

// �����������ͷ�������Դ
EntityManager::~EntityManager()
{
    for (auto& pair : spriteNameToEntity) {
        delete pair.second;
    }

    spriteNameToEntity.clear(); // ���������Ƶ�ʵ���ӳ��
}

// �����µ�ʵ��ʵ������������Ψһ��ʶ��
std::string EntityManager::CreateEntity(const std::string& jsonString)
{
	  Entity* entity = nullptr;
	  std::string resourceBag;
    Json::Reader reader;
    Json::Value root;

    // ���� JSON �ַ���
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
            spriteNameToEntity[name] = entity; // �洢����������ʵ���ӳ��
            return name;
        }
    } 
	else{LogManager::Log("��Դ����ʧ��");}

    return "";

}

// ���ݿ��������ʹ����µ�ʵ��ʵ��
Entity* EntityManager::CreateEntityInstance(const std::string& type, Json::Value root)
{    //���
    if (type == "Player") {
		float posX = static_cast<float>(root.get("posX", 0.0).asDouble());
		float posY = static_cast<float>(root.get("posY", 0.0).asDouble());
		

        return new PlayerController(posX, posY);
    }
    //�����ϰ�����
	else if (type == "Obstacle") {
		float posX = static_cast<float>(root.get("posX", 0.0).asDouble());
		float posY = static_cast<float>(root.get("posY", 0.0).asDouble());
        return new NonInteractiveObject(posX, posY);
    }

    return nullptr;
}

// ��ȡָ�� ID ��ʵ��
Entity* EntityManager::GetEntity(const std::string& name)
{
    auto it =  spriteNameToEntity.find(name);
    if (it !=  spriteNameToEntity.end()) {
        return it->second;
    }
    std::cerr << "Entity with ID: " << name << " not found." << std::endl;
    return nullptr;
}

// ���ݾ������ƻ�ȡʵ��
Entity* EntityManager::GetEntityBySpriteName(const std::string& spriteName)
{
    auto it = spriteNameToEntity.find(spriteName);
    if (it != spriteNameToEntity.end()) {
        return it->second;
    }
    std::cerr << "Entity with sprite name: " << spriteName << " not found." << std::endl;
    return nullptr;
}

// ɾ��ָ�� ID ��ʵ��
void EntityManager::DeleteEntity(const std::string& name)
{
    auto it = spriteNameToEntity.find(name);
    if (it !=spriteNameToEntity.end()) {
        // �Ӿ�������ӳ����ɾ��
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

// ��������ʵ��
void EntityManager::UpdateAllEntities()
{
    for (auto& pair : spriteNameToEntity) {
        pair.second->Update();
        // ������������Ӹ���ĸ����߼�
    }
}
