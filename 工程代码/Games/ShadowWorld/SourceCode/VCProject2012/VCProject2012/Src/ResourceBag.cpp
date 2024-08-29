#include "ResourceBag.h"
#include <iostream>
#include <fstream>




//__________________________________________________________________________________________________________________________________________________________________________________
//==================================================================================================================================================================================

//[说明]
	const std::string ResourceBag::resourceFilename = "resource.json";


//[说明]
//__________________________________________________________________________________________
	ResourceBag::ResourceBag(const std::string & Entity_ID):IdCounter(0),Entity_ID(Entity_ID)
	{
		LogManager::Log("信息: ResourceBag 初始化完成.");
	}
//__________________________________________________________________________________________





//[说明]
//_________________________________________________________________________
	ResourceBag::~ResourceBag() {

		LogManager::Log("信息: ResourceBag 析构函数调用, 开始资源清理.");
		// 资源将由 shared_ptr 自动清理
		container_.clear();
		LogManager::Log("信息: ResourceBag 资源清理完成.");
	}
//_________________________________________________________________________






//[说明]
//____________________________________________________________________________________________________________________________________
	bool ResourceBag::LoadFromJson(const std::string& packageName) {
		try {
		
			LogManager::Log("信息: 从 JSON 文件加载资源: " + resourceFilename);
			std::ifstream file(resourceFilename.c_str(), std::ifstream::binary);
			if (!file.is_open()) {
				throw std::runtime_error("无法打开文件: " + resourceFilename);
			}

			Json::Value root;
			Json::Reader reader;
			if (!reader.parse(file, root)) {
				throw std::runtime_error("解析 JSON 文件失败");
			}

			const Json::Value& resources = root[packageName];
			if (!resources.isObject()) {
				throw std::runtime_error("无效的资源包: " + packageName);
			}

			for (const auto& typeName : resources.getMemberNames()) {
				const Json::Value& resourceInfo = resources[typeName];
				LogManager::Log(typeName);
				if (typeName == "CAnimateSprite") {
					for (const auto& name : resourceInfo.getMemberNames()) {
						std::string resourceName = resourceInfo[name].asString();
						std::string id = Entity_ID+std::to_string(++IdCounter);
						LogManager::Log("		信息: 创建动画, ID: " + id + ", 资源名称: " + resourceName);
						auto sprite = std::make_shared<CAnimateSprite>(id.c_str(), resourceName.c_str());
						sprite->SetSpritePosition(0, 0);

						if(sprite)AddResource(name, sprite);
					}
				} 
				else if (typeName == "CSound") {
					for (const auto& name : resourceInfo.getMemberNames()) {
						std::string resourceName = resourceInfo[name].asString();
						std::string id = Entity_ID+std::to_string(++IdCounter);
						LogManager::Log("		信息: 创建音效, ID: " + id + ", 资源名称: " + resourceName);
						auto sound = std::make_shared<CSound>(resourceName.c_str(), static_cast<float>(1), static_cast<float>(1));
						if (sound)AddResource(name, sound);
					}
				}
				else if (typeName == "CEffect") {
					for (const auto& name : resourceInfo.getMemberNames()) {
						std::string resourceName = resourceInfo[name].asString();
						std::string id = Entity_ID+std::to_string(++IdCounter);
						LogManager::Log("		信息: 创建特效, ID: " + id + ", 资源名称: " + resourceName);
						auto cEffect = std::make_shared<CEffect>(resourceName.c_str(), id.c_str(), static_cast<float>(1));
						if (cEffect)AddResource(name, cEffect);

					}
				}
				else if (typeName == "CTextSprite") {
					for (const auto& name : resourceInfo.getMemberNames()) {
						std::string resourceName = resourceInfo[name].asString();
						std::string id = Entity_ID+std::to_string(++IdCounter);
						LogManager::Log("		信息: 创建字体, ID: " + id + ", 资源名称: " + resourceName);
						auto cTextSprite = std::make_shared<CTextSprite>(id.c_str(), resourceName.c_str());
						if (cTextSprite)AddResource(name, cTextSprite);
					}
				}
				else if (typeName == "CStaticSprite") {
				
					for (const auto& name : resourceInfo.getMemberNames()) {
					
						std::string resourceName = resourceInfo[name].asString();
						std::string id = Entity_ID+std::to_string(++IdCounter);
						LogManager::Log("		信息: 创建静态精灵, ID: " + id + ", 资源名称: " + resourceName);
						auto cStaticSprite = std::make_shared<CStaticSprite>(id.c_str(), resourceName.c_str());
						if (cStaticSprite)AddResource(name, cStaticSprite);
			
					
					}
				}
			

				else {
					LogManager::Log("错误: 未识别的资源类型: " + typeName);
				}
			}

			LogManager::Log("信息: 资源加载完成, 资源包名称: " + packageName);
			return true;
		} catch (const std::exception& e) {
			LogManager::Log("错误: " + std::string(e.what()));
			return false;
		}
	}
//____________________________________________________________________________________________________________________________________







//__________________________________________________________________________________________________________________________________________________________________________________
//==================================================================================================================================================================================