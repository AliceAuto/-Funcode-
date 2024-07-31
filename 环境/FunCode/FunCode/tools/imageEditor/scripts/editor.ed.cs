// --------------------------------------------------------------------
// launchNewImageMap()
//
// This will launch the file browser to create a new image map.
// --------------------------------------------------------------------

$T2D::ImageMapSpec = "All Supported Graphics (*.dds;*.jpg;*.bmp;*.png)|*.dds;*.png;*.jpg;*.bmp|";
function launchNewImageMap()
{
   %dlg = new OpenFileDialog()
   {
      Filters = $T2D::ImageMapSpec;
      ChangePath = false;
      MustExist = true;
      MultipleFiles = true;
   };
   
   %dlg.DefaultPath = $Pref::Dialogs::LastImagePath;
      
   if(%dlg.Execute())
   {    
      // Store last image path
      $Pref::Dialogs::LastImagePath = filePath( %dlg.files[0] );
      
      // Loop and add selected files where appropriate
      for(%i = 0;%i < %dlg.fileCount;%i++)
      {
         %fileName     = %dlg.files[%i];
         %fileOnlyName = fileName( %fileName );         
         %fileBase     = validateDatablockName( fileBase( %fileOnlyName ) @ "ImageMap" );
         
         // [neo, 5/15/2007 - #3117]
         // If the image is already in a sub dir of images don't copy it just use
         // the same path and update the image map to use it.
         %checkPath    = expandFilename( "^game/data/images/" );
         %fileOnlyPath = filePath( expandFileName( %fileName ) );
         %fileBasePath = getSubStr( %fileOnlyPath, 0, strlen( %checkPath ) );           
   
         if( %checkPath !$= %fileBasePath )         
         {                     
            %newFileLocation = expandFilename("^game/data/images/" @ %fileOnlyName );
            
            addResPath( filePath( %newFileLocation ) );
                  
            pathCopy( %fileName, %newFileLocation );
         }            
         else
         {
            // Already exists in data/images or sub dir so just point to it
            %newFileLocation = %fileName;
         }
         
         // Error of some sort, skip it.
         if( !isFile( %newFileLocation ) )
            continue;
            
         %datablock = "datablock t2dImageMapDatablock(" @ %fileBase @ ")\n";      
         %datablock = %datablock SPC "{\n";
         %datablock = %datablock SPC "imageName = " @ "\"" @ %newFileLocation @ "\"" @ ";\n";
         %datablock = %datablock SPC "imageMode = FULL;\n";
         %datablock = %datablock SPC "};";
         eval(%datablock);
         
         if( !isObject( %fileBase ) )
            continue;
         
         LBProjectObj.addDatablock( %fileBase, false );
         
      }
      
      LBProjectObj.persistToDisk( true, false, false );

      // Update object library
      GuiFormManager::SendContentMessage($LBCreateSiderBar, %this, "refreshAll 1");

   }
   %dlg.delete();
}

function validateDatablockName(%name)
{
   // remove whitespaces at beginning and end
   %name = trim( %name );
   
   // If it begins with a number place a _ before it   
   // the first character
   %firstChar = getSubStr( %name, 0, 1 );
   // if the character is a number remove it
   if( strpos( "0123456789", %firstChar ) != -1 )
      %name = "_" @ %name;
   
   // replace whitespaces with underscores
   %name = strreplace( %name, " ", "_" );
   
   // remove any other invalid characters
   %name = stripChars( %name, "-+*/%$&§=()[].?\"#,;!~<>|°^{}" );
   
   if( %name $= "" || !IsValidObjectName(%name) )
      %name = "Unnamed";
    
    
   // Generate valid Non-Existent name
   if( isObject( %name ) )
   {
      // Add numbers starting with 1 until we find a valid one
      %i = 1;
      while( isFile( %name @ %i ) )
         %i++;
      %name = %name @ %i;
   }
   
   return %name;
}

// --------------------------------------------------------------------
// loadImageEditor()
//
// This will load a new image into the Image Builder(usually passed 
// from the file browser).
// --------------------------------------------------------------------
function loadImageEditor(%imageMap)
{  
   // lets make our name the bame of the image
   %name = fileBase(%imageMap.getSrcBitmapName());
   
   // make a valid datablock name out of this
   %name = validateDatablockName( %name );
   
   // if there is already an object with this name
   // then lets look through the names with numbers
   // appended to them until we have a valid name
   %name = %name @ "ImageMap";
   if(isObject(%name))
   {
      %base = %name;
      for(%i=2;isObject(%name);%i++)
         %name = %base @ %i;
   }
   
   ImageEditor.imageName = %name;
   ImageEditor.editing = false;
   
   // set the image map's name
   %imageMap.setName(%name);
   %imageMap = %name;
   
   ImageEditor.sourceDB = %imageMap.getID();
   // store this to compare to link image maps if we save
   ImageEditor.originalName = %imageMap.getName();
   ImageEditor.prevname = ImageEditor.originalName;
   
   ImageEditor.previewDB = copyDB(%imageMap, prevT2DImageMap);
   
   // check if our clean-up object exists
   if(!isObject(ImageEditor.cleanUp))
      ImageEditor.cleanUp = new SimSet();
   
   // setup our image editor and close our file dialog
   // and open our image builder dialog
   setupImageMapEditor();
   ImageEditor.setupPreviewWindow();

   Canvas.popDialog(OpenFileDlgExwPreview);
   Canvas.pushDialog(ImageBuilderGui);  
   
   // load our new image
   ImageEditor.loadPreview(prevT2DImageMap);
}

// --------------------------------------------------------------------
// ImageBuilderGui::onSleep()
//
// This ensures when we close the ImageBuilderGui the global is toggled
// to false.
// --------------------------------------------------------------------
function ImageBuilderGui::onSleep(%this)
{
   $ImageEditorLoaded = false;   
}

// --------------------------------------------------------------------
// launchNewLinkImageMap()
//
// This is called when a new link image map is called to be created,
// it will create a base link image map and then pass it to the editor.
// --------------------------------------------------------------------
function launchNewLinkImageMap()
{
   %name = "linkImage";
   
   if(isObject(%name))
   {
      %base = %name;
      for(%i=0;isObject(%name);%i++)
         %name = %base @ %i;
   }
   
   //lets grab two default images
   %dbSet = getT2DDatablockSet();

   %count = %dbSet.getCount();
   %linkCount = 0;
   for(%i=0;%i<%count;%i++)
   {
      %db = %dbSet.getObject(%i);
      if(!$ignoredDatablockSet.isMember(%db) && %db.getClassName() $= "t2dImageMapDatablock" && %db.getImageMapMode() !$= "LINK")
      {  
         if( !%db.preload )
            continue;
         
         %linkImageMaps = %linkImageMaps @ %db.getName();
         
         %linkCount++;
         if(%linkCount >= 2)
         {
            break;
         } else
         {
            %linkImageMaps = %linkImageMaps @ " ";            
         }
      }
   }

   if(%linkCount < 2)
      return;

   %datablock = "datablock t2dImageMapDatablock(" @ %name @ ")\n";
   %datablock = %datablock SPC "{\n";
   %datablock = %datablock SPC "imageMode = LINK;\n";
   %datablock = %datablock SPC "filterpad = true;\n";
   %datablock = %datablock SPC "linkImageMaps = " @ "\"" @ %linkImageMaps @ "\"" @ ";\n";
   %datablock = %datablock SPC "};";
   eval(%datablock);
   
   // rdbnote: this is kind of a hack, but add this datablock to the ignore list
   // until it is either saved or the user cancels out of the image builder
   $ignoredDatablockSet.add(%name);

   ImageEditor.editing = false;
   ImageEditor.editImageMap(%name);
}

// --------------------------------------------------------------------
// launchEditImageMap()
//
// Passing an image map into this will cause the Image Builder to be 
// launched editing that image map.
// --------------------------------------------------------------------
function launchEditImageMap(%imageMap)
{   
   ImageEditor.editing = true;
   
   ImageEditor.editImageMap(%imageMap);   
}

function ImageEditor::editImageMap(%this, %imageMap)
{
   if(!isObject(%imageMap))
      return;
   
   if(%imageMap.getImageMapMode() $= "LINK")
      %link = true;
   
   setupImageMapEditor(%link);

   Canvas.pushDialog(ImageBuilderGui);
   %this.imageName = %imageMap.getName();
   ImageEditor.launchImageEditor(%imageMap);
}

// Toggle loading preview to false
ImageEditor.loadingPreview = false;

// --------------------------------------------------------------------
// function ImageEditor::launchImageEditor()
//
// This is called both when a new image is created and when an already
// existing image map is being edited.  We copy the image map datablock
// into a temporary holder so if we cancel we can reset the settings.
// --------------------------------------------------------------------
function ImageEditor::launchImageEditor(%this, %imageMap)
{
   // Store the starting name for name checks
   ImageEditor.prevName = %imageMap.getName();
   
   ImageEditor.setupPreviewWindow();
   
   if(!isObject(%this.cleanUp))
      %this.cleanUp = new SimSet();
   
   %this.sourceDB = %imageMap.getID();
   // store this to compare to link image maps if we save
   %this.originalName = %imageMap.getName();
   
   %this.previewDB = copyDB(%imageMap, prevT2DImageMap);
   
   %this.cleanUp.add(prevT2DImageMap);
   
   %this.loadPreview(prevT2DImageMap);
}

// --------------------------------------------------------------------
// ImageEditor::saveImage()
//
// This gets called when the user clicks the save button, it clears
// out the proper data and adds the newly created imageMap to the
// managed datablock (if it isn't already there in the case of editing), 
// as well as calling the object libraries to refresh.
// --------------------------------------------------------------------
function ImageEditor::saveImage(%this)
{
   %imageMap = %this.sourceDB;
   %previewImageMap = %this.previewDB;
   
   // rdbnote: remove the image from the ignore list
   $ignoredDatablockSet.remove(%imageMap);
   
   if(%this.editing)
   {
      %referenceList = new SimSet();
      %val = $currentSceneGraph.getImageMapReferenceList(%imageMap, %referenceList);
      %referenceList.delete();
   }
   
   %imageDBName = ImageEditorTxtImageName.getValue();
   
   %imageDBName = validateDatablockName( %imageDBName );
   
   %imageDB = restoreDB(%previewImageMap.getID(), %imageMap.getID(), %imageDBName);
  
   if(%this.editing)
   { 
      // Now we must check to see if this image map is used in any link image maps
      // if so we must update them properly and compile them as well or we will get
      // a nice little crash
      
      if(%val >= 8)
      {
         // if this val is 8 or greater than we have some link image maps referencing it
         %linkDBList = $AnimationBuilder::linkDatablockImageReferenceList;
         %linkDBCount = %linkDBList.getCount();
         for(%i=0;%i<%linkDBCount;%i++)
         {
            %linkDB = %linkDBList.getObject(%i);
                     
            %linkImageCount = getWordCount(%linkDB.linkImageMaps);
            
            for(%j=0;%j<%linkImageCount;%j++)
            {
               %linkImage = getWord(%linkDB.linkImageMaps, %j);

               if(%linkImage $= %this.originalName)
               {
                  %linkImage = %imageMap.getName();
               }
               
               if(%j==0)
               {
                  %linkImageList = %linkImage;
               } else
               {
                  %linkImageList = %linkImageList SPC %linkImage;
               }
            }
            
            %linkDB.linkImageMaps = %linkImageList;
            %linkDB.compile();
         }
      }
   }
         
   // hide away our Image Builder GUI
   Canvas.popDialog(ImageBuilderGui);
   
   // clear the preview and our data
   %this.clearPreview();
   %this.clearData();
      
   // if we're creating a new image then add it to the managed datablocks
   if(!%this.editing)
      LBProjectObj.addDatablock( %imageDB, true );
   else // Just update our set
      LBProjectObj.persistToDisk( true, false, false );
   
   // tell the object library to refresh
   GuiFormManager::SendContentMessage($LBCreateSiderBar, %this, "refreshall 0");
}

// --------------------------------------------------------------------
// ImageEditor::cancel()
//
// This gets called when the user clicks the cancel button, it cleans up
// some resources and then closes out the Image Builder.
// --------------------------------------------------------------------
function ImageEditor::cancel(%this)
{
   // rdbnote: remove the image from the ignore list
   $ignoredDatablockSet.remove(%this.sourceDB);
   
   if( !%this.editing )
   {
      if(isObject(%this.sourceDB))
         %this.sourceDB.delete();
   }
   
   %this.clearPreview();
   %this.clearData();
      
   Canvas.popDialog(ImageBuilderGui);
}

// --------------------------------------------------------------------
// ImageEditor::imageFileBrowser()
//
// This gets called when the user clicks the file browser button, it 
// calls the cancel functionality then spawns the file browser.
// --------------------------------------------------------------------
function ImageEditor::imageFileBrowser(%this)
{
   %imageMap = %this.selectedImage;

   if(!isObject(%imageMap))
      return; 
   
   %dlg = new OpenFileDialog()
   {
      Filters = $T2D::ImageMapSpec;
      DefaultFile = %imageMap.getSrcBitmapName();
      ChangePath = false;
      MustExist = true;
      MultipleFiles = false;
   };

   // Update Image        
   if(%dlg.Execute())
   {
      %imageMap.imageName = %dlg.FileName;
      %this.reCreateImage();
   }
   %dlg.delete();   
}

// --------------------------------------------------------------------
// ImageEditor::delete()
//
// This gets called when the user clicks the delete button, it will prompt
// the user to make sure they do in fact want to delete this image map.
// --------------------------------------------------------------------
function ImageEditor::delete(%this)
{
   // prompt the user with how many references this image map has
   checkImageMapReference(%this.sourceDB, Toolmanager.getLastWindow().getScenegraph(), "ImageEditor.cancel();");
   
   // [neo, 15/6/2007 - #3231]
   // This doesnt exist so forward it to the SBCreateTrash method.
   // checkImageMapReferences( %this.sourceDB, Toolmanager.getLastWindow().getScenegraph(), "ImageEditor.cancel();" );   
   
   // Save image map ref as this will be cleared when we call cancel()
   %imageMap = %this.sourceDB;
   
   // Close first so it cleans up correctly
   %this.cancel();
   
   // Take out the trash...
   SBCreateTrash::deleteImageMap( %imageMap );
          
   // set the tool to the selection tool otherwise next click you'll try and create
   // and image that doesn't exist 
   LevelBuilderToolManager::setTool(LevelEditorSelectionTool);
}

// --------------------------------------------------------------------
// ImageEditor::deleteImage()
//
// This gets called if the user is sure they want to delete the image map,
// it will first grab the image, then call the cancel functionality, then
// it will delete the image map.
// --------------------------------------------------------------------
function ImageEditor::deleteImage(%this)
{
   %this.cancel();
}

function ImageEditor::help(%this)
{
   
}

function ImageEditor::clearData(%this)
{
   if(isObject(%this.previewDB.getID()))
      %this.previewDB.getID().delete();
   
   %this.startingName = "";
   %this.selectedImage = "";
   %this.previewDB = "";
   %this.sourceDB = "";
   
   %this.previewCleanup();
}

// Image Editor Specific Functions
function copyDB(%oldName, %newName)
{
   if((%oldName $= "" || %newName $= "") || !isObject(%oldName))
      return;
   
   if(isObject(%newName))
      %newName.delete();
   
   //%datablock = "datablock t2dImageMapdatablock(" @ %newName @ " : " @ %oldName.getName() @ ")\n";
   // the datablock xyz( name : parent ) {}; syntax seems to have troubles "-" signs in it
   // so better copy the fields by hand
   
   %datablock = "datablock t2dImageMapdatablock(" @ %newName @ ")\n";
   %datablock = %datablock @ "{\n";
      %datablock = %datablock @ "imageName = " @ "\"" @ %oldName.imageName @ "\"" @ ";\n";
      %datablock = %datablock @ "imageMode = " @ %oldName.imageMode @ ";\n";
      %datablock = %datablock @ "cellWidth = " @ %oldName.cellWidth @ ";\n";
      %datablock = %datablock @ "cellHeight = " @ %oldName.cellHeight @ ";\n";
      %datablock = %datablock @ "filterMode = " @ %oldName.filterMode @ ";\n";
      %datablock = %datablock @ "filterPad = " @ %oldName.filterPad @ ";\n";
      %datablock = %datablock @ "frameCount = "  @ %oldName.frameCount @ ";\n";
      %datablock = %datablock @ "preferPerf = "  @ %oldName.preferPerf @ ";\n";
      %datablock = %datablock @ "cellRowOrder = "  @ %oldName.cellRowOrder @ ";\n";
      %datablock = %datablock @ "cellOffsetX = " @ %oldName.cellOffsetX @ ";\n";
      %datablock = %datablock @ "cellOffsetY = " @ %oldName.cellOffsetY @ ";\n";
      %datablock = %datablock @ "cellStrideX = " @ %oldName.cellStrideX @ ";\n";
      %datablock = %datablock @ "cellStrideY = "  @ %oldName.cellStrideY @ ";\n";
      %datablock = %datablock @ "cellCountX = " @ %oldName.cellCountX @ ";\n";
      %datablock = %datablock @ "cellCountY = " @ %oldName.cellCountY @ ";\n";
      %datablock = %datablock @ "preload = " @ %oldName.preload @ ";\n";
      %datablock = %datablock @ "allowUnload = " @ %oldName.allowUnload @ ";\n";
      %datablock = %datablock @ "force16Bit = " @ %oldName.force16Bit @ ";\n";
      %datablock = %datablock @ "linkImageMaps = \"" @ %oldName.linkImageMaps @ "\";\n";
   %datablock = %datablock @ "};\n";

   eval(%datablock);

   %id = %newName.getID();
   
   return %newName.getID();
}

function restoreDB(%oldName, %newName, %name)
{
   if((%oldName $= "" || %newName $= "") || !isObject(%oldName) || !isObject(%newName))
      return;
   
   %newName.setName(%name);
   %newName.imageName = %oldName.imageName;
   %newName.filterMode = %oldName.filterMode;
   %newName.filterPad = %oldName.filterPad;
   %newName.preferPerf = %oldName.preferPerf;
   %newName.preload = %oldName.preload;
   %newName.allowUnload = %oldName.allowUnload;
   %newName.force16Bit = %oldName.force16Bit;
   %newName.imageMode = %oldName.imageMode;

   %newName.cellCountX = %oldName.cellCountX;
   %newName.cellCountY = %oldName.cellCountY;
   %newName.cellHeight = %oldName.cellHeight;
   %newName.cellWidth = %oldName.cellWidth;
   %newName.cellOffsetX = %oldName.cellOffsetX;
   %newName.cellOffsetY = %oldName.cellOffsetY;
   %newName.cellStrideX = %oldName.cellStrideX;
   %newName.cellStrideY = %oldName.cellStrideY;
   %newName.cellRowOrder = %oldName.cellRowOrder; 
   
   %newName.linkImageMaps = %oldName.linkImageMaps;
   
   %newName.compile();
   
   return %newName.getID();  
}