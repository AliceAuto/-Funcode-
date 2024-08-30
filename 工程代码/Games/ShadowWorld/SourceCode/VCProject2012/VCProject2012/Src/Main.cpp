
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
#include "json\json.h"
#include "Setting.h"





















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
	


    // ���ó�ʼ״̬
    
    // ����״̬�������״̬
;
    // ������ѭ��
    while (CSystem::EngineMainLoop())
    {
        // ��ȡʱ���
        float fTimeDelta = CSystem::GetTimeDelta();

        // ������Ϸ��ѭ��
        CGameMain::GetInstance().GameMainLoop(fTimeDelta);

        // ���¿�����
    }

    // �ر���Ϸ����
    CSystem::ShutdownGameEngine();

    // ֹͣ��־��¼
    LogManager::StopLogging();

    return 0;
}
#endif