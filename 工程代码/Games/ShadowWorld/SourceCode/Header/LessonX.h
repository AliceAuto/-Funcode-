/////////////////////////////////////////////////////////////////////////////////
//
//
//
//
/////////////////////////////////////////////////////////////////////////////////
#ifndef _LESSON_X_H_
#define _LESSON_X_H_
//
#include <Windows.h>

/////////////////////////////////////////////////////////////////////////////////
//
// ��Ϸ�ܹ��ࡣ��������Ϸ��ѭ������Ϸ��ʼ���������ȹ���
class	CGameMain
{
private:
	int				m_iGameState;				// ��Ϸ״̬��0���������ߵȴ���ʼ��1����ʼ����2����Ϸ������


public:
	CGameMain();            //���캯��
	~CGameMain();           //��������  

	// Get����
	int				GetGameState()											{ return m_iGameState; }
	
	// Set����
	void			SetGameState( const int iState )				{ m_iGameState	=	iState; }
	
	// ��Ϸ��ѭ����
	void			GameMainLoop( float	fDeltaTime );
	void			GameInit();
	void			GameRun( float fDeltaTime );
	void			GameEnd();
	void 			OnMouseMove( const float fMouseX, const float fMouseY );
	void 			OnMouseClick( const int iMouseType, const float fMouseX, const float fMouseY );
	void 			OnMouseUp( const int iMouseType, const float fMouseX, const float fMouseY );
	void 			OnKeyDown( const int iKey, const bool bAltPress, const bool bShiftPress, const bool bCtrlPress );
	void 			OnKeyUp( const int iKey );
	void 			OnSpriteColSprite( const char *szSrcName, const char *szTarName );
	void 			OnSpriteColWorldLimit( const char *szName, const int iColSide );
};



/////////////////////////////////////////////////////////////////////////////////
// 
extern CGameMain	g_GameMain;






/*
 * @brief ����һ�� ������	����(obj)
 *һ������Ļ������ʾ�ľ��鶼���Ӧһ��������
 *        
 * @author	�����
 * @date 2024-07-29
 */
class object{
public:
	object(){}
	~object(){}
private:
	CSprite *	spritePtr			;			//����������
};






//---------------------------------------------------------------------------------------

/*
 * @brief ����һ�� ʵ����
 * �̳���obj��һ������Ϸ����������ײ�Ķ�����һ��ʵ�������
 *        
 * @author	�����
 * @date 2024-07-29
 */
class Entity:public object{

};



/*
 * @brief ����һ�� ��ʵ����
 * �̳���obj��һ������Ϸ������������ײ�Ķ�����һ����ʵ�������
 *        
 * @author	�����
 * @date 2024-07-29
 */
class NonEntity:public object{






};
//---------------------------------------------------------------------------------------




/*
 * @brief ����һ�� ��̬ʵ����
 * �̳���Eitity��һ����Ϸ�� ���� �ƶ���ʵ�嶼��һ����̬ʵ�������
 *        
 * @author	�����
 * @date 2024-07-29
 */
class StaticEntity:public Entity{


};


/*
 * @brief ����һ�� ��̬ʵ����
 * �̳���Eitity��һ����Ϸ�� ���ƶ� ��ʵ�嶼��һ����̬ʵ�������
 *        
 * @author	�����
 * @date 2024-07-29
 */
class DynamicEntity:public Entity{


};






/*
 * @brief ����һ�� DynamicNPC��
 * �̳��� DynamicEntity��һ����Ϸ�� �ɳ�����Ƶ� ��̬ʵ���඼��һ��DynamicNPC��
 *        
 * @author	�����
 * @date 2024-07-29
 */
class DynamicNPC:public DynamicEntity{


};





/*
 * @brief ����һ�� PlayerCharacter��
 * �̳��� DynamicEntity��һ����Ϸ�� ����ҿ��Ƶ� ��̬ʵ���඼��һ��PlayerCharacter��
 *        
 * @author	�����
 * @date 2024-07-29
 */
class PlayerCharacter:public DynamicEntity{


};





/*
 * @brief ����һ�� InteractiveBlock��
 * �̳��� StaticEntity�����Խ����ľ�̬ʵ���඼��һ�� InteractiveBlock ��
 *        
 * @author	�����
 * @date 2024-07-29
 */
class InteractiveBlock:public StaticEntity{


};





/*
 * @brief ����һ�� NonInteractiveBlock��
 * �̳��� StaticEntity�������Խ����ľ�̬ʵ���඼��һ�� NonInteractiveBlock ��
 *        
 * @author	�����
 * @date 2024-07-29
 */
class NonInteractiveBlock:public StaticEntity{


};

#endif // _LESSON_X_H_