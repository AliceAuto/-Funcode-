#include "IMouseUi.h"
#include "Logger.h"

//===========================================================================================================================================================================
//																				����ΪUI���봦���
//=======================================================================================================================================================================

IMouseUi::IMouseUi(float initialX, float initialY, const std::string& resourceBagName, const std::string& label) 
    :UI(initialX, initialY, resourceBagName, label), isListenerRegistered(false),isMouseOver(false), isClicked(false),Operating(OperateEvent::OperateType::None)
{
}
IMouseUi::~IMouseUi(){
	IMouseUi::UnregisterMouseListener() ;
}
void IMouseUi::SetEventHandler(const std::function<void()>& handler) {
	LogManager::Log(GetLabel()+":�������¼������� "  );
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
    // ���� UI ״̬��ʵ��
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
        return; // �������δ���ã������¼�
    }

    LogManager::Log("IMouseUi:" + this->GetLabel() + " �����������");

    bool isMouseCurrentlyOver = this->Object::resourceBagPtr->GetResource<CAnimateSprite>("Entity")->IsPointInSprite(event.GetX(), event.GetY());

    if (event.IsLeftPressed()) {
        if (isMouseCurrentlyOver) {
            if (!isClicked) {
                isClicked = true;
                LogManager::Log("IMouseUi���: " + GetLabel());

                EventManager::Instance().DispatchEvent(OperateEvent(OperateEvent::OperateType::LeftClicked, ID)); // ������������¼�
            }
        } else {
            isClicked = false; // �������������⣬����Ҫ�������¼�
        }
    } else {
        if (isClicked && isMouseCurrentlyOver) {
            // �������ͷ�ʱ�����¼�
            isClicked = false;
            LogManager::Log("IMouseUi�������: " + GetLabel());

            EventManager::Instance().DispatchEvent(OperateEvent(OperateEvent::OperateType::LeftClickedRelease, ID)); // ��������ͷ��¼�
        }
    }

    if (isMouseCurrentlyOver) {
        if (!isMouseOver) {
            isMouseOver = true;
            LogManager::Log("������IMouseUi: " + GetLabel());

            EventManager::Instance().DispatchEvent(OperateEvent(OperateEvent::OperateType::MouseInter, ID));
        } else {
            if (event.IsLeftPressed()) {
                LogManager::Log("�������϶���IMouseUi: " + GetLabel());
                EventManager::Instance().DispatchEvent(OperateEvent(OperateEvent::OperateType::DragInput, ID));

            } else if (!event.IsLeftPressed()) {
                LogManager::Log("�����������϶���IMouseUi: " + GetLabel());
                EventManager::Instance().DispatchEvent(OperateEvent(OperateEvent::OperateType::DragOverInput, ID));

                LogManager::Log("���������IMouseUi: " + GetLabel());

            }
        }
    } else {
        if (isMouseOver) {
            isMouseOver = false;
            LogManager::Log("����뿪IMouseUi: " + GetLabel());
            Operating = OperateEvent::OperateType::MouseOut;
            EventManager::Instance().DispatchEvent(OperateEvent(OperateEvent::OperateType::MouseOut, ID));
        }
    }
}







void IMouseUi::RegisterMouseListener() {
    if (!this->isListenerRegistered) {
        // ���� lambda ���ʽ�� std::function ����//


        EventManager::Instance().RegisterListener(EventType::MouseInput, ID +"IMouseUi_mouse_info",[this](const Event& event) 
		{
            this->HandleMouseEvent(static_cast<const MouseInputEvent&>(event));
        });
        this->isListenerRegistered = true;
        LogManager::Log("�ɹ�ע��һ��������");
    }
}

void IMouseUi::UnregisterMouseListener() {
    if (this->isListenerRegistered) {
        EventManager::Instance().RemoveListener(EventType::MouseInput, ID +"IMouseUi_mouse_info");
        this->isListenerRegistered = false;
        LogManager::Log("�ɹ�ע��һ��������");
    }
}






//===========================================================================================================================================================================
//																				����Ϊ��ť��
//=======================================================================================================================================================================









Button::Button(float initialX, float initialY, const std::string& resourceBagName, const std::string& label) 
    :IMouseUi(initialX, initialY, resourceBagName, label), isListenerRegistered(false)
{
}
Button::~Button(){
	this->Button::UnregisterListener() ;
}
void Button::SetClickHandler(const std::function<void()>&  handler) {
	LogManager::Log(GetLabel()+":�������¼������� "  );
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
    // ���� UI ״̬��ʵ��
}



void Button::HandleOperateEvent(const OperateEvent& event) {
    if (isOn) {
        LogManager::Log("��ť:" + this->GetLabel() + " �����������");

        
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
		LogManager::Log("[�������]");
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
        // ���� lambda ���ʽ�� std::function ����//


        EventManager::Instance().RegisterListener(EventType::OperateInput, ID +"button_Operate_info",[this](const Event& event) 
		{
            this->HandleOperateEvent(static_cast<const OperateEvent&>(event));
        });
        this->isListenerRegistered = true;
        LogManager::Log("�ɹ�ע��һ�������¼�����");
    }
}

void Button::UnregisterListener() {
    if (this->isListenerRegistered) {
        EventManager::Instance().RemoveListener(EventType::OperateInput, ID +"button_Operate_info");
        this->isListenerRegistered = false;
        LogManager::Log("�ɹ�ע��һ�������¼�����");
    }
}


//===========================================================================================================================================================================
//																				����Ϊ��ť��չ��
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
    // ���� UI ״̬��ʵ��
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
			LogManager::Log("				��ť�����Ŵ�");
			text->SetSpriteScale(1.1);
			
        } else if (GetNowOperation() == OperateEvent::OperateType::MouseOut){
			text->SetSpriteScale(0.9);

			LogManager::Log("				��ť������С");
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
    // ���� UI ״̬��ʵ��
}


void ArtButton::UpdateAnimation(){
	if(isOn){
	Button::UpdateAnimation();
    CAnimateSprite* sprite =this->resourceBagPtr->GetResource<CAnimateSprite>("Entity").get();
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
}

void ArtButton::UpdateSound(){
	if(isOn){
	Button::UpdateSound();
	}
}
//=============================================================================================================================================
//															���ǿ��϶� ��ľ�����ʵ��
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
        // ���� lambda ���ʽ�� std::function ����//


        EventManager::Instance().RegisterListener(EventType::OperateInput, ID +"IDrag_Operate_info",[this](const Event& event) 
		{
            this->HandleOperateEvent(static_cast<const OperateEvent&>(event));
        });
        this->isListenerRegistered = true;
        LogManager::Log("�ɹ�ע��һ���϶������¼�����");
    }}
void DraggableBlock::UnregisterListener(){if (this->isListenerRegistered) {
        EventManager::Instance().RemoveListener(EventType::OperateInput, ID +"IDrag_Operate_info");
        this->isListenerRegistered = false;
        LogManager::Log("�ɹ�ע��һ���϶������¼�����");
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
    // ���� UI ״̬��ʵ��
	}
}


void DraggableBlock::UpdateAnimation(){
	if(isOn){
	IMouseUi::UpdateAnimation();
    CAnimateSprite* sprite =this->resourceBagPtr->GetResource<CAnimateSprite>("Entity").get();

	if (sprite) {
        if (GetNowOperation() == OperateEvent::OperateType::DragInput) {
			LogManager::Log("				��ť�����Ŵ�");
			sprite->SetSpriteScale(1.3);
			
        } 
		else if (GetNowOperation() == OperateEvent::OperateType::DragOverInput){
			sprite->SetSpriteScale(1);

			LogManager::Log("				��ť������С");
        }
		}	
	}
	
}

void DraggableBlock::UpdateSound(){
	if(isOn){

	}
}