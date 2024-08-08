
//======================================================================
//				���ļ�Ϊ	Window���		Ϊ��Ŀ�����			   //	
//======================================================================

	//========================================
	/*				ע��					//
	//										//
	//	ʹ�õ�Ԫ����ͨ��ʱҪ�޸� "EC.h"		//
	//   �����ļ��� �궨��Ϊ   #define	MIN	//
	//										//
	*/										//
	//=======================================

///////////////////
#include "EC.h" //	��������
#ifdef WIN    //
///////////////

// ���������


#include <windows.h>
#include "Logger.h"
#include "CSprite.h"
#include "CSystem.h"
#include "CGameMain.h"
#include "EventDrivenSystem.h"
#include "CharacterController.h"
#include "MonsterController.h"
#include "PlayerController.h"
#include "StateMachine.h"
#include "States.h"
#include "json\json.h"
#include "Setting.h"





















// �����¼�������
void onMouseInput(const Event& event);
void onKeyboardInput(const Event& event);

// ���������
int PASCAL WinMain(HINSTANCE hInstance,
                   HINSTANCE hPrevInstance,
                   LPSTR     lpCmdLine,
                   int       nCmdShow)
{
    // ��ʼ����Ϸ����
    if (!CSystem::InitGameEngine(hInstance, lpCmdLine))
        return 0;

    // ���ô��ڱ���
    CSystem::SetWindowTitle("Ӱ֮��");

    // ������Դ
   
    

    // ������־��¼
    LogManager::StartLogging("logfile.txt");
    LogManager::Log("�����ǳ�����־:");

    // ����״̬�������״̬
    StateMachine sm;
    sm.AddState("MainMenu", MainMenuState::CreateState());
    sm.AddState("Game", GameState::CreateState());
    sm.AddState("Settings", SettingsMenuState::CreateState());
    sm.AddState("PauseMenu", PauseMenuState::CreateState());
    sm.AddState("Exit", ExitMenuState::CreateState());

    // ������ѭ��
    while (CSystem::EngineMainLoop())
    {
        // ��ȡʱ���
        float fTimeDelta = CSystem::GetTimeDelta();

        // ������Ϸ��ѭ��
        g_GameMain.GameMainLoop(fTimeDelta);

        // ���¿�����
    }

    // �ر���Ϸ����
    CSystem::ShutdownGameEngine();

    // ֹͣ��־��¼
    LogManager::StopLogging();

    return 0;
}
#endif