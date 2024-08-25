#pragma once

#include <string>
#include "entity.h"
#include "ResourceBag.h"
#include "CSprite.h"
#include "EventDrivenSystem.h"
// Button ¿‡
class Button : public Entity {
public:
	Button(const std::string& label);
    Button(const std::string& label, ResourceBag* resourceBag);

    void HandleMouseEvent(const MouseInputEvent& event);
	virtual void UpdateState(){};
	virtual void UpdateAnimation();
	virtual void UpdateSound();

    const std::string& GetLabel() const { return label_; }

    ResourceBag* resourceBagPtr;
private:
    std::string label_;
    bool isMouseOver;
    bool isClicked;
   
};

// ButtonManager ¿‡
class ButtonManager {
public:
    ButtonManager();
    ~ButtonManager();

    void AddButton(Button* button);
    void HandleMouseInput(const MouseInputEvent& event);
    void Update();

    Button* GetButtonByLabel(const std::string& label) const;

private:
    std::unordered_map<std::string, Button*> buttons_;
};
