﻿/**
 * @(#)JStaticSprite.java
 *
 * JStaticSprite application
 *
 * @author
 * @version 1.00
 */

 package FunCode;

 import FunCode.EngineAPI;
/**
 * JStaticSprite
 * 静态精灵(静态图片显示)，从CSprite精灵基类继承下来，比基类多了几个控制精灵图片显示的函数
 * @author root
 *
 */
public	class JStaticSprite extends JSprite
{
	public	JStaticSprite( String szName )
	{
		super( szName );
	}

	/**
	 * SetStaticSpriteImage：设置/更改静态精灵的显示图片
	 * @param 参数 szImageName：图片名字
	 * @param 参数 iFrame：该图片的显示帧数。为编辑器预览图里显示的1/N，范围为 0 到 N - 1
	 */
	public	void		SetStaticSpriteImage( String szImageName,  int iFrame )
	{
		EngineAPI.SetStaticSpriteImage( GetName(), szImageName, iFrame );
	}

	/**
	 * SetStaticSpriteFrame：设置静态精灵当前图片的显示帧数
	 * @param 参数 iFrame：该图片的显示帧数。为编辑器预览图里显示的1/N，范围为 0 到 N - 1
	 */
	public	void		SetStaticSpriteFrame(  int iFrame )
	{
		EngineAPI.SetStaticSpriteFrame( GetName(), iFrame );
	}

	/**
	 * GetStaticSpriteImage：获取精灵当前显示的图片名字
	 * @return 返回值：图片名字
	 */
	public	String  GetStaticSpriteImage()
	{
		return EngineAPI.GetStaticSpriteImage( GetName() );
	}

	/**
	 * GetStaticSpriteFrame：获取精灵当前显示的图片帧数
	 * @return 返回值：帧数
	 */
	public	int			GetStaticSpriteFrame()
	{
		return EngineAPI.GetStaticSpriteFrame( GetName() );
	}
};