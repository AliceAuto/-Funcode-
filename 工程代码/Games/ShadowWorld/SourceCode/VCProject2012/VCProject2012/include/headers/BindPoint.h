#pragma once
#include "Object.h"

//这里要实现对拖入并释放的UI进行绑定
class BindPoint :public Object{
public:
	//构造与析构
	BindPoint(float initialX, float initialY);
	~BindPoint();
	void ifCollision(Object * otherObject) override;//实现绑定脚本
	void UpdateState()override;
private:
	bool isInBind;//当前绑定点的状态
	std::string BindUiID;//绑定UI对应的ID|可以通过ObjectManager访问对象
};