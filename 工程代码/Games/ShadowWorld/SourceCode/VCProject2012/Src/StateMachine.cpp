#include "StateMachine.h"

//==============================================================
/*
						状态机的实现
*/
//==============================================================
























// 状态机构造函数
StateMachine::StateMachine() : currentState_(0) {}




// 状态机析构函数
//============================================
StateMachine::~StateMachine() {
    for (auto it = states_.begin(); it != states_.end(); ++it) {
        delete it->second;	//迭代释放删除哈希元素
    }
}
//================================================================



// 添加状态到状态机
//===================================================================
void StateMachine::AddState(const std::string& name, State* state) {
    states_[name] = state;	//创建映射
}
//===========================================================================




// 设置状态机的 当前状态
//===================================================================
void StateMachine::SetCurrentState(const std::string& name) {
    auto it = states_.find(name);//尝试通过 name 找到其状态
    if (it != states_.end())// [找到了] 
	{
        if (currentState_) //将当前的状态退出
	    {
            currentState_->Exit();
        }
        currentState_ = it->second;	//通过找到的(键-值) 为当前状态赋值更新
        currentStateName_ = name;	//更新当前状态的 键标签 name
        currentState_->Enter();		//进入新设置的状态
    }
	else // [没找到]
	{
        
    }
}
//===================================================================================





// 更新状态机 状态
//=================================================
void StateMachine::Update(int userChoice) {
    if (currentState_) {
        currentState_->Update(userChoice);	//调用	当前状态的更新接口
        std::string nextState = currentState_->GetNextState(userChoice);	//(通过当前状态)获得下一个状态(的键)
        if (!nextState.empty() && nextState != currentStateName_) //设置(状态机的)下一个状态
		{
            SetCurrentState(nextState);
        }
    }
}
//==========================================================================



//获得状态机当前 状态的键
//=======================================================
std::string StateMachine::GetCurrentStateName() const {
    return currentStateName_;
}
//================================================================================




// 获取状态机 当前状态对象的指针
//==============================================================
State* StateMachine::GetState(const std::string& name) const {
    auto it = states_.find(name);
    if (it != states_.end()) {
        return it->second;
    }
    return 0;
}
//===================================================================