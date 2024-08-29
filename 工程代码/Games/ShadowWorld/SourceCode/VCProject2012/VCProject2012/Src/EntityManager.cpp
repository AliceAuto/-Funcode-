#include "EntityManager.h"
#include "PlayerController.h"
#include <iostream>
#include "headers\NonInteractiveObject .h"
#include "Button.h"




//_______________________________________________________________________________________________________________________
//=======================================================================================================================


//[说明]
// 构造函数初始化
//_______________________________________________
	EntityManager::EntityManager(): Id_couter(0)
	{
	}
//_______________________________________________




//[说明]
// 析构函数，释放所有资源
//____________________________________________________________
	EntityManager::~EntityManager()
	{
		for (auto& pair : spriteNameToEntity) 
		{
			delete pair.second;
		}
		spriteNameToEntity.clear(); // 清理精灵名称到实体的映射
	}
//____________________________________________________________





//[说明]
// 创建新的实体实例，并返回其唯一标识符
//___________________________________________________________________________________________________
	std::string EntityManager::CreateEntity(const std::string& jsonString)
	{
		Entity* entity = nullptr;
		Json::Reader reader;
		Json::Value root;
		// 解析 JSON 字符串
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
				spriteNameToEntity[ID] = entity; // 存储精灵名称与实体的映射
				return ID;
			}
		} 
		else
		{LogManager::Log("资源加载失败");}

		return "";

	}
//___________________________________________________________________________________________________






//[说明]
// 根据控制器类型创建新的实体实例
	//___________________________________________________________________________________________________
	Entity* EntityManager::CreateEntityInstance(const std::string& type, Json::Value root)
	{    //玩家
		if (type == "Player") {
			float posX = static_cast<float>(root.get("posX", 0.0).asDouble());
			float posY = static_cast<float>(root.get("posY", 0.0).asDouble());
			std::string resourceBag = root.get("resourceBag", "").asString();
			return new PlayerController(posX, posY,resourceBag);
		}
		//规则障碍方块
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
		//子弹
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







//[说明]
// 获取指定 ID 的实体
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






//[说明]
// 根据精灵名称获取实体
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






//[说明]
// 删除指定 ID 的实体
//_______________________________________________________________________________________________________________________
	void EntityManager::DeleteEntity(const std::string& name)
	{
		auto it = spriteNameToEntity.find(name);
		if (it !=spriteNameToEntity.end()) 
		{
			// 从精灵名称映射中删除
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






//[说明]
//加载所有实体
//__________________________________________________________________
	void EntityManager::LoadAllEntitys()
	{
		LogManager::Log("资源加载中.....");
		for (auto pair :this->spriteNameToEntity)
		{
			if(pair.second)
			{
			pair.second->Init();
			LogManager::Log(pair.first+":加载成功.		<Bind>");
			}
		}
	}
//__________________________________________________________________







//[说明]
//分解所有的实体资源
//_______________________________________________________________________________________
	void EntityManager::breakDownAllEntitys()
	{
		LogManager::Log("资源分解中.....");
		for (auto entityName :this->spriteNameToEntity)
		{
			entityName.second->breakdown();
			LogManager::Log(entityName.first+":分解成功.		<BreakBind>");
		}

	}
//_______________________________________________________________________________________







//[说明]
// 更新所有实体
//____________________________________________________
	void EntityManager::Update()
	{
		for (auto& pair : spriteNameToEntity) 
		{
			pair.second->Update();
			// 可以在这里添加更多的更新逻辑
		}
	}
//____________________________________________________







//_______________________________________________________________________________________________________________________
//=======================================================================================================================
