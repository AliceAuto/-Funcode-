#ifndef DEVICE_H
#define DEVICE_H
#include "Object.h"
class Mouse {
public:
    // 获取唯一实例的静态方法
    static Mouse& Instance();

    // 删除复制构造函数和赋值运算符
   
	float x;
    float y;
    bool leftPressed;
    bool middlePressed;
    bool rightPressed;
	bool ChannelOccupancy; //鼠标通道上锁情况
	std::string keyWords;//锁定秘钥-为Object的ID
private:
    // 私有构造函数
    Mouse();
    
    // 静态成员变量，保存唯一实例
    static Mouse* instance;

    // 数据成员
    
};
#endif