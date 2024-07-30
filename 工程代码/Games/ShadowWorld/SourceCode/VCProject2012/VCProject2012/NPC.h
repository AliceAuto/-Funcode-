#ifndef NPC_H
#define NPC_H
#include"DynamicEntity.h"
/*
 * @brief 这是一个 NPC类
 * 继承自 DynamicEntity，一在游戏中 有程序控制的 动态实体类都是一个NPC类
 *        
 * @author	孙国庆
 * @date 2024-07-29
 */
class NPC:public DynamicEntity{
	NPC();
	virtual ~NPC();
	//智能系统接入

};



#endif