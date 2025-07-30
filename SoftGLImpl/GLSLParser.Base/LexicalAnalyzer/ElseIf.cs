using System;

namespace bitzhuwei.Compiler {
    /// <summary>
    /// else if ('0' <= c && c <= '9') { .. }
    /// </summary>
    public partial class ElseIf {
        public readonly char min;
        public readonly char max;
        public readonly int nextStateId;

        public readonly Acts scripts;
        public readonly int Vt;

        public ElseIf(char c, int nextStateId, Acts scripts, int Vt = 0)
            : this(c, c, nextStateId, scripts, Vt) { }
        public ElseIf(char min, char max, int nextStateId, Acts scripts, int Vt = 0) {
            if (!(Vt == 0 || scripts.HasFlag(Acts.Extend) || scripts.HasFlag(Acts.Accept))) {
                throw new Exception(@"ElseIf expects None/Begin/Extend/Accept, not Extend2/Accept2/Extend3/Accept3.
if (Vt != 0) { scripts must have Extend/Accept }");
            }
            this.min = min;
            this.max = max;
            this.nextStateId = nextStateId;
            this.scripts = scripts;
            this.Vt = Vt;
        }

        public override string ToString() {
            if (min < max) { return $"({min}->{max}) => {nextStateId} {scripts}(Vt: {Vt})"; }
            // maybe something wrong.
            else if (min > max) { return $"({min}<-{max}) => {nextStateId} {scripts}(Vt: {Vt})"; }
            else { return $"({min}) => {nextStateId} {scripts}(Vt: {Vt})"; }
        }
    }
}

