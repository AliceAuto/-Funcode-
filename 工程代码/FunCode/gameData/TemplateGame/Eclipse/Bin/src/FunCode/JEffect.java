/**
 * @(#)JEffect.java
 *
 * JEffect application
 *
 * @author
 * @version 1.00
 */

 package FunCode;

 import FunCode.EngineAPI;
/**
 * 类：JEffect
 * 特效精灵，属于精灵中的一种。用法和文字精灵一样，先在地图里摆放一个特效做为模板，并命名
 * 然后在代码里定义一个特效精灵的对象实例即可使用
 * @author root
 *
 */
public	class JEffect extends JSprite
{
	private String		m_szCloneName;		// 在地图中预先摆放好的用做克隆的特效名字
	private float		m_fTime;			// 非循环特效：生命时长；循环特效：循环时长

	/**
	 * 构造函数
	 * @param 参数 szCloneName：地图里摆放好的特效名字
	 * @param 参数 szMyName：新的特效名字。注意：如果是循环特效，那么必须一个循环特效就定义一个对象实例，用不同的名否则如果一个同名的循环特效被播放多次，在删除的时候会出问题。非循环特效则可以用一个实例多次播放
	 * @param 参数 fTime：非循环特效：生命时长；循环特效：循环时长
	 */
	public	JEffect( String szCloneName, String szMyName, float fTime )
	{
		super( szMyName );

		m_szCloneName = szCloneName;
		m_fTime = fTime;
	}

	/**
	 * GetCloneName：获取用做克隆的特效名字
	 * @return 返回克隆的名称
	 */
	public	String 	GetCloneName()
	{
		return m_szCloneName;
	}

	/**
	 * GetTime：返回特效循环时长或者生命时长
	 * @return 返回时间
	 */
	public	float		GetTime()
	{
		return m_fTime;
	}

	/**
	 * PlayEffect：播放一个不循环的特效，播放完毕之后该特效自动删除
	 * 播放非循环特效的时候，可以使用一个CEffect的对象实例，播放多个特效
	 * @param 参数 fPosX：播放的X坐标
	 * @param 参数 fPosY：播放的Y坐标
	 * @param 参数 fRotation：播放的角度朝向
	 */
	public	void		PlayEffect(  float fPosX,  float fPosY,  float fRotation)
	{
		EngineAPI.PlayEffect( GetCloneName(), GetTime(), fPosX, fPosY, fRotation );
	}

	/**
	 * PlayLoopEffect：播放一个循环特效，不需要该特效的时候，需要自己调用API进行删除
	 * @param 参数 fPosX：播放的X坐标
	 * @param 参数 fPosY：播放的Y坐标
	 * @param 参数 fRotation：播放的角度朝向
	 */
	public	void		PlayLoopEffect(  float fPosX,  float fPosY,  float fRotation)
	{
		EngineAPI.PlayLoopEffect( GetCloneName(), GetName(), GetTime(), fPosX, fPosY, fRotation );
	}

	/**
	 * DeleteEffect：删除一个正在播放的特效，只有循环特效才需要手动删除
	 */
	public	void		DeleteEffect()
	{
		EngineAPI.DeleteEffect( GetName() );
	}
};