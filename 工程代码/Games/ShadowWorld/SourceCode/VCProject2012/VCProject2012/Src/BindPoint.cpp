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
void BindPoint::UpdateState() {
    DraggableBlock *DBlock = static_cast<DraggableBlock*>(
        static_cast<GameState*>(CGameMain::GetInstance().stateMachine->currentState_)->objectManager->GetObjectBySpriteName(this->BindUiID)
    );
    
    if (DBlock) {
        if (DBlock->isDragging) {
            DBlock->resourceBagPtr->GetResource<CAnimateSprite>("Entity")->SpriteDismount();
            this->isInBind = false;
            this->BindUiID = "";
            DBlock->LastBindPointID = this->resourceBagPtr->GetResource<CAnimateSprite>("Entity")->GetName();
        }
    }
}
void BindPoint::ifCollision(Object *otherObject) {
    DraggableBlock *DBlock = dynamic_cast<DraggableBlock*>(otherObject);

    if (DBlock) {
        LogManager::Log("检测到拖拽块对象，拖拽状态: " + std::string(DBlock->isDragging ? "是" : "否"));

        if (DBlock->isDragging) {
            LogManager::Log("拖拽块正在拖拽，当前绑定点状态: " + std::string(this->isInBind ? "已绑定" : "未绑定"));

            if (this->isInBind) {
                // 当前绑定点已被占用，进行交换
                DraggableBlock *currentBoundBlock = static_cast<DraggableBlock*>(
                    static_cast<GameState*>(CGameMain::GetInstance().stateMachine->currentState_)->objectManager->GetObjectBySpriteName(this->BindUiID)
                );

                if (currentBoundBlock && !DBlock->LastBindPointID.empty()) {
                    LogManager::Log("当前绑定点已被占用，正在交换拖拽块");

                    BindPoint *lastBindPoint = static_cast<BindPoint*>(
                        static_cast<GameState*>(CGameMain::GetInstance().stateMachine->currentState_)->objectManager->GetObjectBySpriteName(currentBoundBlock->LastBindPointID)
                    );

                    if (lastBindPoint) {
                        // 解除当前绑定点上的拖拽块，并将其移到之前的绑定点
                        LogManager::Log("解除当前绑定点上的拖拽块，并将其移到之前的绑定点");
                        currentBoundBlock->resourceBagPtr->GetResource<CAnimateSprite>("Entity")->SpriteDismount();
                        currentBoundBlock->resourceBagPtr->GetResource<CAnimateSprite>("Entity")->SpriteMountToSprite(
                            lastBindPoint->resourceBagPtr->GetResource<CAnimateSprite>("Entity")->GetName(), currentBoundBlock->SetX, currentBoundBlock->SetY
							 
                        );LogManager::Log("==========================================================================");

                        // 更新之前绑定点的状态
                        currentBoundBlock->LastBindPointID = lastBindPoint->resourceBagPtr->GetResource<CAnimateSprite>("Entity")->GetName();
                        lastBindPoint->isInBind = true;
                        lastBindPoint->BindUiID = currentBoundBlock->resourceBagPtr->GetResource<CAnimateSprite>("Entity")->GetName();

                        // 更新当前绑定点的状态
                        this->isInBind = false;
                        this->BindUiID.clear();
                    } else {
                        LogManager::Log("错误: 未能找到之前的绑定点");
                    }
                } else {
                    LogManager::Log("错误: 当前绑定点的拖拽块或历史绑定点信息无效");
                }
            }

            // 绑定当前拖拽块到新的绑定点
            if (!this->isInBind) {
                LogManager::Log("当前绑定点为空闲，正在绑定拖拽块");
                this->isInBind = true;
                this->BindUiID = DBlock->resourceBagPtr->GetResource<CAnimateSprite>("Entity")->GetName();
                DBlock->LastBindPointID = this->resourceBagPtr->GetResource<CAnimateSprite>("Entity")->GetName();
            }
        }
    } else {
        LogManager::Log("碰撞检测: 非拖拽块对象");
    }
}