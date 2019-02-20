using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace CSharpGL {
    public static partial class rgbe {
        /* read or write headers */
        /* you may set rgbe_header_info to null if you want to */
        //int RGBE_WriteHeader(FILE* fp, int width, int height, rgbe_header_info* info);
        public static int RGBE_WriteHeader(StreamWriter fp, int width, int height, ref rgbe_header_info info) {
            string programtype = "RGBE";

            if ((info.valid & RGBE_VALID_PROGRAMTYPE) != 0)
                programtype = info.programtype;

            fp.Write(string.Format("#?{0}{1}", programtype, Environment.NewLine));
            /* The #? is to identify file type, the programtype is optional. */

            if ((info.valid & RGBE_VALID_GAMMA) != 0) {
                fp.Write(string.Format("GAMMA={0}{1}", info.gamma, Environment.NewLine));
            }

            if ((info.valid & RGBE_VALID_EXPOSURE) != 0) {
                fp.Write(string.Format("EXPOSURE={0}{1}", info.exposure, Environment.NewLine));
            }

            fp.Write(string.Format("FORMAT=32-bit_rle_rgbe{0}{0}", Environment.NewLine));
            fp.Write(string.Format("-Y {0} +X {1}{2}", height, width, Environment.NewLine));

            return RGBE_RETURN_SUCCESS;
        }
    }
}
