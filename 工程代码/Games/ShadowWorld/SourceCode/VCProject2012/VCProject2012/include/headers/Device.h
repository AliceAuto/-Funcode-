#ifndef DEVICE_H
#define DEVICE_H

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

private:
    // 私有构造函数
    Mouse();
    
    // 静态成员变量，保存唯一实例
    static Mouse* instance;

    // 数据成员
    
};
#endif