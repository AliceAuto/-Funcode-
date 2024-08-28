#include "EntityManager.h"
#include "PlayerController.h"
#include <iostream>
#include "headers\NonInteractiveObject .h"
#include "Button.h"
// ���캯����ʼ��
EntityManager::EntityManager(): Id_couter(0)

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
	  
    Json::Reader reader;
    Json::Value root;

    // ���� JSON �ַ���
    if (reader.parse(jsonString, root)) {  
        std::string typeName = root.get("TypeName", "").asString();
        

        if (typeName == "Player")
			{
				entity = CreateEntityInstance("Player", root);
			}
		else if (typeName == "PhysicalObject")
			{
				entity = CreateEntityInstance("PhysicalObject", root);
			}
		else if (typeName == "ObstacleObject")
			{
				entity = CreateEntityInstance("ObstacleObject", root);
			}
		else if (typeName == "Button")
			{
				entity = CreateEntityInstance("Button", root);
			}


        if (entity) 
		{

            const std::string ID= "ID_"+std::to_string(++Id_couter)+"_";
			entity->ID = ID;
            spriteNameToEntity[ID] = entity; // �洢����������ʵ���ӳ��
            return ID;

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
		std::string resourceBag = root.get("resourceBag", "").asString();
		

        return new PlayerController(posX, posY,resourceBag);
    }
    //�����ϰ�����
	else if (type == "NonInteractiveObject") {
		float posX = static_cast<float>(root.get("posX", 0.0).asDouble());
		float posY = static_cast<float>(root.get("posY", 0.0).asDouble());
		std::string resourceBag = root.get("resourceBag", "").asString();
        return new NonInteractiveObject(posX, posY,resourceBag);
    }
	//
	else if (type == "PhysicalObject") {
		float posX = static_cast<float>(root.get("posX", 0.0).asDouble());
		float posY = static_cast<float>(root.get("posY", 0.0).asDouble());
		std::string resourceBag = root.get("resourceBag", "").asString();
        return new PhysicalObject(posX, posY,resourceBag);
    }
	//
	else if (type == "ObstacleObject") {
		float posX = static_cast<float>(root.get("posX", 0.0).asDouble());
		float posY = static_cast<float>(root.get("posY", 0.0).asDouble());
		std::string resourceBag = root.get("resourceBag", "").asString();
        return new ObstacleObject(posX, posY,resourceBag);
    }
	//
	else if (type == "Button") {
		float posX = static_cast<float>(root.get("posX", 0.0).asDouble());
		float posY = static_cast<float>(root.get("posY", 0.0).asDouble());
		std::string resourceBag = root.get("resourceBag", "").asString();
		std::string label = root.get("label", "").asString();
        return new Button(posX, posY,resourceBag,label);
    }
	//


    return nullptr;
}

// ��ȡָ�� ID ��ʵ��
Entity* EntityManager::GetEntity(const std::string& name)
{
    auto it =  spriteNameToEntity.find(name);
    if (it !=  spriteNameToEntity.end()) {
        return it->second;
    }

    return nullptr;
}

// ���ݾ������ƻ�ȡʵ��
Entity* EntityManager::GetEntityBySpriteName(const std::string& spriteName)
{
    auto it = spriteNameToEntity.find(spriteName);
    if (it != spriteNameToEntity.end()) {
        return it->second;
    }
   
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
//��������ʵ��
void EntityManager::LoadAllEntitys(){
LogManager::Log("��Դ������.....");

for (auto pair :this->spriteNameToEntity){
	if(pair.second){
	pair.second->Init();
	LogManager::Log(pair.first+":���سɹ�.		<Bind>");}
	
}

}
//�ֽ����е�ʵ����Դ
void EntityManager::breakDownAllEntitys(){
LogManager::Log("��Դ�ֽ���.....");



for (auto entityName :this->spriteNameToEntity){
	entityName.second->breakdown();
	LogManager::Log(entityName.first+":�ֽ�ɹ�.		<BreakBind>");
}

}

// ��������ʵ��
void EntityManager::Update()
{
    for (auto& pair : spriteNameToEntity) {
        pair.second->Update();
        // ������������Ӹ���ĸ����߼�
    }

}
