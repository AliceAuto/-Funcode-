/**
 * @(#)EngineCall.java
 *
 *
 * @author
 * @version 1.00
 */

package FunCode;

public interface EngineCall {
	/**
	 * OnMouseMove：鼠标移动后将被调用的函数，可在此函数体里(Main.cpp)增加自己的响应代码
	 * @param 参数 fMouseX:为鼠标当前坐标
	 * @param 参数fMouseY：为鼠标当前坐标
	 */
    public abstract void	OnMouseMove( float fMouseX, float fMouseY );
    /**
     * OnMouseClick：鼠标按下后将被调用的函数，可在此函数体里(Main.cpp)增加自己的响应代码
     * @param 参数 iMouseType：鼠标按键值，见 enum MouseTypes 定义
     * @param 参数fMouseX：为鼠标当前坐标
     * @param 参数fMouseY：为鼠标当前坐标
     */
	public abstract void	OnMouseClick( int iMouseType, float fMouseX, float fMouseY );
	/**
	 * OnMouseUp：鼠标按下后将被调用的函数，可在此函数体里(Main.cpp)增加自己的响应代码
	 * @param 参数 iMouseType：鼠标按键值，见 enum MouseTypes 定义
	 * @param 参数 fMouseX：为鼠标当前坐标
	 * @param 参数 fMouseY：为鼠标当前坐标
	 */
	public abstract void	OnMouseUp( int iMouseType, float fMouseX, float fMouseY );
	/**
	 * OnKeyDown：键盘被按下后将被调用的函数，可在此函数体里(Main.cpp)增加自己的响应代码
	 * @param 参数 iKey：被按下的键，值见 enum KeyCodes 宏定义
	 * @param 参数 bAltPress：键盘上的功能键Alt，Ctrl，Shift当前是否也处于按下状态
	 * @param 参数bShiftPress：键盘上的功能键Alt，Ctrl，Shift当前是否也处于按下状态
	 * @param 参数 bCtrlPress：键盘上的功能键Alt，Ctrl，Shift当前是否也处于按下状态
	 */
    public abstract void	OnKeyDown( int iKey, boolean bAltPress, boolean bShiftPress, boolean bCtrlPress );
    /**
     * OnKeyUp：键盘按键弹起后将被调用的函数，可在此函数体里(Main.cpp)增加自己的响应代码
     * @param 参数 iKey：弹起的键，值见 enum KeyCodes 宏定义
     */
	public abstract void	OnKeyUp( int iKey );
	/**
	 * OnSpriteColSprite：精灵与精灵碰撞后将被调用的函数，可在此函数体里(Main.cpp)增加自己的响应代码
	 * @param 参数 szSrcName：发起碰撞的精灵名字
	 * @param 参数 szTarName：被碰撞的精灵名字
	 */
	public abstract void	OnSpriteColSprite( String szSrcName, String szTarName );

	/**
	 * OnSpriteColWorldLimit：精灵与世界边界碰撞后将被调用的函数，可在此函数体里(Main.cpp)增加自己的响应代码
	 * @param 参数 szName：碰撞到边界的精灵名字
	 * @param 参数 iColSide：碰撞到的边界 0 左边，1 右边，2 上边，3 下边
	 */
	public abstract void	OnSpriteColWorldLimit( String szName, int iColSide );
}
