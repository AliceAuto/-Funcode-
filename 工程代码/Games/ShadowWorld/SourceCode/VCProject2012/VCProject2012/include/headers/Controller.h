#ifndef CONTROLLER_H
#define CONTROLLER_H

#include <cmath>
#include <iostream>
#include <string>
#include <unordered_map>

// �򻯵ļ��������⺯��
bool IsKeyPressed(char key) {
    // �������Ӧ����ʵ�������ʵ��
    // �����Ϊα����
    return false;
}

class PlayerController {
public:
    PlayerController(float initialX, float initialY, float speed)
        : posX(initialX), posY(initialY), baseSpeed(speed), velocityX(0), velocityY(0), isJumping(false) {}

    void ProcessInput(); // �����������
    void Update(float deltaTime); // ���½�ɫ״̬
    void Render(); // ��Ⱦ��ɫ

private:
    void Move(float vx, float vy); // �ƶ���ɫ
    void Jump(); // ʹ��ɫ��Ծ

    float posX, posY; // ��ɫ��ǰλ��
    float baseSpeed; // �����ƶ��ٶ�
    float velocityX, velocityY; // ��ɫ��ǰ���ٶȷ���
    bool isJumping; // �Ƿ�����Ծ״̬
};

void PlayerController::ProcessInput() {
    float moveX = 0, moveY = 0;

    if (IsKeyPressed('W')) {
        moveY = 1; // ����
    }
    if (IsKeyPressed('S')) {
        moveY = -1; // ����
    }
    if (IsKeyPressed('A')) {
        moveX = -1; // ����
    }
    if (IsKeyPressed('D')) {
        moveX = 1; // ����
    }

    if (IsKeyPressed(' ')) {
        Jump();
    }

    Move(moveX * baseSpeed, moveY * baseSpeed);
}

void PlayerController::Move(float vx, float vy) {
    // ����ϳ��ٶ�
    float combinedSpeed = sqrt(vx * vx + vy * vy);
    
    // �����ٶȷ���
    velocityX = vx;
    velocityY = vy;

    // ����λ��
    posX += vx;
    posY += vy;

    std::cout << "Current Speed: " << combinedSpeed << "\n";
}

void PlayerController::Jump() {
    if (!isJumping) {
        isJumping = true;
        // ������Ծ���ٶȵ�
        std::cout << "Jumping...\n";
    }
}

void PlayerController::Update(float deltaTime) {
    ProcessInput();
    // ������Ծ��������߼�
    if (isJumping) {
        // ������Ծ�е�״̬
        // ...
        isJumping = false; // ʾ����������Ծ����
    }
}

void PlayerController::Render() {
    // ��Ⱦ��ɫ�����Ŷ�Ӧ����
    // ��������λ����Ϣ
    std::cout << "Player Position: (" << posX << ", " << posY << ")\n";
}

class AIController {
public:
    AIController(float initialX, float initialY, float speed)
        : posX(initialX), posY(initialY), baseSpeed(speed), velocityX(0), velocityY(0), currentState("Idle") {
        // ��ʼ��״̬��״̬
        stateActions["Idle"] = &AIController::IdleAction;
        stateActions["Moving"] = &AIController::MoveAction;
        stateActions["Attacking"] = &AIController::AttackAction;
    }

    void ReceiveAIInput(float aiMoveX, float aiMoveY, const std::string& aiAction); // ����AI����
    void Update(float deltaTime); // ��������״̬
    void Render() const; // ��Ⱦ����

private:
    void Move(float vx, float vy); // �ƶ�����
    void PerformAction(const std::string& action); // ִ��AIָ���Ķ���
    void IdleAction();
    void MoveAction();
    void AttackAction();

    float posX, posY; // ���ﵱǰλ��
    float baseSpeed; // �����ƶ��ٶ�
    float velocityX, velocityY; // ��ǰ���ٶȷ���
    std::string currentState; // ��ǰ״̬����Idle, Moving, Attacking�ȣ�
    std::unordered_map<std::string, void(AIController::*)()> stateActions; // ״̬����ӳ��
};

void AIController::ReceiveAIInput(float aiMoveX, float aiMoveY, const std::string& aiAction) {
    // ��׼������
    float magnitude = sqrt(aiMoveX * aiMoveX + aiMoveY * aiMoveY);
    if (magnitude > 0) {
        aiMoveX /= magnitude;
        aiMoveY /= magnitude;
    }
    
    Move(aiMoveX * baseSpeed, aiMoveY * baseSpeed);
    PerformAction(aiAction);
}

void AIController::Move(float vx, float vy) {
    // �����ٶȷ���
    velocityX = vx;
    velocityY = vy;

    // ����λ��
    posX += velocityX;
    posY += velocityY;
}

void AIController::PerformAction(const std::string& action) {
    if (stateActions.find(action) != stateActions.end()) {
        currentState = action;
        (this->*stateActions[action])(); // ִ�ж�Ӧ��״̬����
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
    // ������������ݵ�ǰ״̬��������������Ч����
    // ʾ����ֱ�ӱ��ֵ�ǰ״̬����
}

void AIController::Render() const {
    // ��Ⱦ������Ŷ�Ӧ����
    std::cout << "AI Position: (" << posX << ", " << posY << ") - State: " << currentState << "\n";
}

#endif // CONTROLLER_H
