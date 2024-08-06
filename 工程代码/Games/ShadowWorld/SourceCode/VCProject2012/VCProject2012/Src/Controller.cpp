#include "Controller.h"
#include "headers\Logger.h"
#include "string"

//									控制器的构造函数
//==============================================================================
PlayerController::PlayerController(float initialX, float initialY)
    : posX(initialX), posY(initialY), facing(this->facings::up),velocityX(0), velocityY(0) {
    spritePtr = new CAnimateSprite("character");
	soundSpritePtr = new CSound("running.ogg",true,1);
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













//			对状态进行实时更新
//===========================================
void PlayerController::UpdateState(){
	//更新速度
	spritePtr->SetSpriteLinearVelocityX(velocityX);
    spritePtr->SetSpriteLinearVelocityY(velocityY);
	//更新位置
    posX = spritePtr->GetSpritePositionX();
    posY = spritePtr->GetSpritePositionY();
	//更新人物朝向
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




















//				渲染动画
//========================================================================
void PlayerController::UpdateAnimation() {
	static std::string AniTemp;	//	用以更新动画
    static std::string Ani;		//
	//				判断要播放的动画
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

	//动画改变，对动画进行切换
    if (AniTemp.empty()||AniTemp!=Ani) {
		AniTemp	 = Ani;
        spritePtr->AnimateSpritePlayAnimation(Ani.c_str(), false);
		
    }
	//动画不改变，维持动画循环
	else{
		if(spritePtr->IsAnimateSpriteAnimationFinished()){
			spritePtr->AnimateSpritePlayAnimation(Ani.c_str(), true);
			
		}
	}
}
//=========================================================================================



//				渲染音效
//===========================================================
void PlayerController::UpdateSound(){
	static CSound * player;



	if (this->velocityX!= 0||this->velocityY!=0)
	{
		if(player!= this->soundSpritePtr)
		{
			this->soundSpritePtr->PlaySoundA();
			player = this ->soundSpritePtr; 
			LogManager::Log("[声效]:跑动");
			LogManager::Log(this->soundSpritePtr->GetName());
		}
	}
	else{
		this->soundSpritePtr->StopSound();
		player = nullptr;
		LogManager::Log("[声效停止]");
	}
}

//============================================================================













//		更新控制器全方面状态
//================================
void PlayerController::Update() {
	UpdateState();
    Render();
}
//=====================================









//		负责实时渲染控制器
//================================
void PlayerController::Render() {
    UpdateAnimation();		//动画渲染
	UpdateSound();			//音效渲染
}
//====================================



PlayerController player(0, 0); // 初始化 player 对象
