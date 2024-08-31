#include "Timer.h"
#include <iostream>
#include <ctime>

Timer::Timer() {
    lastCheckTime = std::time(0);  // ��ʼ���ϴμ��ʱ��Ϊ��ǰʱ��
}

Timer::~Timer() {}

void Timer::setTimer(Duration duration, TimeCondition condition, Callback callback) {
    std::time_t now = std::time(0);  // ��ȡ��ǰʱ��
    std::time_t expiration = now + duration / 1000;  // ���㴥��ʱ�䣨�룩
    TimerEvent event = { expiration, condition, callback };  // ������ʱ���¼�
    timers[expiration] = event;  // ���¼��洢����ʱ��ӳ����

    // �Զ���鶨ʱ��
    checkTimers();
}

void Timer::checkTimers() {
    std::time_t now = std::time(0);  // ��ȡ��ǰʱ��

    if (now > lastCheckTime) {
        std::map<std::time_t, TimerEvent>::iterator it = timers.begin();
        while (it != timers.end()) {
            if (it->first <= now) {  // �����ʱ������
                if (it->second.condition(now)) {  // ���ʱ������
                    it->second.callback();  // ���ûص�����
                }
                it = timers.erase(it);  // �Ƴ��Ѵ���Ķ�ʱ��
            } else {
                ++it;
            }
        }
        lastCheckTime = now;  // �����ϴμ��ʱ��
    }
}
/*#include "Timer.h"
#include <iostream>
#include <windows.h>  // Sleep ����������ͣ

int main() {
    Timer timer;

    // ����һ����ʱ����1��󴥷�������ÿ��0.5����һ������
    timer.setTimer(1000, [](std::time_t currentTime) -> bool {
        // ���ݵ�ǰʱ������Ƿ�ִ������
        // �������Ǽ�����ĳ����������ʱ���� true
        // ʵ���������Ը���������
        return (currentTime % 2 == 0);  // ʾ����������ǰʱ��������ż��
    }, []() {
        std::cout << "��ʱ��������" << std::endl;
    });

    // ��ѭ����ģ����������
    while (true) {
        Sleep(100);  // ��ͣ�Լ��� CPU ʹ��
    }

    return 0;
}
*/