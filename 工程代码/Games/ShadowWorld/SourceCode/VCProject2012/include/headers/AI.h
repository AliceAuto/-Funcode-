#ifndef AICONTROLLER_H
#define AICONTROLLER_H

#include "Statemachine.h"
#include "CharacterController.h"
#include <memory> // For std::unique_ptr
#include <cstdlib> // For std::rand
#include <cmath> // For std::abs

// AI 状态基类
class AIState : public State {
public:
    virtual ~AIState() {}
    virtual void Enter() override = 0;
    virtual void Exit() override = 0;
    virtual void Update(int userChoice) override = 0;
    virtual std::string GetNextState(int userChoice) override = 0;

protected:
    CharacterController* character; // 与角色控制器关联
};

// 随机移动状态
class RandomMoveState : public AIState {
public:
    RandomMoveState(CharacterController* character) {
        this->character = character;
    }

    virtual void Enter() override {
        // 进入状态时的初始化
    }

    virtual void Exit() override {
        // 退出状态时的清理
    }

    virtual void Update(int userChoice) override {
        int direction = std::rand() % 4;
        switch (direction) {
            case 0: character->ProcessInput(KeyboardInputEvent(KeyCodes::KEY_W, KeyboardInputEvent::State::KEY_ON)); break;
            case 1: character->ProcessInput(KeyboardInputEvent(KeyCodes::KEY_S, KeyboardInputEvent::State::KEY_ON)); break;
            case 2: character->ProcessInput(KeyboardInputEvent(KeyCodes::KEY_A, KeyboardInputEvent::State::KEY_ON)); break;
            case 3: character->ProcessInput(KeyboardInputEvent(KeyCodes::KEY_D, KeyboardInputEvent::State::KEY_ON)); break;
        }
    }

    virtual std::string GetNextState(int userChoice) override {
        // 返回下一个状态的名称，这里可以是逻辑
        return "ChasingState"; // 示例返回，实际逻辑可能不同
    }
};

// 追逐玩家状态
class ChasingState : public AIState {
public:
    ChasingState(CharacterController* character, CharacterController* target) {
        this->character = character;
        this->target = target;
    }

    virtual void Enter() override {
        // 进入状态时的初始化
    }

    virtual void Exit() override {
        // 退出状态时的清理
    }

    virtual void Update(int userChoice) override {
        if (!target) return;

        float deltaX = target->GetPosX() - character->GetPosX();
        float deltaY = target->GetPosY() - character->GetPosY();

        if (std::abs(deltaX) > std::abs(deltaY)) {
            if (deltaX > 0) {
                character->ProcessInput(KeyboardInputEvent(KeyCodes::KEY_D, KeyboardInputEvent::State::KEY_ON));
            } else {
                character->ProcessInput(KeyboardInputEvent(KeyCodes::KEY_A, KeyboardInputEvent::State::KEY_ON));
            }
        } else {
            if (deltaY > 0) {
                character->ProcessInput(KeyboardInputEvent(KeyCodes::KEY_S, KeyboardInputEvent::State::KEY_ON));
            } else {
                character->ProcessInput(KeyboardInputEvent(KeyCodes::KEY_W, KeyboardInputEvent::State::KEY_ON));
            }
        }
    }

    virtual std::string GetNextState(int userChoice) override {
        // 返回下一个状态的名称，这里可以是逻辑
        return "RandomMoveState"; // 示例返回，实际逻辑可能不同
    }

private:
    CharacterController* target;
};

// AI 控制器
class AIController {
public:
    AIController(CharacterController* character) : character_(character) {}

    void SetStateMachine(StateMachine* stateMachine) {
        this->stateMachine.reset(stateMachine);
        stateMachine->SetCurrentState("RandomMoveState"); // 初始状态
    }

    void Update(int userChoice) {
        if (stateMachine) {
            stateMachine->Update(userChoice);
        }
    }

private:
    CharacterController* character_;
    std::unique_ptr<StateMachine> stateMachine;
};

#endif // AICONTROLLER_H
