#ifndef PLAYERCONTROLLER_H
#define PLAYERCONTROLLER_H

#include "CharacterController.h"

//=========================================================
/*
    玩家对象声明
*/
//===========================================================

class PlayerController : public CharacterController {
public:
    PlayerController(float initialX, float initialY,  ResourceBag* resourceBagPtr);
    ~PlayerController() override;

};

#endif // PLAYERCONTROLLER_H
