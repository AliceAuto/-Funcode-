#include "MonsterController.h"

//=====================================================
/*
					NPC或智能物体实现
*/
//=====================================================
















// 构造函数
MonsterController::MonsterController(float initialX, float initialY, ResourceBag * resourceBagPtr)
    : CharacterController(initialX,initialY,resourceBagPtr) {}

// 析构函数
MonsterController::~MonsterController() {}



// 更新状态