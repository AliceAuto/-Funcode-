
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


#include "CSprite.h"
#include "CSystem.h"
#include "CGameMain.h"



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
	CSystem::SetWindowTitle("LessonX");

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
	return 0;
}

#endif