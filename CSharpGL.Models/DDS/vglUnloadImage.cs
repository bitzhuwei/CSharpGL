﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;


namespace CSharpGL {
    public partial class vgl {
        public static void vglUnloadImage(ref vglImageData image) {
            Marshal.FreeHGlobal(image.mip[0].data);
        }
    }
}
