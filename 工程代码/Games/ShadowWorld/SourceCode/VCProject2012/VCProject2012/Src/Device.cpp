
#include "Device.h"


// 初始化静态成员变量
Mouse* Mouse::instance = nullptr;

// 私有构造函数
Mouse::Mouse() : x(0), y(0), leftPressed(false), middlePressed(false), rightPressed(false),ChannelOccupancy(true) ,keyWords(""){
}

// 获取唯一实例的静态方法
Mouse& Mouse::Instance() {
    if (instance == nullptr) {
        instance = new Mouse();
    }
    return *instance;
}
