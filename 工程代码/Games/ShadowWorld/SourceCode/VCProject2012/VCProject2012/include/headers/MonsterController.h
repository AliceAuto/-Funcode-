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
    MonsterController(float initialX, float initialY,const std::string& resourceBagName );
    ~MonsterController();
	void Init() override;
	void breakdown() override;

};



#endif // MONSTERCONTROLLER_H
