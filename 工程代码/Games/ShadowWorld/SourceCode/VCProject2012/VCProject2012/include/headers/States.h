#ifndef STATES_H
#define STATES_H

#include "StateMachine.h"

//============================================================
/*
					��״̬�ӿ������չ��
*/
//============================================================

























// ���˵�״̬
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






// ��Ϸ״̬
class GameState : public State {
public:
    GameState();

    void Enter() override;
    void Exit() override;
    void Update(int userChoice) override;
    std::string GetNextState(int userChoice) override;

    static State* CreateState();
};






// ���ò˵�״̬
class SettingsMenuState : public State {
public:
    SettingsMenuState();

    void Enter() override;
    void Exit() override;
    void Update(int userChoice) override;
    std::string GetNextState(int userChoice) override;

    static State* CreateState();
};






// ��ͣ�˵�״̬
class PauseMenuState : public State {
public:
    PauseMenuState();

    void Enter() override;
    void Exit() override;
    void Update(int userChoice) override;
    std::string GetNextState(int userChoice) override;

    static State* CreateState();
};





// �˳��˵�״̬
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
