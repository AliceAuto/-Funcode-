//---------------------------------------------------------------------------------------------
// Torque Game Builder
// Copyright (C) GarageGames.com, Inc.
//---------------------------------------------------------------------------------------------

$LevelEditorSaving::LayersNeedingSave = new ScriptObject() { class = LayerSaveSet; superClass = LevelEditorSaveSet; };
$LevelEditorSaving::EffectsNeedingSave = new ScriptObject() { class = EffectSaveSet; superClass = LevelEditorSaveSet; };

function LevelEditorSaveSet::onRemove( %this )
{
   if( isObject( %this.set ) )
      %this.set.delete();
}

function LevelEditorSaveSet::add( %this, %object )
{
   if( !isObject( %this.set ) )
      %this.set = new SimSet();
      
   %this.set.add( %object );
}

function LevelEditorSaveSet::remove( %this, %object )
{
   if( !isObject( %this.set ) )
   {
      %this.set = new SimSet();
      return;
   }
      
   %this.set.remove( %object );
}

function LevelEditorSaveSet::getCount( %this )
{
   if( !isObject( %this.set ) )
      %this.set = new SimSet();
      
   return %this.set.getCount();
}

function LevelEditorSaveSet::getObject( %this, %index )
{
   if( !isObject( %this.set ) )
   {
      %this.set = new SimSet();
      return;
   }
      
   return %this.set.getObject( %index );
}

function LevelEditorSaveSet::isMember( %this, %object )
{
   if( !isObject( %this.set ) )
      %this.set = new SimSet();
      
   return %this.set.isMember( %object );
}

function LevelEditorSaveSet::clear( %this )
{
   if( !isObject( %this.set ) )
      %this.set = new SimSet();
      
   %this.set.clear();
}

function LevelEditorSaveSet::setObjectNeedsSave( %this, %object, %val )
{
   if( %val && !%this.isMember( %object ) )
      %this.add( %object );
      
   else if( !%val && %this.isMember( %object ) )
      %this.remove( %object );
}

function LevelEditorSaveSet::getObjectNeedsSave( %this )
{
   return (%this.getCount() > 0);
}

function LayerSaveSet::saveAll( %this, %callback )
{
   %count = %this.getCount();
   if (%count > 0)
   {
      %layer = %this.getObject( 0 );
      if( %layer.getClassName() !$= "t2dTileLayer")
      {
         warn( "Invalid object found in layer save set." );
         %this.remove( %layer );
         return;
      }
      
      TileEditor::saveLayer( %layer, %callback );
   }
   
   if( (%count <= 0) && (%callback !$= "" ) )
      eval( %callback );
}

function EffectSaveSet::saveAll( %this, %callback )
{
   %count = %this.getCount();
   if (%count > 0)
   {
      %effect = %this.getObject( 0 );
      if( %effect.getClassName() !$= "t2dParticleEffect")
      {
         warn( "Invalid object found in effect save set." );
         %this.remove( %effect );
         return;
      }
      
      ParticleEditor::saveEffect( %effect, %callback );
   }
   
   if( (%count <= 0) && (%callback !$= "" ) )
      eval( %callback );
}

function SimObject::onChanged( %this )
{
   GuiFormManager::BroadcastContentMessage( "LevelBuilderQuickEditClasses", %this, "onChanged" SPC %this );
}

function t2dSceneObjectSet::onChanged( %this )
{
   Parent::onChanged( %this );
   
   %count = %this.getCount();
   for( %i = 0; %i < %count; %i++ )
   {
      %obj = %this.getObject( %i );
      %obj.onChanged();
   }
}

function t2dTileLayer::onChanged( %this )
{
   Parent::onChanged( %this );
   
   $LevelEditorSaving::LayersNeedingSave.setObjectNeedsSave( %this, true );
}

function t2dTileLayer::onLayerSaved( %this )
{
   Parent::onChanged( %this );
   
   $LevelEditorSaving::LayersNeedingSave.setObjectNeedsSave( %this, false );
}

function t2dParticleEffect::onChanged( %this )
{
   Parent::onChanged( %this );
   
   $LevelEditorSaving::EffectsNeedingSave.setObjectNeedsSave( %this, true );
}

function t2dParticleEmitter::onChanged( %this )
{
   Parent::onChanged( %this );
   
   %this.getParentEffect().onChanged();
}

function t2dParticleEffect::onEffectSaved( %this )
{
   $LevelEditorSaving::EffectsNeedingSave.setObjectNeedsSave( %this, false );
}

function LevelEditor::getLayerNeedsSave()
{
   return $LevelEditorSaving::LayersNeedingSave.getObjectNeedsSave();
}

function LevelEditor::getEffectNeedsSave()
{
   return $LevelEditorSaving::EffectsNeedingSave.getObjectNeedsSave();
}

function LevelEditor::saveAllLayersAndEffects()
{
   if( LevelEditor::getEffectNeedsSave() )
      $LevelEditorSaving::EffectsNeedingSave.saveAll( %fullCallback );
   else if( LevelEditor::getLayerNeedsSave() )
      $LevelEditorSaving::LayersNeedingSave.saveAll( %fullCallback );
}

function LevelEditor::dontSaveLayersAndEffects()
{
   $LevelEditorSaving::LayersNeedingSave.clear();
   $LevelEditorSaving::EffectsNeedingSave.clear();
}

function LevelEditor::checkUnsavedObjects( %callback )
{
   if( LevelEditor::getLayerNeedsSave() || LevelEditor::getEffectNeedsSave() )
   {
      //MessageBoxOKCancel( "Unsaved Objects.", "There are unsaved tile maps or particle effects in your level. " @
                    //"If these aren't saved, the changes will be lost when the level is closed.",
                    //"LevelEditor::dontSaveLayersAndEffects();" @ %callback, "" );
                    
        MessageBoxYesNoCancel( "是否保存场景及特效?", "场景中有未保存的平铺图或粒子，如果不保存，当运行场景或者关闭场景时，此数据将丢失. 是否保存?",
                               "LevelEditor::saveAllLayersAndEffects(\"" @ %callback @ "\");",
                               "LevelEditor::dontSaveLayersAndEffects();" @ %callback, "" );

      return true;
   }
   
   return false;
}
