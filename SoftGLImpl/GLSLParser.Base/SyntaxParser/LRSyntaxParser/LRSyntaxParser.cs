using System;
using System.Diagnostics;
using System.Text;

namespace bitzhuwei.Compiler {
    /// <summary>
    /// Input: a list of <see cref="Token"/>.
    /// Output: a <see cref="SyntaxTree"/>.
    /// </summary>
    public partial class LRSyntaxParser {
        /// <summary>
        /// the initial state for syntax parse.
        /// </summary>
        public readonly LRParseState initialState;
        /// <summary>
        /// use this token when it's after the end of token list.
        /// </summary>
        public readonly Token EOT;

        /// <summary>
        /// token kind of block comment
        /// </summary>
        public readonly int blockComment;
        /// <summary>
        /// token kind of inline comment
        /// </summary>
        public readonly int inlineComment;
#if DEBUG
        /// <summary>
        /// '¥', 'Vt', Vn
        /// </summary>
        public readonly IReadOnlyList<string> stArray;
#endif 

        /// <summary>
        /// Input: a list of <see cref="Token"/>.
        /// Output: a <see cref="SyntaxTree"/>.
        /// </summary>
        /// <param name="initialState">the initial state for syntax parse.</param>
        /// <param name="EOT">use this token when it's after the end of token list.</param>
        /// <param name="blockComment">name of block comment token kind</param>
        /// <param name="inlineComment">name of inline comment token kind</param>
        /// <exception cref="ArgumentNullException">The {initialState} cannot be null.</exception>
        /// <exception cref="ArgumentNullException">The {EOT} cannot be null.</exception>
        public LRSyntaxParser(
#if DEBUG
            IReadOnlyList<string> stArray,
#endif
            LRParseState initialState,
            Token EOT, int blockComment, int inlineComment) {
#if DEBUG
            ArgumentNullException.ThrowIfNull(stArray);
            this.stArray = stArray;
#endif
            ArgumentNullException.ThrowIfNull(initialState);
            ArgumentNullException.ThrowIfNull(EOT);

            // in case of endless loop in Parse() {
            //     ..
            //     while (nodeType == blockComment || nodeType == inlineComment) { }
            //     ..
            // }
            if (EOT.kind == blockComment) {
                throw new Exception($"[EOT.kind({EOT.kind}) == blockComment] should never happen in case of endless loop in Parse()!");
            }
            if (EOT.kind == inlineComment) {
                throw new Exception($"[EOT.kind({EOT.kind}) == inlineComment] should never happen in case of endless loop in Parse()!");
            }

            this.initialState = initialState;
            this.EOT = EOT;
            this.blockComment = blockComment;
            this.inlineComment = inlineComment;
        }

        public SyntaxTree Parse(IReadOnlyList<Token> tokenList) {
            var context = new LRParseContext(tokenList, this.initialState, this.EOT
#if DEBUG
            , this.stArray
#endif
            );
            var accept = false;
            do {
                Token token = context.CurrentToken;
                int nodeType = token.kind;// no-need-convert from int to int.
                while (nodeType == blockComment || nodeType == inlineComment) {
                    // skip comment token
                    context.cursor++;
                    token = context.CurrentToken;
                    nodeType = token.kind;// no-need-convert from int to int.
                }

                LRParseState currentState = context.stateStack.Peek();
                if (currentState.TryGetAction(nodeType, out var parseAction)) {
                    parseAction.Execute(context);
                    if (parseAction.kind == LRParseAction.Kind.Accept) { accept = true; }
                }
                else { // syntax error happened.
                    return new SyntaxTree(context);
                }
            } while (!accept);

            return new SyntaxTree(context);
        }
    }
}
