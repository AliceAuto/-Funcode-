#ifndef TIMER_H
#define TIMER_H

#include <map>
#include <functional>
#include <utility>
#include <ctime>

class Timer {
public:
    typedef unsigned long Duration;  // 时间间隔（毫秒）
    typedef std::function<void()> Callback;  // 定时器回调函数类型

    Timer();
    ~Timer();

    // 设置定时器
    void setTimer(Duration duration, Callback callback);

private:
    void checkTimers();  // 内部方法：检查并处理定时器事件

    struct TimerEvent {
        std::time_t expiration;  // 事件触发时间（秒）
        Callback callback;  // 事件触发时调用的回调函数
    };

    std::map<std::time_t, TimerEvent> timers;  // 存储定时器事件
    std::time_t lastCheckTime;  // 上次检查定时器的时间（秒）
};

#endif // TIMER_H
