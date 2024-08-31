#ifndef ObjectMANAGER_H
#define ObjectMANAGER_H

#include <string>
#include <unordered_map>
#include "Object.h"
#include "json/json.h"

//==========================================================================================================
class ObjectManager {
public:
    ObjectManager();
    ~ObjectManager();

    // 创建新的 Entity 实例，并返回其唯一标识符
	//json读取可变参数
    std::string CreateObject(const std::string& jsonString);

    // 获取指定 ID 的 Entity
    Object* GetObject(const std::string& id);

    // 根据精灵名称获取 Entity
    Object* GetObjectBySpriteName(const std::string& spriteName);

    // 删除指定 ID 的 Entity
    void DeleteObject(const std::string& id);

    // 更新所有 Entity，包括更新和渲染
    void Update();
	//加载所有实体
	void ObjectManager::LoadAllObjects();
	void ObjectManager::breakDownAllObjects();


private:
    // 根据控制器类型创建新的控制器实例
    Object* CreateObjectInstance(const std::string& type, Json::Value root);

	long long Id_couter;
    // 存储精灵名称到 Entity 的映射
    std::unordered_map<std::string, Object*> spriteNameToObject;
    // 生成唯一 ID
};
//==========================================================================================================

#endif // ENTITYMANAGER_H
