#ifndef NONINTERACTIVEOBJECT_H
#define NONINTERACTIVEOBJECT_H

//严格定义     ==>     非软交互对象











#include "Entity.h"

// 非交互对象类声明
class NonInteractiveObject : public Entity {
public:
    // 构造函数
    NonInteractiveObject(float initialX, float initialY);

    // 虚析构函数
    virtual ~NonInteractiveObject();

protected:
    // 提供默认实现，允许子类选择性重写
    virtual void UpdateState() override;
    virtual void UpdateAnimation() override;
    virtual void UpdateSound() override;

    // 其他非交互对象特有的属性和方法
};

#endif // NONINTERACTIVEOBJECT_H
