#ifndef CHARACTERCONTROLLER_H
#define CHARACTERCONTROLLER_H

// �ϸ���    ==>     ���������Ķ���








#include "EventDrivenSystem.h"
#include "Entity.h"

class CharacterController : public Entity {
public:
    CharacterController(float initialX, float initialY);
    virtual ~CharacterController(); // ����������

    // �������루�麯����
    virtual void ProcessInput(const Event& event);

protected:
    // �ṩĬ��ʵ�֣���������ѡ������д
    virtual void UpdateState() override;
    virtual void UpdateAnimation() override;
    virtual void UpdateSound() override;

    // ��ɫ��������
    enum Facings { Up, Down, Left, Right };
    Facings facing;
};

#endif // CHARACTERCONTROLLER_H
