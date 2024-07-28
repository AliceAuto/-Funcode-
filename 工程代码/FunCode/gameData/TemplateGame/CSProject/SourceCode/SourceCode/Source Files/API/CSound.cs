using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/////////////////////////////////////////////////////////////////////////////
//
/////////////////////////////////////////////////////////////////////////////

/// <summary>
/// 类：CSSound
/// 播放声音的类，定义一个对象实例，调用播放函数即可实现声音的播放
/// </summary>
public	class CSound
{
	private string		m_szName;	// 声音名
	private int			m_iSoundId;	// 引擎播放声音的时候，返回的ID
	private bool		m_bLoop;	// bLoop : 是否循环播放。如果为循环音效，则在CSound实例析构的时候，自动调用StopSound停止此声音的播放
	private float		m_fVolume;	// 音量大小，0-1。1为声音文件的原声大小
 
	/// <summary>
	/// 构造函数
	/// 参数 szName：声音的路径及名称，具体值请在编辑器的资源 -> 添加声音那里查看本项目里的声音资源，完整按照那个路径值填写即可
	/// 参数 bLoop：是否循环播放。如果是循环播放的声音，需要手动调用API停止播放
	/// 参数 fVolume：音量大小，0-1。1为声音文件的原声大小
	/// </summary>
	public	CSound( string szName,  bool bLoop,  float fVolume )
	{
		m_bLoop		=	bLoop;
		m_fVolume	=	fVolume;
		m_iSoundId	=	0;
		m_szName	=	szName;
	}

	/// <summary>
	/// GetName：获取声音名字
	/// </summary>
	public	string GetName()
	{
		return m_szName;
	}

	/// <summary>
	/// PlaySound：播放该声音
	/// </summary>
	public	void		PlaySound()
	{
		if( m_bLoop && 0 != m_iSoundId )
			StopSound();

        m_iSoundId = CommonAPI.dPlaySound(GetName(), m_bLoop ? 1 : 0, m_fVolume);
	}

	/// <summary>
	/// StopSound：停止该声音的播放
	/// 非循环的播放完之后将自动停止，所以一般不需要调用此函数。只有循环的声音才需要调用。对于循环音效，在析构函数里也会自动调用此函数 
	/// </summary>
	public	void		StopSound()
	{
		CommonAPI.dStopSound( m_iSoundId );

		m_iSoundId = 0;
	}

	/// <summary>
	/// StopAllSound：停止播放所有声音
	/// 静态函数，可以以此种方式调用：CSound::StopAllSound，以停止游戏中所有正在播放的声音
	/// </summary>
	public	static void	StopAllSound()
	{
        CommonAPI.dStopAllSound();
	}
};