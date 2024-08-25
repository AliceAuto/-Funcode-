#ifndef ENTITY_H
#define ENTITY_H


//严格定义:   ==>   一切可见的对象












#include <string>
#include "ResourceBag.h"

class Entity {
public:
    Entity(float initialX, float initialY);
    virtual ~Entity(); // 虚析构函数

    // 公共接口
    void Update(); // 更新实体状态
	virtual void Init(const std::string & bag){}
    // 物理属性接口
    float GetPosX() const;
    float GetPosY() const;
    float GetVelocityX() const;
    float GetVelocityY() const;
	
    // 公开 ResourceBag 以便直接操作
    ResourceBag* resourceBagPtr;
	virtual void ifCollision(Entity * otherEntity);
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
};

#endif // ENTITY_H
