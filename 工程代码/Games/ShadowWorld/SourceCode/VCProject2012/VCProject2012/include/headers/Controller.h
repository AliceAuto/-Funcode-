#ifndef CONTROLLER_H
#define CONTROLLER_H

#include <string>
#include "CSprite.h"
#include "CSystem.h"
#include "Setting.h"
#include "EventDrivenSystem.h"

class PlayerController {
public:
    PlayerController(float initialX, float initialY);
    ~PlayerController(); // �����������
	

	//					Ϊ�ⲿϵͳ�ṩ�Ľӿ�
	//===================================================
    void ProcessInput(const Event& event); // �����������
    void Update(); // ���½�ɫ״̬
    void Render(); // ��Ⱦ��ɫ
	//=====================================================
private:

	//				������Ľӿ�
	//============================================
    CAnimateSprite* spritePtr;		//��������ָ��
	CSound * soundSpritePtr;		//��Ч����ָ��
	//============================================




	//				ϵͳ����
	//==========================================
	void PlayerController::UpdateState();//�Ի������Ը���
    void PlayerController::UpdateAnimation(); // ��Ⱦ����
	void PlayerController::UpdateSound();	//��Ⱦ��Ч
	//============================================


	//				��������
	//==============================================
	// [��������]
    float posX, posY; // ��ɫ��ǰλ��
	float velocityX, velocityY; // ��ɫ��ǰ���ٶȷ���

	// [��������]

	
	//ö����
	static enum facings
	{
		up,
		down,
		left,
		right
	};
	float facing;	//����
    
	//================================================
};

extern PlayerController player;	//����������,�����CPP

#endif // CONTROLLER_H
