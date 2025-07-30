using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using bitzhuwei.Compiler;

namespace bitzhuwei.GLSLFormat {
    /// <summary>
    /// Correspond to the Vn node fully_specified_type in the grammar(GLSL).
    /// </summary>
    partial class Vnfully_specified_type : IFullFormat {
        // [122]: fully_specified_type : type_specifier ;
        // [123]: fully_specified_type : type_qualifier type_specifier ;

        public readonly Vntype_qualifier? type_qualifier1;
        public readonly Vntype_specifier type_specifier0;

        public Vnfully_specified_type(Vntype_qualifier? type_qualifier1, Vntype_specifier type_specifier0) {
            if (type_qualifier1 != null) { this._tokenRange = new TokenRange(type_qualifier1, type_specifier0); }
            else { this._tokenRange = new TokenRange(type_specifier0); }
            this.type_qualifier1 = type_qualifier1;
            this.type_specifier0 = type_specifier0;
        }
        private readonly TokenRange _tokenRange;


        public TokenRange Scope => _tokenRange;


        public void FullFormat(BlankConfig? preConfig, TextWriter writer, FormatContext context) {
            if (this.type_qualifier1 != null) {
                this.type_qualifier1.FullFormat(preConfig, writer, context);
                var config = new BlankConfig(inlineBlank: 1, forceNewline: false);
                var lastComment = context.PrintCommentsBetween(this.type_qualifier1, this.type_specifier0, config, writer);
                config.inlineBlank = lastComment != FormatContext.LastComment.None ? 0 : 1;
                this.type_specifier0.FullFormat(config, writer, context);
            }
            else {
                this.type_specifier0.FullFormat(preConfig, writer, context);
            }
        }


        //public void Format(TextWriter writer, FormatContext context) {
        //    if (this.type_qualifier1 != null) {
        //        this.type_qualifier1.Format(writer, context); writer.Write(" ");
        //    }

        //    this.type_specifier0.Format(writer, context);
        //}

        //public IEnumerable<string> YieldTokens(TextWriter writer, FormatContext context) {
        //    if (this.type_qualifier1 != null) {
        //        foreach (var item in this.type_qualifier1.YieldTokens(writer, context)) {
        //            yield return item;
        //        }
        //        writer.Write(" ");
        //    }

        //    foreach (var item in this.type_specifier0.YieldTokens(writer, context)) {
        //        yield return item;
        //    }
        //}

        internal string? GetStructName() {
            return this.type_specifier0.GetStructName();
        }

        internal string GetTypeName() {
            return this.type_specifier0.GetTypeName();
        }
    }
}
