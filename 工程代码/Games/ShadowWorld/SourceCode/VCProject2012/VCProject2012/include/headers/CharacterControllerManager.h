#ifndef CHARACTERCONTROLLERMANAGER_H
#define CHARACTERCONTROLLERMANAGER_H

#include <map>
#include <string>
#include "CharacterController.h"
#include "Setting.h"  // ȷ����������� ResourceBag �Ķ���

/**
 * @class CharacterControllerManager
 * @brief ������ CharacterController ʵ�����ࡣ
 */
class CharacterControllerManager {
public:
    CharacterControllerManager();  // ���캯������
    ~CharacterControllerManager(); // ������������

    std::string CreateCharacterController(const std::string& type, float initialX, float initialY, const ResourceBag * resourceBagPtr);
    CharacterController* GetCharacterController(const std::string& id);
    void DeleteCharacterController(const std::string& id);
    void UpdateAllControllers();
    void RenderAllControllers();

private:
    CharacterController* CreateControllerInstance(const std::string& type, float initialX, float initialY, const ResourceBag * resourceBagPtr);

    std::map<std::string, CharacterController*> controllers;
    int nextID;
};

#endif // CHARACTERCONTROLLERMANAGER_H
