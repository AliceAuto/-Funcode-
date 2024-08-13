#ifndef RESOURCEBAG_H
#define RESOURCEBAG_H

#include <string>
#include <unordered_map>
#include <memory>
#include <json/json.h>
#include "Logger.h"
#include "CSprite.h"


class ResourceBag {
public:
    ResourceBag();
    ~ResourceBag();

    template <typename T>
    void AddResource(const std::string& name, std::shared_ptr<T> resource);

    template <typename T>
    std::shared_ptr<T> GetResource(const std::string& name) const;

    bool LoadFromJson(const std::string& packageName);

private:
    std::unordered_map<std::string, std::shared_ptr<void>> container_;

    static const std::string resourceFilename;
    static int IdCounter;
};

// 模板实现直接放在头文件中

template <typename T>
void ResourceBag::AddResource(const std::string& name, std::shared_ptr<T> resource) {
    
     if (this == nullptr) {
        LogManager::Log("ERROR: ResourceBag 对象未正确初始化 (this == nullptr)");
        return;
    }
    container_[name] = resource;
    LogManager::Log("INFO: 将资源添加到 ResourceBag: " + name);
}

template <typename T>
std::shared_ptr<T> ResourceBag::GetResource(const std::string& name) const {
    LogManager::Log("INFO: 从 ResourceBag 获取资源: " + name);
    auto it = container_.find(name);
    if (it != container_.end()) {
        return std::static_pointer_cast<T>(it->second);
    }
    LogManager::Log("ERROR: 未找到资源: " + name);
    return nullptr;
}

#endif // RESOURCEBAG_H
