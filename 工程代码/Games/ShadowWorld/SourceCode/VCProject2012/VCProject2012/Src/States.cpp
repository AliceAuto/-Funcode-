#include "States.h"
#include "headers\Logger.h"
#include "headers\CSystem.h"	//	Ҫ����������loadMap�����³���




//===============================================================
/*
							����״̬ʵ����ʵ��
*/
//===============================================================




















// ���˵�״̬ʵ��
//==================================================================================
MainMenuState::MainMenuState() {}		//���캯��ʵ��
MainMenuState::~MainMenuState() {}		//��������ʵ��
void MainMenuState::Enter()
{
    LogManager::Log("�ѽ������˵�����");
	CSystem::LoadMap("mainMenu.t2d");//�����³���,ɾ���ɳ������о���
	//���Ų˵����볡����

}

void MainMenuState::Exit()
{
    LogManager::Log("���˳����˵�");
	//�����ڴ��Եĳ�������
	
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











// ��Ϸ״̬ʵ��
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















// ���ò˵�״̬ʵ��
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










// ��ͣ�˵�״̬ʵ��
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














// �˳��˵�״̬ʵ��
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