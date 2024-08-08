#ifndef STATEMACHINE_H
#define STATEMACHINE_H

#include <iostream>
#include <map>
#include <string>
#include <cassert>
#include "Logger.h"


//xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
//===========================================================================================
// 状态接口
class State {
public:
    virtual ~State() {}
    virtual void Enter() = 0;
    virtual void Exit() = 0;
    virtual void Update(int userChoice) = 0;
    virtual std::string GetNextState(int userChoice) = 0;

    // 工厂方法，创建状态实例
    static State* CreateState() { return 0; }
};
//===========================================================================================
//xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
















//xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
//===========================================================================================
// 状态机类
class StateMachine {
public:
    StateMachine() : currentState_(0) {}

    // 添加状态到状态机
    void AddState(const std::string& name, State* state) {
        states_[name] = state;
    }

    // 设置当前状态
    void SetCurrentState(const std::string& name) {
        std::map<std::string, State*>::iterator it = states_.find(name);
        if (it != states_.end()) {
            if (currentState_) {
                currentState_->Exit();
            }
            currentState_ = it->second;
            currentStateName_ = name;
            currentState_->Enter();
        } else {
            std::cerr << "Error: State " << name << " does not exist!" << std::endl;
        }
    }

    // 更新状态机
    void Update(int userChoice) {
        if (currentState_) {
            currentState_->Update(userChoice);
            std::string nextState = currentState_->GetNextState(userChoice);
            if (!nextState.empty() && nextState != currentStateName_) {
                SetCurrentState(nextState);
            }
        }
    }

    std::string GetCurrentStateName() const {
        return currentStateName_;
    }

    // 公有方法来获取状态
    State* GetState(const std::string& name) const {
        std::map<std::string, State*>::const_iterator it = states_.find(name);
        if (it != states_.end()) {
            return it->second;
        }
        return 0;
    }

    // 清理状态对象
    ~StateMachine() {
        for (std::map<std::string, State*>::iterator it = states_.begin(); it != states_.end(); ++it) {
            delete it->second;
        }
    }

private:
    std::map<std::string, State*> states_;
    State* currentState_;
    std::string currentStateName_;
};
//===========================================================================================
//xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx






//xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
//===========================================================================================
// 主菜单状态
class MainMenuState : public State {
public:
    MainMenuState() {}

    void Enter() override {
        std::cout << "Main Menu: Press 1 to Start, 2 for Settings, 3 to Exit, 4 to Pause." << std::endl;
    }

    void Exit() override {
        std::cout << "Exiting Main Menu." << std::endl;
    }

    void Update(int userChoice) override {
        // 处理用户输入由 GetNextState 完成
    }

    std::string GetNextState(int userChoice) override {
        if (userChoice == 1) return "Game";
        if (userChoice == 2) return "Settings";
        if (userChoice == 3) return "Exit";
        if (userChoice == 4) return "PauseMenu";
        return "";
    }

    // 工厂方法
    static State* CreateState() { return new MainMenuState(); }
};
//===========================================================================================
//xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx







//xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
//===========================================================================================
// 游戏状态
class GameState : public State {
public:
    GameState() {}

    void Enter() override {
        std::cout << "Game: Press 0 to Return to Main Menu." << std::endl;
    }

    void Exit() override {
        std::cout << "Exiting Game." << std::endl;
    }

    void Update(int userChoice) override {
        // 处理用户输入由 GetNextState 完成
    }

    std::string GetNextState(int userChoice) override {
        if (userChoice == 0) return "MainMenu";
        return "";
    }

    // 工厂方法
    static State* CreateState() { return new GameState(); }
};
//===========================================================================================
//xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx








//xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
//===========================================================================================
// 设置菜单状态
class SettingsMenuState : public State {
public:
    SettingsMenuState() {}

    void Enter() override {
        std::cout << "Settings Menu: Press 1 to Return to Main Menu." << std::endl;
    }

    void Exit() override {
        std::cout << "Exiting Settings Menu." << std::endl;
    }

    void Update(int userChoice) override {
        // 处理用户输入由 GetNextState 完成
    }

    std::string GetNextState(int userChoice) override {
        if (userChoice == 1) return "MainMenu";
        return "";
    }

    // 工厂方法
    static State* CreateState() { return new SettingsMenuState(); }
};

//===========================================================================================
//xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx









//xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
//===========================================================================================
// 暂停菜单状态
class PauseMenuState : public State {
public:
    PauseMenuState() {}

    void Enter() override {
        std::cout << "Pause Menu: Press 1 to Return to Main Menu, 2 to Exit." << std::endl;
    }

    void Exit() override {
        std::cout << "Exiting Pause Menu." << std::endl;
    }

    void Update(int userChoice) override {
        // 处理用户输入由 GetNextState 完成
    }

    std::string GetNextState(int userChoice) override {
        if (userChoice == 1) return "MainMenu";
        if (userChoice == 2) return "Exit";
        return "";
    }

    // 工厂方法
    static State* CreateState() { return new PauseMenuState(); }
};
//===========================================================================================
//xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx












//xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
//===========================================================================================
// 退出菜单状态
class ExitMenuState : public State {
public:
    ExitMenuState() {}

    void Enter() override {
        std::cout << "Exiting the game. Goodbye!" << std::endl;
    }

    void Exit() override {}

    void Update(int userChoice) override {
        // 退出状态，没有转移
    }

    std::string GetNextState(int userChoice) override {
        return ""; // 退出状态，没有下一个状态
    }

    // 工厂方法
    static State* CreateState() { return new ExitMenuState(); }
};

#endif // STATEMACHINE_H
//===========================================================================================
//xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx


















/*



#include "StateMachine.h"

void TestStateMachine() {
    StateMachine sm;

    // 添加状态
    sm.AddState("MainMenu", MainMenuState::CreateState());
    sm.AddState("Game", GameState::CreateState()); // 添加 Game 状态
    sm.AddState("Settings", SettingsMenuState::CreateState());
    sm.AddState("PauseMenu", PauseMenuState::CreateState());
    sm.AddState("Exit", ExitMenuState::CreateState());

    // 设置当前状态
    sm.SetCurrentState("MainMenu");

    int userChoice;
    while (true) {
        std::cin >> userChoice;
        sm.Update(userChoice);

        if (sm.GetCurrentStateName() == "Exit") {
            break;
        }
    }

    std::cout << "Exiting program." << std::endl;
}

int main() {
    TestStateMachine();
    return 0;
}


*/