#ifndef ENTITY_H
#define ENTITY_H

#include <string>
#include "ResourceBag.h"  // 确保路径正确

class Entity {
public:
    Entity(float initialX, float initialY, const std::string& resourceBagName);
    virtual ~Entity(); // 虚析构函数

    // 公共接口
    void Update(); // 更新实体状态
    virtual void Init();
    virtual void breakdown();

    // 物理属性接口
    float GetPosX() const;
    float GetPosY() const;
    float GetVelocityX() const;
    float GetVelocityY() const;

    // 公开 ResourceBag 以便直接操作
    ResourceBag * resourceBagPtr;
    virtual void ifCollision(Entity* otherEntity);
    std::string ID;

protected:
    // 需要子类实现的虚函数
    virtual void UpdateState() = 0;
    virtual void UpdateAnimation() = 0;
    virtual void UpdateSound() = 0;

    // 公共方法
    void SetPosition(float x, float y);
    void SetVelocity(float vx, float vy);

    // 内部成员变量
    std::string ResourceBagName;
    float posX, posY;
    float velocityX, velocityY;
};

#endif // ENTITY_H
