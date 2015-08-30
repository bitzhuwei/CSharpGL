using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Picture.DDS
{
    public partial class vgl
    {
        void vglUnloadImage(ref vglImageData image)
        {
            Marshal.FreeHGlobal(image.mip[0].data);
        }
    }
}
