#include "States.h"
#include "headers\Logger.h"
#include "headers\CSystem.h"	//	要用这个里面的loadMap加载新场景

<<<<<<< Updated upstream



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
=======
// MainMenuState 实现
MainMenuState::MainMenuState() 
{ 
	std::string button =m_control_Manager->CreateEntity(
	"{\n"
	        "  \"TypeName\"		:			\"Button\"				,\n"
            "  \"posX\"			:			0.0						,\n"
			"  \"posY\"			:			0.0						,\n"
			"  \"label\"			:		\"开始游戏\"					,\n"
			"  \"resourceBag\"  :			\"StartGameButton\"				\n"
	"}"
   );

}
MainMenuState::~MainMenuState() 
{
	

}

void MainMenuState::RegisterEventListeners() {
	//按钮管理器
	
	EventManager::Instance().RegisterListener(EventType::ButtonClick, 
    [this](const Event& event) { this->HandleButtonInput(static_cast<const ButtonClickEvent&>(event)); }
	);
}
void MainMenuState::UnregisterEventListeners(){
	//按钮管理器
	
	EventManager::Instance().RemoveListener(EventType::ButtonClick, [this](const Event& event) {
    const ButtonClickEvent& buttonEvent = static_cast<const ButtonClickEvent&>(event);
    this->HandleButtonInput(buttonEvent);
    });

}
void MainMenuState::Enter() {
	
    LogManager::Log("已进入主菜单界面");
    CSystem::LoadMap("untitled.t2d");
    RegisterEventListeners();
	

    // 获取并绑定事件
   

>>>>>>> Stashed changes

}

void MainMenuState::Exit()
{
    LogManager::Log("已退出主菜单");
	//播放在大脑的出场动画
	
}

<<<<<<< Updated upstream
void MainMenuState::Update(int userChoice) {



=======
void MainMenuState::Update() {
    // 主菜单的更新逻辑
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











// 游戏状态实现
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
    LogManager::Log("进入游戏状态");
    CSystem::LoadMap("gameScene.t2d");
    RegisterEventListeners();// 监听注册
	
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
    LogManager::Log("退出游戏状态");
	
    UnregisterEventListeners();// 注销监听器
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

void SettingsMenuState::RegisterEventListeners(){}
void SettingsMenuState::UnregisterEventListeners(){}








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




<<<<<<< Updated upstream
=======
void PauseMenuState::RegisterEventListeners(){}
void PauseMenuState::UnregisterEventListeners(){}
>>>>>>> Stashed changes










<<<<<<< Updated upstream
// 退出菜单状态实现
//=======================================
=======



// ExitMenuState 实现
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
    // 退出菜单更新逻辑
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








// HighScoreState 实现
HighScoreState::HighScoreState() {}
HighScoreState::~HighScoreState() {}

void HighScoreState::Enter() {
    LogManager::Log("进入高分状态");
    CSystem::LoadMap("highScore.t2d");
    RegisterEventListeners();
}

void HighScoreState::Exit() {
    LogManager::Log("退出高分状态");
    UnregisterEventListeners();
}

void HighScoreState::Update() {
    // 高分状态更新逻辑
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
