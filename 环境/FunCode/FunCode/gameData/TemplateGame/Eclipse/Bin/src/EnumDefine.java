/**
 * @(#)EnumDefine.java
 *
 *
 * @author
 * @version 1.00
 */

public class EnumDefine
{
	/////////////////////////////////////////////////////////////////////////////////
	//
	// Sprite精灵与世界边界碰撞响应定义( 碰撞之后API OnSpriteColWorldLimit 将被调用 )
	//enum EWorldLimit
	public static final int WORLD_LIMIT_OFF = 0;		// 关闭与世界边界的碰撞
	public static final int WORLD_LIMIT_NULL = 1;		// 碰撞之后引擎不做任何处理，由各游戏自己处理响应
	public static final int WORLD_LIMIT_RIGID = 2;		// 刚性物理碰撞反应
	public static final int WORLD_LIMIT_BOUNCE = 3;		// 反弹模式
	public static final int WORLD_LIMIT_CLAMP = 4;		// 小幅反弹，逐渐停止模式(比如篮球落地)
	public static final int WORLD_LIMIT_STICKY = 5;		// 碰撞之后静止
	public static final int WORLD_LIMIT_KILL = 6;		// 碰撞之后精灵将被删除
	public static final int WORLD_LIMIT_INVALID = 7;	//	无效值


	/////////////////////////////////////////////////////////////////////////////////
	//
	/// 精灵与精灵之间、精灵与地图中其它精灵之间的碰撞响应( 碰撞之后API OnSpriteColSprite 将被调用 )
	// enum ECollisionResponse
	public static final int COL_RESPONSE_OFF = 0;		//	关闭碰撞响应(不调用OnSpriteColSprite)
	public static final int COL_RESPONSE_RIGID = 1;		//	刚性物理碰撞响应
	public static final int COL_RESPONSE_BOUNCE = 2;	//	反弹模式
	public static final int COL_RESPONSE_CLAMP = 3;		//	小幅反弹，逐渐停止模式(比如篮球落地)
	public static final int COL_RESPONSE_STICKY = 4;	//	碰撞之后静止
	public static final int COL_RESPONSE_KILL = 5;		//	碰撞之后精灵将被删除
	public static final int COL_RESPONSE_CUSTOM = 6;	//	碰撞之后引擎不做任何处理，由各游戏自己处理响应
	public static final int COL_RESPONSE_INVALID = 7;	//	无效值


	///////////////////////////////////////////////////////////////////////////////////
	//
	// 鼠标按键值定义
	// enum MouseTypes
	public static final int MOUSE_LEFT = 0;				// 左键
	public static final int MOUSE_RIGHT = 1;			// 右键
	public static final int MOUSE_MIDDLE = 2;			// 中键


	/////////////////////////////////////////////////////////////////////////////////
	//
	// 键盘KEY值定义
	// enum KeyCodes
	public static final int KEY_NULL          = 0x000;     ///< Invalid KeyCode
	public static final int KEY_BACKSPACE     = 0x001;
	public static final int KEY_TAB           = 0x002;
	public static final int KEY_ENTER         = 0x003;
	public static final int KEY_CONTROL       = 0x004;
	public static final int KEY_ALT           = 0x005;
	public static final int KEY_SHIFT         = 0x006;
	public static final int KEY_PAUSE         = 0x007;
	public static final int KEY_CAPSLOCK      = 0x008;
	public static final int KEY_ESCAPE        = 0x009;
	public static final int KEY_SPACE         = 0x00a;
	public static final int KEY_PAGE_DOWN     = 0x00b;
	public static final int KEY_PAGE_UP       = 0x00c;
	public static final int KEY_END           = 0x00d;
	public static final int KEY_HOME          = 0x00e;
	public static final int KEY_LEFT          = 0x00f;
	public static final int KEY_UP            = 0x010;
	public static final int KEY_RIGHT         = 0x011;
	public static final int KEY_DOWN          = 0x012;
	public static final int KEY_PRINT         = 0x013;
	public static final int KEY_INSERT        = 0x014;
	public static final int KEY_DELETE        = 0x015;
	public static final int KEY_HELP          = 0x016;

	public static final int KEY_0             = 0x017;
	public static final int KEY_1             = 0x018;
	public static final int KEY_2             = 0x019;
	public static final int KEY_3             = 0x01a;
	public static final int KEY_4             = 0x01b;
	public static final int KEY_5             = 0x01c;
	public static final int KEY_6             = 0x01d;
	public static final int KEY_7             = 0x01e;
	public static final int KEY_8             = 0x01f;
	public static final int KEY_9             = 0x020;

	public static final int KEY_A             = 0x021;
	public static final int KEY_B             = 0x022;
	public static final int KEY_C             = 0x023;
	public static final int KEY_D             = 0x024;
	public static final int KEY_E             = 0x025;
	public static final int KEY_F             = 0x026;
	public static final int KEY_G             = 0x027;
	public static final int KEY_H             = 0x028;
	public static final int KEY_I             = 0x029;
	public static final int KEY_J             = 0x02a;
	public static final int KEY_K             = 0x02b;
	public static final int KEY_L             = 0x02c;
	public static final int KEY_M             = 0x02d;
	public static final int KEY_N             = 0x02e;
	public static final int KEY_O             = 0x02f;
	public static final int KEY_P             = 0x030;
	public static final int KEY_Q             = 0x031;
	public static final int KEY_R             = 0x032;
	public static final int KEY_S             = 0x033;
	public static final int KEY_T             = 0x034;
	public static final int KEY_U             = 0x035;
	public static final int KEY_V             = 0x036;
	public static final int KEY_W             = 0x037;
	public static final int KEY_X             = 0x038;
	public static final int KEY_Y             = 0x039;
	public static final int KEY_Z             = 0x03a;

	public static final int KEY_TILDE         = 0x03b;
	public static final int KEY_MINUS         = 0x03c;
	public static final int KEY_EQUALS        = 0x03d;
	public static final int KEY_LBRACKET      = 0x03e;
	public static final int KEY_RBRACKET      = 0x03f;
	public static final int KEY_BACKSLASH     = 0x040;
	public static final int KEY_SEMICOLON     = 0x041;
	public static final int KEY_APOSTROPHE    = 0x042;
	public static final int KEY_COMMA         = 0x043;
	public static final int KEY_PERIOD        = 0x044;
	public static final int KEY_SLASH         = 0x045;
	public static final int KEY_NUMPAD0       = 0x046;
	public static final int KEY_NUMPAD1       = 0x047;
	public static final int KEY_NUMPAD2       = 0x048;
	public static final int KEY_NUMPAD3       = 0x049;
	public static final int KEY_NUMPAD4       = 0x04a;
	public static final int KEY_NUMPAD5       = 0x04b;
	public static final int KEY_NUMPAD6       = 0x04c;
	public static final int KEY_NUMPAD7       = 0x04d;
	public static final int KEY_NUMPAD8       = 0x04e;
	public static final int KEY_NUMPAD9       = 0x04f;
	public static final int KEY_MULTIPLY      = 0x050;
	public static final int KEY_ADD           = 0x051;
	public static final int KEY_SEPARATOR     = 0x052;
	public static final int KEY_SUBTRACT      = 0x053;
	public static final int KEY_DECIMAL       = 0x054;
	public static final int KEY_DIVIDE        = 0x055;
	public static final int KEY_NUMPADENTER   = 0x056;

	public static final int KEY_F1            = 0x057;
	public static final int KEY_F2            = 0x058;
	public static final int KEY_F3            = 0x059;
	public static final int KEY_F4            = 0x05a;
	public static final int KEY_F5            = 0x05b;
	public static final int KEY_F6            = 0x05c;
	public static final int KEY_F7            = 0x05d;
	public static final int KEY_F8            = 0x05e;
	public static final int KEY_F9            = 0x05f;
	public static final int KEY_F10           = 0x060;
	public static final int KEY_F11           = 0x061;
	public static final int KEY_F12           = 0x062;
	public static final int KEY_F13           = 0x063;
	public static final int KEY_F14           = 0x064;
	public static final int KEY_F15           = 0x065;
	public static final int KEY_F16           = 0x066;
	public static final int KEY_F17           = 0x067;
	public static final int KEY_F18           = 0x068;
	public static final int KEY_F19           = 0x069;
	public static final int KEY_F20           = 0x06a;
	public static final int KEY_F21           = 0x06b;
	public static final int KEY_F22           = 0x06c;
	public static final int KEY_F23           = 0x06d;
	public static final int KEY_F24           = 0x06e;

	public static final int KEY_NUMLOCK       = 0x06f;
	public static final int KEY_SCROLLLOCK    = 0x070;
	public static final int KEY_LCONTROL      = 0x071;
	public static final int KEY_RCONTROL      = 0x072;
	public static final int KEY_LALT          = 0x073;
	public static final int KEY_RALT          = 0x074;
	public static final int KEY_LSHIFT        = 0x075;
	public static final int KEY_RSHIFT        = 0x076;
	public static final int KEY_WIN_LWINDOW   = 0x077;
	public static final int KEY_WIN_RWINDOW   = 0x078;
	public static final int KEY_WIN_APPS      = 0x079;
	public static final int KEY_OEM_102       = 0x080;

	public static final int KEY_MAC_OPT       = 0x090;
	public static final int KEY_MAC_LOPT      = 0x091;
	public static final int KEY_MAC_ROPT      = 0x092;

	public static final int KEY_BUTTON0       = 0x0100;
	public static final int KEY_BUTTON1       = 0x0101;
	public static final int KEY_BUTTON2       = 0x0102;
	public static final int KEY_BUTTON3       = 0x0103;
	public static final int KEY_BUTTON4       = 0x0104;
	public static final int KEY_BUTTON5       = 0x0105;
	public static final int KEY_BUTTON6       = 0x0106;
	public static final int KEY_BUTTON7       = 0x0107;
	public static final int KEY_BUTTON8       = 0x0108;
	public static final int KEY_BUTTON9       = 0x0109;
	public static final int KEY_BUTTON10      = 0x010A;
	public static final int KEY_BUTTON11      = 0x010B;
	public static final int KEY_BUTTON12      = 0x010C;
	public static final int KEY_BUTTON13      = 0x010D;
	public static final int KEY_BUTTON14      = 0x010E;
	public static final int KEY_BUTTON15      = 0x010F;
	public static final int KEY_BUTTON16      = 0x0110;
	public static final int KEY_BUTTON17      = 0x0111;
	public static final int KEY_BUTTON18      = 0x0112;
	public static final int KEY_BUTTON19      = 0x0113;
	public static final int KEY_BUTTON20      = 0x0114;
	public static final int KEY_BUTTON21      = 0x0115;
	public static final int KEY_BUTTON22      = 0x0116;
	public static final int KEY_BUTTON23      = 0x0117;
	public static final int KEY_BUTTON24      = 0x0118;
	public static final int KEY_BUTTON25      = 0x0119;
	public static final int KEY_BUTTON26      = 0x011A;
	public static final int KEY_BUTTON27      = 0x011B;
	public static final int KEY_BUTTON28      = 0x011C;
	public static final int KEY_BUTTON29      = 0x011D;
	public static final int KEY_BUTTON30      = 0x011E;
	public static final int KEY_BUTTON31      = 0x011F;
	public static final int KEY_ANYKEY        = 0xfffe;
};


