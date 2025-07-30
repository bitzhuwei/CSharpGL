using System;
using System.Text;

namespace bitzhuwei.Compiler {
    // 规约规则
    /// <summary>
    /// Exp : Exp '+' Term ;
    /// </summary>
    public partial class Regulation {
        /// <summary>
        /// index in the <see cref="Regulation"/>[].
        /// </summary>
        public readonly int index;
        /// <summary>
        /// Exp
        /// </summary>
        public readonly int left;
        /// <summary>
        /// Exp '+' Term
        /// <para>There can be ZERO element.</para>
        /// </summary>
        public readonly int[] right;

        /// <summary>
        /// Exp = Exp '+' Term ;
        /// </summary>
        /// <param name="index">index in the <see cref="Regulation"/>[].</param>
        /// <param name="left">Additive</param>
        /// <param name="right">Additive '+' Multiplicative
        /// <para>There can be ZERO element.</para>
        /// </param>
        public Regulation(int index, int left, params int[] right) {
            this.index = index;
            this.left = left;
            this.right = right;
        }

        //public static readonly Regulation noRegulation = new(index: -1, left: -1);

        /// <summary>
        /// print :
        /// <para>R[{index}] Exp = Exp '+' Term ;</para>
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="stArray"></param>
        public void Print(TextWriter writer, IReadOnlyList<string>? stArray = null) {
            writer.Write($"R[{this.index}] ");
            if (stArray != null) {
                if (this.left >= 0 && this.left < stArray.Count) {
                    writer.Write(stArray[this.left]);
                }
                else {
                    writer.Write($"[{this.left}]");
                }
                writer.Write(" = ");
                foreach (var node in this.right) {
                    writer.Write(stArray[node]); writer.Write(' ');
                }
            }
            else {
                {
                    writer.Write(this.left); writer.Write(" = ");
                }
                foreach (var node in this.right) {
                    writer.Write(node); writer.Write(' ');
                }
            }

            writer.Write(";");
        }

        public override string ToString() {
            var b = new StringBuilder();
            using (var writer = new StringWriter(b)) { this.Print(writer); }

            return b.ToString();
        }
    }
}
