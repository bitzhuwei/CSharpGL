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
        };

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
        public unsafe struct stbi__context {
            UInt32 img_x, img_y;
            int img_n, img_out_n;

            stbi_io_callbacks io;
            void* io_user_data;

            int read_from_callbacks;
            int buflen;
            char* buffer_start;//=new char[128];

            char* img_buffer;
            char* img_buffer_end;
            char* img_buffer_original;
            char* img_buffer_original_end;
        }
    }
}
