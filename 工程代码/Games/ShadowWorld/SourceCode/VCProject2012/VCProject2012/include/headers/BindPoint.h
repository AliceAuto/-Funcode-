#pragma once
#include "Object.h"

//����Ҫʵ�ֶ����벢�ͷŵ�UI���а�
class BindPoint :public Object{
public:
	//����������
	BindPoint(float initialX, float initialY);
	~BindPoint();
	void ifCollision(Object * otherObject) override;//ʵ�ְ󶨽ű�
	void UpdateState()override;
private:
	bool isInBind;//��ǰ�󶨵��״̬
	std::string BindUiID;//��UI��Ӧ��ID|����ͨ��ObjectManager���ʶ���
};