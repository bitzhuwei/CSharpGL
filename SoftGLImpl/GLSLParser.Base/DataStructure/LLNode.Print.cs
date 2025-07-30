using System;

namespace bitzhuwei.Compiler {
    partial class LLNode {
        /// <summary>
        /// Print all syntax tree.
        /// <para>pre-order traversing.</para>
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="stArray"></param>
        public void Print(System.IO.TextWriter writer, IReadOnlyList<string>? stArray) {
            var stack = new Stack<LLNode>(); stack.Push(this);
            while (stack.Count > 0) {
                var node = stack.Pop();
                node.PrintPremark(writer);
                PrintNode(node, writer, stArray);

                writer.WriteLine();

                for (int i = node.Children.Count - 1; i >= 0; i--) {
                    stack.Push(node.Children[i]);
                }
            }
        }

        private void PrintNode(LLNode node, TextWriter writer, IReadOnlyList<string>? stArray) {
            var regulation = node.regulation;
            var tokenCount = node.tokenCount;
            var start = node.start;
            var nodeKind = node.kind;

            if (regulation != null/*Regulation.noRegulation*/) { // a Vn
                regulation.Print(writer);
                if (tokenCount > 1) {
                    writer.Write($"⛪T[{start.index}->{start.index + tokenCount - 1}]");
                }
                else if (tokenCount == 1) {
                    writer.Write($"⛪T[{start.index}]");
                }
                else if (tokenCount == 0) {
                    if (start.index != -1) { throw new Exception("Algorithm error: this should never happen!"); }
                    writer.Write($"⛪ε");
                }
                else { throw new Exception("Algorithm error: this should never happen!"); }
            }
            else if (start.index >= 0 && tokenCount == 1) { // a Vt
                if (stArray != null) {
                    writer.Write($"T[{start.index}]={stArray[start.kind]} {start.shortValue()}");
                }
                else { writer.Write($"T[{start.index}]={start.kind} {start.shortValue()}"); }
            }
            else { // something wrong.
                throw new Exception("Algorithm error: this should never happen!");
                //writer.Write(nodeKind); writer.Write(" : ");
                //if (tokenCount > 1) {
                //    writer.Write($"⛳T[{tokenIndex}->{tokenIndex + tokenCount - 1}]");
                //}
                //else {
                //    writer.Write($"⛳T[{tokenIndex}]");
                //}
            }
        }

        //private static int IndexOf(Regulation regulation, IReadOnlyList<Regulation> regulations) {
        //    int result = -1;
        //    for (int index = 0; index < regulations.Count; index++) {
        //        if (regulation == regulations[index]) {
        //            result = index;
        //            break;
        //        }
        //    }

        //    return result;
        //}

        //TODO: optimize this ? not needed.
        private void PrintPremark(TextWriter writer) {
            var parent = this.parent; if (parent is null) { return; }

            var lstLine = new List<bool>();
            while (parent != null) {
                var pp = parent.parent;
                if (pp != null) {
                    lstLine.Add(pp._children.IndexOf(parent) < pp.Children.Count - 1);
                }
                parent = pp;
            }
            for (int i = lstLine.Count - 1; i >= 0; i--) {
                if (lstLine[i]) { writer.Write(" │ "); }
                else { writer.Write("   "); }
            }
            parent = this.parent; if (parent is null) { return; }
            if (parent._children.IndexOf(this) < parent.Children.Count - 1) {
                writer.Write(" ├─");
            }
            else { writer.Write(" └─"); }
        }

    }
}
