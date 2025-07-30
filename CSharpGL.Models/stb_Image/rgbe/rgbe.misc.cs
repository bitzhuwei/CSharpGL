using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace CSharpGL {
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

    }
}
