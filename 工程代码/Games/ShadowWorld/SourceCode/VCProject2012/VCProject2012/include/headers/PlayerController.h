#ifndef PLAYERCONTROLLER_H
#define PLAYERCONTROLLER_H

#include "CharacterController.h"

class PlayerController : public CharacterController {
public:
    PlayerController(float initialX, float initialY,const ResourceBag * resourceBagPtr);
    ~PlayerController();

    void ProcessInput(const Event& event) override; // ��������
    void UpdateState() override; // ����״̬�߼�
    void UpdateAnimation() override; // ���¶����߼�
    void UpdateSound() override; // ������Ч�߼�
};



#endif // PLAYERCONTROLLER_H
