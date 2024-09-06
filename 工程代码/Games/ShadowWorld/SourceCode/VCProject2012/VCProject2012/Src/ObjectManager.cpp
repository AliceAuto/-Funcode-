#include "ObjectManager.h"
#include "PlayerController.h"
#include <iostream>
#include "headers\NonInteractiveObject .h"
#include "IMouseUi.h"
#include "BindPoint.h"



//_______________________________________________________________________________________________________________________
//=======================================================================================================================


//[说明]
// 构造函数初始化
//_______________________________________________
	ObjectManager::ObjectManager(): Id_couter(0)
	{
	}
//_______________________________________________




//[说明]
// 析构函数，释放所有资源
//____________________________________________________________
	ObjectManager::~ObjectManager()
	{
		breakDownAllObjects();
		for (auto& pair : spriteNameToObject) 
		{
			delete pair.second;
		}
		spriteNameToObject.clear(); // 清理精灵名称到实体的映射
	}
//____________________________________________________________





//[说明]
// 创建新的实体实例，并返回其唯一标识符
//___________________________________________________________________________________________________
	std::string ObjectManager::CreateObject(const std::string& jsonString)
	{
		Object* object = nullptr;
		Json::Reader reader;
		Json::Value root;
		// 解析 JSON 字符串
		if (reader.parse(jsonString, root)) 
		{  
			std::string typeName = root.get("TypeName", "").asString();
			if (typeName == "Player")
				{
					object = CreateObjectInstance("Player", root);
				}
			else if (typeName == "PhysicalObject")
				{
					object = CreateObjectInstance("PhysicalObject", root);
				}
			else if (typeName == "ObstacleObject")
				{
					object = CreateObjectInstance("ObstacleObject", root);
				}
			else if (typeName == "Button_Text&Photo")
				{
					object = CreateObjectInstance("Button_Text&Photo", root);
				}
			else if (typeName == "Button_ArtPhoto")
				{
					object = CreateObjectInstance("Button_ArtPhoto", root);
				}
			else if (typeName == "Bullet")
				{
					object = CreateObjectInstance("Bullet", root);
				}
			else if (typeName == "DataShower_TextWin")
				{
					object = CreateObjectInstance("Bullet", root);
				}
			else if (typeName == "IMouse_DragUI")
				{
					object = CreateObjectInstance("IMouse_DragUI", root);
				}
			else if (typeName == "UI_BindPoint")
				{
					object = CreateObjectInstance("UI_BindPoint", root);
				}
			if (object) 
			{
				const std::string ID= "ID_"+std::to_string(++Id_couter)+"_";
				object->ID = ID;
				spriteNameToObject[ID] = object; // 存储精灵名称与实体的映射
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
	Object* ObjectManager::CreateObjectInstance(const std::string& type, Json::Value root)
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
		else if (type == "Button_Text&Photo"){
			float posX = static_cast<float>(root.get("posX", 0.0).asDouble());
			float posY = static_cast<float>(root.get("posY", 0.0).asDouble());
			std::string resourceBag = root.get("resourceBag", "").asString();
			std::string label = root.get("label", "").asString();
			return new RenderButton(posX, posY,resourceBag,label);
		}
		else if (type == "Button_ArtPhoto"){
			float posX = static_cast<float>(root.get("posX", 0.0).asDouble());
			float posY = static_cast<float>(root.get("posY", 0.0).asDouble());
			std::string resourceBag = root.get("resourceBag", "").asString();
			std::string label = root.get("label", "").asString();
			return new ArtButton(posX, posY,resourceBag,label);
		}

		else if (type == "DataShower_TextWin"){
			float posX = static_cast<float>(root.get("posX", 0.0).asDouble());
			float posY = static_cast<float>(root.get("posY", 0.0).asDouble());
			std::string resourceBag = root.get("resourceBag", "").asString();
			std::string label = root.get("label", "").asString();
			return new ArtButton(posX, posY,resourceBag,label);
		}
		else if (type == "IMouse_DragUI"){
			float posX = static_cast<float>(root.get("posX", 0.0).asDouble());
			float posY = static_cast<float>(root.get("posY", 0.0).asDouble());
			std::string resourceBag = root.get("resourceBag", "").asString();
			std::string label = root.get("label", "").asString();
			return new DraggableBlock(posX, posY,resourceBag,label);
		}
		//绑定点
		else if (type == "UI_BindPoint"){
			float posX = static_cast<float>(root.get("posX", 0.0).asDouble());
			float posY = static_cast<float>(root.get("posY", 0.0).asDouble());
			return new BindPoint(posX, posY);
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
// 根据精灵名称获取实体
//___________________________________________________________________________________
	Object* ObjectManager::GetObjectBySpriteName(const std::string& spriteName)
	{
		
    std::string numberStr; // 用来存储构建的ID_x

    // 查找 "ID_" 的位置并提取其后的数字部分
    size_t startPos = spriteName.find("ID_");
    if (startPos == std::string::npos) {
        LogManager::Log("Failed to find 'ID_' in spriteName: " + spriteName);
        return nullptr;
    }

    startPos += 3; // 跳过 "ID_" 这三位，找到数字的起始位置
    size_t endPos = spriteName.find('_', startPos); // 从 "ID_" 之后开始找第二个 '_'

    // 确保解析位置合法
    if (endPos != std::string::npos) {
        // 提取从开头到第二个 '_' 为止的部分，即 "ID_x"
        numberStr = spriteName.substr(0, endPos);
    } else {
        LogManager::Log("Failed to parse spriteName: " + spriteName);
        return nullptr;
    }

    LogManager::Log("Parsed sprite ID: " + numberStr);

    // 查找对象
    auto it = spriteNameToObject.find(numberStr+"_");
    if (it != spriteNameToObject.end()) {
        return it->second;
    }

    LogManager::Log("Object not found for spriteName: " + numberStr);
    return nullptr;
	}
//___________________________________________________________________________________






//[说明]
// 删除指定 ID 的实体
//_______________________________________________________________________________________________________________________
	void ObjectManager::DeleteObject(const std::string& name)
	{
		auto it = spriteNameToObject.find(name);
		if (it !=spriteNameToObject.end()) 
		{
			// 从精灵名称映射中删除
			for (auto spriteIt = spriteNameToObject.begin(); spriteIt != spriteNameToObject.end(); ++spriteIt)
			{
				if (spriteIt->second == it->second)
				{
					spriteNameToObject.erase(spriteIt);
					break;
				}
			}
			
			delete it->second;
		   spriteNameToObject.erase(it);
		}
		else 
		{ 
		}
	}
//_______________________________________________________________________________________________________________________






//[说明]
//加载所有实体
//__________________________________________________________________
	void ObjectManager::LoadAllObjects()
	{
		LogManager::Log("资源加载中.....");
		for (auto pair :this->spriteNameToObject)
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
	void ObjectManager::breakDownAllObjects()
	{
		LogManager::Log("资源分解中.....");
		for (auto entityName :this->spriteNameToObject)
		{
			entityName.second->breakdown();
			LogManager::Log(entityName.first+":分解成功.		<BreakBind>");
		}

	}
//_______________________________________________________________________________________







//[说明]
// 更新所有实体
//____________________________________________________
	void ObjectManager::Update()
	{
		for (auto& pair : spriteNameToObject) 
		{
			pair.second->Update();
			// 可以在这里添加更多的更新逻辑
		}
	}
//____________________________________________________







//_______________________________________________________________________________________________________________________
//=======================================================================================================================
