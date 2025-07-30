using System.Reflection.PortableExecutable;

namespace bitzhuwei.Compiler {
    public partial class BinaryFileReader {
        /// <summary>
        /// read <see cref="LRParseState"/>[] from binary file.
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="regulations"></param>
        /// <returns></returns>
        public static (ElseIf[] omitChars, ElseIf[][] lexiTable) ReadLexiInfo(string filename) {
            using (var fs = new FileStream(filename, FileMode.Open, FileAccess.Read))
            using (var reader = new BinaryReader(fs)) {
                {
                    int sign = reader.ReadInt32();
                    if (sign != 0) { throw new Exception("only valid for sign(0) which indicates ElseIf"); }
                }
                ElseIf[] omitChars;
                {
                    int count = reader.ReadInt32();
                    omitChars = new ElseIf[count];
                    for (int i = 0; i < count; i++) {
                        omitChars[i] = ReadElseIf(reader);
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
                            else { array[j] = ReadIfVt(reader, preVt: index_preVt); }
                        }
                        ifVtsArray[i] = array;
                    }
                }
                ElseIf[] segments;
                {
                    int count = reader.ReadInt32();
                    segments = new ElseIf[count];
                    for (int i = 0; i < count; i++) { segments[i] = ReadElseIf(reader); }
                }
                ElseIf[][] lexiTable;
                {
                    int count = reader.ReadInt32();
                    lexiTable = new ElseIf[count][];
                    for (int i = 0; i < count; i++) {
                        int length = reader.ReadInt32();
                        var array = new ElseIf[length];
                        for (int j = 0; j < length; j++) {
                            int index_nextStateId = reader.ReadInt32();
                            if (index_nextStateId < 0) { array[j] = segments[-index_nextStateId - 1]; }
                            else { array[j] = ReadElseIf(reader, nextStateId: index_nextStateId); }
                        }
                        lexiTable[i] = array;
                    }
                }
                return (omitChars, lexiTable);
            }
        }

    }
}

