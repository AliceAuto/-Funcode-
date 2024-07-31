//-----------------------------------------------------------------------------
// Script Class Namespace Object Linking
// Copyright (C) GarageGames.com, Inc.
//-----------------------------------------------------------------------------

//-----------------------------------------------------------------------------
// Register Form Content.
//-----------------------------------------------------------------------------
GuiFormManager::AddFormContent( "LevelBuilder", "ContentManagementToolBar", "LBContentManagementToolBar::CreateForm", "", 2 );


//-----------------------------------------------------------------------------
// Form Content Creation Function
//-----------------------------------------------------------------------------
function LBContentManagementToolBar::CreateForm( %formCtrl )
{    

   //---------------------------------------------------------------------------------------------
   // Toolbar Buttons - Utility
   //---------------------------------------------------------------------------------------------

   // New ImageMap
   LevelBuilderToolManager::addButtonToBar( %formCtrl, $LevelBuilder::GuiPath @ "/images/iconImage", "LaunchFunCodeImage();",  "添加一个新的图片资源" );//launchNewImageMap
   // New Linked Image Map
   //LevelBuilderToolManager::addButtonToBar( %formCtrl, $LevelBuilder::GuiPath @ "/images/iconImageLinked", "launchNewLinkImageMap();",  "创建一个新的链接图片" );
   // New Animation
   LevelBuilderToolManager::addButtonToBar( %formCtrl, $LevelBuilder::GuiPath @ "/images/iconAnimation", "LaunchFunCodeAnimation();",  "添加一个新的动画" );
   // New Particle
   LevelBuilderToolManager::addButtonToBar( %formCtrl, $LevelBuilder::GuiPath @ "/images/iconParticleEffect", "LaunchFunCodeParticle();",  "添加一个新的粒子特效" );
   // New Music
   LevelBuilderToolManager::addButtonToBar( %formCtrl, $LevelBuilder::GuiPath @ "/images/iconMusicAdd", "LaunchFunCodeMusic();",  "添加一个新的音乐" );      
   // New ImageMap
   LevelBuilderToolManager::addButtonToBar( %formCtrl, $LevelBuilder::GuiPath @ "/images/iconImageAdd", "launchNewImageMap();",  "导入新图片" );//
   // New Animation
   LevelBuilderToolManager::addButtonToBar( %formCtrl, $LevelBuilder::GuiPath @ "/images/iconAnimationAdd", "AnimationBuilder.createAnimation();",  "制作新动画", true, false );
   
      // Trash Can
   LevelBuilderToolManager::addButtonToBar( %formCtrl, $LevelBuilder::GuiPath @ "/images/iconTrashCan", "MessageBoxOk(\"从图库里删除图片\", \"拖拽一个图片到此删除.\");",  "拖拽一个图片到此删除.", false, false, "SBCreateTrash" );
   
   // Resize as appropriate.
   if( %formCtrl.isMethod("sizeContentsToFit") )
      %formctrl.sizeContentsToFit(%base, %formCtrl.contentID.margin);

   //*** Return back the base control to indicate we were successful
   return %base;

}

//-----------------------------------------------------------------------------
// Form Content Save Function
//-----------------------------------------------------------------------------
function LBContentManagementToolBar::SaveForm( %formCtrl, %contentObj )
{
}


function SBCreateTrash::onControlDropped(%this, %control, %position)
{
   if (isObject(%control.sceneObject))
   {
      
      %datablockName = %control.datablockName;
      %toolType      = %control.toolType;
      
      %sceneGraph = ToolManager.getLastWindow().getSceneGraph();
   
      switch$( %toolType )
      {
         case "t2dStaticSprite":
            SBCreateTrash::deleteImageMap(%datablockName);
         case "t2dAnimatedSprite":
            SBCreateTrash::deleteAnimation(%datablockName);
         case "t2dScroller":
            SBCreateTrash::deleteImageMap(%datablockName);
         case "t2dTileLayer":
            SBCreateTrash::deleteTileLayer( %datablockName, %sceneGraph );
         case "t2dParticleEffect":
            SBCreateTrash::deleteParticleEffect( %datablockName, %sceneGraph );
         case "t2dShape3D":
            SBCreateTrash::deleteShape3D( %datablockName, %sceneGraph );
      }
   }
}

function SBCreateTrash::deleteImageMap( %imageMap )
{
   %scenegraph = ToolManager.getLastWindow().getSceneGraph();
   %referenceList = new SimSet();
   %referenceCount = %scenegraph.getImageMapReferenceList(%imageMap, %referenceList);
   
   %message = "确认删除此资源?";
   if(%referenceCount > 0)
   {
      %message = "有" @ %referenceCount @ "个精灵引用到此资源. 如果" NL
                                "此资源被删除，则引用到的场景精灵也会被删除. 是否继续?";
   }
   
   %result = messageBox("删除图片", %message, "OkCancel", "Question");
   
   if(%result == $MROk)
   {
      %referenceList.deleteContents();
      %imageMap.delete();
      GuiFormManager::SendContentMessage($LBCreateSiderBar, %this, "refreshall 1");
      LBProjectObj.persistToDisk(true);
   }
   
   %referenceList.delete();
}

function SBCreateTrash::deleteAnimation(%animation)
{
   %scenegraph = ToolManager.getLastWindow().getSceneGraph();
   %referenceList = new SimSet();
   %referenceCount = %scenegraph.getAnimationReferenceList(%animation, %referenceList);
   
   %message = "确认删除此动画?";
   if(%referenceCount > 0)
   {
      %message = "有" @ %referenceCount @ "个精灵引用到此动画. 如果" NL
                                "此动画被删除，则引用到的场景精灵也会被删除.是否继续?";
   }
   
   %result = messageBox("删除动画", %message, "YesNo", "Question");
   
   // [neo, 15/6/2007 - #3233]
   //if(%result == $MRYes)
   if( %result == $MROK )
   {
      %referenceList.deleteContents();
      %animation.delete();
      GuiFormManager::SendContentMessage($LBCAnimatedSprite, %this, "refresh 1");
      LBProjectObj.persistToDisk(true);
   }
   
   %referenceList.delete();
}

function SBCreateTrash::deleteItem( %datablock )
{
   if( isObject( %datablock ) )
      %datablock.delete();
   
   else if( isFile( %datablock ) )
      fileDelete( %datablock );
}

function SBCreateTrash::deleteTileLayer( %filename, %sceneGraph )
{
   if( fileName( %filename ) $= "newLayer.lyr" )
      return;
      
   %count = %sceneGraph.getSceneObjectCount();
   %layers = "";
   for( %i = 0; %i < %count; %i++ )
   {
      %object = %sceneGraph.getSceneObject( %i );
      if( %object.getClassName() $= "t2dTileLayer" )
      {
         if( %object.layerFile $= %filename )
            %layers = %layers SPC %object;
      }
   }
   
   %count = ToolManager.getRecycledObjectCount();
   for( %i = 0; %i < %count; %i++)
   {
      %object = ToolManager.getRecycledObject( %i );
      if( %object.getClassName() $= "t2dTileLayer" )
      {
         if( %object.layerFile $= %filename )
            %layers = %layers SPC %object;
      }
   }
   
   %layers = trim( %layers );
   
   if( getWordCount( %layers ) > 0 )
   {
      %callback = "SBCreateTrash::doTileLayerDelete(\"" @ %filename @ "\", \"" @ %layers @ "\");";
      MessageBoxYesNo( "删除精灵", "有精灵使用到此层级,如果继续, " @
                       "则该精灵也将被删除. 是否继续?", %callback, "" );
   }
   else
      SBCreateTrash::doTileLayerDelete( %filename, %layers );
}

function SBCreateTrash::doTileLayerDelete( %filename, %layers )
{
   %count = getWordCount( %layers );
   for( %i = 0; %i < %count; %i++ )
   {
      %layer = getWord( %layers, %i );
      %layer.delete();
   }
   
   fileDelete( %filename );
   GuiFormManager::SendContentMessage($LBCreateSiderBar, 0, "refreshAll 0");
}

function SBCreateTrash::deleteParticleEffect( %filename, %sceneGraph )
{
   if( fileName( %filename ) $= "newEffect.eff" )
      return;
      
   %count = %sceneGraph.getSceneObjectCount();
   %effects = "";
   for( %i = 0; %i < %count; %i++ )
   {
      %object = %sceneGraph.getSceneObject( %i );
      if( %object.getClassName() $= "t2dParticleEffect" )
      {
         if( %object.effectFile $= %filename )
            %effects = %effects SPC %object;
      }
   }
   
   %count = ToolManager.getRecycledObjectCount();
   for( %i = 0; %i < %count; %i++)
   {
      %object = ToolManager.getRecycledObject( %i );
      if( %object.getClassName() $= "t2dParticleEffect" )
      {
         if( %object.effectFile $= %filename )
            %effects = %effects SPC %object;
      }
   }
   
   %effects = trim( %effects );
   if( %effects $= "" )
      return SBCreateTrash::doParticleEffectDelete( %filename, %effects );
   
   if( getWordCount( %effects ) > 0 )
   {
      %callback = "SBCreateTrash::doParticleEffectDelete(\"" @ %filename @ "\", \"" @ %effects @ "\");";
      MessageBoxYesNo( "删除精灵", "有精灵引用到此特效. 如果继续, " @
                       "则该特效也会被删除. 是否继续?", %callback, "" );
   }
}

function SBCreateTrash::doParticleEffectDelete( %filename, %effects )
{
   %count = getWordCount( %effects );
   for( %i = 0; %i < %count; %i++ )
   {
      %effect = getWord( %effects, %i );
      if( isObject( %effect ) )
         %effect.delete();
   }
   
   fileDelete( %filename );
   GuiFormManager::SendContentMessage($LBCreateSiderBar, 0, "refreshAll 1");
}

function SBCreateTrash::deleteShape3D( %filename, %sceneGraph )
{
   %count = %sceneGraph.getSceneObjectCount();
   %shapes = "";
   for( %i = 0; %i < %count; %i++ )
   {
      %object = %sceneGraph.getSceneObject( %i );
      if( %object.getClassName() $= "t2dShape3D" )
      {
         if( %object.shape $= %filename )
            %shapes = %shapes SPC %object;
      }
   }
   
   %count = ToolManager.getRecycledObjectCount();
   for( %i = 0; %i < %count; %i++)
   {
      %object = ToolManager.getRecycledObject( %i );
      if( %object.getClassName() $= "t2dShape3D" )
      {
         if( %object.shape $= %filename )
            %shapes = %shapes SPC %object;
      }
   }
   
   %shapes = trim( %shapes );
   
   if( getWordCount( %shapes ) > 0 )
   {
      %callback = "SBCreateTrash::doShape3DDelete(\"" @ %filename @ "\", \"" @ %shapes @ "\");";
      MessageBoxYesNo( "Delete Objects", "There are objects using this shape in your scene. If you continue, " @
                       "they will be deleted. Continue?", %callback, "" );
   }
   else
      SBCreateTrash::doShape3DDelete( %filename, %shapes );
}

function SBCreateTrash::doShape3DDelete( %filename, %shapes )
{
   %msg = "是否保存所做更改 " @ %documentName @ "?";
   
   if( %cancelOption == true ) 
      %buttons = "SaveDontSaveCancel";
   else
      %buttons = "SaveDontSave";
      
   %mbResult = MessageBox( "删除贴图", "Would you like to delete the texture files associated with this 3D shape?",
                     "SaveDontSaveCancel", "Question" );   
   
   // Cancel aborts deleting the shape
   if( %mbResult $= $MRCancel ) 
      return false;
   else if( %mbResult $= $MROk )
      // Yes deletes the shape and it's textures
      SBCreateTrash::deleteShape3DTextures(%filename ,%shapes ,true );
   else if( %mbResult $= $MRDontSave )
      // No delete just the DTS file
      SBCreateTrash::deleteShape3DTextures(%filename ,%shapes ,false );
}                       

function SBCreateTrash::deleteShape3DTextures( %filename, %shapes, %deleteTextures )
{
   %count = getWordCount( %shapes );
   for( %i = 0; %i < %count; %i++ )
   {
      %shape = getWord( %shapes, %i );
      if( isObject( %shape ) )
         %shape.delete();
   }
   
   if( %deleteTextures && isFile( %fileName ) )
   {
      %shape = new t2dShape3D() { shape = %filename; };
      %textureList = %shape.getTextureFileList();
      %shape.delete();
      %textureCount = getFieldCount( %textureList );
      for( %i = 0; %i < %textureCount; %i++ )
      {
         %texture = getField( %textureList, %i );
         
         if( !isFile( %texture ) )
            continue;
         
         fileDelete( %texture );
      }
   }
   
   fileDelete( %filename );
   GuiFormManager::SendContentMessage($LBC3DShape, 0, "destroy");
   purgeResources();
   GuiFormManager::SendContentMessage($LBC3DShape, 0, "refresh");
}
