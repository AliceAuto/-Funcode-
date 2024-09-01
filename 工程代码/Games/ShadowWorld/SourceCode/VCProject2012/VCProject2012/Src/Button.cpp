#include "Button.h"
#include "Logger.h"

Button::Button(float initialX, float initialY, const std::string& resourceBagName, const std::string& label) 
    :UI(initialX, initialY, resourceBagName, label),isMouseOver(false), isClicked(false), isListenerRegistered(false)
{
}
Button::~Button(){
	Button::UnregisterMouseListener() ;
}
void Button::SetClickHandler(std::function<void()> handler) {
    clickHandler = handler;
}

void Button::Init()
{
	this->UI::Init();
	Button::RegisterMouseListener();
}

void Button::breakdown(){
	this->UI::breakdown();
	this->UnregisterMouseListener();
}


void Button::HandleMouseEvent(const MouseInputEvent& event) {
    if (isOn) {
        LogManager::Log("��ť:" + this->GetLabel() + " �����������");
        bool isMouseCurrentlyOver = this->Object::resourceBagPtr->GetResource<CAnimateSprite>("Entity")->IsPointInSprite(event.GetX(), event.GetY());
        
        if (event.IsLeftPressed() && isMouseCurrentlyOver) {
            if (!isClicked) {
                isClicked = true;
                LogManager::Log("��ť���: " + GetLabel());
                this->updateAnimation();
                this->updateSound();

                // ���ð�ť�ĵ�������߼�
                if (clickHandler) {
                    clickHandler();
                }
                isClicked = false;
            }
        } else {
            isClicked = false;
            if (isMouseCurrentlyOver && !isMouseOver) {
                isMouseOver = true;
                LogManager::Log("�����밴ť: " + GetLabel());
                this->updateAnimation();
                this->updateSound();
            } else if (!isMouseCurrentlyOver && isMouseOver) {
                isMouseOver = false;
                LogManager::Log("����뿪��ť: " + GetLabel());
                this->updateAnimation();
                this->updateSound();
            }
        }
    }
}






void Button::updateAnimation() {
    // Ĭ�϶�������ʵ�� (��������������д)
}

void Button::updateSound() {
	if (isOn)
	{
	LogManager::Log("[�������]");
    CSound* sound =this->UI::resourceBagPtr->GetResource<CSound>("ButtonSound").get();
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
}




void Button::RegisterMouseListener() {
    if (!this->isListenerRegistered) {
        // ���� lambda ���ʽ�� std::function ����//


        EventManager::Instance().RegisterListener(EventType::MouseInput, UI::ID +"button_mouse_info",[this](const Event& event) 
		{
            this->HandleMouseEvent(static_cast<const MouseInputEvent&>(event));
        });
        this->isListenerRegistered = true;
        LogManager::Log("�ɹ�ע��һ��������");
    }
}

void Button::UnregisterMouseListener() {
    if (this->isListenerRegistered) {
        EventManager::Instance().RemoveListener(EventType::MouseInput, UI::ID +"button_mouse_info");
        this->isListenerRegistered = false;
        LogManager::Log("�ɹ�ע��һ��������");
    }
}




//=======================================================================================
RenderButton::RenderButton(float initialX, float initialY,const std::string& resourceBagName,const std::string& label)
: Button(initialX, initialY,resourceBagName,label)
{

}
RenderButton::~RenderButton()
{
	
}
void RenderButton::Init()
{
	Button::Init();
	CTextSprite* text =this->UI::resourceBagPtr->GetResource<CTextSprite>("ButtonText").get();
	CAnimateSprite* sprite =this->UI::resourceBagPtr->GetResource<CAnimateSprite>("Entity").get();
	text->SpriteMountToSprite( sprite->GetName(),0, 0 );
	text->SetTextString(this-> GetLabel().c_str());
}



void RenderButton::updateAnimation(){

    CAnimateSprite* sprite =this->UI::resourceBagPtr->GetResource<CAnimateSprite>("Entity").get();
	CTextSprite* text =this->UI::resourceBagPtr->GetResource<CTextSprite>("ButtonText").get();//
	LogManager::Log("[��궯��]");
    if (sprite) {
        if (isClicked) {
            text->SetSpriteScale(1.3);
			sprite->SetSpriteScale(1.3);
			
        } else if (isMouseOver) {
			LogManager::Log("				��ť�����Ŵ�");
		
			text->SetSpriteScale(0.9);
			sprite->SetSpriteScale(0.9);
        } else {
			text->SetSpriteScale(1.1);
			sprite->SetSpriteScale(1.1);

			LogManager::Log("				��ť������С");
        }
    }
}
//=================================================================================================================
ArtButton::ArtButton(float initialX, float initialY,const std::string& resourceBagName,const std::string& label)
: Button(initialX, initialY,resourceBagName,label)
{

}
ArtButton::~ArtButton()
{
	
}
void ArtButton::Init()
{
	Button::Init();
}



void ArtButton::updateAnimation(){

    CAnimateSprite* sprite =this->UI::resourceBagPtr->GetResource<CAnimateSprite>("Entity").get();
	LogManager::Log("[��궯��]");
    if (sprite) {
        if (isClicked) {
			sprite->SetSpriteScale(1.3);
        } else if (isMouseOver) {
			LogManager::Log("				��ť�����Ŵ�");
			sprite->SetSpriteScale(0.9);
        } else {
			sprite->SetSpriteScale(1.1);
			LogManager::Log("				��ť������С");
        }
    }
}
