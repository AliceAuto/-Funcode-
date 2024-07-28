using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

///////////////////////////////////////////////////////////////////////////////
//
///////////////////////////////////////////////////////////////////////////////

/// <summary>
/// CStaticSprite
/// 静态精灵(静态图片显示)，从CSprite精灵基类继承下来，比基类多了几个控制精灵图片显示的函数
/// </summary>
public class CStaticSprite : CSprite
{
	public	CStaticSprite( string szName ) : base(szName)
	{
	}

	/// <summary>
	/// SetStaticSpriteImage：设置/更改静态精灵的显示图片
	/// 参数 szImageName：图片名字
	/// 参数 iFrame：该图片的显示帧数。为编辑器预览图里显示的1/N，范围为 0 到 N - 1
	/// </summary>
	/// <param name="szImageName"></param>
	/// <param name="iFrame"></param>
	public	void		SetStaticSpriteImage( string szImageName,  int iFrame )
	{
		CommonAPI.dSetStaticSpriteImage( GetName(), szImageName, iFrame );
	}

	/// <summary>
	/// SetStaticSpriteFrame：设置静态精灵当前图片的显示帧数
	/// 参数 iFrame：该图片的显示帧数。为编辑器预览图里显示的1/N，范围为 0 到 N - 1
	/// </summary>
	/// <param name="iFrame"></param>
	public	void		SetStaticSpriteFrame(  int iFrame )
	{
		CommonAPI.dSetStaticSpriteFrame( GetName(), iFrame );
	}
	
	/// <summary>
	/// GetStaticSpriteImage：获取精灵当前显示的图片名字
	/// 返回值：图片名字
	/// </summary>
	/// <returns></returns>
	public	string  GetStaticSpriteImage()
	{
		return CommonAPI.dGetStaticSpriteImage( GetName() );
	}
 
	/// <summary>
	/// GetStaticSpriteFrame：获取精灵当前显示的图片帧数
	/// 返回值：帧数
	/// </summary>
	/// <returns></returns>
	public	int			GetStaticSpriteFrame()
	{
		return CommonAPI.dGetStaticSpriteFrame( GetName() );
	}
};