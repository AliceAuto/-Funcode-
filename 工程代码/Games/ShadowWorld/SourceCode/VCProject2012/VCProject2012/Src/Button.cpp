#include "Button.h"
#include "Logger.h"

Button::Button(float initialX, float initialY,const std::string& resourceBagName,const std::string& label) 
    : Entity(initialX, initialY,resourceBagName), label_(label), isMouseOver(false), isClicked(false),isListenerRegistered(false) 
{
}
Button::~Button(){
	Button::UnregisterMouseListener() ;
}


void Button::Init()
{
	this->Entity::Init();
	this->RegisterMouseListener();
}

void Button::breakdown()
{
	this->Entity::breakdown();
	this->UnregisterMouseListener();
}



void Button::HandleMouseEvent(const MouseInputEvent& event) {
	LogManager::Log("��ť:"+this->GetLabel()+"  �����������");
    bool isMouseCurrentlyOver = this->Entity::resourceBagPtr->GetResource<CAnimateSprite>("Entity").get()->IsPointInSprite(event.GetX(),event.GetY());
	
    if (event.IsLeftPressed() && isMouseCurrentlyOver) {
        if (!isClicked) {
            isClicked = true;
            LogManager::Log("��ť���: " + label_);
            UpdateAnimation();
            UpdateSound();
			ButtonClickEvent buttonEvent(label_);
    
			// �ַ��¼�
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

}




void Button::UpdateAnimation() {

    CAnimateSprite* sprite =this->Entity::resourceBagPtr->GetResource<CAnimateSprite>("Entity").get();
	LogManager::Log("[��궯��]");
    if (sprite) {
        if (isClicked) {
            sprite->AnimateSpritePlayAnimation("clicked1", true);
        } else if (isMouseOver) {
            sprite->AnimateSpritePlayAnimation("hover", false);
        } else {
            sprite->AnimateSpritePlayAnimation("clicked", false);
        }
    }

}

void Button::UpdateSound() {
	LogManager::Log("[�������]");
    CSound* sound = this->Entity::resourceBagPtr->GetResource<CSound>("ButtonSound").get();
    if (sound && isClicked) {
        sound->PlaySound();
    }
}




void Button::RegisterMouseListener() {
    if (!this->isListenerRegistered) {
        // ���� lambda ���ʽ�� std::function ����//


        EventManager::Instance().RegisterListener(EventType::MouseInput, Entity::ID +"button_mouse_info",[this](const Event& event) 
		{
            this->HandleMouseEvent(static_cast<const MouseInputEvent&>(event));
        });
        this->isListenerRegistered = true;
        LogManager::Log("�ɹ�ע��һ��������");
    }
}

void Button::UnregisterMouseListener() {
    if (this->isListenerRegistered) {
        EventManager::Instance().RemoveListener(EventType::MouseInput, Entity::ID +"button_mouse_info");
        this->isListenerRegistered = false;
        LogManager::Log("�ɹ�ע��һ��������");
    }
}


