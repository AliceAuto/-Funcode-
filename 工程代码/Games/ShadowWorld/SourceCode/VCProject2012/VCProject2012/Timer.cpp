#include "Timer.h"
#include <iostream>
#include <ctime>

Timer::Timer() {
    lastCheckTime = std::time(0);  // 初始化上次检查时间为当前时间
}

Timer::~Timer() {}

void Timer::setTimer(Duration duration, TimeCondition condition, Callback callback) {
    std::time_t now = std::time(0);  // 获取当前时间
    std::time_t expiration = now + duration / 1000;  // 计算触发时间（秒）
    TimerEvent event = { expiration, condition, callback };  // 创建定时器事件
    timers[expiration] = event;  // 将事件存储到定时器映射中

    // 自动检查定时器
    checkTimers();
}

void Timer::checkTimers() {
    std::time_t now = std::time(0);  // 获取当前时间

    if (now > lastCheckTime) {
        std::map<std::time_t, TimerEvent>::iterator it = timers.begin();
        while (it != timers.end()) {
            if (it->first <= now) {  // 如果定时器到期
                if (it->second.condition(now)) {  // 检查时间条件
                    it->second.callback();  // 调用回调函数
                }
                it = timers.erase(it);  // 移除已处理的定时器
            } else {
                ++it;
            }
        }
        lastCheckTime = now;  // 更新上次检查时间
    }
}
/*#include "Timer.h"
#include <iostream>
#include <windows.h>  // Sleep 函数用于暂停

int main() {
    Timer timer;

    // 设置一个定时器，1秒后触发，并且每隔0.5秒检查一次条件
    timer.setTimer(1000, [](std::time_t currentTime) -> bool {
        // 根据当前时间决定是否执行任务
        // 这里我们假设在某个条件满足时返回 true
        // 实际条件可以根据需求定义
        return (currentTime % 2 == 0);  // 示例条件：当前时间秒数是偶数
    }, []() {
        std::cout << "定时器触发！" << std::endl;
    });

    // 主循环，模拟其他工作
    while (true) {
        Sleep(100);  // 暂停以减少 CPU 使用
    }

    return 0;
}
*/