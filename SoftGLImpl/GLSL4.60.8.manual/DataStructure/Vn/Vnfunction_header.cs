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
    /// Correspond to the Vn node function_header in the grammar(GLSL).
    /// </summary>
    partial class Vnfunction_header : Vnfunction_declarator {
        // [104]: function_header : fully_specified_type 'identifier' '(' ;

        private Vnfully_specified_type fully_specified_type2;
        private Token identifier1;
        private readonly Token tkLeftParenthesis;

        public Vnfunction_header(Vnfully_specified_type fully_specified_type2,
            Token identifier1, Token tkLeftParenthesis) {
            this._tokenRange = new TokenRange(fully_specified_type2, tkLeftParenthesis);
            this.fully_specified_type2 = fully_specified_type2;
            this.identifier1 = identifier1;
            this.tkLeftParenthesis = tkLeftParenthesis;
        }

        private readonly TokenRange _tokenRange;


        public override TokenRange Scope => _tokenRange;


        public override void FullFormat(BlankConfig? preConfig, TextWriter writer, FormatContext context) {
            if (this.identifier1.value == "main") {// add "public override"
                var type_qualifier1 = this.fully_specified_type2.type_qualifier1;
                var type_specifier0 = this.fully_specified_type2.type_specifier0;
                if (type_qualifier1 != null) {
                    type_qualifier1.FullFormat(preConfig, writer, context);
                    var config = new BlankConfig(inlineBlank: 1, forceNewline: false);
                    var lastComment = context.PrintCommentsBetween(type_qualifier1, type_specifier0, config, writer);
                    config.inlineBlank = lastComment != FormatContext.LastComment.None ? 0 : 1;
                    context.PrintBlanksBefore(type_specifier0, config, writer);
                    writer.Write("public override ");
                    type_specifier0.FullFormat(null, writer, context);
                }
                else {
                    if (preConfig != null) {
                        context.PrintBlanksBefore(type_specifier0, preConfig.Value, writer);
                    }
                    writer.Write("public override ");
                    type_specifier0.FullFormat(null, writer, context);
                }
            }
            else {
                this.fully_specified_type2.FullFormat(preConfig, writer, context);
            }
            {
                var config = new BlankConfig(inlineBlank: 1, forceNewline: false);
                var lastComment = context.PrintCommentsBetween(this.fully_specified_type2, this.identifier1, config, writer);
                config.inlineBlank = lastComment != FormatContext.LastComment.None ? 0 : 1;
                context.PrintBlanksAnd(this.identifier1, config, writer);
                config.inlineBlank = 1;
                context.PrintCommentsBetween(this.identifier1, this.tkLeftParenthesis, config, writer);
                config.inlineBlank = 0;
                context.PrintBlanksAnd(this.tkLeftParenthesis, config, writer);
            }
        }

        //public override void Format(TextWriter writer, FormatContext context) {
        //    this.fully_specified_type2.Format(writer, context);
        //    writer.Write(" ");
        //    writer.Write(this.identifier1.value);
        //    writer.Write(this.tkLeftParenthesis.value);
        //}

        //public override IEnumerable<string> YieldTokens(TextWriter writer, FormatContext context) {
        //    foreach (var item in this.fully_specified_type2.YieldTokens(writer, context)) {
        //        yield return item;
        //    }
        //    writer.Write(" ");
        //    writer.Write(this.identifier1.value); yield return this.identifier1.value;
        //    writer.Write(this.tkLeftParenthesis.value); yield return this.tkLeftParenthesis.value;
        //}
    }
}
