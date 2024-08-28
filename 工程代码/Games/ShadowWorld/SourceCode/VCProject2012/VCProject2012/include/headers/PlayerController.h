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
    PlayerController(float initialX, float initialY,const std::string& resourceBagName);
    ~PlayerController() override;
	void Init() override;
	void breakdown() override;
protected:
	void RegisterMouseListener();
	void UnregisterMouseListener();
private:
	bool isListenerRegistered;
};

#endif // PLAYERCONTROLLER_H
