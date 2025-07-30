using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using bitzhuwei.Compiler;
using SoftGLImpl;

namespace bitzhuwei.GLSLFormat {
    /// <summary>
    /// Correspond to the Vn node precise_qualifier in the grammar(GLSL).
    /// </summary>
    partial class Vnprecise_qualifier : Vnsingle_type_qualifier {
        // [134]: precise_qualifier : 'precise' ;

        private readonly Token tkPrecise;
        public Vnprecise_qualifier(Token tkPrecise) {
            this._tokenRange = new TokenRange(tkPrecise);
            this.tkPrecise = tkPrecise;
        }

        private readonly TokenRange _tokenRange;

        public override TokenRange Scope => _tokenRange;


        public override string Name => this.tkPrecise.value;
        public override void FullFormat(BlankConfig? preConfig, TextWriter writer, FormatContext context) {
            if (preConfig != null) {
                context.PrintBlanksBefore(this.tkPrecise, preConfig.Value, writer);
            }

            writer.Write("/*["); writer.Write(this.tkPrecise.value); writer.Write("]*/");
            //context.PrintBlanksAnd(this.tkPrecise, preConfig, writer);
        }

        //public override void Format(TextWriter writer, FormatContext context) {
        //    writer.Write(this.tkPrecise.value);
        //}

        //public override IEnumerable<string> YieldTokens(TextWriter writer, FormatContext context) {
        //    writer.Write(this.tkPrecise.value); yield return this.tkPrecise.value;
        //}
    }
}
