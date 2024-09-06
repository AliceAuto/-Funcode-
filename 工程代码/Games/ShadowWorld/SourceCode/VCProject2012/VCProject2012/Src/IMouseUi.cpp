#include "IMouseUi.h"
#include "Logger.h"

//===========================================================================================================================================================================
//																				以下为UI输入处理层
//=======================================================================================================================================================================

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

    if (event.IsLeftPressed()) {
        if (isMouseCurrentlyOver) {
            if (!isClicked) {
                isClicked = true;
                LogManager::Log("IMouseUi点击: " + GetLabel());

                EventManager::Instance().DispatchEvent(OperateEvent(OperateEvent::OperateType::LeftClicked, ID)); // 发送左键单击事件
            }
        } else {
            isClicked = false; // 如果点击在区域外，不需要处理点击事件
        }
    } else {
        if (isClicked && isMouseCurrentlyOver) {
            // 鼠标左键释放时触发事件
            isClicked = false;
            LogManager::Log("IMouseUi点击结束: " + GetLabel());

            EventManager::Instance().DispatchEvent(OperateEvent(OperateEvent::OperateType::LeftClickedRelease, ID)); // 发送左键释放事件
        }
    }

    if (isMouseCurrentlyOver) {
        if (!isMouseOver) {
            isMouseOver = true;
            LogManager::Log("鼠标进入IMouseUi: " + GetLabel());

            EventManager::Instance().DispatchEvent(OperateEvent(OperateEvent::OperateType::MouseInter, ID));
        } else {
            if (event.IsLeftPressed()) {
                LogManager::Log("鼠标左键拖动在IMouseUi: " + GetLabel());
                EventManager::Instance().DispatchEvent(OperateEvent(OperateEvent::OperateType::DragInput, ID));

            } else if (!event.IsLeftPressed()) {
                LogManager::Log("鼠标左键结束拖动在IMouseUi: " + GetLabel());
                EventManager::Instance().DispatchEvent(OperateEvent(OperateEvent::OperateType::DragOverInput, ID));

                LogManager::Log("鼠标悬浮在IMouseUi: " + GetLabel());

            }
        }
    } else {
        if (isMouseOver) {
            isMouseOver = false;
            LogManager::Log("鼠标离开IMouseUi: " + GetLabel());
            Operating = OperateEvent::OperateType::MouseOut;
            EventManager::Instance().DispatchEvent(OperateEvent(OperateEvent::OperateType::MouseOut, ID));
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






//===========================================================================================================================================================================
//																				以下为按钮层
//=======================================================================================================================================================================









Button::Button(float initialX, float initialY, const std::string& resourceBagName, const std::string& label) 
    :IMouseUi(initialX, initialY, resourceBagName, label), isListenerRegistered(false)
{
}
Button::~Button(){
	this->Button::UnregisterListener() ;
}
void Button::SetClickHandler(const std::function<void()>&  handler) {
	LogManager::Log(GetLabel()+":已设置事件处理体 "  );
    IMouseUi::SetEventHandler(handler);
}

void Button::Init()
{
	this->IMouseUi::Init();
	this->Button::RegisterListener();
}

void Button::breakdown(){
	this->IMouseUi::breakdown();
	this->UnregisterListener();
}
void Button::UpdateState() {
	IMouseUi::UpdateState();
    // 更新 UI 状态的实现
}



void Button::HandleOperateEvent(const OperateEvent& event) {
    if (isOn) {
        LogManager::Log("按钮:" + this->GetLabel() + " 捕获鼠标输入");

        
        if (event.GetOperation() == OperateEvent::OperateType::LeftClicked && event.GetSender() == ID) {
			
			Operating = OperateEvent::OperateType::LeftClicked;
			
			
		}
		else if (event.GetOperation() == OperateEvent::OperateType::LeftClickedRelease&& event.GetSender() == ID) {
			Operating = OperateEvent::OperateType::LeftClickedRelease;
			EventHandler();
		
		}
		else if (event.GetOperation() == OperateEvent::OperateType::MouseInter&& event.GetSender() == ID) {
			Operating = OperateEvent::OperateType::MouseInter;
		}
		else if (event.GetOperation() == OperateEvent::OperateType::MouseOut&& event.GetSender() == ID) {
			Operating = OperateEvent::OperateType::MouseOut;
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




void Button::RegisterListener() {
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

void Button::UnregisterListener() {
    if (this->isListenerRegistered) {
        EventManager::Instance().RemoveListener(EventType::OperateInput, ID +"button_Operate_info");
        this->isListenerRegistered = false;
        LogManager::Log("成功注销一个操作事件监听");
    }
}


//===========================================================================================================================================================================
//																				以下为按钮拓展层
//=======================================================================================================================================================================


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
	CTextSprite* text =this->resourceBagPtr->GetResource<CTextSprite>("ButtonText").get();
	CAnimateSprite* sprite =this->resourceBagPtr->GetResource<CAnimateSprite>("Entity").get();
	text->SpriteMountToSprite( sprite->GetName(),0, 0 );
	text->SetTextString(this-> GetLabel().c_str());

}
void RenderButton::breakdown(){
	this->Button::breakdown();

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
//=============================================================================================================================================
//															这是可拖动 积木组件类实现
//===========================================================================================================================================


DraggableBlock::DraggableBlock(float initialX, float initialY, const std::string& resourceBagName, const std::string& label)
    : IMouseUi(initialX, initialY, resourceBagName, label), isDragging(false),SetX(0),SetY(0),isListenerRegistered(false)
{
}

DraggableBlock::~DraggableBlock() {
    UnregisterListener();
}

void DraggableBlock::Init() {
    IMouseUi::Init();
	this->RegisterListener();
}

void DraggableBlock::breakdown() {
    IMouseUi::breakdown();
	this->UnregisterListener();
   
}

void DraggableBlock::RegisterListener(){
if (!this->isListenerRegistered) {
        // 保存 lambda 表达式到 std::function 对象//


        EventManager::Instance().RegisterListener(EventType::OperateInput, ID +"IDrag_Operate_info",[this](const Event& event) 
		{
            this->HandleOperateEvent(static_cast<const OperateEvent&>(event));
        });
        this->isListenerRegistered = true;
        LogManager::Log("成功注册一个拖动操作事件监听");
    }}
void DraggableBlock::UnregisterListener(){if (this->isListenerRegistered) {
        EventManager::Instance().RemoveListener(EventType::OperateInput, ID +"IDrag_Operate_info");
        this->isListenerRegistered = false;
        LogManager::Log("成功注销一个拖动操作事件监听");
    }}



void DraggableBlock::HandleOperateEvent(const OperateEvent& event) {
	if (event.GetOperation()==OperateEvent::OperateType::DragInput&& event.GetSender() == ID){
		Operating = OperateEvent::OperateType::DragInput;
		isDragging = true;
	}
	else if (event.GetOperation()==OperateEvent::OperateType::DragOverInput&& event.GetSender() == ID){
		Operating = OperateEvent::OperateType::DragOverInput;
		isDragging = false;

	
	}

}

void DraggableBlock::UpdateState() {
	if(isOn){
	CAnimateSprite* sprite =this->resourceBagPtr->GetResource<CAnimateSprite>("Entity").get();
	IMouseUi::UpdateState();
	if (isDragging){
		posX = Mouse::Instance().x;
		posY= Mouse::Instance().y;
	sprite->SetSpritePosition(posX,posY);
	}
    // 更新 UI 状态的实现
	}
}


void DraggableBlock::UpdateAnimation(){
	if(isOn){
	IMouseUi::UpdateAnimation();
    CAnimateSprite* sprite =this->resourceBagPtr->GetResource<CAnimateSprite>("Entity").get();

	if (sprite) {
        if (GetNowOperation() == OperateEvent::OperateType::DragInput) {
			LogManager::Log("				按钮持续放大");
			sprite->SetSpriteScale(1.3);
			
        } 
		else if (GetNowOperation() == OperateEvent::OperateType::DragOverInput){
			sprite->SetSpriteScale(1);

			LogManager::Log("				按钮持续缩小");
        }
		}	
	}
	
}

void DraggableBlock::UpdateSound(){
	if(isOn){

	}
}