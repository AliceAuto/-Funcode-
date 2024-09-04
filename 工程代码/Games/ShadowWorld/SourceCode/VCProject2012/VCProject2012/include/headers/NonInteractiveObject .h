#ifndef NONINTERACTIVEOBJECT_H
#define NONINTERACTIVEOBJECT_H

#include "Entity.h"
#include <string>
//==========================================================================================================================
//														������ �ǽ�ǿ����ʵ�� ����
//=======================================================================================================================

//==========================================================================================================

// �ǽ�������������
class NonInteractiveObject : public Entity {
public:
    // ���캯��
    NonInteractiveObject(float initialX, float initialY, const std::string& resourceBagName);

    // ����������
    virtual ~NonInteractiveObject();

    // ��ʼ������
    void Init() override;
	void breakdown() override;
	
protected:
    // �ṩĬ��ʵ�֣���������ѡ������д
    virtual void UpdateState() override;
    virtual void UpdateAnimation() override;
    virtual void UpdateSound() override;
};

// ������ʵ��������
class PhysicalObject : public NonInteractiveObject {
public:
    // ���캯��
    PhysicalObject(float initialX, float initialY, const std::string& resourceBagName);

    // ����������
    virtual ~PhysicalObject();
	void Init() override;
	void breakdown() override;
protected:
    // ��д����״̬�����������˶�
    void UpdateState() override;
    void UpdateAnimation() override;
    void UpdateSound() override;

    // ������ʵ�����е�����
    float velocityX;
    float velocityY;
    void ApplyPhysics();
};

// �ϰ���ʵ��������
class ObstacleObject : public NonInteractiveObject {
public:
    // ���캯��

    ObstacleObject(float initialX, float initialY, const std::string& resourceBagName);

    // ����������
    virtual ~ObstacleObject();
	void Init() override;
	void breakdown() override;
protected:
    // ��д����״̬������λ�ò�����߼�
    void UpdateState() override;
};


//�ӵ���
class Bullet : public NonInteractiveObject {
public:
    // ���캯��
    Bullet(float initialX, float initialY, const std::string& resourceBagName, float speed, float direction);

    // ��������
    virtual ~Bullet();

    // ��ʼ��
    virtual void Init() override;

    // ��Դ����
    virtual void breakdown() override;

    // ����״̬
    virtual void UpdateState() override;

    // ���¶���
    virtual void UpdateAnimation() override;

    // ��������
    virtual void UpdateSound() override;

private:
    float speed;       // �ӵ����ٶ�
    float direction;   // �ӵ��ķ����Ի���Ϊ��λ��
	
    // �ƶ��ӵ�
};
//==========================================================================================================

#endif // NONINTERACTIVEOBJECT_H
