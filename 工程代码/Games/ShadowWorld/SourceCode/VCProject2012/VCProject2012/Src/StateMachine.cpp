#include "StateMachine.h"
State::State()
{
	entityManager = new EntityManager;
}
State::~State()
{
	delete entityManager;
}

// ״̬�����캯��
StateMachine::StateMachine() : currentState_(nullptr) {

}

// ״̬����������
StateMachine::~StateMachine() {
    
}

// ���õ�ǰ״̬
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
// ����״̬��
void StateMachine:: ToNextState(const std::string & stateName) {

    if (currentState_) {
        if (stateName != currentStateName_) {
            SetCurrentState(stateName);
        }
    }
	
}
// ��ѯ��ǰ״̬����
std::string StateMachine::GetCurrentStateName() const {
    return currentStateName_;
}

// ���״̬
void StateMachine::AddState(const std::string& name, std::unique_ptr<State> state) {
    // ͨ���������״̬
    states_[name] = std::move(state);
}

// ��ȡ״̬����
State* StateMachine::GetState(const std::string& name) const {
    auto it = states_.find(name);
    if (it != states_.end()) {
		 
        return it->second.get();
    }
    return nullptr;
}

// ˢ�µ�ǰ״̬
void StateMachine::Update(float fDeltaTime) {
	

    if (currentState_) {
        currentState_->Update(fDeltaTime);
	}
}
