using System;

namespace bitzhuwei.Compiler {
    /// <summary>
    /// Lexically analyze source code and return a list of <see cref="Token"/>.
    /// </summary>
    public partial class LexicalAnalyzer {

        private readonly IAnalyzer _analyzer;
        interface IAnalyzer {
            public TokenList Analyze(ISourceCode sourceCode);

            /// <summary>
            /// Begin/Continue/Finish
            /// </summary>
            public TokenList Begin();
            /// <summary>
            /// continue to analyze lines of source code and return <see cref="Token"/>s
            /// </summary>
            /// <param name="lines">1/more lines</param>
            public TokenList Continue(string lines);
            /// <summary>
            /// deal with '\0'
            /// </summary>
            /// <returns></returns>
            public TokenList Finish();
        }

        public TokenList Analyze(ISourceCode sourceCode) {
            return this._analyzer.Analyze(sourceCode);
        }

        //public static Dictionary<Acts, int> acts2Refered = new();

        /// <summary>
        /// begin/continue/finish
        /// </summary>
        /// <returns></returns>
        public TokenList Begin() {
            return this._analyzer.Begin();
        }
        /// <summary>
        /// continue to analyze lines of source code and return <see cref="Token"/>s
        /// </summary>
        /// <param name="lines">1/more lines</param>
        /// <returns></returns>
        public TokenList Continue(string lines) {
            return this._analyzer.Continue(lines);
        }
        /// <summary>
        /// deal with '\0'
        /// </summary>
        /// <returns></returns>
        public TokenList Finish() {
            return this._analyzer.Finish();
        }

    }

}
