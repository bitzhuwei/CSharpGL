using System;

namespace bitzhuwei.Compiler {
    /// <summary>
    /// information of he next <see cref="Token"/>Token during lexical analyzing.
    /// </summary>
    public class AnalyzingToken {
#if DEBUG
        private readonly IReadOnlyList<string> stArray;
#endif
        /// <summary>
        /// token kind in lexical analyzing.
        /// </summary>
        public int kind;
        /// <summary>
        /// index in the <see cref="TokenList"/>
        /// </summary>
        public int index;
        /// <summary>
        /// position of the first char of this <see cref="Token"/>
        /// </summary>
        public LexicalCursor start;

        /*
         * if  regex/postregex         ok
         * and r e g e x 2 /postregex2 ok
         * we should accept the first one, but the token ends at r e g e x 2 now.
         * this means we have to record end positions for every possible Vt.
         */
        /// <summary>
        /// position of the last char of this <see cref="Token"/>
        /// </summary>
        public LexicalCursor[] ends;

        /// <summary>
        /// content in source code.
        /// </summary>
        public string value = string.Empty;

        /// <summary>
        /// information of he next <see cref="Token"/>Token during lexical analyzing.
        /// </summary>
        /// <param name="eVtKinds">1('¥') + kinds of Vt</param>
        internal AnalyzingToken(
#if DEBUG
            IReadOnlyList<string> stArray,
#endif
            int eVtKinds) {
#if DEBUG
            this.stArray = stArray;
#endif
            // this.kind must NOT be AnalyzingToken.NotYet
            // because the initial state is a state
            // where some imaginary Token is dumped
            // and we are going to analyze the next token(the first token in source code).
            this.kind = Token.Kinds.imaginary;
            this.index = -1;
            this.start = new LexicalCursor(index: -1, line: 1, column: 0);//sourceCode[-1]
            this.ends = new LexicalCursor[eVtKinds];
        }

        public Token Dump(
#if DEBUG
            IReadOnlyList<string> stArray,
#endif
            LexicalCursor end) {
            return new Token(
#if DEBUG
                stArray,
#endif
            this, end);
        }

        public void Reset(int index, LexicalCursor start) {
            // indicates that we are now dealing with a new token.
            this.kind = Token.Kinds.NotYet;

            this.index = index;
            this.start = start;
            //Array.Clear(this.ends, 0, this.ends.Length); // no need
        }

        public void Print(System.IO.TextWriter writer, IReadOnlyList<string>? stArray) {
            if (stArray != null && kind >= 0) {
                writer.Write($"{stArray[kind]} {value} [");
            }
            else {
                writer.Write($"{kind} {value} [");
            }
            start.Print(writer);
            writer.Write($"], L:{value.Length}]");
        }

        public override string ToString() {
#if DEBUG
            if (kind >= 0) {
                return ($"{stArray[kind]} {value} [{start}, L:{value.Length}]");
            }
            else {
                return ($"{kind} {value} [{start}, L:{value.Length}]");
            }
#else
            return ($"{kind} {value} [{start}, L:{value.Length}]");
#endif
        }
    }
}
