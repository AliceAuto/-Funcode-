/**
 * @(#)EngineInterface.java
 *
 *
 * @author 
 * @version 1.00
 */

 
 import FunCode.EngineCall;
 
/**
* �����޸Ĵ�JAVA�ļ�����κ�����
* ��������Ӧ��������ײ��Ӧ�������津�������õĽӿ�
* �����Լ�ʹ��EngineInterface����ඨ��ʵ��
*/
public class EngineInterface implements EngineCall 
{    	
	/**
	* OnMouseMove������ƶ��󽫱����õķ���
	* @param ���� fMouseX��Ϊ��굱ǰ����
	* @param ���� fMouseY��Ϊ��굱ǰ����
	*/
    public void	OnMouseMove( float fMouseX, float fMouseY )
	{
		CGameMain.g_GameMain.OnMouseMove( fMouseX, fMouseY );
	}
	
	/**
	* OnMouseClick����갴�º󽫱����õķ���
	* @param ���� iMouseType����갴��ֵ���� MouseTypes ����
	* @param ���� fMouseX��Ϊ��굱ǰ����
	* @param ���� fMouseY��Ϊ��굱ǰ����
	*/	
	public void	OnMouseClick( int iMouseType, float fMouseX, float fMouseY )
	{		
		CGameMain.g_GameMain.OnMouseClick( iMouseType, fMouseX, fMouseY );
	}
	
	/**
	* OnMouseUp����굯��󽫱����õķ���
	* @param ���� iMouseType����갴��ֵ���� MouseTypes ����
	* @param ���� fMouseX��Ϊ��굱ǰ����
	* @param ���� fMouseY��Ϊ��굱ǰ����
	*/	
	public void	OnMouseUp( int iMouseType, float fMouseX, float fMouseY )
	{		
		CGameMain.g_GameMain.OnMouseUp( iMouseType, fMouseX, fMouseY );
	}
    
	/**
	* OnKeyDown�����̱����º󽫱����õķ���
	* @param ���� iKey�������µļ���ֵ�� KeyCodes �궨��
	* @param ���� bAltPress, bShiftPress��bCtrlPress�������ϵĹ��ܼ�Alt��Ctrl��Shift��ǰ�Ƿ�Ҳ���ڰ���״̬
	*/    
    public void	OnKeyDown( int iKey, boolean bAltPress, boolean bShiftPress, boolean bCtrlPress )
    {
    	CGameMain.g_GameMain.OnKeyDown( iKey, bAltPress, bShiftPress, bCtrlPress );
    }
    
	/**
	* OnKeyUp�����̰�������󽫱����õķ���
	* @param ���� iKey������ļ���ֵ�� KeyCodes �궨��
	*/    
	public void	OnKeyUp( int iKey )
	{
		CGameMain.g_GameMain.OnKeyUp( iKey );
	}
	
	/**
	* OnSpriteColSprite�������뾫����ײ�󽫱����õķ���
	* ����֮��Ҫ������ײ�������ڱ༭�����ߴ��������þ��鷢�ͼ�������ײ
	* @param ���� szSrcName��������ײ�ľ�������
	* @param ���� szTarName������ײ�ľ�������
	*/	
	public void	OnSpriteColSprite( String szSrcName, String szTarName )
	{
		CGameMain.g_GameMain.OnSpriteColSprite( szSrcName, szTarName );
	}
	
	/**
	* OnSpriteColWorldLimit������������߽���ײ�󽫱����õķ���
	* ����֮��Ҫ������ײ�������ڱ༭�����ߴ��������þ��������߽�����
	* @param ���� szName����ײ���߽�ľ�������
	* @param ���� iColSide����ײ���ı߽� 0 ��ߣ�1 �ұߣ�2 �ϱߣ�3 �±�
	*/	
	public void	OnSpriteColWorldLimit( String szName, int iColSide )
	{
		CGameMain.g_GameMain.OnSpriteColWorldLimit( szName, iColSide );
	}
}
