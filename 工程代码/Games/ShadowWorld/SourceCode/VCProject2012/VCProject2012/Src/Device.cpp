
#include "Device.h"


// ��ʼ����̬��Ա����
Mouse* Mouse::instance = nullptr;

// ˽�й��캯��
Mouse::Mouse() : x(0), y(0), leftPressed(false), middlePressed(false), rightPressed(false),ChannelOccupancy(true) ,keyWords(""){
}

// ��ȡΨһʵ���ľ�̬����
Mouse& Mouse::Instance() {
    if (instance == nullptr) {
        instance = new Mouse();
    }
    return *instance;
}
