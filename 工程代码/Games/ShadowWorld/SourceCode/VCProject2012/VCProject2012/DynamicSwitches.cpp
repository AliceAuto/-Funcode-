#include "DynamicSwitches.h"

DynamicSwitches::DynamicSwitches(size_t numSwitches) {
    // 计算所需的 unsigned int 数组大小，每个 unsigned int 可以存储 32 位开关状态
    size_t numInts = (numSwitches + 31) / 32;
    switches.resize(numInts, 0); // 初始化数组，所有开关状态默认为 0
}

void DynamicSwitches::setSwitch(size_t index, bool state) {
    if (state) {
        switches[index / 32] |= (1u << (index % 32)); // 将指定位设置为1
    } else {
        switches[index / 32] &= ~(1u << (index % 32)); // 将指定位清零
    }
}

bool DynamicSwitches::getSwitch(size_t index) const {
    return (switches[index / 32] & (1u << (index % 32))) != 0; // 获取指定位的状态
}

void DynamicSwitches::clearSwitches() {
    switches.assign(switches.size(), 0); // 重置数组，所有开关状态清零
}

size_t DynamicSwitches::getNumSwitches() const {
    return switches.size() * 32; // 计算总开关数
}
