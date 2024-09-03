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

    // �ڲ���Ա�������Ը�����Ҫ���
    // ...
	void UpdateState()override;
	void UpdateAnimation()override;
	void UpdateSound()override;
private:
    // ˽�г�Ա�����򷽷�������У�
    // ...
	
	std::string label_;
};

#endif // UI_H
