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
        public static int RGBE_ReadPixels(StreamReader fp, float[] data, int numpixels) {
            char[] rgbe = new char[4];

            int index = 0;
            while (numpixels-- > 0) {
                if (fp.Read(rgbe, 0, 4) < 1) {
                    return rgbe_error(rgbe_error_codes.rgbe_read_error, string.Empty);
                }
                float r, g, b;
                rgbe2float(out r, out g, out b, rgbe);
                data[index + RGBE_DATA_RED] = r;
                data[index + RGBE_DATA_GREEN] = g;
                data[index + RGBE_DATA_BLUE] = b;
                index += RGBE_DATA_SIZE;
            }

            return RGBE_RETURN_SUCCESS;
        }

    }
}
