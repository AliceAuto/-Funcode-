#include "MonsterController.h"

//=====================================================
/*
					NPC或智能物体实现
*/
//=====================================================
















// 构造函数
<<<<<<< Updated upstream
MonsterController::MonsterController(float initialX, float initialY, ResourceBag * resourceBagPtr)
    : CharacterController(initialX,initialY,resourceBagPtr) {}
=======
MonsterController::MonsterController(float initialX, float initialY,std::string & resourceBag)
    : CharacterController(initialX,initialY,resourceBag) {}
>>>>>>> Stashed changes

// 析构函数
MonsterController::~MonsterController() {}



// 更新状态