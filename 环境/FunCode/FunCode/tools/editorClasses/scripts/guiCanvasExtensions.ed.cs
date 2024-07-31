// Extensions to Global Canvas Object for editor use.
function GuiCanvas::toggleFloater( %this, %floaterName )
{
   // Verify Object
   if( !isObject( %floaterName ) )
   {
      editorDebugError("GuiCanvas::toggleFloater - Invalid Floater Name" SPC %floaterName );
      return false;
   }
   
   // This should be more robust - JDD
   if( Canvas.getContent().isMember( %floaterName.getID() ) )
      Canvas.getContent().remove( %floaterName.getID() );
   else
      Canvas.getContent().add( %floaterName.getID() );
   
   // Success
   return true;
}