using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL.Objects.Texts.FreeTypes
{
    [StructLayout(LayoutKind.Sequential)]
    public class FT_Library
    {
        public System.IntPtr memory;
        public Generic generic;
        public int major;
        public int minor;
        public int patch;
        public uint modules;
        public System.IntPtr module0, module1, module2, module3, module4, module5, module6, module7, module8, module9, module10;
        public System.IntPtr module11, module12, module13, module14, module15, module16, module17, module18, module19, module20;
        public System.IntPtr module21, module22, module23, module24, module25, module26, module27, module28, module29, module30;
        public System.IntPtr module31;
        public ListRec renderers;
        public System.IntPtr renderer;
        public System.IntPtr auto_hinter;
        public System.IntPtr raster_pool;
        public long raster_pool_size;
        public System.IntPtr debug0, debug1, debug2, debug3;
        public int refCount;

        public override string ToString()
        {
            return string.Format("major: {0}, minor: {1}, refCount: {2}", major, minor, refCount);
        }
    }

}
