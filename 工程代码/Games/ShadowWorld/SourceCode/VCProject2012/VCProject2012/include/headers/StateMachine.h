#ifndef STATEMACHINE_H
#define STATEMACHINE_H
//=================================================
/*
			此文件声明了:状态接口、状态机
*/
//==================================================




#include <iostream>
#include <map>
#include <string>







// 状态接口
class State {
public:
	// [  外部接口  ]
    virtual ~State() {}//									【供状态机调用】
    virtual void Enter() = 0;								//状态入口			
    virtual void Exit() = 0;								//状态出口		
    virtual void Update(int userChoice) = 0;				//全权负责	此状态下的特有逻辑
    virtual std::string GetNextState(int userChoice) = 0;	//获得状态转移目标  

private:			
	//[  内部接口 ]
    // 工厂方法，创建状态实例
    static State* CreateState() { return 0; }				
};
















// 状态机类
class StateMachine {
public:
    StateMachine();
    ~StateMachine();

	// [  外部接口  ]
    void AddState(const std::string& name, State* state);	//		【在状态机】添加状态 (申请状态对象[键-值])
    void Update(int userChoice);							//		更新【状态机】当前状态

	//	[ (调试) 外部接口  ]
	void SetCurrentState(const std::string& name);			//		设置【状态机】当前的状态
    std::string GetCurrentStateName() const;				//		查询获得 当前状态【的键】
    State* GetState(const std::string& name) const;			//		快速查询 状态对象


private:
	//[  内部接口  ]
    std::map<std::string, State*> states_;		//		<String,State *> 存储所有状态
    State* currentState_;						//		当前状态指针
    std::string currentStateName_;				//		当前状态对象 【的键】
};

#endif // STATEMACHINE_H
