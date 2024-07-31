function GameConfigXML::writeField( %this, %field, %value )
{
   if( !%this.pushFirstChildElement( %field ) )
      %this.pushNewElement( %field );
   else
      %this.removeText();
      
   %this.addText( %value );
   %this.popElement();
}

function GameConfigXML::readField( %this, %field )
{
   %value = "";
   if( %this.pushFirstChildElement( %field ) )
   {
      %value = %this.getText();
      %this.popElement();
   }
   
   return %value;
}
