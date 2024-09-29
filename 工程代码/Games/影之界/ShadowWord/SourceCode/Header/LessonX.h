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

// 自建函数

// GameMenuGo：将屏幕中的按钮组件移动到屏幕外
// 参数WhichMenu：指定运行的界面wellcome为0，mainmenu为1，mapmenu为2；
extern void GameMenuGo(int WhichMenu);

// GameMenuBack：将屏幕外的按钮组件移回来
// 参数WhichMenu：指定运行的界面wellcome为0，mainmenu为1，mapmenu为2；
extern void GameMenuBack(int WhichMenu);

// GameTjInit：将图鉴菜单初始化
// 参数WhichMap：指定游戏目前进行到第几关了刚开始为0，打通game1为1，打通game2为2；
extern void GameTjInit(int WhichMap);

// MapmenuInit：将图鉴菜单初始化
// 参数WhichMap：指定游戏目前进行到第几关了刚开始为0，打通game1为1，打通game2为2；
extern void MapMenuInit(int WhichMap);

// ShowShuxing：显示人物属性
// 参数szName：指定更改什么属性;
// 参数num：指定为什么值;
extern void ShowShuxing(const char *szName,int num);

// GameSave：将游戏存档
extern void GameSave(void);

// GameLoad：读取游戏存档
extern void GameLoad(void);

// GameClone: 克隆小兵并登场
extern void GameClone(void);

// GameXbMove：小兵移动函数
// PosX：主角的X坐标
extern void GameXbMove(const float PosX);

// GameXbBack：小兵受到攻击后退函数
// szName：小怪精灵名
// top：主角朝向
extern void GameXbBack(const char *szName,int top);

// GameXbHurt：小兵扣血函数
// szName：小怪精灵名
extern int GameXbHurt(const char *szName,int hurtnum);

// GameShowNum：数值显示函数
// szName：显示那种字体的数值'被克隆的数值精灵名'
// num：显示的数值
// PosX：显示的数值的X位置
// PosY: 显示的数值的Y位置
extern void GameShowNum(const char *szName,const int num,const float PosX,const float PosY);

// GameXbAttack：小兵攻击函数
// PosX：主角X位置
extern void GameXbAttack(const float PosX);


// BloodLen：改变血条/经验条长度
// szName：待改变的血条名称
// Oldlen：原血条长度
// Y_blood：原血量
// N_blood：现在的血量
// PosX：原血条的X位置
extern void BloodLen(const char *szName,const float Oldlen,const int Y_blood,const int N_blood,const float PosX);

// ShowNum：改变血条/经验条数值
// flag：改变什么，1=> 血量值， 2=>经验值， 3=>血量最大值， 4=>经验最大值
// num：改变为什么数
extern void ShowNum(const int flag, const int num);

// ShowMap: Map地图初始化
extern void ShowMap(const int level, const int shengming);

// Shengji：升级函数
extern void Shengji(void);

// Addjingya：加经验函数
extern void Addjingya(const int num);

// SubBlood：主角扣血
extern void SubBlood(const int num);

// SkillInit：技能初始化函数
// Level：人物等级
extern void SkillInit(const int Level);

// SendSkill：释放技能
// Skill：哪个技能'U','I','O','L'
extern void SendSkill(const char skill);

// SysTime：显示系统用时
extern void SysTime(const float num);

// CloneBoss：加载Boss
// WhichMap：哪个地图的Boss
extern void CloneBoss(const int WhichMap);

// BossMove：Boss移动函数
// PosX：主角的X坐标
extern void BossMove(const float PosX);

// BossAttack：Boss攻击函数
// PosX：主角的X坐标
extern void BossAttack(const float PosX);

// BossHurt：Boss受伤扣血函数
// hurt：对Boss的伤害
extern void BossHurt(const int hurt);

// BossDie：Boss死亡函数
// WhichMap：哪张地图的Boss
extern void BossDie(const int WhichMap);

// BossAction：Boss行动函数
// 注：在函数中随机产生Boss的行动，移动，释放技能随机产生
extern void BossAction(const float PosX);

// GameMove：主角移动函数
extern void GameMove(void);

// GameLoadGC：加载过场动画
extern void GameLoadGC(const int GameGQ,const int ID);


#endif // _LESSON_X_H_
