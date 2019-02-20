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
        public static int RGBE_ReadHeader(StreamReader fp, out int width, out int height, ref rgbe_header_info info) {
            width = 0; height = 0;
            info.valid = 0; info.programtype = string.Empty;
            info.gamma = 1.0f; info.exposure = 1.0f;

            string line = fp.ReadLine();
            if (!line.StartsWith("#?")) {
                return rgbe_error(rgbe_error_codes.rgbe_format_error, "bad initial token");
            }
            else {
                info.valid |= RGBE_VALID_PROGRAMTYPE;
                info.programtype = line.Substring(2);
            }
            while (true) {
                line = fp.ReadLine();
                if (string.IsNullOrEmpty(line)) {
                    return rgbe_error(rgbe_error_codes.rgbe_format_error, "no FORMAT specifier found");
                }
                else if (line == "FORMAT=32-bit_rle_rgbe\n") {
                    break;
                }
                else if (line.StartsWith("GAMMA=")) {
                    string[] parts = line.Split('=');
                    float gamma = float.Parse(parts[1]);
                    info.gamma = gamma; info.valid |= RGBE_VALID_GAMMA;
                }
                else if (line.StartsWith("EXPOSURE=")) {
                    string[] parts = line.Split('=');
                    float exposure = float.Parse(parts[1]);
                    info.exposure = exposure; info.valid |= RGBE_VALID_EXPOSURE;
                }
            }
            line = fp.ReadLine();
            if (string.IsNullOrEmpty(line)) {
                return rgbe_error(rgbe_error_codes.rgbe_format_error, "missing blank line after FORMAT specifier");
            }

            {
                line = fp.ReadLine();
                string[] parts = line.Split(' ');
                if (parts.Length != 4) {
                    return rgbe_error(rgbe_error_codes.rgbe_format_error, "missing image size specifier");
                }
                height = int.Parse(parts[1]);
                width = int.Parse(parts[3]);
            }

            return RGBE_RETURN_SUCCESS;
        }

    }
}
