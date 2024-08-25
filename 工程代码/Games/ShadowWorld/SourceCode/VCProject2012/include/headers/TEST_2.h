#include <iostream>
#include <string>
#include <map>
#include <vector>
#include <memory>
#include <fstream>
#include <json/json.h>

#include "CSprite.h"

// ==================== 新类型对象示例 ====================

















// 工厂接口
class ISpriteFactory {
public:
    virtual ~ISpriteFactory() = 0;
    virtual CSprite* createSprite(const std::string& typeName, const std::string& value) const = 0;
};

// 具体工厂实现
class SpriteFactory : public ISpriteFactory {
public:
    typedef CSprite* (*CreatorFunc)(const std::string&);

    void registerType(const std::string& typeName, CreatorFunc creator) {
        creators[typeName] = creator;
    }

    CSprite* createSprite(const std::string& typeName, const std::string& value) const override {
        auto it = creators.find(typeName);
        if (it != creators.end()) {
            return it->second(value);
        }
        std::cerr << "Unknown type: " << typeName << std::endl;
        return nullptr;
    }

private:
    std::map<std::string, CreatorFunc> creators;
};




//解析JSON





// ==================== 创建新类型对象 ====================


//创建人物动画精灵





// ==================== 创建 CAnimateSprite 对象 ====================
CSprite* createCAnimateSprite(const std::string& value) {

    return new CAnimateSprite(value.c_str());
}



















// 资源管理器类
class ResourceManager {
public:
    typedef std::map<std::string, CSprite*> Bag;

    ResourceManager(const ISpriteFactory& factory) : factory(factory) {}

    bool loadFromFile(const std::string& filename) {
        std::ifstream file(filename.c_str(), std::ifstream::binary);
        if (!file.is_open()) {
            std::cerr << "Failed to open file: " << filename << std::endl;
            return false;
        }

        Json::Reader reader;
        Json::Value root;
        if (!reader.parse(file, root)) {
            std::cerr << "Failed to parse JSON" << std::endl;
            return false;
        }

        file.close();

        // 遍历根对象中的所有成员
        for (Json::ValueIterator it = root.begin(); it != root.end(); ++it) {
            const std::string bagName = it.key().asString();
            Bag bag;
            const Json::Value& fields = *it;

            // 遍历每个背包中的字段
            for (Json::ValueIterator fieldIt = fields.begin(); fieldIt != fields.end(); ++fieldIt) {
                const std::string fieldName = fieldIt.key().asString();
                std::string type = (*fieldIt)["type"].asString();
                std::string value = (*fieldIt)["value"].asString();
                CSprite* obj = factory.createSprite(type, value);
                if (obj) {
                    bag[fieldName] = obj;
                }
            }

            bags[bagName] = bag;
        }

        return true;
    }

    Bag& operator[](const std::string& bagName) {
        return bags[bagName];
    }

    ~ResourceManager() {
        for (auto& bag : bags) {
            for (auto& entry : bag.second) {
                delete entry.second;
            }
        }
    }

private:
    std::map<std::string, Bag> bags;
    const ISpriteFactory& factory;
};

// 提供虚析构函数的实现

ISpriteFactory::~ISpriteFactory() {}
