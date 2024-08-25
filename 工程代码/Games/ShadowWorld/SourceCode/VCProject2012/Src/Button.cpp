#include "Button.h"

// 初始化静态成员变量
std::unordered_map<std::string, std::unique_ptr<Button>> Button::buttons_;
bool Button::isListenersRegistered = false;

Button::Button(const std::string& label, float posX, float posY, std::string & resourceBag)
    : Entity(posX, posY, resourceBag), // 修正为正确调用基类构造函数
      label_(label), 
      isMouseOver(false), 
      isClicked(false) 
{
    LogManager::Log("创建按钮: " + label_ + "，位置: (" + std::to_string(posX) + ", " + std::to_string(posY) + ")");
}

void Button::AddButton(std::unique_ptr<Button> button) {
    if (button) {
        buttons_[button->GetLabel()] = std::move(button);
        LogManager::Log("添加按钮: " + button->GetLabel());
    } else {
        LogManager::Log("添加按钮失败: 按钮指针为空。");
    }
}

Button* Button::GetButtonByLabel(const std::string& label) {
    auto it = buttons_.find(label);
    if (it != buttons_.end()) {
        LogManager::Log("获取按钮: " + label);
        return it->second.get();
    } else {
        LogManager::Log("未找到按钮: " + label);
        return nullptr;
    }
}



void Button::HandleMouseInputForAll(const Event& event) {
    LogManager::Log("处理所有按钮的鼠标输入事件");
    for (auto& pair : buttons_) {
        if (pair.second) {
            pair.second->HandleMouseEvent(event);
        }
    }
}

void Button::RegisterEventListeners() {
    if (!isListenersRegistered) {
        LogManager::Log("注册鼠标输入事件监听器");
        EventManager::Instance().RegisterListener(EventType::MouseInput,
            std::bind(&Button::HandleMouseInputForAll, std::placeholders::_1)
        );
        isListenersRegistered = true;
        LogManager::Log("鼠标输入事件监听器已注册");
    } else {
        LogManager::Log("鼠标输入事件监听器已经注册");
    }
}

void Button::UnregisterEventListeners() {
    if (isListenersRegistered) {
        LogManager::Log("注销鼠标输入事件监听器");
        EventManager::Instance().RemoveListener(EventType::MouseInput,
            std::bind(&Button::HandleMouseInputForAll, std::placeholders::_1)
        );
        isListenersRegistered = false;
        LogManager::Log("鼠标输入事件监听器已注销");
    } else {
        LogManager::Log("鼠标输入事件监听器未注册");
    }
}

void Button::HandleMouseEvent(const Event& event) {
    LogManager::Log("按钮 " + this->GetLabel() + " 捕获鼠标事件");
    if (event.GetType() == EventType::MouseInput) {
        const MouseInputEvent & mouseInputEvent = static_cast<const MouseInputEvent&>(event);
        bool isMouseCurrentlyOver = this->resourceBagPtr->GetResource<CAnimateSprite>("Entity").get()->IsPointInSprite(mouseInputEvent.GetX(), mouseInputEvent.GetY());

        if (mouseInputEvent.IsLeftPressed() && isMouseCurrentlyOver) {
            if (!isClicked) {
                isClicked = true;
                LogManager::Log("按钮点击: " + label_);
                UpdateAnimation();
                UpdateSound();
                ButtonClickEvent buttonEvent("按钮点击事件: " + label_);
                EventManager::Instance().DispatchEvent(buttonEvent);
                isClicked = false;
            }
        } else {
            isClicked = false;
            if (isMouseCurrentlyOver && !isMouseOver) {
                isMouseOver = true;
                LogManager::Log("鼠标进入按钮: " + label_);
                UpdateAnimation();
            } else if (!isMouseCurrentlyOver && isMouseOver) {
                isMouseOver = false;
                LogManager::Log("鼠标离开按钮: " + label_);
                UpdateAnimation();
            }
        }
    } else {
        LogManager::Log("未处理的事件类型");
    }
}

void Button::UpdateState() {
    LogManager::Log("更新按钮状态: " + this->GetLabel());
    // 实现按钮状态更新逻辑（如需要）
}

void Button::UpdateAnimation() {
    LogManager::Log("更新按钮动画: " + this->GetLabel());
    CAnimateSprite* sprite = this->resourceBagPtr->GetResource<CAnimateSprite>("Entity").get();

    if (sprite) {
        if (isClicked) {
            sprite->AnimateSpritePlayAnimation("clicked", true);
            LogManager::Log("播放点击动画");
        } else if (isMouseOver) {
            sprite->AnimateSpritePlayAnimation("hover", false);
            LogManager::Log("播放悬停动画");
        } else {
            sprite->AnimateSpritePlayAnimation("default", false);
            LogManager::Log("播放默认动画");
        }
    } else {
        LogManager::Log("未找到动画精灵资源");
    }
}

void Button::UpdateSound() {
    LogManager::Log("更新按钮声音: " + this->GetLabel());
    CSound* sound = resourceBagPtr->GetResource<CSound>("ButtonSound").get();
    if (sound && isClicked) {
        sound->PlaySound();
        LogManager::Log("播放按钮声音");
    } else if (!sound) {
        LogManager::Log("未找到声音资源");
    }
}
 // 用于调用无参数成员函数
void Button::CallOnAllButtons(const std::function<void(Button&)>& func){
    for (auto& pair : buttons_) {
        if (pair.second) {
            func(*pair.second);
        }
    }
}
 // 用于调用带参数的成员函数
template <typename... Args>
void Button::CallOnAllButtons(const std::function<void(Button&, Args...)>& func, Args... args) {
    for (auto& pair : buttons_) {
        if (pair.second) {
            func(*pair.second, args...);
        }
    }
}