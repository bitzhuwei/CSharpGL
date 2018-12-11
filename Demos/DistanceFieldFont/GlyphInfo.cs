using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DistanceFieldFont
{
    public class GlyphInfo
    {
        public readonly char name;
        public int x;
        public int y;
        public int width;
        public int height;
        public float xOffset;
        public float yOffset;
        public float xAdvance;
        public int page;
        public int channel;

        public GlyphInfo(char name)
        {
            this.name = name;
        }

        public override string ToString()
        {
            return string.Format("{0}, {1}, {2}, {3}, {4}", name, x, y, width, height);
        }
    }
}
