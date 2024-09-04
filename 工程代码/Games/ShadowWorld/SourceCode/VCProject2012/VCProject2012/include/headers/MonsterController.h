#ifndef MONSTERCONTROLLER_H
#define MONSTERCONTROLLER_H

#include "CharacterController.h"





//==========================================================================================================================
//														以下是 智能物理 声明
//=======================================================================================================================





























//==========================================================================================================

class MonsterController : public CharacterController {
public:
    MonsterController(float initialX, float initialY,const std::string& resourceBagName );
    ~MonsterController();
	void Init() override;
	void breakdown() override;

};
//==========================================================================================================



#endif // MONSTERCONTROLLER_H
