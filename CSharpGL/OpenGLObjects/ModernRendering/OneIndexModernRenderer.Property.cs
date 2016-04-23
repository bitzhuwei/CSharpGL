using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL
{
    public partial class OneIndexModernRenderer : ModernRenderer
    {

        private int mapBufferRangeLength = 2 * 2 * 2 * 2 * 3 * 3 * 3 * 3 * 10;

        public int MapBufferRangeLength
        {
            get { return mapBufferRangeLength; }
            set
            {
                if (value < sizeof(uint) * 4)
                {
                    mapBufferRangeLength = sizeof(uint) * 4;
                }
                else
                {
                    mapBufferRangeLength = value;
                }
            }
        }
    }
}
