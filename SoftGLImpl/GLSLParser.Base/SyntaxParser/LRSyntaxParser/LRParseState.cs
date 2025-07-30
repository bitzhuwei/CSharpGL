using System;
using System.Diagnostics.CodeAnalysis;

namespace bitzhuwei.Compiler {
    /// <summary>
    /// state for syntax parse.
    /// </summary>
    public class LRParseState {
        //private static readonly int[] noNodes = new int[0];
        public int[] nodes = Array.Empty<int>();
        //private static readonly LRParseAction[] noActions = new LRParseAction[0];
        public LRParseAction[] actions = Array.Empty<LRParseAction>();

        /// <summary>
        /// Get handler of this state according to specified <paramref name="V"/>
        /// </summary>
        /// <param name="node">st.node</param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool TryGetAction(int node, [MaybeNullWhen(false)] out LRParseAction value) {
            var index = -1; var list = this.nodes;
            var left = 0; var right = list.Length - 1;
            if (right < 0) { }
            else {
                var result = -1;
                while (left < right) {
                    var mid = (left + right) / 2;
                    var current = list[mid];
                    if (node < current) { result = -1; }
                    else if (node == current) { result = 0; }
                    else { result = 1; }
                    if (result < 0) { right = mid; }
                    else if (result == 0) { left = mid; right = mid; index = left; }
                    else { left = mid + 1; }
                }
                if (result != 0) {
                    var current = list[left];
                    if (node == current) { index = left; }
                }
            }
            if (0 <= index) {
                value = this.actions[index];
                return true;
            }
            else {
                value = null;
                return false;
            }
        }

        public override string ToString() {
            return $"Syntax✪[{this.nodes.Length}]->[{this.actions.Length}]";
        }
    }
}
