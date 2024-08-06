
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
#include <iostream>
#include "Logger.h"
#include "CSprite.h"
#include "CSystem.h"
#include "CGameMain.h"
#include "headers\EventDrivenSystem.h"
#include "stdio.h"
#include "headers\Controller.h"
#include <functional>
///////////////////
#include "EC.h" //	��������
#ifdef WIN    //
///////////////

// ���������



int PASCAL WinMain(HINSTANCE hInstance,
                   HINSTANCE hPrevInstance,
                   LPSTR     lpCmdLine,
                   int       nCmdShow)
{
	// ��ʼ����Ϸ����
	if( !CSystem::InitGameEngine( hInstance, lpCmdLine ) )
		return 0;

	// To do : �ڴ�ʹ��API���Ĵ��ڱ���
	CSystem::SetWindowTitle("Ӱ֮��");


	//			�����Ǽ�������ע��
	//=================================================================
		
		eventManager.RegisterListener(EventType::MouseInput, onMouseInput);
		

		eventManager.RegisterListener(EventType::KeyboardInput, std::bind(&PlayerController::ProcessInput, &player, std::placeholders::_1));
	//=======================================================================

	//			�����ǿ���ʱ�ض����ļ����ĳ�ʼ��
	//=============================================================
		 LogManager::StartLogging("logfile.txt");  // ������־��¼
		 // �����־��Ϣ
		 LogManager::Log("�����ǳ�����־:");
	//===================================================================
   

    

    

    

	// ������ѭ����������Ļͼ��ˢ�µȹ���
	while( CSystem::EngineMainLoop() )
	{
		// ��ȡ���ε���֮���ʱ�����ݸ���Ϸ�߼�����
		float	fTimeDelta	=	CSystem::GetTimeDelta();

		// ִ����Ϸ��ѭ��
		g_GameMain.GameMainLoop( fTimeDelta );
	};

	// �ر���Ϸ����
	CSystem::ShutdownGameEngine();

	LogManager::StopLogging();  // ֹͣ��־��¼


	return 0;
}

#endif