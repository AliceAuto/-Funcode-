
#include <Stdio.h>
#include "CGameMain.h"
#include "headers\PlayerController.h"
#include "Setting.h"
#include "Logger.h"





//============================================================
/*
						��Ϸ���ϵͳʵ��
*/
//============================================================

















////////////////////////////////////////////////////////////////////////////////
//
//

CGameMain		g_GameMain;	

//==============================================================================
//
// ����ĳ�������Ϊ��GameMainLoop����Ϊ��ѭ��������������ÿ֡ˢ����Ļͼ��֮�󣬶��ᱻ����һ�Ρ�

//==============================================================================
//
// ���캯��
CGameMain::CGameMain()
{
	m_iGameState			=	1;
	

}
//==============================================================================
//
// ��������
CGameMain::~CGameMain()
{
}

//==============================================================================
//
// ��Ϸ��ѭ�����˺���������ͣ�ĵ��ã�����ÿˢ��һ����Ļ���˺�����������һ��
// ���Դ�����Ϸ�Ŀ�ʼ�������С������ȸ���״̬. 
// ��������fDeltaTime : �ϴε��ñ��������˴ε��ñ�������ʱ��������λ����
void CGameMain::GameMainLoop( float	fDeltaTime )
{
	switch( GetGameState() )
	{
		// ��ʼ����Ϸ�������һ���������
	case 1:
		{
			GameInit();
			SetGameState(2); // ��ʼ��֮�󣬽���Ϸ״̬����Ϊ������
		}
		break;

		// ��Ϸ�����У����������Ϸ�߼�
	case 2:
		{
			// TODO �޸Ĵ˴���Ϸѭ�������������ȷ��Ϸ�߼�
			if( true )
			{
				GameRun( fDeltaTime );
			}
			else // ��Ϸ������������Ϸ���㺯����������Ϸ״̬�޸�Ϊ����״̬
			{				
				SetGameState(0);
				GameEnd();
			}
		}
		break;

		// ��Ϸ����/�ȴ����ո����ʼ
	case 0:
	default:
		break;
	};
}

//==============================================================================
void CGameMain::GameInit()
{
      // ������Դ
    LoadResourcesFromJSON(m_resourceBagPtrs, "resource.json");
    
    // ���������� PlayerController ��Ϊһ��ʵ��
    std::string playerID = m_control_Manager.CreateEntity(
        "Player",
        0.0f,
        0.0f,
        m_resourceBagPtrs["resources1"]
    );

    LogManager::Log(playerID);

    // ��ȡ�����¼�
    Entity* entity = m_control_Manager.GetEntity(playerID);
    PlayerController* controller = dynamic_cast<PlayerController*>(entity);
    if (controller) {
        eventManager.RegisterListener(EventType::KeyboardInput, std::bind(&PlayerController::ProcessInput, controller, std::placeholders::_1));
        eventManager.RegisterListener(EventType::MouseInput, std::bind(&PlayerController::ProcessInput, controller, std::placeholders::_1));
        LogManager::Log("���̼����󶨳ɹ�");
    } else {
        LogManager::Log("���̼�����ʧ��");
    }

}	

//==============================================================================
void CGameMain::GameRun(float fDeltaTime)
{
	
    m_control_Manager.UpdateAllEntities();

}

//=============================================================================
//
// ������Ϸ����
void CGameMain::GameEnd()
{
}
//==========================================================================
//
// ����ƶ�
// ���� fMouseX, fMouseY��Ϊ��굱ǰ����
void CGameMain::OnMouseMove( const float fMouseX, const float fMouseY )
{
<<<<<<< Updated upstream
	
=======
	 MouseInputEvent mouseEvent(fMouseX, fMouseY, false, false, false);
    
    // �ַ��¼�
    EventManager::Instance().DispatchEvent(mouseEvent);

    // ��־��¼
    LogManager::Log("����ƶ�: (" + std::to_string(fMouseX) + ", " + std::to_string(fMouseY) + ")");
>>>>>>> Stashed changes
}
//==========================================================================
//
// �����
// ���� iMouseType����갴��ֵ���� enum MouseTypes ����
// ���� fMouseX, fMouseY��Ϊ��굱ǰ����
void CGameMain::OnMouseClick( const int iMouseType, const float fMouseX, const float fMouseY )
{
<<<<<<< Updated upstream
	
=======
	 bool isLeftPressed = (iMouseType == 0);
    bool isMiddlePressed = (iMouseType == 1);
    bool isRightPressed = (iMouseType == 2);

    // ����������¼�
    MouseInputEvent mouseEvent(fMouseX, fMouseY, isLeftPressed, isMiddlePressed, isRightPressed);
    
    // �ַ��¼�
    EventManager::Instance().DispatchEvent(mouseEvent);

    // ��־��¼
    LogManager::Log("�����: ����=" + std::to_string(iMouseType) + " ����=(" + std::to_string(fMouseX) + ", " + std::to_string(fMouseY) + ")");
>>>>>>> Stashed changes
}
//==========================================================================
//
// ��굯��
// ���� iMouseType����갴��ֵ���� enum MouseTypes ����
// ���� fMouseX, fMouseY��Ϊ��굱ǰ����
void CGameMain::OnMouseUp( const int iMouseType, const float fMouseX, const float fMouseY )
{
	
}
//==========================================================================
//
// ���̰���
// ���� iKey�������µļ���ֵ�� enum KeyCodes �궨��
// ���� iAltPress, iShiftPress��iCtrlPress�������ϵĹ��ܼ�Alt��Ctrl��Shift��ǰ�Ƿ�Ҳ���ڰ���״̬(0δ���£�1����)
void CGameMain::OnKeyDown( const int iKey, const bool bAltPress, const bool bShiftPress, const bool bCtrlPress )
{	

<<<<<<< Updated upstream
=======

	//�����¼�
    EventManager::Instance().DispatchEvent(keyboardEvent); //			���������¼���		<xxx������>
	
		
	//��־��¼
    LogManager::Log("<"+std::to_string(iKey)+","+std::to_string(bShiftPress)+"> ���̰���");//��ʽ	<Key, ShiftState>
>>>>>>> Stashed changes
}
//==========================================================================
//
// ���̵���
// ���� iKey������ļ���ֵ�� enum KeyCodes �궨��
void CGameMain::OnKeyUp( const int iKey )
{
<<<<<<< Updated upstream
	
=======
			
	// �����¼����ַ�
    KeyboardInputEvent keyboardEvent(iKey,	KeyboardInputEvent::State::KEY_OFF);	//�ַ�	���������¼� <Key, State>


	//�����¼�
    EventManager::Instance().DispatchEvent(keyboardEvent); //			���������¼���		<xxx������>

		
	//��־��¼
    LogManager::Log("<"+std::to_string(iKey)+"> ���̵���");//��ʽ	<Key, ShiftState>


>>>>>>> Stashed changes
}
//===========================================================================
//
// �����뾫����ײ
// ���� szSrcName��������ײ�ľ�������
// ���� szTarName������ײ�ľ�������
void CGameMain::OnSpriteColSprite( const char *szSrcName, const char *szTarName )
{
	
}
//===========================================================================
//
// ����������߽���ײ
// ���� szName����ײ���߽�ľ�������
// ���� iColSide����ײ���ı߽� 0 ��ߣ�1 �ұߣ�2 �ϱߣ�3 �±�
void CGameMain::OnSpriteColWorldLimit( const char *szName, const int iColSide )
{
	
}








