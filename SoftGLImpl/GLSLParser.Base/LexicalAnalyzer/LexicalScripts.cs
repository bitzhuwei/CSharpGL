using System;

namespace bitzhuwei.Compiler {
    public class LexicalScripts {
        public readonly Action<LexicalContext> begin;
        public readonly Action<LexicalContext, int> extend;
        public readonly Action<LexicalContext, int[]> extend2;
        public readonly Action<LexicalContext, IfVt[]> extend3;
        public readonly Action<LexicalContext, int> accept;
        public readonly Action<LexicalContext, int[]> accept2;
        public readonly Action<LexicalContext, IfVt[]> accept3;

        public LexicalScripts(Action<LexicalContext> begin,
            Action<LexicalContext, int> extend,
            Action<LexicalContext, int[]> extend2,
            Action<LexicalContext, IfVt[]> extend3,
            Action<LexicalContext, int> accept,
            Action<LexicalContext, int[]> accept2,
            Action<LexicalContext, IfVt[]> accept3) {
            this.begin = begin;
            this.extend = extend;
            this.extend2 = extend2;
            this.extend3 = extend3;
            this.accept = accept;
            this.accept2 = accept2;
            this.accept3 = accept3;
        }

        public override string ToString() {
            var acts = Acts.None;
            if (begin != null) { acts |= Acts.Begin; }
            if (extend != null) { acts |= Acts.Extend; }
            if (extend2 != null) { acts |= Acts.Extend2; }
            if (extend3 != null) { acts |= Acts.Extend3; }
            if (accept != null) { acts |= Acts.Accept; }
            if (accept2 != null) { acts |= Acts.Accept2; }
            if (accept3 != null) { acts |= Acts.Accept3; }

            return $"scripts: {acts}";
        }
    }
}
