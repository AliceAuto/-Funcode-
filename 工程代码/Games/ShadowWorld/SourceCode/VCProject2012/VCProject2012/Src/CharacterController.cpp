#include "CharacterController.h"
#include "Logger.h"

CharacterController::CharacterController(float initialX, float initialY)
    : Entity(initialX, initialY), facing(Facings::Down) {
    // 其他初始化代码
}

CharacterController::~CharacterController() {
    // 清理代码，如果有需要的话
}

void CharacterController::UpdateState() {
    // 默认实现，可以被子类重写
	LogManager::Log("状态已更新");
    CAnimateSprite* AnimatePtr = this ->resourceBagPtr->GetResource<CAnimateSprite>("Character").get();

    if (AnimatePtr) {
        // 成功转换
    } else {
        // 转换失败
        LogManager::Log("动态转换失败，资源类型错误或资源为空。");
    }

    if (AnimatePtr != nullptr) {
		
        AnimatePtr->SetSpriteLinearVelocity(velocityX, velocityY);LogManager::Log(std::to_string(AnimatePtr->GetSpriteLinearVelocityX()));
		LogManager::Log(std::to_string(posX)+std::to_string(posY));
        posX = AnimatePtr->GetSpritePositionX();
        posY = AnimatePtr->GetSpritePositionY();

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
        LogManager::Log("资源指针为空：UpdateState");
    }
}

void CharacterController::UpdateAnimation() {
    // 默认实现，可以被子类重写
	
    CAnimateSprite* AnimatePtr = resourceBagPtr->GetResource<CAnimateSprite>("Character").get();
    static std::string currentAnimation;
    
    if (AnimatePtr == nullptr) return;

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

    if (currentAnimation != ani && AnimatePtr != nullptr) {
		LogManager::Log("动画已更换");
        AnimatePtr->AnimateSpritePlayAnimation(ani.c_str(), false);
        currentAnimation = ani;
    } else if (resourceBagPtr != nullptr && AnimatePtr != nullptr && AnimatePtr->IsAnimateSpriteAnimationFinished()) {
		LogManager::Log("动画已更新====");
        AnimatePtr->AnimateSpritePlayAnimation(ani.c_str(), true);
		
    }
}

void CharacterController::UpdateSound() {
    // 默认实现，可以被子类重写 
	LogManager::Log("声音已更新");
    CSound* SoundPtr = resourceBagPtr->GetResource<CSound>("running").get();
    static std::string currentSound;
 
    if ((velocityX != 0 || velocityY != 0)) {
        if (resourceBagPtr != nullptr && SoundPtr != nullptr && currentSound != SoundPtr->GetName()) {
            SoundPtr->PlaySound();
            currentSound = SoundPtr->GetName();
			
        }
    } else {
        if (currentSound != "") {
            SoundPtr->StopSound();
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
