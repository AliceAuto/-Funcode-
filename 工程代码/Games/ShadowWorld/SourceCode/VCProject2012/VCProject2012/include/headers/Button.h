#pragma once

#include <string>
#include "entity.h"
#include "ResourceBag.h"
#include "CSprite.h"
#include "EventDrivenSystem.h"
// Button ¿‡
class Button : public Entity {
public:
	Button(float initialX, float initialY,const std::string& resourceBagName,const std::string& label);
    ~Button();

    void HandleMouseEvent(const MouseInputEvent& event);
	virtual void UpdateState(){};
	virtual void UpdateAnimation();
	virtual void UpdateSound();
	void Init() override;
	void breakdown() override;
    const std::string& GetLabel() const { return label_; }
	void RegisterMouseListener();
	void UnregisterMouseListener();
private:
	bool isListenerRegistered;
    std::string label_;
    bool isMouseOver;
    bool isClicked;
   
};
