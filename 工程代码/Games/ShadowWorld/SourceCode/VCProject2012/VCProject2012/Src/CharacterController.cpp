#include "CharacterController.h"
#include "Logger.h"

// 构造函数
CharacterController::CharacterController(float initialX, float initialY,const ResourceBag * resourceBagPtr)
    : posX(initialX), posY(initialY), velocityX(0), velocityY(0), facing(Facings::Down),resourceBagPtr(resourceBagPtr) {}

// 析构函数
CharacterController::~CharacterController() {

	delete resourceBagPtr;
}


// 更新状态
void CharacterController::UpdateCommonState() {
	
	
    if (resourceBagPtr!=nullptr&&resourceBagPtr->Character!= nullptr) 
	{
		
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
    }
	else{
	LogManager::Log("指针为空");
	}
}

// 更新动画
void CharacterController::UpdateCommonAnimation() {
	static std::string currentAnimation;
	LogManager::Log("刷新");
    if (resourceBagPtr==nullptr||resourceBagPtr->Character==nullptr) return;
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
	
    if (currentAnimation != ani&&resourceBagPtr!=nullptr&&resourceBagPtr->Character!=nullptr) {
        resourceBagPtr->Character->AnimateSpritePlayAnimation(ani.c_str(), false);
        currentAnimation = ani;
		
    } else if (resourceBagPtr!=nullptr&&resourceBagPtr->Character!=nullptr&&resourceBagPtr->Character->IsAnimateSpriteAnimationFinished()) {
        resourceBagPtr->Character->AnimateSpritePlayAnimation(ani.c_str(), true);
		LogManager::Log("动画停止");
    }
}

// 更新音效
void CharacterController::UpdateCommonSound() {

	static std::string currentSound;
    if ((velocityX != 0 || velocityY != 0 ))
	{
		if(resourceBagPtr!=nullptr&&resourceBagPtr->running!=nullptr&&currentSound!=resourceBagPtr->running->GetName())
		{
        resourceBagPtr->running->PlaySound();
		currentSound = resourceBagPtr->running->GetName();
		}
    }
	else 
	{  
		if(currentSound!=""){
        resourceBagPtr->running->StopSound();
		
		currentSound = "";}
    }
	
}

// 处理输入事件并更新精灵的速度
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
	LogManager::Log("< "+std::to_string(velocityX)+","+std::to_string(velocityY)+">");
}

void CharacterController::Update() {

	UpdateState(); // 子类实现
	UpdateSound(); // 子类实现
	UpdateAnimation(); // 子类实现
}

void CharacterController::Render() {
    // 默认实现或空实现
}


void CharacterController::LoadResources(ResourceBag * resourceBagPtr) {
    this->resourceBagPtr = resourceBagPtr;
    // 你可以在这里添加额外的资源加载逻辑
}