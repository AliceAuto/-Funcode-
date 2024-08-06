#include "Controller.h"
#include "headers\Logger.h"
#include "string"

//									控制器的构造函数
//==============================================================================
PlayerController::PlayerController(float initialX, float initialY, float speed)
    : posX(initialX), posY(initialY), baseSpeed(speed), velocityX(0), velocityY(0) {
    spritePtr = new CAnimateSprite("character");
}
//=============================================================================================


//			控制器的析构函数
// ====================================
PlayerController::~PlayerController() {
    delete spritePtr;
}
//===============================================





//					监听处理输入信息的函数		[输入] -> [控制]
//========================================================================
void PlayerController::ProcessInput(const Event& event) {
    const KeyboardInputEvent& keyboardEvent = static_cast<const KeyboardInputEvent&>(event);

    switch (keyboardEvent.GetKey()) {
        case KeyCodes::KEY_W:
            velocityY = (keyboardEvent.GetState() == keyboardEvent.KEY_ON) ? -10 : 0;
            break;
        case KeyCodes::KEY_S:
            velocityY = (keyboardEvent.GetState() == keyboardEvent.KEY_ON) ? 10 : 0;
            break;
        case KeyCodes::KEY_A:
            velocityX = (keyboardEvent.GetState() == keyboardEvent.KEY_ON) ?  -10 : 0;
            break;
        case KeyCodes::KEY_D:
            velocityX = (keyboardEvent.GetState() == keyboardEvent.KEY_ON) ? 10 : 0;
            break;
        case ' ':
            if (keyboardEvent.GetState() == keyboardEvent.KEY_ON) {
                // 处理跳跃逻辑
            }
            break;
        default:
            break;
    }
}
//==============================================================================================================



//			指示精灵行动并获得信息反馈
//============================================
void PlayerController::Move() {
    spritePtr->SetSpriteLinearVelocityX(velocityX);
    spritePtr->SetSpriteLinearVelocityY(velocityY);

    posX = spritePtr->GetSpritePositionX();
    posY = spritePtr->GetSpritePositionY();
}
//======================================================


//			负责动画显示相关
//=========================================
void PlayerController::UpdateAnimation() {
    static std::string direction;

	static std::string temp;
    if (velocityX == 0 && velocityY > 0) {
        temp = "to_down";
    } 
    else if (velocityX > 0 && velocityY == 0) {
        temp = "to_right";
    }
   else if (velocityX == 0 && velocityY < 0) {
        temp = "to_up";
    } 
   else if (velocityX < 0 && velocityY == 0) {
        temp = "to_left";
    } 
	else if (velocityX == 0 && velocityY == 0) {
        temp = "to_static";
    } 
    if (temp!=direction) {
        spritePtr->AnimateSpritePlayAnimation(temp.c_str(), false);
		direction =temp;
    }
	else{

		if(spritePtr->IsAnimateSpriteAnimationFinished() && direction !="to_static"){
			spritePtr->AnimateSpritePlayAnimation(temp.c_str(), true);
			LogManager::Log("state："+direction);
		}
	}
}
//=========================================================================================

//		更新控制器全方面状态
//================================
void PlayerController::Update() {
    Render();
}
//=====================================




//		负责实时渲染控制器
//================================
void PlayerController::Render() {
	Move();
    UpdateAnimation();
    
}
//====================================



PlayerController player(0, 0, 1.0f); // 初始化 player 对象
