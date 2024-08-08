#include "ResourceBag.h"
#include "Logger.h"
#include <iostream>
#include <fstream>
#include <json/json.h>

ResourceBag::ResourceBag() : running(nullptr), Character(nullptr) {
    LogManager::Log("ResourceBag Ĭ�Ϲ��캯�������á�");
}

ResourceBag::ResourceBag(const std::string& runningTag, const std::string& characterTag) 
    : running(nullptr), Character(nullptr) {
    LogManager::Log("ResourceBag �������Ĺ��캯�������ã�runningTag: " + runningTag + "��characterTag: " + characterTag);
    LoadResourcesFromTags(runningTag, characterTag);
}

ResourceBag::~ResourceBag() {
    LogManager::Log("ResourceBag �������������á�");
    Unload();
}

void ResourceBag::Unload() {
    LogManager::Log("ResourceBag ����ж����Դ��");
    if (running) {
        LogManager::Log("����ɾ�� running ��Դ��");
        delete running;
        running = nullptr;
    }
    if (Character) {
        LogManager::Log("����ɾ�� Character ��Դ��");
        delete Character;
        Character = nullptr;
    }
	//
}

void ResourceBag::LoadResourcesFromTags(const std::string& runningTag, const std::string& characterTag) {
    LogManager::Log("���ڼ�����Դ��runningTag: " + runningTag + "��characterTag: " + characterTag);
    
    this->running = GetSoundFromTag(runningTag);
    this->Character = GetSpriteFromTag(characterTag);

    LogManager::Log("��Դ���سɹ���");
}

CSound* ResourceBag::GetSoundFromTag(const std::string& tag) {
    LogManager::Log("���ݱ�ǩ��ȡ������Դ: " + tag);
    // ȷ�� CSound ���캯���Ͳ�����ȷ
    return new CSound(tag.c_str(), 1, 1); // ����ֻ��ʾ��
}

CAnimateSprite* ResourceBag::GetSpriteFromTag(const std::string& tag) {
    LogManager::Log("���ݱ�ǩ��ȡ������Դ: " + tag);
    // ȷ�� CAnimateSprite ���캯���Ͳ�����ȷ
    return new CAnimateSprite(tag.c_str()); // ����ֻ��ʾ��
}










void LoadResourcesFromJSON(std::map<std::string, ResourceBag *> & resourceBagPtrs, const std::string& filename) {
    LogManager::Log("�� JSON �ļ�������Դ���ļ���: " + filename);
    
    std::ifstream file(filename);
    if (!file.is_open()) {
        LogManager::Log("�޷����ļ�: " + filename);
       
        return;
    }


	LogManager::Log("�ɹ����ļ�");



	LogManager::Log("----------------------------------------------------------");

    Json::Value root;
    file >> root;

    for (const auto& key : root.getMemberNames()) {
        const Json::Value& value = root[key];

        if (value.isMember("running") && value.isMember("Character")) {
            std::string runningTag = value["running"].asString();
            std::string characterTag = value["Character"].asString();

            // ����һ���µ� ResourceBag ʵ����ֱ�Ӵ洢�� map ��
			LogManager::Log("�ܶ�����: "+runningTag);
			LogManager::Log("����/ʵ�徫��: "+characterTag);
            resourceBagPtrs[key] = new ResourceBag(runningTag, characterTag);
            LogManager::Log("�Ѽ�����Դ���ؼ���: " + key);
			LogManager::Log("----------------------------------------------------------");

        } else {
            LogManager::Log("��Ч�� JSON ��ʽ���ؼ���: " + key);
         
        }
    }

    LogManager::Log("�� JSON �ļ�������Դ��ɡ�");
}
