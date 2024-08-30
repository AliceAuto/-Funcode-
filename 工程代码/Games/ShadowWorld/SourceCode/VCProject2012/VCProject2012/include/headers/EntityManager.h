#ifndef ENTITYMANAGER_H
#define ENTITYMANAGER_H

#include <string>
#include <unordered_map>
#include "Entity.h"
#include "json/json.h"

//==========================================================================================================
class EntityManager {
public:
    EntityManager();
    ~EntityManager();

    // �����µ� Entity ʵ������������Ψһ��ʶ��
	//json��ȡ�ɱ����
    std::string CreateEntity(const std::string& jsonString);

    // ��ȡָ�� ID �� Entity
    Entity* GetEntity(const std::string& id);

    // ���ݾ������ƻ�ȡ Entity
    Entity* GetEntityBySpriteName(const std::string& spriteName);

    // ɾ��ָ�� ID �� Entity
    void DeleteEntity(const std::string& id);

    // �������� Entity���������º���Ⱦ
    void Update();
	//��������ʵ��
	void EntityManager::LoadAllEntitys();
	void EntityManager::breakDownAllEntitys();


private:
    // ���ݿ��������ʹ����µĿ�����ʵ��
    Entity* CreateEntityInstance(const std::string& type, Json::Value root);

	long long Id_couter;
    // �洢�������Ƶ� Entity ��ӳ��
    std::unordered_map<std::string, Entity*> spriteNameToEntity;
    // ����Ψһ ID
};
//==========================================================================================================

#endif // ENTITYMANAGER_H
