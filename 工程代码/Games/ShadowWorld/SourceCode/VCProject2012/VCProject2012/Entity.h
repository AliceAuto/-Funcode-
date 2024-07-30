#ifndef ENTITY_H
#define ENTITY_H
#include "VisiableObject.h"
/*
 * @brief 这是一个 实体类
 * 继承自VisibleObject，一切在游戏中有物理碰撞的对象都是一个实体类对象
 *        
 * @author	孙国庆
 * @date 2024-07-29
 */
class Entity:public VisibleObject{
	Entity();
	virtual ~Entity();
			//设置精灵为开启"发/接"物理碰撞
};


#endif