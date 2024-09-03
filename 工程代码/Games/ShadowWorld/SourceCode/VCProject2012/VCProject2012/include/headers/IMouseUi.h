#pragma once

#include <string>
#include "entity.h"
#include "ResourceBag.h"
#include "CSprite.h"
#include "EventDrivenSystem.h"
#include "UI.h"

class IMouseUi:public UI		//����һ�����ɽ�����UI�ӿ�
{
public:
	IMouseUi(float initialX, float initialY,const std::string& resourceBagName,const std::string& label);
	~IMouseUi();
	void Init() override;
	void breakdown() override;
	void RegisterMouseListener();
	void UnregisterMouseListener();
	virtual void HandleOperateEvent(const OperateEvent& event) = 0;	// �ӿ�  ��������η��������ж��߼�
	void SetEventHandler(const std::function<void()>&  handler);	//�����¼�������
	OperateEvent::OperateType GetNowOperation() const {return Operating;}
protected:
	void UpdateState()override;
	void UpdateAnimation()override;
	void UpdateSound()override;
	void HandleMouseEvent(const MouseInputEvent& event); //  ��������¼�,��Ҫ���ڴ���UI���в����߼�
	std::function<void()> EventHandler;						//�洢��UI�ӹ����һЩ�ɶ���Ϣ
	bool isListenerRegistered;//    �����Ǽ�����ע��״̬��ʶ��һ�㲻�ù�				
	bool isMouseOver;
    bool isClicked; //		������һЩUI״̬	//
	OperateEvent::OperateType Operating;
};













// Button ��
//======================================================
//				���ǰ�ťͨ��Ľӿ�
//======================================================
class Button : public IMouseUi {
public:
	Button(float initialX, float initialY,const std::string& resourceBagName,const std::string& label);
    ~Button();

    
	void Init() override;
	void breakdown() override;
    
	void RegisterMouseListener();
	void UnregisterMouseListener();
	void SetClickHandler(const std::function<void()>& handler);

protected:
	void HandleOperateEvent(const OperateEvent& event) override;
	void UpdateState()override;
	void UpdateAnimation()override;
	void UpdateSound()override;
	bool isListenerRegistered; 

   
};
//=======================================================================================
//								���������������Ⱦ�İ�ť��
//=======================================================================================
//ӵ���������Դ���ؽӿ�,����Դ�� <string (json��ʽ)>




class ArtButton : public Button{
public:
	ArtButton(float initialX, float initialY,const std::string& resourceBagName,const std::string& label) ;
	~ArtButton();
	void Init() override;
	void breakdown() override;
protected:
	void UpdateState()override;
	void UpdateAnimation()override;
	void UpdateSound()override;

};
//=======================================================================================
//								�����Ǻ���������Ⱦ�İ�ť��
//=======================================================================================
//��Դ����Դ�� <json�ļ�>


class RenderButton : public Button{
public:
	RenderButton(float initialX, float initialY,const std::string& resourceBagName,const std::string& label) ;
	~RenderButton();
	void Init() override;
	void breakdown() override;
protected:
	void UpdateState()override;
	void UpdateAnimation()override;
	void UpdateSound()override;
};