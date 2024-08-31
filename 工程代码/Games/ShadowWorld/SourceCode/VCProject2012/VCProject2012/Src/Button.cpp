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
	LogManager::Log("按钮:"+this->GetLabel()+"  捕获鼠标输入");
    bool isMouseCurrentlyOver = this->Entity::resourceBagPtr->GetResource<CAnimateSprite>("Entity").get()->IsPointInSprite(event.GetX(),event.GetY());
	
    if (event.IsLeftPressed() && isMouseCurrentlyOver) {
        if (!isClicked) {
            isClicked = true;
            LogManager::Log("按钮点击: " + label_);
            updateAnimation();
            updateSound();
			ButtonClickEvent buttonEvent(label_);
			// 分发事件
			EventManager::Instance().DispatchEvent(buttonEvent);




			isClicked = false;
        }
    } else {
        isClicked = false;
        if (isMouseCurrentlyOver && !isMouseOver) {
            isMouseOver = true;
            LogManager::Log("鼠标进入按钮: " + label_);
            updateAnimation();
            updateSound();
        } else if (!isMouseCurrentlyOver && isMouseOver) {
            isMouseOver = false;
            LogManager::Log("鼠标离开按钮: " + label_);
            updateAnimation();
            updateSound();
        }
    }

}




void Button::updateAnimation() {
    CAnimateSprite* sprite =this->Entity::resourceBagPtr->GetResource<CAnimateSprite>("Entity").get();
	LogManager::Log("[鼠标动画]");
    if (sprite) {
        if (isClicked) {
            sprite->SetSpriteScale(1.5);
			
        } else if (isMouseOver) {
			LogManager::Log("				按钮持续放大");
		
			sprite->SetSpriteScale(0.9);
        } else {
			sprite->SetSpriteScale(1.1);
        }
    }

}

void Button::updateSound() {
	LogManager::Log("[鼠标声音]");
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
        // 保存 lambda 表达式到 std::function 对象//


        EventManager::Instance().RegisterListener(EventType::MouseInput, Entity::ID +"button_mouse_info",[this](const Event& event) 
		{
            this->HandleMouseEvent(static_cast<const MouseInputEvent&>(event));
        });
        this->isListenerRegistered = true;
        LogManager::Log("成功注册一个鼠标监听");
    }
}

void Button::UnregisterMouseListener() {
    if (this->isListenerRegistered) {
        EventManager::Instance().RemoveListener(EventType::MouseInput, Entity::ID +"button_mouse_info");
        this->isListenerRegistered = false;
        LogManager::Log("成功注销一个鼠标监听");
    }
}


