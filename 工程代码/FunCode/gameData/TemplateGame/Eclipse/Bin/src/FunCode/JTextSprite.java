/**
 * @(#)JTextSprite.java
 *
 * JTextSprite application
 *
 * @author
 * @version 1.00
 */

 package FunCode;

 import FunCode.EngineAPI;
/**
 * 类：JTextSprite
 * 文字精灵，亦属于精灵中的一种。基本用法：在地图里摆放一个“文字”物体，起个名字
 * 然后在代码里定义一个文字精灵的对象实例，将此名字做为构造函数的参数，然后调用对应的成员函数更新文字显示即可
 * @author root
 *
 */
public	class JTextSprite extends JSprite
{
	/**
	 * 构造函数，需要传入一个非空的精灵名字字符串。如果传入的是地图里摆放好的精灵名字，则此类即与地图里的精灵绑定
	 * 如果传入的是一个新的精灵名字，则需要调用成员函数 CloneSprite，复制一份精灵对象实例，才与实际的地图精灵关联起来
	 * @param 参数szName:精灵名字
	 */
	public	JTextSprite( String szName )
	{
		super( szName );
	}

	/**
	 * SetTextValue：文字精灵显示某个数值
	 * @param 参数 iValue：要显示的数值
	 */
	public	void		SetTextValue( int iValue )
	{
		EngineAPI.SetTextValue( GetName(),  iValue );
	}

	/**
	 * SetTextValueFloat：文字精灵显示某个浮点数值
	 * @param 参数 fValue：要显示的数值
	 */
	public	void		SetTextValueFloat( float fValue )
	{
		EngineAPI.SetTextValueFloat( GetName(),  fValue );
	}

	/**
	 * SetTextString：文字精灵显示某个字符串文字
	 * @param 参数 szStr：要显示的字符串
	 */
	public	void		SetTextString( String szStr )
	{
		EngineAPI.SetTextString(  GetName(), szStr );
	}
};