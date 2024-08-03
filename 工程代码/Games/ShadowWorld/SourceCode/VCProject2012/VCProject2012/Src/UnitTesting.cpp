#include "EC.h"//  配置
#ifdef CONSOLE//
//=============




#include <iostream>
#include "headers\BagSystem.h"
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
  std::cout << "测试用例 1: 基础添加和移除测试" << std::endl;
    Inventory inventory(5, 5); // 创建一个5x5的背包

    inventory.addItem(1, 10);
    inventory.addItem(2, 50);
    inventory.addItem(1, 60); // 叠加物品ID 1
    inventory.printInventory();

    inventory.removeItem(1, 20); // 从背包中取出物品ID 1
    inventory.printInventory();

    std::cout << "测试用例 2: 边界测试" << std::endl;
    Inventory smallInventory(2, 2); // 创建一个2x2的小背包

    smallInventory.addItem(1, 30);
    smallInventory.addItem(2, 30);
    smallInventory.addItem(1, 40); // 尝试添加超出背包容量的物品
    smallInventory.printInventory();

    std::cout << "测试用例 3: 空槽和无物品情况" << std::endl;
    Inventory emptyInventory(5, 5); // 创建一个5x5的空背包

    emptyInventory.addItem(3, 30);
    emptyInventory.printInventory();

    emptyInventory.removeItem(4, 10); // 尝试从背包中移除不存在的物品
    emptyInventory.printInventory();

    std::cout << "测试用例 4: 多种物品测试" << std::endl;
    Inventory multiItemInventory(5, 5); // 创建一个5x5的背包

    multiItemInventory.addItem(4, 40);
    multiItemInventory.addItem(5, 25);
    multiItemInventory.addItem(4, 30); // 叠加物品ID 4
    multiItemInventory.printInventory();

    std::cout << "测试用例 5: 添加与移除组合测试" << std::endl;
    Inventory comboInventory(5, 5); // 创建一个5x5的背包

    comboInventory.addItem(6, 15);
    comboInventory.removeItem(2, 10);
    comboInventory.addItem(7, 50);
    comboInventory.removeItem(6, 10);
    comboInventory.printInventory();

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