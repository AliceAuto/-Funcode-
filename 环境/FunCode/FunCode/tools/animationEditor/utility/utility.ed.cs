//---------------------------------------------------------------------------------------------
// Torque Game Builder
// Copyright (C) GarageGames.com, Inc.
//---------------------------------------------------------------------------------------------

/// @group Utility Functions

/// Point2F(float ar, float dimension)
/// Gets dimensions at the specified aspect ratio.
/// @param ar The aspect ratio of the dimensions to return.
/// @parem dimension The dimension of the shorter side in the returned extent.
/// @return The desired width and height.
function resolveAspectRatio(%ar, %dimension)
{
   %width = %dimension;
   %height = %dimension;
   if (%ar > 1.0)
      %width *= %ar;
   else
      %height /= %ar;
      
   return %width SPC %height;
}

/// float(float value, float min, float max)
/// Clamps the value between two numbers.
/// @param value The value to clamp.
/// @param min The minimum value to return.
/// @param max The maximum value to return.
/// @return 'max' if 'value' is greater than 'max', 'min' if 'value' is less
/// than 'min', otherwise 'value'.
function clamp(%value, %min, %max)
{
   if (%value < %min)
      return %min;
   
   if (%value > %max)
      return %max;
      
   return %value;
}

/// String(String name)
/// Makes sure a given name is valid and unused.
/// @param name The name to validate.
/// @return The validated name.
function validateObjectName(%name)
{
   // Remove whitespace
   %name = trim(%name);
   
   %firstChar = getSubStr(%name, 0, 1);
   
   // If it begins with a number place a '_' before the first character.
   if (strpos("0123456789", %firstChar) != -1)
      %name = "_" @ %name;
   
   // Replace whitespaces with underscores.
   %name = strreplace(%name, " ", "_");
   
   // Remove any other invalid characters
   %name = stripChars(%name, "-+*/%$&§=()[].?\"#,;!~<>|°^{}");
   
   // And if we have nothing left...
   if (%name $= "")
      %name = "Unnamed";
   
   // Make sure it's not being used.
   if (isObject(%name))
   {
      // Add numbers starting with 1 until we find a valid one.
      %base = %name;
      for (%i = 1; isObject(%name); %i++)
         %name = %base @ %i;
   }
   
   return %name;
}

//
function IsValidObjectName( %name )
{
   %Len = strlen( %name );
   if( %Len < 1 )
      return true;
      
   %firstChar = getSubStr(%name, 0, 1);
   if(strpos("0123456789", %firstChar) != -1)
      return false;
      
   for( %iLoop = 0; %iLoop < %Len; %iLoop++ )
   {
      %OneChar = getSubStr(%name, %iLoop, 1);
      if(strpos("0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ_", %OneChar) == -1)
         return false;
   }
   
   return true;
}

/// @endgroup

/// void(SimSet this, bool deleteObjects = false)
/// Deletes all the objects in the set.
/// @param this The SimSet
function SimSet::deleteContents(%this)
{
   // Iterate.
   while (%this.getCount() > 0)
      %this.getObject(0).delete();
}

/// Point2F(t2dSceneWindow this, Point2F size)
/// Converts a size from world coordinates to window coordinates.
/// @param this The t2dSceneWindow.
/// @param size The size to convert.
/// @return The converted value.
function t2dSceneWindow::getWindowSize(%this, %size)
{
   %origin = %this.getWindowPoint("0 0");
   %size = %this.getWindowPoint(%size);
   %size = t2dVectorSub(%size, %origin);
   return %size;
}

/// Point2F(t2dSceneWindow this, Point2F size)
/// Converts a size from window coordinates to world coordinates.
/// @param this The t2dSceneWindow.
/// @param size The size to convert.
/// @return The converted value.
function t2dSceneWindow::getWorldSize(%this, %size)
{
   %origin = %this.getWorldPoint("0 0");
   %size = %this.getWorldPoint(%size);
   %size = t2dVectorSub(%size, %origin);
   return %size;
}

/// String(String input, String count)
/// Returns a string with the proper is/are and -s depending on a count.
/// @param input The input string. {are} will be replaced with 'is' or 'are',
/// depending on count, {s} will be replaced with 's' or '' depending on count,
/// and {count} will be replaced with the count.
/// @param count Arbitrary number that determines the format of the string.
/// @return The input string with the correct grammar for the input count.
function getCountString(%input, %count)
{
   %isare = %count == 1 ? "is" : "are";
   %s = %count == 1 ? "" : "s";
   %output = strreplace(%input, "{are}", %isare);
   %output = strreplace(%output, "{s}", %s);
   %output = strreplace(%output, "{count}", %count);
   return %output;
}
