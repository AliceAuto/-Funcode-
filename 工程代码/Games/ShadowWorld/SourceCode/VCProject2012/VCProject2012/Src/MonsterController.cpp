#include "MonsterController.h"

//=====================================================
/*
					NPC����������ʵ��
*/
//=====================================================
















// ���캯��
MonsterController::MonsterController(float initialX, float initialY,const std::string& resourceBagName)
    : CharacterController(initialX,initialY, resourceBagName) {}

// ��������
MonsterController::~MonsterController() {}


void MonsterController::Init(){
CharacterController::Init();}
void MonsterController::breakdown(){
CharacterController::breakdown();
}
// ����״̬