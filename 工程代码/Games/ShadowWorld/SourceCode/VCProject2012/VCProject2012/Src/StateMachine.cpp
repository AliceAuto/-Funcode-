#include "StateMachine.h"
State::State()
{
	entityManager = new EntityManager;
}
State::~State()
{
	delete entityManager;
}

// 状态机构造函数
StateMachine::StateMachine() : currentState_(nullptr) {

}

// 状态机析构函数
StateMachine::~StateMachine() {
    
}

// 设置当前状态
void StateMachine::SetCurrentState(const std::string& name) {

    auto it = states_.find(name);
    if (it != states_.end()) {
        if (currentState_) {
            currentState_->Exit();
        }
        currentState_ = it->second.get();
        currentStateName_ = name;
        currentState_->Enter();
        LogManager::Log("Current state set to: " + name);
    } else {
        LogManager::Log("State not found: " + name);
    }
}
// 更新状态机
void StateMachine:: ToNextState(const std::string & stateName) {

    if (currentState_) {
        if (stateName != currentStateName_) {
            SetCurrentState(stateName);
        }
    }
	
}
// 查询当前状态名称
std::string StateMachine::GetCurrentStateName() const {
    return currentStateName_;
}

// 添加状态
void StateMachine::AddState(const std::string& name, std::unique_ptr<State> state) {
    // 通过名称添加状态
    states_[name] = std::move(state);
}

// 获取状态对象
State* StateMachine::GetState(const std::string& name) const {
    auto it = states_.find(name);
    if (it != states_.end()) {
		 
        return it->second.get();
    }
    return nullptr;
}

// 刷新当前状态
void StateMachine::Update(float fDeltaTime) {
	

    if (currentState_) {
        currentState_->Update(fDeltaTime);
	}
}
