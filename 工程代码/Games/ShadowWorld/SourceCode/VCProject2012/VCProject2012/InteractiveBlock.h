#ifndef INTERACTIVEBLOCK_H
#define INTERACTIVEBLOCK_H
#include"StaticEntity.h"
/*
 * @brief 这是一个 InteractiveBlock类
 * 继承自 StaticEntity，可以交互的静态实体类都是一个 InteractiveBlock 类
 *        
 * @author	孙国庆
 * @date 2024-07-29
 */
class InteractiveBlock:public StaticEntity{
	InteractiveBlock();
	virtual ~InteractiveBlock();

};


#endif 