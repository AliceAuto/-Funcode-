#ifndef PLAYERCONTROLLER_H
#define PLAYERCONTROLLER_H

#include "CharacterController.h"

//=========================================================
/*
    ��Ҷ�������
*/
//===========================================================

class PlayerController : public CharacterController {
public:
<<<<<<< Updated upstream
    PlayerController(float initialX, float initialY,  ResourceBag* resourceBagPtr);
=======
    PlayerController(float initialX, float initialY,std::string & resourceBag);
>>>>>>> Stashed changes
    ~PlayerController() override;


	void RegisterListeners();
    void UnregisterListeners();
};

#endif // PLAYERCONTROLLER_H
