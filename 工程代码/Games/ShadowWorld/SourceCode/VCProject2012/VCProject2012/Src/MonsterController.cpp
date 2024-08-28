#include "MonsterController.h"

//=====================================================
/*
					NPC或智能物体实现
*/
//=====================================================
















// 构造函数
MonsterController::MonsterController(float initialX, float initialY,const std::string& resourceBagName)
    : CharacterController(initialX,initialY, resourceBagName) {}

// 析构函数
MonsterController::~MonsterController() {}


void MonsterController::Init(){
CharacterController::Init();}
void MonsterController::breakdown(){
CharacterController::breakdown();
}
// 更新状态