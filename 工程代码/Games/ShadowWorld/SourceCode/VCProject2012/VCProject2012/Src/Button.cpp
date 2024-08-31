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
	CAnimateSprite* sprite =this->Entity::resourceBagPtr->GetResource<CAnimateSprite>("Entity").get();
	this->RegisterMouseListener();
}

void Button::breakdown(){
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
            updateAnimation();
            updateSound();
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
            updateAnimation();
            updateSound();
        } else if (!isMouseCurrentlyOver && isMouseOver) {
            isMouseOver = false;
            LogManager::Log("����뿪��ť: " + label_);
            updateAnimation();
            updateSound();
        }
    }

}




void Button::updateAnimation() {
    CAnimateSprite* sprite =this->Entity::resourceBagPtr->GetResource<CAnimateSprite>("Entity").get();
	LogManager::Log("[��궯��]");
    if (sprite) {
        if (isClicked) {
            sprite->SetSpriteScale(1.5);
			
        } else if (isMouseOver) {
			LogManager::Log("				��ť�����Ŵ�");
		
			sprite->SetSpriteScale(0.9);
        } else {
			sprite->SetSpriteScale(1.1);
        }
    }

}

void Button::updateSound() {
	LogManager::Log("[�������]");
     CSound* sound =this->Entity::resourceBagPtr->GetResource<CSound>("ButtonSound").get();

    if (sound) {
        if (isClicked) {
			
        } 
		else if (isMouseOver) {
			sound->PlaySoundA();
        }
		else {

        }
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


