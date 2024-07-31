
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
      MessageBoxOK( "´íÎó", "ÇëÊäÈëÕËºÅ" );
      return;
   }
   if( %AccountLen > 20 )
   {
      MessageBoxOK( "´íÎó", "ÇëÊäÈëÐ¡ÓÚ20¸ö×ÖÄ¸µÄÕËºÅ" );
      return;
   }
   
   if( %PasswordLen < 1 )
   {
      MessageBoxOK( "´íÎó", "ÇëÊäÈëÃÜÂë" );
      return;
   }
   if( %PasswordLen > 16 )
   {
      MessageBoxOK( "´íÎó", "ÇëÊäÈëÐ¡ÓÚ16¸ö×ÖÄ¸µÄÃÜÂë" );
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
