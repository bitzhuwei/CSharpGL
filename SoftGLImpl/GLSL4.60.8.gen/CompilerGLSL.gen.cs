using System;
using bitzhuwei.Compiler;

namespace bitzhuwei.GLSLFormat {
    /// <summary>
    /// lexical analyze, syntax parse and extract.
    /// </summary>
    public partial class CompilerGLSL {
#if ! noTableDFA
        private static readonly LexicalScripts lexicalScripts = new(CompilerGLSL.BeginToken,
            CompilerGLSL.ExtendToken, CompilerGLSL.ExtendToken2, CompilerGLSL.ExtendToken3,
            CompilerGLSL.AcceptToken, CompilerGLSL.AcceptToken2, CompilerGLSL.AcceptToken3);
#endif


        private static readonly LRNode endTokenNode;

        private static readonly ElseIf2[] omitChars;
        private static readonly ElseIf2[][] lexiStates;
        public static readonly IReadOnlyList<Regulation> regulations;
        private static readonly LRParseState[] syntaxStates;
#if DEBUG
        public static readonly IReadOnlyList<string> stArray;
#endif

        static CompilerGLSL() {
            (CompilerGLSL.omitChars, CompilerGLSL.lexiStates) = BinaryFileReader.ReadLexiInfo2(
                @"GLSL4.60.8.gen\GLSL.LexiTable.gen.bin");

            CompilerGLSL.regulations = BinaryFileReader.ReadRegulations(
                @"GLSL4.60.8.gen\GLSL.Regulations.gen.bin");

            CompilerGLSL.syntaxStates = BinaryFileReader.ReadLRParseStates(
                @"GLSL4.60.8.gen\GLSL.Table.LALR(1).gen.bin", regulations);

#if DEBUG
            CompilerGLSL.stArray = BinaryFileReader.ReadstArray(
                @"GLSL4.60.8.gen\GLSL.stArray.gen.bin");
#endif

            CompilerGLSL.endTokenNode = new(
#if DEBUG
                CompilerGLSL.stArray,
#endif
                new Token(index: -1, kind: st.@终,
#if DEBUG
                    CompilerGLSL.stArray,
#endif
                    start: new(), end: new(), value: "[EOT]"));

            InitializeExtractorItems();
        }

        /// <summary>
        /// lexical analyze, syntax parse and extract.
        /// </summary>
        public CompilerGLSL() { }

        /// <summary>
        /// lexical analyze source code to get <see cref="Token"/>s.
        /// </summary>
        private readonly LexicalAnalyzer lexiAnalyzer = new(
#if ! noTableDFA
#if DEBUG
            CompilerGLSL.stArray,
#endif
            st.eVtKinds,
            CompilerGLSL.lexiStates,
            CompilerGLSL.omitChars,
            CompilerGLSL.lexicalScripts);
#else
            CompilerGLSL.stArray, CompilerGLSL.lexicalState0, st.eVtKinds);
#endif

        /// <summary>
        /// <see cref="Token"/> list to syntax tree(<see cref="LRNode"/>).
        /// </summary>
        private readonly LRSyntaxParser syntaxParser = new(
#if DEBUG
            CompilerGLSL.stArray,
#endif
            initialState: CompilerGLSL.syntaxStates[0],
            EOT: new Token(index: -1, st.@终,
#if DEBUG
            CompilerGLSL.stArray,
#endif
            start: new LexicalCursor(), end: new LexicalCursor(), value: "[EOT]"),
            blockComment: CompilerGLSL.st.@blockComment块,
            inlineComment: CompilerGLSL.st.@inlineComment行);

        /// <summary>
        /// 
        /// </summary>
        private readonly TExtractor<translation_unit> @translation_unitExtractor = new(
            extractorItems: CompilerGLSL.@translation_unitExtractorItems,
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
        /// begin/continue/finish
        /// </summary>
        /// <returns></returns>
        public IReadOnlyList<Token> Begin() {
            return this.lexiAnalyzer.Begin();
        }
        /// <summary>
        /// continue to analyze lines of source code and return <see cref="Token"/>s
        /// </summary>
        /// <param name="lines">1/more lines</param>
        /// <returns></returns>
        public IReadOnlyList<Token> Continue(string lines) {
            return this.lexiAnalyzer.Continue(lines);
        }
        /// <summary>
        /// deal with '\0'
        /// </summary>
        /// <returns></returns>
        public IReadOnlyList<Token> Finish() {
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

        /// Extract a <see cref="translation_unit"/> object from syntax tree.
        /// <para>Post-order traversing.</para>
        /// </summary>
        /// <param name="tree">root node of the syntax tree.</param>
        /// <param name="tokens">the token list corresponds to <paramref name="rootNode"/>.</param>
        /// <param name="sourceCode">the original source code corresponds to <paramref name="tokens"/>.</param>
        /// <param name="tag">add <paramref name="tag"/>,<paramref name="obj"/> to <see cref="TContext{T}.tagDict"/></param>
        /// <param name="obj">add <paramref name="tag"/>,<paramref name="obj"/> to <see cref="TContext{T}.tagDict"/></param>
        /// <returns></returns>
        public translation_unit? Extract(SyntaxTree tree, IReadOnlyList<Token> tokens, ISourceCode sourceCode, string? tag = null, object? obj = null) {
            var @translation_unit = this.@translation_unitExtractor.Extract(
                tree, tokens, sourceCode, tag, obj);
            return @translation_unit;
        }
        /// Extract a <see cref="translation_unit"/> object from syntax tree.
        /// <para>Post-order traversing.</para>
        /// </summary>
        /// <param name="tree">root node of the syntax tree.</param>
        /// <param name="tokens">the token list corresponds to <paramref name="rootNode"/>.</param>
        /// <param name="sourceCode">the original source code corresponds to <paramref name="tokens"/>.</param>
        /// <param name="tag">add <paramref name="tag"/>,<paramref name="obj"/> to <see cref="TContext{T}.tagDict"/></param>
        /// <param name="obj">add <paramref name="tag"/>,<paramref name="obj"/> to <see cref="TContext{T}.tagDict"/></param>
        /// <returns></returns>
        public translation_unit? Extract(SyntaxTree tree, IReadOnlyList<Token> tokens, string sourceCode, string? tag = null, object? obj = null) {
            return Extract(tree, tokens, new SingleString(sourceCode), tag, obj);
        }

    }

}
