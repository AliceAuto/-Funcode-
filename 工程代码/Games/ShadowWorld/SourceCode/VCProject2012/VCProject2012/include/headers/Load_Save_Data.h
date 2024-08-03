#include <json/json.h>
#include <string>
#include <fstream>
#include <unordered_map>
#include <memory>
#include <iostream>
//xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
//xx											xx	
//xx					�浵ϵͳ				xx
//xx											xx	
//xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx






//xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
//============================================================================

// ����һ�����Ա���ͼ������ݵĻ���
class Savable {
public:
    virtual ~Savable() {}

    // �������ݵ�Json������
    virtual void save(Json::Value& json) const = 0;

    // ��Json�����м�������
    virtual void load(const Json::Value& json) = 0;
};


//============================================================================
//xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx







//xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
//============================================================================
// ����һ������࣬�̳���Savable
class Player : public Savable {
public:
    std::string name; // �������
    int level;        // ��ҵȼ�

    // ʵ�ֱ��溯������������ݱ��浽Json������
    void save(Json::Value& json) const override {
        json["name"] = name;
        json["level"] = level;
    }

    // ʵ�ּ��غ�������Json�����м����������
    void load(const Json::Value& json) override {
        name = json["name"].asString();
        level = json["level"].asInt();
    }
};


//============================================================================
//xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx









//xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
//============================================================================
// ����һ����Ϸ�����࣬�̳���Savable
class GameSettings : public Savable {
public:
    bool fullscreen;          // �Ƿ�ȫ��
    int resolutionWidth;      // �ֱ��ʿ��
    int resolutionHeight;     // �ֱ��ʸ߶�

    // ʵ�ֱ��溯��������Ϸ�������ݱ��浽Json������
    void save(Json::Value& json) const override {
        json["fullscreen"] = fullscreen;
        json["resolutionWidth"] = resolutionWidth;
        json["resolutionHeight"] = resolutionHeight;
    }

    // ʵ�ּ��غ�������Json�����м�����Ϸ��������
    void load(const Json::Value& json) override {
        fullscreen = json["fullscreen"].asBool();
        resolutionWidth = json["resolutionWidth"].asInt();
        resolutionHeight = json["resolutionHeight"].asInt();
    }
};
//============================================================================
//xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx









//xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
//============================================================================

// ����ϵͳ�࣬�������ݵı���ͼ���
class SaveSystem {
public:
    // ע��һ�����Ա�������ͼ����Ӧ�Ĵ�������
    void registerSavable(const std::string& typeName, std::unique_ptr<Savable> (*createFunc)()) {
        factoryMap[typeName] = createFunc;
    }

    // �����󱣴浽ָ���ļ�
    void save(const std::string& fileName, const std::unordered_map<std::string, std::unique_ptr<Savable>>& objects) {
        Json::Value root;  // ����һ����Json����
        // ����������Ҫ����Ķ���
        for (std::unordered_map<std::string, std::unique_ptr<Savable>>::const_iterator it = objects.begin(); it != objects.end(); ++it) {
            const std::string& typeName = it->first;
            const std::unique_ptr<Savable>& obj = it->second;
            Json::Value json; // ����һ��Json����洢�������������
            obj->save(json);  // ����������ݱ��浽Json������
            root[typeName] = json;  // ��Json������ӵ���Json������
        }
        std::ofstream file(fileName); // ��һ������ļ���
        file << root; // ��Json����д���ļ�
    }

    // ��ָ���ļ����ض���
    void load(const std::string& fileName, std::unordered_map<std::string, std::unique_ptr<Savable>>& objects) {
        std::ifstream file(fileName); // ��һ�������ļ���
        Json::Value root; // ����һ����Json����
        file >> root; // ���ļ��ж�ȡJson����

        // ������Json�����е���������
        for (Json::ValueIterator it = root.begin(); it != root.end(); ++it) {
            const std::string typeName = it.key().asString();
            Json::Value json = *it;
            std::unordered_map<std::string, std::unique_ptr<Savable> (*)()>::iterator factoryIt = factoryMap.find(typeName); // ���Ҹ����Ͷ�Ӧ�Ĵ�������
            if (factoryIt != factoryMap.end()) {
                std::unique_ptr<Savable> obj = factoryIt->second(); // ���������͵Ķ���
                obj->load(json); // ��Json�����м��ض�������
                objects[typeName] = std::move(obj); // ������洢�����󼯺���
            }
        }
    }

private:
    // ����ӳ������ڴ洢�������ƺͶ�Ӧ�Ĵ�������
    std::unordered_map<std::string, std::unique_ptr<Savable> (*)()> factoryMap;
};

// �������������ڴ���Player����
std::unique_ptr<Savable> createPlayer() { return std::unique_ptr<Savable>(new Player()); }

// �������������ڴ���GameSettings����
std::unique_ptr<Savable> createGameSettings() { return std::unique_ptr<Savable>(new GameSettings()); }



//============================================================================
//xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx





/*


 SaveSystem saveSystem; // ��������ϵͳ����

    // ע����Ա��������
    saveSystem.registerSavable("Player", createPlayer);
    saveSystem.registerSavable("GameSettings", createGameSettings);

    // �������������
    std::unordered_map<std::string, std::unique_ptr<Savable>> objects;
    {
        // ������Ҷ�������������
        std::unique_ptr<Player> player(new Player());
        player->name = "Hero";
        player->level = 10;
        objects["Player"] = std::move(player); // ����Ҷ�����ӵ����󼯺���

        // ������Ϸ���ö�������������
        std::unique_ptr<GameSettings> settings(new GameSettings());
        settings->fullscreen = true;
        settings->resolutionWidth = 1920;
        settings->resolutionHeight = 1080;
        objects["GameSettings"] = std::move(settings); // ����Ϸ���ö�����ӵ����󼯺���
    }

    // �����󱣴浽�ļ�
    saveSystem.save("savefile.json", objects);

    // ���ļ����ض���
    std::unordered_map<std::string, std::unique_ptr<Savable>> loadedObjects;
    saveSystem.load("savefile.json", loadedObjects);

    // ��֤���ص�����
    if (loadedObjects.find("Player") != loadedObjects.end()) {
        Player* player = dynamic_cast<Player*>(loadedObjects["Player"].get());
        if (player) {
            std::cout << "Player Name: " << player->name << ", Level: " << player->level << std::endl;
        }
    }

    if (loadedObjects.find("GameSettings") != loadedObjects.end()) {
        GameSettings* settings = dynamic_cast<GameSettings*>(loadedObjects["GameSettings"].get());
        if (settings) {
            std::cout << "Fullscreen: " << (settings->fullscreen ? "Yes" : "No")
                      << ", Resolution: " << settings->resolutionWidth << "x" << settings->resolutionHeight << std::endl;
        }
    }


*/