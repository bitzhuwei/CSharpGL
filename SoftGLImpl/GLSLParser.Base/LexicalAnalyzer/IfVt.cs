using System;
using System.Text;

namespace bitzhuwei.Compiler {

    public class IfVt {
        public readonly string signalCondition;
        public readonly int preVt;
        public readonly int Vt;
        public readonly string? nextSignal;
        public IfVt(string signalCondition, int preVt, int Vt, string? nextSignal = null) {
            this.signalCondition = signalCondition;
            this.preVt = preVt;
            this.Vt = Vt;
            this.nextSignal = nextSignal;
        }
        public override string ToString() {
            var builder = new StringBuilder();
            if (signalCondition != LexicalContext.defaultSignal) {
                builder.Append("<");
                builder.Append(signalCondition);
                builder.Append(">");
            }
            if (preVt != 0) { // 0 means Symbol.EOF('¥')
                builder.Append("<'");
                builder.Append(preVt);
                builder.Append("'>");
            }
            builder.Append(this.Vt);
            if (this.nextSignal != null) {
                builder.Append(" (");
                builder.Append(this.nextSignal);
                builder.Append(")");
            }
            return builder.ToString();
        }
    }
}

