#ifndef STATES_H
#define STATES_H

#include "StateMachine.h"
<<<<<<< Updated upstream

//============================================================
/*
					��״̬�ӿ������չ��
*/
//============================================================

























=======
#include "EventDrivenSystem.h"
#include "Logger.h"
#include "CSystem.h"
#include "Button.h"

#include "CollisionManager.h"
>>>>>>> Stashed changes
// ���˵�״̬
class MainMenuState : public State {
public:
    MainMenuState();
	~MainMenuState()override;
    void Enter() override;
    void Exit() override;
<<<<<<< Updated upstream
    void Update(int userChoice) override;
    std::string GetNextState(int userChoice) override;
=======
    void Update() override;
    void HandleButtonInput(const ButtonClickEvent& event);
protected:
	void RegisterEventListeners() override;
    void UnregisterEventListeners()override;
    State* CreateState() const override;
>>>>>>> Stashed changes

    static State* CreateState();
};






// ��Ϸ״̬
class GameState : public State {
public:
    GameState();

    void Enter() override;
    void Exit() override;
<<<<<<< Updated upstream
    void Update(int userChoice) override;
    std::string GetNextState(int userChoice) override;

    static State* CreateState();
=======
    void Update() override;
    void HandleMouseInput(const MouseInputEvent& event) override;
    void HandleKeyboardInput(const KeyboardInputEvent& event) override;
protected:
	void RegisterEventListeners() override;
    void UnregisterEventListeners()override;
    State* CreateState() const override;
>>>>>>> Stashed changes
};






// ���ò˵�״̬
class SettingsMenuState : public State {
public:
    SettingsMenuState();

    void Enter() override;
    void Exit() override;
    void Update(int userChoice) override;
    std::string GetNextState(int userChoice) override;

<<<<<<< Updated upstream
    static State* CreateState();
=======
protected:
	void RegisterEventListeners() override;
    void UnregisterEventListeners()override;
    State* CreateState() const override;
>>>>>>> Stashed changes
};






// ��ͣ�˵�״̬
class PauseMenuState : public State {
public:
    PauseMenuState();

    void Enter() override;
    void Exit() override;
    void Update(int userChoice) override;
    std::string GetNextState(int userChoice) override;

<<<<<<< Updated upstream
    static State* CreateState();
=======
protected:
	void RegisterEventListeners() override;
    void UnregisterEventListeners()override;
    State* CreateState() const override;
>>>>>>> Stashed changes
};





// �˳��˵�״̬
class ExitMenuState : public State {
public:
    ExitMenuState();

    void Enter() override;
    void Exit() override;
    void Update(int userChoice) override;
    std::string GetNextState(int userChoice) override;

<<<<<<< Updated upstream
    static State* CreateState();
=======
protected:
	void RegisterEventListeners() override;
    void UnregisterEventListeners()override;
    State* CreateState() const override;
>>>>>>> Stashed changes
};


<<<<<<< Updated upstream
=======
protected:
	void RegisterEventListeners() override;
    void UnregisterEventListeners()override;
    State* CreateState() const override;
};
>>>>>>> Stashed changes

#endif // STATES_H
