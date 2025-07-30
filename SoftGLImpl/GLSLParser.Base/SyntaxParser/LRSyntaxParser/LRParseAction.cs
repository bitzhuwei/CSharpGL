using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace bitzhuwei.Compiler {
    public class LRParseAction {
        public static readonly LRParseAction accept = new(Kind.Accept);
        public static readonly LRParseAction error = new(Kind.Error);
        public enum Kind {
            /// <summary>
            /// Error
            /// </summary>
            Error,
            /// <summary>
            /// Shift to SyntaxStates[{nextStateIndex}]
            /// </summary>
            Shift,
            /// <summary>
            /// Reduce by R[{regulationIndex}]
            /// </summary>
            Reduce,
            /// <summary>
            /// Go to SyntaxStates[{gotoStateIndex}]
            /// </summary>
            Goto,
            /// <summary>
            /// 完成
            /// </summary>
            Accept,
        }

        public readonly Kind kind;
        [StructLayout(LayoutKind.Explicit)]
        struct Union {
            /// <summary>
            /// next state.
            /// </summary>
            [FieldOffset(0)] public LRParseState nextState;
            /// <summary>
            /// reduce according to
            /// </summary>
            [FieldOffset(0)] public Regulation regulation;
        }
        private Union union;

        /// <summary>
        /// a Accept/Error action.
        /// </summary>
        /// <param name="kind"></param>
        private LRParseAction(Kind kind) {
            this.kind = kind;
        }
        /// <summary>
        /// a Shift/Goto action.
        /// </summary>
        /// <param name="kind"></param>
        /// <param name="syntaxState"></param>
        public LRParseAction(Kind kind, LRParseState syntaxState) {
            this.kind = kind;
            this.union.nextState = syntaxState;
        }
        /// <summary>
        /// a Reduce action.
        /// <para>reduce accroding to <paramref name="regulation"/></para>
        /// </summary>
        /// <param name="regulation"></param>
        public LRParseAction(Regulation regulation) {
            this.kind = Kind.Reduce;
            this.union.regulation = regulation;
        }

        /// 执行分析动作。
        /// <summary>
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public void Execute(LRParseContext context) {
            switch (this.kind) {
            case Kind.Error: { throw new NotImplementedException(); }
            //break;
            case Kind.Shift: {
                var token = context.CurrentToken;
                var leaf = new LRNode(
#if DEBUG
                    context.stArray,
#endif
                    token);
                context.nodeStack.Push(leaf);
                var nextState = this.union.nextState;
                context.stateStack.Push(nextState);
                context.cursor++;
            }
            break;
            case Kind.Reduce: {
                var regulation = this.union.regulation;
                int count = regulation.right.Length;
                var children = new LRNode[count];
                Token? start = null; LRNode? lastNode = null;
                var first = true;
                for (int i = 0; i < count; i++) {
                    var state = context.stateStack.Pop();//只弹出，不再使用。
                    var node = context.nodeStack.Pop();
                    children[count - i - 1] = node;
                    if (node.tokenRange.count > 0) { // this node includes token
                        if (first) { lastNode = node; first = false; }
                        start = node.tokenRange.start;
                    }
                }
                uint tokenCount = 0;
                if (lastNode != null && lastNode.tokenRange.count > 0 && start != null) {
                    tokenCount =
                        (uint)(lastNode.tokenRange.start.index // comment tokens inside of parent are included.
                        - start.index                          // comment tokens before parent are excluded.
                        + lastNode.tokenRange.count);          // comment tokens after parent are excluded.
                }
                var parent = new LRNode(
#if DEBUG
                        context.stArray,
#endif
                    regulation, start, tokenCount, children);
                for (var i = 0; i < count; i++) { children[i].parent = parent; }
                context.nodeStack.Push(parent);
                // goto next syntax-state
                LRParseState currentState = context.stateStack.Peek();
                var nodeType = regulation.left;
                if (currentState.TryGetAction(nodeType, out var parseAction)) {
                    parseAction.Execute(context); // parseAction is supposed to be a Goto action
                }
                Debug.Assert(parseAction != null && parseAction.kind == Kind.Goto);
            }
            break;
            case Kind.Goto: {
                var nextState = this.union.nextState;
                context.stateStack.Push(nextState);
            }
            break;
            case Kind.Accept: {
                var state = context.stateStack.Pop();
                context.root = context.nodeStack.Pop();
            }
            break;
            default: { throw new NotImplementedException(); }
            }
        }

        public override string ToString() {
            string result;
            switch (this.kind) {
            case Kind.Error: result = "/*Error*/"; break;
            case Kind.Shift: result = $"Shift to SyntaxStates[{this.union.nextState}]"; break;
            case Kind.Reduce: result = $"Reduce by Regulations[{this.union.regulation}]"; break;
            case Kind.Goto: result = $"Go to SyntaxStates[{this.union.nextState}]"; break;
            case Kind.Accept: result = "完成"; break;
            default: throw new NotImplementedException();
            }

            return result;
        }
    }
}
