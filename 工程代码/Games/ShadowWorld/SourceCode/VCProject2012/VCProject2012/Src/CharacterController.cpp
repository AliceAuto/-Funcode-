#include "CharacterController.h"
#include "Logger.h"

CharacterController::CharacterController(float initialX, float initialY, ResourceBag* resourceBagPtr)
    : Entity(initialX, initialY, resourceBagPtr), facing(Facings::Down) {}

CharacterController::~CharacterController() {}

void CharacterController::UpdateState() {
    // 默认实现，可以被子类重写
    if (resourceBagPtr != nullptr && resourceBagPtr->Character != nullptr) {
        resourceBagPtr->Character->SetSpriteLinearVelocityX(velocityX);
        resourceBagPtr->Character->SetSpriteLinearVelocityY(velocityY);

        posX = resourceBagPtr->Character->GetSpritePositionX();
        posY = resourceBagPtr->Character->GetSpritePositionY();

        if (velocityX == 0 && velocityY > 0) {
            facing = Facings::Down;
        } else if (velocityX > 0 && velocityY == 0) {
            facing = Facings::Right;
        } else if (velocityX == 0 && velocityY < 0) {
            facing = Facings::Up;
        } else if (velocityX < 0 && velocityY == 0) {
            facing = Facings::Left;
        }
    } else {
        LogManager::Log("资源指针为空");
    }
}

void CharacterController::UpdateAnimation() {
    // 默认实现，可以被子类重写
    static std::string currentAnimation;
    if (resourceBagPtr == nullptr || resourceBagPtr->Character == nullptr) return;

    std::string ani;
    if (velocityX == 0 && velocityY > 0) {
        ani = "to_down";
    } else if (velocityX > 0 && velocityY == 0) {
        ani = "to_right";
    } else if (velocityX == 0 && velocityY < 0) {
        ani = "to_up";
    } else if (velocityX < 0 && velocityY == 0) {
        ani = "to_left";
    }

    if (currentAnimation != ani && resourceBagPtr != nullptr && resourceBagPtr->Character != nullptr) {
        resourceBagPtr->Character->AnimateSpritePlayAnimation(ani.c_str(), false);
        currentAnimation = ani;
    } else if (resourceBagPtr != nullptr && resourceBagPtr->Character != nullptr && resourceBagPtr->Character->IsAnimateSpriteAnimationFinished()) {
        resourceBagPtr->Character->AnimateSpritePlayAnimation(ani.c_str(), true);
        LogManager::Log("动画停止");
    }
}

void CharacterController::UpdateSound() {
    // 默认实现，可以被子类重写
    static std::string currentSound;
    if ((velocityX != 0 || velocityY != 0)) {
        if (resourceBagPtr != nullptr && resourceBagPtr->running != nullptr && currentSound != resourceBagPtr->running->GetName()) {
            resourceBagPtr->running->PlaySound();
            currentSound = resourceBagPtr->running->GetName();
        }
    } else {
        if (currentSound != "") {
            resourceBagPtr->running->StopSound();
            currentSound = "";
        }
    }
}

void CharacterController::ProcessInput(const Event& event) {
    if (event.GetType() == EventType::KeyboardInput) {
        LogManager::Log("键盘事件接收成功,正在处理输入信息");
        const KeyboardInputEvent& keyEvent = static_cast<const KeyboardInputEvent&>(event);
        LogManager::Log("[处理] 拆解输入包...");
        if (keyEvent.GetState() == KeyboardInputEvent::State::KEY_ON) {
            switch (keyEvent.GetKey()) {
                case KeyCodes::KEY_W:
                    velocityY = -10;
                    break;
                case KeyCodes::KEY_S:
                    velocityY = 10;
                    break;
                case KeyCodes::KEY_A:
                    velocityX = -10;
                    break;
                case KeyCodes::KEY_D:
                    velocityX = 10;
                    break;
                default:
                    break;
            }
        } else {
            switch (keyEvent.GetKey()) {
                case KeyCodes::KEY_W:
                case KeyCodes::KEY_S:
                    velocityY = 0;
                    break;
                case KeyCodes::KEY_A:
                case KeyCodes::KEY_D:
                    velocityX = 0;
                    break;
                default:
                    break;
            }
        }
    }
    LogManager::Log("< " + std::to_string(velocityX) + "," + std::to_string(velocityY) + ">");
}
