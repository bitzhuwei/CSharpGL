using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace stb_Image {
    public static partial class rgbe {

        /* standard conversion from rgbe to float pixels */
        /* note: Ward uses ldexp(col+0.5,exp-(128+8)).  However we wanted pixels */
        /*       in the range [0,1] to map back into the range [0,1].            */
        public static void rgbe2float(out float red, out float green, out float blue, char[] _rgbe) {
            float f;

            if (_rgbe[3] != 0) {   /*nonzero pixel*/
                f = (float)ldexp(1.0, _rgbe[3] - (int)(128 + 8));
                red = _rgbe[0] * f;
                green = _rgbe[1] * f;
                blue = _rgbe[2] * f;
            }
            else
                red = green = blue = 0.0f;
        }

        private static double ldexp(double x, int exponent) {
            return x * Math.Pow(2, exponent);
        }

    }
}
