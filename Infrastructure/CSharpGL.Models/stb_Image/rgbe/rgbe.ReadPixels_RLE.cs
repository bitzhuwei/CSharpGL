using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace CSharpGL {
    public static partial class rgbe {
        /* read or write run length encoded files */
        /* must be called to read or write whole scanlines */
        public static int RGBE_ReadPixels_RLE(StreamReader fp, float[] data, int scanline_width, int num_scanlines) {
            char[] rgbe = new char[4];
            char[] scanline_buffer;
            int ptrIndex, ptrEndIndex;
            int i, count;
            char[] buf = new char[2];

            if ((scanline_width < 8) || (scanline_width > 0x7fff))
                /* run length encoding is not allowed so read flat*/
                return RGBE_ReadPixels(fp, data, scanline_width * num_scanlines);
            scanline_buffer = null;

            int index = 0;
            /* read in each successive scanline */
            while (num_scanlines > 0) {
                if (fp.Read(rgbe, 0, 4) < 1) {
                    return rgbe_error(rgbe_error_codes.rgbe_read_error, string.Empty);
                }

                if ((rgbe[0] != (char)2) || (rgbe[1] != (char)2) || ((rgbe[2] & 0x80) != 0)) {
                    /* this file is not run length encoded */
                    float r, g, b;
                    rgbe2float(out r, out g, out b, rgbe);
                    data[index] = r; data[index + 1] = g; data[index + 2] = b;
                    index += RGBE_DATA_SIZE;
                    return RGBE_ReadPixels(fp, data, scanline_width * num_scanlines - 1);
                }

                if ((((int)rgbe[2]) << 8 | rgbe[3]) != scanline_width) {
                    return rgbe_error(rgbe_error_codes.rgbe_format_error, "wrong scanline width");
                }

                if (scanline_buffer == null) {
                    scanline_buffer = new char[4 * scanline_width];
                }

                if (scanline_buffer == null) {
                    return rgbe_error(rgbe_error_codes.rgbe_memory_error, "unable to allocate buffer space");
                }

                ptrIndex = 0;
                /* read each of the four channels for the scanline into the buffer */
                for (i = 0; i < 4; i++) {
                    ptrEndIndex = (i + 1) * scanline_width;
                    while (ptrIndex < ptrEndIndex) {
                        if (fp.Read(buf, 0, 2) < 1) {
                            return rgbe_error(rgbe_error_codes.rgbe_read_error, string.Empty);
                        }

                        if (buf[0] > 128) {
                            /* a run of the same value */
                            count = buf[0] - 128;
                            if ((count == 0) || (count > ptrEndIndex - ptrIndex)) {
                                return rgbe_error(rgbe_error_codes.rgbe_format_error, "bad scanline data");
                            }
                            while (count-- > 0) {
                                scanline_buffer[ptrIndex++] = buf[1];
                            }
                        }
                        else {
                            /* a non-run */
                            count = buf[0];
                            if ((count == 0) || (count > ptrEndIndex - ptrIndex)) {
                                return rgbe_error(rgbe_error_codes.rgbe_format_error, "bad scanline data");
                            }

                            scanline_buffer[ptrIndex++] = buf[1];
                            if (--count > 0) {
                                if (fp.Read(scanline_buffer, ptrIndex, count) < 1) {
                                    return rgbe_error(rgbe_error_codes.rgbe_read_error, string.Empty);
                                }
                                ptrIndex += count;
                            }
                        }
                    }
                }
                /* now convert data from buffer into floats */
                for (i = 0; i < scanline_width; i++) {
                    rgbe[0] = scanline_buffer[i];
                    rgbe[1] = scanline_buffer[i + scanline_width];
                    rgbe[2] = scanline_buffer[i + 2 * scanline_width];
                    rgbe[3] = scanline_buffer[i + 3 * scanline_width];
                    float r, g, b;
                    rgbe2float(out r, out g, out b, rgbe);
                    data[index + RGBE_DATA_RED] = r; data[index + RGBE_DATA_GREEN] = g; data[index + RGBE_DATA_BLUE] = b;
                    index += RGBE_DATA_SIZE;

                }
                num_scanlines--;
            }

            return RGBE_RETURN_SUCCESS;
        }
    }
}
