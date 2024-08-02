#ifndef STATICENTITY_H
#define STATICENTITY_H
#include"Entity.h"


/*
 * @brief 这是一个 静态实体类
 * 继承自Eitity，一在游戏中 不能 移动的实体都是一个静态实体类对象
 *        
 * @author	孙国庆
 * @date 2024-07-29
 */
class StaticEntity:public Entity{
public:
	StaticEntity(){};
	~StaticEntity(){};
	//不配置控制器
};



#endif