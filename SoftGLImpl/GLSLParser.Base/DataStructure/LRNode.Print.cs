using System;

namespace bitzhuwei.Compiler {
    partial class LRNode {
        /// <summary>
        /// Print all syntax tree.
        /// <para>pre-order traversing.</para>
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="stArray"></param>
        public void Print(System.IO.TextWriter writer, IReadOnlyList<string>? stArray = null) {
            var stack = new Stack<LRNode>(); stack.Push(this);
            while (stack.Count > 0) {
                var node = stack.Pop();

                node.PrintPremark(writer);
                PrintNode(node, writer, stArray);
                writer.WriteLine();

                for (int i = node.children.Count - 1; i >= 0; i--) {
                    stack.Push(node.children[i]);
                }
            }
        }

        private void PrintNode(LRNode node, TextWriter writer, IReadOnlyList<string>? stArray) {
            var regulation = node.regulation;
            var tokenRange = node.tokenRange;
            var nodeType = node.kind;

            if (regulation != null/*Regulation.noRegulation*/) { // a Vn
                regulation.Print(writer, stArray);
                var start = tokenRange.start; var count = tokenRange.count;
                if (false) { }
                else if (count > 1) { writer.Write($"⛪T[{start.index}->{start.index + count - 1}]"); }
                else if (count == 1) { writer.Write($"⛪T[{start.index}]"); }
                else { writer.Write($"⛪ε"); }
            }
            else if (tokenRange.count == 1) { // a Vt
                var start = tokenRange.start; var count = tokenRange.count;
                //innerWriter.Write($"➰T[{start.index}]={stArray[start.kind]} {start.shortValue()}");
                if (stArray != null && start.kind >= 0) {
                    writer.Write($"T[{start.index}]={stArray[start.kind]} {start.shortValue()}");
                }
                else { writer.Write($"T[{start.index}]={start.kind} {start.shortValue()}"); }
            }
            else { // something wrong.
                if (stArray != null && nodeType >= 0) { writer.Write(stArray[nodeType]); }
                else { writer.Write(nodeType); }
                writer.Write(" : ");
                var start = tokenRange.start; var count = tokenRange.count;
                if (count > 1) { writer.Write($"⛳T[{start}->{start.index + count - 1}]"); }
                else if (count == 1) { writer.Write($"⛳T[{start.index}]"); }
                else { writer.Write($"⛳T[{start}]"); }
                //throw new Exception("Algorithm error: this should never happen!");
            }
        }

        //TODO: optimize this ? not needed.
        private void PrintPremark(TextWriter writer) {
            var parent = this.parent; if (parent is null) { return; }

            var lstLine = new List<bool>();
            while (parent != null) {
                var pp = parent.parent;
                if (pp != null) {
                    lstLine.Add(Algo.IndexOf(pp.children, parent) < pp.children.Count - 1);
                }
                parent = pp;
            }
            for (int i = lstLine.Count - 1; i >= 0; i--) {
                if (lstLine[i]) {
                    writer.Write(" │ ");
                }
                else { writer.Write("   "); }
            }
            parent = this.parent; if (parent is null) { return; }
            if (Algo.IndexOf(parent.children, this) < parent.children.Count - 1) {
                writer.Write(" ├─");
            }
            else { writer.Write(" └─"); }
        }

    }
}
