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
            stbi__start_file(ref s, f);
            result = stbi__load_and_postprocess_8bit(ref s, x, y, comp, req_comp);
            //if (result[0] != '\0') {
            //    // need to 'unget' all the characters in the IO buffer
            //    fseek(f, -(int)(s.img_buffer_end - s.img_buffer), SEEK_CUR);

            //}
            return result;
        }

        private static unsafe char* stbi__load_and_postprocess_8bit(ref stbi__context s, int* x, int* y, int* comp, int req_comp) {
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

        private static unsafe void stbi__vertical_flip(void* result, int p1, int p2, int p3) {
            throw new NotImplementedException();
        }

        private static unsafe void* stbi__convert_16_to_8(ushort* p1, int p2, int p3, int p4) {
            throw new NotImplementedException();
        }

        private static unsafe void stbi__start_file(ref stbi__context s, StreamReader f) {
            throw new NotImplementedException();
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
