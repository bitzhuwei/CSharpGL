

namespace bitzhuwei.Compiler {
    /// <summary>
    /// for <see cref="IAnalyzer.Begin"/>, <see cref="IAnalyzer.Continue(string)"/>, <see cref="IAnalyzer.Finish"/>
    /// </summary>
    partial class BCFminiDFAContext {
        public readonly LexicalContext context;
        public bool firstLines = true;
        //public readonly AccumulatedTokens accuTokens = new();
        public readonly CurrentStateWrap wrap;

        public BCFminiDFAContext(
#if DEBUG
            IReadOnlyList<string> stArray,
#endif
            int eVtKinds,
            Action<LexicalContext, char, CurrentStateWrap> initialState) {
            this.context = new LexicalContext(
#if DEBUG
                 stArray,
#endif
                 new SourceCode(), eVtKinds);
            this.wrap = new CurrentStateWrap(initialState);
        }

        public override string ToString() {
            return $"{context}";
        }
    }

}
