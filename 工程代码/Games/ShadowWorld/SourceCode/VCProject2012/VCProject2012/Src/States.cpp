#include "States.h"
#include "headers\CGameMain.h"
#include "headers\Button.h"

// MainMenuState 实现
MainMenuState::MainMenuState() { 
	
m_control_Manager = new EntityManager;
 buttonManager = new ButtonManager;}
MainMenuState::~MainMenuState() {
		delete m_control_Manager;
delete buttonManager;
}

void MainMenuState::RegisterEventListeners() {
	eventManager.RegisterListener(EventType::ButtonClick, 
        [this](const Event& event) { this->HandleButtonInput(static_cast<const ButtonClickEvent&>(event)); }
	);
}
void MainMenuState::UnregisterEventListeners(){
 EventManager::Instance().RemoveListener(EventType::ButtonClick, [this](const Event& event) {
        const ButtonClickEvent& buttonEvent = static_cast<const ButtonClickEvent&>(event);
        this->HandleButtonInput(buttonEvent);
    });
}
void MainMenuState::Enter() {
	
    LogManager::Log("已进入主菜单界面");
    CSystem::LoadMap("untitled.t2d");
    RegisterEventListeners();
	
    std::string playerID =m_control_Manager->CreateEntity(
        "Player",
        0.0f,
        0.0f
    );

    LogManager::Log(playerID);

    // 获取并绑定事件
    Entity* entity = m_control_Manager->GetEntity(playerID);
    PlayerController* controller = dynamic_cast<PlayerController*>(entity);
	controller->Init("resources1");

	Button * bptr  = new Button ("开始游戏");
	bptr->resourceBagPtr->LoadFromJson("StartGameButton");
	buttonManager->AddButton(bptr);
}





void MainMenuState::Exit() {
    LogManager::Log("已退出主菜单");

    UnregisterEventListeners();
}

void MainMenuState::Update() {
    // 主菜单的更新逻辑
	m_control_Manager->UpdateAllEntities();
	buttonManager->Update();
}


void MainMenuState::HandleButtonInput(const ButtonClickEvent& event){
	LogManager::Log("鼠标");
	LogManager::Log("Sender: "+event.GetButtonSender());
    std::string sender = event.GetButtonSender() ;
	if (sender == "开始游戏"){
			g_GameMain.stateMachine->ToNextState("Game");
	}
       
        
}

State* MainMenuState::CreateState() const {
    return new MainMenuState();
}

// GameState 实现
GameState::GameState() {}
GameState::~GameState() {}

void GameState::Enter() {
    LogManager::Log("进入游戏状态");
    CSystem::LoadMap("gameScene.t2d");
    RegisterEventListeners();
}

void GameState::Exit() {
    LogManager::Log("退出游戏状态");
    UnregisterEventListeners();
}

void GameState::Update() {
    // 游戏状态更新逻辑
}


void GameState::HandleMouseInput(const MouseInputEvent& event) {
    // Handle mouse input for GameState
}

void GameState::HandleKeyboardInput(const KeyboardInputEvent& event) {
    // Handle keyboard input for GameState
}

State* GameState::CreateState() const {
    return new GameState();
}

// SettingsMenuState 实现
SettingsMenuState::SettingsMenuState() {}
SettingsMenuState::~SettingsMenuState() {}

void SettingsMenuState::Enter() {
    LogManager::Log("进入设置菜单");
    LogManager::Log("进入设置菜单");
    CSystem::LoadMap("settingsMenu.t2d");
    RegisterEventListeners();
}

void SettingsMenuState::Exit() {
    LogManager::Log("退出设置菜单");
    UnregisterEventListeners();
}

void SettingsMenuState::Update() {
    // 设置菜单更新逻辑
}



void SettingsMenuState::HandleMouseInput(const MouseInputEvent& event) {
    // Handle mouse input for SettingsMenuState
}

void SettingsMenuState::HandleKeyboardInput(const KeyboardInputEvent& event) {
    // Handle keyboard input for SettingsMenuState
}

State* SettingsMenuState::CreateState() const {
    return new SettingsMenuState();
}

// PauseMenuState 实现
PauseMenuState::PauseMenuState() {}
PauseMenuState::~PauseMenuState() {}

void PauseMenuState::Enter() {
    LogManager::Log("进入暂停菜单");
    CSystem::LoadMap("pauseMenu.t2d");
    RegisterEventListeners();
}

void PauseMenuState::Exit() {
    LogManager::Log("退出暂停菜单");
    UnregisterEventListeners();
}

void PauseMenuState::Update() {
    // 暂停菜单更新逻辑
}


void PauseMenuState::HandleMouseInput(const MouseInputEvent& event) {
    // Handle mouse input for PauseMenuState
}

void PauseMenuState::HandleKeyboardInput(const KeyboardInputEvent& event) {
    // Handle keyboard input for PauseMenuState
}

State* PauseMenuState::CreateState() const {
    return new PauseMenuState();
}

// ExitMenuState 实现
ExitMenuState::ExitMenuState() {}
ExitMenuState::~ExitMenuState() {}

void ExitMenuState::Enter() {
    LogManager::Log("退出游戏");
    // 退出游戏场景加载或初始化
}

void ExitMenuState::Exit() {
    // 退出游戏状态清理
}

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
