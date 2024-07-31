
//=================================================================
//
//
function OpenAccountInputBox()
{
   Canvas.pushDialog(AccountInputBox);
   
   //
   if( 2 == $levelEditor::SelectedServerType )
   {
      RemoteServerBtn.performClick();
   }
   else
   {
      LocalServerBtn.performClick();
   }
}

//=================================================================
//
//
function OpenConnectWait_NoDB()
{
   Canvas.pushDialog(ConnectWait_NoDB);
}

//=================================================================
//
//
function AccountInputCancelClick()
{
   //Canvas.popDialog( AccountInputBox );
   //
   FunCodeLoginCancel();
}

//==================================================================
//
//
function AccountInputOKClick()
{
   %szAccount = AccountInput_Account.getText();
   %szPassword = AccountInput_Password.getText();
   
   %AccountLen = strlen( %szAccount );
   %PasswordLen = strlen( %szPassword );
   
   if( %AccountLen < 1 )
   {
      MessageBoxOK( "����", "�������˺�" );
      return;
   }
   if( %AccountLen > 20 )
   {
      MessageBoxOK( "����", "������С��20����ĸ���˺�" );
      return;
   }
   
   if( %PasswordLen < 1 )
   {
      MessageBoxOK( "����", "����������" );
      return;
   }
   if( %PasswordLen > 16 )
   {
      MessageBoxOK( "����", "������С��16����ĸ������" );
      return;
   }
           
   //Canvas.popDialog( AccountInputBox );
   //
   FunCodeLoginClick( %szAccount, %szPassword, $levelEditor::SelectedServerType );
}

//==================================================================
//
//
function FunCodeLoginOnline()
{
   Canvas.popDialog( AccountInputBox );
   Canvas.popDialog( ConnectWait_NoDB );
}

//==================================================================
//
//
function AccountInput_Account::onReturn(%this)
{
   AccountInputOKClick();
}

//==================================================================
//
//
function AccountInput_Password::onReturn(%this)
{
   AccountInputOKClick();
}

//==================================================================
//
//
function SelectServerType( %Type )
{
   $levelEditor::SelectedServerType = %Type;
}
