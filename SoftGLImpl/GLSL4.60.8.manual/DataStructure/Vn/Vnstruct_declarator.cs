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
    /// Correspond to the Vn node struct_declarator in the grammar(GLSL).
    /// </summary>
    partial class Vnstruct_declarator : IFullFormat {
        // [300]: struct_declarator : 'identifier' ;
        // [301]: struct_declarator : 'identifier' array_specifier ;

        public Token identifier1;
        public Vnarray_specifier? array_specifier0;

        public Vnstruct_declarator(Token identifier1, Vnarray_specifier? array_specifier0) {
            if (array_specifier0 != null) { this._tokenRange = new TokenRange(identifier1, array_specifier0); }
            else { this._tokenRange = new TokenRange(identifier1); }
            this.identifier1 = identifier1;
            this.array_specifier0 = array_specifier0;
        }
        private readonly TokenRange _tokenRange;


        public TokenRange Scope => _tokenRange;


        public void FullFormat(BlankConfig? preConfig, TextWriter writer, FormatContext context) {
            context.PrintBlanksAnd(this.identifier1, preConfig, writer);
            if (this.array_specifier0 != null) {
                var config = new BlankConfig(inlineBlank: 0, forceNewline: false);
                context.PrintCommentsBetween(this.identifier1, this.array_specifier0, config, writer);
                this.array_specifier0.FullFormat(config, writer, context);
            }
        }


        //public void Format(TextWriter writer, FormatContext context) {
        //    writer.Write(this.identifier1.value);
        //    if (this.array_specifier0 != null) {
        //        this.array_specifier0.Format(writer, context);
        //    }
        //}

        //public IEnumerable<string> YieldTokens(TextWriter writer, FormatContext context) {
        //    writer.Write(this.identifier1.value); yield return this.identifier1.value;
        //    if (this.array_specifier0 != null) {
        //        foreach (var item in array_specifier0.YieldTokens(writer, context)) {
        //            yield return item;
        //        }
        //    }
        //}
    }
}
