#include "ObjectManager.h"
#include "PlayerController.h"
#include <iostream>
#include "headers\NonInteractiveObject .h"
#include "IMouseUi.h"
#include "BindPoint.h"



//_______________________________________________________________________________________________________________________
//=======================================================================================================================


//[˵��]
// ���캯����ʼ��
//_______________________________________________
	ObjectManager::ObjectManager(): Id_couter(0)
	{
	}
//_______________________________________________




//[˵��]
// �����������ͷ�������Դ
//____________________________________________________________
	ObjectManager::~ObjectManager()
	{
		breakDownAllObjects();
		for (auto& pair : spriteNameToObject) 
		{
			delete pair.second;
		}
		spriteNameToObject.clear(); // ���������Ƶ�ʵ���ӳ��
	}
//____________________________________________________________





//[˵��]
// �����µ�ʵ��ʵ������������Ψһ��ʶ��
//___________________________________________________________________________________________________
	std::string ObjectManager::CreateObject(const std::string& jsonString)
	{
		Object* object = nullptr;
		Json::Reader reader;
		Json::Value root;
		// ���� JSON �ַ���
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
				spriteNameToObject[ID] = object; // �洢����������ʵ���ӳ��
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
	Object* ObjectManager::CreateObjectInstance(const std::string& type, Json::Value root)
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
		//�󶨵�
		else if (type == "UI_BindPoint"){
			float posX = static_cast<float>(root.get("posX", 0.0).asDouble());
			float posY = static_cast<float>(root.get("posY", 0.0).asDouble());
			return new BindPoint(posX, posY);
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
// ���ݾ������ƻ�ȡʵ��
//___________________________________________________________________________________
	Object* ObjectManager::GetObjectBySpriteName(const std::string& spriteName)
	{
		
    std::string numberStr; // �����洢������ID_x

    // ���� "ID_" ��λ�ò���ȡ�������ֲ���
    size_t startPos = spriteName.find("ID_");
    if (startPos == std::string::npos) {
        LogManager::Log("Failed to find 'ID_' in spriteName: " + spriteName);
        return nullptr;
    }

    startPos += 3; // ���� "ID_" ����λ���ҵ����ֵ���ʼλ��
    size_t endPos = spriteName.find('_', startPos); // �� "ID_" ֮��ʼ�ҵڶ��� '_'

    // ȷ������λ�úϷ�
    if (endPos != std::string::npos) {
        // ��ȡ�ӿ�ͷ���ڶ��� '_' Ϊֹ�Ĳ��֣��� "ID_x"
        numberStr = spriteName.substr(0, endPos);
    } else {
        LogManager::Log("Failed to parse spriteName: " + spriteName);
        return nullptr;
    }

    LogManager::Log("Parsed sprite ID: " + numberStr);

    // ���Ҷ���
    auto it = spriteNameToObject.find(numberStr+"_");
    if (it != spriteNameToObject.end()) {
        return it->second;
    }

    LogManager::Log("Object not found for spriteName: " + numberStr);
    return nullptr;
	}
//___________________________________________________________________________________






//[˵��]
// ɾ��ָ�� ID ��ʵ��
//_______________________________________________________________________________________________________________________
	void ObjectManager::DeleteObject(const std::string& name)
	{
		auto it = spriteNameToObject.find(name);
		if (it !=spriteNameToObject.end()) 
		{
			// �Ӿ�������ӳ����ɾ��
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






//[˵��]
//��������ʵ��
//__________________________________________________________________
	void ObjectManager::LoadAllObjects()
	{
		LogManager::Log("��Դ������.....");
		for (auto pair :this->spriteNameToObject)
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
	void ObjectManager::breakDownAllObjects()
	{
		LogManager::Log("��Դ�ֽ���.....");
		for (auto entityName :this->spriteNameToObject)
		{
			entityName.second->breakdown();
			LogManager::Log(entityName.first+":�ֽ�ɹ�.		<BreakBind>");
		}

	}
//_______________________________________________________________________________________







//[˵��]
// ��������ʵ��
//____________________________________________________
	void ObjectManager::Update()
	{
		for (auto& pair : spriteNameToObject) 
		{
			pair.second->Update();
			// ������������Ӹ���ĸ����߼�
		}
	}
//____________________________________________________







//_______________________________________________________________________________________________________________________
//=======================================================================================================================
