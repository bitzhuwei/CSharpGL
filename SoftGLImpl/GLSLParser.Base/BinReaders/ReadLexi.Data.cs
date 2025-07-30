using System.IO.IsolatedStorage;
using System.Numerics;
using System.Reflection.Metadata;
using System.Reflection.PortableExecutable;

namespace bitzhuwei.Compiler {
    public partial class BinaryFileReader {

        private static ElseIf ReadElseIf(BinaryReader reader) {
            int nextStateId = reader.ReadInt32();
            return ReadElseIf(reader, nextStateId);
        }
        private static ElseIf ReadElseIf(BinaryReader reader, int nextStateId) {
            char min = reader.ReadChar();
            char max = reader.ReadChar();
            var scripts = (Acts)reader.ReadByte();
            int Vt = reader.ReadInt32();
            return new ElseIf(min, max, nextStateId, scripts, Vt);
        }
        private static IfVt ReadIfVt(BinaryReader reader) {
            int preVt = reader.ReadInt32();
            return ReadIfVt(reader, preVt);
        }
        private static IfVt ReadIfVt(BinaryReader reader, int preVt) {
            string signalCondition = reader.ReadString();
            int Vt = reader.ReadInt32();
            int sign = reader.ReadInt32();
            if (sign == 1) {
                string nextSignal = reader.ReadString();
                return new IfVt(signalCondition, preVt, Vt, nextSignal);
            }
            else {
                return new IfVt(signalCondition, preVt, Vt);
            }
        }

        static ElseIf2 ReadElseIf2_Vt3(BinaryReader reader) {
            int nextStateId = reader.ReadInt32();
            return ReadElseIf2_Vt3(reader, nextStateId);
        }
        static ElseIf2 ReadElseIf2_Vt3(BinaryReader reader, int nextStateId) {
            char min = reader.ReadChar();
            char max = reader.ReadChar();
            var scripts = (Acts)reader.ReadByte();
            int Vt = reader.ReadInt32();
            return new ElseIf2(min, max, nextStateId, scripts, Vt);
        }

        static ElseIf2 ReadElseIf2_Vts4(BinaryReader reader) {
            int nextStateId = reader.ReadInt32();
            return ReadElseIf2_Vts4(reader, nextStateId);
        }
        static ElseIf2 ReadElseIf2_Vts4(BinaryReader reader, int nextStateId) {
            char min = reader.ReadChar();
            char max = reader.ReadChar();
            var scripts = (Acts)reader.ReadByte();
            int VtsLength = reader.ReadInt32();
            var Vts = new int[VtsLength];
            for (int j = 0; j < VtsLength; j++) { Vts[j] = reader.ReadInt32(); }
            return new ElseIf2(min, max, nextStateId, scripts, Vts);
        }

        static ElseIf2 ReadElseIf2_Vts5(BinaryReader reader, int[][] VtsArray) {
            int nextStateId = reader.ReadInt32();
            return ReadElseIf2_Vts5(reader, nextStateId, VtsArray);
        }
        static ElseIf2 ReadElseIf2_Vts5(BinaryReader reader, int nextStateId, int[][] VtsArray) {
            char min = reader.ReadChar();
            char max = reader.ReadChar();
            var scripts = (Acts)reader.ReadByte();
            int vtsIndex = reader.ReadInt32();
            return new ElseIf2(min, max, nextStateId, scripts, VtsArray[vtsIndex]);
        }

        static ElseIf2 ReadElseIf2_IfVts6(BinaryReader reader) {
            int nextStateId = reader.ReadInt32();
            return ReadElseIf2_IfVts6(reader, nextStateId);
        }
        private static ElseIf2 ReadElseIf2_IfVts6(BinaryReader reader, int nextStateId) {
            char min = reader.ReadChar();
            char max = reader.ReadChar();
            var scripts = (Acts)reader.ReadByte();
            int ifVtsLength = reader.ReadInt32();
            var ifVts = new IfVt[ifVtsLength];
            for (int j = 0; j < ifVtsLength; j++) { ifVts[j] = ReadIfVt(reader); }
            return new ElseIf2(min, max, nextStateId, scripts, ifVts);
        }

        private static ElseIf2 ReadElseIf2_IfVts7(BinaryReader reader, IfVt[] ifVtsArray) {
            int nextStateId = reader.ReadInt32();
            return ReadElseIf2_IfVts7(reader, nextStateId, ifVtsArray);
        }
        private static ElseIf2 ReadElseIf2_IfVts7(BinaryReader reader, int nextStateId, IfVt[] ifVtArray) {
            char min = reader.ReadChar();
            char max = reader.ReadChar();
            var scripts = (Acts)reader.ReadByte();
            int ifVtsLength = reader.ReadInt32();
            var ifVts = new IfVt[ifVtsLength];
            for (int j = 0; j < ifVtsLength; j++) {
                int index_preVt = reader.ReadInt32();
                if (index_preVt < 0) { ifVts[j] = ifVtArray[-index_preVt - 1]; }
                else { ifVts[j] = ReadIfVt(reader, preVt: index_preVt); }
            }
            return new ElseIf2(min, max, nextStateId, scripts, ifVts);
        }
        private static ElseIf2 ReadElseIf2_IfVts8(BinaryReader reader, IfVt[][] ifVtsArray) {
            int nextStateId = reader.ReadInt32();
            return ReadElseIf2_IfVts8(reader, nextStateId, ifVtsArray);
        }
        private static ElseIf2 ReadElseIf2_IfVts8(BinaryReader reader, int nextStateId, IfVt[][] ifVtsArray) {
            char min = reader.ReadChar();
            char max = reader.ReadChar();
            var scripts = (Acts)reader.ReadByte();
            int ifVtsIndex = reader.ReadInt32();
            return new ElseIf2(min, max, nextStateId, scripts, ifVtsArray[ifVtsIndex]);
        }
    }

}

