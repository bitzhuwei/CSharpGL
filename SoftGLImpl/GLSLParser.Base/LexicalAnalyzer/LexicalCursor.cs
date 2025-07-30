using System;

namespace bitzhuwei.Compiler {
    public struct LexicalCursor {
        /// <summary>
        /// index(start from 0) of some char in the <paramref name="sourceCode"/>.
        /// </summary>
        public int index;
        /// <summary>
        /// line number(start from 1).
        /// </summary>
        public int line;
        /// <summary>
        /// column number(start from 1).
        /// </summary>
        public int column;

        /// <summary>
        /// initial state: waiting for a MoveForward() to point to the first char in source code.
        /// <para>one char before sourceCode[0]</para>
        /// </summary>
        public LexicalCursor() {
            this.index = -1;
            this.line = 1;
            this.column = 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index">index(start from 0) of some char in the <paramref name="sourceCode"/>.</param>
        /// <param name="line">line number(start from 1).</param>
        /// <param name="column">column number(start from 1).</param>
        public LexicalCursor(int index, int line, int column) {
            this.index = index;
            this.line = line;
            this.column = column;
        }

        public void Print(System.IO.TextWriter writer) {
            writer.Write($"ln:{line}, col:{column} s[{index}]");
        }

        public override string ToString() {
            return $"ln:{line}, col:{column} s[{index}]";
            //return $"ln:{line}, col:{column}, i:{index}";
        }
    }
}
