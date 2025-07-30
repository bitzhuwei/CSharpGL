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
    /// Correspond to the Vn node parameter_declarator in the grammar(GLSL).
    /// </summary>
    partial class Vnparameter_declarator : IFullFormat {
        // [105]: parameter_declarator : type_specifier 'identifier' ;
        // [106]: parameter_declarator : type_specifier 'identifier' array_specifier ;

        private Vntype_specifier type_specifier2;
        private Token identifier1;
        private Vnarray_specifier? array_specifier0;

        public Vnparameter_declarator(
            Vntype_specifier type_specifier2, Token identifier1, Vnarray_specifier? array_specifier0) {
            if (array_specifier0 != null) { this._tokenRange = new TokenRange(type_specifier2, array_specifier0); }
            else { this._tokenRange = new TokenRange(type_specifier2, identifier1); }
            this.type_specifier2 = type_specifier2;
            this.identifier1 = identifier1;
            this.array_specifier0 = array_specifier0;
        }

        private readonly TokenRange _tokenRange;


        public TokenRange Scope => _tokenRange;

        vec3[] aaa = new vec3[3];

        public void FullFormat(BlankConfig? preConfig, TextWriter writer, FormatContext context) {
            this.type_specifier2.FullFormat(preConfig, writer, context);
            var config = new BlankConfig(inlineBlank: 1, forceNewline: false);
            if (this.array_specifier0 != null) {
                //this.array_specifier0.FullFormat(config, writer, context);
                writer.Write("[]");
            }
            context.PrintCommentsBetween(this.type_specifier2, this.identifier1, config, writer);
            context.PrintBlanksAnd(this.identifier1, config, writer);
            if (this.array_specifier0 != null) {
                context.PrintCommentsBetween(this.identifier1, this.array_specifier0, config, writer);
                writer.Write("/*");
                this.array_specifier0.FullFormat(config, writer, context);
                writer.Write("*/");
            }

            //original version
            //this.type_specifier2.FullFormat(preConfig, writer, context);
            //var config = new BlankConfig(inlineBlank: 1, forceNewline: false);
            //context.PrintCommentsBetween(this.type_specifier2, this.identifier1, config, writer);
            //context.PrintBlanksAnd(this.identifier1, config, writer);
            //if (this.array_specifier0 != null) {
            //    context.PrintCommentsBetween(this.identifier1, this.array_specifier0, config, writer);
            //    this.array_specifier0.FullFormat(config, writer, context);
            //}
        }


        //public void Format(TextWriter writer, FormatContext context) {
        //    this.type_specifier2.Format(writer, context);
        //    writer.Write(" ");
        //    writer.Write(this.identifier1.value);
        //    if (this.array_specifier0 != null) {
        //        this.array_specifier0.Format(writer, context);
        //    }
        //}

        //public IEnumerable<string> YieldTokens(TextWriter writer, FormatContext context) {
        //    foreach (var item in this.type_specifier2.YieldTokens(writer, context)) {
        //        yield return item;
        //    }
        //    writer.Write(" ");
        //    writer.Write(this.identifier1.value); yield return this.identifier1.value;
        //    if (this.array_specifier0 != null) {
        //        foreach (var item in this.array_specifier0.YieldTokens(writer, context)) {
        //            yield return item;
        //        }
        //    }
        //}
    }
}
