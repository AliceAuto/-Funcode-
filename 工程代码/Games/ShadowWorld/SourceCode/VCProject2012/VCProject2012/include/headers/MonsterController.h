#ifndef MONSTERCONTROLLER_H
#define MONSTERCONTROLLER_H

#include "CharacterController.h"

class MonsterController : public CharacterController {
public:
    MonsterController(float initialX, float initialY,const ResourceBag * resourceBagPtr);
    ~MonsterController();

    void ProcessInput(const Event& event) override; // ʵ�����봦��
    void Update() override; // ����״̬
    void UpdateState() override; // ����״̬�߼�
    void UpdateAnimation() override; // ���¶����߼�
    void UpdateSound() override; // ������Ч�߼�
};

#endif // MONSTERCONTROLLER_H
