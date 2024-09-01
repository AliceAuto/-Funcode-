#pragma once

#include <string>
#include "entity.h"
#include "ResourceBag.h"
#include "CSprite.h"
#include "EventDrivenSystem.h"
// Button ��
//======================================================
//				���ǰ�ťͨ��Ľӿ�
//======================================================
class Button : public Entity {
public:
	Button(float initialX, float initialY,const std::string& resourceBagName,const std::string& label);
    ~Button();

    void HandleMouseEvent(const MouseInputEvent& event);
	void UpdateState()override{};
	void UpdateAnimation()override{};
	void UpdateSound()override{};
	void Init() override;
	void breakdown() override;
    const std::string& GetLabel() const { return label_; }
	void RegisterMouseListener();
	void UnregisterMouseListener();
	
protected:
	std::string label_;
	virtual void updateAnimation();
	virtual void updateSound();
	bool isListenerRegistered;
    
    bool isMouseOver;
    bool isClicked;
   
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
protected:
	void updateAnimation() override;
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
protected:
	void updateAnimation() override;
};