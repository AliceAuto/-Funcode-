/////////////////////////////////////////////////////////////////////////////////
//
//
//
//
/////////////////////////////////////////////////////////////////////////////////
#include <Stdio.h>
#include "CommonAPI.h"
#include "LessonX.h"
#include "math.h"
#include <algorithm>
////////////////////////////////////////////////////////////////////////////////
//
//
//g_开头的为系统运行变量
//M_开头为系统音效变量
//F_为系统标记变量
//Z_为主角的变量
//O_为其他怪物变量
//B_为Boss变量
//S_为技能变量
int			g_iGameState		=	1;		// 游戏状态，0 -- 游戏结束等待开始状态；1 -- 按下空格键开始，初始化游戏；2 -- 游戏进行中
int         g_WhichMap = 0;         // 记录当前所在地图,mapmenu中的弹出菜单使用-1表示，防止按钮冲突  3是地图1
int         g_Whichgame = 0;        // 记录人物通关数，开始为0，通关game1为1，通关game2为2 ...
int         g_WhichTj = 0;          // 记录当前图鉴菜单显示的时第几个文物图片
int         g_WhichGq = 0;          // 记录当前人物所在的关卡
int         g_IsD = 0;              // 记录D键是否按下
int         g_IsA = 0;              // 记录A键是否按下
int         g_IsU = 0;              // 记录U键是否按下
int         g_IsO = 0;              // 记录O键是否按下
int         g_IsL = 0;              // 记录L键是否按下
int         g_isattack=0;           // 记录主角是否正在进行攻击（是否正在播放攻击动画）
int         g_xbNum = 0;            // 记录当前场景内的小兵数目
int         g_qianjin = 0;          // 记录地图是否可以前进，当场景内的小怪全部被杀死后置为1，否则为零，不可移动地图
int         g_isLoadXb = 0;         // 记录第一波小兵是否登场
int         g_isLoadXb2 = 0;        // 记录第二波小兵是否登场
int         g_isLoadXb3 = 0;        // 记录第三波小兵是否登场
int         g_isLoadBoss = 0;       // 记录Boss是否登场
int         g_isLoadGC = 0;         // 是否加载过场动画
int         g_isLoadGC1 = 0;        // 是否加载过场动画2
int         g_re = 0;               // 记录小兵运动周期

float       g_GCTime = 0;           // 过场动画所用时间
float       g_UseTime = 0;          // 每局游戏所用时间
float       g_gamelage = 1.25;      // 设置关卡图标的接受鼠标时的放大倍数
float       g_buttonlage = 1.25;    // 设置方形按钮图标的接受鼠标时的放大倍数
float       g_otherlage = 1.15;     // 设置其他按钮图标的接受鼠标时的放大倍数
float       g_MenuSpeed = 250;      // 设置按钮的移动速度
// 设置图鉴菜单显示的图鉴图像数组 解锁状态：TJtext?ImageMap  未解锁状态：TJying?ImageMap
const char *firstname = "C";
const char *g_Tujian[] = {"TJying1ImageMap","TJying2ImageMap","TJying3ImageMap",
                          "TJying4ImageMap","TJying5ImageMap","TJying6ImageMap",
                          "TJying7ImageMap","TJying8ImageMap","TJying9ImageMap",};

const char *g_mapname[] = {"","","","game1Bg1","game1Bg1","game1Bg1",
                                     "game1Bg1","game1Bg1","game1Bg1",
                                     "game1Bg1","game1Bg1","game1Bg1",};//记录每一关可移动的地图精灵名

const char *g_Gqname[] = {"Game1.t2d","Game2.t2d","Game3.t2d",
                           "Game4.t2d","Game5.t2d","Game6.t2d",
                           "Game7.t2d","Game8.t2d","Game9.t2d",};//记录每一关的地图名

const char *B_Skillname[] = {"Boss_Skill1","Boss_Skill2","Boss_Skill3","Boss_Skill4","Boss_Skill5",
                              "Boss_Skill6","Boss_Skill7","Boss_Skill8","Boss_Skill9","Boss_Skill10",
                              "Boss_Skill11","Boss_Skill12","Boss_Skill13","Boss_Skill14","Boss_Skill15",
                              "Boss_Skill16","Boss_Skill17","Boss_Skill18","Boss_Skill19"};//记录Boss攻击特效动画名

const char *B_Attackname[] = {"Boss1_attackAnimation","Boss2_attackAnimation","Boss3_attackAnimation",
                               "Boss4_attack2Animation","Boss5_attackAnimation","Boss7_attack2Animation",
                               "Boss8_attack2Animation","Boss6_attackAnimation","Boss9_attackAnimation"};//记录Boss攻击动作动画名

const char *O_Skillname[] = {"XB_Skill1","XB_Skill2","XB_Skill3","XB_Skill4","XB_Skill5","XB_Skill6","XB_Skill7"};
//
int         M_BGMXWX;       // 主菜单音效
int         M_BGMMapMenu;   // 地图场景音效
int         M_BGMguanqia;   // 关卡BGM
int         M_ClickMenu;    // 点击音效
int         M_MouseMove;    // 鼠标掠过音效
int         M_LevelUp;      // 升级音效
int         M_Jump;         // 主角跳跃音效
int         M_Hurt;         // 主角受伤音效
int         M_Attack;       // 主角普攻音效
int         M_Defult;       // 过关失败音效
int         M_OHurt;        // 小兵受伤音效
int         M_Skill1;       // 技能1音效
int         M_Skill2;       // 技能2音效
int         M_Skill3;       // 技能3音效
int         M_Skill4;       // 技能4音效
float       M_vol = 1;      // 设置声音大小，若要静音将其置为零。设置声音时乘以一个常数即可

//
const char *M_Main[]={"BGMXWX.ogg","MainBg2.ogg","MainBg3.ogg","MainBg4.ogg","MainBg5.ogg"};
const char *M_Map[]={"BGMMapMenu.wav","MapBg_3.ogg","MapBg_9.ogg"};
const char *M_Game[]={"BGMguanqia.wav","Gamebg_2.ogg","Gamebg_37.ogg",
                       "Gamebg_4.ogg","Gamebg_56.ogg","Gamebg_56.ogg",
                       "Gamebg_37.ogg","Gamebg_8.ogg","Gamebg_9.ogg"};
//
int         F_Mflag1=0x00;      // 记录音效播放次数
int         F_Mflag2=0x000;     // 记录音效播放次数

//
int         Z_gongji = 10;      //记录主角基本属性 ==> 攻击
int         Z_shengming = 100;  //记录主角基本属性 ==> 生命
int         Z_blood = 100;      //记录主角当前血量
int         Z_speed = 200;      //记录主角基本属性 ==> 速度
int         Z_fangyv = 10;      //记录主角基本属性 ==> 防御
int         Z_jingyan = 0;      //记录主角目前的经验
int         Z_levelMax = 30;    //记录主角的最大经验值
int         Z_level = 1;        //记录主角当前等级
int         Z_jump = 1;         //记录主角能否跳跃
int         Z_jumphigh = -600;  //记录主角跳跃的力量大小（影响跳跃高度）
int         Z_Mass = 10;        //记录主角质量
int         Z_top = 'D';        //记录主角朝向'D'和'A'
int         Z_IsPugong = 1;     //记录主角是否可以进行普攻
int         Z_Ishurt = 1;       //记录主角是否可被碰撞
int         Z_IsSkill[] = {0,0,0,0};//记录主角是否可以释放技能

float       Z_hurtID = 1/(1+(Z_fangyv/100.0)); //记录主角的减伤系数
float       Z_attackTime;       //记录主角距上次进攻的时间
float       Z_hurtTime;         //记录主角距上次受伤的时间
float       Z_PgJiange = 0.6;   //设置主角的普攻间隔
float       Z_hurtJg = 1;     //设置主角的受伤间隔
float       Z_PosX = -470;      //记录主角当前位置的X坐标
float       Z_PosY = -87;       //记录主角当前位置的Y坐标
float       Z_Bloodlen = 255;   //记录主角原血条长度
float       Z_BloodPosX = -346; //记录主角原血条位置
float       Z_Levellen = 228;   //记录主角原经验条长度
float       Z_LevelPosX = -346; //记录主角原经验条位置

const char *Z_name = "zhujue";              //记录主角名字
const char *Z_BloodName ="Z_bloodnum";      //主角血条精灵名
const char *Z_LevelName ="Z_levelnum";      //主角经验条精灵名
const char *Z_run = "Z_runAnimation";       //记录主角奔跑动画名
const char *Z_stand = "Z_standAnimation";   //记录主角静止动画名
const char *Z_attack = "Z_attackAnimation"; //记录主角攻击动画名
const char *Z_hurt = "Z_hurtAnimation";     //记录主角受伤动画名
const char *Z_die = "Z_dieAnimation";       //记录主角死亡动画名
const char *Z_pugong = "Z_pugongAnimation"; //记录主角普通攻击的动画名

//
float S_SpeedTime = 0;              //记录主角释放一技能后移动过程隐身的时间
float S_SpeedTime3 = 0;             //记录主角释放三技能后移动过程静止的时间
float S_SpeedTime4 = 0;             //记录主角释放四技能后移动过程静止的时间
float S_Time1 = 0;                  //记录技能一的释放间隔
float S_Time2 = 0;                  //记录技能二的释放间隔
float S_Time3 = 0;                  //记录技能三的释放间隔
float S_Time4 = 0;                  //记录技能四的释放间隔
float S_CD1 = 4;                    //记录技能一的冷却时间
float S_CD2 = 3;                    //记录技能二的冷却时间
float S_CD3 = 6;                    //记录技能三的冷却时间
float S_CD4 = 9;                    //记录技能四的冷却时间

const char *S_pugong = "pugong";    //记录播放普攻动画的精灵名

char S_Top = 'D';                   //记录一技能的释放方向

//
char O_IsSkill[6] = {0,0,0,0,0,0};       //记录每一关小兵是否可以发动攻击 0 ==> 不可以; 1 ==> 可以
char O_IsPengzhuang[6] = {1,1,1,1,1,1};  //记录小怪是否可碰撞 1 ==> 可碰撞  0 ==> 不可碰撞
char O_isattack = 0;                     //记录当前场地是否已经发起进攻



int O_hurt[9] = {10,15,20,25,32,40,45,48,50};//记录每一关小兵伤害
int O_bloodMax = 100;                   //记录每一关小兵血量上限：每一关翻倍
int O_blood[6] = {0,0,0,0,0,0};         //记录小怪的血量
int O_i = 0;                            //记录当前小兵ID
int O_numSprite = 0;                    //记录当前伤害显示系统的精灵数，满1000之后清零
int O_speed = 15;                       //记录小兵平静状态的速度
int O_Sspeed = 50;                      //记录小兵愤怒状态的速度

float O_attackPosX = 0;                 //记录小怪定点攻击的位置
float O_attackTime = 0;                 //记录场地对主角发动攻击的时间间隔
float O_attack = 2;                     //设置每隔几秒小怪发动一次攻击
float O_PengzhuangTime = 0.5;           //设置精灵与技能碰撞的时间间隔
float O_JiluTime[6] = {};               //记录据上一次碰撞间隔的时间
float O_attTime[6] ={};                 //记录小怪对主角发动攻击的时间间隔

//
int B_IsPengzhuang = 1;                 //记录Boss是否可碰撞1可碰撞，0不可碰撞
char B_IsAttack = 0;                     //记录Boss是否已经发动进攻 0 没有  1 发动了
int B_Shengming = 500;                  //设置Boss的血量上限
int B_Blood = 500;                      //记录Boss当前血量值
int B_Gongji = 50;                      //设置Boss的攻击力
int B_Fangyv = 50;                      //设置Boss的防御力
int B_Speed = 50;                       //设置Boss的速度
int B_num = 0;                          //记录场上Boss数
int B_i = 0;                            //记录当前Boss技能ID，死亡后清零
int B_SkillSpeed = 500;                 //设置Boss技能速度

float B_PengzhuangTime = 0.5;           //设置Boss的碰撞时间间隔
float B_JiangeTime = 0;                 //记录Boss距上次碰撞发生的间隔时间
float B_attack = 4;                     //设置Boss每隔多长时间进行一次攻击
float B_attackTime = 0;                 //记录距离上次Boss发动攻击过去了多长时间

int GC_F[20] = {};                      //过场动画标记
int GC_ID = 0;                          //记录过场动画第几幕

float GC_time = 0;                      //记录过场时间
//
void		GameInit();
void		GameRun( float fDeltaTime );
void		GameEnd();

//==============================================================================
//
// 大体的程序流程为：GameMainLoop函数为主循环函数，在引擎每帧刷新屏幕图像之后，都会被调用一次。


//==============================================================================
//
// 游戏主循环，此函数将被不停的调用，引擎每刷新一次屏幕，此函数即被调用一次
// 用以处理游戏的开始、进行中、结束等各种状态.
// 函数参数fDeltaTime : 上次调用本函数到此次调用本函数的时间间隔，单位：秒
void GameMainLoop( float	fDeltaTime )
{
    switch( g_iGameState )
    {
        // 初始化游戏，清空上一局相关数据
    case 1:
        {
            GameInit();
            g_iGameState	=	2; // 初始化之后，将游戏状态设置为进行中
        }
        break;

        // 游戏进行中，处理各种游戏逻辑
    case 2:
        {
            // TODO 修改此处游戏循环条件，完成正确游戏逻辑
            if( true )
            {
                GameRun( fDeltaTime );
            }
            else
            {
                // 游戏结束。调用游戏结算函数，并把游戏状态修改为结束状态
                g_iGameState	=	0;
                GameEnd();
            }
        }
        break;

        // 游戏结束/等待按空格键开始
    case 0:
    default:
        break;
    };
}

//==============================================================================
//
// 每局开始前进行初始化，清空上一局相关数据
void GameInit()
{
    //初始化时间清零
    g_UseTime = 0;
    switch(g_WhichMap)
    {
        case 0://初始化欢迎界面
            {
                // 如果本次游戏欢迎界面未被加载
                // 加载欢迎界面
                // 加载欢迎页面
                // 等待一秒半钟
                Sleep(1500);
                // 加载主菜单界面
                dLoadMap("MainMenu.t2d");
                // 播放BGM
                M_BGMXWX=dPlaySound("BGMXWX.ogg",1,1*M_vol);
                // 将当前地图标记为1
                g_WhichMap = 1;
            }
        case 1://初始化开始主菜单界面
            {
                dStopAllSound();
                M_BGMXWX=dPlaySound(M_Main[g_Whichgame/2],1,1*M_vol);
            }
            break;
        case 2://初始化地图菜单界面
            {
                //关闭音效
                dStopAllSound();
                // 播放BGM
                M_BGMMapMenu=dPlaySound(M_Map[g_Whichgame/4],1,1*M_vol);
                //进入地图菜单后存档
                GameSave();
                //隐藏所有的地图关卡及其说明
                dSetSpriteVisible("game1",0);
                dSetSpriteVisible("game2",0);
                dSetSpriteVisible("game3",0);
                dSetSpriteVisible("game4",0);
                dSetSpriteVisible("game5",0);
                dSetSpriteVisible("game6",0);
                dSetSpriteVisible("game7",0);
                dSetSpriteVisible("game8",0);
                dSetSpriteVisible("game9",0);
                dSetSpriteVisible("gamename1",0);
                dSetSpriteVisible("gamename2",0);
                dSetSpriteVisible("gamename3",0);
                dSetSpriteVisible("gamename4",0);
                dSetSpriteVisible("gamename5",0);
                dSetSpriteVisible("gamename6",0);
                dSetSpriteVisible("gamename7",0);
                dSetSpriteVisible("gamename8",0);
                dSetSpriteVisible("gamename9",0);
                //初始化&更新图鉴
                GameTjInit(g_Whichgame);
                //初始化&更新人物属性
                ShowShuxing("menusx_sm",Z_shengming);
                ShowShuxing("menusx_fy",Z_fangyv);
                ShowShuxing("menusx_gj",Z_gongji);
                ShowShuxing("menusx_ys",Z_speed);
                ShowMap(Z_level, Z_shengming);

            }
            break;
        case 11:    //初始化地图9
        case 10:    //初始化地图8
        case 9:     //初始化地图7
        case 8:     //初始化地图6
        case 7:     //初始化地图5
        case 6:     //初始化地图4
        case 5:     //初始化地图3
        case 4:     //初始化地图2
        case 3:     //初始化地图1
            {
                //记录当前所在关卡
                g_WhichGq = g_WhichMap - 2;
                //关闭音效
                dStopAllSound();
                // 播放BGM
                M_BGMguanqia=dPlaySound(M_Game[g_WhichGq-1],1,1*M_vol);
                //一切元素回归初始位置
                //主角状态回归初始化
                //初始化主角技能
                SkillInit(Z_level);
                //设置主角质量
                dSetSpriteMass(Z_name,Z_Mass);
                //设置地图不可移动
                g_qianjin = 0;
                //技能标记清零
                g_IsU = 0;
                g_IsO = 0;
                g_IsL = 0;
                //朝向
                S_Top = 'D';
                Z_top = 'D';
                //设置第一,二，三波兵没有产生
                g_isLoadXb = 0;
                g_isLoadXb2 = 0;
                g_isLoadXb3 = 0;
                //设置Boss并未产生
                g_isLoadBoss = 0;
                //设置小兵数和Boss数为0
                g_xbNum = 0;
                B_num = 0;
                //标记小兵未发动攻击
                O_isattack = 0;
                //初始化主角血量
                Z_blood = Z_shengming;
                //初始化血量显示（图形）
                BloodLen(Z_BloodName,Z_Bloodlen,Z_shengming,Z_blood,Z_BloodPosX);
                //初始化经验值显示（图形）
                BloodLen(Z_LevelName,Z_Levellen,Z_levelMax,Z_jingyan,Z_LevelPosX);
                ShowNum(2,Z_shengming);//显示血量最大值（数值）
                ShowNum(0,Z_blood);//显示血量（数值）
                ShowNum(3,Z_levelMax);//显示经验最大值（数值）
                ShowNum(1,Z_jingyan);//显示当前经验（数值）
                //显示等级
                 dSetStaticSpriteFrame("level",Z_level-1);
                //将普攻特效隐藏起来
                //dSetSpriteVisible(S_pugong,0);
                //设置主角的常量推力
                dSetSpriteConstantForce(Z_name,0,1000,1);
                //地图初始化，地图不可移动
                dSetSpriteImmovable(g_mapname[g_WhichMap],1);
                // 初始化Boss血量
                B_Blood = B_Shengming;
                // 记录当前通关进度
                // 如果是第一次到达本关,播放过场动画
                if(g_Whichgame<g_WhichGq)
                {
                    //播放过场动画
                    g_isLoadGC = 1;
                    g_isLoadGC1 = 1;
                }else
                {
                    //不播放过场动画
                    g_isLoadGC = 0;
                    g_isLoadGC1 = 0;
                }
            }
        default:
            break;
    }

}
//==============================================================================
//
// 每局游戏进行中
void GameRun( float fDeltaTime )
{
    switch(g_WhichMap)
    {
    case 1://主菜单
        {
        }
        break;
    case 2://地图菜单
        {
        }
        break;
    case 11://第九关关卡地图
    case 10://第八关关卡地图
    case 9://第七关关卡地图
    case 8://第六关关卡地图
    case 7://第五关关卡地图
    case 6://第四关关卡地图
    case 5://第三关关卡地图
    case 4://第二关关卡地图
    case 3://第一关关卡地图
        {
            // 人物移动函数
            GameMove();
            g_UseTime += fDeltaTime;
            //可以在游戏中显示所用时间
            // 记录主角的攻击间隔时间
            Z_attackTime += fDeltaTime;
            // 记录Boss的攻击间隔
            B_attackTime += fDeltaTime;
            // 记录场地发动进攻的时间间隔
            O_attackTime += fDeltaTime;
            // 记录小兵发动进攻的时间间隔
            for(O_i=0;O_i<6;O_i++)
            {
                //记录六个小兵的攻击间隔时间ID:0~5
                O_attTime[O_i] += fDeltaTime;
            }

            for(O_i=0;O_i<6;O_i++)
            {
                if(O_IsSkill[O_i]==0 && O_attTime[O_i]>=3 && g_xbNum > 0)
                {
                    //如果小兵不可发动攻击，且场上小兵数大于0，检测计时是否过3秒
                    //开启对应小兵接攻击功能
                    O_IsSkill[O_i]=1;
                }
            }
            // 记录主角技能1隐身时间
            S_SpeedTime += fDeltaTime;
            // 记录主角技能3静止时间
            S_SpeedTime3 += fDeltaTime;
            // 记录主角技能4静止时间
            S_SpeedTime4 += fDeltaTime;
            // 记录主角技能CD
            S_Time1 += fDeltaTime;
            S_Time2 += fDeltaTime;
            S_Time3 += fDeltaTime;
            S_Time4 += fDeltaTime;
            // 记录主角的受攻击时间
            Z_hurtTime += fDeltaTime;
            // 记录Boss的受攻击间隔时间
            B_JiangeTime += fDeltaTime;

            // 显示本局用时
            SysTime(g_UseTime);
            // 记录小兵的受攻击间隔时间
            for(O_i=0;O_i<6;O_i++)
            {
                //记录六个小兵的受攻击间隔ID:0~5
                O_JiluTime[O_i] += fDeltaTime;
            }
            //捕捉主角的位置并存储
            Z_PosX = dGetSpritePositionX(Z_name);
            Z_PosY = dGetSpritePositionY(Z_name);

            //如果还有小兵未消灭，则地图禁止运动
            if(g_qianjin == 0)
            {
                dSetSpriteImmovable(g_mapname[g_WhichMap],1);
            }
            //若过去的时间大于主角的普通攻击间隔
            if (Z_attackTime>=Z_PgJiange)
            {
                //可以进行普攻
                Z_IsPugong =1;
            }
            //当主角前进到-450时，若小兵未登场，则小兵登场
            if(Z_PosX >= -450 &&  g_isLoadXb == 0)
            {
                //删除GOGOGO
                dDeleteSprite("GOGOGO");
                //克隆小兵，小兵登场
                GameClone();
                //标记小兵未发动攻击
                O_isattack = 0;
                //将g_isLoadXb置为1，表示小兵登场完毕
                g_isLoadXb = 1;
            }
            //判断主角是否可碰撞，1=可碰撞，0=不可碰撞
            //若主角被碰撞则计时1秒，结束后开启主角碰撞
             if(Z_Ishurt==0 && Z_hurtTime>=Z_hurtJg)
             {
                 //开启主角接受碰撞功能
                dSetSpriteCollisionReceive(Z_name,1);
                //标记精灵开启碰撞
                Z_Ishurt = 1;
             }
            //判断小兵是否可碰撞，1=可碰撞，0=不可碰撞
            //若小兵被碰撞则计时0.3秒，结束后开启小兵碰撞
            for(O_i=0;O_i<6;O_i++)
            {
                if(O_IsPengzhuang[O_i]==0 && O_JiluTime[O_i]>=O_PengzhuangTime)
                {
                    //如果不可碰撞，检测计时是否过0.4秒
                    //开启对应小兵接受碰撞功能
                    dSetSpriteCollisionReceive(dMakeSpriteName("xiaobing",O_i+1),1);
                    //标记精灵开启碰撞
                    O_IsPengzhuang[O_i]=1;
                }
            }
            //判断Boss是否可碰撞
            if(B_IsPengzhuang==0 && B_JiangeTime >= B_PengzhuangTime)
            {
                // 开启Boss碰撞
                dSetSpriteCollisionReceive("Boss1",1);
                // 标记Boss可碰撞
                B_IsPengzhuang = 1;
            }
            //人物技能
            //当发动一技能0.3秒且主角不可见，发动
            if (S_SpeedTime >= 0.3 && Z_IsSkill[0]==0 && g_IsU ==1)
            {
                g_IsU = 0;
                //移动人物位置
                if(S_Top == 'D')
                {
                    dSetSpritePositionX(Z_name,Z_PosX+400);
                }
                else if (S_Top == 'A')
                {
                    dSetSpritePositionX(Z_name,Z_PosX-400);
                }
                //主角可见，可移动,接受碰撞
                dSetSpriteVisible(Z_name,1);//可见
                dSetSpriteImmovable(Z_name,0);//可动
                dSetSpriteCollisionReceive(Z_name,1);//接受碰撞
            }
            //当发动三技能0.3秒且主角不可动
            if (S_SpeedTime3 >= 0.3 && Z_IsSkill[2]==0 && g_IsO==1)
            {
                g_IsO = 0;
                //主角可见，可移动,接受碰撞
                dSetSpriteVisible(Z_name,1);//可见
                dSetSpriteImmovable(Z_name,0);//可动
                dSetSpriteCollisionReceive(Z_name,1);//接受碰撞
            }
            //当发动四技能0.3秒且主角不可动
            if (S_SpeedTime4 >= 0.3 && Z_IsSkill[3]==0 && g_IsL==1)
            {
                g_IsL =0;
                //主角可见，可移动,接受碰撞
                dSetSpriteVisible(Z_name,1);//可见
                dSetSpriteImmovable(Z_name,0);//可动
                dSetSpriteCollisionReceive(Z_name,1);//接受碰撞
            }

            //技能冷却动画是否播放完毕
            if (dIsAnimateSpriteAnimationFinished("skillCD1")&&Z_level>1)
            {
                //播放完毕
                Z_IsSkill[0]=1;//可以发动技能1
            }
            //技能冷却动画是否播放完毕
            if (dIsAnimateSpriteAnimationFinished("skillCD2")&&Z_level>2)
            {
                //播放完毕
                Z_IsSkill[1]=1;//可以发动技能2
            }
            if (dIsAnimateSpriteAnimationFinished("skillCD3")&&Z_level>3)
            {
                //播放完毕
                Z_IsSkill[2]=1;//可以发动技能3
            }
            if (dIsAnimateSpriteAnimationFinished("skillCD4")&&Z_level>5)
            {
                //播放完毕
                Z_IsSkill[3]=1;//可以发动技能4
            }
            //小兵行动
            GameXbMove(Z_PosX);
            //小兵攻击
            GameXbAttack(Z_PosX);
            //判断技能动画是否在播放0=>正在播放，1=>播放完毕
            if(dIsAnimateSpriteAnimationFinished(S_pugong))
            {
                //动画播放完毕，关闭其碰撞，使其无法发送碰撞
                dSetSpriteCollisionSend(S_pugong,0);

            }
            else//动画正在播放
            {
                if(strcmp(dGetAnimateSpriteAnimationName(S_pugong),"Z_pugongAnimation1")==0)//初始的动画不发送碰撞
                {
                    dSetSpriteCollisionSend(S_pugong,0);
                }
                else
                {
                    //开启碰撞，令其可以发送碰撞
                    dSetSpriteCollisionSend(S_pugong,1);
                }

            }
            //如果地图运动到400这个位置，那么加载第二波兵
            if(dGetSpritePositionX(g_mapname[g_WhichMap])<=400 && g_isLoadXb2 == 0)
            {
                //克隆第二波
                //克隆小兵，小兵登场
                GameClone();
                //标记小兵未发动攻击
                O_isattack = 0;
                //将g_isLoadXb置为1，表示小兵登场完毕
                g_isLoadXb2 = 1;
            }
            //如果地图运动到-400这个位置，那么加载第三波兵
            if(dGetSpritePositionX(g_mapname[g_WhichMap])<=-400 && g_isLoadXb3 == 0)
            {
                //克隆第三波
                //克隆小兵，小兵登场
                GameClone();
                //标记小兵未发动攻击
                O_isattack = 0;
                //将g_isLoadXb置为1，表示小兵登场完毕
                g_isLoadXb3 = 1;
            }
            //判断Boss相遇是否执行
            //地图运动到-1251这个位置，将要加载Boss，判断是否加载过场动画
            if(dGetSpritePositionX(g_mapname[g_WhichMap])<=-1251 && g_isLoadGC == 1)
            {
                //地图不可动
                dSetSpriteImmovable(g_mapname[g_WhichMap],1);
                //记录是第幕过场动画
                GC_ID = 1;
                //改变地图标记
                g_WhichMap = -3;//不再进入这个循环，开始进入时间循环
                //标记清零
                for(int i=0;i<20;i++)
                {
                    GC_F[i]=0;
                }
                g_GCTime = 0;
                //break;
                //先进行过场动画===相遇
                //GameLoadGC(g_WhichGq,1);
            }


            //如果地图运动到-1251这个位置，那么加载Boss
            if(dGetSpritePositionX(g_mapname[g_WhichMap])<=-1251 && g_isLoadBoss == 0 && g_isLoadGC == 0)
            {
                //克隆Boss，Boss登场
                CloneBoss(g_WhichMap);
                //将g_isLoadXb置为1，表示Boss登场完毕
                g_isLoadBoss = 1;
            }
            // 若Boss登场，则boss开始移动
            if(g_isLoadBoss==1)
            {
                BossAction(Z_PosX);
            }

            if (Z_blood <= 0)
            {
                //dSetSpritePosition("defeat",0,0);
                dSetSpritePosition("defeat",0,-800);
                dSpriteMoveTo("defeat",0,0,g_MenuSpeed,1);
                //更新地图标记
                g_WhichMap = -2;
                //播放音效
                M_Defult = dPlaySound("Z_Defult.wav",0,1*M_vol);
            }
        }
        break;
    case -3:
        {
            g_GCTime += fDeltaTime;//记录过场所用时间
            //先进行过场动画
            GameLoadGC(g_WhichGq,GC_ID);
            break;
        }
    default:
        break;
    }
}
//==============================================================================
//
// 本局游戏结束
void GameEnd()
{
}
//==========================================================================
//
// 鼠标移动
// 参数 fMouseX, fMouseY：为鼠标当前坐标
void OnMouseMove( const float fMouseX, const float fMouseY )
{
    // 判断目前我们看到的是哪个地图
    switch(g_WhichMap)
    {
        //主菜单
    case 1:
        {
            // 鼠标移动变大特效
            // 开始游戏按钮
            if(dIsPointInSprite("Begin",fMouseX,fMouseY))
            {
                // 图片放大
                dSetSpriteScale("Begin",g_buttonlage);
                // 播放音效,只放一次
                if((F_Mflag1&0x01) == 0)
                {
                    M_MouseMove = dPlaySound("MouseMove.wav",0,1*M_vol);
                    F_Mflag1 |= 0x01;
                }
            }
            else
            {
                //图片不变化
                dSetSpriteScale("Begin",1);
                //更改音效播放计数
                F_Mflag1 &= 0xfe;
            }

            //鼠标移动变大特效
            //旧的回忆按钮
            if(dIsPointInSprite("Load",fMouseX,fMouseY))
            {
                //图片放大
                dSetSpriteScale("Load",g_buttonlage);
                // 播放音效,只放一次
                if((F_Mflag1&0x02) == 0)
                {
                    M_MouseMove = dPlaySound("MouseMove.wav",0,1*M_vol);
                    F_Mflag1 |= 0x02;
                }
            }
            else
            {
                //图片不变化
                dSetSpriteScale("Load",1);
                //更改音效播放计数
                F_Mflag1 &= 0xfd;
            }

            //鼠标移动变大特效
            //游戏介绍按钮
            if(dIsPointInSprite("Intor",fMouseX,fMouseY))
            {
                //图片放大
                dSetSpriteScale("Intor",g_buttonlage);
                // 播放音效,只放一次
                if((F_Mflag1&0x04) == 0)
                {
                    M_MouseMove = dPlaySound("MouseMove.wav",0,1*M_vol);
                    F_Mflag1 |= 0x04;
                }
            }
            else
            {
                //图片不变化
                dSetSpriteScale("Intor",1);
                //更改音效播放计数
                F_Mflag1 &= 0xfb;
            }
///////////////////////////////////////////////////////////////////////////////
            //鼠标移动变大特效
            //游戏介绍1按钮-关闭
            if(dIsPointInSprite("Intor1_Close",fMouseX,fMouseY))
            {
                //图片放大
                dSetSpriteScale("Intor1_Close",g_buttonlage);
                // 播放音效,只放一次
                if((F_Mflag2&0x001) == 0)
                {
                    M_MouseMove = dPlaySound("MouseMove.wav",0,0.7*M_vol);
                    F_Mflag2 |= 0x001;//标记置1
                }
            }
            else
            {
                //图片不变化
                dSetSpriteScale("Intor1_Close",1);
                //更改音效播放计数
                F_Mflag2 &= 0xffe;//标记置0
            }
            //游戏介绍2按钮-关闭
            if(dIsPointInSprite("Intor2_Close",fMouseX,fMouseY))
            {
                //图片放大
                dSetSpriteScale("Intor2_Close",g_buttonlage);
                // 播放音效,只放一次
                if((F_Mflag2&0x002) == 0)
                {
                    M_MouseMove = dPlaySound("MouseMove.wav",0,0.7*M_vol);
                    F_Mflag2 |= 0x002;//标记置1
                }
            }
            else
            {
                //图片不变化
                dSetSpriteScale("Intor2_Close",1);
                //更改音效播放计数
                F_Mflag2 &= 0xffd;//标记置0
            }
            //游戏介绍1按钮-下一页
            if(dIsPointInSprite("Intor_Next",fMouseX,fMouseY))
            {
                //图片放大
                dSetSpriteScale("Intor_Next",g_buttonlage);
                // 播放音效,只放一次
                if((F_Mflag2&0x004) == 0)
                {
                    M_MouseMove = dPlaySound("MouseMove.wav",0,0.7*M_vol);
                    F_Mflag2 |= 0x004;//标记置1
                }
            }
            else
            {
                //图片不变化
                dSetSpriteScale("Intor_Next",1);
                //更改音效播放计数
                F_Mflag2 &= 0xffb;//标记置0
            }
            //游戏介绍2按钮-上一页
            if(dIsPointInSprite("Intor_Back",fMouseX,fMouseY))
            {
                //图片放大
                dSetSpriteScale("Intor_Back",g_buttonlage);
                // 播放音效,只放一次
                if((F_Mflag2&0x008) == 0)
                {
                    M_MouseMove = dPlaySound("MouseMove.wav",0,0.7*M_vol);
                    F_Mflag2 |= 0x008;//标记置1
                }
            }
            else
            {
                //图片不变化
                dSetSpriteScale("Intor_Back",1);
                //更改音效播放计数
                F_Mflag2 &= 0xff7;//标记置0
            }
            //游戏介绍2按钮-A
            if(dIsPointInSprite("M_A",fMouseX,fMouseY))
            {
                //图片放大
                dSetSpriteScale("M_A",g_buttonlage);
                // 播放音效,只放一次
                if((F_Mflag2&0x010) == 0)
                {
                    M_MouseMove = dPlaySound("MouseMove.wav",0,0.7*M_vol);
                    F_Mflag2 |= 0x010;//标记置1
                }
            }
            else
            {
                //图片不变化
                dSetSpriteScale("M_A",1);
                //更改音效播放计数
                F_Mflag2 &= 0xfef;//标记置0
            }
            //游戏介绍2按钮-D
            if(dIsPointInSprite("M_D",fMouseX,fMouseY))
            {
                //图片放大
                dSetSpriteScale("M_D",g_buttonlage);
                // 播放音效,只放一次
                if((F_Mflag2&0x020) == 0)
                {
                    M_MouseMove = dPlaySound("MouseMove.wav",0,0.7*M_vol);
                    F_Mflag2 |= 0x020;//标记置1
                }
            }
            else
            {
                //图片不变化
                dSetSpriteScale("M_D",1);
                //更改音效播放计数
                F_Mflag2 &= 0xfdf;//标记置0
            }
            //游戏介绍2按钮-J
            if(dIsPointInSprite("M_J",fMouseX,fMouseY))
            {
                //图片放大
                dSetSpriteScale("M_J",g_buttonlage);
                // 播放音效,只放一次
                if((F_Mflag2&0x040) == 0)
                {
                    M_MouseMove = dPlaySound("MouseMove.wav",0,0.7*M_vol);
                    F_Mflag2 |= 0x040;//标记置1
                }
            }
            else
            {
                //图片不变化
                dSetSpriteScale("M_J",1);
                //更改音效播放计数
                F_Mflag2 &= 0xfbf;//标记置0
            }
            //游戏介绍2按钮-K
            if(dIsPointInSprite("M_K",fMouseX,fMouseY))
            {
                //图片放大
                dSetSpriteScale("M_K",g_buttonlage);
                // 播放音效,只放一次
                if((F_Mflag2&0x080) == 0)
                {
                    M_MouseMove = dPlaySound("MouseMove.wav",0,0.7*M_vol);
                    F_Mflag2 |= 0x080;//标记置1
                }
            }
            else
            {
                //图片不变化
                dSetSpriteScale("M_K",1);
                //更改音效播放计数
                F_Mflag2 &= 0xf7f;//标记置0
            }

/////////////////////////////////////////////////////////////////////////////
            //鼠标移动变大特效
            //开发人员按钮
            if(dIsPointInSprite("About",fMouseX,fMouseY))
            {
                //图片放大
                dSetSpriteScale("About",g_buttonlage);
                // 播放音效,只放一次
                if((F_Mflag1&0x08) == 0)
                {
                    M_MouseMove = dPlaySound("MouseMove.wav",0,1*M_vol);
                    F_Mflag1 |= 0x08;
                }
            }
            else
            {
                //图片不变化
                dSetSpriteScale("About",1);
                //更改音效播放计数
                F_Mflag1 &= 0xf7;
            }

            //开发人员关闭按钮
            if(dIsPointInSprite("About_Close",fMouseX,fMouseY))
            {
                //图片放大
                dSetSpriteScale("About_Close",g_buttonlage);
                // 播放音效,只放一次
                if((F_Mflag2&0x100) == 0)
                {
                    M_MouseMove = dPlaySound("MouseMove.wav",0,0.7*M_vol);
                    F_Mflag2 |= 0x100;//标记置1
                }
            }
            else
            {
                //图片不变化
                dSetSpriteScale("About_Close",1);
                //更改音效播放计数
                F_Mflag2 &= 0xeff;//标记置0
            }

/////////////////////////////////////////////////////////////////////////////////

            //鼠标移动变大特效
            //退出游戏按钮
            if(dIsPointInSprite("Exit",fMouseX,fMouseY))
            {
                //图片放大
                dSetSpriteScale("Exit",g_buttonlage);
                // 播放音效,只放一次
                if((F_Mflag1&0x10) == 0)
                {
                    M_MouseMove = dPlaySound("MouseMove.wav",0,1*M_vol);
                    F_Mflag1 |= 0x10;
                }
            }
            else
            {
                //图片不变化
                dSetSpriteScale("Exit",1);
                //更改音效播放计数
                F_Mflag1 &= 0xef;
            }
        }
        break;
    case 2://在主菜单里面咱们不设置鼠标掠过音效
        {
            // 鼠标移动变大效果
            //game1
            if(dIsPointInSprite("game1",fMouseX,fMouseY))
            {
                // 图片放大
                dSetSpriteScale("game1",g_gamelage);
            }
            else
            {
                //图片不变化
                dSetSpriteScale("game1",1);
            }
            //game2
            if(dIsPointInSprite("game2",fMouseX,fMouseY))
            {
                // 图片放大
                dSetSpriteScale("game2",g_gamelage);
            }
            else
            {
                //图片不变化
                dSetSpriteScale("game2",1);
            }
            //game3
            if(dIsPointInSprite("game3",fMouseX,fMouseY))
            {
                // 图片放大
                dSetSpriteScale("game3",g_gamelage);
            }
            else
            {
                //图片不变化
                dSetSpriteScale("game3",1);
            }
            //game4
            if(dIsPointInSprite("game4",fMouseX,fMouseY))
            {
                // 图片放大
                dSetSpriteScale("game4",g_gamelage);
            }
            else
            {
                //图片不变化
                dSetSpriteScale("game4",1);
            }
            //game5
            if(dIsPointInSprite("game5",fMouseX,fMouseY))
            {
                // 图片放大
                dSetSpriteScale("game5",g_gamelage);
            }
            else
            {
                //图片不变化
                dSetSpriteScale("game5",1);
            }
            //game6
            if(dIsPointInSprite("game6",fMouseX,fMouseY))
            {
                // 图片放大
                dSetSpriteScale("game6",g_gamelage);
            }
            else
            {
                //图片不变化
                dSetSpriteScale("game6",1);
            }
            //game7
            if(dIsPointInSprite("game7",fMouseX,fMouseY))
            {
                // 图片放大
                dSetSpriteScale("game7",g_gamelage);
            }
            else
            {
                //图片不变化
                dSetSpriteScale("game7",1);
            }
            //game8
            if(dIsPointInSprite("game8",fMouseX,fMouseY))
            {
                // 图片放大
                dSetSpriteScale("game8",g_gamelage);
            }
            else
            {
                //图片不变化
                dSetSpriteScale("game8",1);
            }
            //game9
            if(dIsPointInSprite("game9",fMouseX,fMouseY))
            {
                // 图片放大
                dSetSpriteScale("game9",g_gamelage);
            }
            else
            {
                //图片不变化
                dSetSpriteScale("game9",1);
            }
            //设置按钮
            if(dIsPointInSprite("buttonsz",fMouseX,fMouseY))
            {
                // 图片放大
                dSetSpriteScale("buttonsz",g_otherlage);
            }
            else
            {
                //图片不变化
                dSetSpriteScale("buttonsz",1);
            }
            //图鉴按钮
            if(dIsPointInSprite("buttontj",fMouseX,fMouseY))
            {
                // 图片放大
                dSetSpriteScale("buttontj",g_otherlage);
            }
            else
            {
                //图片不变化
                dSetSpriteScale("buttontj",1);
            }
             //属性按钮
            if(dIsPointInSprite("buttonsx",fMouseX,fMouseY))
            {
                // 图片放大
                dSetSpriteScale("buttonsx",g_otherlage);
            }
            else
            {
                //图片不变化
                dSetSpriteScale("buttonsx",1);
            }
        }
        break;
    case -1:// 主菜单的弹出界面鼠标掠过效果
        {
            //属性菜单的关闭按钮
            if(dIsPointInSprite("menusx_close",fMouseX,fMouseY))
            {
                // 图片放大
                dSetSpriteScale("menusx_close",g_otherlage);
            }
            else
            {
                //图片不变化
                dSetSpriteScale("menusx_close",1);
            }
            //设置菜单的关闭按钮
            if(dIsPointInSprite("menusz_close",fMouseX,fMouseY))
            {
                // 图片放大
                dSetSpriteScale("menusz_close",g_otherlage);
            }
            else
            {
                //图片不变化
                dSetSpriteScale("menusz_close",1);
            }
            //设置菜单的退出按钮
            if(dIsPointInSprite("menusz_exit",fMouseX,fMouseY))
            {
                // 图片放大
                dSetSpriteScale("menusz_exit",g_buttonlage);
            }
            else
            {
                //图片不变化
                dSetSpriteScale("menusz_exit",1);
            }
            //设置菜单的返回主页按钮
            if(dIsPointInSprite("menusz_backhome",fMouseX,fMouseY))
            {
                // 图片放大
                dSetSpriteScale("menusz_backhome",g_buttonlage);
            }
            else
            {
                //图片不变化
                dSetSpriteScale("menusz_backhome",1);
            }
            //图鉴菜单的关闭按钮
            if(dIsPointInSprite("menutj_close",fMouseX,fMouseY))
            {
                // 图片放大
                dSetSpriteScale("menutj_close",g_otherlage);
            }
            else
            {
                //图片不变化
                dSetSpriteScale("menutj_close",1);
            }
            //图鉴菜单的上一篇按钮
            if(dIsPointInSprite("menutj_back",fMouseX,fMouseY))
            {
                // 图片放大
                dSetSpriteScale("menutj_back",g_otherlage);
            }
            else
            {
                //图片不变化
                dSetSpriteScale("menutj_back",1);
            }
            //图鉴菜单的下一篇按钮
            if(dIsPointInSprite("menutj_next",fMouseX,fMouseY))
            {
                // 图片放大
                dSetSpriteScale("menutj_next",g_otherlage);
            }
            else
            {
                //图片不变化
                dSetSpriteScale("menutj_next",1);
            }

        }
        break;
    case 11:    //地图9的鼠标掠过效果
    case 10:    //地图8的鼠标掠过效果
    case 9:     //地图7的鼠标掠过效果
    case 8:     //地图6的鼠标掠过效果
    case 7:     //地图5的鼠标掠过效果
    case 6:     //地图4的鼠标掠过效果
    case 5:     //地图3的鼠标掠过效果
    case 4:     //地图2的鼠标掠过效果
    case 3:     //地图1的鼠标掠过效果
        {
            //设置按钮
            if(dIsPointInSprite("game1sz",fMouseX,fMouseY))
            {
                // 图片放大
                dSetSpriteScale("game1sz",g_otherlage);
            }
            else
            {
                //图片不变化
                dSetSpriteScale("game1sz",1);
            }
        }
        break;
    //TODO:
    case -2://关卡1弹出界面鼠标掠过效果
        {
            //设置-关闭按钮
            if(dIsPointInSprite("menusz_close",fMouseX,fMouseY))
            {
                // 图片放大
                dSetSpriteScale("menusz_close",g_otherlage);
            }
            else
            {
                //图片不变化
                dSetSpriteScale("menusz_close",1);
            }
            //设置-返回地图按钮
            if(dIsPointInSprite("menusz_back",fMouseX,fMouseY))
            {
                // 图片放大
                dSetSpriteScale("menusz_back",g_otherlage);
            }
            else
            {
                //图片不变化
                dSetSpriteScale("menusz_back",1);
            }
            //设置-再次挑战按钮
            if(dIsPointInSprite("menusz_re",fMouseX,fMouseY))
            {
                // 图片放大
                dSetSpriteScale("menusz_re",g_otherlage);
            }
            else
            {
                //图片不变化
                dSetSpriteScale("menusz_re",1);
            }

            //再次挑战按钮
            if(dIsPointInSprite("defeat_re",fMouseX,fMouseY))
            {
                // 图片放大
                dSetSpriteScale("defeat_re",g_otherlage);
            }
            else
            {
                //图片不变化
                dSetSpriteScale("defeat_re",1);
            }

            //返回地图按钮
            if(dIsPointInSprite("defeat_back",fMouseX,fMouseY))
            {
                // 图片放大
                dSetSpriteScale("defeat_back",g_otherlage);
            }
            else
            {
                //图片不变化
                dSetSpriteScale("defeat_back",1);
            }

            //返回地图按钮
            if(dIsPointInSprite("victory_back",fMouseX,fMouseY))
            {
                // 图片放大
                dSetSpriteScale("victory_back",g_otherlage);
            }
            else
            {
                //图片不变化
                dSetSpriteScale("victory_back",1);
            }

            //下一关卡按钮
            if(dIsPointInSprite("victory_next",fMouseX,fMouseY))
            {
                // 图片放大
                dSetSpriteScale("victory_next",g_otherlage);
            }
            else
            {
                //图片不变化
                dSetSpriteScale("victory_next",1);
            }
        }
        break;
    default:
        break;
    }
}
//==========================================================================
//
// 鼠标点击
// 参数 iMouseType：鼠标按键值，见 enum MouseTypes 定义
// 参数 fMouseX, fMouseY：为鼠标当前坐标
void OnMouseClick( const int iMouseType, const float fMouseX, const float fMouseY )
{
}
//==========================================================================
//
// 鼠标弹起
// 参数 iMouseType：鼠标按键值，见 enum MouseTypes 定义
// 参数 fMouseX, fMouseY：为鼠标当前坐标
void OnMouseUp( const int iMouseType, const float fMouseX, const float fMouseY )
{
        switch(g_WhichMap)
    {
    case 1://主菜单
        {
            //点击开始游戏
            if(dIsPointInSprite("Begin",fMouseX,fMouseY))
            {
                // 播放音效,只放一次
                M_MouseMove = dPlaySound("ClickMenu.wav",0,1*M_vol);
                //执行开始游戏命令
                //初始化地图菜单界面
                //进行到第几关，显示什么属性图鉴内容显示什么
                //本选项为重新开始一切重置为默认值
                Z_gongji = 10;
                Z_shengming = 100;
                Z_speed = 200;
                Z_fangyv = 10;
                Z_hurtID = 1/(1+(Z_fangyv/100.0)); //更新主角的减伤系数
                Z_jingyan = 0;
                Z_levelMax = 30;
                Z_level = 1;
                g_Whichgame = 0;
                // 初始化图鉴菜单显示的图鉴图像数组
                g_Tujian[0] = "TJying1ImageMap";
                g_Tujian[1] = "TJying2ImageMap";
                g_Tujian[2] = "TJying3ImageMap";
                g_Tujian[3] = "TJying4ImageMap";
                g_Tujian[4] = "TJying5ImageMap";
                g_Tujian[5] = "TJying6ImageMap";
                g_Tujian[6] = "TJying7ImageMap";
                g_Tujian[7] = "TJying8ImageMap";
                g_Tujian[8] = "TJying9ImageMap";
                //载入地图主菜单界面
                //暂时不更换音乐
                dLoadMap("MapMenu.t2d");
                //更新地图标记
                g_WhichMap = 2;
                //初始化地图
                g_iGameState=1;
            }

            //点击旧的回忆
            if(dIsPointInSprite("load",fMouseX,fMouseY))
            {
                // 播放音效,只放一次
                M_MouseMove = dPlaySound("ClickMenu.wav",0,1*M_vol);
                //载入存档
                GameLoad();
                //载入地图主菜单界面
                dLoadMap("MapMenu.t2d");
                //更新地图标记
                g_WhichMap = 2;
                //初始化地图
                g_iGameState=1;

            }
            //点击游戏介绍
            if(dIsPointInSprite("Intor",fMouseX,fMouseY))
            {
                // 播放音效,只放一次
                M_MouseMove = dPlaySound("ClickMenu.wav",0,1*M_vol);
                //按钮挪走
                GameMenuGo(1);
                //介绍挪下来
                dSetSpritePosition("M_Intor1",225,-700.0);//定位
                dSpriteMoveTo("M_Intor1",225,4,2*g_MenuSpeed,1);
            }
            //点击游戏介绍1的关闭
            if(dIsPointInSprite("Intor1_Close",fMouseX,fMouseY))
            {
                // 播放音效,只放一次
                M_MouseMove = dPlaySound("ClickMenu.wav",0,1*M_vol);
                //介绍挪走
                dSpriteMoveTo("M_Intor1",225,-700,2*g_MenuSpeed,1);
                //按钮回来
                GameMenuBack(1);
            }
            //点击游戏介绍1的下一页
            if(dIsPointInSprite("Intor_Next",fMouseX,fMouseY))
            {
                // 播放音效,只放一次
                M_MouseMove = dPlaySound("ClickMenu.wav",0,1*M_vol);
                //介绍1挪走
                dSetSpritePosition("M_Intor1",225,-700.0);//瞬移走人
                //介绍2挪回来
                dSetSpritePosition("M_Intor2",225,4.0);//瞬移回来
                // 播放动画
                dSetSpriteFlipX(Z_name,0);//不翻转图片
                dAnimateSpritePlayAnimation(Z_name,Z_stand,0);
            }
            //点击游戏介绍2的关闭
            if(dIsPointInSprite("Intor2_Close",fMouseX,fMouseY))
            {
                // 播放音效,只放一次
                M_MouseMove = dPlaySound("ClickMenu.wav",0,1*M_vol);
                //介绍挪走
                dSpriteMoveTo("M_Intor2",225,-700,2*g_MenuSpeed,1);
                //按钮回来
                GameMenuBack(1);
            }
            //点击游戏介绍2的上一页
            if(dIsPointInSprite("Intor_Back",fMouseX,fMouseY))
            {
                // 播放音效,只放一次
                M_MouseMove = dPlaySound("ClickMenu.wav",0,1*M_vol);
                //介绍2挪走
                dSetSpritePosition("M_Intor2",225,-700.0);//瞬移走人
                //介绍1挪回来
                dSetSpritePosition("M_Intor1",225,4.0);//瞬移回来
            }
            //点击ADJK
            if(dIsPointInSprite("M_A",fMouseX,fMouseY))
            {
                // 播放音效,只放一次
                M_MouseMove = dPlaySound("ClickMenu.wav",0,0.7*M_vol);
                // 切换介绍文字
                dSetStaticSpriteImage("M_text","Main_AImageMap",0);
                // 播放动画
                dAnimateSpritePlayAnimation(Z_name,"Z_run2Animation",0);
            }
            //点击ADJK
            if(dIsPointInSprite("M_D",fMouseX,fMouseY))
            {
                // 播放音效,只放一次
                M_MouseMove = dPlaySound("ClickMenu.wav",0,0.7*M_vol);
                // 切换介绍文字
                dSetStaticSpriteImage("M_text","Main_DImageMap",0);
                // 播放动画
                dAnimateSpritePlayAnimation(Z_name,Z_run,0);
            }
            //点击ADJK
            if(dIsPointInSprite("M_J",fMouseX,fMouseY))
            {
                // 播放音效,只放一次
                M_MouseMove = dPlaySound("ClickMenu.wav",0,0.7*M_vol);
                // 切换介绍文字
                dSetStaticSpriteImage("M_text","Main_JImageMap",0);
                // 播放动画
                dAnimateSpritePlayAnimation(Z_name,Z_stand,0);
                //播放攻击动画
                dAnimateSpritePlayAnimation(Z_name,Z_attack,1);
                //播放攻击特效动画
                dAnimateSpritePlayAnimation(S_pugong,Z_pugong,0);
            }
            //点击ADJK
            if(dIsPointInSprite("M_K",fMouseX,fMouseY))
            {
                // 播放音效,只放一次
                M_MouseMove = dPlaySound("ClickMenu.wav",0,0.7*M_vol);
                // 切换介绍文字
                dSetStaticSpriteImage("M_text","Main_KImageMap",0);
                // 播放动画
                dSetSpriteFlipX(Z_name,0);//不翻转图片
                dAnimateSpritePlayAnimation(Z_name,Z_stand,0);
            }
            //点击开发人员
            if(dIsPointInSprite("About",fMouseX,fMouseY))
            {
                // 播放音效,只放一次
                M_MouseMove = dPlaySound("ClickMenu.wav",0,1*M_vol);
                //按钮挪走
                GameMenuGo(1);
                //开发人员挪下来
                dSetSpritePosition("M_About",225,-700.0);//定位
                dSpriteMoveTo("M_About",225,4,2*g_MenuSpeed,1);
            }
            //点击开发人员的关闭
            if(dIsPointInSprite("About_Close",fMouseX,fMouseY))
            {
                // 播放音效,只放一次
                M_MouseMove = dPlaySound("ClickMenu.wav",0,1*M_vol);
                //介绍挪走
                dSpriteMoveTo("M_About",225,-700,2*g_MenuSpeed,1);
                //按钮回来
                GameMenuBack(1);
            }
            //点击退出游戏
            if(dIsPointInSprite("Exit",fMouseX,fMouseY))
            {
                // 播放音效,只放一次
                M_MouseMove = dPlaySound("ClickMenu.wav",0,1*M_vol);
                // 游戏结束。调用游戏结算函数，并把游戏状态修改为结束状态
                g_iGameState = 0;
                //停止音乐
                dStopSound(M_BGMXWX);
                exit(0);
            }

        }
        break;
    case 2:// map菜单
        {
            //game1自动开启无需检查
            if(dIsPointInSprite("game1",fMouseX,fMouseY))
            {
                // 播放音效,只放一次
                M_MouseMove = dPlaySound("ClickMenu.wav",0,1*M_vol);
                //加载地图
                dLoadMap("Game1.t2d");
                //更新地图标记
                g_WhichMap = 3;
                //初始化地图
                g_iGameState=1;
            }
            //点击game2响应
            if(dIsPointInSprite("game2",fMouseX,fMouseY))
            {
                if(g_Whichgame < 1)//若第一关未通过，禁用点击响应
                    break;
                // 播放音效,只放一次
                M_MouseMove = dPlaySound("ClickMenu.wav",0,1*M_vol);
                //加载地图
                dLoadMap("Game2.t2d");
                //更新地图标记
                g_WhichMap = 4;
                //初始化地图
                g_iGameState=1;
            }
            //点击game3响应
            if(dIsPointInSprite("game3",fMouseX,fMouseY))
            {
                if(g_Whichgame < 2)//若第二关未通过，禁用点击响应
                    break;
                // 播放音效,只放一次
                M_MouseMove = dPlaySound("ClickMenu.wav",0,1*M_vol);
                //加载地图
                dLoadMap("Game3.t2d");
                //更新地图标记
                g_WhichMap = 5;
                //初始化地图
                g_iGameState=1;
            }
            //点击game4响应
            if(dIsPointInSprite("game4",fMouseX,fMouseY))
            {
                if(g_Whichgame < 3)//若第三关未通过，禁用点击响应
                    break;
                // 播放音效,只放一次
                M_MouseMove = dPlaySound("ClickMenu.wav",0,1*M_vol);
                //加载地图
                dLoadMap("Game4.t2d");
                //更新地图标记
                g_WhichMap = 6;
                //初始化地图
                g_iGameState=1;
            }
            //点击game5响应
            if(dIsPointInSprite("game5",fMouseX,fMouseY))
            {
                if(g_Whichgame < 4)//若第四关未通过，禁用点击响应
                    break;
                // 播放音效,只放一次
                M_MouseMove = dPlaySound("ClickMenu.wav",0,1*M_vol);
                //加载地图
                dLoadMap("Game5.t2d");
                //更新地图标记
                g_WhichMap = 7;
                //初始化地图
                g_iGameState=1;
            }
            //点击game6响应
            if(dIsPointInSprite("game6",fMouseX,fMouseY))
            {
                if(g_Whichgame < 5)//若第五关未通过，禁用点击响应
                    break;
                // 播放音效,只放一次
                M_MouseMove = dPlaySound("ClickMenu.wav",0,1*M_vol);
                //加载地图
                dLoadMap("Game6.t2d");
                //更新地图标记
                g_WhichMap = 8;
                //初始化地图
                g_iGameState=1;
            }
            //点击game7响应
            if(dIsPointInSprite("game7",fMouseX,fMouseY))
            {
                if(g_Whichgame < 6)//若第六关未通过，禁用点击响应
                    break;
                // 播放音效,只放一次
                M_MouseMove = dPlaySound("ClickMenu.wav",0,1*M_vol);
                //加载地图
                dLoadMap("Game7.t2d");
                //更新地图标记
                g_WhichMap = 9;
                //初始化地图
                g_iGameState=1;
            }
            //点击game8响应
            if(dIsPointInSprite("game8",fMouseX,fMouseY))
            {
                if(g_Whichgame < 7)//若第七关未通过，禁用点击响应
                    break;
                // 播放音效,只放一次
                M_MouseMove = dPlaySound("ClickMenu.wav",0,1*M_vol);
                //加载地图
                dLoadMap("Game8.t2d");
                //更新地图标记
                g_WhichMap = 10;
                //初始化地图
                g_iGameState=1;
            }
            //点击game9响应
            if(dIsPointInSprite("game9",fMouseX,fMouseY))
            {
                if(g_Whichgame < 8)//若第八关未通过，禁用点击响应
                    break;
                // 播放音效,只放一次
                M_MouseMove = dPlaySound("ClickMenu.wav",0,1*M_vol);
                //加载地图
                dLoadMap("Game9.t2d");
                //更新地图标记
                g_WhichMap = 11;
                //初始化地图
                g_iGameState=1;
            }
//////////////////////////////////////////////////////////////////////

            //点击属性按钮
            if(dIsPointInSprite("buttonsx",fMouseX,fMouseY))
            {
                // 播放音效,只放一次
                M_MouseMove = dPlaySound("ClickMenu.wav",0,1*M_vol);
                //执行移动图标函数
                GameMenuGo(2);
                //加载属性菜单
                dSpriteMoveTo("menusx",0,0,3*g_MenuSpeed,1);
                //更新地图标记
                g_WhichMap = -1;
            }
            //点击图鉴按钮
            if(dIsPointInSprite("buttontj",fMouseX,fMouseY))
            {
                // 播放音效,只放一次
                M_MouseMove = dPlaySound("ClickMenu.wav",0,1*M_vol);
                //始终从第一个图鉴开始显示
                g_WhichTj = 0;
                dSetStaticSpriteImage("menutj_text",g_Tujian[g_WhichTj],0);
                //隐藏图鉴菜单的上一个按钮
                dSetSpriteVisible("menutj_back",0);
                //显示图鉴的下一个按钮
                dSetSpriteVisible("menutj_next",1);
                //执行移动图标函数
                GameMenuGo(2);
                //加载属性菜单
                dSpriteMoveTo("menutj",0,0,3*g_MenuSpeed,1);
                //更新地图标记
                g_WhichMap = -1;
            }
            //点击设置按钮
            if(dIsPointInSprite("buttonsz",fMouseX,fMouseY))
            {
                // 播放音效,只放一次
                M_MouseMove = dPlaySound("ClickMenu.wav",0,1*M_vol);
                //执行移动图标函数
                GameMenuGo(2);
                //加载设置菜单
                dSpriteMoveTo("menusz",0,0,3*g_MenuSpeed,1);
                //更新地图标记
                g_WhichMap = -1;
            }
        }
        break;
    case -1://地图菜单界面的弹出界面
        {
            //点击属性-关闭按钮
            if(dIsPointInSprite("menusx_close",fMouseX,fMouseY))
            {
                // 播放音效,只放一次
                M_MouseMove = dPlaySound("ClickMenu.wav",0,1*M_vol);
                //执行移动图标函数
                GameMenuBack(2);
                //加载属性菜单
                dSpriteMoveTo("menusx",0,-768,3*g_MenuSpeed,1);
                //更新地图标记
                g_WhichMap = 2;
            }
            //点击图鉴-关闭按钮
            if(dIsPointInSprite("menutj_close",fMouseX,fMouseY))
            {
                // 播放音效,只放一次
                M_MouseMove = dPlaySound("ClickMenu.wav",0,1*M_vol);
                //执行移动图标函数
                GameMenuBack(2);
                //加载属性菜单
                dSpriteMoveTo("menutj",0,-768,3*g_MenuSpeed,1);
                //更新地图标记
                g_WhichMap = 2;
            }
            //点击图鉴-上一篇按钮
            if(dIsPointInSprite("menutj_back",fMouseX,fMouseY))
            {
                if(g_WhichTj==0)//显示第一张时禁用此按钮
                    break;
                else{
                    // 播放音效,只放一次
                    M_MouseMove = dPlaySound("ClickMenu.wav",0,1*M_vol);
                    //将当前显示的文物图片-1
                    g_WhichTj--;
                    if(g_WhichTj==0)//如果显示第一张图片
                    {
                        //隐藏上一张按钮
                        dSetSpriteVisible("menutj_back",0);
                    }
                    //显示下一张按钮
                    dSetSpriteVisible("menutj_next",1);
                    //更新显示文物图片
                    dSetStaticSpriteImage("menutj_text",g_Tujian[g_WhichTj],0);
                }
            }
            //点击图鉴-下一篇按钮
            if(dIsPointInSprite("menutj_next",fMouseX,fMouseY))
            {
                if(g_WhichTj==8)//显示第九张时禁用此按钮
                    break;
                else{
                    // 播放音效,只放一次
                    M_MouseMove = dPlaySound("ClickMenu.wav",0,1*M_vol);
                    //将当前显示的文物图片+1
                    g_WhichTj++;
                    if(g_WhichTj==8)//如果显示第九张图片
                    {
                        //隐藏下一张按钮
                        dSetSpriteVisible("menutj_next",0);
                    }
                    //显示上一张按钮
                    dSetSpriteVisible("menutj_back",1);
                    //更新显示文物图片
                    dSetStaticSpriteImage("menutj_text",g_Tujian[g_WhichTj],0);
                }

            }
            //点击设置-关闭按钮
            if(dIsPointInSprite("menusz_close",fMouseX,fMouseY))
            {
                // 播放音效,只放一次
                M_MouseMove = dPlaySound("ClickMenu.wav",0,1*M_vol);
                //执行移动图标函数
                GameMenuBack(2);
                //加载属性菜单
                dSpriteMoveTo("menusz",0,-768,3*g_MenuSpeed,1);
                //更新地图标记
                g_WhichMap = 2;
            }
            //点击设置-返回主页按钮
            if(dIsPointInSprite("menusz_backhome",fMouseX,fMouseY))
            {
                // 播放音效,只放一次
                M_MouseMove = dPlaySound("ClickMenu.wav",0,1*M_vol);
                //加载地图
                dLoadMap("MainMenu.t2d");
                //更新地图标记
                g_WhichMap = 1;
                //初始化
                g_iGameState = 1;
            }
            //点击设置-退出按钮
            if(dIsPointInSprite("menusz_exit",fMouseX,fMouseY))
            {
                // 播放音效,只放一次
                M_MouseMove = dPlaySound("ClickMenu.wav",0,1*M_vol);
                // 游戏结束。调用游戏结算函数，并把游戏状态修改为结束状态
                g_iGameState = 0;
                //停止音乐
                dStopSound(M_BGMXWX);
                exit(0);
            }
        }
        break;
    case 11://关卡9界面
    case 10://关卡8界面
    case 9://关卡7界面
    case 8://关卡6界面
    case 7://关卡5界面
    case 6://关卡4界面
    case 5://关卡3界面
    case 4://关卡2界面
    case 3://关卡1界面
        {
            //点击设置按钮
            if(dIsPointInSprite("game1sz",fMouseX,fMouseY))
            {
                // 播放音效,只放一次
                M_MouseMove = dPlaySound("ClickMenu.wav",0,1*M_vol);
                //加载设置菜单
                dSpriteMoveTo("menusz",0,0,3*g_MenuSpeed,1);
                //更新地图标记
                g_WhichMap = -2;
                //游戏暂停
                //
            }
        }
        break;
    case -2://关卡一的弹出界面
        {
            //点击设置-关闭按钮
            if(dIsPointInSprite("menusz_close",fMouseX,fMouseY))
            {
                // 播放音效,只放一次
                M_MouseMove = dPlaySound("ClickMenu.wav",0,1*M_vol);
                //把设置菜单挪回去
                dSpriteMoveTo("menusz",0,-768,3*g_MenuSpeed,1);
                //更新地图标记,标记为原地图
                g_WhichMap = g_WhichGq + 2;
            }
            //点击设置-返回菜单按钮
            if(dIsPointInSprite("menusz_back",fMouseX,fMouseY))
            {
                // 播放音效,只放一次
                M_MouseMove = dPlaySound("ClickMenu.wav",0,1*M_vol);
                //加载地图
                dLoadMap("MapMenu.t2d");
                //更新地图标记
                g_WhichMap = 2;
                //初始化地图
                g_iGameState = 1;
            }
            //点击设置-再次挑战按钮
            if(dIsPointInSprite("menusz_re",fMouseX,fMouseY))
            {
                // 播放音效,只放一次
                M_MouseMove = dPlaySound("ClickMenu.wav",0,1*M_vol);
                //加载地图
                dLoadMap(g_Gqname[g_WhichGq-1]);
                //更新地图标记,标记为原地图
                g_WhichMap = g_WhichGq + 2;
                //初始化地图
                g_iGameState = 1;
            }
            //点击失败界面-返回菜单按钮
            if(dIsPointInSprite("defeat_back",fMouseX,fMouseY))
            {
                // 播放音效,只放一次
                M_MouseMove = dPlaySound("ClickMenu.wav",0,1*M_vol);
                //加载地图
                dLoadMap("MapMenu.t2d");
                //更新地图标记
                g_WhichMap = 2;
                //初始化地图
                g_iGameState = 1;
            }
            //点击失败界面-再次挑战按钮
            if(dIsPointInSprite("defeat_re",fMouseX,fMouseY))
            {
                // 播放音效,只放一次
                M_MouseMove = dPlaySound("ClickMenu.wav",0,1*M_vol);
                //加载地图
                dLoadMap(g_Gqname[g_WhichGq-1]);
                //更新地图标记,标记为原地图
                g_WhichMap = g_WhichGq + 2;
                //初始化地图
                g_iGameState = 1;
            }

             //点击成功界面-返回菜单按钮
            if(dIsPointInSprite("victory_back",fMouseX,fMouseY))
            {
                // 播放音效,只放一次
                M_MouseMove = dPlaySound("ClickMenu.wav",0,1*M_vol);
                //加载地图
                dLoadMap("MapMenu.t2d");
                //更新地图标记
                g_WhichMap = 2;
                //初始化地图
                g_iGameState = 1;
            }
            //点击下一关卡按钮
            if(dIsPointInSprite("victory_next",fMouseX,fMouseY))
            {
                // 播放音效,只放一次
                M_MouseMove = dPlaySound("ClickMenu.wav",0,1*M_vol);
                //加载地图
                dLoadMap(g_Gqname[g_WhichGq]);
                //更新地图标记,标记为原地图
                g_WhichMap = g_WhichGq + 3;
                //初始化地图
                g_iGameState = 1;
            }
        }
        break;
    default:
        break;
    }

}
//==========================================================================
//
// 键盘按下
// 参数 iKey：被按下的键，值见 enum KeyCodes 宏定义
// 参数 iAltPress, iShiftPress，iCtrlPress：键盘上的功能键Alt，Ctrl，Shift当前是否也处于按下状态(0未按下，1按下)
void OnKeyDown( const int iKey, const bool bAltPress, const bool bShiftPress, const bool bCtrlPress )
{
    //主角或Boss死亡，禁用人物移动
    if(Z_blood<=0||B_Blood<=0||g_WhichMap<0)
    {
        return;
    }
    else
    {
    switch(iKey)
	{
    case KEY_D:
        {
            //当D键按下时，IsD置为1
            g_IsD = 1;
            dAnimateSpritePlayAnimation(Z_name,Z_run,0);//主角开始播放前进动画前进
            dSetSpriteFlipX(Z_name,0);//不翻转图片
            //记录当前主角朝向
            Z_top = 'D';
        }
        break;
    case KEY_A://后退
        {
            //当A键按下时，IsA置为1
            g_IsA = 1;
            dAnimateSpritePlayAnimation(Z_name,Z_run,0);
            dSetSpriteFlipX(Z_name,1);//翻转图片
            //记录当前主角朝向
            Z_top = 'A';
        }
        break;
    case KEY_K://跳跃
        {
            // 当Z_jump为1时才可以跳起来
            if(Z_jump == 1)
            {
                //dSpriteMoveTo(Z_name,dGetSpritePositionX(Z_name)+dGetSpriteLinearVelocityX(Z_name),dGetSpritePositionY(Z_name)-120,160,1);
                dSetSpriteImpulseForce(Z_name,0,Z_jumphigh,0);//给人物一个Y方向的瞬时力
                Z_jump = 0;
                // 播放跳跃音效
                M_Jump = dPlaySound("Z_Jump.wav",0,1*M_vol);
            }
        }
        break;
    case KEY_J://攻击
        {
            if(Z_IsPugong ==1 )//查看是否可以普攻
            {
                //播放攻击动画
                dAnimateSpritePlayAnimation(Z_name,Z_attack,1);
                //播放攻击特效动画
                dAnimateSpritePlayAnimation(S_pugong,Z_pugong,0);
                //不可普攻
                Z_IsPugong = 0;
                //开始冷却
                Z_attackTime = 0;
                //播放普攻音效
                M_Attack = dPlaySound("Z_Attack.wav",0,1*M_vol);
            }
        }
        break;
    case KEY_U:
        {
            //当三、四技能未发动时，发动U
            if(Z_IsSkill[0] == 1&& g_IsO==0 && g_IsL==0)
            {
                //发动技能
                SendSkill('U');
            }
        }
        break;
    case KEY_I:
        {
            if(Z_IsSkill[1] == 1)
            {
                //发动技能
                SendSkill('I');
            }
        }
        break;
    case KEY_O:
        {
             //当一、四技能未发动时，发动O
            if(Z_IsSkill[2] == 1 && g_IsU==0 && g_IsL==0)
            {
                //发动技能
                SendSkill('O');
            }
        }
        break;
    case KEY_L:
        {
            //当一、三技能未发动时，发动L
            if(Z_IsSkill[3] == 1 && g_IsU==0 && g_IsO==0)
            {
                //发动技能
                SendSkill('L');
            }
        }
        break;
    default:
        break;
    }
    }
}
//==========================================================================
//
// 键盘弹起
// 参数 iKey：弹起的键，值见 enum KeyCodes 宏定义
void OnKeyUp( const int iKey )
{
    //主角或Boss死亡，禁用人物移动
    if(Z_blood<=0||B_Blood<=0||g_WhichMap<0)
    {
        g_IsA = 0;
        g_IsD = 0;
        dSetSpriteLinearVelocityX(Z_name,0);
        if(Z_blood > 0)
        {
            dAnimateSpritePlayAnimation(Z_name,Z_stand,0);//播放静止动画
        }
        return;
    }
    else
    {
	switch(iKey)
	{
    case KEY_D://前进
        {
            dSetSpriteLinearVelocity("game1Bg1",0,0);//D键弹起地图立即静止
            // 当D弹起时，记录下D未被按下
            g_IsD =0;
            // 若A键也弹起，人物停止
            if(g_IsA==0)
            {
                dSetSpriteLinearVelocityX(Z_name,0);
                //改变当前显示的图片，人物应当静止朝向应当正确
                dAnimateSpritePlayAnimation(Z_name,Z_stand,0);//播放静止动画
                dSetSpriteFlipX(Z_name,0);
                //记录当前主角朝向
                Z_top = 'D';
            }
            else if(g_IsA==1)//若A没有弹起
            {
                dAnimateSpritePlayAnimation(Z_name,Z_run,0);
                dSetSpriteFlipX(Z_name,1);//翻转图片
                //记录当前主角朝向
                Z_top = 'A';
            }
        }
        break;
    case KEY_A://后退
        {
            // 当A弹起时，记录下A未被按下
            g_IsA =0;
            // 若D键也弹起，人物停止
            if(g_IsD==0)
            {
                dSetSpriteLinearVelocityX(Z_name,0);
                //改变当前显示的图片，人物应当静止朝向应当正确
                dAnimateSpritePlayAnimation(Z_name,Z_stand,0);//播放静止动画
                dSetSpriteFlipX(Z_name,1);
                //记录当前主角朝向
                Z_top = 'A';
            }
            else if(g_IsD==1)//若D没有弹起
            {
                dAnimateSpritePlayAnimation(Z_name,Z_run,0);//主角开始播放前进动画前进
                dSetSpriteFlipX(Z_name,0);//不翻转图片
                //记录当前主角朝向
                Z_top = 'D';
            }
        }
        break;
	}
    }
}
//===========================================================================
//
// 精灵与精灵碰撞
// 参数 szSrcName：发起碰撞的精灵名字
// 参数 szTarName：被碰撞的精灵名字
void OnSpriteColSprite( const char *szSrcName, const char *szTarName )
{
    //如果人物普攻与小兵碰撞
    if(strcmp(szSrcName,S_pugong)==0&&strncmp(szTarName,"xiaobing",7)==0)
    {
        //小怪受到一个瞬时的向后的力
        //GameXbBack(szTarName,Z_top);
        //小怪血量减少并显示
        GameXbHurt(szTarName,Z_gongji);

    }

    //如果人物技能1与小兵碰撞
    if(strcmp(szSrcName,"CsendSkill1")==0&&strncmp(szTarName,"xiaobing",7)==0)
    {
        //小怪受到一个瞬时的向后的力
        //GameXbBack(szTarName,Z_top);//取消这个受击反馈
        //小怪血量减少并显示
        GameXbHurt(szTarName,2*Z_gongji);

    }
    //如果人物技能3与小兵碰撞
    if(strcmp(szSrcName,"CsendSkill3")==0&&strncmp(szTarName,"xiaobing",7)==0)
    {
        //小怪受到一个瞬时的向后的力
        //GameXbBack(szTarName,Z_top);//取消这个受击反馈
        //小怪血量减少并显示
        GameXbHurt(szTarName,2.2*Z_gongji);

    }
    //如果人物技能4与小兵碰撞
    if(strcmp(szSrcName,"CsendSkill4")==0&&strncmp(szTarName,"xiaobing",7)==0)
    {
        //小怪受到一个瞬时的向后的力
        //GameXbBack(szTarName,Z_top);//取消这个受击反馈
        //小怪血量减少并显示
        GameXbHurt(szTarName,3.2*Z_gongji);

    }

    //如果场地技能与人物碰撞
    if(strcmp(szTarName,Z_name)==0&&strncmp(szSrcName,"XB_attack",8)==0)
    {
        //主角扣血函数，场地技能是真伤
        SubBlood(10+ g_WhichGq * 10);

    }
    //如果小兵技能与人物碰撞
    if(strcmp(szTarName,Z_name)==0&&strncmp(szSrcName,"CXB_Skill1",8)==0)
    {
        //小兵攻击伤害,伤害乘以防御系数
        SubBlood(O_hurt[g_WhichMap-3] * Z_hurtID + (rand()%5-2));

    }
        //如果人物普攻与Boss碰撞
    if(strcmp(szSrcName,S_pugong)==0&&strcmp(szTarName,"Boss1")==0)
    {
        //Boss血量减少并显示
        BossHurt(Z_gongji);

    }

    //如果人物技能1与Boss碰撞
    if(strcmp(szSrcName,"CsendSkill1")==0&&strcmp(szTarName,"Boss1")==0)
    {
        //Boss血量减少并显示
        BossHurt(2*Z_gongji);
    }
     //如果人物技能3与Boss碰撞
    if(strcmp(szSrcName,"CsendSkill3")==0&&strcmp(szTarName,"Boss1")==0)
    {
        //Boss血量减少并显示
        BossHurt(1.8*Z_gongji);
    }
     //如果人物技能4与Boss碰撞
    if(strcmp(szSrcName,"CsendSkill4")==0&&strcmp(szTarName,"Boss1")==0)
    {
        //Boss血量减少并显示
        BossHurt(3.2*Z_gongji);
    }

    //如果Boss技能与人物碰撞
    if(strcmp(szTarName,Z_name)==0&&strncmp(szSrcName,"CBoss_Skill",10)==0)
    {
        //Boss伤害=伤害乘以防御系数
        SubBlood(O_hurt[g_WhichMap-3] * Z_hurtID * 2 + (rand()%10-4));
    }

}
//===========================================================================
//
// 精灵与世界边界碰撞
// 参数 szName：碰撞到边界的精灵名字
// 参数 iColSide：碰撞到的边界 0 左边，1 右边，2 上边，3 下边
void OnSpriteColWorldLimit( const char *szName, const int iColSide )
{
    //当人物落地后，人物可以跳跃
    if(strcmp(szName,Z_name)==0&&iColSide==3)
    {
        Z_jump = 1;
    }
    //人物与世界边界碰撞后，若碰到了世界的右边界，则判断是否可以移动地图
    if(strcmp(szName,Z_name)==0&&iColSide==1)
    {
        if(g_qianjin == 1)//当g_qianjin为1时，小兵全部被杀死，地图可以前进
        {
            dSetSpriteImmovable(g_mapname[g_WhichMap],0);
        }
    }

}

//===========================================================================
//
// 将屏幕中的按钮组件移动到屏幕外
// 参数WhichMenu：指定运行的界面wellcome为0，mainmenu为1，mapmenu为2；
void GameMenuGo(int WhichMenu)
{
    switch(WhichMenu)
    {
    case 0:// wellcome界面
        break;
    case 1:// MainMenu界面
        {
            dSpriteMoveTo("M_1",850,-264,g_MenuSpeed,1);
            dSpriteMoveTo("Begin",850,-264,g_MenuSpeed,1);
            dSpriteMoveTo("M_2",850,-132,g_MenuSpeed,1);
            dSpriteMoveTo("load",850,-132,g_MenuSpeed,1);
            dSpriteMoveTo("M_3",850,0,g_MenuSpeed,1);
            dSpriteMoveTo("Intor",850,0,g_MenuSpeed,1);
            dSpriteMoveTo("M_4",850,132,g_MenuSpeed,1);
            dSpriteMoveTo("About",850,132,g_MenuSpeed,1);
            dSpriteMoveTo("M_5",850,264,g_MenuSpeed,1);
            dSpriteMoveTo("Exit",850,264,g_MenuSpeed,1);
            dSpriteMoveTo("Logo",-349,4,g_MenuSpeed,1);
        }
        break;
    case 2:// MapMenu界面
        {
            // dSpriteMoveTo：让精灵按照给定速度移动到给定坐标点
            // 参数 szName：精灵名字
            // 参数 fPosX：移动的目标X坐标值
            // 参数 fPosY：移动的目标Y坐标值
            // 参数 fSpeed：移动速度
            // 参数 iAutoStop：移动到终点之后是否自动停止, 1 停止 0 不停止
            dSpriteMoveTo("buttonsx",300,500,g_MenuSpeed,1);    //属性300,300 => 300,500
            dSpriteMoveTo("buttontj",415,500,g_MenuSpeed,1);    //图鉴415,300 => 415,500
            dSpriteMoveTo("buttonsz",530,500,g_MenuSpeed,1);    //设置530,300 => 530,500
            dSpriteMoveTo("menurw",-420,-470,g_MenuSpeed,1);    //人物框-420,-270 => -420,-470
        }
        break;
    default:
        {

        }
        break;
    }
}

//将屏幕外的按钮组件移回来
// 参数WhichMenu：指定运行的界面wellcome为0，mainmenu为1，mapmenu为2；
void GameMenuBack(int WhichMenu)
{
    switch(WhichMenu)
    {
    case 0:// wellcome界面
        break;
    case 1:// MainMenu界面
        {
            dSpriteMoveTo("M_1",216,-264,g_MenuSpeed,1);
            dSpriteMoveTo("Begin",216,-264,g_MenuSpeed,1);
            dSpriteMoveTo("M_2",266,-132,g_MenuSpeed,1);
            dSpriteMoveTo("load",266,-132,g_MenuSpeed,1);
            dSpriteMoveTo("M_3",316,0,g_MenuSpeed,1);
            dSpriteMoveTo("Intor",316,0,g_MenuSpeed,1);
            dSpriteMoveTo("M_4",266,132,g_MenuSpeed,1);
            dSpriteMoveTo("About",266,132,g_MenuSpeed,1);
            dSpriteMoveTo("M_5",216,264,g_MenuSpeed,1);
            dSpriteMoveTo("Exit",216,264,g_MenuSpeed,1);
            dSpriteMoveTo("Logo",-255,4,g_MenuSpeed,1);
        }
        break;
    case 2:// MapMenu界面
        {
            // dSpriteMoveTo：让精灵按照给定速度移动到给定坐标点
            // 参数 szName：精灵名字
            // 参数 fPosX：移动的目标X坐标值
            // 参数 fPosY：移动的目标Y坐标值
            // 参数 fSpeed：移动速度
            // 参数 iAutoStop：移动到终点之后是否自动停止, 1 停止 0 不停止
            dSpriteMoveTo("buttonsx",300,300,g_MenuSpeed,1);    //属性300,500 => 300,300
            dSpriteMoveTo("buttontj",415,300,g_MenuSpeed,1);    //图鉴415,500 => 415,300
            dSpriteMoveTo("buttonsz",530,300,g_MenuSpeed,1);    //设置530,500 => 530,300
            dSpriteMoveTo("menurw",-420,-270,g_MenuSpeed,1);    //人物框-420,-470 => -420,-270
        }
        break;
    default:
        {

        }
        break;
    }
}

//将图鉴菜单初始化
// 参数WhichMap：指定游戏目前进行到第几关了刚开始为0，打通game1为1，打通game2为2；
void GameTjInit(int WhichMap)
{
    //对图鉴菜单的按钮进行初始化
    //隐藏图鉴菜单的第一个按钮
    dSetSpriteVisible("menutj_back",0);
    //修改文物显示数组
    //修改地图显示
    switch(WhichMap)
    {
    case 9:
        g_Tujian[8]="TJtext9ImageMap";
    case 8:
        g_Tujian[7]="TJtext8ImageMap";
        dSetSpriteVisible("game9",1);
        dSetSpriteVisible("gamename9",1);
    case 7:
        g_Tujian[6]="TJtext7ImageMap";
        dSetSpriteVisible("game8",1);
        dSetSpriteVisible("gamename8",1);
    case 6:
        g_Tujian[5]="TJtext6ImageMap";
        dSetSpriteVisible("game7",1);
        dSetSpriteVisible("gamename7",1);
    case 5:
        g_Tujian[4]="TJtext5ImageMap";
        dSetSpriteVisible("game6",1);
        dSetSpriteVisible("gamename6",1);
    case 4:
        g_Tujian[3]="TJtext4ImageMap";
        dSetSpriteVisible("game5",1);
        dSetSpriteVisible("gamename5",1);
    case 3:
        g_Tujian[2]="TJtext3ImageMap";
        dSetSpriteVisible("game4",1);
        dSetSpriteVisible("gamename4",1);
    case 2:
        g_Tujian[1]="TJtext2ImageMap";
        dSetSpriteVisible("game3",1);
        dSetSpriteVisible("gamename3",1);
    case 1:
        g_Tujian[0]="TJtext1ImageMap";
        dSetSpriteVisible("game2",1);
        dSetSpriteVisible("gamename2",1);
    case 0:
        dSetSpriteVisible("game1",1);
        dSetSpriteVisible("gamename1",1);
        break;
    default:
        break;
    }
    //更新显示文物图片
    dSetStaticSpriteImage("menutj_text",g_Tujian[g_WhichTj],0);
}

// ShowShuxing：显示人物属性
void ShowShuxing(const char *szName,const int num)
{
    //更新人物的生命，防御，攻击，移速的数值
    int numB,numS,numG;
    char *sxName[]={dMakeSpriteName(szName,1),dMakeSpriteName(szName,2),dMakeSpriteName(szName,3)};
    numB = num/100;
    numS = num/10%10;
    numG = num%10;
    switch(numB)
    {
    case 0://当数字小于3位
        dSetStaticSpriteFrame(sxName[2],11);
        if(numS == 0)//为一位数时
        {
            dSetStaticSpriteFrame(sxName[1],11);
            dSetStaticSpriteFrame(sxName[0],numG);
        }
        else//为两位数时
        {
            dSetStaticSpriteFrame(sxName[0],numS);
            dSetStaticSpriteFrame(sxName[1],numG);
        }
        break;
    default:
        {
            dSetStaticSpriteFrame(sxName[0],numB);
            dSetStaticSpriteFrame(sxName[1],numS);
            dSetStaticSpriteFrame(sxName[2],numG);
        }
        break;
    }

}

//将游戏存档
void GameSave(void)
{
    FILE *g_Save; //定义文件指针
    if((g_Save = freopen("save.txt","wt+",stdout)) != NULL)
    {
        //存档
        printf("g_Whichgame:%d\nZ_gongji:%d\nZ_fangyv:%d\nZ_shengming:%d\nZ_jingyan:%d\nZ_levelmax:%d\nZ_speed:%d\nZ_level:%d\n",
               g_Whichgame,Z_gongji,Z_fangyv,Z_shengming,Z_jingyan,Z_levelMax,Z_speed,Z_level);
        fclose(g_Save);     //关闭文件
    }
}

//读取游戏存档
void GameLoad(void)
{
    FILE *g_Load; //定义文件指针
    if((g_Load = fopen("save.txt","r")) != NULL)
    {
        fscanf(g_Load,"%*[^:]:%d\n%*[^:]:%d\n%*[^:]:%d\n%*[^:]:%d\n%*[^:]:%d\n%*[^:]:%d\n%*[^:]:%d\n%*[^:]:%d\n",
               &g_Whichgame,&Z_gongji,&Z_fangyv,&Z_shengming,&Z_jingyan,&Z_levelMax,&Z_speed,&Z_level);
        fclose(g_Load);     //关闭文件
    }
}

//克隆小兵
void GameClone(void)
{
    //使用for循环克隆6个小兵
    int i;
    for(i=1;i<=3;i++)
    {
        //使用xg_1作为模板克隆3个名称为xiaobing1~3
        dCloneSprite("xg_1",dMakeSpriteName("xiaobing",i));
        //给他们位置
        dSetSpritePosition(dMakeSpriteName("xiaobing",i),400-60*i,-130);
        //克隆血条
        dCloneSprite("XT_blood",dMakeSpriteName("XT_blood",i));
        //克隆血管
        //dCloneSprite("XG_bloodbar",dMakeSpriteName("XG_bloodbar",i));
        //绑定血条 20210609
        dSpriteMountToSprite(dMakeSpriteName("XT_blood",i),dMakeSpriteName("xiaobing",i),0,-1.4);
        //dSpriteMountToSprite(dMakeSpriteName("XG_bloodbar",i),dMakeSpriteName("xiaobing",i),0,-1.4);
        //克隆完毕后让他们落地登场
        //给个常力
        dSetSpriteConstantForce(dMakeSpriteName("xiaobing",i),0,1000000,0);
        //设置小怪的血量
        O_bloodMax = 100 *(g_WhichMap-2);
        O_blood[i-1]=O_bloodMax;
        //设置小兵未被碰撞
        O_IsPengzhuang[i-1]=1;
        //置为可以发动攻击
        O_IsSkill[i-1] =1;
    }
    for(i=4;i<=6;i++)
    {
        //使用xg_1作为模板克隆3个名称为xiaobing4~6
        dCloneSprite("xg_2",dMakeSpriteName("xiaobing",i));
        //给他们位置
        dSetSpritePosition(dMakeSpriteName("xiaobing",i),-400+60*(i-3),-130);
        //克隆血条
        dCloneSprite("XT_blood",dMakeSpriteName("XT_blood",i));
        //克隆血管
        //dCloneSprite("XG_bloodbar",dMakeSpriteName("XG_bloodbar",i));
        //绑定血条 20210609
        dSpriteMountToSprite(dMakeSpriteName("XT_blood",i),dMakeSpriteName("xiaobing",i),0,-1.4);
        //dSpriteMountToSprite(dMakeSpriteName("XG_bloodbar",i),dMakeSpriteName("xiaobing",i),0,-1.4);
        //克隆完毕后让他们落地登场
        //给个常力
        dSetSpriteConstantForce(dMakeSpriteName("xiaobing",i),0,1000000,0);
        //设置小怪的血量
        O_bloodMax = 100 *(g_WhichMap-2);
        O_blood[i-1]=O_bloodMax;
        //设置小兵未被碰撞
        O_IsPengzhuang[i-1]=1;
        //置为可以发动攻击
        O_IsSkill[i-1] =1;
    }
    //克隆完毕后，将场上小兵数设为6
    g_xbNum=6;
    //克隆完毕后，场上存在小兵，地图不可移动
    g_qianjin = 0;
    //克隆完毕后开启小兵移动循环计数
    g_re =0;
    //初始化小兵攻击
    //将O_attackTime清零
    O_attackTime = 0;
    //标记为未攻击
    O_isattack = 0;

}

// 小兵移动函数
// 如果小兵距离主角太远，小兵自由运动
// 若小兵距离主角达到XXX时，小兵主动向主角移动，移速加快。
// PosX：主角的X坐标
void GameXbMove(const float PosX)
{
    int i,Num_Sj;
    float PosX_xb;//定义一个变量记录小兵当前坐标
    int View_xb=350;//定义小兵的视野，若主角在视野外，小兵进行随机慢速移动
    //小兵随机循环移动
    for(i=1;i<=6;i++,g_re++)
    {
        PosX_xb = dGetSpritePositionX(dMakeSpriteName("xiaobing",i));//获得小兵当前坐标
        //当主角处于小兵视野外时(即小兵与主角间距大于200)
        if(abs(PosX-PosX_xb)>=View_xb&&g_re<6)
        {
            //小兵进行随机移动
            //srand((unsigned)time(NULL));//为随机数播种
            Num_Sj = rand()%2;//随机产生0-1
            //判断是哪个地图的小兵
            switch(g_WhichGq)
            {
            case 1://关卡1
            case 6://关卡6，小兵不反向
                {
                    dSetSpriteFlipX(dMakeSpriteName("xiaobing",i),Num_Sj);
                    dSetSpriteLinearVelocityX(dMakeSpriteName("xiaobing",i),O_speed-Num_Sj*O_speed*2);//设置小兵速度
                    break;
                }
            case 2://关卡2，小兵反向
            case 3://关卡3，小兵反向
            case 4://关卡4，小兵反向
            case 5://关卡5，小兵反向
            case 7://关卡7，小兵反向
            case 8://关卡8，小兵反向
            case 9://关卡9，小兵反向
                {
                    dSetSpriteFlipX(dMakeSpriteName("xiaobing",i),Num_Sj);
                    dSetSpriteLinearVelocityX(dMakeSpriteName("xiaobing",i),-O_speed+Num_Sj*O_speed*2);//设置小兵速度
                    break;
                }
            }
        }
        if(g_re>12345)
        {
            g_re = -1;//g_re计数清零，再次开始随机移动
            i=0;
        }
    }
    for(i=1;i<=6;i++)
    {
        PosX_xb = dGetSpritePositionX(dMakeSpriteName("xiaobing",i));//获得小兵当前坐标
        //给小兵一个向主角移动的速度
        if(PosX-50>PosX_xb&&abs(PosX-PosX_xb)<View_xb)//主角在小兵前方,且在视野内
        {
            switch(g_WhichGq)
            {
            case 1://关卡1
            case 6://关卡6，小兵不反向
                {
                    dSetSpriteFlipX(dMakeSpriteName("xiaobing",i),0);//不转身
                    dSetSpriteLinearVelocityX(dMakeSpriteName("xiaobing",i),O_Sspeed);//设置小兵速度
                    break;
                }
            case 2://关卡2，小兵反向
            case 3://关卡3，小兵反向
            case 4://关卡4，小兵反向
            case 5://关卡5，小兵反向
            case 7://关卡7，小兵反向
            case 8://关卡8，小兵反向
            case 9://关卡9，小兵反向
                {
                    dSetSpriteFlipX(dMakeSpriteName("xiaobing",i),1);//转身
                    dSetSpriteLinearVelocityX(dMakeSpriteName("xiaobing",i),O_Sspeed);//设置小兵速度
                    break;
                }
            }
        }
        else if(PosX+50<PosX_xb&&abs(PosX-PosX_xb)<View_xb)//主角在小兵后方，且在视野内
        {
            switch(g_WhichGq)
            {
            case 1://关卡1
            case 6://关卡6，小兵不反向
                {
                    dSetSpriteFlipX(dMakeSpriteName("xiaobing",i),1);//转身
                    dSetSpriteLinearVelocityX(dMakeSpriteName("xiaobing",i),-O_Sspeed);//设置小兵速度
                    break;
                }
            case 2://关卡2，小兵反向
            case 3://关卡3，小兵反向
            case 4://关卡4，小兵反向
            case 5://关卡5，小兵反向
            case 7://关卡7，小兵反向
            case 8://关卡8，小兵反向
            case 9://关卡9，小兵反向
                {
                    dSetSpriteFlipX(dMakeSpriteName("xiaobing",i),0);//不转身
                    dSetSpriteLinearVelocityX(dMakeSpriteName("xiaobing",i),-O_Sspeed);//设置小兵速度
                    break;
                }
            }
        }
        else if(abs(PosX-PosX_xb)<View_xb && O_IsSkill[i-1]==1)    //当小怪在主角附近时,若可以发动进攻，发动进攻
        {
            //发动进攻
            //克隆技能动画到小兵位置
            //随机产生一个数字
            switch(g_WhichGq)
            {
            case 1:
            case 6:
                {
                    char *Skillname = (char *)O_Skillname[rand()%3];
                    char *name = (char *)malloc(strlen(Skillname) + strlen(firstname));
                    strcpy(name,firstname);
                    strcat(name,Skillname);
                    dCloneSprite(Skillname,dMakeSpriteName(name,i));
                    //以上产生一个技能字符串
                    dSpriteMountToSpriteLinkPoint(dMakeSpriteName(name,i),dMakeSpriteName("xiaobing",i),2);
                    dSetSpriteLinearVelocityX(dMakeSpriteName("xiaobing",i),0);//设置小兵速度
                    //设置技能生命值
                    dSetSpriteLifeTime(dMakeSpriteName(name,i),0.3);
                    break;
                }
            case 9:
            case 8:
            case 7:
            case 5:
            case 4:
            case 3:
            case 2:
                {
                    char *Skillname = (char *)O_Skillname[rand()%4+3];
                    char *name = (char *)malloc(strlen(Skillname) + strlen(firstname));
                    strcpy(name,firstname);
                    strcat(name,Skillname);
                    dCloneSprite(Skillname,dMakeSpriteName(name,i));
                    //以上产生一个技能字符串
                    //dSetSpriteFlipX(dMakeSpriteName(name,i),1);//翻转技能
                    dSpriteMountToSpriteLinkPoint(dMakeSpriteName(name,i),dMakeSpriteName("xiaobing",i),3);
                    dSetSpriteLinearVelocityX(dMakeSpriteName("xiaobing",i),0);//设置小兵速度
                    //设置技能生命值
                    dSetSpriteLifeTime(dMakeSpriteName(name,i),0.3);
                    break;
                }
            }
            O_attTime[i-1] = 0;  //开始计时
            //在运行函数中判断
            //开始冷却，技能置为不可用
            O_IsSkill[i-1] = 0;

        }
    }
}

// 小兵受到攻击后退函数
// szName：小兵精灵名
// top：主角朝向
void GameXbBack(const char *szName,int top)
{
    //给小兵一个瞬间的推力
    if(g_IsL == 1 || g_IsU ==1 || g_IsO == 1)//主角释放技能时无法碰撞
    {
       return;
    }
    switch(top)
    {
    case 'D'://朝前推
        dSetSpriteImpulseForce(szName,3000,0,0);
        break;
    case 'A'://朝后退
        dSetSpriteImpulseForce(szName,-3000,0,0);
        break;
    }
}

// GameXbHurt：小兵扣血函数
// szName：小怪精灵名
int GameXbHurt(const char *szName,int hurtnum)
{
    //小兵后退
    GameXbBack(szName,Z_top);
    //给小兵一个护甲
    int Hj = g_WhichGq * 2 + 9;
    float HJXS = 1/(1+Hj/100);
    //确定具体伤害数值
    hurtnum = hurtnum * HJXS + (rand()%3-2);
    //确认识那个小兵受到了攻击
    int len = strlen(szName);
    int i;
    i = *&szName[len-1]-48;
    if(i>7||i<0)
    {
        return 0;
    }
    //播放小兵受伤声音
    M_OHurt = dPlaySound("O_Hurt.wav",0,1*M_vol);
    //关闭这个小兵接收碰撞功能
    dSetSpriteCollisionReceive(szName,0);
    //计时清零，开始计时
    O_JiluTime[i-1]=0;
    //标记精灵已关闭碰撞
    O_IsPengzhuang[i-1] = 0;
    //扣除血量
    O_blood[i-1]-=hurtnum;
    //显示的扣除血量
    GameShowNum("num_shanghai",hurtnum,dGetSpritePositionX(szName),dGetSpritePositionY(szName));
    //小兵血条缩短
    BloodLen(dMakeSpriteName("XT_blood",i),60,O_bloodMax,O_blood[i-1],dGetSpritePositionX(dMakeSpriteName("XT_blood",i)));
    //血量见底后删除该精灵
    if(O_blood[i-1]<=0)
    {
        //删除精灵
        dDeleteSprite(szName);
        //加主角经验
        Addjingya(g_WhichGq*2);//第几关的小怪加多少经验
        //场上小怪计数-1
        g_xbNum--;
        //当场上小兵数为零时，地图可以移动
        if(g_xbNum == 0)
        {
            g_qianjin = 1;
        }
    }
return 1;
}

// 数值显示函数
// szName：显示那种字体的数值'被克隆的数值精灵名'
// num：显示的数值
// PosX：显示的数值的X位置
// PosY: 显示的数值的Y位置
void GameShowNum(const char *szName,const int num,const float PosX,const float PosY)
{
    //判断这个数值是几位数,
    int numB,numS,numG;
    char *numname1;
    char *numname2;
    char *numname3;
    numB = num/100;
    numS = num/10%10;
    numG = num%10;
    if(O_numSprite >= 2000)
    {
        //数字精灵满1000清一次
        O_numSprite = 0;
    }
    switch(numB)
    {
    case 0://当数字小于3位
        if(numS == 0)//为一位数时
        {
            //克隆一个数字精灵，显示这个数字
            numname1 = dMakeSpriteName("num_",O_numSprite);
            dCloneSprite(szName,numname1);//克隆
            O_numSprite++;
            dSetStaticSpriteFrame(numname1,numG);//显示数值
            //设置精灵位置
            dSetSpritePosition(numname1,PosX,PosY-120);
            //逐渐上移
            dSetSpriteLinearVelocity(numname1,0.f,-25.f);
            //设置其生命 0.8秒
            dSetSpriteLifeTime(numname1,0.8);
        }
        else//为两位数时
        {
            numname1 = dMakeSpriteName("num_",O_numSprite);
            dCloneSprite(szName,numname1);//克隆
            O_numSprite++;
            numname2 = dMakeSpriteName("num_",O_numSprite);
            dCloneSprite(szName,numname2);//克隆
            O_numSprite++;
            dSetStaticSpriteFrame(numname1,numS);
            dSetStaticSpriteFrame(numname2,numG);
            //设置精灵位置
            dSetSpritePosition(numname1,PosX-9,PosY-120);
            dSetSpritePosition(numname2,PosX+9,PosY-120);
            //逐渐上移
            dSetSpriteLinearVelocity(numname1,0.f,-25.f);
            dSetSpriteLinearVelocity(numname2,0.f,-25.f);
            //设置其生命 0.8秒
            dSetSpriteLifeTime(numname1,0.8);
            dSetSpriteLifeTime(numname2,0.8);
        }
        break;
    default:
        {
            numname1 = dMakeSpriteName("num_",O_numSprite);
            dCloneSprite(szName,numname1);//克隆
            O_numSprite++;
            numname2 = dMakeSpriteName("num_",O_numSprite);
            dCloneSprite(szName,numname2);//克隆
            O_numSprite++;
            numname3 = dMakeSpriteName("num_",O_numSprite);
            dCloneSprite(szName,numname3);//克隆
            O_numSprite++;
            dSetStaticSpriteFrame(numname1,numB);
            dSetStaticSpriteFrame(numname2,numS);
            dSetStaticSpriteFrame(numname3,numG);
            //设置精灵位置
            dSetSpritePosition(numname1,PosX-18,PosY-120);
            dSetSpritePosition(numname2,PosX,PosY-120);
            dSetSpritePosition(numname3,PosX+18,PosY-120);
            //逐渐上移
            dSetSpriteLinearVelocity(numname1,0.f,-25.f);
            dSetSpriteLinearVelocity(numname2,0.f,-25.f);
            dSetSpriteLinearVelocity(numname3,0.f,-25.f);
            //设置其生命 0.8秒
            dSetSpriteLifeTime(numname1,0.8);
            dSetSpriteLifeTime(numname2,0.8);
            dSetSpriteLifeTime(numname3,0.8);
        }
        break;
    }
}


// 场景攻击函数
// PosX：主角X位置
void GameXbAttack(const float PosX)
{
    //如果场景内存在小兵
    if(g_xbNum > 0)
    {
        if (O_attackTime >= O_attack && O_attackTime <= O_attack*2 && O_isattack == 0)
        {
            O_attackPosX = PosX;//记录当前主角的位置
            //进攻前一秒钟，提示
            //克隆一个提示动画，名字为XB_hint设置位置，生命为O_attack
            dCloneSprite("S_XBhint","XB_hint");
            dSetSpritePosition("XB_hint",O_attackPosX,262);
            dSetSpriteLifeTime("XB_hint",O_attack);

            //标记为已攻击
            O_isattack = 1;
        }
        else if(O_attackTime > O_attack*2 && O_isattack == 1)
        {
            //进攻
            //克隆一个攻击动画，名字为XB_attack1设置位置，生命为0.3
            dCloneSprite("S_XBattack1","XB_attack1");
            dSetSpritePosition("XB_attack1",O_attackPosX,62);
            dSetSpriteLifeTime("XB_attack1",0.3);

            //将O_attackTime清零
            O_attackTime = 0;
            //标记为未攻击
            O_isattack = 0;
        }
    }
}


// 改变血条/经验条长度
// szName：待改变的血条名称
// Oldlen：原血条长度
// Z_blood：总血量
// N_blood：现在的血量
// PosX：原血条的X位置
void BloodLen(const char *szName,const float Oldlen,const int Z_blood,const int N_blood,const float PosX)
{
    float Newlen,NewPosX;
    // 计算出新血条的长度
    Newlen = (float)N_blood/Z_blood * Oldlen;
    if (Z_blood == 0 && N_blood == 0 && Z_level == 9 && strcmp(szName,Z_LevelName)==0)
    {
        Newlen = Oldlen;
    }
    // 计算出新血条的PosX位置
    NewPosX = PosX - (Oldlen - Newlen)/2;
    // 设置新血条的长度
    dSetSpriteWidth(szName,Newlen);
    // 设置新血条的位置
    dSetSpritePositionX(szName,NewPosX);
}

// 改变血条/经验条数值
// flag：改变什么，0=> 血量值， 1=>经验值， 2=>血量最大值， 3=>经验最大值
// num：改变为什么数
void ShowNum(const int flag, const int num)
{
    //判断这个数值是几位数,
    int numB,numS,numG;
    int numn = num;
    const char* szName[4][3]={{"BloodNum_3","BloodNum_2","BloodNum_1"},{"levelNum_3","levelNum_2","levelNum_1"},
                              {"BloodMax_1","BloodMax_2","BloodMax_3"},{"levelMax_1","levelMax_2","levelMax_3"}};
    if(numn / 1000 > 0)
    {
        numn = numn / 10;
        if(numn / 1000 > 0)
        {
            numn = numn / 10;
        }
    }
    numB = numn/100;
    numS = numn/10%10;
    numG = numn%10;
    switch(numB)
    {
    case 0://当数字小于3位
        dSetStaticSpriteFrame(szName[flag][2] ,13);
        if(numS == 0)//为一位数时
        {
            dSetStaticSpriteFrame(szName[flag][1],13);
            dSetStaticSpriteFrame(szName[flag][0],numG+2);
        }
        else//为两位数时
        {
            if(flag ==0||flag==1)
            {
                dSetStaticSpriteFrame(szName[flag][1],numS+2);
                dSetStaticSpriteFrame(szName[flag][0],numG+2);
            }
            else
            {
                dSetStaticSpriteFrame(szName[flag][0],numS+2);
                dSetStaticSpriteFrame(szName[flag][1],numG+2);
            }
        }
        break;
    default:
        {
            if(flag == 0||flag==1)
            {
                dSetStaticSpriteFrame(szName[flag][2],numB+2);
                dSetStaticSpriteFrame(szName[flag][1],numS+2);
                dSetStaticSpriteFrame(szName[flag][0],numG+2);
            }
            else
            {
                dSetStaticSpriteFrame(szName[flag][0],numB+2);
                dSetStaticSpriteFrame(szName[flag][1],numS+2);
                dSetStaticSpriteFrame(szName[flag][2],numG+2);
            }
        }
        break;
    }
}

// ShowMap: Map地图初始化
void ShowMap(const int level, const int shengming)
{
    //等级初始化
    dSetStaticSpriteFrame("Maplevel",level-1);
    //血量显示
    int g = shengming % 10;
    int s = shengming % 100 / 10;
    int b = shengming / 100;
    dSetStaticSpriteFrame("bloodnum_g",g);
    dSetStaticSpriteFrame("bloodnum_s",s);
    dSetStaticSpriteFrame("bloodnum_b",b);

    dSetStaticSpriteFrame("bloodzong_s",g);
    dSetStaticSpriteFrame("bloodzong_b",s);
    dSetStaticSpriteFrame("bloodzong_q",b);
    //展示界面初始化
    dSetSpriteVisible("skill1",0);
    dSetSpriteVisible("skill2",0);
    dSetSpriteVisible("skill3",0);
    dSetSpriteVisible("skill4",0);
    switch(level)
    {
    case 9:
    case 8:
    case 7:
    case 6:
        dSetSpriteVisible("skill4",1);
    case 5:
    case 4:
        dSetSpriteVisible("skill3",1);
    case 3:
        dSetSpriteVisible("skill2",1);
    case 2:
        dSetSpriteVisible("skill1",1);
    case 1:
        break;
    default :
        break;
    }
    //血量初始化

}

//主角加经验函数
//当主角为9级时，不再加经验
void Addjingya(const int num)
{
    if(Z_level == 9);
    else{
        Z_jingyan += num;
        if(Z_jingyan >= Z_levelMax)
        {
            Z_jingyan -=Z_levelMax;
            //升级
            Shengji();
        }
        //经验值显示（图形）
        BloodLen(Z_LevelName,Z_Levellen,Z_levelMax,Z_jingyan,Z_LevelPosX);
        ShowNum(1,Z_jingyan);//显示经验（数值）
    }

}


// 主角升级
void Shengji(void)
{
    Z_level += 1;
    //主角升级所需经验值翻倍
    Z_levelMax = 60*Z_level-30;
    if(Z_level == 9)
    {
        Z_jingyan = 0;
        Z_levelMax = 0;

    }
    //人物血量+100
    Z_shengming = 100*Z_level;
    //人物现在血量回满
    Z_blood = Z_shengming;
    //人物属性提升
    Z_gongji = 12*Z_level-2;
    Z_fangyv = 12*Z_level-2;
    Z_hurtID = 1/(1+(Z_fangyv/100.0)); //更新主角的减伤系数
    //Z_speed += 1.2;
    //更新显示数据
    //初始化血量显示（图形）
    BloodLen(Z_BloodName,Z_Bloodlen,Z_shengming,Z_blood,Z_BloodPosX);
    //初始化经验值显示（图形）
    BloodLen(Z_LevelName,Z_Levellen,Z_levelMax,Z_jingyan,Z_LevelPosX);
    ShowNum(2,Z_shengming);//显示血量最大值（数值）
    ShowNum(0,Z_blood);//显示血量（数值）
    ShowNum(3,Z_levelMax);//显示经验最大值（数值）
    ShowNum(1,Z_jingyan);//显示当前经验（数值）
    //显示等级
    dSetStaticSpriteFrame("level",Z_level-1);
    //播放动画
    dCloneSprite("level_up","level_up1");//克隆Level UP
    dSetSpritePosition("level_up1",0,50);//设置位置
    dSetSpriteLinearVelocityY("level_up1",-30.f);//逐渐上移
    dSetSpriteLifeTime("level_up1",1.2);//设置生命值
    //播放声音
    M_LevelUp = dPlaySound("Gold.wav",0,1*M_vol);
    //更新技能
     switch(Z_level)
    {
    case 6://六级解锁大招
        // 开启4技能的显示
        dSetStaticSpriteImage("skill4","Skill4ImageMap",0);
        // 设置可以释放四技能
        Z_IsSkill[3] = 1;
        break;
    case 4:
        // 开启3技能图片显示
        dSetStaticSpriteImage("skill3","Skill3ImageMap",0);
        // 设置可以释放三技能
        Z_IsSkill[2] = 1;
        break;
    case 3:
        // 开启2技能图片显示
        dSetStaticSpriteImage("skill2","Skill2ImageMap",0);
        // 设置可以释放二技能
        Z_IsSkill[1] = 1;
        break;
    case 2:
        // 开启1技能图片显示
        dSetStaticSpriteImage("skill1","Skill1ImageMap",0);
        // 设置可以释放一技能
        Z_IsSkill[0] = 1;
        break;
    }
}


// 技能释放函数：
// 按下对应按键时激活
// 释放完成后进入技能冷却
// run函数中检测技能冷却动画是否播放完毕，
// 技能随等级改变，在关卡初始化时就刷新，升级可能会解锁新技能
// 技能初始化函数，用switch结构

// 技能初始化函数
// Level：当前人物等级
void SkillInit(const int Level)
{
    //隐藏所有技能
    dSetStaticSpriteImage("skill4","Skill_BlankImageMap",0);
    Z_IsSkill[0] = 0;
    dSetStaticSpriteImage("skill3","Skill_BlankImageMap",0);
    Z_IsSkill[1] = 0;
    dSetStaticSpriteImage("skill2","Skill_BlankImageMap",0);
    Z_IsSkill[2] = 0;
    dSetStaticSpriteImage("skill1","Skill_BlankImageMap",0);
    Z_IsSkill[3] = 0;

    //依据人物等级开放技能
    switch(Level)
    {
    case 10:
    case 9:
    case 8:
    case 7:
    case 6://六级解锁大招
        // 开启4技能的显示
        dSetStaticSpriteImage("skill4","Skill4ImageMap",0);
        // 设置可以释放四技能
        Z_IsSkill[3] = 1;
    case 5:
    case 4:
        // 开启3技能图片显示
        dSetStaticSpriteImage("skill3","Skill3ImageMap",0);
        // 设置可以释放三技能
        Z_IsSkill[2] = 1;
    case 3:
        // 开启2技能图片显示
        dSetStaticSpriteImage("skill2","Skill2ImageMap",0);
        // 设置可以释放二技能
        Z_IsSkill[1] = 1;
    case 2:
        // 开启1技能图片显示
        dSetStaticSpriteImage("skill1","Skill1ImageMap",0);
        // 设置可以释放一技能
        Z_IsSkill[0] = 1;
        break;
    }
}

// 释放技能
// Skill：哪个技能'U','I','O','L'
void SendSkill(const char skill)
{
    switch(skill)
    {
    case 'U'://1技能
        {
            g_IsU = 1;
            //克隆技能动画到人物位置
            dCloneSprite("sendSkill1","CsendSkill1");
            dSetSpritePosition("CsendSkill1",Z_PosX,Z_PosY+100);
            switch(Z_top)
            {
            case 'D':
                {
                    S_Top = 'D';
                    //技能翻转
                    dSetSpriteFlipX("CsendSkill1",1);
                    //技能移动
                    dSpriteMoveTo("CsendSkill1",Z_PosX+240,Z_PosY+100,800,1);
                    //设置技能生命值
                    dSetSpriteLifeTime("CsendSkill1",0.3);
                }
                break;
            case 'A':
                {
                    S_Top = 'A';
                    //技能翻转
                    dSetSpriteFlipX("CsendSkill1",0);
                    //技能移动
                    dSpriteMoveTo("CsendSkill1",Z_PosX-240,Z_PosY+100,800,1);
                    //设置技能生命值
                    dSetSpriteLifeTime("CsendSkill1",0.3);
                }
                break;
            }
            //主角不可见，不可移动,且不接受碰撞
            dSetSpriteVisible(Z_name,0);//不可见
            dSetSpriteImmovable(Z_name,1);//不可动
            dSetSpriteCollisionReceive(Z_name,0);//不接受碰撞
            S_SpeedTime = 0;  //开始计时
            //在运行函数中判断
            //开始冷却，技能置为不可用
            S_Time1 = 0;//开始冷却
            Z_IsSkill[0] = 0;
            //定位动画位置
            //dCloneSprite("skillCD1","skillCD11");
            dSetSpritePosition("skillCD1",dGetSpritePositionX("skill1")+2,dGetSpritePositionY("skill1")+2);
            //播放冷却动画
            dAnimateSpritePlayAnimation("skillCD1","Skil1l_WaitAnimation",0);
            //播放技能1音效
            M_Skill1 = dPlaySound("Z_Skill1.wav",0,1*M_vol);
        }
        break;
    case 'I'://2技能
        {
            //克隆技能动画到人物位置
            dCloneSprite("sendSkill2","CsendSkill2");
            dSetSpritePosition("CsendSkill2",Z_PosX,Z_PosY-110);
            //克隆特效到人物位置
            dCloneSprite("sendSkill2_1","CsendSkill2_1");
            dSetSpritePosition("CsendSkill2_1",Z_PosX,Z_PosY);
            //绑定在一起
            dSpriteMountToSpriteLinkPoint("CsendSkill2",Z_name,3);
            dSpriteMountToSpriteLinkPoint("CsendSkill2_1",Z_name,4);
            //设置技能生命值
            dSetSpriteLifeTime("CsendSkill2",0.5);
            dSetSpriteLifeTime("CsendSkill2_1",0.5);
            //开始冷却，技能置为不可用
            S_Time2 = 0;//开始冷却
            Z_IsSkill[1] = 0;
            //定位动画位置
            dSetSpritePosition("skillCD2",dGetSpritePositionX("skill2")+2,dGetSpritePositionY("skill2")+2);
            //播放冷却动画
            dAnimateSpritePlayAnimation("skillCD2","Skill2_WaitAnimation",0);
            //技能效果，人物血量回复三分之一
            Z_blood+=Z_shengming/3;
            if(Z_blood >=Z_shengming)
            {
                Z_blood = Z_shengming;
            }
            //改变血条长度
            BloodLen(Z_BloodName,Z_Bloodlen,Z_shengming,Z_blood,Z_BloodPosX);
            //显示血量
            ShowNum(0, Z_blood);
            //播放技能1音效
            M_Skill2 = dPlaySound("Z_Skill2.wav",0,1*M_vol);
        }
        break;
    case 'O'://3技能
        {
            g_IsO = 1;
             //克隆技能动画到人物位置
            dCloneSprite("sendSkill3","CsendSkill3");
            dSetSpritePosition("CsendSkill3",Z_PosX,Z_PosY);
            //设置技能生命值
            dSetSpriteLifeTime("CsendSkill3",0.3);
            //主角不可见，不可移动,且不接受碰撞
            dSetSpriteVisible(Z_name,0);//不可见
            dSetSpriteImmovable(Z_name,1);//不可动
            dSetSpriteCollisionReceive(Z_name,0);//不接受碰撞
            S_SpeedTime3 = 0;  //开始计时
            //在运行函数中判断
            //开始冷却，技能置为不可用
            S_Time3 = 0;//开始冷却
            Z_IsSkill[2] = 0;
            //定位动画位置
            dSetSpritePosition("skillCD3",dGetSpritePositionX("skill3")+2,dGetSpritePositionY("skill3")+2);
            //播放冷却动画
            dAnimateSpritePlayAnimation("skillCD3","Skill3_WaitAnimation",0);
            //播放技能1音效
            M_Skill3 = dPlaySound("Z_Skill3.wav",0,1*M_vol);
        }
        break;
    case 'L'://4技能
        {
            g_IsL = 1;
             //克隆技能动画到人物位置
            dCloneSprite("sendSkill4","CsendSkill4");
            dSetSpritePosition("CsendSkill4",Z_PosX,Z_PosY);
            //设置技能生命值
            dSetSpriteLifeTime("CsendSkill4",0.3);
            //主角不可见，不可移动,且不接受碰撞
            dSetSpriteVisible(Z_name,0);//不可见
            dSetSpriteImmovable(Z_name,1);//不可动
            dSetSpriteCollisionReceive(Z_name,0);//不接受碰撞
            S_SpeedTime4 = 0;  //开始计时
            //在运行函数中判断
            //开始冷却，技能置为不可用
            S_Time4 = 0;//开始冷却
            Z_IsSkill[3] = 0;
            //定位动画位置
            dSetSpritePosition("skillCD4",dGetSpritePositionX("skill4")+2,dGetSpritePositionY("skill4")+2);
            //播放冷却动画
            dAnimateSpritePlayAnimation("skillCD4","Skill4_WaitAnimation",0);
            //播放技能1音效
            M_Skill4 = dPlaySound("Z_Skill4.wav",0,1*M_vol);
        }
        break;
    default:
        break;
    }
}

// 显示系统时间
void SysTime(const float num)
{
    int num1,num2,num3,num4;
    num1 = (int)num%60%10;
    num2 = (int)num%60/10;
    num3 = (int)num/60%10;
    num4 = (int)num/60/10;

    dSetStaticSpriteFrame("systime1",num1+1);
    dSetStaticSpriteFrame("systime2",num2+1);
    dSetStaticSpriteFrame("systime3",num3+1);
    dSetStaticSpriteFrame("systime4",num4+1);
}

// 加载Boss
// WhichMap：哪个地图的Boss
void CloneBoss(const int WhichMap)
{
    // 克隆Boss
    dCloneSprite("Boss","Boss1");
    // 定位
    dSetSpritePosition("Boss1",0,-130);
    // 给Boss一个常量推力
    dSetSpriteConstantForce("Boss1",0,1000000,0);
    // 定义Boss为可碰撞
    B_IsPengzhuang = 1;
    // 定义Boss的基本属性：Boos血量 = 当前地图值-2*250；
    B_Shengming = (WhichMap-2) * 120 + 130;
    B_Gongji =  (WhichMap-2) * 10 + 40;
    B_Fangyv =  (WhichMap-2) * 10 + 60;
    // 设置Boss当前血量
    B_Blood = B_Shengming;
    // Boss血量，定位显示300-280、339.5-263
    dSetSpritePosition("Bossxuetiao",300,-280);
    dSetSpritePosition("Boss_blood",339.5,-263);
    // TODO：播放Boss登场音效
    //克隆完毕后，将场上Boss数设为1
    B_num = 1;
    //克隆完毕后，场上存在Boss，地图不可移动
    g_qianjin = 0;
}

// BossMove：Boss移动函数
// PosX：主角的X坐标
void BossMove(const float PosX)
{
    // 执行此函数时，Boss会向主角移动
    // 获取此时Boss的X位置
    float B_PosX;
    B_PosX = dGetSpritePositionX("Boss1");
    // 判断Boss此时在主角的什么位置
    if (B_PosX > PosX+50) //如果此时Boss在人物前方，给Boss一个朝后的速度，人物翻转
    {
        //Boss翻转
        dSetSpriteFlipX("Boss1",1);
        //给Boss一个向后的速度
        dSetSpriteLinearVelocityX("Boss1",-B_Speed);
    }
    else if (B_PosX < PosX-50) //如果此时Boss在人物后方，给Boss一个朝前的速度，人物不翻转
    {
        //Boss不翻转
        dSetSpriteFlipX("Boss1",0);
        //给Boss一个向前的速度
        dSetSpriteLinearVelocityX("Boss1",B_Speed);
    }
    else // 如果Boss在主角附近不移动
    {
        //将Boss停止
        dSetSpriteLinearVelocityX("Boss1",0);

    }

}

// BossAttack：Boss攻击函数
// PosX：主角的X坐标
void BossAttack(const float PosX)
{
    //播放音效
    //TODO
    // 播放进攻动画
    // Boss进攻动作动画
    dAnimateSpritePlayAnimation("Boss1",B_Attackname[g_WhichGq-1],1);
    // Boss发动攻击，攻击效果随机，攻击方式随机
    // 确定是哪个地图
    switch(g_WhichMap)
    {
    case 9://关卡7
    case 8://关卡6
    case 7://关卡5
    case 3://关卡1
        {
            //发动进攻
            //克隆技能动画到Boss位置
            //随机产生一个数字
            char *Skillname = (char *)B_Skillname[rand()%3];
            char *name = (char *)malloc(strlen(Skillname) + strlen(firstname));
            strcpy(name,firstname);
            strcat(name,Skillname);
            dCloneSprite(Skillname,dMakeSpriteName(name,B_i));
            //以上产生一个技能字符串
            ///////////////////////////////////////////////////////
            //确定主角和Boss的相对位置
            float B_PosX = dGetSpritePositionX("Boss1");
            float B_PosY = dGetSpritePositionY("Boss1");
            if (B_PosX > Z_PosX) //如果此时Boss在人物前方
            {
                dSetSpritePosition(dMakeSpriteName(name,B_i),B_PosX-100,B_PosY+(rand()%200-100));    //设置技能位置
                dSetSpriteFlipX(dMakeSpriteName(name,B_i),1);   //Boss技能翻转
                dSetSpriteLinearVelocityX(dMakeSpriteName(name,B_i),-B_SkillSpeed);     //给Boss技能一个向后的速度
            }
            else if (B_PosX < Z_PosX) //如果此时Boss在人物后方
            {
                dSetSpritePosition(dMakeSpriteName(name,B_i),B_PosX+100,B_PosY);    //设置技能位置
                dSetSpriteFlipX(dMakeSpriteName(name,B_i),0);   //Boss不翻转
                dSetSpriteLinearVelocityX(dMakeSpriteName(name,B_i),B_SkillSpeed);      //给Boss技能一个向前的速度
            }
            dSetSpriteLifeTime(dMakeSpriteName(name,B_i),0.8);      //设置技能生命值
            B_i++;
            break;
        }
    case 4://关卡2
        {
            //发动进攻
            //克隆技能动画到Boss位置
            //随机产生一个数字
            char *Skillname = (char *)B_Skillname[rand()%3+3];
            char *name = (char *)malloc(strlen(Skillname) + strlen(firstname));
            strcpy(name,firstname);
            strcat(name,Skillname);
            dCloneSprite(Skillname,dMakeSpriteName(name,B_i));
            //以上产生一个技能字符串
            ///////////////////////////////////////////////////////
            //确定主角和Boss的相对位置
            float B_PosX = dGetSpritePositionX("Boss1");
            float B_PosY = dGetSpritePositionY("Boss1");
            if (B_PosX > Z_PosX) //如果此时Boss在人物前方
            {
                dSetSpritePosition(dMakeSpriteName(name,B_i),B_PosX-100,B_PosY+(rand()%150-50));    //设置技能位置
                dSetSpriteFlipX(dMakeSpriteName(name,B_i),0);   //Boss技能不翻转
                dSetSpriteLinearVelocityX(dMakeSpriteName(name,B_i),-B_SkillSpeed);     //给Boss技能一个向后的速度
            }
            else if (B_PosX < Z_PosX) //如果此时Boss在人物后方
            {
                dSetSpritePosition(dMakeSpriteName(name,B_i),B_PosX+100,B_PosY);    //设置技能位置
                dSetSpriteFlipX(dMakeSpriteName(name,B_i),1);   //Boss技能翻转
                dSetSpriteLinearVelocityX(dMakeSpriteName(name,B_i),B_SkillSpeed);      //给Boss技能一个向前的速度
            }
            dSetSpriteLifeTime(dMakeSpriteName(name,B_i),0.8);      //设置技能生命值
            B_i++;
            break;
        }
    case 5://关卡3
        {
            //发动进攻
            //克隆技能动画到Boss位置
            //随机产生一个数字
            char *Skillname = (char *)B_Skillname[rand()%5+3];
            char *name = (char *)malloc(strlen(Skillname) + strlen(firstname));
            strcpy(name,firstname);
            strcat(name,Skillname);
            dCloneSprite(Skillname,dMakeSpriteName(name,B_i));
            //以上产生一个技能字符串
            ///////////////////////////////////////////////////////
            //确定主角和Boss的相对位置
            float B_PosX = dGetSpritePositionX("Boss1");
            float B_PosY = dGetSpritePositionY("Boss1");
            if (B_PosX > Z_PosX) //如果此时Boss在人物前方
            {
                dSetSpritePosition(dMakeSpriteName(name,B_i),B_PosX-100,B_PosY+(rand()%150-50));    //设置技能位置
                dSetSpriteFlipX(dMakeSpriteName(name,B_i),0);   //Boss技能不翻转
                dSetSpriteLinearVelocityX(dMakeSpriteName(name,B_i),-B_SkillSpeed);     //给Boss技能一个向后的速度
            }
            else if (B_PosX < Z_PosX) //如果此时Boss在人物后方
            {
                dSetSpritePosition(dMakeSpriteName(name,B_i),B_PosX+100,B_PosY);    //设置技能位置
                dSetSpriteFlipX(dMakeSpriteName(name,B_i),1);   //Boss技能翻转
                dSetSpriteLinearVelocityX(dMakeSpriteName(name,B_i),B_SkillSpeed);      //给Boss技能一个向前的速度
            }
            dSetSpriteLifeTime(dMakeSpriteName(name,B_i),0.8);      //设置技能生命值
            B_i++;
            break;
        }
    case 6://关卡4
        {
            //发动进攻
            //克隆技能动画到Boss位置
            //随机产生一个数字
            char *Skillname = (char *)B_Skillname[rand()%4+8];
            char *name = (char *)malloc(strlen(Skillname) + strlen(firstname));
            strcpy(name,firstname);
            strcat(name,Skillname);
            dCloneSprite(Skillname,dMakeSpriteName(name,B_i));
            //以上产生一个技能字符串
            ///////////////////////////////////////////////////////
            //确定主角和Boss的相对位置
            float B_PosX = dGetSpritePositionX("Boss1");
            float B_PosY = dGetSpritePositionY("Boss1");
            if (B_PosX > Z_PosX) //如果此时Boss在人物前方
            {
                dSetSpritePosition(dMakeSpriteName(name,B_i),B_PosX-100,B_PosY+(rand()%150-50));    //设置技能位置
                dSetSpriteFlipX(dMakeSpriteName(name,B_i),0);   //Boss技能不翻转
                dSetSpriteLinearVelocityX(dMakeSpriteName(name,B_i),-B_SkillSpeed);     //给Boss技能一个向后的速度
            }
            else if (B_PosX < Z_PosX) //如果此时Boss在人物后方
            {
                dSetSpritePosition(dMakeSpriteName(name,B_i),B_PosX+100,B_PosY);    //设置技能位置
                dSetSpriteFlipX(dMakeSpriteName(name,B_i),1);   //Boss技能翻转
                dSetSpriteLinearVelocityX(dMakeSpriteName(name,B_i),B_SkillSpeed);      //给Boss技能一个向前的速度
            }
            dSetSpriteLifeTime(dMakeSpriteName(name,B_i),0.8);      //设置技能生命值
            B_i++;
            break;
        }
    case 10://关卡8
        {
            //发动进攻
            //克隆技能动画到Boss位置
            //随机产生一个数字
            char *Skillname = (char *)B_Skillname[rand()%5];
            char *name = (char *)malloc(strlen(Skillname) + strlen(firstname));
            strcpy(name,firstname);
            strcat(name,Skillname);
            dCloneSprite(Skillname,dMakeSpriteName(name,B_i));
            //以上产生一个技能字符串
            ///////////////////////////////////////////////////////
            //确定主角和Boss的相对位置
            float B_PosX = dGetSpritePositionX("Boss1");
            float B_PosY = dGetSpritePositionY("Boss1");
            if (B_PosX > Z_PosX) //如果此时Boss在人物前方
            {
                dSetSpritePosition(dMakeSpriteName(name,B_i),B_PosX-100,B_PosY+(rand()%150-50));    //设置技能位置
                dSetSpriteFlipX(dMakeSpriteName(name,B_i),0);   //Boss技能不翻转
                dSetSpriteLinearVelocityX(dMakeSpriteName(name,B_i),-B_SkillSpeed);     //给Boss技能一个向后的速度
            }
            else if (B_PosX < Z_PosX) //如果此时Boss在人物后方
            {
                dSetSpritePosition(dMakeSpriteName(name,B_i),B_PosX+100,B_PosY);    //设置技能位置
                dSetSpriteFlipX(dMakeSpriteName(name,B_i),1);   //Boss技能翻转
                dSetSpriteLinearVelocityX(dMakeSpriteName(name,B_i),B_SkillSpeed);      //给Boss技能一个向前的速度
            }
            dSetSpriteLifeTime(dMakeSpriteName(name,B_i),0.8);      //设置技能生命值
            B_i++;
            break;
        }
    case 11://关卡11
        {
            //发动进攻
            //克隆技能动画到Boss位置
            //随机产生一个数字
            char *Skillname = (char *)B_Skillname[rand()%7];
            char *name = (char *)malloc(strlen(Skillname) + strlen(firstname));
            strcpy(name,firstname);
            strcat(name,Skillname);
            dCloneSprite(Skillname,dMakeSpriteName(name,B_i));
            //以上产生一个技能字符串
            ///////////////////////////////////////////////////////
            //确定主角和Boss的相对位置
            float B_PosX = dGetSpritePositionX("Boss1");
            float B_PosY = dGetSpritePositionY("Boss1");
            if (B_PosX > Z_PosX) //如果此时Boss在人物前方
            {
                dSetSpritePosition(dMakeSpriteName(name,B_i),B_PosX-100,B_PosY+(rand()%200-100));    //设置技能位置
                dSetSpriteFlipX(dMakeSpriteName(name,B_i),1);   //Boss技能翻转
                dSetSpriteLinearVelocityX(dMakeSpriteName(name,B_i),-B_SkillSpeed);     //给Boss技能一个向后的速度
            }
            else if (B_PosX < Z_PosX) //如果此时Boss在人物后方
            {
                dSetSpritePosition(dMakeSpriteName(name,B_i),B_PosX+100,B_PosY);    //设置技能位置
                dSetSpriteFlipX(dMakeSpriteName(name,B_i),0);   //Boss不翻转
                dSetSpriteLinearVelocityX(dMakeSpriteName(name,B_i),B_SkillSpeed);      //给Boss技能一个向前的速度
            }
            dSetSpriteLifeTime(dMakeSpriteName(name,B_i),0.8);      //设置技能生命值
            B_i++;
            break;
        }
    }
}

// BossHurt：Boss受伤扣血函数
// hurt：对Boss的伤害
void BossHurt(const int hurt)
{
    // 当Boss受到主角造成的伤害后，调用
    // 依据Boss防御力计算实际对Boss造成的伤害
    int kouxue;
    kouxue = hurt / (1 + (float)B_Fangyv/100.0) + (rand()%6 - 2);
    B_Blood -= kouxue;
     //显示的扣除血量
    GameShowNum("num_shanghai",kouxue,dGetSpritePositionX("Boss1"),dGetSpritePositionY("Boss1"));
    // 改变血条长度
    BloodLen("Boss_blood",569,B_Shengming,B_Blood,339.5);
    //关闭Boss接收碰撞功能
    dSetSpriteCollisionReceive("Boss1",0);
    //计时清零，开始计时
    B_JiangeTime = 0;
    //标记精灵不可碰撞
    B_IsPengzhuang = 0;
    // 当血量归零后,调用Boss死亡函数
    if(B_Blood <= 0)
    {
        //加主角经验
        Addjingya(g_WhichGq*12+3);//第几关的小怪加多少经验
        BossDie(g_WhichMap);
    }
}

// BossDie：Boss死亡函数
// WhichMap：哪张地图的Boss
void BossDie(const int WhichMap)
{
    B_i=0;
    // 删除精灵
    dDeleteSprite("Boss1");
    // 标记已通关
    if (g_Whichgame < WhichMap - 2)
    {
        g_Whichgame = WhichMap-2;
    }
    //如果可以加载过场动画===Boss死亡
    if(g_isLoadGC1==1)
    {
        //记录是第幕过场动画
        GC_ID = 2;
        //改变地图标记
        g_GCTime = 0;
        g_WhichMap = -3;//不再进入这个循环，开始进入时间循环
        //标记清零
        for(int i=0;i<20;i++)
        {
            GC_F[i]=0;
        }
    }
    else
    {
        // 动态显示获胜按钮
        dSetSpritePosition("victory",0,-800);
        dSpriteMoveTo("victory",0,0,g_MenuSpeed,1);
        //dSetSpritePosition("victory",0,0);
        //更新地图标记
        g_WhichMap = -2;
    }
}

// BossAction：Boss行动函数
// 注：在函数中随机产生Boss的行动，移动，释放技能随机产生
void BossAction(const float PosX)
{
    //每过两秒Boss进行一次进攻
    //时间已经过去两秒，Boss尚未发动进攻
    if (B_attackTime > B_attack && B_IsAttack == 0)
    {
        BossAttack(PosX);// Boss释放技能
        B_IsAttack = 1;//标记Boss已经发动进攻
        B_attackTime = 0;//重新计时
    }
    else if(B_IsAttack == 1)//Boss发动了进攻
    {
        BossMove(PosX);// Boss移动
        if(B_attackTime > B_attack)//如果间隔时间大于2秒
        {
            B_IsAttack = 0;//标记Boss未发动进攻
        }
    }


}

// GameMove：主角移动函数
void GameMove(void)
{
    //当只有D被按下
    if(g_IsD ==1 && g_IsA == 0)
    {
        //如果地图不可以移动，人物才可以向前动
        if (dGetSpriteImmovable(g_mapname[g_WhichMap]) == 1)
        {
            dSetSpriteLinearVelocityX(Z_name,Z_speed);//给主角一个向前的速度
        }
        dSetSpriteLinearVelocity(g_mapname[g_WhichMap],-Z_speed,0);//给地图一个向后的速度
    }
    //只有A被按下
    else if(g_IsA ==1 && g_IsD == 0)
    {
        dSetSpriteLinearVelocityX(Z_name,-Z_speed);//给主角一个向后的速度
    }
    // AD都被按下
    else if (g_IsA ==1 && g_IsD == 1)
    {
        //判断主角朝向，主角朝向哪向哪移动
        switch(Z_top)
        {
        case 'A':
            {
                dSetSpriteLinearVelocityX(Z_name,-Z_speed);//给主角一个向后的速度
                break;
            }
        case 'D':
            {
                //如果地图不可以移动，人物才可以向前动
                if (dGetSpriteImmovable(g_mapname[g_WhichMap]) == 1)
                {
                    dSetSpriteLinearVelocityX(Z_name,Z_speed);//给主角一个向前的速度
                }
                dSetSpriteLinearVelocity(g_mapname[g_WhichMap],-Z_speed,0);//给地图一个向后的速度
                break;
            }
        default:
            break;
        }
    }
}

// SubBlood：主角扣血函数
void SubBlood(const int num)
{
    //人物扣血
    //扣除血量
    Z_blood -= num;
    //判断主角剩余血量
    if (Z_blood <= 0)
    {
        Z_blood = 0;
        //速度清零
        dSetSpriteLinearVelocityX(Z_name,0);
        //播放人物死亡动画
        dAnimateSpritePlayAnimation(Z_name,Z_die,0);
        //播放受伤音效
        M_Hurt = dPlaySound("Z_hurt.wav",0,1*M_vol);

    }else{
        //人物播放受伤动画
        dAnimateSpritePlayAnimation(Z_name,Z_hurt,1);
        //播放受伤音效
        M_Hurt = dPlaySound("Z_hurt.wav",0,1*M_vol);
    }
         //关闭主角接收碰撞功能
        dSetSpriteCollisionReceive(Z_name,0);
        //计时清零，开始计时
        Z_hurtTime=0;
        //标记精灵已关闭碰撞
        Z_Ishurt = 0;
        //显示的扣除血量
        GameShowNum("num_Bule",num,dGetSpritePositionX(Z_name),dGetSpritePositionY(Z_name));
        ShowNum(0,Z_blood);
        //改变血条
        BloodLen(Z_BloodName,Z_Bloodlen,Z_shengming,Z_blood,Z_BloodPosX);

}

// GameLoadGC：加载过场动画
// GameGQ：记录是哪个地图
// ID：记录是那一幕,1 =》初见；2 =》击杀
void GameLoadGC(const int GameGQ,const int ID)
{
    //改变地图标记
    g_WhichMap = -3;

    //移动灰幕
    dSetSpritePosition("GC_huimu",0.0,0.0);
    //睡眠1000毫秒
    if(g_GCTime>=0.5&&GC_F[0]==0)//0.5秒后
    {
        //移动对话框
        //1.定位 2.移动 3.睡眠
        dSetSpritePosition("GC_Talk1",-800.0,-170.0);
        dSpriteMoveTo("GC_Talk1",-210.0,-170.0,1000,1);//速度1000
        GC_F[0]=1;//标记
    }
    if(g_GCTime>=1&&GC_F[1]==0)//1秒后
    {
        dSetSpritePosition("GC_Talk2",800.0,120.0);
        dSpriteMoveTo("GC_Talk2",210.0,120.0,1000,1);//速度1000
        GC_F[1]=1;//标记
    }
    //判断是那个地图==加载不同动画
    switch(GameGQ)
    {
        case 1:
            {
                //对话开始
                //确定是哪一幕
                if(ID == 1)
                {//相遇时的对话
                    GC_time = 3;
                    //定位
                    if(g_GCTime>=2&&GC_F[2]==0)//2秒后
                    {
                        dSetSpritePosition("T1_1",-200.0,-180.0);//位置-200；-180
                        GC_F[2]=1;
                    }
                    if(g_GCTime>=3&&GC_F[3]==0)//3秒后
                    {
                        dSetSpritePosition("T1_2",160.0,110.0);//位置160；110
                        GC_F[3]=1;
                    }
                    g_isLoadGC = 0;//记录过场已加载
                }
                else
                {//击杀的对话
                    GC_time = 6;
                    //定位
                    if(g_GCTime>=2&&GC_F[2]==0)//2秒后
                    {
                        dSetSpritePosition("T2_1",127.0,102.0);//位置127；102
                        GC_F[2]=1;
                    }
                    if(g_GCTime>=3&&GC_F[3]==0)//3秒后
                    {
                        dSetSpritePosition("T2_2",-360.0,-215.0);//位置-360；-215
                        GC_F[3]=1;
                    }
                    if(g_GCTime>=4&&GC_F[4]==0)//4秒后
                    {
                        dSetSpritePosition("T2_2",0.0,1460.0);//移走2
                        dSetSpritePosition("T2_3",-317.0,-215.0);//位置-317；-215
                        GC_F[4]=1;
                    }
                    if(g_GCTime>=5&&GC_F[5]==0)//5秒后
                    {
                        dSetSpritePosition("T2_3",0.0,1460.0);//移走3
                        dSetSpritePosition("T2_4",-273.0,-200.0);//位置-273；-200
                        GC_F[5]=1;
                    }
                    if(g_GCTime >= 6 && GC_F[6]==0)//6秒后
                    {
                        dSetSpritePosition("T2_1",0.0,1460.0);//移走1
                        dSetSpritePosition("T2_5",48.0,86.0);//位置48；86
                        GC_F[6]=1;
                    }
                    g_isLoadGC1 = 0;//记录过场2已加载
                }
                break;
            }
        case 2:
            {
                //对话开始
                //确定是哪一幕
                if(ID == 1)
                {//相遇时的对话
                    GC_time = 7;
                    //定位
                    if(g_GCTime>=2&&GC_F[2]==0)//2秒后
                    {
                        dSetSpritePosition("T1_1",-270.0,-215.0);//位置-270；-215
                        GC_F[2]=1;
                    }
                    if(g_GCTime>=3&&GC_F[3]==0)//3秒后
                    {
                        dSetSpritePosition("T1_1",0.0,1460.0);//移走1
                        dSetSpritePosition("T1_2",-315.0,-215.0);//位置-315；-215
                        GC_F[3]=1;
                    }
                    if(g_GCTime>=4&&GC_F[4]==0)//4秒后
                    {
                        dSetSpritePosition("T1_2",0.0,1460.0);//移走2
                        dSetSpritePosition("T1_3",-277.0,-215.0);//位置-277；-215
                        GC_F[4]=1;
                    }
                    if(g_GCTime>=5&&GC_F[5]==0)//5秒后
                    {
                        dSetSpritePosition("T1_4",124.0,86.0);//位置124；86
                        GC_F[5]=1;
                    }
                    if(g_GCTime>=6&&GC_F[6]==0)//6秒后
                    {
                        dSetSpritePosition("T1_4",0.0,1460.0);//移走4
                        dSetSpritePosition("T1_5",160.0,86.0);//位置160；86
                        GC_F[6]=1;
                    }
                    if(g_GCTime>=7&&GC_F[7]==0)//7秒后
                    {
                        dSetSpritePosition("T1_5",0.0,1460.0);//移走5
                        dSetSpritePosition("T1_6",50.0,86.0);//位置50；86
                        GC_F[7]=1;
                    }
                    g_isLoadGC = 0;//记录过场已加载
                }
                else
                {//击杀的对话
                    GC_time = 9;
                    //定位
                    if(g_GCTime>=2&&GC_F[2]==0)//2秒后
                    {
                        dSetSpritePosition("T2_1",-265.0,-215);//位置-265；-215
                        GC_F[2]=1;
                    }
                    if(g_GCTime>=3&&GC_F[3]==0)//3秒后
                    {
                        dSetSpritePosition("T2_2",47.0,86.0); //位置47.0,86.0
                        GC_F[3]=1;
                    }
                    if(g_GCTime>=4&&GC_F[4]==0)//4秒后
                    {
                        dSetSpritePosition("T2_2",0.0,1460.0);//移走2
                        dSetSpritePosition("T2_3",141.0,86.0);//位置141.0,86.0
                        GC_F[4]=1;
                    }
                    if(g_GCTime>=5&&GC_F[5]==0)//5秒后
                    {
                        dSetSpritePosition("T2_3",0.0,1460.0);//移走3
                        dSetSpritePosition("T2_4",85.0,86.0);//位置85.0,86.0
                        GC_F[5]=1;
                    }
                    if(g_GCTime >= 6 && GC_F[6]==0)//6秒后
                    {
                        dSetSpritePosition("T2_4",0.0,1460.0);//移走4
                        dSetSpritePosition("T2_5",98.0,86.0);//位置98.0,86.0
                        GC_F[6]=1;
                    }
                    if(g_GCTime >= 7 &&GC_F[7]==0)//4秒后
                    {
                        dSetSpritePosition("T2_1",0.0,1460.0);//移走1
                        dSetSpritePosition("T2_6",-249.0,-215.0);//6位置-249.0,-215.0
                        GC_F[7]=1;
                    }
                    if(g_GCTime >= 8 &&GC_F[8]==0)//5秒后
                    {
                        dSetSpritePosition("T2_6",0.0,1460.0);//移走6
                        dSetSpritePosition("T2_7",-267.0,-215.0);//位置-267.0,-215.0
                        GC_F[8]=1;
                    }
                    if(g_GCTime >= 9 && GC_F[9]==0)//6秒后
                    {
                        dSetSpritePosition("T2_7",0.0,1460.0);//移走7
                        dSetSpritePosition("T2_8",-333.0,-215.0);//位置-333.0,-215.0
                        GC_F[9]=1;
                    }
                    g_isLoadGC1 = 0;//记录过场2已加载
                }
                break;
            }
        case 3:
            {
                //对话开始
                //确定是哪一幕
                if(ID == 1)
                {//相遇时的对话
                    GC_time = 8;
                    //定位
                    if(g_GCTime>=2&&GC_F[2]==0)//2秒后
                    {
                        dSetSpritePosition("T1_1",61.0,86.0);//位置61.0,86.0
                        GC_F[2]=1;
                    }
                    if(g_GCTime>=3&&GC_F[3]==0)//3秒后
                    {
                        dSetSpritePosition("T1_2",74.0,115.0);//位置74.0,115.0
                        GC_F[3]=1;
                    }
                    if(g_GCTime>=4&&GC_F[4]==0)//4秒后
                    {
                        dSetSpritePosition("T1_3",50.0,144.0);//位置50.0，144.0
                        GC_F[4]=1;
                    }
                    if(g_GCTime>=5&&GC_F[5]==0)//5秒后
                    {
                        dSetSpritePosition("T1_1",0.0,1460.0);//移走1
                        dSetSpritePosition("T1_2",0.0,1460.0);//移走2
                        dSetSpritePosition("T1_3",0.0,1460.0);//移走3
                        dSetSpritePosition("T1_4",99.0,86.0);//位置99.0，86.0
                        GC_F[5]=1;
                    }
                    if(g_GCTime>=6&&GC_F[6]==0)//6秒后
                    {
                        dSetSpritePosition("T1_5",-206.0,-215.0);//位置-206.0，-215.0
                        GC_F[6]=1;
                    }
                    if(g_GCTime>=7&&GC_F[7]==0)//7秒后
                    {
                        dSetSpritePosition("T1_4",0.0,1460.0);//移走4
                        dSetSpritePosition("T1_6",127.0,86.0);//位置127.0，86.0
                        GC_F[7]=1;
                    }
                    if(g_GCTime>=8&&GC_F[8]==0)//8秒后
                    {
                        dSetSpritePosition("T1_6",0.0,1460.0);//移走6
                        dSetSpritePosition("T1_7",75.0,86.0);//位置75.0，86.0
                        GC_F[8]=1;
                    }
                    g_isLoadGC = 0;//记录过场已加载
                }
                else
                {//击杀的对话
                    GC_time = 7;
                    //定位
                    if(g_GCTime>=2&&GC_F[2]==0)//2秒后
                    {
                        dSetSpritePosition("T2_1",25.0,86.0);//位置25.0,86.0
                        GC_F[2]=1;
                    }
                    if(g_GCTime>=3&&GC_F[3]==0)//3秒后
                    {
                        dSetSpritePosition("T2_1",0.0,1460.0);//移走1
                        dSetSpritePosition("T2_2",51.0,86.0); //位置51.0,86.0
                        GC_F[3]=1;
                    }
                    if(g_GCTime>=4&&GC_F[4]==0)//4秒后
                    {
                        dSetSpritePosition("T2_2",0.0,1460.0);//移走2
                        dSetSpritePosition("T2_3",63.0,86.0);//位置63.0,86.0
                        GC_F[4]=1;
                    }
                    if(g_GCTime>=5&&GC_F[5]==0)//5秒后
                    {
                        dSetSpritePosition("T2_4",3.50,115.0);//位置3.50,115.0
                        GC_F[5]=1;
                    }
                    if(g_GCTime >= 6 && GC_F[6]==0)//6秒后
                    {
                        dSetSpritePosition("T2_5",-370.0,-215.0);//位置-370.0,-215.0
                        GC_F[6]=1;
                    }
                    if(g_GCTime >= 7 &&GC_F[7]==0)//4秒后
                    {
                        dSetSpritePosition("T2_5",0.0,1460.0);//移走5
                        dSetSpritePosition("T2_6",-252.0,-215.0);//6位置-252.0,-215.0
                        GC_F[7]=1;
                    }
                    g_isLoadGC1 = 0;//记录过场2已加载
                }
                break;
            }
        case 4:
            {
                //对话开始
                //确定是哪一幕
                if(ID == 1)
                {//相遇时的对话
                    GC_time = 7;
                    //定位
                    if(g_GCTime>=2&&GC_F[2]==0)//2秒后
                    {
                        dSetSpritePosition("T1_1",124.0,86.0);//位置124.0,86.0
                        GC_F[2]=1;
                    }
                    if(g_GCTime>=3&&GC_F[3]==0)//3秒后
                    {
                        dSetSpritePosition("T1_2",-280.0,-215.0);//位置-280.0,-215.0
                        GC_F[3]=1;
                    }
                    if(g_GCTime>=4&&GC_F[4]==0)//4秒后
                    {
                        dSetSpritePosition("T1_1",0.0,1460.0);//移走1
                        dSetSpritePosition("T1_3",111.5,86.0);//位置111.5，86.0
                        GC_F[4]=1;
                    }
                    if(g_GCTime>=5&&GC_F[5]==0)//5秒后
                    {
                        dSetSpritePosition("T1_3",0.0,1460.0);//移走3
                        dSetSpritePosition("T1_4",81.0,86.0);//位置81.0，86.0
                        GC_F[5]=1;
                    }
                    if(g_GCTime>=6&&GC_F[6]==0)//6秒后
                    {
                        dSetSpritePosition("T1_5",178.5,112.5);//位置178.5，112.5
                        GC_F[6]=1;
                    }
                    if(g_GCTime>=7&&GC_F[7]==0)//7秒后
                    {
                        dSetSpritePosition("T1_2",0.0,1460.0);//移走2
                        dSetSpritePosition("T1_6",-290.0,-215.0);//位置-290.0，-215.0
                        GC_F[7]=1;
                    }
                    g_isLoadGC = 0;//记录过场已加载
                }
                else
                {//击杀的对话
                    GC_time = 4;
                    //定位
                    if(g_GCTime>=2&&GC_F[2]==0)//2秒后
                    {
                        dSetSpritePosition("T2_1",111.0,86.0);//位置111.0,86.0
                        GC_F[2]=1;
                    }
                    if(g_GCTime>=3&&GC_F[3]==0)//3秒后
                    {
                        dSetSpritePosition("T2_2",90.0,115.0); //位置90.0,115.0
                        GC_F[3]=1;
                    }
                    if(g_GCTime>=4&&GC_F[4]==0)//4秒后
                    {
                        dSetSpritePosition("T2_2",0.0,1460.0);//移走2
                        dSetSpritePosition("T2_3",-298.0,-215.0);//位置-298.5.0,-215.0
                        GC_F[4]=1;
                    }
                    g_isLoadGC1 = 0;//记录过场2已加载
                }
                break;
            }
        case 5:
            {
                //对话开始
                //确定是哪一幕
                if(ID == 1)
                {//相遇时的对话
                    GC_time = 10;
                    //定位
                    if(g_GCTime>=2&&GC_F[2]==0)//2秒后
                    {
                        dSetSpritePosition("T1_1",100.0,86.0);//位置100.0,86.0
                        GC_F[2]=1;
                    }
                    if(g_GCTime>=3&&GC_F[3]==0)//3秒后
                    {
                        dSetSpritePosition("T1_2",124.0,115.0);//位置124.0,115.0
                        GC_F[3]=1;
                    }
                    if(g_GCTime>=4&&GC_F[4]==0)//4秒后
                    {
                        dSetSpritePosition("T1_3",-210.0,-215.0);//位置-210.0，-215.0
                        GC_F[4]=1;
                    }
                    if(g_GCTime>=5&&GC_F[5]==0)//5秒后
                    {
                        dSetSpritePosition("T1_3",0.0,1460.0);//移走3
                        dSetSpritePosition("T1_4",-290.0,-215.0);//位置-290，-215.0
                        GC_F[5]=1;
                    }
                    if(g_GCTime>=6&&GC_F[6]==0)//6秒后
                    {
                        dSetSpritePosition("T1_1",0.0,1460.0);//移走1
                        dSetSpritePosition("T1_2",0.0,1460.0);//移走2
                        dSetSpritePosition("T1_5",100.0,86.0);//位置100.0，86.0
                        GC_F[6]=1;
                    }
                    if(g_GCTime>=7&&GC_F[7]==0)//7秒后
                    {
                        dSetSpritePosition("T1_6",186.0,115.0);//位置186.0，115.0
                        GC_F[7]=1;
                    }
                    if(g_GCTime>=8&&GC_F[8]==0)//8秒后
                    {
                        dSetSpritePosition("T1_7",198.0,145.0);//位置198.0，145.0
                        GC_F[8]=1;
                    }
                    if(g_GCTime>=9&&GC_F[9]==0)//9秒后
                    {
                        dSetSpritePosition("T1_8",175.0,175.0);//位置175.0，175.0
                        GC_F[9]=1;
                    }
                    if(g_GCTime>=10&&GC_F[10]==0)//10秒后
                    {
                        dSetSpritePosition("T1_9",210.0,205.0);//位置210.0，205.0
                        GC_F[10]=1;
                    }
                    g_isLoadGC = 0;//记录过场已加载
                }
                else
                {//击杀的对话
                    GC_time = 6;
                    //定位
                    if(g_GCTime>=2&&GC_F[2]==0)//2秒后
                    {
                        dSetSpritePosition("T2_1",-295.0,-215.0);//位置-295.0,-215.0
                        GC_F[2]=1;
                    }
                    if(g_GCTime>=3&&GC_F[3]==0)//3秒后
                    {
                        dSetSpritePosition("T2_1",0.0,1460.0);//移走2
                        dSetSpritePosition("T2_2",-287.0,-215.0); //位置-287.0,-215.0
                        GC_F[3]=1;
                    }
                    if(g_GCTime>=4&&GC_F[4]==0)//4秒后
                    {
                        dSetSpritePosition("T2_3",100.0,86.0);//位置100.0,86.0
                        GC_F[4]=1;
                    }
                    if(g_GCTime>=5&&GC_F[5]==0)//5秒后
                    {
                        dSetSpritePosition("T2_4",161.0,115.0);//位置161.0,115.0
                        GC_F[5]=1;
                    }
                    if(g_GCTime>=6&&GC_F[6]==0)//6秒后
                    {
                        dSetSpritePosition("T2_5",153.5,145.0);//位置153.5,145.0
                        GC_F[6]=1;
                    }
                    g_isLoadGC1 = 0;//记录过场2已加载
                }
                break;
            }
        case 6:
            {
                //对话开始
                //确定是哪一幕
                if(ID == 1)
                {//相遇时的对话
                    GC_time = 3;
                    //定位
                    if(g_GCTime>=2&&GC_F[2]==0)//2秒后
                    {
                        dSetSpritePosition("T1_1",-171.5,-215.0);//位置-171.5,-215.0
                        GC_F[2]=1;
                    }
                    if(g_GCTime>=3&&GC_F[3]==0)//3秒后
                    {
                        dSetSpritePosition("T1_2",150.0,86.0);//位置150.0,86.0
                        GC_F[3]=1;
                    }
                    g_isLoadGC = 0;//记录过场已加载
                }
                else
                {//击杀的对话
                    GC_time = 9;
                    //定位
                    if(g_GCTime>=2&&GC_F[2]==0)//2秒后
                    {
                        dSetSpritePosition("T2_1",-345.0,-215.0);//位置-345.0,-215.0
                        GC_F[2]=1;
                    }
                    if(g_GCTime>=3&&GC_F[3]==0)//3秒后
                    {
                        dSetSpritePosition("T2_1",0.0,1460.0);//移走1
                        dSetSpritePosition("T2_2",-226.0,-215.0); //位置-226.0,-215.0
                        GC_F[3]=1;
                    }
                    if(g_GCTime>=4&&GC_F[4]==0)//4秒后
                    {
                        dSetSpritePosition("T2_3",157.5,86.0);//位置157.5,86.0
                        GC_F[4]=1;
                    }
                    if(g_GCTime>=5&&GC_F[5]==0)//5秒后
                    {
                        dSetSpritePosition("T2_3",0.0,1460.0);//移走3
                        dSetSpritePosition("T2_4",89.0,86.0);//位置89.0,86.0
                        GC_F[5]=1;
                    }
                    if(g_GCTime>=6&&GC_F[6]==0)//6秒后
                    {
                        dSetSpritePosition("T2_4",0.0,1460.0);//移走3
                        dSetSpritePosition("T2_5",130.0,86.0);//位置130.0,86.0
                        GC_F[6]=1;
                    }
                    if(g_GCTime>=7&&GC_F[7]==0)//7秒后
                    {
                        dSetSpritePosition("T2_5",0.0,1460.0);//移走3
                        dSetSpritePosition("T2_6",166.0,86.0);//位置89.0,86.0
                        GC_F[7]=1;
                    }
                    if(g_GCTime>=8&&GC_F[8]==0)//8秒后
                    {
                        dSetSpritePosition("T2_6",0.0,1460.0);//移走3
                        dSetSpritePosition("T2_7",106.0,86.0);//位置106.0,86.0
                        GC_F[8]=1;
                    }
                    if(g_GCTime>=9&&GC_F[9]==0)//9秒后
                    {
                        dSetSpritePosition("T2_2",0.0,1460.0);//移走2
                        dSetSpritePosition("T2_8",-189.0,-215.0);//位置-189.0,-215.0
                        GC_F[9]=1;
                    }
                    g_isLoadGC1 = 0;//记录过场2已加载
                }
                break;
            }
        case 7:
            {
                //对话开始
                //确定是哪一幕
                if(ID == 1)
                {//相遇时的对话
                    GC_time = 3;
                    //定位
                    if(g_GCTime>=2&&GC_F[2]==0)//2秒后
                    {
                        dSetSpritePosition("T1_1",-250.0,-215.0);//位置-250,-215.0
                        GC_F[2]=1;
                    }
                    if(g_GCTime>=3&&GC_F[3]==0)//3秒后
                    {
                        dSetSpritePosition("T1_2",96.0,86.0);//位置96.0,86.0
                        GC_F[3]=1;
                    }
                    g_isLoadGC = 0;//记录过场已加载
                }
                else
                {//击杀的对话
                    GC_time = 5;
                    //定位
                    if(g_GCTime>=2&&GC_F[2]==0)//2秒后
                    {
                        dSetSpritePosition("T2_1",72.0,86.0);//位置72.0,86.0
                        GC_F[2]=1;
                    }
                    if(g_GCTime>=3&&GC_F[3]==0)//3秒后
                    {
                        dSetSpritePosition("T2_2",-172.0,-215.0); //位置-172.0,-215.0
                        GC_F[3]=1;
                    }
                    if(g_GCTime>=4&&GC_F[4]==0)//4秒后
                    {
                        dSetSpritePosition("T2_2",0.0,1460.0);//移走3
                        dSetSpritePosition("T2_3",-177.0,-215.0);//位置-177.0,-215.0
                        GC_F[4]=1;
                    }
                    if(g_GCTime>=5&&GC_F[5]==0)//5秒后
                    {
                        dSetSpritePosition("T2_3",0.0,1460.0);//移走3
                        dSetSpritePosition("T2_4",-282.50,-215.0);//位置-282.50,-215.0
                        GC_F[5]=1;
                    }
                    g_isLoadGC1 = 0;//记录过场2已加载
                }
                break;
            }
        case 8:
            {
                //对话开始
                //确定是哪一幕
                if(ID == 1)
                {//相遇时的对话
                    GC_time = 3;
                    //定位
                    if(g_GCTime>=2&&GC_F[2]==0)//2秒后
                    {
                        dSetSpritePosition("T1_1",-250.0,-215.0);//位置-250,-215
                        GC_F[2]=1;
                    }
                    if(g_GCTime>=3&&GC_F[3]==0)//3秒后
                    {
                        dSetSpritePosition("T1_2",181.0,86.0);//位置181.0,86.0
                        GC_F[3]=1;
                    }
                    g_isLoadGC = 0;//记录过场已加载
                }
                else
                {//击杀的对话
                    GC_time = 7;
                    //定位
                    if(g_GCTime>=2&&GC_F[2]==0)//2秒后
                    {
                        dSetSpritePosition("T2_1",67.0,86.0);//位置67.0,86.0
                        GC_F[2]=1;
                    }
                    if(g_GCTime>=3&&GC_F[3]==0)//3秒后
                    {
                        dSetSpritePosition("T2_1",0.0,1460.0);//移走1
                        dSetSpritePosition("T2_2",172.0,86.0); //位置-226.0,-215.0
                        GC_F[3]=1;
                    }
                    if(g_GCTime>=4&&GC_F[4]==0)//4秒后
                    {
                        dSetSpritePosition("T2_2",0.0,1460.0);//移走2
                        dSetSpritePosition("T2_3",158.5,86.0);//位置158.5,86.0
                        GC_F[4]=1;
                    }
                    if(g_GCTime>=5&&GC_F[5]==0)//5秒后
                    {
                        dSetSpritePosition("T2_3",0.0,1460.0);//移走3
                        dSetSpritePosition("T2_4",150.0,86.0);//位置150.0,86.0
                        GC_F[5]=1;
                    }
                    if(g_GCTime>=6&&GC_F[6]==0)//6秒后
                    {
                        dSetSpritePosition("T2_5",-306.0,-215.0);//位置-306,-215.0
                        GC_F[6]=1;
                    }
                    if(g_GCTime>=7&&GC_F[7]==0)//7秒后
                    {
                        dSetSpritePosition("T2_5",0.0,1460.0);//移走5
                        dSetSpritePosition("T2_6",-196.0,-215.0);//位置-196.0,-215.0
                        GC_F[7]=1;
                    }
                    g_isLoadGC1 = 0;//记录过场2已加载
                }
                break;
            }
        case 9:
            {
                //对话开始
                //确定是哪一幕
                if(ID == 1)
                {//相遇时的对话
                    GC_time = 8;
                    //定位
                    if(g_GCTime>=2&&GC_F[2]==0)//2秒后
                    {
                        dSetSpritePosition("T1_1",97.0,86.0);//位置97.0,86.0
                        GC_F[2]=1;
                    }
                    if(g_GCTime>=3&&GC_F[3]==0)//3秒后
                    {
                        dSetSpritePosition("T1_2",200.0,115.0);//位置200.0,115.0
                        GC_F[3]=1;
                    }
                    if(g_GCTime>=4&&GC_F[4]==0)//4秒后
                    {
                        dSetSpritePosition("T1_1",0.0,1460.0);//移走1
                        dSetSpritePosition("T1_2",0.0,1460.0);//移走2
                        dSetSpritePosition("T1_3",173.0,86.0);//位置173.0,86.0
                        GC_F[4]=1;
                    }
                    if(g_GCTime>=5&&GC_F[5]==0)//5秒后
                    {
                        dSetSpritePosition("T1_4",-270.0,-215.0);//位置-270.0,-215.0
                        GC_F[5]=1;
                    }
                    if(g_GCTime>=6 &&GC_F[6]==0)//6秒后
                    {
                        dSetSpritePosition("T1_3",0.0,1460.0);//移走3
                        dSetSpritePosition("T1_5",171.5,86.0);//位置171.5,86.0
                        GC_F[6]=1;
                    }
                    if(g_GCTime>=7 && GC_F[7]==0)//7秒后
                    {
                        dSetSpritePosition("T1_4",0.0,1460.0);//移走4
                        dSetSpritePosition("T1_6",-260.0,-215.0);//位置-260.0,-215.0
                        GC_F[7]=1;
                    }
                    if(g_GCTime>=8 && GC_F[8]==0)//8秒后
                    {
                        dSetSpritePosition("T1_6",0.0,1460.0);//移走6
                        dSetSpritePosition("T1_7",-330.0,-215.0);//位置-330.0,-215.0
                        GC_F[8]=1;
                    }
                    g_isLoadGC = 0;//记录过场已加载
                }
                else
                {//击杀的对话
                    GC_time = 2;
                    //定位
                    if(g_GCTime>=2&&GC_F[2]==0)//2秒后
                    {
                        dSetSpritePosition("T2_1",-203.5,-215.0);//位置67.0,86.0
                        GC_F[2]=1;
                    }
                    g_isLoadGC1 = 0;//记录过场2已加载
                }
                break;
            }
        default:
            break;
    }
    if(g_GCTime >= GC_time + 2 && GC_F[19]==0)//9秒后
    {
        //动画结束
        //移动
        dSetSpritePosition("GC_huimu",0.0,1460.0);//移动灰幕
        dSetSpritePosition("GC_Talk1",0.0,1460.0);//移动对话框
        dSetSpritePosition("GC_Talk2",0.0,1460.0);//移动对话框
        dSetSpritePosition("T1_1",0.0,1460.0);//移动文字
        dSetSpritePosition("T1_2",0.0,1460.0);//移动文字
        dSetSpritePosition("T1_3",0.0,1460.0);//移动文字
        dSetSpritePosition("T1_4",0.0,1460.0);//移动文字
        dSetSpritePosition("T1_5",0.0,1460.0);//移动文字
        dSetSpritePosition("T1_6",0.0,1460.0);//移动文字
        dSetSpritePosition("T1_7",0.0,1460.0);//移动文字
        dSetSpritePosition("T1_8",0.0,1460.0);//移动文字
        dSetSpritePosition("T1_9",0.0,1460.0);//移动文字
        dSetSpritePosition("T2_1",0.0,1460.0);//移动文字
        dSetSpritePosition("T2_2",0.0,1460.0);//移动文字
        dSetSpritePosition("T2_3",0.0,1460.0);//移动文字
        dSetSpritePosition("T2_4",0.0,1460.0);//移动文字
        dSetSpritePosition("T2_5",0.0,1460.0);//移动文字
        dSetSpritePosition("T2_6",0.0,1460.0);//移动文字
        dSetSpritePosition("T2_7",0.0,1460.0);//移动文字
        dSetSpritePosition("T2_8",0.0,1460.0);//移动文字
        dSetSpritePosition("T2_9",0.0,1460.0);//移动文字
        //更新地图标记
        g_WhichMap = g_WhichGq+2;
        GC_F[19]=1;
        if(ID == 2)//补充Boss死亡效果
        {
            // 动态显示获胜按钮
            dSetSpritePosition("victory",0,-800);
            dSpriteMoveTo("victory",0,0,g_MenuSpeed,1);
            //dSetSpritePosition("victory",0,0);
            //更新地图标记
            g_WhichMap = -2;
        }
    }
}

