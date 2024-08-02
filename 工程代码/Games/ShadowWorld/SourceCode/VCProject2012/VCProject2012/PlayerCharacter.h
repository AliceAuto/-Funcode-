#ifndef PLAYERCHARACTER_H
#define PLAYERCHARACTER_H
#include"DynamicEntity.h"
/*
 * @brief 这是一个 PlayerCharacter类
 * 继承自 DynamicEntity，一在游戏中 有玩家控制的 动态实体类都是一个PlayerCharacter类
 *        
 * @author	孙国庆
 * @date 2024-07-29
 */
class PlayerCharacter:public DynamicEntity{
public:
	PlayerCharacter();
	~PlayerCharacter(){};
	//玩家交互信号接入

};

#endif