#ifndef MONSTERCONTROLLER_H
#define MONSTERCONTROLLER_H

#include "CharacterController.h"

class MonsterController : public CharacterController {
public:
    MonsterController(float initialX, float initialY,const ResourceBag * resourceBagPtr);
    ~MonsterController();

    void ProcessInput(const Event& event) override; // 实现输入处理
    void Update() override; // 更新状态
    void UpdateState() override; // 更新状态逻辑
    void UpdateAnimation() override; // 更新动画逻辑
    void UpdateSound() override; // 更新音效逻辑
};

#endif // MONSTERCONTROLLER_H
