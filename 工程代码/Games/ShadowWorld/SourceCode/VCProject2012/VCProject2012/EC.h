
#define CONSOLE    // (   CONSOLE   /   WIN    )

//�޸Ĵ˴�



















				//�˴���ֹ�޸�

//////////////////////////////////////////////////
#ifdef CONSOLE									//
#pragma comment(linker, "/SUBSYSTEM:CONSOLE")	//
#else											//
#pragma comment(linker, "/SUBSYSTEM:WINDOWS")	//
#endif											//
//////////////////////////////////////////////////