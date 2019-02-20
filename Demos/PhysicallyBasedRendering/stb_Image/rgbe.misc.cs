using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace stb_Image {
    public static partial class rgbe {

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
