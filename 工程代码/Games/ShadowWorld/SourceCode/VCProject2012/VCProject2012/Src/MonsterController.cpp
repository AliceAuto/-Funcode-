#include "MonsterController.h"

//=====================================================
/*
					NPC����������ʵ��
*/
//=====================================================
















// ���캯��
<<<<<<< Updated upstream
MonsterController::MonsterController(float initialX, float initialY, ResourceBag * resourceBagPtr)
    : CharacterController(initialX,initialY,resourceBagPtr) {}
=======
MonsterController::MonsterController(float initialX, float initialY,std::string & resourceBag)
    : CharacterController(initialX,initialY,resourceBag) {}
>>>>>>> Stashed changes

// ��������
MonsterController::~MonsterController() {}



// ����״̬