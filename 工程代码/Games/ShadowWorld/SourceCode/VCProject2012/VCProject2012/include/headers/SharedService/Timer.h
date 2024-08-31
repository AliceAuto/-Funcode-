#ifndef TIMER_H
#define TIMER_H

#include <map>
#include <functional>
#include <utility>
#include <ctime>

class Timer {
public:
    typedef unsigned long Duration;  // ʱ���������룩
    typedef std::function<void()> Callback;  // ��ʱ���ص���������

    Timer();
    ~Timer();

    // ���ö�ʱ��
    void setTimer(Duration duration, Callback callback);

private:
    void checkTimers();  // �ڲ���������鲢����ʱ���¼�

    struct TimerEvent {
        std::time_t expiration;  // �¼�����ʱ�䣨�룩
        Callback callback;  // �¼�����ʱ���õĻص�����
    };

    std::map<std::time_t, TimerEvent> timers;  // �洢��ʱ���¼�
    std::time_t lastCheckTime;  // �ϴμ�鶨ʱ����ʱ�䣨�룩
};

#endif // TIMER_H
