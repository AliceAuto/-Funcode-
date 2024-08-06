#ifndef EVENTDRIVENSYSTEM_H
#define EVENTDRIVENSYSTEM_H

#include <iostream>
#include <unordered_map>
#include <vector>
#include <string>

// ö���¼�����
enum class EventType {
    MouseInput,			
    KeyboardInput,
    EventB
};

// �¼�����
class Event {
public:
    virtual ~Event() {} // ��ʽ��������������
    virtual EventType GetType() const = 0;
};

// �����¼�����
class InputEvent : public Event {
public:
    virtual ~InputEvent() {} // ��ʽ��������������
};

// ��������¼�
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

// ���������¼�
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

// �¼�B��������
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

// �¼���������
class EventManager {
public:
    typedef void(*EventListener)(const Event&); // ʹ�� typedef ���庯��ָ������

    // ע�������
    void RegisterListener(EventType type, EventListener listener) {
        listeners[type].push_back(listener);
    }

    // �ַ��¼�
    void DispatchEvent(const Event& event) {
        EventType type = event.GetType();
        if (listeners.find(type) != listeners.end()) {
            for (auto& listener : listeners[type]) {
                listener(event);  // ����������
            }
        }
    }

private:
    std::unordered_map<EventType, std::vector<EventListener>> listeners;
};

#endif // EVENTDRIVENSYSTEM_H
