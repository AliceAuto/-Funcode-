#pragma once

#include <string>
#include "entity.h"
#include "ResourceBag.h"
#include "CSprite.h"
#include "EventDrivenSystem.h"
// Button 类
//======================================================
//				这是按钮通类的接口
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
//								下面是免除字体渲染的按钮类
//=======================================================================================
//拥有特殊的资源加载接口,加载源于 <string (json形式)>




class ArtButton : public Button{
public:
	ArtButton(float initialX, float initialY,const std::string& resourceBagName,const std::string& label) ;
	~ArtButton();
	void Init() override;
protected:
	void updateAnimation() override;
};
//=======================================================================================
//								下面是含有字体渲染的按钮类
//=======================================================================================
//资源加载源于 <json文件>


class RenderButton : public Button{
public:
	RenderButton(float initialX, float initialY,const std::string& resourceBagName,const std::string& label) ;
	~RenderButton();
	void Init() override;
protected:
	void updateAnimation() override;
};