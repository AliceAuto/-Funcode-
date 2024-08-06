#ifndef EVENTDRIVENSYSTEM_H
#define EVENTDRIVENSYSTEM_H

#include <iostream>
#include <unordered_map>
#include <vector>
#include <string>

// 枚举事件类型
enum class EventType {
    MouseInput,			
    KeyboardInput,
    EventB
};

// 事件基类
class Event {
public:
    virtual ~Event() {} // 显式定义虚析构函数
    virtual EventType GetType() const = 0;
};

// 输入事件基类
class InputEvent : public Event {
public:
    virtual ~InputEvent() {} // 显式定义虚析构函数
};

// 鼠标输入事件
class MouseInputEvent : public InputEvent {
public:
    MouseInputEvent(int x, int y) : x(x), y(y) {}

    EventType GetType() const override {
        return EventType::MouseInput;
    }

    int GetX() const {
        return x;
    }

    int GetY() const {
        return y;
    }

private:
    int x;
    int y;
};

// 键盘输入事件
class KeyboardInputEvent : public InputEvent {
public:
    KeyboardInputEvent(int key, int state) : key(key), state(state) {}

    EventType GetType() const override {
        return EventType::KeyboardInput;
    }

    int GetKey() const {
        return key;
    }

    int GetState() const {
        return state;
    }

private:
    int key;
    int state;
};

// 事件B的派生类
class EventB : public Event {
public:
    EventB(const std::string& message) : message(message) {}

    EventType GetType() const override {
        return EventType::EventB;
    }

    std::string GetMessage() const {
        return message;
    }

private:
    std::string message;
};

// 事件管理器类
class EventManager {
public:
    typedef void(*EventListener)(const Event&); // 使用 typedef 定义函数指针类型

    // 注册监听器
    void RegisterListener(EventType type, EventListener listener) {
        listeners[type].push_back(listener);
    }

    // 分发事件
    void DispatchEvent(const Event& event) {
        EventType type = event.GetType();
        if (listeners.find(type) != listeners.end()) {
            for (auto& listener : listeners[type]) {
                listener(event);  // 触发监听器
            }
        }
    }

private:
    std::unordered_map<EventType, std::vector<EventListener>> listeners;
};

#endif // EVENTDRIVENSYSTEM_H
