#ifndef ENTITY_H
#define ENTITY_H
#include "VisiableObject.h"
/*
 * @brief ����һ�� ʵ����
 * �̳���VisibleObject��һ������Ϸ����������ײ�Ķ�����һ��ʵ�������
 *        
 * @author	�����
 * @date 2024-07-29
 */
class Entity:public VisibleObject{
	Entity();
	virtual ~Entity();
			//���þ���Ϊ����"��/��"������ײ
};


#endif