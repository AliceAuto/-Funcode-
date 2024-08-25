#include "States.h"
#include "headers\CGameMain.h"
#include "headers\Button.h"

// MainMenuState ʵ��
MainMenuState::MainMenuState() 
{ 
m_control_Manager = new EntityManager;
 buttonManager = new ButtonManager;
}
MainMenuState::~MainMenuState() 
{
		delete m_control_Manager;
		delete buttonManager;
}

void MainMenuState::RegisterEventListeners() {
	//��ť������
	eventManager.RegisterListener(EventType::ButtonClick, 
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
   

	Button * bptr  = new Button ("��ʼ��Ϸ");
	bptr->resourceBagPtr->LoadFromJson("StartGameButton");
	buttonManager->AddButton(bptr);


}





void MainMenuState::Exit() {
    LogManager::Log("���˳����˵�");

    UnregisterEventListeners();
}

void MainMenuState::Update() {
    // ���˵��ĸ����߼�
	m_control_Manager->UpdateAllEntities();
	buttonManager->Update();
}


void MainMenuState::HandleButtonInput(const ButtonClickEvent& event){
	LogManager::Log("���");
	LogManager::Log("Sender: "+event.GetButtonSender());
    std::string sender = event.GetButtonSender() ;
	if (sender == "��ʼ��Ϸ"){
			g_GameMain.stateMachine->ToNextState("Game");
	}
       
        
}

State* MainMenuState::CreateState() const {
    return new MainMenuState();
}














// GameState ʵ��
GameState::GameState() 
{
 LogManager::Log("=========================================================");
m_control_Manager = new EntityManager;


}
GameState::~GameState()
{
		
delete m_control_Manager;
}

void GameState::Enter() {
    LogManager::Log("������Ϸ״̬");
    CSystem::LoadMap("gameScene.t2d");
    RegisterEventListeners();
	
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
	        "  \"TypeName\"		:			\"Obstacle\"				,\n"
            "  \"posX\"			:			0.0							,\n"
			"  \"posY\"			:			0.0							,\n"
			"  \"resourceBag\"  :			\"block\"						\n"
	"}"
    );//
std::string block2 =m_control_Manager->CreateEntity(
	"{\n"
	        "  \"TypeName\"		:			\"Obstacle\"			,\n"
            "  \"posX\"			:			0.0						,\n"
			"  \"posY\"			:			0.0						,\n"
			"  \"resourceBag\"  :			\"block\"					\n"
	"}"
    );
std::string block3 =m_control_Manager->CreateEntity(
	"{\n"
	        "  \"TypeName\"		:			\"Obstacle\"			,\n"
            "  \"posX\"			:			0.0						,\n"
			"  \"posY\"			:			0.0						,\n"
			"  \"resourceBag\"  :			\"block\"					\n"
	"}"
    );
std::string block4 =m_control_Manager->CreateEntity(
	"{\n"
	        "  \"TypeName\"		:			\"Obstacle\"			,\n"
            "  \"posX\"			:			0.0						,\n"
			"  \"posY\"			:			0.0						,\n"
			"  \"resourceBag\"  :			\"block\"					\n"
	"}"
    );
std::string block5 =m_control_Manager->CreateEntity(
	"{\n"
	        "  \"TypeName\"		:			\"Obstacle\"			,\n"
            "  \"posX\"			:			0.0						,\n"
			"  \"posY\"			:			0.0						,\n"
			"  \"resourceBag\"  :			\"block\"					\n"
	"}"
    );
std::string block6 =m_control_Manager->CreateEntity(
	"{\n"
	        "  \"TypeName\"		:			\"Obstacle\"			,\n"
            "  \"posX\"			:			0.0						,\n"
			"  \"posY\"			:			0.0						,\n"
			"  \"resourceBag\"  :			\"block\"					\n"
	"}"
    );
std::string block7 =m_control_Manager->CreateEntity(
	"{\n"
	        "  \"TypeName\"		:			\"Obstacle\"			,\n"
            "  \"posX\"			:			0.0						,\n"
			"  \"posY\"			:			0.0						,\n"
			"  \"resourceBag\"  :			\"block\"					\n"
	"}"
    );



}

void GameState::Exit() {
    LogManager::Log("�˳���Ϸ״̬");
	
    UnregisterEventListeners();
}

void GameState::Update() {
    // ��Ϸ״̬�����߼�
	m_control_Manager->UpdateAllEntities();

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

void SettingsMenuState::Update() {
    // ���ò˵������߼�
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

void PauseMenuState::Update() {
    // ��ͣ�˵������߼�
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
