#ifndef NONINTERACTIVEOBJECT_H
#define NONINTERACTIVEOBJECT_H

#include "Entity.h"

// 非交互对象类声明
class NonInteractiveObject : public Entity {
public:
    // 构造函数
<<<<<<< Updated upstream
    NonInteractiveObject(float initialX, float initialY,  ResourceBag* resourceBagPtr);
=======
    NonInteractiveObject(float initialX, float initialY,std::string & resourceBag);
>>>>>>> Stashed changes

    // 虚析构函数
    virtual ~NonInteractiveObject();

<<<<<<< Updated upstream
=======
    // 虚函数，允许子类重写
    void Init() override;

>>>>>>> Stashed changes
protected:
    // 提供默认实现，允许子类选择性重写
    virtual void UpdateState() override;
    virtual void UpdateAnimation() override;
    virtual void UpdateSound() override;

    // 其他非交互对象特有的属性和方法
};

//===================================================================
// 物理碰撞体类
class PhysicalCollisionBody : public NonInteractiveObject {
public:
    PhysicalCollisionBody(float initialX, float initialY,std::string & resourceBag);
    virtual ~PhysicalCollisionBody();

    // 重写 Init 方法
    void Init() override;
};

// 子弹类
class Bullet : public PhysicalCollisionBody {
public:
    Bullet(float initialX, float initialY, float speedX, float speedY,std::string & resourceBag);
    virtual ~Bullet();

    // 重写更新状态的方法
    void UpdateState() override;
	void UpdateAnimation() override;
	void UpdateSound()override;

    // 重写 Init 方法
    void Init() override;

private:
    float speedX;  // 子弹在X轴上的速度
    float speedY;  // 子弹在Y轴上的速度
};

// 固定障碍物类
class FixedObstacle : public PhysicalCollisionBody {
public:
    FixedObstacle(float initialX, float initialY,std::string & resourceBag);
    virtual ~FixedObstacle();

    // 重写 Init 方法
    void Init() override;
};

#endif // NONINTERACTIVEOBJECT_H
