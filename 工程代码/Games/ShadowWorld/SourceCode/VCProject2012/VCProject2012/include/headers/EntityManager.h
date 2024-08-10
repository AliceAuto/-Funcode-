#ifndef CHARACTERCONTROLLERMANAGER_H
#define CHARACTERCONTROLLERMANAGER_H

#include <string>
#include <unordered_map>
#include "Entity.h"

class EntityManager {
public:
    EntityManager();
    ~EntityManager();

    // �����µ� CharacterController ʵ��
    std::string CreateEntity(const std::string& type, float initialX, float initialY, ResourceBag* resourceBagPtr);

    // ��ȡָ�� ID �� CharacterController
    Entity * GetEntity(const std::string& id);

    // ɾ��ָ�� ID �� CharacterController
    void DeleteEntity(const std::string& id);

    // �������п��������������º���Ⱦ
    void UpdateAllEntities();

private:
    // ���ݿ��������ʹ����µĿ�����ʵ��
    Entity * CreateEntityInstance(const std::string& type, float initialX, float initialY, ResourceBag* resourceBagPtr);

    std::unordered_map<std::string, Entity *> entities;
    int nextID;
};

#endif // CHARACTERCONTROLLERMANAGER_H
