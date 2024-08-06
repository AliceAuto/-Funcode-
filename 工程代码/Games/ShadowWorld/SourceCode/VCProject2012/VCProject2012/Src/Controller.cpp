#include "Controller.h"
#include "headers\Logger.h"
#include "string"

//									�������Ĺ��캯��
//==============================================================================
PlayerController::PlayerController(float initialX, float initialY)
    : posX(initialX), posY(initialY), facing(this->facings::up),velocityX(0), velocityY(0) {
    spritePtr = new CAnimateSprite("character");
	soundSpritePtr = new CSound("running.ogg",true,1);
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













//			��״̬����ʵʱ����
//===========================================
void PlayerController::UpdateState(){
	//�����ٶ�
	spritePtr->SetSpriteLinearVelocityX(velocityX);
    spritePtr->SetSpriteLinearVelocityY(velocityY);
	//����λ��
    posX = spritePtr->GetSpritePositionX();
    posY = spritePtr->GetSpritePositionY();
	//�������ﳯ��
    if (velocityX == 0 && velocityY > 0) {
 
		this->facing = facings::down;
    } 
    else if (velocityX > 0 && velocityY == 0) {

		this->facing = facings::right;
    }
   else if (velocityX == 0 && velocityY < 0) {

		this->facing = facings::up;
    } 
   else if (velocityX < 0 && velocityY == 0) {

		this->facing = facings::left;
    } 

}
//===============================================




















//				��Ⱦ����
//========================================================================
void PlayerController::UpdateAnimation() {
	static std::string AniTemp;	//	���Ը��¶���
    static std::string Ani;		//
	//				�ж�Ҫ���ŵĶ���
	//____________________________________________
    if (velocityX == 0 && velocityY > 0) {
        Ani = "to_down";

    } 
    else if (velocityX > 0 && velocityY == 0) {
        Ani = "to_right";

    }
   else if (velocityX == 0 && velocityY < 0) {
        Ani = "to_up";

    } 
   else if (velocityX < 0 && velocityY == 0) {
        Ani = "to_left";

    } 
	else if (velocityX == 0 && velocityY == 0) {
        if (this->facing == facings::up)Ani = "to_up";
		else if (this->facing == facings::down)Ani = "to_down";
		else if (this->facing == facings::left)Ani = "to_left";
		else if (this->facing == facings::right)Ani = "to_right";

    } 
	//___________________________________________________________________

	//�����ı䣬�Զ��������л�
    if (AniTemp.empty()||AniTemp!=Ani) {
		AniTemp	 = Ani;
        spritePtr->AnimateSpritePlayAnimation(Ani.c_str(), false);
		
    }
	//�������ı䣬ά�ֶ���ѭ��
	else{
		if(spritePtr->IsAnimateSpriteAnimationFinished()){
			spritePtr->AnimateSpritePlayAnimation(Ani.c_str(), true);
			
		}
	}
}
//=========================================================================================



//				��Ⱦ��Ч
//===========================================================
void PlayerController::UpdateSound(){
	static CSound * player;



	if (this->velocityX!= 0||this->velocityY!=0)
	{
		if(player!= this->soundSpritePtr)
		{
			this->soundSpritePtr->PlaySoundA();
			player = this ->soundSpritePtr; 
			LogManager::Log("[��Ч]:�ܶ�");
			LogManager::Log(this->soundSpritePtr->GetName());
		}
	}
	else{
		this->soundSpritePtr->StopSound();
		player = nullptr;
		LogManager::Log("[��Чֹͣ]");
	}
}

//============================================================================













//		���¿�����ȫ����״̬
//================================
void PlayerController::Update() {
	UpdateState();
    Render();
}
//=====================================









//		����ʵʱ��Ⱦ������
//================================
void PlayerController::Render() {
    UpdateAnimation();		//������Ⱦ
	UpdateSound();			//��Ч��Ⱦ
}
//====================================



PlayerController player(0, 0); // ��ʼ�� player ����
