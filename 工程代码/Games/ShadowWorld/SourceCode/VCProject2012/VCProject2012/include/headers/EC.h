
#define WIN    // (   CONSOLE   /   WIN    )

//修改此处



















				//此处禁止修改

//////////////////////////////////////////////////
#ifdef CONSOLE									//
#pragma comment(linker, "/SUBSYSTEM:CONSOLE")	//
#else											//
#pragma comment(linker, "/SUBSYSTEM:WINDOWS")	//
#endif											//
//////////////////////////////////////////////////