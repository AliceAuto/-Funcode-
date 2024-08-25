#pragma once

#include <unordered_map>
#include <vector>
  #include <functional>

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






// �¼���������
//===========================================================
class EventManager {
public:
    // ʹ�� typedef ���� using ����
    typedef std::function<void(const Event&)> EventListener;

    // ע�������
    void RegisterListener(EventType type, EventListener listener) {
        listeners[type].push_back(listener);
    }

    // �ַ��¼�
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

    // ˽�й��캯������ֹ�ⲿʵ����
private:
	EventManager() {} 
    EventManager(const EventManager&); // ���ÿ������캯��
    EventManager& operator=(const EventManager&); // ���ø�ֵ����
>>>>>>> Stashed changes
    std::unordered_map<EventType, std::vector<EventListener>> listeners;
};
//================================================================================================





// �ⲿ�¼�����������


// �¼�����������

