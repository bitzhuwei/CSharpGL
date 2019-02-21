using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace CSharpGL {
    public static unsafe partial class stb_Image {

        public static float* stbi_loadf(string filename, int* x, int* y, int* comp, int req_comp) {
            float* result;

            using (var fs = new FileStream(filename, FileMode.Open)) {
                result = stbi_loadf_from_file(fs, x, y, comp, req_comp);
            }

            return result;
        }

        static float* stbi_loadf_from_file(FileStream f, int* x, int* y, int* comp, int req_comp) {
            stbi__context s = new stbi__context();
            stbi__start_file(s, f);
            return stbi__loadf_main(s, x, y, comp, req_comp);
        }

        static float* stbi__loadf_main(stbi__context s, int* x, int* y, int* comp, int req_comp) {
            char* data;
            //if (stbi__hdr_test(s)) {
            stbi__result_info ri;
            float* hdr_data = stbi__hdr_load(s, x, y, comp, req_comp, &ri);
            if (hdr_data != null)
                stbi__float_postprocess(hdr_data, x, y, comp, req_comp);
            return hdr_data;
            //}
            data = stbi__load_and_postprocess_8bit(s, x, y, comp, req_comp);
            if (data != null)
                return stbi__ldr_to_hdr(data, *x, *y, req_comp != 0 ? req_comp : *comp);

            stbi__errpf("Image not of any known type, or corrupt");
            return null;
        }

        static float* stbi__ldr_to_hdr(char* data, int x, int y, int comp) {
            if (data == null) { return null; }
            int i, k, n;
            float* output;
            output = (float*)stbi__malloc_mad4(x, y, comp, sizeof(float), 0);
            if (output == null) { STBI_FREE(data); stbi__errpf("Out of memory"); return null; }
            // compute number of non-alpha components
            if ((comp & 1) != 0) { n = comp; } else { n = comp - 1; }
            for (i = 0; i < x * y; ++i) {
                for (k = 0; k < n; ++k) {
                    output[i * comp + k] = (float)(Math.Pow(data[i * comp + k] / 255.0f, stbi__l2h_gamma) * stbi__l2h_scale);
                }
                if (k < comp) output[i * comp + k] = data[i * comp + k] / 255.0f;
            }
            STBI_FREE(data);
            return output;
        }

        static void stbi__float_postprocess(float* result, int* x, int* y, int* comp, int req_comp) {
            if (stbi__vertically_flip_on_load && result != null) {
                int channels = req_comp != 0 ? req_comp : *comp;
                stbi__vertical_flip(result, *x, *y, channels * sizeof(float));
            }
        }

        public static char* stbi_load(string filename, int* x, int* y, int* comp, int req_comp) {
            char* result;

            using (var sr = new FileStream(filename, FileMode.Open)) {
                result = stbi_load_from_file(sr, x, y, comp, req_comp);
            }

            return result;
        }

        private static char* stbi_load_from_file(FileStream f, int* x, int* y, int* comp, int req_comp) {
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

        private static char* stbi__load_and_postprocess_8bit(stbi__context s, int* x, int* y, int* comp, int req_comp) {
            stbi__result_info ri;
            void* result = stbi__load_main(s, x, y, comp, req_comp, &ri, 8);

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

        private static void stbi__vertical_flip(void* image, int w, int h, int bytes_per_pixel) {
            int row;
            int bytes_per_row = w * bytes_per_pixel;
            byte[] temp = new byte[2048];
            byte* bytes = (byte*)image;

            for (row = 0; row < (h >> 1); row++) {
                byte* row0 = bytes + row * bytes_per_row;
                byte* row1 = bytes + (h - row - 1) * bytes_per_row;
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

        private static void memcpy(byte[] dst, byte* src, int count) {
            for (int i = 0; i < count; i++) {
                dst[i] = src[i];
            }
        }

        private static void memcpy(byte* dst, byte* src, int count) {
            for (int i = 0; i < count; i++) {
                dst[i] = src[i];
            }
        }

        private static void memcpy(byte* dst, byte[] src, int count) {
            for (int i = 0; i < count; i++) {
                dst[i] = src[i];
            }
        }

        private static void* stbi__convert_16_to_8(UInt16* orig, int w, int h, int channels) {
            int i;
            int img_len = w * h * channels;
            byte* reduced = (byte*)Marshal.AllocHGlobal(img_len * sizeof(byte));

            for (i = 0; i < img_len; ++i)
                reduced[i] = (byte)((orig[i] >> 8) & 0xFF); // top half of each byte is sufficient approx of 16->8 bit scaling

            //STBI_FREE(orig);
            return reduced;
        }

        private static void stbi__start_file(stbi__context s, FileStream f) {
            stbi__start_callbacks(s, stbi__stdio_callbacks, f);
        }

        static int stbi__stdio_read(object user, byte* data, int size) {
            var reader = user as FileStream;
            //return (int)fread(data, 1, size, (FILE*)user);
            var buffer = new byte[size];
            int result = reader.Read(buffer, 0, size);
            //byte[] buffer = reader.ReadBytes(size);
            for (int i = 0; i < size; i++) {
                data[i] = buffer[i];
            }
            //return result;
            return result;
        }

        static void stbi__stdio_skip(object user, int n) {
            var reader = user as FileStream;
            //fseek((FILE*)user, n, SEEK_CUR);
            reader.Seek(n, SeekOrigin.Current);
        }

        static int stbi__stdio_eof(object user) {
            var reader = user as FileStream;
            //return feof((FILE*)user);
            return reader.Position < reader.Length ? 1 : 0;
        }

        static stbi_io_callbacks stbi__stdio_callbacks = new stbi_io_callbacks(stbi__stdio_read, stbi__stdio_skip, stbi__stdio_eof);

        // initialize a callback-based context
        private static void stbi__start_callbacks(stbi__context s, stbi_io_callbacks c, object user) {
            s.io = c;
            s.io_user_data = user;
            s.buflen = 128; // sizeof(s.buffer_start);
            s.read_from_callbacks = 1;
            s.buffer_start = (byte*)Marshal.AllocHGlobal(128 * sizeof(byte));
            s.img_buffer_original = s.buffer_start;
            stbi__refill_buffer(s);
            s.img_buffer_original_end = s.img_buffer_end;
        }

        private static void stbi__refill_buffer(stbi__context s) {
            int n = s.io.read(s.io_user_data, s.buffer_start, s.buflen);
            if (n == 0) {
                // at end of file, treat same as if from memory, but need to handle case
                // where s->img_buffer isn't pointing to safe memory, e.g. 0-byte file
                s.read_from_callbacks = 0;
                s.img_buffer = s.buffer_start;
                s.img_buffer_end = s.buffer_start + 1;
                *s.img_buffer = 0;
            }
            else {
                s.img_buffer = s.buffer_start;
                s.img_buffer_end = s.buffer_start + n;
            }
        }

        private static void* stbi__load_main(stbi__context s, int* x, int* y, int* comp, int req_comp, stbi__result_info* ri, int bpc) {
            // make sure it's initialized if we add new fields
            ri->num_channels = 0; ri->channel_order = 0;
            ri->bits_per_channel = 8; // default is 8 so most paths don't have to be changed
            ri->channel_order = STBI_ORDER_RGB; // all current input & output are this, but this is here so we can add BGR order
            ri->num_channels = 0;

            //if (stbi__hdr_test(s)) {
            float* hdr = stbi__hdr_load(s, x, y, comp, req_comp, ri);
            return stbi__hdr_to_ldr(hdr, *x, *y, req_comp != 0 ? req_comp : *comp);
            //}

            //return stbi__errpuc("unknown image type", "Image not of any known type, or corrupt");
        }

        private static char* stbi__hdr_to_ldr(float* data, int x, int y, int comp) {
            int i, k, n;
            char* output;
            if (data == null) { return null; }

            output = (char*)stbi__malloc_mad3(x, y, comp, 0);
            // compute number of non-alpha components
            if ((comp & 1) != 0) { n = comp; } else { n = comp - 1; }

            for (i = 0; i < x * y; ++i) {
                for (k = 0; k < n; ++k) {
                    float z = (float)Math.Pow(data[i * comp + k] * stbi__h2l_scale_i, stbi__h2l_gamma_i) * 255 + 0.5f;
                    if (z < 0) z = 0;
                    if (z > 255) z = 255;
                    output[i * comp + k] = (char)((int)z);
                }
                if (k < comp) {
                    float z = data[i * comp + k] * 255 + 0.5f;
                    if (z < 0) z = 0;
                    if (z > 255) z = 255;
                    output[i * comp + k] = (char)((int)z);
                }
            }
            //STBI_FREE(data);
            return output;
        }

        static void* stbi__malloc_mad3(int a, int b, int c, int add) {
            if (stbi__mad3sizes_valid(a, b, c, add)) return null;
            return (void*)Marshal.AllocHGlobal(a * b * c + add);
        }

        // returns 1 if "a*b*c + add" has no negative terms/factors and doesn't overflow
        static bool stbi__mad3sizes_valid(int a, int b, int c, int add) {
            return (stbi__mul2sizes_valid(a, b))
                && (stbi__mul2sizes_valid(a * b, c))
                && (stbi__addsizes_valid(a * b * c, add));
        }

        // return 1 if the sum is valid, 0 on overflow.
        // negative terms are considered invalid.
        static bool stbi__addsizes_valid(int a, int b) {
            if (b < 0) return false;
            // now 0 <= b <= INT_MAX, hence also
            // 0 <= INT_MAX - b <= INTMAX.
            // And "a + b <= INT_MAX" (which might overflow) is the
            // same as a <= INT_MAX - b (no overflow)
            return a <= int.MaxValue - b;
        }

        // returns 1 if the product is valid, 0 on overflow.
        // negative factors are considered invalid.
        static bool stbi__mul2sizes_valid(int a, int b) {
            if (a < 0 || b < 0) return false;
            if (b == 0) return true; // mul-by-0 is always safe
            // portable way to check for no overflows in a*b
            return a <= int.MaxValue / b;
        }

        const int STBI__HDR_BUFLEN = 1024;
        private static float* stbi__hdr_load(stbi__context s, int* x, int* y, int* comp, int req_comp, stbi__result_info* ri) {
            byte* buffer = stackalloc byte[STBI__HDR_BUFLEN];
            byte* token;
            bool valid = false;
            int width, height;
            byte* scanline;
            float* hdr_data;
            int len;
            byte count, value;
            int i, j, k, c1, c2, z;
            byte* headerToken;
            // Check identifier
            headerToken = stbi__hdr_gettoken(s, buffer);
            if (strcmp(headerToken, "#?RADIANCE") && strcmp(headerToken, "#?RGBE")) { stbi__errpf("Corrupt HDR image"); return null; }

            // Parse header
            for (; ; ) {
                token = stbi__hdr_gettoken(s, buffer);
                if (token[0] == 0) break;
                if (!strcmp(token, "FORMAT=32-bit_rle_rgbe")) { valid = true; }
            }

            if (!valid) { stbi__errpf("Unsupported HDR format"); return null; }

            // Parse width and height
            // can't use sscanf() if we're not using stdio!
            token = stbi__hdr_gettoken(s, buffer);
            if (strncmp(token, "-Y ", 3)) { stbi__errpf("Unsupported HDR format"); return null; }
            token += 3;
            height = (int)strtol(token, &token, 10);
            while (*token == ' ') ++token;
            if (strncmp(token, "+X ", 3)) { stbi__errpf("Unsupported HDR format"); return null; }
            token += 3;
            width = (int)strtol(token, null, 10);

            *x = width;
            *y = height;

            if (comp != null) *comp = 3;
            if (req_comp == 0) req_comp = 3;

            if (!stbi__mad4sizes_valid(width, height, req_comp, sizeof(float), 0)) { stbi__errpf("HDR image is too large"); return null; }
            // Read data
            hdr_data = (float*)stbi__malloc_mad4(width, height, req_comp, sizeof(float), 0);
            if (hdr_data == null) { stbi__errpf("Out of memory"); return null; }

            // Load image data
            // image data is stored as some number of sca
            if (width < 8 || width >= 32768) {
                // Read flat data
                for (j = 0; j < height; ++j) {
                    for (i = 0; i < width; ++i) {
                        byte* rgbe = stackalloc byte[4];
                        //main_decode_loop:
                        stbi__getn(s, rgbe, 4);
                        stbi__hdr_convert(hdr_data + j * width * req_comp + i * req_comp, rgbe, req_comp);
                    }
                }
            }
            else {
                // Read RLE-encoded data
                scanline = null;

                for (j = 0; j < height; ++j) {
                    c1 = stbi__get8(s);
                    c2 = stbi__get8(s);
                    len = stbi__get8(s);
                    if (c1 != (byte)2 || c2 != (byte)2 || ((len & 0x80) != 0)) {
                        // not run-length encoded, so we have to actually use THIS data as a decoded
                        // pixel (note this can't be a valid pixel--one of RGB must be >= 128)
                        byte* rgbe = stackalloc byte[4];
                        rgbe[0] = (byte)c1;
                        rgbe[1] = (byte)c2;
                        rgbe[2] = (byte)len;
                        rgbe[3] = (byte)stbi__get8(s);
                        stbi__hdr_convert(hdr_data, rgbe, req_comp);
                        i = 1;
                        j = 0;
                        if (scanline != null) { STBI_FREE(scanline); scanline = null; }
                        //goto main_decode_loop; // yes, this makes no sense
                        // this replaced goto statement.
                        stbi__getn(s, rgbe, 4);
                        stbi__hdr_convert(hdr_data + j * width * req_comp + i * req_comp, rgbe, req_comp);
                        ++j; ++i;
                        // Read flat data
                        for (; j < height; ++j) {
                            for (; i < width; ++i) {
                                stbi__getn(s, rgbe, 4);
                                stbi__hdr_convert(hdr_data + j * width * req_comp + i * req_comp, rgbe, req_comp);
                            }
                        }
                        break;
                        // end of goto.
                    }
                    len <<= 8;
                    len |= stbi__get8(s);
                    if (len != width) { STBI_FREE(hdr_data); STBI_FREE(scanline); stbi__errpf("invalid decoded scanline length | corrupt HDR"); return null; }
                    if (scanline == null) {
                        scanline = (byte*)stbi__malloc_mad2(width, 4, 0);
                        if (scanline == null) {
                            STBI_FREE(hdr_data);
                            stbi__errpf("Out of memory");
                            return null;
                        }
                    }

                    for (k = 0; k < 4; ++k) {
                        int nleft;
                        i = 0;
                        while ((nleft = width - i) > 0) {
                            count = stbi__get8(s);
                            if (count > 128) {
                                // Run
                                value = stbi__get8(s);
                                count -= (byte)128;
                                if (count > nleft) { STBI_FREE(hdr_data); STBI_FREE(scanline); stbi__errpf("corrupt | bad RLE data in HDR"); return null; }
                                for (z = 0; z < count; ++z)
                                    scanline[i++ * 4 + k] = value;
                            }
                            else {
                                // Dump
                                if (count > nleft) { STBI_FREE(hdr_data); STBI_FREE(scanline); stbi__errpf("corrupt | bad RLE data in HDR"); return null; }
                                for (z = 0; z < count; ++z)
                                    scanline[i++ * 4 + k] = stbi__get8(s);
                            }
                        }
                    }
                    for (i = 0; i < width; ++i)
                        stbi__hdr_convert(hdr_data + (j * width + i) * req_comp, scanline + i * 4, req_comp);
                }
                if (scanline != null) { STBI_FREE(scanline); scanline = null; }
            }

            return hdr_data;
        }

        // mallocs with size overflow checking
        static void* stbi__malloc_mad2(int a, int b, int add) {
            if (!stbi__mad2sizes_valid(a, b, add)) return null;
            return (void*)Marshal.AllocHGlobal(a * b + add);
        }

        // returns 1 if "a*b + add" has no negative terms/factors and doesn't overflow
        static bool stbi__mad2sizes_valid(int a, int b, int add) {
            return stbi__mul2sizes_valid(a, b) && stbi__addsizes_valid(a * b, add);
        }

        static void STBI_FREE(void* ptr) {
            Marshal.FreeHGlobal((IntPtr)ptr);
        }
        static void stbi__hdr_convert(float* output, byte* input, int req_comp) {
            if (input[3] != 0) {
                float f1;
                // Exponent
                f1 = (float)ldexp(1.0f, input[3] - (int)(128 + 8));
                if (req_comp <= 2)
                    output[0] = (input[0] + input[1] + input[2]) * f1 / 3;
                else {
                    output[0] = input[0] * f1;
                    output[1] = input[1] * f1;
                    output[2] = input[2] * f1;
                }
                if (req_comp == 2) output[1] = 1;
                if (req_comp == 4) output[3] = 1;
            }
            else {
                switch (req_comp) {
                    case 4: output[3] = 1; output[0] = output[1] = output[2] = 0; break;
                    case 3: output[0] = output[1] = output[2] = 0; break;
                    case 2: output[1] = 1; output[0] = 0; break;
                    case 1: output[0] = 0; break;
                }
            }
        }

        private static double ldexp(double x, int exponent) {
            return x * Math.Pow(2, exponent);
        }

        static bool stbi__getn(stbi__context s, byte* buffer, int n) {
            if (s.io.read != null) {
                int blen = (int)(s.img_buffer_end - s.img_buffer);
                if (blen < n) {
                    bool res;
                    int count;

                    memcpy(buffer, s.img_buffer, blen);

                    count = s.io.read(s.io_user_data, (byte*)buffer + blen, n - blen);
                    res = (count == (n - blen));
                    s.img_buffer = s.img_buffer_end;
                    return res;
                }
            }

            if (s.img_buffer + n <= s.img_buffer_end) {
                memcpy(buffer, s.img_buffer, n);
                s.img_buffer += n;
                return true;
            }
            else
                return false;
        }

        static void* stbi__malloc_mad4(int a, int b, int c, int d, int add) {
            if (!stbi__mad4sizes_valid(a, b, c, d, add)) return null;
            return (void*)Marshal.AllocHGlobal(a * b * c * d + add);
        }

        // returns 1 if "a*b*c*d + add" has no negative terms/factors and doesn't overflow
        static bool stbi__mad4sizes_valid(int a, int b, int c, int d, int add) {
            return stbi__mul2sizes_valid(a, b) && stbi__mul2sizes_valid(a * b, c) &&
                stbi__mul2sizes_valid(a * b * c, d) && stbi__addsizes_valid(a * b * c * d, add);
        }

        /// <summary>
        /// Different
        /// </summary>
        /// <param name="str1"></param>
        /// <param name="p1"></param>
        /// <param name="maxNum"></param>
        /// <returns></returns>
        private static bool strncmp(byte* str1, string str2, int maxNum) {
            bool result = false;
            for (int i = 0; i < str2.Length && i < maxNum; i++) {
                byte c = (byte)str1[i];
                if (c == 0) { result = true; break; }
                if (c != str2[i]) { result = true; break; }
            }

            return result;
        }

        private static void stbi__errpf(string msg) {
            stbi__g_failure_reason = msg;
        }

        /// <summary>
        /// Different
        /// </summary>
        /// <param name="str1"></param>
        /// <param name="str2"></param>
        /// <returns></returns>
        private static bool strcmp(byte* str1, string str2) {
            bool result = false;
            for (int i = 0; i < str2.Length; i++) {
                char c = (char)str1[i];
                if (c == 0) { result = true; break; }
                if (c != str2[i]) { result = true; break; }
            }

            return result;
        }

        static byte* stbi__hdr_gettoken(stbi__context z, byte* buffer) {
            int len = 0;
            byte c = 0;

            c = (byte)stbi__get8(z);

            while (!stbi__at_eof(z) && c != '\n') {
                buffer[len++] = c;
                if (len == STBI__HDR_BUFLEN - 1) {
                    // flush to end of line
                    while (!stbi__at_eof(z) && stbi__get8(z) != '\n')
                        ;
                    break;
                }
                c = stbi__get8(z);
            }

            buffer[len] = 0;
            return buffer;
        }

        static bool stbi__at_eof(stbi__context s) {
            if (s.io.read != null) {
                if (s.io.eof(s.io_user_data) != 0) return false;
                // if feof() is true, check if buffer = end
                // special case: we've only got the special 0 character at the end
                if (s.read_from_callbacks == 0) return true;
            }

            return s.img_buffer >= s.img_buffer_end;
        }

        static byte stbi__get8(stbi__context s) {
            if (s.img_buffer < s.img_buffer_end)
                return *s.img_buffer++;
            if (s.read_from_callbacks != 0) {
                stbi__refill_buffer(s);
                return *s.img_buffer++;
            }
            return 0;
        }
    }
}
