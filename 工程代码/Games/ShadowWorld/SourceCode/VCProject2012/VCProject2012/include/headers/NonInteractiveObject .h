#ifndef NONINTERACTIVEOBJECT_H
#define NONINTERACTIVEOBJECT_H

//�ϸ���     ==>     ����������











#include "Entity.h"

// �ǽ�������������
class NonInteractiveObject : public Entity {
public:
    // ���캯��
    NonInteractiveObject(float initialX, float initialY);

    // ����������
    virtual ~NonInteractiveObject();

protected:
    // �ṩĬ��ʵ�֣���������ѡ������д
    virtual void UpdateState() override;
    virtual void UpdateAnimation() override;
    virtual void UpdateSound() override;

    // �����ǽ����������е����Ժͷ���
};

#endif // NONINTERACTIVEOBJECT_H
