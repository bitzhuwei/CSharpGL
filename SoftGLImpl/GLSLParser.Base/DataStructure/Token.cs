using System;

namespace bitzhuwei.Compiler {
    /// <summary>
    /// Token from lexical analyzing.
    /// </summary>
    public class Token {
        /// <summary>
        /// index in the <see cref="TokenList"/>
        /// </summary>
        public readonly int index;
        /// <summary>
        /// token kind in lexical analyzing
        /// <para>-1 means error kind.</para>
        /// </summary>
        public readonly int kind;

        public static class Kinds {
            public const int error = -1;
            public const int blockComment = -2;
            public const int inlineComment = -3;
            /// <summary>
            /// in the process of contructing a token
            /// </summary>
            public const int NotYet = -4;// int.MinValue;// "not⌕yet";
            public const int imaginary = -5;
        }

#if DEBUG
        public readonly IReadOnlyList<string> stArray;
#endif
        /// <summary>
        /// position of the first char of this <see cref="Token"/>
        /// </summary>
        public readonly LexicalCursor start;

        /// <summary>
        /// position of the last char of this <see cref="Token"/>
        /// </summary>
        public readonly LexicalCursor end;

        /// <summary>
        /// value in plain source code
        /// </summary>
        public readonly string value;

#if DEBUG
        internal static readonly string[] EmptyArray = new string[0];
#endif
        //private const string strEmpty = "ε";
        /// <summary>
        /// TokenList[-1]
        /// </summary>
        internal static readonly Token noToken = new Token(index: -1, kind: Token.Kinds.error,
#if DEBUG
            EmptyArray,
#endif
            start: new LexicalCursor(index: -1, line: 1, column: 0),
            end: new LexicalCursor(index: -1, line: 1, column: 0),
            value: "");
        internal Token(
#if DEBUG
            IReadOnlyList<string> stArray,
#endif
            AnalyzingToken analyzingToken,
            LexicalCursor end)
            : this(analyzingToken.index, analyzingToken.kind,
#if DEBUG
                  stArray,
#endif
                  analyzingToken.start, end, analyzingToken.value) { }

        ///// <summary>
        ///// Gets tokenCount of <paramref name="Content"/>
        ///// </summary>
        //public int Length { get { return this.value.Length; } }


        /// <summary>
        /// Token from lexical analyzing.
        /// </summary>
        /// <param name="index">index in the <see cref="TokenList"/></param>
        /// <param name="kind">token kind in lexical analyzing<para><see cref="Token.Kinds.error"/>(-1) means error kind</para></param>
        /// <param name="start">position of the first char of this <see cref="Token"/></param>
        /// <param name="end">position of the last char of this <see cref="Token"/></param>
        /// <param name="value">value in plain source code</param>
        public Token(int index, int kind,
#if DEBUG
            IReadOnlyList<string> stArray,
#endif
            LexicalCursor start, LexicalCursor end, string value) {
            this.index = index;
            this.kind = kind;
#if DEBUG
            this.stArray = stArray;
#endif
            this.start = start;
            this.end = end;
            this.value = value;
        }

        /// <summary>
        /// print:
        /// <para>T[index]=kind value [start, L:value.Length]</para>
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="stArray"></param>
        public void Print(System.IO.TextWriter writer, IReadOnlyList<string>? stArray = null) {
            string strType;
            if (stArray != null && kind >= 0) { strType = stArray[kind]; }
            else { strType = kind.ToString(); }
            writer.Write($"T[{index}]={strType} {value} [");
            start.Print(writer);
            writer.Write($", L:{value.Length}]");
        }

        public string shortValue(int maxLength = 20) {
            var shortValue = value.Length > maxLength ? value.Substring(0, maxLength) + "✨" : value;
            return shortValue;
        }

        public override string ToString() {
#if DEBUG
            if (kind >= 0) {
                return ($"T[{index}]={stArray[kind]} {this.shortValue()} [{start}]");
            }
            else {
                return ($"T[{index}]={kind} {this.shortValue()} [{start}]");
            }
#else
            return ($"T[{index}]={kind} {this.shortValue()} [{start}]");
#endif
        }
    }
}
