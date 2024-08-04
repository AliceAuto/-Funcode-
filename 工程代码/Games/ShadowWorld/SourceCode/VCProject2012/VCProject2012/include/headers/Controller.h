#ifndef CONTROLLER_H
#define CONTROLLER_H

#include <cmath>
#include <iostream>
#include <string>
#include <unordered_map>

// 简化的键盘输入检测函数
bool IsKeyPressed(char key) {
    // 这个函数应根据实际输入库实现
    // 这里仅为伪代码
    return false;
}

class PlayerController {
public:
    PlayerController(float initialX, float initialY, float speed)
        : posX(initialX), posY(initialY), baseSpeed(speed), velocityX(0), velocityY(0), isJumping(false) {}

    void ProcessInput(); // 处理玩家输入
    void Update(float deltaTime); // 更新角色状态
    void Render(); // 渲染角色

private:
    void Move(float vx, float vy); // 移动角色
    void Jump(); // 使角色跳跃

    float posX, posY; // 角色当前位置
    float baseSpeed; // 基础移动速度
    float velocityX, velocityY; // 角色当前的速度分量
    bool isJumping; // 是否处于跳跃状态
};

void PlayerController::ProcessInput() {
    float moveX = 0, moveY = 0;

    if (IsKeyPressed('W')) {
        moveY = 1; // 向上
    }
    if (IsKeyPressed('S')) {
        moveY = -1; // 向下
    }
    if (IsKeyPressed('A')) {
        moveX = -1; // 向左
    }
    if (IsKeyPressed('D')) {
        moveX = 1; // 向右
    }

    if (IsKeyPressed(' ')) {
        Jump();
    }

    Move(moveX * baseSpeed, moveY * baseSpeed);
}

void PlayerController::Move(float vx, float vy) {
    // 计算合成速度
    float combinedSpeed = sqrt(vx * vx + vy * vy);
    
    // 更新速度分量
    velocityX = vx;
    velocityY = vy;

    // 更新位置
    posX += vx;
    posY += vy;

    std::cout << "Current Speed: " << combinedSpeed << "\n";
}

void PlayerController::Jump() {
    if (!isJumping) {
        isJumping = true;
        // 设置跳跃初速度等
        std::cout << "Jumping...\n";
    }
}

void PlayerController::Update(float deltaTime) {
    ProcessInput();
    // 更新跳跃、物理等逻辑
    if (isJumping) {
        // 处理跳跃中的状态
        // ...
        isJumping = false; // 示例：假设跳跃结束
    }
}

void PlayerController::Render() {
    // 渲染角色，播放对应动画
    // 这里仅输出位置信息
    std::cout << "Player Position: (" << posX << ", " << posY << ")\n";
}

class AIController {
public:
    AIController(float initialX, float initialY, float speed)
        : posX(initialX), posY(initialY), baseSpeed(speed), velocityX(0), velocityY(0), currentState("Idle") {
        // 初始化状态机状态
        stateActions["Idle"] = &AIController::IdleAction;
        stateActions["Moving"] = &AIController::MoveAction;
        stateActions["Attacking"] = &AIController::AttackAction;
    }

    void ReceiveAIInput(float aiMoveX, float aiMoveY, const std::string& aiAction); // 接收AI输入
    void Update(float deltaTime); // 更新生物状态
    void Render() const; // 渲染生物

private:
    void Move(float vx, float vy); // 移动生物
    void PerformAction(const std::string& action); // 执行AI指定的动作
    void IdleAction();
    void MoveAction();
    void AttackAction();

    float posX, posY; // 生物当前位置
    float baseSpeed; // 基础移动速度
    float velocityX, velocityY; // 当前的速度分量
    std::string currentState; // 当前状态（如Idle, Moving, Attacking等）
    std::unordered_map<std::string, void(AIController::*)()> stateActions; // 状态动作映射
};

void AIController::ReceiveAIInput(float aiMoveX, float aiMoveY, const std::string& aiAction) {
    // 标准化输入
    float magnitude = sqrt(aiMoveX * aiMoveX + aiMoveY * aiMoveY);
    if (magnitude > 0) {
        aiMoveX /= magnitude;
        aiMoveY /= magnitude;
    }
    
    Move(aiMoveX * baseSpeed, aiMoveY * baseSpeed);
    PerformAction(aiAction);
}

void AIController::Move(float vx, float vy) {
    // 更新速度分量
    velocityX = vx;
    velocityY = vy;

    // 更新位置
    posX += velocityX;
    posY += velocityY;
}

void AIController::PerformAction(const std::string& action) {
    if (stateActions.find(action) != stateActions.end()) {
        currentState = action;
        (this->*stateActions[action])(); // 执行对应的状态动作
    }
}

void AIController::IdleAction() {
    std::cout << "AI is Idle...\n";
}

void AIController::MoveAction() {
    float combinedSpeed = sqrt(velocityX * velocityX + velocityY * velocityY);
    std::cout << "AI Moving with Speed: " << combinedSpeed << "\n";
}

void AIController::AttackAction() {
    std::cout << "AI is Attacking...\n";
}

void AIController::Update(float deltaTime) {
    // 可以在这里根据当前状态调整动画、物理效果等
    // 示例中直接保持当前状态即可
}

void AIController::Render() const {
    // 渲染生物，播放对应动画
    std::cout << "AI Position: (" << posX << ", " << posY << ") - State: " << currentState << "\n";
}

#endif // CONTROLLER_H
