using System;
using System.Numerics;

namespace bitzhuwei.Compiler {
    /// <summary>
    /// It's an internal bag. You can find anything you need for lexical analyzing.
    /// </summary>
    public partial class LexicalContext {
#if DEBUG
        public IReadOnlyList<string> stArray;
#endif

        /// <summary>
        /// wrapped of source code like *.cpp, *.cs, *.js, *.json, *.3ds, etc.
        /// </summary>
        public readonly ISourceCode sourceCode;
        //public readonly string sourceCode;

        /// <summary>
        /// Lexical analyzer will fill in this list.
        /// </summary>
        public readonly TokenList result;

        /// <summary>
        /// the token that is being constructed...
        /// <para>the initial position is sourceCode[-1] where one char before sourceCode[0]</para>
        /// </summary>
        public readonly AnalyzingToken analyzingToken;// = new(index: -1, start: new LexicalCursor(index: -1, line: 1, column: 0));// sourceCode[-1]

        /// <summary>
        /// It's an internal context. You can find anything you need for lexical analyzing.
        /// </summary>
        /// <param name="sourceCode"></param>
        /// <param name="eVtKinds">1('¥') + kinds of Vt</param>
        internal LexicalContext(
#if DEBUG
            IReadOnlyList<string> stArray,
#endif
            ISourceCode sourceCode, int eVtKinds) {
            ArgumentNullException.ThrowIfNull(sourceCode);
#if DEBUG
            this.stArray = stArray;
#endif
            this.sourceCode = sourceCode;
            this.result = new TokenList(sourceCode);
            //this.union.currentStateId = 0;
            this.analyzingToken = new AnalyzingToken(
#if DEBUG
            stArray,
#endif
            eVtKinds);
        }

        /// <summary>
        /// Index of current char in the <paramref name="sourceCode"/>.
        /// </summary>
        public LexicalCursor cursor =
            new(index: -1, line: 1, column: 0);// one char before sourceCode[0]

        /// <summary>
        /// return true if the last char is lexically analyzed.
        /// </summary>
        public bool EOF => this.cursor.index >= this.sourceCode.Length;
        /// <summary>
        /// Gets current lexically analyzing character.
        /// </summary>
        public char CurrentChar {
            get {
                var index = this.cursor.index;
                var sourceCode = this.sourceCode;
                if (index < sourceCode.Length) {
                    return sourceCode[index];
                }
                else {
                    return '\0'; // '\u0000' or char.MinValue
                }
            }
        }

        /// <summary>
        /// the last token valid for syntax-parse generated during the analyze process.
        /// </summary>
        public Token? lastSyntaxValidToken;
        public const string defaultSignal = "default";
        public string signalCondition = defaultSignal;

        /// <summary>
        /// use this dict to pass user defined data.
        /// </summary>
        public readonly Dictionary<string/*key*/, object> tagDict = new();

        public override string ToString() {
            string appear;
            var c = this.CurrentChar;
            if (char.IsControl(c)) {
                //var x = new char[] {
                //    '\a', '\b', '\c', '\d', '\e', '\f', '\g',
                //    '\h', '\i', '\j', '\k', '\l', '\m', '\n',
                //    '\o', '\p', '\q', '\r', '\s', '\t',
                //    '\u', '\v', '\w', '\x', '\y', '\z',
                //    '\A', '\B', '\C', '\D', '\E', '\F', '\G',
                //    '\H', '\I', '\J', '\K', '\L', '\M', '\N',
                //    '\O', '\P', '\Q', '\R', '\S', '\T',
                //    '\U', '\V', '\W', '\X', '\Y', '\Z',
                //    '\0', '\1', '\2', '\3', '\4', '\5',
                //};
                switch (c) {
                case '\0': appear = @"\0"; break;
                case '\a': appear = @"\a"; break;
                case '\b': appear = @"\b"; break;
                case '\f': appear = @"\f"; break;
                case '\n': appear = @"\n"; break;
                case '\r': appear = @"\r"; break;
                case '\t': appear = @"\t"; break;
                case '\v': appear = @"\v"; break;
                default: appear = string.Format("\\u{0:X4}", (int)c); break;
                }
            }
            else {
                appear = $"{c}";
            }

            var token = this.analyzingToken;
            var startIndex = token.start.index;
            int endIndex = startIndex;
            for (int i = 0; i < token.ends.Length; i++) {
                var index = token.ends[i].index;
                if (endIndex < index) { endIndex = index; }
            }
            var shortLength = endIndex - startIndex + 1;
            if (shortLength > 20) { shortLength = 20; }
            var value = this.sourceCode.Substring(startIndex, shortLength);
#if DEBUG
            if (token.kind >= 0) {
                return $"'{appear}' ☛ {stArray[token.kind]} {value} {token.start}";
            }
            else {
                return $"'{appear}' ☛ {token.kind} {value} {token.start}";
            }
#else
            return $"'{appear}' ☛ {token.kind} {value} {token.start}";
#endif
        }
    }

}
