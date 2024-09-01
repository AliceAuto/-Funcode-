#ifndef UI_H
#define UI_H

#include "Object.h"

class UI : public Object {
public:
    UI(float initialX, float initialY, const std::string& resourceBagName,const std::string& label);
    virtual ~UI(); // 虚析构函数

    // 重写初始化和销毁方法
    void Init() override;
    void breakdown() override;
	const std::string& GetLabel() const { return label_; }

protected:
    // 需要子类实现的虚函数
    virtual void UpdateState() override;
    virtual void UpdateAnimation() override;
    virtual void UpdateSound() override;

    // 内部成员变量可以根据需要添加
    // ...

private:
    // 私有成员变量或方法（如果有）
    // ...
	virtual void updateAnimation(){};
	virtual void updateSound(){};
	std::string label_;
};

#endif // UI_H
