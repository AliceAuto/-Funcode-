#ifndef MONSTERCONTROLLER_H
#define MONSTERCONTROLLER_H

#include "CharacterController.h"





//============================================================
/*
					NPC��������������
*/
//============================================================






























class MonsterController : public CharacterController {
public:
    MonsterController(float initialX, float initialY, ResourceBag * resourceBagPtr);
    ~MonsterController();


};



#endif // MONSTERCONTROLLER_H
