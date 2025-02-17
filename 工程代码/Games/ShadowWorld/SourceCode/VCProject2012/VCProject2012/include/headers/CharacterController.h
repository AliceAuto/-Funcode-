#ifndef CHARACTERCONTROLLER_H
#define CHARACTERCONTROLLER_H

#include "Entity.h"

class CharacterController : public Entity {
public:
    CharacterController(float initialX, float initialY,  ResourceBag* resourceBagPtr);
    virtual ~CharacterController(); // 虚析构函数

    // 处理输入（虚函数）
    virtual void ProcessInput(const Event& event);

protected:
    // 提供默认实现，允许子类选择性重写
    virtual void UpdateState() override;
    virtual void UpdateAnimation() override;
    virtual void UpdateSound() override;

    // 角色特有属性
    enum Facings { Up, Down, Left, Right };
    Facings facing;
};

#endif // CHARACTERCONTROLLER_H
