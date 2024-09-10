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
        LogManager::Log("��⵽��ק�������ק״̬: " + std::string(DBlock->isDragging ? "��" : "��"));

        if (DBlock->isDragging) {
            LogManager::Log("��ק��������ק����ǰ�󶨵�״̬: " + std::string(this->isInBind ? "�Ѱ�" : "δ��"));

            if (this->isInBind) {
                // ��ǰ�󶨵��ѱ�ռ�ã����н���
                DraggableBlock *currentBoundBlock = static_cast<DraggableBlock*>(
                    static_cast<GameState*>(CGameMain::GetInstance().stateMachine->currentState_)->objectManager->GetObjectBySpriteName(this->BindUiID)
                );

                if (currentBoundBlock && !DBlock->LastBindPointID.empty()) {
                    LogManager::Log("��ǰ�󶨵��ѱ�ռ�ã����ڽ�����ק��");

                    BindPoint *lastBindPoint = static_cast<BindPoint*>(
                        static_cast<GameState*>(CGameMain::GetInstance().stateMachine->currentState_)->objectManager->GetObjectBySpriteName(currentBoundBlock->LastBindPointID)
                    );

                    if (lastBindPoint) {
                        // �����ǰ�󶨵��ϵ���ק�飬�������Ƶ�֮ǰ�İ󶨵�
                        LogManager::Log("�����ǰ�󶨵��ϵ���ק�飬�������Ƶ�֮ǰ�İ󶨵�");
                        currentBoundBlock->resourceBagPtr->GetResource<CAnimateSprite>("Entity")->SpriteDismount();
                        currentBoundBlock->resourceBagPtr->GetResource<CAnimateSprite>("Entity")->SpriteMountToSprite(
                            lastBindPoint->resourceBagPtr->GetResource<CAnimateSprite>("Entity")->GetName(), currentBoundBlock->SetX, currentBoundBlock->SetY
							 
                        );LogManager::Log("==========================================================================");

                        // ����֮ǰ�󶨵��״̬
                        currentBoundBlock->LastBindPointID = lastBindPoint->resourceBagPtr->GetResource<CAnimateSprite>("Entity")->GetName();
                        lastBindPoint->isInBind = true;
                        lastBindPoint->BindUiID = currentBoundBlock->resourceBagPtr->GetResource<CAnimateSprite>("Entity")->GetName();

                        // ���µ�ǰ�󶨵��״̬
                        this->isInBind = false;
                        this->BindUiID.clear();
                    } else {
                        LogManager::Log("����: δ���ҵ�֮ǰ�İ󶨵�");
                    }
                } else {
                    LogManager::Log("����: ��ǰ�󶨵����ק�����ʷ�󶨵���Ϣ��Ч");
                }
            }

            // �󶨵�ǰ��ק�鵽�µİ󶨵�
            if (!this->isInBind) {
                LogManager::Log("��ǰ�󶨵�Ϊ���У����ڰ���ק��");
                this->isInBind = true;
                this->BindUiID = DBlock->resourceBagPtr->GetResource<CAnimateSprite>("Entity")->GetName();
                DBlock->LastBindPointID = this->resourceBagPtr->GetResource<CAnimateSprite>("Entity")->GetName();
            }
        }
    } else {
        LogManager::Log("��ײ���: ����ק�����");
    }
}