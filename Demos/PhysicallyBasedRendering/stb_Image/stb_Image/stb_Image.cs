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

    }
}
