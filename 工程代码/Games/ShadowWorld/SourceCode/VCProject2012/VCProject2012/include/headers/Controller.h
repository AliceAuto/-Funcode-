#ifndef CONTROLLER_H
#define CONTROLLER_H

#include <string>
#include "CSprite.h"
#include "CSystem.h"
#include "Setting.h"
#include "EventDrivenSystem.h"

class PlayerController {
public:
    PlayerController(float initialX, float initialY);
    ~PlayerController(); // 添加析构函数
	

	//					为外部系统提供的接口
	//===================================================
    void ProcessInput(const Event& event); // 处理玩家输入
    void Update(); // 更新角色状态
    void Render(); // 渲染角色
	//=====================================================
private:

	//				与引擎的接口
	//============================================
    CAnimateSprite* spritePtr;		//动画精灵指针
	CSound * soundSpritePtr;		//音效精灵指针
	//============================================




	//				系统方法
	//==========================================
	void PlayerController::UpdateState();//对基本属性更新
    void PlayerController::UpdateAnimation(); // 渲染动画
	void PlayerController::UpdateSound();	//渲染音效
	//============================================


	//				基础属性
	//==============================================
	// [世界属性]
    float posX, posY; // 角色当前位置
	float velocityX, velocityY; // 角色当前的速度分量

	// [人物属性]

	
	//枚举体
	static enum facings
	{
		up,
		down,
		left,
		right
	};
	float facing;	//朝向
    
	//================================================
};

extern PlayerController player;	//声明在这里,定义放CPP

#endif // CONTROLLER_H
