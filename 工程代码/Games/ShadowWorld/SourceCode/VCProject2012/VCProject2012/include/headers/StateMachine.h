#ifndef STATEMACHINE_H
#define STATEMACHINE_H
//=================================================
/*
			���ļ�������:״̬�ӿڡ�״̬��
*/
//==================================================




#include <iostream>
#include <map>
#include <string>







// ״̬�ӿ�
class State {
public:
	// [  �ⲿ�ӿ�  ]
    virtual ~State() {}//									����״̬�����á�
    virtual void Enter() = 0;								//״̬���			
    virtual void Exit() = 0;								//״̬����		
    virtual void Update(int userChoice) = 0;				//ȫȨ����	��״̬�µ������߼�
    virtual std::string GetNextState(int userChoice) = 0;	//���״̬ת��Ŀ��  

private:			
	//[  �ڲ��ӿ� ]
    // ��������������״̬ʵ��
    static State* CreateState() { return 0; }				
};
















// ״̬����
class StateMachine {
public:
    StateMachine();
    ~StateMachine();

	// [  �ⲿ�ӿ�  ]
    void AddState(const std::string& name, State* state);	//		����״̬�������״̬ (����״̬����[��-ֵ])
    void Update(int userChoice);							//		���¡�״̬������ǰ״̬

	//	[ (����) �ⲿ�ӿ�  ]
	void SetCurrentState(const std::string& name);			//		���á�״̬������ǰ��״̬
    std::string GetCurrentStateName() const;				//		��ѯ��� ��ǰ״̬���ļ���
    State* GetState(const std::string& name) const;			//		���ٲ�ѯ ״̬����


private:
	//[  �ڲ��ӿ�  ]
    std::map<std::string, State*> states_;		//		<String,State *> �洢����״̬
    State* currentState_;						//		��ǰ״ָ̬��
    std::string currentStateName_;				//		��ǰ״̬���� ���ļ���
};

#endif // STATEMACHINE_H
