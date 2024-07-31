

function FunCodeStartPage::onWake( %this )
{
   SelectProject_RadioC.performClick();
}

$SelectProjectRadio = 1;

function SelectProjectClick()
{
   createSourceProject( $SelectProjectRadio );
   Canvas.popDialog(SelectProjectCreateGui);
}

function SelectProjectRadioClick( %Index )
{
   $SelectProjectRadio = %Index;
}