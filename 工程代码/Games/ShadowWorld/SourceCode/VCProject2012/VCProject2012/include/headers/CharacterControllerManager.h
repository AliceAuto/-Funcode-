#ifndef CHARACTERCONTROLLERMANAGER_H
#define CHARACTERCONTROLLERMANAGER_H

#include <map>
#include <string>
#include "CharacterController.h"
#include "Setting.h"  // 确保这里包含了 ResourceBag 的定义

/**
 * @class CharacterControllerManager
 * @brief 管理多个 CharacterController 实例的类。
 */
class CharacterControllerManager {
public:
    CharacterControllerManager();  // 构造函数声明
    ~CharacterControllerManager(); // 析构函数声明

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
