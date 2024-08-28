#ifndef ENTITY_H
#define ENTITY_H

#include <string>
#include "ResourceBag.h"  // ȷ��·����ȷ

class Entity {
public:
    Entity(float initialX, float initialY, const std::string& resourceBagName);
    virtual ~Entity(); // ����������

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
    virtual void ifCollision(Entity* otherEntity);
    std::string ID;

protected:
    // ��Ҫ����ʵ�ֵ��麯��
    virtual void UpdateState() = 0;
    virtual void UpdateAnimation() = 0;
    virtual void UpdateSound() = 0;

    // ��������
    void SetPosition(float x, float y);
    void SetVelocity(float vx, float vy);

    // �ڲ���Ա����
    std::string ResourceBagName;
    float posX, posY;
    float velocityX, velocityY;
};

#endif // ENTITY_H
