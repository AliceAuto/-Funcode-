/**
 * @(#)EngineInterface.java
 *
 *
 * @author 
 * @version 1.00
 */

 
 import FunCode.EngineCall;
 
// 请勿修改此JAVA文件里的任何内容
// 鼠标键盘响应、精灵碰撞响应等由引擎触发并调用的接口
// 不能自己使用EngineInterface这个类定义实例
//
public class EngineInterface implements EngineCall 
{    	

	// OnMouseMove：鼠标移动后将被调用的方法
	// 参数 fMouseX, fMouseY：为鼠标当前坐标
	//
    public void	OnMouseMove( float fMouseX, float fMouseY )
	{
		CGameMain.g_GameMain.OnMouseMove( fMouseX, fMouseY );
	}
	
	// OnMouseClick：鼠标按下后将被调用的方法
	// 参数 iMouseType：鼠标按键值，见 MouseTypes 定义
	// 参数 fMouseX, fMouseY：为鼠标当前坐标
	//	
	public void	OnMouseClick( int iMouseType, float fMouseX, float fMouseY )
	{		
		CGameMain.g_GameMain.OnMouseClick( iMouseType, fMouseX, fMouseY );
	}
	
	// OnMouseUp：鼠标弹起后将被调用的方法
	// 参数 iMouseType：鼠标按键值，见 MouseTypes 定义
	// 参数 fMouseX, fMouseY：为鼠标当前坐标
	//	
	public void	OnMouseUp( int iMouseType, float fMouseX, float fMouseY )
	{		
		CGameMain.g_GameMain.OnMouseClick( iMouseType, fMouseX, fMouseY );
	}
    
	// OnKeyDown：键盘被按下后将被调用的方法
	// 参数 iKey：被按下的键，值见 KeyCodes 宏定义
	// 参数 bAltPress, bShiftPress，bCtrlPress：键盘上的功能键Alt，Ctrl，Shift当前是否也处于按下状态
	//    
    public void	OnKeyDown( int iKey, boolean bAltPress, boolean bShiftPress, boolean bCtrlPress )
    {
    	CGameMain.g_GameMain.OnKeyDown( iKey, bAltPress, bShiftPress, bCtrlPress );
    }
    
	// OnKeyUp：键盘按键弹起后将被调用的方法
	// 参数 iKey：弹起的键，值见 KeyCodes 宏定义
	//    
	public void	OnKeyUp( int iKey )
	{
		CGameMain.g_GameMain.OnKeyUp( iKey );
	}
	
	// OnSpriteColSprite：精灵与精灵碰撞后将被调用的方法
	// 精灵之间要产生碰撞，必须在编辑器或者代码里设置精灵发送及接受碰撞
	// 参数 szSrcName：发起碰撞的精灵名字
	// 参数 szTarName：被碰撞的精灵名字
	//	
	public void	OnSpriteColSprite( String szSrcName, String szTarName )
	{
		CGameMain.g_GameMain.OnSpriteColSprite( szSrcName, szTarName );
	}
	
	// OnSpriteColWorldLimit：精灵与世界边界碰撞后将被调用的方法
	// 精灵之间要产生碰撞，必须在编辑器或者代码里设置精灵的世界边界限制
	// 参数 szName：碰撞到边界的精灵名字
	// 参数 iColSide：碰撞到的边界 0 左边，1 右边，2 上边，3 下边
	//	
	public void	OnSpriteColWorldLimit( String szName, int iColSide )
	{
		CGameMain.g_GameMain.OnSpriteColWorldLimit( szName, iColSide );
	}
}
