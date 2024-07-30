#ifndef DYNAMICSWITCHES_H
#define DYNAMICSWITCHES_H

#include <vector>
/*
 * @brief ����һ�� DynamicSwitches��
 * �̳���  SimpleObject
 *        
 * @author	�����
 * @date 2024-07-29
 */
class DynamicSwitches {
private:
    std::vector<unsigned int> switches; // ʹ��һ�� unsigned int �������洢����״̬

public:
    // ���캯������ʼ������״̬����
    DynamicSwitches(size_t numSwitches);

    // ����ָ��λ�õĿ���״̬
    void setSwitch(size_t index, bool state);

    // ��ȡָ��λ�õĿ���״̬
    bool getSwitch(size_t index) const;

    // ������п���״̬
    void clearSwitches();

    // ��ȡ��������
    size_t getNumSwitches() const;
};

#endif // DYNAMICSWITCHES_H