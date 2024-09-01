#ifndef SCENESTATES_H
#define SCENESTATES_H

#include <string>
#include "StateMachine.h"
#include "EventDrivenSystem.h"
#include "Logger.h"
#include "CSystem.h"
#include "Button.h"
#include "ObjectManager.h"

// ���˵�״̬
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





// ��Ϸ״̬
class GameState : public State {
public:
    GameState();
    ~GameState();
    void Enter() override;
    void Exit() override;
    void Update(float fDeltaTime) override;


    State* CreateState() const override;
};

// ���ò˵�״̬
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

// ��ͣ�˵�״̬
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

// �˳��˵�״̬
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

// �߷�״̬
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
