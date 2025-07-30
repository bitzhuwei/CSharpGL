using System;
using bitzhuwei.Compiler;

namespace bitzhuwei.PreDirectiveFormat {
    /// <summary>
    /// lexical analyze, syntax parse and extract.
    /// </summary>
    public partial class CompilerPreDirective {
#if ! noTableDFA
        private static readonly LexicalScripts lexicalScripts = new(CompilerPreDirective.BeginToken,
            CompilerPreDirective.ExtendToken, CompilerPreDirective.ExtendToken2, CompilerPreDirective.ExtendToken3,
            CompilerPreDirective.AcceptToken, CompilerPreDirective.AcceptToken2, CompilerPreDirective.AcceptToken3);
#endif


        private static readonly LRNode endTokenNode;

        private static readonly ElseIf2[] omitChars;
        private static readonly ElseIf2[][] lexiStates;
        public static readonly IReadOnlyList<Regulation> regulations;
        private static readonly LRParseState[] syntaxStates;
#if DEBUG
        public static readonly IReadOnlyList<string> stArray;
#endif

        static CompilerPreDirective() {
            (CompilerPreDirective.omitChars, CompilerPreDirective.lexiStates) = BinaryFileReader.ReadLexiInfo2(
                @"PreDirective.gen\PreDirective.LexiTable.gen.bin");

            CompilerPreDirective.regulations = BinaryFileReader.ReadRegulations(
                @"PreDirective.gen\PreDirective.Regulations.gen.bin");

            CompilerPreDirective.syntaxStates = BinaryFileReader.ReadLRParseStates(
                @"PreDirective.gen\PreDirective.Table.LALR(1).gen.bin", regulations);

#if DEBUG
            CompilerPreDirective.stArray = BinaryFileReader.ReadstArray(
                @"PreDirective.gen\PreDirective.stArray.gen.bin");
#endif

            CompilerPreDirective.endTokenNode = new(
#if DEBUG
                CompilerPreDirective.stArray,
#endif
                new Token(index: -1, kind: st.@终,
#if DEBUG
                    CompilerPreDirective.stArray,
#endif
                    start: new(), end: new(), value: "[EOT]"));

            InitializeExtractorItems();
        }

        /// <summary>
        /// lexical analyze, syntax parse and extract.
        /// </summary>
        public CompilerPreDirective() { }

        /// <summary>
        /// lexical analyze source code to get <see cref="Token"/>s.
        /// </summary>
        private readonly LexicalAnalyzer lexiAnalyzer = new(
#if ! noTableDFA
#if DEBUG
            CompilerPreDirective.stArray,
#endif
            st.eVtKinds,
            CompilerPreDirective.lexiStates,
            CompilerPreDirective.omitChars,
            CompilerPreDirective.lexicalScripts);
#else
            CompilerPreDirective.stArray, CompilerPreDirective.lexicalState0, st.eVtKinds);
#endif

        /// <summary>
        /// <see cref="Token"/> list to syntax tree(<see cref="LRNode"/>).
        /// </summary>
        private readonly LRSyntaxParser syntaxParser = new(
#if DEBUG
            CompilerPreDirective.stArray,
#endif
            initialState: CompilerPreDirective.syntaxStates[0],
            EOT: new Token(index: -1, st.@终,
#if DEBUG
            CompilerPreDirective.stArray,
#endif
            start: new LexicalCursor(), end: new LexicalCursor(), value: "[EOT]"),
            blockComment: -3/* "none无" */,
            inlineComment: CompilerPreDirective.st.@inlineComment行);

        /// <summary>
        /// 
        /// </summary>
        private readonly TExtractor<PreDirective> @preDirectiveExtractor = new(
            extractorItems: CompilerPreDirective.@preDirectiveExtractorItems,
            EOT: endTokenNode, VtKinds: st.eVtKinds - 1, VtExtractorMode.SingleFixed);

        /// <summary>
        /// lexically analyze <paramref name="sourceCode"/> and return token list.
        /// </summary>
        /// <param name="sourceCode"></param>
        /// <returns></returns>
        public TokenList Analyze(ISourceCode sourceCode) {
            var tokenList = this.lexiAnalyzer.Analyze(sourceCode);
            return tokenList;
        }

        /// <summary>
        /// lexically analyze <paramref name="sourceCode"/> and return token list.
        /// </summary>
        /// <param name="sourceCode"></param>
        /// <returns></returns>
        public TokenList Analyze(string sourceCode) {
            var wrap = new SingleString(sourceCode);
            var tokenList = this.lexiAnalyzer.Analyze(wrap);
            return tokenList;
        }
        /// <summary>
        /// Begin/Continue/Finish
        /// </summary>
        /// <returns></returns>
        public IReadOnlyList<Token> BeginAnalyze() {
            return this.lexiAnalyzer.Begin();
        }
        /// <summary>
        /// continue to analyze lines of source code and return <see cref="Token"/>s
        /// </summary>
        /// <param name="lines">1/more lines</param>
        /// <returns></returns>
        public IReadOnlyList<Token> ContinueAnalyze(string lines) {
            return this.lexiAnalyzer.Continue(lines);
        }
        /// <summary>
        /// deal with '\0'
        /// </summary>
        /// <returns></returns>
        public IReadOnlyList<Token> FinishAnalyze() {
            return this.lexiAnalyzer.Finish();
        }

        /// <summary>
        /// parse specified <paramref name="tokenList"/> to get syntax tree.
        /// </summary>
        /// <param name="tokenList"></param>
        /// <returns></returns>
        public SyntaxTree Parse(IReadOnlyList<Token> tokenList) {
            var syntaxTree = this.syntaxParser.Parse(tokenList);
            return syntaxTree;
        }
        /// <summary>
        /// Begin/Continue/Finish
        /// <para>call <see cref="Continue"/> after the returned <see cref="List{Token}"/> were appended.</para>
        /// </summary>
        /// <param name="tokenList">add tokens to this list and then call <see cref="Continue"/></param>
        /// <returns></returns>
        public void BeginParse(List<Token> tokenList) {
            this.syntaxParser.Begin(tokenList);
        }
        /// <summary>
        /// continue to parse the <see cref="List{Token}"/> returned by <see cref="Begin"/> after it were appended.
        /// </summary>
        /// <returns></returns>
        public SyntaxTree ContinueParse() {
            return this.syntaxParser.Continue();
        }
        /// <summary>
        /// deal with the <see cref="LRParseContext.EOT"/> token.
        /// </summary>
        /// <returns></returns>
        public SyntaxTree FinishParse() {
            return this.syntaxParser.Finish();
        }

        /// Extract a <see cref="PreDirective"/> object from syntax tree.
        /// <para>Post-order traversing.</para>
        /// </summary>
        /// <param name="tree">the syntax tree from syntax-parse.</param>
        /// <param name="tokens">the token list corresponds to <paramref name="rootNode"/>.</param>
        /// <param name="sourceCode">the original source code corresponds to <paramref name="tokens"/>.</param>
        /// <param name="tag">add <paramref name="tag"/>,<paramref name="obj"/> to <see cref="TContext{T}.tagDict"/></param>
        /// <param name="obj">add <paramref name="tag"/>,<paramref name="obj"/> to <see cref="TContext{T}.tagDict"/></param>
        /// <returns></returns>
        public PreDirective? Extract(SyntaxTree tree, IReadOnlyList<Token> tokens, ISourceCode sourceCode, string? tag = null, object? obj = null) {
            var @preDirective = this.@preDirectiveExtractor.Extract(
                tree, tokens, sourceCode, tag, obj);
            return @preDirective;
        }
        /// Extract a <see cref="PreDirective"/> object from syntax tree.
        /// <para>Post-order traversing.</para>
        /// </summary>
        /// <param name="tree">the syntax tree from syntax-parse.</param>
        /// <param name="tokens">the token list corresponds to <paramref name="rootNode"/>.</param>
        /// <param name="sourceCode">the original source code corresponds to <paramref name="tokens"/>.</param>
        /// <param name="tag">add <paramref name="tag"/>,<paramref name="obj"/> to <see cref="TContext{T}.tagDict"/></param>
        /// <param name="obj">add <paramref name="tag"/>,<paramref name="obj"/> to <see cref="TContext{T}.tagDict"/></param>
        /// <returns></returns>
        public PreDirective? Extract(SyntaxTree tree, IReadOnlyList<Token> tokens, string sourceCode, string? tag = null, object? obj = null) {
            return Extract(tree, tokens, new SingleString(sourceCode), tag, obj);
        }

    }

}
