#ifndef ENTITY_H
#define ENTITY_H


//�ϸ���:   ==>   һ�пɼ��Ķ���












#include <string>
#include "ResourceBag.h"

class Entity {
public:
    Entity(float initialX, float initialY);
    virtual ~Entity(); // ����������

    // �����ӿ�
    void Update(); // ����ʵ��״̬
	virtual void Init(const std::string & bag){}
    // �������Խӿ�
    float GetPosX() const;
    float GetPosY() const;
    float GetVelocityX() const;
    float GetVelocityY() const;
	
    // ���� ResourceBag �Ա�ֱ�Ӳ���
    ResourceBag* resourceBagPtr;
	virtual void ifCollision(Entity * otherEntity);
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
};

#endif // ENTITY_H
