using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpFont
{
    struct InstructionStream
    {
        byte[] instructions;
        int ip;

        //public bool IsValid => instructions != null;
        public bool IsValid
        { get { return instructions != null; } }
        public bool Done
        { get { return ip >= instructions.Length; } }

        public InstructionStream(byte[] instructions)
        {
            this.instructions = instructions;
            ip = 0;
        }

        public int NextByte()
        {
            if (Done)
                throw new InvalidFontException();
            return instructions[ip++];
        }

        //public OpCode NextOpCode () => (OpCode)NextByte();
        public OpCode NextOpCode()
        {
            return (OpCode)NextByte();
        }
        //public int NextWord () => (short)(ushort)(NextByte() << 8 | NextByte());
        public int NextWord()
        {
            return (short)(ushort)(NextByte() << 8 | NextByte());
        }
        //public void Jump (int offset) => ip += offset;
        public void Jump(int offset)
        {
            ip += offset;
        }
    }
}
