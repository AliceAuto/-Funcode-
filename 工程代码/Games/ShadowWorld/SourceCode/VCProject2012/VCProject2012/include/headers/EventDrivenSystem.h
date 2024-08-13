#pragma once

#include <unordered_map>
#include <vector>
#include <functional>
#include <algorithm>
#include <typeinfo>

//======================================================================================
/*
								�¼�����ϵͳ �ӿ�����
*/
//======================================================================================


























// ö���¼�����
enum class EventType {
    MouseInput,
    KeyboardInput,
	ButtonClick,  // ������ť����¼�����
    EventB
};






// �¼�����
//=========================================
class Event {
public:
    virtual ~Event() {}
    virtual EventType GetType() const = 0;
};
//===================================================







// ��������¼�
//====================================================
class MouseInputEvent : public Event {
public:
    // ���캯��
    MouseInputEvent(float x, float y, bool isLeftPressed, bool isMiddlePressed, bool isRightPressed)
        : x(x), y(y), isLeftPressed(isLeftPressed), isMiddlePressed(isMiddlePressed), isRightPressed(isRightPressed) {}

    // ��ȡ�¼�����
    EventType GetType() const override 
	{
        return EventType::MouseInput;
    }

    // ���е� getter ����
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
    // ˽�е����ݳ�Ա
    float x;
    float y;
    bool isLeftPressed;
    bool isMiddlePressed;
    bool isRightPressed;
};
//========================================================================











// ���������¼�
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




// ��ť����¼���
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
	std::string sender;//��ʶ������
    
};
//===========================================================================================






// �¼���������
//===========================================================
class EventManager {
public:
    // ʹ�� typedef ���� using ����
    typedef std::function<void(const Event&)> EventListener;

    // ��ȡ�¼���������ʵ��
    static EventManager& Instance() {
        static EventManager instance;
        return instance;
    }

    // ע�������
    void RegisterListener(EventType type, EventListener listener) {
        auto& listenerList = listeners[type];
        listenerList.push_back(listener);
    }

    // �Ƴ�������
    void RemoveListener(EventType type, EventListener listener) {
     auto it = listeners.find(type);
    if (it != listeners.end()) {
        auto& listenerList = it->second;

        for (auto it = listenerList.begin(); it != listenerList.end(); ) {
            if (it->target<void(*)(const Event&)>() == listener.target<void(*)(const Event&)>()) {
                it = listenerList.erase(it); // �Ƴ������µ�����
            } else {
                ++it; // �����µ�����
            }
        }
    }
}

    // �ַ��¼�
    void DispatchEvent(const Event& event) const {
        EventType type = event.GetType();
        auto it = listeners.find(type);
        if (it != listeners.end()) {
            for (const auto& listener : it->second) {
                listener(event);
            }
        }
    }


    EventManager() {} // ˽�й��캯������ֹ�ⲿʵ����
private:
    EventManager(const EventManager&); // ���ÿ������캯��
    EventManager& operator=(const EventManager&); // ���ø�ֵ����
    std::unordered_map<EventType, std::vector<EventListener>> listeners;
};
//================================================================================================





// �ⲿ�¼�����������
extern EventManager eventManager;

// �¼�����������
void onMouseInput(const Event& event);
void onKeyboardInput(const Event& event);
