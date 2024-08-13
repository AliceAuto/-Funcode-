#include "Button.h"
#include "Logger.h"

Button::Button(const std::string& label) 
    : Entity(0.0f, 0.0f), label_(label), isMouseOver(false), isClicked(false), resourceBagPtr(new ResourceBag) {}

Button::Button(const std::string& label, ResourceBag* resourceBag)
    : Entity(0.0f, 0.0f), label_(label), isMouseOver(false), isClicked(false), resourceBagPtr(resourceBag) {}


void Button::HandleMouseEvent(const MouseInputEvent& event) {
	LogManager::Log("按钮:"+this->GetLabel()+"  捕获鼠标输入");
    bool isMouseCurrentlyOver = this->resourceBagPtr->GetResource<CAnimateSprite>("ButtonSprite").get()->IsPointInSprite(event.GetX(),event.GetY());
	LogManager::Log(std::to_string(isMouseCurrentlyOver));
    if (event.IsLeftPressed() && isMouseCurrentlyOver) {
        if (!isClicked) {
            isClicked = true;
            LogManager::Log("按钮点击: " + label_);
            UpdateAnimation();
            UpdateSound();
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

}

void Button::UpdateAnimation() {
    CAnimateSprite* sprite = resourceBagPtr->GetResource<CAnimateSprite>("ButtonSprite").get();
	LogManager::Log("[鼠标动画]");
    if (sprite) {
        if (isClicked) {
            sprite->AnimateSpritePlayAnimation("clicked", false);
        } else if (isMouseOver) {
            sprite->AnimateSpritePlayAnimation("hover", false);
        } else {
            sprite->AnimateSpritePlayAnimation("normal", false);
        }
    }
}

void Button::UpdateSound() {
	LogManager::Log("[鼠标声音]");
    CSound* sound = resourceBagPtr->GetResource<CSound>("ButtonSound").get();
    if (sound && isClicked) {
        sound->PlaySound();
    }
}

ButtonManager::ButtonManager() {
        // 注册鼠标输入监听器，将其绑定到 ButtonManager 的 HandleMouseInput 方法
   eventManager.RegisterListener(EventType::MouseInput, 
        [this](const Event& event) { this->HandleMouseInput(static_cast<const MouseInputEvent&>(event)); }
    );
    LogManager::Log("鼠标监听器绑定成功!");

}

ButtonManager::~ButtonManager() {
    EventManager::Instance().RemoveListener(EventType::MouseInput, [this](const Event& event) {
        const MouseInputEvent& mouseEvent = static_cast<const MouseInputEvent&>(event);
        this->HandleMouseInput(mouseEvent);
    });
	LogManager::Log("鼠标监听器绑定!");
    for (auto& pair : buttons_) {
        delete pair.second;
    }
    buttons_.clear();
}

void ButtonManager::AddButton(Button* button) {
    if (button) buttons_[button->GetLabel()] = button;
}

void ButtonManager::HandleMouseInput(const MouseInputEvent& event) {
	LogManager::Log("按钮管理器监听到鼠标信息");
    for (auto& pair : buttons_) {
        pair.second->HandleMouseEvent(event);
    }
}

void ButtonManager::Update() {
    for (auto& pair : buttons_) {
        pair.second->UpdateAnimation();
        pair.second->UpdateSound();
    }
}

Button* ButtonManager::GetButtonByLabel(const std::string& label) const {
    auto it = buttons_.find(label);
    return it != buttons_.end() ? it->second : nullptr;
}
