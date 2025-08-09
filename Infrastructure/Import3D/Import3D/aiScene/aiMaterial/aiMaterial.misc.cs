
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Import3D {
    unsafe partial class aiMaterial {
        private static byte* fast_atoreal_move(byte* cur, float outValue, bool check_comma = true) {
            float f = 0;

            bool inv = (*cur == '-');
            if (inv || *cur == '+') {
                ++cur;
            }

            if ((cur[0] == 'N' || cur[0] == 'n') && ASSIMP_strincmp(cur, "nan", 3) == 0) {
                outValue = float.NaN;
                cur += 3;
                return cur;
            }

            if ((cur[0] == 'I' || cur[0] == 'i') && ASSIMP_strincmp(cur, "inf", 3) == 0) {
                outValue = float.PositiveInfinity;// std::numeric_limits<float>::infinity();
                if (inv) {
                    outValue = -outValue;
                }
                cur += 3;
                if ((cur[0] == 'I' || cur[0] == 'i') && ASSIMP_strincmp(cur, "inity", 5) == 0) {
                    cur += 5;
                }
                return cur;
            }

            if (!(cur[0] >= '0' && cur[0] <= '9') &&
                    !((cur[0] == '.' || (check_comma && cur[0] == ',')) && cur[1] >= '0' && cur[1] <= '9')) {
                // The string is known to be bad, so don't risk printing the whole thing.
                throw new Exception($"Cannot parse string  as a real number: does not start with digit or decimal point followed by digit.");
            }

            if (*cur != '.' && (!check_comma || cur[0] != ',')) {
                f = strtoul10_64(cur, &cur);
            }

            if ((*cur == '.' || (check_comma && cur[0] == ',')) && cur[1] >= '0' && cur[1] <= '9') {
                ++cur;

                // NOTE: The original implementation is highly inaccurate here. The precision of a single
                // IEEE 754 float is not high enough, everything behind the 6th digit tends to be more
                // inaccurate than it would need to be. Casting to double seems to solve the problem.
                // strtol_64 is used to prevent integer overflow.

                // Another fix: this tends to become 0 for long numbers if we don't limit the maximum
                // number of digits to be read. AI_FAST_ATOF_RELAVANT_DECIMALS can be a value between
                // 1 and 15.
                int diff = /*AI_FAST_ATOF_RELAVANT_DECIMALS*/15;
                double pl = strtoul10_64(cur, &cur, &diff);

                pl *= fast_atof_table[diff];
                f += (float)pl;
            }
            // For backwards compatibility: eat trailing dots, but not trailing commas.
            else if (*cur == '.') {
                ++cur;
            }

            // A major 'E' must be allowed. Necessary for proper reading of some DXF files.
            // Thanks to Zhao Lei to point out that this if() must be outside the if (*c == '.' ..)
            if (*cur == 'e' || *cur == 'E') {
                ++cur;
                bool einv = (*cur == '-');
                if (einv || *cur == '+') {
                    ++cur;
                }

                // The reason float constants are used here is that we've seen cases where compilers
                // would perform such casts on compile-time constants at runtime, which would be
                // bad considering how frequently fast_atoreal_move<float> is called in Assimp.
                float exp = strtoul10_64(cur, &cur);
                if (einv) {
                    exp = -exp;
                }
                f *= (float)Math.Pow(10.0f, exp);
            }

            if (inv) {
                f = -f;
            }
            outValue = f;
            return cur;

        }
        // we write [16] here instead of [] to work around a swig bug
        static double[] fast_atof_table = new double[16] {
        0.0,
        0.1,
        0.01,
        0.001,
        0.0001,
        0.00001,
        0.000001,
        0.0000001,
        0.00000001,
        0.000000001,
        0.0000000001,
        0.00000000001,
        0.000000000001,
        0.0000000000001,
        0.00000000000001,
        0.000000000000001
        };

        // ------------------------------------------------------------------------------------
        // Special version of the function, providing higher accuracy and safety
        // It is mainly used by fast_atof to prevent ugly and unwanted integer overflows.
        // ------------------------------------------------------------------------------------
        static UInt64 strtoul10_64(byte* inValue, byte** outValue = null, int* max_inout = null) {
            int cur = 0;
            UInt64 value = 0;

            if (*inValue < '0' || *inValue > '9') {
                // The string is known to be bad, so don't risk printing the whole thing.
                throw new Exception("The string cannot be converted into a value.");
            }

            for (; ; ) {
                if (*inValue < '0' || *inValue > '9') {
                    break;
                }

                UInt64 new_value = (value * (UInt64)10) + ((UInt64)(*inValue - '0'));

                // numeric overflow, we rely on you
                if (new_value < value) {
                    Import3D.Log.WriteLine("Converting the string into a value resulted inValue overflow.");
                    return 0;
                }

                value = new_value;

                ++inValue;
                ++cur;

                if (max_inout != null && *max_inout == cur) {
                    if (outValue != null) { /* skip to end */
                        while (*inValue >= '0' && *inValue <= '9') {
                            ++inValue;
                        }
                        *outValue = inValue;
                    }

                    return value;
                }
            }
            if (outValue != null) {
                *outValue = inValue;
            }

            if (max_inout != null) {
                *max_inout = cur;
            }

            return value;

        }

        static int ASSIMP_strincmp(byte* s1, string s2, int n) {
            Debug.Assert(null != s1);
            Debug.Assert(null != s2);
            if (n == 0) {
                return 0;
            }

            char c1, c2; int c2Index = 0;
            int p = 0;
            do {
                if (p++ >= n) return 0;
                c1 = char.ToLower((char)*(s1++));
                c2 = char.ToLower(s2[c2Index++]);
            } while (c1 != 0 && (c1 == c2));

            return c1 - c2;
        }
        // -------------------------------------------------------------------------------
        /** @brief Helper function to do platform independent string comparison.
         *
         *  This is required since strincmp() is not consistently available on
         *  all platforms. Some platforms use the '_' prefix, others don't even
         *  have such a function.
         *
         *  @param s1 First input string
         *  @param s2 Second input string
         *  @param n Maximum number of characters to compare
         *  @return 0 if the given strings are identical
         */
        static int ASSIMP_strincmp(byte* s1, byte* s2, int n) {
            Debug.Assert(null != s1);
            Debug.Assert(null != s2);
            if (n == 0) {
                return 0;
            }

            char c1, c2;
            int p = 0;
            do {
                if (p++ >= n) return 0;
                c1 = char.ToLower((char)*(s1++));
                c2 = char.ToLower((char)*(s2++));
            } while (c1 != 0 && (c1 == c2));

            return c1 - c2;
        }
        private static bool IsSpace(byte v) {
            return v == ' ' || v == '\t';
        }

        // ------------------------------------------------------------------------------------
        // signed variant of strtoul10
        // ------------------------------------------------------------------------------------
        static int strtol10(byte* inValue, byte** outValue = null) {
            bool inv = (*inValue == '-');
            if (inv || *inValue == '+') {
                ++inValue;
            }

            int value = strtoul10(inValue, outValue);
            if (inv) {
                if (value < int.MaxValue && value > int.MinValue) {
                    value = -value;
                }
                else {
                    //Log.WriteLine($"Converting the string \"{inValue}\" into an inverted value resulted in overflow.");
                    Log.WriteLine($"Converting the string [] into an inverted value resulted in overflow.");
                }
            }
            return value;
        }
        // ------------------------------------------------------------------------------------
        // Convert a string in decimal format to a number
        // ------------------------------------------------------------------------------------
        static int strtoul10(byte* inValue, byte** outValue = null) {
            int value = 0;

            for (; ; ) {
                if (*inValue < '0' || *inValue > '9') {
                    break;
                }

                value = (value * 10) + (*inValue - '0');
                ++inValue;
            }
            if (outValue != null) {
                *outValue = inValue;
            }
            return value;
        }
    }
}