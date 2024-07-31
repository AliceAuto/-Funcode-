//---------------------------------------------------------------------------------------------
// Torque Game Builder
// Copyright (C) GarageGames.com, Inc.
//---------------------------------------------------------------------------------------------


if(!isObject(NavPanelProfile)) new GuiControlProfile (NavPanelProfile) 
{
   opaque = false;
   border = -2;
};


if(!isObject(NavPanel)) new GuiControlProfile (NavPanel : NavPanelProfile) 
{
   bitmap = "./navPanel";
};

if(!isObject(NavPanelBlue)) new GuiControlProfile (NavPanelBlue : NavPanelProfile) 
{
   bitmap = "./navPanel_blue";
};

if(!isObject(NavPanelGreen)) new GuiControlProfile (NavPanelGreen : NavPanelProfile) 
{
   bitmap = "./navPanel_green";
};

if(!isObject(NavPanelRed)) new GuiControlProfile (NavPanelRed : NavPanelProfile) 
{
   bitmap = "./navPanel_red";
};

if(!isObject(NavPanelWhite)) new GuiControlProfile (NavPanelWhite : NavPanelProfile) 
{
   bitmap = "./navPanel_white";
};

if(!isObject(NavPanelYellow)) new GuiControlProfile (NavPanelYellow : NavPanelProfile) 
{
   bitmap = "./navPanel_yellow";
};

