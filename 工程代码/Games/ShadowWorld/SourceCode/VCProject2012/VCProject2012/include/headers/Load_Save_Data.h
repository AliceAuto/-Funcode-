#include <json/json.h>
#include <string>
#include <fstream>
#include <unordered_map>
#include <memory>
#include <iostream>
//xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
//xx											xx	
//xx					存档系统				xx
//xx											xx	
//xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx






//xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
//============================================================================

// 定义一个可以保存和加载数据的基类
class Savable {
public:
    virtual ~Savable() {}

    // 保存数据到Json对象中
    virtual void save(Json::Value& json) const = 0;

    // 从Json对象中加载数据
    virtual void load(const Json::Value& json) = 0;
};


//============================================================================
//xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx







//xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
//============================================================================
// 定义一个玩家类，继承自Savable
class Player : public Savable {
public:
    std::string name; // 玩家姓名
    int level;        // 玩家等级

    // 实现保存函数，将玩家数据保存到Json对象中
    void save(Json::Value& json) const override {
        json["name"] = name;
        json["level"] = level;
    }

    // 实现加载函数，从Json对象中加载玩家数据
    void load(const Json::Value& json) override {
        name = json["name"].asString();
        level = json["level"].asInt();
    }
};


//============================================================================
//xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx









//xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
//============================================================================
// 定义一个游戏设置类，继承自Savable
class GameSettings : public Savable {
public:
    bool fullscreen;          // 是否全屏
    int resolutionWidth;      // 分辨率宽度
    int resolutionHeight;     // 分辨率高度

    // 实现保存函数，将游戏设置数据保存到Json对象中
    void save(Json::Value& json) const override {
        json["fullscreen"] = fullscreen;
        json["resolutionWidth"] = resolutionWidth;
        json["resolutionHeight"] = resolutionHeight;
    }

    // 实现加载函数，从Json对象中加载游戏设置数据
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

// 保存系统类，管理数据的保存和加载
class SaveSystem {
public:
    // 注册一个可以保存的类型及其对应的创建函数
    void registerSavable(const std::string& typeName, std::unique_ptr<Savable> (*createFunc)()) {
        factoryMap[typeName] = createFunc;
    }

    // 将对象保存到指定文件
    void save(const std::string& fileName, const std::unordered_map<std::string, std::unique_ptr<Savable>>& objects) {
        Json::Value root;  // 创建一个根Json对象
        // 遍历所有需要保存的对象
        for (std::unordered_map<std::string, std::unique_ptr<Savable>>::const_iterator it = objects.begin(); it != objects.end(); ++it) {
            const std::string& typeName = it->first;
            const std::unique_ptr<Savable>& obj = it->second;
            Json::Value json; // 创建一个Json对象存储单个对象的数据
            obj->save(json);  // 将对象的数据保存到Json对象中
            root[typeName] = json;  // 将Json对象添加到根Json对象中
        }
        std::ofstream file(fileName); // 打开一个输出文件流
        file << root; // 将Json数据写入文件
    }

    // 从指定文件加载对象
    void load(const std::string& fileName, std::unordered_map<std::string, std::unique_ptr<Savable>>& objects) {
        std::ifstream file(fileName); // 打开一个输入文件流
        Json::Value root; // 创建一个根Json对象
        file >> root; // 从文件中读取Json数据

        // 遍历根Json对象中的所有数据
        for (Json::ValueIterator it = root.begin(); it != root.end(); ++it) {
            const std::string typeName = it.key().asString();
            Json::Value json = *it;
            std::unordered_map<std::string, std::unique_ptr<Savable> (*)()>::iterator factoryIt = factoryMap.find(typeName); // 查找该类型对应的创建函数
            if (factoryIt != factoryMap.end()) {
                std::unique_ptr<Savable> obj = factoryIt->second(); // 创建该类型的对象
                obj->load(json); // 从Json数据中加载对象数据
                objects[typeName] = std::move(obj); // 将对象存储到对象集合中
            }
        }
    }

private:
    // 工厂映射表，用于存储类型名称和对应的创建函数
    std::unordered_map<std::string, std::unique_ptr<Savable> (*)()> factoryMap;
};

// 工厂函数，用于创建Player对象
std::unique_ptr<Savable> createPlayer() { return std::unique_ptr<Savable>(new Player()); }

// 工厂函数，用于创建GameSettings对象
std::unique_ptr<Savable> createGameSettings() { return std::unique_ptr<Savable>(new GameSettings()); }



//============================================================================
//xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx





/*


 SaveSystem saveSystem; // 创建保存系统对象

    // 注册可以保存的类型
    saveSystem.registerSavable("Player", createPlayer);
    saveSystem.registerSavable("GameSettings", createGameSettings);

    // 创建并保存对象
    std::unordered_map<std::string, std::unique_ptr<Savable>> objects;
    {
        // 创建玩家对象并设置其属性
        std::unique_ptr<Player> player(new Player());
        player->name = "Hero";
        player->level = 10;
        objects["Player"] = std::move(player); // 将玩家对象添加到对象集合中

        // 创建游戏设置对象并设置其属性
        std::unique_ptr<GameSettings> settings(new GameSettings());
        settings->fullscreen = true;
        settings->resolutionWidth = 1920;
        settings->resolutionHeight = 1080;
        objects["GameSettings"] = std::move(settings); // 将游戏设置对象添加到对象集合中
    }

    // 将对象保存到文件
    saveSystem.save("savefile.json", objects);

    // 从文件加载对象
    std::unordered_map<std::string, std::unique_ptr<Savable>> loadedObjects;
    saveSystem.load("savefile.json", loadedObjects);

    // 验证加载的数据
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