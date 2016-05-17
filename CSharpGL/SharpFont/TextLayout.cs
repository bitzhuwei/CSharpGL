using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpFont
{
    public class TextLayout
    {
        public List<Data> Stuff = new List<Data>();

        internal void SetCount(int count)
        {
            Stuff.Clear();
            Stuff.Capacity = count;
        }

        internal void AddGlyph(int destX, int destY, int sourceX, int sourceY, int width, int height)
        {
            Stuff.Add(new Data
            {
                DestX = destX,
                DestY = destY,
                SourceX = sourceX,
                SourceY = sourceY,
                Width = width,
                Height = height
            });
        }

        public struct Data
        {
            public int DestX, DestY;
            public int SourceX, SourceY;
            public int Width, Height;
        }
    }
}
