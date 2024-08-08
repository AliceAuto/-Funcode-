#ifndef PLAYERCONTROLLER_H
#define PLAYERCONTROLLER_H

#include "CharacterController.h"

class PlayerController : public CharacterController {
public:
    PlayerController(float initialX, float initialY,const ResourceBag * resourceBagPtr);
    ~PlayerController();

    void ProcessInput(const Event& event) override; // 处理输入
    void UpdateState() override; // 更新状态逻辑
    void UpdateAnimation() override; // 更新动画逻辑
    void UpdateSound() override; // 更新音效逻辑
};



#endif // PLAYERCONTROLLER_H
