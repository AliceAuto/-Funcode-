
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
      barName     = "文件";      
      
      //item[0] = "新建场景..." TAB $cmdCtrl SPC "N" TAB "ToolManager.getLastWindow().setFirstResponder(); LBProjectObj.newLevel();";
      //item[1] = "打开场景..." TAB $cmdCtrl SPC "O" TAB "ToolManager.getLastWindow().setFirstResponder(); LBProjectObj.openLevel();";
      //item[2] = "-";
      item[0] = "打开项目..." TAB "" TAB "ToolManager.getLastWindow().setFirstResponder(); TGBWorkspace.OpenProject();";
      item[1] = "-";
      item[2] = "保存" TAB $cmdCtrl SPC "S" TAB "ToolManager.getLastWindow().setFirstResponder(); LBProjectObj.saveLevel();";
      item[3] = "另存为..." TAB "" TAB "ToolManager.getLastWindow().setFirstResponder(); LBProjectObj.saveLevelAs();";
      
      // the mac os application menu already has a quit item, yay! no need to duplicate it here!
      // we therefore hide these next two entries
      item[%nonMacMenu + 4] = "-";
      item[%nonMacMenu + 5] = "退出" TAB "" TAB "quit();";
   };

   //-----------------------------------------------------------------------------
   // Edit Menu
   //-----------------------------------------------------------------------------
   %editMenu = new PopupMenu()
   {
      superClass = "MenuBuilder";
      
      barPosition = 1;
      barName     = "编辑";      

      item[0] = "撤消" TAB "" TAB "ToolManager.getLastWindow().setFirstResponder(); levelBuilderUndo(1);";
      item[1] = "重做" TAB "" TAB "ToolManager.getLastWindow().setFirstResponder(); levelBuilderRedo(1);";
      item[2] = "-";
      item[3] = "剪切" TAB "" TAB "ToolManager.getLastWindow().setFirstResponder(); levelBuilderCut(1);";
      item[4] = "复制" TAB "" TAB "ToolManager.getLastWindow().setFirstResponder(); levelBuilderCopy(1);";
      item[5] = "粘贴" TAB "" TAB "ToolManager.getLastWindow().setFirstResponder();levelBuilderPaste(1);";
      //item[6] = "-";
      //item[7] = "成组" TAB "" TAB "ToolManager.getLastWindow().setFirstResponder(); ToolManager.groupObjects();";
      //item[8] = "解散组" TAB "" TAB "ToolManager.getLastWindow().setFirstResponder(); ToolManager.breakApart();";
      item[6] = "-";
      item[7] = "后置" TAB $cmdCtrl SPC "B" TAB "ToolManager.getLastWindow().setFirstResponder(); sendToBack(true);";
      item[8] = "前置" TAB $cmdCtrl SPC "F" TAB "ToolManager.getLastWindow().setFirstResponder(); bringToFront(true);";
      item[9] = "-";
      item[10] = "设置..." TAB "" TAB "ToolManager.getLastWindow().setFirstResponder(); Canvas.pushDialog(optionsDlg);";
   };


   //-----------------------------------------------------------------------------
   // Project Menu
   //-----------------------------------------------------------------------------
   %projectMenu = new PopupMenu()
   {
      superClass = "MenuBuilder";
      
      barPosition = 2;
      barName     = "项目";      

      item[0] = "-";
      item[1] = "运行游戏" TAB "" TAB "ToolManager.getLastWindow().setFirstResponder(); runGame();";
      //item[2] = "-";
      //item[3] = "添加一个新的图片资源..." TAB "" TAB "LaunchFunCodeImage();";
      //item[4] = "添加一个新的动画..." TAB "" TAB "LaunchFunCodeAnimation();";
      //item[5] = "-";
      //item[6] = "刷新物体层级" TAB "" TAB "GuiFormManager::SendContentMessage($LBCreateSiderBar, %this, \"refreshall 0\");";
      //item[7] = "重新加载贴图" TAB "" TAB "reloadImageMaps();";
      item[2] = "-";
      item[3] = "恢复至初始地图" TAB "" TAB "RecoverLevel();";
      item[4] = "打开工程文件夹" TAB "" TAB "openProjectFolder();";
      //item[5] = "启动VC工程" TAB "" TAB "openSourceProject();";
      item[5] = "-";
      item[6] = "创建C语言工程" TAB "" TAB "createSourceProject(1);";
      item[7] = "创建C++工程" TAB "" TAB "createSourceProject(0);";      
      item[8] = "创建Java工程" TAB "" TAB "createSourceProject(2);";
      //item[9] = "-";
      //item[10] = "设置开发工具" TAB "" TAB "Canvas.pushDialog(SetVCVersionGUI);";
      item[9] = "-";
      item[10] = "导入地图模板" TAB "" TAB "Canvas.pushDialog(SelectUserTemplateGUI);";
      item[11] = "保存地图为模板" TAB "" TAB "Canvas.pushDialog(SaveUserTemplateGUI);";
      //item[12] = "资源..." TAB $cmdCtrl SPC "R" TAB "Canvas.pushDialog(projectOptionsDlg);";
      item[12] = "-";
      item[13] = "设置Eclipse.exe位置" TAB "" TAB "SetEXEPath(\"Eclipse\");";
      item[14] = "-";
      item[15] = "设置VC6(MSDEV.EXE)位置" TAB "" TAB "SetEXEPath(\"VC6\");";
      item[16] = "设置VC2008(devenv.exe)位置" TAB "" TAB "SetEXEPath(\"VC2008\");";
      item[17] = "设置VC2010(devenv.exe)位置" TAB "" TAB "SetEXEPath(\"VC2010\");";
      item[18] = "设置codeblock.exe位置" TAB "" TAB "SetEXEPath(\"CodeBlock\");";
   };      

   //-----------------------------------------------------------------------------
   // View Menu
   //-----------------------------------------------------------------------------
   %viewMenu = new PopupMenu()
   {
      superClass = "MenuBuilder";
      
      barPosition = 3;
      barName     = "视图";

      
      item[0] = "屏幕复位" TAB "" TAB "levelBuilderHomeView(1);";
      item[1] = "显示全部" TAB "" TAB "levelBuilderZoomToFit(1);";
      item[2] = "显示已选择的" TAB "" TAB "levelBuilderZoomToSelected(1);";
      item[3] = "-";
      item[4] = "缩放 25%" TAB "" TAB "levelBuilderZoomView(0.25);";
      item[5] = "缩放 50%" TAB "" TAB "levelBuilderZoomView(0.5);";
      item[6] = "缩放 100%" TAB "" TAB "levelBuilderZoomView(1.0);";
      item[7] = "缩放 200%" TAB "" TAB "levelBuilderZoomView(2.0);";
      item[8] = "缩放 400%" TAB "" TAB "levelBuilderZoomView(4.0);";
   };      

   //-----------------------------------------------------------------------------
   // Help Menu
   //-----------------------------------------------------------------------------
   %helpFile = expandFilename("^tools/help.html");
   %helpMenu = new PopupMenu()
   {
      superClass = "MenuBuilder";
      
      barPosition = 4;
      barName     = "帮助";
      
      item[0] = "教学网站" TAB "" TAB "GotoHelpWWW();";
      item[1] = "帮助文档" TAB "" TAB "OpenHelpPDF();";
      item[2] = "-";
      item[3] = "设置服务器" TAB "" TAB "Canvas.pushDialog(SetServerIP);";
      item[4] = "-";
      item[5] = "快捷键..." TAB "" TAB "Canvas.pushDialog(optionsdlg);OptionsTabBook.selectPage(1);";
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
   //MessageBoxOk("感谢使用", "试用版不支持该功能，请购买正式版。");
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
      %fileName = %Path @ AnsiToUtf8( "帮助文档.pdf" );       
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