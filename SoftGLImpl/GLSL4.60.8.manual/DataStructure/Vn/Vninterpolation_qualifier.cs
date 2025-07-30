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
    /// Correspond to the Vn node interpolation_qualifier in the grammar(GLSL).
    /// </summary>
    partial class Vninterpolation_qualifier : Vnsingle_type_qualifier {
        // [125]: interpolation_qualifier : 'smooth' ;
        // [126]: interpolation_qualifier : 'flat' ;
        // [127]: interpolation_qualifier : 'noperspective' ;

        private readonly Token tkContent;
        public Vninterpolation_qualifier(Token tkContent) {
            this._tokenRange = new TokenRange(tkContent);
            this.tkContent = tkContent;
        }
        //public static readonly interpolation_qualifier smooth = new();
        //public static readonly interpolation_qualifier flat = new();
        //public static readonly interpolation_qualifier noperspective = new();
        private readonly TokenRange _tokenRange;


        public override TokenRange Scope => _tokenRange;


        public override string Name => this.tkContent.value;
        public override void FullFormat(BlankConfig? preConfig, TextWriter writer, FormatContext context) {
            //context.PrintBlanksAnd(this.tkContent, preConfig, writer);
            if (preConfig != null) {
                context.PrintBlanksBefore(this.tkContent, preConfig.Value, writer);
            }
            writer.Write("[interpolation("); writer.Write(this.tkContent.value); writer.Write(")]");
        }

        //public override void Format(TextWriter writer, FormatContext context) {
        //    writer.Write(this.tkContent.value);
        //}

        //public override IEnumerable<string> YieldTokens(TextWriter writer, FormatContext context) {
        //    writer.Write(this.tkContent.value); yield return this.tkContent.value;
        //    //if (false) { }
        //    //else if (this == smooth) {
        //    //    writer.Write(nameof(smooth)); yield return nameof(smooth);
        //    //}
        //    //else if (this == flat) {
        //    //    writer.Write(nameof(flat)); yield return nameof(flat);
        //    //}
        //    //else if (this == noperspective) {
        //    //    writer.Write(nameof(noperspective)); yield return nameof(noperspective);
        //    //}
        //    //else { throw new NotImplementedException(); }
        //}
    }
}
