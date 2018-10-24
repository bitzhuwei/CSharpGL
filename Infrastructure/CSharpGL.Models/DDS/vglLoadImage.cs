using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace CSharpGL
{
    public partial class vgl
    {
        public static void vglLoadImage(string filename, ref vglImageData image)
        {
            vglLoadDDS(filename, ref image);
        }
    }
}
