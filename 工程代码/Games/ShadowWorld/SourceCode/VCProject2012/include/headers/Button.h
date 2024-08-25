#ifndef BUTTON_H
#define BUTTON_H

#include "Logger.h"
#include <unordered_map>
#include <memory>
#include "Entity.h"
#include "EventDrivenSystem.h"
#include "ResourceBag.h"

// 按钮类
class Button : public Entity
{
public:
    // 修改构造函数以包含位置参数
    Button(const std::string& label, float posX, float posY, std::string & resourceBag);

    // 静态方法用于管理按钮
    static void AddButton(std::unique_ptr<Button> button);
    static Button* GetButtonByLabel(const std::string& label);

    static void Button::CallOnAllButtons(const std::function<void(Button&)>& func);
	template <typename... Args>
    static void CallOnAllButtons(const std::function<void(Button&, Args...)>& func, Args... args);
    
    void RegisterEventListeners();
    void UnregisterEventListeners();
    // 按钮事件处理
    void HandleMouseEvent(const Event& event);
    void UpdateState() override;
    void UpdateAnimation() override;
    void UpdateSound() override;
    std::string GetLabel() const { return label_; }

private:
    std::string label_;
    float posX_; // 按钮的 X 坐标
    float posY_; // 按钮的 Y 坐标
    bool isMouseOver;
    bool isClicked;
  

    // 静态按钮集合和事件监听标志
    static std::unordered_map<std::string, std::unique_ptr<Button>> buttons_;
    static bool isListenersRegistered;
};

#endif // BUTTON_H
