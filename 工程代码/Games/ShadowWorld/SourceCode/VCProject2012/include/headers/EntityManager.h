#ifndef CHARACTERCONTROLLERMANAGER_H
#define CHARACTERCONTROLLERMANAGER_H

#include <string>
#include <unordered_map>
#include "Entity.h"
<<<<<<< Updated upstream
=======
#include "json/json.h"
>>>>>>> Stashed changes

class EntityManager {
public:
    // ���캯��
    EntityManager();

    // ��������
    ~EntityManager();

<<<<<<< Updated upstream
    // �����µ� CharacterController ʵ��
    std::string CreateEntity(const std::string& type, float initialX, float initialY, ResourceBag* resourceBagPtr);
=======
    // �����µ� Entity ʵ������������Ψһ��ʶ��
    std::string CreateEntity(const std::string& jsonString);
>>>>>>> Stashed changes

    // ��ȡָ�� ID �� CharacterController
    Entity * GetEntity(const std::string& id);

    // ɾ��ָ�� ID �� CharacterController
    void DeleteEntity(const std::string& id);

    // �������п��������������º���Ⱦ
    void UpdateAllEntities();

    // ע���¼�������
    void RegisterEventListeners();

    // ע���¼�������
    void UnregisterEventListeners();

private:
    // ���ݿ��������ʹ����µĿ�����ʵ��
    Entity * CreateEntityInstance(const std::string& type, float initialX, float initialY, ResourceBag* resourceBagPtr);

<<<<<<< Updated upstream
    std::unordered_map<std::string, Entity *> entities;
    int nextID;
=======
    bool listenersRegistered;  // ����¼��������Ƿ���ע��

    // �洢�������Ƶ� Entity ��ӳ��
    std::unordered_map<std::string, Entity*> spriteNameToEntity;
>>>>>>> Stashed changes
};

#endif // CHARACTERCONTROLLERMANAGER_H
