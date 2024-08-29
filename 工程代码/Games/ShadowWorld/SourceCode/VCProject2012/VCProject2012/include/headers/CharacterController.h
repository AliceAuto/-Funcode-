#ifndef CHARACTERCONTROLLER_H
#define CHARACTERCONTROLLER_H

// 严格定义    ==>     可以软交互的对象








#include "EventDrivenSystem.h"
#include "Entity.h"

class CharacterController : public Entity {
public:
    CharacterController(float initialX, float initialY,const std::string& resourceBagName);
    virtual ~CharacterController(); // 虚析构函数
	void Init () override;
	void breakdown () override;
    // 处理输入（虚函数）
    virtual void ProcessInput(const Event& event);

protected:
    // 提供默认实现，允许子类选择性重写

    virtual void UpdateState() override;
    virtual void UpdateAnimation() override;
    virtual void UpdateSound() override;
	float forceX,forceY;
	float mess;
    // 角色特有属性
    enum Facings { Up, Down, Left, Right };
    Facings facing;
};

#endif // CHARACTERCONTROLLER_H
