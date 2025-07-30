using System;
using System.Diagnostics;
using System.Text;

namespace bitzhuwei.Compiler {
    /// <summary>
    /// Node of the syntax tree from syntax parse.
    /// </summary>
    public partial class LRNode {
        /// <summary>
        /// kind of this node(some Vn or Vt).
        /// </summary>
        public readonly int kind;
#if DEBUG
        public readonly IReadOnlyList<string> stArray;
#endif
        /// <summary>
        /// Reduce according to which <see cref="regulation"/> ?
        /// <para>if null, it means this is a leaf-node</para>
        /// </summary>
        public readonly Regulation? regulation;

        public struct TokenRange {
            /// <summary>
            /// the first <see cref="bitzhuwei.Compiler.Token"/> this <see cref="LRNode"/> includes.
            /// <para>if null, then <see cref="tokenCount"/> should be 0.</para>
            /// </summary>
            public readonly Token start;
            /// <summary>
            /// count of all <see cref="bitzhuwei.Compiler.Token"/>s this <see cref="bitzhuwei.Compiler.LRNode"/> includes.
            /// <para>some tokens are (block/inline comment).</para>
            /// <para>but the first token and the last token are not (block/inline comment).</para>
            /// </summary>
            public readonly uint count;

            public TokenRange(Token start, uint count) {
                this.start = start;
                this.count = count;
            }
            public override string ToString() {
                if (count == 0) { return $"(×)T[{start.index}]"; }
                else { return $"T[{start.index} -> {start.index + count - 1}]"; }
            }
        }
        /// <summary>
        /// if <see cref="regulation"/>is not null, then <see cref="tokenRange"/> could be null(includes no token) or not-null(includes some tokens).
        /// <para>if <see cref="regulation"/>is null, then this node represents a leaf node which includes 1 <see cref="Token"/>.</para>
        /// </summary>
        public readonly TokenRange tokenRange;


        public readonly IReadOnlyList<LRNode> children;
        private static readonly LRNode[] emptyChildren = Array.Empty<LRNode>();//new LRNode[0];

        public LRNode? parent = null;

        //public int LastTokenIndex() { return this.start - 1 + this.tokenCount; }
        ///// <summary>
        ///// get index of the token after the last token in scope of this node.
        ///// <para>If it is not a comment node, it's also the first token in scope of the node who is this node's brother node.</para>
        ///// </summary>
        ///// <returns></returns>
        //public int GetNextIndex() { return this.start + this.tokenCount; }

        /// <summary>
        /// Node from syntax parse.
        /// <para>presents a <see cref="Regulation"/> and <see cref="Token"/>s it includes.</para>
        /// </summary>
        /// <param name="regulation"></param>
        /// <param name="start"></param>
        /// <param name="tokenCount"></param>
        /// <param name="children"></param>
        public LRNode(
#if DEBUG
            IReadOnlyList<string> stArray,
#endif
            Regulation regulation, Token? start, uint tokenCount, LRNode[] children) {
#if DEBUG
            this.stArray = stArray ?? throw new ArgumentNullException(nameof(stArray));
#endif
            this.kind = regulation.left;
            this.regulation = regulation;
            if (start != null) {// [1, more] tokens
                this.tokenRange = new TokenRange(start, tokenCount);
            }
            else {// 0 token
                this.tokenRange = new TokenRange(Token.noToken, 0);
            }
            this.children = children;
        }
        //        /// <summary>
        //        /// Node from syntax parse.
        //        /// <para>presents a <see cref="Regulation"/>(left : empty ;) which includes no <see cref="Token"/>.</para>
        //        /// </summary>
        //        /// <param name="regulation"></param>
        //        public LRNode(
        //#if DEBUG
        //            IReadOnlyList<string> stArray,
        //#endif
        //            Regulation regulation) {
        //#if DEBUG
        //            this.stArray = stArray ?? throw new ArgumentNullException(nameof(stArray));
        //#endif
        //            this.kind = regulation.left;
        //            this.regulation = regulation;
        //            this.start = Token.noToken;
        //            this.tokenCount = 0;
        //            this.children = emptyChildren;
        //        }
        /// <summary>
        /// Node from syntax parse.
        /// <para>presents a leaf node which includes 1 <see cref="Token"/>.</para>
        /// </summary>
        /// <param name="token">the only token</param>
        public LRNode(
#if DEBUG
            IReadOnlyList<string> stArray,
#endif
            Token token) {
#if DEBUG
            this.stArray = stArray ?? throw new ArgumentNullException(nameof(stArray));
#endif
            this.kind = token.kind;
            this.regulation = null;// Regulation.noRegulation;
            // 1 token
            this.tokenRange = new TokenRange(token, 1);
            this.children = emptyChildren;
        }

        public override string ToString() {
            var builder = new StringBuilder();
            using (var writer = new StringWriter(builder)) {
#if DEBUG
                PrintNode(this, writer, this.stArray);
#else
                string[]? stArray = null;
                PrintNode(this, writer, stArray);
#endif
            }
            return builder.ToString();
        }
    }
}
