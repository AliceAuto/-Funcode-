#include "BindPoint.h"
#include "IMouseUi.h"
BindPoint::BindPoint(float initialX, float initialY):
Object(initialX,initialY,"BindPoint"),isInBind(false)
{
}
BindPoint::~BindPoint(){}
void BindPoint::UpdateState(){


}
void BindPoint::ifCollision(Object * otherObject) {
	//这里获得检测一下碰撞体的类型

	 DraggableBlock * DBlock = dynamic_cast<DraggableBlock*>(otherObject);
	 if (DBlock)
	 {
		if (!DBlock->isDragging)
		{
			LogManager::Log("====================================================");
			DBlock->resourceBagPtr->GetResource<CAnimateSprite>("Entity")->SpriteMountToSprite(this->resourceBagPtr->GetResource<CAnimateSprite>("Entity")->GetName(),0,0);
			this->BindUiID =DBlock->resourceBagPtr->GetResource<CAnimateSprite>("Entity")->GetName();
			this->isInBind =true;
		}
	 }


}