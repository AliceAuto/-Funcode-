function LBQuickEditContent::createParticleEmitterStack(%this )
{
   %stack = new GuiStackControl() {
      StackingType = "Vertical";
      class = "LBQuickEditParticleEmitterStack";
      superclass = "LBQuickEditContent";
      HorizStacking = "Left to Right";
      VertStacking = "Top to Bottom";
      Padding = "0";
      canSaveDynamicFields = "0";
      Profile = "EditorContainerProfile";
      HorizSizing = "width";
      VertSizing = "height";
      Position = "0 0";
      Extent = "300 250";
      MinExtent = "150 10";
      canSave = "1";
      Visible = "1";
      hovertime = "1000";
      object = %this.object;
      parent = %this;
   };
   
   %stack.spatialProperties = new SimSet();
   %stack.statusCheck = new SimSet();
   %stack.properties = new SimSet();
   $LB::QuickEditGroup.add( %stack.spatialProperties );
   $LB::QuickEditGroup.add( %stack.statusCheck );
   $LB::QuickEditGroup.add( %stack.properties );
   $LB::QuickEditGroup.add( %stack );
   
   
   %this.addProperty(%stack);
   %this.add(%stack);
   return %stack;
}



function LBQuickEditParticleEmitterStack::createAddEmitter(%this )
{
   %container = new GuiControl() {
      canSaveDynamicFields = "0";
      Profile = "EditorContainerProfile";
      HorizSizing = "right";
      VertSizing = "bottom";
      Position = "0 0";
      Extent = "300 42";
      MinExtent = "8 2";
      canSave = "1";
      Visible = "1";
      hovertime = "100";
   };
   
   %labelControl = new GuiTextCtrl() {
      canSaveDynamicFields = "0";
      Profile = "EditorFontHLBold";
      HorizSizing = "right";
      VertSizing = "bottom";
      Position = "16 8";
      Extent = "128 18";
      MinExtent = "8 2";
      canSave = "1";
      Visible = "1";
      hovertime = "100";
      tooltip = "���һ������������Ч";
      tooltipProfile = "EditorToolTipProfile";
      text = "��������:";
      maxLength = "1024";
   };
   
   %nameControl = new GuiTextEditCtrl() {
      Profile = "EditorTextEdit";
      HorizSizing = "right";
      VertSizing = "bottom";
      Position = "158 7"; //"128 7";
      Extent = "142 20";
      MinExtent = "8 2";
      canSave = "1";
      Visible = "1";
      hovertime = "100";
      maxLength = "1024";
      historySize = "0";
      password = "0";
      tabComplete = "0";
      sinkAllKeyEvents = "0";
      password = "0";
      passwordMask = "*";
      text = "NewEmitterName";
   };
   
   
   
   %buttonControl = new GuiIconButtonCtrl() {
      canSaveDynamicFields = "0";
      class  = LBQuickEditAddEmitterButton;
      Profile = "EditorButton";
      HorizSizing = "right";
      VertSizing = "bottom";
      Position = "128 7"; //"278 7";
      Extent = "22 22";
      MinExtent = "8 2";
      canSave = "1";
      Visible = "1";
      hovertime = "100";
      iconBitmap = "~/levelEditor/gui/images/iconAdd.png";
      sizeIconToButton = "1";
      nameControl = %nameControl;
      base = %this;
   };
   
   
   %container.add(%labelControl);
   %container.add(%nameControl);
   %container.add(%buttonControl);
   
   %this.add(%container);
   return %container;
}

function LBQuickEditParticleEmitterStack::setProperty(%this, %object)
{
   GuiFormManager::BroadcastContentMessage( "LevelBuilderQuickEditClasses", %this, "updateEffectObject" SPC %object );   
   
   // Delete Children
   %this.deleteChildren();
 
   if( !isObject( %object ) )
      return;
        
   // Create Add Emitter Button
   %this.createAddEmitter();
   
   // Add Existent Emitters
   %count = %object.getEmitterCount();
   for( %i = 0; %i < %count; %i++ )
   {
      // Fetch Emitter
      %emitter = %object.getEmitterObject( %i );
      if( !isObject( %emitter ) ) 
         continue;
      
      // Create the emitter edit.
      %emitterStack = %this.createRolloutStack("Emitter -" SPC %emitter.getEmitterName(), false );
      %emitterStack.rolloutCtrl.Collapsed = true;
      %emitterStack.rolloutCtrl.setInternalName("ParticleEmitterStack");
      %emitterStack.object = %emitter;
      
      %button = new GuiIconButtonCtrl(ShowEmitterGraphButton) {
         canSaveDynamicFields = "0";
         class  = TGBEmitterFieldList;
         superClass = TGBGraphFieldList;
         Profile = "EditorButtonMiddle";
         HorizSizing = "right";
         VertSizing = "bottom";
         Position = "6 4";
         Extent = "18 24";
         MinExtent = "8 2";
         canSave = "1";
         Visible = "1";
         hovertime = "100";
         iconBitmap = "~/levelEditor/gui/images/iconGraphLine.png";
         sizeIconToButton = "0";
         text = "�༭����ͼ��";
         textLocation = "Center";
         ButtonMargin = "12 3";
         valueControl = %valueControl;
         nameControl = %nameControl;
         fieldsObject = %emitter;
         base = %this;
         tooltip = "��ʾ���������ͼ������";
         tooltipProfile = "EditorToolTipProfile"; 
         hovertime = 100;        
      };
      %emitterStack.add( %button );
      
      %emitterStack.createSpacer(12);
      
      %imageMap = %emitterStack.createT2DDatablockList("ImageMapOrAnimation", "ͼƬ", "t2dImageMapDatablock");
      %animation = %emitterStack.createT2DDatablockList("ImageMapOrAnimation", "����", "t2dAnimationDatablock");
      %frameStack = %emitterStack.createHideableStack(%emitter @ ".getUsingAnimation();");
      %frameStack.addControlDependency(%imageMap);
      %frameStack.addControlDependency(%animation);
      %frameStack.createLeftRightEdit("Frame", "0;", %emitter @ ".getImageMap().getFrameCount() - 1;", 1, "֡��", "��ʾ֡��");
      %emitterStack.createListBox("emitterType", false, "����", "POINT\tLINEX\tLINEY\tAREA");
      %emitterStack.createListBox("particleOrientationMode", false, "����", "ALIGNED\tFIXED\tRANDOM");
      %emitterStack.createTextEdit("fixedAngleOffset", 2, "�̶��Ƕ�ƫ��");
      %emitterStack.createTextEdit2("pivotPointX", "pivotPointY", 2, "���ĵ�", "X", "Y");
      %emitterStack.createTextEdit("fixedForceAngle", 2, "�������Ƕ�");
      %emitterStack.createCheckBox("FixedAspect", "�̶�����");
      %emitterStack.createCheckBox("UseEffectEmission", "ʹ����Ч������");
      %emitterStack.createCheckBox("IntenseParticles", "ǿ����Ч");
      %emitterStack.createCheckBox("SingleParticle", "��һ��Ч");
      %emitterStack.createCheckBox("AttachPositionToEmitter", "����λ��");
      %emitterStack.createCheckBox("AttachRotationToEmitter", "���泯��");
      %emitterStack.createCheckBox("LinkEmissionRotation", "��ת������");
      %emitterStack.createCheckBox("FirstinFrontOrder", "��ǰ���ȷ���");
      
      %deleteEmitterButton = %emitterStack.createCommandButton("", "ɾ��������", DeleteEmitterGraphButton);
      %deleteEmitterButton.fieldsObject = %emitter;
      %deleteEmitterButton.base = %this;
   }

   if( %count > 0 )
      %object.playEffect();
   
   GuiFormManager::SendContentMessage( $LBQuickEdit, %this, "resize");
   ToolManager.getLastWindow().setFirstResponder();
}

function LBQuickEditParticleEmitterStack::deleteChildren(%this)
{
   while (%this.parent.findObjectByInternalName("ParticleEmitterStack") )
   {
      %object = %this.parent.findObjectByInternalName("ParticleEmitterStack");
      if( isObject( %object ) )
         %object.delete();
   }
   
   while( %this.getCount() )
   {
      %object = %this.getObject( 0 );
      if( isObject( %object ) )
         %this.getObject( 0 ).delete();
   }
}

function t2dParticleEmitter::getPivotPointX(%this)
{
   return getWord(%this.getPivotPoint(), 0);
}

function t2dParticleEmitter::getPivotPointY(%this)
{
   return getWord(%this.getPivotPoint(), 1);
}

function t2dParticleEmitter::setPivotPointX(%this, %x)
{
   %y = %this.getPivotPointY();
   %this.setPivotPoint(%x, %y);
}

function t2dParticleEmitter::setPivotPointY(%this, %y)
{
   %x = %this.getPivotPointX();
   %this.setPivotPoint(%x, %y);
}

function t2dParticleEmitter::getImageMap(%this)
{
   return getWord(%this.getImageMapNameFrame(), 0);
}

function t2dParticleEmitter::getImageMapOrAnimation(%this)
{
   if (%this.getUsingAnimation())
      return %this.getAnimationName();
      
   return %this.getImageMap();
}

function t2dParticleEmitter::setImageMapOrAnimation(%this, %db)
{
   if (!isObject(%db))
      return;
      
   if (%db.getClassName() $= "t2dImageMapDatablock")
      %this.setImageMap(%db);
   else
      %this.setAnimationName(%db);
}

function t2dParticleEmitter::getFrame(%this)
{
   return getWord(%this.getImageMapNameFrame(), 1);
}

function t2dParticleEmitter::setFrame(%this, %frame)
{
   %imageMap = getWord(%this.getImageMapNameFrame(), 0);
   %this.setImageMap(%imageMap, %frame);
}