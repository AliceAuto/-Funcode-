#ifndef DEVICE_H
#define DEVICE_H

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

private:
    // ˽�й��캯��
    Mouse();
    
    // ��̬��Ա����������Ψһʵ��
    static Mouse* instance;

    // ���ݳ�Ա
    
};
#endif