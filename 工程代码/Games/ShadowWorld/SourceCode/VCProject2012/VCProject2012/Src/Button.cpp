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

    // �������¼�
    if (event.IsLeftPressed()) {
        if (isMouseCurrentlyOver) {
            if (!isClicked) {
                isClicked = true;
                LogManager::Log("IMouseUi���: " + GetLabel());
                Operating = OperateEvent::OperateType::LeftClicked;
                EventManager::Instance().DispatchEvent(OperateEvent(OperateEvent::OperateType::LeftClicked,ID)); // ������������¼�
            }
        } else {
            isClicked = false; // �������������⣬����Ҫ�������¼�
        }
    } else {
        // �������ͷŵ����
        isClicked = false;
    }

    // ���������롢�������뿪״̬
    if (isMouseCurrentlyOver) {
        if (!isMouseOver) {
            // �����ⲿ��������
            isMouseOver = true;
            LogManager::Log("������IMouseUi: " + GetLabel());
            Operating = OperateEvent::OperateType::MouseInter;
            EventManager::Instance().DispatchEvent(OperateEvent(OperateEvent::OperateType::MouseInter,ID)); // �����������¼�
        } else {
            // ���������������
            LogManager::Log("���������IMouseUi: " + GetLabel());
            Operating = OperateEvent::OperateType::MouseHover;
            // ��������Դ�������״̬���߼�
        }
    } else {
        if (isMouseOver) {
            // �����������뿪
            isMouseOver = false;
            LogManager::Log("����뿪IMouseUi: " + GetLabel());
            Operating = OperateEvent::OperateType::MouseOut;
            EventManager::Instance().DispatchEvent(OperateEvent(OperateEvent::OperateType::MouseOut,ID)); // ��������뿪�¼�
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







//=======================================================================================================================================================================









Button::Button(float initialX, float initialY, const std::string& resourceBagName, const std::string& label) 
    :IMouseUi(initialX, initialY, resourceBagName, label), isListenerRegistered(false)
{
}
Button::~Button(){
	Button::UnregisterMouseListener() ;
}
void Button::SetClickHandler(const std::function<void()>&  handler) {
	LogManager::Log(GetLabel()+":�������¼������� "  );
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
    // ���� UI ״̬��ʵ��
}



void Button::HandleOperateEvent(const OperateEvent& event) {
    if (isOn) {
        LogManager::Log("��ť:" + this->GetLabel() + " �����������");

        
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




void Button::RegisterMouseListener() {
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

void Button::UnregisterMouseListener() {
    if (this->isListenerRegistered) {
        EventManager::Instance().RemoveListener(EventType::OperateInput, ID +"button_Operate_info");
        this->isListenerRegistered = false;
        LogManager::Log("�ɹ�ע��һ�������¼�����");
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