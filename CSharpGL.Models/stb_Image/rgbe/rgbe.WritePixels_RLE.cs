using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace CSharpGL {
    public static partial class rgbe {
        /* read or write run length encoded files */
        /* must be called to read or write whole scanlines */
        public static int RGBE_WritePixels_RLE(StreamWriter fp, float[] data, int scanline_width, int num_scanlines) {
            char[] rgbe = new char[4];
            int i, err;

            //if ((scanline_width < 8) || (scanline_width > 0x7fff))
            //    /* run length encoding is not allowed so write flat*/
            //    return RGBE_WritePixels(fp, data, scanline_width*num_scanlines);


            char[] buffer = new char[4 * scanline_width];
            int index = 0;
            while (num_scanlines-- > 0) {
                rgbe[0] = (char)2;
                rgbe[1] = (char)2;
                rgbe[2] = (char)(scanline_width >> 8);
                rgbe[3] = (char)(scanline_width & 0xFF);
                fp.Write(rgbe);
                for (i = 0; i < scanline_width; i++) {
                    float2rgbe(rgbe, data[index + RGBE_DATA_RED], data[index + RGBE_DATA_GREEN], data[index + RGBE_DATA_BLUE]);
                    buffer[i] = rgbe[0];
                    buffer[i + scanline_width] = rgbe[1];
                    buffer[i + 2 * scanline_width] = rgbe[2];
                    buffer[i + 3 * scanline_width] = rgbe[3];
                    index += RGBE_DATA_SIZE;
                }
                /* write out each of the four channels separately run length encoded */
                /* first red, then green, then blue, then exponent */
                for (i = 0; i < 4; i++) {
                    if ((err = RGBE_WriteBytes_RLE(fp, buffer, i * scanline_width,
                        scanline_width)) != RGBE_RETURN_SUCCESS) {
                        return err;
                    }
                }
            }

            return RGBE_RETURN_SUCCESS;
        }
    }
}
