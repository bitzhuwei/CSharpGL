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

    public enum rgbe_error_codes {
        rgbe_read_error,
        rgbe_write_error,
        rgbe_format_error,
        rgbe_memory_error,
    }

    public static class rgbe {

        /* flags indicating which fields in an rgbe_header_info are valid */
        public const int RGBE_VALID_PROGRAMTYPE = 0x01;
        public const int RGBE_VALID_GAMMA = 0x02;
        public const int RGBE_VALID_EXPOSURE = 0x04;

        /* return codes for rgbe routines */
        public const int RGBE_RETURN_SUCCESS = 0;
        public const int RGBE_RETURN_FAILURE = -1;

        /* offsets to red, green, and blue components in a data (float) pixel */
        public const int RGBE_DATA_RED = 0;
        public const int RGBE_DATA_GREEN = 1;
        public const int RGBE_DATA_BLUE = 2;
        /* number of floats per pixel */
        public const int RGBE_DATA_SIZE = 3;


        /* default error routine.  change this to change error handling */
        public static int rgbe_error(rgbe_error_codes rgbe_error_code, string msg) {
            switch (rgbe_error_code) {
                case rgbe_error_codes.rgbe_read_error:
                    Console.WriteLine("RGBE read error");
                    break;
                case rgbe_error_codes.rgbe_write_error:
                    Console.WriteLine("RGBE write error");
                    break;
                case rgbe_error_codes.rgbe_format_error:
                    Console.WriteLine("RGBE bad file format: %s\n", msg);
                    break;
                case rgbe_error_codes.rgbe_memory_error:
                    Console.WriteLine("RGBE error: %s\n", msg);
                    break;
                default:
                    Console.WriteLine("RGBE error: %s\n", msg);
                    break;
            }
            return RGBE_RETURN_FAILURE;
        }


        /* read or write headers */
        /* you may set rgbe_header_info to null if you want to */
        //int RGBE_WriteHeader(FILE* fp, int width, int height, rgbe_header_info* info);
        public static int RGBE_WriteHeader(FileStream fp, int width, int height, ref rgbe_header_info info) {
            throw new NotImplementedException();
        }
        public static int RGBE_ReadHeader(FileStream fp, out int width, out int height, ref rgbe_header_info info) {
            throw new NotImplementedException();

        }

        /* read or write pixels */
        /* can read or write pixels in chunks of any size including single pixels*/
        public static int RGBE_WritePixels(FileStream fp, out float[] data, int numpixels) {
            throw new NotImplementedException();

        }
        public static int RGBE_ReadPixels(FileStream fp, out float[] data, int numpixels) {
            throw new NotImplementedException();

        }

        /* read or write run length encoded files */
        /* must be called to read or write whole scanlines */
        public static int RGBE_WritePixels_RLE(FileStream fp, out float[] data, int scanline_width,
                     int num_scanlines) {
            throw new NotImplementedException();

        }
        public static int RGBE_ReadPixels_RLE(FileStream fp, out float[] data, int scanline_width,
                    int num_scanlines) {
            throw new NotImplementedException();

        }
    }
}
