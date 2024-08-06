#pragma once

#include <unordered_map>
#include <vector>
  #include <functional>

// ö���¼�����
enum class EventType {
    MouseInput,
    KeyboardInput,
    EventB
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

// ���������¼�
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

// �¼���������
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

private:
    std::unordered_map<EventType, std::vector<EventListener>> listeners;
};

// �ⲿ�¼�����������
extern EventManager eventManager;

// �¼�����������
void onMouseInput(const Event& event);
void onKeyboardInput(const Event& event);
