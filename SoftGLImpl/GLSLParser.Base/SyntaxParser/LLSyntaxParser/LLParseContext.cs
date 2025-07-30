using System;
using System.Diagnostics;

namespace bitzhuwei.Compiler {
    /// <summary>
    /// It's an internal bag. You can find anything you need for syntax parse.
    /// </summary>
    public class LLParseContext {
        /// <summary>
        /// Gets index of current Token in the <paramref name="tokenList"/>.
        /// </summary>
        internal int cursor;// { get { return this.m_Index; } }

        /// <summary>
        /// [Vn, Vt] -&gt; <see cref="Regulation"/>
        /// </summary>
        internal readonly Dictionary<int/*Vn*/, Dictionary<int/*Vt*/, Regulation>> LL1SyntaxParseTable;

        /// <summary>
        /// When syntax parse is finished, this is where syntax tree lies.
        /// </summary>
        internal readonly Stack<LLNode> nodeStack = new();

        public readonly LLNode rootNode;

        /// <summary>
        /// token list from source code like C, C++, C#, Java, Xml, etc.
        /// </summary>
        private readonly TokenList tokenList;
        /// <summary>
        /// the compiler-added token that represents it's after the end of <see cref="LLParseContext.tokenList"/>
        /// </summary>
        private readonly Token EOT;

        /// <summary>
        /// It's an internal context. You can find anything you need for syntax parse.
        /// </summary>
        /// <param name="tokenList"></param>
        /// <param name="initialNodeType"></param>
        /// <param name="LL1SyntaxParseTable">[Vn, Vt] -&gt; <see cref="Regulation"/></param>
        /// <param name="EOT"></param>
        public LLParseContext(TokenList tokenList, int initialNodeType, Dictionary<int, Dictionary<int, Regulation>> LL1SyntaxParseTable, Token EOT) {
            Debug.Assert(tokenList != null);

            this.tokenList = tokenList;
            var node = new LLNode(initialNodeType);
            this.nodeStack.Push(node);
            this.rootNode = node;
            this.LL1SyntaxParseTable = LL1SyntaxParseTable;
            this.EOT = EOT;
        }

        /// <summary>
        /// return true if the last token is syntax parsed.
        /// </summary>
        public bool EndOfTokens { get { return this.cursor >= this.tokenList.Count; } }
        /// <summary>
        /// Gets current lexically analyzing character.
        /// </summary>
        public Token CurrentToken {
            get {
                var cursor = this.cursor;
                TokenList tokenList = this.tokenList;
                if (cursor < tokenList.Count) {
                    return tokenList[cursor];
                }
                else {
                    return this.EOT;
                }
            }
        }

        /// <summary>
        /// Get action of this state according to specified <paramref name="token"/>
        /// </summary>
        /// <param name="VnState"></param>
        /// <param name="Vt"></param>
        /// <returns></returns>
        public /*ParsingAction*/Regulation? GetRegulation(/*SyntaxState*/int VnState, int Vt) {
            //var action = state.GetAction(nodeType);
            //return action;
            if (this.LL1SyntaxParseTable.TryGetValue(VnState, out var dict)) {
                if (dict.TryGetValue(Vt, out var regulation)) {
                    return regulation;
                }
            }

            // TODO: return error handler.
            return null;
        }

    }

}
