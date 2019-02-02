using CSharpGL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace PhysicallyBasedRendering
{
    public unsafe class stb_image
    {
        public struct FixedArray<T> : IDisposable where T : struct
        {
            public readonly T[] array;
            //public IntPtr header;
            public int current;

            //private readonly IntPtr originalHeader;
            private GCHandle pin;

            public FixedArray(int elementCount)
            {
                var array = new T[elementCount];
                GCHandle pin = GCHandle.Alloc(array, GCHandleType.Pinned);
                //var header = pin.AddrOfPinnedObject();
                IntPtr header = Marshal.UnsafeAddrOfPinnedArrayElement(array, 0);

                this.array = array;
                //this.header = header;
                this.current = 0;
                //this.originalHeader = header;
                this.pin = pin;
            }

            #region IDisposable 成员

            /// <summary>
            /// dummy impl.
            /// </summary>
            public void Dispose()
            {
                this.pin.Free();
            }

            #endregion

            public override string ToString()
            {
                return string.Format("{0}[{1}]", typeof(T).Name, this.array.Length);
            }
        }

        delegate int delRead(object user, FixedArray<char> data, int size);
        delegate void delSkip(object user, int n);
        delegate int delEof(object user);
        class stbi_io_callbacks
        {
            //int      (*read)  (void *user,char *data,int size);   
            // fill 'data' with 'size' bytes.  return number of bytes actually read
            public delRead read;
            //void     (*skip)  (void *user,int n);                 
            // skip the next 'n' bytes, or 'unget' the last -n bytes if negative
            public delSkip skip;
            //int      (*eof)   (void *user);                       
            // returns nonzero if we are at end of file/data
            public delEof eof;

            public stbi_io_callbacks(delRead read, delSkip skip, delEof eof)
            {
                this.read = read; this.skip = skip; this.eof = eof;
            }
        }

        //  stbi__context struct and start_xxx functions

        // stbi__context structure is our basic context used by all images, so it
        // contains all the IO context, plus some basic image information
        class stbi__context
        {
            public UInt32 img_x, img_y;
            public int img_n, img_out_n;

            public stbi_io_callbacks io;
            public object io_user_data;

            public bool read_from_callbacks;
            public int buflen;
            //public char* buffer_start = Marshal.AllocHGlobal(sizeof(char) * 128);// new char[128];
            public FixedArray<char> buffer_start = new FixedArray<char>(128);

            public FixedArray<char> img_buffer, img_buffer_end;
            public FixedArray<char> img_buffer_original, img_buffer_original_end;

        }

        public static float[] stbi_loadf(string filename, out int x, out  int y, out int comp, int req_comp)
        {
            float[] result;
            //FILE* f = stbi__fopen(filename, "rb");
            //if (!f) return stbi__errpf("can't fopen", "Unable to open file");
            //result = stbi_loadf_from_file(f, x, y, comp, req_comp);
            //fclose(f);
            using (var f = new StreamReader(filename))
            {
                result = stbi_loadf_from_file(f, out x, out y, out comp, req_comp);
            }
            return result;
        }

        private static float[] stbi_loadf_from_file(StreamReader f, out int x, out int y, out int comp, int req_comp)
        {
            var s = new stbi__context();
            stbi__start_file(s, f);
            return stbi__loadf_main(s, out x, out y, out comp, req_comp);
        }

        class stbi__result_info
        {
            public int bits_per_channel;
            public int num_channels;
            public int channel_order;
        }

        private static float[] stbi__loadf_main(stbi__context s, out int x, out int y, out int comp, int req_comp)
        {
            char[] data;
            ////#ifndef STBI_NO_HDR
            //if (stbi__hdr_test(s))
            //{
            //    stbi__result_info ri;
            //    float* hdr_data = stbi__hdr_load(s, x, y, comp, req_comp, &ri);
            //    if (hdr_data)
            //        stbi__float_postprocess(hdr_data, x, y, comp, req_comp);
            //    return hdr_data;
            //}
            ////#endif
            //data = stbi__load_and_postprocess_8bit(s, x, y, comp, req_comp);
            //if (data)
            //    return stbi__ldr_to_hdr(data, *x, *y, req_comp ? req_comp : *comp);
            //return stbi__errpf("unknown image type", "Image not of any known type, or corrupt");
            //throw new NotImplementedException();
            if (stbi__hdr_test(s))
            {
                var ri = new stbi__result_info();
                float[] hdr_data = stbi__hdr_load(s, x, y, comp, req_comp, ri);
                if (hdr_data)
                    stbi__float_postprocess(hdr_data, x, y, comp, req_comp);
                return hdr_data;
            }
            //#endif
            data = stbi__load_and_postprocess_8bit(s, x, y, comp, req_comp);
            return stbi__ldr_to_hdr(data, x, y, (req_comp ? req_comp : comp));
        }

        private const int STBI__HDR_BUFLEN = 1024;
        private static float[] stbi__hdr_load(stbi__context s, int x, int y, int comp, int req_comp, stbi__result_info ri)
        {
            var buffer = new char[STBI__HDR_BUFLEN];
            char[] token;
            int valid = 0;
            int width, height;
            char[] scanline;
            float[] hdr_data;
            int len;
            char count, value;
            int i, j, k, c1, c2, z;
            char[] headerToken;
            //STBI_NOTUSED(ri);

            // Check identifier
            headerToken = stbi__hdr_gettoken(s, buffer);
            //if (strcmp(headerToken, "#?RADIANCE") != 0 && strcmp(headerToken, "#?RGBE") != 0)
            //return stbi__errpf("not HDR", "Corrupt HDR image");

            // Parse header
            for (; ; )
            {
                token = stbi__hdr_gettoken(s, buffer);
                if (token[0] == 0) break;
                if (strcmp(token, "FORMAT=32-bit_rle_rgbe") == 0) valid = 1;
            }

            // Parse width and height
            // can't use sscanf() if we're not using stdio!
            token = stbi__hdr_gettoken(s, buffer);
            if (strncmp(token, "-Y ", 3)) return stbi__errpf("unsupported data layout", "Unsupported HDR format");
            token += 3;
            height = (int)strtol(token, &token, 10);
            while (*token == ' ') ++token;
            if (strncmp(token, "+X ", 3)) return stbi__errpf("unsupported data layout", "Unsupported HDR format");
            token += 3;
            width = (int)strtol(token, NULL, 10);

            *x = width;
            *y = height;

            if (comp) *comp = 3;
            if (req_comp == 0) req_comp = 3;

            if (!stbi__mad4sizes_valid(width, height, req_comp, sizeof(float), 0))
                return stbi__errpf("too large", "HDR image is too large");

            // Read data
            hdr_data = (float*)stbi__malloc_mad4(width, height, req_comp, sizeof(float), 0);
            if (!hdr_data)
                return stbi__errpf("outofmem", "Out of memory");

            // Load image data
            // image data is stored as some number of sca
            // Read RLE-encoded data
            scanline = NULL;

            for (j = 0; j < height; ++j)
            {
                c1 = stbi__get8(s);
                c2 = stbi__get8(s);
                len = stbi__get8(s);
                if (c1 != 2 || c2 != 2 || (len & 0x80))
                {
                    // not run-length encoded, so we have to actually use THIS data as a decoded
                    // pixel (note this can't be a valid pixel--one of RGB must be >= 128)
                    var rgbe = new char[4];
                    rgbe[0] = (char)c1;
                    rgbe[1] = (char)c2;
                    rgbe[2] = (char)len;
                    rgbe[3] = (char)stbi__get8(s);
                    stbi__hdr_convert(hdr_data, rgbe, req_comp);
                    i = 1;
                    j = 0;
                    STBI_FREE(scanline);
                    goto main_decode_loop; // yes, this makes no sense
                }
                len <<= 8;
                len |= stbi__get8(s);
                if (len != width) { STBI_FREE(hdr_data); STBI_FREE(scanline); return stbi__errpf("invalid decoded scanline length", "corrupt HDR"); }
                if (scanline == NULL)
                {
                    scanline = (char*)stbi__malloc_mad2(width, 4, 0);
                    if (!scanline)
                    {
                        STBI_FREE(hdr_data);
                        return stbi__errpf("outofmem", "Out of memory");
                    }
                }

                for (k = 0; k < 4; ++k)
                {
                    int nleft;
                    i = 0;
                    while ((nleft = width - i) > 0)
                    {
                        count = stbi__get8(s);
                        if (count > 128)
                        {
                            // Run
                            value = stbi__get8(s);
                            count -= 128;
                            if (count > nleft) { STBI_FREE(hdr_data); STBI_FREE(scanline); return stbi__errpf("corrupt", "bad RLE data in HDR"); }
                            for (z = 0; z < count; ++z)
                                scanline[i++ * 4 + k] = value;
                        }
                        else
                        {
                            // Dump
                            if (count > nleft) { STBI_FREE(hdr_data); STBI_FREE(scanline); return stbi__errpf("corrupt", "bad RLE data in HDR"); }
                            for (z = 0; z < count; ++z)
                                scanline[i++ * 4 + k] = stbi__get8(s);
                        }
                    }
                }
                for (i = 0; i < width; ++i)
                    stbi__hdr_convert(hdr_data + (j * width + i) * req_comp, scanline + i * 4, req_comp);
            }
            if (scanline)
                STBI_FREE(scanline);

            return hdr_data;
        }

        private static bool stbi__hdr_test(stbi__context s)
        {
            bool r = stbi__hdr_test_core(s, "#?RADIANCE\n");
            stbi__rewind(s);
            if (!r)
            {
                r = stbi__hdr_test_core(s, "#?RGBE\n");
                stbi__rewind(s);
            }
            return r;
        }

        private static bool stbi__hdr_test_core(stbi__context s, string signature)
        {
            for (int i = 0; i < signature.Length; ++i)
            {
                if (stbi__get8(s) != signature[i])
                {
                    return false;
                }
            }
            stbi__rewind(s);
            return true;
        }

        private static void stbi__rewind(stbi__context s)
        {
            //// conceptually rewind SHOULD rewind to the beginning of the stream,
            //// but we just rewind to the beginning of the initial buffer, because
            //// we only use it after doing 'test', which only ever looks at at most 92 bytes
            //s->img_buffer = s->img_buffer_original;
            //s->img_buffer_end = s->img_buffer_original_end;
            //throw new NotImplementedException();
            s.img_buffer = s.img_buffer_original;
            s.img_buffer_end = s.img_buffer_original_end;
        }

        private static char stbi__get8(stbi__context s)
        {
            //if (s->img_buffer < s->img_buffer_end)
            //    return *s->img_buffer++;
            //if (s->read_from_callbacks)
            //{
            //    stbi__refill_buffer(s);
            //    return *s->img_buffer++;
            //}
            //return 0;
            //throw new NotImplementedException();
            char result = '\0';
            if (s.img_buffer.current < s.img_buffer_end.current)
            {
                result = s.img_buffer.array[s.img_buffer.current];
                s.img_buffer.current++;
            }
            else
            {
                stbi__refill_buffer(s);
                result = s.img_buffer.array[s.img_buffer.current];
                s.img_buffer.current++;
            }

            return result;
        }

        static int stbi__stdio_read(object user, FixedArray<char> data, int size)
        {
            //return (int)fread(data, 1, size, (void*)user);
            var sr = (StreamReader)user;
            int result = sr.Read(data.array, 1, size);
            return result;
        }
        static void stbi__stdio_skip(object user, int n)
        {
            //fseek((FILE*)user, n, SEEK_CUR);
            var sr = (StreamReader)user;
            sr.BaseStream.Seek(n, SeekOrigin.Current);
        }

        static int stbi__stdio_eof(object user)
        {
            //return feof((FILE*)user);
            var sr = (StreamReader)user;
            return sr.EndOfStream ? 1 : 0;
        }

        static stbi_io_callbacks stbi__stdio_callbacks = new stbi_io_callbacks(
            stbi__stdio_read, stbi__stdio_skip, stbi__stdio_eof);

        private static void stbi__start_file(stbi__context s, StreamReader f)
        {
            //stbi__start_callbacks(s, &stbi__stdio_callbacks, (void*)f);
            stbi__start_callbacks(s, stbi__stdio_callbacks, f);
        }

        private static void stbi__start_callbacks(stbi__context s, stbi_io_callbacks c, object user)
        {
            //            s->io = *c;
            //s->io_user_data = user;
            //s->buflen = sizeof(s->buffer_start);
            //s->read_from_callbacks = 1;
            //s->img_buffer_original = s->buffer_start;
            //stbi__refill_buffer(s);
            //s->img_buffer_original_end = s->img_buffer_end;
            s.io = c;
            s.io_user_data = user;
            s.buflen = s.buffer_start.array.Length;
            s.read_from_callbacks = true;
            s.img_buffer_original = s.buffer_start;
            stbi__refill_buffer(s);
            s.img_buffer_original_end = s.img_buffer_end;
        }

        private static void stbi__refill_buffer(stbi__context s)
        {
            //int n = (s->io.read)(s->io_user_data, (char*)s->buffer_start, s->buflen);
            //if (n == 0)
            //{
            //    // at end of file, treat same as if from memory, but need to handle case
            //    // where s->img_buffer isn't pointing to safe memory, e.g. 0-byte file
            //    s->read_from_callbacks = 0;
            //    s->img_buffer = s->buffer_start;
            //    s->img_buffer_end = s->buffer_start + 1;
            //    *s->img_buffer = 0;
            //}
            //else
            //{
            //    s->img_buffer = s->buffer_start;
            //    s->img_buffer_end = s->buffer_start + n;
            //}
            //throw new NotImplementedException();
            int n = (s.io.read(s.io_user_data, s.buffer_start, s.buflen));
            if (n == 0)
            {
                // at end of file, treat same as if from memory, but need to handle case
                // where s->img_buffer isn't pointing to safe memory, e.g. 0-byte file
                s.read_from_callbacks = false;
                s.img_buffer = s.buffer_start;
                s.img_buffer_end.current = s.buffer_start.current + 1;
                s.img_buffer.array[0] = '\0'; // '\0': end of string.
            }
            else
            {
                s.img_buffer = s.buffer_start;
                s.img_buffer_end.current = s.buffer_start.current + n;
            }
        }
    }
}
