#include "ResourceBag.h"
#include <iostream>
#include <fstream>




//__________________________________________________________________________________________________________________________________________________________________________________
//==================================================================================================================================================================================

//[˵��]
	const std::string ResourceBag::resourceFilename = "resource.json";


//[˵��]
//__________________________________________________________________________________________
	ResourceBag::ResourceBag(const std::string & Entity_ID):IdCounter(0),Entity_ID(Entity_ID)
	{
		LogManager::Log("��Ϣ: ResourceBag ��ʼ�����.");
	}
//__________________________________________________________________________________________





//[˵��]
//_________________________________________________________________________
	ResourceBag::~ResourceBag() {

		LogManager::Log("��Ϣ: ResourceBag ������������, ��ʼ��Դ����.");
		// ��Դ���� shared_ptr �Զ�����
		container_.clear();
		LogManager::Log("��Ϣ: ResourceBag ��Դ�������.");
	}
//_________________________________________________________________________






//[˵��]
//____________________________________________________________________________________________________________________________________
	bool ResourceBag::LoadFromJson(const std::string& packageName) {
		try {
		
			LogManager::Log("��Ϣ: �� JSON �ļ�������Դ: " + resourceFilename);
			std::ifstream file(resourceFilename.c_str(), std::ifstream::binary);
			if (!file.is_open()) {
				throw std::runtime_error("�޷����ļ�: " + resourceFilename);
			}

			Json::Value root;
			Json::Reader reader;
			if (!reader.parse(file, root)) {
				throw std::runtime_error("���� JSON �ļ�ʧ��");
			}

			const Json::Value& resources = root[packageName];
			if (!resources.isObject()) {
				throw std::runtime_error("��Ч����Դ��: " + packageName);
			}

			for (const auto& typeName : resources.getMemberNames()) {
				const Json::Value& resourceInfo = resources[typeName];
				LogManager::Log(typeName);
				if (typeName == "CAnimateSprite") {
					for (const auto& name : resourceInfo.getMemberNames()) {
						std::string resourceName = resourceInfo[name].asString();
						std::string id = Entity_ID+std::to_string(++IdCounter);
						LogManager::Log("		��Ϣ: ��������, ID: " + id + ", ��Դ����: " + resourceName);
						auto sprite = std::make_shared<CAnimateSprite>(id.c_str(), resourceName.c_str());
						sprite->SetSpritePosition(0, 0);

						if(sprite)AddResource(name, sprite);
					}
				} 
				else if (typeName == "CSound") {
					for (const auto& name : resourceInfo.getMemberNames()) {
						std::string resourceName = resourceInfo[name].asString();
						std::string id = Entity_ID+std::to_string(++IdCounter);
						LogManager::Log("		��Ϣ: ������Ч, ID: " + id + ", ��Դ����: " + resourceName);
						auto sound = std::make_shared<CSound>(resourceName.c_str(), static_cast<float>(1), static_cast<float>(1));
						if (sound)AddResource(name, sound);
					}
				}
				else if (typeName == "CEffect") {
					for (const auto& name : resourceInfo.getMemberNames()) {
						std::string resourceName = resourceInfo[name].asString();
						std::string id = Entity_ID+std::to_string(++IdCounter);
						LogManager::Log("		��Ϣ: ������Ч, ID: " + id + ", ��Դ����: " + resourceName);
						auto cEffect = std::make_shared<CEffect>(resourceName.c_str(), id.c_str(), static_cast<float>(1));
						if (cEffect)AddResource(name, cEffect);

					}
				}
				else if (typeName == "CTextSprite") {
					for (const auto& name : resourceInfo.getMemberNames()) {
						std::string resourceName = resourceInfo[name].asString();
						std::string id = Entity_ID+std::to_string(++IdCounter);
						LogManager::Log("		��Ϣ: ��������, ID: " + id + ", ��Դ����: " + resourceName);
						auto cTextSprite = std::make_shared<CTextSprite>(id.c_str(), resourceName.c_str());
						if (cTextSprite)AddResource(name, cTextSprite);
					}
				}
				else if (typeName == "CStaticSprite") {
				
					for (const auto& name : resourceInfo.getMemberNames()) {
					
						std::string resourceName = resourceInfo[name].asString();
						std::string id = Entity_ID+std::to_string(++IdCounter);
						LogManager::Log("		��Ϣ: ������̬����, ID: " + id + ", ��Դ����: " + resourceName);
						auto cStaticSprite = std::make_shared<CStaticSprite>(id.c_str(), resourceName.c_str());
						if (cStaticSprite)AddResource(name, cStaticSprite);
			
					
					}
				}
			

				else {
					LogManager::Log("����: δʶ�����Դ����: " + typeName);
				}
			}

			LogManager::Log("��Ϣ: ��Դ�������, ��Դ������: " + packageName);
			return true;
		} catch (const std::exception& e) {
			LogManager::Log("����: " + std::string(e.what()));
			return false;
		}
	}
//____________________________________________________________________________________________________________________________________







//__________________________________________________________________________________________________________________________________________________________________________________
//==================================================================================================================================================================================