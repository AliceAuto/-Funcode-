#ifndef BUTTON_H
#define BUTTON_H

#include "Logger.h"
#include <unordered_map>
#include <memory>
#include "Entity.h"
#include "EventDrivenSystem.h"
#include "ResourceBag.h"

// ��ť��
class Button : public Entity
{
public:
    // �޸Ĺ��캯���԰���λ�ò���
    Button(const std::string& label, float posX, float posY, std::string & resourceBag);

    // ��̬�������ڹ���ť
    static void AddButton(std::unique_ptr<Button> button);
    static Button* GetButtonByLabel(const std::string& label);

    static void Button::CallOnAllButtons(const std::function<void(Button&)>& func);
	template <typename... Args>
    static void CallOnAllButtons(const std::function<void(Button&, Args...)>& func, Args... args);
    
    void RegisterEventListeners();
    void UnregisterEventListeners();
    // ��ť�¼�����
    void HandleMouseEvent(const Event& event);
    void UpdateState() override;
    void UpdateAnimation() override;
    void UpdateSound() override;
    std::string GetLabel() const { return label_; }

private:
    std::string label_;
    float posX_; // ��ť�� X ����
    float posY_; // ��ť�� Y ����
    bool isMouseOver;
    bool isClicked;
  

    // ��̬��ť���Ϻ��¼�������־
    static std::unordered_map<std::string, std::unique_ptr<Button>> buttons_;
    static bool isListenersRegistered;
};

#endif // BUTTON_H
