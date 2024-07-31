//---------------------------------------------------------------------------------------------
// Torque Game Builder
// Copyright (C) GarageGames.com, Inc.
//---------------------------------------------------------------------------------------------

//---------------------------------------------------------------------------------------------
// onWake
// Called by the engine when the options gui is first set.
//---------------------------------------------------------------------------------------------
function OptionsDlg::onWake(%this)
{
   // Fill the graphics drop down menu.
   %buffer = getDisplayDeviceList();
   %count = getFieldCount(%buffer);
   GraphicsDriverMenu.clear();
   
   for(%i = 0; %i < %count; %i++)
      GraphicsDriverMenu.add(getField(%buffer, %i), %i);
      
   // Grab the current graphics driver selection.
   %selId = GraphicsDriverMenu.findText($pref::Video::displayDevice);
   if (%selId == -1)
      %selId = 0;
      
   GraphicsDriverMenu.setSelected(%selId);
   
   // Set audio.
   MusicVolume.setValue($pref::Audio::channelVolume[$musicAudioType]);
   EffectsVolume.setValue($pref::Audio::channelVolume[$effectsAudioType]);
   MusicVolume.oldValue = $pref::Audio::channelVolume[$musicAudioType];
   EffectsVolume.oldValue = $pref::Audio::channelVolume[$effectsAudioType];
   
   // set sleep times
   ForegroundSleep.setValue($Pref::timeManagerProcessInterval);
   BackgroundSleep.setValue($Pref::backgroundSleepTime);
   ForegroundSleep.oldValue = $Pref::timeManagerProcessInterval;
   BackgroundSleep.oldValue = $Pref::backgroundSleepTime;
   
   // Fill the screenshot drop down menu.
   ScreenshotMenu.clear();
   ScreenshotMenu.add("PNG", 0);
   ScreenshotMenu.add("JPEG", 1);
   ScreenshotMenu.setValue($pref::Video::screenShotFormat);
   
   // Set up the keybind options.
   initializeKeybindOptions();
}

// [neo, 6/12/2007 - #3222]
function closeOptionsDialog( %save )
{
   // we either save
   if( %save )
   {
      // Save keybindings
      saveCustomEditorBindings();      
   
      // Save audio / video settings 
      applyAVOptions(); 
      
      // Save Scene editor settings
      updateLevelEdOptions();
   }
   else // or revert
   {
      // rdbnote: I think keybindings will get reset so don't do it here
      
      // Reset audio / video settings
      revertAVOptionChanges();
      
      // Reset Scene editor settings
      revertLevelEdOptionChanges();
   }
   
   Canvas.popDialog(OptionsDlg);
}


//---------------------------------------------------------------------------------------------
// updateChannelVolume
// Update an audio channels volume.
//---------------------------------------------------------------------------------------------
$AudioTestHandle = 0;
function updateChannelVolume(%channel, %volume)
{
   // Only valid channels are 1-8
   if (%channel < 1 || %channel > 8)
      return;
      
   alxSetChannelVolume(%channel, %volume);
   $pref::Audio::channelVolume[%channel] = %volume;
   
   // Play a test sound for volume feedback.
   if (!alxIsPlaying($AudioTestHandle))
   {
      $AudioTestHandle = alxCreateSource("AudioChannel" @ %channel,
                                         expandFilename("~/data/audio/volumeTest.wav"));
      alxPlay($AudioTestHandle);
   }
}

//---------------------------------------------------------------------------------------------
// applyAVOptions
// Apply the AV changes.
//---------------------------------------------------------------------------------------------
function applyAVOptions()
{
   %newDriver = GraphicsDriverMenu.getText();
   $pref::Video::screenShotFormat = ScreenshotMenu.getText();
   
   %res = getRes();
   if (%newDriver !$= $pref::Video::displayDevice)
   {
      // Sort out the menu disappearing by detaching then reattaching popups so
      // that they link/recreate platform dependencies correctly. 
      detachMenuBars();
      
      setDisplayDevice(%newDriver, firstWord(%res), getWord(%res, 1), getWord(%res, 2), isFullScreen());
      
      // Reattach popupmenus to menu bar
      attachMenuBars();
   }

   $Pref::timeManagerProcessInterval = ForegroundSleep.getValue();
   $Pref::backgroundSleepTime = BackgroundSleep.getValue();

   OptionsDlg.onWake();
}

//---------------------------------------------------------------------------------------------
// revertAVOptions
// Revert the AV options to the defaults. Does not apply the changes. Only resets the
// selections.
//---------------------------------------------------------------------------------------------
function revertAVOptions()
{
   // Default graphics driver: OpenGL;
   %selId = GraphicsDriverMenu.findText("OpenGL");
   if (%selId == -1)
      %selId = 0;
      
   GraphicsDriverMenu.setSelected(%selId);
   
   // Default volume: 0.8;
   EffectsVolume.setValue(0.8);
   MusicVolume.setValue(0.8);

   ScreenshotMenu.clear();
   
   // Default screenshot format: PNG;
   ScreenshotMenu.setValue("PNG");
   
   ForegroundSleep.setValue(0);
   BackgroundSleep.setValue(200);
}

//---------------------------------------------------------------------------------------------
// revertAVOptionChanges
// Revert the AV changes made since the options menu was opened - which happen to be the
// values of the related $prefs.
//---------------------------------------------------------------------------------------------
function revertAVOptionChanges()
{
   %selId = GraphicsDriverMenu.findText($pref::Video::displayDevice);
   if (%selId == -1)
      %selId = 0;
      
   GraphicsDriverMenu.setSelected(%selId);
   
   ScreenshotMenu.setValue($pref::video::screenshotFormat);

   EffectsVolume.setValue(EffectsVolume.oldValue);
   MusicVolume.setValue(MusicVolume.oldValue);
   
   ForegroundSleep.setValue(ForegroundSleep.oldValue);
   BackgroundSleep.setValue(BackgrondSleep.oldValue);
}


function MusicVolume::onAction(%this)
{
   updateChannelVolume($musicAudioType, 0.8);
}

function EffectsVolume::onAction(%this)
{
   updateChannelVolume($effectsAudioType, 0.8);
}
