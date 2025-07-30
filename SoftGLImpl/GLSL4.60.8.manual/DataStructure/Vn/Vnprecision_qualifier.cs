using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using bitzhuwei.Compiler;

namespace bitzhuwei.GLSLFormat {
    /// <summary>
    /// Correspond to the Vn node precision_qualifier in the grammar(GLSL).
    /// </summary>
    partial class Vnprecision_qualifier : Vnsingle_type_qualifier {
        // [289]: precision_qualifier : 'highp' ;
        // [290]: precision_qualifier : 'mediump' ;
        // [291]: precision_qualifier : 'lowp' ;

        private readonly Token tkPrecision;
        public Vnprecision_qualifier(Token tkPrecision) {
            this._tokenRange = new TokenRange(tkPrecision);
            this.tkPrecision = tkPrecision;
        }

        private readonly TokenRange _tokenRange;

        public override TokenRange Scope => _tokenRange;


        public override string Name => this.tkPrecision.value;
        public override void FullFormat(BlankConfig? preConfig, TextWriter writer, FormatContext context) {
            //context.PrintBlanksAnd(this.tkPrecision, preConfig, writer);
            if (preConfig != null) {
                context.PrintBlanksBefore(this.tkPrecision, preConfig.Value, writer);
            }

            writer.Write("/*[precision(mode = "); writer.Write(this.tkPrecision.value); writer.Write(")]*/");
        }

        //public override void Format(TextWriter writer, FormatContext context) {
        //    writer.Write(this.tkPrecision.value);
        //}

        //public override IEnumerable<string> YieldTokens(TextWriter writer, FormatContext context) {
        //    writer.Write(this.tkPrecision.value); yield return this.tkPrecision.value;
        //}
    }
}
