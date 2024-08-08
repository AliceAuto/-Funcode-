#include "EC.h"//  ����
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
//				���ļ�Ϊ��Ԫ�������			   //
//===================================================
int main() {


	//���������ڲ����е�Ԫ����
	/*		ע��

	ʹ�õ�Ԫ����ͨ��ʱҪ�޸� "EC.h"	
	�����ļ��� �궨��Ϊ		#define	CONSOLE
	
	*/
/*//==========================================================================================================
*+			+			+ 		    +o		I	   o +			 +		   	 +			 +			 +		//
* +		  +	  +		  +	  +		  +	 o 	 	I	   o   +	   +   +	   +   +       +   +	   +   +	//
*	+	+		+	+ 		+	+	 o   \\ I //   o     +	 +	     +	 +		 +	 +		 +	 +		 +	//
*	  + 		  +			  +		 o	  \\_//	   o	   +		   +		   +		   +		   +//
//==========================================================================================================*/

	 StateMachine sm;


    // ���״̬
    sm.AddState("MainMenu", MainMenuState::CreateState());
    sm.AddState("Game", GameState::CreateState());
    sm.AddState("Settings", SettingsMenuState::CreateState());
    sm.AddState("PauseMenu", PauseMenuState::CreateState());
    sm.AddState("Exit", ExitMenuState::CreateState());

    // ���õ�ǰ״̬
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