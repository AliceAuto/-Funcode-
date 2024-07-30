#ifndef NONINTERACTIVEBLOCK_H
#define NONINTERACTIVEBLOCK_H
#include"StaticEntity.h"
/*
 * @brief 这是一个 NonInteractiveBlock类
 * 继承自 StaticEntity，不可以交互的静态实体类都是一个 NonInteractiveBlock 类
 *        
 * @author	孙国庆
 * @date 2024-07-29
 */
class NonInteractiveBlock:public StaticEntity{
	NonInteractiveBlock();
	virtual ~NonInteractiveBlock();

};
#endif