#include "CharacterController.h"
#include "Logger.h"
#include <cmath>
CharacterController::CharacterController(float initialX, float initialY)
    : Entity(initialX, initialY), facing(Facings::Down),forceX(0),forceY(0) {



    // 其他初始化代码
}
void CharacterController::Init(const std::string & bag){
	//对物理人物进行初始化
	this->resourceBagPtr->LoadFromJson(bag);
	this->resourceBagPtr->GetResource<CAnimateSprite>("Entity").get()->SetSpritePosition(posX,posY);
	this->resourceBagPtr->GetResource<CAnimateSprite>("Entity").get()->SetSpriteMass(100);
	this->resourceBagPtr->GetResource<CAnimateSprite>("Entity").get()->SetSpriteAtRest(false);
	this->resourceBagPtr->GetResource<CAnimateSprite>("Entity").get()->SetSpriteInertialMoment(100);
	this->resourceBagPtr->GetResource<CAnimateSprite>("Entity").get()->SetSpriteAutoMassInertia(true);
	this->resourceBagPtr->GetResource<CAnimateSprite>("Entity").get()->SetSpriteMaxLinearVelocity(20);
	mess = this->resourceBagPtr->GetResource<CAnimateSprite>("Entity").get()->GetSpriteMass();
}
CharacterController::~CharacterController() {
    // 清理代码，如果有需要的话
}

void CharacterController::UpdateState() {
    // 默认实现，可以被子类重写
	LogManager::Log("状态已更新");
    CAnimateSprite* AnimatePtr = resourceBagPtr->GetResource<CAnimateSprite>("Entity").get();

    if (AnimatePtr) {

        // 成功转换
    } else {
        // 转换失败
        LogManager::Log("动态转换失败，资源类型错误或资源为空。");
    }

    if (AnimatePtr != nullptr) {
		// 初始化摩擦力
       // 初始化摩擦力
    static const float frictionCoefficient = 40; // 摩擦系数，根据需要调整
    static const float velocityThreshold = 1; // 速度阈值，小于此值将速度设为零

    // 更新速度
    velocityX = AnimatePtr->GetSpriteLinearVelocityX();
    velocityY = AnimatePtr->GetSpriteLinearVelocityY();

    // 计算摩擦力
    float frictionForceX = 0;
    float frictionForceY = 0;

    if (std::abs(velocityX) > velocityThreshold) {
        frictionForceX = -frictionCoefficient * mess*(velocityX/std::abs(velocityX));
    }
    if (std::abs(velocityY) > velocityThreshold) {
        frictionForceY = -frictionCoefficient * mess* (velocityY/std::abs(velocityY));
    }

    // 将摩擦力和外力应用到角色上
    AnimatePtr->SetSpriteConstantForce(forceX + frictionForceX, forceY + frictionForceY, false);

    // 如果速度低于阈值，直接将速度设为零
    if (std::abs(velocityX) < velocityThreshold) {
        AnimatePtr->SetSpriteLinearVelocityX(0);
    }
    if (std::abs(velocityY) < velocityThreshold) {
        AnimatePtr->SetSpriteLinearVelocityY(0);
    }

    // 更新位置
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
	
    CAnimateSprite* AnimatePtr = resourceBagPtr->GetResource<CAnimateSprite>("Entity").get();
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
		LogManager::Log("动画已更新");
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
                    forceY -= 80000;
                    break;
                case KeyCodes::KEY_S:
                    forceY += 80000;
                    break;
                case KeyCodes::KEY_A:
                    forceX -=80000;
                    break;
                case KeyCodes::KEY_D:
                    forceX += 80000;
                    break;
				case KeyCodes::KEY_SPACE:
                    this->resourceBagPtr->GetResource<CAnimateSprite>("Entity").get()->SetSpriteMaxLinearVelocity(200);
                    break;
                default:
                    break;
            }
        } else {
            switch (keyEvent.GetKey()) {
                case KeyCodes::KEY_W:
					forceY +=80000 ;
                    break;
                case KeyCodes::KEY_S:
                    forceY -= 80000;
                    break;
                case KeyCodes::KEY_A:
					forceX += 80000;
                    break;
                case KeyCodes::KEY_D:
                    forceX -= 80000;
                    break;
				case KeyCodes::KEY_SPACE:
                    this->resourceBagPtr->GetResource<CAnimateSprite>("Entity").get()->SetSpriteMaxLinearVelocity(20);
                    break;
                default:
                    break;
            }
        }
    }
  
}
