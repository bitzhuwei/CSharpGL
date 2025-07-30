
using CSharpGL;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.DataFormats;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace demos.glGuide8code {

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct targa_header {
        //public byte idLength;
        //public byte colorMapType;
        //public byte imageType;
        //public struct _cmap_spec {
        //    char cmap_table_offset;
        //    char cmap_entry_count;
        //    byte cmap_entry_size;
        //}
        //public _cmap_spec cmap_spec;
        //public struct _image_spec {
        //    public char x_origin;
        //    public char y_origin;
        //    public char width;
        //    public char height;
        //    public byte bits_per_pixel;
        //    public byte alpha_depth;// = 4;
        //    public byte image_origin;// = 2;
        //    public byte xxx;// = 2;
        //}
        //public _image_spec image_spec;
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

        public bool is_compressed_targa() {
            return (this.ImageType & 0x08) != 0;
        }


        public bool get_targa_format_type_and_size(out GLenum format, out GLenum type, out int size) {
            // TODO: Support paletted TGA files. Note, L8 files are actually stored as
            // paletted bitmaps with a 256 entry grayscale palette.

            format = 0; type = 0; size = 0;
            if (this.ColorMapType != 0) { return false; }

            // By default...
            type = GL.GL_UNSIGNED_BYTE;

            switch (this.PixelDepth) {
            case 8:
            format = GL.GL_RED;
            size = 1;
            return true;
            case 16:
            switch (this.ImageDescriptor) {
            case 0:
            format = GL.GL_RG8;
            break;
            case 8:
            format = GL.GL_RG;
            break;
            default:
            return false;
            }
            size = 2;
            return true;
            case 24:
            switch (this.ImageDescriptor) {
            case 0:
            format = GL.GL_BGR;
            break;
            default:
            // Huh, 24 bits per pixel, non-0 alpha - Red-Green-Alpha?
            return false;
            }
            size = 3;
            return true;
            case 32:
            switch (this.ImageDescriptor) {
            case 8:
            format = 0x8000;// GL.GL_ABGR_EXT;
            break;
            default:
            // 32-bit image without alpha.
            return false;
            }
            size = 4;
            return true;
            default:
            return false;
            }
        }


        public static unsafe byte[] load_targa(string filename, out GLenum format, out int width, out int height) {
            format = 0; width = 0; height = 0;
            using (var reader = new FileStream(filename, FileMode.Open, FileAccess.Read)) {
                var headerSize = Marshal.SizeOf<targa_header>();
                if (reader.Length < headerSize) { return Array.Empty<byte>(); }
                //var span = MemoryMarshal.CreateSpan(ref header, 1);
                //var bytes = MemoryMarshal.AsBytes(span);
                var header = new targa_header();
                var span = new Span<byte>(&header, headerSize);
                reader.Read(span);
                // Note: same result
                //reader.Position = 0;
                //var bytes = new byte[headerSize];
                //reader.Read(bytes, 0, bytes.Length);
                //fixed (byte* ptr = bytes) {
                //    header = *((targa_header*)ptr);
                //}
                //fread(&header, sizeof(header), 1, f);

                width = header.Width; height = header.Height;

                GLenum type; int size;

                header.get_targa_format_type_and_size(out format, out type, out size);

                var data = new byte[width * height * size];

                if (header.is_compressed_targa()) {
                    // TODO: Handle compressed targa files
                    throw new NotImplementedException();
                }
                else {
                    //fread(data, width * height, size, f);
                    reader.Read(data);
                }

                //fclose(f);
                return data;
            }
        }
    }
}