#include "States.h"

#include "headers\CGameMain.h"
#include "headers\Button.h"

// MainMenuState ʵ��
MainMenuState::MainMenuState():State()
{		
std::string Button =entityManager->CreateEntity(
	"{\n"
	        "  \"TypeName\"		:			\"Button\"				,\n"
            "  \"posX\"			:			0.0						,\n"
			"  \"posY\"			:			0.0						,\n"
			"  \"resourceBag\"  :			\"StartGameButton\"		,\n"
			"  \"label\"		:			\"��ʼ��Ϸ\"				\n"
	"}"
   );
}
MainMenuState::~MainMenuState() 
{



}

void MainMenuState::RegisterEventListeners() {
	//��ť������
	 LogManager::Log("ע��һ����ť������");
	EventManager::Instance().RegisterListener(EventType::ButtonClick, "MainState_mouse_info" ,
    [this](const Event& event) { this->HandleButtonInput(static_cast<const ButtonClickEvent&>(event)); }
	);



}
void MainMenuState::UnregisterEventListeners(){
	//��ť������
	EventManager::Instance().RemoveListener(EventType::ButtonClick,"MainState_mouse_info");
	LogManager::Log("ע��һ����ť������");



}
void MainMenuState::Enter() {
	
    LogManager::Log("�ѽ������˵�����");
    CSystem::LoadMap("untitled.t2d");
	entityManager->LoadAllEntitys();



	
    RegisterEventListeners();
	

    // ��ȡ�����¼�
   



}





void MainMenuState::Exit() {
    LogManager::Log("���˳����˵�");
	entityManager->breakDownAllEntitys();
    UnregisterEventListeners();
}

void MainMenuState::Update(float fDeltaTime) {
    // ���˵��ĸ����߼�
	
	entityManager->Update();
	 
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
GameState::GameState() :State()
{



std::string player1 =entityManager->CreateEntity(
	"{\n"
	        "  \"TypeName\"		:			\"Player\"				,\n"
            "  \"posX\"			:			0.0						,\n"
			"  \"posY\"			:			0.0						,\n"
			"  \"resourceBag\"  :			\"resources1\"				\n"
	"}"
   );

std::string block1 =entityManager->CreateEntity(
	"{\n"
	        "  \"TypeName\"		:			\"ObstacleObject\"				,\n"
            "  \"posX\"			:			0.0							,\n"
			"  \"posY\"			:			0.0							,\n"
			"  \"resourceBag\"  :			\"block\"						\n"
	"}"
    );//
std::string block2 =entityManager->CreateEntity(
	"{\n"
	        "  \"TypeName\"		:			\"ObstacleObject\"			,\n"
            "  \"posX\"			:			0.0						,\n"
			"  \"posY\"			:			0.0						,\n"
			"  \"resourceBag\"  :			\"block\"					\n"
	"}"
    );
std::string block3 =entityManager->CreateEntity(
	"{\n"
	        "  \"TypeName\"		:			\"ObstacleObject\"			,\n"
            "  \"posX\"			:			0.0						,\n"
			"  \"posY\"			:			0.0						,\n"
			"  \"resourceBag\"  :			\"block\"					\n"
	"}"
    );
std::string block4 =entityManager->CreateEntity(
	"{\n"
	        "  \"TypeName\"		:			\"ObstacleObject\"			,\n"
            "  \"posX\"			:			0.0						,\n"
			"  \"posY\"			:			0.0						,\n"
			"  \"resourceBag\"  :			\"block\"					\n"
	"}"
    );
std::string block5 =entityManager->CreateEntity(
	"{\n"
	        "  \"TypeName\"		:			\"ObstacleObject\"			,\n"
            "  \"posX\"			:			0.0						,\n"
			"  \"posY\"			:			0.0						,\n"
			"  \"resourceBag\"  :			\"block\"					\n"
	"}"
    );
std::string block6 =entityManager->CreateEntity(
	"{\n"
	        "  \"TypeName\"		:			\"ObstacleObject\"			,\n"
            "  \"posX\"			:			0.0						,\n"
			"  \"posY\"			:			0.0						,\n"
			"  \"resourceBag\"  :			\"block\"					\n"
	"}"
    );
std::string block7 =entityManager->CreateEntity(
	"{\n"
	        "  \"TypeName\"		:			\"ObstacleObject\"			,\n"
            "  \"posX\"			:			0.0						,\n"
			"  \"posY\"			:			0.0						,\n"
			"  \"resourceBag\"  :			\"block\"					\n"
	"}"
    );


}
GameState::~GameState()
{
	

}

void GameState::Enter() {
    LogManager::Log("������Ϸ״̬");
    CSystem::LoadMap("gameScene.t2d");
	entityManager->LoadAllEntitys();
	
	


}

void GameState::Exit() {
    LogManager::Log("�˳���Ϸ״̬");
	entityManager->breakDownAllEntitys();
}

void GameState::Update(float fDeltaTime) {
LogManager::Log("TAG");
    // ��Ϸ״̬�����߼�
	entityManager->Update();
	 
}



State* GameState::CreateState() const {
    return new GameState();
}












// SettingsMenuState ʵ��
SettingsMenuState::SettingsMenuState():State() {}
SettingsMenuState::~SettingsMenuState() {}

void SettingsMenuState::Enter() {
    LogManager::Log("�������ò˵�");
    CSystem::LoadMap("settingsMenu.t2d");
    
}

void SettingsMenuState::Exit() {
    LogManager::Log("�˳����ò˵�");
    entityManager->breakDownAllEntitys();
}

void SettingsMenuState::Update(float fDeltaTime) {
    // ���ò˵������߼�
}




State* SettingsMenuState::CreateState() const {
    return new SettingsMenuState();
}












// PauseMenuState ʵ��
PauseMenuState::PauseMenuState():State() {}
PauseMenuState::~PauseMenuState() {}

void PauseMenuState::Enter() {
    LogManager::Log("������ͣ�˵�");
    CSystem::LoadMap("pauseMenu.t2d");

}

void PauseMenuState::Exit() {
    LogManager::Log("�˳���ͣ�˵�");
	entityManager->breakDownAllEntitys();
}

void PauseMenuState::Update(float fDeltaTime) {
    // ��ͣ�˵������߼�
}



State* PauseMenuState::CreateState() const {
    return new PauseMenuState();
}










// ExitMenuState ʵ��
ExitMenuState::ExitMenuState() :State(){}
ExitMenuState::~ExitMenuState() {}

void ExitMenuState::Enter() {
    LogManager::Log("�˳���Ϸ");
    // �˳���Ϸ�������ػ��ʼ��
}

void ExitMenuState::Exit() {
    // �˳���Ϸ״̬����
	entityManager->breakDownAllEntitys();
}

void ExitMenuState::Update(float fDeltaTime) {
    // �˳��˵������߼�
}



State* ExitMenuState::CreateState() const {
    return new ExitMenuState();
}




















// HighScoreState ʵ��
HighScoreState::HighScoreState() :State() {}
HighScoreState::~HighScoreState() {}

void HighScoreState::Enter() {
    LogManager::Log("����߷�״̬");
    CSystem::LoadMap("highScore.t2d");

}

void HighScoreState::Exit() {
    LogManager::Log("�˳��߷�״̬");

}

void HighScoreState::Update(float fDeltaTime) {
    // �߷�״̬�����߼�
}



State* HighScoreState::CreateState() const {
    return new HighScoreState();
}
