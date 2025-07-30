using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;

namespace bitzhuwei.Compiler {

    /// <summary>
    /// else if ('0' <= c && c <= '9') { .. }
    /// </summary>
    public partial class ElseIf2 {
        public readonly char min;
        public readonly char max;
        public readonly int nextStateId;

        public readonly Acts scripts;
        [StructLayout(LayoutKind.Explicit)]
        internal struct Union {
            /// <summary>
            /// <para>Extend(LexicalContext context, int Vt);</para>
            /// <para>Accept(LexicalContext context, int Vt);</para>
            /// </summary>
            [FieldOffset(0)]
            //public VtWrap Vt;
            public int[] Vt;// I need a int, but it causes alignment problem. So I use int[1]. It's always int[1] here.
            /// <summary>
            /// <para>Extend2(LexicalContext context, int[] Vts);</para>
            /// <para>Accept2(LexicalContext context, int[] Vts);// only use Vts[0]</para> 
            /// </summary>
            [FieldOffset(0)]
            public int[] Vts;
            /// <summary>
            /// <para>Extend3(LexicalContext context, IfVt[] ifVts);</para>
            /// <para>Accept3(LexicalContext context, IfVt[] ifVts);</para>
            /// </summary>
            [FieldOffset(0)]
            public IfVt[] ifVts;
        }
        internal readonly Union union;

        public ElseIf2(char c, int nextStateId, Acts scripts, int Vt = 0)
            : this(c, c, nextStateId, scripts, Vt) { }
        public ElseIf2(char min, char max, int nextStateId, Acts scripts, int Vt = 0) {
            this.min = min;
            this.max = max;
            this.nextStateId = nextStateId;
            this.scripts = scripts;
            this.union.Vt = new int[] { Vt };// VtWrap.GetWrap(Vt);
        }

        public ElseIf2(char c, int nextStateId, Acts scripts, params int[] Vts)
            : this(c, c, nextStateId, scripts, Vts) { }
        public ElseIf2(char min, char max, int nextStateId, Acts scripts, params int[] Vts) {
            Debug.Assert(scripts.HasFlag(Acts.Extend2) || scripts.HasFlag(Acts.Accept2));
            this.min = min;
            this.max = max;
            this.nextStateId = nextStateId;
            this.scripts = scripts;
            this.union.Vts = Vts;
        }

        public ElseIf2(char c, int nextStateId, Acts scripts, params IfVt[] ifVts)
            : this(c, c, nextStateId, scripts, ifVts) { }
        public ElseIf2(char min, char max, int nextStateId, Acts scripts, params IfVt[] ifVts) {
            Debug.Assert(scripts.HasFlag(Acts.Extend3) || scripts.HasFlag(Acts.Accept3));
            this.min = min;
            this.max = max;
            this.nextStateId = nextStateId;
            this.scripts = scripts;
            this.union.ifVts = ifVts;
        }



        public override string ToString() {
            if (false) { }
            else if (this.scripts.HasFlag(Acts.Extend) || this.scripts.HasFlag(Acts.Accept)) {
                if (min < max) { return $"({min}->{max}) => {nextStateId} {scripts}(Vt: {union.Vt[0]})"; }
                // maybe something wrong.
                else if (min > max) { return $"({min}<-{max}) => {nextStateId} {scripts}(Vt: {union.Vt[0]})"; }
                else { return $"({min}) => {nextStateId} {scripts}(Vt: {union.Vt[0]})"; }
            }
            else if (this.scripts.HasFlag(Acts.Extend2) || this.scripts.HasFlag(Acts.Accept2)) {
                var builder = new StringBuilder();
                builder.Append("("); builder.Append(min);
                if (min < max) { builder.Append("->"); builder.Append(max); }
                // maybe something wrong.
                else if (min > max) { builder.Append("<-"); builder.Append(max); }
                else { /* nothing to do */ }
                builder.Append(") => "); builder.Append(nextStateId); builder.Append(" ");
                builder.Append(scripts);
                builder.Append("(Vts: ");
                var first = true;
                foreach (var Vt in this.union.Vts) {
                    if (first) { first = false; } else { builder.Append("/"); }
                    builder.Append(Vt);
                }
                builder.Append(")");
                return builder.ToString();
            }
            else if (this.scripts.HasFlag(Acts.Extend3) || this.scripts.HasFlag(Acts.Accept3)) {
                var builder = new StringBuilder();
                builder.Append("("); builder.Append(min);
                if (min < max) { builder.Append("->"); builder.Append(max); }
                // maybe something wrong.
                else if (min > max) { builder.Append("<-"); builder.Append(max); }
                else { /* nothing to do */ }
                builder.Append(") => "); builder.Append(nextStateId); builder.Append(" ");
                builder.Append(scripts);
                builder.Append("(ifVts: ");
                var first = true;
                foreach (var ifVt in this.union.ifVts) {
                    if (first) { first = false; } else { builder.Append("#"); }
                    builder.Append(ifVt.Vt);
                }
                builder.Append(")");
                return builder.ToString();
            }
            else {
                if (min < max) { return $"({min}->{max}) => {nextStateId} {scripts}"; }
                // maybe something wrong.
                else if (min > max) { return $"({min}<-{max}) => {nextStateId} {scripts}"; }
                else { return $"({min}) => {nextStateId} {scripts}"; }
            }
        }
    }
}

