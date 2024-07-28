using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//////////////////////////////////////////////////////////////////////////////
//
//////////////////////////////////////////////////////////////////////////////

/// <summary>
/// �ࣺCSprite
/// ���о���Ļ��ࡣ��������ľ�̬���飬��̬���飬���֣���Ч�Ⱦ��ɴ���̳���ȥ
/// һ���ͼƬ����ӱ���̳���ȥ���ɡ�ֻ������ľ��飬����������ľ��飬����Ҫ�Ӷ�̬����̳���ȥ
/// </summary>
public class CSprite
{
    private string m_szName;		// ��������

	/// <summary>
    /// ���캯������Ҫ����һ���ǿյľ��������ַ��������������ǵ�ͼ��ڷźõľ������֣�����༴���ͼ��ľ����
	/// ����������һ���µľ������֣�����Ҫ���ó�Ա���� CloneSprite������һ�ݾ������ʵ��������ʵ�ʵĵ�ͼ�����������
    /// </summary>
    public CSprite(string szName)
	{
		m_szName = szName;
	}

    /// <summary>
    /// GetName
	/// ����ֵ�����ؾ�������
    /// </summary>
    public string GetName()
	{
		return m_szName;
	}
    
	/// <summary>
	/// CloneSprite������(����)һ�����顣����Ĵ�����ʽ�����ڵ�ͼ�аڷ�һ��������Ϊģ�壬���úø��������Ȼ���ڴ�����ʹ�ô˺�����¡һ��ʵ��
	/// ����ֵ��true��ʾ��¡�ɹ���false��¡ʧ�ܡ�ʧ�ܵ�ԭ��������ڵ�ͼ��δ�ҵ���Ӧ���ֵľ���
	/// ���� szSrcName����ͼ������ģ��ľ�������
	/// </summary>
    public bool CloneSprite(string szSrcName)
	{
		return CommonAPI.dCloneSprite( szSrcName, GetName() ) == 0 ? false : true;
	}

	/// <summary>
	/// DeleteSprite���ڵ�ͼ��ɾ���뱾����ʵ�������ľ���
	/// </summary>
	public void		DeleteSprite()
	{
		CommonAPI.dDeleteSprite( GetName() );
	}

	/// <summary>
	/// SetSpriteVisible�����þ������ػ�����ʾ(�ɼ����ɼ�)
    /// ���� bVisible��true �ɼ� false���ɼ�
	/// </summary>
    public void SetSpriteVisible(bool bVisible)
	{
		CommonAPI.dSetSpriteVisible( GetName(), bVisible ? 1 : 0 );
	}

	/// <summary>
	/// IsSpriteVisible����ȡ�þ��鵱ǰ�Ƿ�ɼ�
	/// </summary>
    public bool IsSpriteVisible()
	{
		return CommonAPI.dIsSpriteVisible( GetName() ) == 0 ? false : true;
	}

	/// <summary>
	/// SetSpriteEnable����ֹ�������øþ��顣����ֹ�ľ��齫�������κ���Ӧ���������ƶ���û����ײ�ȣ��������ڵ�ͼ����ʾ
	/// ���� bEnable��true���� false��ֹ
	/// </summary>
    public void SetSpriteEnable(bool bEnable)
	{
		CommonAPI.dSetSpriteEnable( GetName(), bEnable ? 1 : 0 );
	}

	/// <summary>
	/// SetSpriteScale�����þ��������ֵ
	/// ���� fScale������ֵ������0��ֵ
	/// </summary>
	public void		SetSpriteScale(  float fScale )
	{
		CommonAPI.dSetSpriteScale( GetName(), fScale );
	}

	/// <summary>
	/// IsPointInSprite���ж�ĳ��������Ƿ�λ�ھ����ڲ�
	/// ���� fPosX��X�����
	/// ���� fPosY��Y�����
	/// </summary>
    public bool IsPointInSprite(float fPosX, float fPosY)
	{
		return CommonAPI.dIsPointInSprite( GetName(), fPosX, fPosY ) == 0 ? false : true;
	}

	/// <summary>
	/// SetSpritePosition�����þ���λ��
	/// ���� fPosX��X����
	/// ���� fPosY��Y����
	/// </summary>
	public void		SetSpritePosition(  float fPosX,  float fPosY )
	{
		CommonAPI.dSetSpritePosition( GetName(), fPosX, fPosY );
	}

	/// <summary>
	/// SetSpritePositionX��ֻ���þ���X����
	/// ���� fPosX��X����
	/// </summary>
	public void		SetSpritePositionX(  float fPosX )
	{
		CommonAPI.dSetSpritePositionX( GetName(), fPosX );
	}

	/// <summary>
	/// SetSpritePositionY��ֻ���þ���Y����
	/// ���� fPosY��Y����
	/// </summary>
	public void		SetSpritePositionY(  float fPosY )
	{
		CommonAPI.dSetSpritePositionY( GetName(), fPosY );
	}

	/// <summary>
	/// GetSpritePositionX����ȡ����X����
	/// ����ֵ�������X����
	/// </summary>
	public float		GetSpritePositionX()
	{
		return CommonAPI.dGetSpritePositionX( GetName() );
	}

	/// <summary>
	/// GetSpritePositionY����ȡ����Y����
	/// ����ֵ�������Y����
	/// </summary>
	public float		GetSpritePositionY()
	{
		return CommonAPI.dGetSpritePositionY( GetName() );
	}

	/// <summary>
	/// GetSpriteLinkPointPosX����ȡ�������ӵ�X���ꡣ���ӵ��������ھ����һ������㣬�����ڱ༭�������ӻ���ɾ��
	/// ���� iId�����ӵ���ţ���һ��Ϊ1���������εݼ�
	/// </summary>
	public float		GetSpriteLinkPointPosX(  int iId )
	{
		return CommonAPI.dGetSpriteLinkPointPosX( GetName(), iId );
	}

	/// <summary>
	/// GetSpriteLinkPointPosY����ȡ�������ӵ�Y���ꡣ���ӵ��������ھ����һ������㣬�����ڱ༭�������ӻ���ɾ��
	/// ���� iId�����ӵ���ţ���һ��Ϊ1���������εݼ�
	/// </summary>
	public float		GetSpriteLinkPointPosY(  int iId )
	{
		return CommonAPI.dGetSpriteLinkPointPosY( GetName(), iId );
	}

	/// <summary>
	/// SetSpriteRotation�����þ������ת�Ƕ�
	/// ���� fRot����ת�Ƕȣ���Χ0 - 360
	/// </summary>
	public void		SetSpriteRotation(  float fRot )
	{
		CommonAPI.dSetSpriteRotation( GetName(), fRot );
	}

	/// <summary>
	/// GetSpriteRotation����ȡ�������ת�Ƕ�
	/// ����ֵ���������ת�Ƕ�
	/// </summary>
	public float		GetSpriteRotation()
	{
		return CommonAPI.dGetSpriteRotation( GetName() );
	}

	/// <summary>
	/// SetSpriteAutoRot�����þ��鰴��ָ���ٶ��Զ���ת
	/// ���� fRotSpeed����ת�ٶ�
	/// </summary>
	public void 		SetSpriteAutoRot(  float fRotSpeed )
	{
		CommonAPI.dSetSpriteAutoRot( GetName(), fRotSpeed );
	}

	/// <summary>
	/// SetSpriteWidth�����þ������ο��
	/// ���� fWidth�����ֵ������0
	/// </summary>
	public void		SetSpriteWidth(  float fWidth )
	{
		CommonAPI.dSetSpriteWidth( GetName(), fWidth );
	}

	/// <summary>
	/// GetSpriteWidth����ȡ�������ο��
	/// ����ֵ��������ֵ
	/// </summary>
	public float		GetSpriteWidth()
	{
		return CommonAPI.dGetSpriteWidth( GetName() );
	}

	/// <summary>
	/// SetSpriteHeight�����þ������θ߶�
	/// ���� fHeight������߶�ֵ
	/// </summary>
	public void		SetSpriteHeight(  float fHeight )
	{
		CommonAPI.dSetSpriteHeight( GetName(), fHeight );
	}

	/// <summary>
	/// GetSpriteHeight����ȡ�������θ߶�
	/// ����ֵ������߶�ֵ
	/// </summary>
	public float		GetSpriteHeight()
	{
		return CommonAPI.dGetSpriteHeight( GetName() );
	}

	/// <summary>
	/// SetSpriteFlipX�����þ���ͼƬX����ת��ʾ
	/// ���� bFlipX��true ��ת false����ת(�ָ�ԭ������)
	/// </summary>
	public void		SetSpriteFlipX( bool bFlipX )
	{
		CommonAPI.dSetSpriteFlipX( GetName(), bFlipX ? 1 : 0 );
	}

	/// <summary>
	/// GetSpriteFlipX����ȡ��ǰ����ͼƬX�����Ƿ��Ƿ�ת��ʾ
	/// ����ֵ��true ��ת false����ת
	/// </summary>
	public bool		GetSpriteFlipX()
	{
		return CommonAPI.dGetSpriteFlipX( GetName() ) == 0 ? false : true;
	}
	/// <summary>
	/// SetSpriteFlipY�����þ���ͼƬY����ת��ʾ
	/// ���� bFlipY��true ��ת false����ת(�ָ�ԭ������)
	/// </summary>
	public void		SetSpriteFlipY( bool bFlipY )
	{
		CommonAPI.dSetSpriteFlipY( GetName(), bFlipY ? 1 : 0 );
	}

	/// <summary>
	/// GetSpriteFlipY����ȡ��ǰ����ͼƬY�����Ƿ��Ƿ�ת��ʾ
	/// ����ֵ��true ��ת false����ת
	/// </summary>
	public bool		GetSpriteFlipY()
	{
        return CommonAPI.dGetSpriteFlipY(GetName()) == 0 ? false : true;
	}

	/// <summary>
	/// SetSpriteFlip��ͬʱ���þ��鷭תX��Y����
	/// ���� bFlipX��true ��ת false����ת(�ָ�ԭ������)
	/// ���� bFlipY��true ��ת false����ת(�ָ�ԭ������)
	/// </summary>
	public void		SetSpriteFlip( bool bFlipX, bool bFlipY )
	{
        CommonAPI.dSetSpriteFlip(GetName(), bFlipX ? 1 : 0, bFlipY ? 1 : 0);
	}

	/// <summary>
	/// SetSpriteLifeTime�����þ��������ʱ����ʱ�䵽��֮���Զ���ɾ��
	/// ���� fLifeTime������ʱ������λ ��
	/// </summary>
	public void		SetSpriteLifeTime(  float fLifeTime )
	{
		CommonAPI.dSetSpriteLifeTime( GetName(), fLifeTime );
	}

	/// <summary>
	/// GetSpriteLifeTime����ȡ��������ʱ��
	/// ����ֵ������ʱ������λ ��
	/// </summary>
	public float		GetSpriteLifeTime()
	{
		return CommonAPI.dGetSpriteLifeTime( GetName() );
	}
    
	/// <summary>
	/// SpriteMoveTo���þ��鰴�ո����ٶ��ƶ������������
	/// ���� fPosX���ƶ���Ŀ��X����ֵ
	/// ���� fPosY���ƶ���Ŀ��Y����ֵ
	/// ���� fSpeed���ƶ��ٶ�
	/// ���� bAutoStop���ƶ����յ�֮���Ƿ��Զ�ֹͣ
	/// </summary>
	public void		SpriteMoveTo(  float fPosX,  float fPosY,  float fSpeed, bool bAutoStop )
	{
        CommonAPI.dSpriteMoveTo(GetName(), fPosX, fPosY, fSpeed, bAutoStop ? 1 : 0);
	}

	/// <summary>
	/// SpriteRotateTo���þ��鰴�ո����ٶ���ת�������ĽǶ�
	/// ���� fRotation��������Ŀ����תֵ
	/// ���� fRotSpeed����ת�ٶ�
	/// ���� bAutoStop����ת���յ�֮���Ƿ��Զ�ֹͣ
	/// </summary>
	public void		SpriteRotateTo(  float fRotation,  float fRotSpeed, bool bAutoStop )
	{
        CommonAPI.dSpriteRotateTo(GetName(), fRotation, fRotSpeed, bAutoStop ? 1 : 0);
	}

	/// <summary>
	/// SetSpriteWorldLimit�����þ��������߽��������Ƽ���ײģʽ
	/// ���� Limit����ײ������߽�֮�����Ӧģʽ�����ΪOFF�����ǹر�����߽���ײ������ֵ�� EWorldLimit
	/// ���� fLeft���߽�����X����
	/// ���� fTop���߽���ϱ�Y����
	/// ���� fRight���߽���ұ�X����
	/// ���� fBottom���߽���±�Y����
	/// </summary>
	public void		SetSpriteWorldLimit(  EWorldLimit Limit,  float fLeft,  float fTop,  float fRight,  float fBottom )
	{
		CommonAPI.dSetSpriteWorldLimit( GetName(), Limit, fLeft, fTop, fRight, fBottom );
	}

	/// <summary>
	/// SetSpriteWorldLimitMode�����þ��������߽���ײģʽ
	/// ���� Limit����ײ������߽�֮�����Ӧģʽ�����ΪOFF�����ǹر�����߽���ײ������ֵ�� EWorldLimit
	/// </summary>
	public void		SetSpriteWorldLimitMode(  EWorldLimit Limit )
	{
		CommonAPI.dSetSpriteWorldLimitMode( GetName(), Limit );
	}

	/// <summary>
	/// SetSpriteWorldLimitMin�����þ��������߽��ϱ߼������������
	/// ���� fLeft���߽�����X����
	/// ���� fTop���߽���ϱ�Y����
	/// </summary>
	public void		SetSpriteWorldLimitMin(  float fLeft,  float fTop )
	{
		CommonAPI.dSetSpriteWorldLimitMin( GetName(), fLeft, fTop );
	}
    
	/// <summary>
	/// SetSpriteWorldLimitMax�����þ��������߽��±߼��ұ���������
	/// ���� fRight���߽���ұ�X����
	/// ���� fBottom���߽���±�Y����
	/// </summary>
	public void		SetSpriteWorldLimitMax(  float fRight,  float fBottom )
	{
		CommonAPI.dSetSpriteWorldLimitMax( GetName(), fRight, fBottom );
	}

	/// <summary>
	/// GetSpriteWorldLimitLeft����ȡ��������߽���߽�����
	/// </summary>
	public float floatGetSpriteWorldLimitLeft()
	{
		return CommonAPI.dGetSpriteWorldLimitLeft(GetName());
	}

	/// <summary>
	/// GetSpriteWorldLimitLeft����ȡ��������߽��ϱ߽�����
	/// </summary>
	public float GetSpriteWorldLimitTop()
	{
		return CommonAPI.dGetSpriteWorldLimitTop(GetName());
	}

	/// <summary>
	/// GetSpriteWorldLimitLeft����ȡ��������߽��ұ߽�����
	/// </summary>
	public float GetSpriteWorldLimitRight()
	{
		return CommonAPI.dGetSpriteWorldLimitRight(GetName());
	}

	/// <summary>
	/// GetSpriteWorldLimitLeft����ȡ��������߽��±߽�����
	/// </summary>
	public float GetSpriteWorldLimitBottom()
	{
		return CommonAPI.dGetSpriteWorldLimitBottom(GetName());
	}

	/// <summary>
	/// SetSpriteCollisionSend�����þ����Ƿ���Է���(����)��ײ
	/// �������ײ��ʽΪ����A�ƶ�������Bʱ�����A�ǿ��Բ�����ײ�ģ�B�ǿ��Խ�����ײ�ģ�����2������������ײ��������ײ��API�������á���������ײ����
	/// ���� bSend��true ���Բ��� false ������
	/// </summary>
	public void 		SetSpriteCollisionSend( bool bSend )
	{
        CommonAPI.dSetSpriteCollisionSend(GetName(), bSend ? 1 : 0);
	}

	/// <summary>
	/// SetSpriteCollisionReceive�����þ����Ƿ���Խ�����ײ
	/// �������ײ��ʽΪ����A�ƶ�������Bʱ�����A�ǿ��Բ�����ײ�ģ�B�ǿ��Խ�����ײ�ģ�����2������������ײ��������ײ��API�������á���������ײ����
	/// ���� bReceive��true ���Խ��� false ������
	/// </summary>
	public void 		SetSpriteCollisionReceive( bool bReceive )
	{
        CommonAPI.dSetSpriteCollisionReceive(GetName(), bReceive ? 1 : 0);
	}

	/// <summary>
	/// SetSpriteCollisionActive��ͬʱ���þ����Ƿ���Բ�����������ײ
	/// �������ײ��ʽΪ����A�ƶ�������Bʱ�����A�ǿ��Բ�����ײ�ģ�B�ǿ��Խ�����ײ�ģ�����2������������ײ��������ײ��API�������á���������ײ����
	/// ���� bSend��true ���Բ��� false ������
	/// ���� bReceive��true ���Խ��� false ������
	/// </summary>
	public void 		SetSpriteCollisionActive( bool bSend, bool bReceive )
	{
        CommonAPI.dSetSpriteCollisionActive(GetName(), bSend ? 1 : 0, bReceive ? 1 : 0);
	}

	/// <summary>
	/// SetSpriteCollisionPhysicsSend�����þ����Ƿ���Է���(����)��ײ
	/// ���� bSend��true ���Բ��� false ������
	/// </summary>
	public void 		SetSpriteCollisionPhysicsSend( bool bSend )
	{
        CommonAPI.dSetSpriteCollisionPhysicsSend(GetName(), bSend ? 1 : 0);
	}

	/// <summary>
	/// SetSpriteCollisionPhysicsReceive�����þ����Ƿ���Խ�����ײ
	/// ���� bReceive��true ���Խ��� false ������
	/// </summary>
	public void 		SetSpriteCollisionPhysicsReceive( bool bReceive )
	{
        CommonAPI.dSetSpriteCollisionPhysicsReceive(GetName(), bReceive ? 1 : 0);
	}

	/// <summary>
	/// GetSpriteCollisionSend����ȡ���鵱ǰ�Ƿ��ǿ��Բ�����ײ
	/// ����ֵ��true ���Բ��� false ������
	/// </summary>
	public bool 		GetSpriteCollisionSend()
	{
		return CommonAPI.dGetSpriteCollisionSend( GetName() ) == 0 ? false : true;
	}

	/// <summary>
	/// GetSpriteCollisionReceive����ȡ���鵱ǰ�Ƿ��ǿ��Խ�����ײ
	/// ����ֵ��true ���Խ��� false ������
	/// </summary>
	public bool 		GetSpriteCollisionReceive()
	{
        return CommonAPI.dGetSpriteCollisionReceive(GetName()) == 0 ? false : true;
	}

	/// <summary>
	/// SetSpriteCollisionResponse�����þ����뾫�����ײ��Ӧģʽ
	/// ���� Response����Ӧģʽ�����ΪOFF����Ϊ�ر���ײ��Ӧ����ײAPI�����ᱻ���á�����ֵ�� ECollisionResponse
	/// </summary>
	public void		SetSpriteCollisionResponse(  ECollisionResponse Response )
	{
		CommonAPI.dSetSpriteCollisionResponse( GetName(), Response );
	}

	/// <summary>
	/// SetSpriteCollisionMaxIterations�����þ�����ײ֮�����󷴵�����
	/// ���� iTimes����������
	/// </summary>
	/// <param name="iTimes"></param>
	public void		SetSpriteCollisionMaxIterations(  int iTimes )
	{
		CommonAPI.dSetSpriteCollisionMaxIterations( GetName(), iTimes );
	}

	/// <summary>
	/// SetSpriteForwardMovementOnly�����þ����Ƿ�ֻ�ܳ�ǰ�ƶ�
	/// ���� bForward��true ֻ�ܳ�ǰ�ƶ� false ���Գ����������ƶ�
	/// </summary>
	/// <param name="bForward"></param>
	public void		SetSpriteForwardMovementOnly( bool bForward )
	{
        CommonAPI.dSetSpriteForwardMovementOnly(GetName(), bForward ? 1 : 0);
	}

	/// <summary>
	/// GetSpriteForwardMovementOnly����ȡ���鵱ǰ�Ƿ�ֻ�ܳ�ǰ�ƶ�
	/// ����ֵ��true ֻ�ܳ�ǰ�ƶ� false ���Գ����������ƶ�
	/// </summary>
	/// <returns></returns>
	public bool		GetSpriteForwardMovementOnly()
	{
        return CommonAPI.dGetSpriteForwardMovementOnly(GetName()) == 0 ? false : true;
	}

	/// <summary>
	/// SetSpriteForwardSpeed�����þ�����ǰ���ٶ�
	/// ���� fSpeed���ٶ�
	/// </summary>
	/// <param name="fSpeed"></param>
	public void		SetSpriteForwardSpeed(  float fSpeed )
	{
		CommonAPI.dSetSpriteForwardSpeed( GetName(), fSpeed );
	}

	/// <summary>
	/// SetSpriteImpulseForce�����þ���˲������
	/// ���� fForceX��X����������С
	/// ���� fForceY��Y����������С
	/// ���� bGravitic���Ƿ��������
	/// </summary>
	/// <param name="fForceX"></param>
	/// <param name="fForceY"></param>
	/// <param name="bGravitic"></param>
	public void 		SetSpriteImpulseForce(  float fForceX,  float fForceY, bool bGravitic )
	{
        CommonAPI.dSetSpriteImpulseForce(GetName(), fForceX, fForceY, bGravitic ? 1 : 0);
	}

	/// <summary>
	/// SetSpriteImpulseForcePolar�����Ƕȳ������þ���˲������
	/// ���� fPolar���Ƕȳ���
	/// ���� fForce��������С
	/// ���� bGravitic���Ƿ��������
	/// </summary>
	/// <param name="fPolar"></param>
	/// <param name="fForce"></param>
	/// <param name="bGravitic"></param>
	public void 		SetSpriteImpulseForcePolar(  float fPolar,  float fForce, bool bGravitic )
	{
        CommonAPI.dSetSpriteImpulseForcePolar(GetName(), fPolar, fForce, bGravitic ? 1 : 0);
	}

	/// <summary>
	/// SetSpriteConstantForceX�����þ���X����������
	/// ���� fForceX��X����������С
	/// </summary>
	/// <param name="fForceX"></param>
	public void 		SetSpriteConstantForceX(  float fForceX )
	{
		CommonAPI.dSetSpriteConstantForceX( GetName(), fForceX );
	}

	/// <summary>
	/// SetSpriteConstantForceY�����þ���Y����������
	/// ���� fForceY��Y����������С
	/// </summary>
	/// <param name="fForceY"></param>
	public void 		SetSpriteConstantForceY(  float fForceY )
	{
		CommonAPI.dSetSpriteConstantForceY( GetName(), fForceY );
	}

	/// <summary>
	/// SetSpriteConstantForceGravitic�������ڼ��㳣��������ʱ���Ƿ��������
	/// ���� bGravitic���Ƿ��������
	/// </summary>
	/// <param name="bGravitic"></param>
	public void 		SetSpriteConstantForceGravitic( bool bGravitic )
	{
        CommonAPI.dSetSpriteConstantForceGravitic(GetName(), bGravitic ? 1 : 0);
	}

	/// <summary>
	/// SetSpriteConstantForce�����þ��鳣������
	/// ���� fForceX��X����������С
	/// ���� fForceY��Y����������С
	/// ���� bGravitic���Ƿ��������
	/// </summary>
	/// <param name="fForceX"></param>
	/// <param name="fForceY"></param>
	/// <param name="bGravitic"></param>
	public void 		SetSpriteConstantForce(  float fForceX,  float fForceY, bool bGravitic )
	{
        CommonAPI.dSetSpriteConstantForce(GetName(), fForceX, fForceY, bGravitic ? 1 : 0);
	}

	/// <summary>
	/// SetSpriteConstantForcePolar�����Ƕȳ������þ��鳣������
	/// ���� fPolar���Ƕȳ���
	/// ���� fForce��������С
	/// ���� bGravitic���Ƿ��������
	/// </summary>
	/// <param name="fPolar"></param>
	/// <param name="fForce"></param>
	/// <param name="bGravitic"></param>
	public void 		SetSpriteConstantForcePolar(  float fPolar,  float fForce, bool bGravitic )
	{
        CommonAPI.dSetSpriteConstantForcePolar(GetName(), fPolar, fForce, bGravitic ? 1 : 0);
	}

	/// <summary>
	/// StopSpriteConstantForce��ֹͣ���鳣������
	/// </summary>
	public void 		StopSpriteConstantForce()
	{
		CommonAPI.dStopSpriteConstantForce( GetName() );
	}

	/// <summary>
	/// SetSpriteForceScale�����������ž��鵱ǰ�ܵ�����
	/// ���� fScale������ֵ
	/// </summary>
	/// <param name="fScale"></param>
	public void 		SetSpriteForceScale(  float fScale )
	{
		CommonAPI.dSetSpriteForceScale( GetName(), fScale );
	}

	/// <summary>
	/// SetSpriteAtRest����ͣ/��������ĸ�����������
	/// ���� bRest��true ��ͣ false ����
	/// </summary>
	/// <param name="bRest"></param>
	public void 		SetSpriteAtRest( bool bRest )
	{
        CommonAPI.dSetSpriteAtRest(GetName(), bRest ? 1 : 0);
	}

	/// <summary>
	/// GetSpriteAtRest����ȡ���鵱ǰ�Ƿ�����ͣ��
	/// ����ֵ��true ��ͣ�� false ����
	/// </summary>
	/// <returns></returns>
	public bool 		GetSpriteAtRest( )
	{
        return CommonAPI.dGetSpriteAtRest(GetName()) == 0 ? false : true;
	}

	/// <summary>
	/// SetSpriteFriction�����þ���Ħ����
	/// ���� fFriction��Ħ������С
	/// </summary>
	/// <param name="fFriction"></param>
	public void 		SetSpriteFriction(  float fFriction )
	{
		CommonAPI.dSetSpriteFriction( GetName(), fFriction );
	}

	/// <summary>
	/// SetSpriteRestitution�����þ��鵯��
	/// ���� fRestitution������ֵ��С
	/// </summary>
	/// <param name="fRestitution"></param>
	public void 		SetSpriteRestitution(  float fRestitution )
	{
		CommonAPI.dSetSpriteRestitution( GetName(), fRestitution );
	}

	/// <summary>
	/// SetSpriteMass�����þ�������
	/// ���� fMass��������С
	/// </summary>
	/// <param name="fMass"></param>
	public void 		SetSpriteMass(  float fMass )
	{
		CommonAPI.dSetSpriteMass( GetName(), fMass );
	}

	/// <summary>
	/// GetSpriteMass����ȡ��������
	/// ����ֵ ��������С
	/// </summary>
	/// <returns></returns>
	public float 		GetSpriteMass()
	{
		return CommonAPI.dGetSpriteMass( GetName() );
	}

	/// <summary>
	/// SetSpriteAutoMassInertia���������߹رվ������
	/// ���� bStatus��true ���� false �ر�
	/// </summary>
	/// <param name="bStatus"></param>
	public void 		SetSpriteAutoMassInertia( bool bStatus )
	{
        CommonAPI.dSetSpriteAutoMassInertia(GetName(), bStatus ? 1 : 0);
	}

	/// <summary>
	/// SetSpriteInertialMoment�����þ�����Դ�С
	/// ���� fInert�����Դ�С
	/// </summary>
	/// <param name="fInert"></param>
	public void 		SetSpriteInertialMoment(  float fInert )
	{
		CommonAPI.dSetSpriteInertialMoment( GetName(), fInert );
	}

	/// <summary>
	/// SetSpriteDamping�����þ���˥��ֵ
	/// ���� fDamp��˥��ֵ��С
	/// </summary>
	/// <param name="fDamp"></param>
	public void 		SetSpriteDamping(  float fDamp )
	{
		CommonAPI.dSetSpriteDamping( GetName(), fDamp );
	}
    	
	/// <summary>
	/// SetSpriteImmovable�����þ����Ƿ񲻿��ƶ�
	/// ���� bImmovable��true �������ƶ� false �����ƶ�
	/// </summary>
	/// <param name="bImmovable"></param>
	public void 		SetSpriteImmovable( bool bImmovable )
	{
        CommonAPI.dSetSpriteImmovable(GetName(), bImmovable ? 1 : 0);
	}

	/// <summary>
	/// GetSpriteImmovable����ȡ���鵱ǰ�Ƿ񲻿����ƶ�
	/// ����ֵ��true �������ƶ� false �����ƶ�
	/// </summary>
	/// <returns></returns>
	public bool 		GetSpriteImmovable()
	{
        return CommonAPI.dGetSpriteImmovable(GetName()) == 0 ? false : true;
	}

	/// <summary>
	/// SetSpriteLinearVelocity�����þ����ƶ��ٶ�
	/// ���� fVelX��X�����ٶ�
	/// ���� fVelY��Y�����ٶ�
	/// </summary>
	/// <param name="fVelX"></param>
	/// <param name="fVelY"></param>
	public void 		SetSpriteLinearVelocity(  float fVelX,  float fVelY )
	{
		CommonAPI.dSetSpriteLinearVelocity( GetName(), fVelX, fVelY );
	}

	/// <summary>
	/// SetSpriteLinearVelocityX�����þ���X�����ƶ��ٶ�
	/// ���� fVelX��X�����ٶ�
	/// </summary>
	/// <param name="fVelX"></param>
	public void 		SetSpriteLinearVelocityX(  float fVelX )
	{
		CommonAPI.dSetSpriteLinearVelocityX( GetName(), fVelX );
	}

	/// <summary>
	/// SetSpriteLinearVelocityY�����þ���Y�����ƶ��ٶ�
	/// ���� fVelY��Y�����ٶ�
	/// </summary>
	/// <param name="fVelY"></param>
	public void 		SetSpriteLinearVelocityY(  float fVelY )
	{
		CommonAPI.dSetSpriteLinearVelocityY( GetName(), fVelY );
	}

	/// <summary>
	/// SetSpriteLinearVelocityPolar�����Ƕȳ������þ����ƶ��ٶ�
	/// ���� fSpeed���ƶ��ٶ�
	/// ���� fPolar���Ƕȳ���
	/// </summary>
	/// <param name="fSpeed"></param>
	/// <param name="fPolar"></param>
	public void 		SetSpriteLinearVelocityPolar(  float fSpeed,  float fPolar )
	{
		CommonAPI.dSetSpriteLinearVelocityPolar( GetName(), fSpeed, fPolar );
	}
 
	/// <summary>
	/// SetSpriteAngularVelocity�����þ���Ƕ���ת�ٶ�
	/// ���� fAngular���Ƕ���ת�ٶ�
	/// </summary>
	/// <param name="fAngular"></param>
	public void 		SetSpriteAngularVelocity(  float fAngular )
	{
		CommonAPI.dSetSpriteAngularVelocity( GetName(), fAngular );
	}

	/// <summary>
	/// SetSpriteMinLinearVelocity�����þ�����С�ٶ�
	/// ���� fMin����С�ٶ�ֵ
	/// </summary>
	/// <param name="fMin"></param>
	public void 		SetSpriteMinLinearVelocity(  float fMin )
	{
		CommonAPI.dSetSpriteMinLinearVelocity( GetName(), fMin );
	}

	/// <summary>
	/// SetSpriteMaxLinearVelocity�����þ�������ٶ�
	/// ���� fMax������ٶ�ֵ
	/// </summary>
	/// <param name="fMax"></param>
	public void 		SetSpriteMaxLinearVelocity(  float fMax )
	{
		CommonAPI.dSetSpriteMaxLinearVelocity( GetName(), fMax );
	}

	/// <summary>
	/// SetSpriteMinAngularVelocity�����þ�����С���ٶ�
	/// ���� fMin����С���ٶ�
	/// </summary>
	/// <param name="fMin"></param>
	public void 		SetSpriteMinAngularVelocity(  float fMin )
	{
		CommonAPI.dSetSpriteMinAngularVelocity( GetName(), fMin );
	}

	/// <summary>
	/// SetSpriteMaxAngularVelocity�����þ��������ٶ�
	/// ���� fMax�������ٶ�
	/// </summary>
	/// <param name="fMax"></param>
	public void 		SetSpriteMaxAngularVelocity(  float fMax )
	{
		CommonAPI.dSetSpriteMaxAngularVelocity( GetName(), fMax );
	}
    	
	/// <summary>
	/// GetSpriteLinearVelocityX����ȡ����X�����ٶ�
	/// ����ֵ��X�����ٶ�
	/// </summary>
	/// <returns></returns>
	public float 		GetSpriteLinearVelocityX()
	{
		return CommonAPI.dGetSpriteLinearVelocityX( GetName() );
	}

	/// <summary>
	/// GetSpriteLinearVelocityY����ȡ����Y�����ٶ�
	/// ����ֵ��Y�����ٶ�
	/// </summary>
	/// <returns></returns>
	public float 		GetSpriteLinearVelocityY()
	{
		return CommonAPI.dGetSpriteLinearVelocityY( GetName() );
	}
    
	/// <summary>
	/// SpriteMountToSprite����һ������󶨵���һ�������ϣ���ʱ�ĳ�Ϊ��һ�������һ���֣��������˶���
	/// ���� szDstName�����ذ󶨵�ĸ�徫������
	/// ���� fOffSetX����ƫ��X
	/// ���� fOffsetY����ƫ��Y
	/// ����ֵ������һ����ID
	/// </summary>
	/// <param name="szDstName"></param>
	/// <param name="fOffSetX"></param>
	/// <param name="fOffsetY"></param>
	/// <returns></returns>
    public int SpriteMountToSprite(string szDstName, float fOffSetX, float fOffsetY)
	{
		return CommonAPI.dSpriteMountToSprite( GetName(), szDstName, fOffSetX, fOffsetY );
	}

	/// <summary>
	/// SpriteMountToSpriteLinkPoint����һ������󶨵���һ�������ϣ���λ��Ϊָ�������ӵ㣬��ʱ�ĳ�Ϊ��һ�������һ���֣��������˶���
	/// ���� szDstName�����ذ󶨵�ĸ�徫������
	/// ���� iPointId�����ӵ����
	/// ����ֵ������һ����ID
	/// </summary>
	/// <param name="szDstName"></param>
	/// <param name="iPointId"></param>
	/// <returns></returns>
    public int SpriteMountToSpriteLinkPoint(string szDstName, int iPointId)
	{
		return CommonAPI.dSpriteMountToSpriteLinkPoint( GetName(), szDstName, iPointId );
	}

	/// <summary>
	/// SetSpriteMountRotation�����þ���İ󶨳��򣬼������ĸ��ĳ���
	/// ���� fRot���Ƕȳ���0 - 360
	/// </summary>
	/// <param name="fRot"></param>
	public void		SetSpriteMountRotation(  float fRot )
	{
		CommonAPI.dSetSpriteMountRotation( GetName(), fRot );
	}

	/// <summary>
	/// GetSpriteMountRotation����ȡ����İ󶨳��򣬼������ĸ��ĳ���
	/// ����ֵ���Ƕȳ���
	/// </summary>
	/// <returns></returns>
	public float		GetSpriteMountRotation()
	{
		return CommonAPI.dGetSpriteMountRotation( GetName() );
	}

	/// <summary>
	/// SetSpriteAutoMountRotation�����þ����֮���Զ���ת
	/// ���� fRot����ת�ٶ�
	/// </summary>
	/// <param name="fRot"></param>
	public void		SetSpriteAutoMountRotation(  float fRot )
	{
		CommonAPI.dSetSpriteAutoMountRotation( GetName(), fRot );
	}

	/// <summary>
	/// GetSpriteAutoMountRotation����ȡ�����֮����Զ���תֵ
	/// ����ֵ����ת�ٶ�
	/// </summary>
	/// <returns></returns>
	public float		GetSpriteAutoMountRotation()
	{
		return CommonAPI.dGetSpriteAutoMountRotation( GetName() );
	}

	/// <summary>
	/// SetSpriteMountForce��������һ������ʱ�����ӵ�������
	/// ���� fFroce��������
	/// </summary>
	/// <param name="fForce"></param>
	public void		SetSpriteMountForce(  float fForce )
	{
		CommonAPI.dSetSpriteMountForce( GetName(), fForce );
	}

	/// <summary>
	/// SetSpriteMountTrackRotation���󶨵ľ����Ƿ����ĸ����ת
	/// ���� bTrackRotation��true ���� false ������
	/// </summary>
	/// <param name="bTrackRotation"></param>
	public void		SetSpriteMountTrackRotation( bool bTrackRotation )
	{
        CommonAPI.dSetSpriteMountTrackRotation(GetName(), bTrackRotation ? 1 : 0);
	}

	/// <summary>
	/// SetSpriteMountOwned��ĸ�屻ɾ����ʱ�򣬰󶨵ľ����Ƿ�Ҳ���ű�ɾ��
	/// ���� bMountOwned��true ���� false ������
	/// </summary>
	/// <param name="bMountOwned"></param>
	public void		SetSpriteMountOwned( bool bMountOwned )
	{
        CommonAPI.dSetSpriteMountOwned(GetName(), bMountOwned ? 1 : 0);
	}

	/// <summary>
	/// SetSpriteMountInheritAttributes���󶨵�ʱ���Ƿ�̳�ĸ�������
	/// ���� bInherAttr��true �̳� false ���̳�
	/// </summary>
	/// <param name="bInherAttr"></param>
	public void		SetSpriteMountInheritAttributes( bool bInherAttr )
	{
        CommonAPI.dSetSpriteMountInheritAttributes(GetName(), bInherAttr ? 1 : 0);
	}

	/// <summary>
	/// SpriteDismount�����Ѿ��󶨵ľ�����н��
	/// </summary>
	public void		SpriteDismount()
	{
		CommonAPI.dSpriteDismount( GetName() );
	}

	/// <summary>
	/// GetSpriteIsMounted���жϾ����Ƿ������һ��������
	/// ����ֵ��true �� false ����
	/// </summary>
	/// <returns></returns>
	public bool		GetSpriteIsMounted()
	{
        return CommonAPI.dGetSpriteIsMounted(GetName()) == 0 ? false : true;
	}

	/// <summary>
	/// GetSpriteMountedParent����ȡ�󶨵�ĸ�徫�������
	/// ����ֵ��ĸ�徫�����֣����δ�󶨣��򷵻ؿ��ַ���
	/// </summary>
	/// <returns></returns>
    public string GetSpriteMountedParent()
	{
		return CommonAPI.dGetSpriteMountedParent( GetName() );
	}

	/// <summary>
	/// SetSpriteColorRed�����ľ�����ʾ��ɫ�еĺ�ɫ��Ĭ�Ͼ���ĺ���������ɫ��ֵ��Ϊ255���޸�����һ����Ըı�����ɫ
	/// ���� iCol����ɫ��Χ 0 - 255
	/// </summary>
	/// <param name="iCol"></param>
	public void		SetSpriteColorRed(  int iCol )
	{
		CommonAPI.dSetSpriteColorRed( GetName(), iCol );
	}

	/// <summary>
	/// SetSpriteColorGreen�����ľ�����ʾ��ɫ�е���ɫ��Ĭ�Ͼ���ĺ���������ɫ��ֵ��Ϊ255���޸�����һ����Ըı�����ɫ
	/// ���� iCol����ɫ��Χ 0 - 255
	/// </summary>
	/// <param name="iCol"></param>
	public void		SetSpriteColorGreen(  int iCol )
	{
		CommonAPI.dSetSpriteColorGreen( GetName(), iCol );
	}

	/// <summary>
	/// SetSpriteColorBlue�����ľ�����ʾ��ɫ�е���ɫ��Ĭ�Ͼ���ĺ���������ɫ��ֵ��Ϊ255���޸�����һ����Ըı�����ɫ
	/// ���� iCol����ɫ��Χ 0 - 255
	/// </summary>
	/// <param name="iCol"></param>
	public void		SetSpriteColorBlue(  int iCol )
	{
		CommonAPI.dSetSpriteColorBlue( GetName(), iCol );
	}

	/// <summary>
	/// SetSpriteColorAlpha�����þ���͸����
	/// ���� iCol��͸���ȣ�ֵ0 - 255������ȫ͸������ȫ��͸��
	/// </summary>
	/// <param name="iCol"></param>
	public void		SetSpriteColorAlpha(  int iCol )
	{
		CommonAPI.dSetSpriteColorAlpha(  GetName(), iCol );
	}

	/// <summary>
	/// GetSpriteColorRed����ȡ������ʾ��ɫ�еĺ�ɫֵ
	/// ����ֵ����ɫֵ
	/// </summary>
	/// <returns></returns>
	public int			GetSpriteColorRed()
	{
		return CommonAPI.dGetSpriteColorRed( GetName() );
	}

	/// <summary>
	/// GetSpriteColorGreen����ȡ������ʾ��ɫ�е���ɫֵ
	/// ����ֵ����ɫֵ
	/// </summary>
	/// <returns></returns>
	public int			GetSpriteColorGreen()
	{
		return CommonAPI.dGetSpriteColorGreen( GetName() );
	}

	/// <summary>
	/// GetSpriteColorBlue����ȡ������ʾ��ɫ�е���ɫֵ
	/// ����ֵ����ɫֵ
	/// </summary>
	/// <returns></returns>
	public int			GetSpriteColorBlue()
	{
		return CommonAPI.dGetSpriteColorBlue( GetName() );
	}

	/// <summary>
	/// GetSpriteColorAlpha����ȡ����͸����
	/// ����ֵ��͸����
	/// </summary>
	/// <returns></returns>
	public int			GetSpriteColorAlpha()
	{
		return CommonAPI.dGetSpriteColorAlpha( GetName() );
	}
};