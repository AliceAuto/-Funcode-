

//							===================================================
//							//				事件驱动系统					//
//							===================================================



#include <iostream>
#include <unordered_map>
#include <vector>
#include <string>
//--**--**--**--**--**--**//
//		枚举事件类型					//  枚举 可能存在 的 事件类型
enum class EventType				
{
    EventA,			
    EventB
};
//--**--**--**--**--**--**//







// 事件基类							//	 所有类型的基本属性,一般不用修改
class Event							
{
public:
    virtual EventType GetType() const = 0;
};








						
//=============//==//==//==//==//==//==//==//==//=======================
//						事件类型定义

					//具体定义每个类型

// 事件A的派生类，带有额外的数据
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

// 事件B的派生类，带有额外的数据
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










						//对多事件的管理，一般不做修改
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











					//		对每个类型的回调函数定义

//=============//==//==//==//==//==//==//==//==//=======================
						// 监听器函数
void onEventA(const Event& event) {
    // 将事件转换为具体类型
    const EventA& eventA = static_cast<const EventA&>(event);//静态转换
    int value = eventA.GetValue();

    std::cout << "Handling EventA with value: " << value << std::endl;

    // 根据事件数据执行逻辑
    if (value > 10) {
        std::cout << "Value is greater than 10." << std::endl;
    } else {
        std::cout << "Value is 10 or less." << std::endl;
    }
}

void onEventB(const Event& event) {
    // 将事件转换为具体类型
    const EventB& eventB = static_cast<const EventB&>(event);
    std::string message = eventB.GetMessage();

    std::cout << "Handling EventB with message: " << message << std::endl;

    // 根据事件数据执行逻辑
    if (message == "Hello") {
        std::cout << "Greeting received!" << std::endl;
    } else {
        std::cout << "Different message received." << std::endl;
    }
}
//=============//==//==//==//==//==//==//==//==//=======================
/*
// 测试代码
int main() {
    EventManager eventManager;

    // 注册监听器
    eventManager.RegisterListener(EventType::EventA, onEventA);
    eventManager.RegisterListener(EventType::EventB, onEventB);

    // 创建事件并分发
    EventA eventA(15);
    EventB eventB("Hello");

    eventManager.DispatchEvent(eventA); // 触发事件A
    eventManager.DispatchEvent(eventB); // 触发事件B

    return 0;
}
*/