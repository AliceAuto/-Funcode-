#include "DynamicSwitches.h"

DynamicSwitches::DynamicSwitches(size_t numSwitches) {
    // ��������� unsigned int �����С��ÿ�� unsigned int ���Դ洢 32 λ����״̬
    size_t numInts = (numSwitches + 31) / 32;
    switches.resize(numInts, 0); // ��ʼ�����飬���п���״̬Ĭ��Ϊ 0
}

void DynamicSwitches::setSwitch(size_t index, bool state) {
    if (state) {
        switches[index / 32] |= (1u << (index % 32)); // ��ָ��λ����Ϊ1
    } else {
        switches[index / 32] &= ~(1u << (index % 32)); // ��ָ��λ����
    }
}

bool DynamicSwitches::getSwitch(size_t index) const {
    return (switches[index / 32] & (1u << (index % 32))) != 0; // ��ȡָ��λ��״̬
}

void DynamicSwitches::clearSwitches() {
    switches.assign(switches.size(), 0); // �������飬���п���״̬����
}

size_t DynamicSwitches::getNumSwitches() const {
    return switches.size() * 32; // �����ܿ�����
}
