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

/////////////////////////////////////////////////////////////////////////////////
//
// 游戏总管类。负责处理游戏主循环、游戏初始化、结束等工作
class	CGameMain
{
private:
	int				m_iGameState;				// 游戏状态，0：结束或者等待开始；1：初始化；2：游戏进行中


public:
	CGameMain();            //构造函数
	~CGameMain();           //析构函数  

	// Get方法
	int				GetGameState()											{ return m_iGameState; }
	
	// Set方法
	void			SetGameState( const int iState )				{ m_iGameState	=	iState; }
	
	// 游戏主循环等
	void			GameMainLoop( float	fDeltaTime );
	void			GameInit();
	void			GameRun( float fDeltaTime );
	void			GameEnd();
	void 			OnMouseMove( const float fMouseX, const float fMouseY );
	void 			OnMouseClick( const int iMouseType, const float fMouseX, const float fMouseY );
	void 			OnMouseUp( const int iMouseType, const float fMouseX, const float fMouseY );
	void 			OnKeyDown( const int iKey, const bool bAltPress, const bool bShiftPress, const bool bCtrlPress );
	void 			OnKeyUp( const int iKey );
	void 			OnSpriteColSprite( const char *szSrcName, const char *szTarName );
	void 			OnSpriteColWorldLimit( const char *szName, const int iColSide );
};



/////////////////////////////////////////////////////////////////////////////////
// 
extern CGameMain	g_GameMain;






/*
 * @brief 这是一个 对象类	基类(obj)
 *一切在屏幕上有显示的精灵都会对应一个对象类
 *        
 * @author	孙国庆
 * @date 2024-07-29
 */
class object{
public:
	object(){}
	~object(){}
private:
	CSprite *	spritePtr			;			//物理精灵属性
};






//---------------------------------------------------------------------------------------

/*
 * @brief 这是一个 实体类
 * 继承自obj，一切在游戏中有物理碰撞的对象都是一个实体类对象
 *        
 * @author	孙国庆
 * @date 2024-07-29
 */
class Entity:public object{

};



/*
 * @brief 这是一个 非实体类
 * 继承自obj，一切在游戏中有无物理碰撞的对象都是一个非实体类对象
 *        
 * @author	孙国庆
 * @date 2024-07-29
 */
class NonEntity:public object{






};
//---------------------------------------------------------------------------------------




/*
 * @brief 这是一个 静态实体类
 * 继承自Eitity，一在游戏中 不能 移动的实体都是一个静态实体类对象
 *        
 * @author	孙国庆
 * @date 2024-07-29
 */
class StaticEntity:public Entity{


};


/*
 * @brief 这是一个 动态实体类
 * 继承自Eitity，一在游戏中 能移动 的实体都是一个动态实体类对象
 *        
 * @author	孙国庆
 * @date 2024-07-29
 */
class DynamicEntity:public Entity{


};






/*
 * @brief 这是一个 DynamicNPC类
 * 继承自 DynamicEntity，一在游戏中 由程序控制的 动态实体类都是一个DynamicNPC类
 *        
 * @author	孙国庆
 * @date 2024-07-29
 */
class DynamicNPC:public DynamicEntity{


};





/*
 * @brief 这是一个 PlayerCharacter类
 * 继承自 DynamicEntity，一在游戏中 有玩家控制的 动态实体类都是一个PlayerCharacter类
 *        
 * @author	孙国庆
 * @date 2024-07-29
 */
class PlayerCharacter:public DynamicEntity{


};





/*
 * @brief 这是一个 InteractiveBlock类
 * 继承自 StaticEntity，可以交互的静态实体类都是一个 InteractiveBlock 类
 *        
 * @author	孙国庆
 * @date 2024-07-29
 */
class InteractiveBlock:public StaticEntity{


};





/*
 * @brief 这是一个 NonInteractiveBlock类
 * 继承自 StaticEntity，不可以交互的静态实体类都是一个 NonInteractiveBlock 类
 *        
 * @author	孙国庆
 * @date 2024-07-29
 */
class NonInteractiveBlock:public StaticEntity{


};

#endif // _LESSON_X_H_