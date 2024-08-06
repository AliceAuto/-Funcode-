#ifndef CONTROLLER_H
#define CONTROLLER_H

#include <string>
#include "CSprite.h"
#include "CSystem.h"
#include "Setting.h"
#include "EventDrivenSystem.h"

class PlayerController {
public:
    PlayerController(float initialX, float initialY, float speed);
    ~PlayerController(); // �����������

    void ProcessInput(const Event& event); // �����������
    void Update(); // ���½�ɫ״̬
    void Render(); // ��Ⱦ��ɫ

private:
    CAnimateSprite* spritePtr;

    void Move(); // �ƶ���ɫ
    void UpdateAnimation(); // ���½�ɫ����

    float posX, posY; // ��ɫ��ǰλ��
    float baseSpeed; // �����ƶ��ٶ�
    float velocityX, velocityY; // ��ɫ��ǰ���ٶȷ���
};

extern PlayerController player;

#endif // CONTROLLER_H
