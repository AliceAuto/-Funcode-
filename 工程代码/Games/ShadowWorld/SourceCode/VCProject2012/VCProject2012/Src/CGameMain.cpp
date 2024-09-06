
#include <Stdio.h>
#include "CGameMain.h"
#include "headers\PlayerController.h"
#include "Setting.h"
#include "Logger.h"
#include "headers\SceneStates.h"
#include "headers\StateMachine.h"
#include "Device.h"

//============================================================
/*
						��Ϸ���ϵͳʵ��
*/
//============================================================

















////////////////////////////////////////////////////////////////////////////////
//
//



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

	 stateMachine = new StateMachine;
    // ���״̬
    stateMachine->AddState("MainMenu", std::unique_ptr<MainMenuState>(new MainMenuState()));
    stateMachine->AddState("Game", std::unique_ptr<GameState>(new GameState()));
    stateMachine->AddState("Settings", std::unique_ptr<SettingsMenuState>(new SettingsMenuState()));
    stateMachine->AddState("PauseMenu", std::unique_ptr<PauseMenuState>(new PauseMenuState()));
    stateMachine->AddState("Exit", std::unique_ptr<ExitMenuState>(new ExitMenuState()));
    stateMachine->AddState("HighScore", std::unique_ptr<HighScoreState>(new HighScoreState()));
    stateMachine->SetCurrentState("MainMenu");

}	

//==============================================================================
void CGameMain::GameRun(float fDeltaTime)
{

  stateMachine->Update(fDeltaTime);

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
	 
    
   

    // ��־��¼
    LogManager::Log("����ƶ�: (" + std::to_string(fMouseX) + ", " + std::to_string(fMouseY) + ")");
	Mouse::Instance().x=fMouseX;
	Mouse::Instance().y = fMouseY;
	MouseInputEvent mouseEvent(Mouse::Instance().x, Mouse::Instance().y , Mouse::Instance().leftPressed,Mouse::Instance().middlePressed, Mouse::Instance().rightPressed); 
	// �ַ��¼�
    EventManager::Instance().DispatchEvent(mouseEvent);
}
//==========================================================================
//
// �����
// ���� iMouseType����갴��ֵ���� enum MouseTypes ����
// ���� fMouseX, fMouseY��Ϊ��굱ǰ����
void CGameMain::OnMouseClick( const int iMouseType, const float fMouseX, const float fMouseY )
{

	if (iMouseType ==0){Mouse::Instance().leftPressed=true;
	}
	else if (iMouseType ==1){Mouse::Instance().middlePressed=true;
	}
	else if (iMouseType ==2){Mouse::Instance().rightPressed=true;
	}
    // ����������¼�
    MouseInputEvent mouseEvent(Mouse::Instance().x, Mouse::Instance().y, Mouse::Instance().leftPressed, Mouse::Instance().middlePressed, Mouse::Instance().rightPressed);
    
    // �ַ��¼�
    EventManager::Instance().DispatchEvent(mouseEvent);
	
    // ��־��¼
    LogManager::Log("�����: ����=" + std::to_string(iMouseType) + " ����=(" + std::to_string(fMouseX) + ", " + std::to_string(fMouseY) + ")");

}
//==========================================================================
//
// ��굯��
// ���� iMouseType����갴��ֵ���� enum MouseTypes ����
// ���� fMouseX, fMouseY��Ϊ��굱ǰ����
void CGameMain::OnMouseUp( const int iMouseType, const float fMouseX, const float fMouseY )
{
	if (iMouseType ==0){Mouse::Instance().leftPressed=false;
	}
	else if (iMouseType ==1){Mouse::Instance().middlePressed=false;
	}
	else if (iMouseType ==2){Mouse::Instance().rightPressed=false;
	}
	 MouseInputEvent mouseEvent(Mouse::Instance().x, Mouse::Instance().y, Mouse::Instance().leftPressed, Mouse::Instance().middlePressed, Mouse::Instance().rightPressed);
    
    // �ַ��¼�
    EventManager::Instance().DispatchEvent(mouseEvent);
}
//==========================================================================
//
// ���̰���
// ���� iKey�������µļ���ֵ�� enum KeyCodes �궨��
// ���� iAltPress, iShiftPress��iCtrlPress�������ϵĹ��ܼ�Alt��Ctrl��Shift��ǰ�Ƿ�Ҳ���ڰ���״̬(0δ���£�1����)
void CGameMain::OnKeyDown( const int iKey, const bool bAltPress, const bool bShiftPress, const bool bCtrlPress )
{	
		// �����¼����ַ�
    KeyboardInputEvent keyboardEvent(iKey,	KeyboardInputEvent::KeyState::KEY_ON);	//�ַ�	���������¼� <Key, State>


	//�����¼�
    EventManager::Instance().DispatchEvent(keyboardEvent); //			���������¼���		<xxx������>
	
		
	//��־��¼
    LogManager::Log("<"+std::to_string(iKey)+","+std::to_string(bShiftPress)+"> ���̰���");//��ʽ	<Key, ShiftState>
}
//==========================================================================
//
// ���̵���
// ���� iKey������ļ���ֵ�� enum KeyCodes �궨��
void CGameMain::OnKeyUp( const int iKey )
{
			
	// �����¼����ַ�
    KeyboardInputEvent keyboardEvent(iKey,	KeyboardInputEvent::KeyState::KEY_OFF);	//�ַ�	���������¼� <Key, State>


	//�����¼�
    EventManager::Instance().DispatchEvent(keyboardEvent); //			���������¼���		<xxx������>

		
	//��־��¼
    LogManager::Log("<"+std::to_string(iKey)+"> ���̵���");//��ʽ	<Key, ShiftState>


}
//===========================================================================
//
// �����뾫����ײ
// ���� szSrcName��������ײ�ľ�������
// ���� szTarName������ײ�ľ�������
void CGameMain::OnSpriteColSprite( const char *szSrcName, const char *szTarName )
{

	
	Object* spriteA =static_cast<GameState*>(stateMachine->currentState_)->objectManager->GetObjectBySpriteName(szSrcName);
    Object* spriteB = static_cast<GameState*>(stateMachine->currentState_)->objectManager->GetObjectBySpriteName(szTarName);
	if (spriteA||spriteB){
	spriteA->ifCollision(spriteB);
	spriteB->ifCollision(spriteA);
	}
}
//===========================================================================
//
// ����������߽���ײ
// ���� szName����ײ���߽�ľ�������
// ���� iColSide����ײ���ı߽� 0 ��ߣ�1 �ұߣ�2 �ϱߣ�3 �±�
void CGameMain::OnSpriteColWorldLimit( const char *szName, const int iColSide )
{
	
}








