using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace CSharpGL {
    public static unsafe partial class stb_Image {

        public static char* stbi_load(string filename, int* x, int* y, int* comp, int req_comp) {
            char* result;

            using (var sr = new StreamReader(filename)) {
                result = stbi_load_from_file(sr, x, y, comp, req_comp);
            }

            return result;
        }

        public static char* stbi_load_from_file(StreamReader f, int* x, int* y, int* comp, int req_comp) {
            char* result;
            stbi__context s = new stbi__context();
            stbi__start_file(s, f);
            result = stbi__load_and_postprocess_8bit(s, x, y, comp, req_comp);
            //if (result[0] != '\0') {
            //    // need to 'unget' all the characters in the IO buffer
            //    fseek(f, -(int)(s.img_buffer_end - s.img_buffer), SEEK_CUR);

            //}
            return result;
        }

        private static unsafe char* stbi__load_and_postprocess_8bit(stbi__context s, int* x, int* y, int* comp, int req_comp) {
            stbi__result_info ri;
            void* result = stbi__load_main(ref s, x, y, comp, req_comp, &ri, 8);

            if (result == null) { return null; }

            if (ri.bits_per_channel != 8) {
                //STBI_ASSERT(ri.bits_per_channel == 16);
                result = stbi__convert_16_to_8((UInt16*)result, *x, *y, req_comp == 0 ? *comp : req_comp);
                ri.bits_per_channel = 8;
            }

            // @TODO: move stbi__convert_format to here
            if (stbi__vertically_flip_on_load) {
                int channels = req_comp != 0 ? req_comp : *comp;
                stbi__vertical_flip(result, *x, *y, channels * sizeof(char));
            }

            return (char*)result;
        }

        private static unsafe void stbi__vertical_flip(void* image, int w, int h, int bytes_per_pixel) {
            int row;
            int bytes_per_row = w * bytes_per_pixel;
            char[] temp = new char[2048];
            char* bytes = (char*)image;

            for (row = 0; row < (h >> 1); row++) {
                char* row0 = bytes + row * bytes_per_row;
                char* row1 = bytes + (h - row - 1) * bytes_per_row;
                // swap row0 with row1
                int bytes_left = bytes_per_row;
                while (bytes_left != 0) {
                    int bytes_copy = (bytes_left < temp.Length) ? bytes_left : temp.Length;
                    memcpy(temp, row0, bytes_copy);
                    memcpy(row0, row1, bytes_copy);
                    memcpy(row1, temp, bytes_copy);

                    row0 += bytes_copy;
                    row1 += bytes_copy;
                    bytes_left -= bytes_copy;
                }
            }
        }

        private static unsafe void memcpy(char[] dst, char* src, int count) {
            for (int i = 0; i < count; i++) {
                dst[i] = src[i];
            }
        }

        private static unsafe void memcpy(char* dst, char* src, int count) {
            for (int i = 0; i < count; i++) {
                dst[i] = src[i];
            }
        }

        private static unsafe void memcpy(char* dst, char[] src, int count) {
            for (int i = 0; i < count; i++) {
                dst[i] = src[i];
            }
        }

        private static unsafe void* stbi__convert_16_to_8(UInt16* orig, int w, int h, int channels) {
            int i;
            int img_len = w * h * channels;
            char* reduced = (char*)Marshal.AllocHGlobal(img_len * sizeof(char));

            for (i = 0; i < img_len; ++i)
                reduced[i] = (char)((orig[i] >> 8) & 0xFF); // top half of each byte is sufficient approx of 16->8 bit scaling

            //STBI_FREE(orig);
            return reduced;
        }

        private static unsafe void stbi__start_file(stbi__context s, StreamReader f) {
            stbi__start_callbacks(s, stbi__stdio_callbacks, f);
        }

        static int stbi__stdio_read(object user, char* data, int size) {
            var reader = user as StreamReader;
            //return (int)fread(data, 1, size, (FILE*)user);
            var buffer = new char[size];
            int result = reader.Read(buffer, 0, size);
            for (int i = 0; i < size; i++) {
                data[i] = buffer[i];
            }
            return result;
        }

        static void stbi__stdio_skip(object user, int n) {
            var reader = user as StreamReader;
            //fseek((FILE*)user, n, SEEK_CUR);
            reader.BaseStream.Seek(n, SeekOrigin.Current);
        }

        static int stbi__stdio_eof(object user) {
            var reader = user as StreamReader;
            //return feof((FILE*)user);
            return reader.EndOfStream ? 1 : 0;
        }

        static stbi_io_callbacks stbi__stdio_callbacks = new stbi_io_callbacks(stbi__stdio_read, stbi__stdio_skip, stbi__stdio_eof);

        // initialize a callback-based context
        private static unsafe void stbi__start_callbacks(stbi__context s, stbi_io_callbacks c, object user) {
            s.io = c;
            s.io_user_data = user;
            s.buflen = 128; // sizeof(s.buffer_start);
            s.read_from_callbacks = 1;
            s.img_buffer_original = s.buffer_start;
            stbi__refill_buffer(s);
            s.img_buffer_original_end = s.img_buffer_end;
        }

        private static unsafe void stbi__refill_buffer(stbi__context s) {
            int n = s.io.read(s.io_user_data, s.buffer_start, s.buflen);
            if (n == 0) {
                // at end of file, treat same as if from memory, but need to handle case
                // where s->img_buffer isn't pointing to safe memory, e.g. 0-byte file
                s.read_from_callbacks = 0;
                s.img_buffer = s.buffer_start;
                s.img_buffer_end = s.buffer_start + 1;
                *s.img_buffer = '\0';
            }
            else {
                s.img_buffer = s.buffer_start;
                s.img_buffer_end = s.buffer_start + n;
            }
        }

        private static void* stbi__load_main(ref stbi__context s, int* x, int* y, int* comp, int req_comp, stbi__result_info* ri, int bpc) {
            // make sure it's initialized if we add new fields
            ri->num_channels = 0; ri->channel_order = 0;
            ri->bits_per_channel = 8; // default is 8 so most paths don't have to be changed
            ri->channel_order = STBI_ORDER_RGB; // all current input & output are this, but this is here so we can add BGR order
            ri->num_channels = 0;

            //if (stbi__hdr_test(s)) {
            float* hdr = stbi__hdr_load(ref s, x, y, comp, req_comp, ri);
            return stbi__hdr_to_ldr(hdr, out x, out y, req_comp != 0 ? req_comp : *comp);
            //}

            //return stbi__errpuc("unknown image type", "Image not of any known type, or corrupt");
        }

        private static unsafe void* stbi__hdr_to_ldr(float* hdr, out int* x, out int* y, int p) {
            throw new NotImplementedException();
        }

        private static unsafe float* stbi__hdr_load(ref stbi__context s, int* x, int* y, int* comp, int req_comp, stbi__result_info* ri) {
            throw new NotImplementedException();
        }

    }
}
