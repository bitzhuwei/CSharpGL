using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace CSharpGL {
    public static partial class rgbe {
        /* The code below is only needed for the run-length encoded files. */
        /* Run length encoding adds considerable complexity but does */
        /* save some space.  For each scanline, each channel (r,g,b,e) is */
        /* encoded separately for better compression. */
        static int RGBE_WriteBytes_RLE(StreamWriter fp, char[] data, int startIndex, int numbytes) {
            const int MINRUNLENGTH = 4;
            int cur, beg_run, run_count, old_run_count, nonrun_count;
            char[] buf = new char[2];

            cur = 0;
            while (cur < numbytes) {
                beg_run = cur;
                /* find next run of length at least 4 if one exists */
                run_count = old_run_count = 0;
                while ((run_count < MINRUNLENGTH) && (beg_run < numbytes)) {
                    beg_run += run_count;
                    old_run_count = run_count;
                    run_count = 1;
                    while ((beg_run + run_count < numbytes) && (run_count < 127)
                        && (data[startIndex + beg_run] == data[startIndex + beg_run + run_count]))
                        run_count++;
                }
                /* if data before next big run is a short run then write it as such */
                if ((old_run_count > 1) && (old_run_count == beg_run - cur)) {
                    buf[0] = (char)(128 + old_run_count);   /*write short run*/
                    buf[1] = data[startIndex + cur];
                    fp.Write(buf, 0, 2);
                    cur = beg_run;
                }
                /* write out bytes until we reach the start of the next run */
                while (cur < beg_run) {
                    nonrun_count = beg_run - cur;
                    if (nonrun_count > 128)
                        nonrun_count = 128;
                    buf[0] = (char)nonrun_count;
                    fp.Write(buf[0]);
                    fp.Write(data, startIndex + cur, nonrun_count);
                    cur += nonrun_count;
                }
                /* write out next run if one was found */
                if (run_count >= MINRUNLENGTH) {
                    buf[0] = (char)(128 + run_count);
                    buf[1] = data[startIndex + beg_run];
                    fp.Write(buf, 0, 2);
                    cur += run_count;
                }
            }
            return RGBE_RETURN_SUCCESS;
        }
    }
}
