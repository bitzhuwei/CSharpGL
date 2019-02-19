using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace stb_Image {
    public struct rgbe_header_info {
        /// <summary>
        /// indicate which fields are valid.
        /// </summary>
        int valid;
        /// <summary>
        /// listed at beginning of file to identify it after "#?".  defaults to "RGBE".
        /// </summary>
        char[] programtype; // new char[16];
        /// <summary>
        /// image has already been gamma corrected with given gamma.  defaults to 1.0 (no correction) 
        /// </summary>
        float gamma;
        /// <summary>
        /// a value of 1.0 in an image corresponds to &lt;exposure&gt; watts/steradian/m^2. defaults to 1.0
        /// </summary>
        float exposure;

    }

    public static class rgbe {
        /* flags indicating which fields in an rgbe_header_info are valid */
        public const int RGBE_VALID_PROGRAMTYPE = 0x01;
        public const int RGBE_VALID_GAMMA = 0x02;
        public const int RGBE_VALID_EXPOSURE = 0x04;

        /* return codes for rgbe routines */
        public const int RGBE_RETURN_SUCCESS = 0;
        public const int RGBE_RETURN_FAILURE = -1;

        /* read or write headers */
        /* you may set rgbe_header_info to null if you want to */
        //int RGBE_WriteHeader(FILE* fp, int width, int height, rgbe_header_info* info);
        int RGBE_WriteHeader(FileStream fp, int width, int height, ref rgbe_header_info info) {
            throw new NotImplementedException();
        }
        int RGBE_ReadHeader(FileStream fp, out int width, out int height, ref rgbe_header_info info) {
            throw new NotImplementedException();

        }

        /* read or write pixels */
        /* can read or write pixels in chunks of any size including single pixels*/
        int RGBE_WritePixels(FileStream fp, out float[] data, int numpixels) {
            throw new NotImplementedException();

        }
        int RGBE_ReadPixels(FileStream fp, out float[] data, int numpixels) {
            throw new NotImplementedException();

        }

        /* read or write run length encoded files */
        /* must be called to read or write whole scanlines */
        int RGBE_WritePixels_RLE(FileStream fp, out float[] data, int scanline_width,
                     int num_scanlines) {
            throw new NotImplementedException();

        }
        int RGBE_ReadPixels_RLE(FileStream fp, out float[] data, int scanline_width,
                    int num_scanlines) {
            throw new NotImplementedException();

        }
    }
}
