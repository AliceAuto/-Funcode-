#pragma once

#include <unordered_map>
#include <vector>
#include <functional>
#include <algorithm>
#include <string>
#include "Logger.h"

//======================================================================================
/*
                                事件驱动系统 接口声明
*/
//======================================================================================

// 枚举事件类型
enum EventType {
    MouseInput,
    KeyboardInput,
    ButtonClick,
    Collision
};

// 事件基类
class Event {
public:
    virtual ~Event() {}
    virtual EventType GetType() const = 0;
};

// 鼠标输入事件
class MouseInputEvent : public Event {
public:
    MouseInputEvent(float x, float y, bool isLeftPressed, bool isMiddlePressed, bool isRightPressed)
        : x(x), y(y), isLeftPressed(isLeftPressed), isMiddlePressed(isMiddlePressed), isRightPressed(isRightPressed) {}

    EventType GetType() const override {
        return MouseInput;
    }

    float GetX() const { return x; }
    float GetY() const { return y; }
    bool IsLeftPressed() const { return isLeftPressed; }
    bool IsMiddlePressed() const { return isMiddlePressed; }
    bool IsRightPressed() const { return isRightPressed; }

private:
    float x, y;
    bool isLeftPressed, isMiddlePressed, isRightPressed;
};

// 键盘输入事件
class KeyboardInputEvent : public Event {
public:
    enum KeyState {
        KEY_ON,
        KEY_OFF
    };

    KeyboardInputEvent(int key, KeyState state) : key(key), state(state) {}

    EventType GetType() const override {
        return KeyboardInput;
    }

    int GetKey() const { return key; }
    KeyState GetState() const { return state; }

private:
    int key;
    KeyState state;
};

// 精灵碰撞事件类
class CollisionEvent : public Event {
public:
    CollisionEvent(const std::string& A, const std::string& B) : A(A), B(B) {}

    EventType GetType() const override {
        return Collision;
    }

    const std::string& GetA() const { return A; }
    const std::string& GetB() const { return B; }

private:
    std::string A, B;
};

// 按钮点击事件类
class ButtonClickEvent : public Event {
public:
    ButtonClickEvent(const std::string& sender) : sender(sender) {}

    EventType GetType() const override {
        return ButtonClick;
    }

    std::string GetButtonSender() const { return sender; }

private:
    std::string sender;
};

// 事件管理器类
class EventManager {
public:
    typedef std::function<void(const Event&)> EventListener;

    // 获取事件管理器的实例
    static EventManager& Instance() {
        static EventManager instance;
        return instance;
    }

    // 注册监听器，指定事件类型
    void RegisterListener(EventType type, const std::string& listenerID, EventListener listener) {
        listeners[type].push_back(std::make_pair(listenerID, listener));
    }

    // 移除监听器，指定事件类型
    void RemoveListener(EventType type, const std::string& listenerID) {
        std::vector<std::pair<std::string, EventListener>>& listenerList = listeners[type];
        listenerList.erase(
            std::remove_if(listenerList.begin(), listenerList.end(),
                [&](const std::pair<std::string, EventListener>& pair) {
                    return pair.first == listenerID;
                }),
            listenerList.end()
        );
    }

    // 分发事件
    void DispatchEvent(const Event& event) {
        EventType type = event.GetType();
        auto it = listeners.find(type);
        if (it != listeners.end()) {
            // 使用临时容器来避免迭代器失效
            std::vector<EventListener> tempListeners;
            for (const auto& pair : it->second) {
                tempListeners.push_back(pair.second);
            }
            for (const auto& listener : tempListeners) {
                try {
                    listener(event);
                } catch (const std::exception& e) {
                    LogManager::Log("Exception: " + std::string(e.what()));
                }
            }
        }
    }

    // 清理所有监听器
    void ClearListeners() {
        listeners.clear();
    }

private:
    EventManager() {} // 私有构造函数，防止外部实例化

    std::unordered_map<EventType, std::vector<std::pair<std::string, EventListener>>> listeners;
};
