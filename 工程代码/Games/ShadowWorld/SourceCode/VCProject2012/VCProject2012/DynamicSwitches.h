#ifndef DYNAMICSWITCHES_H
#define DYNAMICSWITCHES_H
#include "SimpleFunc.h"
#include <vector>
/*
  @brief ����һ�� DynamicSwitches��  �̳���  SimpleObject

 �������һ��01״̬�����,����λ����Ͷ�̬�ṹ��ʵ�֣���ʵ������Ŀ�������,���Ҿ��и�Ч�Ĳ���Ч��,�ʺ����ڴ��ģ01״̬����

 * @author	�����
 * @date 2024-07-29
 */
class DynamicSwitches:public SimpleFunc {



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
	// Num ������ 32 �ı���
    size_t getNumSwitches() const;
};

#endif // DYNAMICSWITCHES_H