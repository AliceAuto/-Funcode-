#ifndef CONTAINER_H
#define CONTAINER_H

#include <map>
#include <memory>
#include <string>
#include <functional>
#include <stdexcept>

class Container {
public:
    // �����Դ������
    template <typename T>
    void SetValue(const std::string& key, T* value) {
        // ʹ�� lambda ȷ����Դɾ��
        values_[key] = std::unique_ptr<void, std::function<void(void*)>>(
            value, [](void* ptr) { delete static_cast<T*>(ptr); });
    }

    // ��������ȡ��Դ
    template <typename T>
    T* GetValue(const std::string& key) const {
        auto it = values_.find(key);
        if (it == values_.end()) {
            throw std::runtime_error("Resource not found: " + key);
        }
        return static_cast<T*>(it->second.get());
    }

private:
    std::map<std::string, std::unique_ptr<void, std::function<void(void*)>>> values_;
};

#endif // CONTAINER_H
