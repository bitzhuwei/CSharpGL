using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpGL {
    public static unsafe partial class stb_Image {
        static char TOLOWER(byte x) { return (char)(x | 0X20); }
        static bool isxdigit(byte c) {
            return (('0' <= (c) && (c) <= '9')
             || ('a' <= (c) && (c) <= 'f')
             || ('A' <= (c) && (c) <= 'F'));
        }

        static bool isdigit(byte c) { return ('0' <= (c) && (c) <= '9'); }

        static ulong strtoul(byte* cp, byte** endp, int _base) {
            ulong result = 0, value;

            if (_base == 0) {
                _base = 10;
                if (*cp == '0') {
                    _base = 8;
                    cp++;
                    if ((TOLOWER(*cp) == 'x') && isxdigit(cp[1])) {
                        cp++;
                        _base = 16;
                    }
                }
            }
            else if (_base == 16) {
                if (cp[0] == '0' && TOLOWER(cp[1]) == 'x')
                    cp += 2;
            }
            while (isxdigit(*cp) &&
                   (value = (ulong)(isdigit(*cp) ? *cp - '0' : TOLOWER(*cp) - 'a' + 10)) < (ulong)_base) {
                result = result * (ulong)_base + value;
                cp++;
            }
            if (endp != null)
                *endp = (byte*)cp;
            return result;
        }

        static long strtol(byte* cp, byte** endp, int _base) {
            if (*cp == '-')
                return -((long)strtoul(cp + 1, endp, _base));
            return (long)strtoul(cp, endp, _base);
        }

    }
}
