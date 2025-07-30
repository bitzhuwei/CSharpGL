using System;
using System.Diagnostics;
using System.Xml.Linq;

namespace bitzhuwei.Compiler {
    /// <summary>
    /// Extract some data structure from syntax tree.
    /// </summary>
    /// <typeparam name="T">Extracted Type</typeparam>
    public class TExtractor<T> where T : class {
        /// <summary>
        /// <see cref="LRNode.kind"/> -&gt; <see cref="Action{Node, TContext{T}}"/>
        /// </summary>
        private readonly Action<LRNode, TContext<T>>?[] extractorItems;
        /// <summary>
        /// use this node when it's after the end of token list.
        /// </summary>
        private readonly LRNode EOT;
        private readonly Action<LRNode, TContext<T>> visit;
        /// <summary>
        /// kinds of Vt('¥' excluded)
        /// </summary>
        private readonly int VtKinds;
        private readonly Action<LRNode, TContext<T>> single4Vt;
        private static readonly Action<LRNode, TContext<T>> defaultSingle4Vt =
        (node, context) => {
            Debug.Assert(node.tokenRange.count > 0);
            context.rightStack.Push(node.tokenRange.start);
        };

        /// <summary>
        /// Extract some data structure from syntax tree.
        /// </summary>
        /// <param name="extractorItems"><see cref="LRNode.kind"/>('¥'/Vt/Vn) -&gt; <see cref="Action{Node, TContext{T}}"/></param>
        /// <param name="EOT">use this token when it's after the End Of Tokens.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public TExtractor(Action<LRNode, TContext<T>>?[] extractorItems, LRNode EOT)
            : this(extractorItems, EOT, 0, VtExtractorMode.Each, defaultSingle4Vt) {
        }

        /// <summary>
        /// Extract some data structure from syntax tree.
        /// </summary>
        /// <param name="extractorItems"><see cref="LRNode.kind"/>('¥'/Vn) -&gt; <see cref="Action{Node, TContext{T}}"/></param>
        /// <param name="EOT">use this token when it's after the End Of Tokens.</param>
        /// <param name="VtKinds">kinds of Vt('¥' excluded)</param>
        /// <param name="mode"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public TExtractor(Action<LRNode, TContext<T>>?[] extractorItems, LRNode EOT, int VtKinds, VtExtractorMode mode)
            : this(extractorItems, EOT, VtKinds, mode, defaultSingle4Vt) {
            if (mode != VtExtractorMode.SingleFixed && mode != VtExtractorMode.Omit) {
                throw new Exception($"it should be {VtExtractorMode.SingleFixed} or {VtExtractorMode.Omit}");
            }
        }

        /// <summary>
        /// Extract some data structure from syntax tree.
        /// </summary>
        /// <param name="extractorItems"><see cref="LRNode.kind"/>('¥'/Vn) -&gt; <see cref="Action{Node, TContext{T}}"/></param>
        /// <param name="EOT">use this token when it's after the End Of Tokens.</param>
        /// <param name="VtKinds">kinds of Vt('¥' excluded)</param>
        /// <param name="single4Vt">the one uniform way to deal with Vt symbol</param>
        /// <exception cref="ArgumentNullException"></exception>
        public TExtractor(Action<LRNode, TContext<T>>?[] extractorItems, LRNode EOT, int VtKinds, Action<LRNode, TContext<T>> single4Vt)
            : this(extractorItems, EOT, VtKinds, VtExtractorMode.Single, single4Vt) {
        }

        private TExtractor(Action<LRNode, TContext<T>>?[] extractorItems, LRNode EOT, int VtKinds, VtExtractorMode mode, Action<LRNode, TContext<T>> single4Vt) {
            ArgumentNullException.ThrowIfNull(extractorItems);
            ArgumentNullException.ThrowIfNull(EOT);
            ArgumentNullException.ThrowIfNull(single4Vt);

            this.extractorItems = extractorItems;
            this.EOT = EOT;
            this.VtKinds = VtKinds;
            switch (mode) {
            case VtExtractorMode.SingleFixed: this.visit = this.SingleFixed; break;
            case VtExtractorMode.Single: this.visit = this.Single; break;
            case VtExtractorMode.Omit: this.visit = this.Omit; break;
            case VtExtractorMode.Each: this.visit = this.Each; break;
            default: throw new NotImplementedException();
            }
            this.single4Vt = single4Vt;
        }

        /// <summary>
        /// Extract some data structure from syntax tree.
        /// <para>post-order traverse <paramref name="root"/> with stack(without recursion).</para>
        /// </summary>
        /// <param name="tree">the syntax tree.</param>
        /// <param name="tokens">the token list correspond to <paramref name="root"/>.</param>
        /// <param name="sourceCode">the source code correspond to <paramref name="tokens"/>.</param>
        /// <param name="tag">add <paramref name="tag"/>,<paramref name="obj"/> to <see cref="TContext{T}.tagDict"/></param>
        /// <param name="obj">add <paramref name="tag"/>,<paramref name="obj"/> to <see cref="TContext{T}.tagDict"/></param>
        /// <returns></returns>
        public T? Extract(SyntaxTree tree, IReadOnlyList<Token> tokens, ISourceCode sourceCode, string? tag = null, object? obj = null) {
            if (tree.root != null) {
                var context = new TContext<T>(tree.root, tokens, sourceCode, tag, obj);
                Extract(context);
                return context.result;
            }
            else {// do my best when syntax-parse failed.
                foreach (var node in tree.context.nodeStack.Reverse()) {
                    var context = new TContext<T>(node, tokens, sourceCode, tag, obj);
                    Extract(context);
                }
                return null;
            }
        }

        private void Extract(TContext<T> context) {
            var nodeStack = new Stack<LRNode>(); var indexStack = new Stack<int>();
            // init stack.
            {
                // push nextLeft and its next pending children.
                var nextLeft = context.rootNode; var index = 0;
                nodeStack.Push(nextLeft); indexStack.Push(index);
                while (nextLeft.children.Count > 0) {
                    nextLeft = nextLeft.children[0];
                    nodeStack.Push(nextLeft); indexStack.Push(0);
                }
            }

            while (nodeStack.Count > 0) {
                var current = nodeStack.Pop(); var index = indexStack.Pop() + 1;
                if (index < current.children.Count) {
                    // push this node back again.
                    nodeStack.Push(current); indexStack.Push(index);

                    // push nextLeft and its next pending children.
                    var nextLeft = current.children[index];
                    nodeStack.Push(nextLeft); indexStack.Push(0);
                    while (nextLeft.children.Count > 0) {
                        nextLeft = nextLeft.children[0];
                        nodeStack.Push(nextLeft); indexStack.Push(0);
                    }
                }
                else {
                    this.visit(current, context);
                }
            }

            this.visit(this.EOT, context);

        }

        private void SingleFixed(LRNode current, TContext<T> context) {
            if (current.kind == 0) { // 0 means Symbol.EOF('¥')
                var action = extractorItems[0];
                if (action != null) { action(current, context); }
            }
            else if (current.kind > this.VtKinds) { // Vn
                var action = extractorItems[current.kind - this.VtKinds];
                if (action != null) { action(current, context); }
            }
            else { // single fixed action for Vt symbols
                Debug.Assert(current.tokenRange.count > 0);
                context.rightStack.Push(current.tokenRange.start);
            }
        }

        private void Single(LRNode current, TContext<T> context) {
            if (current.kind == 0) { // 0 means Symbol.EOF('¥')
                var action = extractorItems[0];
                if (action != null) { action(current, context); }
            }
            else if (current.kind > this.VtKinds) { // Vn
                var action = extractorItems[current.kind - this.VtKinds];
                if (action != null) { action(current, context); }
            }
            else { // single user-defined action for Vt symbols
                this.single4Vt(current, context);
            }
        }

        private void Omit(LRNode current, TContext<T> context) {
            if (current.kind == 0) { // 0 means Symbol.EOF('¥')
                var action = extractorItems[0];
                if (action != null) { action(current, context); }
            }
            else if (current.kind > this.VtKinds) { // Vn
                var action = extractorItems[current.kind - this.VtKinds];
                if (action != null) { action(current, context); }
            }
        }

        private void Each(LRNode current, TContext<T> context) {
            var action = extractorItems[current.kind];
            if (action != null) { action(current, context); }
        }
        //private void Visit(LRNode current, TContext<T> context) {
        //    switch (this.vtExtractorMode) {
        //    case VtExtractorMode.SingleFixed: {
        //        if (current.kind == 0) { // 0 means Symbol.EOF('¥')
        //            var action = extractorItems[current.kind];
        //            if (action != null) { action(current, context); }
        //        }
        //        else if (current.kind > this.VtKinds) { // Vn
        //            var action = extractorItems[current.kind - this.VtKinds];
        //            if (action != null) { action(current, context); }
        //        }
        //        else { // single fixed action for Vt symbols
        //            context.rightStack.Push(current.start);
        //        }
        //    }
        //    break;
        //    case VtExtractorMode.Single: {
        //        if (current.kind == 0) { // 0 means Symbol.EOF('¥')
        //            var action = extractorItems[current.kind];
        //            if (action != null) { action(current, context); }
        //        }
        //        else if (current.kind > this.VtKinds) { // Vn
        //            var action = extractorItems[current.kind - this.VtKinds];
        //            if (action != null) { action(current, context); }
        //        }
        //        else { // single fixed action for Vt symbols
        //            this.single4Vt(current, context);
        //        }
        //    }
        //    break;
        //    case VtExtractorMode.Omit: {
        //        if (current.kind == 0) { // 0 means Symbol.EOF('¥')
        //            var action = extractorItems[current.kind];
        //            if (action != null) { action(current, context); }
        //        }
        //        else if (current.kind > this.VtKinds) { // Vn
        //            var action = extractorItems[current.kind - this.VtKinds];
        //            if (action != null) { action(current, context); }
        //        }
        //    }
        //    break;
        //    case VtExtractorMode.Each: {
        //        var action = extractorItems[current.kind];
        //        if (action != null) { action(current, context); }
        //    }
        //    break;
        //    default: throw new NotImplementedException();
        //    }
        //}

        //void PostOrderRecursion(LRNode node) {
        //    for (int i = 0; i < node.children.Count; i++) {
        //        PostOrderRecursion(node.children[i]);
        //    }

        //    Visit(node);
        //}

        //private void Visit(LRNode node) {
        //    throw new NotImplementedException();
        //}

    }
}
