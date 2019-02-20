using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL {
    public static unsafe partial class stb_Image {

        enum STBI {
            /// <summary>
            /// only used for desired_channels
            /// </summary>
            STBI_default = 0,

            STBI_grey = 1,
            STBI_grey_alpha = 2,
            STBI_rgb = 3,
            STBI_rgb_alpha = 4
        }

        delegate int delRead(object user, char* data, int size);
        delegate void delSkip(object user, int n);
        delegate int delEof(object user);
        struct stbi_io_callbacks {
            // fill 'data' with 'size' bytes.  return number of bytes actually read
            public delRead read;

            // skip the next 'n' bytes, or 'unget' the last -n bytes if negative
            public delSkip skip;

            // returns nonzero if we are at end of file/data
            public delEof eof;
        }

        // stbi__context structure is our basic context used by all images, so it
        // contains all the IO context, plus some basic image information
        unsafe struct stbi__context {
            public UInt32 img_x, img_y;
            public int img_n, img_out_n;

            public stbi_io_callbacks io;
            public void* io_user_data;

            public int read_from_callbacks;
            public int buflen;
            public char* buffer_start;//=new char[128];

            public char* img_buffer;
            public char* img_buffer_end;
            public char* img_buffer_original;
            public char* img_buffer_original_end;
        }

        struct stbi__result_info {
            public int bits_per_channel;
            public int num_channels;
            public int channel_order;
        }

        static int stbi__vertically_flip_on_load = 0;

    }
}
