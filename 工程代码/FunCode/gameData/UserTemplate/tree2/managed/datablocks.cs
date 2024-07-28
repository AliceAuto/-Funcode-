$managedDatablockSet = new SimSet() {
   canSaveDynamicFields = "1";
      setType = "Datablocks";

   new t2dImageMapDatablock(background_copyImageMap) {
      imageName = "~/data/images/background_copy.dds";
      imageMode = "CELL";
      frameCount = "-1";
      filterMode = "SMOOTH";
      filterPad = "0";
      preferPerf = "1";
      cellRowOrder = "1";
      cellOffsetX = "0";
      cellOffsetY = "0";
      cellStrideX = "0";
      cellStrideY = "0";
      cellCountX = "1";
      cellCountY = "1";
      cellWidth = "512";
      cellHeight = "384";
      preload = "1";
      allowUnload = "0";
      force16Bit = "0";
   };
};
