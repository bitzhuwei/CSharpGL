using System;

namespace bitzhuwei.Compiler {
    /// <summary>
    /// It's an internal bag. You can find anything you need for syntax parse.
    /// </summary>
    public partial class LRParseContext {
        /// <summary>
        /// index of current Token in the <paramref name="tokenList"/>.
        /// </summary>
        internal int cursor;

        /// <summary>
        /// current state which is ready to read current Token.
        /// </summary>
        public readonly Stack<LRParseState> stateStack = new();
        /// <summary>
        /// When syntax parse is finished, this is where syntax tree lies.
        /// </summary>
        public readonly Stack<LRNode> nodeStack = new();


        /// <summary>
        /// token list from source code like C, C++, C#, Java, Xml, etc.
        /// </summary>
        internal readonly IReadOnlyList<Token> tokenList;
        /// <summary>
        /// use this token when it's after the end of token list.
        /// </summary>
        internal readonly Token EOT;
        //internal readonly IReadOnlyList<Regulation>? regulations;
#if DEBUG
        internal readonly IReadOnlyList<string> stArray;
#endif

        /// <summary>
        /// root node of the final syntax-tree.
        /// </summary>
        internal LRNode? root;

        /// <summary>
        /// It's an internal context. You can find anything you need for syntax parse.
        /// </summary>
        /// <param name="tokenList"></param>
        /// <param name="initialState"></param>
        /// <param name="EOT">use this token when it's after the end of token list.</param>
        internal LRParseContext(IReadOnlyList<Token> tokenList,
            LRParseState initialState,
            Token EOT
#if DEBUG
            , IReadOnlyList<string> stArray
#endif
            ) {
            ArgumentNullException.ThrowIfNull(tokenList);
            this.tokenList = tokenList;
            this.stateStack.Push(initialState);
            this.EOT = EOT;
#if DEBUG
            this.stArray = stArray;
#endif
        }

        ///// <summary>
        ///// return true if the last token is syntax parsed.
        ///// </summary>
        //public bool EndOfTokens => this.m_Index >= this.tokenList.Count;
        /// <summary>
        /// Gets current lexically analyzing character.
        /// </summary>
        internal Token CurrentToken {
            get {
                var cursor = this.cursor;
                var tokenList = this.tokenList;
                if (0 <= cursor && cursor < tokenList.Count) {
                    return tokenList[cursor];
                }
                else {
                    return this.EOT;
                }
            }
        }

        public override string ToString() {
            return $"{this.nodeStack.Count} nodes in stack";
        }

    }

}
