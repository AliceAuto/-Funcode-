#ifndef ENTITY_H
#define ENTITY_H

#include <string> // ȷ��·����ȷ
#include "Object.h"
class Entity :public Object {
public:
    Entity(float initialX, float initialY, const std::string& resourceBagName);
    virtual ~Entity(); // ����������

    // �����ӿ�

    virtual void Init();
    virtual void breakdown();
    virtual void ifCollision(Entity* otherEntity);
protected:
    // ��Ҫ����ʵ�ֵ��麯��
	void UpdateState() ;
    void UpdateAnimation() ;
    void UpdateSound() ;
};

#endif // ENTITY_H
