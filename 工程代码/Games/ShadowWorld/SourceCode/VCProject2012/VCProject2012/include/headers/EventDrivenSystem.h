

//							===================================================
//							//				�¼�����ϵͳ					//
//							===================================================



#include <iostream>
#include <unordered_map>
#include <vector>
#include <string>
//--**--**--**--**--**--**//
//		ö���¼�����					//  ö�� ���ܴ��� �� �¼�����
enum class EventType				
{
    EventA,			
    EventB
};
//--**--**--**--**--**--**//







// �¼�����							//	 �������͵Ļ�������,һ�㲻���޸�
class Event							
{
public:
    virtual EventType GetType() const = 0;
};








						
//=============//==//==//==//==//==//==//==//==//=======================
//						�¼����Ͷ���

					//���嶨��ÿ������

// �¼�A�������࣬���ж��������
class EventA : public Event {
public:
    EventA(int value) : value(value) {}

    EventType GetType() const override {
        return EventType::EventA;
    }

    int GetValue() const {
        return value;
    }

private:
    int value;
};

// �¼�B�������࣬���ж��������
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
//=============//==//==//==//==//==//==//==//==//=======================










						//�Զ��¼��Ĺ���һ�㲻���޸�
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











					//		��ÿ�����͵Ļص���������

//=============//==//==//==//==//==//==//==//==//=======================
						// ����������
void onEventA(const Event& event) {
    // ���¼�ת��Ϊ��������
    const EventA& eventA = static_cast<const EventA&>(event);//��̬ת��
    int value = eventA.GetValue();

    std::cout << "Handling EventA with value: " << value << std::endl;

    // �����¼�����ִ���߼�
    if (value > 10) {
        std::cout << "Value is greater than 10." << std::endl;
    } else {
        std::cout << "Value is 10 or less." << std::endl;
    }
}

void onEventB(const Event& event) {
    // ���¼�ת��Ϊ��������
    const EventB& eventB = static_cast<const EventB&>(event);
    std::string message = eventB.GetMessage();

    std::cout << "Handling EventB with message: " << message << std::endl;

    // �����¼�����ִ���߼�
    if (message == "Hello") {
        std::cout << "Greeting received!" << std::endl;
    } else {
        std::cout << "Different message received." << std::endl;
    }
}
//=============//==//==//==//==//==//==//==//==//=======================
/*
// ���Դ���
int main() {
    EventManager eventManager;

    // ע�������
    eventManager.RegisterListener(EventType::EventA, onEventA);
    eventManager.RegisterListener(EventType::EventB, onEventB);

    // �����¼����ַ�
    EventA eventA(15);
    EventB eventB("Hello");

    eventManager.DispatchEvent(eventA); // �����¼�A
    eventManager.DispatchEvent(eventB); // �����¼�B

    return 0;
}
*/