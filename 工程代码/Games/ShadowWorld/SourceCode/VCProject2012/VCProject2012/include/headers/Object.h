#ifndef OBJECT_H
#define	OBJECT_H

#include <string>
#include "ResourceBag.h"  // ȷ��·����ȷ

class Object {
public:
    Object(float initialX, float initialY, const std::string& resourceBagName);
    virtual ~Object(); // ����������

    // �����ӿ�
    void Update(); // ����ʵ��״̬
    virtual void Init();
    virtual void breakdown();

    // �������Խӿ�
    float GetPosX() const;
    float GetPosY() const;
    float GetVelocityX() const;
    float GetVelocityY() const;

    // ���� ResourceBag �Ա�ֱ�Ӳ���
    ResourceBag * resourceBagPtr;
    std::string ID;

protected:
    // ��Ҫ����ʵ�ֵ��麯��
    virtual void UpdateState() {};
    virtual void UpdateAnimation() {};
	virtual void UpdateSound(){};

    // ��������
    void SetPosition(float x, float y);
    void SetVelocity(float vx, float vy);

    // �ڲ���Ա����
    std::string ResourceBagName;
    float posX, posY;
    float velocityX, velocityY;
};

#endif // ENTITY_H
