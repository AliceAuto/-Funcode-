#include "States.h"
#include "headers\Logger.h"
#include "headers\CSystem.h"	//	要用这个里面的loadMap加载新场景




//===============================================================
/*
							各个状态实现类实现
*/
//===============================================================




















// 主菜单状态实现
//==================================================================================
MainMenuState::MainMenuState() {}		//构造函数实现
MainMenuState::~MainMenuState() {}		//析构函数实现
void MainMenuState::Enter()
{
    LogManager::Log("已进入主菜单界面");
	CSystem::LoadMap("mainMenu.t2d");//加载新场景,删除旧场景所有精灵
	//播放菜单的入场动画

}

void MainMenuState::Exit()
{
    LogManager::Log("已退出主菜单");
	//播放在大脑的出场动画
	
}

void MainMenuState::Update(int userChoice) {



}

std::string MainMenuState::GetNextState(int userChoice) 
{
    if (userChoice == 1) return "Game";
    if (userChoice == 2) return "Settings";
    if (userChoice == 3) return "Exit";
    if (userChoice == 4) return "PauseMenu";
    return "";
}

State* MainMenuState::CreateState() { return new MainMenuState(); }
//===============================================================================================================











// 游戏状态实现
//============================================
GameState::GameState() {}

void GameState::Enter() {
    std::cout << "Game: Press 0 to Return to Main Menu." << std::endl;
}

void GameState::Exit() {
    std::cout << "Exiting Game." << std::endl;
}

void GameState::Update(int userChoice) {}

std::string GameState::GetNextState(int userChoice) {
    if (userChoice == 0) return "MainMenu";
    return "";
}

State* GameState::CreateState() { return new GameState(); }
//=====================================================================================















// 设置菜单状态实现
//=============================================
SettingsMenuState::SettingsMenuState() {}

void SettingsMenuState::Enter() {
    std::cout << "Settings Menu: Press 1 to Return to Main Menu." << std::endl;
}

void SettingsMenuState::Exit() {
    std::cout << "Exiting Settings Menu." << std::endl;
}

void SettingsMenuState::Update(int userChoice) {}

std::string SettingsMenuState::GetNextState(int userChoice) {
    if (userChoice == 1) return "MainMenu";
    return "";
}

State* SettingsMenuState::CreateState() { return new SettingsMenuState(); }
//=======================================================================================










// 暂停菜单状态实现
//=========================================
PauseMenuState::PauseMenuState() {}

void PauseMenuState::Enter() {
    std::cout << "Pause Menu: Press 1 to Return to Main Menu, 2 to Exit." << std::endl;
}

void PauseMenuState::Exit() {
    std::cout << "Exiting Pause Menu." << std::endl;
}

void PauseMenuState::Update(int userChoice) {}

std::string PauseMenuState::GetNextState(int userChoice) {
    if (userChoice == 1) return "MainMenu";
    if (userChoice == 2) return "Exit";
    return "";
}

State* PauseMenuState::CreateState() { return new PauseMenuState(); }
//=================================================================================================














// 退出菜单状态实现
//=======================================
ExitMenuState::ExitMenuState() {}

void ExitMenuState::Enter() {
    std::cout << "Exiting the game. Goodbye!" << std::endl;
}

void ExitMenuState::Exit() {}

void ExitMenuState::Update(int userChoice) {}

std::string ExitMenuState::GetNextState(int userChoice) {
    return "";
}

State* ExitMenuState::CreateState() { return new ExitMenuState(); }
//============================================================================