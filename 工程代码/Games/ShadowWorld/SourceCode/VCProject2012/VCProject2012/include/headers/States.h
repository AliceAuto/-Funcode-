#ifndef STATES_H
#define STATES_H

#include "StateMachine.h"

// Ö÷²Ëµ¥×´Ì¬
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






// ÓÎÏ·×´Ì¬
class GameState : public State {
public:
    GameState();

    void Enter() override;
    void Exit() override;
    void Update(int userChoice) override;
    std::string GetNextState(int userChoice) override;

    static State* CreateState();
};






// ÉèÖÃ²Ëµ¥×´Ì¬
class SettingsMenuState : public State {
public:
    SettingsMenuState();

    void Enter() override;
    void Exit() override;
    void Update(int userChoice) override;
    std::string GetNextState(int userChoice) override;

    static State* CreateState();
};






// ÔÝÍ£²Ëµ¥×´Ì¬
class PauseMenuState : public State {
public:
    PauseMenuState();

    void Enter() override;
    void Exit() override;
    void Update(int userChoice) override;
    std::string GetNextState(int userChoice) override;

    static State* CreateState();
};





// ÍË³ö²Ëµ¥×´Ì¬
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
