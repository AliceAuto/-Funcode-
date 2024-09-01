#ifndef ENTITY_H
#define ENTITY_H

#include <string> // 确保路径正确
#include "Object.h"
class Entity :public Object {
public:
    Entity(float initialX, float initialY, const std::string& resourceBagName);
    virtual ~Entity(); // 虚析构函数

    // 公共接口

    virtual void Init();
    virtual void breakdown();
    virtual void ifCollision(Entity* otherEntity);
protected:
    // 需要子类实现的虚函数
	void UpdateState() ;
    void UpdateAnimation() ;
    void UpdateSound() ;
};

#endif // ENTITY_H
