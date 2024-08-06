#ifndef CONTROLLER_H
#define CONTROLLER_H

#include <string>
#include "CSprite.h"
#include "CSystem.h"
#include "Setting.h"
#include "EventDrivenSystem.h"

class PlayerController {
public:
    PlayerController(float initialX, float initialY, float speed);
    ~PlayerController(); // 添加析构函数

    void ProcessInput(const Event& event); // 处理玩家输入
    void Update(); // 更新角色状态
    void Render(); // 渲染角色

private:
    CAnimateSprite* spritePtr;

    void Move(); // 移动角色
    void UpdateAnimation(); // 更新角色动画

    float posX, posY; // 角色当前位置
    float baseSpeed; // 基础移动速度
    float velocityX, velocityY; // 角色当前的速度分量
};

extern PlayerController player;

#endif // CONTROLLER_H
