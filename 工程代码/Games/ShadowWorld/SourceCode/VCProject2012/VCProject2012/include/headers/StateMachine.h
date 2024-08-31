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
// ״̬�ӿ�
class State {
public:
	State();
	virtual ~State();
    // ״̬����ӿ�
                 // ״̬����
    void update(float fDeltaTime);
	void enter();
	void exit();
	
    // �¼�����ӿ�
	// ע���ȡ���¼�����
    virtual void RegisterEventListeners() {};
    virtual void UnregisterEventListeners() {};
	ObjectManager * objectManager;
protected:
    // ��������������״̬ʵ��
    virtual State* CreateState() const = 0;
private:
	virtual void Update(float fDeltaTime) =0;
	virtual void Enter() = 0;               // ״̬���
    virtual void Exit() = 0;   
};
//=========================================================================















//======================================================================================
// ״̬����
class StateMachine {
public:
    StateMachine();
    ~StateMachine(); // ��ʾ������������
    // ���״̬��ֱ�Ӵ���״̬����
    void AddState(const std::string& name, std::unique_ptr<State> state);
    void ToNextState(const std::string & stateName);  // ����״̬����ǰ״̬
    // (����) �ⲿ�ӿ�
    void SetCurrentState(const std::string& name); // ����״̬����ǰ��״̬
    std::string GetCurrentStateName() const;       // ��ѯ��ǰ״̬������
    State* GetState(const std::string& name) const; // ��ȡ״̬����ָ��
    void Update(float fDeltaTime);
    std::map<std::string, std::unique_ptr<State>> states_; // �洢����״̬
    State* currentState_;  // ��ǰ״ָ̬��
    std::string currentStateName_; // ��ǰ״̬����
};
//======================================================================================





#endif // STATEMACHINE_H
