#ifndef NONINTERACTIVEOBJECT_H
#define NONINTERACTIVEOBJECT_H

#include "Entity.h"

// �ǽ�������������
class NonInteractiveObject : public Entity {
public:
    // ���캯��
<<<<<<< Updated upstream
    NonInteractiveObject(float initialX, float initialY,  ResourceBag* resourceBagPtr);
=======
    NonInteractiveObject(float initialX, float initialY,std::string & resourceBag);
>>>>>>> Stashed changes

    // ����������
    virtual ~NonInteractiveObject();

<<<<<<< Updated upstream
=======
    // �麯��������������д
    void Init() override;

>>>>>>> Stashed changes
protected:
    // �ṩĬ��ʵ�֣���������ѡ������д
    virtual void UpdateState() override;
    virtual void UpdateAnimation() override;
    virtual void UpdateSound() override;

    // �����ǽ����������е����Ժͷ���
};

//===================================================================
// ������ײ����
class PhysicalCollisionBody : public NonInteractiveObject {
public:
    PhysicalCollisionBody(float initialX, float initialY,std::string & resourceBag);
    virtual ~PhysicalCollisionBody();

    // ��д Init ����
    void Init() override;
};

// �ӵ���
class Bullet : public PhysicalCollisionBody {
public:
    Bullet(float initialX, float initialY, float speedX, float speedY,std::string & resourceBag);
    virtual ~Bullet();

    // ��д����״̬�ķ���
    void UpdateState() override;
	void UpdateAnimation() override;
	void UpdateSound()override;

    // ��д Init ����
    void Init() override;

private:
    float speedX;  // �ӵ���X���ϵ��ٶ�
    float speedY;  // �ӵ���Y���ϵ��ٶ�
};

// �̶��ϰ�����
class FixedObstacle : public PhysicalCollisionBody {
public:
    FixedObstacle(float initialX, float initialY,std::string & resourceBag);
    virtual ~FixedObstacle();

    // ��д Init ����
    void Init() override;
};

#endif // NONINTERACTIVEOBJECT_H
