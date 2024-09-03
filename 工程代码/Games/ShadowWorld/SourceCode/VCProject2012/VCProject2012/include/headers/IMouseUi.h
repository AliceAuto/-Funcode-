#pragma once

#include <string>
#include "entity.h"
#include "ResourceBag.h"
#include "CSprite.h"
#include "EventDrivenSystem.h"
#include "UI.h"

class IMouseUi:public UI		//这是一个鼠标可交互的UI接口
{
public:
	IMouseUi(float initialX, float initialY,const std::string& resourceBagName,const std::string& label);
	~IMouseUi();
	void Init() override;
	void breakdown() override;
	void RegisterMouseListener();
	void UnregisterMouseListener();
	virtual void HandleOperateEvent(const OperateEvent& event) = 0;	// 接口  调用子类次方法进行判断逻辑
	void SetEventHandler(const std::function<void()>&  handler);	//设置事件处理体
	OperateEvent::OperateType GetNowOperation() const {return Operating;}
protected:
	void UpdateState()override;
	void UpdateAnimation()override;
	void UpdateSound()override;
	void HandleMouseEvent(const MouseInputEvent& event); //  处理鼠标事件,主要用于处理UI固有操作逻辑
	std::function<void()> EventHandler;						//存储按UI加工后的一些可读信息
	bool isListenerRegistered;//    这里是监听器注册状态标识，一般不用管				
	bool isMouseOver;
    bool isClicked; //		这里是一些UI状态	//
	OperateEvent::OperateType Operating;
};













// Button 类
//======================================================
//				这是按钮通类的接口
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
//								下面是免除字体渲染的按钮类
//=======================================================================================
//拥有特殊的资源加载接口,加载源于 <string (json形式)>




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
//								下面是含有字体渲染的按钮类
//=======================================================================================
//资源加载源于 <json文件>


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