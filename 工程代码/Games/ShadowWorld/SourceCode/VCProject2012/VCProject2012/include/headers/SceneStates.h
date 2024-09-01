#ifndef SCENESTATES_H
#define SCENESTATES_H

#include <string>
#include "StateMachine.h"
#include "EventDrivenSystem.h"
#include "Logger.h"
#include "CSystem.h"
#include "Button.h"
#include "ObjectManager.h"

// Ö÷²Ëµ¥×´Ì¬
class MainMenuState : public State {
public:

    MainMenuState();
    ~MainMenuState();
    void Enter() override;
    void Exit() override;
    void Update(float fDeltaTime) override;
   
protected:
	void RegisterEventListeners() override;
    void UnregisterEventListeners()override;
    State* CreateState() const override;
	


};





// ÓÎÏ·×´Ì¬
class GameState : public State {
public:
    GameState();
    ~GameState();
    void Enter() override;
    void Exit() override;
    void Update(float fDeltaTime) override;


    State* CreateState() const override;
};

// ÉèÖÃ²Ëµ¥×´Ì¬
class SettingsMenuState : public State {
public:
    SettingsMenuState();
    ~SettingsMenuState();
    void Enter() override;
    void Exit() override;
    void Update(float fDeltaTime) override;


protected:
    State* CreateState() const override;
};

// ÔÝÍ£²Ëµ¥×´Ì¬
class PauseMenuState : public State {
public:
    PauseMenuState();
    ~PauseMenuState();
    void Enter() override;
    void Exit() override;
    void Update(float fDeltaTime) override;


protected:
    State* CreateState() const override;
};

// ÍË³ö²Ëµ¥×´Ì¬
class ExitMenuState : public State {
public:
    ExitMenuState();
    ~ExitMenuState();
    void Enter() override;
    void Exit() override;
    void Update(float fDeltaTime) override;
 


protected:
    State* CreateState() const override;
};

// ¸ß·Ö×´Ì¬
class HighScoreState : public State {
public:
    HighScoreState();
    ~HighScoreState();
    void Enter() override;
    void Exit() override;
    void Update(float fDeltaTime) override;
 


protected:
    State* CreateState() const override;
};

#endif // STATES_H
