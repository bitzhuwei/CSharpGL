using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace PhysicallyBasedRendering
{
    public class stb_image
    {
        delegate int delRead(object user, char[] data, int size);
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

            public int read_from_callbacks;
            public int buflen;
            public char[] buffer_start = new char[128];

            public char[] img_buffer, img_buffer_end;
            public char[] img_buffer_original, img_buffer_original_end;
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
                stbi__result_info ri;
                float* hdr_data = stbi__hdr_load(s, x, y, comp, req_comp, &ri);
                if (hdr_data)
                    stbi__float_postprocess(hdr_data, x, y, comp, req_comp);
                return hdr_data;
            }
            //#endif
            data = stbi__load_and_postprocess_8bit(s, x, y, comp, req_comp);
            return stbi__ldr_to_hdr(data, *x, *y, req_comp ? req_comp : *comp);
        }

        static int stbi__stdio_read(object user, char[] data, int size)
        {
            //return (int)fread(data, 1, size, (void*)user);
            var sr = (StreamReader)user;
            int result = sr.Read(data, 1, size);
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
            s.buflen = s.buffer_start.Length;
            s.read_from_callbacks = 1;
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
                s.read_from_callbacks = 0;
                s.img_buffer = s.buffer_start;
                s.img_buffer_end = s.buffer_start + 1;
                s.img_buffer[0] = 0; // '\0': end of string.
            }
            else
            {
                s.img_buffer = s.buffer_start;
                s.img_buffer_end = s.buffer_start + n;
            }
        }
    }
}
