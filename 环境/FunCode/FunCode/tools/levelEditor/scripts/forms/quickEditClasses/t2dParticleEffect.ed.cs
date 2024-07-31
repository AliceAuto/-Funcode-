//-----------------------------------------------------------------------------
// Gui SceneGraphEditCtrl Form Content
// Copyright (C) GarageGames.com, Inc.
//-----------------------------------------------------------------------------

//-----------------------------------------------------------------------------
// Register Form Content.
//-----------------------------------------------------------------------------
$LBQEParticleEffect = GuiFormManager::AddFormContent( "LevelBuilderQuickEditClasses", "t2dParticleEffect", "LBQEParticleEffect::CreateForm", "LBQEParticleEffect::SaveForm", 2 );

//-----------------------------------------------------------------------------
// Form Content Creation Function
//-----------------------------------------------------------------------------
function LBQEParticleEffect::CreateForm( %contentCtrl, %quickEditObj )
{    
   
   %base = %contentCtrl.createBaseStack("LBQESceneObjectClass", %quickEditObj);
   %rollout = %base.createRolloutStack("粒子特效", true);
   
   // Create Effect Persistence Buttons
   //%emitterStack = %rollout.createEffectPersistence( %quickEditObj );
   
   //%rollout.createSpacer(12);
      
   // Create Effect Graph Editing Button
   //%button = new GuiIconButtonCtrl(ShowEffectGraphButton) {
   //   canSaveDynamicFields = "0";
  //    class  = TGBEffectFieldList;
   //   superClass = TGBGraphFieldList;
   //   Profile = "EditorButton";
   //   HorizSizing = "right";
   //   VertSizing = "bottom";
   //   Position = "6 4";
   //   Extent = "16 24";
   //   canSave = "1";
   //   Visible = "1";
   //   hovertime = "100";
   //   iconBitmap = "~/levelEditor/gui/images/iconGraphLine.png";
   //   sizeIconToButton = "0";
   //   text = "编辑特效图像";
   //   textLocation = "Center";
   //   ButtonMargin = "12 3";
   //   fieldsObject = %quickEditObj;
   //};
   //%rollout.add( %button );
   
   //%rollout.createSpacer(12);
     
   // Effect Life Mode
   %effectModeCtrl = %rollout.createEnumList("effectMode", true, "特效模式", "特效的生命模式: 无限播放、循环播放", "t2dParticleEffect", "effectMode");
   %effectTimeStack = %rollout.createHideableStack("(" @ %base @ ".object.effectMode $= \"INFINITE\");");
   %effectTimeStack.addControlDependency(%effectModeCtrl);
   %effectTimeStack.createTextEditProperty( "effectTime", 3, "特效生命周期", "特效生命时长");
   //%rollout.createCheckBox("effectCollisionStatus", "开启特效碰撞");
        
   // Create Emitter Chain
   //%emitterStack = %rollout.createParticleEmitterStack();
      
   %contentCtrl.add(%base);

   //*** Return back the base control to indicate we were successful
   return %base;
}

//-----------------------------------------------------------------------------
// Form Content Save Function
//-----------------------------------------------------------------------------
function LBParticleEditToolProperties::SaveForm( %formCtrl )
{
   // Nothing.
}


function LBQuickEditContent::createEffectPersistence(%this, %object )
{
   %container = new GuiControl() 
   {
      canSaveDynamicFields = "0";
      Profile = "EditorPanelLight";
      HorizSizing = "right";
      VertSizing = "bottom";
      position = "324 186";
      Extent = "230 37";
      MinExtent = "8 2";
      canSave = "1";
      Visible = "1";
      hovertime = "1000";
   };
   
   %loadEffectButton = new GuiIconButtonCtrl() 
   {
      canSaveDynamicFields = "0";
      Profile = "EditorButton";
      HorizSizing = "right";
      VertSizing = "bottom";
      class = ParticleLoadEffectButton;
      position = "6 7";
      Extent = "94 23";
      MinExtent = "8 2";
      canSave = "1";
      Visible = "1";
      hovertime = "1000";
      text = "加载特效";
      groupNum = "-1";
      buttonType = "PushButton";
      buttonMargin = "4 4";
      iconBitmap = "^tools/levelEditor/gui/images/iconOpen.png";
      iconLocation = "Left";
      sizeIconToButton = "0";
      textLocation = "Right";
      textMargin = "4";
      parentObject = %this;
   };
   
   %saveEffectButton = new GuiIconButtonCtrl() 
   {
      canSaveDynamicFields = "0";
      Profile = "EditorButton";
      class = ParticleSaveEffectButton;
      HorizSizing = "left";
      VertSizing = "bottom";
      position = "130 7";
      Extent = "94 23";
      MinExtent = "8 2";
      canSave = "1";
      Visible = "1";
      hovertime = "1000";
      text = "保存特效";
      groupNum = "-1";
      buttonType = "PushButton";
      buttonMargin = "4 4";
      iconBitmap = "^tools/levelEditor/gui/images/iconSave.png";
      iconLocation = "Left";
      sizeIconToButton = "0";
      textLocation = "Right";
      textMargin = "4";
      parentObject = %this;      
   };
   
   %this.effectObject = %object;
   
   %container.add(%loadEffectButton);
   %container.add(%saveEffectButton);
   
   %this.add(%container);
   
   return %container;
}


function ParticleSaveEffectButton::onClick( %this )
{
   if( !isObject( $editingeffectObject ) )
      return;
      
   %callback = "GuiFormManager::BroadcastContentMessage( \"LevelBuilderSidebarCreate\", 0, \"refresh\" );";
   ParticleEditor::saveEffect( $editingeffectObject, %callback, true );
}

function ParticleLoadEffectButton::onClick( %this )
{
   %effectObject = $editingeffectObject;
   if( !isObject( %effectObject ) )
      return;

   // Fetch file name to open  
   if (fileName(%effectObject.effectFile) !$= $particleEditor::NewEffectFileName)
      %currentFile = %effectObject.effectFile;
   else 
      %currentFile = "";
  
   %fileName = T2DParticleEffect::getLevelOpenName( %currentFile );
   
   // If none, return
   if( %fileName $= "" )
      return;
   
   %position = %effectObject.getPosition();
   %size = %effectObject.getSize();
      
   %effectObject.loadEffect( %fileName );
   %effectObject.playEffect( true );
   
   %effectObject.setSize( GetWord( %size, 0 ), GetWord( %size, 1 ) );
   %effectObject.setPosition( GetWord( %position, 0 ), GetWord( %position, 1 ) );
      

   // Update Global Effect Var      
   GuiFormManager::BroadcastContentMessage( "LevelBuilderQuickEditClasses", %this, "updateEffectObject" SPC %effectObject );   
   // Update Quick Edit
   GuiFormManager::BroadcastContentMessage( "LevelBuilderQuickEditClasses", %this, "syncQuickEdit" SPC %effectObject );
   // refresh the particle object library
   GuiFormManager::BroadcastContentMessage( "LevelBuilderSidebarCreate", 0, "refresh" );

}