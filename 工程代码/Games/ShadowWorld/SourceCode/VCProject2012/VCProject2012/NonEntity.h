#ifndef NONENTITY_H
#define NONENTITY_H
#include"VisiableObject.h"

/*
 * @brief 这是一个 非实体类
 * 继承自obj，一切在游戏中有无物理碰撞的对象都是一个非实体类对象
 *        
 * @author	孙国庆
 * @date 2024-07-29
 */
class NonEntity:public VisibleObject{
	NonEntity();
	virtual ~NonEntity();
		//设置精灵为不开启"发/接"物理碰撞
};



#endif