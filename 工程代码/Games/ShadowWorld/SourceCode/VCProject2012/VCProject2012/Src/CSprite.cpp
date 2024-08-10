#include "headers\CSprite.h"
#include "headers\EventDrivenSystem.h" // 用到事件包

//=====================================================
/*
					精灵衍生类实现
*/
//=====================================================





















//按钮
//====================================================
#include <unordered_map>
#include <queue>       


// 按钮类构造函数
Button::Button(const char* szName)
    : CAnimateSprite(szName), state(Normal), prevState(Normal), textSprite(nullptr) {
    // 初始化文字精灵
    textSprite = new CTextSprite(szName);
}

// 按钮类析构函数
Button::~Button() {
    // 释放事件队列中的事件
    while (!eventQueue.empty()) {
        delete eventQueue.front();
        eventQueue.pop();
    }

    // 释放声音资源
    for (auto& pair : sounds) {
        delete pair.second; // 删除CSound对象
    }

    // 删除文字精灵
    delete textSprite;
}

// 处理事件
void Button::HandleEvent(const Event& event) {
    // 将事件添加到事件队列
    eventQueue.push(new MouseInputEvent(static_cast<const MouseInputEvent&>(event)));
}

// 更新按钮状态
void Button::Update() {
    while (!eventQueue.empty()) {
        const Event* event = eventQueue.front();
        eventQueue.pop();
        UpdateState(*event); // 更新状态
    }
    PlayAnimation(); // 播放动画
}

// 更新按钮状态
void Button::UpdateState(const Event& event) {
    if (auto mouseInputEvent = dynamic_cast<const MouseInputEvent*>(&event)) {
        bool isHovering = CSprite::IsPointInSprite(mouseInputEvent->GetX(), mouseInputEvent->GetY());
        ButtonState newState = state;

        if (isHovering) {
            if (mouseInputEvent->IsLeftPressed()) {
                newState = Clicked;
            } else {
                newState = Hover;
            }
        } else {
            newState = Normal;
        }

        if (newState != state) {
            SetState(newState);
            if (sounds.find(state) != sounds.end()) {
                sounds[state]->PlaySound(); // 播放音效
            }
        }
    }
}

// 播放按钮动画
void Button::PlayAnimation() {
    auto it = animNames.find(state);
    if (it != animNames.end()) {
        AnimateSpritePlayAnimation(it->second.c_str(), true);
    }
}

// 设置按钮状态
void Button::SetState(ButtonState newState) {
    prevState = state;
    state = newState;
}

// 绑定动画
void Button::BindAnimation(ButtonState state, const char* animName) {
    animNames[state] = animName;
}

// 绑定音效
void Button::BindSound(ButtonState state, const char* soundName, bool loop, float volume) {
    // 创建一个CSound对象并存储到sounds映射中
    sounds[state] = new CSound(soundName, loop, volume);
}

// 设置按钮上的文字
void Button::SetText(const char* text) {
    if (textSprite) {
        textSprite->SetTextString(text);
    }
}

// 设置按钮上的数值文字
void Button::SetTextValue(int value) {
    if (textSprite) {
        textSprite->SetTextValue(value);
    }
}

// 获取按钮当前状态
Button::ButtonState Button::GetState() const {
    return state;
}

// 渲染按钮动画和文字
void Button::Render() {
    // 渲染按钮动画
    PlayAnimation();

    // 渲染按钮上的文字
    if (textSprite) {
       // textSprite->Render();
    }
}


//====================================================