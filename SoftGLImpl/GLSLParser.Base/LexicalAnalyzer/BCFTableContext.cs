

namespace bitzhuwei.Compiler {
    /// <summary>
    /// for <see cref="IAnalyzer.Begin"/>, <see cref="IAnalyzer.Continue(string)"/>, <see cref="IAnalyzer.Finish"/>
    /// </summary>
    partial class BCFTableContext {
        public readonly LexicalContext context;
        public bool firstLines = true;
        //public readonly AccumulatedTokens accuTokens = new();
        public int currentStateId = 0;

        /// <summary>
        /// for <see cref="IAnalyzer.Begin"/>, <see cref="IAnalyzer.Continue(string)"/>, <see cref="IAnalyzer.Finish"/>
        /// </summary>
        /// <param name="context"></param>
        public BCFTableContext(
#if DEBUG
            IReadOnlyList<string> stArray,
#endif
            int eVtKinds) {

            this.context = new LexicalContext(
#if DEBUG
            stArray,
#endif
            new SourceCode(), eVtKinds);
        }
        public override string ToString() {
            return $"{context}";
        }
    }

}
