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
//g_��ͷ��Ϊϵͳ���б���
//M_��ͷΪϵͳ��Ч����
//F_Ϊϵͳ��Ǳ���
//Z_Ϊ���ǵı���
//O_Ϊ�����������
//B_ΪBoss����
//S_Ϊ���ܱ���
int			g_iGameState		=	1;		// ��Ϸ״̬��0 -- ��Ϸ�����ȴ���ʼ״̬��1 -- ���¿ո����ʼ����ʼ����Ϸ��2 -- ��Ϸ������
int         g_WhichMap = 0;         // ��¼��ǰ���ڵ�ͼ,mapmenu�еĵ����˵�ʹ��-1��ʾ����ֹ��ť��ͻ  3�ǵ�ͼ1
int         g_Whichgame = 0;        // ��¼����ͨ��������ʼΪ0��ͨ��game1Ϊ1��ͨ��game2Ϊ2 ...
int         g_WhichTj = 0;          // ��¼��ǰͼ���˵���ʾ��ʱ�ڼ�������ͼƬ
int         g_WhichGq = 0;          // ��¼��ǰ�������ڵĹؿ�
int         g_IsD = 0;              // ��¼D���Ƿ���
int         g_IsA = 0;              // ��¼A���Ƿ���
int         g_IsU = 0;              // ��¼U���Ƿ���
int         g_IsO = 0;              // ��¼O���Ƿ���
int         g_IsL = 0;              // ��¼L���Ƿ���
int         g_isattack=0;           // ��¼�����Ƿ����ڽ��й������Ƿ����ڲ��Ź���������
int         g_xbNum = 0;            // ��¼��ǰ�����ڵ�С����Ŀ
int         g_qianjin = 0;          // ��¼��ͼ�Ƿ����ǰ�����������ڵ�С��ȫ����ɱ������Ϊ1������Ϊ�㣬�����ƶ���ͼ
int         g_isLoadXb = 0;         // ��¼��һ��С���Ƿ�ǳ�
int         g_isLoadXb2 = 0;        // ��¼�ڶ���С���Ƿ�ǳ�
int         g_isLoadXb3 = 0;        // ��¼������С���Ƿ�ǳ�
int         g_isLoadBoss = 0;       // ��¼Boss�Ƿ�ǳ�
int         g_isLoadGC = 0;         // �Ƿ���ع�������
int         g_isLoadGC1 = 0;        // �Ƿ���ع�������2
int         g_re = 0;               // ��¼С���˶�����

float       g_GCTime = 0;           // ������������ʱ��
float       g_UseTime = 0;          // ÿ����Ϸ����ʱ��
float       g_gamelage = 1.25;      // ���ùؿ�ͼ��Ľ������ʱ�ķŴ���
float       g_buttonlage = 1.25;    // ���÷��ΰ�ťͼ��Ľ������ʱ�ķŴ���
float       g_otherlage = 1.15;     // ����������ťͼ��Ľ������ʱ�ķŴ���
float       g_MenuSpeed = 250;      // ���ð�ť���ƶ��ٶ�
// ����ͼ���˵���ʾ��ͼ��ͼ������ ����״̬��TJtext?ImageMap  δ����״̬��TJying?ImageMap
const char *firstname = "C";
const char *g_Tujian[] = {"TJying1ImageMap","TJying2ImageMap","TJying3ImageMap",
                          "TJying4ImageMap","TJying5ImageMap","TJying6ImageMap",
                          "TJying7ImageMap","TJying8ImageMap","TJying9ImageMap",};

const char *g_mapname[] = {"","","","game1Bg1","game1Bg1","game1Bg1",
                                     "game1Bg1","game1Bg1","game1Bg1",
                                     "game1Bg1","game1Bg1","game1Bg1",};//��¼ÿһ�ؿ��ƶ��ĵ�ͼ������

const char *g_Gqname[] = {"Game1.t2d","Game2.t2d","Game3.t2d",
                           "Game4.t2d","Game5.t2d","Game6.t2d",
                           "Game7.t2d","Game8.t2d","Game9.t2d",};//��¼ÿһ�صĵ�ͼ��

const char *B_Skillname[] = {"Boss_Skill1","Boss_Skill2","Boss_Skill3","Boss_Skill4","Boss_Skill5",
                              "Boss_Skill6","Boss_Skill7","Boss_Skill8","Boss_Skill9","Boss_Skill10",
                              "Boss_Skill11","Boss_Skill12","Boss_Skill13","Boss_Skill14","Boss_Skill15",
                              "Boss_Skill16","Boss_Skill17","Boss_Skill18","Boss_Skill19"};//��¼Boss������Ч������

const char *B_Attackname[] = {"Boss1_attackAnimation","Boss2_attackAnimation","Boss3_attackAnimation",
                               "Boss4_attack2Animation","Boss5_attackAnimation","Boss7_attack2Animation",
                               "Boss8_attack2Animation","Boss6_attackAnimation","Boss9_attackAnimation"};//��¼Boss��������������

const char *O_Skillname[] = {"XB_Skill1","XB_Skill2","XB_Skill3","XB_Skill4","XB_Skill5","XB_Skill6","XB_Skill7"};
//
int         M_BGMXWX;       // ���˵���Ч
int         M_BGMMapMenu;   // ��ͼ������Ч
int         M_BGMguanqia;   // �ؿ�BGM
int         M_ClickMenu;    // �����Ч
int         M_MouseMove;    // ����ӹ���Ч
int         M_LevelUp;      // ������Ч
int         M_Jump;         // ������Ծ��Ч
int         M_Hurt;         // ����������Ч
int         M_Attack;       // �����չ���Ч
int         M_Defult;       // ����ʧ����Ч
int         M_OHurt;        // С��������Ч
int         M_Skill1;       // ����1��Ч
int         M_Skill2;       // ����2��Ч
int         M_Skill3;       // ����3��Ч
int         M_Skill4;       // ����4��Ч
float       M_vol = 1;      // ����������С����Ҫ����������Ϊ�㡣��������ʱ����һ����������

//
const char *M_Main[]={"BGMXWX.ogg","MainBg2.ogg","MainBg3.ogg","MainBg4.ogg","MainBg5.ogg"};
const char *M_Map[]={"BGMMapMenu.wav","MapBg_3.ogg","MapBg_9.ogg"};
const char *M_Game[]={"BGMguanqia.wav","Gamebg_2.ogg","Gamebg_37.ogg",
                       "Gamebg_4.ogg","Gamebg_56.ogg","Gamebg_56.ogg",
                       "Gamebg_37.ogg","Gamebg_8.ogg","Gamebg_9.ogg"};
//
int         F_Mflag1=0x00;      // ��¼��Ч���Ŵ���
int         F_Mflag2=0x000;     // ��¼��Ч���Ŵ���

//
int         Z_gongji = 10;      //��¼���ǻ������� ==> ����
int         Z_shengming = 100;  //��¼���ǻ������� ==> ����
int         Z_blood = 100;      //��¼���ǵ�ǰѪ��
int         Z_speed = 200;      //��¼���ǻ������� ==> �ٶ�
int         Z_fangyv = 10;      //��¼���ǻ������� ==> ����
int         Z_jingyan = 0;      //��¼����Ŀǰ�ľ���
int         Z_levelMax = 30;    //��¼���ǵ������ֵ
int         Z_level = 1;        //��¼���ǵ�ǰ�ȼ�
int         Z_jump = 1;         //��¼�����ܷ���Ծ
int         Z_jumphigh = -600;  //��¼������Ծ��������С��Ӱ����Ծ�߶ȣ�
int         Z_Mass = 10;        //��¼��������
int         Z_top = 'D';        //��¼���ǳ���'D'��'A'
int         Z_IsPugong = 1;     //��¼�����Ƿ���Խ����չ�
int         Z_Ishurt = 1;       //��¼�����Ƿ�ɱ���ײ
int         Z_IsSkill[] = {0,0,0,0};//��¼�����Ƿ�����ͷż���

float       Z_hurtID = 1/(1+(Z_fangyv/100.0)); //��¼���ǵļ���ϵ��
float       Z_attackTime;       //��¼���Ǿ��ϴν�����ʱ��
float       Z_hurtTime;         //��¼���Ǿ��ϴ����˵�ʱ��
float       Z_PgJiange = 0.6;   //�������ǵ��չ����
float       Z_hurtJg = 1;     //�������ǵ����˼��
float       Z_PosX = -470;      //��¼���ǵ�ǰλ�õ�X����
float       Z_PosY = -87;       //��¼���ǵ�ǰλ�õ�Y����
float       Z_Bloodlen = 255;   //��¼����ԭѪ������
float       Z_BloodPosX = -346; //��¼����ԭѪ��λ��
float       Z_Levellen = 228;   //��¼����ԭ����������
float       Z_LevelPosX = -346; //��¼����ԭ������λ��

const char *Z_name = "zhujue";              //��¼��������
const char *Z_BloodName ="Z_bloodnum";      //����Ѫ��������
const char *Z_LevelName ="Z_levelnum";      //���Ǿ�����������
const char *Z_run = "Z_runAnimation";       //��¼���Ǳ��ܶ�����
const char *Z_stand = "Z_standAnimation";   //��¼���Ǿ�ֹ������
const char *Z_attack = "Z_attackAnimation"; //��¼���ǹ���������
const char *Z_hurt = "Z_hurtAnimation";     //��¼�������˶�����
const char *Z_die = "Z_dieAnimation";       //��¼��������������
const char *Z_pugong = "Z_pugongAnimation"; //��¼������ͨ�����Ķ�����

//
float S_SpeedTime = 0;              //��¼�����ͷ�һ���ܺ��ƶ����������ʱ��
float S_SpeedTime3 = 0;             //��¼�����ͷ������ܺ��ƶ����̾�ֹ��ʱ��
float S_SpeedTime4 = 0;             //��¼�����ͷ��ļ��ܺ��ƶ����̾�ֹ��ʱ��
float S_Time1 = 0;                  //��¼����һ���ͷż��
float S_Time2 = 0;                  //��¼���ܶ����ͷż��
float S_Time3 = 0;                  //��¼���������ͷż��
float S_Time4 = 0;                  //��¼�����ĵ��ͷż��
float S_CD1 = 4;                    //��¼����һ����ȴʱ��
float S_CD2 = 3;                    //��¼���ܶ�����ȴʱ��
float S_CD3 = 6;                    //��¼����������ȴʱ��
float S_CD4 = 9;                    //��¼�����ĵ���ȴʱ��

const char *S_pugong = "pugong";    //��¼�����չ������ľ�����

char S_Top = 'D';                   //��¼һ���ܵ��ͷŷ���

//
char O_IsSkill[6] = {0,0,0,0,0,0};       //��¼ÿһ��С���Ƿ���Է������� 0 ==> ������; 1 ==> ����
char O_IsPengzhuang[6] = {1,1,1,1,1,1};  //��¼С���Ƿ����ײ 1 ==> ����ײ  0 ==> ������ײ
char O_isattack = 0;                     //��¼��ǰ�����Ƿ��Ѿ��������



int O_hurt[9] = {10,15,20,25,32,40,45,48,50};//��¼ÿһ��С���˺�
int O_bloodMax = 100;                   //��¼ÿһ��С��Ѫ�����ޣ�ÿһ�ط���
int O_blood[6] = {0,0,0,0,0,0};         //��¼С�ֵ�Ѫ��
int O_i = 0;                            //��¼��ǰС��ID
int O_numSprite = 0;                    //��¼��ǰ�˺���ʾϵͳ�ľ���������1000֮������
int O_speed = 15;                       //��¼С��ƽ��״̬���ٶ�
int O_Sspeed = 50;                      //��¼С����ŭ״̬���ٶ�

float O_attackPosX = 0;                 //��¼С�ֶ��㹥����λ��
float O_attackTime = 0;                 //��¼���ض����Ƿ���������ʱ����
float O_attack = 2;                     //����ÿ������С�ַ���һ�ι���
float O_PengzhuangTime = 0.5;           //���þ����뼼����ײ��ʱ����
float O_JiluTime[6] = {};               //��¼����һ����ײ�����ʱ��
float O_attTime[6] ={};                 //��¼С�ֶ����Ƿ���������ʱ����

//
int B_IsPengzhuang = 1;                 //��¼Boss�Ƿ����ײ1����ײ��0������ײ
char B_IsAttack = 0;                     //��¼Boss�Ƿ��Ѿ��������� 0 û��  1 ������
int B_Shengming = 500;                  //����Boss��Ѫ������
int B_Blood = 500;                      //��¼Boss��ǰѪ��ֵ
int B_Gongji = 50;                      //����Boss�Ĺ�����
int B_Fangyv = 50;                      //����Boss�ķ�����
int B_Speed = 50;                       //����Boss���ٶ�
int B_num = 0;                          //��¼����Boss��
int B_i = 0;                            //��¼��ǰBoss����ID������������
int B_SkillSpeed = 500;                 //����Boss�����ٶ�

float B_PengzhuangTime = 0.5;           //����Boss����ײʱ����
float B_JiangeTime = 0;                 //��¼Boss���ϴ���ײ�����ļ��ʱ��
float B_attack = 4;                     //����Bossÿ���೤ʱ�����һ�ι���
float B_attackTime = 0;                 //��¼�����ϴ�Boss����������ȥ�˶೤ʱ��

int GC_F[20] = {};                      //�����������
int GC_ID = 0;                          //��¼���������ڼ�Ļ

float GC_time = 0;                      //��¼����ʱ��
//
void		GameInit();
void		GameRun( float fDeltaTime );
void		GameEnd();

//==============================================================================
//
// ����ĳ�������Ϊ��GameMainLoop����Ϊ��ѭ��������������ÿ֡ˢ����Ļͼ��֮�󣬶��ᱻ����һ�Ρ�


//==============================================================================
//
// ��Ϸ��ѭ�����˺���������ͣ�ĵ��ã�����ÿˢ��һ����Ļ���˺�����������һ��
// ���Դ�����Ϸ�Ŀ�ʼ�������С������ȸ���״̬.
// ��������fDeltaTime : �ϴε��ñ��������˴ε��ñ�������ʱ��������λ����
void GameMainLoop( float	fDeltaTime )
{
    switch( g_iGameState )
    {
        // ��ʼ����Ϸ�������һ���������
    case 1:
        {
            GameInit();
            g_iGameState	=	2; // ��ʼ��֮�󣬽���Ϸ״̬����Ϊ������
        }
        break;

        // ��Ϸ�����У����������Ϸ�߼�
    case 2:
        {
            // TODO �޸Ĵ˴���Ϸѭ�������������ȷ��Ϸ�߼�
            if( true )
            {
                GameRun( fDeltaTime );
            }
            else
            {
                // ��Ϸ������������Ϸ���㺯����������Ϸ״̬�޸�Ϊ����״̬
                g_iGameState	=	0;
                GameEnd();
            }
        }
        break;

        // ��Ϸ����/�ȴ����ո����ʼ
    case 0:
    default:
        break;
    };
}

//==============================================================================
//
// ÿ�ֿ�ʼǰ���г�ʼ���������һ���������
void GameInit()
{
    //��ʼ��ʱ������
    g_UseTime = 0;
    switch(g_WhichMap)
    {
        case 0://��ʼ����ӭ����
            {
                // ���������Ϸ��ӭ����δ������
                // ���ػ�ӭ����
                // ���ػ�ӭҳ��
                // �ȴ�һ�����
                Sleep(1500);
                // �������˵�����
                dLoadMap("MainMenu.t2d");
                // ����BGM
                M_BGMXWX=dPlaySound("BGMXWX.ogg",1,1*M_vol);
                // ����ǰ��ͼ���Ϊ1
                g_WhichMap = 1;
            }
        case 1://��ʼ����ʼ���˵�����
            {
                dStopAllSound();
                M_BGMXWX=dPlaySound(M_Main[g_Whichgame/2],1,1*M_vol);
            }
            break;
        case 2://��ʼ����ͼ�˵�����
            {
                //�ر���Ч
                dStopAllSound();
                // ����BGM
                M_BGMMapMenu=dPlaySound(M_Map[g_Whichgame/4],1,1*M_vol);
                //�����ͼ�˵���浵
                GameSave();
                //�������еĵ�ͼ�ؿ�����˵��
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
                //��ʼ��&����ͼ��
                GameTjInit(g_Whichgame);
                //��ʼ��&������������
                ShowShuxing("menusx_sm",Z_shengming);
                ShowShuxing("menusx_fy",Z_fangyv);
                ShowShuxing("menusx_gj",Z_gongji);
                ShowShuxing("menusx_ys",Z_speed);
                ShowMap(Z_level, Z_shengming);

            }
            break;
        case 11:    //��ʼ����ͼ9
        case 10:    //��ʼ����ͼ8
        case 9:     //��ʼ����ͼ7
        case 8:     //��ʼ����ͼ6
        case 7:     //��ʼ����ͼ5
        case 6:     //��ʼ����ͼ4
        case 5:     //��ʼ����ͼ3
        case 4:     //��ʼ����ͼ2
        case 3:     //��ʼ����ͼ1
            {
                //��¼��ǰ���ڹؿ�
                g_WhichGq = g_WhichMap - 2;
                //�ر���Ч
                dStopAllSound();
                // ����BGM
                M_BGMguanqia=dPlaySound(M_Game[g_WhichGq-1],1,1*M_vol);
                //һ��Ԫ�ػع��ʼλ��
                //����״̬�ع��ʼ��
                //��ʼ�����Ǽ���
                SkillInit(Z_level);
                //������������
                dSetSpriteMass(Z_name,Z_Mass);
                //���õ�ͼ�����ƶ�
                g_qianjin = 0;
                //���ܱ������
                g_IsU = 0;
                g_IsO = 0;
                g_IsL = 0;
                //����
                S_Top = 'D';
                Z_top = 'D';
                //���õ�һ,����������û�в���
                g_isLoadXb = 0;
                g_isLoadXb2 = 0;
                g_isLoadXb3 = 0;
                //����Boss��δ����
                g_isLoadBoss = 0;
                //����С������Boss��Ϊ0
                g_xbNum = 0;
                B_num = 0;
                //���С��δ��������
                O_isattack = 0;
                //��ʼ������Ѫ��
                Z_blood = Z_shengming;
                //��ʼ��Ѫ����ʾ��ͼ�Σ�
                BloodLen(Z_BloodName,Z_Bloodlen,Z_shengming,Z_blood,Z_BloodPosX);
                //��ʼ������ֵ��ʾ��ͼ�Σ�
                BloodLen(Z_LevelName,Z_Levellen,Z_levelMax,Z_jingyan,Z_LevelPosX);
                ShowNum(2,Z_shengming);//��ʾѪ�����ֵ����ֵ��
                ShowNum(0,Z_blood);//��ʾѪ������ֵ��
                ShowNum(3,Z_levelMax);//��ʾ�������ֵ����ֵ��
                ShowNum(1,Z_jingyan);//��ʾ��ǰ���飨��ֵ��
                //��ʾ�ȼ�
                 dSetStaticSpriteFrame("level",Z_level-1);
                //���չ���Ч��������
                //dSetSpriteVisible(S_pugong,0);
                //�������ǵĳ�������
                dSetSpriteConstantForce(Z_name,0,1000,1);
                //��ͼ��ʼ������ͼ�����ƶ�
                dSetSpriteImmovable(g_mapname[g_WhichMap],1);
                // ��ʼ��BossѪ��
                B_Blood = B_Shengming;
                // ��¼��ǰͨ�ؽ���
                // ����ǵ�һ�ε��ﱾ��,���Ź�������
                if(g_Whichgame<g_WhichGq)
                {
                    //���Ź�������
                    g_isLoadGC = 1;
                    g_isLoadGC1 = 1;
                }else
                {
                    //�����Ź�������
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
// ÿ����Ϸ������
void GameRun( float fDeltaTime )
{
    switch(g_WhichMap)
    {
    case 1://���˵�
        {
        }
        break;
    case 2://��ͼ�˵�
        {
        }
        break;
    case 11://�ھŹعؿ���ͼ
    case 10://�ڰ˹عؿ���ͼ
    case 9://���߹عؿ���ͼ
    case 8://�����عؿ���ͼ
    case 7://����عؿ���ͼ
    case 6://���Ĺعؿ���ͼ
    case 5://�����عؿ���ͼ
    case 4://�ڶ��عؿ���ͼ
    case 3://��һ�عؿ���ͼ
        {
            // �����ƶ�����
            GameMove();
            g_UseTime += fDeltaTime;
            //��������Ϸ����ʾ����ʱ��
            // ��¼���ǵĹ������ʱ��
            Z_attackTime += fDeltaTime;
            // ��¼Boss�Ĺ������
            B_attackTime += fDeltaTime;
            // ��¼���ط���������ʱ����
            O_attackTime += fDeltaTime;
            // ��¼С������������ʱ����
            for(O_i=0;O_i<6;O_i++)
            {
                //��¼����С���Ĺ������ʱ��ID:0~5
                O_attTime[O_i] += fDeltaTime;
            }

            for(O_i=0;O_i<6;O_i++)
            {
                if(O_IsSkill[O_i]==0 && O_attTime[O_i]>=3 && g_xbNum > 0)
                {
                    //���С�����ɷ����������ҳ���С��������0������ʱ�Ƿ��3��
                    //������ӦС���ӹ�������
                    O_IsSkill[O_i]=1;
                }
            }
            // ��¼���Ǽ���1����ʱ��
            S_SpeedTime += fDeltaTime;
            // ��¼���Ǽ���3��ֹʱ��
            S_SpeedTime3 += fDeltaTime;
            // ��¼���Ǽ���4��ֹʱ��
            S_SpeedTime4 += fDeltaTime;
            // ��¼���Ǽ���CD
            S_Time1 += fDeltaTime;
            S_Time2 += fDeltaTime;
            S_Time3 += fDeltaTime;
            S_Time4 += fDeltaTime;
            // ��¼���ǵ��ܹ���ʱ��
            Z_hurtTime += fDeltaTime;
            // ��¼Boss���ܹ������ʱ��
            B_JiangeTime += fDeltaTime;

            // ��ʾ������ʱ
            SysTime(g_UseTime);
            // ��¼С�����ܹ������ʱ��
            for(O_i=0;O_i<6;O_i++)
            {
                //��¼����С�����ܹ������ID:0~5
                O_JiluTime[O_i] += fDeltaTime;
            }
            //��׽���ǵ�λ�ò��洢
            Z_PosX = dGetSpritePositionX(Z_name);
            Z_PosY = dGetSpritePositionY(Z_name);

            //�������С��δ�������ͼ��ֹ�˶�
            if(g_qianjin == 0)
            {
                dSetSpriteImmovable(g_mapname[g_WhichMap],1);
            }
            //����ȥ��ʱ��������ǵ���ͨ�������
            if (Z_attackTime>=Z_PgJiange)
            {
                //���Խ����չ�
                Z_IsPugong =1;
            }
            //������ǰ����-450ʱ����С��δ�ǳ�����С���ǳ�
            if(Z_PosX >= -450 &&  g_isLoadXb == 0)
            {
                //ɾ��GOGOGO
                dDeleteSprite("GOGOGO");
                //��¡С����С���ǳ�
                GameClone();
                //���С��δ��������
                O_isattack = 0;
                //��g_isLoadXb��Ϊ1����ʾС���ǳ����
                g_isLoadXb = 1;
            }
            //�ж������Ƿ����ײ��1=����ײ��0=������ײ
            //�����Ǳ���ײ���ʱ1�룬��������������ײ
             if(Z_Ishurt==0 && Z_hurtTime>=Z_hurtJg)
             {
                 //�������ǽ�����ײ����
                dSetSpriteCollisionReceive(Z_name,1);
                //��Ǿ��鿪����ײ
                Z_Ishurt = 1;
             }
            //�ж�С���Ƿ����ײ��1=����ײ��0=������ײ
            //��С������ײ���ʱ0.3�룬��������С����ײ
            for(O_i=0;O_i<6;O_i++)
            {
                if(O_IsPengzhuang[O_i]==0 && O_JiluTime[O_i]>=O_PengzhuangTime)
                {
                    //���������ײ������ʱ�Ƿ��0.4��
                    //������ӦС��������ײ����
                    dSetSpriteCollisionReceive(dMakeSpriteName("xiaobing",O_i+1),1);
                    //��Ǿ��鿪����ײ
                    O_IsPengzhuang[O_i]=1;
                }
            }
            //�ж�Boss�Ƿ����ײ
            if(B_IsPengzhuang==0 && B_JiangeTime >= B_PengzhuangTime)
            {
                // ����Boss��ײ
                dSetSpriteCollisionReceive("Boss1",1);
                // ���Boss����ײ
                B_IsPengzhuang = 1;
            }
            //���＼��
            //������һ����0.3�������ǲ��ɼ�������
            if (S_SpeedTime >= 0.3 && Z_IsSkill[0]==0 && g_IsU ==1)
            {
                g_IsU = 0;
                //�ƶ�����λ��
                if(S_Top == 'D')
                {
                    dSetSpritePositionX(Z_name,Z_PosX+400);
                }
                else if (S_Top == 'A')
                {
                    dSetSpritePositionX(Z_name,Z_PosX-400);
                }
                //���ǿɼ������ƶ�,������ײ
                dSetSpriteVisible(Z_name,1);//�ɼ�
                dSetSpriteImmovable(Z_name,0);//�ɶ�
                dSetSpriteCollisionReceive(Z_name,1);//������ײ
            }
            //������������0.3�������ǲ��ɶ�
            if (S_SpeedTime3 >= 0.3 && Z_IsSkill[2]==0 && g_IsO==1)
            {
                g_IsO = 0;
                //���ǿɼ������ƶ�,������ײ
                dSetSpriteVisible(Z_name,1);//�ɼ�
                dSetSpriteImmovable(Z_name,0);//�ɶ�
                dSetSpriteCollisionReceive(Z_name,1);//������ײ
            }
            //�������ļ���0.3�������ǲ��ɶ�
            if (S_SpeedTime4 >= 0.3 && Z_IsSkill[3]==0 && g_IsL==1)
            {
                g_IsL =0;
                //���ǿɼ������ƶ�,������ײ
                dSetSpriteVisible(Z_name,1);//�ɼ�
                dSetSpriteImmovable(Z_name,0);//�ɶ�
                dSetSpriteCollisionReceive(Z_name,1);//������ײ
            }

            //������ȴ�����Ƿ񲥷����
            if (dIsAnimateSpriteAnimationFinished("skillCD1")&&Z_level>1)
            {
                //�������
                Z_IsSkill[0]=1;//���Է�������1
            }
            //������ȴ�����Ƿ񲥷����
            if (dIsAnimateSpriteAnimationFinished("skillCD2")&&Z_level>2)
            {
                //�������
                Z_IsSkill[1]=1;//���Է�������2
            }
            if (dIsAnimateSpriteAnimationFinished("skillCD3")&&Z_level>3)
            {
                //�������
                Z_IsSkill[2]=1;//���Է�������3
            }
            if (dIsAnimateSpriteAnimationFinished("skillCD4")&&Z_level>5)
            {
                //�������
                Z_IsSkill[3]=1;//���Է�������4
            }
            //С���ж�
            GameXbMove(Z_PosX);
            //С������
            GameXbAttack(Z_PosX);
            //�жϼ��ܶ����Ƿ��ڲ���0=>���ڲ��ţ�1=>�������
            if(dIsAnimateSpriteAnimationFinished(S_pugong))
            {
                //����������ϣ��ر�����ײ��ʹ���޷�������ײ
                dSetSpriteCollisionSend(S_pugong,0);

            }
            else//�������ڲ���
            {
                if(strcmp(dGetAnimateSpriteAnimationName(S_pugong),"Z_pugongAnimation1")==0)//��ʼ�Ķ�����������ײ
                {
                    dSetSpriteCollisionSend(S_pugong,0);
                }
                else
                {
                    //������ײ��������Է�����ײ
                    dSetSpriteCollisionSend(S_pugong,1);
                }

            }
            //�����ͼ�˶���400���λ�ã���ô���صڶ�����
            if(dGetSpritePositionX(g_mapname[g_WhichMap])<=400 && g_isLoadXb2 == 0)
            {
                //��¡�ڶ���
                //��¡С����С���ǳ�
                GameClone();
                //���С��δ��������
                O_isattack = 0;
                //��g_isLoadXb��Ϊ1����ʾС���ǳ����
                g_isLoadXb2 = 1;
            }
            //�����ͼ�˶���-400���λ�ã���ô���ص�������
            if(dGetSpritePositionX(g_mapname[g_WhichMap])<=-400 && g_isLoadXb3 == 0)
            {
                //��¡������
                //��¡С����С���ǳ�
                GameClone();
                //���С��δ��������
                O_isattack = 0;
                //��g_isLoadXb��Ϊ1����ʾС���ǳ����
                g_isLoadXb3 = 1;
            }
            //�ж�Boss�����Ƿ�ִ��
            //��ͼ�˶���-1251���λ�ã���Ҫ����Boss���ж��Ƿ���ع�������
            if(dGetSpritePositionX(g_mapname[g_WhichMap])<=-1251 && g_isLoadGC == 1)
            {
                //��ͼ���ɶ�
                dSetSpriteImmovable(g_mapname[g_WhichMap],1);
                //��¼�ǵ�Ļ��������
                GC_ID = 1;
                //�ı��ͼ���
                g_WhichMap = -3;//���ٽ������ѭ������ʼ����ʱ��ѭ��
                //�������
                for(int i=0;i<20;i++)
                {
                    GC_F[i]=0;
                }
                g_GCTime = 0;
                //break;
                //�Ƚ��й�������===����
                //GameLoadGC(g_WhichGq,1);
            }


            //�����ͼ�˶���-1251���λ�ã���ô����Boss
            if(dGetSpritePositionX(g_mapname[g_WhichMap])<=-1251 && g_isLoadBoss == 0 && g_isLoadGC == 0)
            {
                //��¡Boss��Boss�ǳ�
                CloneBoss(g_WhichMap);
                //��g_isLoadXb��Ϊ1����ʾBoss�ǳ����
                g_isLoadBoss = 1;
            }
            // ��Boss�ǳ�����boss��ʼ�ƶ�
            if(g_isLoadBoss==1)
            {
                BossAction(Z_PosX);
            }

            if (Z_blood <= 0)
            {
                //dSetSpritePosition("defeat",0,0);
                dSetSpritePosition("defeat",0,-800);
                dSpriteMoveTo("defeat",0,0,g_MenuSpeed,1);
                //���µ�ͼ���
                g_WhichMap = -2;
                //������Ч
                M_Defult = dPlaySound("Z_Defult.wav",0,1*M_vol);
            }
        }
        break;
    case -3:
        {
            g_GCTime += fDeltaTime;//��¼��������ʱ��
            //�Ƚ��й�������
            GameLoadGC(g_WhichGq,GC_ID);
            break;
        }
    default:
        break;
    }
}
//==============================================================================
//
// ������Ϸ����
void GameEnd()
{
}
//==========================================================================
//
// ����ƶ�
// ���� fMouseX, fMouseY��Ϊ��굱ǰ����
void OnMouseMove( const float fMouseX, const float fMouseY )
{
    // �ж�Ŀǰ���ǿ��������ĸ���ͼ
    switch(g_WhichMap)
    {
        //���˵�
    case 1:
        {
            // ����ƶ������Ч
            // ��ʼ��Ϸ��ť
            if(dIsPointInSprite("Begin",fMouseX,fMouseY))
            {
                // ͼƬ�Ŵ�
                dSetSpriteScale("Begin",g_buttonlage);
                // ������Ч,ֻ��һ��
                if((F_Mflag1&0x01) == 0)
                {
                    M_MouseMove = dPlaySound("MouseMove.wav",0,1*M_vol);
                    F_Mflag1 |= 0x01;
                }
            }
            else
            {
                //ͼƬ���仯
                dSetSpriteScale("Begin",1);
                //������Ч���ż���
                F_Mflag1 &= 0xfe;
            }

            //����ƶ������Ч
            //�ɵĻ��䰴ť
            if(dIsPointInSprite("Load",fMouseX,fMouseY))
            {
                //ͼƬ�Ŵ�
                dSetSpriteScale("Load",g_buttonlage);
                // ������Ч,ֻ��һ��
                if((F_Mflag1&0x02) == 0)
                {
                    M_MouseMove = dPlaySound("MouseMove.wav",0,1*M_vol);
                    F_Mflag1 |= 0x02;
                }
            }
            else
            {
                //ͼƬ���仯
                dSetSpriteScale("Load",1);
                //������Ч���ż���
                F_Mflag1 &= 0xfd;
            }

            //����ƶ������Ч
            //��Ϸ���ܰ�ť
            if(dIsPointInSprite("Intor",fMouseX,fMouseY))
            {
                //ͼƬ�Ŵ�
                dSetSpriteScale("Intor",g_buttonlage);
                // ������Ч,ֻ��һ��
                if((F_Mflag1&0x04) == 0)
                {
                    M_MouseMove = dPlaySound("MouseMove.wav",0,1*M_vol);
                    F_Mflag1 |= 0x04;
                }
            }
            else
            {
                //ͼƬ���仯
                dSetSpriteScale("Intor",1);
                //������Ч���ż���
                F_Mflag1 &= 0xfb;
            }
///////////////////////////////////////////////////////////////////////////////
            //����ƶ������Ч
            //��Ϸ����1��ť-�ر�
            if(dIsPointInSprite("Intor1_Close",fMouseX,fMouseY))
            {
                //ͼƬ�Ŵ�
                dSetSpriteScale("Intor1_Close",g_buttonlage);
                // ������Ч,ֻ��һ��
                if((F_Mflag2&0x001) == 0)
                {
                    M_MouseMove = dPlaySound("MouseMove.wav",0,0.7*M_vol);
                    F_Mflag2 |= 0x001;//�����1
                }
            }
            else
            {
                //ͼƬ���仯
                dSetSpriteScale("Intor1_Close",1);
                //������Ч���ż���
                F_Mflag2 &= 0xffe;//�����0
            }
            //��Ϸ����2��ť-�ر�
            if(dIsPointInSprite("Intor2_Close",fMouseX,fMouseY))
            {
                //ͼƬ�Ŵ�
                dSetSpriteScale("Intor2_Close",g_buttonlage);
                // ������Ч,ֻ��һ��
                if((F_Mflag2&0x002) == 0)
                {
                    M_MouseMove = dPlaySound("MouseMove.wav",0,0.7*M_vol);
                    F_Mflag2 |= 0x002;//�����1
                }
            }
            else
            {
                //ͼƬ���仯
                dSetSpriteScale("Intor2_Close",1);
                //������Ч���ż���
                F_Mflag2 &= 0xffd;//�����0
            }
            //��Ϸ����1��ť-��һҳ
            if(dIsPointInSprite("Intor_Next",fMouseX,fMouseY))
            {
                //ͼƬ�Ŵ�
                dSetSpriteScale("Intor_Next",g_buttonlage);
                // ������Ч,ֻ��һ��
                if((F_Mflag2&0x004) == 0)
                {
                    M_MouseMove = dPlaySound("MouseMove.wav",0,0.7*M_vol);
                    F_Mflag2 |= 0x004;//�����1
                }
            }
            else
            {
                //ͼƬ���仯
                dSetSpriteScale("Intor_Next",1);
                //������Ч���ż���
                F_Mflag2 &= 0xffb;//�����0
            }
            //��Ϸ����2��ť-��һҳ
            if(dIsPointInSprite("Intor_Back",fMouseX,fMouseY))
            {
                //ͼƬ�Ŵ�
                dSetSpriteScale("Intor_Back",g_buttonlage);
                // ������Ч,ֻ��һ��
                if((F_Mflag2&0x008) == 0)
                {
                    M_MouseMove = dPlaySound("MouseMove.wav",0,0.7*M_vol);
                    F_Mflag2 |= 0x008;//�����1
                }
            }
            else
            {
                //ͼƬ���仯
                dSetSpriteScale("Intor_Back",1);
                //������Ч���ż���
                F_Mflag2 &= 0xff7;//�����0
            }
            //��Ϸ����2��ť-A
            if(dIsPointInSprite("M_A",fMouseX,fMouseY))
            {
                //ͼƬ�Ŵ�
                dSetSpriteScale("M_A",g_buttonlage);
                // ������Ч,ֻ��һ��
                if((F_Mflag2&0x010) == 0)
                {
                    M_MouseMove = dPlaySound("MouseMove.wav",0,0.7*M_vol);
                    F_Mflag2 |= 0x010;//�����1
                }
            }
            else
            {
                //ͼƬ���仯
                dSetSpriteScale("M_A",1);
                //������Ч���ż���
                F_Mflag2 &= 0xfef;//�����0
            }
            //��Ϸ����2��ť-D
            if(dIsPointInSprite("M_D",fMouseX,fMouseY))
            {
                //ͼƬ�Ŵ�
                dSetSpriteScale("M_D",g_buttonlage);
                // ������Ч,ֻ��һ��
                if((F_Mflag2&0x020) == 0)
                {
                    M_MouseMove = dPlaySound("MouseMove.wav",0,0.7*M_vol);
                    F_Mflag2 |= 0x020;//�����1
                }
            }
            else
            {
                //ͼƬ���仯
                dSetSpriteScale("M_D",1);
                //������Ч���ż���
                F_Mflag2 &= 0xfdf;//�����0
            }
            //��Ϸ����2��ť-J
            if(dIsPointInSprite("M_J",fMouseX,fMouseY))
            {
                //ͼƬ�Ŵ�
                dSetSpriteScale("M_J",g_buttonlage);
                // ������Ч,ֻ��һ��
                if((F_Mflag2&0x040) == 0)
                {
                    M_MouseMove = dPlaySound("MouseMove.wav",0,0.7*M_vol);
                    F_Mflag2 |= 0x040;//�����1
                }
            }
            else
            {
                //ͼƬ���仯
                dSetSpriteScale("M_J",1);
                //������Ч���ż���
                F_Mflag2 &= 0xfbf;//�����0
            }
            //��Ϸ����2��ť-K
            if(dIsPointInSprite("M_K",fMouseX,fMouseY))
            {
                //ͼƬ�Ŵ�
                dSetSpriteScale("M_K",g_buttonlage);
                // ������Ч,ֻ��һ��
                if((F_Mflag2&0x080) == 0)
                {
                    M_MouseMove = dPlaySound("MouseMove.wav",0,0.7*M_vol);
                    F_Mflag2 |= 0x080;//�����1
                }
            }
            else
            {
                //ͼƬ���仯
                dSetSpriteScale("M_K",1);
                //������Ч���ż���
                F_Mflag2 &= 0xf7f;//�����0
            }

/////////////////////////////////////////////////////////////////////////////
            //����ƶ������Ч
            //������Ա��ť
            if(dIsPointInSprite("About",fMouseX,fMouseY))
            {
                //ͼƬ�Ŵ�
                dSetSpriteScale("About",g_buttonlage);
                // ������Ч,ֻ��һ��
                if((F_Mflag1&0x08) == 0)
                {
                    M_MouseMove = dPlaySound("MouseMove.wav",0,1*M_vol);
                    F_Mflag1 |= 0x08;
                }
            }
            else
            {
                //ͼƬ���仯
                dSetSpriteScale("About",1);
                //������Ч���ż���
                F_Mflag1 &= 0xf7;
            }

            //������Ա�رհ�ť
            if(dIsPointInSprite("About_Close",fMouseX,fMouseY))
            {
                //ͼƬ�Ŵ�
                dSetSpriteScale("About_Close",g_buttonlage);
                // ������Ч,ֻ��һ��
                if((F_Mflag2&0x100) == 0)
                {
                    M_MouseMove = dPlaySound("MouseMove.wav",0,0.7*M_vol);
                    F_Mflag2 |= 0x100;//�����1
                }
            }
            else
            {
                //ͼƬ���仯
                dSetSpriteScale("About_Close",1);
                //������Ч���ż���
                F_Mflag2 &= 0xeff;//�����0
            }

/////////////////////////////////////////////////////////////////////////////////

            //����ƶ������Ч
            //�˳���Ϸ��ť
            if(dIsPointInSprite("Exit",fMouseX,fMouseY))
            {
                //ͼƬ�Ŵ�
                dSetSpriteScale("Exit",g_buttonlage);
                // ������Ч,ֻ��һ��
                if((F_Mflag1&0x10) == 0)
                {
                    M_MouseMove = dPlaySound("MouseMove.wav",0,1*M_vol);
                    F_Mflag1 |= 0x10;
                }
            }
            else
            {
                //ͼƬ���仯
                dSetSpriteScale("Exit",1);
                //������Ч���ż���
                F_Mflag1 &= 0xef;
            }
        }
        break;
    case 2://�����˵��������ǲ���������ӹ���Ч
        {
            // ����ƶ����Ч��
            //game1
            if(dIsPointInSprite("game1",fMouseX,fMouseY))
            {
                // ͼƬ�Ŵ�
                dSetSpriteScale("game1",g_gamelage);
            }
            else
            {
                //ͼƬ���仯
                dSetSpriteScale("game1",1);
            }
            //game2
            if(dIsPointInSprite("game2",fMouseX,fMouseY))
            {
                // ͼƬ�Ŵ�
                dSetSpriteScale("game2",g_gamelage);
            }
            else
            {
                //ͼƬ���仯
                dSetSpriteScale("game2",1);
            }
            //game3
            if(dIsPointInSprite("game3",fMouseX,fMouseY))
            {
                // ͼƬ�Ŵ�
                dSetSpriteScale("game3",g_gamelage);
            }
            else
            {
                //ͼƬ���仯
                dSetSpriteScale("game3",1);
            }
            //game4
            if(dIsPointInSprite("game4",fMouseX,fMouseY))
            {
                // ͼƬ�Ŵ�
                dSetSpriteScale("game4",g_gamelage);
            }
            else
            {
                //ͼƬ���仯
                dSetSpriteScale("game4",1);
            }
            //game5
            if(dIsPointInSprite("game5",fMouseX,fMouseY))
            {
                // ͼƬ�Ŵ�
                dSetSpriteScale("game5",g_gamelage);
            }
            else
            {
                //ͼƬ���仯
                dSetSpriteScale("game5",1);
            }
            //game6
            if(dIsPointInSprite("game6",fMouseX,fMouseY))
            {
                // ͼƬ�Ŵ�
                dSetSpriteScale("game6",g_gamelage);
            }
            else
            {
                //ͼƬ���仯
                dSetSpriteScale("game6",1);
            }
            //game7
            if(dIsPointInSprite("game7",fMouseX,fMouseY))
            {
                // ͼƬ�Ŵ�
                dSetSpriteScale("game7",g_gamelage);
            }
            else
            {
                //ͼƬ���仯
                dSetSpriteScale("game7",1);
            }
            //game8
            if(dIsPointInSprite("game8",fMouseX,fMouseY))
            {
                // ͼƬ�Ŵ�
                dSetSpriteScale("game8",g_gamelage);
            }
            else
            {
                //ͼƬ���仯
                dSetSpriteScale("game8",1);
            }
            //game9
            if(dIsPointInSprite("game9",fMouseX,fMouseY))
            {
                // ͼƬ�Ŵ�
                dSetSpriteScale("game9",g_gamelage);
            }
            else
            {
                //ͼƬ���仯
                dSetSpriteScale("game9",1);
            }
            //���ð�ť
            if(dIsPointInSprite("buttonsz",fMouseX,fMouseY))
            {
                // ͼƬ�Ŵ�
                dSetSpriteScale("buttonsz",g_otherlage);
            }
            else
            {
                //ͼƬ���仯
                dSetSpriteScale("buttonsz",1);
            }
            //ͼ����ť
            if(dIsPointInSprite("buttontj",fMouseX,fMouseY))
            {
                // ͼƬ�Ŵ�
                dSetSpriteScale("buttontj",g_otherlage);
            }
            else
            {
                //ͼƬ���仯
                dSetSpriteScale("buttontj",1);
            }
             //���԰�ť
            if(dIsPointInSprite("buttonsx",fMouseX,fMouseY))
            {
                // ͼƬ�Ŵ�
                dSetSpriteScale("buttonsx",g_otherlage);
            }
            else
            {
                //ͼƬ���仯
                dSetSpriteScale("buttonsx",1);
            }
        }
        break;
    case -1:// ���˵��ĵ�����������ӹ�Ч��
        {
            //���Բ˵��Ĺرհ�ť
            if(dIsPointInSprite("menusx_close",fMouseX,fMouseY))
            {
                // ͼƬ�Ŵ�
                dSetSpriteScale("menusx_close",g_otherlage);
            }
            else
            {
                //ͼƬ���仯
                dSetSpriteScale("menusx_close",1);
            }
            //���ò˵��Ĺرհ�ť
            if(dIsPointInSprite("menusz_close",fMouseX,fMouseY))
            {
                // ͼƬ�Ŵ�
                dSetSpriteScale("menusz_close",g_otherlage);
            }
            else
            {
                //ͼƬ���仯
                dSetSpriteScale("menusz_close",1);
            }
            //���ò˵����˳���ť
            if(dIsPointInSprite("menusz_exit",fMouseX,fMouseY))
            {
                // ͼƬ�Ŵ�
                dSetSpriteScale("menusz_exit",g_buttonlage);
            }
            else
            {
                //ͼƬ���仯
                dSetSpriteScale("menusz_exit",1);
            }
            //���ò˵��ķ�����ҳ��ť
            if(dIsPointInSprite("menusz_backhome",fMouseX,fMouseY))
            {
                // ͼƬ�Ŵ�
                dSetSpriteScale("menusz_backhome",g_buttonlage);
            }
            else
            {
                //ͼƬ���仯
                dSetSpriteScale("menusz_backhome",1);
            }
            //ͼ���˵��Ĺرհ�ť
            if(dIsPointInSprite("menutj_close",fMouseX,fMouseY))
            {
                // ͼƬ�Ŵ�
                dSetSpriteScale("menutj_close",g_otherlage);
            }
            else
            {
                //ͼƬ���仯
                dSetSpriteScale("menutj_close",1);
            }
            //ͼ���˵�����һƪ��ť
            if(dIsPointInSprite("menutj_back",fMouseX,fMouseY))
            {
                // ͼƬ�Ŵ�
                dSetSpriteScale("menutj_back",g_otherlage);
            }
            else
            {
                //ͼƬ���仯
                dSetSpriteScale("menutj_back",1);
            }
            //ͼ���˵�����һƪ��ť
            if(dIsPointInSprite("menutj_next",fMouseX,fMouseY))
            {
                // ͼƬ�Ŵ�
                dSetSpriteScale("menutj_next",g_otherlage);
            }
            else
            {
                //ͼƬ���仯
                dSetSpriteScale("menutj_next",1);
            }

        }
        break;
    case 11:    //��ͼ9������ӹ�Ч��
    case 10:    //��ͼ8������ӹ�Ч��
    case 9:     //��ͼ7������ӹ�Ч��
    case 8:     //��ͼ6������ӹ�Ч��
    case 7:     //��ͼ5������ӹ�Ч��
    case 6:     //��ͼ4������ӹ�Ч��
    case 5:     //��ͼ3������ӹ�Ч��
    case 4:     //��ͼ2������ӹ�Ч��
    case 3:     //��ͼ1������ӹ�Ч��
        {
            //���ð�ť
            if(dIsPointInSprite("game1sz",fMouseX,fMouseY))
            {
                // ͼƬ�Ŵ�
                dSetSpriteScale("game1sz",g_otherlage);
            }
            else
            {
                //ͼƬ���仯
                dSetSpriteScale("game1sz",1);
            }
        }
        break;
    //TODO:
    case -2://�ؿ�1������������ӹ�Ч��
        {
            //����-�رհ�ť
            if(dIsPointInSprite("menusz_close",fMouseX,fMouseY))
            {
                // ͼƬ�Ŵ�
                dSetSpriteScale("menusz_close",g_otherlage);
            }
            else
            {
                //ͼƬ���仯
                dSetSpriteScale("menusz_close",1);
            }
            //����-���ص�ͼ��ť
            if(dIsPointInSprite("menusz_back",fMouseX,fMouseY))
            {
                // ͼƬ�Ŵ�
                dSetSpriteScale("menusz_back",g_otherlage);
            }
            else
            {
                //ͼƬ���仯
                dSetSpriteScale("menusz_back",1);
            }
            //����-�ٴ���ս��ť
            if(dIsPointInSprite("menusz_re",fMouseX,fMouseY))
            {
                // ͼƬ�Ŵ�
                dSetSpriteScale("menusz_re",g_otherlage);
            }
            else
            {
                //ͼƬ���仯
                dSetSpriteScale("menusz_re",1);
            }

            //�ٴ���ս��ť
            if(dIsPointInSprite("defeat_re",fMouseX,fMouseY))
            {
                // ͼƬ�Ŵ�
                dSetSpriteScale("defeat_re",g_otherlage);
            }
            else
            {
                //ͼƬ���仯
                dSetSpriteScale("defeat_re",1);
            }

            //���ص�ͼ��ť
            if(dIsPointInSprite("defeat_back",fMouseX,fMouseY))
            {
                // ͼƬ�Ŵ�
                dSetSpriteScale("defeat_back",g_otherlage);
            }
            else
            {
                //ͼƬ���仯
                dSetSpriteScale("defeat_back",1);
            }

            //���ص�ͼ��ť
            if(dIsPointInSprite("victory_back",fMouseX,fMouseY))
            {
                // ͼƬ�Ŵ�
                dSetSpriteScale("victory_back",g_otherlage);
            }
            else
            {
                //ͼƬ���仯
                dSetSpriteScale("victory_back",1);
            }

            //��һ�ؿ���ť
            if(dIsPointInSprite("victory_next",fMouseX,fMouseY))
            {
                // ͼƬ�Ŵ�
                dSetSpriteScale("victory_next",g_otherlage);
            }
            else
            {
                //ͼƬ���仯
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
// �����
// ���� iMouseType����갴��ֵ���� enum MouseTypes ����
// ���� fMouseX, fMouseY��Ϊ��굱ǰ����
void OnMouseClick( const int iMouseType, const float fMouseX, const float fMouseY )
{
}
//==========================================================================
//
// ��굯��
// ���� iMouseType����갴��ֵ���� enum MouseTypes ����
// ���� fMouseX, fMouseY��Ϊ��굱ǰ����
void OnMouseUp( const int iMouseType, const float fMouseX, const float fMouseY )
{
        switch(g_WhichMap)
    {
    case 1://���˵�
        {
            //�����ʼ��Ϸ
            if(dIsPointInSprite("Begin",fMouseX,fMouseY))
            {
                // ������Ч,ֻ��һ��
                M_MouseMove = dPlaySound("ClickMenu.wav",0,1*M_vol);
                //ִ�п�ʼ��Ϸ����
                //��ʼ����ͼ�˵�����
                //���е��ڼ��أ���ʾʲô����ͼ��������ʾʲô
                //��ѡ��Ϊ���¿�ʼһ������ΪĬ��ֵ
                Z_gongji = 10;
                Z_shengming = 100;
                Z_speed = 200;
                Z_fangyv = 10;
                Z_hurtID = 1/(1+(Z_fangyv/100.0)); //�������ǵļ���ϵ��
                Z_jingyan = 0;
                Z_levelMax = 30;
                Z_level = 1;
                g_Whichgame = 0;
                // ��ʼ��ͼ���˵���ʾ��ͼ��ͼ������
                g_Tujian[0] = "TJying1ImageMap";
                g_Tujian[1] = "TJying2ImageMap";
                g_Tujian[2] = "TJying3ImageMap";
                g_Tujian[3] = "TJying4ImageMap";
                g_Tujian[4] = "TJying5ImageMap";
                g_Tujian[5] = "TJying6ImageMap";
                g_Tujian[6] = "TJying7ImageMap";
                g_Tujian[7] = "TJying8ImageMap";
                g_Tujian[8] = "TJying9ImageMap";
                //�����ͼ���˵�����
                //��ʱ����������
                dLoadMap("MapMenu.t2d");
                //���µ�ͼ���
                g_WhichMap = 2;
                //��ʼ����ͼ
                g_iGameState=1;
            }

            //����ɵĻ���
            if(dIsPointInSprite("load",fMouseX,fMouseY))
            {
                // ������Ч,ֻ��һ��
                M_MouseMove = dPlaySound("ClickMenu.wav",0,1*M_vol);
                //����浵
                GameLoad();
                //�����ͼ���˵�����
                dLoadMap("MapMenu.t2d");
                //���µ�ͼ���
                g_WhichMap = 2;
                //��ʼ����ͼ
                g_iGameState=1;

            }
            //�����Ϸ����
            if(dIsPointInSprite("Intor",fMouseX,fMouseY))
            {
                // ������Ч,ֻ��һ��
                M_MouseMove = dPlaySound("ClickMenu.wav",0,1*M_vol);
                //��ťŲ��
                GameMenuGo(1);
                //����Ų����
                dSetSpritePosition("M_Intor1",225,-700.0);//��λ
                dSpriteMoveTo("M_Intor1",225,4,2*g_MenuSpeed,1);
            }
            //�����Ϸ����1�Ĺر�
            if(dIsPointInSprite("Intor1_Close",fMouseX,fMouseY))
            {
                // ������Ч,ֻ��һ��
                M_MouseMove = dPlaySound("ClickMenu.wav",0,1*M_vol);
                //����Ų��
                dSpriteMoveTo("M_Intor1",225,-700,2*g_MenuSpeed,1);
                //��ť����
                GameMenuBack(1);
            }
            //�����Ϸ����1����һҳ
            if(dIsPointInSprite("Intor_Next",fMouseX,fMouseY))
            {
                // ������Ч,ֻ��һ��
                M_MouseMove = dPlaySound("ClickMenu.wav",0,1*M_vol);
                //����1Ų��
                dSetSpritePosition("M_Intor1",225,-700.0);//˲������
                //����2Ų����
                dSetSpritePosition("M_Intor2",225,4.0);//˲�ƻ���
                // ���Ŷ���
                dSetSpriteFlipX(Z_name,0);//����תͼƬ
                dAnimateSpritePlayAnimation(Z_name,Z_stand,0);
            }
            //�����Ϸ����2�Ĺر�
            if(dIsPointInSprite("Intor2_Close",fMouseX,fMouseY))
            {
                // ������Ч,ֻ��һ��
                M_MouseMove = dPlaySound("ClickMenu.wav",0,1*M_vol);
                //����Ų��
                dSpriteMoveTo("M_Intor2",225,-700,2*g_MenuSpeed,1);
                //��ť����
                GameMenuBack(1);
            }
            //�����Ϸ����2����һҳ
            if(dIsPointInSprite("Intor_Back",fMouseX,fMouseY))
            {
                // ������Ч,ֻ��һ��
                M_MouseMove = dPlaySound("ClickMenu.wav",0,1*M_vol);
                //����2Ų��
                dSetSpritePosition("M_Intor2",225,-700.0);//˲������
                //����1Ų����
                dSetSpritePosition("M_Intor1",225,4.0);//˲�ƻ���
            }
            //���ADJK
            if(dIsPointInSprite("M_A",fMouseX,fMouseY))
            {
                // ������Ч,ֻ��һ��
                M_MouseMove = dPlaySound("ClickMenu.wav",0,0.7*M_vol);
                // �л���������
                dSetStaticSpriteImage("M_text","Main_AImageMap",0);
                // ���Ŷ���
                dAnimateSpritePlayAnimation(Z_name,"Z_run2Animation",0);
            }
            //���ADJK
            if(dIsPointInSprite("M_D",fMouseX,fMouseY))
            {
                // ������Ч,ֻ��һ��
                M_MouseMove = dPlaySound("ClickMenu.wav",0,0.7*M_vol);
                // �л���������
                dSetStaticSpriteImage("M_text","Main_DImageMap",0);
                // ���Ŷ���
                dAnimateSpritePlayAnimation(Z_name,Z_run,0);
            }
            //���ADJK
            if(dIsPointInSprite("M_J",fMouseX,fMouseY))
            {
                // ������Ч,ֻ��һ��
                M_MouseMove = dPlaySound("ClickMenu.wav",0,0.7*M_vol);
                // �л���������
                dSetStaticSpriteImage("M_text","Main_JImageMap",0);
                // ���Ŷ���
                dAnimateSpritePlayAnimation(Z_name,Z_stand,0);
                //���Ź�������
                dAnimateSpritePlayAnimation(Z_name,Z_attack,1);
                //���Ź�����Ч����
                dAnimateSpritePlayAnimation(S_pugong,Z_pugong,0);
            }
            //���ADJK
            if(dIsPointInSprite("M_K",fMouseX,fMouseY))
            {
                // ������Ч,ֻ��һ��
                M_MouseMove = dPlaySound("ClickMenu.wav",0,0.7*M_vol);
                // �л���������
                dSetStaticSpriteImage("M_text","Main_KImageMap",0);
                // ���Ŷ���
                dSetSpriteFlipX(Z_name,0);//����תͼƬ
                dAnimateSpritePlayAnimation(Z_name,Z_stand,0);
            }
            //���������Ա
            if(dIsPointInSprite("About",fMouseX,fMouseY))
            {
                // ������Ч,ֻ��һ��
                M_MouseMove = dPlaySound("ClickMenu.wav",0,1*M_vol);
                //��ťŲ��
                GameMenuGo(1);
                //������ԱŲ����
                dSetSpritePosition("M_About",225,-700.0);//��λ
                dSpriteMoveTo("M_About",225,4,2*g_MenuSpeed,1);
            }
            //���������Ա�Ĺر�
            if(dIsPointInSprite("About_Close",fMouseX,fMouseY))
            {
                // ������Ч,ֻ��һ��
                M_MouseMove = dPlaySound("ClickMenu.wav",0,1*M_vol);
                //����Ų��
                dSpriteMoveTo("M_About",225,-700,2*g_MenuSpeed,1);
                //��ť����
                GameMenuBack(1);
            }
            //����˳���Ϸ
            if(dIsPointInSprite("Exit",fMouseX,fMouseY))
            {
                // ������Ч,ֻ��һ��
                M_MouseMove = dPlaySound("ClickMenu.wav",0,1*M_vol);
                // ��Ϸ������������Ϸ���㺯����������Ϸ״̬�޸�Ϊ����״̬
                g_iGameState = 0;
                //ֹͣ����
                dStopSound(M_BGMXWX);
                exit(0);
            }

        }
        break;
    case 2:// map�˵�
        {
            //game1�Զ�����������
            if(dIsPointInSprite("game1",fMouseX,fMouseY))
            {
                // ������Ч,ֻ��һ��
                M_MouseMove = dPlaySound("ClickMenu.wav",0,1*M_vol);
                //���ص�ͼ
                dLoadMap("Game1.t2d");
                //���µ�ͼ���
                g_WhichMap = 3;
                //��ʼ����ͼ
                g_iGameState=1;
            }
            //���game2��Ӧ
            if(dIsPointInSprite("game2",fMouseX,fMouseY))
            {
                if(g_Whichgame < 1)//����һ��δͨ�������õ����Ӧ
                    break;
                // ������Ч,ֻ��һ��
                M_MouseMove = dPlaySound("ClickMenu.wav",0,1*M_vol);
                //���ص�ͼ
                dLoadMap("Game2.t2d");
                //���µ�ͼ���
                g_WhichMap = 4;
                //��ʼ����ͼ
                g_iGameState=1;
            }
            //���game3��Ӧ
            if(dIsPointInSprite("game3",fMouseX,fMouseY))
            {
                if(g_Whichgame < 2)//���ڶ���δͨ�������õ����Ӧ
                    break;
                // ������Ч,ֻ��һ��
                M_MouseMove = dPlaySound("ClickMenu.wav",0,1*M_vol);
                //���ص�ͼ
                dLoadMap("Game3.t2d");
                //���µ�ͼ���
                g_WhichMap = 5;
                //��ʼ����ͼ
                g_iGameState=1;
            }
            //���game4��Ӧ
            if(dIsPointInSprite("game4",fMouseX,fMouseY))
            {
                if(g_Whichgame < 3)//��������δͨ�������õ����Ӧ
                    break;
                // ������Ч,ֻ��һ��
                M_MouseMove = dPlaySound("ClickMenu.wav",0,1*M_vol);
                //���ص�ͼ
                dLoadMap("Game4.t2d");
                //���µ�ͼ���
                g_WhichMap = 6;
                //��ʼ����ͼ
                g_iGameState=1;
            }
            //���game5��Ӧ
            if(dIsPointInSprite("game5",fMouseX,fMouseY))
            {
                if(g_Whichgame < 4)//�����Ĺ�δͨ�������õ����Ӧ
                    break;
                // ������Ч,ֻ��һ��
                M_MouseMove = dPlaySound("ClickMenu.wav",0,1*M_vol);
                //���ص�ͼ
                dLoadMap("Game5.t2d");
                //���µ�ͼ���
                g_WhichMap = 7;
                //��ʼ����ͼ
                g_iGameState=1;
            }
            //���game6��Ӧ
            if(dIsPointInSprite("game6",fMouseX,fMouseY))
            {
                if(g_Whichgame < 5)//�������δͨ�������õ����Ӧ
                    break;
                // ������Ч,ֻ��һ��
                M_MouseMove = dPlaySound("ClickMenu.wav",0,1*M_vol);
                //���ص�ͼ
                dLoadMap("Game6.t2d");
                //���µ�ͼ���
                g_WhichMap = 8;
                //��ʼ����ͼ
                g_iGameState=1;
            }
            //���game7��Ӧ
            if(dIsPointInSprite("game7",fMouseX,fMouseY))
            {
                if(g_Whichgame < 6)//��������δͨ�������õ����Ӧ
                    break;
                // ������Ч,ֻ��һ��
                M_MouseMove = dPlaySound("ClickMenu.wav",0,1*M_vol);
                //���ص�ͼ
                dLoadMap("Game7.t2d");
                //���µ�ͼ���
                g_WhichMap = 9;
                //��ʼ����ͼ
                g_iGameState=1;
            }
            //���game8��Ӧ
            if(dIsPointInSprite("game8",fMouseX,fMouseY))
            {
                if(g_Whichgame < 7)//�����߹�δͨ�������õ����Ӧ
                    break;
                // ������Ч,ֻ��һ��
                M_MouseMove = dPlaySound("ClickMenu.wav",0,1*M_vol);
                //���ص�ͼ
                dLoadMap("Game8.t2d");
                //���µ�ͼ���
                g_WhichMap = 10;
                //��ʼ����ͼ
                g_iGameState=1;
            }
            //���game9��Ӧ
            if(dIsPointInSprite("game9",fMouseX,fMouseY))
            {
                if(g_Whichgame < 8)//���ڰ˹�δͨ�������õ����Ӧ
                    break;
                // ������Ч,ֻ��һ��
                M_MouseMove = dPlaySound("ClickMenu.wav",0,1*M_vol);
                //���ص�ͼ
                dLoadMap("Game9.t2d");
                //���µ�ͼ���
                g_WhichMap = 11;
                //��ʼ����ͼ
                g_iGameState=1;
            }
//////////////////////////////////////////////////////////////////////

            //������԰�ť
            if(dIsPointInSprite("buttonsx",fMouseX,fMouseY))
            {
                // ������Ч,ֻ��һ��
                M_MouseMove = dPlaySound("ClickMenu.wav",0,1*M_vol);
                //ִ���ƶ�ͼ�꺯��
                GameMenuGo(2);
                //�������Բ˵�
                dSpriteMoveTo("menusx",0,0,3*g_MenuSpeed,1);
                //���µ�ͼ���
                g_WhichMap = -1;
            }
            //���ͼ����ť
            if(dIsPointInSprite("buttontj",fMouseX,fMouseY))
            {
                // ������Ч,ֻ��һ��
                M_MouseMove = dPlaySound("ClickMenu.wav",0,1*M_vol);
                //ʼ�մӵ�һ��ͼ����ʼ��ʾ
                g_WhichTj = 0;
                dSetStaticSpriteImage("menutj_text",g_Tujian[g_WhichTj],0);
                //����ͼ���˵�����һ����ť
                dSetSpriteVisible("menutj_back",0);
                //��ʾͼ������һ����ť
                dSetSpriteVisible("menutj_next",1);
                //ִ���ƶ�ͼ�꺯��
                GameMenuGo(2);
                //�������Բ˵�
                dSpriteMoveTo("menutj",0,0,3*g_MenuSpeed,1);
                //���µ�ͼ���
                g_WhichMap = -1;
            }
            //������ð�ť
            if(dIsPointInSprite("buttonsz",fMouseX,fMouseY))
            {
                // ������Ч,ֻ��һ��
                M_MouseMove = dPlaySound("ClickMenu.wav",0,1*M_vol);
                //ִ���ƶ�ͼ�꺯��
                GameMenuGo(2);
                //�������ò˵�
                dSpriteMoveTo("menusz",0,0,3*g_MenuSpeed,1);
                //���µ�ͼ���
                g_WhichMap = -1;
            }
        }
        break;
    case -1://��ͼ�˵�����ĵ�������
        {
            //�������-�رհ�ť
            if(dIsPointInSprite("menusx_close",fMouseX,fMouseY))
            {
                // ������Ч,ֻ��һ��
                M_MouseMove = dPlaySound("ClickMenu.wav",0,1*M_vol);
                //ִ���ƶ�ͼ�꺯��
                GameMenuBack(2);
                //�������Բ˵�
                dSpriteMoveTo("menusx",0,-768,3*g_MenuSpeed,1);
                //���µ�ͼ���
                g_WhichMap = 2;
            }
            //���ͼ��-�رհ�ť
            if(dIsPointInSprite("menutj_close",fMouseX,fMouseY))
            {
                // ������Ч,ֻ��һ��
                M_MouseMove = dPlaySound("ClickMenu.wav",0,1*M_vol);
                //ִ���ƶ�ͼ�꺯��
                GameMenuBack(2);
                //�������Բ˵�
                dSpriteMoveTo("menutj",0,-768,3*g_MenuSpeed,1);
                //���µ�ͼ���
                g_WhichMap = 2;
            }
            //���ͼ��-��һƪ��ť
            if(dIsPointInSprite("menutj_back",fMouseX,fMouseY))
            {
                if(g_WhichTj==0)//��ʾ��һ��ʱ���ô˰�ť
                    break;
                else{
                    // ������Ч,ֻ��һ��
                    M_MouseMove = dPlaySound("ClickMenu.wav",0,1*M_vol);
                    //����ǰ��ʾ������ͼƬ-1
                    g_WhichTj--;
                    if(g_WhichTj==0)//�����ʾ��һ��ͼƬ
                    {
                        //������һ�Ű�ť
                        dSetSpriteVisible("menutj_back",0);
                    }
                    //��ʾ��һ�Ű�ť
                    dSetSpriteVisible("menutj_next",1);
                    //������ʾ����ͼƬ
                    dSetStaticSpriteImage("menutj_text",g_Tujian[g_WhichTj],0);
                }
            }
            //���ͼ��-��һƪ��ť
            if(dIsPointInSprite("menutj_next",fMouseX,fMouseY))
            {
                if(g_WhichTj==8)//��ʾ�ھ���ʱ���ô˰�ť
                    break;
                else{
                    // ������Ч,ֻ��һ��
                    M_MouseMove = dPlaySound("ClickMenu.wav",0,1*M_vol);
                    //����ǰ��ʾ������ͼƬ+1
                    g_WhichTj++;
                    if(g_WhichTj==8)//�����ʾ�ھ���ͼƬ
                    {
                        //������һ�Ű�ť
                        dSetSpriteVisible("menutj_next",0);
                    }
                    //��ʾ��һ�Ű�ť
                    dSetSpriteVisible("menutj_back",1);
                    //������ʾ����ͼƬ
                    dSetStaticSpriteImage("menutj_text",g_Tujian[g_WhichTj],0);
                }

            }
            //�������-�رհ�ť
            if(dIsPointInSprite("menusz_close",fMouseX,fMouseY))
            {
                // ������Ч,ֻ��һ��
                M_MouseMove = dPlaySound("ClickMenu.wav",0,1*M_vol);
                //ִ���ƶ�ͼ�꺯��
                GameMenuBack(2);
                //�������Բ˵�
                dSpriteMoveTo("menusz",0,-768,3*g_MenuSpeed,1);
                //���µ�ͼ���
                g_WhichMap = 2;
            }
            //�������-������ҳ��ť
            if(dIsPointInSprite("menusz_backhome",fMouseX,fMouseY))
            {
                // ������Ч,ֻ��һ��
                M_MouseMove = dPlaySound("ClickMenu.wav",0,1*M_vol);
                //���ص�ͼ
                dLoadMap("MainMenu.t2d");
                //���µ�ͼ���
                g_WhichMap = 1;
                //��ʼ��
                g_iGameState = 1;
            }
            //�������-�˳���ť
            if(dIsPointInSprite("menusz_exit",fMouseX,fMouseY))
            {
                // ������Ч,ֻ��һ��
                M_MouseMove = dPlaySound("ClickMenu.wav",0,1*M_vol);
                // ��Ϸ������������Ϸ���㺯����������Ϸ״̬�޸�Ϊ����״̬
                g_iGameState = 0;
                //ֹͣ����
                dStopSound(M_BGMXWX);
                exit(0);
            }
        }
        break;
    case 11://�ؿ�9����
    case 10://�ؿ�8����
    case 9://�ؿ�7����
    case 8://�ؿ�6����
    case 7://�ؿ�5����
    case 6://�ؿ�4����
    case 5://�ؿ�3����
    case 4://�ؿ�2����
    case 3://�ؿ�1����
        {
            //������ð�ť
            if(dIsPointInSprite("game1sz",fMouseX,fMouseY))
            {
                // ������Ч,ֻ��һ��
                M_MouseMove = dPlaySound("ClickMenu.wav",0,1*M_vol);
                //�������ò˵�
                dSpriteMoveTo("menusz",0,0,3*g_MenuSpeed,1);
                //���µ�ͼ���
                g_WhichMap = -2;
                //��Ϸ��ͣ
                //
            }
        }
        break;
    case -2://�ؿ�һ�ĵ�������
        {
            //�������-�رհ�ť
            if(dIsPointInSprite("menusz_close",fMouseX,fMouseY))
            {
                // ������Ч,ֻ��һ��
                M_MouseMove = dPlaySound("ClickMenu.wav",0,1*M_vol);
                //�����ò˵�Ų��ȥ
                dSpriteMoveTo("menusz",0,-768,3*g_MenuSpeed,1);
                //���µ�ͼ���,���Ϊԭ��ͼ
                g_WhichMap = g_WhichGq + 2;
            }
            //�������-���ز˵���ť
            if(dIsPointInSprite("menusz_back",fMouseX,fMouseY))
            {
                // ������Ч,ֻ��һ��
                M_MouseMove = dPlaySound("ClickMenu.wav",0,1*M_vol);
                //���ص�ͼ
                dLoadMap("MapMenu.t2d");
                //���µ�ͼ���
                g_WhichMap = 2;
                //��ʼ����ͼ
                g_iGameState = 1;
            }
            //�������-�ٴ���ս��ť
            if(dIsPointInSprite("menusz_re",fMouseX,fMouseY))
            {
                // ������Ч,ֻ��һ��
                M_MouseMove = dPlaySound("ClickMenu.wav",0,1*M_vol);
                //���ص�ͼ
                dLoadMap(g_Gqname[g_WhichGq-1]);
                //���µ�ͼ���,���Ϊԭ��ͼ
                g_WhichMap = g_WhichGq + 2;
                //��ʼ����ͼ
                g_iGameState = 1;
            }
            //���ʧ�ܽ���-���ز˵���ť
            if(dIsPointInSprite("defeat_back",fMouseX,fMouseY))
            {
                // ������Ч,ֻ��һ��
                M_MouseMove = dPlaySound("ClickMenu.wav",0,1*M_vol);
                //���ص�ͼ
                dLoadMap("MapMenu.t2d");
                //���µ�ͼ���
                g_WhichMap = 2;
                //��ʼ����ͼ
                g_iGameState = 1;
            }
            //���ʧ�ܽ���-�ٴ���ս��ť
            if(dIsPointInSprite("defeat_re",fMouseX,fMouseY))
            {
                // ������Ч,ֻ��һ��
                M_MouseMove = dPlaySound("ClickMenu.wav",0,1*M_vol);
                //���ص�ͼ
                dLoadMap(g_Gqname[g_WhichGq-1]);
                //���µ�ͼ���,���Ϊԭ��ͼ
                g_WhichMap = g_WhichGq + 2;
                //��ʼ����ͼ
                g_iGameState = 1;
            }

             //����ɹ�����-���ز˵���ť
            if(dIsPointInSprite("victory_back",fMouseX,fMouseY))
            {
                // ������Ч,ֻ��һ��
                M_MouseMove = dPlaySound("ClickMenu.wav",0,1*M_vol);
                //���ص�ͼ
                dLoadMap("MapMenu.t2d");
                //���µ�ͼ���
                g_WhichMap = 2;
                //��ʼ����ͼ
                g_iGameState = 1;
            }
            //�����һ�ؿ���ť
            if(dIsPointInSprite("victory_next",fMouseX,fMouseY))
            {
                // ������Ч,ֻ��һ��
                M_MouseMove = dPlaySound("ClickMenu.wav",0,1*M_vol);
                //���ص�ͼ
                dLoadMap(g_Gqname[g_WhichGq]);
                //���µ�ͼ���,���Ϊԭ��ͼ
                g_WhichMap = g_WhichGq + 3;
                //��ʼ����ͼ
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
// ���̰���
// ���� iKey�������µļ���ֵ�� enum KeyCodes �궨��
// ���� iAltPress, iShiftPress��iCtrlPress�������ϵĹ��ܼ�Alt��Ctrl��Shift��ǰ�Ƿ�Ҳ���ڰ���״̬(0δ���£�1����)
void OnKeyDown( const int iKey, const bool bAltPress, const bool bShiftPress, const bool bCtrlPress )
{
    //���ǻ�Boss���������������ƶ�
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
            //��D������ʱ��IsD��Ϊ1
            g_IsD = 1;
            dAnimateSpritePlayAnimation(Z_name,Z_run,0);//���ǿ�ʼ����ǰ������ǰ��
            dSetSpriteFlipX(Z_name,0);//����תͼƬ
            //��¼��ǰ���ǳ���
            Z_top = 'D';
        }
        break;
    case KEY_A://����
        {
            //��A������ʱ��IsA��Ϊ1
            g_IsA = 1;
            dAnimateSpritePlayAnimation(Z_name,Z_run,0);
            dSetSpriteFlipX(Z_name,1);//��תͼƬ
            //��¼��ǰ���ǳ���
            Z_top = 'A';
        }
        break;
    case KEY_K://��Ծ
        {
            // ��Z_jumpΪ1ʱ�ſ���������
            if(Z_jump == 1)
            {
                //dSpriteMoveTo(Z_name,dGetSpritePositionX(Z_name)+dGetSpriteLinearVelocityX(Z_name),dGetSpritePositionY(Z_name)-120,160,1);
                dSetSpriteImpulseForce(Z_name,0,Z_jumphigh,0);//������һ��Y�����˲ʱ��
                Z_jump = 0;
                // ������Ծ��Ч
                M_Jump = dPlaySound("Z_Jump.wav",0,1*M_vol);
            }
        }
        break;
    case KEY_J://����
        {
            if(Z_IsPugong ==1 )//�鿴�Ƿ�����չ�
            {
                //���Ź�������
                dAnimateSpritePlayAnimation(Z_name,Z_attack,1);
                //���Ź�����Ч����
                dAnimateSpritePlayAnimation(S_pugong,Z_pugong,0);
                //�����չ�
                Z_IsPugong = 0;
                //��ʼ��ȴ
                Z_attackTime = 0;
                //�����չ���Ч
                M_Attack = dPlaySound("Z_Attack.wav",0,1*M_vol);
            }
        }
        break;
    case KEY_U:
        {
            //�������ļ���δ����ʱ������U
            if(Z_IsSkill[0] == 1&& g_IsO==0 && g_IsL==0)
            {
                //��������
                SendSkill('U');
            }
        }
        break;
    case KEY_I:
        {
            if(Z_IsSkill[1] == 1)
            {
                //��������
                SendSkill('I');
            }
        }
        break;
    case KEY_O:
        {
             //��һ���ļ���δ����ʱ������O
            if(Z_IsSkill[2] == 1 && g_IsU==0 && g_IsL==0)
            {
                //��������
                SendSkill('O');
            }
        }
        break;
    case KEY_L:
        {
            //��һ��������δ����ʱ������L
            if(Z_IsSkill[3] == 1 && g_IsU==0 && g_IsO==0)
            {
                //��������
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
// ���̵���
// ���� iKey������ļ���ֵ�� enum KeyCodes �궨��
void OnKeyUp( const int iKey )
{
    //���ǻ�Boss���������������ƶ�
    if(Z_blood<=0||B_Blood<=0||g_WhichMap<0)
    {
        g_IsA = 0;
        g_IsD = 0;
        dSetSpriteLinearVelocityX(Z_name,0);
        if(Z_blood > 0)
        {
            dAnimateSpritePlayAnimation(Z_name,Z_stand,0);//���ž�ֹ����
        }
        return;
    }
    else
    {
	switch(iKey)
	{
    case KEY_D://ǰ��
        {
            dSetSpriteLinearVelocity("game1Bg1",0,0);//D�������ͼ������ֹ
            // ��D����ʱ����¼��Dδ������
            g_IsD =0;
            // ��A��Ҳ��������ֹͣ
            if(g_IsA==0)
            {
                dSetSpriteLinearVelocityX(Z_name,0);
                //�ı䵱ǰ��ʾ��ͼƬ������Ӧ����ֹ����Ӧ����ȷ
                dAnimateSpritePlayAnimation(Z_name,Z_stand,0);//���ž�ֹ����
                dSetSpriteFlipX(Z_name,0);
                //��¼��ǰ���ǳ���
                Z_top = 'D';
            }
            else if(g_IsA==1)//��Aû�е���
            {
                dAnimateSpritePlayAnimation(Z_name,Z_run,0);
                dSetSpriteFlipX(Z_name,1);//��תͼƬ
                //��¼��ǰ���ǳ���
                Z_top = 'A';
            }
        }
        break;
    case KEY_A://����
        {
            // ��A����ʱ����¼��Aδ������
            g_IsA =0;
            // ��D��Ҳ��������ֹͣ
            if(g_IsD==0)
            {
                dSetSpriteLinearVelocityX(Z_name,0);
                //�ı䵱ǰ��ʾ��ͼƬ������Ӧ����ֹ����Ӧ����ȷ
                dAnimateSpritePlayAnimation(Z_name,Z_stand,0);//���ž�ֹ����
                dSetSpriteFlipX(Z_name,1);
                //��¼��ǰ���ǳ���
                Z_top = 'A';
            }
            else if(g_IsD==1)//��Dû�е���
            {
                dAnimateSpritePlayAnimation(Z_name,Z_run,0);//���ǿ�ʼ����ǰ������ǰ��
                dSetSpriteFlipX(Z_name,0);//����תͼƬ
                //��¼��ǰ���ǳ���
                Z_top = 'D';
            }
        }
        break;
	}
    }
}
//===========================================================================
//
// �����뾫����ײ
// ���� szSrcName��������ײ�ľ�������
// ���� szTarName������ײ�ľ�������
void OnSpriteColSprite( const char *szSrcName, const char *szTarName )
{
    //��������չ���С����ײ
    if(strcmp(szSrcName,S_pugong)==0&&strncmp(szTarName,"xiaobing",7)==0)
    {
        //С���ܵ�һ��˲ʱ��������
        //GameXbBack(szTarName,Z_top);
        //С��Ѫ�����ٲ���ʾ
        GameXbHurt(szTarName,Z_gongji);

    }

    //������＼��1��С����ײ
    if(strcmp(szSrcName,"CsendSkill1")==0&&strncmp(szTarName,"xiaobing",7)==0)
    {
        //С���ܵ�һ��˲ʱ��������
        //GameXbBack(szTarName,Z_top);//ȡ������ܻ�����
        //С��Ѫ�����ٲ���ʾ
        GameXbHurt(szTarName,2*Z_gongji);

    }
    //������＼��3��С����ײ
    if(strcmp(szSrcName,"CsendSkill3")==0&&strncmp(szTarName,"xiaobing",7)==0)
    {
        //С���ܵ�һ��˲ʱ��������
        //GameXbBack(szTarName,Z_top);//ȡ������ܻ�����
        //С��Ѫ�����ٲ���ʾ
        GameXbHurt(szTarName,2.2*Z_gongji);

    }
    //������＼��4��С����ײ
    if(strcmp(szSrcName,"CsendSkill4")==0&&strncmp(szTarName,"xiaobing",7)==0)
    {
        //С���ܵ�һ��˲ʱ��������
        //GameXbBack(szTarName,Z_top);//ȡ������ܻ�����
        //С��Ѫ�����ٲ���ʾ
        GameXbHurt(szTarName,3.2*Z_gongji);

    }

    //������ؼ�����������ײ
    if(strcmp(szTarName,Z_name)==0&&strncmp(szSrcName,"XB_attack",8)==0)
    {
        //���ǿ�Ѫ���������ؼ���������
        SubBlood(10+ g_WhichGq * 10);

    }
    //���С��������������ײ
    if(strcmp(szTarName,Z_name)==0&&strncmp(szSrcName,"CXB_Skill1",8)==0)
    {
        //С�������˺�,�˺����Է���ϵ��
        SubBlood(O_hurt[g_WhichMap-3] * Z_hurtID + (rand()%5-2));

    }
        //��������չ���Boss��ײ
    if(strcmp(szSrcName,S_pugong)==0&&strcmp(szTarName,"Boss1")==0)
    {
        //BossѪ�����ٲ���ʾ
        BossHurt(Z_gongji);

    }

    //������＼��1��Boss��ײ
    if(strcmp(szSrcName,"CsendSkill1")==0&&strcmp(szTarName,"Boss1")==0)
    {
        //BossѪ�����ٲ���ʾ
        BossHurt(2*Z_gongji);
    }
     //������＼��3��Boss��ײ
    if(strcmp(szSrcName,"CsendSkill3")==0&&strcmp(szTarName,"Boss1")==0)
    {
        //BossѪ�����ٲ���ʾ
        BossHurt(1.8*Z_gongji);
    }
     //������＼��4��Boss��ײ
    if(strcmp(szSrcName,"CsendSkill4")==0&&strcmp(szTarName,"Boss1")==0)
    {
        //BossѪ�����ٲ���ʾ
        BossHurt(3.2*Z_gongji);
    }

    //���Boss������������ײ
    if(strcmp(szTarName,Z_name)==0&&strncmp(szSrcName,"CBoss_Skill",10)==0)
    {
        //Boss�˺�=�˺����Է���ϵ��
        SubBlood(O_hurt[g_WhichMap-3] * Z_hurtID * 2 + (rand()%10-4));
    }

}
//===========================================================================
//
// ����������߽���ײ
// ���� szName����ײ���߽�ľ�������
// ���� iColSide����ײ���ı߽� 0 ��ߣ�1 �ұߣ�2 �ϱߣ�3 �±�
void OnSpriteColWorldLimit( const char *szName, const int iColSide )
{
    //��������غ����������Ծ
    if(strcmp(szName,Z_name)==0&&iColSide==3)
    {
        Z_jump = 1;
    }
    //����������߽���ײ����������������ұ߽磬���ж��Ƿ�����ƶ���ͼ
    if(strcmp(szName,Z_name)==0&&iColSide==1)
    {
        if(g_qianjin == 1)//��g_qianjinΪ1ʱ��С��ȫ����ɱ������ͼ����ǰ��
        {
            dSetSpriteImmovable(g_mapname[g_WhichMap],0);
        }
    }

}

//===========================================================================
//
// ����Ļ�еİ�ť����ƶ�����Ļ��
// ����WhichMenu��ָ�����еĽ���wellcomeΪ0��mainmenuΪ1��mapmenuΪ2��
void GameMenuGo(int WhichMenu)
{
    switch(WhichMenu)
    {
    case 0:// wellcome����
        break;
    case 1:// MainMenu����
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
    case 2:// MapMenu����
        {
            // dSpriteMoveTo���þ��鰴�ո����ٶ��ƶ������������
            // ���� szName����������
            // ���� fPosX���ƶ���Ŀ��X����ֵ
            // ���� fPosY���ƶ���Ŀ��Y����ֵ
            // ���� fSpeed���ƶ��ٶ�
            // ���� iAutoStop���ƶ����յ�֮���Ƿ��Զ�ֹͣ, 1 ֹͣ 0 ��ֹͣ
            dSpriteMoveTo("buttonsx",300,500,g_MenuSpeed,1);    //����300,300 => 300,500
            dSpriteMoveTo("buttontj",415,500,g_MenuSpeed,1);    //ͼ��415,300 => 415,500
            dSpriteMoveTo("buttonsz",530,500,g_MenuSpeed,1);    //����530,300 => 530,500
            dSpriteMoveTo("menurw",-420,-470,g_MenuSpeed,1);    //�����-420,-270 => -420,-470
        }
        break;
    default:
        {

        }
        break;
    }
}

//����Ļ��İ�ť����ƻ���
// ����WhichMenu��ָ�����еĽ���wellcomeΪ0��mainmenuΪ1��mapmenuΪ2��
void GameMenuBack(int WhichMenu)
{
    switch(WhichMenu)
    {
    case 0:// wellcome����
        break;
    case 1:// MainMenu����
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
    case 2:// MapMenu����
        {
            // dSpriteMoveTo���þ��鰴�ո����ٶ��ƶ������������
            // ���� szName����������
            // ���� fPosX���ƶ���Ŀ��X����ֵ
            // ���� fPosY���ƶ���Ŀ��Y����ֵ
            // ���� fSpeed���ƶ��ٶ�
            // ���� iAutoStop���ƶ����յ�֮���Ƿ��Զ�ֹͣ, 1 ֹͣ 0 ��ֹͣ
            dSpriteMoveTo("buttonsx",300,300,g_MenuSpeed,1);    //����300,500 => 300,300
            dSpriteMoveTo("buttontj",415,300,g_MenuSpeed,1);    //ͼ��415,500 => 415,300
            dSpriteMoveTo("buttonsz",530,300,g_MenuSpeed,1);    //����530,500 => 530,300
            dSpriteMoveTo("menurw",-420,-270,g_MenuSpeed,1);    //�����-420,-470 => -420,-270
        }
        break;
    default:
        {

        }
        break;
    }
}

//��ͼ���˵���ʼ��
// ����WhichMap��ָ����ϷĿǰ���е��ڼ����˸տ�ʼΪ0����ͨgame1Ϊ1����ͨgame2Ϊ2��
void GameTjInit(int WhichMap)
{
    //��ͼ���˵��İ�ť���г�ʼ��
    //����ͼ���˵��ĵ�һ����ť
    dSetSpriteVisible("menutj_back",0);
    //�޸�������ʾ����
    //�޸ĵ�ͼ��ʾ
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
    //������ʾ����ͼƬ
    dSetStaticSpriteImage("menutj_text",g_Tujian[g_WhichTj],0);
}

// ShowShuxing����ʾ��������
void ShowShuxing(const char *szName,const int num)
{
    //������������������������������ٵ���ֵ
    int numB,numS,numG;
    char *sxName[]={dMakeSpriteName(szName,1),dMakeSpriteName(szName,2),dMakeSpriteName(szName,3)};
    numB = num/100;
    numS = num/10%10;
    numG = num%10;
    switch(numB)
    {
    case 0://������С��3λ
        dSetStaticSpriteFrame(sxName[2],11);
        if(numS == 0)//Ϊһλ��ʱ
        {
            dSetStaticSpriteFrame(sxName[1],11);
            dSetStaticSpriteFrame(sxName[0],numG);
        }
        else//Ϊ��λ��ʱ
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

//����Ϸ�浵
void GameSave(void)
{
    FILE *g_Save; //�����ļ�ָ��
    if((g_Save = freopen("save.txt","wt+",stdout)) != NULL)
    {
        //�浵
        printf("g_Whichgame:%d\nZ_gongji:%d\nZ_fangyv:%d\nZ_shengming:%d\nZ_jingyan:%d\nZ_levelmax:%d\nZ_speed:%d\nZ_level:%d\n",
               g_Whichgame,Z_gongji,Z_fangyv,Z_shengming,Z_jingyan,Z_levelMax,Z_speed,Z_level);
        fclose(g_Save);     //�ر��ļ�
    }
}

//��ȡ��Ϸ�浵
void GameLoad(void)
{
    FILE *g_Load; //�����ļ�ָ��
    if((g_Load = fopen("save.txt","r")) != NULL)
    {
        fscanf(g_Load,"%*[^:]:%d\n%*[^:]:%d\n%*[^:]:%d\n%*[^:]:%d\n%*[^:]:%d\n%*[^:]:%d\n%*[^:]:%d\n%*[^:]:%d\n",
               &g_Whichgame,&Z_gongji,&Z_fangyv,&Z_shengming,&Z_jingyan,&Z_levelMax,&Z_speed,&Z_level);
        fclose(g_Load);     //�ر��ļ�
    }
}

//��¡С��
void GameClone(void)
{
    //ʹ��forѭ����¡6��С��
    int i;
    for(i=1;i<=3;i++)
    {
        //ʹ��xg_1��Ϊģ���¡3������Ϊxiaobing1~3
        dCloneSprite("xg_1",dMakeSpriteName("xiaobing",i));
        //������λ��
        dSetSpritePosition(dMakeSpriteName("xiaobing",i),400-60*i,-130);
        //��¡Ѫ��
        dCloneSprite("XT_blood",dMakeSpriteName("XT_blood",i));
        //��¡Ѫ��
        //dCloneSprite("XG_bloodbar",dMakeSpriteName("XG_bloodbar",i));
        //��Ѫ�� 20210609
        dSpriteMountToSprite(dMakeSpriteName("XT_blood",i),dMakeSpriteName("xiaobing",i),0,-1.4);
        //dSpriteMountToSprite(dMakeSpriteName("XG_bloodbar",i),dMakeSpriteName("xiaobing",i),0,-1.4);
        //��¡��Ϻ���������صǳ�
        //��������
        dSetSpriteConstantForce(dMakeSpriteName("xiaobing",i),0,1000000,0);
        //����С�ֵ�Ѫ��
        O_bloodMax = 100 *(g_WhichMap-2);
        O_blood[i-1]=O_bloodMax;
        //����С��δ����ײ
        O_IsPengzhuang[i-1]=1;
        //��Ϊ���Է�������
        O_IsSkill[i-1] =1;
    }
    for(i=4;i<=6;i++)
    {
        //ʹ��xg_1��Ϊģ���¡3������Ϊxiaobing4~6
        dCloneSprite("xg_2",dMakeSpriteName("xiaobing",i));
        //������λ��
        dSetSpritePosition(dMakeSpriteName("xiaobing",i),-400+60*(i-3),-130);
        //��¡Ѫ��
        dCloneSprite("XT_blood",dMakeSpriteName("XT_blood",i));
        //��¡Ѫ��
        //dCloneSprite("XG_bloodbar",dMakeSpriteName("XG_bloodbar",i));
        //��Ѫ�� 20210609
        dSpriteMountToSprite(dMakeSpriteName("XT_blood",i),dMakeSpriteName("xiaobing",i),0,-1.4);
        //dSpriteMountToSprite(dMakeSpriteName("XG_bloodbar",i),dMakeSpriteName("xiaobing",i),0,-1.4);
        //��¡��Ϻ���������صǳ�
        //��������
        dSetSpriteConstantForce(dMakeSpriteName("xiaobing",i),0,1000000,0);
        //����С�ֵ�Ѫ��
        O_bloodMax = 100 *(g_WhichMap-2);
        O_blood[i-1]=O_bloodMax;
        //����С��δ����ײ
        O_IsPengzhuang[i-1]=1;
        //��Ϊ���Է�������
        O_IsSkill[i-1] =1;
    }
    //��¡��Ϻ󣬽�����С������Ϊ6
    g_xbNum=6;
    //��¡��Ϻ󣬳��ϴ���С������ͼ�����ƶ�
    g_qianjin = 0;
    //��¡��Ϻ���С���ƶ�ѭ������
    g_re =0;
    //��ʼ��С������
    //��O_attackTime����
    O_attackTime = 0;
    //���Ϊδ����
    O_isattack = 0;

}

// С���ƶ�����
// ���С����������̫Զ��С�������˶�
// ��С���������ǴﵽXXXʱ��С�������������ƶ������ټӿ졣
// PosX�����ǵ�X����
void GameXbMove(const float PosX)
{
    int i,Num_Sj;
    float PosX_xb;//����һ��������¼С����ǰ����
    int View_xb=350;//����С������Ұ������������Ұ�⣬С��������������ƶ�
    //С�����ѭ���ƶ�
    for(i=1;i<=6;i++,g_re++)
    {
        PosX_xb = dGetSpritePositionX(dMakeSpriteName("xiaobing",i));//���С����ǰ����
        //�����Ǵ���С����Ұ��ʱ(��С�������Ǽ�����200)
        if(abs(PosX-PosX_xb)>=View_xb&&g_re<6)
        {
            //С����������ƶ�
            //srand((unsigned)time(NULL));//Ϊ���������
            Num_Sj = rand()%2;//�������0-1
            //�ж����ĸ���ͼ��С��
            switch(g_WhichGq)
            {
            case 1://�ؿ�1
            case 6://�ؿ�6��С��������
                {
                    dSetSpriteFlipX(dMakeSpriteName("xiaobing",i),Num_Sj);
                    dSetSpriteLinearVelocityX(dMakeSpriteName("xiaobing",i),O_speed-Num_Sj*O_speed*2);//����С���ٶ�
                    break;
                }
            case 2://�ؿ�2��С������
            case 3://�ؿ�3��С������
            case 4://�ؿ�4��С������
            case 5://�ؿ�5��С������
            case 7://�ؿ�7��С������
            case 8://�ؿ�8��С������
            case 9://�ؿ�9��С������
                {
                    dSetSpriteFlipX(dMakeSpriteName("xiaobing",i),Num_Sj);
                    dSetSpriteLinearVelocityX(dMakeSpriteName("xiaobing",i),-O_speed+Num_Sj*O_speed*2);//����С���ٶ�
                    break;
                }
            }
        }
        if(g_re>12345)
        {
            g_re = -1;//g_re�������㣬�ٴο�ʼ����ƶ�
            i=0;
        }
    }
    for(i=1;i<=6;i++)
    {
        PosX_xb = dGetSpritePositionX(dMakeSpriteName("xiaobing",i));//���С����ǰ����
        //��С��һ���������ƶ����ٶ�
        if(PosX-50>PosX_xb&&abs(PosX-PosX_xb)<View_xb)//������С��ǰ��,������Ұ��
        {
            switch(g_WhichGq)
            {
            case 1://�ؿ�1
            case 6://�ؿ�6��С��������
                {
                    dSetSpriteFlipX(dMakeSpriteName("xiaobing",i),0);//��ת��
                    dSetSpriteLinearVelocityX(dMakeSpriteName("xiaobing",i),O_Sspeed);//����С���ٶ�
                    break;
                }
            case 2://�ؿ�2��С������
            case 3://�ؿ�3��С������
            case 4://�ؿ�4��С������
            case 5://�ؿ�5��С������
            case 7://�ؿ�7��С������
            case 8://�ؿ�8��С������
            case 9://�ؿ�9��С������
                {
                    dSetSpriteFlipX(dMakeSpriteName("xiaobing",i),1);//ת��
                    dSetSpriteLinearVelocityX(dMakeSpriteName("xiaobing",i),O_Sspeed);//����С���ٶ�
                    break;
                }
            }
        }
        else if(PosX+50<PosX_xb&&abs(PosX-PosX_xb)<View_xb)//������С���󷽣�������Ұ��
        {
            switch(g_WhichGq)
            {
            case 1://�ؿ�1
            case 6://�ؿ�6��С��������
                {
                    dSetSpriteFlipX(dMakeSpriteName("xiaobing",i),1);//ת��
                    dSetSpriteLinearVelocityX(dMakeSpriteName("xiaobing",i),-O_Sspeed);//����С���ٶ�
                    break;
                }
            case 2://�ؿ�2��С������
            case 3://�ؿ�3��С������
            case 4://�ؿ�4��С������
            case 5://�ؿ�5��С������
            case 7://�ؿ�7��С������
            case 8://�ؿ�8��С������
            case 9://�ؿ�9��С������
                {
                    dSetSpriteFlipX(dMakeSpriteName("xiaobing",i),0);//��ת��
                    dSetSpriteLinearVelocityX(dMakeSpriteName("xiaobing",i),-O_Sspeed);//����С���ٶ�
                    break;
                }
            }
        }
        else if(abs(PosX-PosX_xb)<View_xb && O_IsSkill[i-1]==1)    //��С�������Ǹ���ʱ,�����Է�����������������
        {
            //��������
            //��¡���ܶ�����С��λ��
            //�������һ������
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
                    //���ϲ���һ�������ַ���
                    dSpriteMountToSpriteLinkPoint(dMakeSpriteName(name,i),dMakeSpriteName("xiaobing",i),2);
                    dSetSpriteLinearVelocityX(dMakeSpriteName("xiaobing",i),0);//����С���ٶ�
                    //���ü�������ֵ
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
                    //���ϲ���һ�������ַ���
                    //dSetSpriteFlipX(dMakeSpriteName(name,i),1);//��ת����
                    dSpriteMountToSpriteLinkPoint(dMakeSpriteName(name,i),dMakeSpriteName("xiaobing",i),3);
                    dSetSpriteLinearVelocityX(dMakeSpriteName("xiaobing",i),0);//����С���ٶ�
                    //���ü�������ֵ
                    dSetSpriteLifeTime(dMakeSpriteName(name,i),0.3);
                    break;
                }
            }
            O_attTime[i-1] = 0;  //��ʼ��ʱ
            //�����к������ж�
            //��ʼ��ȴ��������Ϊ������
            O_IsSkill[i-1] = 0;

        }
    }
}

// С���ܵ��������˺���
// szName��С��������
// top�����ǳ���
void GameXbBack(const char *szName,int top)
{
    //��С��һ��˲�������
    if(g_IsL == 1 || g_IsU ==1 || g_IsO == 1)//�����ͷż���ʱ�޷���ײ
    {
       return;
    }
    switch(top)
    {
    case 'D'://��ǰ��
        dSetSpriteImpulseForce(szName,3000,0,0);
        break;
    case 'A'://������
        dSetSpriteImpulseForce(szName,-3000,0,0);
        break;
    }
}

// GameXbHurt��С����Ѫ����
// szName��С�־�����
int GameXbHurt(const char *szName,int hurtnum)
{
    //С������
    GameXbBack(szName,Z_top);
    //��С��һ������
    int Hj = g_WhichGq * 2 + 9;
    float HJXS = 1/(1+Hj/100);
    //ȷ�������˺���ֵ
    hurtnum = hurtnum * HJXS + (rand()%3-2);
    //ȷ��ʶ�Ǹ�С���ܵ��˹���
    int len = strlen(szName);
    int i;
    i = *&szName[len-1]-48;
    if(i>7||i<0)
    {
        return 0;
    }
    //����С����������
    M_OHurt = dPlaySound("O_Hurt.wav",0,1*M_vol);
    //�ر����С��������ײ����
    dSetSpriteCollisionReceive(szName,0);
    //��ʱ���㣬��ʼ��ʱ
    O_JiluTime[i-1]=0;
    //��Ǿ����ѹر���ײ
    O_IsPengzhuang[i-1] = 0;
    //�۳�Ѫ��
    O_blood[i-1]-=hurtnum;
    //��ʾ�Ŀ۳�Ѫ��
    GameShowNum("num_shanghai",hurtnum,dGetSpritePositionX(szName),dGetSpritePositionY(szName));
    //С��Ѫ������
    BloodLen(dMakeSpriteName("XT_blood",i),60,O_bloodMax,O_blood[i-1],dGetSpritePositionX(dMakeSpriteName("XT_blood",i)));
    //Ѫ�����׺�ɾ���þ���
    if(O_blood[i-1]<=0)
    {
        //ɾ������
        dDeleteSprite(szName);
        //�����Ǿ���
        Addjingya(g_WhichGq*2);//�ڼ��ص�С�ּӶ��پ���
        //����С�ּ���-1
        g_xbNum--;
        //������С����Ϊ��ʱ����ͼ�����ƶ�
        if(g_xbNum == 0)
        {
            g_qianjin = 1;
        }
    }
return 1;
}

// ��ֵ��ʾ����
// szName����ʾ�����������ֵ'����¡����ֵ������'
// num����ʾ����ֵ
// PosX����ʾ����ֵ��Xλ��
// PosY: ��ʾ����ֵ��Yλ��
void GameShowNum(const char *szName,const int num,const float PosX,const float PosY)
{
    //�ж������ֵ�Ǽ�λ��,
    int numB,numS,numG;
    char *numname1;
    char *numname2;
    char *numname3;
    numB = num/100;
    numS = num/10%10;
    numG = num%10;
    if(O_numSprite >= 2000)
    {
        //���־�����1000��һ��
        O_numSprite = 0;
    }
    switch(numB)
    {
    case 0://������С��3λ
        if(numS == 0)//Ϊһλ��ʱ
        {
            //��¡һ�����־��飬��ʾ�������
            numname1 = dMakeSpriteName("num_",O_numSprite);
            dCloneSprite(szName,numname1);//��¡
            O_numSprite++;
            dSetStaticSpriteFrame(numname1,numG);//��ʾ��ֵ
            //���þ���λ��
            dSetSpritePosition(numname1,PosX,PosY-120);
            //������
            dSetSpriteLinearVelocity(numname1,0.f,-25.f);
            //���������� 0.8��
            dSetSpriteLifeTime(numname1,0.8);
        }
        else//Ϊ��λ��ʱ
        {
            numname1 = dMakeSpriteName("num_",O_numSprite);
            dCloneSprite(szName,numname1);//��¡
            O_numSprite++;
            numname2 = dMakeSpriteName("num_",O_numSprite);
            dCloneSprite(szName,numname2);//��¡
            O_numSprite++;
            dSetStaticSpriteFrame(numname1,numS);
            dSetStaticSpriteFrame(numname2,numG);
            //���þ���λ��
            dSetSpritePosition(numname1,PosX-9,PosY-120);
            dSetSpritePosition(numname2,PosX+9,PosY-120);
            //������
            dSetSpriteLinearVelocity(numname1,0.f,-25.f);
            dSetSpriteLinearVelocity(numname2,0.f,-25.f);
            //���������� 0.8��
            dSetSpriteLifeTime(numname1,0.8);
            dSetSpriteLifeTime(numname2,0.8);
        }
        break;
    default:
        {
            numname1 = dMakeSpriteName("num_",O_numSprite);
            dCloneSprite(szName,numname1);//��¡
            O_numSprite++;
            numname2 = dMakeSpriteName("num_",O_numSprite);
            dCloneSprite(szName,numname2);//��¡
            O_numSprite++;
            numname3 = dMakeSpriteName("num_",O_numSprite);
            dCloneSprite(szName,numname3);//��¡
            O_numSprite++;
            dSetStaticSpriteFrame(numname1,numB);
            dSetStaticSpriteFrame(numname2,numS);
            dSetStaticSpriteFrame(numname3,numG);
            //���þ���λ��
            dSetSpritePosition(numname1,PosX-18,PosY-120);
            dSetSpritePosition(numname2,PosX,PosY-120);
            dSetSpritePosition(numname3,PosX+18,PosY-120);
            //������
            dSetSpriteLinearVelocity(numname1,0.f,-25.f);
            dSetSpriteLinearVelocity(numname2,0.f,-25.f);
            dSetSpriteLinearVelocity(numname3,0.f,-25.f);
            //���������� 0.8��
            dSetSpriteLifeTime(numname1,0.8);
            dSetSpriteLifeTime(numname2,0.8);
            dSetSpriteLifeTime(numname3,0.8);
        }
        break;
    }
}


// ������������
// PosX������Xλ��
void GameXbAttack(const float PosX)
{
    //��������ڴ���С��
    if(g_xbNum > 0)
    {
        if (O_attackTime >= O_attack && O_attackTime <= O_attack*2 && O_isattack == 0)
        {
            O_attackPosX = PosX;//��¼��ǰ���ǵ�λ��
            //����ǰһ���ӣ���ʾ
            //��¡һ����ʾ����������ΪXB_hint����λ�ã�����ΪO_attack
            dCloneSprite("S_XBhint","XB_hint");
            dSetSpritePosition("XB_hint",O_attackPosX,262);
            dSetSpriteLifeTime("XB_hint",O_attack);

            //���Ϊ�ѹ���
            O_isattack = 1;
        }
        else if(O_attackTime > O_attack*2 && O_isattack == 1)
        {
            //����
            //��¡һ����������������ΪXB_attack1����λ�ã�����Ϊ0.3
            dCloneSprite("S_XBattack1","XB_attack1");
            dSetSpritePosition("XB_attack1",O_attackPosX,62);
            dSetSpriteLifeTime("XB_attack1",0.3);

            //��O_attackTime����
            O_attackTime = 0;
            //���Ϊδ����
            O_isattack = 0;
        }
    }
}


// �ı�Ѫ��/����������
// szName�����ı��Ѫ������
// Oldlen��ԭѪ������
// Z_blood����Ѫ��
// N_blood�����ڵ�Ѫ��
// PosX��ԭѪ����Xλ��
void BloodLen(const char *szName,const float Oldlen,const int Z_blood,const int N_blood,const float PosX)
{
    float Newlen,NewPosX;
    // �������Ѫ���ĳ���
    Newlen = (float)N_blood/Z_blood * Oldlen;
    if (Z_blood == 0 && N_blood == 0 && Z_level == 9 && strcmp(szName,Z_LevelName)==0)
    {
        Newlen = Oldlen;
    }
    // �������Ѫ����PosXλ��
    NewPosX = PosX - (Oldlen - Newlen)/2;
    // ������Ѫ���ĳ���
    dSetSpriteWidth(szName,Newlen);
    // ������Ѫ����λ��
    dSetSpritePositionX(szName,NewPosX);
}

// �ı�Ѫ��/��������ֵ
// flag���ı�ʲô��0=> Ѫ��ֵ�� 1=>����ֵ�� 2=>Ѫ�����ֵ�� 3=>�������ֵ
// num���ı�Ϊʲô��
void ShowNum(const int flag, const int num)
{
    //�ж������ֵ�Ǽ�λ��,
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
    case 0://������С��3λ
        dSetStaticSpriteFrame(szName[flag][2] ,13);
        if(numS == 0)//Ϊһλ��ʱ
        {
            dSetStaticSpriteFrame(szName[flag][1],13);
            dSetStaticSpriteFrame(szName[flag][0],numG+2);
        }
        else//Ϊ��λ��ʱ
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

// ShowMap: Map��ͼ��ʼ��
void ShowMap(const int level, const int shengming)
{
    //�ȼ���ʼ��
    dSetStaticSpriteFrame("Maplevel",level-1);
    //Ѫ����ʾ
    int g = shengming % 10;
    int s = shengming % 100 / 10;
    int b = shengming / 100;
    dSetStaticSpriteFrame("bloodnum_g",g);
    dSetStaticSpriteFrame("bloodnum_s",s);
    dSetStaticSpriteFrame("bloodnum_b",b);

    dSetStaticSpriteFrame("bloodzong_s",g);
    dSetStaticSpriteFrame("bloodzong_b",s);
    dSetStaticSpriteFrame("bloodzong_q",b);
    //չʾ�����ʼ��
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
    //Ѫ����ʼ��

}

//���ǼӾ��麯��
//������Ϊ9��ʱ�����ټӾ���
void Addjingya(const int num)
{
    if(Z_level == 9);
    else{
        Z_jingyan += num;
        if(Z_jingyan >= Z_levelMax)
        {
            Z_jingyan -=Z_levelMax;
            //����
            Shengji();
        }
        //����ֵ��ʾ��ͼ�Σ�
        BloodLen(Z_LevelName,Z_Levellen,Z_levelMax,Z_jingyan,Z_LevelPosX);
        ShowNum(1,Z_jingyan);//��ʾ���飨��ֵ��
    }

}


// ��������
void Shengji(void)
{
    Z_level += 1;
    //�����������辭��ֵ����
    Z_levelMax = 60*Z_level-30;
    if(Z_level == 9)
    {
        Z_jingyan = 0;
        Z_levelMax = 0;

    }
    //����Ѫ��+100
    Z_shengming = 100*Z_level;
    //��������Ѫ������
    Z_blood = Z_shengming;
    //������������
    Z_gongji = 12*Z_level-2;
    Z_fangyv = 12*Z_level-2;
    Z_hurtID = 1/(1+(Z_fangyv/100.0)); //�������ǵļ���ϵ��
    //Z_speed += 1.2;
    //������ʾ����
    //��ʼ��Ѫ����ʾ��ͼ�Σ�
    BloodLen(Z_BloodName,Z_Bloodlen,Z_shengming,Z_blood,Z_BloodPosX);
    //��ʼ������ֵ��ʾ��ͼ�Σ�
    BloodLen(Z_LevelName,Z_Levellen,Z_levelMax,Z_jingyan,Z_LevelPosX);
    ShowNum(2,Z_shengming);//��ʾѪ�����ֵ����ֵ��
    ShowNum(0,Z_blood);//��ʾѪ������ֵ��
    ShowNum(3,Z_levelMax);//��ʾ�������ֵ����ֵ��
    ShowNum(1,Z_jingyan);//��ʾ��ǰ���飨��ֵ��
    //��ʾ�ȼ�
    dSetStaticSpriteFrame("level",Z_level-1);
    //���Ŷ���
    dCloneSprite("level_up","level_up1");//��¡Level UP
    dSetSpritePosition("level_up1",0,50);//����λ��
    dSetSpriteLinearVelocityY("level_up1",-30.f);//������
    dSetSpriteLifeTime("level_up1",1.2);//��������ֵ
    //��������
    M_LevelUp = dPlaySound("Gold.wav",0,1*M_vol);
    //���¼���
     switch(Z_level)
    {
    case 6://������������
        // ����4���ܵ���ʾ
        dSetStaticSpriteImage("skill4","Skill4ImageMap",0);
        // ���ÿ����ͷ��ļ���
        Z_IsSkill[3] = 1;
        break;
    case 4:
        // ����3����ͼƬ��ʾ
        dSetStaticSpriteImage("skill3","Skill3ImageMap",0);
        // ���ÿ����ͷ�������
        Z_IsSkill[2] = 1;
        break;
    case 3:
        // ����2����ͼƬ��ʾ
        dSetStaticSpriteImage("skill2","Skill2ImageMap",0);
        // ���ÿ����ͷŶ�����
        Z_IsSkill[1] = 1;
        break;
    case 2:
        // ����1����ͼƬ��ʾ
        dSetStaticSpriteImage("skill1","Skill1ImageMap",0);
        // ���ÿ����ͷ�һ����
        Z_IsSkill[0] = 1;
        break;
    }
}


// �����ͷź�����
// ���¶�Ӧ����ʱ����
// �ͷ���ɺ���뼼����ȴ
// run�����м�⼼����ȴ�����Ƿ񲥷���ϣ�
// ������ȼ��ı䣬�ڹؿ���ʼ��ʱ��ˢ�£��������ܻ�����¼���
// ���ܳ�ʼ����������switch�ṹ

// ���ܳ�ʼ������
// Level����ǰ����ȼ�
void SkillInit(const int Level)
{
    //�������м���
    dSetStaticSpriteImage("skill4","Skill_BlankImageMap",0);
    Z_IsSkill[0] = 0;
    dSetStaticSpriteImage("skill3","Skill_BlankImageMap",0);
    Z_IsSkill[1] = 0;
    dSetStaticSpriteImage("skill2","Skill_BlankImageMap",0);
    Z_IsSkill[2] = 0;
    dSetStaticSpriteImage("skill1","Skill_BlankImageMap",0);
    Z_IsSkill[3] = 0;

    //��������ȼ����ż���
    switch(Level)
    {
    case 10:
    case 9:
    case 8:
    case 7:
    case 6://������������
        // ����4���ܵ���ʾ
        dSetStaticSpriteImage("skill4","Skill4ImageMap",0);
        // ���ÿ����ͷ��ļ���
        Z_IsSkill[3] = 1;
    case 5:
    case 4:
        // ����3����ͼƬ��ʾ
        dSetStaticSpriteImage("skill3","Skill3ImageMap",0);
        // ���ÿ����ͷ�������
        Z_IsSkill[2] = 1;
    case 3:
        // ����2����ͼƬ��ʾ
        dSetStaticSpriteImage("skill2","Skill2ImageMap",0);
        // ���ÿ����ͷŶ�����
        Z_IsSkill[1] = 1;
    case 2:
        // ����1����ͼƬ��ʾ
        dSetStaticSpriteImage("skill1","Skill1ImageMap",0);
        // ���ÿ����ͷ�һ����
        Z_IsSkill[0] = 1;
        break;
    }
}

// �ͷż���
// Skill���ĸ�����'U','I','O','L'
void SendSkill(const char skill)
{
    switch(skill)
    {
    case 'U'://1����
        {
            g_IsU = 1;
            //��¡���ܶ���������λ��
            dCloneSprite("sendSkill1","CsendSkill1");
            dSetSpritePosition("CsendSkill1",Z_PosX,Z_PosY+100);
            switch(Z_top)
            {
            case 'D':
                {
                    S_Top = 'D';
                    //���ܷ�ת
                    dSetSpriteFlipX("CsendSkill1",1);
                    //�����ƶ�
                    dSpriteMoveTo("CsendSkill1",Z_PosX+240,Z_PosY+100,800,1);
                    //���ü�������ֵ
                    dSetSpriteLifeTime("CsendSkill1",0.3);
                }
                break;
            case 'A':
                {
                    S_Top = 'A';
                    //���ܷ�ת
                    dSetSpriteFlipX("CsendSkill1",0);
                    //�����ƶ�
                    dSpriteMoveTo("CsendSkill1",Z_PosX-240,Z_PosY+100,800,1);
                    //���ü�������ֵ
                    dSetSpriteLifeTime("CsendSkill1",0.3);
                }
                break;
            }
            //���ǲ��ɼ��������ƶ�,�Ҳ�������ײ
            dSetSpriteVisible(Z_name,0);//���ɼ�
            dSetSpriteImmovable(Z_name,1);//���ɶ�
            dSetSpriteCollisionReceive(Z_name,0);//��������ײ
            S_SpeedTime = 0;  //��ʼ��ʱ
            //�����к������ж�
            //��ʼ��ȴ��������Ϊ������
            S_Time1 = 0;//��ʼ��ȴ
            Z_IsSkill[0] = 0;
            //��λ����λ��
            //dCloneSprite("skillCD1","skillCD11");
            dSetSpritePosition("skillCD1",dGetSpritePositionX("skill1")+2,dGetSpritePositionY("skill1")+2);
            //������ȴ����
            dAnimateSpritePlayAnimation("skillCD1","Skil1l_WaitAnimation",0);
            //���ż���1��Ч
            M_Skill1 = dPlaySound("Z_Skill1.wav",0,1*M_vol);
        }
        break;
    case 'I'://2����
        {
            //��¡���ܶ���������λ��
            dCloneSprite("sendSkill2","CsendSkill2");
            dSetSpritePosition("CsendSkill2",Z_PosX,Z_PosY-110);
            //��¡��Ч������λ��
            dCloneSprite("sendSkill2_1","CsendSkill2_1");
            dSetSpritePosition("CsendSkill2_1",Z_PosX,Z_PosY);
            //����һ��
            dSpriteMountToSpriteLinkPoint("CsendSkill2",Z_name,3);
            dSpriteMountToSpriteLinkPoint("CsendSkill2_1",Z_name,4);
            //���ü�������ֵ
            dSetSpriteLifeTime("CsendSkill2",0.5);
            dSetSpriteLifeTime("CsendSkill2_1",0.5);
            //��ʼ��ȴ��������Ϊ������
            S_Time2 = 0;//��ʼ��ȴ
            Z_IsSkill[1] = 0;
            //��λ����λ��
            dSetSpritePosition("skillCD2",dGetSpritePositionX("skill2")+2,dGetSpritePositionY("skill2")+2);
            //������ȴ����
            dAnimateSpritePlayAnimation("skillCD2","Skill2_WaitAnimation",0);
            //����Ч��������Ѫ���ظ�����֮һ
            Z_blood+=Z_shengming/3;
            if(Z_blood >=Z_shengming)
            {
                Z_blood = Z_shengming;
            }
            //�ı�Ѫ������
            BloodLen(Z_BloodName,Z_Bloodlen,Z_shengming,Z_blood,Z_BloodPosX);
            //��ʾѪ��
            ShowNum(0, Z_blood);
            //���ż���1��Ч
            M_Skill2 = dPlaySound("Z_Skill2.wav",0,1*M_vol);
        }
        break;
    case 'O'://3����
        {
            g_IsO = 1;
             //��¡���ܶ���������λ��
            dCloneSprite("sendSkill3","CsendSkill3");
            dSetSpritePosition("CsendSkill3",Z_PosX,Z_PosY);
            //���ü�������ֵ
            dSetSpriteLifeTime("CsendSkill3",0.3);
            //���ǲ��ɼ��������ƶ�,�Ҳ�������ײ
            dSetSpriteVisible(Z_name,0);//���ɼ�
            dSetSpriteImmovable(Z_name,1);//���ɶ�
            dSetSpriteCollisionReceive(Z_name,0);//��������ײ
            S_SpeedTime3 = 0;  //��ʼ��ʱ
            //�����к������ж�
            //��ʼ��ȴ��������Ϊ������
            S_Time3 = 0;//��ʼ��ȴ
            Z_IsSkill[2] = 0;
            //��λ����λ��
            dSetSpritePosition("skillCD3",dGetSpritePositionX("skill3")+2,dGetSpritePositionY("skill3")+2);
            //������ȴ����
            dAnimateSpritePlayAnimation("skillCD3","Skill3_WaitAnimation",0);
            //���ż���1��Ч
            M_Skill3 = dPlaySound("Z_Skill3.wav",0,1*M_vol);
        }
        break;
    case 'L'://4����
        {
            g_IsL = 1;
             //��¡���ܶ���������λ��
            dCloneSprite("sendSkill4","CsendSkill4");
            dSetSpritePosition("CsendSkill4",Z_PosX,Z_PosY);
            //���ü�������ֵ
            dSetSpriteLifeTime("CsendSkill4",0.3);
            //���ǲ��ɼ��������ƶ�,�Ҳ�������ײ
            dSetSpriteVisible(Z_name,0);//���ɼ�
            dSetSpriteImmovable(Z_name,1);//���ɶ�
            dSetSpriteCollisionReceive(Z_name,0);//��������ײ
            S_SpeedTime4 = 0;  //��ʼ��ʱ
            //�����к������ж�
            //��ʼ��ȴ��������Ϊ������
            S_Time4 = 0;//��ʼ��ȴ
            Z_IsSkill[3] = 0;
            //��λ����λ��
            dSetSpritePosition("skillCD4",dGetSpritePositionX("skill4")+2,dGetSpritePositionY("skill4")+2);
            //������ȴ����
            dAnimateSpritePlayAnimation("skillCD4","Skill4_WaitAnimation",0);
            //���ż���1��Ч
            M_Skill4 = dPlaySound("Z_Skill4.wav",0,1*M_vol);
        }
        break;
    default:
        break;
    }
}

// ��ʾϵͳʱ��
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

// ����Boss
// WhichMap���ĸ���ͼ��Boss
void CloneBoss(const int WhichMap)
{
    // ��¡Boss
    dCloneSprite("Boss","Boss1");
    // ��λ
    dSetSpritePosition("Boss1",0,-130);
    // ��Bossһ����������
    dSetSpriteConstantForce("Boss1",0,1000000,0);
    // ����BossΪ����ײ
    B_IsPengzhuang = 1;
    // ����Boss�Ļ������ԣ�BoosѪ�� = ��ǰ��ͼֵ-2*250��
    B_Shengming = (WhichMap-2) * 120 + 130;
    B_Gongji =  (WhichMap-2) * 10 + 40;
    B_Fangyv =  (WhichMap-2) * 10 + 60;
    // ����Boss��ǰѪ��
    B_Blood = B_Shengming;
    // BossѪ������λ��ʾ300-280��339.5-263
    dSetSpritePosition("Bossxuetiao",300,-280);
    dSetSpritePosition("Boss_blood",339.5,-263);
    // TODO������Boss�ǳ���Ч
    //��¡��Ϻ󣬽�����Boss����Ϊ1
    B_num = 1;
    //��¡��Ϻ󣬳��ϴ���Boss����ͼ�����ƶ�
    g_qianjin = 0;
}

// BossMove��Boss�ƶ�����
// PosX�����ǵ�X����
void BossMove(const float PosX)
{
    // ִ�д˺���ʱ��Boss���������ƶ�
    // ��ȡ��ʱBoss��Xλ��
    float B_PosX;
    B_PosX = dGetSpritePositionX("Boss1");
    // �ж�Boss��ʱ�����ǵ�ʲôλ��
    if (B_PosX > PosX+50) //�����ʱBoss������ǰ������Bossһ��������ٶȣ����﷭ת
    {
        //Boss��ת
        dSetSpriteFlipX("Boss1",1);
        //��Bossһ�������ٶ�
        dSetSpriteLinearVelocityX("Boss1",-B_Speed);
    }
    else if (B_PosX < PosX-50) //�����ʱBoss������󷽣���Bossһ����ǰ���ٶȣ����ﲻ��ת
    {
        //Boss����ת
        dSetSpriteFlipX("Boss1",0);
        //��Bossһ����ǰ���ٶ�
        dSetSpriteLinearVelocityX("Boss1",B_Speed);
    }
    else // ���Boss�����Ǹ������ƶ�
    {
        //��Bossֹͣ
        dSetSpriteLinearVelocityX("Boss1",0);

    }

}

// BossAttack��Boss��������
// PosX�����ǵ�X����
void BossAttack(const float PosX)
{
    //������Ч
    //TODO
    // ���Ž�������
    // Boss������������
    dAnimateSpritePlayAnimation("Boss1",B_Attackname[g_WhichGq-1],1);
    // Boss��������������Ч�������������ʽ���
    // ȷ�����ĸ���ͼ
    switch(g_WhichMap)
    {
    case 9://�ؿ�7
    case 8://�ؿ�6
    case 7://�ؿ�5
    case 3://�ؿ�1
        {
            //��������
            //��¡���ܶ�����Bossλ��
            //�������һ������
            char *Skillname = (char *)B_Skillname[rand()%3];
            char *name = (char *)malloc(strlen(Skillname) + strlen(firstname));
            strcpy(name,firstname);
            strcat(name,Skillname);
            dCloneSprite(Skillname,dMakeSpriteName(name,B_i));
            //���ϲ���һ�������ַ���
            ///////////////////////////////////////////////////////
            //ȷ�����Ǻ�Boss�����λ��
            float B_PosX = dGetSpritePositionX("Boss1");
            float B_PosY = dGetSpritePositionY("Boss1");
            if (B_PosX > Z_PosX) //�����ʱBoss������ǰ��
            {
                dSetSpritePosition(dMakeSpriteName(name,B_i),B_PosX-100,B_PosY+(rand()%200-100));    //���ü���λ��
                dSetSpriteFlipX(dMakeSpriteName(name,B_i),1);   //Boss���ܷ�ת
                dSetSpriteLinearVelocityX(dMakeSpriteName(name,B_i),-B_SkillSpeed);     //��Boss����һ�������ٶ�
            }
            else if (B_PosX < Z_PosX) //�����ʱBoss�������
            {
                dSetSpritePosition(dMakeSpriteName(name,B_i),B_PosX+100,B_PosY);    //���ü���λ��
                dSetSpriteFlipX(dMakeSpriteName(name,B_i),0);   //Boss����ת
                dSetSpriteLinearVelocityX(dMakeSpriteName(name,B_i),B_SkillSpeed);      //��Boss����һ����ǰ���ٶ�
            }
            dSetSpriteLifeTime(dMakeSpriteName(name,B_i),0.8);      //���ü�������ֵ
            B_i++;
            break;
        }
    case 4://�ؿ�2
        {
            //��������
            //��¡���ܶ�����Bossλ��
            //�������һ������
            char *Skillname = (char *)B_Skillname[rand()%3+3];
            char *name = (char *)malloc(strlen(Skillname) + strlen(firstname));
            strcpy(name,firstname);
            strcat(name,Skillname);
            dCloneSprite(Skillname,dMakeSpriteName(name,B_i));
            //���ϲ���һ�������ַ���
            ///////////////////////////////////////////////////////
            //ȷ�����Ǻ�Boss�����λ��
            float B_PosX = dGetSpritePositionX("Boss1");
            float B_PosY = dGetSpritePositionY("Boss1");
            if (B_PosX > Z_PosX) //�����ʱBoss������ǰ��
            {
                dSetSpritePosition(dMakeSpriteName(name,B_i),B_PosX-100,B_PosY+(rand()%150-50));    //���ü���λ��
                dSetSpriteFlipX(dMakeSpriteName(name,B_i),0);   //Boss���ܲ���ת
                dSetSpriteLinearVelocityX(dMakeSpriteName(name,B_i),-B_SkillSpeed);     //��Boss����һ�������ٶ�
            }
            else if (B_PosX < Z_PosX) //�����ʱBoss�������
            {
                dSetSpritePosition(dMakeSpriteName(name,B_i),B_PosX+100,B_PosY);    //���ü���λ��
                dSetSpriteFlipX(dMakeSpriteName(name,B_i),1);   //Boss���ܷ�ת
                dSetSpriteLinearVelocityX(dMakeSpriteName(name,B_i),B_SkillSpeed);      //��Boss����һ����ǰ���ٶ�
            }
            dSetSpriteLifeTime(dMakeSpriteName(name,B_i),0.8);      //���ü�������ֵ
            B_i++;
            break;
        }
    case 5://�ؿ�3
        {
            //��������
            //��¡���ܶ�����Bossλ��
            //�������һ������
            char *Skillname = (char *)B_Skillname[rand()%5+3];
            char *name = (char *)malloc(strlen(Skillname) + strlen(firstname));
            strcpy(name,firstname);
            strcat(name,Skillname);
            dCloneSprite(Skillname,dMakeSpriteName(name,B_i));
            //���ϲ���һ�������ַ���
            ///////////////////////////////////////////////////////
            //ȷ�����Ǻ�Boss�����λ��
            float B_PosX = dGetSpritePositionX("Boss1");
            float B_PosY = dGetSpritePositionY("Boss1");
            if (B_PosX > Z_PosX) //�����ʱBoss������ǰ��
            {
                dSetSpritePosition(dMakeSpriteName(name,B_i),B_PosX-100,B_PosY+(rand()%150-50));    //���ü���λ��
                dSetSpriteFlipX(dMakeSpriteName(name,B_i),0);   //Boss���ܲ���ת
                dSetSpriteLinearVelocityX(dMakeSpriteName(name,B_i),-B_SkillSpeed);     //��Boss����һ�������ٶ�
            }
            else if (B_PosX < Z_PosX) //�����ʱBoss�������
            {
                dSetSpritePosition(dMakeSpriteName(name,B_i),B_PosX+100,B_PosY);    //���ü���λ��
                dSetSpriteFlipX(dMakeSpriteName(name,B_i),1);   //Boss���ܷ�ת
                dSetSpriteLinearVelocityX(dMakeSpriteName(name,B_i),B_SkillSpeed);      //��Boss����һ����ǰ���ٶ�
            }
            dSetSpriteLifeTime(dMakeSpriteName(name,B_i),0.8);      //���ü�������ֵ
            B_i++;
            break;
        }
    case 6://�ؿ�4
        {
            //��������
            //��¡���ܶ�����Bossλ��
            //�������һ������
            char *Skillname = (char *)B_Skillname[rand()%4+8];
            char *name = (char *)malloc(strlen(Skillname) + strlen(firstname));
            strcpy(name,firstname);
            strcat(name,Skillname);
            dCloneSprite(Skillname,dMakeSpriteName(name,B_i));
            //���ϲ���һ�������ַ���
            ///////////////////////////////////////////////////////
            //ȷ�����Ǻ�Boss�����λ��
            float B_PosX = dGetSpritePositionX("Boss1");
            float B_PosY = dGetSpritePositionY("Boss1");
            if (B_PosX > Z_PosX) //�����ʱBoss������ǰ��
            {
                dSetSpritePosition(dMakeSpriteName(name,B_i),B_PosX-100,B_PosY+(rand()%150-50));    //���ü���λ��
                dSetSpriteFlipX(dMakeSpriteName(name,B_i),0);   //Boss���ܲ���ת
                dSetSpriteLinearVelocityX(dMakeSpriteName(name,B_i),-B_SkillSpeed);     //��Boss����һ�������ٶ�
            }
            else if (B_PosX < Z_PosX) //�����ʱBoss�������
            {
                dSetSpritePosition(dMakeSpriteName(name,B_i),B_PosX+100,B_PosY);    //���ü���λ��
                dSetSpriteFlipX(dMakeSpriteName(name,B_i),1);   //Boss���ܷ�ת
                dSetSpriteLinearVelocityX(dMakeSpriteName(name,B_i),B_SkillSpeed);      //��Boss����һ����ǰ���ٶ�
            }
            dSetSpriteLifeTime(dMakeSpriteName(name,B_i),0.8);      //���ü�������ֵ
            B_i++;
            break;
        }
    case 10://�ؿ�8
        {
            //��������
            //��¡���ܶ�����Bossλ��
            //�������һ������
            char *Skillname = (char *)B_Skillname[rand()%5];
            char *name = (char *)malloc(strlen(Skillname) + strlen(firstname));
            strcpy(name,firstname);
            strcat(name,Skillname);
            dCloneSprite(Skillname,dMakeSpriteName(name,B_i));
            //���ϲ���һ�������ַ���
            ///////////////////////////////////////////////////////
            //ȷ�����Ǻ�Boss�����λ��
            float B_PosX = dGetSpritePositionX("Boss1");
            float B_PosY = dGetSpritePositionY("Boss1");
            if (B_PosX > Z_PosX) //�����ʱBoss������ǰ��
            {
                dSetSpritePosition(dMakeSpriteName(name,B_i),B_PosX-100,B_PosY+(rand()%150-50));    //���ü���λ��
                dSetSpriteFlipX(dMakeSpriteName(name,B_i),0);   //Boss���ܲ���ת
                dSetSpriteLinearVelocityX(dMakeSpriteName(name,B_i),-B_SkillSpeed);     //��Boss����һ�������ٶ�
            }
            else if (B_PosX < Z_PosX) //�����ʱBoss�������
            {
                dSetSpritePosition(dMakeSpriteName(name,B_i),B_PosX+100,B_PosY);    //���ü���λ��
                dSetSpriteFlipX(dMakeSpriteName(name,B_i),1);   //Boss���ܷ�ת
                dSetSpriteLinearVelocityX(dMakeSpriteName(name,B_i),B_SkillSpeed);      //��Boss����һ����ǰ���ٶ�
            }
            dSetSpriteLifeTime(dMakeSpriteName(name,B_i),0.8);      //���ü�������ֵ
            B_i++;
            break;
        }
    case 11://�ؿ�11
        {
            //��������
            //��¡���ܶ�����Bossλ��
            //�������һ������
            char *Skillname = (char *)B_Skillname[rand()%7];
            char *name = (char *)malloc(strlen(Skillname) + strlen(firstname));
            strcpy(name,firstname);
            strcat(name,Skillname);
            dCloneSprite(Skillname,dMakeSpriteName(name,B_i));
            //���ϲ���һ�������ַ���
            ///////////////////////////////////////////////////////
            //ȷ�����Ǻ�Boss�����λ��
            float B_PosX = dGetSpritePositionX("Boss1");
            float B_PosY = dGetSpritePositionY("Boss1");
            if (B_PosX > Z_PosX) //�����ʱBoss������ǰ��
            {
                dSetSpritePosition(dMakeSpriteName(name,B_i),B_PosX-100,B_PosY+(rand()%200-100));    //���ü���λ��
                dSetSpriteFlipX(dMakeSpriteName(name,B_i),1);   //Boss���ܷ�ת
                dSetSpriteLinearVelocityX(dMakeSpriteName(name,B_i),-B_SkillSpeed);     //��Boss����һ�������ٶ�
            }
            else if (B_PosX < Z_PosX) //�����ʱBoss�������
            {
                dSetSpritePosition(dMakeSpriteName(name,B_i),B_PosX+100,B_PosY);    //���ü���λ��
                dSetSpriteFlipX(dMakeSpriteName(name,B_i),0);   //Boss����ת
                dSetSpriteLinearVelocityX(dMakeSpriteName(name,B_i),B_SkillSpeed);      //��Boss����һ����ǰ���ٶ�
            }
            dSetSpriteLifeTime(dMakeSpriteName(name,B_i),0.8);      //���ü�������ֵ
            B_i++;
            break;
        }
    }
}

// BossHurt��Boss���˿�Ѫ����
// hurt����Boss���˺�
void BossHurt(const int hurt)
{
    // ��Boss�ܵ�������ɵ��˺��󣬵���
    // ����Boss����������ʵ�ʶ�Boss��ɵ��˺�
    int kouxue;
    kouxue = hurt / (1 + (float)B_Fangyv/100.0) + (rand()%6 - 2);
    B_Blood -= kouxue;
     //��ʾ�Ŀ۳�Ѫ��
    GameShowNum("num_shanghai",kouxue,dGetSpritePositionX("Boss1"),dGetSpritePositionY("Boss1"));
    // �ı�Ѫ������
    BloodLen("Boss_blood",569,B_Shengming,B_Blood,339.5);
    //�ر�Boss������ײ����
    dSetSpriteCollisionReceive("Boss1",0);
    //��ʱ���㣬��ʼ��ʱ
    B_JiangeTime = 0;
    //��Ǿ��鲻����ײ
    B_IsPengzhuang = 0;
    // ��Ѫ�������,����Boss��������
    if(B_Blood <= 0)
    {
        //�����Ǿ���
        Addjingya(g_WhichGq*12+3);//�ڼ��ص�С�ּӶ��پ���
        BossDie(g_WhichMap);
    }
}

// BossDie��Boss��������
// WhichMap�����ŵ�ͼ��Boss
void BossDie(const int WhichMap)
{
    B_i=0;
    // ɾ������
    dDeleteSprite("Boss1");
    // �����ͨ��
    if (g_Whichgame < WhichMap - 2)
    {
        g_Whichgame = WhichMap-2;
    }
    //������Լ��ع�������===Boss����
    if(g_isLoadGC1==1)
    {
        //��¼�ǵ�Ļ��������
        GC_ID = 2;
        //�ı��ͼ���
        g_GCTime = 0;
        g_WhichMap = -3;//���ٽ������ѭ������ʼ����ʱ��ѭ��
        //�������
        for(int i=0;i<20;i++)
        {
            GC_F[i]=0;
        }
    }
    else
    {
        // ��̬��ʾ��ʤ��ť
        dSetSpritePosition("victory",0,-800);
        dSpriteMoveTo("victory",0,0,g_MenuSpeed,1);
        //dSetSpritePosition("victory",0,0);
        //���µ�ͼ���
        g_WhichMap = -2;
    }
}

// BossAction��Boss�ж�����
// ע���ں������������Boss���ж����ƶ����ͷż����������
void BossAction(const float PosX)
{
    //ÿ������Boss����һ�ν���
    //ʱ���Ѿ���ȥ���룬Boss��δ��������
    if (B_attackTime > B_attack && B_IsAttack == 0)
    {
        BossAttack(PosX);// Boss�ͷż���
        B_IsAttack = 1;//���Boss�Ѿ���������
        B_attackTime = 0;//���¼�ʱ
    }
    else if(B_IsAttack == 1)//Boss�����˽���
    {
        BossMove(PosX);// Boss�ƶ�
        if(B_attackTime > B_attack)//������ʱ�����2��
        {
            B_IsAttack = 0;//���Bossδ��������
        }
    }


}

// GameMove�������ƶ�����
void GameMove(void)
{
    //��ֻ��D������
    if(g_IsD ==1 && g_IsA == 0)
    {
        //�����ͼ�������ƶ�������ſ�����ǰ��
        if (dGetSpriteImmovable(g_mapname[g_WhichMap]) == 1)
        {
            dSetSpriteLinearVelocityX(Z_name,Z_speed);//������һ����ǰ���ٶ�
        }
        dSetSpriteLinearVelocity(g_mapname[g_WhichMap],-Z_speed,0);//����ͼһ�������ٶ�
    }
    //ֻ��A������
    else if(g_IsA ==1 && g_IsD == 0)
    {
        dSetSpriteLinearVelocityX(Z_name,-Z_speed);//������һ�������ٶ�
    }
    // AD��������
    else if (g_IsA ==1 && g_IsD == 1)
    {
        //�ж����ǳ������ǳ����������ƶ�
        switch(Z_top)
        {
        case 'A':
            {
                dSetSpriteLinearVelocityX(Z_name,-Z_speed);//������һ�������ٶ�
                break;
            }
        case 'D':
            {
                //�����ͼ�������ƶ�������ſ�����ǰ��
                if (dGetSpriteImmovable(g_mapname[g_WhichMap]) == 1)
                {
                    dSetSpriteLinearVelocityX(Z_name,Z_speed);//������һ����ǰ���ٶ�
                }
                dSetSpriteLinearVelocity(g_mapname[g_WhichMap],-Z_speed,0);//����ͼһ�������ٶ�
                break;
            }
        default:
            break;
        }
    }
}

// SubBlood�����ǿ�Ѫ����
void SubBlood(const int num)
{
    //�����Ѫ
    //�۳�Ѫ��
    Z_blood -= num;
    //�ж�����ʣ��Ѫ��
    if (Z_blood <= 0)
    {
        Z_blood = 0;
        //�ٶ�����
        dSetSpriteLinearVelocityX(Z_name,0);
        //����������������
        dAnimateSpritePlayAnimation(Z_name,Z_die,0);
        //����������Ч
        M_Hurt = dPlaySound("Z_hurt.wav",0,1*M_vol);

    }else{
        //���ﲥ�����˶���
        dAnimateSpritePlayAnimation(Z_name,Z_hurt,1);
        //����������Ч
        M_Hurt = dPlaySound("Z_hurt.wav",0,1*M_vol);
    }
         //�ر����ǽ�����ײ����
        dSetSpriteCollisionReceive(Z_name,0);
        //��ʱ���㣬��ʼ��ʱ
        Z_hurtTime=0;
        //��Ǿ����ѹر���ײ
        Z_Ishurt = 0;
        //��ʾ�Ŀ۳�Ѫ��
        GameShowNum("num_Bule",num,dGetSpritePositionX(Z_name),dGetSpritePositionY(Z_name));
        ShowNum(0,Z_blood);
        //�ı�Ѫ��
        BloodLen(Z_BloodName,Z_Bloodlen,Z_shengming,Z_blood,Z_BloodPosX);

}

// GameLoadGC�����ع�������
// GameGQ����¼���ĸ���ͼ
// ID����¼����һĻ,1 =��������2 =����ɱ
void GameLoadGC(const int GameGQ,const int ID)
{
    //�ı��ͼ���
    g_WhichMap = -3;

    //�ƶ���Ļ
    dSetSpritePosition("GC_huimu",0.0,0.0);
    //˯��1000����
    if(g_GCTime>=0.5&&GC_F[0]==0)//0.5���
    {
        //�ƶ��Ի���
        //1.��λ 2.�ƶ� 3.˯��
        dSetSpritePosition("GC_Talk1",-800.0,-170.0);
        dSpriteMoveTo("GC_Talk1",-210.0,-170.0,1000,1);//�ٶ�1000
        GC_F[0]=1;//���
    }
    if(g_GCTime>=1&&GC_F[1]==0)//1���
    {
        dSetSpritePosition("GC_Talk2",800.0,120.0);
        dSpriteMoveTo("GC_Talk2",210.0,120.0,1000,1);//�ٶ�1000
        GC_F[1]=1;//���
    }
    //�ж����Ǹ���ͼ==���ز�ͬ����
    switch(GameGQ)
    {
        case 1:
            {
                //�Ի���ʼ
                //ȷ������һĻ
                if(ID == 1)
                {//����ʱ�ĶԻ�
                    GC_time = 3;
                    //��λ
                    if(g_GCTime>=2&&GC_F[2]==0)//2���
                    {
                        dSetSpritePosition("T1_1",-200.0,-180.0);//λ��-200��-180
                        GC_F[2]=1;
                    }
                    if(g_GCTime>=3&&GC_F[3]==0)//3���
                    {
                        dSetSpritePosition("T1_2",160.0,110.0);//λ��160��110
                        GC_F[3]=1;
                    }
                    g_isLoadGC = 0;//��¼�����Ѽ���
                }
                else
                {//��ɱ�ĶԻ�
                    GC_time = 6;
                    //��λ
                    if(g_GCTime>=2&&GC_F[2]==0)//2���
                    {
                        dSetSpritePosition("T2_1",127.0,102.0);//λ��127��102
                        GC_F[2]=1;
                    }
                    if(g_GCTime>=3&&GC_F[3]==0)//3���
                    {
                        dSetSpritePosition("T2_2",-360.0,-215.0);//λ��-360��-215
                        GC_F[3]=1;
                    }
                    if(g_GCTime>=4&&GC_F[4]==0)//4���
                    {
                        dSetSpritePosition("T2_2",0.0,1460.0);//����2
                        dSetSpritePosition("T2_3",-317.0,-215.0);//λ��-317��-215
                        GC_F[4]=1;
                    }
                    if(g_GCTime>=5&&GC_F[5]==0)//5���
                    {
                        dSetSpritePosition("T2_3",0.0,1460.0);//����3
                        dSetSpritePosition("T2_4",-273.0,-200.0);//λ��-273��-200
                        GC_F[5]=1;
                    }
                    if(g_GCTime >= 6 && GC_F[6]==0)//6���
                    {
                        dSetSpritePosition("T2_1",0.0,1460.0);//����1
                        dSetSpritePosition("T2_5",48.0,86.0);//λ��48��86
                        GC_F[6]=1;
                    }
                    g_isLoadGC1 = 0;//��¼����2�Ѽ���
                }
                break;
            }
        case 2:
            {
                //�Ի���ʼ
                //ȷ������һĻ
                if(ID == 1)
                {//����ʱ�ĶԻ�
                    GC_time = 7;
                    //��λ
                    if(g_GCTime>=2&&GC_F[2]==0)//2���
                    {
                        dSetSpritePosition("T1_1",-270.0,-215.0);//λ��-270��-215
                        GC_F[2]=1;
                    }
                    if(g_GCTime>=3&&GC_F[3]==0)//3���
                    {
                        dSetSpritePosition("T1_1",0.0,1460.0);//����1
                        dSetSpritePosition("T1_2",-315.0,-215.0);//λ��-315��-215
                        GC_F[3]=1;
                    }
                    if(g_GCTime>=4&&GC_F[4]==0)//4���
                    {
                        dSetSpritePosition("T1_2",0.0,1460.0);//����2
                        dSetSpritePosition("T1_3",-277.0,-215.0);//λ��-277��-215
                        GC_F[4]=1;
                    }
                    if(g_GCTime>=5&&GC_F[5]==0)//5���
                    {
                        dSetSpritePosition("T1_4",124.0,86.0);//λ��124��86
                        GC_F[5]=1;
                    }
                    if(g_GCTime>=6&&GC_F[6]==0)//6���
                    {
                        dSetSpritePosition("T1_4",0.0,1460.0);//����4
                        dSetSpritePosition("T1_5",160.0,86.0);//λ��160��86
                        GC_F[6]=1;
                    }
                    if(g_GCTime>=7&&GC_F[7]==0)//7���
                    {
                        dSetSpritePosition("T1_5",0.0,1460.0);//����5
                        dSetSpritePosition("T1_6",50.0,86.0);//λ��50��86
                        GC_F[7]=1;
                    }
                    g_isLoadGC = 0;//��¼�����Ѽ���
                }
                else
                {//��ɱ�ĶԻ�
                    GC_time = 9;
                    //��λ
                    if(g_GCTime>=2&&GC_F[2]==0)//2���
                    {
                        dSetSpritePosition("T2_1",-265.0,-215);//λ��-265��-215
                        GC_F[2]=1;
                    }
                    if(g_GCTime>=3&&GC_F[3]==0)//3���
                    {
                        dSetSpritePosition("T2_2",47.0,86.0); //λ��47.0,86.0
                        GC_F[3]=1;
                    }
                    if(g_GCTime>=4&&GC_F[4]==0)//4���
                    {
                        dSetSpritePosition("T2_2",0.0,1460.0);//����2
                        dSetSpritePosition("T2_3",141.0,86.0);//λ��141.0,86.0
                        GC_F[4]=1;
                    }
                    if(g_GCTime>=5&&GC_F[5]==0)//5���
                    {
                        dSetSpritePosition("T2_3",0.0,1460.0);//����3
                        dSetSpritePosition("T2_4",85.0,86.0);//λ��85.0,86.0
                        GC_F[5]=1;
                    }
                    if(g_GCTime >= 6 && GC_F[6]==0)//6���
                    {
                        dSetSpritePosition("T2_4",0.0,1460.0);//����4
                        dSetSpritePosition("T2_5",98.0,86.0);//λ��98.0,86.0
                        GC_F[6]=1;
                    }
                    if(g_GCTime >= 7 &&GC_F[7]==0)//4���
                    {
                        dSetSpritePosition("T2_1",0.0,1460.0);//����1
                        dSetSpritePosition("T2_6",-249.0,-215.0);//6λ��-249.0,-215.0
                        GC_F[7]=1;
                    }
                    if(g_GCTime >= 8 &&GC_F[8]==0)//5���
                    {
                        dSetSpritePosition("T2_6",0.0,1460.0);//����6
                        dSetSpritePosition("T2_7",-267.0,-215.0);//λ��-267.0,-215.0
                        GC_F[8]=1;
                    }
                    if(g_GCTime >= 9 && GC_F[9]==0)//6���
                    {
                        dSetSpritePosition("T2_7",0.0,1460.0);//����7
                        dSetSpritePosition("T2_8",-333.0,-215.0);//λ��-333.0,-215.0
                        GC_F[9]=1;
                    }
                    g_isLoadGC1 = 0;//��¼����2�Ѽ���
                }
                break;
            }
        case 3:
            {
                //�Ի���ʼ
                //ȷ������һĻ
                if(ID == 1)
                {//����ʱ�ĶԻ�
                    GC_time = 8;
                    //��λ
                    if(g_GCTime>=2&&GC_F[2]==0)//2���
                    {
                        dSetSpritePosition("T1_1",61.0,86.0);//λ��61.0,86.0
                        GC_F[2]=1;
                    }
                    if(g_GCTime>=3&&GC_F[3]==0)//3���
                    {
                        dSetSpritePosition("T1_2",74.0,115.0);//λ��74.0,115.0
                        GC_F[3]=1;
                    }
                    if(g_GCTime>=4&&GC_F[4]==0)//4���
                    {
                        dSetSpritePosition("T1_3",50.0,144.0);//λ��50.0��144.0
                        GC_F[4]=1;
                    }
                    if(g_GCTime>=5&&GC_F[5]==0)//5���
                    {
                        dSetSpritePosition("T1_1",0.0,1460.0);//����1
                        dSetSpritePosition("T1_2",0.0,1460.0);//����2
                        dSetSpritePosition("T1_3",0.0,1460.0);//����3
                        dSetSpritePosition("T1_4",99.0,86.0);//λ��99.0��86.0
                        GC_F[5]=1;
                    }
                    if(g_GCTime>=6&&GC_F[6]==0)//6���
                    {
                        dSetSpritePosition("T1_5",-206.0,-215.0);//λ��-206.0��-215.0
                        GC_F[6]=1;
                    }
                    if(g_GCTime>=7&&GC_F[7]==0)//7���
                    {
                        dSetSpritePosition("T1_4",0.0,1460.0);//����4
                        dSetSpritePosition("T1_6",127.0,86.0);//λ��127.0��86.0
                        GC_F[7]=1;
                    }
                    if(g_GCTime>=8&&GC_F[8]==0)//8���
                    {
                        dSetSpritePosition("T1_6",0.0,1460.0);//����6
                        dSetSpritePosition("T1_7",75.0,86.0);//λ��75.0��86.0
                        GC_F[8]=1;
                    }
                    g_isLoadGC = 0;//��¼�����Ѽ���
                }
                else
                {//��ɱ�ĶԻ�
                    GC_time = 7;
                    //��λ
                    if(g_GCTime>=2&&GC_F[2]==0)//2���
                    {
                        dSetSpritePosition("T2_1",25.0,86.0);//λ��25.0,86.0
                        GC_F[2]=1;
                    }
                    if(g_GCTime>=3&&GC_F[3]==0)//3���
                    {
                        dSetSpritePosition("T2_1",0.0,1460.0);//����1
                        dSetSpritePosition("T2_2",51.0,86.0); //λ��51.0,86.0
                        GC_F[3]=1;
                    }
                    if(g_GCTime>=4&&GC_F[4]==0)//4���
                    {
                        dSetSpritePosition("T2_2",0.0,1460.0);//����2
                        dSetSpritePosition("T2_3",63.0,86.0);//λ��63.0,86.0
                        GC_F[4]=1;
                    }
                    if(g_GCTime>=5&&GC_F[5]==0)//5���
                    {
                        dSetSpritePosition("T2_4",3.50,115.0);//λ��3.50,115.0
                        GC_F[5]=1;
                    }
                    if(g_GCTime >= 6 && GC_F[6]==0)//6���
                    {
                        dSetSpritePosition("T2_5",-370.0,-215.0);//λ��-370.0,-215.0
                        GC_F[6]=1;
                    }
                    if(g_GCTime >= 7 &&GC_F[7]==0)//4���
                    {
                        dSetSpritePosition("T2_5",0.0,1460.0);//����5
                        dSetSpritePosition("T2_6",-252.0,-215.0);//6λ��-252.0,-215.0
                        GC_F[7]=1;
                    }
                    g_isLoadGC1 = 0;//��¼����2�Ѽ���
                }
                break;
            }
        case 4:
            {
                //�Ի���ʼ
                //ȷ������һĻ
                if(ID == 1)
                {//����ʱ�ĶԻ�
                    GC_time = 7;
                    //��λ
                    if(g_GCTime>=2&&GC_F[2]==0)//2���
                    {
                        dSetSpritePosition("T1_1",124.0,86.0);//λ��124.0,86.0
                        GC_F[2]=1;
                    }
                    if(g_GCTime>=3&&GC_F[3]==0)//3���
                    {
                        dSetSpritePosition("T1_2",-280.0,-215.0);//λ��-280.0,-215.0
                        GC_F[3]=1;
                    }
                    if(g_GCTime>=4&&GC_F[4]==0)//4���
                    {
                        dSetSpritePosition("T1_1",0.0,1460.0);//����1
                        dSetSpritePosition("T1_3",111.5,86.0);//λ��111.5��86.0
                        GC_F[4]=1;
                    }
                    if(g_GCTime>=5&&GC_F[5]==0)//5���
                    {
                        dSetSpritePosition("T1_3",0.0,1460.0);//����3
                        dSetSpritePosition("T1_4",81.0,86.0);//λ��81.0��86.0
                        GC_F[5]=1;
                    }
                    if(g_GCTime>=6&&GC_F[6]==0)//6���
                    {
                        dSetSpritePosition("T1_5",178.5,112.5);//λ��178.5��112.5
                        GC_F[6]=1;
                    }
                    if(g_GCTime>=7&&GC_F[7]==0)//7���
                    {
                        dSetSpritePosition("T1_2",0.0,1460.0);//����2
                        dSetSpritePosition("T1_6",-290.0,-215.0);//λ��-290.0��-215.0
                        GC_F[7]=1;
                    }
                    g_isLoadGC = 0;//��¼�����Ѽ���
                }
                else
                {//��ɱ�ĶԻ�
                    GC_time = 4;
                    //��λ
                    if(g_GCTime>=2&&GC_F[2]==0)//2���
                    {
                        dSetSpritePosition("T2_1",111.0,86.0);//λ��111.0,86.0
                        GC_F[2]=1;
                    }
                    if(g_GCTime>=3&&GC_F[3]==0)//3���
                    {
                        dSetSpritePosition("T2_2",90.0,115.0); //λ��90.0,115.0
                        GC_F[3]=1;
                    }
                    if(g_GCTime>=4&&GC_F[4]==0)//4���
                    {
                        dSetSpritePosition("T2_2",0.0,1460.0);//����2
                        dSetSpritePosition("T2_3",-298.0,-215.0);//λ��-298.5.0,-215.0
                        GC_F[4]=1;
                    }
                    g_isLoadGC1 = 0;//��¼����2�Ѽ���
                }
                break;
            }
        case 5:
            {
                //�Ի���ʼ
                //ȷ������һĻ
                if(ID == 1)
                {//����ʱ�ĶԻ�
                    GC_time = 10;
                    //��λ
                    if(g_GCTime>=2&&GC_F[2]==0)//2���
                    {
                        dSetSpritePosition("T1_1",100.0,86.0);//λ��100.0,86.0
                        GC_F[2]=1;
                    }
                    if(g_GCTime>=3&&GC_F[3]==0)//3���
                    {
                        dSetSpritePosition("T1_2",124.0,115.0);//λ��124.0,115.0
                        GC_F[3]=1;
                    }
                    if(g_GCTime>=4&&GC_F[4]==0)//4���
                    {
                        dSetSpritePosition("T1_3",-210.0,-215.0);//λ��-210.0��-215.0
                        GC_F[4]=1;
                    }
                    if(g_GCTime>=5&&GC_F[5]==0)//5���
                    {
                        dSetSpritePosition("T1_3",0.0,1460.0);//����3
                        dSetSpritePosition("T1_4",-290.0,-215.0);//λ��-290��-215.0
                        GC_F[5]=1;
                    }
                    if(g_GCTime>=6&&GC_F[6]==0)//6���
                    {
                        dSetSpritePosition("T1_1",0.0,1460.0);//����1
                        dSetSpritePosition("T1_2",0.0,1460.0);//����2
                        dSetSpritePosition("T1_5",100.0,86.0);//λ��100.0��86.0
                        GC_F[6]=1;
                    }
                    if(g_GCTime>=7&&GC_F[7]==0)//7���
                    {
                        dSetSpritePosition("T1_6",186.0,115.0);//λ��186.0��115.0
                        GC_F[7]=1;
                    }
                    if(g_GCTime>=8&&GC_F[8]==0)//8���
                    {
                        dSetSpritePosition("T1_7",198.0,145.0);//λ��198.0��145.0
                        GC_F[8]=1;
                    }
                    if(g_GCTime>=9&&GC_F[9]==0)//9���
                    {
                        dSetSpritePosition("T1_8",175.0,175.0);//λ��175.0��175.0
                        GC_F[9]=1;
                    }
                    if(g_GCTime>=10&&GC_F[10]==0)//10���
                    {
                        dSetSpritePosition("T1_9",210.0,205.0);//λ��210.0��205.0
                        GC_F[10]=1;
                    }
                    g_isLoadGC = 0;//��¼�����Ѽ���
                }
                else
                {//��ɱ�ĶԻ�
                    GC_time = 6;
                    //��λ
                    if(g_GCTime>=2&&GC_F[2]==0)//2���
                    {
                        dSetSpritePosition("T2_1",-295.0,-215.0);//λ��-295.0,-215.0
                        GC_F[2]=1;
                    }
                    if(g_GCTime>=3&&GC_F[3]==0)//3���
                    {
                        dSetSpritePosition("T2_1",0.0,1460.0);//����2
                        dSetSpritePosition("T2_2",-287.0,-215.0); //λ��-287.0,-215.0
                        GC_F[3]=1;
                    }
                    if(g_GCTime>=4&&GC_F[4]==0)//4���
                    {
                        dSetSpritePosition("T2_3",100.0,86.0);//λ��100.0,86.0
                        GC_F[4]=1;
                    }
                    if(g_GCTime>=5&&GC_F[5]==0)//5���
                    {
                        dSetSpritePosition("T2_4",161.0,115.0);//λ��161.0,115.0
                        GC_F[5]=1;
                    }
                    if(g_GCTime>=6&&GC_F[6]==0)//6���
                    {
                        dSetSpritePosition("T2_5",153.5,145.0);//λ��153.5,145.0
                        GC_F[6]=1;
                    }
                    g_isLoadGC1 = 0;//��¼����2�Ѽ���
                }
                break;
            }
        case 6:
            {
                //�Ի���ʼ
                //ȷ������һĻ
                if(ID == 1)
                {//����ʱ�ĶԻ�
                    GC_time = 3;
                    //��λ
                    if(g_GCTime>=2&&GC_F[2]==0)//2���
                    {
                        dSetSpritePosition("T1_1",-171.5,-215.0);//λ��-171.5,-215.0
                        GC_F[2]=1;
                    }
                    if(g_GCTime>=3&&GC_F[3]==0)//3���
                    {
                        dSetSpritePosition("T1_2",150.0,86.0);//λ��150.0,86.0
                        GC_F[3]=1;
                    }
                    g_isLoadGC = 0;//��¼�����Ѽ���
                }
                else
                {//��ɱ�ĶԻ�
                    GC_time = 9;
                    //��λ
                    if(g_GCTime>=2&&GC_F[2]==0)//2���
                    {
                        dSetSpritePosition("T2_1",-345.0,-215.0);//λ��-345.0,-215.0
                        GC_F[2]=1;
                    }
                    if(g_GCTime>=3&&GC_F[3]==0)//3���
                    {
                        dSetSpritePosition("T2_1",0.0,1460.0);//����1
                        dSetSpritePosition("T2_2",-226.0,-215.0); //λ��-226.0,-215.0
                        GC_F[3]=1;
                    }
                    if(g_GCTime>=4&&GC_F[4]==0)//4���
                    {
                        dSetSpritePosition("T2_3",157.5,86.0);//λ��157.5,86.0
                        GC_F[4]=1;
                    }
                    if(g_GCTime>=5&&GC_F[5]==0)//5���
                    {
                        dSetSpritePosition("T2_3",0.0,1460.0);//����3
                        dSetSpritePosition("T2_4",89.0,86.0);//λ��89.0,86.0
                        GC_F[5]=1;
                    }
                    if(g_GCTime>=6&&GC_F[6]==0)//6���
                    {
                        dSetSpritePosition("T2_4",0.0,1460.0);//����3
                        dSetSpritePosition("T2_5",130.0,86.0);//λ��130.0,86.0
                        GC_F[6]=1;
                    }
                    if(g_GCTime>=7&&GC_F[7]==0)//7���
                    {
                        dSetSpritePosition("T2_5",0.0,1460.0);//����3
                        dSetSpritePosition("T2_6",166.0,86.0);//λ��89.0,86.0
                        GC_F[7]=1;
                    }
                    if(g_GCTime>=8&&GC_F[8]==0)//8���
                    {
                        dSetSpritePosition("T2_6",0.0,1460.0);//����3
                        dSetSpritePosition("T2_7",106.0,86.0);//λ��106.0,86.0
                        GC_F[8]=1;
                    }
                    if(g_GCTime>=9&&GC_F[9]==0)//9���
                    {
                        dSetSpritePosition("T2_2",0.0,1460.0);//����2
                        dSetSpritePosition("T2_8",-189.0,-215.0);//λ��-189.0,-215.0
                        GC_F[9]=1;
                    }
                    g_isLoadGC1 = 0;//��¼����2�Ѽ���
                }
                break;
            }
        case 7:
            {
                //�Ի���ʼ
                //ȷ������һĻ
                if(ID == 1)
                {//����ʱ�ĶԻ�
                    GC_time = 3;
                    //��λ
                    if(g_GCTime>=2&&GC_F[2]==0)//2���
                    {
                        dSetSpritePosition("T1_1",-250.0,-215.0);//λ��-250,-215.0
                        GC_F[2]=1;
                    }
                    if(g_GCTime>=3&&GC_F[3]==0)//3���
                    {
                        dSetSpritePosition("T1_2",96.0,86.0);//λ��96.0,86.0
                        GC_F[3]=1;
                    }
                    g_isLoadGC = 0;//��¼�����Ѽ���
                }
                else
                {//��ɱ�ĶԻ�
                    GC_time = 5;
                    //��λ
                    if(g_GCTime>=2&&GC_F[2]==0)//2���
                    {
                        dSetSpritePosition("T2_1",72.0,86.0);//λ��72.0,86.0
                        GC_F[2]=1;
                    }
                    if(g_GCTime>=3&&GC_F[3]==0)//3���
                    {
                        dSetSpritePosition("T2_2",-172.0,-215.0); //λ��-172.0,-215.0
                        GC_F[3]=1;
                    }
                    if(g_GCTime>=4&&GC_F[4]==0)//4���
                    {
                        dSetSpritePosition("T2_2",0.0,1460.0);//����3
                        dSetSpritePosition("T2_3",-177.0,-215.0);//λ��-177.0,-215.0
                        GC_F[4]=1;
                    }
                    if(g_GCTime>=5&&GC_F[5]==0)//5���
                    {
                        dSetSpritePosition("T2_3",0.0,1460.0);//����3
                        dSetSpritePosition("T2_4",-282.50,-215.0);//λ��-282.50,-215.0
                        GC_F[5]=1;
                    }
                    g_isLoadGC1 = 0;//��¼����2�Ѽ���
                }
                break;
            }
        case 8:
            {
                //�Ի���ʼ
                //ȷ������һĻ
                if(ID == 1)
                {//����ʱ�ĶԻ�
                    GC_time = 3;
                    //��λ
                    if(g_GCTime>=2&&GC_F[2]==0)//2���
                    {
                        dSetSpritePosition("T1_1",-250.0,-215.0);//λ��-250,-215
                        GC_F[2]=1;
                    }
                    if(g_GCTime>=3&&GC_F[3]==0)//3���
                    {
                        dSetSpritePosition("T1_2",181.0,86.0);//λ��181.0,86.0
                        GC_F[3]=1;
                    }
                    g_isLoadGC = 0;//��¼�����Ѽ���
                }
                else
                {//��ɱ�ĶԻ�
                    GC_time = 7;
                    //��λ
                    if(g_GCTime>=2&&GC_F[2]==0)//2���
                    {
                        dSetSpritePosition("T2_1",67.0,86.0);//λ��67.0,86.0
                        GC_F[2]=1;
                    }
                    if(g_GCTime>=3&&GC_F[3]==0)//3���
                    {
                        dSetSpritePosition("T2_1",0.0,1460.0);//����1
                        dSetSpritePosition("T2_2",172.0,86.0); //λ��-226.0,-215.0
                        GC_F[3]=1;
                    }
                    if(g_GCTime>=4&&GC_F[4]==0)//4���
                    {
                        dSetSpritePosition("T2_2",0.0,1460.0);//����2
                        dSetSpritePosition("T2_3",158.5,86.0);//λ��158.5,86.0
                        GC_F[4]=1;
                    }
                    if(g_GCTime>=5&&GC_F[5]==0)//5���
                    {
                        dSetSpritePosition("T2_3",0.0,1460.0);//����3
                        dSetSpritePosition("T2_4",150.0,86.0);//λ��150.0,86.0
                        GC_F[5]=1;
                    }
                    if(g_GCTime>=6&&GC_F[6]==0)//6���
                    {
                        dSetSpritePosition("T2_5",-306.0,-215.0);//λ��-306,-215.0
                        GC_F[6]=1;
                    }
                    if(g_GCTime>=7&&GC_F[7]==0)//7���
                    {
                        dSetSpritePosition("T2_5",0.0,1460.0);//����5
                        dSetSpritePosition("T2_6",-196.0,-215.0);//λ��-196.0,-215.0
                        GC_F[7]=1;
                    }
                    g_isLoadGC1 = 0;//��¼����2�Ѽ���
                }
                break;
            }
        case 9:
            {
                //�Ի���ʼ
                //ȷ������һĻ
                if(ID == 1)
                {//����ʱ�ĶԻ�
                    GC_time = 8;
                    //��λ
                    if(g_GCTime>=2&&GC_F[2]==0)//2���
                    {
                        dSetSpritePosition("T1_1",97.0,86.0);//λ��97.0,86.0
                        GC_F[2]=1;
                    }
                    if(g_GCTime>=3&&GC_F[3]==0)//3���
                    {
                        dSetSpritePosition("T1_2",200.0,115.0);//λ��200.0,115.0
                        GC_F[3]=1;
                    }
                    if(g_GCTime>=4&&GC_F[4]==0)//4���
                    {
                        dSetSpritePosition("T1_1",0.0,1460.0);//����1
                        dSetSpritePosition("T1_2",0.0,1460.0);//����2
                        dSetSpritePosition("T1_3",173.0,86.0);//λ��173.0,86.0
                        GC_F[4]=1;
                    }
                    if(g_GCTime>=5&&GC_F[5]==0)//5���
                    {
                        dSetSpritePosition("T1_4",-270.0,-215.0);//λ��-270.0,-215.0
                        GC_F[5]=1;
                    }
                    if(g_GCTime>=6 &&GC_F[6]==0)//6���
                    {
                        dSetSpritePosition("T1_3",0.0,1460.0);//����3
                        dSetSpritePosition("T1_5",171.5,86.0);//λ��171.5,86.0
                        GC_F[6]=1;
                    }
                    if(g_GCTime>=7 && GC_F[7]==0)//7���
                    {
                        dSetSpritePosition("T1_4",0.0,1460.0);//����4
                        dSetSpritePosition("T1_6",-260.0,-215.0);//λ��-260.0,-215.0
                        GC_F[7]=1;
                    }
                    if(g_GCTime>=8 && GC_F[8]==0)//8���
                    {
                        dSetSpritePosition("T1_6",0.0,1460.0);//����6
                        dSetSpritePosition("T1_7",-330.0,-215.0);//λ��-330.0,-215.0
                        GC_F[8]=1;
                    }
                    g_isLoadGC = 0;//��¼�����Ѽ���
                }
                else
                {//��ɱ�ĶԻ�
                    GC_time = 2;
                    //��λ
                    if(g_GCTime>=2&&GC_F[2]==0)//2���
                    {
                        dSetSpritePosition("T2_1",-203.5,-215.0);//λ��67.0,86.0
                        GC_F[2]=1;
                    }
                    g_isLoadGC1 = 0;//��¼����2�Ѽ���
                }
                break;
            }
        default:
            break;
    }
    if(g_GCTime >= GC_time + 2 && GC_F[19]==0)//9���
    {
        //��������
        //�ƶ�
        dSetSpritePosition("GC_huimu",0.0,1460.0);//�ƶ���Ļ
        dSetSpritePosition("GC_Talk1",0.0,1460.0);//�ƶ��Ի���
        dSetSpritePosition("GC_Talk2",0.0,1460.0);//�ƶ��Ի���
        dSetSpritePosition("T1_1",0.0,1460.0);//�ƶ�����
        dSetSpritePosition("T1_2",0.0,1460.0);//�ƶ�����
        dSetSpritePosition("T1_3",0.0,1460.0);//�ƶ�����
        dSetSpritePosition("T1_4",0.0,1460.0);//�ƶ�����
        dSetSpritePosition("T1_5",0.0,1460.0);//�ƶ�����
        dSetSpritePosition("T1_6",0.0,1460.0);//�ƶ�����
        dSetSpritePosition("T1_7",0.0,1460.0);//�ƶ�����
        dSetSpritePosition("T1_8",0.0,1460.0);//�ƶ�����
        dSetSpritePosition("T1_9",0.0,1460.0);//�ƶ�����
        dSetSpritePosition("T2_1",0.0,1460.0);//�ƶ�����
        dSetSpritePosition("T2_2",0.0,1460.0);//�ƶ�����
        dSetSpritePosition("T2_3",0.0,1460.0);//�ƶ�����
        dSetSpritePosition("T2_4",0.0,1460.0);//�ƶ�����
        dSetSpritePosition("T2_5",0.0,1460.0);//�ƶ�����
        dSetSpritePosition("T2_6",0.0,1460.0);//�ƶ�����
        dSetSpritePosition("T2_7",0.0,1460.0);//�ƶ�����
        dSetSpritePosition("T2_8",0.0,1460.0);//�ƶ�����
        dSetSpritePosition("T2_9",0.0,1460.0);//�ƶ�����
        //���µ�ͼ���
        g_WhichMap = g_WhichGq+2;
        GC_F[19]=1;
        if(ID == 2)//����Boss����Ч��
        {
            // ��̬��ʾ��ʤ��ť
            dSetSpritePosition("victory",0,-800);
            dSpriteMoveTo("victory",0,0,g_MenuSpeed,1);
            //dSetSpritePosition("victory",0,0);
            //���µ�ͼ���
            g_WhichMap = -2;
        }
    }
}

