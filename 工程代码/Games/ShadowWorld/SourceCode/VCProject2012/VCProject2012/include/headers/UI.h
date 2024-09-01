#ifndef UI_H
#define UI_H

#include "Object.h"

class UI : public Object {
public:
    UI(float initialX, float initialY, const std::string& resourceBagName,const std::string& label);
    virtual ~UI(); // ����������

    // ��д��ʼ�������ٷ���
    void Init() override;
    void breakdown() override;
	const std::string& GetLabel() const { return label_; }

protected:
    // ��Ҫ����ʵ�ֵ��麯��
    virtual void UpdateState() override;
    virtual void UpdateAnimation() override;
    virtual void UpdateSound() override;

    // �ڲ���Ա�������Ը�����Ҫ���
    // ...

private:
    // ˽�г�Ա�����򷽷�������У�
    // ...
	virtual void updateAnimation(){};
	virtual void updateSound(){};
	std::string label_;
};

#endif // UI_H
