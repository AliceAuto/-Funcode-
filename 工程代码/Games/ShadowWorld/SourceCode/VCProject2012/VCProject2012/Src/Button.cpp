#include "Button.h"

// ��ʼ����̬��Ա����
std::unordered_map<std::string, std::unique_ptr<Button>> Button::buttons_;
bool Button::isListenersRegistered = false;

Button::Button(const std::string& label, float posX, float posY, std::string & resourceBag)
    : Entity(posX, posY, resourceBag), // ����Ϊ��ȷ���û��๹�캯��
      label_(label), 
      isMouseOver(false), 
      isClicked(false) 
{
    LogManager::Log("������ť: " + label_ + "��λ��: (" + std::to_string(posX) + ", " + std::to_string(posY) + ")");
}

void Button::AddButton(std::unique_ptr<Button> button) {
    if (button) {
        buttons_[button->GetLabel()] = std::move(button);
        LogManager::Log("��Ӱ�ť: " + button->GetLabel());
    } else {
        LogManager::Log("��Ӱ�ťʧ��: ��ťָ��Ϊ�ա�");
    }
}

Button* Button::GetButtonByLabel(const std::string& label) {
    auto it = buttons_.find(label);
    if (it != buttons_.end()) {
        LogManager::Log("��ȡ��ť: " + label);
        return it->second.get();
    } else {
        LogManager::Log("δ�ҵ���ť: " + label);
        return nullptr;
    }
}



void Button::HandleMouseInputForAll(const Event& event) {
    LogManager::Log("�������а�ť����������¼�");
    for (auto& pair : buttons_) {
        if (pair.second) {
            pair.second->HandleMouseEvent(event);
        }
    }
}

void Button::RegisterEventListeners() {
    if (!isListenersRegistered) {
        LogManager::Log("ע����������¼�������");
        EventManager::Instance().RegisterListener(EventType::MouseInput,
            std::bind(&Button::HandleMouseInputForAll, std::placeholders::_1)
        );
        isListenersRegistered = true;
        LogManager::Log("��������¼���������ע��");
    } else {
        LogManager::Log("��������¼��������Ѿ�ע��");
    }
}

void Button::UnregisterEventListeners() {
    if (isListenersRegistered) {
        LogManager::Log("ע����������¼�������");
        EventManager::Instance().RemoveListener(EventType::MouseInput,
            std::bind(&Button::HandleMouseInputForAll, std::placeholders::_1)
        );
        isListenersRegistered = false;
        LogManager::Log("��������¼���������ע��");
    } else {
        LogManager::Log("��������¼�������δע��");
    }
}

void Button::HandleMouseEvent(const Event& event) {
    LogManager::Log("��ť " + this->GetLabel() + " ��������¼�");
    if (event.GetType() == EventType::MouseInput) {
        const MouseInputEvent & mouseInputEvent = static_cast<const MouseInputEvent&>(event);
        bool isMouseCurrentlyOver = this->resourceBagPtr->GetResource<CAnimateSprite>("Entity").get()->IsPointInSprite(mouseInputEvent.GetX(), mouseInputEvent.GetY());

        if (mouseInputEvent.IsLeftPressed() && isMouseCurrentlyOver) {
            if (!isClicked) {
                isClicked = true;
                LogManager::Log("��ť���: " + label_);
                UpdateAnimation();
                UpdateSound();
                ButtonClickEvent buttonEvent("��ť����¼�: " + label_);
                EventManager::Instance().DispatchEvent(buttonEvent);
                isClicked = false;
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
    } else {
        LogManager::Log("δ������¼�����");
    }
}

void Button::UpdateState() {
    LogManager::Log("���°�ť״̬: " + this->GetLabel());
    // ʵ�ְ�ť״̬�����߼�������Ҫ��
}

void Button::UpdateAnimation() {
    LogManager::Log("���°�ť����: " + this->GetLabel());
    CAnimateSprite* sprite = this->resourceBagPtr->GetResource<CAnimateSprite>("Entity").get();

    if (sprite) {
        if (isClicked) {
            sprite->AnimateSpritePlayAnimation("clicked", true);
            LogManager::Log("���ŵ������");
        } else if (isMouseOver) {
            sprite->AnimateSpritePlayAnimation("hover", false);
            LogManager::Log("������ͣ����");
        } else {
            sprite->AnimateSpritePlayAnimation("default", false);
            LogManager::Log("����Ĭ�϶���");
        }
    } else {
        LogManager::Log("δ�ҵ�����������Դ");
    }
}

void Button::UpdateSound() {
    LogManager::Log("���°�ť����: " + this->GetLabel());
    CSound* sound = resourceBagPtr->GetResource<CSound>("ButtonSound").get();
    if (sound && isClicked) {
        sound->PlaySound();
        LogManager::Log("���Ű�ť����");
    } else if (!sound) {
        LogManager::Log("δ�ҵ�������Դ");
    }
}
 // ���ڵ����޲�����Ա����
void Button::CallOnAllButtons(const std::function<void(Button&)>& func){
    for (auto& pair : buttons_) {
        if (pair.second) {
            func(*pair.second);
        }
    }
}
 // ���ڵ��ô������ĳ�Ա����
template <typename... Args>
void Button::CallOnAllButtons(const std::function<void(Button&, Args...)>& func, Args... args) {
    for (auto& pair : buttons_) {
        if (pair.second) {
            func(*pair.second, args...);
        }
    }
}