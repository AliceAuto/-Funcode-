#ifndef ENTITY_H
#define ENTITY_H

#include <string>
#include "ResourceBag.h"

class Entity {
public:
    Entity(float initialX, float initialY,  ResourceBag * resourceBagPtr);
    virtual ~Entity(); // 虚析构函数

    // 公共接口
    void Update(); // 禁止子类重写的模板方法

    // 资源管理接口
    void LoadResources(ResourceBag * resourceBagPtr);

    // 物理属性接口
    float GetPosX() const;
    float GetPosY() const;
    float GetVelocityX() const;
    float GetVelocityY() const;

protected:
    // 需要子类实现的虚函数
    virtual void UpdateState() = 0;
    virtual void UpdateAnimation() = 0;
    virtual void UpdateSound() = 0;

    // 公共方法
    void SetPosition(float x, float y);
    void SetVelocity(float vx, float vy);

    // 内部成员变量
    float posX, posY;
    float velocityX, velocityY;
    ResourceBag * resourceBagPtr;
};

#endif // ENTITY_H
