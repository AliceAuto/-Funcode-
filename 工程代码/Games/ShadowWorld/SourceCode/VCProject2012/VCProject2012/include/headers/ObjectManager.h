#ifndef ObjectMANAGER_H
#define ObjectMANAGER_H

#include <string>
#include <unordered_map>
#include "Object.h"
#include "json/json.h"

//==========================================================================================================
class ObjectManager {
public:
    ObjectManager();
    ~ObjectManager();

    // �����µ� Entity ʵ������������Ψһ��ʶ��
	//json��ȡ�ɱ����
    std::string CreateObject(const std::string& jsonString);

    // ��ȡָ�� ID �� Entity
    Object* GetObject(const std::string& id);

    // ���ݾ������ƻ�ȡ Entity
    Object* GetObjectBySpriteName(const std::string& spriteName);

    // ɾ��ָ�� ID �� Entity
    void DeleteObject(const std::string& id);

    // �������� Entity���������º���Ⱦ
    void Update();
	//��������ʵ��
	void ObjectManager::LoadAllObjects();
	void ObjectManager::breakDownAllObjects();


private:
    // ���ݿ��������ʹ����µĿ�����ʵ��
    Object* CreateObjectInstance(const std::string& type, Json::Value root);

	long long Id_couter;
    // �洢�������Ƶ� Entity ��ӳ��
    std::unordered_map<std::string, Object*> spriteNameToObject;
    // ����Ψһ ID
};
//==========================================================================================================

#endif // ENTITYMANAGER_H
