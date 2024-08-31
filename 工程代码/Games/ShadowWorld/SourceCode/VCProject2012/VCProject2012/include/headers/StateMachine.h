#ifndef STATEMACHINE_H
#define STATEMACHINE_H

#include <iostream>
#include <map>
#include <memory>
#include <string>
#include "EventDrivenSystem.h"
#include "Logger.h"
#include "ObjectManager.h"














//=========================================================================
// 状态接口
class State {
public:
	State();
	virtual ~State();
    // 状态管理接口
                 // 状态出口
    void update(float fDeltaTime);
	void enter();
	void exit();
	
    // 事件处理接口
	// 注册和取消事件监听
    virtual void RegisterEventListeners() {};
    virtual void UnregisterEventListeners() {};
	ObjectManager * objectManager;
protected:
    // 工厂方法，创建状态实例
    virtual State* CreateState() const = 0;
private:
	virtual void Update(float fDeltaTime) =0;
	virtual void Enter() = 0;               // 状态入口
    virtual void Exit() = 0;   
};
//=========================================================================















//======================================================================================
// 状态机类
class StateMachine {
public:
    StateMachine();
    ~StateMachine(); // 显示声明析构函数
    // 添加状态，直接传递状态对象
    void AddState(const std::string& name, std::unique_ptr<State> state);
    void ToNextState(const std::string & stateName);  // 更新状态机当前状态
    // (调试) 外部接口
    void SetCurrentState(const std::string& name); // 设置状态机当前的状态
    std::string GetCurrentStateName() const;       // 查询当前状态的名称
    State* GetState(const std::string& name) const; // 获取状态对象指针
    void Update(float fDeltaTime);
    std::map<std::string, std::unique_ptr<State>> states_; // 存储所有状态
    State* currentState_;  // 当前状态指针
    std::string currentStateName_; // 当前状态名称
};
//======================================================================================





#endif // STATEMACHINE_H
