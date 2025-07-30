using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL {
    public static unsafe partial class stb_Image {

        /// <summary>
        /// only used for desired_channels
        /// </summary>
        const int STBI_default = 0;

        const int STBI_grey = 1;
        const int STBI_grey_alpha = 2;
        const int STBI_rgb = 3;
        const int STBI_rgb_alpha = 4;

        const int STBI_ORDER_RGB = 0;
        const int STBI_ORDER_BGR = 1;

        delegate int delRead(object user, byte* data, int size);
        delegate void delSkip(object user, int n);
        delegate int delEof(object user);
        class stbi_io_callbacks {
            // fill 'data' with 'size' bytes.  return number of bytes actually read
            public delRead read;

            // skip the next 'n' bytes, or 'unget' the last -n bytes if negative
            public delSkip skip;

            // returns nonzero if we are at end of file/data
            public delEof eof;

            public stbi_io_callbacks(delRead read, delSkip skip, delEof eof) {
                this.read = read; this.skip = skip; this.eof = eof;
            }
        }

        // stbi__context structure is our basic context used by all images, so it
        // contains all the IO context, plus some basic image information
        unsafe class stbi__context {
            public UInt32 img_x, img_y;
            public int img_n, img_out_n;

            public stbi_io_callbacks io;
            public object io_user_data;

            public int read_from_callbacks;
            public int buflen;
            public byte* buffer_start;// = stackalloc byte[128];

            public byte* img_buffer;
            public byte* img_buffer_end;
            public byte* img_buffer_original;
            public byte* img_buffer_original_end;
        }

        struct stbi__result_info {
            public int bits_per_channel;
            public int num_channels;
            public int channel_order;
        }

        public static void stbi_set_flip_vertically_on_load(bool flag_true_if_should_flip) {
            stbi__vertically_flip_on_load = flag_true_if_should_flip;
        }
        static bool stbi__vertically_flip_on_load = false;
        static float stbi__h2l_gamma_i = 1.0f / 2.2f;
        static float stbi__h2l_scale_i = 1.0f;
        // this is not threadsafe
        static string stbi__g_failure_reason;
        static float stbi__l2h_gamma = 2.2f;
        static float stbi__l2h_scale = 1.0f;
    }
}
