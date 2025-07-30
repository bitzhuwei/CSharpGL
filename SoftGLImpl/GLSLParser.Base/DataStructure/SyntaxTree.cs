using System;

namespace bitzhuwei.Compiler {
    /// <summary>
    /// Result of syntax parse.
    /// </summary>
    public partial class SyntaxTree {
        public readonly LRNode? root;

        public readonly LRParseContext context;
        //public bool Error => this.root == null;


        ///// <summary>
        ///// Result of lexical analyzing.
        ///// </summary>
        ///// <param name="root"></param>
        //public SyntaxTree(LRNode root) {
        //    this.root = root;
        //}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        internal SyntaxTree(LRParseContext context) {
            if (context == null) throw new ArgumentNullException(nameof(context));
            this.context = context;
            this.root = context.root;
        }

        //        private static readonly LRNode errorNode = new(
        //#if DEBUG
        //            Token.EmptyArray,
        //#endif
        //            Token.noToken);
        public void Print(System.IO.TextWriter writer, IReadOnlyList<string>? stArray = null) {
            if (context.root != null) {
                context.root.Print(writer, stArray);
            }
            else {// do my best when syntax-perse failed.
                foreach (var node in this.context.nodeStack.Reverse()) {
                    node.Print(writer, stArray);
                }
            }
        }


        public override string ToString() {
            if (this.context != null) {
                return $"Error at: {this.context.CurrentToken}";
            }
            else {
                return $"{this.root}";
            }

        }


    }
}
