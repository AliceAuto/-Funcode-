
//
$LangCount = 2;
$Lang_Type[0] = "��������";
$Lang_Type[1] = "English";
$Lang_Type[2] = "-";
$Lang_Type[3] = "-";
$Lang_Type[4] = "-";
function Language_GetLanguageMenu(%index) { return $Lang_Type[%index]; }
function Language_GetLanguageTitle() { return "����(Language)"; }

//
$Lang_AnimBuilder1[0]="�����༭��";
$Lang_AnimBuilder1[1]="Animation Editor";
function Language_AnimBuilder1() { return $Lang_AnimBuilder1[$pref::LanguageType]; }
//
$Lang_AnimBuilder2[0]="ɾ��������ѡ���֡";
$Lang_AnimBuilder2[1]="Delete all the frames chosen";
function Language_AnimBuilder2() { return $Lang_AnimBuilder2[$pref::LanguageType]; }
//
$Lang_AnimBuilder3[0]="�������ͼƬ";
$Lang_AnimBuilder3[1]="Add a completed picture";
function Language_AnimBuilder3() { return $Lang_AnimBuilder3[$pref::LanguageType]; }
//
$Lang_AnimBuilder4[0]="��ͣ����";
$Lang_AnimBuilder4[1]="Pause";
function Language_AnimBuilder4() { return $Lang_AnimBuilder4[$pref::LanguageType]; }
//
$Lang_AnimBuilder5[0]="���Ŷ���";
$Lang_AnimBuilder5[1]="Play";
function Language_AnimBuilder5() { return $Lang_AnimBuilder5[$pref::LanguageType]; }
//
$Lang_AnimBuilder6[0]="ѭ������";
$Lang_AnimBuilder6[1]="Loop";
function Language_AnimBuilder6() { return $Lang_AnimBuilder6[$pref::LanguageType]; }
//
$Lang_AnimBuilder7[0]="���";
$Lang_AnimBuilder7[1]="Ramdon";
function Language_AnimBuilder7() { return $Lang_AnimBuilder7[$pref::LanguageType]; }
//
$Lang_AnimBuilder8[0]="֡/��";
$Lang_AnimBuilder8[1]="Frame/Second";
function Language_AnimBuilder8() { return $Lang_AnimBuilder8[$pref::LanguageType]; }
//
$Lang_AnimBuilder9[0]="��ʼ֡";
$Lang_AnimBuilder9[1]="Beginning Frame";
function Language_AnimBuilder9() { return $Lang_AnimBuilder9[$pref::LanguageType]; }
//
$Lang_AnimBuilder10[0]="����";
$Lang_AnimBuilder10[1]="Name";
function Language_AnimBuilder10() { return $Lang_AnimBuilder10[$pref::LanguageType]; }
//
$Lang_AnimBuilder11[0]="˫�򲥷�";
$Lang_AnimBuilder11[1]="Two-way Play";
function Language_AnimBuilder11() { return $Lang_AnimBuilder11[$pref::LanguageType]; }
//
$Lang_AnimBuilder12[0]="���򲥷�";
$Lang_AnimBuilder12[1]="Reverse Play";
function Language_AnimBuilder12() { return $Lang_AnimBuilder12[$pref::LanguageType]; }
//
$Lang_AnimBuilder13[0]="����";
$Lang_AnimBuilder13[1]="Save";
function Language_AnimBuilder13() { return $Lang_AnimBuilder13[$pref::LanguageType]; }
//
$Lang_AnimBuilder14[0]="ȡ��";
$Lang_AnimBuilder14[1]="Cancel";
function Language_AnimBuilder14() { return $Lang_AnimBuilder14[$pref::LanguageType]; }

//
$Lang_FunCodeAnim1[0]="������Դ";
$Lang_FunCodeAnim1[1]="Animation Resources";
function Language_FunCodeAnim1() { return $Lang_FunCodeAnim1[$pref::LanguageType]; }
//
$Lang_FunCodeAnim2[0]="��Դ";
$Lang_FunCodeAnim2[1]="Resources";
function Language_FunCodeAnim2() { return $Lang_FunCodeAnim2[$pref::LanguageType]; }
//
$Lang_FunCodeAnim3[0]="Ԥ��";
$Lang_FunCodeAnim3[1]="Preview";
function Language_FunCodeAnim3() { return $Lang_FunCodeAnim3[$pref::LanguageType]; }
//
$Lang_FunCodeAnim4[0]="��ӵ�����";
$Lang_FunCodeAnim4[1]="Add to the project";
function Language_FunCodeAnim4() { return $Lang_FunCodeAnim4[$pref::LanguageType]; }
//
$Lang_FunCodeAnim5[0]="�رմ���ʱ�ͷ�ͼƬ��Դ(���õ����û���)";
$Lang_FunCodeAnim5[1]="Release pictures after closing windows(for the  lower-configured)";
function Language_FunCodeAnim5() { return $Lang_FunCodeAnim5[$pref::LanguageType]; }

//
$Lang_ImageMapSel1[0]="ѡ��";
$Lang_ImageMapSel1[1]="Select";
function Language_ImageMapSel1() { return $Lang_ImageMapSel1[$pref::LanguageType]; }
//
$Lang_ImageMapSel2[0]="��Դ";
$Lang_ImageMapSel2[1]="Resources";
function Language_ImageMapSel2() { return $Lang_ImageMapSel2[$pref::LanguageType]; }
//
$Lang_ImageMapSel3[0]="Ԥ��";
$Lang_ImageMapSel3[1]="Preview";
function Language_ImageMapSel3() { return $Lang_ImageMapSel3[$pref::LanguageType]; }
//
$Lang_ImageMapSel4[0]="ѡ��";
$Lang_ImageMapSel4[1]="Select";
function Language_ImageMapSel4() { return $Lang_ImageMapSel4[$pref::LanguageType]; }

//
$Lang_behaviorEditor1[0]="��Ϊ(�ű����)";
$Lang_behaviorEditor1[1]="Behavior(Script)";
function Language_behaviorEditor1() { return $Lang_behaviorEditor1[$pref::LanguageType]; }

//
$Lang_BehaviorList1[0]="��ǰ��ӵ����������Ϊ";
$Lang_BehaviorList1[1]="Current add to the object behavior";
function Language_BehaviorList1() { return $Lang_BehaviorList1[$pref::LanguageType]; }
//
$Lang_BehaviorList2[0]="�����ѡ�����Ϊ��������";
$Lang_BehaviorList2[1]="Add the chosen behavior to the object";
function Language_BehaviorList2() { return $Lang_BehaviorList2[$pref::LanguageType]; }
//
$Lang_BehaviorList3[0]="ɾ��������Ĵ���Ϊ";
$Lang_BehaviorList3[1]="Delete the object behavior";
function Language_BehaviorList3() { return $Lang_BehaviorList3[$pref::LanguageType]; }

//
$Lang_BehaviorDlg1[0]="���/ɾ���������Ϊ";
$Lang_BehaviorDlg1[1]="Add/Delect object behavior";
function Language_BehaviorDlg1() { return $Lang_BehaviorDlg1[$pref::LanguageType]; }
//
$Lang_BehaviorDlg2[0]="�����Ϊ";
$Lang_BehaviorDlg2[1]="Add behavior";
function Language_BehaviorDlg2() { return $Lang_BehaviorDlg2[$pref::LanguageType]; }
//
$Lang_BehaviorDlg3[0]="ɾ����Ϊ";
$Lang_BehaviorDlg3[1]="Delete behavior";
function Language_BehaviorDlg3() { return $Lang_BehaviorDlg3[$pref::LanguageType]; }
//
$Lang_BehaviorDlg4[0]="ȡ��";
$Lang_BehaviorDlg4[1]="Cancel";
function Language_BehaviorDlg4() { return $Lang_BehaviorDlg4[$pref::LanguageType]; }
  //
$Lang_BehaviorDlg5[0]="Ӧ��";
$Lang_BehaviorDlg5[1]="Apply";
function Language_BehaviorDlg5() { return $Lang_BehaviorDlg5[$pref::LanguageType]; }
  //
$Lang_BehaviorDlg6[0]="���õ���Ϊ";
$Lang_BehaviorDlg6[1]="Available Behavior";
function Language_BehaviorDlg6() { return $Lang_BehaviorDlg6[$pref::LanguageType]; }
  //
$Lang_BehaviorDlg7[0]="��֯:";
$Lang_BehaviorDlg7[1]="Construction:";
function Language_BehaviorDlg7() { return $Lang_BehaviorDlg7[$pref::LanguageType]; }
  //
$Lang_BehaviorDlg8[0]="��Դ";
$Lang_BehaviorDlg8[1]="Resources";
function Language_BehaviorDlg8() { return $Lang_BehaviorDlg8[$pref::LanguageType]; }
  //
$Lang_BehaviorDlg9[0]="����";
$Lang_BehaviorDlg9[1]="Type";
function Language_BehaviorDlg9() { return $Lang_BehaviorDlg9[$pref::LanguageType]; }
  //
$Lang_BehaviorDlg10[0]="��ǰӦ�õ���Ϊ";
$Lang_BehaviorDlg10[1]="Behavior being applied at present";
function Language_BehaviorDlg10() { return $Lang_BehaviorDlg10[$pref::LanguageType]; }
  //
$Lang_BehaviorDlg11[0]="δѡ���κ���Ϊ";
$Lang_BehaviorDlg11[1]="No behavior selected";
function Language_BehaviorDlg11() { return $Lang_BehaviorDlg11[$pref::LanguageType]; }
  //
$Lang_BehaviorDlg12[0]="ֵ��";
$Lang_BehaviorDlg12[1]="Range";
function Language_BehaviorDlg12() { return $Lang_BehaviorDlg12[$pref::LanguageType]; }
  //
$Lang_BehaviorDlg13[0]="�������߹ر���Ϊ��Ϣ���";
$Lang_BehaviorDlg13[1]="Open or close behavior message panel";
function Language_BehaviorDlg13() { return $Lang_BehaviorDlg13[$pref::LanguageType]; }
  //
$Lang_BehaviorDlg14[0]="�����ƶ�ѡ�����Ϊ";
$Lang_BehaviorDlg14[1]="Move up the chosen behavior";
function Language_BehaviorDlg14() { return $Lang_BehaviorDlg14[$pref::LanguageType]; }
  //
$Lang_BehaviorDlg15[0]="�����ƶ�ѡ�����Ϊ";
$Lang_BehaviorDlg15[1]="Move down the chosen behavior";
function Language_BehaviorDlg15() { return $Lang_BehaviorDlg15[$pref::LanguageType]; }
  //
$Lang_BehaviorDlg16[0]="�Զ�������Ϊ��Ĭ������";
$Lang_BehaviorDlg16[1]="Auto Alter behavior to the default data";
function Language_BehaviorDlg16() { return $Lang_BehaviorDlg16[$pref::LanguageType]; }
  //
$Lang_BehaviorDlg17[0]="�Զ�Ĭ��";
$Lang_BehaviorDlg17[1]="Auto Default";
function Language_BehaviorDlg17() { return $Lang_BehaviorDlg17[$pref::LanguageType]; }
  //
$Lang_BehaviorDlg18[0]="�Զ���ȡ";
$Lang_BehaviorDlg18[1]="Auto Claim";
function Language_BehaviorDlg18() { return $Lang_BehaviorDlg18[$pref::LanguageType]; }

  //
$Lang_guiForm1[0]="ˮƽ��ִ˴���";
$Lang_guiForm1[1]="Split the window horizontally";
function Language_guiForm1() { return $Lang_guiForm1[$pref::LanguageType]; }
    //
$Lang_guiForm2[0]="��ֱ��ִ˴���";
$Lang_guiForm2[1]="Split the window vertically";
function Language_guiForm2() { return $Lang_guiForm2[$pref::LanguageType]; }
    //
$Lang_guiForm3[0]="ɾ���˴���";
$Lang_guiForm3[1]="Delete the window";
function Language_guiForm3() { return $Lang_guiForm3[$pref::LanguageType]; }

  //
$Lang_guiFormContent1[0]="��ͼԤ��";
$Lang_guiFormContent1[1]="Scene Preview";
function Language_guiFormContent1() { return $Lang_guiFormContent1[$pref::LanguageType]; }

  //
$Lang_AccountInput1[0]="�������˺�";
$Lang_AccountInput1[1]="Enter the account";
function Language_AccountInput1() { return $Lang_AccountInput1[$pref::LanguageType]; }
    //
$Lang_AccountInput2[0]="������С��20����ĸ���˺�";
$Lang_AccountInput2[1]="Enter an account less than twenty letters";
function Language_AccountInput2() { return $Lang_AccountInput2[$pref::LanguageType]; }
    //
$Lang_AccountInput3[0]="����������";
$Lang_AccountInput3[1]="Enter the password";
function Language_AccountInput3() { return $Lang_AccountInput3[$pref::LanguageType]; }
    //
$Lang_AccountInput4[0]="������С��16����ĸ������";
$Lang_AccountInput4[1]="Enter a password less than 16 letters";
function Language_AccountInput4() { return $Lang_AccountInput4[$pref::LanguageType]; }
    //
$Lang_AccountInput5[0]="FunCode��½";
$Lang_AccountInput5[1]="FunCode Log in";
function Language_AccountInput5() { return $Lang_AccountInput5[$pref::LanguageType]; }
    //
$Lang_AccountInput6[0]="ȡ��";
$Lang_AccountInput6[1]="Cancel";
function Language_AccountInput6() { return $Lang_AccountInput6[$pref::LanguageType]; }
    //
$Lang_AccountInput7[0]="��½";
$Lang_AccountInput7[1]="Log in";
function Language_AccountInput7() { return $Lang_AccountInput7[$pref::LanguageType]; }
    //
$Lang_AccountInput8[0]="�˺�:";
$Lang_AccountInput8[1]="Account:";
function Language_AccountInput8() { return $Lang_AccountInput8[$pref::LanguageType]; }
    //
$Lang_AccountInput9[0]="����:";
$Lang_AccountInput9[1]="Password:";
function Language_AccountInput9() { return $Lang_AccountInput9[$pref::LanguageType]; }
    //
$Lang_AccountInput10[0]="������������";
$Lang_AccountInput10[1]="Local area network server";
function Language_AccountInput10() { return $Lang_AccountInput10[$pref::LanguageType]; }
    //
$Lang_AccountInput11[0]="������������";
$Lang_AccountInput11[1]="WAN";
function Language_AccountInput11() { return $Lang_AccountInput11[$pref::LanguageType]; }
      //
$Lang_AccountInput12[0]="����";
$Lang_AccountInput12[1]="Error";
function Language_AccountInput12() { return $Lang_AccountInput12[$pref::LanguageType]; }

  //
$Lang_ColorPicker1[0]="��ɫ��ȡ";
$Lang_ColorPicker1[1]="Color Pick";
function Language_ColorPicker1() { return $Lang_ColorPicker1[$pref::LanguageType]; }
    //
$Lang_ColorPicker2[0]="����";
$Lang_ColorPicker2[1]="Abandon";
function Language_ColorPicker2() { return $Lang_ColorPicker2[$pref::LanguageType]; }
    //
$Lang_ColorPicker3[0]="ȷ��";
$Lang_ColorPicker3[1]="Confirm";
function Language_ColorPicker3() { return $Lang_ColorPicker3[$pref::LanguageType]; }
    //
$Lang_ColorPicker4[0]="ȡ��";
$Lang_ColorPicker4[1]="Cancel";
function Language_ColorPicker4() { return $Lang_ColorPicker4[$pref::LanguageType]; }
    //
$Lang_OpenFileDlg5[0]="���ļ�...";
$Lang_OpenFileDlg5[1]="Open the file...";
function Language_OpenFileDlg5() { return $Lang_OpenFileDlg5[$pref::LanguageType]; }
    //
$Lang_OpenFileDlg6[0]="�ļ�����";
$Lang_OpenFileDlg6[1]="File Type";
function Language_OpenFileDlg6() { return $Lang_OpenFileDlg6[$pref::LanguageType]; }
    //
$Lang_OpenFileDlg7[0]="��";
$Lang_OpenFileDlg7[1]="Open";
function Language_OpenFileDlg7() { return $Lang_OpenFileDlg7[$pref::LanguageType]; }
    //
$Lang_OpenFileDlg8[0]="ȡ��";
$Lang_OpenFileDlg8[1]="Cancel";
function Language_OpenFileDlg8() { return $Lang_OpenFileDlg8[$pref::LanguageType]; }

  //
$Lang_SaveChangeDlg1[0]="�������";
$Lang_SaveChangeDlg1[1]="Save Changes";
function Language_SaveChangeDlg1() { return $Lang_SaveChangeDlg1[$pref::LanguageType]; }
    //
$Lang_SaveChangeDlg2[0]="����";
$Lang_SaveChangeDlg2[1]="Save";
function Language_SaveChangeDlg2() { return $Lang_SaveChangeDlg2[$pref::LanguageType]; }
    //
$Lang_SaveChangeDlg3[0]="ȡ��";
$Lang_SaveChangeDlg3[1]="Cancel";
function Language_SaveChangeDlg3() { return $Lang_SaveChangeDlg3[$pref::LanguageType]; }
    //
$Lang_SaveChangeDlg4[0]="������";
$Lang_SaveChangeDlg4[1]="Not Save";
function Language_SaveChangeDlg4() { return $Lang_SaveChangeDlg4[$pref::LanguageType]; }
    //
$Lang_SaveChangeDlg5[0]="�Ƿ񱣴���������?";
$Lang_SaveChangeDlg5[1]="Save the changes?";
function Language_SaveChangeDlg5() { return $Lang_SaveChangeDlg5[$pref::LanguageType]; }
    //
$Lang_SaveChangeDlg6[0]="��������棬�㽫��ʧ���и���.";
$Lang_SaveChangeDlg6[1]="If not save,changes loss.";
function Language_SaveChangeDlg6() { return $Lang_SaveChangeDlg6[$pref::LanguageType]; }

  //
$Lang_saveFileDlg1[0]="�����ļ�...";
$Lang_saveFileDlg1[1]="Save File...";
function Language_saveFileDlg1() { return $Lang_saveFileDlg1[$pref::LanguageType]; }
    //
$Lang_saveFileDlg2[0]="�ļ�����";
$Lang_saveFileDlg2[1]="File Type";
function Language_saveFileDlg2() { return $Lang_saveFileDlg2[$pref::LanguageType]; }
    //
$Lang_saveFileDlg3[0]="�ļ�����";
$Lang_saveFileDlg3[1]="File Name";
function Language_saveFileDlg3() { return $Lang_saveFileDlg3[$pref::LanguageType]; }
    //
$Lang_saveFileDlg4[0]="�����ļ�";
$Lang_saveFileDlg4[1]="Save File";
function Language_saveFileDlg4() { return $Lang_saveFileDlg4[$pref::LanguageType]; }
    //
$Lang_saveFileDlg5[0]="ȡ��";
$Lang_saveFileDlg5[1]="Cancel";
function Language_saveFileDlg5() { return $Lang_saveFileDlg5[$pref::LanguageType]; }

  //
$Lang_simViewDlg1[0]="Ԥ��";
$Lang_simViewDlg1[1]="Preview";
function Language_simViewDlg1() { return $Lang_simViewDlg1[$pref::LanguageType]; }
    //
$Lang_simViewDlg2[0]="����ID:";
$Lang_simViewDlg2[1]="Sprite ID:";
function Language_simViewDlg2() { return $Lang_simViewDlg2[$pref::LanguageType]; }
    //
$Lang_simViewDlg3[0]="�ڲ�����:";
$Lang_simViewDlg3[1]="Inside Name:";
function Language_simViewDlg3() { return $Lang_simViewDlg3[$pref::LanguageType]; }
    //
$Lang_simViewDlg4[0]="ѡ����:";
$Lang_simViewDlg4[1]="Choose Sprite:";
function Language_simViewDlg4() { return $Lang_simViewDlg4[$pref::LanguageType]; }
    //
$Lang_simViewDlg5[0]="ˢ��";
$Lang_simViewDlg5[1]="Refresh";
function Language_simViewDlg5() { return $Lang_simViewDlg5[$pref::LanguageType]; }
    //
$Lang_simViewDlg6[0]="ɾ��";
$Lang_simViewDlg6[1]="Delete";
function Language_simViewDlg6() { return $Lang_simViewDlg6[$pref::LanguageType]; }

  //
$Lang_guiEditor1[0]="��/�ر����";
$Lang_guiEditor1[1]="Open/Close Panel";
function Language_guiEditor1() { return $Lang_guiEditor1[$pref::LanguageType]; }
    //
$Lang_guiEditor2[0]="���뵽����";
$Lang_guiEditor2[1]="Snap To Grid";
function Language_guiEditor2() { return $Lang_guiEditor2[$pref::LanguageType]; }
    //
$Lang_guiEditor3[0]="����:";
$Lang_guiEditor3[1]="Name:";
function Language_guiEditor3() { return $Lang_guiEditor3[$pref::LanguageType]; }
    //
$Lang_guiEditor4[0]="Ӧ��";
$Lang_guiEditor4[1]="Apply";
function Language_guiEditor4() { return $Lang_guiEditor4[$pref::LanguageType]; }

  //
$Lang_guiEditorPalette1[0]="�������";
$Lang_guiEditorPalette1[1]="Control Panel";
function Language_guiEditorPalette1() { return $Lang_guiEditorPalette1[$pref::LanguageType]; }
    //
$Lang_guiEditorPalette2[0]="��ͨ";
$Lang_guiEditorPalette2[1]="Common";
function Language_guiEditorPalette2() { return $Lang_guiEditorPalette2[$pref::LanguageType]; }
    //
$Lang_guiEditorPalette3[0]="����";
$Lang_guiEditorPalette3[1]="All";
function Language_guiEditorPalette3() { return $Lang_guiEditorPalette3[$pref::LanguageType]; }

//
$Lang_guiEditorPrefsDlg1[0]="����༭������";
$Lang_guiEditorPrefsDlg1[1]="Interface Builder set";
function Language_guiEditorPrefsDlg1() { return $Lang_guiEditorPrefsDlg1[$pref::LanguageType]; }
  //
$Lang_guiEditorPrefsDlg2[0]="ȡ��";
$Lang_guiEditorPrefsDlg2[1]="Cancel";
function Language_guiEditorPrefsDlg2() { return $Lang_guiEditorPrefsDlg2[$pref::LanguageType]; }
  //
$Lang_guiEditorPrefsDlg3[0]="ȷ��";
$Lang_guiEditorPrefsDlg3[1]="Confirm";
function Language_guiEditorPrefsDlg3() { return $Lang_guiEditorPrefsDlg3[$pref::LanguageType]; }
  //
$Lang_guiEditorPrefsDlg4[0]="�ָ�Ĭ��";
$Lang_guiEditorPrefsDlg4[1]="Default Restore";
function Language_guiEditorPrefsDlg4() { return $Lang_guiEditorPrefsDlg4[$pref::LanguageType]; }
  //
$Lang_guiEditorPrefsDlg5[0]="�����С:";
$Lang_guiEditorPrefsDlg5[1]="Grid Size:";
function Language_guiEditorPrefsDlg5() { return $Lang_guiEditorPrefsDlg5[$pref::LanguageType]; }

  //
$Lang_NewGuiDialog1[0]="�½�����";
$Lang_NewGuiDialog1[1]="New Create Interface";
function Language_NewGuiDialog1() { return $Lang_NewGuiDialog1[$pref::LanguageType]; }
    //
$Lang_NewGuiDialog2[0]="ȡ��";
$Lang_NewGuiDialog2[1]="Cancel";
function Language_NewGuiDialog2() { return $Lang_NewGuiDialog2[$pref::LanguageType]; }
    //
$Lang_NewGuiDialog3[0]="����";
$Lang_NewGuiDialog3[1]="Create";
function Language_NewGuiDialog3() { return $Lang_NewGuiDialog3[$pref::LanguageType]; }
    //
$Lang_NewGuiDialog4[0]="��������";
$Lang_NewGuiDialog4[1]="Interface Name";
function Language_NewGuiDialog4() { return $Lang_NewGuiDialog4[$pref::LanguageType]; }
    //
$Lang_NewGuiDialog5[0]="��������(Class)";
$Lang_NewGuiDialog5[1]="Interface Class Name";
function Language_NewGuiDialog5() { return $Lang_NewGuiDialog5[$pref::LanguageType]; }

  //
$Lang_FunCodeImage1[0]="ͼƬ��Դ";
$Lang_FunCodeImage1[1]="Image Resource";
function Language_FunCodeImage1() { return $Lang_FunCodeImage1[$pref::LanguageType]; }
    //
$Lang_FunCodeImage2[0]="��Դ";
$Lang_FunCodeImage2[1]="Resource";
function Language_FunCodeImage2() { return $Lang_FunCodeImage2[$pref::LanguageType]; }
    //
$Lang_FunCodeImage3[0]="Ԥ��";
$Lang_FunCodeImage3[1]="Preview";
function Language_FunCodeImage3() { return $Lang_FunCodeImage3[$pref::LanguageType]; }
    //
$Lang_FunCodeImage4[0]="��ӵ�����";
$Lang_FunCodeImage4[1]="Add to the project";
function Language_FunCodeImage4() { return $Lang_FunCodeImage4[$pref::LanguageType]; }
    //
$Lang_FunCodeImage5[0]="�رմ���ʱ�ͷ�ͼƬ��Դ(���õ����û���)";
$Lang_FunCodeImage5[1]="Image resources released when closing window (For the low-configure)";
function Language_FunCodeImage5() { return $Lang_FunCodeImage5[$pref::LanguageType]; }

  //
$Lang_FunCodeMusic1[0]="������Դ";
$Lang_FunCodeMusic1[1]="Music Resources";
function Language_FunCodeMusic1() { return $Lang_FunCodeMusic1[$pref::LanguageType]; }
    //
$Lang_FunCodeMusic2[0]="��Դ";
$Lang_FunCodeMusic2[1]="Resources";
function Language_FunCodeMusic2() { return $Lang_FunCodeMusic2[$pref::LanguageType]; }
    //
$Lang_FunCodeMusic3[0]="��ǰ������Դ";
$Lang_FunCodeMusic3[1]="Current project resource";
function Language_FunCodeMusic3() { return $Lang_FunCodeMusic3[$pref::LanguageType]; }
    //
$Lang_FunCodeMusic4[0]="��ӵ�����";
$Lang_FunCodeMusic4[1]="Add to the project";
function Language_FunCodeMusic4() { return $Lang_FunCodeMusic4[$pref::LanguageType]; }
    //
$Lang_FunCodeMusic5[0]="��������";
$Lang_FunCodeMusic5[1]="Import Music";
function Language_FunCodeMusic5() { return $Lang_FunCodeMusic5[$pref::LanguageType]; }
    //
$Lang_FunCodeMusic6[0]="����";
$Lang_FunCodeMusic6[1]="Play";
function Language_FunCodeMusic6() { return $Lang_FunCodeMusic6[$pref::LanguageType]; }
    //
$Lang_FunCodeMusic7[0]="ֹͣ   ";
$Lang_FunCodeMusic7[1]="Stop   ";
function Language_FunCodeMusic7() { return $Lang_FunCodeMusic7[$pref::LanguageType]; }
    //
$Lang_FunCodeMusic8[0]="�ӹ�����ɾ��";
$Lang_FunCodeMusic8[1]="Delete from the project";
function Language_FunCodeMusic8() { return $Lang_FunCodeMusic8[$pref::LanguageType]; }

  //
$Lang_ImageBuilderGui1[0]="ͼƬ�༭��";
$Lang_ImageBuilderGui1[1]="Image Editor";
function Language_ImageBuilderGui1() { return $Lang_ImageBuilderGui1[$pref::LanguageType]; }
    //
$Lang_ImageBuilderGui2[0]="ȡ��";
$Lang_ImageBuilderGui2[1]="Cancel";
function Language_ImageBuilderGui2() { return $Lang_ImageBuilderGui2[$pref::LanguageType]; }
    //
$Lang_ImageBuilderGui3[0]="ͼƬ����";
$Lang_ImageBuilderGui3[1]="Image Setting";
function Language_ImageBuilderGui3() { return $Lang_ImageBuilderGui3[$pref::LanguageType]; }
    //
$Lang_ImageBuilderGui4[0]="���棺�������Ѿ���ʹ�ã�������";
$Lang_ImageBuilderGui4[1]="Warning: name has been used,choose another";
function Language_ImageBuilderGui4() { return $Lang_ImageBuilderGui4[$pref::LanguageType]; }
    //
$Lang_ImageBuilderGui5[0]="ͼƬ��:";
$Lang_ImageBuilderGui5[1]="Image Name:";
function Language_ImageBuilderGui5() { return $Lang_ImageBuilderGui5[$pref::LanguageType]; }
    //
$Lang_ImageBuilderGui6[0]="ͼƬģʽ:";
$Lang_ImageBuilderGui6[1]="Image Mode:";
function Language_ImageBuilderGui6() { return $Lang_ImageBuilderGui6[$pref::LanguageType]; }
    //
$Lang_ImageBuilderGui7[0]="����ģʽ:";
$Lang_ImageBuilderGui7[1]="Filter Mode:";
function Language_ImageBuilderGui7() { return $Lang_ImageBuilderGui7[$pref::LanguageType]; }
    //
$Lang_ImageBuilderGui8[0]="ͼƬ��С:";
$Lang_ImageBuilderGui8[1]="Image Size:";
function Language_ImageBuilderGui8() { return $Lang_ImageBuilderGui8[$pref::LanguageType]; }
    //
$Lang_ImageBuilderGui9[0]="ѡ��һ����������";
$Lang_ImageBuilderGui9[1]="Choose a zoom area";
function Language_ImageBuilderGui9() { return $Lang_ImageBuilderGui9[$pref::LanguageType]; }
    //
$Lang_ImageBuilderGui10[0]="����";
$Lang_ImageBuilderGui10[1]="Zoom";
function Language_ImageBuilderGui10() { return $Lang_ImageBuilderGui10[$pref::LanguageType]; }
    //
$Lang_ImageBuilderGui11[0]="�Ŵ�";
$Lang_ImageBuilderGui11[1]="Zoom In";
function Language_ImageBuilderGui11() { return $Lang_ImageBuilderGui11[$pref::LanguageType]; }
    //
$Lang_ImageBuilderGui12[0]="�Ŵ�";
$Lang_ImageBuilderGui12[1]="Zoom In";
function Language_ImageBuilderGui12() { return $Lang_ImageBuilderGui12[$pref::LanguageType]; }
    //
$Lang_ImageBuilderGui13[0]="���ı������߱߿�ɫ";
$Lang_ImageBuilderGui13[1]="Change the background or border color";
function Language_ImageBuilderGui13() { return $Lang_ImageBuilderGui13[$pref::LanguageType]; }
    //
$Lang_ImageBuilderGui14[0]="����";
$Lang_ImageBuilderGui14[1]="Background";
function Language_ImageBuilderGui14() { return $Lang_ImageBuilderGui14[$pref::LanguageType]; }
    //
$Lang_ImageBuilderGui15[0]="����:";
$Lang_ImageBuilderGui15[1]="Coordinate:";
function Language_ImageBuilderGui15() { return $Lang_ImageBuilderGui15[$pref::LanguageType]; }
    //
$Lang_ImageBuilderGui16[0]="ѡ����������";
$Lang_ImageBuilderGui16[1]="Select the zoom area";
function Language_ImageBuilderGui16() { return $Lang_ImageBuilderGui16[$pref::LanguageType]; }
    //
$Lang_ImageBuilderGui17[0]="������ѡ��";
$Lang_ImageBuilderGui17[1]="Zoom area select";
function Language_ImageBuilderGui17() { return $Lang_ImageBuilderGui17[$pref::LanguageType]; }
    //
$Lang_ImageBuilderGui18[0]="<just:center>����<br> ������Ҫ<br>2 ��ͼƬ��������";
$Lang_ImageBuilderGui18[1]="<just:center>Warning<br> need at least<br> 2 images to connect";
function Language_ImageBuilderGui18() { return $Lang_ImageBuilderGui18[$pref::LanguageType]; }
    //
$Lang_ImageBuilderGui19[0]="��ǰ�����б�";
$Lang_ImageBuilderGui19[1]="Connect to the list at present";
function Language_ImageBuilderGui19() { return $Lang_ImageBuilderGui19[$pref::LanguageType]; }
    //
$Lang_ImageBuilderGui20[0]="���һ��ͼƬ��������Դ";
$Lang_ImageBuilderGui20[1]="Add an image to the connecion resource";
function Language_ImageBuilderGui20() { return $Lang_ImageBuilderGui20[$pref::LanguageType]; }
    //
$Lang_ImageBuilderGui21[0]="ͼƬ";
$Lang_ImageBuilderGui21[1]="Image";
function Language_ImageBuilderGui21() { return $Lang_ImageBuilderGui21[$pref::LanguageType]; }
    //
$Lang_ImageBuilderGui22[0]="ɾ��ѡ��";
$Lang_ImageBuilderGui22[1]="Delete the selected";
function Language_ImageBuilderGui22() { return $Lang_ImageBuilderGui22[$pref::LanguageType]; }
    //
$Lang_ImageBuilderGui23[0]="��Ԫ(Cell)ģʽѡ��";
$Lang_ImageBuilderGui23[1]="Cell mode select";
function Language_ImageBuilderGui23() { return $Lang_ImageBuilderGui23[$pref::LanguageType]; }
    //
$Lang_ImageBuilderGui24[0]="��Ԫƫ��X:";
$Lang_ImageBuilderGui24[1]="Unit offset X:";
function Language_ImageBuilderGui24() { return $Lang_ImageBuilderGui24[$pref::LanguageType]; }
    //
$Lang_ImageBuilderGui25[0]="��Ԫƫ��Y:";
$Lang_ImageBuilderGui25[1]="Unit offset Y:";
function Language_ImageBuilderGui25() { return $Lang_ImageBuilderGui25[$pref::LanguageType]; }
    //
$Lang_ImageBuilderGui26[0]="��Ԫ����Y:";
$Lang_ImageBuilderGui26[1]="Unit stepping Y:";
function Language_ImageBuilderGui26() { return $Lang_ImageBuilderGui26[$pref::LanguageType]; }
    //
$Lang_ImageBuilderGui27[0]="��Ԫ����X:";
$Lang_ImageBuilderGui27[1]="Unit stepping X:";
function Language_ImageBuilderGui27() { return $Lang_ImageBuilderGui27[$pref::LanguageType]; }
    //
$Lang_ImageBuilderGui28[0]="��Ԫ�����и�";
$Lang_ImageBuilderGui28[1]="Unit cut in line";
function Language_ImageBuilderGui28() { return $Lang_ImageBuilderGui28[$pref::LanguageType]; }
    //
$Lang_ImageBuilderGui29[0]="��Ԫ����Y:";
$Lang_ImageBuilderGui29[1]="Unit count Y:";
function Language_ImageBuilderGui29() { return $Lang_ImageBuilderGui29[$pref::LanguageType]; }
    //
$Lang_ImageBuilderGui30[0]="��Ԫ��:";
$Lang_ImageBuilderGui30[1]="Unit height:";
function Language_ImageBuilderGui30() { return $Lang_ImageBuilderGui30[$pref::LanguageType]; }
    //
$Lang_ImageBuilderGui31[0]="��Ԫ��:";
$Lang_ImageBuilderGui31[1]="Unit width:";
function Language_ImageBuilderGui31() { return $Lang_ImageBuilderGui31[$pref::LanguageType]; }
    //
$Lang_ImageBuilderGui32[0]="��Ԫ����X:";
$Lang_ImageBuilderGui32[1]="Unit count X";
function Language_ImageBuilderGui32() { return $Lang_ImageBuilderGui32[$pref::LanguageType]; }
    //
$Lang_ImageBuilderGui33[0]="�߼�����";
$Lang_ImageBuilderGui33[1]="Advanced settings";
function Language_ImageBuilderGui33() { return $Lang_ImageBuilderGui33[$pref::LanguageType]; }
    //
$Lang_ImageBuilderGui34[0]="���һ��ͼƬ";
$Lang_ImageBuilderGui34[1]="Browse an image";
function Language_ImageBuilderGui34() { return $Lang_ImageBuilderGui34[$pref::LanguageType]; }
    //
$Lang_ImageBuilderGui35[0]="���";
$Lang_ImageBuilderGui35[1]="Browse";
function Language_ImageBuilderGui35() { return $Lang_ImageBuilderGui35[$pref::LanguageType]; }
    //
$Lang_ImageBuilderGui36[0]="����ͼƬ����Ĺ�����ɾ����";
$Lang_ImageBuilderGui36[1]="Delete the image from your project";
function Language_ImageBuilderGui36() { return $Lang_ImageBuilderGui36[$pref::LanguageType]; }
    //
$Lang_ImageBuilderGui37[0]="ɾ��";
$Lang_ImageBuilderGui37[1]="Delete";
function Language_ImageBuilderGui37() { return $Lang_ImageBuilderGui37[$pref::LanguageType]; }
    //
$Lang_ImageBuilderGui38[0]="����";
$Lang_ImageBuilderGui38[1]="Save";
function Language_ImageBuilderGui38() { return $Lang_ImageBuilderGui38[$pref::LanguageType]; }
    //
$Lang_ImageBuilderGui39[0]="ͼƬ�༭��Ԥ����ɫ����";
$Lang_ImageBuilderGui39[1]="Image editor color preview set";
function Language_ImageBuilderGui39() { return $Lang_ImageBuilderGui39[$pref::LanguageType]; }
    //
$Lang_ImageBuilderGui40[0]="������ɫ";
$Lang_ImageBuilderGui40[1]="Background color";
function Language_ImageBuilderGui40() { return $Lang_ImageBuilderGui40[$pref::LanguageType]; }
    //
$Lang_ImageBuilderGui41[0]="ͼƬԤ��������ɫ";
$Lang_ImageBuilderGui41[1]="Image preview background color";
function Language_ImageBuilderGui41() { return $Lang_ImageBuilderGui41[$pref::LanguageType]; }
    //
$Lang_ImageBuilderGui42[0]="������ɫ";
$Lang_ImageBuilderGui42[1]="Basic Color";
function Language_ImageBuilderGui42() { return $Lang_ImageBuilderGui42[$pref::LanguageType]; }
    //
$Lang_ImageBuilderGui43[0]="��ɫ��ȡ";
$Lang_ImageBuilderGui43[1]="Color Pick";
function Language_ImageBuilderGui43() { return $Lang_ImageBuilderGui43[$pref::LanguageType]; }
    //
$Lang_ImageBuilderGui44[0]="����ѡ��";
$Lang_ImageBuilderGui44[1]="More Choices";
function Language_ImageBuilderGui44() { return $Lang_ImageBuilderGui44[$pref::LanguageType]; }
    //
$Lang_ImageBuilderGui45[0]="�ر�";
$Lang_ImageBuilderGui45[1]="Close";
function Language_ImageBuilderGui45() { return $Lang_ImageBuilderGui45[$pref::LanguageType]; }
    //
$Lang_ImageBuilderGui46[0]="����߿���ɫ";
$Lang_ImageBuilderGui46[1]="Sprite border color";
function Language_ImageBuilderGui46() { return $Lang_ImageBuilderGui46[$pref::LanguageType]; }
    //
$Lang_ImageBuilderGui47[0]="ͼƬԤ���߿���ɫ";
$Lang_ImageBuilderGui47[1]="Image preview border color";
function Language_ImageBuilderGui47() { return $Lang_ImageBuilderGui47[$pref::LanguageType]; }
    //
$Lang_ImageBuilderGui48[0]="������ɫ";
$Lang_ImageBuilderGui48[1]="Basic Color";
function Language_ImageBuilderGui48() { return $Lang_ImageBuilderGui48[$pref::LanguageType]; }
    //
$Lang_ImageBuilderGui49[0]="��ɫ��ȡ";
$Lang_ImageBuilderGui49[1]="Color Pick";
function Language_ImageBuilderGui49() { return $Lang_ImageBuilderGui49[$pref::LanguageType]; }
    //
$Lang_ImageBuilderGui50[0]="����ѡ��";
$Lang_ImageBuilderGui50[1]="More Choices";
function Language_ImageBuilderGui50() { return $Lang_ImageBuilderGui50[$pref::LanguageType]; }
    //
$Lang_ImageBuilderGui51[0]="�ر�";
$Lang_ImageBuilderGui51[1]="Close";
function Language_ImageBuilderGui51() { return $Lang_ImageBuilderGui51[$pref::LanguageType]; }

//
$Lang_OpenFileDlgExwPreview0[0]="ѡ��ͼƬ�ļ�...";
$Lang_OpenFileDlgExwPreview0[1]="Select image file...";
function Language_OpenFileDlgExwPreview0() { return $Lang_OpenFileDlgExwPreview0[$pref::LanguageType]; }
//
$Lang_OpenFileDlgExwPreview1[0]="��ǰ·��";
$Lang_OpenFileDlgExwPreview1[1]="Current path";
function Language_OpenFileDlgExwPreview1() { return $Lang_OpenFileDlgExwPreview1[$pref::LanguageType]; }
  //
$Lang_OpenFileDlgExwPreview2[0]="ͼƬ��С:";
$Lang_OpenFileDlgExwPreview2[1]="Image Size:";
function Language_OpenFileDlgExwPreview2() { return $Lang_OpenFileDlgExwPreview2[$pref::LanguageType]; }
  //
$Lang_OpenFileDlgExwPreview3[0]="ͼƬ·��";
$Lang_OpenFileDlgExwPreview3[1]="Image Path";
function Language_OpenFileDlgExwPreview3() { return $Lang_OpenFileDlgExwPreview3[$pref::LanguageType]; }
  //
$Lang_OpenFileDlgExwPreview4[0]="ѡ��";
$Lang_OpenFileDlgExwPreview4[1]="Select";
function Language_OpenFileDlgExwPreview4() { return $Lang_OpenFileDlgExwPreview4[$pref::LanguageType]; }
  //
$Lang_OpenFileDlgExwPreview5[0]="ȡ��";
$Lang_OpenFileDlgExwPreview5[1]="Cancel";
function Language_OpenFileDlgExwPreview5() { return $Lang_OpenFileDlgExwPreview5[$pref::LanguageType]; }

//
$Lang_applicationClose0[0]="�Ƿ񱣴���ĵ������ĸ���";
$Lang_applicationClose0[1]="Save the changes of the document or not";
function Language_applicationClose0() { return $Lang_applicationClose0[$pref::LanguageType]; }

//
$Lang_t2dProjectPersistence0[0]="����Java����";
$Lang_t2dProjectPersistence0[1]="Start Java project";
function Language_t2dProjectPersistence0() { return $Lang_t2dProjectPersistence0[$pref::LanguageType]; }
  //
$Lang_t2dProjectPersistence1[0]="����VC����";
$Lang_t2dProjectPersistence1[1]="Start VC project";
function Language_t2dProjectPersistence1() { return $Lang_t2dProjectPersistence1[$pref::LanguageType]; }
  //
$Lang_t2dProjectPersistence2[0]="��������VC����";
$Lang_t2dProjectPersistence2[1]="Set start VC project";
function Language_t2dProjectPersistence2() { return $Lang_t2dProjectPersistence2[$pref::LanguageType]; }
  //
$Lang_t2dProjectPersistence3[0]="����VC����";
$Lang_t2dProjectPersistence3[1]="Create VC project";
function Language_t2dProjectPersistence3() { return $Lang_t2dProjectPersistence3[$pref::LanguageType]; }
  //
$Lang_t2dProjectPersistence4[0]="����C#����";
$Lang_t2dProjectPersistence4[1]="Start C# project";
function Language_t2dProjectPersistence4() { return $Lang_t2dProjectPersistence4[$pref::LanguageType]; }
  //
$Lang_t2dProjectPersistence5[0]="��������C#����";
$Lang_t2dProjectPersistence5[1]="Set start C# project";
function Language_t2dProjectPersistence5() { return $Lang_t2dProjectPersistence5[$pref::LanguageType]; }
  //
$Lang_t2dProjectPersistence6[0]="����VB����";
$Lang_t2dProjectPersistence6[1]="Start VB project";
function Language_t2dProjectPersistence6() { return $Lang_t2dProjectPersistence6[$pref::LanguageType]; }
  //
$Lang_t2dProjectPersistence7[0]="��������VB����";
$Lang_t2dProjectPersistence7[1]="Set start VB project";
function Language_t2dProjectPersistence7() { return $Lang_t2dProjectPersistence7[$pref::LanguageType]; }
//
$Lang_t2dProjectPersistence8[0]="����Python����";
$Lang_t2dProjectPersistence8[1]="Start Python project";
function Language_t2dProjectPersistence8() { return $Lang_t2dProjectPersistence8[$pref::LanguageType]; }
  //
$Lang_t2dProjectPersistence9[0]="��������Python����";
$Lang_t2dProjectPersistence9[1]="Set start Python project";
function Language_t2dProjectPersistence9() { return $Lang_t2dProjectPersistence9[$pref::LanguageType]; }

//
$Lang_layouts_Default0[0]="��ͼ����";
$Lang_layouts_Default0[1]="Scene window";
function Language_layouts_Default0() { return $Lang_layouts_Default0[$pref::LanguageType]; }

//
$Lang_CreateOtherProjectGUI0[0]="����VC����";
$Lang_CreateOtherProjectGUI0[1]="Create VC project";
function Language_CreateOtherProjectGUI0() { return $Lang_CreateOtherProjectGUI0[$pref::LanguageType]; }
//
$Lang_CreateOtherProjectGUI1[0]="���������汾Java����";
$Lang_CreateOtherProjectGUI1[1]="Create other Java project";
function Language_CreateOtherProjectGUI1() { return $Lang_CreateOtherProjectGUI1[$pref::LanguageType]; }
//
$Lang_CreateOtherProjectGUI2[0]="����VC����";
$Lang_CreateOtherProjectGUI2[1]="Create VC project";
function Language_CreateOtherProjectGUI2() { return $Lang_CreateOtherProjectGUI2[$pref::LanguageType]; }

//
$Lang_CreateProjectGUI0[0]="������(��ĸ������):";
$Lang_CreateProjectGUI0[1]="Project name(letter and number):";
function Language_CreateProjectGUI0() { return $Lang_CreateProjectGUI0[$pref::LanguageType]; }
  //
$Lang_CreateProjectGUI1[0]="����·��:";
$Lang_CreateProjectGUI1[1]="Project path:";
function Language_CreateProjectGUI1() { return $Lang_CreateProjectGUI1[$pref::LanguageType]; }
  //
$Lang_CreateProjectGUI2[0]="ȷ��";
$Lang_CreateProjectGUI2[1]="Confirm";
function Language_CreateProjectGUI2() { return $Lang_CreateProjectGUI2[$pref::LanguageType]; }
  //
$Lang_CreateProjectGUI3[0]="ȡ��";
$Lang_CreateProjectGUI3[1]="Cancel";
function Language_CreateProjectGUI3() { return $Lang_CreateProjectGUI3[$pref::LanguageType]; }
  //
$Lang_CreateProjectGUI4[0]="��������:";
$Lang_CreateProjectGUI4[1]="Development Tool:";
function Language_CreateProjectGUI4() { return $Lang_CreateProjectGUI4[$pref::LanguageType]; }
  //
$Lang_CreateProjectGUI5[0]="���̼ܹ�:";
$Lang_CreateProjectGUI5[1]="Project Framework:";
function Language_CreateProjectGUI5() { return $Lang_CreateProjectGUI5[$pref::LanguageType]; }
  //
$Lang_CreateProjectGUI6[0]="���ļ�";
$Lang_CreateProjectGUI6[1]="Multi File";
function Language_CreateProjectGUI6() { return $Lang_CreateProjectGUI6[$pref::LanguageType]; }
  //
$Lang_CreateProjectGUI7[0]="���ļ�";
$Lang_CreateProjectGUI7[1]="Single File";
function Language_CreateProjectGUI7() { return $Lang_CreateProjectGUI7[$pref::LanguageType]; }

//
$Lang_LBPlayLevel0[0]="�㼶����";
$Lang_LBPlayLevel0[1]="Layer Control";
function Language_LBPlayLevel0() { return $Lang_LBPlayLevel0[$pref::LanguageType]; }

//
$Lang_options0[0]="��ͼ�༭��";
$Lang_options0[1]="Scene Editior";
function Language_options0() { return $Lang_options0[$pref::LanguageType]; }
  //
$Lang_options1[0]="�ٽ�ֵ:";
$Lang_options1[1]="Threshold:";
function Language_options1() { return $Lang_options1[$pref::LanguageType]; }
  //
$Lang_options2[0]="��������";
$Lang_options2[1]="Grid Set";
function Language_options2() { return $Lang_options2[$pref::LanguageType]; }
  //
$Lang_options3[0]="���ģʽ��С:";
$Lang_options3[1]="Design Pattern Size:";
function Language_options3() { return $Lang_options3[$pref::LanguageType]; }
  //
$Lang_options4[0]="������ɫ:";
$Lang_options4[1]="Grid Color:";
function Language_options4() { return $Lang_options4[$pref::LanguageType]; }
  //
$Lang_options5[0]="��ʾ����";
$Lang_options5[1]="Show Grid";
function Language_options5() { return $Lang_options5[$pref::LanguageType]; }
  //
$Lang_options6[0]="�����С Y:";
$Lang_options6[1]="Grid size Y:";
function Language_options6() { return $Lang_options6[$pref::LanguageType]; }
  //
$Lang_options7[0]="�����С X:";
$Lang_options7[1]="Grid size X:";
function Language_options7() { return $Lang_options7[$pref::LanguageType]; }
  //
$Lang_options8[0]="�༭������:";
$Lang_options8[1]="Editor Background:";
function Language_options8() { return $Lang_options8[$pref::LanguageType]; }
  //
$Lang_options9[0]="���뵽X��";
$Lang_options9[1]="Align to X Axis";
function Language_options9() { return $Lang_options9[$pref::LanguageType]; }
  //
$Lang_options10[0]="���뵽Y��";
$Lang_options10[1]="Align to Y Axis";
function Language_options10() { return $Lang_options10[$pref::LanguageType]; }
  //
$Lang_options11[0]="��ʾ�ű�����";
$Lang_options11[1]="Show script error";
function Language_options11() { return $Lang_options11[$pref::LanguageType]; }
  //
$Lang_options12[0]="ȷ��";
$Lang_options12[1]="Confirm";
function Language_options12() { return $Lang_options12[$pref::LanguageType]; }
  //
$Lang_options13[0]="ȡ��";
$Lang_options13[1]="Cancel";
function Language_options13() { return $Lang_options13[$pref::LanguageType]; }
  //
$Lang_options14[0]="��������";
$Lang_options14[1]="Tool Setting";
function Language_options14() { return $Lang_options14[$pref::LanguageType]; }
  //
$Lang_options15[0]="ȡ��ѡ��";
$Lang_options15[1]="Cancel the selected";
function Language_options15() { return $Lang_options15[$pref::LanguageType]; }
  //
$Lang_options16[0]="��ʾ��Ļ";
$Lang_options16[1]="Show Screen";
function Language_options16() { return $Lang_options16[$pref::LanguageType]; }
  //
$Lang_options17[0]="��ʾԭ��";
$Lang_options17[1]="Show original point";
function Language_options17() { return $Lang_options17[$pref::LanguageType]; }
  //
$Lang_options18[0]="���鱳��:";
$Lang_options18[1]="Sprite Background:";
function Language_options18() { return $Lang_options18[$pref::LanguageType]; }
  //
$Lang_options19[0]="��";
$Lang_options19[1]="Bright";
function Language_options19() { return $Lang_options19[$pref::LanguageType]; }
  //
$Lang_options20[0]="�ж�";
$Lang_options20[1]="Middle";
function Language_options20() { return $Lang_options20[$pref::LanguageType]; }
  //
$Lang_options21[0]="��";
$Lang_options21[1]="Dark";
function Language_options21() { return $Lang_options21[$pref::LanguageType]; }

//
$Lang_SaveUserTemplateGUI0[0]="����ģ��";
$Lang_SaveUserTemplateGUI0[1]="Save Template";
function Language_SaveUserTemplateGUI0() { return $Lang_SaveUserTemplateGUI0[$pref::LanguageType]; }
//
$Lang_SaveUserTemplateGUI1[0]="ģ����(֧������):";
$Lang_SaveUserTemplateGUI1[1]="Template Name:";
function Language_SaveUserTemplateGUI1() { return $Lang_SaveUserTemplateGUI1[$pref::LanguageType]; }
//
$Lang_SaveUserTemplateGUI2[0]="ȷ��";
$Lang_SaveUserTemplateGUI2[1]="Confirm";
function Language_SaveUserTemplateGUI2() { return $Lang_SaveUserTemplateGUI2[$pref::LanguageType]; }
//
$Lang_SaveUserTemplateGUI3[0]="ȡ��";
$Lang_SaveUserTemplateGUI3[1]="Cancel";
function Language_SaveUserTemplateGUI3() { return $Lang_SaveUserTemplateGUI3[$pref::LanguageType]; }

//
$Lang_SelectProjectCreateGui0[0]="ȷ��";
$Lang_SelectProjectCreateGui0[1]="Confirm";
function Language_SelectProjectCreateGui0() { return $Lang_SelectProjectCreateGui0[$pref::LanguageType]; }
  //
$Lang_SelectProjectCreateGui1[0]="ȡ��";
$Lang_SelectProjectCreateGui1[1]="Cancel";
function Language_SelectProjectCreateGui1() { return $Lang_SelectProjectCreateGui1[$pref::LanguageType]; }
  //
$Lang_SelectProjectCreateGui2[0]="C���Թ���";
$Lang_SelectProjectCreateGui2[1]="C Language Project";
function Language_SelectProjectCreateGui2() { return $Lang_SelectProjectCreateGui2[$pref::LanguageType]; }
  //
$Lang_SelectProjectCreateGui3[0]="C++����";
$Lang_SelectProjectCreateGui3[1]="C++ Project";
function Language_SelectProjectCreateGui3() { return $Lang_SelectProjectCreateGui3[$pref::LanguageType]; }
  //
$Lang_SelectProjectCreateGui4[0]="Java����";
$Lang_SelectProjectCreateGui4[1]="Jave Project";
function Language_SelectProjectCreateGui4() { return $Lang_SelectProjectCreateGui4[$pref::LanguageType]; }
  //
$Lang_SelectProjectCreateGui5[0]="C#����";
$Lang_SelectProjectCreateGui5[1]="C# Project";
function Language_SelectProjectCreateGui5() { return $Lang_SelectProjectCreateGui5[$pref::LanguageType]; }
  //
$Lang_SelectProjectCreateGui6[0]="VB����";
$Lang_SelectProjectCreateGui6[1]="VB Project";
function Language_SelectProjectCreateGui6() { return $Lang_SelectProjectCreateGui6[$pref::LanguageType]; }
  //
$Lang_SelectProjectCreateGui7[0]="Python����";
$Lang_SelectProjectCreateGui7[1]="Python Project";
function Language_SelectProjectCreateGui7() { return $Lang_SelectProjectCreateGui7[$pref::LanguageType]; }

//
$Lang_SelectUserTemplateGUI0[0]="����ģ��";
$Lang_SelectUserTemplateGUI0[1]="Import Template";
function Language_SelectUserTemplateGUI0() { return $Lang_SelectUserTemplateGUI0[$pref::LanguageType]; }
  //
$Lang_SelectUserTemplateGUI1[0]="���뵽����";
$Lang_SelectUserTemplateGUI1[1]="Import Into Project";
function Language_SelectUserTemplateGUI1() { return $Lang_SelectUserTemplateGUI1[$pref::LanguageType]; }
  //
$Lang_SelectUserTemplateGUI2[0]="ɾ��ģ��";
$Lang_SelectUserTemplateGUI2[1]="Cancel Template";
function Language_SelectUserTemplateGUI2() { return $Lang_SelectUserTemplateGUI2[$pref::LanguageType]; }

//
$Lang_SetEclipsePathGUI0[0]="����Eclipse.exeλ��";
$Lang_SetEclipsePathGUI0[1]="Set Eclipse.exe location";
function Language_SetEclipsePathGUI0() { return $Lang_SetEclipsePathGUI0[$pref::LanguageType]; }
  //
$Lang_SetEclipsePathGUI1[0]="ѡ��Eclipse.exe:";
$Lang_SetEclipsePathGUI1[1]="Select Eclipse.exe:";
function Language_SetEclipsePathGUI1() { return $Lang_SetEclipsePathGUI1[$pref::LanguageType]; }
  //
$Lang_SetEclipsePathGUI2[0]="ȷ��";
$Lang_SetEclipsePathGUI2[1]="Confirm";
function Language_SetEclipsePathGUI2() { return $Lang_SetEclipsePathGUI2[$pref::LanguageType]; }
  //
$Lang_SetEclipsePathGUI3[0]="ȡ��";
$Lang_SetEclipsePathGUI3[1]="Cancel";
function Language_SetEclipsePathGUI3() { return $Lang_SetEclipsePathGUI3[$pref::LanguageType]; }
  //
$Lang_SetEclipsePathGUI4[0]="���";
$Lang_SetEclipsePathGUI4[1]="Browse";
function Language_SetEclipsePathGUI4() { return $Lang_SetEclipsePathGUI4[$pref::LanguageType]; }

//
$Lang_SetServerIP0[0]="������IP:";
$Lang_SetServerIP0[1]="Server IP:";
function Language_SetServerIP0() { return $Lang_SetServerIP0[$pref::LanguageType]; }
  //
$Lang_SetServerIP1[0]="ȷ��";
$Lang_SetServerIP1[1]="Confirm";
function Language_SetServerIP1() { return $Lang_SetServerIP1[$pref::LanguageType]; }
  //
$Lang_SetServerIP2[0]="ȡ��";
$Lang_SetServerIP2[1]="Cancel";
function Language_SetServerIP2() { return $Lang_SetServerIP2[$pref::LanguageType]; }

//
$Lang_SetStartVCGUI0[0]="������������";
$Lang_SetStartVCGUI0[1]="Set Start Project";
function Language_SetStartVCGUI0() { return $Lang_SetStartVCGUI0[$pref::LanguageType]; }
  //
$Lang_SetStartVCGUI1[0]="����Java�������� : ��ǰδ����";
$Lang_SetStartVCGUI1[1]="Set Java start project: unset at present";
function Language_SetStartVCGUI1() { return $Lang_SetStartVCGUI1[$pref::LanguageType]; }
  //
$Lang_SetStartVCGUI2[0]="����Java�������� : ��ǰJCreator";
$Lang_SetStartVCGUI2[1]="Set Java start project:current JCreator";
function Language_SetStartVCGUI2() { return $Lang_SetStartVCGUI2[$pref::LanguageType]; }
  //
$Lang_SetStartVCGUI3[0]="����Java�������� : ��ǰEclipse";
$Lang_SetStartVCGUI3[1]="Set Java start project:current Eclipse";
function Language_SetStartVCGUI3() { return $Lang_SetStartVCGUI3[$pref::LanguageType]; }
  //
$Lang_SetStartVCGUI4[0]="����Java�������� : ��ǰNetbeans";
$Lang_SetStartVCGUI4[1]="Set Java start project:current Netbeans";
function Language_SetStartVCGUI4() { return $Lang_SetStartVCGUI4[$pref::LanguageType]; }
  //
$Lang_SetStartVCGUI5[0]="����VC�������� : ��ǰδ����";
$Lang_SetStartVCGUI5[1]="Set VC start project: unset at present";
function Language_SetStartVCGUI5() { return $Lang_SetStartVCGUI5[$pref::LanguageType]; }
  //
$Lang_SetStartVCGUI6[0]="����VC�������� : ��ǰVC6.0";
$Lang_SetStartVCGUI6[1]="Set VC start project:current VC6.0";
function Language_SetStartVCGUI6() { return $Lang_SetStartVCGUI6[$pref::LanguageType]; }
  //
$Lang_SetStartVCGUI7[0]="����VC�������� : ��ǰVC2012";
$Lang_SetStartVCGUI7[1]="Set VC start project:current VC2012";
function Language_SetStartVCGUI7() { return $Lang_SetStartVCGUI7[$pref::LanguageType]; }
  //
$Lang_SetStartVCGUI8[0]="����VC�������� : ��ǰVC2015";
$Lang_SetStartVCGUI8[1]="Set VC start project:current VC2015";
function Language_SetStartVCGUI8() { return $Lang_SetStartVCGUI8[$pref::LanguageType]; }
  //
$Lang_SetStartVCGUI9[0]="����VC�������� : ��ǰCodeBlock";
$Lang_SetStartVCGUI9[1]="Set VC start project:current CodeBlock";
function Language_SetStartVCGUI9() { return $Lang_SetStartVCGUI9[$pref::LanguageType]; }
  //
$Lang_SetStartVCGUI10[0]="����C#�������� : ��ǰδ����";
$Lang_SetStartVCGUI10[1]="Set C# start project: unset at present";
function Language_SetStartVCGUI10() { return $Lang_SetStartVCGUI10[$pref::LanguageType]; }
  //
$Lang_SetStartVCGUI11[0]="����C#�������� : ��ǰVC2012";
$Lang_SetStartVCGUI11[1]="Set C# start project:current VC2012";
function Language_SetStartVCGUI11() { return $Lang_SetStartVCGUI11[$pref::LanguageType]; }
  //
$Lang_SetStartVCGUI12[0]="����C#�������� : ��ǰVC2015";
$Lang_SetStartVCGUI12[1]="Set C# start project:current VC2015";
function Language_SetStartVCGUI12() { return $Lang_SetStartVCGUI12[$pref::LanguageType]; }
  //
$Lang_SetStartVCGUI13[0]="����VB�������� : ��ǰδ����";
$Lang_SetStartVCGUI13[1]="Set VB start project: unset at present";
function Language_SetStartVCGUI13() { return $Lang_SetStartVCGUI13[$pref::LanguageType]; }
  //
$Lang_SetStartVCGUI14[0]="����VB�������� : ��ǰVC2012";
$Lang_SetStartVCGUI14[1]="Set VB start project:current VC2012";
function Language_SetStartVCGUI14() { return $Lang_SetStartVCGUI14[$pref::LanguageType]; }
  //
$Lang_SetStartVCGUI15[0]="����VB�������� : ��ǰVC2015";
$Lang_SetStartVCGUI15[1]="Set VB start project:current VC2015";
function Language_SetStartVCGUI15() { return $Lang_SetStartVCGUI15[$pref::LanguageType]; }
  //
$Lang_SetStartVCGUI16[0]="����Python�������� : ��ǰδ����";
$Lang_SetStartVCGUI16[1]="Set Python start project: unset at present";
function Language_SetStartVCGUI16() { return $Lang_SetStartVCGUI16[$pref::LanguageType]; }
  //
$Lang_SetStartVCGUI17[0]="����Python�������� : ��ǰEclipse";
$Lang_SetStartVCGUI17[1]="Set Python start project:current Eclipse";
function Language_SetStartVCGUI17() { return $Lang_SetStartVCGUI17[$pref::LanguageType]; }
  //
$Lang_SetStartVCGUI18[0]="����Python�������� : ��ǰPyCharm";
$Lang_SetStartVCGUI18[1]="Set Python start project:current PyCharm";
function Language_SetStartVCGUI18() { return $Lang_SetStartVCGUI18[$pref::LanguageType]; }

//
$Lang_SetVCVersionGUI0[0]="���ÿ�������";
$Lang_SetVCVersionGUI0[1]="Set Development Tool";
function Language_SetVCVersionGUI0() { return $Lang_SetVCVersionGUI0[$pref::LanguageType]; }
  //
$Lang_SetVCVersionGUI1[0]="����Java�������� : ��ǰJCreator";
$Lang_SetVCVersionGUI1[1]="Set Java development tool:current JCreator";
function Language_SetVCVersionGUI1() { return $Lang_SetVCVersionGUI1[$pref::LanguageType]; }
  //
$Lang_SetVCVersionGUI2[0]="����Java�������� : ��ǰEclipse";
$Lang_SetVCVersionGUI2[1]="Set Java development tool:current Eclipse";
function Language_SetVCVersionGUI2() { return $Lang_SetVCVersionGUI2[$pref::LanguageType]; }
  //
$Lang_SetVCVersionGUI3[0]="����Java�������� : ��ǰNetbeans";
$Lang_SetVCVersionGUI3[1]="Set Java development tool:current Netbeans";
function Language_SetVCVersionGUI3() { return $Lang_SetVCVersionGUI3[$pref::LanguageType]; }
  //
$Lang_SetVCVersionGUI4[0]="����VC�������� : ��ǰVC6.0";
$Lang_SetVCVersionGUI4[1]="Set VC development tool:current VC6.0";
function Language_SetVCVersionGUI4() { return $Lang_SetVCVersionGUI4[$pref::LanguageType]; }
  //
$Lang_SetVCVersionGUI5[0]="����VC�������� : ��ǰVC2012";
$Lang_SetVCVersionGUI5[1]="Set VC development tool:current VC2012";
function Language_SetVCVersionGUI5() { return $Lang_SetVCVersionGUI5[$pref::LanguageType]; }
  //
$Lang_SetVCVersionGUI6[0]="����VC�������� : ��ǰVC2015";
$Lang_SetVCVersionGUI6[1]="Set VC development tool:current VC2015";
function Language_SetVCVersionGUI6() { return $Lang_SetVCVersionGUI6[$pref::LanguageType]; }
  //
$Lang_SetVCVersionGUI7[0]="����VC�������� : ��ǰCodeBlock";
$Lang_SetVCVersionGUI7[1]="Set VC development tool:current CodeBlock";
function Language_SetVCVersionGUI7() { return $Lang_SetVCVersionGUI7[$pref::LanguageType]; }
  //
$Lang_SetVCVersionGUI8[0]="����C#�������� : ��ǰVC2012";
$Lang_SetVCVersionGUI8[1]="Set C# development tool:current VC2012";
function Language_SetVCVersionGUI8() { return $Lang_SetVCVersionGUI8[$pref::LanguageType]; }
  //
$Lang_SetVCVersionGUI9[0]="����C#�������� : ��ǰVC2015";
$Lang_SetVCVersionGUI9[1]="Set C# development tool:current VC2015";
function Language_SetVCVersionGUI9() { return $Lang_SetVCVersionGUI9[$pref::LanguageType]; }
  //
$Lang_SetVCVersionGUI10[0]="����VB�������� : ��ǰVC2012";
$Lang_SetVCVersionGUI10[1]="Set VB development tool:current VC2012";
function Language_SetVCVersionGUI10() { return $Lang_SetVCVersionGUI10[$pref::LanguageType]; }
  //
$Lang_SetVCVersionGUI11[0]="����VB�������� : ��ǰVC2015";
$Lang_SetVCVersionGUI11[1]="Set VB development tool:current VC2015";
function Language_SetVCVersionGUI11() { return $Lang_SetVCVersionGUI11[$pref::LanguageType]; }
  //
$Lang_SetVCVersionGUI12[0]="����Python�������� : ��ǰEclipse";
$Lang_SetVCVersionGUI12[1]="Set Python development tool:current Eclipse";
function Language_SetVCVersionGUI12() { return $Lang_SetVCVersionGUI12[$pref::LanguageType]; }
  //
$Lang_SetVCVersionGUI13[0]="����Python�������� : ��ǰPyCharm";
$Lang_SetVCVersionGUI13[1]="Set Python development tool:current PyCharm";
function Language_SetVCVersionGUI13() { return $Lang_SetVCVersionGUI13[$pref::LanguageType]; }

//
$Lang_toolHelpDlg0[0]="���ٰ���";
$Lang_toolHelpDlg0[1]="Quick Help";
function Language_toolHelpDlg0() { return $Lang_toolHelpDlg0[$pref::LanguageType]; }

//
$Lang_AnimatedSprites0[0]="��������(Sprites)";
$Lang_AnimatedSprites0[1]="Animated Sprites";
function Language_AnimatedSprites0() { return $Lang_AnimatedSprites0[$pref::LanguageType]; }

//
$Lang_otherObjects0[0]="����";
$Lang_otherObjects0[1]="Other";
function Language_otherObjects0() { return $Lang_otherObjects0[$pref::LanguageType]; }
  //
$Lang_otherObjects1[0]="��ͼ����";
$Lang_otherObjects1[1]="Scene Object";
function Language_otherObjects1() { return $Lang_otherObjects1[$pref::LanguageType]; }
  //
$Lang_otherObjects2[0]="������";
$Lang_otherObjects2[1]="Trigger";
function Language_otherObjects2() { return $Lang_otherObjects2[$pref::LanguageType]; }
  //
$Lang_otherObjects3[0]="·��";
$Lang_otherObjects3[1]="Path";
function Language_otherObjects3() { return $Lang_otherObjects3[$pref::LanguageType]; }
  //
$Lang_otherObjects4[0]="����";
$Lang_otherObjects4[1]="Text";
function Language_otherObjects4() { return $Lang_otherObjects4[$pref::LanguageType]; }
  //
$Lang_otherObjects5[0]="�����";
$Lang_otherObjects5[1]="Polygon";
function Language_otherObjects5() { return $Lang_otherObjects5[$pref::LanguageType]; }

//
$Lang_particleEffects0[0]="������Ч";
$Lang_particleEffects0[1]="Particle Effects";
function Language_particleEffects0() { return $Lang_particleEffects0[$pref::LanguageType]; }

//
$Lang_scrollers0[0]="����ͼ";
$Lang_scrollers0[1]="Scrollers";
function Language_scrollers0() { return $Lang_scrollers0[$pref::LanguageType]; }

//
$Lang_staticSprites0[0]="��̬����(Sprites)";
$Lang_staticSprites0[1]="Static Sprites";
function Language_staticSprites0() { return $Lang_staticSprites0[$pref::LanguageType]; }

//
$Lang_tileMaps0[0]="ƽ��ͼ";
$Lang_tileMaps0[1]="Tilemaps";
function Language_tileMaps0() { return $Lang_tileMaps0[$pref::LanguageType]; }

//
$Lang_align0[0]="����";
$Lang_align0[1]="Align";
function Language_align0() { return $Lang_align0[$pref::LanguageType]; }
  //
$Lang_align1[0]="�ֲ�";
$Lang_align1[1]="Distribute";
function Language_align1() { return $Lang_align1[$pref::LanguageType]; }
  //
$Lang_align2[0]="��Сƥ��";
$Lang_align2[1]="Size Match";
function Language_align2() { return $Lang_align2[$pref::LanguageType]; }
  //
$Lang_align3[0]="���";
$Lang_align3[1]="Interval";
function Language_align3() { return $Lang_align3[$pref::LanguageType]; }
  //
$Lang_align4[0]="���뵽��Ļ";
$Lang_align4[1]="Align to Screen";
function Language_align4() { return $Lang_align4[$pref::LanguageType]; }

//
$Lang_particleEffectGraph0[0]="�༭����Ч������";
$Lang_particleEffectGraph0[1]="Edit the  effect property";
function Language_particleEffectGraph0() { return $Lang_particleEffectGraph0[$pref::LanguageType]; }
  //
$Lang_particleEffectGraph1[0]="�������Ч���ļ�";
$Lang_particleEffectGraph1[1]="Save the effect to file";
function Language_particleEffectGraph1() { return $Lang_particleEffectGraph1[$pref::LanguageType]; }
  //
$Lang_particleEffectGraph2[0]="����һ����Ч������Ч";
$Lang_particleEffectGraph2[1]="Add another effect to this";
function Language_particleEffectGraph2() { return $Lang_particleEffectGraph2[$pref::LanguageType]; }

//
$Lang_particleEmitterStack0[0]="���һ������������Ч";
$Lang_particleEmitterStack0[1]="Add a particle to this effect";
function Language_particleEmitterStack0() { return $Lang_particleEmitterStack0[$pref::LanguageType]; }
  //
$Lang_particleEmitterStack1[0]="��������:";
$Lang_particleEmitterStack1[1]="Create Particle:";
function Language_particleEmitterStack1() { return $Lang_particleEmitterStack1[$pref::LanguageType]; }
  //
$Lang_particleEmitterStack2[0]="�༭����ͼ��";
$Lang_particleEmitterStack2[1]="Edit particle image";
function Language_particleEmitterStack2() { return $Lang_particleEmitterStack2[$pref::LanguageType]; }
  //
$Lang_particleEmitterStack3[0]="��ʾ���������ͼ������";
$Lang_particleEmitterStack3[1]="Show the particle's image data";
function Language_particleEmitterStack3() { return $Lang_particleEmitterStack3[$pref::LanguageType]; }
  //
$Lang_particleEmitterStack4[0]="ͼƬ";
$Lang_particleEmitterStack4[1]="Image";
function Language_particleEmitterStack4() { return $Lang_particleEmitterStack4[$pref::LanguageType]; }
  //
$Lang_particleEmitterStack5[0]="����";
$Lang_particleEmitterStack5[1]="Animation";
function Language_particleEmitterStack5() { return $Lang_particleEmitterStack5[$pref::LanguageType]; }
  //
$Lang_particleEmitterStack6[0]="֡��";
$Lang_particleEmitterStack6[1]="Frame Count";
function Language_particleEmitterStack6() { return $Lang_particleEmitterStack6[$pref::LanguageType]; }
  //
$Lang_particleEmitterStack7[0]="��ʾ֡��";
$Lang_particleEmitterStack7[1]="Show the frame count";
function Language_particleEmitterStack7() { return $Lang_particleEmitterStack7[$pref::LanguageType]; }
  //
$Lang_particleEmitterStack8[0]="����";
$Lang_particleEmitterStack8[1]="Type";
function Language_particleEmitterStack8() { return $Lang_particleEmitterStack8[$pref::LanguageType]; }
  //
$Lang_particleEmitterStack9[0]="����";
$Lang_particleEmitterStack9[1]="Orientation";
function Language_particleEmitterStack9() { return $Lang_particleEmitterStack9[$pref::LanguageType]; }
  //
$Lang_particleEmitterStack10[0]="�̶��Ƕ�ƫ��";
$Lang_particleEmitterStack10[1]="Fixed Angle Offset";
function Language_particleEmitterStack10() { return $Lang_particleEmitterStack10[$pref::LanguageType]; }
  //
$Lang_particleEmitterStack11[0]="���ĵ�";
$Lang_particleEmitterStack11[1]="Pivot Point";
function Language_particleEmitterStack11() { return $Lang_particleEmitterStack11[$pref::LanguageType]; }
  //
$Lang_particleEmitterStack12[0]="�������Ƕ�";
$Lang_particleEmitterStack12[1]="Force Angle";
function Language_particleEmitterStack12() { return $Lang_particleEmitterStack12[$pref::LanguageType]; }
  //
$Lang_particleEmitterStack13[0]="�̶�����";
$Lang_particleEmitterStack13[1]="Fixed Aspect";
function Language_particleEmitterStack13() { return $Lang_particleEmitterStack13[$pref::LanguageType]; }
  //
$Lang_particleEmitterStack14[0]="ʹ����Ч������";
$Lang_particleEmitterStack14[1]="Use Effect Emission";
function Language_particleEmitterStack14() { return $Lang_particleEmitterStack14[$pref::LanguageType]; }
  //
$Lang_particleEmitterStack15[0]="ǿ����Ч";
$Lang_particleEmitterStack15[1]="Intense Effect";
function Language_particleEmitterStack15() { return $Lang_particleEmitterStack15[$pref::LanguageType]; }
  //
$Lang_particleEmitterStack16[0]="��һ��Ч";
$Lang_particleEmitterStack16[1]="Single Particle";
function Language_particleEmitterStack16() { return $Lang_particleEmitterStack16[$pref::LanguageType]; }
  //
$Lang_particleEmitterStack17[0]="����λ��";
$Lang_particleEmitterStack17[1]="Attach Position";
function Language_particleEmitterStack17() { return $Lang_particleEmitterStack17[$pref::LanguageType]; }
  //
$Lang_particleEmitterStack18[0]="���泯��";
$Lang_particleEmitterStack18[1]="Attach Rotation";
function Language_particleEmitterStack18() { return $Lang_particleEmitterStack18[$pref::LanguageType]; }
  //
$Lang_particleEmitterStack19[0]="��ת������";
$Lang_particleEmitterStack19[1]="Rotation Emission";
function Language_particleEmitterStack19() { return $Lang_particleEmitterStack19[$pref::LanguageType]; }
  //
$Lang_particleEmitterStack20[0]="��ǰ���ȷ���";
$Lang_particleEmitterStack20[1]="Front emission first";
function Language_particleEmitterStack20() { return $Lang_particleEmitterStack20[$pref::LanguageType]; }
  //
$Lang_particleEmitterStack21[0]="ɾ��������";
$Lang_particleEmitterStack21[1]="Delete the particle";
function Language_particleEmitterStack21() { return $Lang_particleEmitterStack21[$pref::LanguageType]; }

//
$Lang_particleGraphFieldList0[0]="��һ��";
$Lang_particleGraphFieldList0[1]="Previous One";
function Language_particleGraphFieldList0() { return $Lang_particleGraphFieldList0[$pref::LanguageType]; }
  //
$Lang_particleGraphFieldList1[0]="��һ��";
$Lang_particleGraphFieldList1[1]="Next One";
function Language_particleGraphFieldList1() { return $Lang_particleGraphFieldList1[$pref::LanguageType]; }
  //
$Lang_particleGraphFieldList2[0]="�ر�";
$Lang_particleGraphFieldList2[1]="Close";
function Language_particleGraphFieldList2() { return $Lang_particleGraphFieldList2[$pref::LanguageType]; }
  //
$Lang_particleGraphFieldList3[0]="��ǰ������:";
$Lang_particleGraphFieldList3[1]="Current Property Field";
function Language_particleGraphFieldList3() { return $Lang_particleGraphFieldList3[$pref::LanguageType]; }
  //
$Lang_particleGraphFieldList4[0]="ֵ";
$Lang_particleGraphFieldList4[1]="Value";
function Language_particleGraphFieldList4() { return $Lang_particleGraphFieldList4[$pref::LanguageType]; }
  //
$Lang_particleGraphFieldList5[0]="ʱ��";
$Lang_particleGraphFieldList5[1]="Time";
function Language_particleGraphFieldList5() { return $Lang_particleGraphFieldList5[$pref::LanguageType]; }
  //
$Lang_particleGraphFieldList6[0]="ֵ (��С/���)";
$Lang_particleGraphFieldList6[1]="Value (Minimum/Maximum)";
function Language_particleGraphFieldList6() { return $Lang_particleGraphFieldList6[$pref::LanguageType]; }
  //
$Lang_particleGraphFieldList7[0]="ʱ�� (��С/���)";
$Lang_particleGraphFieldList7[1]="Time (Minimum/Maximum)";
function Language_particleGraphFieldList7() { return $Lang_particleGraphFieldList7[$pref::LanguageType]; }
  //
$Lang_particleGraphFieldList8[0]="��ӹؼ�֡ - ��Чʱ��";
$Lang_particleGraphFieldList8[1]="Add key frame- invalid time";
function Language_particleGraphFieldList8() { return $Lang_particleGraphFieldList8[$pref::LanguageType]; }
  //
$Lang_particleGraphFieldList9[0]="ʱ�䳬������ķ�Χ (��С = ";
$Lang_particleGraphFieldList9[1]="time out of range (minimum = ";
function Language_particleGraphFieldList9() { return $Lang_particleGraphFieldList9[$pref::LanguageType]; }
    //
$Lang_particleGraphFieldList10[0]="��� = ";
$Lang_particleGraphFieldList10[1]="maximum= ";
function Language_particleGraphFieldList10() { return $Lang_particleGraphFieldList10[$pref::LanguageType]; }
  //
$Lang_particleGraphFieldList11[0]="��ӹؼ�֡ - ��Чֵ";
$Lang_particleGraphFieldList11[1]="Add key frame- invalid value";
function Language_particleGraphFieldList11() { return $Lang_particleGraphFieldList11[$pref::LanguageType]; }
    //
$Lang_particleGraphFieldList12[0]="ֵ��������ķ�Χ (��С = ";
$Lang_particleGraphFieldList12[1]="value out of range(minimum = ";
function Language_particleGraphFieldList12() { return $Lang_particleGraphFieldList12[$pref::LanguageType]; }
  //
$Lang_particleGraphFieldList13[0]="��� = ";
$Lang_particleGraphFieldList13[1]="maximum= ";
function Language_particleGraphFieldList13() { return $Lang_particleGraphFieldList13[$pref::LanguageType]; }

//
$Lang_showGraphButton0[0]="ɾ�����Ӵ���";
$Lang_showGraphButton0[1]="Particles delete error";
function Language_showGraphButton0() { return $Lang_showGraphButton0[$pref::LanguageType]; }
  //
$Lang_showGraphButton1[0]="�����Ч������һ������!";
$Lang_showGraphButton1[1]="Needs at least one particle!";
function Language_showGraphButton1() { return $Lang_showGraphButton1[$pref::LanguageType]; }

//
$Lang_layerManager0[0]="�㼶 ";
$Lang_layerManager0[1]="Layer ";
function Language_layerManager0() { return $Lang_layerManager0[$pref::LanguageType]; }
  //
$Lang_layerManager1[0]="����/�����˲㼶";
$Lang_layerManager1[1]="Lock/Unlock the layer";
function Language_layerManager1() { return $Lang_layerManager1[$pref::LanguageType]; }
  //
$Lang_layerManager2[0]="��ʾ/���ش˲㼶";
$Lang_layerManager2[1]="Show/Hide the layer";
function Language_layerManager2() { return $Lang_layerManager2[$pref::LanguageType]; }
  //
$Lang_layerManager3[0]="�㼶����ʽ";
$Lang_layerManager3[1]="Layer Sort Order";
function Language_layerManager3() { return $Lang_layerManager3[$pref::LanguageType]; }
  
//
$Lang_mask0[0]="ȫ������";
$Lang_mask0[1]="Activate All";
function Language_mask0() { return $Lang_mask0[$pref::LanguageType]; }
//
$Lang_mask1[0]="����";
$Lang_mask1[1]="All";
function Language_mask1() { return $Lang_mask1[$pref::LanguageType]; }
//
$Lang_mask2[0]="ȫ���䲻�";
$Lang_mask2[1]="All change to inactive";
function Language_mask2() { return $Lang_mask2[$pref::LanguageType]; }
//
$Lang_mask3[0]="��";
$Lang_mask3[1]="None";
function Language_mask3() { return $Lang_mask3[$pref::LanguageType]; }

//
$Lang_quickEditFieldBaseType0[0]="�������зǷ��ַ�";
$Lang_quickEditFieldBaseType0[1]="Name contains  illegal character";
function Language_quickEditFieldBaseType0() { return $Lang_quickEditFieldBaseType0[$pref::LanguageType]; }
//
$Lang_quickEditFieldBaseType1[0]="���ֱ�������ĸ�����֡��»�����ɣ���������ĸ����������";
$Lang_quickEditFieldBaseType1[1]="Name should include letter,number and underline,numbercannot be used as the first letter";
function Language_quickEditFieldBaseType1() { return $Lang_quickEditFieldBaseType1[$pref::LanguageType]; }

//
$Lang_t2dAnimatedSprite0[0]="����";
$Lang_t2dAnimatedSprite0[1]="Animation";
function Language_t2dAnimatedSprite0() { return $Lang_t2dAnimatedSprite0[$pref::LanguageType]; }
//
$Lang_t2dAnimatedSprite1[0]="��������";
$Lang_t2dAnimatedSprite1[1]="Play animation";
function Language_t2dAnimatedSprite1() { return $Lang_t2dAnimatedSprite1[$pref::LanguageType]; }
//
$Lang_t2dAnimatedSprite2[0]="��������";
$Lang_t2dAnimatedSprite2[1]="Animated Sprite";
function Language_t2dAnimatedSprite2() { return $Lang_t2dAnimatedSprite2[$pref::LanguageType]; }

//
$Lang_t2dParticleEffect0[0]="��Чģʽ";
$Lang_t2dParticleEffect0[1]="Effect mode";
function Language_t2dParticleEffect0() { return $Lang_t2dParticleEffect0[$pref::LanguageType]; }
//
$Lang_t2dParticleEffect1[0]="��Ч������ģʽ: ���޲��š�ѭ������";
$Lang_t2dParticleEffect1[1]="Effect life mode:infinite play,cycle play";
function Language_t2dParticleEffect1() { return $Lang_t2dParticleEffect1[$pref::LanguageType]; }
//
$Lang_t2dParticleEffect2[0]="��Ч��������";
$Lang_t2dParticleEffect2[1]="Effect lifecycle";
function Language_t2dParticleEffect2() { return $Lang_t2dParticleEffect2[$pref::LanguageType]; }
//
$Lang_t2dParticleEffect3[0]="��Ч����ʱ��";
$Lang_t2dParticleEffect3[1]="Effect life time";
function Language_t2dParticleEffect3() { return $Lang_t2dParticleEffect3[$pref::LanguageType]; }
//
$Lang_t2dParticleEffect4[0]="������Ч";
$Lang_t2dParticleEffect4[1]="Load Effect";
function Language_t2dParticleEffect4() { return $Lang_t2dParticleEffect4[$pref::LanguageType]; }
//
$Lang_t2dParticleEffect5[0]="������Ч";
$Lang_t2dParticleEffect5[1]="Save Effect";
function Language_t2dParticleEffect5() { return $Lang_t2dParticleEffect5[$pref::LanguageType]; }
//
$Lang_t2dParticleEffect6[0]="������Ч";
$Lang_t2dParticleEffect6[1]="Particle Effect";
function Language_t2dParticleEffect6() { return $Lang_t2dParticleEffect6[$pref::LanguageType]; }

//
$Lang_t2dPath0[0]="·������";
$Lang_t2dPath0[1]="Path Type";
function Language_t2dPath0() { return $Lang_t2dPath0[$pref::LanguageType]; }
//
$Lang_t2dPath1[0]="·���Ĳ�ֵ����";
$Lang_t2dPath1[1]="Path interpolation type";
function Language_t2dPath1() { return $Lang_t2dPath1[$pref::LanguageType]; }
//
$Lang_t2dPath2[0]="·��";
$Lang_t2dPath2[1]="Path";
function Language_t2dPath2() { return $Lang_t2dPath2[$pref::LanguageType]; }

//
$Lang_t2dSceneGraph0[0]="��Ļλ��";
$Lang_t2dSceneGraph0[1]="Screen Position";
function Language_t2dSceneGraph0() { return $Lang_t2dSceneGraph0[$pref::LanguageType]; }
//
$Lang_t2dSceneGraph1[0]="������Ļλ��";
$Lang_t2dSceneGraph1[1]="Set screen position";
function Language_t2dSceneGraph1() { return $Lang_t2dSceneGraph1[$pref::LanguageType]; }
//
$Lang_t2dSceneGraph2[0]="��";
$Lang_t2dSceneGraph2[1]="Width";
function Language_t2dSceneGraph2() { return $Lang_t2dSceneGraph2[$pref::LanguageType]; }
//
$Lang_t2dSceneGraph3[0]="��";
$Lang_t2dSceneGraph3[1]="Height";
function Language_t2dSceneGraph3() { return $Lang_t2dSceneGraph3[$pref::LanguageType]; }
//
$Lang_t2dSceneGraph4[0]="������Ļ��С";
$Lang_t2dSceneGraph4[1]="Set screen size";
function Language_t2dSceneGraph4() { return $Lang_t2dSceneGraph4[$pref::LanguageType]; }
//
$Lang_t2dSceneGraph5[0]="���ڴ�С";
$Lang_t2dSceneGraph5[1]="Window size";
function Language_t2dSceneGraph5() { return $Lang_t2dSceneGraph5[$pref::LanguageType]; }
//
$Lang_t2dSceneGraph6[0]="���ô��ڴ�С";
$Lang_t2dSceneGraph6[1]="Set window size";
function Language_t2dSceneGraph6() { return $Lang_t2dSceneGraph6[$pref::LanguageType]; }
//
$Lang_t2dSceneGraph7[0]="�߽��";
$Lang_t2dSceneGraph7[1]="Bounding boxes";
function Language_t2dSceneGraph7() { return $Lang_t2dSceneGraph7[$pref::LanguageType]; }
//
$Lang_t2dSceneGraph8[0]="��ʾ����߽��";
$Lang_t2dSceneGraph8[1]="Show Sprite bounding boxes";
function Language_t2dSceneGraph8() { return $Lang_t2dSceneGraph8[$pref::LanguageType]; }
//
$Lang_t2dSceneGraph9[0]="���ӵ�";
$Lang_t2dSceneGraph9[1]="Link points";
function Language_t2dSceneGraph9() { return $Lang_t2dSceneGraph9[$pref::LanguageType]; }
//
$Lang_t2dSceneGraph10[0]="��ʾ�������ӵ�";
$Lang_t2dSceneGraph10[1]="Show Sprite link points";
function Language_t2dSceneGraph10() { return $Lang_t2dSceneGraph10[$pref::LanguageType]; }
//
$Lang_t2dSceneGraph11[0]="����߽�����";
$Lang_t2dSceneGraph11[1]="World border limit";
function Language_t2dSceneGraph11() { return $Lang_t2dSceneGraph11[$pref::LanguageType]; }
//
$Lang_t2dSceneGraph12[0]="��ʾ��������߽�����";
$Lang_t2dSceneGraph12[1]="Show Sprite world border limit";
function Language_t2dSceneGraph12() { return $Lang_t2dSceneGraph12[$pref::LanguageType]; }
//
$Lang_t2dSceneGraph13[0]="��ײ��";
$Lang_t2dSceneGraph13[1]="Collision boxes";
function Language_t2dSceneGraph13() { return $Lang_t2dSceneGraph13[$pref::LanguageType]; }
//
$Lang_t2dSceneGraph14[0]="��ʾ������ײ��";
$Lang_t2dSceneGraph14[1]="Show Sprite collision boxes";
function Language_t2dSceneGraph14() { return $Lang_t2dSceneGraph14[$pref::LanguageType]; }
//
$Lang_t2dSceneGraph15[0]="�����";
$Lang_t2dSceneGraph15[1]="Sort points";
function Language_t2dSceneGraph15() { return $Lang_t2dSceneGraph15[$pref::LanguageType]; }
//
$Lang_t2dSceneGraph16[0]="��ʾ���������";
$Lang_t2dSceneGraph16[1]="Show Sprite sort points";
function Language_t2dSceneGraph16() { return $Lang_t2dSceneGraph16[$pref::LanguageType]; }
//
$Lang_t2dSceneGraph17[0]="��Ļ";
$Lang_t2dSceneGraph17[1]="Screen";
function Language_t2dSceneGraph17() { return $Lang_t2dSceneGraph17[$pref::LanguageType]; }
//
$Lang_t2dSceneGraph18[0]="��ʾѡ��";
$Lang_t2dSceneGraph18[1]="Show Options";
function Language_t2dSceneGraph18() { return $Lang_t2dSceneGraph18[$pref::LanguageType]; }

//
$Lang_t2dSceneObject0[0]="����";
$Lang_t2dSceneObject0[1]="Name";
function Language_t2dSceneObject0() { return $Lang_t2dSceneObject0[$pref::LanguageType]; }
//
$Lang_t2dSceneObject1[0]="������ʹ�õ�����";
$Lang_t2dSceneObject1[1]="Name used in program";
function Language_t2dSceneObject1() { return $Lang_t2dSceneObject1[$pref::LanguageType]; }
//
$Lang_t2dSceneObject2[0]="λ��";
$Lang_t2dSceneObject2[1]="Position";
function Language_t2dSceneObject2() { return $Lang_t2dSceneObject2[$pref::LanguageType]; }
//
$Lang_t2dSceneObject3[0]="��С";
$Lang_t2dSceneObject3[1]="Size";
function Language_t2dSceneObject3() { return $Lang_t2dSceneObject3[$pref::LanguageType]; }
//
$Lang_t2dSceneObject4[0]="��";
$Lang_t2dSceneObject4[1]="Width";
function Language_t2dSceneObject4() { return $Lang_t2dSceneObject4[$pref::LanguageType]; }
//
$Lang_t2dSceneObject5[0]="��";
$Lang_t2dSceneObject5[1]="Height";
function Language_t2dSceneObject5() { return $Lang_t2dSceneObject5[$pref::LanguageType]; }
//
$Lang_t2dSceneObject6[0]="����";
$Lang_t2dSceneObject6[1]="Orientation";
function Language_t2dSceneObject6() { return $Lang_t2dSceneObject6[$pref::LanguageType]; }
//
$Lang_t2dSceneObject7[0]="��ת�Ƕ�";
$Lang_t2dSceneObject7[1]="Rotation angle";
function Language_t2dSceneObject7() { return $Lang_t2dSceneObject7[$pref::LanguageType]; }
//
$Lang_t2dSceneObject8[0]="�Զ���ת";
$Lang_t2dSceneObject8[1]="Auto rotation";
function Language_t2dSceneObject8() { return $Lang_t2dSceneObject8[$pref::LanguageType]; }
//
$Lang_t2dSceneObject9[0]="�Զ���ת�ٶ�";
$Lang_t2dSceneObject9[1]="Auto rotation velocity";
function Language_t2dSceneObject9() { return $Lang_t2dSceneObject9[$pref::LanguageType]; }
//
$Lang_t2dSceneObject10[0]="ˮƽ��ת";
$Lang_t2dSceneObject10[1]="Flip horizontal";
function Language_t2dSceneObject10() { return $Lang_t2dSceneObject10[$pref::LanguageType]; }
//
$Lang_t2dSceneObject11[0]="��ֱ��ת";
$Lang_t2dSceneObject11[1]="Flip vertical";
function Language_t2dSceneObject11() { return $Lang_t2dSceneObject11[$pref::LanguageType]; }
//
$Lang_t2dSceneObject12[0]="�����";
$Lang_t2dSceneObject12[1]="Sort points";
function Language_t2dSceneObject12() { return $Lang_t2dSceneObject12[$pref::LanguageType]; }
//
$Lang_t2dSceneObject13[0]="ͼƬ��ʾ˳�����������";
$Lang_t2dSceneObject13[1]="Sort by image show order";
function Language_t2dSceneObject13() { return $Lang_t2dSceneObject13[$pref::LanguageType]; }
//
$Lang_t2dSceneObject14[0]="��";
$Lang_t2dSceneObject14[1]="Layer";
function Language_t2dSceneObject14() { return $Lang_t2dSceneObject14[$pref::LanguageType]; }
//
$Lang_t2dSceneObject15[0]="��ʾ�Ĳ㼶";
$Lang_t2dSceneObject15[1]="Layer shown";
function Language_t2dSceneObject15() { return $Lang_t2dSceneObject15[$pref::LanguageType]; }
//
$Lang_t2dSceneObject16[0]="��";
$Lang_t2dSceneObject16[1]="Group";
function Language_t2dSceneObject16() { return $Lang_t2dSceneObject16[$pref::LanguageType]; }
//
$Lang_t2dSceneObject17[0]="ͼ����";
$Lang_t2dSceneObject17[1]="Image group";
function Language_t2dSceneObject17() { return $Lang_t2dSceneObject17[$pref::LanguageType]; }
//
$Lang_t2dSceneObject18[0]="����/ǰ��";
$Lang_t2dSceneObject18[1]="Move backward/forward";
function Language_t2dSceneObject18() { return $Lang_t2dSceneObject18[$pref::LanguageType]; }
//
$Lang_t2dSceneObject19[0]="��ͬһ�㼶�н���ǰ�û����";
$Lang_t2dSceneObject19[1]="Move backward/forward in the the same layer";
function Language_t2dSceneObject19() { return $Lang_t2dSceneObject19[$pref::LanguageType]; }
//
$Lang_t2dSceneObject20[0]="�ɼ�";
$Lang_t2dSceneObject20[1]="Visible";
function Language_t2dSceneObject20() { return $Lang_t2dSceneObject20[$pref::LanguageType]; }
//
$Lang_t2dSceneObject21[0]="��ʾ��������";
$Lang_t2dSceneObject21[1]="Show or hide";
function Language_t2dSceneObject21() { return $Lang_t2dSceneObject21[$pref::LanguageType]; }
//
$Lang_t2dSceneObject22[0]="��������";
$Lang_t2dSceneObject22[1]="Lifetime";
function Language_t2dSceneObject22() { return $Lang_t2dSceneObject22[$pref::LanguageType]; }
//
$Lang_t2dSceneObject23[0]="�������ڽ����Զ�ɾ������λ��";
$Lang_t2dSceneObject23[1]="Auto delete when lifetime is over,unit second";
function Language_t2dSceneObject23() { return $Lang_t2dSceneObject23[$pref::LanguageType]; }
//
$Lang_t2dSceneObject24[0]="��ʼ��";
$Lang_t2dSceneObject24[1]="Starting point";
function Language_t2dSceneObject24() { return $Lang_t2dSceneObject24[$pref::LanguageType]; }
//
$Lang_t2dSceneObject25[0]="�þ���Ѱ·����ʼ��";
$Lang_t2dSceneObject25[1]="The starting point of sprites pathfinding";
function Language_t2dSceneObject25() { return $Lang_t2dSceneObject25[$pref::LanguageType]; }
//
$Lang_t2dSceneObject26[0]="��ֹ��";
$Lang_t2dSceneObject26[1]="End point";
function Language_t2dSceneObject26() { return $Lang_t2dSceneObject26[$pref::LanguageType]; }
//
$Lang_t2dSceneObject27[0]="�þ���Ѱ·����ֹ��";
$Lang_t2dSceneObject27[1]="The end point of sprites pathfinding";
function Language_t2dSceneObject27() { return $Lang_t2dSceneObject27[$pref::LanguageType]; }
//
$Lang_t2dSceneObject28[0]="�ٶ�";
$Lang_t2dSceneObject28[1]="Speed";
function Language_t2dSceneObject28() { return $Lang_t2dSceneObject28[$pref::LanguageType]; }
//
$Lang_t2dSceneObject29[0]="����·���ƶ����ٶ�";
$Lang_t2dSceneObject29[1]="Speed of moving with the path";
function Language_t2dSceneObject29() { return $Lang_t2dSceneObject29[$pref::LanguageType]; }
//
$Lang_t2dSceneObject30[0]="��ǰ�ƶ�";
$Lang_t2dSceneObject30[1]="Move forward";
function Language_t2dSceneObject30() { return $Lang_t2dSceneObject30[$pref::LanguageType]; }
//
$Lang_t2dSceneObject31[0]="ֱ����ǰ�ƶ�";
$Lang_t2dSceneObject31[1]="Move forward directly";
function Language_t2dSceneObject31() { return $Lang_t2dSceneObject31[$pref::LanguageType]; }
//
$Lang_t2dSceneObject32[0]="�����·��";
$Lang_t2dSceneObject32[1]="Move toward the path";
function Language_t2dSceneObject32() { return $Lang_t2dSceneObject32[$pref::LanguageType]; }
//
$Lang_t2dSceneObject33[0]="��ת�þ�������·������һ��";
$Lang_t2dSceneObject33[1]="Rotate the Sprite to the same orientation with the path";
function Language_t2dSceneObject33() { return $Lang_t2dSceneObject33[$pref::LanguageType]; }
//
$Lang_t2dSceneObject34[0]="��תƫ��";
$Lang_t2dSceneObject34[1]="Rotation offset";
function Language_t2dSceneObject34() { return $Lang_t2dSceneObject34[$pref::LanguageType]; }
//
$Lang_t2dSceneObject35[0]="��·������ת��ƫ��";
$Lang_t2dSceneObject35[1]="Path rotation offset";
function Language_t2dSceneObject35() { return $Lang_t2dSceneObject35[$pref::LanguageType]; }
//
$Lang_t2dSceneObject36[0]="ѭ���ƶ�";
$Lang_t2dSceneObject36[1]="Move loops";
function Language_t2dSceneObject36() { return $Lang_t2dSceneObject36[$pref::LanguageType]; }
//
$Lang_t2dSceneObject37[0]="ѭ���ƶ�����";
$Lang_t2dSceneObject37[1]="Move loops times";
function Language_t2dSceneObject37() { return $Lang_t2dSceneObject37[$pref::LanguageType]; }
//
$Lang_t2dSceneObject38[0]="����ģʽ";
$Lang_t2dSceneObject38[1]="Follow mode";
function Language_t2dSceneObject38() { return $Lang_t2dSceneObject38[$pref::LanguageType]; }
//
$Lang_t2dSceneObject39[0]="�ƶ����յ�ĸ���·��ģʽ";
$Lang_t2dSceneObject39[1]="Move to the end follow mode";
function Language_t2dSceneObject39() { return $Lang_t2dSceneObject39[$pref::LanguageType]; }
//
$Lang_t2dSceneObject40[0]="������ײ";
$Lang_t2dSceneObject40[1]="Collision send";
function Language_t2dSceneObject40() { return $Lang_t2dSceneObject40[$pref::LanguageType]; }
//
$Lang_t2dSceneObject41[0]="����������Ӵ�ʱ�����������ľ��������ײ";
$Lang_t2dSceneObject41[1]="Auto collision when touching other sprites";
function Language_t2dSceneObject41() { return $Lang_t2dSceneObject41[$pref::LanguageType]; }
//
$Lang_t2dSceneObject42[0]="������ײ";
$Lang_t2dSceneObject42[1]="Collision receive";
function Language_t2dSceneObject42() { return $Lang_t2dSceneObject42[$pref::LanguageType]; }
//
$Lang_t2dSceneObject43[0]="����������Ӵ�ʱ�������ܱ�ľ��鷢�͵���ײ";
$Lang_t2dSceneObject43[1]="Receive collision sent by other sprites when touching";
function Language_t2dSceneObject43() { return $Lang_t2dSceneObject43[$pref::LanguageType]; }
//
$Lang_t2dSceneObject44[0]="����������ײ";
$Lang_t2dSceneObject44[1]="Send physics collision";
function Language_t2dSceneObject44() { return $Lang_t2dSceneObject44[$pref::LanguageType]; }
//
$Lang_t2dSceneObject45[0]="����������Ӵ�ʱ����ʹ�������������ľ��������ײ";
$Lang_t2dSceneObject45[1]="Use physics to collide with other sprites when touching";
function Language_t2dSceneObject45() { return $Lang_t2dSceneObject45[$pref::LanguageType]; }
//
$Lang_t2dSceneObject46[0]="����������ײ";
$Lang_t2dSceneObject46[1]="Receive physics collision";
function Language_t2dSceneObject46() { return $Lang_t2dSceneObject46[$pref::LanguageType]; }
//
$Lang_t2dSceneObject47[0]="����������Ӵ�ʱ�������ܱ�ľ��鷢�͵�������ײ";
$Lang_t2dSceneObject47[1]="Receive physics collision sent by other sprites when touching";
function Language_t2dSceneObject47() { return $Lang_t2dSceneObject47[$pref::LanguageType]; }
//
$Lang_t2dSceneObject48[0]="������ײ��Ӧ";
$Lang_t2dSceneObject48[1]="Physics collision response";
function Language_t2dSceneObject48() { return $Lang_t2dSceneObject48[$pref::LanguageType]; }
//
$Lang_t2dSceneObject49[0]="�ֱ�Ϊ���رա�ͣ������������ֹ��ɾ�������塢�Զ���";
$Lang_t2dSceneObject49[1]="Respectively:off,clamp,bounce,sticky,kill,rigid,custom";
function Language_t2dSceneObject49() { return $Lang_t2dSceneObject49[$pref::LanguageType]; }
//
$Lang_t2dSceneObject50[0]="��ײ�Ĳ㼶";
$Lang_t2dSceneObject50[1]="Collision Layers";
function Language_t2dSceneObject50() { return $Lang_t2dSceneObject50[$pref::LanguageType]; }
//
$Lang_t2dSceneObject51[0]="���Ĵ˾�����Խ�����ײ�Ĳ㼶";
$Lang_t2dSceneObject51[1]="Change Sprite collision layers";
function Language_t2dSceneObject51() { return $Lang_t2dSceneObject51[$pref::LanguageType]; }
//
$Lang_t2dSceneObject52[0]="�ٶ�";
$Lang_t2dSceneObject52[1]="Velocity";
function Language_t2dSceneObject52() { return $Lang_t2dSceneObject52[$pref::LanguageType]; }
//
$Lang_t2dSceneObject53[0]="ֱ���ٶ�";
$Lang_t2dSceneObject53[1]="Linear velocity";
function Language_t2dSceneObject53() { return $Lang_t2dSceneObject53[$pref::LanguageType]; }
//
$Lang_t2dSceneObject54[0]="��С";
$Lang_t2dSceneObject54[1]="Minimum";
function Language_t2dSceneObject54() { return $Lang_t2dSceneObject54[$pref::LanguageType]; }
//
$Lang_t2dSceneObject55[0]="���";
$Lang_t2dSceneObject55[1]="Maximum";
function Language_t2dSceneObject55() { return $Lang_t2dSceneObject55[$pref::LanguageType]; }
//
$Lang_t2dSceneObject56[0]="��Сֱ���ٶ�";
$Lang_t2dSceneObject56[1]="Min linear velocity";
function Language_t2dSceneObject56() { return $Lang_t2dSceneObject56[$pref::LanguageType]; }
//
$Lang_t2dSceneObject57[0]="���ٶ�";
$Lang_t2dSceneObject57[1]="Angular velocity";
function Language_t2dSceneObject57() { return $Lang_t2dSceneObject57[$pref::LanguageType]; }
//
$Lang_t2dSceneObject58[0]="���Ƕ���ת�ٶ�";
$Lang_t2dSceneObject58[1]="According to angular rotation velocity";
function Language_t2dSceneObject58() { return $Lang_t2dSceneObject58[$pref::LanguageType]; }
//
$Lang_t2dSceneObject59[0]="��С";
$Lang_t2dSceneObject59[1]="Minimum";
function Language_t2dSceneObject59() { return $Lang_t2dSceneObject59[$pref::LanguageType]; }
//
$Lang_t2dSceneObject60[0]="���";
$Lang_t2dSceneObject60[1]="Maximum";
function Language_t2dSceneObject60() { return $Lang_t2dSceneObject60[$pref::LanguageType]; }
//
$Lang_t2dSceneObject61[0]="��С���ٶ�";
$Lang_t2dSceneObject61[1]="Min angular velocity";
function Language_t2dSceneObject61() { return $Lang_t2dSceneObject61[$pref::LanguageType]; }
//
$Lang_t2dSceneObject62[0]="�����ƶ�";
$Lang_t2dSceneObject62[1]="Immovable";
function Language_t2dSceneObject62() { return $Lang_t2dSceneObject62[$pref::LanguageType]; }
//
$Lang_t2dSceneObject63[0]="�Ƿ�����������ƶ�";
$Lang_t2dSceneObject63[1]="Allow the object move or not";
function Language_t2dSceneObject63() { return $Lang_t2dSceneObject63[$pref::LanguageType]; }
//
$Lang_t2dSceneObject64[0]="����";
$Lang_t2dSceneObject64[1]="Constant force";
function Language_t2dSceneObject64() { return $Lang_t2dSceneObject64[$pref::LanguageType]; }
//
$Lang_t2dSceneObject65[0]="һֱ�����ڴ˾��������";
$Lang_t2dSceneObject65[1]="Continuous force on the Sprite";
function Language_t2dSceneObject65() { return $Lang_t2dSceneObject65[$pref::LanguageType]; }
//
$Lang_t2dSceneObject66[0]="����";
$Lang_t2dSceneObject66[1]="Orientation";
function Language_t2dSceneObject66() { return $Lang_t2dSceneObject66[$pref::LanguageType]; }
//
$Lang_t2dSceneObject67[0]="�ҽӳ���";
$Lang_t2dSceneObject67[1]="Mount orientation";
function Language_t2dSceneObject67() { return $Lang_t2dSceneObject67[$pref::LanguageType]; }
//
$Lang_t2dSceneObject68[0]="�Զ���ת";
$Lang_t2dSceneObject68[1]="Auto rotation";
function Language_t2dSceneObject68() { return $Lang_t2dSceneObject68[$pref::LanguageType]; }
//
$Lang_t2dSceneObject69[0]="�ڹҽӵ��Զ���ת";
$Lang_t2dSceneObject69[1]="Auto mount rotation";
function Language_t2dSceneObject69() { return $Lang_t2dSceneObject69[$pref::LanguageType]; }
//
$Lang_t2dSceneObject70[0]="������ת";
$Lang_t2dSceneObject70[1]="Track rotation";
function Language_t2dSceneObject70() { return $Lang_t2dSceneObject70[$pref::LanguageType]; }
//
$Lang_t2dSceneObject71[0]="����ҽ�����ת";
$Lang_t2dSceneObject71[1]="Mount track rotation";
function Language_t2dSceneObject71() { return $Lang_t2dSceneObject71[$pref::LanguageType]; }
//
$Lang_t2dSceneObject72[0]="�ɹҽ��߿���";
$Lang_t2dSceneObject72[1]="Mount owned";
function Language_t2dSceneObject72() { return $Lang_t2dSceneObject72[$pref::LanguageType]; }
//
$Lang_t2dSceneObject73[0]="�����ƣ���ҽ�����ʧ���������ʧ";
$Lang_t2dSceneObject73[1]="Owned,disappear with mount";
function Language_t2dSceneObject73() { return $Lang_t2dSceneObject73[$pref::LanguageType]; }
//
$Lang_t2dSceneObject74[0]="�̳�����";
$Lang_t2dSceneObject74[1]="Inherit attributes";
function Language_t2dSceneObject74() { return $Lang_t2dSceneObject74[$pref::LanguageType]; }
//
$Lang_t2dSceneObject75[0]="�̳йҽ��ߵ�����";
$Lang_t2dSceneObject75[1]="Inherit mount attributes";
function Language_t2dSceneObject75() { return $Lang_t2dSceneObject75[$pref::LanguageType]; }
//
$Lang_t2dSceneObject76[0]="����ģʽ";
$Lang_t2dSceneObject76[1]="Limit Mode";
function Language_t2dSceneObject76() { return $Lang_t2dSceneObject76[$pref::LanguageType]; }
//
$Lang_t2dSceneObject77[0]="�ֱ�Ϊ���رա��Զ��塢��ͣ����������ֹ��ɾ��";
$Lang_t2dSceneObject77[1]="Respectively:off,null,clamp,bounce,sticky,kill";
function Language_t2dSceneObject77() { return $Lang_t2dSceneObject77[$pref::LanguageType]; }
//
$Lang_t2dSceneObject78[0]="�߽����Ͻ�����";
$Lang_t2dSceneObject78[1]="Upper-left corner coordinate";
function Language_t2dSceneObject78() { return $Lang_t2dSceneObject78[$pref::LanguageType]; }
//
$Lang_t2dSceneObject79[0]="����߽�������Ϸ�������ֵ";
$Lang_t2dSceneObject79[1]="World Limit left and upward coordinate value";
function Language_t2dSceneObject79() { return $Lang_t2dSceneObject79[$pref::LanguageType]; }
//
$Lang_t2dSceneObject80[0]="�߽����½�����";
$Lang_t2dSceneObject80[1]="Bottom right corner coordinate";
function Language_t2dSceneObject80() { return $Lang_t2dSceneObject80[$pref::LanguageType]; }
//
$Lang_t2dSceneObject81[0]="����߽���Ҳ���·�������ֵ";
$Lang_t2dSceneObject81[1]="World limit right and downward coordinate value";
function Language_t2dSceneObject81() { return $Lang_t2dSceneObject81[$pref::LanguageType]; }
//
$Lang_t2dSceneObject82[0]="����";
$Lang_t2dSceneObject82[1]="Open";
function Language_t2dSceneObject82() { return $Lang_t2dSceneObject82[$pref::LanguageType]; }
//
$Lang_t2dSceneObject83[0]="����������ɫ����";
$Lang_t2dSceneObject83[1]="Open color post processing";
function Language_t2dSceneObject83() { return $Lang_t2dSceneObject83[$pref::LanguageType]; }
//
$Lang_t2dSceneObject84[0]="Դ�������";
$Lang_t2dSceneObject84[1]="Source blend factor";
function Language_t2dSceneObject84() { return $Lang_t2dSceneObject84[$pref::LanguageType]; }
//
$Lang_t2dSceneObject85[0]="Ŀ��������";
$Lang_t2dSceneObject85[1]="Dest blend factor";
function Language_t2dSceneObject85() { return $Lang_t2dSceneObject85[$pref::LanguageType]; }
//
$Lang_t2dSceneObject86[0]="������ɫ����";
$Lang_t2dSceneObject86[1]="Color post processing";
function Language_t2dSceneObject86() { return $Lang_t2dSceneObject86[$pref::LanguageType]; }
//
$Lang_t2dSceneObject87[0]="����ӿ�";
$Lang_t2dSceneObject87[1]="Program interface";
function Language_t2dSceneObject87() { return $Lang_t2dSceneObject87[$pref::LanguageType]; }
//
$Lang_t2dSceneObject88[0]="��������";
$Lang_t2dSceneObject88[1]="Base property";
function Language_t2dSceneObject88() { return $Lang_t2dSceneObject88[$pref::LanguageType]; }
//
$Lang_t2dSceneObject89[0]="Ѱ·";
$Lang_t2dSceneObject89[1]="Path finding";
function Language_t2dSceneObject89() { return $Lang_t2dSceneObject89[$pref::LanguageType]; }
//
$Lang_t2dSceneObject90[0]="��ײ";
$Lang_t2dSceneObject90[1]="Collision";
function Language_t2dSceneObject90() { return $Lang_t2dSceneObject90[$pref::LanguageType]; }
//
$Lang_t2dSceneObject91[0]="����";
$Lang_t2dSceneObject91[1]="Physics";
function Language_t2dSceneObject91() { return $Lang_t2dSceneObject91[$pref::LanguageType]; }
//
$Lang_t2dSceneObject92[0]="�ҽ�";
$Lang_t2dSceneObject92[1]="Mount";
function Language_t2dSceneObject92() { return $Lang_t2dSceneObject92[$pref::LanguageType]; }
//
$Lang_t2dSceneObject93[0]="����߽�����";
$Lang_t2dSceneObject93[1]="World Limit";
function Language_t2dSceneObject93() { return $Lang_t2dSceneObject93[$pref::LanguageType]; }
//
$Lang_t2dSceneObject94[0]="������ɫ����";
$Lang_t2dSceneObject94[1]="Color post processing";
function Language_t2dSceneObject94() { return $Lang_t2dSceneObject94[$pref::LanguageType]; }

//
$Lang_t2dSceneObjectSet0[0]="����";
$Lang_t2dSceneObjectSet0[1]="Coordinate";
function Language_t2dSceneObjectSet0() { return $Lang_t2dSceneObjectSet0[$pref::LanguageType]; }
//
$Lang_t2dSceneObjectSet1[0]="�������ĵ�����";
$Lang_t2dSceneObjectSet1[1]="Center coordinate";
function Language_t2dSceneObjectSet1() { return $Lang_t2dSceneObjectSet1[$pref::LanguageType]; }
//
$Lang_t2dSceneObjectSet2[0]="��С";
$Lang_t2dSceneObjectSet2[1]="Size";
function Language_t2dSceneObjectSet2() { return $Lang_t2dSceneObjectSet2[$pref::LanguageType]; }
//
$Lang_t2dSceneObjectSet3[0]="��";
$Lang_t2dSceneObjectSet3[1]="Width";
function Language_t2dSceneObjectSet3() { return $Lang_t2dSceneObjectSet3[$pref::LanguageType]; }
//
$Lang_t2dSceneObjectSet4[0]="��";
$Lang_t2dSceneObjectSet4[1]="Height";
function Language_t2dSceneObjectSet4() { return $Lang_t2dSceneObjectSet4[$pref::LanguageType]; }
//
$Lang_t2dSceneObjectSet5[0]="��С";
$Lang_t2dSceneObjectSet5[1]="Size";
function Language_t2dSceneObjectSet5() { return $Lang_t2dSceneObjectSet5[$pref::LanguageType]; }
//
$Lang_t2dSceneObjectSet6[0]="����";
$Lang_t2dSceneObjectSet6[1]="Orientation";
function Language_t2dSceneObjectSet6() { return $Lang_t2dSceneObjectSet6[$pref::LanguageType]; }
//
$Lang_t2dSceneObjectSet7[0]="����ĳ���";
$Lang_t2dSceneObjectSet7[1]="The whole orientation";
function Language_t2dSceneObjectSet7() { return $Lang_t2dSceneObjectSet7[$pref::LanguageType]; }
//
$Lang_t2dSceneObjectSet8[0]="ˮƽ��ת";
$Lang_t2dSceneObjectSet8[1]="Flip horizontal";
function Language_t2dSceneObjectSet8() { return $Lang_t2dSceneObjectSet8[$pref::LanguageType]; }
//
$Lang_t2dSceneObjectSet9[0]="ˮƽ��ת";
$Lang_t2dSceneObjectSet9[1]="Flip horizontal";
function Language_t2dSceneObjectSet9() { return $Lang_t2dSceneObjectSet9[$pref::LanguageType]; }
//
$Lang_t2dSceneObjectSet10[0]="��ֱ��ת";
$Lang_t2dSceneObjectSet10[1]="Flip vertical";
function Language_t2dSceneObjectSet10() { return $Lang_t2dSceneObjectSet10[$pref::LanguageType]; }
//
$Lang_t2dSceneObjectSet11[0]="��ֱ��ת";
$Lang_t2dSceneObjectSet11[1]="Flip vertical";
function Language_t2dSceneObjectSet11() { return $Lang_t2dSceneObjectSet11[$pref::LanguageType]; }
//
$Lang_t2dSceneObjectSet12[0]="��";
$Lang_t2dSceneObjectSet12[1]="Layer";
function Language_t2dSceneObjectSet12() { return $Lang_t2dSceneObjectSet12[$pref::LanguageType]; }
//
$Lang_t2dSceneObjectSet13[0]="��ʾ�Ĳ㼶";
$Lang_t2dSceneObjectSet13[1]="Layer show";
function Language_t2dSceneObjectSet13() { return $Lang_t2dSceneObjectSet13[$pref::LanguageType]; }
//
$Lang_t2dSceneObjectSet14[0]="ѡ�еľ��鼯";
$Lang_t2dSceneObjectSet14[1]="Scene Object Set";
function Language_t2dSceneObjectSet14() { return $Lang_t2dSceneObjectSet14[$pref::LanguageType]; }

//
$Lang_t2dScroller0[0]="ͼƬ";
$Lang_t2dScroller0[1]="Image";
function Language_t2dScroller0() { return $Lang_t2dScroller0[$pref::LanguageType]; }
//
$Lang_t2dScroller1[0]="�þ������ʾͼƬ";
$Lang_t2dScroller1[1]="The Sprite image shown";
function Language_t2dScroller1() { return $Lang_t2dScroller1[$pref::LanguageType]; }
//
$Lang_t2dScroller2[0]="�ظ�";
$Lang_t2dScroller2[1]="Repeat";
function Language_t2dScroller2() { return $Lang_t2dScroller2[$pref::LanguageType]; }
//
$Lang_t2dScroller3[0]="ͼƬ���ظ�����";
$Lang_t2dScroller3[1]="Repeat times";
function Language_t2dScroller3() { return $Lang_t2dScroller3[$pref::LanguageType]; }
//
$Lang_t2dScroller4[0]="�����ٶ�";
$Lang_t2dScroller4[1]="Scroll velocity";
function Language_t2dScroller4() { return $Lang_t2dScroller4[$pref::LanguageType]; }
//
$Lang_t2dScroller5[0]="ͼƬ�Ĺ����ٶ�";
$Lang_t2dScroller5[1]="Image scroll velocity";
function Language_t2dScroller5() { return $Lang_t2dScroller5[$pref::LanguageType]; }
//
$Lang_t2dScroller6[0]="����ͼ";
$Lang_t2dScroller6[1]="Scroller";
function Language_t2dScroller6() { return $Lang_t2dScroller6[$pref::LanguageType]; }

//
$Lang_t2dShapeVector0[0]="�༭�����";
$Lang_t2dShapeVector0[1]="Polygon Edit";
function Language_t2dShapeVector0() { return $Lang_t2dShapeVector0[$pref::LanguageType]; }
//
$Lang_t2dShapeVector1[0]="������ɫ";
$Lang_t2dShapeVector1[1]="Line color";
function Language_t2dShapeVector1() { return $Lang_t2dShapeVector1[$pref::LanguageType]; }
//
$Lang_t2dShapeVector2[0]="������ɫ";
$Lang_t2dShapeVector2[1]="Line color";
function Language_t2dShapeVector2() { return $Lang_t2dShapeVector2[$pref::LanguageType]; }
//
$Lang_t2dShapeVector3[0]="�������";
$Lang_t2dShapeVector3[1]="Fill polygon";
function Language_t2dShapeVector3() { return $Lang_t2dShapeVector3[$pref::LanguageType]; }
//
$Lang_t2dShapeVector4[0]="���ɫ";
$Lang_t2dShapeVector4[1]="Fill color";
function Language_t2dShapeVector4() { return $Lang_t2dShapeVector4[$pref::LanguageType]; }
//
$Lang_t2dShapeVector5[0]="���ɫ";
$Lang_t2dShapeVector5[1]="Fill color";
function Language_t2dShapeVector5() { return $Lang_t2dShapeVector5[$pref::LanguageType]; }
//
$Lang_t2dShapeVector6[0]="ʹ��͹������Ϊ�������ײ";
$Lang_t2dShapeVector6[1]="Use convex as polygon collision";
function Language_t2dShapeVector6() { return $Lang_t2dShapeVector6[$pref::LanguageType]; }
//
$Lang_t2dShapeVector7[0]="���������";
$Lang_t2dShapeVector7[1]="Shape Vector";
function Language_t2dShapeVector7() { return $Lang_t2dShapeVector7[$pref::LanguageType]; }

//
$Lang_t2dStaticSprite0[0]="ͼƬ";
$Lang_t2dStaticSprite0[1]="Image";
function Language_t2dStaticSprite0() { return $Lang_t2dStaticSprite0[$pref::LanguageType]; }
//
$Lang_t2dStaticSprite1[0]="�þ������ʾͼƬ";
$Lang_t2dStaticSprite1[1]="Sprite image show";
function Language_t2dStaticSprite1() { return $Lang_t2dStaticSprite1[$pref::LanguageType]; }
//
$Lang_t2dStaticSprite2[0]="֡";
$Lang_t2dStaticSprite2[1]="Frame";
function Language_t2dStaticSprite2() { return $Lang_t2dStaticSprite2[$pref::LanguageType]; }
//
$Lang_t2dStaticSprite3[0]="ͼƬ֡��";
$Lang_t2dStaticSprite3[1]="Image frame number";
function Language_t2dStaticSprite3() { return $Lang_t2dStaticSprite3[$pref::LanguageType]; }
//
$Lang_t2dStaticSprite4[0]="��̬����";
$Lang_t2dStaticSprite4[1]="Static Sprite";
function Language_t2dStaticSprite4() { return $Lang_t2dStaticSprite4[$pref::LanguageType]; }

//
$Lang_t2dTextObject0[0]="����";
$Lang_t2dTextObject0[1]="Font";
function Language_t2dTextObject0() { return $Lang_t2dTextObject0[$pref::LanguageType]; }
//
$Lang_t2dTextObject1[0]="���뷽ʽ";
$Lang_t2dTextObject1[1]="Alignment";
function Language_t2dTextObject1() { return $Lang_t2dTextObject1[$pref::LanguageType]; }
//
$Lang_t2dTextObject2[0]="���ָ߶�";
$Lang_t2dTextObject2[1]="Character height";
function Language_t2dTextObject2() { return $Lang_t2dTextObject2[$pref::LanguageType]; }
//
$Lang_t2dTextObject3[0]="�߶μ��";
$Lang_t2dTextObject3[1]="Line spacing";
function Language_t2dTextObject3() { return $Lang_t2dTextObject3[$pref::LanguageType]; }
//
$Lang_t2dTextObject4[0]="���ּ��";
$Lang_t2dTextObject4[1]="Character spacing";
function Language_t2dTextObject4() { return $Lang_t2dTextObject4[$pref::LanguageType]; }
//
$Lang_t2dTextObject5[0]="ˮƽ����";
$Lang_t2dTextObject5[1]="Horizontal scaling";
function Language_t2dTextObject5() { return $Lang_t2dTextObject5[$pref::LanguageType]; }
//
$Lang_t2dTextObject6[0]="������ģʽ";
$Lang_t2dTextObject6[1]="Word wrap mode";
function Language_t2dTextObject6() { return $Lang_t2dTextObject6[$pref::LanguageType]; }
//
$Lang_t2dTextObject7[0]="���س����߽��";
$Lang_t2dTextObject7[1]="Hide overflow";
function Language_t2dTextObject7() { return $Lang_t2dTextObject7[$pref::LanguageType]; }
//
$Lang_t2dTextObject8[0]="˫���Թ���";
$Lang_t2dTextObject8[1]="Bilinear filter";
function Language_t2dTextObject8() { return $Lang_t2dTextObject8[$pref::LanguageType]; }
//
$Lang_t2dTextObject9[0]="�������߹ر�˫���Թ��˲�ֵ";
$Lang_t2dTextObject9[1]="Start or shut Bilinear filter interpolation";
function Language_t2dTextObject9() { return $Lang_t2dTextObject9[$pref::LanguageType]; }
//
$Lang_t2dTextObject10[0]="����������С";
$Lang_t2dTextObject10[1]="Snap to integer";
function Language_t2dTextObject10() { return $Lang_t2dTextObject10[$pref::LanguageType]; }
//
$Lang_t2dTextObject11[0]="����������С����������ְ�����ش�С";
$Lang_t2dTextObject11[1]="Snap to integer,Not allow half pixel";
function Language_t2dTextObject11() { return $Lang_t2dTextObject11[$pref::LanguageType]; }
//
$Lang_t2dTextObject12[0]="���־���";
$Lang_t2dTextObject12[1]="Text Sprite";
function Language_t2dTextObject12() { return $Lang_t2dTextObject12[$pref::LanguageType]; }

//
$Lang_t2dTileLayer0[0]="�Զ�ƽ��";
$Lang_t2dTileLayer0[1]="Auto pan";
function Language_t2dTileLayer0() { return $Lang_t2dTileLayer0[$pref::LanguageType]; }
//
$Lang_t2dTileLayer1[0]="�Զ�ƽ��";
$Lang_t2dTileLayer1[1]="Auto pan";
function Language_t2dTileLayer1() { return $Lang_t2dTileLayer1[$pref::LanguageType]; }
//
$Lang_t2dTileLayer2[0]="ƽ������";
$Lang_t2dTileLayer2[1]="Pan coordinate";
function Language_t2dTileLayer2() { return $Lang_t2dTileLayer2[$pref::LanguageType]; }
//
$Lang_t2dTileLayer3[0]="ƽ������";
$Lang_t2dTileLayer3[1]="Pan coordinate";
function Language_t2dTileLayer3() { return $Lang_t2dTileLayer3[$pref::LanguageType]; }
//
$Lang_t2dTileLayer4[0]="��� X";
$Lang_t2dTileLayer4[1]="Wrap X";
function Language_t2dTileLayer4() { return $Lang_t2dTileLayer4[$pref::LanguageType]; }
//
$Lang_t2dTileLayer5[0]="��� Y";
$Lang_t2dTileLayer5[1]="Wrap Y";
function Language_t2dTileLayer5() { return $Lang_t2dTileLayer5[$pref::LanguageType]; }
//
$Lang_t2dTileLayer6[0]="ƽ������";
$Lang_t2dTileLayer6[1]="Tile number";
function Language_t2dTileLayer6() { return $Lang_t2dTileLayer6[$pref::LanguageType]; }
//
$Lang_t2dTileLayer7[0]="ƽ������";
$Lang_t2dTileLayer7[1]="Tile number";
function Language_t2dTileLayer7() { return $Lang_t2dTileLayer7[$pref::LanguageType]; }
//
$Lang_t2dTileLayer8[0]="ƽ�̴�С";
$Lang_t2dTileLayer8[1]="Tile size";
function Language_t2dTileLayer8() { return $Lang_t2dTileLayer8[$pref::LanguageType]; }
//
$Lang_t2dTileLayer9[0]="ƽ�̴�С";
$Lang_t2dTileLayer9[1]="Tile size";
function Language_t2dTileLayer9() { return $Lang_t2dTileLayer9[$pref::LanguageType]; }
//
$Lang_t2dTileLayer10[0]="�����С��㼶һ��";
$Lang_t2dTileLayer10[1]="Sprite size is in line with layer";
function Language_t2dTileLayer10() { return $Lang_t2dTileLayer10[$pref::LanguageType]; }
//
$Lang_t2dTileLayer11[0]="�༭ƽ�̲㼶";
$Lang_t2dTileLayer11[1]="Edit tile layer";
function Language_t2dTileLayer11() { return $Lang_t2dTileLayer11[$pref::LanguageType]; }
//
$Lang_t2dTileLayer12[0]="��ˢ";
$Lang_t2dTileLayer12[1]="Brush";
function Language_t2dTileLayer12() { return $Lang_t2dTileLayer12[$pref::LanguageType]; }
//
$Lang_t2dTileLayer13[0]="ͼƬ";
$Lang_t2dTileLayer13[1]="Image";
function Language_t2dTileLayer13() { return $Lang_t2dTileLayer13[$pref::LanguageType]; }
//
$Lang_t2dTileLayer14[0]="֡��";
$Lang_t2dTileLayer14[1]="Frame number";
function Language_t2dTileLayer14() { return $Lang_t2dTileLayer14[$pref::LanguageType]; }
//
$Lang_t2dTileLayer15[0]="ƽ��ͼ�ű�";
$Lang_t2dTileLayer15[1]="Tile script";
function Language_t2dTileLayer15() { return $Lang_t2dTileLayer15[$pref::LanguageType]; }
//
$Lang_t2dTileLayer16[0]="�Զ�������";
$Lang_t2dTileLayer16[1]="Custom data";
function Language_t2dTileLayer16() { return $Lang_t2dTileLayer16[$pref::LanguageType]; }
//
$Lang_t2dTileLayer17[0]="ˮƽ��ת";
$Lang_t2dTileLayer17[1]="Flip  horizontal";
function Language_t2dTileLayer17() { return $Lang_t2dTileLayer17[$pref::LanguageType]; }
//
$Lang_t2dTileLayer18[0]="��ֱ��ת";
$Lang_t2dTileLayer18[1]="Flip vertical";
function Language_t2dTileLayer18() { return $Lang_t2dTileLayer18[$pref::LanguageType]; }
//
$Lang_t2dTileLayer19[0]="������ײ";
$Lang_t2dTileLayer19[1]="Enable collision";
function Language_t2dTileLayer19() { return $Lang_t2dTileLayer19[$pref::LanguageType]; }
//
$Lang_t2dTileLayer20[0]="Ӧ����ѡ���ͼ��";
$Lang_t2dTileLayer20[1]="Apply to chosen block";
function Language_t2dTileLayer20() { return $Lang_t2dTileLayer20[$pref::LanguageType]; }
//
$Lang_t2dTileLayer21[0]="�����ˢ";
$Lang_t2dTileLayer21[1]="Save brush";
function Language_t2dTileLayer21() { return $Lang_t2dTileLayer21[$pref::LanguageType]; }
//
$Lang_t2dTileLayer22[0]="ɾ����ˢ";
$Lang_t2dTileLayer22[1]="Delete brush";
function Language_t2dTileLayer22() { return $Lang_t2dTileLayer22[$pref::LanguageType]; }
//
$Lang_t2dTileLayer23[0]="����";
$Lang_t2dTileLayer23[1]="Warning";
function Language_t2dTileLayer23() { return $Lang_t2dTileLayer23[$pref::LanguageType]; }
//
$Lang_t2dTileLayer24[0]="����ƽ��������ɾ���㼶�߽����ƽ��ͼ���˲��������棬����?";
$Lang_t2dTileLayer24[1]="Tile number reduce would delete tile image outside layer boundary,it's irreversible,continue?";
function Language_t2dTileLayer24() { return $Lang_t2dTileLayer24[$pref::LanguageType]; }
//
$Lang_t2dTileLayer25[0]="����";
$Lang_t2dTileLayer25[1]="Warning";
function Language_t2dTileLayer25() { return $Lang_t2dTileLayer25[$pref::LanguageType]; }
//
$Lang_t2dTileLayer26[0]="����ƽ��������ɾ���㼶�߽����ƽ��ͼ���˲��������棬����?";
$Lang_t2dTileLayer26[1]="Tile number reduce would delete tile image outside layer boundary,it's irreversible,continue?";
function Language_t2dTileLayer26() { return $Lang_t2dTileLayer26[$pref::LanguageType]; }
//
$Lang_t2dTileLayer27[0]="ƽ��ͼ";
$Lang_t2dTileLayer27[1]="Tile Layer";
function Language_t2dTileLayer27() { return $Lang_t2dTileLayer27[$pref::LanguageType]; }
//
$Lang_t2dTileLayer28[0]="ƽ��ͼ�༭";
$Lang_t2dTileLayer28[1]="Tile Layer Edit";
function Language_t2dTileLayer28() { return $Lang_t2dTileLayer28[$pref::LanguageType]; }

//
$Lang_t2dTileLayer29[0]="ѡ��";
$Lang_t2dTileLayer29[1]="Select";
function Language_t2dTileLayer29() { return $Lang_t2dTileLayer29[$pref::LanguageType]; }
//
$Lang_t2dTileLayer30[0]="��Ϳ";
$Lang_t2dTileLayer30[1]="Paint";
function Language_t2dTileLayer30() { return $Lang_t2dTileLayer30[$pref::LanguageType]; }
//
$Lang_t2dTileLayer31[0]="�����";
$Lang_t2dTileLayer31[1]="Flood";
function Language_t2dTileLayer31() { return $Lang_t2dTileLayer31[$pref::LanguageType]; }
//
$Lang_t2dTileLayer32[0]="��ȡͼƬ";
$Lang_t2dTileLayer32[1]="Pick Image";
function Language_t2dTileLayer32() { return $Lang_t2dTileLayer32[$pref::LanguageType]; }
//
$Lang_t2dTileLayer33[0]="��Ƥ��";
$Lang_t2dTileLayer33[1]="Eraser";
function Language_t2dTileLayer33() { return $Lang_t2dTileLayer33[$pref::LanguageType]; }

//
$Lang_t2dTrigger0[0]="����ʱ����";
$Lang_t2dTrigger0[1]="Trigger On Enter";
function Language_t2dTrigger0() { return $Lang_t2dTrigger0[$pref::LanguageType]; }
//
$Lang_t2dTrigger1[0]="���о�����봥�����ڲ�ʱ��������Ӧ����";
$Lang_t2dTrigger1[1]="When Sprite enter the trigger,trigger function";
function Language_t2dTrigger1() { return $Lang_t2dTrigger1[$pref::LanguageType]; }
//
$Lang_t2dTrigger2[0]="ͣ��ʱ����";
$Lang_t2dTrigger2[1]="Trigger On Stay";
function Language_t2dTrigger2() { return $Lang_t2dTrigger2[$pref::LanguageType]; }
//
$Lang_t2dTrigger3[0]="���о���ͣ���ڴ������ڲ�ʱ��������Ӧ����";
$Lang_t2dTrigger3[1]="When Sprite stay in the trigger,trigger function";
function Language_t2dTrigger3() { return $Lang_t2dTrigger3[$pref::LanguageType]; }
//
$Lang_t2dTrigger4[0]="�뿪ʱ����";
$Lang_t2dTrigger4[1]="Trigger On Leave";
function Language_t2dTrigger4() { return $Lang_t2dTrigger4[$pref::LanguageType]; }
//
$Lang_t2dTrigger5[0]="���о����뿪������ʱ��������Ӧ����";
$Lang_t2dTrigger5[1]="When Sprite leave the trigger,trigger function";
function Language_t2dTrigger5() { return $Lang_t2dTrigger5[$pref::LanguageType]; }
//
$Lang_t2dTrigger6[0]="������";
$Lang_t2dTrigger6[1]="Trigger";
function Language_t2dTrigger6() { return $Lang_t2dTrigger6[$pref::LanguageType]; }

//
$Lang_projectManPanel0[0]="�ָ�����ʼ��ͼ";
$Lang_projectManPanel0[1]="Reset to original map";
function Language_projectManPanel0() { return $Lang_projectManPanel0[$pref::LanguageType]; }
//
$Lang_projectManPanel1[0]="�򿪹����ļ���";
$Lang_projectManPanel1[1]="Open project folder";
function Language_projectManPanel1() { return $Lang_projectManPanel1[$pref::LanguageType]; }
//
$Lang_projectManPanel2[0]="����VC����";
$Lang_projectManPanel2[1]="Start VC project";
function Language_projectManPanel2() { return $Lang_projectManPanel2[$pref::LanguageType]; }
//
$Lang_projectManPanel3[0]="��������VC����";
$Lang_projectManPanel3[1]="Set start VC project";
function Language_projectManPanel3() { return $Lang_projectManPanel3[$pref::LanguageType]; }
//
$Lang_projectManPanel4[0]="����VC����";
$Lang_projectManPanel4[1]="Create VC project";
function Language_projectManPanel4() { return $Lang_projectManPanel4[$pref::LanguageType]; }

//
$Lang_sideBarClassConfigLink0[0]="��������ӽű���������";
$Lang_sideBarClassConfigLink0[1]="Panel link script to object";
function Language_sideBarClassConfigLink0() { return $Lang_sideBarClassConfigLink0[$pref::LanguageType]; }
//
$Lang_sideBarClassConfigLink1[0]="��";
$Lang_sideBarClassConfigLink1[1]="Class";
function Language_sideBarClassConfigLink1() { return $Lang_sideBarClassConfigLink1[$pref::LanguageType]; }

//
$Lang_sideBarContentManagement0[0]="���һ���µ�ͼƬ��Դ";
$Lang_sideBarContentManagement0[1]="Add new image resource";
function Language_sideBarContentManagement0() { return $Lang_sideBarContentManagement0[$pref::LanguageType]; }
//
$Lang_sideBarContentManagement1[0]="���һ���µĶ���";
$Lang_sideBarContentManagement1[1]="Add a new animation";
function Language_sideBarContentManagement1() { return $Lang_sideBarContentManagement1[$pref::LanguageType]; }
//
$Lang_sideBarContentManagement2[0]="���һ���µ�������Ч";
$Lang_sideBarContentManagement2[1]="Add a new particle effect";
function Language_sideBarContentManagement2() { return $Lang_sideBarContentManagement2[$pref::LanguageType]; }
//
$Lang_sideBarContentManagement3[0]="���һ���µ�����";
$Lang_sideBarContentManagement3[1]="Add new music";
function Language_sideBarContentManagement3() { return $Lang_sideBarContentManagement3[$pref::LanguageType]; }
//
$Lang_sideBarContentManagement4[0]="������ͼƬ";
$Lang_sideBarContentManagement4[1]="Import new image";
function Language_sideBarContentManagement4() { return $Lang_sideBarContentManagement4[$pref::LanguageType]; }
//
$Lang_sideBarContentManagement5[0]="�����¶���";
$Lang_sideBarContentManagement5[1]="Create new animation";
function Language_sideBarContentManagement5() { return $Lang_sideBarContentManagement5[$pref::LanguageType]; }
//
$Lang_sideBarContentManagement6[0]="��ͼ����ɾ��ͼƬ";
$Lang_sideBarContentManagement6[1]="Delete image from gallery";
function Language_sideBarContentManagement6() { return $Lang_sideBarContentManagement6[$pref::LanguageType]; }
//
$Lang_sideBarContentManagement7[0]="��קһ��ͼƬ����ɾ��";
$Lang_sideBarContentManagement7[1]="Drag an image here to delete";
function Language_sideBarContentManagement7() { return $Lang_sideBarContentManagement7[$pref::LanguageType]; }
//
$Lang_sideBarContentManagement8[0]="��קһ��ͼƬ����ɾ��";
$Lang_sideBarContentManagement8[1]="Drag an image here to delete";
function Language_sideBarContentManagement8() { return $Lang_sideBarContentManagement8[$pref::LanguageType]; }
//
$Lang_sideBarContentManagement9[0]="ȷ��ɾ������Դ?";
$Lang_sideBarContentManagement9[1]="Confirm delete the resource?";
function Language_sideBarContentManagement9() { return $Lang_sideBarContentManagement9[$pref::LanguageType]; }
//
$Lang_sideBarContentManagement10[0]="��";
$Lang_sideBarContentManagement10[1]="There";
function Language_sideBarContentManagement10() { return $Lang_sideBarContentManagement10[$pref::LanguageType]; }
//
$Lang_sideBarContentManagement11[0]="���������õ�����Դ. �������Դ��ɾ���������õ��ĵ�ͼ����Ҳ�ᱻɾ��. �Ƿ����?";
$Lang_sideBarContentManagement11[1]="Sprite use the resource,if resource delete,the scene Sprite would be deleted,continue?";
function Language_sideBarContentManagement11() { return $Lang_sideBarContentManagement11[$pref::LanguageType]; }
//
$Lang_sideBarContentManagement12[0]="ȷ��ɾ���˶���?";
$Lang_sideBarContentManagement12[1]="Sure to delete the animation?";
function Language_sideBarContentManagement12() { return $Lang_sideBarContentManagement12[$pref::LanguageType]; }
//
$Lang_sideBarContentManagement13[0]="��";
$Lang_sideBarContentManagement13[1]="There";
function Language_sideBarContentManagement13() { return $Lang_sideBarContentManagement13[$pref::LanguageType]; }
//
$Lang_sideBarContentManagement14[0]="���������õ��˶���. ����˶�����ɾ���������õ��ĵ�ͼ����Ҳ�ᱻɾ��.�Ƿ����?";
$Lang_sideBarContentManagement14[1]="Sprite use the animation,if animation delete,the scene Sprite would be deleted,continue?";
function Language_sideBarContentManagement14() { return $Lang_sideBarContentManagement14[$pref::LanguageType]; }
//
$Lang_sideBarContentManagement15[0]="ɾ������";
$Lang_sideBarContentManagement15[1]="Delete Sprite";
function Language_sideBarContentManagement15() { return $Lang_sideBarContentManagement15[$pref::LanguageType]; }
//
$Lang_sideBarContentManagement16[0]="�о���ʹ�õ��˲㼶,�������, ��þ���Ҳ����ɾ��. �Ƿ����?";
$Lang_sideBarContentManagement16[1]="Sprite use the layer,if continue,the Sprite would be deleted,continue?";
function Language_sideBarContentManagement16() { return $Lang_sideBarContentManagement16[$pref::LanguageType]; }
//
$Lang_sideBarContentManagement17[0]="ɾ������";
$Lang_sideBarContentManagement17[1]="Delete Sprite";
function Language_sideBarContentManagement17() { return $Lang_sideBarContentManagement17[$pref::LanguageType]; }
//
$Lang_sideBarContentManagement18[0]="�о������õ�����Ч. �������, �����ЧҲ�ᱻɾ��. �Ƿ����?";
$Lang_sideBarContentManagement18[1]="Sprite use the effect,if continue,the effect would be deleted,continue?";
function Language_sideBarContentManagement18() { return $Lang_sideBarContentManagement18[$pref::LanguageType]; }
//
$Lang_sideBarContentManagement19[0]="�Ƿ񱣴��������� ";
$Lang_sideBarContentManagement19[1]="Save the changes ";
function Language_sideBarContentManagement19() { return $Lang_sideBarContentManagement19[$pref::LanguageType]; }
//
$Lang_sideBarContentManagement20[0]="ɾ����ͼ";
$Lang_sideBarContentManagement20[1]="Delete Mapping";
function Language_sideBarContentManagement20() { return $Lang_sideBarContentManagement20[$pref::LanguageType]; }
//
$Lang_sideBarContentManagement21[0]="ɾ��ͼƬ";
$Lang_sideBarContentManagement21[1]="Delete Image";
function Language_sideBarContentManagement21() { return $Lang_sideBarContentManagement21[$pref::LanguageType]; }
//
$Lang_sideBarContentManagement22[0]="ɾ������";
$Lang_sideBarContentManagement22[1]="Delete Animation";
function Language_sideBarContentManagement22() { return $Lang_sideBarContentManagement22[$pref::LanguageType]; }
//
$Lang_sideBarCreate0[0]="��Դ";
$Lang_sideBarCreate0[1]="Resource";
function Language_sideBarCreate0() { return $Lang_sideBarCreate0[$pref::LanguageType]; }

//
$Lang_sideBarHistoryView0[0]="������ʷ";
$Lang_sideBarHistoryView0[1]="Cancel history";
function Language_sideBarHistoryView0() { return $Lang_sideBarHistoryView0[$pref::LanguageType]; }

//
$Lang_sideBarProject0[0]="��Ŀ";
$Lang_sideBarProject0[1]="Project";
function Language_sideBarProject0() { return $Lang_sideBarProject0[$pref::LanguageType]; }

//
$Lang_sideBarQuickEdit0[0]="�༭";
$Lang_sideBarQuickEdit0[1]="Edit";
function Language_sideBarQuickEdit0() { return $Lang_sideBarQuickEdit0[$pref::LanguageType]; }

//
$Lang_sideBarTreeView0[0]="��Ŀ����";
$Lang_sideBarTreeView0[1]="Project management";
function Language_sideBarTreeView0() { return $Lang_sideBarTreeView0[$pref::LanguageType]; }
//
$Lang_sideBarTreeView1[0]="�����б�";
$Lang_sideBarTreeView1[1]="Sprites list";
function Language_sideBarTreeView1() { return $Lang_sideBarTreeView1[$pref::LanguageType]; }

//
$Lang_toolPropertiesSelection0[0]="ȫ������ѡ��";
$Lang_toolPropertiesSelection0[1]="Select from all forms";
function Language_toolPropertiesSelection0() { return $Lang_toolPropertiesSelection0[$pref::LanguageType]; }
//
$Lang_toolPropertiesSelection1[0]="���뵽����";
$Lang_toolPropertiesSelection1[1]="Snap to grid";
function Language_toolPropertiesSelection1() { return $Lang_toolPropertiesSelection1[$pref::LanguageType]; }

//
$Lang_lbStaticSpriteThumbnailPopup0[0]="��̬����(Sprites)...";
$Lang_lbStaticSpriteThumbnailPopup0[1]="Static sprites...";
function Language_lbStaticSpriteThumbnailPopup0() { return $Lang_lbStaticSpriteThumbnailPopup0[$pref::LanguageType]; }
//
$Lang_lbStaticSpriteThumbnailPopup1[0]="֡...";
$Lang_lbStaticSpriteThumbnailPopup1[1]="Frame...";
function Language_lbStaticSpriteThumbnailPopup1() { return $Lang_lbStaticSpriteThumbnailPopup1[$pref::LanguageType]; }

//
$Lang_scripts_edit0[0]="ע��";
$Lang_scripts_edit0[1]="Attention";
function Language_scirpts_edit0() { return $Lang_scripts_edit0[$pref::LanguageType]; }
//
$Lang_scripts_edit1[0]="��ǰ�򿪵�ͼ���ָ�����һ�δ�ʱ״̬���Ƿ�ȷ����";
$Lang_scripts_edit1[1]="The current map would return to the beginning when it's opened,confirm?";
function Language_scirpts_edit1() { return $Lang_scripts_edit1[$pref::LanguageType]; }
//
$Lang_scripts_edit2[0]="����";
$Lang_scripts_edit2[1]="Error";
function Language_scirpts_edit2() { return $Lang_scripts_edit2[$pref::LanguageType]; }
//
$Lang_scripts_edit3[0]="������������Java����";
$Lang_scripts_edit3[1]="Please Set start Java project";
function Language_scirpts_edit3() { return $Lang_scripts_edit3[$pref::LanguageType]; }
//
$Lang_scripts_edit4[0]="����";
$Lang_scripts_edit4[1]="Error";
function Language_scirpts_edit4() { return $Lang_scripts_edit4[$pref::LanguageType]; }
//
$Lang_scripts_edit5[0]="�޷��򿪹����ļ�! ��ȷ���Ѿ���װJCreator�����";
$Lang_scripts_edit5[1]="Project file cannot be opened,please check that JCreator software has been installed.";
function Language_scirpts_edit5() { return $Lang_scripts_edit5[$pref::LanguageType]; }
//
$Lang_scripts_edit6[0]="����";
$Lang_scripts_edit6[1]="Error";
function Language_scirpts_edit6() { return $Lang_scripts_edit6[$pref::LanguageType]; }
//
$Lang_scripts_edit7[0]="�޷��򿪹����ļ�! ��ȷ���Ƿ��Ѿ������ð汾�����ļ���";
$Lang_scripts_edit7[1]="Project file cannot be opened,please check that the  project file of this version has been created.";
function Language_scirpts_edit7() { return $Lang_scripts_edit7[$pref::LanguageType]; }
//
$Lang_scripts_edit8[0]="����";
$Lang_scripts_edit8[1]="Error";
function Language_scirpts_edit8() { return $Lang_scripts_edit8[$pref::LanguageType]; }
//
$Lang_scripts_edit9[0]="��������Eclipse.exe��λ�á�";
$Lang_scripts_edit9[1]="Please set Eclipse.exe position first.";
function Language_scirpts_edit9() { return $Lang_scripts_edit9[$pref::LanguageType]; }
//
$Lang_scripts_edit10[0]="����";
$Lang_scripts_edit10[1]="Error";
function Language_scirpts_edit10() { return $Lang_scripts_edit10[$pref::LanguageType]; }
//
$Lang_scripts_edit11[0]="ָ����Eclipse��Ч [";
$Lang_scripts_edit11[1]="Assigned Eclipse is invalid [";
function Language_scirpts_edit11() { return $Lang_scripts_edit11[$pref::LanguageType]; }
//
$Lang_scripts_edit12[0]="] ��������ָ��Eclipse.exeλ�á�";
$Lang_scripts_edit12[1]="],appoint Eclipse.exe position again";
function Language_scirpts_edit12() { return $Lang_scripts_edit12[$pref::LanguageType]; }
//
$Lang_scripts_edit13[0]="����";
$Lang_scripts_edit13[1]="Error";
function Language_scirpts_edit13() { return $Lang_scripts_edit13[$pref::LanguageType]; }
//
$Lang_scripts_edit14[0]="�޷��ҵ�Eclipse��� [";
$Lang_scripts_edit14[1]="Eclipse software[";
function Language_scirpts_edit14() { return $Lang_scripts_edit14[$pref::LanguageType]; }
//
$Lang_scripts_edit15[0]="] ��������ָ��Eclipse.exeλ�á�";
$Lang_scripts_edit15[1]="], cannot be found,appoint Eclipse.exe position again";
function Language_scirpts_edit15() { return $Lang_scripts_edit15[$pref::LanguageType]; }
//
$Lang_scripts_edit16[0]="����";
$Lang_scripts_edit16[1]="Error";
function Language_scirpts_edit16() { return $Lang_scripts_edit16[$pref::LanguageType]; }
//
$Lang_scripts_edit17[0]="�޷��򿪹����ļ�! ��ȷ���Ƿ��Ѿ������ð汾�����ļ���";
$Lang_scripts_edit17[1]="Project file cannot be opened!please check that the  project file of this version has been created.";
function Language_scirpts_edit17() { return $Lang_scripts_edit17[$pref::LanguageType]; }
//
$Lang_scripts_edit18[0]="��ȷ��VC2015�Ѿ���װ�������Ѿ�����VC2015·����";
$Lang_scripts_edit18[1]="Please check that VC2015 has been installed or set";
function Language_scirpts_edit18() { return $Lang_scripts_edit18[$pref::LanguageType]; }
//
$Lang_scripts_edit19[0]="������������VC����";
$Lang_scripts_edit19[1]="Please set start VC project";
function Language_scirpts_edit19() { return $Lang_scripts_edit19[$pref::LanguageType]; }
//
$Lang_scripts_edit20[0]="������������VB����";
$Lang_scripts_edit20[1]="Please set start VB project";
function Language_scirpts_edit20() { return $Lang_scripts_edit20[$pref::LanguageType]; }
//
$Lang_scripts_edit21[0]="��ȷ��VC6�Ѿ���װ�������Ѿ�����VC6·����";
$Lang_scripts_edit21[1]="Please check that VC6 has been installed or set";
function Language_scirpts_edit21() { return $Lang_scripts_edit21[$pref::LanguageType]; }
//
$Lang_scripts_edit22[0]="����";
$Lang_scripts_edit22[1]="Error";
function Language_scirpts_edit22() { return $Lang_scripts_edit22[$pref::LanguageType]; }
//
$Lang_scripts_edit23[0]="δ�����ð汾�����ļ���";
$Lang_scripts_edit23[1]="The project file of this version has not been created.";
function Language_scirpts_edit23() { return $Lang_scripts_edit23[$pref::LanguageType]; }
//
$Lang_scripts_edit24[0]="����";
$Lang_scripts_edit24[1]="Error";
function Language_scirpts_edit24() { return $Lang_scripts_edit24[$pref::LanguageType]; }
//
$Lang_scripts_edit25[0]="�޷��򿪹����ļ�! ��ȷ���Ƿ��Ѿ������ð汾�����ļ���";
$Lang_scripts_edit25[1]="Project file cannot be opened,please check that the  project file of this version has been created.";
function Language_scirpts_edit25() { return $Lang_scripts_edit25[$pref::LanguageType]; }
//
$Lang_scripts_edit26[0]="����";
$Lang_scripts_edit26[1]="Error";
function Language_scirpts_edit26() { return $Lang_scripts_edit26[$pref::LanguageType]; }
//
$Lang_scripts_edit27[0]="��ȷ��CodeBlock�Ѿ���װ�������Ѿ�����CodeBlock·����";
$Lang_scripts_edit27[1]="Please check that CodeBlock has been installed or Code Block path has been set";
function Language_scirpts_edit27() { return $Lang_scripts_edit27[$pref::LanguageType]; }
//
$Lang_scripts_edit28[0]="����";
$Lang_scripts_edit28[1]="Error";
function Language_scirpts_edit28() { return $Lang_scripts_edit28[$pref::LanguageType]; }
//
$Lang_scripts_edit29[0]="δ�����ð汾�����ļ���";
$Lang_scripts_edit29[1]="The project file of this version has not been created.";
function Language_scirpts_edit29() { return $Lang_scripts_edit29[$pref::LanguageType]; }
//
$Lang_scripts_edit30[0]="����";
$Lang_scripts_edit30[1]="Error";
function Language_scirpts_edit30() { return $Lang_scripts_edit30[$pref::LanguageType]; }
//
$Lang_scripts_edit31[0]="�޷��򿪹����ļ�! ��ȷ���Ƿ��Ѿ������ð汾�����ļ���";
$Lang_scripts_edit31[1]="Project file cannot be opened,please check that the  project file of this version has been created.";
function Language_scirpts_edit31() { return $Lang_scripts_edit31[$pref::LanguageType]; }
//
$Lang_scripts_edit32[0]="����";
$Lang_scripts_edit32[1]="Error";
function Language_scirpts_edit32() { return $Lang_scripts_edit32[$pref::LanguageType]; }
//
$Lang_scripts_edit33[0]="��ȷ��VC2015�Ѿ���װ�������Ѿ�����VC2015·����";
$Lang_scripts_edit33[1]="Please check that VC2015 has been installed or VC2015 path has been set";
function Language_scirpts_edit33() { return $Lang_scripts_edit33[$pref::LanguageType]; }
//
$Lang_scripts_edit34[0]="����";
$Lang_scripts_edit34[1]="Error";
function Language_scirpts_edit34() { return $Lang_scripts_edit34[$pref::LanguageType]; }
//
$Lang_scripts_edit35[0]="δ�����ð汾�����ļ���";
$Lang_scripts_edit35[1]="The project file of this version has not been created";
function Language_scirpts_edit35() { return $Lang_scripts_edit35[$pref::LanguageType]; }
//
$Lang_scripts_edit36[0]="����";
$Lang_scripts_edit36[1]="Error";
function Language_scirpts_edit36() { return $Lang_scripts_edit36[$pref::LanguageType]; }
//
$Lang_scripts_edit37[0]="�޷��򿪹����ļ�! ��ȷ���Ƿ��Ѿ������ð汾�����ļ���";
$Lang_scripts_edit37[1]="Project file cannot be opened,please check that the  project file of this version has been created";
function Language_scirpts_edit37() { return $Lang_scripts_edit37[$pref::LanguageType]; }
//
$Lang_scripts_edit38[0]="����";
$Lang_scripts_edit38[1]="Error";
function Language_scirpts_edit38() { return $Lang_scripts_edit38[$pref::LanguageType]; }
//
$Lang_scripts_edit39[0]="��ȷ��VC2012�Ѿ���װ�������Ѿ�����VC2012·����";
$Lang_scripts_edit39[1]="Please check that VC2012 has been installed or VC2012 path has been set";
function Language_scirpts_edit39() { return $Lang_scripts_edit39[$pref::LanguageType]; }
//
$Lang_scripts_edit40[0]="����";
$Lang_scripts_edit40[1]="Error";
function Language_scirpts_edit40() { return $Lang_scripts_edit40[$pref::LanguageType]; }
//
$Lang_scripts_edit41[0]="δ�����ð汾�����ļ���";
$Lang_scripts_edit41[1]="The project file of this version has not been created";
function Language_scirpts_edit41() { return $Lang_scripts_edit41[$pref::LanguageType]; }
//
$Lang_scripts_edit42[0]="����";
$Lang_scripts_edit42[1]="Error";
function Language_scirpts_edit42() { return $Lang_scripts_edit42[$pref::LanguageType]; }
//
$Lang_scripts_edit43[0]="�޷��򿪹����ļ�! ��ȷ���Ƿ��Ѿ������ð汾�����ļ���";
$Lang_scripts_edit43[1]="Project file cannot be opened,please check that the  project file of this version has been created.";
function Language_scirpts_edit43() { return $Lang_scripts_edit43[$pref::LanguageType]; }
//
$Lang_scripts_edit44[0]="����";
$Lang_scripts_edit44[1]="Error";
function Language_scirpts_edit44() { return $Lang_scripts_edit44[$pref::LanguageType]; }
//
$Lang_scripts_edit45[0]="�����빤������";
$Lang_scripts_edit45[1]="Please enter project name";
function Language_scirpts_edit45() { return $Lang_scripts_edit45[$pref::LanguageType]; }
//
$Lang_scripts_edit46[0]="ѡ��Visual Studio 14.0(devenv.exe):";
$Lang_scripts_edit46[1]="Select Visual Studio 14.0(devenv.exe):";
function Language_scirpts_edit46() { return $Lang_scripts_edit46[$pref::LanguageType]; }
//
$Lang_scripts_edit47[0]="�������ֲ��ܺ��������ַ�����ȫ���ַ������Ҳ��������ֿ�ͷ.";
$Lang_scripts_edit47[1]="Project name doesnot contain Chinese Characters or full-width characters,number cannot be the first letter";
function Language_scirpts_edit47() { return $Lang_scripts_edit47[$pref::LanguageType]; }
//
$Lang_scripts_edit48[0]="����VC2015(devenv.exe)λ��";
$Lang_scripts_edit48[1]="Set VC2015(devenv.exe)position";
function Language_scirpts_edit48() { return $Lang_scripts_edit48[$pref::LanguageType]; }
//
$Lang_scripts_edit49[0]="�����ֵ��ļ����Ѿ����ڣ���ʹ���������֡�";
$Lang_scripts_edit49[1]="Name folder is existing,use other name";
function Language_scirpts_edit49() { return $Lang_scripts_edit49[$pref::LanguageType]; }
//
$Lang_scripts_edit50[0]="��ʾ";
$Lang_scripts_edit50[1]="Hint";
function Language_scirpts_edit50() { return $Lang_scripts_edit50[$pref::LanguageType]; }
//
$Lang_scripts_edit51[0]="�ð汾�����Ѿ����ڡ�";
$Lang_scripts_edit51[1]="The project of this version already exists";
function Language_scirpts_edit51() { return $Lang_scripts_edit51[$pref::LanguageType]; }
//
$Lang_scripts_edit52[0]="�Ƿ񴴽��ð汾����?";
$Lang_scripts_edit52[1]="Create the project of this version or not?";
function Language_scirpts_edit52() { return $Lang_scripts_edit52[$pref::LanguageType]; }
//
$Lang_scripts_edit53[0]="�����ɹ�!";
$Lang_scripts_edit53[1]="Creation is successful";
function Language_scirpts_edit53() { return $Lang_scripts_edit53[$pref::LanguageType]; }
//
$Lang_scripts_edit54[0]="������ģ������";
$Lang_scripts_edit54[1]="Enter template name";
function Language_scirpts_edit54() { return $Lang_scripts_edit54[$pref::LanguageType]; }
//
$Lang_scripts_edit55[0]="�����ֵ�ģ���Ѿ����ڣ���ʹ���������֡�";
$Lang_scripts_edit55[1]="The template name already exists,please use other name";
function Language_scirpts_edit55() { return $Lang_scripts_edit55[$pref::LanguageType]; }
//
$Lang_scripts_edit56[0]="����ģ��ɹ�!";
$Lang_scripts_edit56[1]="Template save success.";
function Language_scirpts_edit56() { return $Lang_scripts_edit56[$pref::LanguageType]; }
//
$Lang_scripts_edit57[0]="����ѡ��һ��ģ�塣";
$Lang_scripts_edit57[1]="Select a template";
function Language_scirpts_edit57() { return $Lang_scripts_edit57[$pref::LanguageType]; }
//
$Lang_scripts_edit58[0]="����";
$Lang_scripts_edit58[1]="Warning";
function Language_scirpts_edit58() { return $Lang_scripts_edit58[$pref::LanguageType]; }
//
$Lang_scripts_edit59[0]="����ģ�彫�������е�ͼ�����е�ͼ���ݽ�ȫ����ʧ���Ƿ����?";
$Lang_scripts_edit59[1]="Import template would cover the current map and map data would loss,continue?";
function Language_scirpts_edit59() { return $Lang_scripts_edit59[$pref::LanguageType]; }
//
$Lang_scripts_edit60[0]="����ѡ��һ��ģ�塣";
$Lang_scripts_edit60[1]="Select a template";
function Language_scirpts_edit60() { return $Lang_scripts_edit60[$pref::LanguageType]; }
//
$Lang_scripts_edit61[0]="ģ��ɾ���󽫲����Իָ����Ƿ����?";
$Lang_scripts_edit61[1]="Template delete cannot be recovered,continue?";
function Language_scirpts_edit61() { return $Lang_scripts_edit61[$pref::LanguageType]; }
//
$Lang_scripts_edit62[0]="����VC6(MSDEV.EXE)λ��";
$Lang_scripts_edit62[1]="Set VC6(MSDEV.EXE) position";
function Language_scirpts_edit62() { return $Lang_scripts_edit62[$pref::LanguageType]; }
//
$Lang_scripts_edit63[0]="ѡ��Visual Studio(MSDEV.EXE):";
$Lang_scripts_edit63[1]="Select Visual Studio(MSDEV.EXE):";
function Language_scirpts_edit63() { return $Lang_scripts_edit63[$pref::LanguageType]; }
//
$Lang_scripts_edit64[0]="����VC2015(devenv.exe)λ��";
$Lang_scripts_edit64[1]="Set VC2015(devenv.exe)position";
function Language_scirpts_edit64() { return $Lang_scripts_edit64[$pref::LanguageType]; }
//
$Lang_scripts_edit65[0]="ѡ��Visual Studio 9.0(devenv.exe):";
$Lang_scripts_edit65[1]="Select Visual Studio 9.0(devenv.exe):";
function Language_scirpts_edit65() { return $Lang_scripts_edit65[$pref::LanguageType]; }
//
$Lang_scripts_edit66[0]="����VC2012(devenv.exe)λ��";
$Lang_scripts_edit66[1]="Set VC2012(devenv.exe) position";
function Language_scirpts_edit66() { return $Lang_scripts_edit66[$pref::LanguageType]; }
//
$Lang_scripts_edit67[0]="ѡ��Visual Studio 10.0(devenv.exe):";
$Lang_scripts_edit67[1]="Select Visual Studio 10.0(devenv.exe):";
function Language_scirpts_edit67() { return $Lang_scripts_edit67[$pref::LanguageType]; }
//
$Lang_scripts_edit68[0]="���� codeblock.exeλ��";
$Lang_scripts_edit68[1]="Set codeblock.exe position ";
function Language_scirpts_edit68() { return $Lang_scripts_edit68[$pref::LanguageType]; }
//
$Lang_scripts_edit69[0]="ѡ�� codeblock.exe:";
$Lang_scripts_edit69[1]="Select codeblock.exe:";
function Language_scirpts_edit69() { return $Lang_scripts_edit69[$pref::LanguageType]; }
//
$Lang_scripts_edit70[0]="����Eclipse.exeλ��";
$Lang_scripts_edit70[1]="Set Eclipse.exe position";
function Language_scirpts_edit70() { return $Lang_scripts_edit70[$pref::LanguageType]; }
//
$Lang_scripts_edit71[0]="ѡ��Eclipse.exe:";
$Lang_scripts_edit71[1]="Select Eclipse.exe:";
function Language_scirpts_edit71() { return $Lang_scripts_edit71[$pref::LanguageType]; }
//
$Lang_scripts_edit72[0]="��������PyCharm.exe��λ�á�";
$Lang_scripts_edit72[1]="Please set PyCharm.exe position first.";
function Language_scirpts_edit72() { return $Lang_scripts_edit72[$pref::LanguageType]; }
//
$Lang_scripts_edit73[0]="ָ����PyCharm��Ч [";
$Lang_scripts_edit73[1]="Assigned PyCharm is invalid [";
function Language_scirpts_edit73() { return $Lang_scripts_edit73[$pref::LanguageType]; }
//
$Lang_scripts_edit74[0]="] ��������ָ��PyCharm.exeλ�á�";
$Lang_scripts_edit74[1]="],appoint PyCharm.exe position again";
function Language_scirpts_edit74() { return $Lang_scripts_edit74[$pref::LanguageType]; }
//
$Lang_scripts_edit75[0]="�޷��ҵ�PyCharm��� [";
$Lang_scripts_edit75[1]="PyCharm software[";
function Language_scirpts_edit75() { return $Lang_scripts_edit75[$pref::LanguageType]; }
//
$Lang_scripts_edit76[0]="] ��������ָ��PyCharm.exeλ�á�";
$Lang_scripts_edit76[1]="], cannot be found,appoint PyCharm.exe position again";
function Language_scirpts_edit76() { return $Lang_scripts_edit76[$pref::LanguageType]; }
//
$Lang_scripts_edit77[0]="����PyCharm.exeλ��";
$Lang_scripts_edit77[1]="Set PyCharm.exe position";
function Language_scirpts_edit77() { return $Lang_scripts_edit77[$pref::LanguageType]; }
//
$Lang_scripts_edit78[0]="ѡ��PyCharm.exe:";
$Lang_scripts_edit78[1]="Select PyCharm.exe:";
function Language_scirpts_edit78() { return $Lang_scripts_edit78[$pref::LanguageType]; }

//
$Lang_levelEditorMenu0[0]="�ļ�";
$Lang_levelEditorMenu0[1]="File";
function Language_levelEditorMenu0() { return $Lang_levelEditorMenu0[$pref::LanguageType]; }
//
$Lang_levelEditorMenu1[0]="�򿪵�ͼ...";
$Lang_levelEditorMenu1[1]="Open scene...";
function Language_levelEditorMenu1() { return $Lang_levelEditorMenu1[$pref::LanguageType]; }
//
$Lang_levelEditorMenu2[0]="����Ŀ...";
$Lang_levelEditorMenu2[1]="Open project...";
function Language_levelEditorMenu2() { return $Lang_levelEditorMenu2[$pref::LanguageType]; }
//
$Lang_levelEditorMenu3[0]="�����ͼ";
$Lang_levelEditorMenu3[1]="Save scene";
function Language_levelEditorMenu3() { return $Lang_levelEditorMenu3[$pref::LanguageType]; }
//
$Lang_levelEditorMenu4[0]="��ͼ���Ϊ...";
$Lang_levelEditorMenu4[1]="Save scene as...";
function Language_levelEditorMenu4() { return $Lang_levelEditorMenu4[$pref::LanguageType]; }
//
$Lang_levelEditorMenu5[0]="�˳�";
$Lang_levelEditorMenu5[1]="Quit";
function Language_levelEditorMenu5() { return $Lang_levelEditorMenu5[$pref::LanguageType]; }
//
$Lang_levelEditorMenu6[0]="�༭";
$Lang_levelEditorMenu6[1]="Edit";
function Language_levelEditorMenu6() { return $Lang_levelEditorMenu6[$pref::LanguageType]; }
//
$Lang_levelEditorMenu7[0]="����";
$Lang_levelEditorMenu7[1]="Cancel";
function Language_levelEditorMenu7() { return $Lang_levelEditorMenu7[$pref::LanguageType]; }
//
$Lang_levelEditorMenu8[0]="����";
$Lang_levelEditorMenu8[1]="Redo";
function Language_levelEditorMenu8() { return $Lang_levelEditorMenu8[$pref::LanguageType]; }
//
$Lang_levelEditorMenu9[0]="����";
$Lang_levelEditorMenu9[1]="Cut";
function Language_levelEditorMenu9() { return $Lang_levelEditorMenu9[$pref::LanguageType]; }
//
$Lang_levelEditorMenu10[0]="����";
$Lang_levelEditorMenu10[1]="Copy";
function Language_levelEditorMenu10() { return $Lang_levelEditorMenu10[$pref::LanguageType]; }
//
$Lang_levelEditorMenu11[0]="ճ��";
$Lang_levelEditorMenu11[1]="Paste";
function Language_levelEditorMenu11() { return $Lang_levelEditorMenu11[$pref::LanguageType]; }
//
$Lang_levelEditorMenu12[0]="����";
$Lang_levelEditorMenu12[1]="Postposition";
function Language_levelEditorMenu12() { return $Lang_levelEditorMenu12[$pref::LanguageType]; }
//
$Lang_levelEditorMenu13[0]="ǰ��";
$Lang_levelEditorMenu13[1]="Preposition";
function Language_levelEditorMenu13() { return $Lang_levelEditorMenu13[$pref::LanguageType]; }
//
$Lang_levelEditorMenu14[0]="����...";
$Lang_levelEditorMenu14[1]="Set...";
function Language_levelEditorMenu14() { return $Lang_levelEditorMenu14[$pref::LanguageType]; }
//
$Lang_levelEditorMenu15[0]="��Ŀ";
$Lang_levelEditorMenu15[1]="Project";
function Language_levelEditorMenu15() { return $Lang_levelEditorMenu15[$pref::LanguageType]; }
//
$Lang_levelEditorMenu16[0]="������Ϸ";
$Lang_levelEditorMenu16[1]="Run Game";
function Language_levelEditorMenu16() { return $Lang_levelEditorMenu16[$pref::LanguageType]; }
//
$Lang_levelEditorMenu17[0]="�ָ�����ʼ��ͼ";
$Lang_levelEditorMenu17[1]="Recover to original map";
function Language_levelEditorMenu17() { return $Lang_levelEditorMenu17[$pref::LanguageType]; }
//
$Lang_levelEditorMenu18[0]="�򿪹����ļ���";
$Lang_levelEditorMenu18[1]="Open Project Folder";
function Language_levelEditorMenu18() { return $Lang_levelEditorMenu18[$pref::LanguageType]; }
//
$Lang_levelEditorMenu19[0]="����C#����";
$Lang_levelEditorMenu19[1]="Create C# project";
function Language_levelEditorMenu19() { return $Lang_levelEditorMenu19[$pref::LanguageType]; }
//
$Lang_levelEditorMenu20[0]="����C���Թ���";
$Lang_levelEditorMenu20[1]="Create C language project";
function Language_levelEditorMenu20() { return $Lang_levelEditorMenu20[$pref::LanguageType]; }
//
$Lang_levelEditorMenu21[0]="����C++����";
$Lang_levelEditorMenu21[1]="Create C++ project";
function Language_levelEditorMenu21() { return $Lang_levelEditorMenu21[$pref::LanguageType]; }
//
$Lang_levelEditorMenu22[0]="����Java����";
$Lang_levelEditorMenu22[1]="Create Java project";
function Language_levelEditorMenu22() { return $Lang_levelEditorMenu22[$pref::LanguageType]; }
//
$Lang_levelEditorMenu23[0]="����VB����";
$Lang_levelEditorMenu23[1]="Create VB project";
function Language_levelEditorMenu23() { return $Lang_levelEditorMenu23[$pref::LanguageType]; }
//
$Lang_levelEditorMenu24[0]="�����ͼ����";
$Lang_levelEditorMenu24[1]="Import map override";
function Language_levelEditorMenu24() { return $Lang_levelEditorMenu24[$pref::LanguageType]; }
//
$Lang_levelEditorMenu25[0]="�����ͼΪģ��";
$Lang_levelEditorMenu25[1]="Save map as template";
function Language_levelEditorMenu25() { return $Lang_levelEditorMenu25[$pref::LanguageType]; }
//
$Lang_levelEditorMenu26[0]="����Eclipse.exeλ��";
$Lang_levelEditorMenu26[1]="Set Eclipse.exe position";
function Language_levelEditorMenu26() { return $Lang_levelEditorMenu26[$pref::LanguageType]; }
//
$Lang_levelEditorMenu27[0]="����VC6(MSDEV.EXE)λ��";
$Lang_levelEditorMenu27[1]="Set VC6(MSDEV.EXE) position";
function Language_levelEditorMenu27() { return $Lang_levelEditorMenu27[$pref::LanguageType]; }
//
$Lang_levelEditorMenu28[0]="����VC2015(devenv.exe)λ��";
$Lang_levelEditorMenu28[1]="Set VC2015(devenv.exe) position";
function Language_levelEditorMenu28() { return $Lang_levelEditorMenu28[$pref::LanguageType]; }
//
$Lang_levelEditorMenu29[0]="����VC2012(devenv.exe)λ��";
$Lang_levelEditorMenu29[1]="Set VC2012(devenv.exe) position";
function Language_levelEditorMenu29() { return $Lang_levelEditorMenu29[$pref::LanguageType]; }
//
$Lang_levelEditorMenu30[0]="����codeblock.exeλ��";
$Lang_levelEditorMenu30[1]="Set codeblock.exe position";
function Language_levelEditorMenu30() { return $Lang_levelEditorMenu30[$pref::LanguageType]; }
//
$Lang_levelEditorMenu31[0]="��ͼ";
$Lang_levelEditorMenu31[1]="View";
function Language_levelEditorMenu31() { return $Lang_levelEditorMenu31[$pref::LanguageType]; }
//
$Lang_levelEditorMenu32[0]="��Ļ��λ";
$Lang_levelEditorMenu32[1]="Screen reset";
function Language_levelEditorMenu32() { return $Lang_levelEditorMenu32[$pref::LanguageType]; }
//
$Lang_levelEditorMenu33[0]="��ʾȫ��";
$Lang_levelEditorMenu33[1]="Show all";
function Language_levelEditorMenu33() { return $Lang_levelEditorMenu33[$pref::LanguageType]; }
//
$Lang_levelEditorMenu34[0]="��ʾ��ѡ���";
$Lang_levelEditorMenu34[1]="Show the selected";
function Language_levelEditorMenu34() { return $Lang_levelEditorMenu34[$pref::LanguageType]; }
//
$Lang_levelEditorMenu35[0]="���� 25%";
$Lang_levelEditorMenu35[1]="Zoom 25%";
function Language_levelEditorMenu35() { return $Lang_levelEditorMenu35[$pref::LanguageType]; }
//
$Lang_levelEditorMenu36[0]="���� 50%";
$Lang_levelEditorMenu36[1]="Zoom 50%";
function Language_levelEditorMenu36() { return $Lang_levelEditorMenu36[$pref::LanguageType]; }
//
$Lang_levelEditorMenu37[0]="���� 100%";
$Lang_levelEditorMenu37[1]="Zoom 100%";
function Language_levelEditorMenu37() { return $Lang_levelEditorMenu37[$pref::LanguageType]; }
//
$Lang_levelEditorMenu38[0]="���� 200%";
$Lang_levelEditorMenu38[1]="Zoom 200%";
function Language_levelEditorMenu38() { return $Lang_levelEditorMenu38[$pref::LanguageType]; }
//
$Lang_levelEditorMenu39[0]="���� 400%";
$Lang_levelEditorMenu39[1]="Zoom 400%";
function Language_levelEditorMenu39() { return $Lang_levelEditorMenu39[$pref::LanguageType]; }
//
$Lang_levelEditorMenu40[0]="����";
$Lang_levelEditorMenu40[1]="Help";
function Language_levelEditorMenu40() { return $Lang_levelEditorMenu40[$pref::LanguageType]; }
//
$Lang_levelEditorMenu41[0]="��ѧ��վ";
$Lang_levelEditorMenu41[1]="Teaching website";
function Language_levelEditorMenu41() { return $Lang_levelEditorMenu41[$pref::LanguageType]; }
//
$Lang_levelEditorMenu42[0]="�����ĵ�";
$Lang_levelEditorMenu42[1]="Help document";
function Language_levelEditorMenu42() { return $Lang_levelEditorMenu42[$pref::LanguageType]; }
//
$Lang_levelEditorMenu43[0]="���ý�ѧ��վ������";
$Lang_levelEditorMenu43[1]="Set teaching server";
function Language_levelEditorMenu43() { return $Lang_levelEditorMenu43[$pref::LanguageType]; }
//
$Lang_levelEditorMenu44[0]="��ݼ�...";
$Lang_levelEditorMenu44[1]="Shortcut key...";
function Language_levelEditorMenu44() { return $Lang_levelEditorMenu44[$pref::LanguageType]; }
//
$Lang_levelEditorMenu45[0]="�����ĵ�.pdf";
$Lang_levelEditorMenu45[1]="HelpDocument.pdf";
function Language_levelEditorMenu45() { return $Lang_levelEditorMenu45[$pref::LanguageType]; }
//
$Lang_levelEditorMenu46[0]="����Python����";
$Lang_levelEditorMenu46[1]="Create Python project";
function Language_levelEditorMenu46() { return $Lang_levelEditorMenu46[$pref::LanguageType]; }
//
$Lang_levelEditorMenu47[0]="����VC2015(devenv.exe)λ��";
$Lang_levelEditorMenu47[1]="Set VC2015(devenv.exe) position";
function Language_levelEditorMenu47() { return $Lang_levelEditorMenu47[$pref::LanguageType]; }
//
$Lang_levelEditorMenu48[0]="���õ�½������";
$Lang_levelEditorMenu48[1]="Set login server";
function Language_levelEditorMenu48() { return $Lang_levelEditorMenu48[$pref::LanguageType]; }
//
$Lang_levelEditorMenu49[0]="����PyCharm.exeλ��";
$Lang_levelEditorMenu49[1]="Set PyCharm.exe position";
function Language_levelEditorMenu49() { return $Lang_levelEditorMenu49[$pref::LanguageType]; }
//
$Lang_levelEditorMenu50[0]="�汾��";
$Lang_levelEditorMenu50[1]="Version: ";
function Language_levelEditorMenu50() { return $Lang_levelEditorMenu50[$pref::LanguageType]; }

//
$Lang_levelManagement0[0]="������Ϸ";
$Lang_levelManagement0[1]="Run game";
function Language_levelManagement0() { return $Lang_levelManagement0[$pref::LanguageType]; }
//
$Lang_levelManagement1[0]="�޷��ҵ�ִ���ļ�:";
$Lang_levelManagement1[1]="Executable file cannot be found:";
function Language_levelManagement1() { return $Lang_levelManagement1[$pref::LanguageType]; }
//
$Lang_levelManagement2[0]="ȷ��";
$Lang_levelManagement2[1]="Confirm";
function Language_levelManagement2() { return $Lang_levelManagement2[$pref::LanguageType]; }
//
$Lang_levelManagement3[0]="ֹͣ";
$Lang_levelManagement3[1]="Stop";
function Language_levelManagement3() { return $Lang_levelManagement3[$pref::LanguageType]; }
//
$Lang_levelManagement4[0]="������Ϸ";
$Lang_levelManagement4[1]="Run game";
function Language_levelManagement4() { return $Lang_levelManagement4[$pref::LanguageType]; }
//
$Lang_levelManagement5[0]="�ű����д���!";
$Lang_levelManagement5[1]="Script running error!";
function Language_levelManagement5() { return $Lang_levelManagement5[$pref::LanguageType]; }
//
$Lang_levelManagement6[0]="��('~')���鿴��ϸ����.";
$Lang_levelManagement6[1]="Press('~')to check.";
function Language_levelManagement6() { return $Lang_levelManagement6[$pref::LanguageType]; }
//
$Lang_levelManagement7[0]="����";
$Lang_levelManagement7[1]="Error";
function Language_levelManagement7() { return $Lang_levelManagement7[$pref::LanguageType]; }
//
$Lang_levelManagement8[0]="�޷������µ�ͼ��û�е�ͼ�Ӵ�";
$Lang_levelManagement8[1]="Can't create level, no window view.";
function Language_levelManagement8() { return $Lang_levelManagement8[$pref::LanguageType]; }

//
$Lang_saving0[0]="�Ƿ񱣴��ͼ����Ч?";
$Lang_saving0[1]="Save scene and effect?";
function Language_saving0() { return $Lang_saving0[$pref::LanguageType]; }
//
$Lang_saving1[0]="��ͼ����δ�����ƽ��ͼ�����ӣ���������棬�����е�ͼ���߹رյ�ͼʱ�������ݽ���ʧ. �Ƿ񱣴�?";
$Lang_saving1[1]="Unsaved scene tiled image or particle would loss when running or closing scene .Save?";
function Language_saving1() { return $Lang_saving1[$pref::LanguageType]; }

//
$Lang_toolbar0[0]="�����µ�ͼ";
$Lang_toolbar0[1]="Create a new scene";
function Language_toolbar0() { return $Lang_toolbar0[$pref::LanguageType]; }
//
$Lang_toolbar1[0]="�򿪵�ͼ";
$Lang_toolbar1[1]="Open a current scene";
function Language_toolbar1() { return $Lang_toolbar1[$pref::LanguageType]; }
//
$Lang_toolbar2[0]="���浱ǰ��ͼ";
$Lang_toolbar2[1]="Save current scene changes";
function Language_toolbar2() { return $Lang_toolbar2[$pref::LanguageType]; }
//
$Lang_toolbar3[0]="����ѡ�еľ�����������";
$Lang_toolbar3[1]="Cut selected Sprite to clipboard";
function Language_toolbar3() { return $Lang_toolbar3[$pref::LanguageType]; }
//
$Lang_toolbar4[0]="����ѡ�еľ�����������";
$Lang_toolbar4[1]="Copy selected Sprite to clipboard";
function Language_toolbar4() { return $Lang_toolbar4[$pref::LanguageType]; }
//
$Lang_toolbar5[0]="ճ����������ľ���";
$Lang_toolbar5[1]="ClipBoard Sprite paste";
function Language_toolbar5() { return $Lang_toolbar5[$pref::LanguageType]; }
//
$Lang_toolbar6[0]="�����ϴβ���";
$Lang_toolbar6[1]="Last operation cancel";
function Language_toolbar6() { return $Lang_toolbar6[$pref::LanguageType]; }
//
$Lang_toolbar7[0]="�����ϴβ���";
$Lang_toolbar7[1]="Last operation redo";
function Language_toolbar7() { return $Lang_toolbar7[$pref::LanguageType]; }
//
$Lang_toolbar8[0]="������Ϸ";
$Lang_toolbar8[1]="Run game";
function Language_toolbar8() { return $Lang_toolbar8[$pref::LanguageType]; }
//
$Lang_toolbar9[0]="�༭�˾������ײ��";
$Lang_toolbar9[1]="Edit the Sprite collision object";
function Language_toolbar9() { return $Lang_toolbar9[$pref::LanguageType]; }
//
$Lang_toolbar10[0]="�༭�˾�������ӵ�";
$Lang_toolbar10[1]="Edit the Sprite link point";
function Language_toolbar10() { return $Lang_toolbar10[$pref::LanguageType]; }
//
$Lang_toolbar11[0]="�༭�˾�������ĵ�";
$Lang_toolbar11[1]="Edit the Sprite center point";
function Language_toolbar11() { return $Lang_toolbar11[$pref::LanguageType]; }
//
$Lang_toolbar12[0]="�󶨴˾�������һ������";
$Lang_toolbar12[1]="Sprite binding to another";
function Language_toolbar12() { return $Lang_toolbar12[$pref::LanguageType]; }
//
$Lang_toolbar13[0]="���˾���֮ǰ�����İ�";
$Lang_toolbar13[1]="Unbind previous Sprite binding";
function Language_toolbar13() { return $Lang_toolbar13[$pref::LanguageType]; }
//
$Lang_toolbar14[0]="���˾���֮ǰ�����İ�";
$Lang_toolbar14[1]="Unbind previous Sprite binding";
function Language_toolbar14() { return $Lang_toolbar14[$pref::LanguageType]; }
//
$Lang_toolbar15[0]="���Ĵ˾��������߽�����";
$Lang_toolbar15[1]="Change the Sprite's world boundary limit";
function Language_toolbar15() { return $Lang_toolbar15[$pref::LanguageType]; }
//
$Lang_toolbar16[0]="�༭��·��";
$Lang_toolbar16[1]="Edit the path";
function Language_toolbar16() { return $Lang_toolbar16[$pref::LanguageType]; }
//
$Lang_toolbar17[0]="�༭��ƽ��ͼ";
$Lang_toolbar17[1]="Edit the tiled  image";
function Language_toolbar17() { return $Lang_toolbar17[$pref::LanguageType]; }
//
$Lang_toolbar18[0]="�༭������";
$Lang_toolbar18[1]="Edit the text";
function Language_toolbar18() { return $Lang_toolbar18[$pref::LanguageType]; }
//
$Lang_toolbar19[0]="�༭�˶����";
$Lang_toolbar19[1]="Edit the polygon";
function Language_toolbar19() { return $Lang_toolbar19[$pref::LanguageType]; }

// ������toolbar44������FunCode C++��������õ� 
$Lang_toolbar20[0]="3Dģ�͹���";
$Lang_toolbar20[1]="3D Model tool";
function Language_toolbar20() { return $Lang_toolbar20[$pref::LanguageType]; }
//
$Lang_toolbar21[0]="�������鹤��";
$Lang_toolbar21[1]="Animated sprite tool";
function Language_toolbar21() { return $Lang_toolbar21[$pref::LanguageType]; }
//
$Lang_toolbar22[0]="�����༭����";
$Lang_toolbar22[1]="Base edit tool";
function Language_toolbar22() { return $Lang_toolbar22[$pref::LanguageType]; }
//
$Lang_toolbar23[0]="��������";
$Lang_toolbar23[1]="Base tool";
function Language_toolbar23() { return $Lang_toolbar23[$pref::LanguageType]; }
//
$Lang_toolbar24[0]="��Ļ";
$Lang_toolbar24[1]="Screen";
function Language_toolbar24() { return $Lang_toolbar24[$pref::LanguageType]; }
//
$Lang_toolbar25[0]="�������鹤��";
$Lang_toolbar25[1]="Batch Sprite tool";
function Language_toolbar25() { return $Lang_toolbar25[$pref::LanguageType]; }
//
$Lang_toolbar26[0]="��������";
$Lang_toolbar26[1]="Create tool";
function Language_toolbar26() { return $Lang_toolbar26[$pref::LanguageType]; }
//
$Lang_toolbar27[0]="�ҽӹ���";
$Lang_toolbar27[1]="Mount tool";
function Language_toolbar27() { return $Lang_toolbar27[$pref::LanguageType]; }
//
$Lang_toolbar28[0]="�ҽӹ���";
$Lang_toolbar28[1]="Mount tool";
function Language_toolbar28() { return $Lang_toolbar28[$pref::LanguageType]; }
//
$Lang_toolbar29[0]="������Ч����";
$Lang_toolbar29[1]="Particle effect tool";
function Language_toolbar29() { return $Lang_toolbar29[$pref::LanguageType]; }
//
$Lang_toolbar30[0]="·������";
$Lang_toolbar30[1]="Path tool";
function Language_toolbar30() { return $Lang_toolbar30[$pref::LanguageType]; }
//
$Lang_toolbar31[0]="·������";
$Lang_toolbar31[1]="Path tool";
function Language_toolbar31() { return $Lang_toolbar31[$pref::LanguageType]; }
//
$Lang_toolbar32[0]="�������ײ����";
$Lang_toolbar32[1]="Poly collision tool";
function Language_toolbar32() { return $Lang_toolbar32[$pref::LanguageType]; }
//
$Lang_toolbar33[0]="��ͼ���幤��";
$Lang_toolbar33[1]="Scene object tool";
function Language_toolbar33() { return $Lang_toolbar33[$pref::LanguageType]; }
//
$Lang_toolbar34[0]="����ͼ����";
$Lang_toolbar34[1]="Scroller tool";
function Language_toolbar34() { return $Lang_toolbar34[$pref::LanguageType]; }
//
$Lang_toolbar35[0]="ѡ�񹤾�";
$Lang_toolbar35[1]="Select tool";
function Language_toolbar35() { return $Lang_toolbar35[$pref::LanguageType]; }
//
$Lang_toolbar36[0]="ģ����������";
$Lang_toolbar36[1]="Shape vector tool";
function Language_toolbar36() { return $Lang_toolbar36[$pref::LanguageType]; }
//
$Lang_toolbar37[0]="����㹤��";
$Lang_toolbar37[1]="Sort point tool";
function Language_toolbar37() { return $Lang_toolbar37[$pref::LanguageType]; }
//
$Lang_toolbar38[0]="��̬���鹤��";
$Lang_toolbar38[1]="Static Sprite tool";
function Language_toolbar38() { return $Lang_toolbar38[$pref::LanguageType]; }
//
$Lang_toolbar39[0]="���ֱ༭����";
$Lang_toolbar39[1]="Text edit tool";
function Language_toolbar39() { return $Lang_toolbar39[$pref::LanguageType]; }
//
$Lang_toolbar40[0]="�������幤��";
$Lang_toolbar40[1]="Text object tool";
function Language_toolbar40() { return $Lang_toolbar40[$pref::LanguageType]; }
//
$Lang_toolbar41[0]="ƽ��ͼ����";
$Lang_toolbar41[1]="Tilemap tool";
function Language_toolbar41() { return $Lang_toolbar41[$pref::LanguageType]; }
//
$Lang_toolbar42[0]="ƽ��ͼ����";
$Lang_toolbar42[1]="Tilemap tool";
function Language_toolbar42() { return $Lang_toolbar42[$pref::LanguageType]; }
//
$Lang_toolbar43[0]="����������";
$Lang_toolbar43[1]="Trigger tool";
function Language_toolbar43() { return $Lang_toolbar43[$pref::LanguageType]; }
//
$Lang_toolbar44[0]="����߽����ƹ���";
$Lang_toolbar44[1]="World limit tool";
function Language_toolbar44() { return $Lang_toolbar44[$pref::LanguageType]; }

//
$Lang_LocalPointEditor0[0]="�߽�����༭";
$Lang_LocalPointEditor0[1]="Border coordinate edit";
function Language_LocalPointEditor0() { return $Lang_LocalPointEditor0[$pref::LanguageType]; }
//
$Lang_LocalPointEditor1[0]="����";
$Lang_LocalPointEditor1[1]="Area";
function Language_LocalPointEditor1() { return $Lang_LocalPointEditor1[$pref::LanguageType]; }
//
$Lang_LocalPointEditor2[0]="��ʾ͹������";
$Lang_LocalPointEditor2[1]="Show outer convexity";
function Language_LocalPointEditor2() { return $Lang_LocalPointEditor2[$pref::LanguageType]; }
//
$Lang_LocalPointEditor3[0]="��ʾ�߽�";
$Lang_LocalPointEditor3[1]="Show border";
function Language_LocalPointEditor3() { return $Lang_LocalPointEditor3[$pref::LanguageType]; }
//
$Lang_LocalPointEditor4[0]="��ʾ͹��߽����";
$Lang_LocalPointEditor4[1]="Show convexity border error";
function Language_LocalPointEditor4() { return $Lang_LocalPointEditor4[$pref::LanguageType]; }
//
$Lang_LocalPointEditor5[0]="��ʾ�߽����";
$Lang_LocalPointEditor5[1]="Show border error";
function Language_LocalPointEditor5() { return $Lang_LocalPointEditor5[$pref::LanguageType]; }
//
$Lang_LocalPointEditor6[0]="������֮�佨����";
$Lang_LocalPointEditor6[1]="Creat point between two points";
function Language_LocalPointEditor6() { return $Lang_LocalPointEditor6[$pref::LanguageType]; }
//
$Lang_LocalPointEditor7[0]="���յ��½���";
$Lang_LocalPointEditor7[1]="Create new point at the end point";
function Language_LocalPointEditor7() { return $Lang_LocalPointEditor7[$pref::LanguageType]; }
//
$Lang_LocalPointEditor8[0]="��͹������ȡ����";
$Lang_LocalPointEditor8[1]="Replace point from the outer convexity";
function Language_LocalPointEditor8() { return $Lang_LocalPointEditor8[$pref::LanguageType]; }
//
$Lang_LocalPointEditor9[0]="���ο�߱�";
$Lang_LocalPointEditor9[1]="Square aspect ratio";
function Language_LocalPointEditor9() { return $Lang_LocalPointEditor9[$pref::LanguageType]; }
//
$Lang_LocalPointEditor10[0]="ƽ���߱�";
$Lang_LocalPointEditor10[1]="Planar aspect ratio";
function Language_LocalPointEditor10() { return $Lang_LocalPointEditor10[$pref::LanguageType]; }
//
$Lang_LocalPointEditor11[0]="�½�:";
$Lang_LocalPointEditor11[1]="Newly create:";
function Language_LocalPointEditor11() { return $Lang_LocalPointEditor11[$pref::LanguageType]; }
//
$Lang_LocalPointEditor12[0]="�����˵�";
$Lang_LocalPointEditor12[1]="Create the point";
function Language_LocalPointEditor12() { return $Lang_LocalPointEditor12[$pref::LanguageType]; }
//
$Lang_LocalPointEditor13[0]="��ʾ����ͼ";
$Lang_LocalPointEditor13[1]="Show background image";
function Language_LocalPointEditor13() { return $Lang_LocalPointEditor13[$pref::LanguageType]; }
//
$Lang_LocalPointEditor14[0]="��ʾ����";
$Lang_LocalPointEditor14[1]="Show background";
function Language_LocalPointEditor14() { return $Lang_LocalPointEditor14[$pref::LanguageType]; }
//
$Lang_LocalPointEditor15[0]="�������β���";
$Lang_LocalPointEditor15[1]="Operation cancel";
function Language_LocalPointEditor15() { return $Lang_LocalPointEditor15[$pref::LanguageType]; }
//
$Lang_LocalPointEditor16[0]="�����ϴβ���";
$Lang_LocalPointEditor16[1]="Last operation redo";
function Language_LocalPointEditor16() { return $Lang_LocalPointEditor16[$pref::LanguageType]; }
//
$Lang_LocalPointEditor17[0]="����";
$Lang_LocalPointEditor17[1]="Save";
function Language_LocalPointEditor17() { return $Lang_LocalPointEditor17[$pref::LanguageType]; }
//
$Lang_LocalPointEditor18[0]="ȡ��";
$Lang_LocalPointEditor18[1]="Cancel";
function Language_LocalPointEditor18() { return $Lang_LocalPointEditor18[$pref::LanguageType]; }

//
$Lang_animationEditor_main0[0]="ѡ��ͼƬ��Դ";
$Lang_animationEditor_main0[1]="Select Image Resource";
function Language_animationEditor_main0() { return $Lang_animationEditor_main0[$pref::LanguageType]; }

//
$Lang_collisionPolyEditor0[0]="������ײ��?";
$Lang_collisionPolyEditor0[1]="Save collision object?";
function Language_collisionPolyEditor0() { return $Lang_collisionPolyEditor0[$pref::LanguageType]; }
//
$Lang_collisionPolyEditor1[0]="������ײ����������?";
$Lang_collisionPolyEditor1[1]="Save the collision object to replace polygon?";
function Language_collisionPolyEditor1() { return $Lang_collisionPolyEditor1[$pref::LanguageType]; }

//
$Lang_linkpointEditor0[0]="���ӵ�����ʹ���У�ɾ�������ӵ㼰���ӽڵ�?";
$Lang_linkpointEditor0[1]="Link point is being used,delete the link point and its sub-node?";
function Language_linkpointEditor0() { return $Lang_linkpointEditor0[$pref::LanguageType]; }
//
$Lang_linkpointEditor1[0]="ɾ������?";
$Lang_linkpointEditor1[1]="Delete Link point?";
function Language_linkpointEditor1() { return $Lang_linkpointEditor1[$pref::LanguageType]; }

//
$Lang_localPointEditorcs0[0]="      -      �����������, ��ק�ƶ�, �Ҽ�����ɾ��. ��ק���б���Ը���˳��.";
$Lang_localPointEditorcs0[1]="      -      Left click to create,drag to move,right click to delete.Drag list to change order";
function Language_localPointEditorcs0() { return $Lang_localPointEditorcs0[$pref::LanguageType]; }
//
$Lang_localPointEditorcs1[0]="ɾ���˵�";
$Lang_localPointEditorcs1[1]="Delete point";
function Language_localPointEditorcs1() { return $Lang_localPointEditorcs1[$pref::LanguageType]; }

//
$Lang_localPointEditor_main0[0]="����(�ҽ�)��༭��";
$Lang_localPointEditor_main0[1]="Mount point editor";
function Language_localPointEditor_main0() { return $Lang_localPointEditor_main0[$pref::LanguageType]; }
//
$Lang_localPointEditor_main1[0]="��ײ�༭��";
$Lang_localPointEditor_main1[1]="Collision editor";
function Language_localPointEditor_main1() { return $Lang_localPointEditor_main1[$pref::LanguageType]; }
//
$Lang_localPointEditor_main2[0]="����α༭��";
$Lang_localPointEditor_main2[1]="Polygon editor";
function Language_localPointEditor_main2() { return $Lang_localPointEditor_main2[$pref::LanguageType]; }
//
$Lang_localPointEditor_main3[0]="�������Ϊ�༭��";
$Lang_localPointEditor_main3[1]="Polygon behavior editor";
function Language_localPointEditor_main3() { return $Lang_localPointEditor_main3[$pref::LanguageType]; }
//
$Lang_localPointEditor_main4[0]="���������б�༭��";
$Lang_localPointEditor_main4[1]="Local coordinate list editor ";
function Language_localPointEditor_main4() { return $Lang_localPointEditor_main4[$pref::LanguageType]; }

//
$Lang_FunCodeParticle0[0]="������Ч��Դ";
$Lang_FunCodeParticle0[1]="Particle effect resource";
function Language_FunCodeParticle0() { return $Lang_FunCodeParticle0[$pref::LanguageType]; }
//
$Lang_FunCodeParticle1[0]="��Դ";
$Lang_FunCodeParticle1[1]="Resource";
function Language_FunCodeParticle1() { return $Lang_FunCodeParticle1[$pref::LanguageType]; }
//
$Lang_FunCodeParticle2[0]="Ԥ��";
$Lang_FunCodeParticle2[1]="Preview";
function Language_FunCodeParticle2() { return $Lang_FunCodeParticle2[$pref::LanguageType]; }
//
$Lang_FunCodeParticle3[0]="��ӵ�����";
$Lang_FunCodeParticle3[1]="Add to the project";
function Language_FunCodeParticle3() { return $Lang_FunCodeParticle3[$pref::LanguageType]; }
//
$Lang_FunCodeParticle4[0]="�رմ���ʱ�ͷ�ͼƬ��Դ(���õ����û���)";
$Lang_FunCodeParticle4[1]="Image resources release when window off(for  low-configure machine)";
function Language_FunCodeParticle4() { return $Lang_FunCodeParticle4[$pref::LanguageType]; }

//
$Lang_projectBuilder0[0]="������Ϸ��װ��";
$Lang_projectBuilder0[1]="Create game installer";
function Language_projectBuilder0() { return $Lang_projectBuilder0[$pref::LanguageType]; }
//
$Lang_projectBuilder1[0]="��˾����:";
$Lang_projectBuilder1[1]="Company name:";
function Language_projectBuilder1() { return $Lang_projectBuilder1[$pref::LanguageType]; }
//
$Lang_projectBuilder2[0]="��Ʒ����:";
$Lang_projectBuilder2[1]="Product name:";
function Language_projectBuilder2() { return $Lang_projectBuilder2[$pref::LanguageType]; }
//
$Lang_projectBuilder3[0]="��ʼ��ͼ:";
$Lang_projectBuilder3[1]="Original scene:";
function Language_projectBuilder3() { return $Lang_projectBuilder3[$pref::LanguageType]; }
//
$Lang_projectBuilder4[0]="���Ĭ�ϵ�ͼ";
$Lang_projectBuilder4[1]="Browse default scene";
function Language_projectBuilder4() { return $Lang_projectBuilder4[$pref::LanguageType]; }
//
$Lang_projectBuilder5[0]="���Ŀ¼";
$Lang_projectBuilder5[1]="Output directory";
function Language_projectBuilder5() { return $Lang_projectBuilder5[$pref::LanguageType]; }
//
$Lang_projectBuilder6[0]="�����������λ��";
$Lang_projectBuilder6[1]="Browse extra output location";
function Language_projectBuilder6() { return $Lang_projectBuilder6[$pref::LanguageType]; }
//
$Lang_projectBuilder7[0]="����ƽ̨";
$Lang_projectBuilder7[1]="Running platform";
function Language_projectBuilder7() { return $Lang_projectBuilder7[$pref::LanguageType]; }
//
$Lang_projectBuilder8[0]="�����ű�Դ����";
$Lang_projectBuilder8[1]="Scipt source code included";
function Language_projectBuilder8() { return $Lang_projectBuilder8[$pref::LanguageType]; }
//
$Lang_projectBuilder9[0]="ȡ��";
$Lang_projectBuilder9[1]="Cancel";
function Language_projectBuilder9() { return $Lang_projectBuilder9[$pref::LanguageType]; }
//
$Lang_projectBuilder10[0]="����";
$Lang_projectBuilder10[1]="Create";
function Language_projectBuilder10() { return $Lang_projectBuilder10[$pref::LanguageType]; }

//
$Lang_newProjectDlg0[0]="�½���Ŀ";
$Lang_newProjectDlg0[1]="New create project";
function Language_newProjectDlg0() { return $Lang_newProjectDlg0[$pref::LanguageType]; }
//
$Lang_newProjectDlg1[0]="�����ĵ���";
$Lang_newProjectDlg1[1]="Browse your computer";
function Language_newProjectDlg1() { return $Lang_newProjectDlg1[$pref::LanguageType]; }
//
$Lang_newProjectDlg2[0]="λ�� :";
$Lang_newProjectDlg2[1]="Location:";
function Language_newProjectDlg2() { return $Lang_newProjectDlg2[$pref::LanguageType]; }
//
$Lang_newProjectDlg3[0]="��Ŀģ�� :";
$Lang_newProjectDlg3[1]="Project template:";
function Language_newProjectDlg3() { return $Lang_newProjectDlg3[$pref::LanguageType]; }
//
$Lang_newProjectDlg4[0]="���� :";
$Lang_newProjectDlg4[1]="Name:";
function Language_newProjectDlg4() { return $Lang_newProjectDlg4[$pref::LanguageType]; }
//
$Lang_newProjectDlg5[0]="����ģ��ִ�е����½���Ŀ";
$Lang_newProjectDlg5[1]="Copy template to new project";
function Language_newProjectDlg5() { return $Lang_newProjectDlg5[$pref::LanguageType]; }
//
$Lang_newProjectDlg6[0]="����";
$Lang_newProjectDlg6[1]="Create";
function Language_newProjectDlg6() { return $Lang_newProjectDlg6[$pref::LanguageType]; }

//
$Lang_openProjectDlg0[0]="����Ŀ";
$Lang_openProjectDlg0[1]="Open project";
function Language_openProjectDlg0() { return $Lang_openProjectDlg0[$pref::LanguageType]; }
//
$Lang_openProjectDlg1[0]="ȡ��";
$Lang_openProjectDlg1[1]="Cancel";
function Language_openProjectDlg1() { return $Lang_openProjectDlg1[$pref::LanguageType]; }
//
$Lang_openProjectDlg2[0]="����Ŀ";
$Lang_openProjectDlg2[1]="Open project";
function Language_openProjectDlg2() { return $Lang_openProjectDlg2[$pref::LanguageType]; }

//
$Lang_projectOptionsDlg0[0]="��Ŀ��Դ";
$Lang_projectOptionsDlg0[1]="Project options";
function Language_projectOptionsDlg0() { return $Lang_projectOptionsDlg0[$pref::LanguageType]; }
//
$Lang_projectOptionsDlg1[0]="��ӵ���Ŀ";
$Lang_projectOptionsDlg1[1]="Add to the project";
function Language_projectOptionsDlg1() { return $Lang_projectOptionsDlg1[$pref::LanguageType]; }
//
$Lang_projectOptionsDlg2[0]="����Ŀ��ɾ��";
$Lang_projectOptionsDlg2[1]="Delete from the project";
function Language_projectOptionsDlg2() { return $Lang_projectOptionsDlg2[$pref::LanguageType]; }
//
$Lang_projectOptionsDlg3[0]="ȡ��";
$Lang_projectOptionsDlg3[1]="Cancel";
function Language_projectOptionsDlg3() { return $Lang_projectOptionsDlg3[$pref::LanguageType]; }
//
$Lang_projectOptionsDlg4[0]="����";
$Lang_projectOptionsDlg4[1]="Save";
function Language_projectOptionsDlg4() { return $Lang_projectOptionsDlg4[$pref::LanguageType]; }
//
$Lang_projectOptionsDlg5[0]="������Դ";
$Lang_projectOptionsDlg5[1]="Available options";
function Language_projectOptionsDlg5() { return $Lang_projectOptionsDlg5[$pref::LanguageType]; }
//
$Lang_projectOptionsDlg6[0]="��ǰ��Ŀ����Դ";
$Lang_projectOptionsDlg6[1]="Current project options";
function Language_projectOptionsDlg6() { return $Lang_projectOptionsDlg6[$pref::LanguageType]; }

//
$Lang_levelEditorMap0[0]="�ƶ�ѡ������������Ļһ��";
$Lang_levelEditorMap0[1]="Move selection near screen layer";
function Language_levelEditorMap0() { return $Lang_levelEditorMap0[$pref::LanguageType]; }
//
$Lang_levelEditorMap1[0]="�ƶ�ѡ������Զ����Ļһ��";
$Lang_levelEditorMap1[1]="Move selection far from screen layer";
function Language_levelEditorMap1() { return $Lang_levelEditorMap1[$pref::LanguageType]; }
//
$Lang_levelEditorMap2[0]="����ѡ�񹤾�";
$Lang_levelEditorMap2[1]="Activate selection tool";
function Language_levelEditorMap2() { return $Lang_levelEditorMap2[$pref::LanguageType]; }
//
$Lang_levelEditorMap3[0]="��ʾ�༭���";
$Lang_levelEditorMap3[1]="Show edit panel";
function Language_levelEditorMap3() { return $Lang_levelEditorMap3[$pref::LanguageType]; }
//
$Lang_levelEditorMap4[0]="��ʾ�������";
$Lang_levelEditorMap4[1]="Show create panel";
function Language_levelEditorMap4() { return $Lang_levelEditorMap4[$pref::LanguageType]; }
//
$Lang_levelEditorMap5[0]="��ʾ��Ŀ���";
$Lang_levelEditorMap5[1]="Show project panel";
function Language_levelEditorMap5() { return $Lang_levelEditorMap5[$pref::LanguageType]; }
//
$Lang_levelEditorMap6[0]="��Ļ��λ";
$Lang_levelEditorMap6[1]="Screen reset";
function Language_levelEditorMap6() { return $Lang_levelEditorMap6[$pref::LanguageType]; }
//
$Lang_levelEditorMap7[0]="��ʾ���о���";
$Lang_levelEditorMap7[1]="Show all the sprites";
function Language_levelEditorMap7() { return $Lang_levelEditorMap7[$pref::LanguageType]; }
//
$Lang_levelEditorMap8[0]="�Ŵ󴰿�";
$Lang_levelEditorMap8[1]="Zoom in";
function Language_levelEditorMap8() { return $Lang_levelEditorMap8[$pref::LanguageType]; }
//
$Lang_levelEditorMap9[0]="��С����";
$Lang_levelEditorMap9[1]="Zoom out";
function Language_levelEditorMap9() { return $Lang_levelEditorMap9[$pref::LanguageType]; }
//
$Lang_levelEditorMap10[0]="�����ƶ�����";
$Lang_levelEditorMap10[1]="Window moves left";
function Language_levelEditorMap10() { return $Lang_levelEditorMap10[$pref::LanguageType]; }
//
$Lang_levelEditorMap11[0]="�����ƶ�����";
$Lang_levelEditorMap11[1]="Window moves right";
function Language_levelEditorMap11() { return $Lang_levelEditorMap11[$pref::LanguageType]; }
//
$Lang_levelEditorMap12[0]="�����ƶ�����";
$Lang_levelEditorMap12[1]="Window moves up";
function Language_levelEditorMap12() { return $Lang_levelEditorMap12[$pref::LanguageType]; }
//
$Lang_levelEditorMap13[0]="�����ƶ�����";
$Lang_levelEditorMap13[1]="Window moves down";
function Language_levelEditorMap13() { return $Lang_levelEditorMap13[$pref::LanguageType]; }
//
$Lang_levelEditorMap14[0]="����";
$Lang_levelEditorMap14[1]="Cancel";
function Language_levelEditorMap14() { return $Lang_levelEditorMap14[$pref::LanguageType]; }
//
$Lang_levelEditorMap15[0]="����";
$Lang_levelEditorMap15[1]="Redo";
function Language_levelEditorMap15() { return $Lang_levelEditorMap15[$pref::LanguageType]; }
//
$Lang_levelEditorMap16[0]="����";
$Lang_levelEditorMap16[1]="Copy";
function Language_levelEditorMap16() { return $Lang_levelEditorMap16[$pref::LanguageType]; }
//
$Lang_levelEditorMap17[0]="����";
$Lang_levelEditorMap17[1]="Cut";
function Language_levelEditorMap17() { return $Lang_levelEditorMap17[$pref::LanguageType]; }
//
$Lang_levelEditorMap18[0]="ճ��";
$Lang_levelEditorMap18[1]="Paste";
function Language_levelEditorMap18() { return $Lang_levelEditorMap18[$pref::LanguageType]; }

//
$Lang_IPInput0[0]="IP����";
$Lang_IPInput0[1]="IP Config";
function Language_IPInput0() { return $Lang_IPInput0[$pref::LanguageType]; }
//
$Lang_IPInput1[0]="������IP��";
$Lang_IPInput1[1]="Server IP:";
function Language_IPInput1() { return $Lang_IPInput1[$pref::LanguageType]; }
//
$Lang_IPInput2[0]="ȷ��";
$Lang_IPInput2[1]="Confirm";
function Language_IPInput2() { return $Lang_IPInput2[$pref::LanguageType]; }
//
$Lang_IPInput3[0]="ȡ��";
$Lang_IPInput3[1]="Cancel";
function Language_IPInput3() { return $Lang_IPInput3[$pref::LanguageType]; }
//
$Lang_IPInput4[0]="������IP��";
$Lang_IPInput4[1]="Enter IP please!";
function Language_IPInput4() { return $Lang_IPInput4[$pref::LanguageType]; }
//
$Lang_IPInput5[0]="IP�ѱ���";
$Lang_IPInput5[1]="IP Saved";
function Language_IPInput5() { return $Lang_IPInput5[$pref::LanguageType]; }
//
$Lang_IPInput6[0]="�˿ڣ�";
$Lang_IPInput6[1]="Port:";
function Language_IPInput6() { return $Lang_IPInput6[$pref::LanguageType]; }
//
$Lang_IPInput7[0]="������˿ڣ�";
$Lang_IPInput7[1]="Enter Port please!";
function Language_IPInput7() { return $Lang_IPInput7[$pref::LanguageType]; }

echo("- Initialized Language");