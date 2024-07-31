
//set up $cmdctrl variable so that it matches OS standards
$cmdCtrl = $platform $= "macos" ? "Cmd" : "Ctrl";

function LevelBuilderMenu::initialize( %this )
{
   if( isObject( LevelBuilderBase.menuGroup ) )
      LevelBuilderBase.menuGroup.delete();
      
   LevelBuilderBase.menuGroup = new SimGroup();
   
   //-----------------------------------------------------------------------------
   // File Menu
   //-----------------------------------------------------------------------------    
   %nonMacMenu = 0;
   if( $platform $= "macos" )
      %nonMacMenu = -1000;

   %fileMenu = new PopupMenu()
   {
      superClass = "MenuBuilder";
      
      barPosition = 0;
      barName     = "�ļ�";      
      
      //item[0] = "�½�����..." TAB $cmdCtrl SPC "N" TAB "ToolManager.getLastWindow().setFirstResponder(); LBProjectObj.newLevel();";
      //item[1] = "�򿪳���..." TAB $cmdCtrl SPC "O" TAB "ToolManager.getLastWindow().setFirstResponder(); LBProjectObj.openLevel();";
      //item[2] = "-";
      item[0] = "����Ŀ..." TAB "" TAB "ToolManager.getLastWindow().setFirstResponder(); TGBWorkspace.OpenProject();";
      item[1] = "-";
      item[2] = "����" TAB $cmdCtrl SPC "S" TAB "ToolManager.getLastWindow().setFirstResponder(); LBProjectObj.saveLevel();";
      item[3] = "���Ϊ..." TAB "" TAB "ToolManager.getLastWindow().setFirstResponder(); LBProjectObj.saveLevelAs();";
      
      // the mac os application menu already has a quit item, yay! no need to duplicate it here!
      // we therefore hide these next two entries
      item[%nonMacMenu + 4] = "-";
      item[%nonMacMenu + 5] = "�˳�" TAB "" TAB "quit();";
   };

   //-----------------------------------------------------------------------------
   // Edit Menu
   //-----------------------------------------------------------------------------
   %editMenu = new PopupMenu()
   {
      superClass = "MenuBuilder";
      
      barPosition = 1;
      barName     = "�༭";      

      item[0] = "����" TAB "" TAB "ToolManager.getLastWindow().setFirstResponder(); levelBuilderUndo(1);";
      item[1] = "����" TAB "" TAB "ToolManager.getLastWindow().setFirstResponder(); levelBuilderRedo(1);";
      item[2] = "-";
      item[3] = "����" TAB "" TAB "ToolManager.getLastWindow().setFirstResponder(); levelBuilderCut(1);";
      item[4] = "����" TAB "" TAB "ToolManager.getLastWindow().setFirstResponder(); levelBuilderCopy(1);";
      item[5] = "ճ��" TAB "" TAB "ToolManager.getLastWindow().setFirstResponder();levelBuilderPaste(1);";
      //item[6] = "-";
      //item[7] = "����" TAB "" TAB "ToolManager.getLastWindow().setFirstResponder(); ToolManager.groupObjects();";
      //item[8] = "��ɢ��" TAB "" TAB "ToolManager.getLastWindow().setFirstResponder(); ToolManager.breakApart();";
      item[6] = "-";
      item[7] = "����" TAB $cmdCtrl SPC "B" TAB "ToolManager.getLastWindow().setFirstResponder(); sendToBack(true);";
      item[8] = "ǰ��" TAB $cmdCtrl SPC "F" TAB "ToolManager.getLastWindow().setFirstResponder(); bringToFront(true);";
      item[9] = "-";
      item[10] = "����..." TAB "" TAB "ToolManager.getLastWindow().setFirstResponder(); Canvas.pushDialog(optionsDlg);";
   };


   //-----------------------------------------------------------------------------
   // Project Menu
   //-----------------------------------------------------------------------------
   %projectMenu = new PopupMenu()
   {
      superClass = "MenuBuilder";
      
      barPosition = 2;
      barName     = "��Ŀ";      

      item[0] = "-";
      item[1] = "������Ϸ" TAB "" TAB "ToolManager.getLastWindow().setFirstResponder(); runGame();";
      //item[2] = "-";
      //item[3] = "���һ���µ�ͼƬ��Դ..." TAB "" TAB "LaunchFunCodeImage();";
      //item[4] = "���һ���µĶ���..." TAB "" TAB "LaunchFunCodeAnimation();";
      //item[5] = "-";
      //item[6] = "ˢ������㼶" TAB "" TAB "GuiFormManager::SendContentMessage($LBCreateSiderBar, %this, \"refreshall 0\");";
      //item[7] = "���¼�����ͼ" TAB "" TAB "reloadImageMaps();";
      item[2] = "-";
      item[3] = "�ָ�����ʼ��ͼ" TAB "" TAB "RecoverLevel();";
      item[4] = "�򿪹����ļ���" TAB "" TAB "openProjectFolder();";
      //item[5] = "����VC����" TAB "" TAB "openSourceProject();";
      item[5] = "-";
      item[6] = "����C���Թ���" TAB "" TAB "createSourceProject(1);";
      item[7] = "����C++����" TAB "" TAB "createSourceProject(0);";      
      item[8] = "����Java����" TAB "" TAB "createSourceProject(2);";
      //item[9] = "-";
      //item[10] = "���ÿ�������" TAB "" TAB "Canvas.pushDialog(SetVCVersionGUI);";
      item[9] = "-";
      item[10] = "�����ͼģ��" TAB "" TAB "Canvas.pushDialog(SelectUserTemplateGUI);";
      item[11] = "�����ͼΪģ��" TAB "" TAB "Canvas.pushDialog(SaveUserTemplateGUI);";
      //item[12] = "��Դ..." TAB $cmdCtrl SPC "R" TAB "Canvas.pushDialog(projectOptionsDlg);";
      item[12] = "-";
      item[13] = "����Eclipse.exeλ��" TAB "" TAB "SetEXEPath(\"Eclipse\");";
      item[14] = "-";
      item[15] = "����VC6(MSDEV.EXE)λ��" TAB "" TAB "SetEXEPath(\"VC6\");";
      item[16] = "����VC2008(devenv.exe)λ��" TAB "" TAB "SetEXEPath(\"VC2008\");";
      item[17] = "����VC2010(devenv.exe)λ��" TAB "" TAB "SetEXEPath(\"VC2010\");";
      item[18] = "����codeblock.exeλ��" TAB "" TAB "SetEXEPath(\"CodeBlock\");";
   };      

   //-----------------------------------------------------------------------------
   // View Menu
   //-----------------------------------------------------------------------------
   %viewMenu = new PopupMenu()
   {
      superClass = "MenuBuilder";
      
      barPosition = 3;
      barName     = "��ͼ";

      
      item[0] = "��Ļ��λ" TAB "" TAB "levelBuilderHomeView(1);";
      item[1] = "��ʾȫ��" TAB "" TAB "levelBuilderZoomToFit(1);";
      item[2] = "��ʾ��ѡ���" TAB "" TAB "levelBuilderZoomToSelected(1);";
      item[3] = "-";
      item[4] = "���� 25%" TAB "" TAB "levelBuilderZoomView(0.25);";
      item[5] = "���� 50%" TAB "" TAB "levelBuilderZoomView(0.5);";
      item[6] = "���� 100%" TAB "" TAB "levelBuilderZoomView(1.0);";
      item[7] = "���� 200%" TAB "" TAB "levelBuilderZoomView(2.0);";
      item[8] = "���� 400%" TAB "" TAB "levelBuilderZoomView(4.0);";
   };      

   //-----------------------------------------------------------------------------
   // Help Menu
   //-----------------------------------------------------------------------------
   %helpFile = expandFilename("^tools/help.html");
   %helpMenu = new PopupMenu()
   {
      superClass = "MenuBuilder";
      
      barPosition = 4;
      barName     = "����";
      
      item[0] = "��ѧ��վ" TAB "" TAB "GotoHelpWWW();";
      item[1] = "�����ĵ�" TAB "" TAB "OpenHelpPDF();";
      item[2] = "-";
      item[3] = "���÷�����" TAB "" TAB "Canvas.pushDialog(SetServerIP);";
      item[4] = "-";
      item[5] = "��ݼ�..." TAB "" TAB "Canvas.pushDialog(optionsdlg);OptionsTabBook.selectPage(1);";
   };
      
   // Submenus will be deleted when the menu they are in is deleted
   LevelBuilderBase.menuGroup.add(%fileMenu);
   LevelBuilderBase.menuGroup.add(%editMenu);
   LevelBuilderBase.menuGroup.add(%projectMenu);
   LevelBuilderBase.menuGroup.add(%viewMenu);
   LevelBuilderBase.menuGroup.add(%helpMenu);

}

function GotoHelpWWW()
{
   // Trail Version
   //MessageBoxOk("��лʹ��", "���ð治֧�ָù��ܣ��빺����ʽ�档");
   //return;
   
   %HelpWWW = $HelpWWWBegin @ $LevelEditor::HelpWWWMid @ $HelpWWWEnd;
   if( %HelpWWW !$= "" )
      gotoWebPage( %HelpWWW );
}

function OpenHelpPDF()
{
   %Path = expandFileName("");
   
   if( "" !$= $HelpDocDir )
   {
      %folder = %Path @ AnsiToUtf8( $HelpDocDir );
      openFolder( %folder );
   }
   else
   {
      %fileName = %Path @ AnsiToUtf8( "�����ĵ�.pdf" );       
      shellExecute( %fileName );
   }
}

function LevelBuilderMenu::destroy( %this )
{
   LevelBuilderBase.menuGroup.delete();
}

// [neo, 5/31/2007 - #3174]
// Refactored menu attach stuff so we can call it as needed
// e.g. before and after display changes, etc.
function LevelBuilderBase::attachMenuGroup( %this )
{
   if( !isObject( %this.menuGroup ) ) 
      return;

   for( %i = 0; %i < %this.menuGroup.getCount(); %i++ )
     %this.menuGroup.getObject( %i ).attachToMenuBar();
}

// [neo, 5/31/2007 - #3174]
// Refactored menu detach stuff so we can call it as needed
// e.g. before and after display changes, etc.
function LevelBuilderBase::detachMenuGroup( %this )
{
   if( !isObject( %this.menuGroup ) ) 
      return;
      
   for( %i = 0; %i < %this.menuGroup.getCount(); %i++ )
      %this.menuGroup.getObject( %i ).removeFromMenuBar();
}

// This is a component of the LevelBuilder GUI so this is called when the GUI Sleeps.
function LevelBuilderBase::onSleep( %this )
{
   // [neo, 5/31/2007 - #3174]
   // Refactored code to detachMenuGroup();
   detachMenuBars();
}

function LevelBuilderBase::onWake( %this )
{
   if( %this.getID() != Canvas.getContent().getID() )
      return;
 
   // [neo, 5/31/2007 - #3174]
   // Refactored to attachMenuGroup();
   attachMenuBars();   
}