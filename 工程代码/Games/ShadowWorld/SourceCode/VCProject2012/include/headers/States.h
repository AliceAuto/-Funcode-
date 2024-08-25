#ifndef STATES_H
#define STATES_H

#include "StateMachine.h"
<<<<<<< Updated upstream

//============================================================
/*
					对状态接口类的拓展类
*/
//============================================================

























=======
#include "EventDrivenSystem.h"
#include "Logger.h"
#include "CSystem.h"
#include "Button.h"

#include "CollisionManager.h"
>>>>>>> Stashed changes
// 主菜单状态
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






// 游戏状态
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






// 设置菜单状态
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






// 暂停菜单状态
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





// 退出菜单状态
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
