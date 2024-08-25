#include "StateMachine.h"

//==============================================================
/*
						״̬����ʵ��
*/
//==============================================================
























// ״̬�����캯��
StateMachine::StateMachine() : currentState_(0) {}




// ״̬����������
//============================================
StateMachine::~StateMachine() {
    for (auto it = states_.begin(); it != states_.end(); ++it) {
        delete it->second;	//�����ͷ�ɾ����ϣԪ��
    }
}
//================================================================



// ���״̬��״̬��
//===================================================================
void StateMachine::AddState(const std::string& name, State* state) {
    states_[name] = state;	//����ӳ��
}
//===========================================================================




// ����״̬���� ��ǰ״̬
//===================================================================
void StateMachine::SetCurrentState(const std::string& name) {
    auto it = states_.find(name);//����ͨ�� name �ҵ���״̬
    if (it != states_.end())// [�ҵ���] 
	{
        if (currentState_) //����ǰ��״̬�˳�
	    {
            currentState_->Exit();
        }
        currentState_ = it->second;	//ͨ���ҵ���(��-ֵ) Ϊ��ǰ״̬��ֵ����
        currentStateName_ = name;	//���µ�ǰ״̬�� ����ǩ name
        currentState_->Enter();		//���������õ�״̬
    }
	else // [û�ҵ�]
	{
        
    }
}
//===================================================================================





// ����״̬�� ״̬
//=================================================
void StateMachine::Update(int userChoice) {
    if (currentState_) {
        currentState_->Update(userChoice);	//����	��ǰ״̬�ĸ��½ӿ�
        std::string nextState = currentState_->GetNextState(userChoice);	//(ͨ����ǰ״̬)�����һ��״̬(�ļ�)
        if (!nextState.empty() && nextState != currentStateName_) //����(״̬����)��һ��״̬
		{
            SetCurrentState(nextState);
        }
    }
}
//==========================================================================



//���״̬����ǰ ״̬�ļ�
//=======================================================
std::string StateMachine::GetCurrentStateName() const {
    return currentStateName_;
}
//================================================================================




// ��ȡ״̬�� ��ǰ״̬�����ָ��
//==============================================================
State* StateMachine::GetState(const std::string& name) const {
    auto it = states_.find(name);
    if (it != states_.end()) {
        return it->second;
    }
    return 0;
}
//===================================================================