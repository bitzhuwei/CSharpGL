using System;
using System.Text;

namespace bitzhuwei.Compiler {
    /// <summary>
    /// Node of the syntax tree from syntax parse.
    /// </summary>
    public partial class LLNode {
        /// <summary>
        /// kind of this node(some Vn or Vt).
        /// </summary>
        public readonly int kind;
        /// <summary>
        /// the first <see cref="bitzhuwei.Compiler.Token"/> in the <see cref="bitzhuwei.Compiler.Token"/> list.
        /// </summary>
        public Token start = Token.noToken;
        /// <summary>
        /// count of all <see cref="bitzhuwei.Compiler.Token"/>s inside of this <see cref="bitzhuwei.Compiler.Node"/>.
        /// <para>some tokens are (block/inline comment).</para>
        /// <para>but the first token and the last token are not (block/inline comment).</para>
        /// </summary>
        public int tokenCount = 0;
        /// <summary>
        /// Reduce according to which regulation?
        /// </summary>
        public Regulation? regulation = null;// Regulation.noRegulation;

        internal readonly List<LLNode> _children = new();
        public IReadOnlyList<LLNode> Children => this._children;

        public LLNode? parent;

        /// <summary>
        /// Node from syntax parse.
        /// </summary>
        /// <param name="kind">kind of this node(some Vn or Vt)</param>
        public LLNode(int kind) { this.kind = kind; }

        public override string ToString() {
            var builder = new StringBuilder();
            using (var writer = new StringWriter(builder)) {
                string[]? stArray = null;
                PrintNode(this, writer, stArray);
            }
            return builder.ToString();
        }
    }
}
