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
                  
      levelEditorMap.bind(keyboard, "lbracket", layerSelectionDown, "�ƶ�ѡ������������Ļһ��");
      levelEditorMap.bind(keyboard, "rbracket", layerSelectionUp, "�ƶ�ѡ������Զ����Ļһ��");
      
      levelEditorMap.bind(keyboard, "escape", levelBuilderSetSelectionTool, "����ѡ�񹤾�");
      
      levelEditorMap.bind(keyboard, "e", levelBuilderSetEditPanel, "��ʾ�༭���");
      levelEditorMap.bind(keyboard, "c", levelBuilderSetCreatePanel, "��ʾ�������");
      levelEditorMap.bind(keyboard, "p", levelBuilderSetProjectPanel, "��ʾ��Ŀ���");
      
      levelEditorMap.bind(keyboard, "home", levelBuilderHomeView, "��Ļ��λ");
      levelEditorMap.bind(keyboard, "end", levelBuilderZoomToFit, "��ʾ���о���");
      levelEditorMap.bind(keyboard, "equals", levelBuilderZoomViewIn, "�Ŵ󴰿�");
      levelEditorMap.bind(keyboard, "minus", levelBuilderZoomViewOut, "��С����");
      levelEditorMap.bind(keyboard, "left", levelBuilderViewLeft, "�����ƶ�����");
      levelEditorMap.bind(keyboard, "right", levelBuilderViewRight, "�����ƶ�����");
      levelEditorMap.bind(keyboard, "up", levelBuilderViewUp, "�����ƶ�����");
      levelEditorMap.bind(keyboard, "down", levelBuilderViewDown, "�����ƶ�����");
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
         levelEditorMap.bind(keyboard, "ctrl z", levelBuilderUndo, "����");
         levelEditorMap.bind(keyboard, "ctrl y", levelBuilderRedo, "����");
         levelEditorMap.bind(keyboard, "ctrl c", levelBuilderCopy, "����");
         levelEditorMap.bind(keyboard, "ctrl x", levelBuilderCut, "����");
         levelEditorMap.bind(keyboard, "ctrl v", levelBuilderPaste, "ճ��");
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

