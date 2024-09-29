/////////////////////////////////////////////////////////////////////////////////
//
//
//
//
/////////////////////////////////////////////////////////////////////////////////
#ifndef _LESSON_X_H_
#define _LESSON_X_H_
//
#include <Windows.h>
#include <stdlib.h>
#include <math.h>
#include <time.h>

extern void	GameMainLoop( float	fDeltaTime );
extern void OnMouseMove( const float fMouseX, const float fMouseY );
extern void OnMouseClick( const int iMouseType, const float fMouseX, const float fMouseY );
extern void OnMouseUp( const int iMouseType, const float fMouseX, const float fMouseY );
extern void OnKeyDown( const int iKey, const bool bAltPress, const bool bShiftPress, const bool bCtrlPress );
extern void OnKeyUp( const int iKey );
extern void OnSpriteColSprite( const char *szSrcName, const char *szTarName );
extern void OnSpriteColWorldLimit( const char *szName, const int iColSide );

// �Խ�����

// GameMenuGo������Ļ�еİ�ť����ƶ�����Ļ��
// ����WhichMenu��ָ�����еĽ���wellcomeΪ0��mainmenuΪ1��mapmenuΪ2��
extern void GameMenuGo(int WhichMenu);

// GameMenuBack������Ļ��İ�ť����ƻ���
// ����WhichMenu��ָ�����еĽ���wellcomeΪ0��mainmenuΪ1��mapmenuΪ2��
extern void GameMenuBack(int WhichMenu);

// GameTjInit����ͼ���˵���ʼ��
// ����WhichMap��ָ����ϷĿǰ���е��ڼ����˸տ�ʼΪ0����ͨgame1Ϊ1����ͨgame2Ϊ2��
extern void GameTjInit(int WhichMap);

// MapmenuInit����ͼ���˵���ʼ��
// ����WhichMap��ָ����ϷĿǰ���е��ڼ����˸տ�ʼΪ0����ͨgame1Ϊ1����ͨgame2Ϊ2��
extern void MapMenuInit(int WhichMap);

// ShowShuxing����ʾ��������
// ����szName��ָ������ʲô����;
// ����num��ָ��Ϊʲôֵ;
extern void ShowShuxing(const char *szName,int num);

// GameSave������Ϸ�浵
extern void GameSave(void);

// GameLoad����ȡ��Ϸ�浵
extern void GameLoad(void);

// GameClone: ��¡С�����ǳ�
extern void GameClone(void);

// GameXbMove��С���ƶ�����
// PosX�����ǵ�X����
extern void GameXbMove(const float PosX);

// GameXbBack��С���ܵ��������˺���
// szName��С�־�����
// top�����ǳ���
extern void GameXbBack(const char *szName,int top);

// GameXbHurt��С����Ѫ����
// szName��С�־�����
extern int GameXbHurt(const char *szName,int hurtnum);

// GameShowNum����ֵ��ʾ����
// szName����ʾ�����������ֵ'����¡����ֵ������'
// num����ʾ����ֵ
// PosX����ʾ����ֵ��Xλ��
// PosY: ��ʾ����ֵ��Yλ��
extern void GameShowNum(const char *szName,const int num,const float PosX,const float PosY);

// GameXbAttack��С����������
// PosX������Xλ��
extern void GameXbAttack(const float PosX);


// BloodLen���ı�Ѫ��/����������
// szName�����ı��Ѫ������
// Oldlen��ԭѪ������
// Y_blood��ԭѪ��
// N_blood�����ڵ�Ѫ��
// PosX��ԭѪ����Xλ��
extern void BloodLen(const char *szName,const float Oldlen,const int Y_blood,const int N_blood,const float PosX);

// ShowNum���ı�Ѫ��/��������ֵ
// flag���ı�ʲô��1=> Ѫ��ֵ�� 2=>����ֵ�� 3=>Ѫ�����ֵ�� 4=>�������ֵ
// num���ı�Ϊʲô��
extern void ShowNum(const int flag, const int num);

// ShowMap: Map��ͼ��ʼ��
extern void ShowMap(const int level, const int shengming);

// Shengji����������
extern void Shengji(void);

// Addjingya���Ӿ��麯��
extern void Addjingya(const int num);

// SubBlood�����ǿ�Ѫ
extern void SubBlood(const int num);

// SkillInit�����ܳ�ʼ������
// Level������ȼ�
extern void SkillInit(const int Level);

// SendSkill���ͷż���
// Skill���ĸ�����'U','I','O','L'
extern void SendSkill(const char skill);

// SysTime����ʾϵͳ��ʱ
extern void SysTime(const float num);

// CloneBoss������Boss
// WhichMap���ĸ���ͼ��Boss
extern void CloneBoss(const int WhichMap);

// BossMove��Boss�ƶ�����
// PosX�����ǵ�X����
extern void BossMove(const float PosX);

// BossAttack��Boss��������
// PosX�����ǵ�X����
extern void BossAttack(const float PosX);

// BossHurt��Boss���˿�Ѫ����
// hurt����Boss���˺�
extern void BossHurt(const int hurt);

// BossDie��Boss��������
// WhichMap�����ŵ�ͼ��Boss
extern void BossDie(const int WhichMap);

// BossAction��Boss�ж�����
// ע���ں������������Boss���ж����ƶ����ͷż����������
extern void BossAction(const float PosX);

// GameMove�������ƶ�����
extern void GameMove(void);

// GameLoadGC�����ع�������
extern void GameLoadGC(const int GameGQ,const int ID);


#endif // _LESSON_X_H_
