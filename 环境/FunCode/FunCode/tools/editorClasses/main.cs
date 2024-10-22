//-----------------------------------------------------------------------------
// Torque2D Editor Classes
// Copyright (C) GarageGames.com, Inc.
//-----------------------------------------------------------------------------

function initializeEditorClasses()
{
   echo(" % - Initializing Tools Base");


   $EditorClassesGroup = "EditorClassesCleanup";
   if( !isObject( $EditorClassesGroup ) )
      new SimGroup( $EditorClassesGroup );


   //-----------------------------------------------------------------------------
   // Load Editor Profiles
   //-----------------------------------------------------------------------------
   
   exec("./gui/editorProfiles.ed.cs");
   exec("./scripts/fileLoader.ed.cs");   
   
   loadDirectory( expandFilename("./gui/panels") );
   

   //-----------------------------------------------------------------------------
   // Setup Preferences Manager
   //-----------------------------------------------------------------------------
   
   exec("./scripts/preferencesManager.ed.cs");
   initPreferencesManager();
   
   //-----------------------------------------------------------------------------
   // Load Form Managers
   //-----------------------------------------------------------------------------
   
   exec("./scripts/guiFormLibraryManager.ed.cs");
   exec("./scripts/guiFormContentManager.ed.cs");
   exec("./scripts/guiFormReferenceManager.ed.cs");
   exec("./scripts/guiFormLayoutManager.ed.cs");
   exec("./scripts/guiFormMessageManager.ed.cs");
   exec("./scripts/resourceFinder.ed.cs");
   exec("./scripts/resourceLoader.ed.cs");
   exec("./scripts/debugOutput.ed.cs");
   exec("./scripts/guiCanvasExtensions.ed.cs");   
   exec("./scripts/editorMenus.ed.cs");
   exec("./scripts/expandos.ed.cs");
   exec("./scripts/utility.ed.cs");
   setupBaseExpandos();

   // User Display
   exec("./scripts/contextPopup.ed.cs");

   // Project Support   
   exec("./scripts/projects/projectEvents.ed.cs");
   exec("./scripts/projects/projectInternalInterface.ed.cs");
   
   // Input
   exec("./scripts/input/inputEvents.ed.cs");
   exec("./scripts/input/dragDropEvents.ed.cs");
   exec("./scripts/input/applicationEvents.ed.cs");
   
   // Form Class
   exec("./scripts/guiFormClass.ed.cs");
   exec("./scripts/guiClasses/guiThumbnailPopup.ed.cs");
   exec("./scripts/guiClasses/guiThumbnail.ed.cs");
   exec("./scripts/RSSNews/RSSFeedScript.ed.cs");

   // Start Page
   exec("./gui/tgbStartPage.ed.gui");
   exec("./gui/tgbStartPage.ed.cs");
   exec("./gui/FunCodeStartPage.ed.gui");
   exec("./gui/FunCodeStartPage.ed.cs");
   
   loadDirectory( expandFilename("./scripts/core") );
   loadDirectory( expandFilename("./scripts/platform") );
   

   // Initialize.
   GuiFormManager::Init();
}

function destroyEditorClasses()
{

   // Destroy.
   GuiFormManager::Destroy();
}
