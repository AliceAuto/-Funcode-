#ifndef CHARACTERCONTROLLER_H
#define CHARACTERCONTROLLER_H

#include <string>
#include "CSprite.h"
#include "EventDrivenSystem.h"
#include "Logger.h"
#include "ResourceBag.h"

class CharacterController {
public:
    CharacterController(float initialX, float initialY,const ResourceBag * resourceBagPtr);
    virtual ~CharacterController(); // 虚析构函数

    // 为外部系统提供的接口
    virtual void ProcessInput(const Event& event); // 处理输入（虚函数）
    virtual void Update(); // 更新状态（虚函数）
    virtual void Render(); // 渲染状态（虚函数）

    // 资源管理接口
    void LoadResources(ResourceBag * resourceBagPtr);

protected:
    // 子类可以调用的公共方法
    virtual void UpdateState() = 0; // 更新状态（纯虚函数）
    virtual void UpdateAnimation() = 0; // 更新动画（纯虚函数）
    virtual void UpdateSound() = 0; // 更新音效（纯虚函数）

    // 公共属性
    float posX, posY; // 位置
    float velocityX, velocityY; // 速度分量
    enum class Facings {
        Up,
        Down,
        Left,
        Right
    };
    Facings facing; // 朝向

    // 公共实现方法
    void UpdateCommonState();
    void UpdateCommonAnimation();
    void UpdateCommonSound();

    const ResourceBag * resourceBagPtr; // 持有资源
};




#endif // CHARACTERCONTROLLER_H
