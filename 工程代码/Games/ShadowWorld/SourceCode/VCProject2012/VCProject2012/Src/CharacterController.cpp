#include "CharacterController.h"
#include "Logger.h"
#include <cmath>
#include "CGameMain.h"
//======================================================
/*
                        CharacterController 类的实现
*/
//======================================================





// [说明]
// 构造函数：初始化角色控制器
// 初始化角色控制器，设置初始位置、资源包名称，以及初始面朝方向和力的状态
// 参数:
//   - initialX: 角色的初始 X 坐标
//   - initialY: 角色的初始 Y 坐标
//   - resourceBagName: 资源包的名称
//____________________________________________________________________________________________________________
CharacterController::CharacterController(float initialX, float initialY, const std::string& resourceBagName)
    : Entity(initialX, initialY, resourceBagName), facing(Facings::Down), forceX(0), forceY(0) {
    // 其他初始化代码
}
//____________________________________________________________________________________________________________




// [说明]
// Init 函数：初始化角色的物理属性
// 对角色的物理属性进行初始化，如设置质量、惯性矩等
//____________________________________________________________________________________________________________
void CharacterController::Init() {
    this->Entity::Init(); // 调用基类的初始化函数

    // 设置角色动画精灵的属性
    auto animateSprite = this->resourceBagPtr->GetResource<CAnimateSprite>("Entity").get();
    if (animateSprite) {
        animateSprite->SetSpritePosition(posX, posY);
        animateSprite->SetSpriteMass(100);
        animateSprite->SetSpriteAtRest(false);
        animateSprite->SetSpriteInertialMoment(100);
        animateSprite->SetSpriteAutoMassInertia(true);
        animateSprite->SetSpriteMaxLinearVelocity(20);
        mess = animateSprite->GetSpriteMass();
    } else {
        LogManager::Log("初始化失败：无法获取 CAnimateSprite 资源。");
    }
}
//____________________________________________________________________________________________________________




// [说明]
// breakdown 函数：清理角色的物理属性
// 对角色的物理属性进行清理，调用基类的清理函数
//____________________________________________________________________________________________________________
void CharacterController::breakdown() {
    Entity::breakdown(); // 调用基类的清理函数
}
//____________________________________________________________________________________________________________





// [说明]
// 析构函数：清理角色控制器
// 清理角色控制器的资源（如果需要）
//____________________________________________________________________________________________________________
CharacterController::~CharacterController() {
    // 清理代码，如果有需要的话
}
//____________________________________________________________________________________________________________





// [说明]
// UpdateState 函数：更新角色状态
// 更新角色的物理状态和位置，包括摩擦力计算和方向判断
//____________________________________________________________________________________________________________
void CharacterController::UpdateState() {
    LogManager::Log("状态已更新");
    auto AnimatePtr = resourceBagPtr->GetResource<CAnimateSprite>("Entity").get();
	LogManager::Log(std::to_string(velocityX));
    if (AnimatePtr) {
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
            frictionForceX = -frictionCoefficient * mess * (velocityX / std::abs(velocityX));
        }
        if (std::abs(velocityY) > velocityThreshold) {
            frictionForceY = -frictionCoefficient * mess * (velocityY / std::abs(velocityY));
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

        // 根据速度判断角色面朝方向
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
//____________________________________________________________________________________________________________




// [说明]
// UpdateAnimation 函数：更新角色动画
// 根据角色的运动方向更新角色的动画状态
//____________________________________________________________________________________________________________
void CharacterController::UpdateAnimation() {
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
//____________________________________________________________________________________________________________




// [说明]
// UpdateSound 函数：更新角色声音
// 根据角色的运动状态更新角色的声音效果
//____________________________________________________________________________________________________________
void CharacterController::UpdateSound() {
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
//____________________________________________________________________________________________________________





// [说明]
// ProcessInput 函数：处理输入事件
// 根据键盘输入事件更新角色的力和速度
// 参数:
//   - event: 输入事件
//____________________________________________________________________________________________________________
void CharacterController::ProcessInput(const Event& event) 
{  
	if (event.GetType() == EventType::KeyboardInput) 
	{
        LogManager::Log("键盘事件接收成功,正在处理输入信息");
        const KeyboardInputEvent& keyEvent = static_cast<const KeyboardInputEvent&>(event);
        LogManager::Log("[处理] 拆解输入包...");
        if (keyEvent.GetState() == KeyboardInputEvent::KeyState::KEY_ON) {
            switch (keyEvent.GetKey()) {
                case KeyCodes::KEY_W:
                    forceY -= 80000;
                    break;
                case KeyCodes::KEY_S:
                    forceY += 80000;
                    break;
                case KeyCodes::KEY_A:
                    forceX -= 80000;
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
                    forceY += 80000;
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
    } else if (event.GetType() == EventType::MouseInput) 
	{
        const MouseInputEvent& mouseEvent = static_cast<const MouseInputEvent&>(event);
        if (mouseEvent.GetType() == EventType::MouseInput) 
		{
			if(mouseEvent.IsLeftPressed())
			{
				// 处理鼠标点击事件，发射子弹
				float dx = mouseEvent.GetX() - posX;
				float dy = mouseEvent.GetY() - posY;
				float distance = std::sqrt(dx * dx + dy * dy);
				float direction = std::atan2(dy, dx); // 计算方向（弧度）

				// 创建子弹
				float bulletSpeed = 200.0f; // 你可以根据需要调整子弹的速度
				std::string bulletID = CGameMain::GetInstance().stateMachine->currentState_->objectManager->CreateObject(
					"{\n"
					"  \"TypeName\"      : \"Bullet\",\n"
					"  \"posX\"          : " + std::to_string(posX) + ",\n"
					"  \"posY\"          : " + std::to_string(posY) + ",\n"
					"  \"speed\"         : " + std::to_string(bulletSpeed) + ",\n"
					"  \"direction\"     : " + std::to_string(direction) + ",\n"
					"  \"resourceBag\"   : \"Bullet_1\"\n"
					"}"
				);
				CGameMain::GetInstance().stateMachine->currentState_->objectManager->GetObjectBySpriteName(bulletID)->Init();
				LogManager::Log("子弹创建成功，ID: " + bulletID);
			}
		
		}
	}
}
//____________________________________________________________________________________________________________
