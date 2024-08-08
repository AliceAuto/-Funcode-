#include "ResourceBag.h"
#include "Logger.h"
#include <iostream>
#include <fstream>
#include <json/json.h>

ResourceBag::ResourceBag() : running(nullptr), Character(nullptr) {
    LogManager::Log("ResourceBag 默认构造函数被调用。");
}

ResourceBag::ResourceBag(const std::string& runningTag, const std::string& characterTag) 
    : running(nullptr), Character(nullptr) {
    LogManager::Log("ResourceBag 带参数的构造函数被调用，runningTag: " + runningTag + "，characterTag: " + characterTag);
    LoadResourcesFromTags(runningTag, characterTag);
}

ResourceBag::~ResourceBag() {
    LogManager::Log("ResourceBag 析构函数被调用。");
    Unload();
}

void ResourceBag::Unload() {
    LogManager::Log("ResourceBag 正在卸载资源。");
    if (running) {
        LogManager::Log("正在删除 running 资源。");
        delete running;
        running = nullptr;
    }
    if (Character) {
        LogManager::Log("正在删除 Character 资源。");
        delete Character;
        Character = nullptr;
    }
	//
}

void ResourceBag::LoadResourcesFromTags(const std::string& runningTag, const std::string& characterTag) {
    LogManager::Log("正在加载资源，runningTag: " + runningTag + "，characterTag: " + characterTag);
    
    this->running = GetSoundFromTag(runningTag);
    this->Character = GetSpriteFromTag(characterTag);

    LogManager::Log("资源加载成功。");
}

CSound* ResourceBag::GetSoundFromTag(const std::string& tag) {
    LogManager::Log("根据标签获取声音资源: " + tag);
    // 确保 CSound 构造函数和参数正确
    return new CSound(tag.c_str(), 1, 1); // 这里只是示例
}

CAnimateSprite* ResourceBag::GetSpriteFromTag(const std::string& tag) {
    LogManager::Log("根据标签获取精灵资源: " + tag);
    // 确保 CAnimateSprite 构造函数和参数正确
    return new CAnimateSprite(tag.c_str()); // 这里只是示例
}










void LoadResourcesFromJSON(std::map<std::string, ResourceBag *> & resourceBagPtrs, const std::string& filename) {
    LogManager::Log("从 JSON 文件加载资源，文件名: " + filename);
    
    std::ifstream file(filename);
    if (!file.is_open()) {
        LogManager::Log("无法打开文件: " + filename);
       
        return;
    }


	LogManager::Log("成功打开文件");



	LogManager::Log("----------------------------------------------------------");

    Json::Value root;
    file >> root;

    for (const auto& key : root.getMemberNames()) {
        const Json::Value& value = root[key];

        if (value.isMember("running") && value.isMember("Character")) {
            std::string runningTag = value["running"].asString();
            std::string characterTag = value["Character"].asString();

            // 创建一个新的 ResourceBag 实例并直接存储到 map 中
			LogManager::Log("跑动声音: "+runningTag);
			LogManager::Log("动画/实体精灵: "+characterTag);
            resourceBagPtrs[key] = new ResourceBag(runningTag, characterTag);
            LogManager::Log("已加载资源，关键字: " + key);
			LogManager::Log("----------------------------------------------------------");

        } else {
            LogManager::Log("无效的 JSON 格式，关键字: " + key);
         
        }
    }

    LogManager::Log("从 JSON 文件加载资源完成。");
}
