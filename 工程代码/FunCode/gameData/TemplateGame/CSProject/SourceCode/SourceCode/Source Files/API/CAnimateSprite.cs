using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//////////////////////////////////////////////////////////////////////////////
//
/////////////////////////////////////////////////////////////////////////////

/// <summary>
/// 类：CAnimateSprite
/// 动态精灵(带图片动画)，从CSprite精灵基类继承下来，比基类多了几个控制图片动画的函数
/// </summary>
public class CAnimateSprite : CSprite
{
    /// <summary>
    /// 构造函数 
    /// </summary>
    public CAnimateSprite(string szName) : base(szName)
    {
    }
    
	/// <summary>
	/// SetAnimateSpriteFrame：设置动态精灵的动画帧数
    /// 参数 iFrame：动画帧数
	/// </summary>
	public void		SetAnimateSpriteFrame( int iFrame )
	{
		CommonAPI.dSetAnimateSpriteFrame( GetName(), iFrame );
	}

	/// <summary>
    /// GetAnimateSpriteAnimationName：获取动态精灵当前动画名字
    /// 返回值：动画名字
	/// </summary>
    public string GetAnimateSpriteAnimationName()
	{
        return CommonAPI.dGetAnimateSpriteAnimationName(GetName());
	}

	/// <summary>
    /// GetAnimateSpriteAnimationTime：获取动画精灵当前动画时间长度
    /// 返回值：长度，单位秒
	/// </summary>
    public float GetAnimateSpriteAnimationTime()
	{
        return CommonAPI.dGetAnimateSpriteAnimationTime(GetName());
	}

	/// <summary>
    /// IsAnimateSpriteAnimationFinished：判断动态精灵当前动画是否播放完毕，只针对非循环动画而言
    /// 返回值：true 完毕 false 未完毕
	/// </summary>
    public bool IsAnimateSpriteAnimationFinished()
	{
        return (CommonAPI.dIsAnimateSpriteAnimationFinished(GetName()) == 0 ? false : true);
	}
    
	/// <summary>
    /// AnimateSpritePlayAnimation：动画精灵播放动画
    /// 参数 szAnim：动画名字
    /// 参数 bRestore：播放完毕后是否恢复当前动画
    /// 返回值：是否播放成功
	/// </summary>
    public bool AnimateSpritePlayAnimation( string szAnim, bool bRestore)
	{
        return (CommonAPI.dAnimateSpritePlayAnimation(GetName(), szAnim, bRestore ? 1 : 0) == 0 ? false : true);
	}
};