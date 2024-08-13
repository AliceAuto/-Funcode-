#pragma once

#include <unordered_map>
#include <vector>
#include <functional>
#include <algorithm>
#include <typeinfo>

//======================================================================================
/*
								事件驱动系统 接口声明
*/
//======================================================================================


























// 枚举事件类型
enum class EventType {
    MouseInput,
    KeyboardInput,
	ButtonClick,  // 新增按钮点击事件类型
    EventB
};






// 事件基类
//=========================================
class Event {
public:
    virtual ~Event() {}
    virtual EventType GetType() const = 0;
};
//===================================================







// 鼠标输入事件
//====================================================
class MouseInputEvent : public Event {
public:
    // 构造函数
    MouseInputEvent(float x, float y, bool isLeftPressed, bool isMiddlePressed, bool isRightPressed)
        : x(x), y(y), isLeftPressed(isLeftPressed), isMiddlePressed(isMiddlePressed), isRightPressed(isRightPressed) {}

    // 获取事件类型
    EventType GetType() const override 
	{
        return EventType::MouseInput;
    }

    // 公有的 getter 方法
    float GetX() const
	{
        return x;
    }

    float GetY() const
	{
        return y;
    }

    bool IsLeftPressed() const 
	{
        return isLeftPressed;
    }

    bool IsMiddlePressed() const 
	{
        return isMiddlePressed;
    }

    bool IsRightPressed() const
	{
        return isRightPressed;
    }

private:
    // 私有的数据成员
    float x;
    float y;
    bool isLeftPressed;
    bool isMiddlePressed;
    bool isRightPressed;
};
//========================================================================











// 键盘输入事件
//===============================================================
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
//==============================================================================================




// 按钮点击事件类
//=================================================================
class ButtonClickEvent : public Event {
public:
    ButtonClickEvent(std::string sender) : sender(sender) {}

    EventType GetType() const override {
        return EventType::ButtonClick;
    }

    std::string GetButtonSender() const {
        return sender;
    }

private:
	std::string sender;//辨识发送者
    
};
//===========================================================================================






// 事件管理器类
//===========================================================
class EventManager {
public:
    // 使用 typedef 代替 using 声明
    typedef std::function<void(const Event&)> EventListener;

    // 获取事件管理器的实例
    static EventManager& Instance() {
        static EventManager instance;
        return instance;
    }

    // 注册监听器
    void RegisterListener(EventType type, EventListener listener) {
        auto& listenerList = listeners[type];
        listenerList.push_back(listener);
    }

    // 移除监听器
    void RemoveListener(EventType type, EventListener listener) {
     auto it = listeners.find(type);
    if (it != listeners.end()) {
        auto& listenerList = it->second;

        for (auto it = listenerList.begin(); it != listenerList.end(); ) {
            if (it->target<void(*)(const Event&)>() == listener.target<void(*)(const Event&)>()) {
                it = listenerList.erase(it); // 移除并更新迭代器
            } else {
                ++it; // 仅更新迭代器
            }
        }
    }
}

    // 分发事件
    void DispatchEvent(const Event& event) const {
        EventType type = event.GetType();
        auto it = listeners.find(type);
        if (it != listeners.end()) {
            for (const auto& listener : it->second) {
                listener(event);
            }
        }
    }


    EventManager() {} // 私有构造函数，防止外部实例化
private:
    EventManager(const EventManager&); // 禁用拷贝构造函数
    EventManager& operator=(const EventManager&); // 禁用赋值操作
    std::unordered_map<EventType, std::vector<EventListener>> listeners;
};
//================================================================================================





// 外部事件管理器声明
extern EventManager eventManager;

// 事件处理函数声明
void onMouseInput(const Event& event);
void onKeyboardInput(const Event& event);
