#ifndef CHARACTERCONTROLLER_H
#define CHARACTERCONTROLLER_H

#include <string>
#include "CSprite.h"
#include "EventDrivenSystem.h"
#include "Logger.h"
#include "ResourceBag.h"

class CharacterController {
public:
    CharacterController(float initialX, float initialY,const ResourceBag * resourceBagPtr);
    virtual ~CharacterController(); // ����������

    // Ϊ�ⲿϵͳ�ṩ�Ľӿ�
    virtual void ProcessInput(const Event& event); // �������루�麯����
    virtual void Update(); // ����״̬���麯����
    virtual void Render(); // ��Ⱦ״̬���麯����

    // ��Դ����ӿ�
    void LoadResources(ResourceBag * resourceBagPtr);

protected:
    // ������Ե��õĹ�������
    virtual void UpdateState() = 0; // ����״̬�����麯����
    virtual void UpdateAnimation() = 0; // ���¶��������麯����
    virtual void UpdateSound() = 0; // ������Ч�����麯����

    // ��������
    float posX, posY; // λ��
    float velocityX, velocityY; // �ٶȷ���
    enum class Facings {
        Up,
        Down,
        Left,
        Right
    };
    Facings facing; // ����

    // ����ʵ�ַ���
    void UpdateCommonState();
    void UpdateCommonAnimation();
    void UpdateCommonSound();

    const ResourceBag * resourceBagPtr; // ������Դ
};




#endif // CHARACTERCONTROLLER_H
