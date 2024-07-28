/**
 * @(#)JAnimateSprite.java
 *
 * JAnimateSprite application
 *
 * @author
 * @version 1.00
 */

 package FunCode;

 import FunCode.EngineAPI;
/**
 * 类：JAnimateSprite
 * 动态精灵(带图片动画)，从JSprite精灵基类继承下来，比基类多了几个控制图片动画的函数
 * @author root
 *
 */
public	class JAnimateSprite extends JSprite
{
	public	JAnimateSprite( String szName )
	{
		super( szName );
	}


	/**
	 * SetAnimateSpriteFrame：设置动态精灵的动画帧数
	 * @param 参数 iFrame：动画帧数
	 */
	public	void		SetAnimateSpriteFrame(  int iFrame )
	{
		EngineAPI.SetAnimateSpriteFrame( GetName(), iFrame );
	}

	/**
	 * GetAnimateSpriteAnimationName：获取动态精灵当前动画名字
	 * @return 返回值：动画名字
	 */
	public	String  GetAnimateSpriteAnimationName()
	{
		return EngineAPI.GetAnimateSpriteAnimationName( GetName() );
	}

	/**
	 * GetAnimateSpriteAnimationTime：获取动画精灵当前动画时间长度
	 * @return 返回值：长度，单位秒
	 */
	public	float		GetAnimateSpriteAnimationTime()
	{
		return EngineAPI.GetAnimateSpriteAnimationTime( GetName() );
	}

	/**
	 * IsAnimateSpriteAnimationFinished：判断动态精灵当前动画是否播放完毕，只针对非循环动画而言
	 * @return 返回值：true 完毕 false 未完毕
	 */
	public	boolean		IsAnimateSpriteAnimationFinished()
	{
		return EngineAPI.IsAnimateSpriteAnimationFinished( GetName() );
	}

	/**
	 * AnimateSpritePlayAnimation：动画精灵播放动画
	 * @param 参数 szAnim：动画名字
	 * @param 参数 bRestore：播放完毕后是否恢复当前动画
	 * @return 返回值：是否播放成功
	 */
	public	boolean		AnimateSpritePlayAnimation( String szAnim,  boolean bRestore )
	{
		return EngineAPI.AnimateSpritePlayAnimation( GetName(), szAnim, bRestore );
	}
};