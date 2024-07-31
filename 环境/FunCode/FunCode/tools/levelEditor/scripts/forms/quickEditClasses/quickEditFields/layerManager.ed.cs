function LBQuickEditContent::createLayerManager(%this, %layer )
{
   %container = new GuiControl() {
      canSaveDynamicFields = "0";
      Profile = "EditorContainerProfile";
      HorizSizing = "right";
      VertSizing = "bottom";
      Position = "0 0";
      Extent = "300 30";
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
      Position = "16 6";
      Extent = "128 18";
      MinExtent = "8 2";
      canSave = "1";
      Visible = "1";
      text = "层级 " @ %layer;
      maxLength = "1024";
   };
   
   %locked = new GuiIconButtonCtrl() {
      canSaveDynamicFields = "0";
      class = "LockLayerButton";
      Profile = "EditorButtonToolbar";
      HorizSizing = "right";
      VertSizing = "bottom";
      Position = "98 5";
      Extent = "24 24";
      MinExtent = "8 2";
      canSave = "1";
      Visible = "1";
      groupNum = "-1";
      buttonType = "ToggleButton";
      buttonMargin = "4 4";
      iconLocation = "Center";
      sizeIconToButton = "1";
      textLocation = "Center";
      textMargin = "4";
      layer = %layer;
      tooltipprofile = "EditorToolTipProfile";
      ToolTip = "锁定/解锁此层级";
      hovertime = "100";      
      iconBitmap = expandFilename("^tools/gui/images/iconUnlocked");
   };
   
   %hidden = new GuiIconButtonCtrl() {
      canSaveDynamicFields = "0";
      class = "HideLayerButton";
      Profile = "EditorButtonToolbar";
      HorizSizing = "right";
      VertSizing = "bottom";
      Position = "68 5";
      Extent = "24 24";
      MinExtent = "8 2";
      canSave = "1";
      Visible = "1";
      groupNum = "-1";
      buttonType = "ToggleButton";
      buttonMargin = "4 4";
      iconLocation = "Center";
      sizeIconToButton = "1";
      textLocation = "Center";
      textMargin = "4";
      layer = %layer;
      tooltipprofile = "EditorToolTipProfile";
      ToolTip = "显示/隐藏此层级";
      hovertime = "100";
      iconBitmap = expandFilename("^tools/gui/images/iconVisible");
   };
   
   %listBox = new GuiPopUpMenuCtrlEx() {
      canSaveDynamicFields = "0";
      class = "QuickEditLayerSortEnum";
      internalName = "LayerManager" @ %layer;
      Profile = "GuiPopupMenuProfile";
      HorizSizing = "width";
      VertSizing = "bottom";
      Position = "140 5";
      Extent = "152 20";
      MinExtent = "8 2";
      canSave = "1";
      Visible = "1";
      tooltipprofile = "EditorToolTipProfile";
      ToolTip = "层级排序方式";
      hovertime = "100";
      maxLength = "1024";
      maxPopupHeight = "200";
      object = %this.object;
      layer = %layer;
      fieldString = "layerSortMode" @ %layer;
   };
   
   %listBox.command = "ToolManager.getLastWindow().setFirstResponder(); " @ %listBox @ ".updateProperty(" @ %this @ ".object);";
   %listBox.setEnumContent("t2dSceneGraph", "layerSortMode" @ %layer);
   
   %locked.command = "ToolManager.getLastWindow().setFirstResponder(); " @ %locked @ ".updateProperty(" @ %this @ ".object);";
   %hidden.command = "ToolManager.getLastWindow().setFirstResponder(); " @ %hidden @ ".updateProperty(" @ %this @ ".object);";
   
   %container.add(%labelControl);
   %container.add(%hidden);
   %container.add(%locked);
   %container.add(%listBox);
   
   %this.addProperty(%hidden);
   %this.addProperty(%locked);
   %this.addProperty(%listBox);
   %this.add(%container);
   return %container;
}

function QuickEditLayerSortEnum::setProperty(%this, %object)
{
   %val = %object.getFieldValue( %this.fieldString );
   %this.setSelected( %this.findText( %val ) );
}

function QuickEditLayerSortEnum::updateProperty(%this, %object)
{
   %val = %this.getTextById( %this.getSelected() );
   %object.setFieldValue( %this.fieldString, %val );
}

function HideLayerButton::updateProperty( %this, %object )
{
   %window = ToolManager.getLastWindow();
   if( !isObject( %window ) )
      return;
   
   %val = %this.getValue();
   %mask = %window.getRenderLayerMask();
   %newMask = 0;
   if( %val )
   {
      %this.setBitmap("");
      %newMask = removeBitFromMask( %mask, %this.layer );
   }
   else
   {
      %this.setBitmap(expandFilename("^tools/gui/images/iconVisible"));
      %newMask = addBitToMask( %mask, %this.layer );
   }
      
   %window.setRenderMasks( %newMask );
   %object.onChanged();
}

function LockLayerButton::updateProperty( %this, %object )
{
   %window = ToolManager.getLastWindow();
   if( !isObject( %window ) )
      return;
   
   %val = %this.getValue();
   %mask = %window.getLayerMask();
   %newMask = 0;
   if( %val )
   {
      %this.setBitmap(expandFilename("^tools/gui/images/iconLocked"));
      %newMask = removeBitFromMask( %mask, %this.layer );
   }
   else
   {
      %this.setBitmap(expandFilename("^tools/gui/images/iconUnlocked"));
      %newMask = addBitToMask( %mask, %this.layer );
   }
      
   %window.setLayerMask( %newMask );
   %object.onChanged();
}

function LockLayerButton::setProperty( %this, %object )
{
   %window = ToolManager.getLastWindow();
   if( !isObject( %window ) )
      return;
      
   %val = %window.getLayerMask();
   
   if( %this.layer == 31 )
   {
      if( %val >= BIT( 31 ) )
         %this.setStateOn( true );
      else
         %this.setStateOn( false );
      
      return;
   }
   
   %on = !( %val & BIT( %this.layer ) );
   
   if( %on )
      %this.setBitmap(expandFilename("^tools/gui/images/iconLocked"));
   else
      %this.setBitmap(expandFilename("^tools/gui/images/iconUnlocked"));
     
   %this.setStateOn( %on );
}

function HideLayerButton::setProperty( %this, %object )
{
   %window = ToolManager.getLastWindow();
   if( !isObject( %window ) )
      return;
      
   %val = %window.getRenderLayerMask();
   
   if( %this.layer == 31 )
   {
      if( %val >= BIT( 31 ) )
         %this.setStateOn( true );
      else
         %this.setStateOn( false );
      
      return;
   }
   
   %on = !( %val & BIT( %this.layer ) );
   
   if( %on )
      %this.setBitmap("");
   else
      %this.setBitmap(expandFilename("^tools/gui/images/iconVisible"));
   
   %this.setStateOn( %on );
}
