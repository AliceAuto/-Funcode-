#include "States.h"

#include "headers\CGameMain.h"
#include "headers\Button.h"

// MainMenuState 实现
MainMenuState::MainMenuState():State()
{		
std::string Button =entityManager->CreateEntity(
	"{\n"
	        "  \"TypeName\"		:			\"Button\"				,\n"
            "  \"posX\"			:			0.0						,\n"
			"  \"posY\"			:			0.0						,\n"
			"  \"resourceBag\"  :			\"StartGameButton\"		,\n"
			"  \"label\"		:			\"开始游戏\"				\n"
	"}"
   );
}
MainMenuState::~MainMenuState() 
{



}

void MainMenuState::RegisterEventListeners() {
	//按钮管理器
	 LogManager::Log("注册一个按钮监听器");
	EventManager::Instance().RegisterListener(EventType::ButtonClick, "MainState_mouse_info" ,
    [this](const Event& event) { this->HandleButtonInput(static_cast<const ButtonClickEvent&>(event)); }
	);



}
void MainMenuState::UnregisterEventListeners(){
	//按钮管理器
	EventManager::Instance().RemoveListener(EventType::ButtonClick,"MainState_mouse_info");
	LogManager::Log("注销一个按钮监听器");



}
void MainMenuState::Enter() {
	
    LogManager::Log("已进入主菜单界面");
    CSystem::LoadMap("untitled.t2d");
	entityManager->LoadAllEntitys();



	
    RegisterEventListeners();
	

    // 获取并绑定事件
   



}





void MainMenuState::Exit() {
    LogManager::Log("已退出主菜单");
	entityManager->breakDownAllEntitys();
    UnregisterEventListeners();
}

void MainMenuState::Update(float fDeltaTime) {
    // 主菜单的更新逻辑
	
	entityManager->Update();
	 
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
    LogManager::Log("进入游戏状态");
    CSystem::LoadMap("gameScene.t2d");
	entityManager->LoadAllEntitys();
	
	


}

void GameState::Exit() {
    LogManager::Log("退出游戏状态");
	entityManager->breakDownAllEntitys();
}

void GameState::Update(float fDeltaTime) {
LogManager::Log("TAG");
    // 游戏状态更新逻辑
	entityManager->Update();
	 
}



State* GameState::CreateState() const {
    return new GameState();
}












// SettingsMenuState 实现
SettingsMenuState::SettingsMenuState():State() {}
SettingsMenuState::~SettingsMenuState() {}

void SettingsMenuState::Enter() {
    LogManager::Log("进入设置菜单");
    CSystem::LoadMap("settingsMenu.t2d");
    
}

void SettingsMenuState::Exit() {
    LogManager::Log("退出设置菜单");
    entityManager->breakDownAllEntitys();
}

void SettingsMenuState::Update(float fDeltaTime) {
    // 设置菜单更新逻辑
}




State* SettingsMenuState::CreateState() const {
    return new SettingsMenuState();
}












// PauseMenuState 实现
PauseMenuState::PauseMenuState():State() {}
PauseMenuState::~PauseMenuState() {}

void PauseMenuState::Enter() {
    LogManager::Log("进入暂停菜单");
    CSystem::LoadMap("pauseMenu.t2d");

}

void PauseMenuState::Exit() {
    LogManager::Log("退出暂停菜单");
	entityManager->breakDownAllEntitys();
}

void PauseMenuState::Update(float fDeltaTime) {
    // 暂停菜单更新逻辑
}



State* PauseMenuState::CreateState() const {
    return new PauseMenuState();
}










// ExitMenuState 实现
ExitMenuState::ExitMenuState() :State(){}
ExitMenuState::~ExitMenuState() {}

void ExitMenuState::Enter() {
    LogManager::Log("退出游戏");
    // 退出游戏场景加载或初始化
}

void ExitMenuState::Exit() {
    // 退出游戏状态清理
	entityManager->breakDownAllEntitys();
}

void ExitMenuState::Update(float fDeltaTime) {
    // 退出菜单更新逻辑
}



State* ExitMenuState::CreateState() const {
    return new ExitMenuState();
}




















// HighScoreState 实现
HighScoreState::HighScoreState() :State() {}
HighScoreState::~HighScoreState() {}

void HighScoreState::Enter() {
    LogManager::Log("进入高分状态");
    CSystem::LoadMap("highScore.t2d");

}

void HighScoreState::Exit() {
    LogManager::Log("退出高分状态");

}

void HighScoreState::Update(float fDeltaTime) {
    // 高分状态更新逻辑
}



State* HighScoreState::CreateState() const {
    return new HighScoreState();
}
