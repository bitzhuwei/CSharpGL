
using CSharpGL;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Xml.Linq;
using static CSharpGL.GLProgram;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace demos.glSuperBible7code {
    public unsafe partial class Utility {
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct targa_header {
            public byte IdLength;           // 0
            public byte ColorMapType;       // 1
            public byte ImageType;          // 2
            public ushort ColorMapOrigin;   // 3
            public ushort ColorMapLength;   // 5
            public byte ColorMapDepth;      // 7
            public short XOrigin;           // 8
            public short YOrigin;           // 10
            public ushort Width;            // 12
            public ushort Height;           // 14
            public byte PixelDepth;         // 16
            public byte ImageDescriptor;    // 17
        }

        public static void make_screenshot(int width, int height, GL gl) {
            int row_size = ((width * 3 + 3) & ~3);
            int data_size = row_size * height;
            var data = new byte[data_size];

            fixed (byte* p = data) {
                gl.glReadPixels(0, 0,// Origin
                    width, height,   // Size
                    GL.GL_BGR, GL.GL_UNSIGNED_BYTE,// Format, type
                    (IntPtr)p);      // Data
            }

            var header = new targa_header();
            header.ImageType = 2;
            header.Width = (ushort)width;
            header.Height = (ushort)height;
            header.PixelDepth = 24;

            var time = string.Format("{0:yyyyMMdd_HHmmss.fff}", DateTime.Now);
            using (var writer = new FileStream($"screenShot{time}.tga", FileMode.Create, FileAccess.Write)) {
                var headerSize = Marshal.SizeOf<targa_header>();
                //var span = MemoryMarshal.CreateSpan(ref header, 1);
                //var bytes = MemoryMarshal.AsBytes(span);
                var span = new Span<byte>(&header, headerSize);
                writer.Write(span);
                writer.Write(data);
            }
        }
    }
}

