using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Font2Bmps
{
    class WorkerData
    {
        public int fontHeight;
        public int maxTexturWidth;
        public char firstChar;
        public char lastChar;
        public string[] selectedTTFFiles;
        public bool generateGlyphList;
        public bool drawBBox;

        public WorkerData(int fontHeight, int maxTexturWidth,
            char firstChar, char lastChar, string[] selectedTTFFiles,
            bool generateGlyphList, bool drawHeightLine)
        {
            this.fontHeight = fontHeight;
            this.maxTexturWidth = maxTexturWidth;
            this.firstChar = firstChar;
            this.lastChar = lastChar;
            this.selectedTTFFiles = selectedTTFFiles;
            this.generateGlyphList = generateGlyphList;
            this.drawBBox = drawHeightLine;
        }
    }
}
