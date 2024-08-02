#ifndef CSYSTEM_H
#define CSYSTEM_H

#include <windows.h>
////////////////////////////////////////////////////////////////////////////////
//
// �ࣺCSystem
// ϵͳ��ع��ܵ���. �������÷��� CSystem::������();
//
class CSystem
{
public:
	CSystem();
	~CSystem();

	// OnMouseMove������ƶ��󽫱����õĺ��������ڴ˺�������(Main.cpp)�����Լ�����Ӧ����
	// ���� fMouseX, fMouseY��Ϊ��굱ǰ����
	//
	static void		OnMouseMove( const float fMouseX, const float fMouseY );

	// OnMouseClick����갴�º󽫱����õĺ��������ڴ˺�������(Main.cpp)�����Լ�����Ӧ����
	// ���� iMouseType����갴��ֵ���� enum MouseTypes ����
	// ���� fMouseX, fMouseY��Ϊ��굱ǰ����
	//
	static void		OnMouseClick( const int iMouseType, const float fMouseX, const float fMouseY );

	// OnMouseUp����갴�º󽫱����õĺ��������ڴ˺�������(Main.cpp)�����Լ�����Ӧ����
	// ���� iMouseType����갴��ֵ���� enum MouseTypes ����
	// ���� fMouseX, fMouseY��Ϊ��굱ǰ����
	//
	static void		OnMouseUp( const int iMouseType, const float fMouseX, const float fMouseY );

	// OnKeyDown�����̱����º󽫱����õĺ��������ڴ˺�������(Main.cpp)�����Լ�����Ӧ����
	// ���� iKey�������µļ���ֵ�� enum KeyCodes �궨��
	// ���� bAltPress, bShiftPress��bCtrlPress�������ϵĹ��ܼ�Alt��Ctrl��Shift��ǰ�Ƿ�Ҳ���ڰ���״̬
	//
	static void		OnKeyDown( const int iKey, const bool bAltPress, const bool bShiftPress, const bool bCtrlPress );

	// OnKeyUp�����̰�������󽫱����õĺ��������ڴ˺�������(Main.cpp)�����Լ�����Ӧ����
	// ���� iKey������ļ���ֵ�� enum KeyCodes �궨��
	//
	static void		OnKeyUp( const int iKey );

	// OnSpriteColSprite�������뾫����ײ�󽫱����õĺ��������ڴ˺�������(Main.cpp)�����Լ�����Ӧ����
	// ����֮��Ҫ������ײ�������ڱ༭�����ߴ��������þ��鷢�ͼ�������ײ
	// ���� szSrcName��������ײ�ľ�������
	// ���� szTarName������ײ�ľ�������
	//
	static void		OnSpriteColSprite( const char *szSrcName, const char *szTarName );

	// OnSpriteColWorldLimit������������߽���ײ�󽫱����õĺ��������ڴ˺�������(Main.cpp)�����Լ�����Ӧ����
	// ����֮��Ҫ������ײ�������ڱ༭�����ߴ��������þ��������߽�����
	// ���� szName����ײ���߽�ľ�������
	// ���� iColSide����ײ���ı߽� 0 ��ߣ�1 �ұߣ�2 �ϱߣ�3 �±�
	//
	static void		OnSpriteColWorldLimit( const char *szName, const int iColSide );

	// MakeSpriteName: ��ǰ����ַ����������������ϳ�һ���ַ�����
	// ���� szPrev��һ���ǿ��ַ���������ܳ���20��Ӣ���ַ�������ǰ����ַ���
	// ���� iId��һ������
	// ����ֵ������һ���ַ��������紫��("xxx", 2),�򷵻�"xxx2"
	//
	static char* MakeSpriteName(const char *szPrev, const int iId);

	// CursorOff���ر���겻��ʾ����API���ص�������Windows����꣬���ǵ��ÿ�������API dCursorOn��������꽫һֱ����ʾ
	//
	static void		CursorOff();

	// CursorOn�����������ʾ����API dCursorOff�رյ�������¿�����ʾ
	//
	static void		CursorOn();

	// IsCursorOn����ǰ����ǿ������ǹرա���Ӧ������API dCursorOff��dCursorOn�������߹رյĲ���
	// ����ֵ��trueΪ����״̬��falseΪ�ر�״̬
	//
	static bool		IsCursorOn();

	// ShowCursor������/��ʾ��ꡣ��APIֻ�����ر����򴰿��ڵ���꣬�ƶ����������ʱ����껹�ǻ���ʾ
	// ���� bShow��true Ϊ��ʾ��false Ϊ����
	//
	static void		ShowCursor( const bool bShow );

	// IsShowCursor����ǰ�������ʾ�������ء���Ӧ������API ShowCursor���ػ�����ʾ�Ĳ���
	// ����ֵ��trueΪ����״̬��falseΪ�ر�״̬
	//
	static bool		IsShowCursor();

	// SetWindowTitle�����ô�������/����
	// ���� szTitle���ǿ��ַ���
	//
	static void		SetWindowTitle( const char *szTitle );

	// ResizeWindow�����Ĵ��ڴ�С
	// ���� iWidth����ȣ�����0С�ڵ���1920
	// ���� iHeight���߶ȣ�����0С�ڵ���1080
	//
	static void		ResizeWindow(int iWidth, int iHeight);

	// GetHwnd����ȡ���ھ��
	// ����ֵ�����ھ��
	//
	static void		*GetHwnd();

	// Random����ȡһ�����ڵ���0�������
	// ����ֵ��int����Χ0 - 2147483648
	//
	static int		Random();

	// RandomRange����ȡһ��λ�ڲ���1������2֮��������
	// ����ֵ��int����ΧiMin - iMax
	// ���� iMin��С��iMax������
	// ���� iMax������iMin������
	//
	static int		RandomRange( const int iMin, const int iMax );

	// CalLineRotation�������������ߵ�ֱ�ߵ���ת�Ƕ�
	// ����ֵ���Ƕȣ���Χ0 - 360
	// ���� fStartX����ʼ����X
	// ���� fStartY����ʼ����Y
	// ���� fEndX���յ�����X
	// ���� fEndY���յ�����Y
	//
	static float	CalLineRotation( const float fStartX, const float fStartY, const float fEndX, const float fEndY );

	// RotationToVectorX������ĳ���Ƕȶ�Ӧ��ֱ��������X����
	// ���� fRotation���Ƕȣ���Χ0 - 360
	// ����ֵ ����ֱ��������Xֵ
	//
	static float	RotationToVectorX( const float fRotation );

	// RotationToVectorY������ĳ���Ƕȶ�Ӧ��ֱ��������Y����
	// ���� fRotation���Ƕȣ���Χ0 - 360
	// ����ֵ ����ֱ��������Yֵ
	//
	static float	RotationToVectorY( const float fRotation );

	// DrawLine��������֮�仭һ����
	// ���� fStartX����ʼ����X
	// ���� fStartY����ʼ����Y
	// ���� fEndX���յ�����X
	// ���� fEndY���յ�����Y
	// ���� fLineWidth���ߵĴ�ϸ�����ڵ���1
	// ���� iLayer���������ڵĲ㣬��༭�������õľ���Ĳ㼶��ͬһ�������Χ0 - 31��
	// ���� iRed, iGreen, iBlue : ��������ԭɫ����ɫֵ����Χ 0 - 255
	// ���� iAlpha���ߵ�͸���ȣ���Χ0-255. 0Ϊȫ͸����255Ϊ��͸��
	//
	static void		DrawLine( const float fStartX, const float fStartY, const float fEndX, const float fEndY, const float fLineWidth, const int iLayer, const int iRed, const int iGreen, const int iBlue, const int iAlpha );

	// DrawTriangle����һ��������
	// ���� fX1,fX2,fX3�����������������X����
	// ���� fY1,fY2,fY3�����������������Y����
	// ���� fLineWidth���ߵĴ�ϸ�����ڵ���1
	// ���� iLayer�������������ڵĲ㣬��༭�������õľ���Ĳ㼶��ͬһ�������Χ0 - 31��
	// ���� iRed, iGreen, iBlue : ��������ԭɫ����ɫֵ����Χ 0 - 255
	// ���� iAlpha�������ε�͸���ȣ���Χ0-255. 0Ϊȫ͸����255Ϊ��͸��
	//
	static void		DrawTriangle( const float fX1, const float fY1, const float fX2, const float fY2, const float fX3, const float fY3, const float fLineWidth, const int iLayer, const int iRed, const int iGreen, const int iBlue, const int iAlpha );

	// DrawRect����һ������
	// ���� fUpperX�����Ͻ�����X
	// ���� fUpperY�����Ͻ�����Y
	// ���� fLowerX�����½�����X
	// ���� fLowerY�����½�����Y
	// ���� fLineWidth���ߵĴ�ϸ�����ڵ���1
	// ���� iLayer���þ������ڵĲ㣬��༭�������õľ���Ĳ㼶��ͬһ�������Χ0 - 31��
	// ���� iRed, iGreen, iBlue : ��������ԭɫ����ɫֵ����Χ 0 - 255
	// ���� iAlpha�����ε�͸���ȣ���Χ0-255. 0Ϊȫ͸����255Ϊ��͸��
	//
	static void		DrawRect( const float fUpperX, const float fUpperY, const float fLowerX, const float fLowerY, const float fLineWidth, const int iLayer, const int iRed, const int iGreen, const int iBlue, const int iAlpha );

	// DrawCircle����һ��Բ
	// ���� fCenterX��Բ������X
	// ���� fCenterY��Բ������Y
	// ���� fRadius��Բ�İ뾶
	// ���� iSegment��Բ����������Χ4-72. ���紫��6�����õ�һ��6���Σ�����Խ��ԽԲ�������ǻ�ͼЧ��Խ��
	// ���� fLineWidth���ߵĴ�ϸ�����ڵ���1
	// ���� iLayer����Բ���ڵĲ㣬��༭�������õľ���Ĳ㼶��ͬһ�������Χ0 - 31��
	// ���� iRed, iGreen, iBlue : ��������ԭɫ����ɫֵ����Χ 0 - 255
	// ���� iAlpha��Բ��͸���ȣ���Χ0-255. 0Ϊȫ͸����255Ϊ��͸��
	//
	static void		DrawCircle( const float fCenterX, const float fCenterY, const float fRadius, const int iSegment, const float fLineWidth, const int iLayer, const int iRed, const int iGreen, const int iBlue, const int iAlpha );

	// GetScreenLeft����ȡ����߽�֮���X����
	// ����ֵ����߽�X����
	//
	static float	GetScreenLeft();

	// GetScreenTop����ȡ����߽�֮�ϱ�Y����
	// ����ֵ���ϱ߽�Y����
	//
	static float	GetScreenTop();

	// GetScreenRight����ȡ����߽�֮�ұ�X����
	// ����ֵ���ұ߽�X����
	//
	static float	GetScreenRight();

	// GetScreenBottom����ȡ����߽�֮�±�Y����
	// ����ֵ���±߽�Y����
	//
	static float	GetScreenBottom();

	// LoadMap�������³�����ע�⣬�����³�����ʱ�򣬾ɳ��������о��鶼��������ɾ���������������ڳ����д��������Ƴ����ľ��鶼�����ڵ��ñ�API֮ǰ��ɾ����
	// ���� szName���������֡����½����������ʱ��ȡ�����֣������Сд�ĺ�׺ -- xxx.t2d�����ô�·��
	//
	static void		LoadMap( const char *szName );

	//////////////////////////////////////////////////////////////////////////////////////////
	//
	// ����APIΪϵͳAPI�������Լ�����
	//
	//////////////////////////////////////////////////////////////////////////////////////////

	// GetTimeDelta����ȡ���ε��ñ�����֮���ʱ���
	// ����ֵ��float����λ ��
	//
	static float	GetTimeDelta();
	// EngineMainLoop��������ѭ�������������Լ�����
	//
	static bool		EngineMainLoop();
	// InitGameEngine����ʼ�����棬�����Լ�����
	//
	static bool		InitGameEngine( HINSTANCE hInstance, LPSTR lpCmdLine );
	static bool		InitGameEngineEx( HINSTANCE hInstance, LPSTR lpCmdLine );
	// ShutdownGameEngine���ر����棬�����Լ�����
	//
	static void		ShutdownGameEngine();
};



#endif