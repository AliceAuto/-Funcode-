
#include "CSystem.h"//					����ӿ��ļ�
#include "CGameMain.h"//				����ʱ��Ϸ�߼�ϵͳ��Ҫ���
#include "headers\EventDrivenSystem.h"	//	���Ĺ����������Ҫ���
#include "Logger.h"	//					������¼�����������־
#include <string>//						����ǿ��ת������Ϊstring
#include "Setting.h"//					���õ������һЩö����





//==========================================================================
/*
								��Ϸ���ʵ��
*/
//==========================================================================





















//==========================================================================
void CSystem::OnMouseMove( const float fMouseX, const float fMouseY )
{
	// �����ڴ������Ϸ��Ҫ����Ӧ����
	g_GameMain.OnMouseMove(fMouseX, fMouseY);
	 MouseInputEvent mouseEvent(fMouseX, fMouseY, false, false, false);
    
    // �ַ��¼�
    eventManager.DispatchEvent(mouseEvent);

    // ��־��¼
    LogManager::Log("����ƶ�: (" + std::to_string(fMouseX) + ", " + std::to_string(fMouseY) + ")");
	/*
	// �����¼����ַ�
    MouseInputEvent mouseEvent(fMouseX, fMouseY);		//�ַ�	����ƶ��¼� <fMouseX, fMouseY>


	//�����¼�
    eventManager.DispatchEvent(mouseEvent); //			��������¼���		<xxx������>

		
	//��־��¼
    LogManager::Log("<"+std::to_string(fMouseY)+","+std::to_string(fMouseY)+">");//��ʽ	<fMouseX, fMouseY>
	*/
}

//==========================================================================
//
// ���沶׽�������Ϣ�󣬽����õ�������
// ���� iMouseType����갴��ֵ���� enum MouseTypes ����
// ���� fMouseX, fMouseY��Ϊ��굱ǰ����
//
void CSystem::OnMouseClick( const int iMouseType, const float fMouseX, const float fMouseY )
{
	// �����ڴ������Ϸ��Ҫ����Ӧ����
	g_GameMain.OnMouseClick(iMouseType, fMouseX, fMouseY);
	 bool isLeftPressed = (iMouseType == 0);
    bool isMiddlePressed = (iMouseType == 1);
    bool isRightPressed = (iMouseType == 2);

    // ����������¼�
    MouseInputEvent mouseEvent(fMouseX, fMouseY, isLeftPressed, isMiddlePressed, isRightPressed);
    
    // �ַ��¼�
    eventManager.DispatchEvent(mouseEvent);

    // ��־��¼
    LogManager::Log("�����: ����=" + std::to_string(iMouseType) + " ����=(" + std::to_string(fMouseX) + ", " + std::to_string(fMouseY) + ")");
}
//==========================================================================
//
// ���沶׽��굯����Ϣ�󣬽����õ�������
// ���� iMouseType����갴��ֵ���� enum MouseTypes ����
// ���� fMouseX, fMouseY��Ϊ��굱ǰ����
//
void CSystem::OnMouseUp( const int iMouseType, const float fMouseX, const float fMouseY )
{
	// �����ڴ������Ϸ��Ҫ����Ӧ����
	g_GameMain.OnMouseUp(iMouseType, fMouseX, fMouseY);
}
//==========================================================================
//
// ���沶׽���̰�����Ϣ�󣬽����õ�������
// ���� iKey�������µļ���ֵ�� enum KeyCodes �궨��
// ���� iAltPress, iShiftPress��iCtrlPress�������ϵĹ��ܼ�Alt��Ctrl��Shift��ǰ�Ƿ�Ҳ���ڰ���״̬(0δ���£�1����)
//
void CSystem::OnKeyDown( const int iKey, const bool bAltPress, const bool bShiftPress, const bool bCtrlPress )
{
	// �����ڴ������Ϸ��Ҫ����Ӧ����
	g_GameMain.OnKeyDown(iKey, bAltPress, bShiftPress, bCtrlPress);

	
	// �����¼����ַ�
    KeyboardInputEvent keyboardEvent(iKey,	KeyboardInputEvent::State::KEY_ON);	//�ַ�	���������¼� <Key, State>


	//�����¼�
    eventManager.DispatchEvent(keyboardEvent); //			���������¼���		<xxx������>
	
		
	//��־��¼
    LogManager::Log("<"+std::to_string(iKey)+","+std::to_string(bShiftPress)+"> ���̰���");//��ʽ	<Key, ShiftState>



}
//==========================================================================
//
// ���沶׽���̵�����Ϣ�󣬽����õ�������
// ���� iKey������ļ���ֵ�� enum KeyCodes �궨��
//
void CSystem::OnKeyUp( const int iKey )
{
	// �����ڴ������Ϸ��Ҫ����Ӧ����
	g_GameMain.OnKeyUp(iKey);




		
	// �����¼����ַ�
    KeyboardInputEvent keyboardEvent(iKey,	KeyboardInputEvent::State::KEY_OFF);	//�ַ�	���������¼� <Key, State>


	//�����¼�
    eventManager.DispatchEvent(keyboardEvent); //			���������¼���		<xxx������>

		
	//��־��¼
    LogManager::Log("<"+std::to_string(iKey)+"> ���̵���");//��ʽ	<Key, ShiftState>



}

//===========================================================================
//
// ���沶׽�������뾫����ײ֮�󣬵��ô˺���
// ����֮��Ҫ������ײ�������ڱ༭�����ߴ��������þ��鷢�ͼ�������ײ
// ���� szSrcName��������ײ�ľ�������
// ���� szTarName������ײ�ľ�������
//
void CSystem::OnSpriteColSprite( const char *szSrcName, const char *szTarName )
{
	// �����ڴ������Ϸ��Ҫ����Ӧ����
	g_GameMain.OnSpriteColSprite(szSrcName, szTarName);
}

//===========================================================================
//
// ���沶׽������������߽���ײ֮�󣬵��ô˺���.
// ����֮��Ҫ������ײ�������ڱ༭�����ߴ��������þ��������߽�����
// ���� szName����ײ���߽�ľ�������
// ���� iColSide����ײ���ı߽� 0 ��ߣ�1 �ұߣ�2 �ϱߣ�3 �±�
//
void CSystem::OnSpriteColWorldLimit( const char *szName, const int iColSide )
{
	// �����ڴ������Ϸ��Ҫ����Ӧ����
	g_GameMain.OnSpriteColWorldLimit(szName, iColSide);

}

