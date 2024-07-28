using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//////////////////////////////////////////////////////////////////////////////
//
/////////////////////////////////////////////////////////////////////////////

/// <summary>
/// �ࣺCAnimateSprite
/// ��̬����(��ͼƬ����)����CSprite�������̳��������Ȼ�����˼�������ͼƬ�����ĺ���
/// </summary>
public class CAnimateSprite : CSprite
{
    /// <summary>
    /// ���캯�� 
    /// </summary>
    public CAnimateSprite(string szName) : base(szName)
    {
    }
    
	/// <summary>
	/// SetAnimateSpriteFrame�����ö�̬����Ķ���֡��
    /// ���� iFrame������֡��
	/// </summary>
	public void		SetAnimateSpriteFrame( int iFrame )
	{
		CommonAPI.dSetAnimateSpriteFrame( GetName(), iFrame );
	}

	/// <summary>
    /// GetAnimateSpriteAnimationName����ȡ��̬���鵱ǰ��������
    /// ����ֵ����������
	/// </summary>
    public string GetAnimateSpriteAnimationName()
	{
        return CommonAPI.dGetAnimateSpriteAnimationName(GetName());
	}

	/// <summary>
    /// GetAnimateSpriteAnimationTime����ȡ�������鵱ǰ����ʱ�䳤��
    /// ����ֵ�����ȣ���λ��
	/// </summary>
    public float GetAnimateSpriteAnimationTime()
	{
        return CommonAPI.dGetAnimateSpriteAnimationTime(GetName());
	}

	/// <summary>
    /// IsAnimateSpriteAnimationFinished���ж϶�̬���鵱ǰ�����Ƿ񲥷���ϣ�ֻ��Է�ѭ����������
    /// ����ֵ��true ��� false δ���
	/// </summary>
    public bool IsAnimateSpriteAnimationFinished()
	{
        return (CommonAPI.dIsAnimateSpriteAnimationFinished(GetName()) == 0 ? false : true);
	}
    
	/// <summary>
    /// AnimateSpritePlayAnimation���������鲥�Ŷ���
    /// ���� szAnim����������
    /// ���� bRestore��������Ϻ��Ƿ�ָ���ǰ����
    /// ����ֵ���Ƿ񲥷ųɹ�
	/// </summary>
    public bool AnimateSpritePlayAnimation( string szAnim, bool bRestore)
	{
        return (CommonAPI.dAnimateSpritePlayAnimation(GetName(), szAnim, bRestore ? 1 : 0) == 0 ? false : true);
	}
};