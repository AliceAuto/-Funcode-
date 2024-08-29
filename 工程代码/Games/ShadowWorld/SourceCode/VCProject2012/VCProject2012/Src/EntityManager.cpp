#include "EntityManager.h"
#include "PlayerController.h"
#include <iostream>
#include "headers\NonInteractiveObject .h"
#include "Button.h"




//_______________________________________________________________________________________________________________________
//=======================================================================================================================


//[˵��]
// ���캯����ʼ��
//_______________________________________________
	EntityManager::EntityManager(): Id_couter(0)
	{
	}
//_______________________________________________




//[˵��]
// �����������ͷ�������Դ
//____________________________________________________________
	EntityManager::~EntityManager()
	{
		for (auto& pair : spriteNameToEntity) 
		{
			delete pair.second;
		}
		spriteNameToEntity.clear(); // ���������Ƶ�ʵ���ӳ��
	}
//____________________________________________________________





//[˵��]
// �����µ�ʵ��ʵ������������Ψһ��ʶ��
//___________________________________________________________________________________________________
	std::string EntityManager::CreateEntity(const std::string& jsonString)
	{
		Entity* entity = nullptr;
		Json::Reader reader;
		Json::Value root;
		// ���� JSON �ַ���
		if (reader.parse(jsonString, root)) 
		{  
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
			else if (typeName == "Bullet")
				{
					entity = CreateEntityInstance("Bullet", root);
				}
			if (entity) 
			{
				const std::string ID= "ID_"+std::to_string(++Id_couter)+"_";
				entity->ID = ID;
				spriteNameToEntity[ID] = entity; // �洢����������ʵ���ӳ��
				return ID;
			}
		} 
		else
		{LogManager::Log("��Դ����ʧ��");}

		return "";

	}
//___________________________________________________________________________________________________






//[˵��]
// ���ݿ��������ʹ����µ�ʵ��ʵ��
	//___________________________________________________________________________________________________
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
		//�ӵ�
		else if (type == "Bullet") {
        float posX = static_cast<float>(root.get("posX", 0.0).asDouble());
        float posY = static_cast<float>(root.get("posY", 0.0).asDouble());
        std::string resourceBag = root.get("resourceBag", "").asString();
        float speed = static_cast<float>(root.get("speed", 0.0).asDouble());
        float direction = static_cast<float>(root.get("direction", 0.0).asDouble());
        return new Bullet(posX, posY, resourceBag, speed, direction);
    }
		return nullptr;
	}
//___________________________________________________________________________________________________







//[˵��]
// ��ȡָ�� ID ��ʵ��
//________________________________________________________________
	Entity* EntityManager::GetEntity(const std::string& name)
	{
		auto it =  spriteNameToEntity.find(name);
		if (it !=  spriteNameToEntity.end()) 
		{
			return it->second;
		}
		return nullptr;
	}
//________________________________________________________________






//[˵��]
// ���ݾ������ƻ�ȡʵ��
//___________________________________________________________________________________
	Entity* EntityManager::GetEntityBySpriteName(const std::string& spriteName)
	{
		auto it = spriteNameToEntity.find(spriteName);
		if (it != spriteNameToEntity.end()) 
		{
			return it->second;
		}
		return nullptr;
	}
//___________________________________________________________________________________






//[˵��]
// ɾ��ָ�� ID ��ʵ��
//_______________________________________________________________________________________________________________________
	void EntityManager::DeleteEntity(const std::string& name)
	{
		auto it = spriteNameToEntity.find(name);
		if (it !=spriteNameToEntity.end()) 
		{
			// �Ӿ�������ӳ����ɾ��
			for (auto spriteIt = spriteNameToEntity.begin(); spriteIt != spriteNameToEntity.end(); ++spriteIt)
			{
				if (spriteIt->second == it->second)
				{
					spriteNameToEntity.erase(spriteIt);
					break;
				}
			}
			delete it->second;
		   spriteNameToEntity.erase(it);
		}
		else 
		{ 
		}
	}
//_______________________________________________________________________________________________________________________






//[˵��]
//��������ʵ��
//__________________________________________________________________
	void EntityManager::LoadAllEntitys()
	{
		LogManager::Log("��Դ������.....");
		for (auto pair :this->spriteNameToEntity)
		{
			if(pair.second)
			{
			pair.second->Init();
			LogManager::Log(pair.first+":���سɹ�.		<Bind>");
			}
		}
	}
//__________________________________________________________________







//[˵��]
//�ֽ����е�ʵ����Դ
//_______________________________________________________________________________________
	void EntityManager::breakDownAllEntitys()
	{
		LogManager::Log("��Դ�ֽ���.....");
		for (auto entityName :this->spriteNameToEntity)
		{
			entityName.second->breakdown();
			LogManager::Log(entityName.first+":�ֽ�ɹ�.		<BreakBind>");
		}

	}
//_______________________________________________________________________________________







//[˵��]
// ��������ʵ��
//____________________________________________________
	void EntityManager::Update()
	{
		for (auto& pair : spriteNameToEntity) 
		{
			pair.second->Update();
			// ������������Ӹ���ĸ����߼�
		}
	}
//____________________________________________________







//_______________________________________________________________________________________________________________________
//=======================================================================================================================
