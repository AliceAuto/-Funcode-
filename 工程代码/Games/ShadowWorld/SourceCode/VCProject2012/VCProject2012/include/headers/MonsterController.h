#ifndef MONSTERCONTROLLER_H
#define MONSTERCONTROLLER_H

#include "CharacterController.h"





//============================================================
/*
					NPC或智能物体声明
*/
//============================================================






























class MonsterController : public CharacterController {
public:
    MonsterController(float initialX, float initialY, ResourceBag * resourceBagPtr);
    ~MonsterController();


};



#endif // MONSTERCONTROLLER_H
