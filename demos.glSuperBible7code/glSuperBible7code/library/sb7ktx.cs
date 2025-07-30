using CSharpGL;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace demos.glSuperBible7code {
    public unsafe class sb7ktx {

        public struct header {
            public fixed byte identifier[12];
            public uint endianness;
            public uint gltype;
            public uint gltypesize;
            public uint glformat;
            public uint glinternalformat;
            public uint glbaseinternalformat;
            public uint pixelwidth;
            public uint pixelheight;
            public uint pixeldepth;
            public uint arrayelements;
            public uint faces;
            public uint miplevels;
            public uint keypairbytes;
        }
        static readonly byte[] identifier = { 0xAB, 0x4B, 0x54, 0x58, 0x20, 0x31, 0x31, 0xBB, 0x0D, 0x0A, 0x1A, 0x0A };
        /// <summary>
        /// load a ktx file and return a texture id
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="gl"></param>
        /// <returns></returns>
        public static uint load(string filename) {
            var gl = GL.Current; Debug.Assert(gl != null);
            GLuint retval = 0;
            header h = new header();
            //size_t data_start, data_end;
            //byte* data;
            GLenum target = GL.GL_NONE;

            using (var reader = new FileStream(filename, FileMode.Open, FileAccess.Read)) {
                var headerSize = sizeof(header);
                var span = new Span<byte>(&h, headerSize);
                var read = reader.Read(span);
                if (read != headerSize) { goto fail_read; }
                for (int i = 0; i < identifier.Length; i++) {
                    if (h.identifier[i] != identifier[i]) { goto fail_header; }
                }
                if (h.endianness == 0x04030201) {
                    // No swap needed
                }
                else if (h.endianness == 0x01020304) {
                    // Swap needed
                    h.endianness = swap32(h.endianness);
                    h.gltype = swap32(h.gltype);
                    h.gltypesize = swap32(h.gltypesize);
                    h.glformat = swap32(h.glformat);
                    h.glinternalformat = swap32(h.glinternalformat);
                    h.glbaseinternalformat = swap32(h.glbaseinternalformat);
                    h.pixelwidth = swap32(h.pixelwidth);
                    h.pixelheight = swap32(h.pixelheight);
                    h.pixeldepth = swap32(h.pixeldepth);
                    h.arrayelements = swap32(h.arrayelements);
                    h.faces = swap32(h.faces);
                    h.miplevels = swap32(h.miplevels);
                    h.keypairbytes = swap32(h.keypairbytes);
                }
                else {
                    goto fail_header;
                }

                // Guess target (texture type)
                if (h.pixelheight == 0) {
                    if (h.arrayelements == 0) { target = GL.GL_TEXTURE_1D; }
                    else { target = GL.GL_TEXTURE_1D_ARRAY; }
                }
                else if (h.pixeldepth == 0) {
                    if (h.arrayelements == 0) {
                        if (h.faces == 0) { target = GL.GL_TEXTURE_2D; }
                        else { target = GL.GL_TEXTURE_CUBE_MAP; }
                    }
                    else {
                        if (h.faces == 0) { target = GL.GL_TEXTURE_2D_ARRAY; }
                        else { target = GL.GL_TEXTURE_CUBE_MAP_ARRAY; }
                    }
                }
                else { target = GL.GL_TEXTURE_3D; }

                // Check for insanity...
                if ((target == GL.GL_NONE) ||                  // Couldn't figure out target
                    (h.pixelwidth == 0) ||                     // Texture has no width???
                    (h.pixelheight == 0 && h.pixeldepth != 0)) // Texture has depth but no height???
                { goto fail_header; }

                var id = stackalloc GLuint[1];
                gl.glGenTextures(1, id); var tex = id[0];
                gl.glBindTexture(target, tex);

                var data_start = reader.Position + h.keypairbytes;
                var data_end = reader.Length;
                reader.Position = data_start;

                var data = new byte[data_end - data_start];
                reader.Read(data, 0, data.Length);

                if (h.miplevels == 0) { h.miplevels = 1; }

                switch (target) {
                case GL.GL_TEXTURE_1D:
                gl.glTexStorage1D(GL.GL_TEXTURE_1D, (int)h.miplevels, h.glinternalformat, (int)h.pixelwidth);
                fixed (byte* p = data) {
                    gl.glTexSubImage1D(GL.GL_TEXTURE_1D, 0, 0, (int)h.pixelwidth, h.glformat, h.glinternalformat, (IntPtr)p);
                }
                break;
                case GL.GL_TEXTURE_2D:
                // glTexImage2D(GL.GL_TEXTURE_2D, 0, h.glinternalformat, h.pixelwidth, h.pixelheight, 0, h.glformat, h.gltype, data);
                if (h.gltype == GL.GL_NONE) {
                    fixed (byte* p = data) {
                        gl.glCompressedTexImage2D(GL.GL_TEXTURE_2D, 0, h.glinternalformat,
                            (int)h.pixelwidth, (int)h.pixelheight, 0, 420 * 380 / 2, (IntPtr)p);
                    }
                }
                else {
                    gl.glTexStorage2D(GL.GL_TEXTURE_2D, (int)h.miplevels, h.glinternalformat, (int)h.pixelwidth, (int)h.pixelheight);
                    fixed (byte* ptr = data) {
                        var p = ptr;
                        var height = h.pixelheight; var width = h.pixelwidth;
                        gl.glPixelStorei(GL.GL_UNPACK_ALIGNMENT, 1);
                        for (int i = 0; i < h.miplevels; i++) {
                            gl.glTexSubImage2D(GL.GL_TEXTURE_2D, i, 0, 0, (int)width, (int)height, h.glformat, h.gltype, (IntPtr)p);
                            p += height * calculate_stride(&h, width, 1);
                            height >>= 1; width >>= 1;
                            if (height == 0) { height = 1; }
                            if (width == 0) { width = 1; }
                        }
                    }
                }
                break;
                case GL.GL_TEXTURE_3D:
                gl.glTexStorage3D(GL.GL_TEXTURE_3D, (int)h.miplevels, h.glinternalformat, (int)h.pixelwidth, (int)h.pixelheight, (int)h.pixeldepth);
                fixed (byte* p = data) {
                    gl.glTexSubImage3D(GL.GL_TEXTURE_3D, 0, 0, 0, 0, (int)h.pixelwidth, (int)h.pixelheight, (int)h.pixeldepth, h.glformat, h.gltype, (IntPtr)p);
                }
                break;
                case GL.GL_TEXTURE_1D_ARRAY:
                gl.glTexStorage2D(GL.GL_TEXTURE_1D_ARRAY, (int)h.miplevels, h.glinternalformat, (int)h.pixelwidth, (int)h.arrayelements);
                fixed (byte* p = data) {
                    gl.glTexSubImage2D(GL.GL_TEXTURE_1D_ARRAY, 0, 0, 0, (int)h.pixelwidth, (int)h.arrayelements, h.glformat, h.gltype, (IntPtr)p);
                }
                break;
                case GL.GL_TEXTURE_2D_ARRAY:
                gl.glTexStorage3D(GL.GL_TEXTURE_2D_ARRAY, (int)h.miplevels, h.glinternalformat, (int)h.pixelwidth, (int)h.pixelheight, (int)h.arrayelements);
                fixed (byte* p = data) {
                    gl.glTexSubImage3D(GL.GL_TEXTURE_2D_ARRAY, 0, 0, 0, 0,
                        (int)h.pixelwidth, (int)h.pixelheight, (int)h.arrayelements, h.glformat, h.gltype, (IntPtr)p);
                }
                break;
                case GL.GL_TEXTURE_CUBE_MAP:
                gl.glTexStorage2D(GL.GL_TEXTURE_CUBE_MAP, (int)h.miplevels, h.glinternalformat, (int)h.pixelwidth, (int)h.pixelheight);
                // glTexSubImage3D(GL.GL_TEXTURE_CUBE_MAP, 0, 0, 0, 0, h.pixelwidth, h.pixelheight, h.faces, h.glformat, h.gltype, data);
                uint face_size = calculate_face_size(&h);
                fixed (byte* p = data) {
                    var ptr = p;
                    for (uint i = 0; i < h.faces; i++) {
                        gl.glTexSubImage2D(GL.GL_TEXTURE_CUBE_MAP_POSITIVE_X + i, 0, 0, 0,
                            (int)h.pixelwidth, (int)h.pixelheight, h.glformat, h.gltype, (IntPtr)ptr);
                        ptr += face_size;
                    }
                }
                break;
                case GL.GL_TEXTURE_CUBE_MAP_ARRAY:
                gl.glTexStorage3D(GL.GL_TEXTURE_CUBE_MAP_ARRAY, (int)h.miplevels, h.glinternalformat, (int)h.pixelwidth, (int)h.pixelheight, (int)h.arrayelements);
                fixed (byte* p = data) {
                    gl.glTexSubImage3D(GL.GL_TEXTURE_CUBE_MAP_ARRAY, 0, 0, 0, 0, (int)h.pixelwidth, (int)h.pixelheight, (int)(h.faces * h.arrayelements), h.glformat, h.gltype, (IntPtr)p);
                }
                break;
                default:                                               // Should never happen
                goto fail_target;
                }

                if (h.miplevels == 1) {
                    gl.glGenerateMipmap(target);
                }

                retval = tex;

            fail_target:;
            fail_header:;
            fail_read:;
            }

            return retval;
        }
        [StructLayout(LayoutKind.Explicit)]
        struct union1 {
            [FieldOffset(0)]
            public uint u32;
            [FieldOffset(0)]
            public fixed byte u8[4];
        }
        static uint swap32(uint u32) {
            var a = new union1();
            var b = new union1();
            a.u32 = u32;
            b.u8[0] = a.u8[3];
            b.u8[1] = a.u8[2];
            b.u8[2] = a.u8[1];
            b.u8[3] = a.u8[0];

            return b.u32;
        }
        [StructLayout(LayoutKind.Explicit)]
        struct union2 {
            [FieldOffset(0)]
            public ushort u16;
            [FieldOffset(0)]
            public fixed byte u8[2];
        }
        static ushort swap16(ushort u16) {
            var a = new union2();
            var b = new union2();

            a.u16 = u16;
            b.u8[0] = a.u8[1];
            b.u8[1] = a.u8[0];

            return b.u16;
        }

        static uint calculate_stride(header* h, uint width, uint pad = 4) {
            uint channels = 0;

            switch (h->glbaseinternalformat) {
            case GL.GL_RED:
            channels = 1;
            break;
            case GL.GL_RG:
            channels = 2;
            break;
            case GL.GL_BGR:
            case GL.GL_RGB:
            channels = 3;
            break;
            case GL.GL_BGRA:
            case GL.GL_RGBA:
            channels = 4;
            break;
            }

            uint stride = h->gltypesize * channels * width;

            stride = (stride + (pad - 1)) & ~(pad - 1);

            return stride;
        }

        static uint calculate_face_size(header* h) {
            uint stride = calculate_stride(h, h->pixelwidth);

            return stride * h->pixelheight;
        }

    }
}