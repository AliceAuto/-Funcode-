#ifndef PLAYERCONTROLLER_H
#define PLAYERCONTROLLER_H

#include "CharacterController.h"

//=========================================================
/*
    ��Ҷ�������
*/
//===========================================================

class PlayerController : public CharacterController {
public:
    PlayerController(float initialX, float initialY,  ResourceBag* resourceBagPtr);
    ~PlayerController() override;

};

#endif // PLAYERCONTROLLER_H
