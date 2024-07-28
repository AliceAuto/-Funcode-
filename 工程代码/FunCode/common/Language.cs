
//
$LangCount = 2;
$Lang_Type[0] = "简体中文";
$Lang_Type[1] = "English";
$Lang_Type[2] = "-";
$Lang_Type[3] = "-";
$Lang_Type[4] = "-";
function Language_GetLanguageMenu(%index) { return $Lang_Type[%index]; }
function Language_GetLanguageTitle() { return "语言(Language)"; }

//
$Lang_AnimBuilder1[0]="动画编辑器";
$Lang_AnimBuilder1[1]="Animation Editor";
function Language_AnimBuilder1() { return $Lang_AnimBuilder1[$pref::LanguageType]; }
//
$Lang_AnimBuilder2[0]="删除所有已选择的帧";
$Lang_AnimBuilder2[1]="Delete all the frames chosen";
function Language_AnimBuilder2() { return $Lang_AnimBuilder2[$pref::LanguageType]; }
//
$Lang_AnimBuilder3[0]="添加整张图片";
$Lang_AnimBuilder3[1]="Add a completed picture";
function Language_AnimBuilder3() { return $Lang_AnimBuilder3[$pref::LanguageType]; }
//
$Lang_AnimBuilder4[0]="暂停动画";
$Lang_AnimBuilder4[1]="Pause";
function Language_AnimBuilder4() { return $Lang_AnimBuilder4[$pref::LanguageType]; }
//
$Lang_AnimBuilder5[0]="播放动画";
$Lang_AnimBuilder5[1]="Play";
function Language_AnimBuilder5() { return $Lang_AnimBuilder5[$pref::LanguageType]; }
//
$Lang_AnimBuilder6[0]="循环播放";
$Lang_AnimBuilder6[1]="Loop";
function Language_AnimBuilder6() { return $Lang_AnimBuilder6[$pref::LanguageType]; }
//
$Lang_AnimBuilder7[0]="随机";
$Lang_AnimBuilder7[1]="Ramdon";
function Language_AnimBuilder7() { return $Lang_AnimBuilder7[$pref::LanguageType]; }
//
$Lang_AnimBuilder8[0]="帧/秒";
$Lang_AnimBuilder8[1]="Frame/Second";
function Language_AnimBuilder8() { return $Lang_AnimBuilder8[$pref::LanguageType]; }
//
$Lang_AnimBuilder9[0]="起始帧";
$Lang_AnimBuilder9[1]="Beginning Frame";
function Language_AnimBuilder9() { return $Lang_AnimBuilder9[$pref::LanguageType]; }
//
$Lang_AnimBuilder10[0]="名字";
$Lang_AnimBuilder10[1]="Name";
function Language_AnimBuilder10() { return $Lang_AnimBuilder10[$pref::LanguageType]; }
//
$Lang_AnimBuilder11[0]="双向播放";
$Lang_AnimBuilder11[1]="Two-way Play";
function Language_AnimBuilder11() { return $Lang_AnimBuilder11[$pref::LanguageType]; }
//
$Lang_AnimBuilder12[0]="倒序播放";
$Lang_AnimBuilder12[1]="Reverse Play";
function Language_AnimBuilder12() { return $Lang_AnimBuilder12[$pref::LanguageType]; }
//
$Lang_AnimBuilder13[0]="保存";
$Lang_AnimBuilder13[1]="Save";
function Language_AnimBuilder13() { return $Lang_AnimBuilder13[$pref::LanguageType]; }
//
$Lang_AnimBuilder14[0]="取消";
$Lang_AnimBuilder14[1]="Cancel";
function Language_AnimBuilder14() { return $Lang_AnimBuilder14[$pref::LanguageType]; }

//
$Lang_FunCodeAnim1[0]="动画资源";
$Lang_FunCodeAnim1[1]="Animation Resources";
function Language_FunCodeAnim1() { return $Lang_FunCodeAnim1[$pref::LanguageType]; }
//
$Lang_FunCodeAnim2[0]="资源";
$Lang_FunCodeAnim2[1]="Resources";
function Language_FunCodeAnim2() { return $Lang_FunCodeAnim2[$pref::LanguageType]; }
//
$Lang_FunCodeAnim3[0]="预览";
$Lang_FunCodeAnim3[1]="Preview";
function Language_FunCodeAnim3() { return $Lang_FunCodeAnim3[$pref::LanguageType]; }
//
$Lang_FunCodeAnim4[0]="添加到工程";
$Lang_FunCodeAnim4[1]="Add to the project";
function Language_FunCodeAnim4() { return $Lang_FunCodeAnim4[$pref::LanguageType]; }
//
$Lang_FunCodeAnim5[0]="关闭窗口时释放图片资源(适用低配置机器)";
$Lang_FunCodeAnim5[1]="Release pictures after closing windows(for the  lower-configured)";
function Language_FunCodeAnim5() { return $Lang_FunCodeAnim5[$pref::LanguageType]; }

//
$Lang_ImageMapSel1[0]="选择";
$Lang_ImageMapSel1[1]="Select";
function Language_ImageMapSel1() { return $Lang_ImageMapSel1[$pref::LanguageType]; }
//
$Lang_ImageMapSel2[0]="资源";
$Lang_ImageMapSel2[1]="Resources";
function Language_ImageMapSel2() { return $Lang_ImageMapSel2[$pref::LanguageType]; }
//
$Lang_ImageMapSel3[0]="预览";
$Lang_ImageMapSel3[1]="Preview";
function Language_ImageMapSel3() { return $Lang_ImageMapSel3[$pref::LanguageType]; }
//
$Lang_ImageMapSel4[0]="选择";
$Lang_ImageMapSel4[1]="Select";
function Language_ImageMapSel4() { return $Lang_ImageMapSel4[$pref::LanguageType]; }

//
$Lang_behaviorEditor1[0]="行为(脚本相关)";
$Lang_behaviorEditor1[1]="Behavior(Script)";
function Language_behaviorEditor1() { return $Lang_behaviorEditor1[$pref::LanguageType]; }

//
$Lang_BehaviorList1[0]="当前添加到此物体的行为";
$Lang_BehaviorList1[1]="Current add to the object behavior";
function Language_BehaviorList1() { return $Lang_BehaviorList1[$pref::LanguageType]; }
//
$Lang_BehaviorList2[0]="添加已选择的行为至该物体";
$Lang_BehaviorList2[1]="Add the chosen behavior to the object";
function Language_BehaviorList2() { return $Lang_BehaviorList2[$pref::LanguageType]; }
//
$Lang_BehaviorList3[0]="删除本物体的此行为";
$Lang_BehaviorList3[1]="Delete the object behavior";
function Language_BehaviorList3() { return $Lang_BehaviorList3[$pref::LanguageType]; }

//
$Lang_BehaviorDlg1[0]="添加/删除物体的行为";
$Lang_BehaviorDlg1[1]="Add/Delect object behavior";
function Language_BehaviorDlg1() { return $Lang_BehaviorDlg1[$pref::LanguageType]; }
//
$Lang_BehaviorDlg2[0]="添加行为";
$Lang_BehaviorDlg2[1]="Add behavior";
function Language_BehaviorDlg2() { return $Lang_BehaviorDlg2[$pref::LanguageType]; }
//
$Lang_BehaviorDlg3[0]="删除行为";
$Lang_BehaviorDlg3[1]="Delete behavior";
function Language_BehaviorDlg3() { return $Lang_BehaviorDlg3[$pref::LanguageType]; }
//
$Lang_BehaviorDlg4[0]="取消";
$Lang_BehaviorDlg4[1]="Cancel";
function Language_BehaviorDlg4() { return $Lang_BehaviorDlg4[$pref::LanguageType]; }
  //
$Lang_BehaviorDlg5[0]="应用";
$Lang_BehaviorDlg5[1]="Apply";
function Language_BehaviorDlg5() { return $Lang_BehaviorDlg5[$pref::LanguageType]; }
  //
$Lang_BehaviorDlg6[0]="可用的行为";
$Lang_BehaviorDlg6[1]="Available Behavior";
function Language_BehaviorDlg6() { return $Lang_BehaviorDlg6[$pref::LanguageType]; }
  //
$Lang_BehaviorDlg7[0]="组织:";
$Lang_BehaviorDlg7[1]="Construction:";
function Language_BehaviorDlg7() { return $Lang_BehaviorDlg7[$pref::LanguageType]; }
  //
$Lang_BehaviorDlg8[0]="资源";
$Lang_BehaviorDlg8[1]="Resources";
function Language_BehaviorDlg8() { return $Lang_BehaviorDlg8[$pref::LanguageType]; }
  //
$Lang_BehaviorDlg9[0]="类型";
$Lang_BehaviorDlg9[1]="Type";
function Language_BehaviorDlg9() { return $Lang_BehaviorDlg9[$pref::LanguageType]; }
  //
$Lang_BehaviorDlg10[0]="当前应用的行为";
$Lang_BehaviorDlg10[1]="Behavior being applied at present";
function Language_BehaviorDlg10() { return $Lang_BehaviorDlg10[$pref::LanguageType]; }
  //
$Lang_BehaviorDlg11[0]="未选择任何行为";
$Lang_BehaviorDlg11[1]="No behavior selected";
function Language_BehaviorDlg11() { return $Lang_BehaviorDlg11[$pref::LanguageType]; }
  //
$Lang_BehaviorDlg12[0]="值域";
$Lang_BehaviorDlg12[1]="Range";
function Language_BehaviorDlg12() { return $Lang_BehaviorDlg12[$pref::LanguageType]; }
  //
$Lang_BehaviorDlg13[0]="开启或者关闭行为信息面板";
$Lang_BehaviorDlg13[1]="Open or close behavior message panel";
function Language_BehaviorDlg13() { return $Lang_BehaviorDlg13[$pref::LanguageType]; }
  //
$Lang_BehaviorDlg14[0]="向上移动选择的行为";
$Lang_BehaviorDlg14[1]="Move up the chosen behavior";
function Language_BehaviorDlg14() { return $Lang_BehaviorDlg14[$pref::LanguageType]; }
  //
$Lang_BehaviorDlg15[0]="向下移动选择的行为";
$Lang_BehaviorDlg15[1]="Move down the chosen behavior";
function Language_BehaviorDlg15() { return $Lang_BehaviorDlg15[$pref::LanguageType]; }
  //
$Lang_BehaviorDlg16[0]="自动更改行为至默认数据";
$Lang_BehaviorDlg16[1]="Auto Alter behavior to the default data";
function Language_BehaviorDlg16() { return $Lang_BehaviorDlg16[$pref::LanguageType]; }
  //
$Lang_BehaviorDlg17[0]="自动默认";
$Lang_BehaviorDlg17[1]="Auto Default";
function Language_BehaviorDlg17() { return $Lang_BehaviorDlg17[$pref::LanguageType]; }
  //
$Lang_BehaviorDlg18[0]="自动索取";
$Lang_BehaviorDlg18[1]="Auto Claim";
function Language_BehaviorDlg18() { return $Lang_BehaviorDlg18[$pref::LanguageType]; }

  //
$Lang_guiForm1[0]="水平拆分此窗口";
$Lang_guiForm1[1]="Split the window horizontally";
function Language_guiForm1() { return $Lang_guiForm1[$pref::LanguageType]; }
    //
$Lang_guiForm2[0]="垂直拆分此窗口";
$Lang_guiForm2[1]="Split the window vertically";
function Language_guiForm2() { return $Lang_guiForm2[$pref::LanguageType]; }
    //
$Lang_guiForm3[0]="删除此窗口";
$Lang_guiForm3[1]="Delete the window";
function Language_guiForm3() { return $Lang_guiForm3[$pref::LanguageType]; }

  //
$Lang_guiFormContent1[0]="地图预览";
$Lang_guiFormContent1[1]="Scene Preview";
function Language_guiFormContent1() { return $Lang_guiFormContent1[$pref::LanguageType]; }

  //
$Lang_AccountInput1[0]="请输入账号";
$Lang_AccountInput1[1]="Enter the account";
function Language_AccountInput1() { return $Lang_AccountInput1[$pref::LanguageType]; }
    //
$Lang_AccountInput2[0]="请输入小于20个字母的账号";
$Lang_AccountInput2[1]="Enter an account less than twenty letters";
function Language_AccountInput2() { return $Lang_AccountInput2[$pref::LanguageType]; }
    //
$Lang_AccountInput3[0]="请输入密码";
$Lang_AccountInput3[1]="Enter the password";
function Language_AccountInput3() { return $Lang_AccountInput3[$pref::LanguageType]; }
    //
$Lang_AccountInput4[0]="请输入小于16个字母的密码";
$Lang_AccountInput4[1]="Enter a password less than 16 letters";
function Language_AccountInput4() { return $Lang_AccountInput4[$pref::LanguageType]; }
    //
$Lang_AccountInput5[0]="FunCode登陆";
$Lang_AccountInput5[1]="FunCode Log in";
function Language_AccountInput5() { return $Lang_AccountInput5[$pref::LanguageType]; }
    //
$Lang_AccountInput6[0]="取消";
$Lang_AccountInput6[1]="Cancel";
function Language_AccountInput6() { return $Lang_AccountInput6[$pref::LanguageType]; }
    //
$Lang_AccountInput7[0]="登陆";
$Lang_AccountInput7[1]="Log in";
function Language_AccountInput7() { return $Lang_AccountInput7[$pref::LanguageType]; }
    //
$Lang_AccountInput8[0]="账号:";
$Lang_AccountInput8[1]="Account:";
function Language_AccountInput8() { return $Lang_AccountInput8[$pref::LanguageType]; }
    //
$Lang_AccountInput9[0]="密码:";
$Lang_AccountInput9[1]="Password:";
function Language_AccountInput9() { return $Lang_AccountInput9[$pref::LanguageType]; }
    //
$Lang_AccountInput10[0]="局域网服务器";
$Lang_AccountInput10[1]="Local area network server";
function Language_AccountInput10() { return $Lang_AccountInput10[$pref::LanguageType]; }
    //
$Lang_AccountInput11[0]="广域网服务器";
$Lang_AccountInput11[1]="WAN";
function Language_AccountInput11() { return $Lang_AccountInput11[$pref::LanguageType]; }
      //
$Lang_AccountInput12[0]="错误";
$Lang_AccountInput12[1]="Error";
function Language_AccountInput12() { return $Lang_AccountInput12[$pref::LanguageType]; }

  //
$Lang_ColorPicker1[0]="颜色吸取";
$Lang_ColorPicker1[1]="Color Pick";
function Language_ColorPicker1() { return $Lang_ColorPicker1[$pref::LanguageType]; }
    //
$Lang_ColorPicker2[0]="放弃";
$Lang_ColorPicker2[1]="Abandon";
function Language_ColorPicker2() { return $Lang_ColorPicker2[$pref::LanguageType]; }
    //
$Lang_ColorPicker3[0]="确定";
$Lang_ColorPicker3[1]="Confirm";
function Language_ColorPicker3() { return $Lang_ColorPicker3[$pref::LanguageType]; }
    //
$Lang_ColorPicker4[0]="取消";
$Lang_ColorPicker4[1]="Cancel";
function Language_ColorPicker4() { return $Lang_ColorPicker4[$pref::LanguageType]; }
    //
$Lang_OpenFileDlg5[0]="打开文件...";
$Lang_OpenFileDlg5[1]="Open the file...";
function Language_OpenFileDlg5() { return $Lang_OpenFileDlg5[$pref::LanguageType]; }
    //
$Lang_OpenFileDlg6[0]="文件类型";
$Lang_OpenFileDlg6[1]="File Type";
function Language_OpenFileDlg6() { return $Lang_OpenFileDlg6[$pref::LanguageType]; }
    //
$Lang_OpenFileDlg7[0]="打开";
$Lang_OpenFileDlg7[1]="Open";
function Language_OpenFileDlg7() { return $Lang_OpenFileDlg7[$pref::LanguageType]; }
    //
$Lang_OpenFileDlg8[0]="取消";
$Lang_OpenFileDlg8[1]="Cancel";
function Language_OpenFileDlg8() { return $Lang_OpenFileDlg8[$pref::LanguageType]; }

  //
$Lang_SaveChangeDlg1[0]="保存更改";
$Lang_SaveChangeDlg1[1]="Save Changes";
function Language_SaveChangeDlg1() { return $Lang_SaveChangeDlg1[$pref::LanguageType]; }
    //
$Lang_SaveChangeDlg2[0]="保存";
$Lang_SaveChangeDlg2[1]="Save";
function Language_SaveChangeDlg2() { return $Lang_SaveChangeDlg2[$pref::LanguageType]; }
    //
$Lang_SaveChangeDlg3[0]="取消";
$Lang_SaveChangeDlg3[1]="Cancel";
function Language_SaveChangeDlg3() { return $Lang_SaveChangeDlg3[$pref::LanguageType]; }
    //
$Lang_SaveChangeDlg4[0]="不保存";
$Lang_SaveChangeDlg4[1]="Not Save";
function Language_SaveChangeDlg4() { return $Lang_SaveChangeDlg4[$pref::LanguageType]; }
    //
$Lang_SaveChangeDlg5[0]="是否保存所做更改?";
$Lang_SaveChangeDlg5[1]="Save the changes?";
function Language_SaveChangeDlg5() { return $Lang_SaveChangeDlg5[$pref::LanguageType]; }
    //
$Lang_SaveChangeDlg6[0]="如果不保存，你将丢失所有更改.";
$Lang_SaveChangeDlg6[1]="If not save,changes loss.";
function Language_SaveChangeDlg6() { return $Lang_SaveChangeDlg6[$pref::LanguageType]; }

  //
$Lang_saveFileDlg1[0]="保存文件...";
$Lang_saveFileDlg1[1]="Save File...";
function Language_saveFileDlg1() { return $Lang_saveFileDlg1[$pref::LanguageType]; }
    //
$Lang_saveFileDlg2[0]="文件类型";
$Lang_saveFileDlg2[1]="File Type";
function Language_saveFileDlg2() { return $Lang_saveFileDlg2[$pref::LanguageType]; }
    //
$Lang_saveFileDlg3[0]="文件名字";
$Lang_saveFileDlg3[1]="File Name";
function Language_saveFileDlg3() { return $Lang_saveFileDlg3[$pref::LanguageType]; }
    //
$Lang_saveFileDlg4[0]="保存文件";
$Lang_saveFileDlg4[1]="Save File";
function Language_saveFileDlg4() { return $Lang_saveFileDlg4[$pref::LanguageType]; }
    //
$Lang_saveFileDlg5[0]="取消";
$Lang_saveFileDlg5[1]="Cancel";
function Language_saveFileDlg5() { return $Lang_saveFileDlg5[$pref::LanguageType]; }

  //
$Lang_simViewDlg1[0]="预览";
$Lang_simViewDlg1[1]="Preview";
function Language_simViewDlg1() { return $Lang_simViewDlg1[$pref::LanguageType]; }
    //
$Lang_simViewDlg2[0]="精灵ID:";
$Lang_simViewDlg2[1]="Sprite ID:";
function Language_simViewDlg2() { return $Lang_simViewDlg2[$pref::LanguageType]; }
    //
$Lang_simViewDlg3[0]="内部名称:";
$Lang_simViewDlg3[1]="Inside Name:";
function Language_simViewDlg3() { return $Lang_simViewDlg3[$pref::LanguageType]; }
    //
$Lang_simViewDlg4[0]="选择精灵:";
$Lang_simViewDlg4[1]="Choose Sprite:";
function Language_simViewDlg4() { return $Lang_simViewDlg4[$pref::LanguageType]; }
    //
$Lang_simViewDlg5[0]="刷新";
$Lang_simViewDlg5[1]="Refresh";
function Language_simViewDlg5() { return $Lang_simViewDlg5[$pref::LanguageType]; }
    //
$Lang_simViewDlg6[0]="删除";
$Lang_simViewDlg6[1]="Delete";
function Language_simViewDlg6() { return $Lang_simViewDlg6[$pref::LanguageType]; }

  //
$Lang_guiEditor1[0]="打开/关闭面板";
$Lang_guiEditor1[1]="Open/Close Panel";
function Language_guiEditor1() { return $Lang_guiEditor1[$pref::LanguageType]; }
    //
$Lang_guiEditor2[0]="对齐到网格";
$Lang_guiEditor2[1]="Snap To Grid";
function Language_guiEditor2() { return $Lang_guiEditor2[$pref::LanguageType]; }
    //
$Lang_guiEditor3[0]="名字:";
$Lang_guiEditor3[1]="Name:";
function Language_guiEditor3() { return $Lang_guiEditor3[$pref::LanguageType]; }
    //
$Lang_guiEditor4[0]="应用";
$Lang_guiEditor4[1]="Apply";
function Language_guiEditor4() { return $Lang_guiEditor4[$pref::LanguageType]; }

  //
$Lang_guiEditorPalette1[0]="控制面板";
$Lang_guiEditorPalette1[1]="Control Panel";
function Language_guiEditorPalette1() { return $Lang_guiEditorPalette1[$pref::LanguageType]; }
    //
$Lang_guiEditorPalette2[0]="普通";
$Lang_guiEditorPalette2[1]="Common";
function Language_guiEditorPalette2() { return $Lang_guiEditorPalette2[$pref::LanguageType]; }
    //
$Lang_guiEditorPalette3[0]="所有";
$Lang_guiEditorPalette3[1]="All";
function Language_guiEditorPalette3() { return $Lang_guiEditorPalette3[$pref::LanguageType]; }

//
$Lang_guiEditorPrefsDlg1[0]="界面编辑器设置";
$Lang_guiEditorPrefsDlg1[1]="Interface Builder set";
function Language_guiEditorPrefsDlg1() { return $Lang_guiEditorPrefsDlg1[$pref::LanguageType]; }
  //
$Lang_guiEditorPrefsDlg2[0]="取消";
$Lang_guiEditorPrefsDlg2[1]="Cancel";
function Language_guiEditorPrefsDlg2() { return $Lang_guiEditorPrefsDlg2[$pref::LanguageType]; }
  //
$Lang_guiEditorPrefsDlg3[0]="确定";
$Lang_guiEditorPrefsDlg3[1]="Confirm";
function Language_guiEditorPrefsDlg3() { return $Lang_guiEditorPrefsDlg3[$pref::LanguageType]; }
  //
$Lang_guiEditorPrefsDlg4[0]="恢复默认";
$Lang_guiEditorPrefsDlg4[1]="Default Restore";
function Language_guiEditorPrefsDlg4() { return $Lang_guiEditorPrefsDlg4[$pref::LanguageType]; }
  //
$Lang_guiEditorPrefsDlg5[0]="网格大小:";
$Lang_guiEditorPrefsDlg5[1]="Grid Size:";
function Language_guiEditorPrefsDlg5() { return $Lang_guiEditorPrefsDlg5[$pref::LanguageType]; }

  //
$Lang_NewGuiDialog1[0]="新建界面";
$Lang_NewGuiDialog1[1]="New Create Interface";
function Language_NewGuiDialog1() { return $Lang_NewGuiDialog1[$pref::LanguageType]; }
    //
$Lang_NewGuiDialog2[0]="取消";
$Lang_NewGuiDialog2[1]="Cancel";
function Language_NewGuiDialog2() { return $Lang_NewGuiDialog2[$pref::LanguageType]; }
    //
$Lang_NewGuiDialog3[0]="创建";
$Lang_NewGuiDialog3[1]="Create";
function Language_NewGuiDialog3() { return $Lang_NewGuiDialog3[$pref::LanguageType]; }
    //
$Lang_NewGuiDialog4[0]="界面名字";
$Lang_NewGuiDialog4[1]="Interface Name";
function Language_NewGuiDialog4() { return $Lang_NewGuiDialog4[$pref::LanguageType]; }
    //
$Lang_NewGuiDialog5[0]="界面类名(Class)";
$Lang_NewGuiDialog5[1]="Interface Class Name";
function Language_NewGuiDialog5() { return $Lang_NewGuiDialog5[$pref::LanguageType]; }

  //
$Lang_FunCodeImage1[0]="图片资源";
$Lang_FunCodeImage1[1]="Image Resource";
function Language_FunCodeImage1() { return $Lang_FunCodeImage1[$pref::LanguageType]; }
    //
$Lang_FunCodeImage2[0]="资源";
$Lang_FunCodeImage2[1]="Resource";
function Language_FunCodeImage2() { return $Lang_FunCodeImage2[$pref::LanguageType]; }
    //
$Lang_FunCodeImage3[0]="预览";
$Lang_FunCodeImage3[1]="Preview";
function Language_FunCodeImage3() { return $Lang_FunCodeImage3[$pref::LanguageType]; }
    //
$Lang_FunCodeImage4[0]="添加到工程";
$Lang_FunCodeImage4[1]="Add to the project";
function Language_FunCodeImage4() { return $Lang_FunCodeImage4[$pref::LanguageType]; }
    //
$Lang_FunCodeImage5[0]="关闭窗口时释放图片资源(适用低配置机器)";
$Lang_FunCodeImage5[1]="Image resources released when closing window (For the low-configure)";
function Language_FunCodeImage5() { return $Lang_FunCodeImage5[$pref::LanguageType]; }

  //
$Lang_FunCodeMusic1[0]="音乐资源";
$Lang_FunCodeMusic1[1]="Music Resources";
function Language_FunCodeMusic1() { return $Lang_FunCodeMusic1[$pref::LanguageType]; }
    //
$Lang_FunCodeMusic2[0]="资源";
$Lang_FunCodeMusic2[1]="Resources";
function Language_FunCodeMusic2() { return $Lang_FunCodeMusic2[$pref::LanguageType]; }
    //
$Lang_FunCodeMusic3[0]="当前工程资源";
$Lang_FunCodeMusic3[1]="Current project resource";
function Language_FunCodeMusic3() { return $Lang_FunCodeMusic3[$pref::LanguageType]; }
    //
$Lang_FunCodeMusic4[0]="添加到工程";
$Lang_FunCodeMusic4[1]="Add to the project";
function Language_FunCodeMusic4() { return $Lang_FunCodeMusic4[$pref::LanguageType]; }
    //
$Lang_FunCodeMusic5[0]="导入音乐";
$Lang_FunCodeMusic5[1]="Import Music";
function Language_FunCodeMusic5() { return $Lang_FunCodeMusic5[$pref::LanguageType]; }
    //
$Lang_FunCodeMusic6[0]="播放";
$Lang_FunCodeMusic6[1]="Play";
function Language_FunCodeMusic6() { return $Lang_FunCodeMusic6[$pref::LanguageType]; }
    //
$Lang_FunCodeMusic7[0]="停止   ";
$Lang_FunCodeMusic7[1]="Stop   ";
function Language_FunCodeMusic7() { return $Lang_FunCodeMusic7[$pref::LanguageType]; }
    //
$Lang_FunCodeMusic8[0]="从工程里删除";
$Lang_FunCodeMusic8[1]="Delete from the project";
function Language_FunCodeMusic8() { return $Lang_FunCodeMusic8[$pref::LanguageType]; }

  //
$Lang_ImageBuilderGui1[0]="图片编辑器";
$Lang_ImageBuilderGui1[1]="Image Editor";
function Language_ImageBuilderGui1() { return $Lang_ImageBuilderGui1[$pref::LanguageType]; }
    //
$Lang_ImageBuilderGui2[0]="取消";
$Lang_ImageBuilderGui2[1]="Cancel";
function Language_ImageBuilderGui2() { return $Lang_ImageBuilderGui2[$pref::LanguageType]; }
    //
$Lang_ImageBuilderGui3[0]="图片设置";
$Lang_ImageBuilderGui3[1]="Image Setting";
function Language_ImageBuilderGui3() { return $Lang_ImageBuilderGui3[$pref::LanguageType]; }
    //
$Lang_ImageBuilderGui4[0]="警告：此名字已经被使用，请另起";
$Lang_ImageBuilderGui4[1]="Warning: name has been used,choose another";
function Language_ImageBuilderGui4() { return $Lang_ImageBuilderGui4[$pref::LanguageType]; }
    //
$Lang_ImageBuilderGui5[0]="图片名:";
$Lang_ImageBuilderGui5[1]="Image Name:";
function Language_ImageBuilderGui5() { return $Lang_ImageBuilderGui5[$pref::LanguageType]; }
    //
$Lang_ImageBuilderGui6[0]="图片模式:";
$Lang_ImageBuilderGui6[1]="Image Mode:";
function Language_ImageBuilderGui6() { return $Lang_ImageBuilderGui6[$pref::LanguageType]; }
    //
$Lang_ImageBuilderGui7[0]="过滤模式:";
$Lang_ImageBuilderGui7[1]="Filter Mode:";
function Language_ImageBuilderGui7() { return $Lang_ImageBuilderGui7[$pref::LanguageType]; }
    //
$Lang_ImageBuilderGui8[0]="图片大小:";
$Lang_ImageBuilderGui8[1]="Image Size:";
function Language_ImageBuilderGui8() { return $Lang_ImageBuilderGui8[$pref::LanguageType]; }
    //
$Lang_ImageBuilderGui9[0]="选择一个缩放区域";
$Lang_ImageBuilderGui9[1]="Choose a zoom area";
function Language_ImageBuilderGui9() { return $Lang_ImageBuilderGui9[$pref::LanguageType]; }
    //
$Lang_ImageBuilderGui10[0]="缩放";
$Lang_ImageBuilderGui10[1]="Zoom";
function Language_ImageBuilderGui10() { return $Lang_ImageBuilderGui10[$pref::LanguageType]; }
    //
$Lang_ImageBuilderGui11[0]="放大";
$Lang_ImageBuilderGui11[1]="Zoom In";
function Language_ImageBuilderGui11() { return $Lang_ImageBuilderGui11[$pref::LanguageType]; }
    //
$Lang_ImageBuilderGui12[0]="放大";
$Lang_ImageBuilderGui12[1]="Zoom In";
function Language_ImageBuilderGui12() { return $Lang_ImageBuilderGui12[$pref::LanguageType]; }
    //
$Lang_ImageBuilderGui13[0]="更改背景或者边框色";
$Lang_ImageBuilderGui13[1]="Change the background or border color";
function Language_ImageBuilderGui13() { return $Lang_ImageBuilderGui13[$pref::LanguageType]; }
    //
$Lang_ImageBuilderGui14[0]="背景";
$Lang_ImageBuilderGui14[1]="Background";
function Language_ImageBuilderGui14() { return $Lang_ImageBuilderGui14[$pref::LanguageType]; }
    //
$Lang_ImageBuilderGui15[0]="坐标:";
$Lang_ImageBuilderGui15[1]="Coordinate:";
function Language_ImageBuilderGui15() { return $Lang_ImageBuilderGui15[$pref::LanguageType]; }
    //
$Lang_ImageBuilderGui16[0]="选择缩放区域";
$Lang_ImageBuilderGui16[1]="Select the zoom area";
function Language_ImageBuilderGui16() { return $Lang_ImageBuilderGui16[$pref::LanguageType]; }
    //
$Lang_ImageBuilderGui17[0]="缩放区选择";
$Lang_ImageBuilderGui17[1]="Zoom area select";
function Language_ImageBuilderGui17() { return $Lang_ImageBuilderGui17[$pref::LanguageType]; }
    //
$Lang_ImageBuilderGui18[0]="<just:center>警告<br> 至少需要<br>2 张图片才能连接";
$Lang_ImageBuilderGui18[1]="<just:center>Warning<br> need at least<br> 2 images to connect";
function Language_ImageBuilderGui18() { return $Lang_ImageBuilderGui18[$pref::LanguageType]; }
    //
$Lang_ImageBuilderGui19[0]="当前连接列表";
$Lang_ImageBuilderGui19[1]="Connect to the list at present";
function Language_ImageBuilderGui19() { return $Lang_ImageBuilderGui19[$pref::LanguageType]; }
    //
$Lang_ImageBuilderGui20[0]="添加一张图片至连接资源";
$Lang_ImageBuilderGui20[1]="Add an image to the connecion resource";
function Language_ImageBuilderGui20() { return $Lang_ImageBuilderGui20[$pref::LanguageType]; }
    //
$Lang_ImageBuilderGui21[0]="图片";
$Lang_ImageBuilderGui21[1]="Image";
function Language_ImageBuilderGui21() { return $Lang_ImageBuilderGui21[$pref::LanguageType]; }
    //
$Lang_ImageBuilderGui22[0]="删除选择";
$Lang_ImageBuilderGui22[1]="Delete the selected";
function Language_ImageBuilderGui22() { return $Lang_ImageBuilderGui22[$pref::LanguageType]; }
    //
$Lang_ImageBuilderGui23[0]="单元(Cell)模式选择";
$Lang_ImageBuilderGui23[1]="Cell mode select";
function Language_ImageBuilderGui23() { return $Lang_ImageBuilderGui23[$pref::LanguageType]; }
    //
$Lang_ImageBuilderGui24[0]="单元偏移X:";
$Lang_ImageBuilderGui24[1]="Unit offset X:";
function Language_ImageBuilderGui24() { return $Lang_ImageBuilderGui24[$pref::LanguageType]; }
    //
$Lang_ImageBuilderGui25[0]="单元偏移Y:";
$Lang_ImageBuilderGui25[1]="Unit offset Y:";
function Language_ImageBuilderGui25() { return $Lang_ImageBuilderGui25[$pref::LanguageType]; }
    //
$Lang_ImageBuilderGui26[0]="单元步进Y:";
$Lang_ImageBuilderGui26[1]="Unit stepping Y:";
function Language_ImageBuilderGui26() { return $Lang_ImageBuilderGui26[$pref::LanguageType]; }
    //
$Lang_ImageBuilderGui27[0]="单元步进X:";
$Lang_ImageBuilderGui27[1]="Unit stepping X:";
function Language_ImageBuilderGui27() { return $Lang_ImageBuilderGui27[$pref::LanguageType]; }
    //
$Lang_ImageBuilderGui28[0]="单元按行切割";
$Lang_ImageBuilderGui28[1]="Unit cut in line";
function Language_ImageBuilderGui28() { return $Lang_ImageBuilderGui28[$pref::LanguageType]; }
    //
$Lang_ImageBuilderGui29[0]="单元数量Y:";
$Lang_ImageBuilderGui29[1]="Unit count Y:";
function Language_ImageBuilderGui29() { return $Lang_ImageBuilderGui29[$pref::LanguageType]; }
    //
$Lang_ImageBuilderGui30[0]="单元高:";
$Lang_ImageBuilderGui30[1]="Unit height:";
function Language_ImageBuilderGui30() { return $Lang_ImageBuilderGui30[$pref::LanguageType]; }
    //
$Lang_ImageBuilderGui31[0]="单元宽:";
$Lang_ImageBuilderGui31[1]="Unit width:";
function Language_ImageBuilderGui31() { return $Lang_ImageBuilderGui31[$pref::LanguageType]; }
    //
$Lang_ImageBuilderGui32[0]="单元数量X:";
$Lang_ImageBuilderGui32[1]="Unit count X";
function Language_ImageBuilderGui32() { return $Lang_ImageBuilderGui32[$pref::LanguageType]; }
    //
$Lang_ImageBuilderGui33[0]="高级设置";
$Lang_ImageBuilderGui33[1]="Advanced settings";
function Language_ImageBuilderGui33() { return $Lang_ImageBuilderGui33[$pref::LanguageType]; }
    //
$Lang_ImageBuilderGui34[0]="浏览一张图片";
$Lang_ImageBuilderGui34[1]="Browse an image";
function Language_ImageBuilderGui34() { return $Lang_ImageBuilderGui34[$pref::LanguageType]; }
    //
$Lang_ImageBuilderGui35[0]="浏览";
$Lang_ImageBuilderGui35[1]="Browse";
function Language_ImageBuilderGui35() { return $Lang_ImageBuilderGui35[$pref::LanguageType]; }
    //
$Lang_ImageBuilderGui36[0]="将此图片由你的工程里删除掉";
$Lang_ImageBuilderGui36[1]="Delete the image from your project";
function Language_ImageBuilderGui36() { return $Lang_ImageBuilderGui36[$pref::LanguageType]; }
    //
$Lang_ImageBuilderGui37[0]="删除";
$Lang_ImageBuilderGui37[1]="Delete";
function Language_ImageBuilderGui37() { return $Lang_ImageBuilderGui37[$pref::LanguageType]; }
    //
$Lang_ImageBuilderGui38[0]="保存";
$Lang_ImageBuilderGui38[1]="Save";
function Language_ImageBuilderGui38() { return $Lang_ImageBuilderGui38[$pref::LanguageType]; }
    //
$Lang_ImageBuilderGui39[0]="图片编辑器预览颜色设置";
$Lang_ImageBuilderGui39[1]="Image editor color preview set";
function Language_ImageBuilderGui39() { return $Lang_ImageBuilderGui39[$pref::LanguageType]; }
    //
$Lang_ImageBuilderGui40[0]="背景颜色";
$Lang_ImageBuilderGui40[1]="Background color";
function Language_ImageBuilderGui40() { return $Lang_ImageBuilderGui40[$pref::LanguageType]; }
    //
$Lang_ImageBuilderGui41[0]="图片预览背景颜色";
$Lang_ImageBuilderGui41[1]="Image preview background color";
function Language_ImageBuilderGui41() { return $Lang_ImageBuilderGui41[$pref::LanguageType]; }
    //
$Lang_ImageBuilderGui42[0]="基本颜色";
$Lang_ImageBuilderGui42[1]="Basic Color";
function Language_ImageBuilderGui42() { return $Lang_ImageBuilderGui42[$pref::LanguageType]; }
    //
$Lang_ImageBuilderGui43[0]="颜色吸取";
$Lang_ImageBuilderGui43[1]="Color Pick";
function Language_ImageBuilderGui43() { return $Lang_ImageBuilderGui43[$pref::LanguageType]; }
    //
$Lang_ImageBuilderGui44[0]="更多选项";
$Lang_ImageBuilderGui44[1]="More Choices";
function Language_ImageBuilderGui44() { return $Lang_ImageBuilderGui44[$pref::LanguageType]; }
    //
$Lang_ImageBuilderGui45[0]="关闭";
$Lang_ImageBuilderGui45[1]="Close";
function Language_ImageBuilderGui45() { return $Lang_ImageBuilderGui45[$pref::LanguageType]; }
    //
$Lang_ImageBuilderGui46[0]="精灵边框颜色";
$Lang_ImageBuilderGui46[1]="Sprite border color";
function Language_ImageBuilderGui46() { return $Lang_ImageBuilderGui46[$pref::LanguageType]; }
    //
$Lang_ImageBuilderGui47[0]="图片预览边框颜色";
$Lang_ImageBuilderGui47[1]="Image preview border color";
function Language_ImageBuilderGui47() { return $Lang_ImageBuilderGui47[$pref::LanguageType]; }
    //
$Lang_ImageBuilderGui48[0]="基本颜色";
$Lang_ImageBuilderGui48[1]="Basic Color";
function Language_ImageBuilderGui48() { return $Lang_ImageBuilderGui48[$pref::LanguageType]; }
    //
$Lang_ImageBuilderGui49[0]="颜色吸取";
$Lang_ImageBuilderGui49[1]="Color Pick";
function Language_ImageBuilderGui49() { return $Lang_ImageBuilderGui49[$pref::LanguageType]; }
    //
$Lang_ImageBuilderGui50[0]="更多选项";
$Lang_ImageBuilderGui50[1]="More Choices";
function Language_ImageBuilderGui50() { return $Lang_ImageBuilderGui50[$pref::LanguageType]; }
    //
$Lang_ImageBuilderGui51[0]="关闭";
$Lang_ImageBuilderGui51[1]="Close";
function Language_ImageBuilderGui51() { return $Lang_ImageBuilderGui51[$pref::LanguageType]; }

//
$Lang_OpenFileDlgExwPreview0[0]="选择图片文件...";
$Lang_OpenFileDlgExwPreview0[1]="Select image file...";
function Language_OpenFileDlgExwPreview0() { return $Lang_OpenFileDlgExwPreview0[$pref::LanguageType]; }
//
$Lang_OpenFileDlgExwPreview1[0]="当前路径";
$Lang_OpenFileDlgExwPreview1[1]="Current path";
function Language_OpenFileDlgExwPreview1() { return $Lang_OpenFileDlgExwPreview1[$pref::LanguageType]; }
  //
$Lang_OpenFileDlgExwPreview2[0]="图片大小:";
$Lang_OpenFileDlgExwPreview2[1]="Image Size:";
function Language_OpenFileDlgExwPreview2() { return $Lang_OpenFileDlgExwPreview2[$pref::LanguageType]; }
  //
$Lang_OpenFileDlgExwPreview3[0]="图片路径";
$Lang_OpenFileDlgExwPreview3[1]="Image Path";
function Language_OpenFileDlgExwPreview3() { return $Lang_OpenFileDlgExwPreview3[$pref::LanguageType]; }
  //
$Lang_OpenFileDlgExwPreview4[0]="选择";
$Lang_OpenFileDlgExwPreview4[1]="Select";
function Language_OpenFileDlgExwPreview4() { return $Lang_OpenFileDlgExwPreview4[$pref::LanguageType]; }
  //
$Lang_OpenFileDlgExwPreview5[0]="取消";
$Lang_OpenFileDlgExwPreview5[1]="Cancel";
function Language_OpenFileDlgExwPreview5() { return $Lang_OpenFileDlgExwPreview5[$pref::LanguageType]; }

//
$Lang_applicationClose0[0]="是否保存此文档所做的更改";
$Lang_applicationClose0[1]="Save the changes of the document or not";
function Language_applicationClose0() { return $Lang_applicationClose0[$pref::LanguageType]; }

//
$Lang_t2dProjectPersistence0[0]="启动Java工程";
$Lang_t2dProjectPersistence0[1]="Start Java project";
function Language_t2dProjectPersistence0() { return $Lang_t2dProjectPersistence0[$pref::LanguageType]; }
  //
$Lang_t2dProjectPersistence1[0]="启动VC工程";
$Lang_t2dProjectPersistence1[1]="Start VC project";
function Language_t2dProjectPersistence1() { return $Lang_t2dProjectPersistence1[$pref::LanguageType]; }
  //
$Lang_t2dProjectPersistence2[0]="设置启动VC工程";
$Lang_t2dProjectPersistence2[1]="Set start VC project";
function Language_t2dProjectPersistence2() { return $Lang_t2dProjectPersistence2[$pref::LanguageType]; }
  //
$Lang_t2dProjectPersistence3[0]="创建VC工程";
$Lang_t2dProjectPersistence3[1]="Create VC project";
function Language_t2dProjectPersistence3() { return $Lang_t2dProjectPersistence3[$pref::LanguageType]; }
  //
$Lang_t2dProjectPersistence4[0]="启动C#工程";
$Lang_t2dProjectPersistence4[1]="Start C# project";
function Language_t2dProjectPersistence4() { return $Lang_t2dProjectPersistence4[$pref::LanguageType]; }
  //
$Lang_t2dProjectPersistence5[0]="设置启动C#工程";
$Lang_t2dProjectPersistence5[1]="Set start C# project";
function Language_t2dProjectPersistence5() { return $Lang_t2dProjectPersistence5[$pref::LanguageType]; }
  //
$Lang_t2dProjectPersistence6[0]="启动VB工程";
$Lang_t2dProjectPersistence6[1]="Start VB project";
function Language_t2dProjectPersistence6() { return $Lang_t2dProjectPersistence6[$pref::LanguageType]; }
  //
$Lang_t2dProjectPersistence7[0]="设置启动VB工程";
$Lang_t2dProjectPersistence7[1]="Set start VB project";
function Language_t2dProjectPersistence7() { return $Lang_t2dProjectPersistence7[$pref::LanguageType]; }
//
$Lang_t2dProjectPersistence8[0]="启动Python工程";
$Lang_t2dProjectPersistence8[1]="Start Python project";
function Language_t2dProjectPersistence8() { return $Lang_t2dProjectPersistence8[$pref::LanguageType]; }
  //
$Lang_t2dProjectPersistence9[0]="设置启动Python工程";
$Lang_t2dProjectPersistence9[1]="Set start Python project";
function Language_t2dProjectPersistence9() { return $Lang_t2dProjectPersistence9[$pref::LanguageType]; }

//
$Lang_layouts_Default0[0]="地图窗口";
$Lang_layouts_Default0[1]="Scene window";
function Language_layouts_Default0() { return $Lang_layouts_Default0[$pref::LanguageType]; }

//
$Lang_CreateOtherProjectGUI0[0]="创建VC工程";
$Lang_CreateOtherProjectGUI0[1]="Create VC project";
function Language_CreateOtherProjectGUI0() { return $Lang_CreateOtherProjectGUI0[$pref::LanguageType]; }
//
$Lang_CreateOtherProjectGUI1[0]="创建其它版本Java工程";
$Lang_CreateOtherProjectGUI1[1]="Create other Java project";
function Language_CreateOtherProjectGUI1() { return $Lang_CreateOtherProjectGUI1[$pref::LanguageType]; }
//
$Lang_CreateOtherProjectGUI2[0]="创建VC工程";
$Lang_CreateOtherProjectGUI2[1]="Create VC project";
function Language_CreateOtherProjectGUI2() { return $Lang_CreateOtherProjectGUI2[$pref::LanguageType]; }

//
$Lang_CreateProjectGUI0[0]="工程名(字母及数字):";
$Lang_CreateProjectGUI0[1]="Project name(letter and number):";
function Language_CreateProjectGUI0() { return $Lang_CreateProjectGUI0[$pref::LanguageType]; }
  //
$Lang_CreateProjectGUI1[0]="工程路径:";
$Lang_CreateProjectGUI1[1]="Project path:";
function Language_CreateProjectGUI1() { return $Lang_CreateProjectGUI1[$pref::LanguageType]; }
  //
$Lang_CreateProjectGUI2[0]="确定";
$Lang_CreateProjectGUI2[1]="Confirm";
function Language_CreateProjectGUI2() { return $Lang_CreateProjectGUI2[$pref::LanguageType]; }
  //
$Lang_CreateProjectGUI3[0]="取消";
$Lang_CreateProjectGUI3[1]="Cancel";
function Language_CreateProjectGUI3() { return $Lang_CreateProjectGUI3[$pref::LanguageType]; }
  //
$Lang_CreateProjectGUI4[0]="开发工具:";
$Lang_CreateProjectGUI4[1]="Development Tool:";
function Language_CreateProjectGUI4() { return $Lang_CreateProjectGUI4[$pref::LanguageType]; }
  //
$Lang_CreateProjectGUI5[0]="工程架构:";
$Lang_CreateProjectGUI5[1]="Project Framework:";
function Language_CreateProjectGUI5() { return $Lang_CreateProjectGUI5[$pref::LanguageType]; }
  //
$Lang_CreateProjectGUI6[0]="多文件";
$Lang_CreateProjectGUI6[1]="Multi File";
function Language_CreateProjectGUI6() { return $Lang_CreateProjectGUI6[$pref::LanguageType]; }
  //
$Lang_CreateProjectGUI7[0]="单文件";
$Lang_CreateProjectGUI7[1]="Single File";
function Language_CreateProjectGUI7() { return $Lang_CreateProjectGUI7[$pref::LanguageType]; }

//
$Lang_LBPlayLevel0[0]="层级控制";
$Lang_LBPlayLevel0[1]="Layer Control";
function Language_LBPlayLevel0() { return $Lang_LBPlayLevel0[$pref::LanguageType]; }

//
$Lang_options0[0]="地图编辑器";
$Lang_options0[1]="Scene Editior";
function Language_options0() { return $Lang_options0[$pref::LanguageType]; }
  //
$Lang_options1[0]="临界值:";
$Lang_options1[1]="Threshold:";
function Language_options1() { return $Lang_options1[$pref::LanguageType]; }
  //
$Lang_options2[0]="网格设置";
$Lang_options2[1]="Grid Set";
function Language_options2() { return $Lang_options2[$pref::LanguageType]; }
  //
$Lang_options3[0]="设计模式大小:";
$Lang_options3[1]="Design Pattern Size:";
function Language_options3() { return $Lang_options3[$pref::LanguageType]; }
  //
$Lang_options4[0]="网格颜色:";
$Lang_options4[1]="Grid Color:";
function Language_options4() { return $Lang_options4[$pref::LanguageType]; }
  //
$Lang_options5[0]="显示网格";
$Lang_options5[1]="Show Grid";
function Language_options5() { return $Lang_options5[$pref::LanguageType]; }
  //
$Lang_options6[0]="网格大小 Y:";
$Lang_options6[1]="Grid size Y:";
function Language_options6() { return $Lang_options6[$pref::LanguageType]; }
  //
$Lang_options7[0]="网格大小 X:";
$Lang_options7[1]="Grid size X:";
function Language_options7() { return $Lang_options7[$pref::LanguageType]; }
  //
$Lang_options8[0]="编辑器背景:";
$Lang_options8[1]="Editor Background:";
function Language_options8() { return $Lang_options8[$pref::LanguageType]; }
  //
$Lang_options9[0]="对齐到X轴";
$Lang_options9[1]="Align to X Axis";
function Language_options9() { return $Lang_options9[$pref::LanguageType]; }
  //
$Lang_options10[0]="对齐到Y轴";
$Lang_options10[1]="Align to Y Axis";
function Language_options10() { return $Lang_options10[$pref::LanguageType]; }
  //
$Lang_options11[0]="显示脚本错误";
$Lang_options11[1]="Show script error";
function Language_options11() { return $Lang_options11[$pref::LanguageType]; }
  //
$Lang_options12[0]="确定";
$Lang_options12[1]="Confirm";
function Language_options12() { return $Lang_options12[$pref::LanguageType]; }
  //
$Lang_options13[0]="取消";
$Lang_options13[1]="Cancel";
function Language_options13() { return $Lang_options13[$pref::LanguageType]; }
  //
$Lang_options14[0]="工具设置";
$Lang_options14[1]="Tool Setting";
function Language_options14() { return $Lang_options14[$pref::LanguageType]; }
  //
$Lang_options15[0]="取消选择";
$Lang_options15[1]="Cancel the selected";
function Language_options15() { return $Lang_options15[$pref::LanguageType]; }
  //
$Lang_options16[0]="显示屏幕";
$Lang_options16[1]="Show Screen";
function Language_options16() { return $Lang_options16[$pref::LanguageType]; }
  //
$Lang_options17[0]="显示原点";
$Lang_options17[1]="Show original point";
function Language_options17() { return $Lang_options17[$pref::LanguageType]; }
  //
$Lang_options18[0]="精灵背景:";
$Lang_options18[1]="Sprite Background:";
function Language_options18() { return $Lang_options18[$pref::LanguageType]; }
  //
$Lang_options19[0]="亮";
$Lang_options19[1]="Bright";
function Language_options19() { return $Lang_options19[$pref::LanguageType]; }
  //
$Lang_options20[0]="中度";
$Lang_options20[1]="Middle";
function Language_options20() { return $Lang_options20[$pref::LanguageType]; }
  //
$Lang_options21[0]="暗";
$Lang_options21[1]="Dark";
function Language_options21() { return $Lang_options21[$pref::LanguageType]; }

//
$Lang_SaveUserTemplateGUI0[0]="保存模板";
$Lang_SaveUserTemplateGUI0[1]="Save Template";
function Language_SaveUserTemplateGUI0() { return $Lang_SaveUserTemplateGUI0[$pref::LanguageType]; }
//
$Lang_SaveUserTemplateGUI1[0]="模板名(支持中文):";
$Lang_SaveUserTemplateGUI1[1]="Template Name:";
function Language_SaveUserTemplateGUI1() { return $Lang_SaveUserTemplateGUI1[$pref::LanguageType]; }
//
$Lang_SaveUserTemplateGUI2[0]="确定";
$Lang_SaveUserTemplateGUI2[1]="Confirm";
function Language_SaveUserTemplateGUI2() { return $Lang_SaveUserTemplateGUI2[$pref::LanguageType]; }
//
$Lang_SaveUserTemplateGUI3[0]="取消";
$Lang_SaveUserTemplateGUI3[1]="Cancel";
function Language_SaveUserTemplateGUI3() { return $Lang_SaveUserTemplateGUI3[$pref::LanguageType]; }

//
$Lang_SelectProjectCreateGui0[0]="确定";
$Lang_SelectProjectCreateGui0[1]="Confirm";
function Language_SelectProjectCreateGui0() { return $Lang_SelectProjectCreateGui0[$pref::LanguageType]; }
  //
$Lang_SelectProjectCreateGui1[0]="取消";
$Lang_SelectProjectCreateGui1[1]="Cancel";
function Language_SelectProjectCreateGui1() { return $Lang_SelectProjectCreateGui1[$pref::LanguageType]; }
  //
$Lang_SelectProjectCreateGui2[0]="C语言工程";
$Lang_SelectProjectCreateGui2[1]="C Language Project";
function Language_SelectProjectCreateGui2() { return $Lang_SelectProjectCreateGui2[$pref::LanguageType]; }
  //
$Lang_SelectProjectCreateGui3[0]="C++工程";
$Lang_SelectProjectCreateGui3[1]="C++ Project";
function Language_SelectProjectCreateGui3() { return $Lang_SelectProjectCreateGui3[$pref::LanguageType]; }
  //
$Lang_SelectProjectCreateGui4[0]="Java工程";
$Lang_SelectProjectCreateGui4[1]="Jave Project";
function Language_SelectProjectCreateGui4() { return $Lang_SelectProjectCreateGui4[$pref::LanguageType]; }
  //
$Lang_SelectProjectCreateGui5[0]="C#工程";
$Lang_SelectProjectCreateGui5[1]="C# Project";
function Language_SelectProjectCreateGui5() { return $Lang_SelectProjectCreateGui5[$pref::LanguageType]; }
  //
$Lang_SelectProjectCreateGui6[0]="VB工程";
$Lang_SelectProjectCreateGui6[1]="VB Project";
function Language_SelectProjectCreateGui6() { return $Lang_SelectProjectCreateGui6[$pref::LanguageType]; }
  //
$Lang_SelectProjectCreateGui7[0]="Python工程";
$Lang_SelectProjectCreateGui7[1]="Python Project";
function Language_SelectProjectCreateGui7() { return $Lang_SelectProjectCreateGui7[$pref::LanguageType]; }

//
$Lang_SelectUserTemplateGUI0[0]="导入模板";
$Lang_SelectUserTemplateGUI0[1]="Import Template";
function Language_SelectUserTemplateGUI0() { return $Lang_SelectUserTemplateGUI0[$pref::LanguageType]; }
  //
$Lang_SelectUserTemplateGUI1[0]="导入到工程";
$Lang_SelectUserTemplateGUI1[1]="Import Into Project";
function Language_SelectUserTemplateGUI1() { return $Lang_SelectUserTemplateGUI1[$pref::LanguageType]; }
  //
$Lang_SelectUserTemplateGUI2[0]="删除模板";
$Lang_SelectUserTemplateGUI2[1]="Cancel Template";
function Language_SelectUserTemplateGUI2() { return $Lang_SelectUserTemplateGUI2[$pref::LanguageType]; }

//
$Lang_SetEclipsePathGUI0[0]="设置Eclipse.exe位置";
$Lang_SetEclipsePathGUI0[1]="Set Eclipse.exe location";
function Language_SetEclipsePathGUI0() { return $Lang_SetEclipsePathGUI0[$pref::LanguageType]; }
  //
$Lang_SetEclipsePathGUI1[0]="选择Eclipse.exe:";
$Lang_SetEclipsePathGUI1[1]="Select Eclipse.exe:";
function Language_SetEclipsePathGUI1() { return $Lang_SetEclipsePathGUI1[$pref::LanguageType]; }
  //
$Lang_SetEclipsePathGUI2[0]="确定";
$Lang_SetEclipsePathGUI2[1]="Confirm";
function Language_SetEclipsePathGUI2() { return $Lang_SetEclipsePathGUI2[$pref::LanguageType]; }
  //
$Lang_SetEclipsePathGUI3[0]="取消";
$Lang_SetEclipsePathGUI3[1]="Cancel";
function Language_SetEclipsePathGUI3() { return $Lang_SetEclipsePathGUI3[$pref::LanguageType]; }
  //
$Lang_SetEclipsePathGUI4[0]="浏览";
$Lang_SetEclipsePathGUI4[1]="Browse";
function Language_SetEclipsePathGUI4() { return $Lang_SetEclipsePathGUI4[$pref::LanguageType]; }

//
$Lang_SetServerIP0[0]="服务器IP:";
$Lang_SetServerIP0[1]="Server IP:";
function Language_SetServerIP0() { return $Lang_SetServerIP0[$pref::LanguageType]; }
  //
$Lang_SetServerIP1[0]="确定";
$Lang_SetServerIP1[1]="Confirm";
function Language_SetServerIP1() { return $Lang_SetServerIP1[$pref::LanguageType]; }
  //
$Lang_SetServerIP2[0]="取消";
$Lang_SetServerIP2[1]="Cancel";
function Language_SetServerIP2() { return $Lang_SetServerIP2[$pref::LanguageType]; }

//
$Lang_SetStartVCGUI0[0]="设置启动工程";
$Lang_SetStartVCGUI0[1]="Set Start Project";
function Language_SetStartVCGUI0() { return $Lang_SetStartVCGUI0[$pref::LanguageType]; }
  //
$Lang_SetStartVCGUI1[0]="设置Java启动工程 : 当前未设置";
$Lang_SetStartVCGUI1[1]="Set Java start project: unset at present";
function Language_SetStartVCGUI1() { return $Lang_SetStartVCGUI1[$pref::LanguageType]; }
  //
$Lang_SetStartVCGUI2[0]="设置Java启动工程 : 当前JCreator";
$Lang_SetStartVCGUI2[1]="Set Java start project:current JCreator";
function Language_SetStartVCGUI2() { return $Lang_SetStartVCGUI2[$pref::LanguageType]; }
  //
$Lang_SetStartVCGUI3[0]="设置Java启动工程 : 当前Eclipse";
$Lang_SetStartVCGUI3[1]="Set Java start project:current Eclipse";
function Language_SetStartVCGUI3() { return $Lang_SetStartVCGUI3[$pref::LanguageType]; }
  //
$Lang_SetStartVCGUI4[0]="设置Java启动工程 : 当前Netbeans";
$Lang_SetStartVCGUI4[1]="Set Java start project:current Netbeans";
function Language_SetStartVCGUI4() { return $Lang_SetStartVCGUI4[$pref::LanguageType]; }
  //
$Lang_SetStartVCGUI5[0]="设置VC启动工程 : 当前未设置";
$Lang_SetStartVCGUI5[1]="Set VC start project: unset at present";
function Language_SetStartVCGUI5() { return $Lang_SetStartVCGUI5[$pref::LanguageType]; }
  //
$Lang_SetStartVCGUI6[0]="设置VC启动工程 : 当前VC6.0";
$Lang_SetStartVCGUI6[1]="Set VC start project:current VC6.0";
function Language_SetStartVCGUI6() { return $Lang_SetStartVCGUI6[$pref::LanguageType]; }
  //
$Lang_SetStartVCGUI7[0]="设置VC启动工程 : 当前VC2012";
$Lang_SetStartVCGUI7[1]="Set VC start project:current VC2012";
function Language_SetStartVCGUI7() { return $Lang_SetStartVCGUI7[$pref::LanguageType]; }
  //
$Lang_SetStartVCGUI8[0]="设置VC启动工程 : 当前VC2015";
$Lang_SetStartVCGUI8[1]="Set VC start project:current VC2015";
function Language_SetStartVCGUI8() { return $Lang_SetStartVCGUI8[$pref::LanguageType]; }
  //
$Lang_SetStartVCGUI9[0]="设置VC启动工程 : 当前CodeBlock";
$Lang_SetStartVCGUI9[1]="Set VC start project:current CodeBlock";
function Language_SetStartVCGUI9() { return $Lang_SetStartVCGUI9[$pref::LanguageType]; }
  //
$Lang_SetStartVCGUI10[0]="设置C#启动工程 : 当前未设置";
$Lang_SetStartVCGUI10[1]="Set C# start project: unset at present";
function Language_SetStartVCGUI10() { return $Lang_SetStartVCGUI10[$pref::LanguageType]; }
  //
$Lang_SetStartVCGUI11[0]="设置C#启动工程 : 当前VC2012";
$Lang_SetStartVCGUI11[1]="Set C# start project:current VC2012";
function Language_SetStartVCGUI11() { return $Lang_SetStartVCGUI11[$pref::LanguageType]; }
  //
$Lang_SetStartVCGUI12[0]="设置C#启动工程 : 当前VC2015";
$Lang_SetStartVCGUI12[1]="Set C# start project:current VC2015";
function Language_SetStartVCGUI12() { return $Lang_SetStartVCGUI12[$pref::LanguageType]; }
  //
$Lang_SetStartVCGUI13[0]="设置VB启动工程 : 当前未设置";
$Lang_SetStartVCGUI13[1]="Set VB start project: unset at present";
function Language_SetStartVCGUI13() { return $Lang_SetStartVCGUI13[$pref::LanguageType]; }
  //
$Lang_SetStartVCGUI14[0]="设置VB启动工程 : 当前VC2012";
$Lang_SetStartVCGUI14[1]="Set VB start project:current VC2012";
function Language_SetStartVCGUI14() { return $Lang_SetStartVCGUI14[$pref::LanguageType]; }
  //
$Lang_SetStartVCGUI15[0]="设置VB启动工程 : 当前VC2015";
$Lang_SetStartVCGUI15[1]="Set VB start project:current VC2015";
function Language_SetStartVCGUI15() { return $Lang_SetStartVCGUI15[$pref::LanguageType]; }
  //
$Lang_SetStartVCGUI16[0]="设置Python启动工程 : 当前未设置";
$Lang_SetStartVCGUI16[1]="Set Python start project: unset at present";
function Language_SetStartVCGUI16() { return $Lang_SetStartVCGUI16[$pref::LanguageType]; }
  //
$Lang_SetStartVCGUI17[0]="设置Python启动工程 : 当前Eclipse";
$Lang_SetStartVCGUI17[1]="Set Python start project:current Eclipse";
function Language_SetStartVCGUI17() { return $Lang_SetStartVCGUI17[$pref::LanguageType]; }
  //
$Lang_SetStartVCGUI18[0]="设置Python启动工程 : 当前PyCharm";
$Lang_SetStartVCGUI18[1]="Set Python start project:current PyCharm";
function Language_SetStartVCGUI18() { return $Lang_SetStartVCGUI18[$pref::LanguageType]; }

//
$Lang_SetVCVersionGUI0[0]="设置开发工具";
$Lang_SetVCVersionGUI0[1]="Set Development Tool";
function Language_SetVCVersionGUI0() { return $Lang_SetVCVersionGUI0[$pref::LanguageType]; }
  //
$Lang_SetVCVersionGUI1[0]="设置Java开发工具 : 当前JCreator";
$Lang_SetVCVersionGUI1[1]="Set Java development tool:current JCreator";
function Language_SetVCVersionGUI1() { return $Lang_SetVCVersionGUI1[$pref::LanguageType]; }
  //
$Lang_SetVCVersionGUI2[0]="设置Java开发工具 : 当前Eclipse";
$Lang_SetVCVersionGUI2[1]="Set Java development tool:current Eclipse";
function Language_SetVCVersionGUI2() { return $Lang_SetVCVersionGUI2[$pref::LanguageType]; }
  //
$Lang_SetVCVersionGUI3[0]="设置Java开发工具 : 当前Netbeans";
$Lang_SetVCVersionGUI3[1]="Set Java development tool:current Netbeans";
function Language_SetVCVersionGUI3() { return $Lang_SetVCVersionGUI3[$pref::LanguageType]; }
  //
$Lang_SetVCVersionGUI4[0]="设置VC开发工具 : 当前VC6.0";
$Lang_SetVCVersionGUI4[1]="Set VC development tool:current VC6.0";
function Language_SetVCVersionGUI4() { return $Lang_SetVCVersionGUI4[$pref::LanguageType]; }
  //
$Lang_SetVCVersionGUI5[0]="设置VC开发工具 : 当前VC2012";
$Lang_SetVCVersionGUI5[1]="Set VC development tool:current VC2012";
function Language_SetVCVersionGUI5() { return $Lang_SetVCVersionGUI5[$pref::LanguageType]; }
  //
$Lang_SetVCVersionGUI6[0]="设置VC开发工具 : 当前VC2015";
$Lang_SetVCVersionGUI6[1]="Set VC development tool:current VC2015";
function Language_SetVCVersionGUI6() { return $Lang_SetVCVersionGUI6[$pref::LanguageType]; }
  //
$Lang_SetVCVersionGUI7[0]="设置VC开发工具 : 当前CodeBlock";
$Lang_SetVCVersionGUI7[1]="Set VC development tool:current CodeBlock";
function Language_SetVCVersionGUI7() { return $Lang_SetVCVersionGUI7[$pref::LanguageType]; }
  //
$Lang_SetVCVersionGUI8[0]="设置C#开发工具 : 当前VC2012";
$Lang_SetVCVersionGUI8[1]="Set C# development tool:current VC2012";
function Language_SetVCVersionGUI8() { return $Lang_SetVCVersionGUI8[$pref::LanguageType]; }
  //
$Lang_SetVCVersionGUI9[0]="设置C#开发工具 : 当前VC2015";
$Lang_SetVCVersionGUI9[1]="Set C# development tool:current VC2015";
function Language_SetVCVersionGUI9() { return $Lang_SetVCVersionGUI9[$pref::LanguageType]; }
  //
$Lang_SetVCVersionGUI10[0]="设置VB开发工具 : 当前VC2012";
$Lang_SetVCVersionGUI10[1]="Set VB development tool:current VC2012";
function Language_SetVCVersionGUI10() { return $Lang_SetVCVersionGUI10[$pref::LanguageType]; }
  //
$Lang_SetVCVersionGUI11[0]="设置VB开发工具 : 当前VC2015";
$Lang_SetVCVersionGUI11[1]="Set VB development tool:current VC2015";
function Language_SetVCVersionGUI11() { return $Lang_SetVCVersionGUI11[$pref::LanguageType]; }
  //
$Lang_SetVCVersionGUI12[0]="设置Python开发工具 : 当前Eclipse";
$Lang_SetVCVersionGUI12[1]="Set Python development tool:current Eclipse";
function Language_SetVCVersionGUI12() { return $Lang_SetVCVersionGUI12[$pref::LanguageType]; }
  //
$Lang_SetVCVersionGUI13[0]="设置Python开发工具 : 当前PyCharm";
$Lang_SetVCVersionGUI13[1]="Set Python development tool:current PyCharm";
function Language_SetVCVersionGUI13() { return $Lang_SetVCVersionGUI13[$pref::LanguageType]; }

//
$Lang_toolHelpDlg0[0]="快速帮助";
$Lang_toolHelpDlg0[1]="Quick Help";
function Language_toolHelpDlg0() { return $Lang_toolHelpDlg0[$pref::LanguageType]; }

//
$Lang_AnimatedSprites0[0]="动画精灵(Sprites)";
$Lang_AnimatedSprites0[1]="Animated Sprites";
function Language_AnimatedSprites0() { return $Lang_AnimatedSprites0[$pref::LanguageType]; }

//
$Lang_otherObjects0[0]="其它";
$Lang_otherObjects0[1]="Other";
function Language_otherObjects0() { return $Lang_otherObjects0[$pref::LanguageType]; }
  //
$Lang_otherObjects1[0]="地图物体";
$Lang_otherObjects1[1]="Scene Object";
function Language_otherObjects1() { return $Lang_otherObjects1[$pref::LanguageType]; }
  //
$Lang_otherObjects2[0]="触发器";
$Lang_otherObjects2[1]="Trigger";
function Language_otherObjects2() { return $Lang_otherObjects2[$pref::LanguageType]; }
  //
$Lang_otherObjects3[0]="路径";
$Lang_otherObjects3[1]="Path";
function Language_otherObjects3() { return $Lang_otherObjects3[$pref::LanguageType]; }
  //
$Lang_otherObjects4[0]="文字";
$Lang_otherObjects4[1]="Text";
function Language_otherObjects4() { return $Lang_otherObjects4[$pref::LanguageType]; }
  //
$Lang_otherObjects5[0]="多边形";
$Lang_otherObjects5[1]="Polygon";
function Language_otherObjects5() { return $Lang_otherObjects5[$pref::LanguageType]; }

//
$Lang_particleEffects0[0]="粒子特效";
$Lang_particleEffects0[1]="Particle Effects";
function Language_particleEffects0() { return $Lang_particleEffects0[$pref::LanguageType]; }

//
$Lang_scrollers0[0]="滚动图";
$Lang_scrollers0[1]="Scrollers";
function Language_scrollers0() { return $Lang_scrollers0[$pref::LanguageType]; }

//
$Lang_staticSprites0[0]="静态精灵(Sprites)";
$Lang_staticSprites0[1]="Static Sprites";
function Language_staticSprites0() { return $Lang_staticSprites0[$pref::LanguageType]; }

//
$Lang_tileMaps0[0]="平铺图";
$Lang_tileMaps0[1]="Tilemaps";
function Language_tileMaps0() { return $Lang_tileMaps0[$pref::LanguageType]; }

//
$Lang_align0[0]="对齐";
$Lang_align0[1]="Align";
function Language_align0() { return $Lang_align0[$pref::LanguageType]; }
  //
$Lang_align1[0]="分布";
$Lang_align1[1]="Distribute";
function Language_align1() { return $Lang_align1[$pref::LanguageType]; }
  //
$Lang_align2[0]="大小匹配";
$Lang_align2[1]="Size Match";
function Language_align2() { return $Lang_align2[$pref::LanguageType]; }
  //
$Lang_align3[0]="间隔";
$Lang_align3[1]="Interval";
function Language_align3() { return $Lang_align3[$pref::LanguageType]; }
  //
$Lang_align4[0]="对齐到屏幕";
$Lang_align4[1]="Align to Screen";
function Language_align4() { return $Lang_align4[$pref::LanguageType]; }

//
$Lang_particleEffectGraph0[0]="编辑此特效的属性";
$Lang_particleEffectGraph0[1]="Edit the  effect property";
function Language_particleEffectGraph0() { return $Lang_particleEffectGraph0[$pref::LanguageType]; }
  //
$Lang_particleEffectGraph1[0]="保存此特效至文件";
$Lang_particleEffectGraph1[1]="Save the effect to file";
function Language_particleEffectGraph1() { return $Lang_particleEffectGraph1[$pref::LanguageType]; }
  //
$Lang_particleEffectGraph2[0]="加载一个特效至此特效";
$Lang_particleEffectGraph2[1]="Add another effect to this";
function Language_particleEffectGraph2() { return $Lang_particleEffectGraph2[$pref::LanguageType]; }

//
$Lang_particleEmitterStack0[0]="添加一个粒子至此特效";
$Lang_particleEmitterStack0[1]="Add a particle to this effect";
function Language_particleEmitterStack0() { return $Lang_particleEmitterStack0[$pref::LanguageType]; }
  //
$Lang_particleEmitterStack1[0]="创建粒子:";
$Lang_particleEmitterStack1[1]="Create Particle:";
function Language_particleEmitterStack1() { return $Lang_particleEmitterStack1[$pref::LanguageType]; }
  //
$Lang_particleEmitterStack2[0]="编辑粒子图像";
$Lang_particleEmitterStack2[1]="Edit particle image";
function Language_particleEmitterStack2() { return $Lang_particleEmitterStack2[$pref::LanguageType]; }
  //
$Lang_particleEmitterStack3[0]="显示该粒子相关图像数据";
$Lang_particleEmitterStack3[1]="Show the particle's image data";
function Language_particleEmitterStack3() { return $Lang_particleEmitterStack3[$pref::LanguageType]; }
  //
$Lang_particleEmitterStack4[0]="图片";
$Lang_particleEmitterStack4[1]="Image";
function Language_particleEmitterStack4() { return $Lang_particleEmitterStack4[$pref::LanguageType]; }
  //
$Lang_particleEmitterStack5[0]="动画";
$Lang_particleEmitterStack5[1]="Animation";
function Language_particleEmitterStack5() { return $Lang_particleEmitterStack5[$pref::LanguageType]; }
  //
$Lang_particleEmitterStack6[0]="帧数";
$Lang_particleEmitterStack6[1]="Frame Count";
function Language_particleEmitterStack6() { return $Lang_particleEmitterStack6[$pref::LanguageType]; }
  //
$Lang_particleEmitterStack7[0]="显示帧数";
$Lang_particleEmitterStack7[1]="Show the frame count";
function Language_particleEmitterStack7() { return $Lang_particleEmitterStack7[$pref::LanguageType]; }
  //
$Lang_particleEmitterStack8[0]="类型";
$Lang_particleEmitterStack8[1]="Type";
function Language_particleEmitterStack8() { return $Lang_particleEmitterStack8[$pref::LanguageType]; }
  //
$Lang_particleEmitterStack9[0]="方向";
$Lang_particleEmitterStack9[1]="Orientation";
function Language_particleEmitterStack9() { return $Lang_particleEmitterStack9[$pref::LanguageType]; }
  //
$Lang_particleEmitterStack10[0]="固定角度偏移";
$Lang_particleEmitterStack10[1]="Fixed Angle Offset";
function Language_particleEmitterStack10() { return $Lang_particleEmitterStack10[$pref::LanguageType]; }
  //
$Lang_particleEmitterStack11[0]="轴心点";
$Lang_particleEmitterStack11[1]="Pivot Point";
function Language_particleEmitterStack11() { return $Lang_particleEmitterStack11[$pref::LanguageType]; }
  //
$Lang_particleEmitterStack12[0]="作用力角度";
$Lang_particleEmitterStack12[1]="Force Angle";
function Language_particleEmitterStack12() { return $Lang_particleEmitterStack12[$pref::LanguageType]; }
  //
$Lang_particleEmitterStack13[0]="固定朝向";
$Lang_particleEmitterStack13[1]="Fixed Aspect";
function Language_particleEmitterStack13() { return $Lang_particleEmitterStack13[$pref::LanguageType]; }
  //
$Lang_particleEmitterStack14[0]="使用特效发射器";
$Lang_particleEmitterStack14[1]="Use Effect Emission";
function Language_particleEmitterStack14() { return $Lang_particleEmitterStack14[$pref::LanguageType]; }
  //
$Lang_particleEmitterStack15[0]="强烈特效";
$Lang_particleEmitterStack15[1]="Intense Effect";
function Language_particleEmitterStack15() { return $Lang_particleEmitterStack15[$pref::LanguageType]; }
  //
$Lang_particleEmitterStack16[0]="单一特效";
$Lang_particleEmitterStack16[1]="Single Particle";
function Language_particleEmitterStack16() { return $Lang_particleEmitterStack16[$pref::LanguageType]; }
  //
$Lang_particleEmitterStack17[0]="跟随位置";
$Lang_particleEmitterStack17[1]="Attach Position";
function Language_particleEmitterStack17() { return $Lang_particleEmitterStack17[$pref::LanguageType]; }
  //
$Lang_particleEmitterStack18[0]="跟随朝向";
$Lang_particleEmitterStack18[1]="Attach Rotation";
function Language_particleEmitterStack18() { return $Lang_particleEmitterStack18[$pref::LanguageType]; }
  //
$Lang_particleEmitterStack19[0]="旋转发射器";
$Lang_particleEmitterStack19[1]="Rotation Emission";
function Language_particleEmitterStack19() { return $Lang_particleEmitterStack19[$pref::LanguageType]; }
  //
$Lang_particleEmitterStack20[0]="靠前的先发射";
$Lang_particleEmitterStack20[1]="Front emission first";
function Language_particleEmitterStack20() { return $Lang_particleEmitterStack20[$pref::LanguageType]; }
  //
$Lang_particleEmitterStack21[0]="删除此粒子";
$Lang_particleEmitterStack21[1]="Delete the particle";
function Language_particleEmitterStack21() { return $Lang_particleEmitterStack21[$pref::LanguageType]; }

//
$Lang_particleGraphFieldList0[0]="上一个";
$Lang_particleGraphFieldList0[1]="Previous One";
function Language_particleGraphFieldList0() { return $Lang_particleGraphFieldList0[$pref::LanguageType]; }
  //
$Lang_particleGraphFieldList1[0]="下一个";
$Lang_particleGraphFieldList1[1]="Next One";
function Language_particleGraphFieldList1() { return $Lang_particleGraphFieldList1[$pref::LanguageType]; }
  //
$Lang_particleGraphFieldList2[0]="关闭";
$Lang_particleGraphFieldList2[1]="Close";
function Language_particleGraphFieldList2() { return $Lang_particleGraphFieldList2[$pref::LanguageType]; }
  //
$Lang_particleGraphFieldList3[0]="当前属性域:";
$Lang_particleGraphFieldList3[1]="Current Property Field";
function Language_particleGraphFieldList3() { return $Lang_particleGraphFieldList3[$pref::LanguageType]; }
  //
$Lang_particleGraphFieldList4[0]="值";
$Lang_particleGraphFieldList4[1]="Value";
function Language_particleGraphFieldList4() { return $Lang_particleGraphFieldList4[$pref::LanguageType]; }
  //
$Lang_particleGraphFieldList5[0]="时间";
$Lang_particleGraphFieldList5[1]="Time";
function Language_particleGraphFieldList5() { return $Lang_particleGraphFieldList5[$pref::LanguageType]; }
  //
$Lang_particleGraphFieldList6[0]="值 (最小/最大)";
$Lang_particleGraphFieldList6[1]="Value (Minimum/Maximum)";
function Language_particleGraphFieldList6() { return $Lang_particleGraphFieldList6[$pref::LanguageType]; }
  //
$Lang_particleGraphFieldList7[0]="时间 (最小/最大)";
$Lang_particleGraphFieldList7[1]="Time (Minimum/Maximum)";
function Language_particleGraphFieldList7() { return $Lang_particleGraphFieldList7[$pref::LanguageType]; }
  //
$Lang_particleGraphFieldList8[0]="添加关键帧 - 无效时间";
$Lang_particleGraphFieldList8[1]="Add key frame- invalid time";
function Language_particleGraphFieldList8() { return $Lang_particleGraphFieldList8[$pref::LanguageType]; }
  //
$Lang_particleGraphFieldList9[0]="时间超出允许的范围 (最小 = ";
$Lang_particleGraphFieldList9[1]="time out of range (minimum = ";
function Language_particleGraphFieldList9() { return $Lang_particleGraphFieldList9[$pref::LanguageType]; }
    //
$Lang_particleGraphFieldList10[0]="最大 = ";
$Lang_particleGraphFieldList10[1]="maximum= ";
function Language_particleGraphFieldList10() { return $Lang_particleGraphFieldList10[$pref::LanguageType]; }
  //
$Lang_particleGraphFieldList11[0]="添加关键帧 - 无效值";
$Lang_particleGraphFieldList11[1]="Add key frame- invalid value";
function Language_particleGraphFieldList11() { return $Lang_particleGraphFieldList11[$pref::LanguageType]; }
    //
$Lang_particleGraphFieldList12[0]="值超出允许的范围 (最小 = ";
$Lang_particleGraphFieldList12[1]="value out of range(minimum = ";
function Language_particleGraphFieldList12() { return $Lang_particleGraphFieldList12[$pref::LanguageType]; }
  //
$Lang_particleGraphFieldList13[0]="最大 = ";
$Lang_particleGraphFieldList13[1]="maximum= ";
function Language_particleGraphFieldList13() { return $Lang_particleGraphFieldList13[$pref::LanguageType]; }

//
$Lang_showGraphButton0[0]="删除粒子错误";
$Lang_showGraphButton0[1]="Particles delete error";
function Language_showGraphButton0() { return $Lang_showGraphButton0[$pref::LanguageType]; }
  //
$Lang_showGraphButton1[0]="你的特效至少有一个粒子!";
$Lang_showGraphButton1[1]="Needs at least one particle!";
function Language_showGraphButton1() { return $Lang_showGraphButton1[$pref::LanguageType]; }

//
$Lang_layerManager0[0]="层级 ";
$Lang_layerManager0[1]="Layer ";
function Language_layerManager0() { return $Lang_layerManager0[$pref::LanguageType]; }
  //
$Lang_layerManager1[0]="锁定/解锁此层级";
$Lang_layerManager1[1]="Lock/Unlock the layer";
function Language_layerManager1() { return $Lang_layerManager1[$pref::LanguageType]; }
  //
$Lang_layerManager2[0]="显示/隐藏此层级";
$Lang_layerManager2[1]="Show/Hide the layer";
function Language_layerManager2() { return $Lang_layerManager2[$pref::LanguageType]; }
  //
$Lang_layerManager3[0]="层级排序方式";
$Lang_layerManager3[1]="Layer Sort Order";
function Language_layerManager3() { return $Lang_layerManager3[$pref::LanguageType]; }
  
//
$Lang_mask0[0]="全部激活";
$Lang_mask0[1]="Activate All";
function Language_mask0() { return $Lang_mask0[$pref::LanguageType]; }
//
$Lang_mask1[0]="所有";
$Lang_mask1[1]="All";
function Language_mask1() { return $Lang_mask1[$pref::LanguageType]; }
//
$Lang_mask2[0]="全部变不活动";
$Lang_mask2[1]="All change to inactive";
function Language_mask2() { return $Lang_mask2[$pref::LanguageType]; }
//
$Lang_mask3[0]="无";
$Lang_mask3[1]="None";
function Language_mask3() { return $Lang_mask3[$pref::LanguageType]; }

//
$Lang_quickEditFieldBaseType0[0]="名字中有非法字符";
$Lang_quickEditFieldBaseType0[1]="Name contains  illegal character";
function Language_quickEditFieldBaseType0() { return $Lang_quickEditFieldBaseType0[$pref::LanguageType]; }
//
$Lang_quickEditFieldBaseType1[0]="名字必须由字母、数字、下划线组成，并且首字母不能是数字";
$Lang_quickEditFieldBaseType1[1]="Name should include letter,number and underline,numbercannot be used as the first letter";
function Language_quickEditFieldBaseType1() { return $Lang_quickEditFieldBaseType1[$pref::LanguageType]; }

//
$Lang_t2dAnimatedSprite0[0]="动画";
$Lang_t2dAnimatedSprite0[1]="Animation";
function Language_t2dAnimatedSprite0() { return $Lang_t2dAnimatedSprite0[$pref::LanguageType]; }
//
$Lang_t2dAnimatedSprite1[0]="动画播放";
$Lang_t2dAnimatedSprite1[1]="Play animation";
function Language_t2dAnimatedSprite1() { return $Lang_t2dAnimatedSprite1[$pref::LanguageType]; }
//
$Lang_t2dAnimatedSprite2[0]="动画精灵";
$Lang_t2dAnimatedSprite2[1]="Animated Sprite";
function Language_t2dAnimatedSprite2() { return $Lang_t2dAnimatedSprite2[$pref::LanguageType]; }

//
$Lang_t2dParticleEffect0[0]="特效模式";
$Lang_t2dParticleEffect0[1]="Effect mode";
function Language_t2dParticleEffect0() { return $Lang_t2dParticleEffect0[$pref::LanguageType]; }
//
$Lang_t2dParticleEffect1[0]="特效的生命模式: 无限播放、循环播放";
$Lang_t2dParticleEffect1[1]="Effect life mode:infinite play,cycle play";
function Language_t2dParticleEffect1() { return $Lang_t2dParticleEffect1[$pref::LanguageType]; }
//
$Lang_t2dParticleEffect2[0]="特效生命周期";
$Lang_t2dParticleEffect2[1]="Effect lifecycle";
function Language_t2dParticleEffect2() { return $Lang_t2dParticleEffect2[$pref::LanguageType]; }
//
$Lang_t2dParticleEffect3[0]="特效生命时长";
$Lang_t2dParticleEffect3[1]="Effect life time";
function Language_t2dParticleEffect3() { return $Lang_t2dParticleEffect3[$pref::LanguageType]; }
//
$Lang_t2dParticleEffect4[0]="加载特效";
$Lang_t2dParticleEffect4[1]="Load Effect";
function Language_t2dParticleEffect4() { return $Lang_t2dParticleEffect4[$pref::LanguageType]; }
//
$Lang_t2dParticleEffect5[0]="保存特效";
$Lang_t2dParticleEffect5[1]="Save Effect";
function Language_t2dParticleEffect5() { return $Lang_t2dParticleEffect5[$pref::LanguageType]; }
//
$Lang_t2dParticleEffect6[0]="粒子特效";
$Lang_t2dParticleEffect6[1]="Particle Effect";
function Language_t2dParticleEffect6() { return $Lang_t2dParticleEffect6[$pref::LanguageType]; }

//
$Lang_t2dPath0[0]="路径类型";
$Lang_t2dPath0[1]="Path Type";
function Language_t2dPath0() { return $Lang_t2dPath0[$pref::LanguageType]; }
//
$Lang_t2dPath1[0]="路径的插值类型";
$Lang_t2dPath1[1]="Path interpolation type";
function Language_t2dPath1() { return $Lang_t2dPath1[$pref::LanguageType]; }
//
$Lang_t2dPath2[0]="路径";
$Lang_t2dPath2[1]="Path";
function Language_t2dPath2() { return $Lang_t2dPath2[$pref::LanguageType]; }

//
$Lang_t2dSceneGraph0[0]="屏幕位置";
$Lang_t2dSceneGraph0[1]="Screen Position";
function Language_t2dSceneGraph0() { return $Lang_t2dSceneGraph0[$pref::LanguageType]; }
//
$Lang_t2dSceneGraph1[0]="设置屏幕位置";
$Lang_t2dSceneGraph1[1]="Set screen position";
function Language_t2dSceneGraph1() { return $Lang_t2dSceneGraph1[$pref::LanguageType]; }
//
$Lang_t2dSceneGraph2[0]="宽";
$Lang_t2dSceneGraph2[1]="Width";
function Language_t2dSceneGraph2() { return $Lang_t2dSceneGraph2[$pref::LanguageType]; }
//
$Lang_t2dSceneGraph3[0]="高";
$Lang_t2dSceneGraph3[1]="Height";
function Language_t2dSceneGraph3() { return $Lang_t2dSceneGraph3[$pref::LanguageType]; }
//
$Lang_t2dSceneGraph4[0]="设置屏幕大小";
$Lang_t2dSceneGraph4[1]="Set screen size";
function Language_t2dSceneGraph4() { return $Lang_t2dSceneGraph4[$pref::LanguageType]; }
//
$Lang_t2dSceneGraph5[0]="窗口大小";
$Lang_t2dSceneGraph5[1]="Window size";
function Language_t2dSceneGraph5() { return $Lang_t2dSceneGraph5[$pref::LanguageType]; }
//
$Lang_t2dSceneGraph6[0]="设置窗口大小";
$Lang_t2dSceneGraph6[1]="Set window size";
function Language_t2dSceneGraph6() { return $Lang_t2dSceneGraph6[$pref::LanguageType]; }
//
$Lang_t2dSceneGraph7[0]="边界盒";
$Lang_t2dSceneGraph7[1]="Bounding boxes";
function Language_t2dSceneGraph7() { return $Lang_t2dSceneGraph7[$pref::LanguageType]; }
//
$Lang_t2dSceneGraph8[0]="显示精灵边界盒";
$Lang_t2dSceneGraph8[1]="Show Sprite bounding boxes";
function Language_t2dSceneGraph8() { return $Lang_t2dSceneGraph8[$pref::LanguageType]; }
//
$Lang_t2dSceneGraph9[0]="链接点";
$Lang_t2dSceneGraph9[1]="Link points";
function Language_t2dSceneGraph9() { return $Lang_t2dSceneGraph9[$pref::LanguageType]; }
//
$Lang_t2dSceneGraph10[0]="显示精灵链接点";
$Lang_t2dSceneGraph10[1]="Show Sprite link points";
function Language_t2dSceneGraph10() { return $Lang_t2dSceneGraph10[$pref::LanguageType]; }
//
$Lang_t2dSceneGraph11[0]="世界边界限制";
$Lang_t2dSceneGraph11[1]="World border limit";
function Language_t2dSceneGraph11() { return $Lang_t2dSceneGraph11[$pref::LanguageType]; }
//
$Lang_t2dSceneGraph12[0]="显示精灵世界边界限制";
$Lang_t2dSceneGraph12[1]="Show Sprite world border limit";
function Language_t2dSceneGraph12() { return $Lang_t2dSceneGraph12[$pref::LanguageType]; }
//
$Lang_t2dSceneGraph13[0]="碰撞盒";
$Lang_t2dSceneGraph13[1]="Collision boxes";
function Language_t2dSceneGraph13() { return $Lang_t2dSceneGraph13[$pref::LanguageType]; }
//
$Lang_t2dSceneGraph14[0]="显示精灵碰撞盒";
$Lang_t2dSceneGraph14[1]="Show Sprite collision boxes";
function Language_t2dSceneGraph14() { return $Lang_t2dSceneGraph14[$pref::LanguageType]; }
//
$Lang_t2dSceneGraph15[0]="排序点";
$Lang_t2dSceneGraph15[1]="Sort points";
function Language_t2dSceneGraph15() { return $Lang_t2dSceneGraph15[$pref::LanguageType]; }
//
$Lang_t2dSceneGraph16[0]="显示精灵排序点";
$Lang_t2dSceneGraph16[1]="Show Sprite sort points";
function Language_t2dSceneGraph16() { return $Lang_t2dSceneGraph16[$pref::LanguageType]; }
//
$Lang_t2dSceneGraph17[0]="屏幕";
$Lang_t2dSceneGraph17[1]="Screen";
function Language_t2dSceneGraph17() { return $Lang_t2dSceneGraph17[$pref::LanguageType]; }
//
$Lang_t2dSceneGraph18[0]="显示选项";
$Lang_t2dSceneGraph18[1]="Show Options";
function Language_t2dSceneGraph18() { return $Lang_t2dSceneGraph18[$pref::LanguageType]; }

//
$Lang_t2dSceneObject0[0]="名字";
$Lang_t2dSceneObject0[1]="Name";
function Language_t2dSceneObject0() { return $Lang_t2dSceneObject0[$pref::LanguageType]; }
//
$Lang_t2dSceneObject1[0]="程序中使用的名字";
$Lang_t2dSceneObject1[1]="Name used in program";
function Language_t2dSceneObject1() { return $Lang_t2dSceneObject1[$pref::LanguageType]; }
//
$Lang_t2dSceneObject2[0]="位置";
$Lang_t2dSceneObject2[1]="Position";
function Language_t2dSceneObject2() { return $Lang_t2dSceneObject2[$pref::LanguageType]; }
//
$Lang_t2dSceneObject3[0]="大小";
$Lang_t2dSceneObject3[1]="Size";
function Language_t2dSceneObject3() { return $Lang_t2dSceneObject3[$pref::LanguageType]; }
//
$Lang_t2dSceneObject4[0]="宽";
$Lang_t2dSceneObject4[1]="Width";
function Language_t2dSceneObject4() { return $Lang_t2dSceneObject4[$pref::LanguageType]; }
//
$Lang_t2dSceneObject5[0]="高";
$Lang_t2dSceneObject5[1]="Height";
function Language_t2dSceneObject5() { return $Lang_t2dSceneObject5[$pref::LanguageType]; }
//
$Lang_t2dSceneObject6[0]="朝向";
$Lang_t2dSceneObject6[1]="Orientation";
function Language_t2dSceneObject6() { return $Lang_t2dSceneObject6[$pref::LanguageType]; }
//
$Lang_t2dSceneObject7[0]="旋转角度";
$Lang_t2dSceneObject7[1]="Rotation angle";
function Language_t2dSceneObject7() { return $Lang_t2dSceneObject7[$pref::LanguageType]; }
//
$Lang_t2dSceneObject8[0]="自动旋转";
$Lang_t2dSceneObject8[1]="Auto rotation";
function Language_t2dSceneObject8() { return $Lang_t2dSceneObject8[$pref::LanguageType]; }
//
$Lang_t2dSceneObject9[0]="自动旋转速度";
$Lang_t2dSceneObject9[1]="Auto rotation velocity";
function Language_t2dSceneObject9() { return $Lang_t2dSceneObject9[$pref::LanguageType]; }
//
$Lang_t2dSceneObject10[0]="水平翻转";
$Lang_t2dSceneObject10[1]="Flip horizontal";
function Language_t2dSceneObject10() { return $Lang_t2dSceneObject10[$pref::LanguageType]; }
//
$Lang_t2dSceneObject11[0]="垂直翻转";
$Lang_t2dSceneObject11[1]="Flip vertical";
function Language_t2dSceneObject11() { return $Lang_t2dSceneObject11[$pref::LanguageType]; }
//
$Lang_t2dSceneObject12[0]="排序点";
$Lang_t2dSceneObject12[1]="Sort points";
function Language_t2dSceneObject12() { return $Lang_t2dSceneObject12[$pref::LanguageType]; }
//
$Lang_t2dSceneObject13[0]="图片显示顺序的排序依据";
$Lang_t2dSceneObject13[1]="Sort by image show order";
function Language_t2dSceneObject13() { return $Lang_t2dSceneObject13[$pref::LanguageType]; }
//
$Lang_t2dSceneObject14[0]="层";
$Lang_t2dSceneObject14[1]="Layer";
function Language_t2dSceneObject14() { return $Lang_t2dSceneObject14[$pref::LanguageType]; }
//
$Lang_t2dSceneObject15[0]="显示的层级";
$Lang_t2dSceneObject15[1]="Layer shown";
function Language_t2dSceneObject15() { return $Lang_t2dSceneObject15[$pref::LanguageType]; }
//
$Lang_t2dSceneObject16[0]="组";
$Lang_t2dSceneObject16[1]="Group";
function Language_t2dSceneObject16() { return $Lang_t2dSceneObject16[$pref::LanguageType]; }
//
$Lang_t2dSceneObject17[0]="图像组";
$Lang_t2dSceneObject17[1]="Image group";
function Language_t2dSceneObject17() { return $Lang_t2dSceneObject17[$pref::LanguageType]; }
//
$Lang_t2dSceneObject18[0]="后置/前置";
$Lang_t2dSceneObject18[1]="Move backward/forward";
function Language_t2dSceneObject18() { return $Lang_t2dSceneObject18[$pref::LanguageType]; }
//
$Lang_t2dSceneObject19[0]="在同一层级中进行前置或后置";
$Lang_t2dSceneObject19[1]="Move backward/forward in the the same layer";
function Language_t2dSceneObject19() { return $Lang_t2dSceneObject19[$pref::LanguageType]; }
//
$Lang_t2dSceneObject20[0]="可见";
$Lang_t2dSceneObject20[1]="Visible";
function Language_t2dSceneObject20() { return $Lang_t2dSceneObject20[$pref::LanguageType]; }
//
$Lang_t2dSceneObject21[0]="显示或者隐藏";
$Lang_t2dSceneObject21[1]="Show or hide";
function Language_t2dSceneObject21() { return $Lang_t2dSceneObject21[$pref::LanguageType]; }
//
$Lang_t2dSceneObject22[0]="生命周期";
$Lang_t2dSceneObject22[1]="Lifetime";
function Language_t2dSceneObject22() { return $Lang_t2dSceneObject22[$pref::LanguageType]; }
//
$Lang_t2dSceneObject23[0]="生命周期结束自动删除，单位秒";
$Lang_t2dSceneObject23[1]="Auto delete when lifetime is over,unit second";
function Language_t2dSceneObject23() { return $Lang_t2dSceneObject23[$pref::LanguageType]; }
//
$Lang_t2dSceneObject24[0]="起始点";
$Lang_t2dSceneObject24[1]="Starting point";
function Language_t2dSceneObject24() { return $Lang_t2dSceneObject24[$pref::LanguageType]; }
//
$Lang_t2dSceneObject25[0]="该精灵寻路的起始点";
$Lang_t2dSceneObject25[1]="The starting point of sprites pathfinding";
function Language_t2dSceneObject25() { return $Lang_t2dSceneObject25[$pref::LanguageType]; }
//
$Lang_t2dSceneObject26[0]="终止点";
$Lang_t2dSceneObject26[1]="End point";
function Language_t2dSceneObject26() { return $Lang_t2dSceneObject26[$pref::LanguageType]; }
//
$Lang_t2dSceneObject27[0]="该精灵寻路的终止点";
$Lang_t2dSceneObject27[1]="The end point of sprites pathfinding";
function Language_t2dSceneObject27() { return $Lang_t2dSceneObject27[$pref::LanguageType]; }
//
$Lang_t2dSceneObject28[0]="速度";
$Lang_t2dSceneObject28[1]="Speed";
function Language_t2dSceneObject28() { return $Lang_t2dSceneObject28[$pref::LanguageType]; }
//
$Lang_t2dSceneObject29[0]="跟随路径移动的速度";
$Lang_t2dSceneObject29[1]="Speed of moving with the path";
function Language_t2dSceneObject29() { return $Lang_t2dSceneObject29[$pref::LanguageType]; }
//
$Lang_t2dSceneObject30[0]="向前移动";
$Lang_t2dSceneObject30[1]="Move forward";
function Language_t2dSceneObject30() { return $Lang_t2dSceneObject30[$pref::LanguageType]; }
//
$Lang_t2dSceneObject31[0]="直接向前移动";
$Lang_t2dSceneObject31[1]="Move forward directly";
function Language_t2dSceneObject31() { return $Lang_t2dSceneObject31[$pref::LanguageType]; }
//
$Lang_t2dSceneObject32[0]="朝向该路径";
$Lang_t2dSceneObject32[1]="Move toward the path";
function Language_t2dSceneObject32() { return $Lang_t2dSceneObject32[$pref::LanguageType]; }
//
$Lang_t2dSceneObject33[0]="旋转该精灵至与路径方向一致";
$Lang_t2dSceneObject33[1]="Rotate the Sprite to the same orientation with the path";
function Language_t2dSceneObject33() { return $Lang_t2dSceneObject33[$pref::LanguageType]; }
//
$Lang_t2dSceneObject34[0]="旋转偏移";
$Lang_t2dSceneObject34[1]="Rotation offset";
function Language_t2dSceneObject34() { return $Lang_t2dSceneObject34[$pref::LanguageType]; }
//
$Lang_t2dSceneObject35[0]="在路径上旋转的偏移";
$Lang_t2dSceneObject35[1]="Path rotation offset";
function Language_t2dSceneObject35() { return $Lang_t2dSceneObject35[$pref::LanguageType]; }
//
$Lang_t2dSceneObject36[0]="循环移动";
$Lang_t2dSceneObject36[1]="Move loops";
function Language_t2dSceneObject36() { return $Lang_t2dSceneObject36[$pref::LanguageType]; }
//
$Lang_t2dSceneObject37[0]="循环移动次数";
$Lang_t2dSceneObject37[1]="Move loops times";
function Language_t2dSceneObject37() { return $Lang_t2dSceneObject37[$pref::LanguageType]; }
//
$Lang_t2dSceneObject38[0]="跟随模式";
$Lang_t2dSceneObject38[1]="Follow mode";
function Language_t2dSceneObject38() { return $Lang_t2dSceneObject38[$pref::LanguageType]; }
//
$Lang_t2dSceneObject39[0]="移动到终点的跟随路径模式";
$Lang_t2dSceneObject39[1]="Move to the end follow mode";
function Language_t2dSceneObject39() { return $Lang_t2dSceneObject39[$pref::LanguageType]; }
//
$Lang_t2dSceneObject40[0]="发送碰撞";
$Lang_t2dSceneObject40[1]="Collision send";
function Language_t2dSceneObject40() { return $Lang_t2dSceneObject40[$pref::LanguageType]; }
//
$Lang_t2dSceneObject41[0]="与其它精灵接触时，将主动与别的精灵产生碰撞";
$Lang_t2dSceneObject41[1]="Auto collision when touching other sprites";
function Language_t2dSceneObject41() { return $Lang_t2dSceneObject41[$pref::LanguageType]; }
//
$Lang_t2dSceneObject42[0]="接受碰撞";
$Lang_t2dSceneObject42[1]="Collision receive";
function Language_t2dSceneObject42() { return $Lang_t2dSceneObject42[$pref::LanguageType]; }
//
$Lang_t2dSceneObject43[0]="与其它精灵接触时，将接受别的精灵发送的碰撞";
$Lang_t2dSceneObject43[1]="Receive collision sent by other sprites when touching";
function Language_t2dSceneObject43() { return $Lang_t2dSceneObject43[$pref::LanguageType]; }
//
$Lang_t2dSceneObject44[0]="发送物理碰撞";
$Lang_t2dSceneObject44[1]="Send physics collision";
function Language_t2dSceneObject44() { return $Lang_t2dSceneObject44[$pref::LanguageType]; }
//
$Lang_t2dSceneObject45[0]="与其它精灵接触时，将使用物理主动与别的精灵产生碰撞";
$Lang_t2dSceneObject45[1]="Use physics to collide with other sprites when touching";
function Language_t2dSceneObject45() { return $Lang_t2dSceneObject45[$pref::LanguageType]; }
//
$Lang_t2dSceneObject46[0]="接受物理碰撞";
$Lang_t2dSceneObject46[1]="Receive physics collision";
function Language_t2dSceneObject46() { return $Lang_t2dSceneObject46[$pref::LanguageType]; }
//
$Lang_t2dSceneObject47[0]="与其它精灵接触时，将接受别的精灵发送的物理碰撞";
$Lang_t2dSceneObject47[1]="Receive physics collision sent by other sprites when touching";
function Language_t2dSceneObject47() { return $Lang_t2dSceneObject47[$pref::LanguageType]; }
//
$Lang_t2dSceneObject48[0]="物理碰撞反应";
$Lang_t2dSceneObject48[1]="Physics collision response";
function Language_t2dSceneObject48() { return $Lang_t2dSceneObject48[$pref::LanguageType]; }
//
$Lang_t2dSceneObject49[0]="分别为：关闭、停渐、反弹、静止、删除、刚体、自定义";
$Lang_t2dSceneObject49[1]="Respectively:off,clamp,bounce,sticky,kill,rigid,custom";
function Language_t2dSceneObject49() { return $Lang_t2dSceneObject49[$pref::LanguageType]; }
//
$Lang_t2dSceneObject50[0]="碰撞的层级";
$Lang_t2dSceneObject50[1]="Collision Layers";
function Language_t2dSceneObject50() { return $Lang_t2dSceneObject50[$pref::LanguageType]; }
//
$Lang_t2dSceneObject51[0]="更改此精灵可以进行碰撞的层级";
$Lang_t2dSceneObject51[1]="Change Sprite collision layers";
function Language_t2dSceneObject51() { return $Lang_t2dSceneObject51[$pref::LanguageType]; }
//
$Lang_t2dSceneObject52[0]="速度";
$Lang_t2dSceneObject52[1]="Velocity";
function Language_t2dSceneObject52() { return $Lang_t2dSceneObject52[$pref::LanguageType]; }
//
$Lang_t2dSceneObject53[0]="直线速度";
$Lang_t2dSceneObject53[1]="Linear velocity";
function Language_t2dSceneObject53() { return $Lang_t2dSceneObject53[$pref::LanguageType]; }
//
$Lang_t2dSceneObject54[0]="最小";
$Lang_t2dSceneObject54[1]="Minimum";
function Language_t2dSceneObject54() { return $Lang_t2dSceneObject54[$pref::LanguageType]; }
//
$Lang_t2dSceneObject55[0]="最大";
$Lang_t2dSceneObject55[1]="Maximum";
function Language_t2dSceneObject55() { return $Lang_t2dSceneObject55[$pref::LanguageType]; }
//
$Lang_t2dSceneObject56[0]="最小直线速度";
$Lang_t2dSceneObject56[1]="Min linear velocity";
function Language_t2dSceneObject56() { return $Lang_t2dSceneObject56[$pref::LanguageType]; }
//
$Lang_t2dSceneObject57[0]="角速度";
$Lang_t2dSceneObject57[1]="Angular velocity";
function Language_t2dSceneObject57() { return $Lang_t2dSceneObject57[$pref::LanguageType]; }
//
$Lang_t2dSceneObject58[0]="按角度旋转速度";
$Lang_t2dSceneObject58[1]="According to angular rotation velocity";
function Language_t2dSceneObject58() { return $Lang_t2dSceneObject58[$pref::LanguageType]; }
//
$Lang_t2dSceneObject59[0]="最小";
$Lang_t2dSceneObject59[1]="Minimum";
function Language_t2dSceneObject59() { return $Lang_t2dSceneObject59[$pref::LanguageType]; }
//
$Lang_t2dSceneObject60[0]="最大";
$Lang_t2dSceneObject60[1]="Maximum";
function Language_t2dSceneObject60() { return $Lang_t2dSceneObject60[$pref::LanguageType]; }
//
$Lang_t2dSceneObject61[0]="最小角速度";
$Lang_t2dSceneObject61[1]="Min angular velocity";
function Language_t2dSceneObject61() { return $Lang_t2dSceneObject61[$pref::LanguageType]; }
//
$Lang_t2dSceneObject62[0]="不可移动";
$Lang_t2dSceneObject62[1]="Immovable";
function Language_t2dSceneObject62() { return $Lang_t2dSceneObject62[$pref::LanguageType]; }
//
$Lang_t2dSceneObject63[0]="是否允许该物体移动";
$Lang_t2dSceneObject63[1]="Allow the object move or not";
function Language_t2dSceneObject63() { return $Lang_t2dSceneObject63[$pref::LanguageType]; }
//
$Lang_t2dSceneObject64[0]="常力";
$Lang_t2dSceneObject64[1]="Constant force";
function Language_t2dSceneObject64() { return $Lang_t2dSceneObject64[$pref::LanguageType]; }
//
$Lang_t2dSceneObject65[0]="一直作用于此精灵的力量";
$Lang_t2dSceneObject65[1]="Continuous force on the Sprite";
function Language_t2dSceneObject65() { return $Lang_t2dSceneObject65[$pref::LanguageType]; }
//
$Lang_t2dSceneObject66[0]="朝向";
$Lang_t2dSceneObject66[1]="Orientation";
function Language_t2dSceneObject66() { return $Lang_t2dSceneObject66[$pref::LanguageType]; }
//
$Lang_t2dSceneObject67[0]="挂接朝向";
$Lang_t2dSceneObject67[1]="Mount orientation";
function Language_t2dSceneObject67() { return $Lang_t2dSceneObject67[$pref::LanguageType]; }
//
$Lang_t2dSceneObject68[0]="自动旋转";
$Lang_t2dSceneObject68[1]="Auto rotation";
function Language_t2dSceneObject68() { return $Lang_t2dSceneObject68[$pref::LanguageType]; }
//
$Lang_t2dSceneObject69[0]="在挂接点自动旋转";
$Lang_t2dSceneObject69[1]="Auto mount rotation";
function Language_t2dSceneObject69() { return $Lang_t2dSceneObject69[$pref::LanguageType]; }
//
$Lang_t2dSceneObject70[0]="跟随旋转";
$Lang_t2dSceneObject70[1]="Track rotation";
function Language_t2dSceneObject70() { return $Lang_t2dSceneObject70[$pref::LanguageType]; }
//
$Lang_t2dSceneObject71[0]="跟随挂接者旋转";
$Lang_t2dSceneObject71[1]="Mount track rotation";
function Language_t2dSceneObject71() { return $Lang_t2dSceneObject71[$pref::LanguageType]; }
//
$Lang_t2dSceneObject72[0]="由挂接者控制";
$Lang_t2dSceneObject72[1]="Mount owned";
function Language_t2dSceneObject72() { return $Lang_t2dSceneObject72[$pref::LanguageType]; }
//
$Lang_t2dSceneObject73[0]="被控制，如挂接者消失，其跟着消失";
$Lang_t2dSceneObject73[1]="Owned,disappear with mount";
function Language_t2dSceneObject73() { return $Lang_t2dSceneObject73[$pref::LanguageType]; }
//
$Lang_t2dSceneObject74[0]="继承属性";
$Lang_t2dSceneObject74[1]="Inherit attributes";
function Language_t2dSceneObject74() { return $Lang_t2dSceneObject74[$pref::LanguageType]; }
//
$Lang_t2dSceneObject75[0]="继承挂接者的属性";
$Lang_t2dSceneObject75[1]="Inherit mount attributes";
function Language_t2dSceneObject75() { return $Lang_t2dSceneObject75[$pref::LanguageType]; }
//
$Lang_t2dSceneObject76[0]="限制模式";
$Lang_t2dSceneObject76[1]="Limit Mode";
function Language_t2dSceneObject76() { return $Lang_t2dSceneObject76[$pref::LanguageType]; }
//
$Lang_t2dSceneObject77[0]="分别为：关闭、自定义、渐停、反弹、静止、删除";
$Lang_t2dSceneObject77[1]="Respectively:off,null,clamp,bounce,sticky,kill";
function Language_t2dSceneObject77() { return $Lang_t2dSceneObject77[$pref::LanguageType]; }
//
$Lang_t2dSceneObject78[0]="边界左上角坐标";
$Lang_t2dSceneObject78[1]="Upper-left corner coordinate";
function Language_t2dSceneObject78() { return $Lang_t2dSceneObject78[$pref::LanguageType]; }
//
$Lang_t2dSceneObject79[0]="世界边界的左侧和上方的坐标值";
$Lang_t2dSceneObject79[1]="World Limit left and upward coordinate value";
function Language_t2dSceneObject79() { return $Lang_t2dSceneObject79[$pref::LanguageType]; }
//
$Lang_t2dSceneObject80[0]="边界右下角坐标";
$Lang_t2dSceneObject80[1]="Bottom right corner coordinate";
function Language_t2dSceneObject80() { return $Lang_t2dSceneObject80[$pref::LanguageType]; }
//
$Lang_t2dSceneObject81[0]="世界边界的右侧和下方的坐标值";
$Lang_t2dSceneObject81[1]="World limit right and downward coordinate value";
function Language_t2dSceneObject81() { return $Lang_t2dSceneObject81[$pref::LanguageType]; }
//
$Lang_t2dSceneObject82[0]="开启";
$Lang_t2dSceneObject82[1]="Open";
function Language_t2dSceneObject82() { return $Lang_t2dSceneObject82[$pref::LanguageType]; }
//
$Lang_t2dSceneObject83[0]="开启后期颜色处理";
$Lang_t2dSceneObject83[1]="Open color post processing";
function Language_t2dSceneObject83() { return $Lang_t2dSceneObject83[$pref::LanguageType]; }
//
$Lang_t2dSceneObject84[0]="源混合因子";
$Lang_t2dSceneObject84[1]="Source blend factor";
function Language_t2dSceneObject84() { return $Lang_t2dSceneObject84[$pref::LanguageType]; }
//
$Lang_t2dSceneObject85[0]="目标混合因子";
$Lang_t2dSceneObject85[1]="Dest blend factor";
function Language_t2dSceneObject85() { return $Lang_t2dSceneObject85[$pref::LanguageType]; }
//
$Lang_t2dSceneObject86[0]="后期颜色处理";
$Lang_t2dSceneObject86[1]="Color post processing";
function Language_t2dSceneObject86() { return $Lang_t2dSceneObject86[$pref::LanguageType]; }
//
$Lang_t2dSceneObject87[0]="程序接口";
$Lang_t2dSceneObject87[1]="Program interface";
function Language_t2dSceneObject87() { return $Lang_t2dSceneObject87[$pref::LanguageType]; }
//
$Lang_t2dSceneObject88[0]="基本属性";
$Lang_t2dSceneObject88[1]="Base property";
function Language_t2dSceneObject88() { return $Lang_t2dSceneObject88[$pref::LanguageType]; }
//
$Lang_t2dSceneObject89[0]="寻路";
$Lang_t2dSceneObject89[1]="Path finding";
function Language_t2dSceneObject89() { return $Lang_t2dSceneObject89[$pref::LanguageType]; }
//
$Lang_t2dSceneObject90[0]="碰撞";
$Lang_t2dSceneObject90[1]="Collision";
function Language_t2dSceneObject90() { return $Lang_t2dSceneObject90[$pref::LanguageType]; }
//
$Lang_t2dSceneObject91[0]="物理";
$Lang_t2dSceneObject91[1]="Physics";
function Language_t2dSceneObject91() { return $Lang_t2dSceneObject91[$pref::LanguageType]; }
//
$Lang_t2dSceneObject92[0]="挂接";
$Lang_t2dSceneObject92[1]="Mount";
function Language_t2dSceneObject92() { return $Lang_t2dSceneObject92[$pref::LanguageType]; }
//
$Lang_t2dSceneObject93[0]="世界边界限制";
$Lang_t2dSceneObject93[1]="World Limit";
function Language_t2dSceneObject93() { return $Lang_t2dSceneObject93[$pref::LanguageType]; }
//
$Lang_t2dSceneObject94[0]="后期颜色处理";
$Lang_t2dSceneObject94[1]="Color post processing";
function Language_t2dSceneObject94() { return $Lang_t2dSceneObject94[$pref::LanguageType]; }

//
$Lang_t2dSceneObjectSet0[0]="坐标";
$Lang_t2dSceneObjectSet0[1]="Coordinate";
function Language_t2dSceneObjectSet0() { return $Lang_t2dSceneObjectSet0[$pref::LanguageType]; }
//
$Lang_t2dSceneObjectSet1[0]="整体中心的坐标";
$Lang_t2dSceneObjectSet1[1]="Center coordinate";
function Language_t2dSceneObjectSet1() { return $Lang_t2dSceneObjectSet1[$pref::LanguageType]; }
//
$Lang_t2dSceneObjectSet2[0]="大小";
$Lang_t2dSceneObjectSet2[1]="Size";
function Language_t2dSceneObjectSet2() { return $Lang_t2dSceneObjectSet2[$pref::LanguageType]; }
//
$Lang_t2dSceneObjectSet3[0]="宽";
$Lang_t2dSceneObjectSet3[1]="Width";
function Language_t2dSceneObjectSet3() { return $Lang_t2dSceneObjectSet3[$pref::LanguageType]; }
//
$Lang_t2dSceneObjectSet4[0]="高";
$Lang_t2dSceneObjectSet4[1]="Height";
function Language_t2dSceneObjectSet4() { return $Lang_t2dSceneObjectSet4[$pref::LanguageType]; }
//
$Lang_t2dSceneObjectSet5[0]="大小";
$Lang_t2dSceneObjectSet5[1]="Size";
function Language_t2dSceneObjectSet5() { return $Lang_t2dSceneObjectSet5[$pref::LanguageType]; }
//
$Lang_t2dSceneObjectSet6[0]="朝向";
$Lang_t2dSceneObjectSet6[1]="Orientation";
function Language_t2dSceneObjectSet6() { return $Lang_t2dSceneObjectSet6[$pref::LanguageType]; }
//
$Lang_t2dSceneObjectSet7[0]="整体的朝向";
$Lang_t2dSceneObjectSet7[1]="The whole orientation";
function Language_t2dSceneObjectSet7() { return $Lang_t2dSceneObjectSet7[$pref::LanguageType]; }
//
$Lang_t2dSceneObjectSet8[0]="水平翻转";
$Lang_t2dSceneObjectSet8[1]="Flip horizontal";
function Language_t2dSceneObjectSet8() { return $Lang_t2dSceneObjectSet8[$pref::LanguageType]; }
//
$Lang_t2dSceneObjectSet9[0]="水平翻转";
$Lang_t2dSceneObjectSet9[1]="Flip horizontal";
function Language_t2dSceneObjectSet9() { return $Lang_t2dSceneObjectSet9[$pref::LanguageType]; }
//
$Lang_t2dSceneObjectSet10[0]="垂直翻转";
$Lang_t2dSceneObjectSet10[1]="Flip vertical";
function Language_t2dSceneObjectSet10() { return $Lang_t2dSceneObjectSet10[$pref::LanguageType]; }
//
$Lang_t2dSceneObjectSet11[0]="垂直翻转";
$Lang_t2dSceneObjectSet11[1]="Flip vertical";
function Language_t2dSceneObjectSet11() { return $Lang_t2dSceneObjectSet11[$pref::LanguageType]; }
//
$Lang_t2dSceneObjectSet12[0]="层";
$Lang_t2dSceneObjectSet12[1]="Layer";
function Language_t2dSceneObjectSet12() { return $Lang_t2dSceneObjectSet12[$pref::LanguageType]; }
//
$Lang_t2dSceneObjectSet13[0]="显示的层级";
$Lang_t2dSceneObjectSet13[1]="Layer show";
function Language_t2dSceneObjectSet13() { return $Lang_t2dSceneObjectSet13[$pref::LanguageType]; }
//
$Lang_t2dSceneObjectSet14[0]="选中的精灵集";
$Lang_t2dSceneObjectSet14[1]="Scene Object Set";
function Language_t2dSceneObjectSet14() { return $Lang_t2dSceneObjectSet14[$pref::LanguageType]; }

//
$Lang_t2dScroller0[0]="图片";
$Lang_t2dScroller0[1]="Image";
function Language_t2dScroller0() { return $Lang_t2dScroller0[$pref::LanguageType]; }
//
$Lang_t2dScroller1[0]="该精灵的显示图片";
$Lang_t2dScroller1[1]="The Sprite image shown";
function Language_t2dScroller1() { return $Lang_t2dScroller1[$pref::LanguageType]; }
//
$Lang_t2dScroller2[0]="重复";
$Lang_t2dScroller2[1]="Repeat";
function Language_t2dScroller2() { return $Lang_t2dScroller2[$pref::LanguageType]; }
//
$Lang_t2dScroller3[0]="图片的重复次数";
$Lang_t2dScroller3[1]="Repeat times";
function Language_t2dScroller3() { return $Lang_t2dScroller3[$pref::LanguageType]; }
//
$Lang_t2dScroller4[0]="滚动速度";
$Lang_t2dScroller4[1]="Scroll velocity";
function Language_t2dScroller4() { return $Lang_t2dScroller4[$pref::LanguageType]; }
//
$Lang_t2dScroller5[0]="图片的滚动速度";
$Lang_t2dScroller5[1]="Image scroll velocity";
function Language_t2dScroller5() { return $Lang_t2dScroller5[$pref::LanguageType]; }
//
$Lang_t2dScroller6[0]="滚动图";
$Lang_t2dScroller6[1]="Scroller";
function Language_t2dScroller6() { return $Lang_t2dScroller6[$pref::LanguageType]; }

//
$Lang_t2dShapeVector0[0]="编辑多边形";
$Lang_t2dShapeVector0[1]="Polygon Edit";
function Language_t2dShapeVector0() { return $Lang_t2dShapeVector0[$pref::LanguageType]; }
//
$Lang_t2dShapeVector1[0]="线条颜色";
$Lang_t2dShapeVector1[1]="Line color";
function Language_t2dShapeVector1() { return $Lang_t2dShapeVector1[$pref::LanguageType]; }
//
$Lang_t2dShapeVector2[0]="线条颜色";
$Lang_t2dShapeVector2[1]="Line color";
function Language_t2dShapeVector2() { return $Lang_t2dShapeVector2[$pref::LanguageType]; }
//
$Lang_t2dShapeVector3[0]="填充多边形";
$Lang_t2dShapeVector3[1]="Fill polygon";
function Language_t2dShapeVector3() { return $Lang_t2dShapeVector3[$pref::LanguageType]; }
//
$Lang_t2dShapeVector4[0]="填充色";
$Lang_t2dShapeVector4[1]="Fill color";
function Language_t2dShapeVector4() { return $Lang_t2dShapeVector4[$pref::LanguageType]; }
//
$Lang_t2dShapeVector5[0]="填充色";
$Lang_t2dShapeVector5[1]="Fill color";
function Language_t2dShapeVector5() { return $Lang_t2dShapeVector5[$pref::LanguageType]; }
//
$Lang_t2dShapeVector6[0]="使用凸面体作为多边形碰撞";
$Lang_t2dShapeVector6[1]="Use convex as polygon collision";
function Language_t2dShapeVector6() { return $Lang_t2dShapeVector6[$pref::LanguageType]; }
//
$Lang_t2dShapeVector7[0]="多边形向量";
$Lang_t2dShapeVector7[1]="Shape Vector";
function Language_t2dShapeVector7() { return $Lang_t2dShapeVector7[$pref::LanguageType]; }

//
$Lang_t2dStaticSprite0[0]="图片";
$Lang_t2dStaticSprite0[1]="Image";
function Language_t2dStaticSprite0() { return $Lang_t2dStaticSprite0[$pref::LanguageType]; }
//
$Lang_t2dStaticSprite1[0]="该精灵的显示图片";
$Lang_t2dStaticSprite1[1]="Sprite image show";
function Language_t2dStaticSprite1() { return $Lang_t2dStaticSprite1[$pref::LanguageType]; }
//
$Lang_t2dStaticSprite2[0]="帧";
$Lang_t2dStaticSprite2[1]="Frame";
function Language_t2dStaticSprite2() { return $Lang_t2dStaticSprite2[$pref::LanguageType]; }
//
$Lang_t2dStaticSprite3[0]="图片帧数";
$Lang_t2dStaticSprite3[1]="Image frame number";
function Language_t2dStaticSprite3() { return $Lang_t2dStaticSprite3[$pref::LanguageType]; }
//
$Lang_t2dStaticSprite4[0]="静态精灵";
$Lang_t2dStaticSprite4[1]="Static Sprite";
function Language_t2dStaticSprite4() { return $Lang_t2dStaticSprite4[$pref::LanguageType]; }

//
$Lang_t2dTextObject0[0]="字体";
$Lang_t2dTextObject0[1]="Font";
function Language_t2dTextObject0() { return $Lang_t2dTextObject0[$pref::LanguageType]; }
//
$Lang_t2dTextObject1[0]="对齐方式";
$Lang_t2dTextObject1[1]="Alignment";
function Language_t2dTextObject1() { return $Lang_t2dTextObject1[$pref::LanguageType]; }
//
$Lang_t2dTextObject2[0]="文字高度";
$Lang_t2dTextObject2[1]="Character height";
function Language_t2dTextObject2() { return $Lang_t2dTextObject2[$pref::LanguageType]; }
//
$Lang_t2dTextObject3[0]="线段间隔";
$Lang_t2dTextObject3[1]="Line spacing";
function Language_t2dTextObject3() { return $Lang_t2dTextObject3[$pref::LanguageType]; }
//
$Lang_t2dTextObject4[0]="文字间隔";
$Lang_t2dTextObject4[1]="Character spacing";
function Language_t2dTextObject4() { return $Lang_t2dTextObject4[$pref::LanguageType]; }
//
$Lang_t2dTextObject5[0]="水平缩放";
$Lang_t2dTextObject5[1]="Horizontal scaling";
function Language_t2dTextObject5() { return $Lang_t2dTextObject5[$pref::LanguageType]; }
//
$Lang_t2dTextObject6[0]="字体卷盖模式";
$Lang_t2dTextObject6[1]="Word wrap mode";
function Language_t2dTextObject6() { return $Lang_t2dTextObject6[$pref::LanguageType]; }
//
$Lang_t2dTextObject7[0]="隐藏超出边界的";
$Lang_t2dTextObject7[1]="Hide overflow";
function Language_t2dTextObject7() { return $Lang_t2dTextObject7[$pref::LanguageType]; }
//
$Lang_t2dTextObject8[0]="双线性过滤";
$Lang_t2dTextObject8[1]="Bilinear filter";
function Language_t2dTextObject8() { return $Lang_t2dTextObject8[$pref::LanguageType]; }
//
$Lang_t2dTextObject9[0]="开启或者关闭双线性过滤插值";
$Lang_t2dTextObject9[1]="Start or shut Bilinear filter interpolation";
function Language_t2dTextObject9() { return $Lang_t2dTextObject9[$pref::LanguageType]; }
//
$Lang_t2dTextObject10[0]="对齐整数大小";
$Lang_t2dTextObject10[1]="Snap to integer";
function Language_t2dTextObject10() { return $Lang_t2dTextObject10[$pref::LanguageType]; }
//
$Lang_t2dTextObject11[0]="对齐整数大小，不允许出现半个像素大小";
$Lang_t2dTextObject11[1]="Snap to integer,Not allow half pixel";
function Language_t2dTextObject11() { return $Lang_t2dTextObject11[$pref::LanguageType]; }
//
$Lang_t2dTextObject12[0]="文字精灵";
$Lang_t2dTextObject12[1]="Text Sprite";
function Language_t2dTextObject12() { return $Lang_t2dTextObject12[$pref::LanguageType]; }

//
$Lang_t2dTileLayer0[0]="自动平铺";
$Lang_t2dTileLayer0[1]="Auto pan";
function Language_t2dTileLayer0() { return $Lang_t2dTileLayer0[$pref::LanguageType]; }
//
$Lang_t2dTileLayer1[0]="自动平铺";
$Lang_t2dTileLayer1[1]="Auto pan";
function Language_t2dTileLayer1() { return $Lang_t2dTileLayer1[$pref::LanguageType]; }
//
$Lang_t2dTileLayer2[0]="平铺坐标";
$Lang_t2dTileLayer2[1]="Pan coordinate";
function Language_t2dTileLayer2() { return $Lang_t2dTileLayer2[$pref::LanguageType]; }
//
$Lang_t2dTileLayer3[0]="平铺坐标";
$Lang_t2dTileLayer3[1]="Pan coordinate";
function Language_t2dTileLayer3() { return $Lang_t2dTileLayer3[$pref::LanguageType]; }
//
$Lang_t2dTileLayer4[0]="卷盖 X";
$Lang_t2dTileLayer4[1]="Wrap X";
function Language_t2dTileLayer4() { return $Lang_t2dTileLayer4[$pref::LanguageType]; }
//
$Lang_t2dTileLayer5[0]="卷盖 Y";
$Lang_t2dTileLayer5[1]="Wrap Y";
function Language_t2dTileLayer5() { return $Lang_t2dTileLayer5[$pref::LanguageType]; }
//
$Lang_t2dTileLayer6[0]="平铺数量";
$Lang_t2dTileLayer6[1]="Tile number";
function Language_t2dTileLayer6() { return $Lang_t2dTileLayer6[$pref::LanguageType]; }
//
$Lang_t2dTileLayer7[0]="平铺数量";
$Lang_t2dTileLayer7[1]="Tile number";
function Language_t2dTileLayer7() { return $Lang_t2dTileLayer7[$pref::LanguageType]; }
//
$Lang_t2dTileLayer8[0]="平铺大小";
$Lang_t2dTileLayer8[1]="Tile size";
function Language_t2dTileLayer8() { return $Lang_t2dTileLayer8[$pref::LanguageType]; }
//
$Lang_t2dTileLayer9[0]="平铺大小";
$Lang_t2dTileLayer9[1]="Tile size";
function Language_t2dTileLayer9() { return $Lang_t2dTileLayer9[$pref::LanguageType]; }
//
$Lang_t2dTileLayer10[0]="精灵大小与层级一致";
$Lang_t2dTileLayer10[1]="Sprite size is in line with layer";
function Language_t2dTileLayer10() { return $Lang_t2dTileLayer10[$pref::LanguageType]; }
//
$Lang_t2dTileLayer11[0]="编辑平铺层级";
$Lang_t2dTileLayer11[1]="Edit tile layer";
function Language_t2dTileLayer11() { return $Lang_t2dTileLayer11[$pref::LanguageType]; }
//
$Lang_t2dTileLayer12[0]="笔刷";
$Lang_t2dTileLayer12[1]="Brush";
function Language_t2dTileLayer12() { return $Lang_t2dTileLayer12[$pref::LanguageType]; }
//
$Lang_t2dTileLayer13[0]="图片";
$Lang_t2dTileLayer13[1]="Image";
function Language_t2dTileLayer13() { return $Lang_t2dTileLayer13[$pref::LanguageType]; }
//
$Lang_t2dTileLayer14[0]="帧数";
$Lang_t2dTileLayer14[1]="Frame number";
function Language_t2dTileLayer14() { return $Lang_t2dTileLayer14[$pref::LanguageType]; }
//
$Lang_t2dTileLayer15[0]="平铺图脚本";
$Lang_t2dTileLayer15[1]="Tile script";
function Language_t2dTileLayer15() { return $Lang_t2dTileLayer15[$pref::LanguageType]; }
//
$Lang_t2dTileLayer16[0]="自定义数据";
$Lang_t2dTileLayer16[1]="Custom data";
function Language_t2dTileLayer16() { return $Lang_t2dTileLayer16[$pref::LanguageType]; }
//
$Lang_t2dTileLayer17[0]="水平翻转";
$Lang_t2dTileLayer17[1]="Flip  horizontal";
function Language_t2dTileLayer17() { return $Lang_t2dTileLayer17[$pref::LanguageType]; }
//
$Lang_t2dTileLayer18[0]="垂直翻转";
$Lang_t2dTileLayer18[1]="Flip vertical";
function Language_t2dTileLayer18() { return $Lang_t2dTileLayer18[$pref::LanguageType]; }
//
$Lang_t2dTileLayer19[0]="开启碰撞";
$Lang_t2dTileLayer19[1]="Enable collision";
function Language_t2dTileLayer19() { return $Lang_t2dTileLayer19[$pref::LanguageType]; }
//
$Lang_t2dTileLayer20[0]="应用至选择的图块";
$Lang_t2dTileLayer20[1]="Apply to chosen block";
function Language_t2dTileLayer20() { return $Lang_t2dTileLayer20[$pref::LanguageType]; }
//
$Lang_t2dTileLayer21[0]="保存笔刷";
$Lang_t2dTileLayer21[1]="Save brush";
function Language_t2dTileLayer21() { return $Lang_t2dTileLayer21[$pref::LanguageType]; }
//
$Lang_t2dTileLayer22[0]="删除笔刷";
$Lang_t2dTileLayer22[1]="Delete brush";
function Language_t2dTileLayer22() { return $Lang_t2dTileLayer22[$pref::LanguageType]; }
//
$Lang_t2dTileLayer23[0]="警告";
$Lang_t2dTileLayer23[1]="Warning";
function Language_t2dTileLayer23() { return $Lang_t2dTileLayer23[$pref::LanguageType]; }
//
$Lang_t2dTileLayer24[0]="减少平铺数量将删除层级边界外的平铺图，此操作不可逆，继续?";
$Lang_t2dTileLayer24[1]="Tile number reduce would delete tile image outside layer boundary,it's irreversible,continue?";
function Language_t2dTileLayer24() { return $Lang_t2dTileLayer24[$pref::LanguageType]; }
//
$Lang_t2dTileLayer25[0]="警告";
$Lang_t2dTileLayer25[1]="Warning";
function Language_t2dTileLayer25() { return $Lang_t2dTileLayer25[$pref::LanguageType]; }
//
$Lang_t2dTileLayer26[0]="减少平铺数量将删除层级边界外的平铺图，此操作不可逆，继续?";
$Lang_t2dTileLayer26[1]="Tile number reduce would delete tile image outside layer boundary,it's irreversible,continue?";
function Language_t2dTileLayer26() { return $Lang_t2dTileLayer26[$pref::LanguageType]; }
//
$Lang_t2dTileLayer27[0]="平铺图";
$Lang_t2dTileLayer27[1]="Tile Layer";
function Language_t2dTileLayer27() { return $Lang_t2dTileLayer27[$pref::LanguageType]; }
//
$Lang_t2dTileLayer28[0]="平铺图编辑";
$Lang_t2dTileLayer28[1]="Tile Layer Edit";
function Language_t2dTileLayer28() { return $Lang_t2dTileLayer28[$pref::LanguageType]; }

//
$Lang_t2dTileLayer29[0]="选择";
$Lang_t2dTileLayer29[1]="Select";
function Language_t2dTileLayer29() { return $Lang_t2dTileLayer29[$pref::LanguageType]; }
//
$Lang_t2dTileLayer30[0]="喷涂";
$Lang_t2dTileLayer30[1]="Paint";
function Language_t2dTileLayer30() { return $Lang_t2dTileLayer30[$pref::LanguageType]; }
//
$Lang_t2dTileLayer31[0]="填充满";
$Lang_t2dTileLayer31[1]="Flood";
function Language_t2dTileLayer31() { return $Lang_t2dTileLayer31[$pref::LanguageType]; }
//
$Lang_t2dTileLayer32[0]="吸取图片";
$Lang_t2dTileLayer32[1]="Pick Image";
function Language_t2dTileLayer32() { return $Lang_t2dTileLayer32[$pref::LanguageType]; }
//
$Lang_t2dTileLayer33[0]="橡皮擦";
$Lang_t2dTileLayer33[1]="Eraser";
function Language_t2dTileLayer33() { return $Lang_t2dTileLayer33[$pref::LanguageType]; }

//
$Lang_t2dTrigger0[0]="进入时触发";
$Lang_t2dTrigger0[1]="Trigger On Enter";
function Language_t2dTrigger0() { return $Lang_t2dTrigger0[$pref::LanguageType]; }
//
$Lang_t2dTrigger1[0]="当有精灵进入触发器内部时，触发对应功能";
$Lang_t2dTrigger1[1]="When Sprite enter the trigger,trigger function";
function Language_t2dTrigger1() { return $Lang_t2dTrigger1[$pref::LanguageType]; }
//
$Lang_t2dTrigger2[0]="停留时触发";
$Lang_t2dTrigger2[1]="Trigger On Stay";
function Language_t2dTrigger2() { return $Lang_t2dTrigger2[$pref::LanguageType]; }
//
$Lang_t2dTrigger3[0]="当有精灵停留在触发器内部时，触发对应功能";
$Lang_t2dTrigger3[1]="When Sprite stay in the trigger,trigger function";
function Language_t2dTrigger3() { return $Lang_t2dTrigger3[$pref::LanguageType]; }
//
$Lang_t2dTrigger4[0]="离开时触发";
$Lang_t2dTrigger4[1]="Trigger On Leave";
function Language_t2dTrigger4() { return $Lang_t2dTrigger4[$pref::LanguageType]; }
//
$Lang_t2dTrigger5[0]="当有精灵离开触发器时，触发对应功能";
$Lang_t2dTrigger5[1]="When Sprite leave the trigger,trigger function";
function Language_t2dTrigger5() { return $Lang_t2dTrigger5[$pref::LanguageType]; }
//
$Lang_t2dTrigger6[0]="触发器";
$Lang_t2dTrigger6[1]="Trigger";
function Language_t2dTrigger6() { return $Lang_t2dTrigger6[$pref::LanguageType]; }

//
$Lang_projectManPanel0[0]="恢复至初始地图";
$Lang_projectManPanel0[1]="Reset to original map";
function Language_projectManPanel0() { return $Lang_projectManPanel0[$pref::LanguageType]; }
//
$Lang_projectManPanel1[0]="打开工程文件夹";
$Lang_projectManPanel1[1]="Open project folder";
function Language_projectManPanel1() { return $Lang_projectManPanel1[$pref::LanguageType]; }
//
$Lang_projectManPanel2[0]="启动VC工程";
$Lang_projectManPanel2[1]="Start VC project";
function Language_projectManPanel2() { return $Lang_projectManPanel2[$pref::LanguageType]; }
//
$Lang_projectManPanel3[0]="设置启动VC工程";
$Lang_projectManPanel3[1]="Set start VC project";
function Language_projectManPanel3() { return $Lang_projectManPanel3[$pref::LanguageType]; }
//
$Lang_projectManPanel4[0]="创建VC工程";
$Lang_projectManPanel4[1]="Create VC project";
function Language_projectManPanel4() { return $Lang_projectManPanel4[$pref::LanguageType]; }

//
$Lang_sideBarClassConfigLink0[0]="此面板链接脚本类至物体";
$Lang_sideBarClassConfigLink0[1]="Panel link script to object";
function Language_sideBarClassConfigLink0() { return $Lang_sideBarClassConfigLink0[$pref::LanguageType]; }
//
$Lang_sideBarClassConfigLink1[0]="类";
$Lang_sideBarClassConfigLink1[1]="Class";
function Language_sideBarClassConfigLink1() { return $Lang_sideBarClassConfigLink1[$pref::LanguageType]; }

//
$Lang_sideBarContentManagement0[0]="添加一个新的图片资源";
$Lang_sideBarContentManagement0[1]="Add new image resource";
function Language_sideBarContentManagement0() { return $Lang_sideBarContentManagement0[$pref::LanguageType]; }
//
$Lang_sideBarContentManagement1[0]="添加一个新的动画";
$Lang_sideBarContentManagement1[1]="Add a new animation";
function Language_sideBarContentManagement1() { return $Lang_sideBarContentManagement1[$pref::LanguageType]; }
//
$Lang_sideBarContentManagement2[0]="添加一个新的粒子特效";
$Lang_sideBarContentManagement2[1]="Add a new particle effect";
function Language_sideBarContentManagement2() { return $Lang_sideBarContentManagement2[$pref::LanguageType]; }
//
$Lang_sideBarContentManagement3[0]="添加一个新的音乐";
$Lang_sideBarContentManagement3[1]="Add new music";
function Language_sideBarContentManagement3() { return $Lang_sideBarContentManagement3[$pref::LanguageType]; }
//
$Lang_sideBarContentManagement4[0]="导入新图片";
$Lang_sideBarContentManagement4[1]="Import new image";
function Language_sideBarContentManagement4() { return $Lang_sideBarContentManagement4[$pref::LanguageType]; }
//
$Lang_sideBarContentManagement5[0]="制作新动画";
$Lang_sideBarContentManagement5[1]="Create new animation";
function Language_sideBarContentManagement5() { return $Lang_sideBarContentManagement5[$pref::LanguageType]; }
//
$Lang_sideBarContentManagement6[0]="从图库里删除图片";
$Lang_sideBarContentManagement6[1]="Delete image from gallery";
function Language_sideBarContentManagement6() { return $Lang_sideBarContentManagement6[$pref::LanguageType]; }
//
$Lang_sideBarContentManagement7[0]="拖拽一个图片到此删除";
$Lang_sideBarContentManagement7[1]="Drag an image here to delete";
function Language_sideBarContentManagement7() { return $Lang_sideBarContentManagement7[$pref::LanguageType]; }
//
$Lang_sideBarContentManagement8[0]="拖拽一个图片到此删除";
$Lang_sideBarContentManagement8[1]="Drag an image here to delete";
function Language_sideBarContentManagement8() { return $Lang_sideBarContentManagement8[$pref::LanguageType]; }
//
$Lang_sideBarContentManagement9[0]="确认删除此资源?";
$Lang_sideBarContentManagement9[1]="Confirm delete the resource?";
function Language_sideBarContentManagement9() { return $Lang_sideBarContentManagement9[$pref::LanguageType]; }
//
$Lang_sideBarContentManagement10[0]="有";
$Lang_sideBarContentManagement10[1]="There";
function Language_sideBarContentManagement10() { return $Lang_sideBarContentManagement10[$pref::LanguageType]; }
//
$Lang_sideBarContentManagement11[0]="个精灵引用到此资源. 如果此资源被删除，则引用到的地图精灵也会被删除. 是否继续?";
$Lang_sideBarContentManagement11[1]="Sprite use the resource,if resource delete,the scene Sprite would be deleted,continue?";
function Language_sideBarContentManagement11() { return $Lang_sideBarContentManagement11[$pref::LanguageType]; }
//
$Lang_sideBarContentManagement12[0]="确认删除此动画?";
$Lang_sideBarContentManagement12[1]="Sure to delete the animation?";
function Language_sideBarContentManagement12() { return $Lang_sideBarContentManagement12[$pref::LanguageType]; }
//
$Lang_sideBarContentManagement13[0]="有";
$Lang_sideBarContentManagement13[1]="There";
function Language_sideBarContentManagement13() { return $Lang_sideBarContentManagement13[$pref::LanguageType]; }
//
$Lang_sideBarContentManagement14[0]="个精灵引用到此动画. 如果此动画被删除，则引用到的地图精灵也会被删除.是否继续?";
$Lang_sideBarContentManagement14[1]="Sprite use the animation,if animation delete,the scene Sprite would be deleted,continue?";
function Language_sideBarContentManagement14() { return $Lang_sideBarContentManagement14[$pref::LanguageType]; }
//
$Lang_sideBarContentManagement15[0]="删除精灵";
$Lang_sideBarContentManagement15[1]="Delete Sprite";
function Language_sideBarContentManagement15() { return $Lang_sideBarContentManagement15[$pref::LanguageType]; }
//
$Lang_sideBarContentManagement16[0]="有精灵使用到此层级,如果继续, 则该精灵也将被删除. 是否继续?";
$Lang_sideBarContentManagement16[1]="Sprite use the layer,if continue,the Sprite would be deleted,continue?";
function Language_sideBarContentManagement16() { return $Lang_sideBarContentManagement16[$pref::LanguageType]; }
//
$Lang_sideBarContentManagement17[0]="删除精灵";
$Lang_sideBarContentManagement17[1]="Delete Sprite";
function Language_sideBarContentManagement17() { return $Lang_sideBarContentManagement17[$pref::LanguageType]; }
//
$Lang_sideBarContentManagement18[0]="有精灵引用到此特效. 如果继续, 则该特效也会被删除. 是否继续?";
$Lang_sideBarContentManagement18[1]="Sprite use the effect,if continue,the effect would be deleted,continue?";
function Language_sideBarContentManagement18() { return $Lang_sideBarContentManagement18[$pref::LanguageType]; }
//
$Lang_sideBarContentManagement19[0]="是否保存所做更改 ";
$Lang_sideBarContentManagement19[1]="Save the changes ";
function Language_sideBarContentManagement19() { return $Lang_sideBarContentManagement19[$pref::LanguageType]; }
//
$Lang_sideBarContentManagement20[0]="删除贴图";
$Lang_sideBarContentManagement20[1]="Delete Mapping";
function Language_sideBarContentManagement20() { return $Lang_sideBarContentManagement20[$pref::LanguageType]; }
//
$Lang_sideBarContentManagement21[0]="删除图片";
$Lang_sideBarContentManagement21[1]="Delete Image";
function Language_sideBarContentManagement21() { return $Lang_sideBarContentManagement21[$pref::LanguageType]; }
//
$Lang_sideBarContentManagement22[0]="删除动画";
$Lang_sideBarContentManagement22[1]="Delete Animation";
function Language_sideBarContentManagement22() { return $Lang_sideBarContentManagement22[$pref::LanguageType]; }
//
$Lang_sideBarCreate0[0]="资源";
$Lang_sideBarCreate0[1]="Resource";
function Language_sideBarCreate0() { return $Lang_sideBarCreate0[$pref::LanguageType]; }

//
$Lang_sideBarHistoryView0[0]="撤销历史";
$Lang_sideBarHistoryView0[1]="Cancel history";
function Language_sideBarHistoryView0() { return $Lang_sideBarHistoryView0[$pref::LanguageType]; }

//
$Lang_sideBarProject0[0]="项目";
$Lang_sideBarProject0[1]="Project";
function Language_sideBarProject0() { return $Lang_sideBarProject0[$pref::LanguageType]; }

//
$Lang_sideBarQuickEdit0[0]="编辑";
$Lang_sideBarQuickEdit0[1]="Edit";
function Language_sideBarQuickEdit0() { return $Lang_sideBarQuickEdit0[$pref::LanguageType]; }

//
$Lang_sideBarTreeView0[0]="项目管理";
$Lang_sideBarTreeView0[1]="Project management";
function Language_sideBarTreeView0() { return $Lang_sideBarTreeView0[$pref::LanguageType]; }
//
$Lang_sideBarTreeView1[0]="精灵列表";
$Lang_sideBarTreeView1[1]="Sprites list";
function Language_sideBarTreeView1() { return $Lang_sideBarTreeView1[$pref::LanguageType]; }

//
$Lang_toolPropertiesSelection0[0]="全部框中选择";
$Lang_toolPropertiesSelection0[1]="Select from all forms";
function Language_toolPropertiesSelection0() { return $Lang_toolPropertiesSelection0[$pref::LanguageType]; }
//
$Lang_toolPropertiesSelection1[0]="对齐到网格";
$Lang_toolPropertiesSelection1[1]="Snap to grid";
function Language_toolPropertiesSelection1() { return $Lang_toolPropertiesSelection1[$pref::LanguageType]; }

//
$Lang_lbStaticSpriteThumbnailPopup0[0]="静态精灵(Sprites)...";
$Lang_lbStaticSpriteThumbnailPopup0[1]="Static sprites...";
function Language_lbStaticSpriteThumbnailPopup0() { return $Lang_lbStaticSpriteThumbnailPopup0[$pref::LanguageType]; }
//
$Lang_lbStaticSpriteThumbnailPopup1[0]="帧...";
$Lang_lbStaticSpriteThumbnailPopup1[1]="Frame...";
function Language_lbStaticSpriteThumbnailPopup1() { return $Lang_lbStaticSpriteThumbnailPopup1[$pref::LanguageType]; }

//
$Lang_scripts_edit0[0]="注意";
$Lang_scripts_edit0[1]="Attention";
function Language_scirpts_edit0() { return $Lang_scripts_edit0[$pref::LanguageType]; }
//
$Lang_scripts_edit1[0]="当前打开地图将恢复至第一次打开时状态，是否确定？";
$Lang_scripts_edit1[1]="The current map would return to the beginning when it's opened,confirm?";
function Language_scirpts_edit1() { return $Lang_scripts_edit1[$pref::LanguageType]; }
//
$Lang_scripts_edit2[0]="错误";
$Lang_scripts_edit2[1]="Error";
function Language_scirpts_edit2() { return $Lang_scripts_edit2[$pref::LanguageType]; }
//
$Lang_scripts_edit3[0]="请先设置启动Java工程";
$Lang_scripts_edit3[1]="Please Set start Java project";
function Language_scirpts_edit3() { return $Lang_scripts_edit3[$pref::LanguageType]; }
//
$Lang_scripts_edit4[0]="错误";
$Lang_scripts_edit4[1]="Error";
function Language_scirpts_edit4() { return $Lang_scripts_edit4[$pref::LanguageType]; }
//
$Lang_scripts_edit5[0]="无法打开工程文件! 请确认已经安装JCreator软件。";
$Lang_scripts_edit5[1]="Project file cannot be opened,please check that JCreator software has been installed.";
function Language_scirpts_edit5() { return $Lang_scripts_edit5[$pref::LanguageType]; }
//
$Lang_scripts_edit6[0]="错误";
$Lang_scripts_edit6[1]="Error";
function Language_scirpts_edit6() { return $Lang_scripts_edit6[$pref::LanguageType]; }
//
$Lang_scripts_edit7[0]="无法打开工程文件! 请确认是否已经创建该版本工程文件。";
$Lang_scripts_edit7[1]="Project file cannot be opened,please check that the  project file of this version has been created.";
function Language_scirpts_edit7() { return $Lang_scripts_edit7[$pref::LanguageType]; }
//
$Lang_scripts_edit8[0]="错误";
$Lang_scripts_edit8[1]="Error";
function Language_scirpts_edit8() { return $Lang_scripts_edit8[$pref::LanguageType]; }
//
$Lang_scripts_edit9[0]="请先设置Eclipse.exe的位置。";
$Lang_scripts_edit9[1]="Please set Eclipse.exe position first.";
function Language_scirpts_edit9() { return $Lang_scripts_edit9[$pref::LanguageType]; }
//
$Lang_scripts_edit10[0]="错误";
$Lang_scripts_edit10[1]="Error";
function Language_scirpts_edit10() { return $Lang_scripts_edit10[$pref::LanguageType]; }
//
$Lang_scripts_edit11[0]="指定的Eclipse无效 [";
$Lang_scripts_edit11[1]="Assigned Eclipse is invalid [";
function Language_scirpts_edit11() { return $Lang_scripts_edit11[$pref::LanguageType]; }
//
$Lang_scripts_edit12[0]="] ，请重新指定Eclipse.exe位置。";
$Lang_scripts_edit12[1]="],appoint Eclipse.exe position again";
function Language_scirpts_edit12() { return $Lang_scripts_edit12[$pref::LanguageType]; }
//
$Lang_scripts_edit13[0]="错误";
$Lang_scripts_edit13[1]="Error";
function Language_scirpts_edit13() { return $Lang_scripts_edit13[$pref::LanguageType]; }
//
$Lang_scripts_edit14[0]="无法找到Eclipse软件 [";
$Lang_scripts_edit14[1]="Eclipse software[";
function Language_scirpts_edit14() { return $Lang_scripts_edit14[$pref::LanguageType]; }
//
$Lang_scripts_edit15[0]="] ，请重新指定Eclipse.exe位置。";
$Lang_scripts_edit15[1]="], cannot be found,appoint Eclipse.exe position again";
function Language_scirpts_edit15() { return $Lang_scripts_edit15[$pref::LanguageType]; }
//
$Lang_scripts_edit16[0]="错误";
$Lang_scripts_edit16[1]="Error";
function Language_scirpts_edit16() { return $Lang_scripts_edit16[$pref::LanguageType]; }
//
$Lang_scripts_edit17[0]="无法打开工程文件! 请确认是否已经创建该版本工程文件。";
$Lang_scripts_edit17[1]="Project file cannot be opened!please check that the  project file of this version has been created.";
function Language_scirpts_edit17() { return $Lang_scripts_edit17[$pref::LanguageType]; }
//
$Lang_scripts_edit18[0]="请确认VC2015已经安装，或者已经设置VC2015路径。";
$Lang_scripts_edit18[1]="Please check that VC2015 has been installed or set";
function Language_scirpts_edit18() { return $Lang_scripts_edit18[$pref::LanguageType]; }
//
$Lang_scripts_edit19[0]="请先设置启动VC工程";
$Lang_scripts_edit19[1]="Please set start VC project";
function Language_scirpts_edit19() { return $Lang_scripts_edit19[$pref::LanguageType]; }
//
$Lang_scripts_edit20[0]="请先设置启动VB工程";
$Lang_scripts_edit20[1]="Please set start VB project";
function Language_scirpts_edit20() { return $Lang_scripts_edit20[$pref::LanguageType]; }
//
$Lang_scripts_edit21[0]="请确认VC6已经安装，或者已经设置VC6路径。";
$Lang_scripts_edit21[1]="Please check that VC6 has been installed or set";
function Language_scirpts_edit21() { return $Lang_scripts_edit21[$pref::LanguageType]; }
//
$Lang_scripts_edit22[0]="错误";
$Lang_scripts_edit22[1]="Error";
function Language_scirpts_edit22() { return $Lang_scripts_edit22[$pref::LanguageType]; }
//
$Lang_scripts_edit23[0]="未创建该版本工程文件。";
$Lang_scripts_edit23[1]="The project file of this version has not been created.";
function Language_scirpts_edit23() { return $Lang_scripts_edit23[$pref::LanguageType]; }
//
$Lang_scripts_edit24[0]="错误";
$Lang_scripts_edit24[1]="Error";
function Language_scirpts_edit24() { return $Lang_scripts_edit24[$pref::LanguageType]; }
//
$Lang_scripts_edit25[0]="无法打开工程文件! 请确认是否已经创建该版本工程文件。";
$Lang_scripts_edit25[1]="Project file cannot be opened,please check that the  project file of this version has been created.";
function Language_scirpts_edit25() { return $Lang_scripts_edit25[$pref::LanguageType]; }
//
$Lang_scripts_edit26[0]="错误";
$Lang_scripts_edit26[1]="Error";
function Language_scirpts_edit26() { return $Lang_scripts_edit26[$pref::LanguageType]; }
//
$Lang_scripts_edit27[0]="请确认CodeBlock已经安装，或者已经设置CodeBlock路径。";
$Lang_scripts_edit27[1]="Please check that CodeBlock has been installed or Code Block path has been set";
function Language_scirpts_edit27() { return $Lang_scripts_edit27[$pref::LanguageType]; }
//
$Lang_scripts_edit28[0]="错误";
$Lang_scripts_edit28[1]="Error";
function Language_scirpts_edit28() { return $Lang_scripts_edit28[$pref::LanguageType]; }
//
$Lang_scripts_edit29[0]="未创建该版本工程文件。";
$Lang_scripts_edit29[1]="The project file of this version has not been created.";
function Language_scirpts_edit29() { return $Lang_scripts_edit29[$pref::LanguageType]; }
//
$Lang_scripts_edit30[0]="错误";
$Lang_scripts_edit30[1]="Error";
function Language_scirpts_edit30() { return $Lang_scripts_edit30[$pref::LanguageType]; }
//
$Lang_scripts_edit31[0]="无法打开工程文件! 请确认是否已经创建该版本工程文件。";
$Lang_scripts_edit31[1]="Project file cannot be opened,please check that the  project file of this version has been created.";
function Language_scirpts_edit31() { return $Lang_scripts_edit31[$pref::LanguageType]; }
//
$Lang_scripts_edit32[0]="错误";
$Lang_scripts_edit32[1]="Error";
function Language_scirpts_edit32() { return $Lang_scripts_edit32[$pref::LanguageType]; }
//
$Lang_scripts_edit33[0]="请确认VC2015已经安装，或者已经设置VC2015路径。";
$Lang_scripts_edit33[1]="Please check that VC2015 has been installed or VC2015 path has been set";
function Language_scirpts_edit33() { return $Lang_scripts_edit33[$pref::LanguageType]; }
//
$Lang_scripts_edit34[0]="错误";
$Lang_scripts_edit34[1]="Error";
function Language_scirpts_edit34() { return $Lang_scripts_edit34[$pref::LanguageType]; }
//
$Lang_scripts_edit35[0]="未创建该版本工程文件。";
$Lang_scripts_edit35[1]="The project file of this version has not been created";
function Language_scirpts_edit35() { return $Lang_scripts_edit35[$pref::LanguageType]; }
//
$Lang_scripts_edit36[0]="错误";
$Lang_scripts_edit36[1]="Error";
function Language_scirpts_edit36() { return $Lang_scripts_edit36[$pref::LanguageType]; }
//
$Lang_scripts_edit37[0]="无法打开工程文件! 请确认是否已经创建该版本工程文件。";
$Lang_scripts_edit37[1]="Project file cannot be opened,please check that the  project file of this version has been created";
function Language_scirpts_edit37() { return $Lang_scripts_edit37[$pref::LanguageType]; }
//
$Lang_scripts_edit38[0]="错误";
$Lang_scripts_edit38[1]="Error";
function Language_scirpts_edit38() { return $Lang_scripts_edit38[$pref::LanguageType]; }
//
$Lang_scripts_edit39[0]="请确认VC2012已经安装，或者已经设置VC2012路径。";
$Lang_scripts_edit39[1]="Please check that VC2012 has been installed or VC2012 path has been set";
function Language_scirpts_edit39() { return $Lang_scripts_edit39[$pref::LanguageType]; }
//
$Lang_scripts_edit40[0]="错误";
$Lang_scripts_edit40[1]="Error";
function Language_scirpts_edit40() { return $Lang_scripts_edit40[$pref::LanguageType]; }
//
$Lang_scripts_edit41[0]="未创建该版本工程文件。";
$Lang_scripts_edit41[1]="The project file of this version has not been created";
function Language_scirpts_edit41() { return $Lang_scripts_edit41[$pref::LanguageType]; }
//
$Lang_scripts_edit42[0]="错误";
$Lang_scripts_edit42[1]="Error";
function Language_scirpts_edit42() { return $Lang_scripts_edit42[$pref::LanguageType]; }
//
$Lang_scripts_edit43[0]="无法打开工程文件! 请确认是否已经创建该版本工程文件。";
$Lang_scripts_edit43[1]="Project file cannot be opened,please check that the  project file of this version has been created.";
function Language_scirpts_edit43() { return $Lang_scripts_edit43[$pref::LanguageType]; }
//
$Lang_scripts_edit44[0]="错误";
$Lang_scripts_edit44[1]="Error";
function Language_scirpts_edit44() { return $Lang_scripts_edit44[$pref::LanguageType]; }
//
$Lang_scripts_edit45[0]="请输入工程名字";
$Lang_scripts_edit45[1]="Please enter project name";
function Language_scirpts_edit45() { return $Lang_scripts_edit45[$pref::LanguageType]; }
//
$Lang_scripts_edit46[0]="选择Visual Studio 14.0(devenv.exe):";
$Lang_scripts_edit46[1]="Select Visual Studio 14.0(devenv.exe):";
function Language_scirpts_edit46() { return $Lang_scripts_edit46[$pref::LanguageType]; }
//
$Lang_scripts_edit47[0]="工程名字不能含有中文字符或者全角字符，并且不能以数字开头.";
$Lang_scripts_edit47[1]="Project name doesnot contain Chinese Characters or full-width characters,number cannot be the first letter";
function Language_scirpts_edit47() { return $Lang_scripts_edit47[$pref::LanguageType]; }
//
$Lang_scripts_edit48[0]="设置VC2015(devenv.exe)位置";
$Lang_scripts_edit48[1]="Set VC2015(devenv.exe)position";
function Language_scirpts_edit48() { return $Lang_scripts_edit48[$pref::LanguageType]; }
//
$Lang_scripts_edit49[0]="该名字的文件夹已经存在，请使用其它名字。";
$Lang_scripts_edit49[1]="Name folder is existing,use other name";
function Language_scirpts_edit49() { return $Lang_scripts_edit49[$pref::LanguageType]; }
//
$Lang_scripts_edit50[0]="提示";
$Lang_scripts_edit50[1]="Hint";
function Language_scirpts_edit50() { return $Lang_scripts_edit50[$pref::LanguageType]; }
//
$Lang_scripts_edit51[0]="该版本工程已经存在。";
$Lang_scripts_edit51[1]="The project of this version already exists";
function Language_scirpts_edit51() { return $Lang_scripts_edit51[$pref::LanguageType]; }
//
$Lang_scripts_edit52[0]="是否创建该版本工程?";
$Lang_scripts_edit52[1]="Create the project of this version or not?";
function Language_scirpts_edit52() { return $Lang_scripts_edit52[$pref::LanguageType]; }
//
$Lang_scripts_edit53[0]="创建成功!";
$Lang_scripts_edit53[1]="Creation is successful";
function Language_scirpts_edit53() { return $Lang_scripts_edit53[$pref::LanguageType]; }
//
$Lang_scripts_edit54[0]="请输入模板名字";
$Lang_scripts_edit54[1]="Enter template name";
function Language_scirpts_edit54() { return $Lang_scripts_edit54[$pref::LanguageType]; }
//
$Lang_scripts_edit55[0]="该名字的模板已经存在，请使用其它名字。";
$Lang_scripts_edit55[1]="The template name already exists,please use other name";
function Language_scirpts_edit55() { return $Lang_scripts_edit55[$pref::LanguageType]; }
//
$Lang_scripts_edit56[0]="保存模板成功!";
$Lang_scripts_edit56[1]="Template save success.";
function Language_scirpts_edit56() { return $Lang_scripts_edit56[$pref::LanguageType]; }
//
$Lang_scripts_edit57[0]="请先选择一个模板。";
$Lang_scripts_edit57[1]="Select a template";
function Language_scirpts_edit57() { return $Lang_scripts_edit57[$pref::LanguageType]; }
//
$Lang_scripts_edit58[0]="警告";
$Lang_scripts_edit58[1]="Warning";
function Language_scirpts_edit58() { return $Lang_scripts_edit58[$pref::LanguageType]; }
//
$Lang_scripts_edit59[0]="导入模板将覆盖现有地图，现有地图数据将全部丢失，是否继续?";
$Lang_scripts_edit59[1]="Import template would cover the current map and map data would loss,continue?";
function Language_scirpts_edit59() { return $Lang_scripts_edit59[$pref::LanguageType]; }
//
$Lang_scripts_edit60[0]="请先选择一个模板。";
$Lang_scripts_edit60[1]="Select a template";
function Language_scirpts_edit60() { return $Lang_scripts_edit60[$pref::LanguageType]; }
//
$Lang_scripts_edit61[0]="模板删除后将不可以恢复，是否继续?";
$Lang_scripts_edit61[1]="Template delete cannot be recovered,continue?";
function Language_scirpts_edit61() { return $Lang_scripts_edit61[$pref::LanguageType]; }
//
$Lang_scripts_edit62[0]="设置VC6(MSDEV.EXE)位置";
$Lang_scripts_edit62[1]="Set VC6(MSDEV.EXE) position";
function Language_scirpts_edit62() { return $Lang_scripts_edit62[$pref::LanguageType]; }
//
$Lang_scripts_edit63[0]="选择Visual Studio(MSDEV.EXE):";
$Lang_scripts_edit63[1]="Select Visual Studio(MSDEV.EXE):";
function Language_scirpts_edit63() { return $Lang_scripts_edit63[$pref::LanguageType]; }
//
$Lang_scripts_edit64[0]="设置VC2015(devenv.exe)位置";
$Lang_scripts_edit64[1]="Set VC2015(devenv.exe)position";
function Language_scirpts_edit64() { return $Lang_scripts_edit64[$pref::LanguageType]; }
//
$Lang_scripts_edit65[0]="选择Visual Studio 9.0(devenv.exe):";
$Lang_scripts_edit65[1]="Select Visual Studio 9.0(devenv.exe):";
function Language_scirpts_edit65() { return $Lang_scripts_edit65[$pref::LanguageType]; }
//
$Lang_scripts_edit66[0]="设置VC2012(devenv.exe)位置";
$Lang_scripts_edit66[1]="Set VC2012(devenv.exe) position";
function Language_scirpts_edit66() { return $Lang_scripts_edit66[$pref::LanguageType]; }
//
$Lang_scripts_edit67[0]="选择Visual Studio 10.0(devenv.exe):";
$Lang_scripts_edit67[1]="Select Visual Studio 10.0(devenv.exe):";
function Language_scirpts_edit67() { return $Lang_scripts_edit67[$pref::LanguageType]; }
//
$Lang_scripts_edit68[0]="设置 codeblock.exe位置";
$Lang_scripts_edit68[1]="Set codeblock.exe position ";
function Language_scirpts_edit68() { return $Lang_scripts_edit68[$pref::LanguageType]; }
//
$Lang_scripts_edit69[0]="选择 codeblock.exe:";
$Lang_scripts_edit69[1]="Select codeblock.exe:";
function Language_scirpts_edit69() { return $Lang_scripts_edit69[$pref::LanguageType]; }
//
$Lang_scripts_edit70[0]="设置Eclipse.exe位置";
$Lang_scripts_edit70[1]="Set Eclipse.exe position";
function Language_scirpts_edit70() { return $Lang_scripts_edit70[$pref::LanguageType]; }
//
$Lang_scripts_edit71[0]="选择Eclipse.exe:";
$Lang_scripts_edit71[1]="Select Eclipse.exe:";
function Language_scirpts_edit71() { return $Lang_scripts_edit71[$pref::LanguageType]; }
//
$Lang_scripts_edit72[0]="请先设置PyCharm.exe的位置。";
$Lang_scripts_edit72[1]="Please set PyCharm.exe position first.";
function Language_scirpts_edit72() { return $Lang_scripts_edit72[$pref::LanguageType]; }
//
$Lang_scripts_edit73[0]="指定的PyCharm无效 [";
$Lang_scripts_edit73[1]="Assigned PyCharm is invalid [";
function Language_scirpts_edit73() { return $Lang_scripts_edit73[$pref::LanguageType]; }
//
$Lang_scripts_edit74[0]="] ，请重新指定PyCharm.exe位置。";
$Lang_scripts_edit74[1]="],appoint PyCharm.exe position again";
function Language_scirpts_edit74() { return $Lang_scripts_edit74[$pref::LanguageType]; }
//
$Lang_scripts_edit75[0]="无法找到PyCharm软件 [";
$Lang_scripts_edit75[1]="PyCharm software[";
function Language_scirpts_edit75() { return $Lang_scripts_edit75[$pref::LanguageType]; }
//
$Lang_scripts_edit76[0]="] ，请重新指定PyCharm.exe位置。";
$Lang_scripts_edit76[1]="], cannot be found,appoint PyCharm.exe position again";
function Language_scirpts_edit76() { return $Lang_scripts_edit76[$pref::LanguageType]; }
//
$Lang_scripts_edit77[0]="设置PyCharm.exe位置";
$Lang_scripts_edit77[1]="Set PyCharm.exe position";
function Language_scirpts_edit77() { return $Lang_scripts_edit77[$pref::LanguageType]; }
//
$Lang_scripts_edit78[0]="选择PyCharm.exe:";
$Lang_scripts_edit78[1]="Select PyCharm.exe:";
function Language_scirpts_edit78() { return $Lang_scripts_edit78[$pref::LanguageType]; }

//
$Lang_levelEditorMenu0[0]="文件";
$Lang_levelEditorMenu0[1]="File";
function Language_levelEditorMenu0() { return $Lang_levelEditorMenu0[$pref::LanguageType]; }
//
$Lang_levelEditorMenu1[0]="打开地图...";
$Lang_levelEditorMenu1[1]="Open scene...";
function Language_levelEditorMenu1() { return $Lang_levelEditorMenu1[$pref::LanguageType]; }
//
$Lang_levelEditorMenu2[0]="打开项目...";
$Lang_levelEditorMenu2[1]="Open project...";
function Language_levelEditorMenu2() { return $Lang_levelEditorMenu2[$pref::LanguageType]; }
//
$Lang_levelEditorMenu3[0]="保存地图";
$Lang_levelEditorMenu3[1]="Save scene";
function Language_levelEditorMenu3() { return $Lang_levelEditorMenu3[$pref::LanguageType]; }
//
$Lang_levelEditorMenu4[0]="地图另存为...";
$Lang_levelEditorMenu4[1]="Save scene as...";
function Language_levelEditorMenu4() { return $Lang_levelEditorMenu4[$pref::LanguageType]; }
//
$Lang_levelEditorMenu5[0]="退出";
$Lang_levelEditorMenu5[1]="Quit";
function Language_levelEditorMenu5() { return $Lang_levelEditorMenu5[$pref::LanguageType]; }
//
$Lang_levelEditorMenu6[0]="编辑";
$Lang_levelEditorMenu6[1]="Edit";
function Language_levelEditorMenu6() { return $Lang_levelEditorMenu6[$pref::LanguageType]; }
//
$Lang_levelEditorMenu7[0]="撤消";
$Lang_levelEditorMenu7[1]="Cancel";
function Language_levelEditorMenu7() { return $Lang_levelEditorMenu7[$pref::LanguageType]; }
//
$Lang_levelEditorMenu8[0]="重做";
$Lang_levelEditorMenu8[1]="Redo";
function Language_levelEditorMenu8() { return $Lang_levelEditorMenu8[$pref::LanguageType]; }
//
$Lang_levelEditorMenu9[0]="剪切";
$Lang_levelEditorMenu9[1]="Cut";
function Language_levelEditorMenu9() { return $Lang_levelEditorMenu9[$pref::LanguageType]; }
//
$Lang_levelEditorMenu10[0]="复制";
$Lang_levelEditorMenu10[1]="Copy";
function Language_levelEditorMenu10() { return $Lang_levelEditorMenu10[$pref::LanguageType]; }
//
$Lang_levelEditorMenu11[0]="粘贴";
$Lang_levelEditorMenu11[1]="Paste";
function Language_levelEditorMenu11() { return $Lang_levelEditorMenu11[$pref::LanguageType]; }
//
$Lang_levelEditorMenu12[0]="后置";
$Lang_levelEditorMenu12[1]="Postposition";
function Language_levelEditorMenu12() { return $Lang_levelEditorMenu12[$pref::LanguageType]; }
//
$Lang_levelEditorMenu13[0]="前置";
$Lang_levelEditorMenu13[1]="Preposition";
function Language_levelEditorMenu13() { return $Lang_levelEditorMenu13[$pref::LanguageType]; }
//
$Lang_levelEditorMenu14[0]="设置...";
$Lang_levelEditorMenu14[1]="Set...";
function Language_levelEditorMenu14() { return $Lang_levelEditorMenu14[$pref::LanguageType]; }
//
$Lang_levelEditorMenu15[0]="项目";
$Lang_levelEditorMenu15[1]="Project";
function Language_levelEditorMenu15() { return $Lang_levelEditorMenu15[$pref::LanguageType]; }
//
$Lang_levelEditorMenu16[0]="运行游戏";
$Lang_levelEditorMenu16[1]="Run Game";
function Language_levelEditorMenu16() { return $Lang_levelEditorMenu16[$pref::LanguageType]; }
//
$Lang_levelEditorMenu17[0]="恢复至初始地图";
$Lang_levelEditorMenu17[1]="Recover to original map";
function Language_levelEditorMenu17() { return $Lang_levelEditorMenu17[$pref::LanguageType]; }
//
$Lang_levelEditorMenu18[0]="打开工程文件夹";
$Lang_levelEditorMenu18[1]="Open Project Folder";
function Language_levelEditorMenu18() { return $Lang_levelEditorMenu18[$pref::LanguageType]; }
//
$Lang_levelEditorMenu19[0]="创建C#工程";
$Lang_levelEditorMenu19[1]="Create C# project";
function Language_levelEditorMenu19() { return $Lang_levelEditorMenu19[$pref::LanguageType]; }
//
$Lang_levelEditorMenu20[0]="创建C语言工程";
$Lang_levelEditorMenu20[1]="Create C language project";
function Language_levelEditorMenu20() { return $Lang_levelEditorMenu20[$pref::LanguageType]; }
//
$Lang_levelEditorMenu21[0]="创建C++工程";
$Lang_levelEditorMenu21[1]="Create C++ project";
function Language_levelEditorMenu21() { return $Lang_levelEditorMenu21[$pref::LanguageType]; }
//
$Lang_levelEditorMenu22[0]="创建Java工程";
$Lang_levelEditorMenu22[1]="Create Java project";
function Language_levelEditorMenu22() { return $Lang_levelEditorMenu22[$pref::LanguageType]; }
//
$Lang_levelEditorMenu23[0]="创建VB工程";
$Lang_levelEditorMenu23[1]="Create VB project";
function Language_levelEditorMenu23() { return $Lang_levelEditorMenu23[$pref::LanguageType]; }
//
$Lang_levelEditorMenu24[0]="导入地图覆盖";
$Lang_levelEditorMenu24[1]="Import map override";
function Language_levelEditorMenu24() { return $Lang_levelEditorMenu24[$pref::LanguageType]; }
//
$Lang_levelEditorMenu25[0]="保存地图为模板";
$Lang_levelEditorMenu25[1]="Save map as template";
function Language_levelEditorMenu25() { return $Lang_levelEditorMenu25[$pref::LanguageType]; }
//
$Lang_levelEditorMenu26[0]="设置Eclipse.exe位置";
$Lang_levelEditorMenu26[1]="Set Eclipse.exe position";
function Language_levelEditorMenu26() { return $Lang_levelEditorMenu26[$pref::LanguageType]; }
//
$Lang_levelEditorMenu27[0]="设置VC6(MSDEV.EXE)位置";
$Lang_levelEditorMenu27[1]="Set VC6(MSDEV.EXE) position";
function Language_levelEditorMenu27() { return $Lang_levelEditorMenu27[$pref::LanguageType]; }
//
$Lang_levelEditorMenu28[0]="设置VC2015(devenv.exe)位置";
$Lang_levelEditorMenu28[1]="Set VC2015(devenv.exe) position";
function Language_levelEditorMenu28() { return $Lang_levelEditorMenu28[$pref::LanguageType]; }
//
$Lang_levelEditorMenu29[0]="设置VC2012(devenv.exe)位置";
$Lang_levelEditorMenu29[1]="Set VC2012(devenv.exe) position";
function Language_levelEditorMenu29() { return $Lang_levelEditorMenu29[$pref::LanguageType]; }
//
$Lang_levelEditorMenu30[0]="设置codeblock.exe位置";
$Lang_levelEditorMenu30[1]="Set codeblock.exe position";
function Language_levelEditorMenu30() { return $Lang_levelEditorMenu30[$pref::LanguageType]; }
//
$Lang_levelEditorMenu31[0]="视图";
$Lang_levelEditorMenu31[1]="View";
function Language_levelEditorMenu31() { return $Lang_levelEditorMenu31[$pref::LanguageType]; }
//
$Lang_levelEditorMenu32[0]="屏幕复位";
$Lang_levelEditorMenu32[1]="Screen reset";
function Language_levelEditorMenu32() { return $Lang_levelEditorMenu32[$pref::LanguageType]; }
//
$Lang_levelEditorMenu33[0]="显示全部";
$Lang_levelEditorMenu33[1]="Show all";
function Language_levelEditorMenu33() { return $Lang_levelEditorMenu33[$pref::LanguageType]; }
//
$Lang_levelEditorMenu34[0]="显示已选择的";
$Lang_levelEditorMenu34[1]="Show the selected";
function Language_levelEditorMenu34() { return $Lang_levelEditorMenu34[$pref::LanguageType]; }
//
$Lang_levelEditorMenu35[0]="缩放 25%";
$Lang_levelEditorMenu35[1]="Zoom 25%";
function Language_levelEditorMenu35() { return $Lang_levelEditorMenu35[$pref::LanguageType]; }
//
$Lang_levelEditorMenu36[0]="缩放 50%";
$Lang_levelEditorMenu36[1]="Zoom 50%";
function Language_levelEditorMenu36() { return $Lang_levelEditorMenu36[$pref::LanguageType]; }
//
$Lang_levelEditorMenu37[0]="缩放 100%";
$Lang_levelEditorMenu37[1]="Zoom 100%";
function Language_levelEditorMenu37() { return $Lang_levelEditorMenu37[$pref::LanguageType]; }
//
$Lang_levelEditorMenu38[0]="缩放 200%";
$Lang_levelEditorMenu38[1]="Zoom 200%";
function Language_levelEditorMenu38() { return $Lang_levelEditorMenu38[$pref::LanguageType]; }
//
$Lang_levelEditorMenu39[0]="缩放 400%";
$Lang_levelEditorMenu39[1]="Zoom 400%";
function Language_levelEditorMenu39() { return $Lang_levelEditorMenu39[$pref::LanguageType]; }
//
$Lang_levelEditorMenu40[0]="帮助";
$Lang_levelEditorMenu40[1]="Help";
function Language_levelEditorMenu40() { return $Lang_levelEditorMenu40[$pref::LanguageType]; }
//
$Lang_levelEditorMenu41[0]="教学网站";
$Lang_levelEditorMenu41[1]="Teaching website";
function Language_levelEditorMenu41() { return $Lang_levelEditorMenu41[$pref::LanguageType]; }
//
$Lang_levelEditorMenu42[0]="帮助文档";
$Lang_levelEditorMenu42[1]="Help document";
function Language_levelEditorMenu42() { return $Lang_levelEditorMenu42[$pref::LanguageType]; }
//
$Lang_levelEditorMenu43[0]="设置教学网站服务器";
$Lang_levelEditorMenu43[1]="Set teaching server";
function Language_levelEditorMenu43() { return $Lang_levelEditorMenu43[$pref::LanguageType]; }
//
$Lang_levelEditorMenu44[0]="快捷键...";
$Lang_levelEditorMenu44[1]="Shortcut key...";
function Language_levelEditorMenu44() { return $Lang_levelEditorMenu44[$pref::LanguageType]; }
//
$Lang_levelEditorMenu45[0]="帮助文档.pdf";
$Lang_levelEditorMenu45[1]="HelpDocument.pdf";
function Language_levelEditorMenu45() { return $Lang_levelEditorMenu45[$pref::LanguageType]; }
//
$Lang_levelEditorMenu46[0]="创建Python工程";
$Lang_levelEditorMenu46[1]="Create Python project";
function Language_levelEditorMenu46() { return $Lang_levelEditorMenu46[$pref::LanguageType]; }
//
$Lang_levelEditorMenu47[0]="设置VC2015(devenv.exe)位置";
$Lang_levelEditorMenu47[1]="Set VC2015(devenv.exe) position";
function Language_levelEditorMenu47() { return $Lang_levelEditorMenu47[$pref::LanguageType]; }
//
$Lang_levelEditorMenu48[0]="设置登陆服务器";
$Lang_levelEditorMenu48[1]="Set login server";
function Language_levelEditorMenu48() { return $Lang_levelEditorMenu48[$pref::LanguageType]; }
//
$Lang_levelEditorMenu49[0]="设置PyCharm.exe位置";
$Lang_levelEditorMenu49[1]="Set PyCharm.exe position";
function Language_levelEditorMenu49() { return $Lang_levelEditorMenu49[$pref::LanguageType]; }
//
$Lang_levelEditorMenu50[0]="版本：";
$Lang_levelEditorMenu50[1]="Version: ";
function Language_levelEditorMenu50() { return $Lang_levelEditorMenu50[$pref::LanguageType]; }

//
$Lang_levelManagement0[0]="运行游戏";
$Lang_levelManagement0[1]="Run game";
function Language_levelManagement0() { return $Lang_levelManagement0[$pref::LanguageType]; }
//
$Lang_levelManagement1[0]="无法找到执行文件:";
$Lang_levelManagement1[1]="Executable file cannot be found:";
function Language_levelManagement1() { return $Lang_levelManagement1[$pref::LanguageType]; }
//
$Lang_levelManagement2[0]="确定";
$Lang_levelManagement2[1]="Confirm";
function Language_levelManagement2() { return $Lang_levelManagement2[$pref::LanguageType]; }
//
$Lang_levelManagement3[0]="停止";
$Lang_levelManagement3[1]="Stop";
function Language_levelManagement3() { return $Lang_levelManagement3[$pref::LanguageType]; }
//
$Lang_levelManagement4[0]="运行游戏";
$Lang_levelManagement4[1]="Run game";
function Language_levelManagement4() { return $Lang_levelManagement4[$pref::LanguageType]; }
//
$Lang_levelManagement5[0]="脚本运行错误!";
$Lang_levelManagement5[1]="Script running error!";
function Language_levelManagement5() { return $Lang_levelManagement5[$pref::LanguageType]; }
//
$Lang_levelManagement6[0]="按('~')键查看详细错误.";
$Lang_levelManagement6[1]="Press('~')to check.";
function Language_levelManagement6() { return $Lang_levelManagement6[$pref::LanguageType]; }
//
$Lang_levelManagement7[0]="错误";
$Lang_levelManagement7[1]="Error";
function Language_levelManagement7() { return $Lang_levelManagement7[$pref::LanguageType]; }
//
$Lang_levelManagement8[0]="无法创建新地图，没有地图视窗";
$Lang_levelManagement8[1]="Can't create level, no window view.";
function Language_levelManagement8() { return $Lang_levelManagement8[$pref::LanguageType]; }

//
$Lang_saving0[0]="是否保存地图及特效?";
$Lang_saving0[1]="Save scene and effect?";
function Language_saving0() { return $Lang_saving0[$pref::LanguageType]; }
//
$Lang_saving1[0]="地图中有未保存的平铺图或粒子，如果不保存，当运行地图或者关闭地图时，此数据将丢失. 是否保存?";
$Lang_saving1[1]="Unsaved scene tiled image or particle would loss when running or closing scene .Save?";
function Language_saving1() { return $Lang_saving1[$pref::LanguageType]; }

//
$Lang_toolbar0[0]="创建新地图";
$Lang_toolbar0[1]="Create a new scene";
function Language_toolbar0() { return $Lang_toolbar0[$pref::LanguageType]; }
//
$Lang_toolbar1[0]="打开地图";
$Lang_toolbar1[1]="Open a current scene";
function Language_toolbar1() { return $Lang_toolbar1[$pref::LanguageType]; }
//
$Lang_toolbar2[0]="保存当前地图";
$Lang_toolbar2[1]="Save current scene changes";
function Language_toolbar2() { return $Lang_toolbar2[$pref::LanguageType]; }
//
$Lang_toolbar3[0]="剪切选中的精灵至剪贴板";
$Lang_toolbar3[1]="Cut selected Sprite to clipboard";
function Language_toolbar3() { return $Lang_toolbar3[$pref::LanguageType]; }
//
$Lang_toolbar4[0]="复制选中的精灵至剪贴板";
$Lang_toolbar4[1]="Copy selected Sprite to clipboard";
function Language_toolbar4() { return $Lang_toolbar4[$pref::LanguageType]; }
//
$Lang_toolbar5[0]="粘贴剪贴板里的精灵";
$Lang_toolbar5[1]="ClipBoard Sprite paste";
function Language_toolbar5() { return $Lang_toolbar5[$pref::LanguageType]; }
//
$Lang_toolbar6[0]="撤销上次操作";
$Lang_toolbar6[1]="Last operation cancel";
function Language_toolbar6() { return $Lang_toolbar6[$pref::LanguageType]; }
//
$Lang_toolbar7[0]="重做上次操作";
$Lang_toolbar7[1]="Last operation redo";
function Language_toolbar7() { return $Lang_toolbar7[$pref::LanguageType]; }
//
$Lang_toolbar8[0]="运行游戏";
$Lang_toolbar8[1]="Run game";
function Language_toolbar8() { return $Lang_toolbar8[$pref::LanguageType]; }
//
$Lang_toolbar9[0]="编辑此精灵的碰撞体";
$Lang_toolbar9[1]="Edit the Sprite collision object";
function Language_toolbar9() { return $Lang_toolbar9[$pref::LanguageType]; }
//
$Lang_toolbar10[0]="编辑此精灵的链接点";
$Lang_toolbar10[1]="Edit the Sprite link point";
function Language_toolbar10() { return $Lang_toolbar10[$pref::LanguageType]; }
//
$Lang_toolbar11[0]="编辑此精灵的中心点";
$Lang_toolbar11[1]="Edit the Sprite center point";
function Language_toolbar11() { return $Lang_toolbar11[$pref::LanguageType]; }
//
$Lang_toolbar12[0]="绑定此精灵至另一个精灵";
$Lang_toolbar12[1]="Sprite binding to another";
function Language_toolbar12() { return $Lang_toolbar12[$pref::LanguageType]; }
//
$Lang_toolbar13[0]="解绑此精灵之前所做的绑定";
$Lang_toolbar13[1]="Unbind previous Sprite binding";
function Language_toolbar13() { return $Lang_toolbar13[$pref::LanguageType]; }
//
$Lang_toolbar14[0]="解绑此精灵之前所做的绑定";
$Lang_toolbar14[1]="Unbind previous Sprite binding";
function Language_toolbar14() { return $Lang_toolbar14[$pref::LanguageType]; }
//
$Lang_toolbar15[0]="更改此精灵的世界边界限制";
$Lang_toolbar15[1]="Change the Sprite's world boundary limit";
function Language_toolbar15() { return $Lang_toolbar15[$pref::LanguageType]; }
//
$Lang_toolbar16[0]="编辑此路径";
$Lang_toolbar16[1]="Edit the path";
function Language_toolbar16() { return $Lang_toolbar16[$pref::LanguageType]; }
//
$Lang_toolbar17[0]="编辑此平铺图";
$Lang_toolbar17[1]="Edit the tiled  image";
function Language_toolbar17() { return $Lang_toolbar17[$pref::LanguageType]; }
//
$Lang_toolbar18[0]="编辑此文字";
$Lang_toolbar18[1]="Edit the text";
function Language_toolbar18() { return $Lang_toolbar18[$pref::LanguageType]; }
//
$Lang_toolbar19[0]="编辑此多边形";
$Lang_toolbar19[1]="Edit the polygon";
function Language_toolbar19() { return $Lang_toolbar19[$pref::LanguageType]; }

// 从这起到toolbar44都是在FunCode C++代码里调用的 
$Lang_toolbar20[0]="3D模型工具";
$Lang_toolbar20[1]="3D Model tool";
function Language_toolbar20() { return $Lang_toolbar20[$pref::LanguageType]; }
//
$Lang_toolbar21[0]="动画精灵工具";
$Lang_toolbar21[1]="Animated sprite tool";
function Language_toolbar21() { return $Lang_toolbar21[$pref::LanguageType]; }
//
$Lang_toolbar22[0]="基础编辑工具";
$Lang_toolbar22[1]="Base edit tool";
function Language_toolbar22() { return $Lang_toolbar22[$pref::LanguageType]; }
//
$Lang_toolbar23[0]="基础工具";
$Lang_toolbar23[1]="Base tool";
function Language_toolbar23() { return $Lang_toolbar23[$pref::LanguageType]; }
//
$Lang_toolbar24[0]="屏幕";
$Lang_toolbar24[1]="Screen";
function Language_toolbar24() { return $Lang_toolbar24[$pref::LanguageType]; }
//
$Lang_toolbar25[0]="批量精灵工具";
$Lang_toolbar25[1]="Batch Sprite tool";
function Language_toolbar25() { return $Lang_toolbar25[$pref::LanguageType]; }
//
$Lang_toolbar26[0]="创建工具";
$Lang_toolbar26[1]="Create tool";
function Language_toolbar26() { return $Lang_toolbar26[$pref::LanguageType]; }
//
$Lang_toolbar27[0]="挂接工具";
$Lang_toolbar27[1]="Mount tool";
function Language_toolbar27() { return $Lang_toolbar27[$pref::LanguageType]; }
//
$Lang_toolbar28[0]="挂接工具";
$Lang_toolbar28[1]="Mount tool";
function Language_toolbar28() { return $Lang_toolbar28[$pref::LanguageType]; }
//
$Lang_toolbar29[0]="粒子特效工具";
$Lang_toolbar29[1]="Particle effect tool";
function Language_toolbar29() { return $Lang_toolbar29[$pref::LanguageType]; }
//
$Lang_toolbar30[0]="路径工具";
$Lang_toolbar30[1]="Path tool";
function Language_toolbar30() { return $Lang_toolbar30[$pref::LanguageType]; }
//
$Lang_toolbar31[0]="路径工具";
$Lang_toolbar31[1]="Path tool";
function Language_toolbar31() { return $Lang_toolbar31[$pref::LanguageType]; }
//
$Lang_toolbar32[0]="多边形碰撞工具";
$Lang_toolbar32[1]="Poly collision tool";
function Language_toolbar32() { return $Lang_toolbar32[$pref::LanguageType]; }
//
$Lang_toolbar33[0]="地图物体工具";
$Lang_toolbar33[1]="Scene object tool";
function Language_toolbar33() { return $Lang_toolbar33[$pref::LanguageType]; }
//
$Lang_toolbar34[0]="滚动图工具";
$Lang_toolbar34[1]="Scroller tool";
function Language_toolbar34() { return $Lang_toolbar34[$pref::LanguageType]; }
//
$Lang_toolbar35[0]="选择工具";
$Lang_toolbar35[1]="Select tool";
function Language_toolbar35() { return $Lang_toolbar35[$pref::LanguageType]; }
//
$Lang_toolbar36[0]="模型向量工具";
$Lang_toolbar36[1]="Shape vector tool";
function Language_toolbar36() { return $Lang_toolbar36[$pref::LanguageType]; }
//
$Lang_toolbar37[0]="排序点工具";
$Lang_toolbar37[1]="Sort point tool";
function Language_toolbar37() { return $Lang_toolbar37[$pref::LanguageType]; }
//
$Lang_toolbar38[0]="静态精灵工具";
$Lang_toolbar38[1]="Static Sprite tool";
function Language_toolbar38() { return $Lang_toolbar38[$pref::LanguageType]; }
//
$Lang_toolbar39[0]="文字编辑工具";
$Lang_toolbar39[1]="Text edit tool";
function Language_toolbar39() { return $Lang_toolbar39[$pref::LanguageType]; }
//
$Lang_toolbar40[0]="文字物体工具";
$Lang_toolbar40[1]="Text object tool";
function Language_toolbar40() { return $Lang_toolbar40[$pref::LanguageType]; }
//
$Lang_toolbar41[0]="平铺图工具";
$Lang_toolbar41[1]="Tilemap tool";
function Language_toolbar41() { return $Lang_toolbar41[$pref::LanguageType]; }
//
$Lang_toolbar42[0]="平铺图工具";
$Lang_toolbar42[1]="Tilemap tool";
function Language_toolbar42() { return $Lang_toolbar42[$pref::LanguageType]; }
//
$Lang_toolbar43[0]="触发器工具";
$Lang_toolbar43[1]="Trigger tool";
function Language_toolbar43() { return $Lang_toolbar43[$pref::LanguageType]; }
//
$Lang_toolbar44[0]="世界边界限制工具";
$Lang_toolbar44[1]="World limit tool";
function Language_toolbar44() { return $Lang_toolbar44[$pref::LanguageType]; }

//
$Lang_LocalPointEditor0[0]="边界坐标编辑";
$Lang_LocalPointEditor0[1]="Border coordinate edit";
function Language_LocalPointEditor0() { return $Lang_LocalPointEditor0[$pref::LanguageType]; }
//
$Lang_LocalPointEditor1[0]="区域";
$Lang_LocalPointEditor1[1]="Area";
function Language_LocalPointEditor1() { return $Lang_LocalPointEditor1[$pref::LanguageType]; }
//
$Lang_LocalPointEditor2[0]="显示凸面外体";
$Lang_LocalPointEditor2[1]="Show outer convexity";
function Language_LocalPointEditor2() { return $Lang_LocalPointEditor2[$pref::LanguageType]; }
//
$Lang_LocalPointEditor3[0]="显示边界";
$Lang_LocalPointEditor3[1]="Show border";
function Language_LocalPointEditor3() { return $Lang_LocalPointEditor3[$pref::LanguageType]; }
//
$Lang_LocalPointEditor4[0]="显示凸面边界错误";
$Lang_LocalPointEditor4[1]="Show convexity border error";
function Language_LocalPointEditor4() { return $Lang_LocalPointEditor4[$pref::LanguageType]; }
//
$Lang_LocalPointEditor5[0]="显示边界错误";
$Lang_LocalPointEditor5[1]="Show border error";
function Language_LocalPointEditor5() { return $Lang_LocalPointEditor5[$pref::LanguageType]; }
//
$Lang_LocalPointEditor6[0]="在两点之间建立点";
$Lang_LocalPointEditor6[1]="Creat point between two points";
function Language_LocalPointEditor6() { return $Lang_LocalPointEditor6[$pref::LanguageType]; }
//
$Lang_LocalPointEditor7[0]="在终点新建点";
$Lang_LocalPointEditor7[1]="Create new point at the end point";
function Language_LocalPointEditor7() { return $Lang_LocalPointEditor7[$pref::LanguageType]; }
//
$Lang_LocalPointEditor8[0]="由凸面外体取代点";
$Lang_LocalPointEditor8[1]="Replace point from the outer convexity";
function Language_LocalPointEditor8() { return $Lang_LocalPointEditor8[$pref::LanguageType]; }
//
$Lang_LocalPointEditor9[0]="方形宽高比";
$Lang_LocalPointEditor9[1]="Square aspect ratio";
function Language_LocalPointEditor9() { return $Lang_LocalPointEditor9[$pref::LanguageType]; }
//
$Lang_LocalPointEditor10[0]="平面宽高比";
$Lang_LocalPointEditor10[1]="Planar aspect ratio";
function Language_LocalPointEditor10() { return $Lang_LocalPointEditor10[$pref::LanguageType]; }
//
$Lang_LocalPointEditor11[0]="新建:";
$Lang_LocalPointEditor11[1]="Newly create:";
function Language_LocalPointEditor11() { return $Lang_LocalPointEditor11[$pref::LanguageType]; }
//
$Lang_LocalPointEditor12[0]="创建此点";
$Lang_LocalPointEditor12[1]="Create the point";
function Language_LocalPointEditor12() { return $Lang_LocalPointEditor12[$pref::LanguageType]; }
//
$Lang_LocalPointEditor13[0]="显示背景图";
$Lang_LocalPointEditor13[1]="Show background image";
function Language_LocalPointEditor13() { return $Lang_LocalPointEditor13[$pref::LanguageType]; }
//
$Lang_LocalPointEditor14[0]="显示背景";
$Lang_LocalPointEditor14[1]="Show background";
function Language_LocalPointEditor14() { return $Lang_LocalPointEditor14[$pref::LanguageType]; }
//
$Lang_LocalPointEditor15[0]="撤销本次操作";
$Lang_LocalPointEditor15[1]="Operation cancel";
function Language_LocalPointEditor15() { return $Lang_LocalPointEditor15[$pref::LanguageType]; }
//
$Lang_LocalPointEditor16[0]="重做上次操作";
$Lang_LocalPointEditor16[1]="Last operation redo";
function Language_LocalPointEditor16() { return $Lang_LocalPointEditor16[$pref::LanguageType]; }
//
$Lang_LocalPointEditor17[0]="保存";
$Lang_LocalPointEditor17[1]="Save";
function Language_LocalPointEditor17() { return $Lang_LocalPointEditor17[$pref::LanguageType]; }
//
$Lang_LocalPointEditor18[0]="取消";
$Lang_LocalPointEditor18[1]="Cancel";
function Language_LocalPointEditor18() { return $Lang_LocalPointEditor18[$pref::LanguageType]; }

//
$Lang_animationEditor_main0[0]="选择图片资源";
$Lang_animationEditor_main0[1]="Select Image Resource";
function Language_animationEditor_main0() { return $Lang_animationEditor_main0[$pref::LanguageType]; }

//
$Lang_collisionPolyEditor0[0]="保存碰撞体?";
$Lang_collisionPolyEditor0[1]="Save collision object?";
function Language_collisionPolyEditor0() { return $Lang_collisionPolyEditor0[$pref::LanguageType]; }
//
$Lang_collisionPolyEditor1[0]="保存碰撞体替代多变形?";
$Lang_collisionPolyEditor1[1]="Save the collision object to replace polygon?";
function Language_collisionPolyEditor1() { return $Lang_collisionPolyEditor1[$pref::LanguageType]; }

//
$Lang_linkpointEditor0[0]="链接点正在使用中，删除此链接点及其子节点?";
$Lang_linkpointEditor0[1]="Link point is being used,delete the link point and its sub-node?";
function Language_linkpointEditor0() { return $Lang_linkpointEditor0[$pref::LanguageType]; }
//
$Lang_linkpointEditor1[0]="删减物体?";
$Lang_linkpointEditor1[1]="Delete Link point?";
function Language_linkpointEditor1() { return $Lang_linkpointEditor1[$pref::LanguageType]; }

//
$Lang_localPointEditorcs0[0]="      -      左键单击创建, 拖拽移动, 右键单击删除. 拖拽点列表可以更改顺序.";
$Lang_localPointEditorcs0[1]="      -      Left click to create,drag to move,right click to delete.Drag list to change order";
function Language_localPointEditorcs0() { return $Lang_localPointEditorcs0[$pref::LanguageType]; }
//
$Lang_localPointEditorcs1[0]="删除此点";
$Lang_localPointEditorcs1[1]="Delete point";
function Language_localPointEditorcs1() { return $Lang_localPointEditorcs1[$pref::LanguageType]; }

//
$Lang_localPointEditor_main0[0]="链接(挂接)点编辑器";
$Lang_localPointEditor_main0[1]="Mount point editor";
function Language_localPointEditor_main0() { return $Lang_localPointEditor_main0[$pref::LanguageType]; }
//
$Lang_localPointEditor_main1[0]="碰撞编辑器";
$Lang_localPointEditor_main1[1]="Collision editor";
function Language_localPointEditor_main1() { return $Lang_localPointEditor_main1[$pref::LanguageType]; }
//
$Lang_localPointEditor_main2[0]="多边形编辑器";
$Lang_localPointEditor_main2[1]="Polygon editor";
function Language_localPointEditor_main2() { return $Lang_localPointEditor_main2[$pref::LanguageType]; }
//
$Lang_localPointEditor_main3[0]="多边形行为编辑器";
$Lang_localPointEditor_main3[1]="Polygon behavior editor";
function Language_localPointEditor_main3() { return $Lang_localPointEditor_main3[$pref::LanguageType]; }
//
$Lang_localPointEditor_main4[0]="本地坐标列表编辑器";
$Lang_localPointEditor_main4[1]="Local coordinate list editor ";
function Language_localPointEditor_main4() { return $Lang_localPointEditor_main4[$pref::LanguageType]; }

//
$Lang_FunCodeParticle0[0]="粒子特效资源";
$Lang_FunCodeParticle0[1]="Particle effect resource";
function Language_FunCodeParticle0() { return $Lang_FunCodeParticle0[$pref::LanguageType]; }
//
$Lang_FunCodeParticle1[0]="资源";
$Lang_FunCodeParticle1[1]="Resource";
function Language_FunCodeParticle1() { return $Lang_FunCodeParticle1[$pref::LanguageType]; }
//
$Lang_FunCodeParticle2[0]="预览";
$Lang_FunCodeParticle2[1]="Preview";
function Language_FunCodeParticle2() { return $Lang_FunCodeParticle2[$pref::LanguageType]; }
//
$Lang_FunCodeParticle3[0]="添加到工程";
$Lang_FunCodeParticle3[1]="Add to the project";
function Language_FunCodeParticle3() { return $Lang_FunCodeParticle3[$pref::LanguageType]; }
//
$Lang_FunCodeParticle4[0]="关闭窗口时释放图片资源(适用低配置机器)";
$Lang_FunCodeParticle4[1]="Image resources release when window off(for  low-configure machine)";
function Language_FunCodeParticle4() { return $Lang_FunCodeParticle4[$pref::LanguageType]; }

//
$Lang_projectBuilder0[0]="生成游戏安装包";
$Lang_projectBuilder0[1]="Create game installer";
function Language_projectBuilder0() { return $Lang_projectBuilder0[$pref::LanguageType]; }
//
$Lang_projectBuilder1[0]="公司名字:";
$Lang_projectBuilder1[1]="Company name:";
function Language_projectBuilder1() { return $Lang_projectBuilder1[$pref::LanguageType]; }
//
$Lang_projectBuilder2[0]="产品名称:";
$Lang_projectBuilder2[1]="Product name:";
function Language_projectBuilder2() { return $Lang_projectBuilder2[$pref::LanguageType]; }
//
$Lang_projectBuilder3[0]="初始地图:";
$Lang_projectBuilder3[1]="Original scene:";
function Language_projectBuilder3() { return $Lang_projectBuilder3[$pref::LanguageType]; }
//
$Lang_projectBuilder4[0]="浏览默认地图";
$Lang_projectBuilder4[1]="Browse default scene";
function Language_projectBuilder4() { return $Lang_projectBuilder4[$pref::LanguageType]; }
//
$Lang_projectBuilder5[0]="输出目录";
$Lang_projectBuilder5[1]="Output directory";
function Language_projectBuilder5() { return $Lang_projectBuilder5[$pref::LanguageType]; }
//
$Lang_projectBuilder6[0]="浏览额外的输出位置";
$Lang_projectBuilder6[1]="Browse extra output location";
function Language_projectBuilder6() { return $Lang_projectBuilder6[$pref::LanguageType]; }
//
$Lang_projectBuilder7[0]="运行平台";
$Lang_projectBuilder7[1]="Running platform";
function Language_projectBuilder7() { return $Lang_projectBuilder7[$pref::LanguageType]; }
//
$Lang_projectBuilder8[0]="包含脚本源代码";
$Lang_projectBuilder8[1]="Scipt source code included";
function Language_projectBuilder8() { return $Lang_projectBuilder8[$pref::LanguageType]; }
//
$Lang_projectBuilder9[0]="取消";
$Lang_projectBuilder9[1]="Cancel";
function Language_projectBuilder9() { return $Lang_projectBuilder9[$pref::LanguageType]; }
//
$Lang_projectBuilder10[0]="生成";
$Lang_projectBuilder10[1]="Create";
function Language_projectBuilder10() { return $Lang_projectBuilder10[$pref::LanguageType]; }

//
$Lang_newProjectDlg0[0]="新建项目";
$Lang_newProjectDlg0[1]="New create project";
function Language_newProjectDlg0() { return $Lang_newProjectDlg0[$pref::LanguageType]; }
//
$Lang_newProjectDlg1[0]="浏览你的电脑";
$Lang_newProjectDlg1[1]="Browse your computer";
function Language_newProjectDlg1() { return $Lang_newProjectDlg1[$pref::LanguageType]; }
//
$Lang_newProjectDlg2[0]="位置 :";
$Lang_newProjectDlg2[1]="Location:";
function Language_newProjectDlg2() { return $Lang_newProjectDlg2[$pref::LanguageType]; }
//
$Lang_newProjectDlg3[0]="项目模板 :";
$Lang_newProjectDlg3[1]="Project template:";
function Language_newProjectDlg3() { return $Lang_newProjectDlg3[$pref::LanguageType]; }
//
$Lang_newProjectDlg4[0]="名字 :";
$Lang_newProjectDlg4[1]="Name:";
function Language_newProjectDlg4() { return $Lang_newProjectDlg4[$pref::LanguageType]; }
//
$Lang_newProjectDlg5[0]="拷贝模板执行档至新建项目";
$Lang_newProjectDlg5[1]="Copy template to new project";
function Language_newProjectDlg5() { return $Lang_newProjectDlg5[$pref::LanguageType]; }
//
$Lang_newProjectDlg6[0]="创建";
$Lang_newProjectDlg6[1]="Create";
function Language_newProjectDlg6() { return $Lang_newProjectDlg6[$pref::LanguageType]; }

//
$Lang_openProjectDlg0[0]="打开项目";
$Lang_openProjectDlg0[1]="Open project";
function Language_openProjectDlg0() { return $Lang_openProjectDlg0[$pref::LanguageType]; }
//
$Lang_openProjectDlg1[0]="取消";
$Lang_openProjectDlg1[1]="Cancel";
function Language_openProjectDlg1() { return $Lang_openProjectDlg1[$pref::LanguageType]; }
//
$Lang_openProjectDlg2[0]="打开项目";
$Lang_openProjectDlg2[1]="Open project";
function Language_openProjectDlg2() { return $Lang_openProjectDlg2[$pref::LanguageType]; }

//
$Lang_projectOptionsDlg0[0]="项目资源";
$Lang_projectOptionsDlg0[1]="Project options";
function Language_projectOptionsDlg0() { return $Lang_projectOptionsDlg0[$pref::LanguageType]; }
//
$Lang_projectOptionsDlg1[0]="添加到项目";
$Lang_projectOptionsDlg1[1]="Add to the project";
function Language_projectOptionsDlg1() { return $Lang_projectOptionsDlg1[$pref::LanguageType]; }
//
$Lang_projectOptionsDlg2[0]="从项目里删除";
$Lang_projectOptionsDlg2[1]="Delete from the project";
function Language_projectOptionsDlg2() { return $Lang_projectOptionsDlg2[$pref::LanguageType]; }
//
$Lang_projectOptionsDlg3[0]="取消";
$Lang_projectOptionsDlg3[1]="Cancel";
function Language_projectOptionsDlg3() { return $Lang_projectOptionsDlg3[$pref::LanguageType]; }
//
$Lang_projectOptionsDlg4[0]="保存";
$Lang_projectOptionsDlg4[1]="Save";
function Language_projectOptionsDlg4() { return $Lang_projectOptionsDlg4[$pref::LanguageType]; }
//
$Lang_projectOptionsDlg5[0]="可用资源";
$Lang_projectOptionsDlg5[1]="Available options";
function Language_projectOptionsDlg5() { return $Lang_projectOptionsDlg5[$pref::LanguageType]; }
//
$Lang_projectOptionsDlg6[0]="当前项目的资源";
$Lang_projectOptionsDlg6[1]="Current project options";
function Language_projectOptionsDlg6() { return $Lang_projectOptionsDlg6[$pref::LanguageType]; }

//
$Lang_levelEditorMap0[0]="移动选择物至靠近屏幕一层";
$Lang_levelEditorMap0[1]="Move selection near screen layer";
function Language_levelEditorMap0() { return $Lang_levelEditorMap0[$pref::LanguageType]; }
//
$Lang_levelEditorMap1[0]="移动选择物至远离屏幕一层";
$Lang_levelEditorMap1[1]="Move selection far from screen layer";
function Language_levelEditorMap1() { return $Lang_levelEditorMap1[$pref::LanguageType]; }
//
$Lang_levelEditorMap2[0]="激活选择工具";
$Lang_levelEditorMap2[1]="Activate selection tool";
function Language_levelEditorMap2() { return $Lang_levelEditorMap2[$pref::LanguageType]; }
//
$Lang_levelEditorMap3[0]="显示编辑面板";
$Lang_levelEditorMap3[1]="Show edit panel";
function Language_levelEditorMap3() { return $Lang_levelEditorMap3[$pref::LanguageType]; }
//
$Lang_levelEditorMap4[0]="显示创建面板";
$Lang_levelEditorMap4[1]="Show create panel";
function Language_levelEditorMap4() { return $Lang_levelEditorMap4[$pref::LanguageType]; }
//
$Lang_levelEditorMap5[0]="显示项目面板";
$Lang_levelEditorMap5[1]="Show project panel";
function Language_levelEditorMap5() { return $Lang_levelEditorMap5[$pref::LanguageType]; }
//
$Lang_levelEditorMap6[0]="屏幕复位";
$Lang_levelEditorMap6[1]="Screen reset";
function Language_levelEditorMap6() { return $Lang_levelEditorMap6[$pref::LanguageType]; }
//
$Lang_levelEditorMap7[0]="显示所有精灵";
$Lang_levelEditorMap7[1]="Show all the sprites";
function Language_levelEditorMap7() { return $Lang_levelEditorMap7[$pref::LanguageType]; }
//
$Lang_levelEditorMap8[0]="放大窗口";
$Lang_levelEditorMap8[1]="Zoom in";
function Language_levelEditorMap8() { return $Lang_levelEditorMap8[$pref::LanguageType]; }
//
$Lang_levelEditorMap9[0]="缩小窗口";
$Lang_levelEditorMap9[1]="Zoom out";
function Language_levelEditorMap9() { return $Lang_levelEditorMap9[$pref::LanguageType]; }
//
$Lang_levelEditorMap10[0]="向左移动窗口";
$Lang_levelEditorMap10[1]="Window moves left";
function Language_levelEditorMap10() { return $Lang_levelEditorMap10[$pref::LanguageType]; }
//
$Lang_levelEditorMap11[0]="向右移动窗口";
$Lang_levelEditorMap11[1]="Window moves right";
function Language_levelEditorMap11() { return $Lang_levelEditorMap11[$pref::LanguageType]; }
//
$Lang_levelEditorMap12[0]="向上移动窗口";
$Lang_levelEditorMap12[1]="Window moves up";
function Language_levelEditorMap12() { return $Lang_levelEditorMap12[$pref::LanguageType]; }
//
$Lang_levelEditorMap13[0]="向下移动窗口";
$Lang_levelEditorMap13[1]="Window moves down";
function Language_levelEditorMap13() { return $Lang_levelEditorMap13[$pref::LanguageType]; }
//
$Lang_levelEditorMap14[0]="撤销";
$Lang_levelEditorMap14[1]="Cancel";
function Language_levelEditorMap14() { return $Lang_levelEditorMap14[$pref::LanguageType]; }
//
$Lang_levelEditorMap15[0]="重做";
$Lang_levelEditorMap15[1]="Redo";
function Language_levelEditorMap15() { return $Lang_levelEditorMap15[$pref::LanguageType]; }
//
$Lang_levelEditorMap16[0]="拷贝";
$Lang_levelEditorMap16[1]="Copy";
function Language_levelEditorMap16() { return $Lang_levelEditorMap16[$pref::LanguageType]; }
//
$Lang_levelEditorMap17[0]="剪切";
$Lang_levelEditorMap17[1]="Cut";
function Language_levelEditorMap17() { return $Lang_levelEditorMap17[$pref::LanguageType]; }
//
$Lang_levelEditorMap18[0]="粘贴";
$Lang_levelEditorMap18[1]="Paste";
function Language_levelEditorMap18() { return $Lang_levelEditorMap18[$pref::LanguageType]; }

//
$Lang_IPInput0[0]="IP设置";
$Lang_IPInput0[1]="IP Config";
function Language_IPInput0() { return $Lang_IPInput0[$pref::LanguageType]; }
//
$Lang_IPInput1[0]="服务器IP：";
$Lang_IPInput1[1]="Server IP:";
function Language_IPInput1() { return $Lang_IPInput1[$pref::LanguageType]; }
//
$Lang_IPInput2[0]="确定";
$Lang_IPInput2[1]="Confirm";
function Language_IPInput2() { return $Lang_IPInput2[$pref::LanguageType]; }
//
$Lang_IPInput3[0]="取消";
$Lang_IPInput3[1]="Cancel";
function Language_IPInput3() { return $Lang_IPInput3[$pref::LanguageType]; }
//
$Lang_IPInput4[0]="请输入IP！";
$Lang_IPInput4[1]="Enter IP please!";
function Language_IPInput4() { return $Lang_IPInput4[$pref::LanguageType]; }
//
$Lang_IPInput5[0]="IP已保存";
$Lang_IPInput5[1]="IP Saved";
function Language_IPInput5() { return $Lang_IPInput5[$pref::LanguageType]; }
//
$Lang_IPInput6[0]="端口：";
$Lang_IPInput6[1]="Port:";
function Language_IPInput6() { return $Lang_IPInput6[$pref::LanguageType]; }
//
$Lang_IPInput7[0]="请输入端口！";
$Lang_IPInput7[1]="Enter Port please!";
function Language_IPInput7() { return $Lang_IPInput7[$pref::LanguageType]; }

echo("- Initialized Language");