#ifndef ENTITY_H
#define ENTITY_H

#include <string>
#include "ResourceBag.h"

class Entity {
public:
    Entity(float initialX, float initialY,  ResourceBag * resourceBagPtr);
    virtual ~Entity(); // ����������

    // �����ӿ�
    void Update(); // ��ֹ������д��ģ�巽��

    // ��Դ����ӿ�
    void LoadResources(ResourceBag * resourceBagPtr);

    // �������Խӿ�
    float GetPosX() const;
    float GetPosY() const;
    float GetVelocityX() const;
    float GetVelocityY() const;

protected:
    // ��Ҫ����ʵ�ֵ��麯��
    virtual void UpdateState() = 0;
    virtual void UpdateAnimation() = 0;
    virtual void UpdateSound() = 0;

    // ��������
    void SetPosition(float x, float y);
    void SetVelocity(float vx, float vy);

    // �ڲ���Ա����
    float posX, posY;
    float velocityX, velocityY;
    ResourceBag * resourceBagPtr;
};

#endif // ENTITY_H
