#pragma once

#include <unordered_map>
#include <vector>
#include <functional>
#include <algorithm>
#include <string>
#include "Logger.h"

//======================================================================================
/*
                                �¼�����ϵͳ �ӿ�����
*/
//======================================================================================

// ö���¼�����
enum EventType {
    MouseInput,
    KeyboardInput,
    ButtonClick,
    Collision
};

// �¼�����
class Event {
public:
    virtual ~Event() {}
    virtual EventType GetType() const = 0;
};

// ��������¼�
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

// ���������¼�
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

// ������ײ�¼���
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

// ��ť����¼���
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

// �¼���������
class EventManager {
public:
    typedef std::function<void(const Event&)> EventListener;

    // ��ȡ�¼���������ʵ��
    static EventManager& Instance() {
        static EventManager instance;
        return instance;
    }

    // ע���������ָ���¼�����
    void RegisterListener(EventType type, const std::string& listenerID, EventListener listener) {
        listeners[type].push_back(std::make_pair(listenerID, listener));
    }

    // �Ƴ���������ָ���¼�����
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

    // �ַ��¼�
    void DispatchEvent(const Event& event) {
        EventType type = event.GetType();
        auto it = listeners.find(type);
        if (it != listeners.end()) {
            // ʹ����ʱ���������������ʧЧ
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

    // �������м�����
    void ClearListeners() {
        listeners.clear();
    }

private:
    EventManager() {} // ˽�й��캯������ֹ�ⲿʵ����

    std::unordered_map<EventType, std::vector<std::pair<std::string, EventListener>>> listeners;
};
