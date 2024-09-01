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
	Button::RegisterMouseListener();
}

void Button::breakdown(){
	this->Entity::breakdown();
	this->UnregisterMouseListener();
}



void Button::HandleMouseEvent(const MouseInputEvent& event) {
	if (isOn){
	LogManager::Log("按钮:"+this->GetLabel()+"  捕获鼠标输入");
    bool isMouseCurrentlyOver = this->Entity::resourceBagPtr->GetResource<CAnimateSprite>("Entity").get()->IsPointInSprite(event.GetX(),event.GetY());
	
    if (event.IsLeftPressed() && isMouseCurrentlyOver) {
        if (!isClicked) {
            isClicked = true;
            LogManager::Log("按钮点击: " + label_);
            this->updateAnimation();
            this->updateSound();
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
            this->updateAnimation();
            this->updateSound();
        } else if (!isMouseCurrentlyOver && isMouseOver) {
            isMouseOver = false;
            LogManager::Log("鼠标离开按钮: " + label_);
            this->updateAnimation();
            this->updateSound();
        }
    }
	}
}




void Button::updateAnimation() {
 
}

void Button::updateSound() {
	if (isOn)
	{
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
	CTextSprite* text =this->Entity::resourceBagPtr->GetResource<CTextSprite>("ButtonText").get();
	CAnimateSprite* sprite =this->Entity::resourceBagPtr->GetResource<CAnimateSprite>("Entity").get();
	text->SpriteMountToSprite( sprite->GetName(),0, 0 );
	text->SetTextString(this->label_.c_str());
}



void RenderButton::updateAnimation(){

    CAnimateSprite* sprite =this->Entity::resourceBagPtr->GetResource<CAnimateSprite>("Entity").get();
	CTextSprite* text =this->Entity::resourceBagPtr->GetResource<CTextSprite>("ButtonText").get();//
	LogManager::Log("[鼠标动画]");
    if (sprite) {
        if (isClicked) {
            text->SetSpriteScale(1.3);
			sprite->SetSpriteScale(1.3);
			
        } else if (isMouseOver) {
			LogManager::Log("				按钮持续放大");
		
			text->SetSpriteScale(0.9);
			sprite->SetSpriteScale(0.9);
        } else {
			text->SetSpriteScale(1.1);
			sprite->SetSpriteScale(1.1);

			LogManager::Log("				按钮持续缩小");
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

    CAnimateSprite* sprite =this->Entity::resourceBagPtr->GetResource<CAnimateSprite>("Entity").get();
	LogManager::Log("[鼠标动画]");
    if (sprite) {
        if (isClicked) {
			sprite->SetSpriteScale(1.3);
        } else if (isMouseOver) {
			LogManager::Log("				按钮持续放大");
			sprite->SetSpriteScale(0.9);
        } else {
			sprite->SetSpriteScale(1.1);
			LogManager::Log("				按钮持续缩小");
        }
    }
}
