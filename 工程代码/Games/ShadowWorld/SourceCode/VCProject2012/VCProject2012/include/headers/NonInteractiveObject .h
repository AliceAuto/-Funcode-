#ifndef NONINTERACTIVEOBJECT_H
#define NONINTERACTIVEOBJECT_H

#include "Entity.h"
#include <string>
//==========================================================================================================================
//														以下是 非交强互类实体 声明
//=======================================================================================================================

//==========================================================================================================

// 非交互对象类声明
class NonInteractiveObject : public Entity {
public:
    // 构造函数
    NonInteractiveObject(float initialX, float initialY, const std::string& resourceBagName);

    // 虚析构函数
    virtual ~NonInteractiveObject();

    // 初始化函数
    void Init() override;
	void breakdown() override;
	
protected:
    // 提供默认实现，允许子类选择性重写
    virtual void UpdateState() override;
    virtual void UpdateAnimation() override;
    virtual void UpdateSound() override;
};

// 物理性实体类声明
class PhysicalObject : public NonInteractiveObject {
public:
    // 构造函数
    PhysicalObject(float initialX, float initialY, const std::string& resourceBagName);

    // 虚析构函数
    virtual ~PhysicalObject();
	void Init() override;
	void breakdown() override;
protected:
    // 重写更新状态，处理物理运动
    void UpdateState() override;
    void UpdateAnimation() override;
    void UpdateSound() override;

    // 物理性实体特有的属性
    float velocityX;
    float velocityY;
    void ApplyPhysics();
};

// 障碍物实体类声明
class ObstacleObject : public NonInteractiveObject {
public:
    // 构造函数

    ObstacleObject(float initialX, float initialY, const std::string& resourceBagName);

    // 虚析构函数
    virtual ~ObstacleObject();
	void Init() override;
	void breakdown() override;
protected:
    // 重写更新状态，处理位置不变的逻辑
    void UpdateState() override;
};


//子弹类
class Bullet : public NonInteractiveObject {
public:
    // 构造函数
    Bullet(float initialX, float initialY, const std::string& resourceBagName, float speed, float direction);

    // 析构函数
    virtual ~Bullet();

    // 初始化
    virtual void Init() override;

    // 资源清理
    virtual void breakdown() override;

    // 更新状态
    virtual void UpdateState() override;

    // 更新动画
    virtual void UpdateAnimation() override;

    // 更新声音
    virtual void UpdateSound() override;

private:
    float speed;       // 子弹的速度
    float direction;   // 子弹的方向（以弧度为单位）
	
    // 移动子弹
};
//==========================================================================================================

#endif // NONINTERACTIVEOBJECT_H
