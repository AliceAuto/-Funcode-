#ifndef STATES_H
#define STATES_H

#include "StateMachine.h"

//============================================================
/*
					对状态接口类的拓展类
*/
//============================================================

























// 主菜单状态
class MainMenuState : public State {
public:
    MainMenuState();
	~MainMenuState()override;
    void Enter() override;
    void Exit() override;
    void Update(int userChoice) override;
    std::string GetNextState(int userChoice) override;

    static State* CreateState();
};






// 游戏状态
class GameState : public State {
public:
    GameState();

    void Enter() override;
    void Exit() override;
    void Update(int userChoice) override;
    std::string GetNextState(int userChoice) override;

    static State* CreateState();
};






// 设置菜单状态
class SettingsMenuState : public State {
public:
    SettingsMenuState();

    void Enter() override;
    void Exit() override;
    void Update(int userChoice) override;
    std::string GetNextState(int userChoice) override;

    static State* CreateState();
};






// 暂停菜单状态
class PauseMenuState : public State {
public:
    PauseMenuState();

    void Enter() override;
    void Exit() override;
    void Update(int userChoice) override;
    std::string GetNextState(int userChoice) override;

    static State* CreateState();
};





// 退出菜单状态
class ExitMenuState : public State {
public:
    ExitMenuState();

    void Enter() override;
    void Exit() override;
    void Update(int userChoice) override;
    std::string GetNextState(int userChoice) override;

    static State* CreateState();
};



#endif // STATES_H
