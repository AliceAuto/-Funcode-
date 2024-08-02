#ifndef DYNAMICENTITY_H
#define DYNAMICENTITY_H
#include"Entity.h"
/*
 * @brief 这是一个 动态实体类
 * 继承自Eitity，一在游戏中 能移动 的实体都是一个动态实体类对象
 *        
 * @author	孙国庆
 * @date 2024-07-29
 */
class DynamicEntity:public Entity{
public:
	DynamicEntity(){};
	~DynamicEntity(){};
	//配置控制器
};

#endif