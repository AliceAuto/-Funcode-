//------------------------------------------------------------------------------
// Torque Game Builder
// Copyright (C) GarageGames.com, Inc.
//------------------------------------------------------------------------------

function isInList( %word, %list )
{
   %count = getWordCount( %list );
   for( %i = 0; %i < %count; %i++ )
   {
      %entry = getField( %list, %i );
      if( %word $= %entry )
         return true;
   }
   
   return false;
}

function isInFieldList(%word, %list)
{
   %count = getFieldCount( %list );
   for( %i = 0; %i < %count; %i++ )
   {
      %entry = getField( %list, %i );
      if( %word $= %entry )
         return true;
   }
   
   return false;
}
