#include "Button.h"
#include "Logger.h"

Button::Button(const std::string& label) 
    : Entity(0.0f, 0.0f), label_(label), isMouseOver(false), isClicked(false), resourceBagPtr(new ResourceBag) {}

Button::Button(const std::string& label, ResourceBag* resourceBag)
    : Entity(0.0f, 0.0f), label_(label), isMouseOver(false), isClicked(false), resourceBagPtr(resourceBag) {}


void Button::HandleMouseEvent(const MouseInputEvent& event) {
	LogManager::Log("��ť:"+this->GetLabel()+"  �����������");
    bool isMouseCurrentlyOver = this->resourceBagPtr->GetResource<CAnimateSprite>("ButtonSprite").get()->IsPointInSprite(event.GetX(),event.GetY());
	LogManager::Log(std::to_string(isMouseCurrentlyOver));
    if (event.IsLeftPressed() && isMouseCurrentlyOver) {
        if (!isClicked) {
            isClicked = true;
            LogManager::Log("��ť���: " + label_);
            UpdateAnimation();
            UpdateSound();
        }
    } else {
        isClicked = false;
        if (isMouseCurrentlyOver && !isMouseOver) {
            isMouseOver = true;
            LogManager::Log("�����밴ť: " + label_);
            UpdateAnimation();
        } else if (!isMouseCurrentlyOver && isMouseOver) {
            isMouseOver = false;
            LogManager::Log("����뿪��ť: " + label_);
            UpdateAnimation();
        }
    }

}

void Button::UpdateAnimation() {
    CAnimateSprite* sprite = resourceBagPtr->GetResource<CAnimateSprite>("ButtonSprite").get();
	LogManager::Log("[��궯��]");
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
	LogManager::Log("[�������]");
    CSound* sound = resourceBagPtr->GetResource<CSound>("ButtonSound").get();
    if (sound && isClicked) {
        sound->PlaySound();
    }
}

ButtonManager::ButtonManager() {
        // ע��������������������󶨵� ButtonManager �� HandleMouseInput ����
   eventManager.RegisterListener(EventType::MouseInput, 
        [this](const Event& event) { this->HandleMouseInput(static_cast<const MouseInputEvent&>(event)); }
    );
    LogManager::Log("���������󶨳ɹ�!");

}

ButtonManager::~ButtonManager() {
    EventManager::Instance().RemoveListener(EventType::MouseInput, [this](const Event& event) {
        const MouseInputEvent& mouseEvent = static_cast<const MouseInputEvent&>(event);
        this->HandleMouseInput(mouseEvent);
    });
	LogManager::Log("����������!");
    for (auto& pair : buttons_) {
        delete pair.second;
    }
    buttons_.clear();
}

void ButtonManager::AddButton(Button* button) {
    if (button) buttons_[button->GetLabel()] = button;
}

void ButtonManager::HandleMouseInput(const MouseInputEvent& event) {
	LogManager::Log("��ť�����������������Ϣ");
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
