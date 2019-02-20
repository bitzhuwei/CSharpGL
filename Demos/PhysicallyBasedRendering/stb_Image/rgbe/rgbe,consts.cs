using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace stb_Image {
    public static partial class rgbe {

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

    }
}
