#ifndef DEVICE_H
#define DEVICE_H
#include "Object.h"
class Mouse {
public:
    // ��ȡΨһʵ���ľ�̬����
    static Mouse& Instance();

    // ɾ�����ƹ��캯���͸�ֵ�����
   
	float x;
    float y;
    bool leftPressed;
    bool middlePressed;
    bool rightPressed;
	bool ChannelOccupancy; //���ͨ���������
	std::string keyWords;//������Կ-ΪObject��ID
private:
    // ˽�й��캯��
    Mouse();
    
    // ��̬��Ա����������Ψһʵ��
    static Mouse* instance;

    // ���ݳ�Ա
    
};
#endif