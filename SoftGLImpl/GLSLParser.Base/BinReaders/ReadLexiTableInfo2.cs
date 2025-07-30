using System.IO.IsolatedStorage;
using System.Numerics;
using System.Reflection.Metadata;
using System.Reflection.PortableExecutable;

namespace bitzhuwei.Compiler {
    public partial class BinaryFileReader {
        /// <summary>
        /// read <see cref="LRParseState"/>[] from binary file.
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="regulations"></param>
        /// <returns></returns>
        public static (ElseIf2[] omitChars, ElseIf2[][] lexiTable) ReadLexiInfo2(string filename) {
            using (var fs = new FileStream(filename, FileMode.Open, FileAccess.Read))
            using (var reader = new BinaryReader(fs)) {
                {
                    int sign = reader.ReadInt32();
                    if (sign != 1) { throw new Exception("only valid for sign(1) which indicates ElseIf2"); }
                }
                ElseIf2[] omitChars;
                {
                    int count = reader.ReadInt32();
                    omitChars = new ElseIf2[count];
                    for (int i = 0; i < count; i++) {
                        omitChars[i] = ReadElseIf2_Vt3(reader);
                    }
                }
                int[][] VtsArray;
                {
                    int count = reader.ReadInt32();
                    VtsArray = new int[count][];
                    for (int i = 0; i < count; i++) {
                        int length = reader.ReadInt32();
                        var array = new int[length];
                        for (int j = 0; j < length; j++) { array[j] = reader.ReadInt32(); }
                        VtsArray[i] = array;
                    }
                }
                IfVt[] ifVtArray;
                {
                    int count = reader.ReadInt32();
                    ifVtArray = new IfVt[count];
                    for (int i = 0; i < count; i++) { ifVtArray[i] = ReadIfVt(reader); }
                }
                IfVt[][] ifVtsArray;
                {
                    int count = reader.ReadInt32();
                    ifVtsArray = new IfVt[count][];
                    for (int i = 0; i < count; i++) {
                        int length = reader.ReadInt32();
                        var array = new IfVt[length];
                        for (int j = 0; j < length; j++) {
                            int index_preVt = reader.ReadInt32();
                            if (index_preVt < 0) { array[j] = ifVtArray[-index_preVt - 1]; }
                            else { array[j] = ReadIfVt(reader, index_preVt); }
                        }
                        ifVtsArray[i] = array;
                    }
                }
                ElseIf2[] segments;
                {
                    int count = reader.ReadInt32();
                    segments = new ElseIf2[count];
                    for (int i = 0; i < count; i++) {
                        segments[i] = ReadSegment(reader, VtsArray, ifVtArray, ifVtsArray);
                    }
                }
                ElseIf2[][] lexiTable;
                {
                    int count = reader.ReadInt32();
                    lexiTable = new ElseIf2[count][];
                    for (int i = 0; i < count; i++) {
                        int length = reader.ReadInt32();
                        var array = new ElseIf2[length];
                        for (int j = 0; j < length; j++) {
                            int index_header = reader.ReadInt32();
                            if (index_header < 0) { array[j] = segments[-index_header - 1]; }
                            else { array[j] = ReadSegment(reader, index_header, VtsArray, ifVtArray, ifVtsArray); }
                        }
                        lexiTable[i] = array;
                    }
                }
                return (omitChars, lexiTable);
            }
        }

        private static ElseIf2 ReadSegment(BinaryReader reader, int[][] VtsArray, IfVt[] ifVtArray, IfVt[][] ifVtsArray) {
            int header = reader.ReadInt32();
            return ReadSegment(reader, header, VtsArray, ifVtArray, ifVtsArray);
        }
        private static ElseIf2 ReadSegment(BinaryReader reader, int header, int[][] VtsArray, IfVt[] ifVtArray, IfVt[][] ifVtsArray) {
            ElseIf2 result;
            switch (header) {
            case 3: result = ReadElseIf2_Vt3(reader); break;
            case 4: result = ReadElseIf2_Vts4(reader); break;
            case 5: result = ReadElseIf2_Vts5(reader, VtsArray); break;
            case 6: result = ReadElseIf2_IfVts6(reader); break;
            case 7: result = ReadElseIf2_IfVts7(reader, ifVtArray); break;
            case 8: result = ReadElseIf2_IfVts8(reader, ifVtsArray); break;
            default: throw new NotImplementedException();
            }
            return result;
        }
    }

}

