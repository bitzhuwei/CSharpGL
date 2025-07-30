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
    /// Correspond to the Vn node invariant_qualifier in the grammar(GLSL).
    /// </summary>
    partial class Vninvariant_qualifier : Vnsingle_type_qualifier {
        // [124]: invariant_qualifier : 'invariant' ;

        private readonly Token tkContent;
        public Vninvariant_qualifier(Token tkContent) {
            this._tokenRange = new TokenRange(tkContent);
            this.tkContent = tkContent;
        }
        //public static readonly invariant_qualifier invariant = new();

        private readonly TokenRange _tokenRange;

        public override TokenRange Scope => _tokenRange;


        public override string Name => this.tkContent.value;
        public override void FullFormat(BlankConfig? preConfig, TextWriter writer, FormatContext context) {
            //context.PrintBlanksAnd(this.tkContent, preConfig, writer);

            if (preConfig != null) {
                context.PrintBlanksBefore(this.tkContent, preConfig.Value, writer);
            }
            writer.Write("["); writer.Write(this.tkContent.value); writer.Write("]");
        }

        //public override void Format(TextWriter writer, FormatContext context) {
        //    writer.Write(this.tkContent.value);
        //}
        //public override IEnumerable<string> YieldTokens(TextWriter writer, FormatContext context) {
        //    writer.Write(this.tkContent.value); yield return this.tkContent.value;
        //    //if (false) { }
        //    //else if (this == invariant) {
        //    //    writer.Write(nameof(invariant)); yield return nameof(invariant);
        //    //}
        //    //else { throw new NotImplementedException(); }
        //}
    }
}
