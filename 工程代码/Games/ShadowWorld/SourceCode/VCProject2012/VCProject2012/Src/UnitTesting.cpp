#include "EC.h"//  ����
#ifdef CONSOLE//
//=============




#include <iostream>
#include "headers\BagSystem.h"
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
  std::cout << "�������� 1: ������Ӻ��Ƴ�����" << std::endl;
    Inventory inventory(5, 5); // ����һ��5x5�ı���

    inventory.addItem(1, 10);
    inventory.addItem(2, 50);
    inventory.addItem(1, 60); // ������ƷID 1
    inventory.printInventory();

    inventory.removeItem(1, 20); // �ӱ�����ȡ����ƷID 1
    inventory.printInventory();

    std::cout << "�������� 2: �߽����" << std::endl;
    Inventory smallInventory(2, 2); // ����һ��2x2��С����

    smallInventory.addItem(1, 30);
    smallInventory.addItem(2, 30);
    smallInventory.addItem(1, 40); // ������ӳ���������������Ʒ
    smallInventory.printInventory();

    std::cout << "�������� 3: �ղۺ�����Ʒ���" << std::endl;
    Inventory emptyInventory(5, 5); // ����һ��5x5�Ŀձ���

    emptyInventory.addItem(3, 30);
    emptyInventory.printInventory();

    emptyInventory.removeItem(4, 10); // ���Դӱ������Ƴ������ڵ���Ʒ
    emptyInventory.printInventory();

    std::cout << "�������� 4: ������Ʒ����" << std::endl;
    Inventory multiItemInventory(5, 5); // ����һ��5x5�ı���

    multiItemInventory.addItem(4, 40);
    multiItemInventory.addItem(5, 25);
    multiItemInventory.addItem(4, 30); // ������ƷID 4
    multiItemInventory.printInventory();

    std::cout << "�������� 5: ������Ƴ���ϲ���" << std::endl;
    Inventory comboInventory(5, 5); // ����һ��5x5�ı���

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