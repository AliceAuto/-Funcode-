#ifndef DYNAMICSWITCHES_H
#define DYNAMICSWITCHES_H
#include "SimpleFunc.h"
#include <vector>
/*
  @brief 这是一个 DynamicSwitches类  继承自  SimpleObject

 这个类是一个01状态管理池,采用位运算和动态结构来实现，可实现任意的开关容量,并且具有高效的操作效率,适合用于大规模01状态管理

 * @author	孙国庆
 * @date 2024-07-29
 */
class DynamicSwitches:public SimpleFunc {



private:
    std::vector<unsigned int> switches; // 使用一个 unsigned int 数组来存储开关状态

public:
    // 构造函数，初始化开关状态数组
    DynamicSwitches(size_t numSwitches);
    // 设置指定位置的开关状态
    void setSwitch(size_t index, bool state);

    // 获取指定位置的开关状态
    bool getSwitch(size_t index) const;

    // 清除所有开关状态
    void clearSwitches();

    // 获取开关总数
	// Num 将会是 32 的倍数
    size_t getNumSwitches() const;
};

#endif // DYNAMICSWITCHES_H