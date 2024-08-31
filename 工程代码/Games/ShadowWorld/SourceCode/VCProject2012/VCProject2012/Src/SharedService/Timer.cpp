#include "headers\SharedService\Timer.h"
#include <iostream>
#include <ctime>

Timer::Timer() {
    lastCheckTime = std::time(0);  // 初始化上次检查时间为当前时间
}

Timer::~Timer() {}

void Timer::setTimer(Duration duration, Callback callback) {
    std::time_t now = std::time(0);  // 获取当前时间
    std::time_t expiration = now + duration / 1000;  // 计算触发时间（秒）
    TimerEvent event = { expiration, callback };  // 创建定时器事件
    timers[expiration] = event;  // 将事件存储到定时器映射中

    // 自动检查定时器
    checkTimers();
}

void Timer::checkTimers() {
    std::time_t now = std::time(0);  // 获取当前时间

    // 如果当前时间大于上次检查时间
    if (now > lastCheckTime) {
        std::map<std::time_t, TimerEvent>::iterator it = timers.begin();
        while (it != timers.end()) {
            if (it->first <= now) {  // 如果定时器到期
                it->second.callback();  // 调用回调函数
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

    // 设置一个定时器，1秒后触发
    timer.setTimer(1000, []() {
        std::cout << "定时器触发！" << std::endl;
    });

    // 主循环，模拟其他工作
    while (true) {
        Sleep(100);  // 暂停以减少 CPU 使用
    }

    return 0;
}
*/