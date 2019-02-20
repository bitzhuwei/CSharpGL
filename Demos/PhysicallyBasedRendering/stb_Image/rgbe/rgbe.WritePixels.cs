using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace stb_Image {
    public static partial class rgbe {
        /* read or write pixels */
        /* can read or write pixels in chunks of any size including single pixels*/
        public static int RGBE_WritePixels(StreamWriter fp, float[] data, int numpixels) {
            char[] rgbe = new char[4];

            int index = 0;
            while (numpixels-- > 0) {
                float2rgbe(rgbe, data[index + RGBE_DATA_RED], data[index + RGBE_DATA_GREEN], data[index + RGBE_DATA_BLUE]);
                index += RGBE_DATA_SIZE;
                fp.Write(rgbe);
            }

            return RGBE_RETURN_SUCCESS;
        }

    }
}
