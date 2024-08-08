#include "EC.h"//  配置
#ifdef CONSOLE//
//=============




#include <iostream>
#include "headers\EventDrivenSystem.h"
#include "CSystem.h"
#include "headers\CGameMain.h"
#include "StateMachine.h"
#include "States.h"


 // For std::auto_ptr
//===================================================
//				此文件为单元测试入口			   //
//===================================================
int main() {


	//在主函数内部进行单元测试
	/*		注意

	使用单元测试通道时要修改 "EC.h"	
	配置文件中 宏定义为		#define	CONSOLE
	
	*/
/*//==========================================================================================================
*+			+			+ 		    +o		I	   o +			 +		   	 +			 +			 +		//
* +		  +	  +		  +	  +		  +	 o 	 	I	   o   +	   +   +	   +   +       +   +	   +   +	//
*	+	+		+	+ 		+	+	 o   \\ I //   o     +	 +	     +	 +		 +	 +		 +	 +		 +	//
*	  + 		  +			  +		 o	  \\_//	   o	   +		   +		   +		   +		   +//
//==========================================================================================================*/

	 StateMachine sm;


    // 添加状态
    sm.AddState("MainMenu", MainMenuState::CreateState());
    sm.AddState("Game", GameState::CreateState());
    sm.AddState("Settings", SettingsMenuState::CreateState());
    sm.AddState("PauseMenu", PauseMenuState::CreateState());
    sm.AddState("Exit", ExitMenuState::CreateState());

    // 设置当前状态
    sm.SetCurrentState("MainMenu");

    int userChoice;
    while (true) {
        std::cin >> userChoice;
        sm.Update(userChoice);

        if (sm.GetCurrentStateName() == "Exit") {
            break;
        }
    }

    std::cout << "Exiting program." << std::endl;





/*//==========================================================================================================
*+			+			+ 		    +o	  //-\\	     o +		   +	        +		    +		    +	   //
* +		  +	  +		  +	  +		  +	 o 	 //	I \\     o   +	     +   +	      +   +	      +   +	      +	  +	   //
*	+	+		+	+ 		+	+	 o      I 	     o     +   +       +   +		+	+		+   +		+  //
*	  + 		  +			  +		 o	  	I	     o       +		   	 +			  +		      +			 + //
//==========================================================================================================*/
	system("pause"); 
    return 0;
}
#endif