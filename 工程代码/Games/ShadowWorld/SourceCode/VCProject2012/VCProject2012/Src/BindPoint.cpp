#include "BindPoint.h"
#include "IMouseUi.h"
#include "headers\SceneStates.h"
#include "headers\StateMachine.h"
#include "headers\CGameMain.h"
BindPoint::BindPoint(float initialX, float initialY):
Object(initialX,initialY,"BindPoint"),isInBind(false)
{
}
BindPoint::~BindPoint(){}
void BindPoint::UpdateState(){

	 DraggableBlock * DBlock = static_cast< DraggableBlock *>(static_cast<GameState*>(CGameMain::GetInstance().stateMachine->currentState_)->objectManager->GetObjectBySpriteName(this->BindUiID));
	 if(DBlock){
		 
		 if(DBlock->isDragging){
			 DBlock->resourceBagPtr->GetResource<CAnimateSprite>("Entity")->SpriteDismount();
			 this->isInBind =false;
			 this->BindUiID = "";
		 }
	 }
}
void BindPoint::ifCollision(Object * otherObject) {
	//这里获得检测一下碰撞体的类型

	 DraggableBlock * DBlock = dynamic_cast<DraggableBlock*>(otherObject);
	 if (DBlock)
	 {
		if (!DBlock->isDragging &&this->isInBind ==false)
		{

			DBlock->resourceBagPtr->GetResource<CAnimateSprite>("Entity")->SpriteMountToSprite(this->resourceBagPtr->GetResource<CAnimateSprite>("Entity")->GetName(),0,0);
			this->BindUiID =DBlock->resourceBagPtr->GetResource<CAnimateSprite>("Entity")->GetName();								//捕捉绑定块的ID并做拷贝存储
			this->isInBind =true;																									//设置当前绑定点的状态为已绑定
		}
	 }


}