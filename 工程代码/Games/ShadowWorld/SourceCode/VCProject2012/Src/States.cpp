#include "States.h"
#include "headers\Logger.h"
#include "headers\CSystem.h"	//	Ҫ����������loadMap�����³���

<<<<<<< Updated upstream



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
=======
// MainMenuState ʵ��
MainMenuState::MainMenuState() 
{ 
	std::string button =m_control_Manager->CreateEntity(
	"{\n"
	        "  \"TypeName\"		:			\"Button\"				,\n"
            "  \"posX\"			:			0.0						,\n"
			"  \"posY\"			:			0.0						,\n"
			"  \"label\"			:		\"��ʼ��Ϸ\"					,\n"
			"  \"resourceBag\"  :			\"StartGameButton\"				\n"
	"}"
   );

}
MainMenuState::~MainMenuState() 
{
	

}

void MainMenuState::RegisterEventListeners() {
	//��ť������
	
	EventManager::Instance().RegisterListener(EventType::ButtonClick, 
    [this](const Event& event) { this->HandleButtonInput(static_cast<const ButtonClickEvent&>(event)); }
	);
}
void MainMenuState::UnregisterEventListeners(){
	//��ť������
	
	EventManager::Instance().RemoveListener(EventType::ButtonClick, [this](const Event& event) {
    const ButtonClickEvent& buttonEvent = static_cast<const ButtonClickEvent&>(event);
    this->HandleButtonInput(buttonEvent);
    });

}
void MainMenuState::Enter() {
	
    LogManager::Log("�ѽ������˵�����");
    CSystem::LoadMap("untitled.t2d");
    RegisterEventListeners();
	

    // ��ȡ�����¼�
   

>>>>>>> Stashed changes

}

void MainMenuState::Exit()
{
    LogManager::Log("���˳����˵�");
	//�����ڴ��Եĳ�������
	
}

<<<<<<< Updated upstream
void MainMenuState::Update(int userChoice) {



=======
void MainMenuState::Update() {
    // ���˵��ĸ����߼�
	m_control_Manager->UpdateAllEntities();
	
>>>>>>> Stashed changes
}

std::string MainMenuState::GetNextState(int userChoice) 
{
<<<<<<< Updated upstream
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
=======
 LogManager::Log("=========================================================");



}
GameState::~GameState()
{

}

void GameState::Enter() {
    LogManager::Log("������Ϸ״̬");
    CSystem::LoadMap("gameScene.t2d");
    RegisterEventListeners();// ����ע��
	
std::string player1 =m_control_Manager->CreateEntity(
	"{\n"
	        "  \"TypeName\"		:			\"Player\"				,\n"
            "  \"posX\"			:			0.0						,\n"
			"  \"posY\"			:			0.0						,\n"
			"  \"resourceBag\"  :			\"resources1\"				\n"
	"}"
   );

std::string block1 =m_control_Manager->CreateEntity(
	"{\n"
	        "  \"TypeName\"		:			\"PhysicalObstacle\"				,\n"
            "  \"posX\"			:			0.0							,\n"
			"  \"posY\"			:			0.0							,\n"
			"  \"resourceBag\"  :			\"block\"						\n"
	"}"
    );//
std::string block2 =m_control_Manager->CreateEntity(
	"{\n"
	        "  \"TypeName\"		:			\"PhysicalObstacle\"			,\n"
            "  \"posX\"			:			0.0						,\n"
			"  \"posY\"			:			0.0						,\n"
			"  \"resourceBag\"  :			\"block\"					\n"
	"}"
    );
std::string block3 =m_control_Manager->CreateEntity(
	"{\n"
	        "  \"TypeName\"		:			\"PhysicalObstacle\"			,\n"
            "  \"posX\"			:			0.0						,\n"
			"  \"posY\"			:			0.0						,\n"
			"  \"resourceBag\"  :			\"block\"					\n"
	"}"
    );
std::string block4 =m_control_Manager->CreateEntity(
	"{\n"
	        "  \"TypeName\"		:			\"PhysicalObstacle\"			,\n"
            "  \"posX\"			:			0.0						,\n"
			"  \"posY\"			:			0.0						,\n"
			"  \"resourceBag\"  :			\"block\"					\n"
	"}"
    );
std::string block5 =m_control_Manager->CreateEntity(
	"{\n"
	        "  \"TypeName\"		:			\"PhysicalObstacle\"			,\n"
            "  \"posX\"			:			0.0						,\n"
			"  \"posY\"			:			0.0						,\n"
			"  \"resourceBag\"  :			\"block\"					\n"
	"}"
    );
std::string block6 =m_control_Manager->CreateEntity(
	"{\n"
	        "  \"TypeName\"		:			\"PhysicalObstacle\"			,\n"
            "  \"posX\"			:			0.0						,\n"
			"  \"posY\"			:			0.0						,\n"
			"  \"resourceBag\"  :			\"block\"					\n"
	"}"
    );
std::string block7 =m_control_Manager->CreateEntity(
	"{\n"
	        "  \"TypeName\"		:			\"PhysicalObstacle\"			,\n"
            "  \"posX\"			:			0.0						,\n"
			"  \"posY\"			:			0.0						,\n"
			"  \"resourceBag\"  :			\"block\"					\n"
	"}"
    );

std::string block8 =m_control_Manager->CreateEntity(
	"{\n"
	        "  \"TypeName\"		:			\"FixeObstacle\"			,\n"
            "  \"posX\"			:			0.0						,\n"
			"  \"posY\"			:			0.0						,\n"
			"  \"resourceBag\"  :			\"FixeObstacle\"			\n"
	"}"
    );


}

void GameState::Exit() {
    LogManager::Log("�˳���Ϸ״̬");
	
    UnregisterEventListeners();// ע��������
>>>>>>> Stashed changes
}

void GameState::Update(int userChoice) {}

std::string GameState::GetNextState(int userChoice) {
    if (userChoice == 0) return "MainMenu";
    return "";
}

State* GameState::CreateState() { return new GameState(); }
//=====================================================================================

void GameState::RegisterEventListeners()
{
	m_control_Manager->RegisterEventListeners();
}

void GameState::UnregisterEventListeners()
{
	m_control_Manager->UnregisterEventListeners();
}













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

void SettingsMenuState::RegisterEventListeners(){}
void SettingsMenuState::UnregisterEventListeners(){}








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




<<<<<<< Updated upstream
=======
void PauseMenuState::RegisterEventListeners(){}
void PauseMenuState::UnregisterEventListeners(){}
>>>>>>> Stashed changes










<<<<<<< Updated upstream
// �˳��˵�״̬ʵ��
//=======================================
=======



// ExitMenuState ʵ��
>>>>>>> Stashed changes
ExitMenuState::ExitMenuState() {}

void ExitMenuState::Enter() {
    std::cout << "Exiting the game. Goodbye!" << std::endl;
}

void ExitMenuState::Exit() {}

void ExitMenuState::Update(int userChoice) {}

std::string ExitMenuState::GetNextState(int userChoice) {
    return "";
}

<<<<<<< Updated upstream
State* ExitMenuState::CreateState() { return new ExitMenuState(); }
//============================================================================
=======
void ExitMenuState::Update() {
    // �˳��˵������߼�
}


void ExitMenuState::HandleMouseInput(const MouseInputEvent& event) {
    // Handle mouse input for ExitMenuState
}

void ExitMenuState::HandleKeyboardInput(const KeyboardInputEvent& event) {
    // Handle keyboard input for ExitMenuState
}

State* ExitMenuState::CreateState() const {
    return new ExitMenuState();
}


void ExitMenuState::RegisterEventListeners(){}
void ExitMenuState::UnregisterEventListeners(){}








// HighScoreState ʵ��
HighScoreState::HighScoreState() {}
HighScoreState::~HighScoreState() {}

void HighScoreState::Enter() {
    LogManager::Log("����߷�״̬");
    CSystem::LoadMap("highScore.t2d");
    RegisterEventListeners();
}

void HighScoreState::Exit() {
    LogManager::Log("�˳��߷�״̬");
    UnregisterEventListeners();
}

void HighScoreState::Update() {
    // �߷�״̬�����߼�
}


void HighScoreState::HandleMouseInput(const MouseInputEvent& event) {
    // Handle mouse input for HighScoreState
}

void HighScoreState::HandleKeyboardInput(const KeyboardInputEvent& event) {
    // Handle keyboard input for HighScoreState
}

State* HighScoreState::CreateState() const {
    return new HighScoreState();
}

void HighScoreState::RegisterEventListeners(){}
void HighScoreState::UnregisterEventListeners(){}
>>>>>>> Stashed changes
