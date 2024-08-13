#include "States.h"
#include "headers\CGameMain.h"
#include "headers\Button.h"

// MainMenuState ʵ��
MainMenuState::MainMenuState() { 
	
m_control_Manager = new EntityManager;
 buttonManager = new ButtonManager;}
MainMenuState::~MainMenuState() {
}

void MainMenuState::Enter() {
    LogManager::Log("�ѽ������˵�����");
    CSystem::LoadMap("untitled.t2d");
    RegisterEventListeners();
	
    std::string playerID =m_control_Manager->CreateEntity(
        "Player",
        0.0f,
        0.0f
    );

    LogManager::Log(playerID);

    // ��ȡ�����¼�
    Entity* entity = m_control_Manager->GetEntity(playerID);
    PlayerController* controller = dynamic_cast<PlayerController*>(entity);
	if(controller)controller->resourceBagPtr->LoadFromJson("resources1");

    if (controller) {
        eventManager.RegisterListener(EventType::KeyboardInput, std::bind(&PlayerController::ProcessInput, controller, std::placeholders::_1));

        LogManager::Log("���̼����󶨳ɹ�");
    } else {
        LogManager::Log("���̼�����ʧ��");
    }
	Button * bptr  = new Button ("��ʼ��Ϸ");
	bptr->resourceBagPtr->LoadFromJson("StartGameButton");
	buttonManager->AddButton(bptr);
	




}
void MainMenuState::Refresh(){

	m_control_Manager->UpdateAllEntities();
	buttonManager->Update();

}
void MainMenuState::Exit() {
    LogManager::Log("���˳����˵�");
	delete m_control_Manager;
delete buttonManager;
    UnregisterEventListeners();
}

void MainMenuState::Update(int userChoice) {
    // ���˵��ĸ����߼�
	
}

std::string MainMenuState::GetNextState(int userChoice) {
    switch (userChoice) {
        case 1: return "Game";
        case 2: return "Settings";
        case 3: return "Exit";
        case 4: return "PauseMenu";
        default: return "";
    }
}

void MainMenuState::HandleMouseInput(const MouseInputEvent& event) {
	LogManager::Log("���");
    if (event.IsLeftPressed()) {

        std::string sender = "exampleButton"; // Retrieve button sender from event
        if (sender == "��ʼ��Ϸ") {
            std::string nextState = GetNextState(1);
            // Logic to transition to the next state
        }
    }
}

void MainMenuState::HandleKeyboardInput(const KeyboardInputEvent& event) {
    // Handle keyboard input for MainMenuState
}

State* MainMenuState::CreateState() const {
    return new MainMenuState();
}

// GameState ʵ��
GameState::GameState() {}
GameState::~GameState() {}

void GameState::Enter() {
    LogManager::Log("������Ϸ״̬");
    CSystem::LoadMap("gameScene.t2d");
    RegisterEventListeners();
}

void GameState::Exit() {
    LogManager::Log("�˳���Ϸ״̬");
    UnregisterEventListeners();
}

void GameState::Update(int userChoice) {
    // ��Ϸ״̬�����߼�
}

std::string GameState::GetNextState(int userChoice) {
    return (userChoice == 0) ? "MainMenu" : "";
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

// SettingsMenuState ʵ��
SettingsMenuState::SettingsMenuState() {}
SettingsMenuState::~SettingsMenuState() {}

void SettingsMenuState::Enter() {
    LogManager::Log("�������ò˵�");
    LogManager::Log("�������ò˵�");
    CSystem::LoadMap("settingsMenu.t2d");
    RegisterEventListeners();
}

void SettingsMenuState::Exit() {
    LogManager::Log("�˳����ò˵�");
    UnregisterEventListeners();
}

void SettingsMenuState::Update(int userChoice) {
    // ���ò˵������߼�
}

std::string SettingsMenuState::GetNextState(int userChoice) {
    return (userChoice == 1) ? "MainMenu" : "";
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

// PauseMenuState ʵ��
PauseMenuState::PauseMenuState() {}
PauseMenuState::~PauseMenuState() {}

void PauseMenuState::Enter() {
    LogManager::Log("������ͣ�˵�");
    CSystem::LoadMap("pauseMenu.t2d");
    RegisterEventListeners();
}

void PauseMenuState::Exit() {
    LogManager::Log("�˳���ͣ�˵�");
    UnregisterEventListeners();
}

void PauseMenuState::Update(int userChoice) {
    // ��ͣ�˵������߼�
}

std::string PauseMenuState::GetNextState(int userChoice) {
    switch (userChoice) {
        case 1: return "MainMenu";
        case 2: return "Exit";
        default: return "";
    }
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

// ExitMenuState ʵ��
ExitMenuState::ExitMenuState() {}
ExitMenuState::~ExitMenuState() {}

void ExitMenuState::Enter() {
    LogManager::Log("�˳���Ϸ");
    // �˳���Ϸ�������ػ��ʼ��
}

void ExitMenuState::Exit() {
    // �˳���Ϸ״̬����
}

void ExitMenuState::Update(int userChoice) {
    // �˳��˵������߼�
}

std::string ExitMenuState::GetNextState(int userChoice) {
    return "";
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

void HighScoreState::Update(int userChoice) {
    // �߷�״̬�����߼�
}

std::string HighScoreState::GetNextState(int userChoice) {
    return (userChoice == 1) ? "MainMenu" : "";
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
