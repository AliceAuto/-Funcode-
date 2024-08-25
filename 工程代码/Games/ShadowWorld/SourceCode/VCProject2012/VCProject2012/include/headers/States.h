#ifndef STATES_H
#define STATES_H

#include <string>
#include "StateMachine.h"
#include "EventDrivenSystem.h"
#include "Logger.h"
#include "CSystem.h"
#include "Button.h"
#include "EntityManager.h"
#include "CollisionManager.h"
// ���˵�״̬
class MainMenuState : public State {
public:

    MainMenuState();
    ~MainMenuState();
    void Enter() override;
    void Exit() override;
    void Update() override;
    void HandleButtonInput(const ButtonClickEvent& event);
protected:
	void RegisterEventListeners() override;
    void UnregisterEventListeners()override;
    State* CreateState() const override;
	EntityManager * m_control_Manager;
	ButtonManager  * buttonManager;

};





// ��Ϸ״̬
class GameState : public State {
public:
    GameState();
    ~GameState();
    void Enter() override;
    void Exit() override;
    void Update() override;
    void HandleMouseInput(const MouseInputEvent& event) override;
    void HandleKeyboardInput(const KeyboardInputEvent& event) override;

	EntityManager * m_control_Manager;
    State* CreateState() const override;
};

// ���ò˵�״̬
class SettingsMenuState : public State {
public:
    SettingsMenuState();
    ~SettingsMenuState();
    void Enter() override;
    void Exit() override;
    void Update() override;
    void HandleMouseInput(const MouseInputEvent& event) override;
    void HandleKeyboardInput(const KeyboardInputEvent& event) override;

protected:
    State* CreateState() const override;
};

// ��ͣ�˵�״̬
class PauseMenuState : public State {
public:
    PauseMenuState();
    ~PauseMenuState();
    void Enter() override;
    void Exit() override;
    void Update() override;
    void HandleMouseInput(const MouseInputEvent& event) override;
    void HandleKeyboardInput(const KeyboardInputEvent& event) override;

protected:
    State* CreateState() const override;
};

// �˳��˵�״̬
class ExitMenuState : public State {
public:
    ExitMenuState();
    ~ExitMenuState();
    void Enter() override;
    void Exit() override;
    void Update() override;
 
    void HandleMouseInput(const MouseInputEvent& event) override;
    void HandleKeyboardInput(const KeyboardInputEvent& event) override;

protected:
    State* CreateState() const override;
};

// �߷�״̬
class HighScoreState : public State {
public:
    HighScoreState();
    ~HighScoreState();
    void Enter() override;
    void Exit() override;
    void Update() override;
 
    void HandleMouseInput(const MouseInputEvent& event) override;
    void HandleKeyboardInput(const KeyboardInputEvent& event) override;

protected:
    State* CreateState() const override;
};

#endif // STATES_H
