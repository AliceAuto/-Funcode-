//---------------------------------------------------------------------------------------------
// Torque Game Builder
// Copyright (C) GarageGames.com, Inc.
//---------------------------------------------------------------------------------------------

//---------------------------------------------------------------------------------------------
// Space separated list of editors to load.
//---------------------------------------------------------------------------------------------
$editors = "editorClasses debugger guiEditor projectBuilder particleEditor leveleditor tileLayerEditor projectWizard animationEditor imageEditor behaviorEditor localPointEditor";

$Tools::resourcePath = "tools/";

//---------------------------------------------------------------------------------------------
// Tools Package.
//---------------------------------------------------------------------------------------------
package Tools
{
   function loadKeybindings()
   {
      Parent::loadKeybindings();
      
      // [neo, 6/12/2007 - #3222]
      // Try load this, if it is empty or does not exist it will fall through below
      loadCustomEditorbindings();
      
      if (isObject(levelEditorMap))
         return;
         
      new ActionMap(levelEditorMap);      
                  
      levelEditorMap.bind(keyboard, "lbracket", layerSelectionDown, "移动选择物至靠近屏幕一层");
      levelEditorMap.bind(keyboard, "rbracket", layerSelectionUp, "移动选择物至远离屏幕一层");
      
      levelEditorMap.bind(keyboard, "escape", levelBuilderSetSelectionTool, "激活选择工具");
      
      levelEditorMap.bind(keyboard, "e", levelBuilderSetEditPanel, "显示编辑面板");
      levelEditorMap.bind(keyboard, "c", levelBuilderSetCreatePanel, "显示创建面板");
      levelEditorMap.bind(keyboard, "p", levelBuilderSetProjectPanel, "显示项目面板");
      
      levelEditorMap.bind(keyboard, "home", levelBuilderHomeView, "屏幕复位");
      levelEditorMap.bind(keyboard, "end", levelBuilderZoomToFit, "显示所有精灵");
      levelEditorMap.bind(keyboard, "equals", levelBuilderZoomViewIn, "放大窗口");
      levelEditorMap.bind(keyboard, "minus", levelBuilderZoomViewOut, "缩小窗口");
      levelEditorMap.bind(keyboard, "left", levelBuilderViewLeft, "向左移动窗口");
      levelEditorMap.bind(keyboard, "right", levelBuilderViewRight, "向右移动窗口");
      levelEditorMap.bind(keyboard, "up", levelBuilderViewUp, "向上移动窗口");
      levelEditorMap.bind(keyboard, "down", levelBuilderViewDown, "向下移动窗口");
      levelEditorMap.bindCmd(keyboard, "F5", "runGame();", "");
      
      if($platform $= "macos")
      {
         levelEditorMap.bind(keyboard, "cmd z",       levelBuilderUndo, "Undo The Last Action");
         levelEditorMap.bind(keyboard, "cmd-shift z", levelBuilderRedo, "Redo an Undone Action");
         levelEditorMap.bind(keyboard, "cmd c",       levelBuilderCopy, "Copy the Selected Objects");
         levelEditorMap.bind(keyboard, "cmd x",       levelBuilderCut, "Cut the Selected Objects");
         levelEditorMap.bind(keyboard, "cmd v",       levelBuilderPaste, "Paste Cut or Copied Objects");
      }
      else
      {
         levelEditorMap.bind(keyboard, "ctrl z", levelBuilderUndo, "撤销");
         levelEditorMap.bind(keyboard, "ctrl y", levelBuilderRedo, "重做");
         levelEditorMap.bind(keyboard, "ctrl c", levelBuilderCopy, "拷贝");
         levelEditorMap.bind(keyboard, "ctrl x", levelBuilderCut, "剪切");
         levelEditorMap.bind(keyboard, "ctrl v", levelBuilderPaste, "粘贴");
      }

   }
   
   // [neo, 6/12/2007 - #3222]
   // Save out key bindings if they have changed
   function saveCustomEditorBindings()
   {      
      %bindFile = getPrefsPath( "customEditorBind.cs" );
      
      levelEditorMap.save( %bindFile );
   }

   // [neo, 6/12/2007 - #3222]
   // Save out key bindings if they have changed
   function loadCustomEditorbindings()
   {
      %bindFile = getPrefsPath( "customEditorBind.cs" );
   
      if( isFile( %bindFile ) )
      {
         exec( %bindFile );
      
         return true;
      }
      
      return false;
   }

   
   // [neo, 6/1/2007 - #3168]
   // On windows platform make sure tool and game executables 
   function checkPlatformAssociations()
   {
      if( $platform $= "windows" )
      {
         %tgbr = new TGBRegistryManager();
   
         if( isObject( %tgbr ) )
         {
            //if( !%tgbr.fileAssociationExists() )
               %tgbr.setFileAssociations();
      
            //if( !%tgbr.executablePathsAreRegistered() )
               %tgbr.registerExecutablePaths();
         
            %tgbr.delete();
         }
      }
   }
   
   // Start-up.
   function onStart()
   {
      Parent::onStart();
      
      //%toggle = $Scripts::ignoreDSOs;
      //$Scripts::ignoreDSOs = true;
       
      echo(" % - Initializing Tools");
      
      // Common GUI stuff.
      exec("./gui/cursors.ed.cs");
      exec("./gui/profiles.ed.cs");
   
      $ignoredDatablockSet = new SimSet();
   
      // [neo, 6/1/2007 - #3166]
      //checkPlatformAssociations();
   
      %count = getWordCount($editors);
      for (%i = 0; %i < %count; %i++)
      {
         exec("./" @ getWord($editors, %i) @ "/main.cs");
         call("initialize" @ getWord($editors, %i));
      }

      // Make sure we get editor profiles before any GUI's
      exec("./gui/guiDialogs.ed.cs");

      // Load up the tools resources. All the editors are initialized at this point, so
      // resources can override, redefine, or add functionality.
      Tools::LoadResources( $Tools::resourcePath );
      
      //$Scripts::ignoreDSOs = %toggle;
   }
   
   // Shutdown.
   function onExit()
   {
      GuiFormManager::SaveLayout(LevelBuilder, Default, User);
      
      %count = getWordCount($editors);
      for (%i = 0; %i < %count; %i++)
      {
         call("destroy" @ getWord($editors, %i));
      }
      
      // Export Preferences.
      echo("Exporting Gui preferences.");
      export("$Pref::FileDialogs::*", "fileDialogPrefs.cs", false);
	
      // Call Parent.
      Parent::onExit();
   }
};

function Tools::LoadResources( %path )
{
   %resourcesPath = %path @ "resources/";
   %resourcesList = getDirectoryList( %resourcesPath );
   
   %wordCount = getFieldCount( %resourcesList );
   for( %i = 0; %i < %wordCount; %i++ )
   {
      %resource = GetField( %resourcesList, %i );
      if( isFile( %resourcesPath @ %resource @ "/resourceDatabase.cs") )
         ResourceObject::load( %path, %resource );
   }
}


//-----------------------------------------------------------------------------
// Activate Package.
//-----------------------------------------------------------------------------
activatePackage(Tools);

