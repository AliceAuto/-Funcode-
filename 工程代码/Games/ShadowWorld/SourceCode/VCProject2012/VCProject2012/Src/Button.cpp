#include "Button.h"
#include "Logger.h"


IMouseUi::IMouseUi(float initialX, float initialY, const std::string& resourceBagName, const std::string& label) 
    :UI(initialX, initialY, resourceBagName, label), isListenerRegistered(false),isMouseOver(false), isClicked(false),Operating(OperateEvent::OperateType::None)
{
}
IMouseUi::~IMouseUi(){
	IMouseUi::UnregisterMouseListener() ;
}
void IMouseUi::SetEventHandler(const std::function<void()>& handler) {
	LogManager::Log(GetLabel()+":已设置事件处理体 "  );
    EventHandler = handler;
}

void IMouseUi::Init()
{
	this->UI::Init();
	IMouseUi::RegisterMouseListener();
}

void IMouseUi::breakdown(){
	this->UI::breakdown();
	this->UnregisterMouseListener();
}

void IMouseUi::UpdateState() {
	if(isOn){
	UI::UpdateState();
    // 更新 UI 状态的实现
	}
}

void IMouseUi::UpdateAnimation(){
	if(isOn){
	UI::UpdateAnimation();
	}
}
void IMouseUi::UpdateSound(){
	if(isOn){
	UI::UpdateSound();
	}
}
void IMouseUi::HandleMouseEvent(const MouseInputEvent& event) {
    if (!isOn) {
        return; // 如果对象未启用，忽略事件
    }

    LogManager::Log("IMouseUi:" + this->GetLabel() + " 捕获鼠标输入");

    bool isMouseCurrentlyOver = this->Object::resourceBagPtr->GetResource<CAnimateSprite>("Entity")->IsPointInSprite(event.GetX(), event.GetY());

    // 处理点击事件
    if (event.IsLeftPressed()) {
        if (isMouseCurrentlyOver) {
            if (!isClicked) {
                isClicked = true;
                LogManager::Log("IMouseUi点击: " + GetLabel());
                Operating = OperateEvent::OperateType::LeftClicked;
                EventManager::Instance().DispatchEvent(OperateEvent(OperateEvent::OperateType::LeftClicked,ID)); // 发送左键单击事件
            }
        } else {
            isClicked = false; // 如果点击在区域外，不需要处理点击事件
        }
    } else {
        // 处理点击释放的情况
        isClicked = false;
    }

    // 处理鼠标进入、悬浮和离开状态
    if (isMouseCurrentlyOver) {
        if (!isMouseOver) {
            // 鼠标从外部进入区域
            isMouseOver = true;
            LogManager::Log("鼠标进入IMouseUi: " + GetLabel());
            Operating = OperateEvent::OperateType::MouseInter;
            EventManager::Instance().DispatchEvent(OperateEvent(OperateEvent::OperateType::MouseInter,ID)); // 发送鼠标进入事件
        } else {
            // 鼠标悬浮在区域内
            LogManager::Log("鼠标悬浮在IMouseUi: " + GetLabel());
            Operating = OperateEvent::OperateType::MouseHover;
            // 在这里可以处理悬浮状态的逻辑
        }
    } else {
        if (isMouseOver) {
            // 鼠标从区域内离开
            isMouseOver = false;
            LogManager::Log("鼠标离开IMouseUi: " + GetLabel());
            Operating = OperateEvent::OperateType::MouseOut;
            EventManager::Instance().DispatchEvent(OperateEvent(OperateEvent::OperateType::MouseOut,ID)); // 发送鼠标离开事件
        }
    }
}








void IMouseUi::RegisterMouseListener() {
    if (!this->isListenerRegistered) {
        // 保存 lambda 表达式到 std::function 对象//


        EventManager::Instance().RegisterListener(EventType::MouseInput, ID +"IMouseUi_mouse_info",[this](const Event& event) 
		{
            this->HandleMouseEvent(static_cast<const MouseInputEvent&>(event));
        });
        this->isListenerRegistered = true;
        LogManager::Log("成功注册一个鼠标监听");
    }
}

void IMouseUi::UnregisterMouseListener() {
    if (this->isListenerRegistered) {
        EventManager::Instance().RemoveListener(EventType::MouseInput, ID +"IMouseUi_mouse_info");
        this->isListenerRegistered = false;
        LogManager::Log("成功注销一个鼠标监听");
    }
}







//=======================================================================================================================================================================









Button::Button(float initialX, float initialY, const std::string& resourceBagName, const std::string& label) 
    :IMouseUi(initialX, initialY, resourceBagName, label), isListenerRegistered(false)
{
}
Button::~Button(){
	Button::UnregisterMouseListener() ;
}
void Button::SetClickHandler(const std::function<void()>&  handler) {
	LogManager::Log(GetLabel()+":已设置事件处理体 "  );
    IMouseUi::SetEventHandler(handler);
}

void Button::Init()
{
	this->IMouseUi::Init();
	Button::RegisterMouseListener();
}

void Button::breakdown(){
	this->IMouseUi::breakdown();
	this->UnregisterMouseListener();
}
void Button::UpdateState() {
	IMouseUi::UpdateState();
    // 更新 UI 状态的实现
}



void Button::HandleOperateEvent(const OperateEvent& event) {
    if (isOn) {
        LogManager::Log("按钮:" + this->GetLabel() + " 捕获鼠标输入");

        
        if (event.GetOperation() == OperateEvent::OperateType::LeftClicked && event.GetSender() == ID) {
			
			
			EventHandler();
			
		}
		else if (event.GetOperation() == OperateEvent::OperateType::MouseInter) {
		}
		else if (event.GetOperation() == OperateEvent::OperateType::MouseOut) {
		}

		
	}

}






void Button::UpdateAnimation() {
	if (isOn){
		IMouseUi::UpdateAnimation();
		CAnimateSprite* sprite =this->resourceBagPtr->GetResource<CAnimateSprite>("Entity").get();
		if(GetNowOperation() == OperateEvent::OperateType::LeftClicked){
			sprite->SetSpriteScale(1.3);
		}
		else if(GetNowOperation()== OperateEvent::OperateType::MouseInter){
			sprite->SetSpriteScale(1.1);
		}
		else if(GetNowOperation()== OperateEvent::OperateType::MouseOut){		
			sprite->SetSpriteScale(0.9);
		}
	
	}
}

void Button::UpdateSound() {
	if (isOn)
	{
		IMouseUi::UpdateSound();
		LogManager::Log("[鼠标声音]");
		CSound* sound =this->resourceBagPtr->GetResource<CSound>("ButtonSound").get();

		if(GetNowOperation() == OperateEvent::OperateType::LeftClicked){
			
		}
		else if(GetNowOperation() == OperateEvent::OperateType::MouseInter){
			sound->PlaySoundA();
		}
		else if(GetNowOperation() == OperateEvent::OperateType::MouseOut){

		}
		
	}
}




void Button::RegisterMouseListener() {
    if (!this->isListenerRegistered) {
        // 保存 lambda 表达式到 std::function 对象//


        EventManager::Instance().RegisterListener(EventType::OperateInput, ID +"button_Operate_info",[this](const Event& event) 
		{
            this->HandleOperateEvent(static_cast<const OperateEvent&>(event));
        });
        this->isListenerRegistered = true;
        LogManager::Log("成功注册一个操作事件监听");
    }
}

void Button::UnregisterMouseListener() {
    if (this->isListenerRegistered) {
        EventManager::Instance().RemoveListener(EventType::OperateInput, ID +"button_Operate_info");
        this->isListenerRegistered = false;
        LogManager::Log("成功注销一个操作事件监听");
    }
}




//==================================================================================================================================
RenderButton::RenderButton(float initialX, float initialY,const std::string& resourceBagName,const std::string& label)
: Button(initialX, initialY,resourceBagName,label)
{
RenderButton::UnregisterMouseListener() ;
}
RenderButton::~RenderButton()
{
	
}
void RenderButton::Init()
{
	Button::Init();
	CTextSprite* text =this->resourceBagPtr->GetResource<CTextSprite>("ButtonText").get();
	CAnimateSprite* sprite =this->resourceBagPtr->GetResource<CAnimateSprite>("Entity").get();
	text->SpriteMountToSprite( sprite->GetName(),0, 0 );
	text->SetTextString(this-> GetLabel().c_str());

}
void RenderButton::breakdown(){
	this->Button::breakdown();
	this->UnregisterMouseListener();
}

void RenderButton::UpdateState() {
	if(isOn){
	Button::UpdateState();
	}
    // 更新 UI 状态的实现
}

void RenderButton::UpdateAnimation(){
	if(isOn){
	Button::UpdateAnimation();
    CAnimateSprite* sprite =this->resourceBagPtr->GetResource<CAnimateSprite>("Entity").get();
	CTextSprite* text =this->resourceBagPtr->GetResource<CTextSprite>("ButtonText").get();//

    if (sprite) {
        if (GetNowOperation() == OperateEvent::OperateType::LeftClicked){
            text->SetSpriteScale(1.3);
			
        } else if (GetNowOperation() == OperateEvent::OperateType::MouseInter) {
			LogManager::Log("				按钮持续放大");
			text->SetSpriteScale(1.1);
			
        } else if (GetNowOperation() == OperateEvent::OperateType::MouseOut){
			text->SetSpriteScale(0.9);

			LogManager::Log("				按钮持续缩小");
        }
		}	
	}
}


void RenderButton::UpdateSound(){
	if (isOn){
		Button::UpdateSound();}
}
//==================
ArtButton::ArtButton(float initialX, float initialY,const std::string& resourceBagName,const std::string& label)
: Button(initialX, initialY,resourceBagName,label)
{
	ArtButton::UnregisterMouseListener() ;
}
ArtButton::~ArtButton()
{
	
}
void ArtButton::Init()
{
	Button::Init();
}
void ArtButton::breakdown(){
	this->Button::breakdown();
	this->UnregisterMouseListener();
}
void ArtButton::UpdateState() {
	Button::UpdateState();
    // 更新 UI 状态的实现
}


void ArtButton::UpdateAnimation(){
	if(isOn){
	Button::UpdateAnimation();
    CAnimateSprite* sprite =this->resourceBagPtr->GetResource<CAnimateSprite>("Entity").get();
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
}

void ArtButton::UpdateSound(){
	if(isOn){
	Button::UpdateSound();
	}
}