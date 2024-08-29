//====================================================================
/*
                        ��Ϸ���ϵͳ������
*/
//====================================================================

#ifndef _LESSON_X_H_
#define _LESSON_X_H_

#include <Windows.h>
#include "headers/PlayerController.h"
#include <map>
#include "EntityManager.h"
#include "StateMachine.h"

// ��Ϸ�ܹ��ࡣ��������Ϸ��ѭ������Ϸ��ʼ���������ȹ���
class CGameMain
{
private:
    int                m_iGameState;                // ��Ϸ״̬��0���������ߵȴ���ʼ��1����ʼ����2����Ϸ������

    // ˽�й��캯��������������ȷ���ⲿ����ֱ�Ӵ���������ʵ��
    CGameMain();            // ���캯��
    ~CGameMain();           // ��������
public:
    StateMachine* stateMachine;

    // ��̬������ȡΨһʵ��
    static CGameMain& GetInstance()
    {
        static CGameMain instance; // �ֲ���̬������ȷ��Ψһ��
        return instance;
    }

    // Get����
    int GetGameState() const { return m_iGameState; }
    // Set����
    void SetGameState(const int iState) { m_iGameState = iState; }
    // ��Ϸ��ѭ����
    void GameMainLoop(float fDeltaTime);
    void GameInit();
    void GameRun(float fDeltaTime);
    void GameEnd();
    void OnMouseMove(const float fMouseX, const float fMouseY);
    void OnMouseClick(const int iMouseType, const float fMouseX, const float fMouseY);
    void OnMouseUp(const int iMouseType, const float fMouseX, const float fMouseY);
    void OnKeyDown(const int iKey, const bool bAltPress, const bool bShiftPress, const bool bCtrlPress);
    void OnKeyUp(const int iKey);
    void OnSpriteColSprite(const char* szSrcName, const char* szTarName);
    void OnSpriteColWorldLimit(const char* szName, const int iColSide);
};

#endif // _LESSON_X_H_
