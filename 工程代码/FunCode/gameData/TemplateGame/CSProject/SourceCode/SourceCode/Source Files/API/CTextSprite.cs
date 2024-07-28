using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//////////////////////////////////////////////////////////////////////////////
//
//////////////////////////////////////////////////////////////////////////////

/// <summary>
/// 类：CSTextSprite
/// 文字精灵，亦属于精灵中的一种。基本用法：在地图里摆放一个“文字”物体，起个名字
/// 然后在代码里定义一个文字精灵的对象实例，将此名字做为构造函数的参数，然后调用对应的成员函数更新文字显示即可
/// </summary>
public class CTextSprite : CSprite
{
	public	CTextSprite( string szName ) : base(szName)
	{
	}

	/// <summary>
	/// SetTextValue：文字精灵显示某个数值
	/// 参数 iValue：要显示的数值
	/// </summary>
	/// <param name="iValue"></param>
	public	void		SetTextValue( int iValue )
	{
		CommonAPI.dSetTextValue( GetName(),  iValue );
	}

    /// <summary>
	/// SetTextValueFloat：文字精灵显示某个浮点数值
	/// 参数 fValue：要显示的数值
	/// </summary>
	/// <param name="fValue"></param>
	public	void		SetTextValueFloat( float fValue )
	{
		CommonAPI.dSetTextValueFloat( GetName(),  fValue );
	}

	/// <summary>
	/// SetTextstring：文字精灵显示某个字符串文字
	/// 参数 szStr：要显示的字符串
	/// </summary>
	/// <param name="szStr"></param>
	public	void		SetTextstring( string szStr )
	{
		CommonAPI.dSetTextstring(  GetName(), szStr );
	}
};