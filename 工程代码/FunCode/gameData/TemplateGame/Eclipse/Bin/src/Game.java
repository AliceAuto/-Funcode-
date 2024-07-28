/**
 * @(#)Game.java
 *
 *
 * @author 
 * @version 1.00
 */
import FunCode.JSystem;

public class Game 
{
	// �������
    public static void main(String[] args) 
    {    	
    	// ����һ��ʵ����������Ӧ����Ľӿڻص�
		EngineInterface g_EngineInterface = new EngineInterface();

		// ��ʼ����Ϸ����
		if( !JSystem.InitGameEngine( g_EngineInterface, args ) )
			return;
			
		// �ڴ�ʹ��API���Ĵ��ڱ���
		JSystem.SetWindowTitle("Lesson");	
			
		// ������ѭ����������Ļͼ��ˢ�µȹ���
		while( JSystem.EngineMainLoop() )
		{
			// ��ȡ���ε���֮���ʱ�����ݸ���Ϸ�߼�����
			float	fTimeDelta	=	JSystem.GetTimeDelta();
	
			// ִ����Ϸ��ѭ��
			CGameMain.g_GameMain.GameMainLoop( fTimeDelta );
		};
		
		// �ر���Ϸ����
		JSystem.ShutdownGameEngine();
    }
    
}

