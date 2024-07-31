//-----------------------------------------------------------------------------
// Torque Game Builder
// Copyright (C) GarageGames.com, Inc.
//-----------------------------------------------------------------------------

$levelBuilderClipboardFile = getPrefsPath( "levelEditor/clipboard.cs" );
$FunCodeProjectName     =  "DefaultProject";
$FunCodeProjectType     =  "C"; // C,CPP,JAVA
$FunCodeRecover         = 0;
$FunCodeCreate_NotExit  = 0;
$CreateProjectIndex     = 0;
$SetExePathType         =  "Eclipse"; // Eclipse, VC6, VC2008, VC2010, CodeBlock
   
function reloadImageMaps()
{
   flushTextureCache();
   recompileAllImageMaps();
}

function reloadProject()
{
   //[neo, 4/6/2007 - #3192]
   // Track when we are reloading a project
   $pref::reloadLastProject = true;
   
   setCurrentDirectory( expandFilename("^tool/") );
   
   restartInstance();
}

function RecoverLevel()
{
   MessageBoxOKCancel( "注意", "当前打开地图将恢复至第一次打开时状态，是否确定？", "DoRecoverLevel();", "" );
}

function DoRecoverLevel()
{
   if( isFile( LBProjectObj.currentLevelFile ) && isFile( LBProjectObj.currentLevelFile @ ".bak" ) )
   {
      fileDelete( LBProjectObj.currentLevelFile @ ".dso" );
      fileDelete( LBProjectObj.currentLevelFile );
      pathCopy( LBProjectObj.currentLevelFile @ ".bak", LBProjectObj.currentLevelFile, false );
   }
   
   $FunCodeRecover = 1;
   reloadProject();   
}

function SetStartProject(%Index)
{
   if( $FunCodeProjectType $= JAVA )
   {
      if( %Index == 1 )
      {
         $levelEditor::StartJAVAVersion = "JCreator";
      }
      else if( %Index == 2 )
      {
         $levelEditor::StartJAVAVersion = "Eclipse";
      }
      else if( %Index == 3 )
      {
         $levelEditor::StartJAVAVersion = "Netbeans";
      }
   }
   else
   {
      if( %Index == 1 )
      {
         $levelEditor::StartVCVersion = "VCProjectVC6";
      }
      else if( %Index == 2 )
      {
         $levelEditor::StartVCVersion = "VCProject2010";
      }
      else if( %Index == 3 )
      {
         $levelEditor::StartVCVersion = "VCProject2008";
      }
      else if( %Index == 4 )
      {
         $levelEditor::StartVCVersion = "CodeBlock";
      }
   }
   
   Canvas.popDialog(SetStartVCGUI);
}

function SetDevProjectVersion(%Index)
{
   if( $CreateProjectIndex == 2 )
   {
      if( %Index == 1 )
      {
         $levelEditor::DevJAVAVersion = "JCreator";
      }
      else if( %Index == 2 )
      {
         $levelEditor::DevJAVAVersion = "Eclipse";
      }
      else if( %Index == 3 )
      {
         $levelEditor::DevJAVAVersion = "Netbeans";
      }
   }
   else
   { 
      if( %Index == 1 )
      {
         $levelEditor::DevVCVersion = "VCProjectVC6";
      }
      else if( %Index == 2 )
      {
         $levelEditor::DevVCVersion = "VCProject2010";
      }
      else if( %Index == 3 )
      {
         $levelEditor::DevVCVersion = "VCProject2008";
      }
      else if( %Index == 4 )
      {
         $levelEditor::DevVCVersion = "CodeBlock";
      }
   }   
}

function SetProjectArcSingle( %Single )
{
   $LevelEditor::ProjectArcSingle = %Single;
}

function openProjectFolder()
{    
   %project = expandFileName("^project/");
   %project = filePath( %project );
   %project = filePath( %project );
   openFolder(%project); 
 }

function openSourceProject()
{
   if( $FunCodeProjectType $= JAVA )
   {
       if( $levelEditor::StartJAVAVersion $= "" )
      {
         MessageBoxOk("错误", "请先设置启动Java工程");
         return;
      }
      
      %project = expandFileName("^project/");
      %project = filePath( %project );
      %project = filePath( %project );
      
      if( $levelEditor::StartJAVAVersion $= "JCreator" )
      {
         %fileName = %project @ "/SourceCode/JCreatorProject";
         %AppPath = GetRegisterAppPath("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Uninstall\\JCreator Pro_is1", "InstallLocation", 1);
         if( %AppPath $= "" )
            %AppPath = GetRegisterAppPath("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Uninstall\\JCreator LE_is1", "InstallLocation", 1);
            
         if( %AppPath $= "" )
         {
         	%fileName = %project @ "/SourceCode/JCreatorProject/" @ "JCreatorProject.jcw";
         	if(!shellExecute(%fileName))
         	{
            		MessageBoxOk("错误", "无法打开工程文件! 请确认已经安装JCreator软件。");
         	}
            return;
         }
         
         if(!shellExecute( %AppPath @ "JCreator.exe", "JCreatorProject" @ ".jcw",%fileName))//$FunCodeProjectName
         {
            MessageBoxOk("错误", "无法打开工程文件! 请确认是否已经创建该版本工程文件。");
         }
      }
      else if( $levelEditor::StartJAVAVersion $= "Eclipse" )
      {
         if( $levelEditor::EclipsePath $= "" )
         {
            MessageBoxOk("错误", "请先设置Eclipse.exe的位置。");
            return;
         }
         
         %EclipsePath = $levelEditor::EclipsePath;
         if( strstr( %EclipsePath, "eclipse.exe") == -1 )
         {
            MessageBoxOk("错误", "指定的Eclipse无效 [" @ %EclipsePath @ "] ，请重新指定Eclipse.exe位置。");
            return;
         }
         if( !isFile( AnsiToUtf8(%EclipsePath) ) )
         {
            MessageBoxOk("错误", "无法找到Eclipse软件 [" @ %EclipsePath @ "] ，请重新指定Eclipse.exe位置。");
            return;
         }         

         if(!shellExecute( AnsiToUtf8(%EclipsePath), "-data " @ %project))
         {
            MessageBoxOk("错误", "无法打开工程文件! 请确认是否已经创建该版本工程文件。");
         }
      }
      else
      {
         //         
         //MessageBoxOk("提示", "不支持Netbeans");
      }
   }
   else
   {
      if( $levelEditor::StartVCVersion $= "" )
      {
         MessageBoxOk("错误", "请先设置启动VC工程");
         return;
      }
      
      %project = expandFileName("^project/");
      %project = filePath( %project );
      %project = filePath( %project );
      if( $levelEditor::StartVCVersion $= "VCProjectVC6" )
      {
         %VCPath = strlwr( $levelEditor::VC6Path );                  
         if( strstr( %VCPath, "msdev.exe") == -1 )
         {
            %VCPath = GetVC6AppPath(1); 
            %VCPath = strlwr( %VCPath );
         }
                                
         //
         if( strstr( %VCPath, "msdev.exe") == -1 )
         {
            MessageBoxOk("错误", "请确认VC6已经安装，或者已经设置VC6路径。");
         }
         else
         {
            %fileName = %project @ "/SourceCode/" @ $levelEditor::StartVCVersion;
            %fileNameFull = %fileName @ "/" @ $FunCodeProjectName @ ".dsw";
            if( !isFile(%fileNameFull) )
            {
               MessageBoxOk("错误", "未创建该版本工程文件。");
            }
            else
            {
               if(!shellExecute( %VCPath, $FunCodeProjectName @ ".dsw",%fileName))
               {
                  MessageBoxOk("错误", "无法打开工程文件! 请确认是否已经创建该版本工程文件。");
               }
            }
         }
      }
      else if( $levelEditor::StartVCVersion $= "CodeBlock" )
      {
         %VCPath = strlwr( $levelEditor::CodeBlockPath );
         if( strstr( %VCPath, "codeblocks.exe") == -1 )
         {
            %VCPath = GetCodeBlockAppPath(1);
            %VCPath = strlwr( %VCPath );
         }            
            
         if( strstr( %VCPath, "codeblocks.exe") == -1 )
         {
            MessageBoxOk("错误", "请确认CodeBlock已经安装，或者已经设置CodeBlock路径。");
         }
         else
         {
            %fileName = %project @ "/SourceCode/" @ $levelEditor::StartVCVersion;
            %fileNameFull = %fileName @ "/" @ $FunCodeProjectName @ ".cbp";
            if( !isFile(%fileNameFull) )
            {
               MessageBoxOk("错误", "未创建该版本工程文件。");
            }
            else
            {
               if(!shellExecute( %VCPath, $FunCodeProjectName @ ".cbp",%fileName))
               {
                  MessageBoxOk("错误", "无法打开工程文件! 请确认是否已经创建该版本工程文件。");
               }
            }
         }
      }
      else if( $levelEditor::StartVCVersion $= "VCProject2008" )
      {
         %VCPath = strlwr( $levelEditor::VC2008Path );
         if( strstr( %VCPath, "devenv.exe") == -1 )
         {
            %VCPath = GetVC2008AppPath(1);
            %VCPath = strlwr( %VCPath );
         }                    
            
         if( strstr( %VCPath, "devenv.exe") == -1 )
         {
            MessageBoxOk("错误", "请确认VC2008已经安装，或者已经设置VC2008路径。");
         }
         else
         {
            %fileName = %project @ "/SourceCode/" @ $levelEditor::StartVCVersion;
            %fileNameFull = %fileName @ "/" @ $FunCodeProjectName @ ".sln";
            if( !isFile(%fileNameFull) )
            {
               MessageBoxOk("错误", "未创建该版本工程文件。");
            }
            else
            {
               if(!shellExecute( %VCPath, $FunCodeProjectName @ ".sln",%fileName))
               {
                  MessageBoxOk("错误", "无法打开工程文件! 请确认是否已经创建该版本工程文件。");
               }
            }
         }
      }
      else if( $levelEditor::StartVCVersion $= "VCProject2010" )
      {
         %VCPath = strlwr( $levelEditor::VC2010Path );
         if( strstr( %VCPath, "devenv.exe") == -1 )
         {
            %VCPath = GetVC2010AppPath(1);
            %VCPath = strlwr( %VCPath );
         }            
            
         if( strstr( %VCPath, "devenv.exe") == -1 )
         {
            MessageBoxOk("错误", "请确认VC2010已经安装，或者已经设置VC2010路径。");
         }
         else
         {
            %fileName = %project @ "/SourceCode/" @ $levelEditor::StartVCVersion;
            %fileNameFull = %fileName @ "/" @ $FunCodeProjectName @ ".sln";
            if( !isFile(%fileNameFull) )
            {
               MessageBoxOk("错误", "未创建该版本工程文件。");
            }
            else
            {
               if(!shellExecute( %VCPath, $FunCodeProjectName @ ".sln",%fileName))
               {
                  MessageBoxOk("错误", "无法打开工程文件! 请确认是否已经创建该版本工程文件。");
               }
            }
         }
      }
   }
}

function createSourceProject( %Index )
{
   // Trail Version
   //MessageBoxOk("感谢使用", "试用版不支持该功能，请购买正式版。");
   //return;
   
   $CreateProjectIndex  =  %Index;
   Canvas.pushDialog(CreateProjectGUI, 99);
   
   UpdateCreateProjectGUI();
   CreateProject_Name.text = "";
   
   //
   if( $LevelEditor::CreateProjectFolder $= "" )
      $LevelEditor::CreateProjectFolder = getFunCodeGamePath("Games");
   CreateProject_Folder.text = $LevelEditor::CreateProjectFolder;
}

function CreateProject_OK()
{
   if( CreateProject_Name.getText() $= "" )
   {
      MessageBoxOk("错误", "请输入工程名字");
      return;
   }   

   if( !IsValidObjectName( CreateProject_Name.getText() ) )
   {
      MessageBoxOk("错误", "工程名字不能含有中文字符或者全角字符，并且不能以数字开头.");
      return;
   }  

   %fileFolder =  CreateProject_Folder.text;
   %fileName   = %fileFolder @ "/" @ CreateProject_Name.getText();  
   if( isFolderA( %fileName ) )
   {
      MessageBoxOk("错误", "该名字的文件夹已经存在，请使用其它名字。");
      return;
   }   
   
   Canvas.popDialog(CreateProjectGUI);
   
   $FunCodeProjectName = CreateProject_Name.getText();
   //
   if( $CreateProjectIndex == 0 )
      $FunCodeProjectType = "CPP";
   else if( $CreateProjectIndex == 2 )
      $FunCodeProjectType = "JAVA";
   else
      $FunCodeProjectType = "C";

   // 
   %ProjectFolder = expandFilename("gameData/TemplateGame");
    
    if( $CreateProjectIndex == 2 && $levelEditor::DevJAVAVersion $= "Eclipse" )
    {
      %dstName = AnsiToUtf8( %fileName );
      pathCopy( %ProjectFolder @ "/Eclipse", %dstName, false );
    }
    else
    {
      %dstName = AnsiToUtf8( %fileName @ "/Bin" );
      pathCopy( %ProjectFolder @ "/Bin", %dstName, false );
    }
   
   if( $CreateProjectIndex == 0 )
   {
      %dstName = AnsiToUtf8( %fileName @ "/SourceCode" );
      if( $levelEditor::DevVCVersion $= "CodeBlock" )
      {
         pathCopy( %ProjectFolder @ "/SourceCode_CodeBlock", %dstName, false );
      }
      else
      {         
         pathCopy( %ProjectFolder @ "/SourceCode", %dstName, false );
      }
   }
   else if( $CreateProjectIndex == 2 )
   {
      if( $levelEditor::DevJAVAVersion !$= "Eclipse" )
      {
         %dstName = AnsiToUtf8( %fileName @ "/SourceCode" );
         pathCopy( %ProjectFolder @ "/SourceCode_Java", %dstName, false );   
      }
   }
   else
   {
      %dstName = AnsiToUtf8( %fileName @ "/SourceCode" );
      if( $levelEditor::DevVCVersion $= "CodeBlock" )
      {
         pathCopy( %ProjectFolder @ "/SourceCode_CodeBlockC", %dstName, false );
      }
      else
      {
         if( $LevelEditor::ProjectArcSingle )
            pathCopy( %ProjectFolder @ "/SourceCode_C2", %dstName, false );
         else 
            pathCopy( %ProjectFolder @ "/SourceCode_C", %dstName, false );
      }
   }
   
   // VCProject
   if( $CreateProjectIndex != 2 )
   {
      // 删除JAVA内容
      %dstName = AnsiToUtf8( %fileName @ "/Bin/Game.class" );
      fileDelete( %dstName );
      %dstName = AnsiToUtf8( %fileName @ "/Bin/Game.bat" );
      fileDelete( %dstName );
      %dstName = %fileName @ "/Bin/FunCode";
      DeleteFolderA( %dstName );
      
      if( $levelEditor::DevVCVersion $= "CodeBlock" )
      {
         %vcSrcName = AnsiToUtf8( %fileName @ "/SourceCode/CodeBlock/Template.cbp" );
         %vcDstName = AnsiToUtf8( %fileName @ "/SourceCode/CodeBlock/" @ $FunCodeProjectName @ ".cbp" );
         pathCopy( %vcSrcName, %vcDstName, false );
         fileDelete( %vcSrcName );
      }
      else
      {      
         %vcSrcName = AnsiToUtf8( %fileName @ "/SourceCode/VCProjectVC6/Template.dsw" );
         %vcDstName = AnsiToUtf8( %fileName @ "/SourceCode/VCProjectVC6/" @ $FunCodeProjectName @ ".dsw" );
         pathCopy( %vcSrcName, %vcDstName, false );
         fileDelete( %vcSrcName );
         //
         %vcSrcName = AnsiToUtf8( %fileName @ "/SourceCode/VCProject2010/Template.sln" );
         %vcDstName = AnsiToUtf8( %fileName @ "/SourceCode/VCProject2010/" @ $FunCodeProjectName @ ".sln" );
         pathCopy( %vcSrcName, %vcDstName, false );
         fileDelete( %vcSrcName );
         //
         %vcSrcName = AnsiToUtf8( %fileName @ "/SourceCode/VCProject2008/Template.sln" );
         %vcDstName = AnsiToUtf8( %fileName @ "/SourceCode/VCProject2008/" @ $FunCodeProjectName @ ".sln" );
         pathCopy( %vcSrcName, %vcDstName, false );
         fileDelete( %vcSrcName );
      
         // 删除非默认的另外2个工程
         if( $levelEditor::DevVCVersion $= "VCProject2010" )
         {
            %vcSrcName = %fileName @ "/SourceCode/VCProjectVC6";
            DeleteFolderA( %vcSrcName );
            %vcSrcName = %fileName @ "/SourceCode/VCProject2008";
            DeleteFolderA( %vcSrcName );
            //
            if( $CreateProjectIndex == 0 )
            {
               %Lib1 = AnsiToUtf8( %fileName @ "/SourceCode/Src/CommonClass_2008.lib" );
               %Lib2 = AnsiToUtf8( %fileName @ "/SourceCode/Src/CommonClass_VC6.lib" );     
               fileDelete( %Lib1 );
               fileDelete( %Lib2 );
            }
            else
            {
               %Lib1 = AnsiToUtf8( %fileName @ "/SourceCode/Src/CommonAPI_2008.lib" );
               %Lib2 = AnsiToUtf8( %fileName @ "/SourceCode/Src/CommonAPI_VC6.lib" );     
               fileDelete( %Lib1 );
               fileDelete( %Lib2 );
            }
         }
         else if( $levelEditor::DevVCVersion $= "VCProject2008" )
         {
            %vcSrcName = %fileName @ "/SourceCode/VCProjectVC6";
            DeleteFolderA( %vcSrcName );
            %vcSrcName = %fileName @ "/SourceCode/VCProject2010";
            DeleteFolderA( %vcSrcName );
            //
            if( $CreateProjectIndex == 0 )
            {
               %Lib1 = AnsiToUtf8( %fileName @ "/SourceCode/Src/CommonClass_2010.lib" );
               %Lib2 = AnsiToUtf8( %fileName @ "/SourceCode/Src/CommonClass_VC6.lib" );     
               fileDelete( %Lib1 );
               fileDelete( %Lib2 );
            }
            else
            {
               %Lib1 = AnsiToUtf8( %fileName @ "/SourceCode/Src/CommonAPI_2010.lib" );
               %Lib2 = AnsiToUtf8( %fileName @ "/SourceCode/Src/CommonAPI_VC6.lib" );     
               fileDelete( %Lib1 );
               fileDelete( %Lib2 );
            }   
         }
         else // VC6
         {
            %vcSrcName = %fileName @ "/SourceCode/VCProject2008";
            DeleteFolderA( %vcSrcName );
            %vcSrcName = %fileName @ "/SourceCode/VCProject2010";
            DeleteFolderA( %vcSrcName );
             //
            if( $CreateProjectIndex == 0 )
            {
               %Lib1 = AnsiToUtf8( %fileName @ "/SourceCode/Src/CommonClass_2010.lib" );
               %Lib2 = AnsiToUtf8( %fileName @ "/SourceCode/Src/CommonClass_2008.lib" );     
               fileDelete( %Lib1 );
               fileDelete( %Lib2 );
            }
            else
            {
               %Lib1 = AnsiToUtf8( %fileName @ "/SourceCode/Src/CommonAPI_2010.lib" );
               %Lib2 = AnsiToUtf8( %fileName @ "/SourceCode/Src/CommonAPI_2008.lib" );     
               fileDelete( %Lib1 );
               fileDelete( %Lib2 );
            }   
        }
      }
   }
   else
   {
      if( $levelEditor::DevJAVAVersion !$= "Eclipse" )
      {
         // 删除C内容
         %dstName = AnsiToUtf8( %fileName @ "/Bin/Game.exe" );
         fileDelete( %dstName );
      }
   }
   
   // 拷贝文件必须放后面，等上面拷贝文件夹完成之后，建立了目标文件夹，才能拷贝成功
   %ProjectFile = AnsiToUtf8( %fileName @ "/" @ "project.funProj" );
   pathCopy( %ProjectFolder @ "/" @ "project.funProj", %ProjectFile, false );
   
   //
   ChangeProjectName( %ProjectFile );   
   
   $FunCodeCreate_NotExit = 1;
   
   //JCreator Eclipse不共存，所以更改启动工程
   if( $levelEditor::DevJAVAVersion $= "Eclipse" )
      $levelEditor::StartJAVAVersion = "Eclipse";
   else
      $levelEditor::StartJAVAVersion = "JCreator";

   // Open it
   MainOpenProject( %ProjectFile );
   reloadProject();   
}

$CreateOtherProjectIndex = 1;

function CreateOtherProject( %Index )
{   
   %project = expandFileName("^project/");
   %project = filePath( %project );
   %project = filePath( %project );
   
   if( $FunCodeProjectType $= "JAVA" )
   {
   }
   else
   {
      if( %Index == 1 )
      {
         %fileName = %project @ "/SourceCode/VCProjectVC6/" @ $FunCodeProjectName @ ".dsw";
         if( fileSize(%fileName) > 0 )
         {
            MessageBoxOk("提示", "该版本工程已经存在。");
            return;
         }
      }
      else if( %Index == 2 )
      {
         %fileName = %project @ "/SourceCode/VCProject2010/" @ $FunCodeProjectName @ ".sln";
         if( fileSize(%fileName) > 0 )
         {
            MessageBoxOk("提示", "该版本工程已经存在。");
            return;
         }
      }
      else if( %Index == 3 )
      {
         %fileName = %project @ "/SourceCode/VCProject2008/" @ $FunCodeProjectName @ ".sln";
         if( fileSize(%fileName) > 0 )
         {
            MessageBoxOk("提示", "该版本工程已经存在。");
            return;
         }      
      }
      else if( %Index == 4 )
      {
         %fileName = %project @ "/SourceCode/CodeBlock/" @ $FunCodeProjectName @ ".cbp";
         if( fileSize(%fileName) > 0 )
         {
            MessageBoxOk("提示", "该版本工程已经存在。");
            return;
         }      
      }
   }
   
   $CreateOtherProjectIndex = %Index;     
   MessageBoxYesNo("提示", "是否创建该版本工程?", "CreateOtherProject_OK();", "");
 
}

function CreateOtherProject_OK()
{
   %TemplateFolder = expandFilename("gameData/TemplateGame");
   %GameFolder = expandFileName("^project/");
   %GameFolder = filePath( %GameFolder );
   %GameFolder = filePath( %GameFolder );
   
   //
   if( $FunCodeProjectType $= "JAVA" )
   {
   }
   else
   {
      %ProjType = "SourceCode_C";
      %LibType = "CommonAPI";
      if( $FunCodeProjectType $= "CPP" )
      {
         %ProjType = "SourceCode";
         %LibType = "CommonClass";
      }
      else if( $LevelEditor::ProjectArcSingle )
      {
         %ProjType = "SourceCode_C2";
      }
      
      // VC6
      if( $CreateOtherProjectIndex == 1 )
      {
         %dstName = %GameFolder @ "/SourceCode/VCProjectVC6" ;
         pathCopy( %TemplateFolder @ "/" @ %ProjType @ "/VCProjectVC6", %dstName, false );
      
         %dstName = %GameFolder @ "/SourceCode/Src/" @ %LibType @ "_VC6.lib";
         pathCopy( %TemplateFolder @ "/" @ %ProjType @ "/Src/" @ %LibType @ "_VC6.lib", %dstName, false );
         
         %vcSrcName = %GameFolder @ "/SourceCode/VCProjectVC6/Template.dsw";
         %vcDstName = %GameFolder @ "/SourceCode/VCProjectVC6/" @ $FunCodeProjectName @ ".dsw";
         pathCopy( %vcSrcName, %vcDstName, false );
         fileDelete( %vcSrcName );      
      }
      // VC2010
      else if( $CreateOtherProjectIndex == 2 )
      {
         %dstName = %GameFolder @ "/SourceCode/VCProject2010";
         pathCopy( %TemplateFolder @ "/" @ %ProjType @ "/VCProject2010", %dstName, false );
         
         %dstName = %GameFolder @ "/SourceCode/Src/" @ %LibType @ "_2010.lib";
         pathCopy( %TemplateFolder @ "/" @ %ProjType @ "/Src/" @ %LibType @ "_2010.lib", %dstName, false );
         
         %vcSrcName = %GameFolder @ "/SourceCode/VCProject2010/Template.sln";
         %vcDstName = %GameFolder @ "/SourceCode/VCProject2010/" @ $FunCodeProjectName @ ".sln";
         pathCopy( %vcSrcName, %vcDstName, false );
         fileDelete( %vcSrcName );
      }
      // VC2008
      else if( $CreateOtherProjectIndex == 3 )
      {
         %dstName = %GameFolder @ "/SourceCode/VCProject2008";
         pathCopy( %TemplateFolder @ "/" @ %ProjType @ "/VCProject2008", %dstName, false );
         
         %dstName = %GameFolder @ "/SourceCode/Src/" @ %LibType @ "_2008.lib";
         pathCopy( %TemplateFolder @ "/" @ %ProjType @ "/Src/" @ %LibType @ "_2008.lib", %dstName, false );
         
         %vcSrcName = %GameFolder @ "/SourceCode/VCProject2008/Template.sln";
         %vcDstName = %GameFolder @ "/SourceCode/VCProject2008/" @ $FunCodeProjectName @ ".sln";
         pathCopy( %vcSrcName, %vcDstName, false );
         fileDelete( %vcSrcName );
      }
      // CodeBlock
      else if( $CreateOtherProjectIndex == 4 )
      {
         %ProjType = "SourceCode_CodeBlockC";
         %LibType = "CommonAPI.a";
         if( $FunCodeProjectType $= "CPP" )
         {
            %ProjType = "SourceCode_CodeBlock";
            %LibType = "CommonClass.a";
         }
      
         %dstName = %GameFolder @ "/SourceCode/CodeBlock";
         pathCopy( %TemplateFolder @ "/" @ %ProjType @ "/CodeBlock", %dstName, false );
         
         %dstName = %GameFolder @ "/SourceCode/Src/" @ %LibType;
         pathCopy( %TemplateFolder @ "/" @ %ProjType @ "/Src/" @ %LibType, %dstName, false );
         
         %dstName = %GameFolder @ "/SourceCode/Icon.rc";
         pathCopy( %TemplateFolder @ "/" @ %ProjType @ "/Icon.rc", %dstName, false );
         
         %vcSrcName = %GameFolder @ "/SourceCode/CodeBlock/Template.cbp";
         %vcDstName = %GameFolder @ "/SourceCode/CodeBlock/" @ $FunCodeProjectName @ ".cbp";
         pathCopy( %vcSrcName, %vcDstName, false );
         fileDelete( %vcSrcName );
      }
   }
   //
   Canvas.popDialog(CreateOtherProjectGUI);
   //
   MessageBoxOk("提示", "创建成功!");
}

function ChangeProjectName(%projectFile)
{
   // Read
   %xml = new ScriptObject() { class = "XML"; };
   if( %xml.beginRead( %projectFile ) )
   {
      if( %xml.readClassBegin( "TorqueProject" ) )
      {
         %lastLevel = %xml.readField( "LastLevel" );         
         %xml.readClassEnd();
      }
      %xml.endRead();
   }   
   // Delete the object
   %xml.delete();
   
   // Write
   %xml = new ScriptObject() { class = "XML"; };
   if( %xml.beginWrite( %projectFile ) )
   {
      %xml.writeClassBegin( "TorqueProject" );
         %xml.writeField( "Type", "T2DProject" );
         %xml.writeField( "Version", getT2DVersion() );
         %xml.writeField( "MinVersion", "v1.1.4"); // Depends on ATLEAST 1.1.4 projects
         %xml.writeField( "Creator", "Torque Game Builder" );
         %xml.writeField( "LastLevel", %lastLevel );
         %xml.writeField( "ProjectName", $FunCodeProjectName );
         %xml.writeField( "ProjectType", $FunCodeProjectType );
	 %xml.writeField( "JavaDevVersion", $levelEditor::DevJAVAVersion );
      %xml.writeClassEnd();
      %xml.endWrite();
   }  
   // Delete the object
   %xml.delete();
}

function ChangeProjectFolder()
{
   %dlg = new OpenFolderDialog()
   {
      DefaultPath = AnsiToUtf8( CreateProject_Folder.text );
   };
     
   if(%dlg.Execute() && %dlg.FileName !$= "" )
   {
      CreateProject_Folder.text = Utf8ToAnsi( %dlg.FileName );
      $LevelEditor::CreateProjectFolder = CreateProject_Folder.text;
   }
   
   %dlg.delete();
}

function SaveTemplate_OK()
{
   if( SaveTemplate_Name.getText() $= "" )
   {
      MessageBoxOk("错误", "请输入模板名字");
      return;
   }   

   %TemplateFolder = expandFilename("gameData/UserTemplate");   
   %fileName   = %TemplateFolder @ "/" @ SaveTemplate_Name.getText();  
   if( isFolder( %fileName ) )
   {
      MessageBoxOk("错误", "该名字的模板已经存在，请使用其它名字。");
      return;
   }   
     
   %ProjFolder = expandFileName("^project/");
   %DataFolder = %ProjFolder @ "game/data";
   %ManagedFolder = %ProjFolder @ "game/managed";
   %DstDataName = %fileName @ "/data";
   %DstManagedName = %fileName @ "/managed";
   //
   pathCopy( %DataFolder, %DstDataName, false );
   pathCopy( %ManagedFolder, %DstManagedName, false );
    
   MessageBoxOK("提示", "保存模板成功!");
   Canvas.popDialog(SaveUserTemplateGUI);
}

function SelUserTemplate()
{
   if( UserTemplateList.getSelectedItem() < 0 )
   {
      MessageBoxOK( "提示", "请先选择一个模板。" );
      return;
   }      
  
   MessageBoxYesNo("警告", "导入模板将覆盖现有地图，现有地图数据将全部丢失，是否继续?", "SelUserTemplate_OK();", "");
}

function SelUserTemplate_OK()
{
   if( UserTemplateList.getSelectedItem() < 0 )
   {
      return;
   }
    
   %SelectedText = UserTemplateList.getItemText(UserTemplateList.getSelectedItem()); 
   %Template = AnsiToUtf8( %SelectedText );
   Canvas.popDialog(SelectUserTemplateGUI);   
   
   %TemplateFolder = expandFilename("gameData/UserTemplate");   
   %SrcDataFolder   = %TemplateFolder @ "/" @ %Template @ "/data";    
   %SrcManagedFolder = %TemplateFolder @ "/" @ %Template @ "/managed";
   
   %ProjFolder = expandFileName("^project/");
   %DataFolder = %ProjFolder @ "game/data";
   %ManagedFolder = %ProjFolder @ "game/managed";
   
   DeleteFolderA( Utf8ToAnsi(%DataFolder) );
   DeleteFolderA( Utf8ToAnsi(%ManagedFolder) );
   pathCopy( %SrcDataFolder, %DataFolder, false );
   pathCopy( %SrcManagedFolder, %ManagedFolder, false );
   
   // Reload it
   $FunCodeRecover = 1;
   reloadProject();  
}

function DelUserTemplate()
{
   if( UserTemplateList.getSelectedItem() < 0 )
   {
      MessageBoxOK( "提示", "请先选择一个模板。" );
      return;
   }  
   
   MessageBoxYesNo("警告", "模板删除后将不可以恢复，是否继续?", "DelUserTemplate_OK();", "");
}

function DelUserTemplate_OK()
{
   if( UserTemplateList.getSelectedItem() < 0 )
   {      
      return;
   }  
   
   %Template = UserTemplateList.getItemText(UserTemplateList.getSelectedItem());  
   %TemplateFolder = expandFilename("gameData/UserTemplate");  
   
   %DelFolder = Utf8ToAnsi( %TemplateFolder ) @ "/" @ %Template;
   DeleteFolderA( %DelFolder );
   
   UserTemplateList.deleteItem( UserTemplateList.getSelectedItem() );
}

function SelectUserTemplateGUI::onWake( %this )
{
   UserTemplateList.clearItems();
   
   %TemplateFolder = expandFilename("gameData/UserTemplate");    
   %TemplateList = getDirectoryList( %TemplateFolder );
   
   %wordCount = getFieldCount( %TemplateList );
   for( %i = 0; %i < %wordCount; %i++ )
   {
      %resource = GetField( %TemplateList, %i );
      UserTemplateList.addItem( Utf8ToAnsi(%resource) );
   }
}

function UpdateCreateProjectGUI()
{
   if( $CreateProjectIndex == 2 )
   {
      if( $levelEditor::DevJAVAVersion $= "" )
         $levelEditor::DevJAVAVersion = "JCreator";
         
      if( $levelEditor::DevJAVAVersion $= "JCreator" )
      {         
         CreateProjRadioBtn1.performClick();
      }
      else if( $levelEditor::DevJAVAVersion $= "Eclipse" )
      {         
         CreateProjRadioBtn2.performClick();
      }
      else if( $levelEditor::DevJAVAVersion $= "Netbeans" )
      {         
         //CreateProjRadioBtn3.performClick();
      }
      
      CreateProjRadioBtn1.text =  "JCreator";
      CreateProjRadioBtn2.text =  "Eclipse";
      CreateProjRadioBtn3.text =  "Netbeans";
      CreateProjRadioBtn3.Visible = 0;
      CreateProjRadioBtn4.Visible = 0;
      CreateProjArcBtn1.Visible = 0;
      CreateProjArcBtn2.Visible = 0; 
      CreateProjArcText.Visible = 0;     
   }
   else
   { 
      if( $levelEditor::DevVCVersion $= "" )
         $levelEditor::DevVCVersion = "VCProjectVC6";
               
      if( $levelEditor::DevVCVersion $= "VCProjectVC6" )
      {         
         CreateProjRadioBtn1.performClick();
      }
      else if( $levelEditor::DevVCVersion $= "VCProject2010" )
      {         
         CreateProjRadioBtn2.performClick();
      }
      else if( $levelEditor::DevVCVersion $= "VCProject2008" )
      {         
         CreateProjRadioBtn3.performClick();
      }
      else if( $levelEditor::DevVCVersion $= "CodeBlock" )
      {         
         CreateProjRadioBtn4.performClick();
      }
      
      //
      if( $LevelEditor::ProjectArcSingle && $OpenCSingleMult )
         CreateProjArcBtn1.performClick();
      else
         CreateProjArcBtn2.performClick();
      
      CreateProjRadioBtn1.text =  "VC6.0";
      CreateProjRadioBtn2.text =  "VC2010";
      CreateProjRadioBtn3.text =  "VC2008";
      CreateProjRadioBtn4.text =  "CodeBlock";
      CreateProjRadioBtn3.Visible = 1;
      CreateProjRadioBtn4.Visible = 1;
      
      if( $CreateProjectIndex == 0 || !$OpenCSingleMult )
      {
         CreateProjArcBtn1.Visible = 0;
         CreateProjArcBtn2.Visible = 0; 
         CreateProjArcText.Visible = 0;   
      }
      else
      {
         CreateProjArcBtn1.Visible = 1;
         CreateProjArcBtn2.Visible = 1;
         CreateProjArcText.Visible = 1;
      }
   }  
}

function SetEXEPath( %val )
{
   $SetExePathType = %val;
   
   Canvas.pushDialog(SetEclipsePathGUI);   
   
   if( %val $= "VC6" )
   {
      SetExePathWindow.text   = "设置VC6(MSDEV.EXE)位置";
      SelectEXEText.text      = "选择Visual Studio(MSDEV.EXE):";
      SetEXEPath_Folder.text = $levelEditor::VC6Path;
   }
   else if( %val $= "VC2008" )
   {
      SetExePathWindow.text   = "设置VC2008(devenv.exe)位置";
      SelectEXEText.text      = "选择Visual Studio 9.0(devenv.exe):";
      SetEXEPath_Folder.text = $levelEditor::VC2008Path;
   }
   else if( %val $= "VC2010" )
   {
      SetExePathWindow.text   = "设置VC2010(devenv.exe)位置";
      SelectEXEText.text      = "选择Visual Studio 10.0(devenv.exe):";
      SetEXEPath_Folder.text = $levelEditor::VC2010Path;
   }
   else if( %val $= "CodeBlock" )
   {
      SetExePathWindow.text   = "设置 codeblock.exe位置";
      SelectEXEText.text      = "选择 codeblock.exe:";
      SetEXEPath_Folder.text = $levelEditor::CodeBlockPath;
   }
   else
   {
      SetExePathWindow.text   = "设置Eclipse.exe位置";
      SelectEXEText.text      = "选择Eclipse.exe:";
      SetEXEPath_Folder.text  = $levelEditor::EclipsePath;
   }
}

function SetEXEPath_OK()
{
   if( $SetExePathType $= "VC6" )
   {
      $levelEditor::VC6Path = SetEXEPath_Folder.text;
   }
   else if( $SetExePathType $= "VC2008" )
   {
      $levelEditor::VC2008Path = SetEXEPath_Folder.text;
   }
   else if( $SetExePathType $= "VC2010" )
   {
      $levelEditor::VC2010Path = SetEXEPath_Folder.text;
   }
   else if( $SetExePathType $= "CodeBlock" )
   {
      $levelEditor::CodeBlockPath = SetEXEPath_Folder.text;
   }
   else
   {
      $levelEditor::EclipsePath = SetEXEPath_Folder.text;
   }   
   
   Canvas.popDialog(SetEclipsePathGUI);
}

function ChangeEXEFolder()
{
   %EXEPath = $levelEditor::EclipsePath;
   if( $SetExePathType $= "VC6" )
   {
      %EXEPath = $levelEditor::VC6Path;
   }
   else if( $SetExePathType $= "VC2008" )
   {
      %EXEPath = $levelEditor::VC2008Path;
   }
   else if( $SetExePathType $= "VC2010" )
   {
      %EXEPath = $levelEditor::VC2010Path;
   }
   else if( $SetExePathType $= "CodeBlock" )
   {
      %EXEPath = $levelEditor::CodeBlockPath;
   }
   
   %dlg = new OpenFileDialog()
   {
      Filters        =  "(*.exe)|*.exe";
      DefaultPath    = filePath( %EXEPath );
      MustExist      = true;   
   };
     
   if(%dlg.Execute() && %dlg.FileName !$= "" )
      SetEXEPath_Folder.text = Utf8ToAnsi( %dlg.FileName );
   
   %dlg.delete();
}

function LevelBuilderSceneEdit::groupObjects(%this)
{
   %this.groupAcquiredObjects();
   RefreshTreeView();
}

function LevelBuilderSceneEdit::breakApart(%this)
{
   %this.breakApartAcquiredObjects();
   RefreshTreeView();
}

function RefreshTreeView()
{
   GuiFormManager::SendContentMessage($LBTreeViewContent, "", "openCurrentGraph");
}

function levelBuilderUndo(%val)
{
   if (%val)
      ToolManager.undo();
}

function levelBuilderRedo(%val)
{
   if (%val)
      ToolManager.redo();
}

function levelBuilderCut(%val)
{
   if (%val)
   {
      levelBuilderCopy(1);
      // Undo will be handled by this call.
      ToolManager.deleteAcquiredObjects();
   }
}

function levelBuilderCopy(%val)
{
   if (%val)
      saveSelectedObjectsCallback($levelBuilderClipboardFile);
}

function levelBuilderPaste(%val)
{
   if (%val)
   {
      %undo = new UndoScriptAction() { actionName = "Paste"; class = UndoPasteAction; };
      %undo.objectList = new SimSet();
      
      addToLevelCallback($levelBuilderClipboardFile);
      %newObjectList = $LevelManagement::newObjects;
      
      if( isObject( %newObjectList ) )
      {
         ToolManager.clearAcquisition();
         
         if( %newObjectList.isMemberOfClass( "t2dSceneObject" ) )
         {
            %undo.objectList.add( %newObjectList );
            ToolManager.acquireObject( %newObjectList );
         }
         
         else
         {
            %count = %newObjectList.getCount();
            for (%i = 0; %i < %count; %i++)
            {
               %obj = %newObjectList.getObject( %i );
               ToolManager.acquireObject( %obj );
               %undo.objectList.add(%obj);
            }
         }
      }
      
      if (%undo.objectList.getCount() > 0)
         %undo.addToManager(LevelBuilderUndoManager);
      else
      {
         %undo.objectList.delete();
         %undo.delete();
      }
   }
}

function UndoPasteAction::undo(%this)
{
   ToolManager.clearAcquisition();
   for (%i = 0; %i < %this.objectList.getCount(); %i++)
      ToolManager.moveToRecycleBin(%this.objectList.getObject(%i));
}

function UndoPasteAction::redo(%this)
{
   for (%i = 0; %i < %this.objectList.getCount(); %i++)
      ToolManager.moveFromRecycleBin(%this.objectList.getObject(%i));
}

function levelBuilderSetSelectionTool(%val)
{
   if (%val && (ToolManager.getActiveTool() != LevelEditorSelectionTool.getId()))
      LevelBuilderToolManager::setTool(LevelEditorSelectionTool);
}

function levelBuilderHomeView(%val)
{
   if (%val)
   {
      %sceneWindow = ToolManager.getLastWindow();
      %scenegraph = %sceneWindow.getSceneGraph();
      %cameraPosition = "0 0";
      %cameraSize = $levelEditor::DefaultCameraSize;
      if (%scenegraph.cameraPosition)
         %cameraPosition = %scenegraph.cameraPosition;
      if (%scenegraph.cameraSize)
         %cameraSize = %scenegraph.cameraSize;
         
      %sceneWindow.setTargetCameraPosition(%cameraPosition, %cameraSize);
      %sceneWindow.setTargetCameraZoom(1.0);
      %sceneWindow.startCameraMove(0.5);
   }
}

function levelBuilderZoomView(%amount)
{
   %sceneWindow = ToolManager.getLastWindow();
   %scenegraph = %sceneWindow.getSceneGraph();
   %cameraPosition = ToolManager.getLastWindow().getCurrentCameraPosition();
   %cameraSize = $levelEditor::DefaultCameraSize;
   if (%scenegraph.cameraSize)
      %cameraSize = %scenegraph.cameraSize;
   
   %windowX = getWord( %sceneWindow.getExtent(), 0 );
   %windowY = getWord( %sceneWindow.getExtent(), 1 );
   
   %newX = getWord( %cameraSize, 0 ) * %windowX / $levelEditor::DesignResolutionX;
   %newY = getWord( %cameraSize, 1 ) * %windowY / $levelEditor::DesignResolutionY;
   
   %sceneWindow.setTargetCameraPosition(%cameraPosition, %newX SPC %newY);
   %sceneWindow.setTargetCameraZoom(%amount);
   %sceneWindow.startCameraMove(0.5);
}

function levelBuilderZoomToFit(%val)
{
   if (%val)
   {
      %sceneWindow = ToolManager.getLastWindow();
      %sceneGraph = %sceneWindow.getSceneGraph();
      if (!isObject(%sceneWindow) || !isObject(%sceneGraph))
         return;
      
      %count = %sceneGraph.getSceneObjectCount();
      if (%count < 1)
         return;
      
      %minX = 0;
      %minY = 0;
      %maxX = 1;
      %maxY = 1;
      for (%i = 0; %i < %count; %i++)
      {
         %object = %sceneGraph.getSceneObject(%i);
         if (%i == 0)
         {
            %minX = %object.getPositionX() - (%object.getWidth() / 2);
            %minY = %object.getPositionY() - (%object.getHeight() / 2);
            %maxX = %object.getPositionX() + (%object.getWidth() / 2);
            %maxY = %object.getPositionY() + (%object.getHeight() / 2);
         }
         else
         {
            %newMinX = %object.getPositionX() - (%object.getWidth() / 2);
            %newMinY = %object.getPositionY() - (%object.getHeight() / 2);
            %newMaxX = %object.getPositionX() + (%object.getWidth() / 2);
            %newMaxY = %object.getPositionY() + (%object.getHeight() / 2);
            if (%newMinX < %minX)
               %minX = %newMinX;
            if (%newMaxX > %maxX)
               %maxX = %newMaxX;
            if (%newMinY < %minY)
               %minY = %newMinY;
            if (%newMaxY > %maxY)
               %maxY = %newMaxY;
         }
      }
      
      %sceneWindow.setTargetCameraArea(%minX, %minY, %maxX, %maxY);
      %sceneWindow.setTargetCameraZoom(1.0);
      %sceneWindow.startCameraMove(0.5);
   }
}

function levelBuilderZoomToSelected(%val)
{
   if (%val)
   {
      %sceneWindow = ToolManager.getLastWindow();
      if (!isObject(%sceneWindow))
         return;
      
      %selectedObjects = ToolManager.getAcquiredObjects();
      %count = %selectedObjects.getCount();
      if (%count < 1)
         return;
      
      %minX = 0;
      %minY = 0;
      %maxX = 1;
      %maxY = 1;
      for (%i = 0; %i < %count; %i++)
      {
         %object = %selectedObjects.getObject(%i);
         if (%i == 0)
         {
            %minX = %object.getPositionX() - (%object.getWidth() / 2);
            %minY = %object.getPositionY() - (%object.getHeight() / 2);
            %maxX = %object.getPositionX() + (%object.getWidth() / 2);
            %maxY = %object.getPositionY() + (%object.getHeight() / 2);
         }
         else
         {
            %newMinX = %object.getPositionX() - (%object.getWidth() / 2);
            %newMinY = %object.getPositionY() - (%object.getHeight() / 2);
            %newMaxX = %object.getPositionX() + (%object.getWidth() / 2);
            %newMaxY = %object.getPositionY() + (%object.getHeight() / 2);
            if (%newMinX < %minX)
               %minX = %newMinX;
            if (%newMaxX > %maxX)
               %maxX = %newMaxX;
            if (%newMinY < %minY)
               %minY = %newMinY;
            if (%newMaxY > %maxY)
               %maxY = %newMaxY;
         }
      }
      
      %sceneWindow.setTargetCameraArea(%minX, %minY, %maxX, %maxY);
      %sceneWindow.setTargetCameraZoom(1.0);
      %sceneWindow.startCameraMove(0.5);
   }
}

function levelBuilderSetEditPanel(%val)
{
   if (%val)
      GuiFormManager::SendContentMessage($LBSideBarContent, "", "setTabPage" SPC "edit");
}

function levelBuilderSetProjectPanel(%val)
{
   if (%val)
      GuiFormManager::SendContentMessage($LBSideBarContent, "", "setTabPage" SPC "project");
}

function levelBuilderSetCreatePanel(%val)
{
   if (%val)
      GuiFormManager::SendContentMessage($LBSideBarContent, "", "setTabPage" SPC "create");
}

function levelBuilderZoomViewIn(%val)
{
   if (%val)
   {
      %camera = ToolManager.getLastWindow();
      %zoom = %camera.getCurrentCameraZoom();
      %amount = 120 * 0.001 * %zoom;
      %camera.setTargetCameraZoom(%zoom + %amount);
      %camera.startCameraMove(0.1);
   }
}

function levelBuilderZoomViewOut(%val)
{
   if (%val)
   {
      %camera = ToolManager.getLastWindow();
      %zoom = %camera.getCurrentCameraZoom();
      %amount = -120 * 0.001 * %zoom;
      %camera.setTargetCameraZoom(%zoom + %amount);
      %camera.startCameraMove(0.1);
   }
}

function levelBuilderViewLeft(%val)
{
   if (%val && (ToolManager.getAcquiredObjectCount() == 0))
   {
      %camera = ToolManager.getLastWindow();
      %position = %camera.getCurrentCameraPosition();
      %zoom = %camera.getCurrentCameraZoom();
      %amount = (-10 + %zoom) SPC 0;
      %camera.setTargetCameraPosition(t2dVectorAdd(%position, %amount));
      %camera.startCameraMove(0.1);
   }
}

function levelBuilderViewRight(%val)
{
   if (%val && (ToolManager.getAcquiredObjectCount() == 0))
   {
      %camera = ToolManager.getLastWindow();
      %position = %camera.getCurrentCameraPosition();
      %zoom = %camera.getCurrentCameraZoom();
      %amount = (10 - %zoom) SPC 0;
      %camera.setTargetCameraPosition(t2dVectorAdd(%position, %amount));
      %camera.startCameraMove(0.1);
   }
}

function levelBuilderViewUp(%val)
{
   if (%val && (ToolManager.getAcquiredObjectCount() == 0))
   {
      %camera = ToolManager.getLastWindow();
      %position = %camera.getCurrentCameraPosition();
      %zoom = %camera.getCurrentCameraZoom();
      %amount = 0 SPC (-10 + %zoom);
      %camera.setTargetCameraPosition(t2dVectorAdd(%position, %amount));
      %camera.startCameraMove(0.1);
   }
}

function levelBuilderViewDown(%val)
{
   if (%val && (ToolManager.getAcquiredObjectCount() == 0))
   {
      %camera = ToolManager.getLastWindow();
      %position = %camera.getCurrentCameraPosition();
      %zoom = %camera.getCurrentCameraZoom();
      %amount = 0 SPC (10 - %zoom);
      %camera.setTargetCameraPosition(t2dVectorAdd(%position, %amount));
      %camera.startCameraMove(0.1);
   }
}
