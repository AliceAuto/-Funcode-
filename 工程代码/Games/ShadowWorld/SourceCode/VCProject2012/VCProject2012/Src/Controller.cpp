#include "Controller.h"
#include "headers\Logger.h"
#include "string"

//									�������Ĺ��캯��
//==============================================================================
PlayerController::PlayerController(float initialX, float initialY, float speed)
    : posX(initialX), posY(initialY), baseSpeed(speed), velocityX(0), velocityY(0) {
    spritePtr = new CAnimateSprite("character");
}
//=============================================================================================


//			����������������
// ====================================
PlayerController::~PlayerController() {
    delete spritePtr;
}
//===============================================





//					��������������Ϣ�ĺ���		[����] -> [����]
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
                // ������Ծ�߼�
            }
            break;
        default:
            break;
    }
}
//==============================================================================================================



//			ָʾ�����ж��������Ϣ����
//============================================
void PlayerController::Move() {
    spritePtr->SetSpriteLinearVelocityX(velocityX);
    spritePtr->SetSpriteLinearVelocityY(velocityY);

    posX = spritePtr->GetSpritePositionX();
    posY = spritePtr->GetSpritePositionY();
}
//======================================================


//			���𶯻���ʾ���
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
			LogManager::Log("state��"+direction);
		}
	}
}
//=========================================================================================

//		���¿�����ȫ����״̬
//================================
void PlayerController::Update() {
    Render();
}
//=====================================




//		����ʵʱ��Ⱦ������
//================================
void PlayerController::Render() {
	Move();
    UpdateAnimation();
    
}
//====================================



PlayerController player(0, 0, 1.0f); // ��ʼ�� player ����
