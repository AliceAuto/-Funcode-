#pragma once

#include <unordered_map>
#include <vector>
  #include <functional>

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
    ButtonClickEvent(int buttonId) : buttonName(buttonName) {}

    EventType GetType() const override {
        return EventType::ButtonClick;
    }

    int GetButtonId() const {
        return buttonName;
    }

private:
    int buttonName;
};
//===========================================================================================






// 事件管理器类
//===========================================================
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

<<<<<<< Updated upstream
private:
=======

    // 私有构造函数，防止外部实例化
private:
	EventManager() {} 
    EventManager(const EventManager&); // 禁用拷贝构造函数
    EventManager& operator=(const EventManager&); // 禁用赋值操作
>>>>>>> Stashed changes
    std::unordered_map<EventType, std::vector<EventListener>> listeners;
};
//================================================================================================





// 外部事件管理器声明


// 事件处理函数声明

