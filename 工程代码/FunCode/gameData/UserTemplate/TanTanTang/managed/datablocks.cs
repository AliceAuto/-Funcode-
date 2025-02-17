$managedDatablockSet = new SimSet() {
   canSaveDynamicFields = "1";
      setType = "Datablocks";

   new t2dImageMapDatablock(DandanBackImageMap) {
      imageName = "~/data/images/DandanBack.dds";
      imageMode = "CELL";
      frameCount = "-1";
      filterMode = "SMOOTH";
      filterPad = "0";
      preferPerf = "0";
      cellRowOrder = "1";
      cellOffsetX = "0";
      cellOffsetY = "0";
      cellStrideX = "0";
      cellStrideY = "0";
      cellCountX = "1";
      cellCountY = "1";
      cellWidth = "683";
      cellHeight = "512";
      preload = "0";
      allowUnload = "0";
      force16Bit = "0";
   };
   new t2dImageMapDatablock(DandanBlock1ImageMap) {
      imageName = "~/data/images/DandanBlock1.dds";
      imageMode = "FULL";
      frameCount = "-1";
      filterMode = "SMOOTH";
      filterPad = "0";
      preferPerf = "1";
      cellRowOrder = "1";
      cellOffsetX = "0";
      cellOffsetY = "0";
      cellStrideX = "0";
      cellStrideY = "0";
      cellCountX = "-1";
      cellCountY = "-1";
      cellWidth = "0";
      cellHeight = "0";
      preload = "1";
      allowUnload = "0";
      force16Bit = "0";
   };
   new t2dImageMapDatablock(DandanBumbImageMap) {
      imageName = "~/data/images/DandanBumb.dds";
      imageMode = "CELL";
      frameCount = "-1";
      filterMode = "SMOOTH";
      filterPad = "0";
      preferPerf = "0";
      cellRowOrder = "1";
      cellOffsetX = "0";
      cellOffsetY = "0";
      cellStrideX = "0";
      cellStrideY = "0";
      cellCountX = "-1";
      cellCountY = "-1";
      cellWidth = "64";
      cellHeight = "64";
      preload = "0";
      allowUnload = "0";
      force16Bit = "0";
   };
   new t2dImageMapDatablock(DandanCannonImageMap) {
      imageName = "~/data/images/DandanCannon.dds";
      imageMode = "FULL";
      frameCount = "-1";
      filterMode = "SMOOTH";
      filterPad = "0";
      preferPerf = "1";
      cellRowOrder = "1";
      cellOffsetX = "0";
      cellOffsetY = "0";
      cellStrideX = "0";
      cellStrideY = "0";
      cellCountX = "-1";
      cellCountY = "-1";
      cellWidth = "0";
      cellHeight = "0";
      preload = "1";
      allowUnload = "0";
      force16Bit = "0";
   };
   new t2dImageMapDatablock(DandanPlatformImageMap) {
      imageName = "~/data/images/DandanPlatform.dds";
      imageMode = "FULL";
      frameCount = "-1";
      filterMode = "SMOOTH";
      filterPad = "0";
      preferPerf = "1";
      cellRowOrder = "1";
      cellOffsetX = "0";
      cellOffsetY = "0";
      cellStrideX = "0";
      cellStrideY = "0";
      cellCountX = "-1";
      cellCountY = "-1";
      cellWidth = "0";
      cellHeight = "0";
      preload = "1";
      allowUnload = "0";
      force16Bit = "0";
   };
   new t2dImageMapDatablock(particles2ImageMap) {
      imageName = "~/data/images/particles2.dds";
      imageMode = "CELL";
      frameCount = "-1";
      filterMode = "SMOOTH";
      filterPad = "0";
      preferPerf = "0";
      cellRowOrder = "1";
      cellOffsetX = "0";
      cellOffsetY = "0";
      cellStrideX = "0";
      cellStrideY = "0";
      cellCountX = "-1";
      cellCountY = "-1";
      cellWidth = "128";
      cellHeight = "128";
      preload = "0";
      allowUnload = "0";
      force16Bit = "0";
   };
   new t2dImageMapDatablock(particles3ImageMap) {
      imageName = "~/data/images/particles3.dds";
      imageMode = "CELL";
      frameCount = "-1";
      filterMode = "SMOOTH";
      filterPad = "0";
      preferPerf = "0";
      cellRowOrder = "1";
      cellOffsetX = "0";
      cellOffsetY = "0";
      cellStrideX = "0";
      cellStrideY = "0";
      cellCountX = "-1";
      cellCountY = "-1";
      cellWidth = "128";
      cellHeight = "128";
      preload = "0";
      allowUnload = "0";
      force16Bit = "0";
   };
   new t2dAnimationDatablock(DandanBumbAnimation) {
      imageMap = "DandanBumbImageMap";
      animationFrames = "0 1 2 3";
      animationTime = "0.133333";
      animationCycle = "1";
      randomStart = "0";
      startFrame = "0";
      animationPingPong = "0";
      animationReverse = "0";
   };
   new t2dImageMapDatablock(DandanTarget1ImageMap) {
      imageName = "~/data/images/DandanTarget1.dds";
      imageMode = "CELL";
      frameCount = "-1";
      filterMode = "SMOOTH";
      filterPad = "0";
      preferPerf = "0";
      cellRowOrder = "1";
      cellOffsetX = "0";
      cellOffsetY = "0";
      cellStrideX = "0";
      cellStrideY = "0";
      cellCountX = "4";
      cellCountY = "5";
      cellWidth = "64";
      cellHeight = "92";
      preload = "0";
      allowUnload = "0";
      force16Bit = "0";
   };
   new t2dImageMapDatablock(DandanTarget2ImageMap) {
      imageName = "~/data/images/DandanTarget2.dds";
      imageMode = "CELL";
      frameCount = "-1";
      filterMode = "SMOOTH";
      filterPad = "0";
      preferPerf = "0";
      cellRowOrder = "1";
      cellOffsetX = "0";
      cellOffsetY = "0";
      cellStrideX = "0";
      cellStrideY = "0";
      cellCountX = "4";
      cellCountY = "5";
      cellWidth = "64";
      cellHeight = "92";
      preload = "0";
      allowUnload = "0";
      force16Bit = "0";
   };
   new t2dImageMapDatablock(DandanTarget3ImageMap) {
      imageName = "~/data/images/DandanTarget3.dds";
      imageMode = "CELL";
      frameCount = "-1";
      filterMode = "SMOOTH";
      filterPad = "0";
      preferPerf = "0";
      cellRowOrder = "1";
      cellOffsetX = "0";
      cellOffsetY = "0";
      cellStrideX = "0";
      cellStrideY = "0";
      cellCountX = "4";
      cellCountY = "5";
      cellWidth = "64";
      cellHeight = "92";
      preload = "0";
      allowUnload = "0";
      force16Bit = "0";
   };
   new t2dAnimationDatablock(DandanTargetAnimation1) {
      imageMap = "DandanTarget1ImageMap";
      animationFrames = "0 1 2 3 4 5 6 7 8 9 10 11 12 13 14 15";
      animationTime = "0.533333";
      animationCycle = "1";
      randomStart = "0";
      startFrame = "0";
      animationPingPong = "0";
      animationReverse = "0";
   };
   new t2dAnimationDatablock(DandanTargetAnimation2) {
      imageMap = "DandanTarget2ImageMap";
      animationFrames = "0 1 2 3 4 5 6 7 8 9 10 11 12 13 14 15";
      animationTime = "0.695652";
      animationCycle = "1";
      randomStart = "0";
      startFrame = "0";
      animationPingPong = "0";
      animationReverse = "0";
   };
   new t2dAnimationDatablock(DandanTargetAnimation3) {
      imageMap = "DandanTarget3ImageMap";
      animationFrames = "0 1 2 3 4 5 6 7 8 9 10 11 12 13 14 15";
      animationTime = "1";
      animationCycle = "1";
      randomStart = "0";
      startFrame = "0";
      animationPingPong = "0";
      animationReverse = "0";
   };
};
