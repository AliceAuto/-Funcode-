#pragma once

#include <unordered_map>
#include <vector>
  #include <functional>

// 枚举事件类型
enum class EventType {
    MouseInput,
    KeyboardInput,
    EventB
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
    MouseInputEvent(float x, float y) : x(x), y(y) {}

    EventType GetType() const override {
        return EventType::MouseInput;
    }

    float GetX() const {
        return x;
    }

    float GetY() const {
        return y;
    }

private:
    float x;
    float y;
};

// 键盘输入事件
class KeyboardInputEvent : public Event {
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
static enum	State{
	KEY_ON,
	KEY_OFF
	};
private:

    int key;
    int state;
};

// 事件管理器类
class EventManager {
public:
    // 使用 typedef 代替 using 声明
    typedef std::function<void(const Event&)> EventListener;

    // 注册监听器
    void RegisterListener(EventType type, EventListener listener) {
        listeners[type].push_back(listener);
    }

    // 分发事件
    void DispatchEvent(const Event& event) const {
        EventType type = event.GetType();
        if (listeners.find(type) != listeners.end()) {
            for (const auto& listener : listeners.at(type)) {
                listener(event);
            }
        }
    }

private:
    std::unordered_map<EventType, std::vector<EventListener>> listeners;
};

// 外部事件管理器声明
extern EventManager eventManager;

// 事件处理函数声明
void onMouseInput(const Event& event);
void onKeyboardInput(const Event& event);
