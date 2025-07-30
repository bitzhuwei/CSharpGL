using System;

namespace bitzhuwei.Compiler {
    /// <summary>
    /// Input: a list of Token.
    /// Output: a syntax tree.
    /// </summary>
    public partial class LLSyntaxParser {
        /// <summary>
        /// kind of the first <see cref="Regulation.left"/>
        /// </summary>
        public readonly int startNodeKind;
        /// <summary>
        /// [Vn, Vt] - <see cref="Regulation"/>
        /// </summary>
        public readonly Dictionary<int/*Vn*/, Dictionary<int/*Vt*/, Regulation>> predictiveParseTable;
        /// <summary>
        /// use this token when it's after the end of token list.
        /// </summary>
        public readonly Token EOT;

        /// <summary>
        /// </summary>
        /// <param name="startNodeType">the first <see cref="Regulation.left"/></param>
        /// <param name="predictiveParseTable">[Vn, Vt] - <see cref="Regulation"/></param>
        /// <param name="EOT">use this token when it's after the end of token list.</param>
        /// <exception cref="ArgumentNullException">The {LL1SyntaxParseTable} cannot be null.</exception>
        /// <exception cref="ArgumentNullException">The {EOT} cannot be null.</exception>
        public LLSyntaxParser(int startNodeType, Dictionary<int/*Vn*/, Dictionary<int/*Vt*/, Regulation>> predictiveParseTable, Token EOT) {
            ArgumentNullException.ThrowIfNull(predictiveParseTable);
            ArgumentNullException.ThrowIfNull(EOT);

            this.startNodeKind = startNodeType;
            this.predictiveParseTable = predictiveParseTable;
            this.EOT = EOT;
        }

        public LLNode Parse(TokenList tokenList) {
            var context = new LLParseContext(tokenList, this.startNodeKind, this.predictiveParseTable, this.EOT);
            do {
                var node = context.nodeStack.Pop();
                Token currentToken = context.CurrentToken;
                var regulation = context.GetRegulation(node.kind, currentToken.kind);
                if (regulation is null) { // node is a Vt
                    node.start = context.CurrentToken;
                    node.tokenCount = 1;
                    RefreshParentInfo(node);
                    context.cursor = node.start.index + 1;
                }
                else { // node is a Vn. ε is not a node.
                    node.regulation = regulation;
                    int count = regulation.right.Length;
                    for (int i = count - 1; i >= 0; i--) {
                        var kind = regulation.right[i];
                        var child = new LLNode(kind);
                        child.parent = node; node._children.Insert(0, child);
                        context.nodeStack.Push(child);
                    }
                }
            } while (!context.EndOfTokens);

            return context.rootNode;
        }

        private void RefreshParentInfo(LLNode node) {
            var parent = node.parent;
            while (parent != null) {
                if (parent.start.index < 0) { // not assigned yet.
                    parent.start = node.start;
                }

                parent.tokenCount = node.start.index - parent.start.index + 1;

                node = parent;
                parent = parent.parent;
            }
        }
    }
}
