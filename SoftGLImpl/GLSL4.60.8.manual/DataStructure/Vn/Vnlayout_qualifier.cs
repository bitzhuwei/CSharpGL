using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using bitzhuwei.Compiler;
using SoftGLImpl;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace bitzhuwei.GLSLFormat {
    /// <summary>
    /// Correspond to the Vn node layout_qualifier in the grammar(GLSL).
    /// </summary>
    partial class Vnlayout_qualifier : Vnsingle_type_qualifier {

        // [128]: layout_qualifier : 'layout' '(' layout_qualifier_id_list ')' ;

        //[layout
        //    (
        //    location
        //    =
        //    1
        //    )
        //    ]
        private readonly Token tkLayout;
        private readonly Token tkLeftParenthesis;
        private Vnlayout_qualifier_id_list layout_qualifier_id_list1;
        private readonly Token tkRightParenthesis;

        public Vnlayout_qualifier(Token tkLayout, Token tkLeftParenthesis,
            Vnlayout_qualifier_id_list layout_qualifier_id_list1, Token tkRightParenthesis) {
            this._tokenRange = new TokenRange(tkLayout, tkRightParenthesis);
            this.tkLayout = tkLayout;
            this.tkLeftParenthesis = tkLeftParenthesis;
            this.layout_qualifier_id_list1 = layout_qualifier_id_list1;
            this.tkRightParenthesis = tkRightParenthesis;
        }
        private readonly TokenRange _tokenRange;


        public override TokenRange Scope => _tokenRange;


        public override string Name => this.tkLayout.value;
        public override void FullFormat(BlankConfig? preConfig, TextWriter writer, FormatContext context) {
            if (preConfig != null) {
                context.PrintBlanksBefore(this.tkLayout, preConfig.Value, writer);
            }
            writer.Write("[layout");
            var config = new BlankConfig(inlineBlank: 0, forceNewline: false);
            context.PrintCommentsBetween(this.tkLayout, this.tkLeftParenthesis, config, writer);
            context.PrintBlanksAnd(this.tkLeftParenthesis, config, writer);
            context.PrintCommentsBetween(this.tkLeftParenthesis, this.layout_qualifier_id_list1, config, writer);
            context.PrintBlanksAnd(this.layout_qualifier_id_list1, config, writer);
            context.PrintCommentsBetween(this.layout_qualifier_id_list1, this.tkRightParenthesis, config, writer);
            context.PrintBlanksAnd(this.tkRightParenthesis, config, writer);
            writer.Write("]");

            // original version
            //context.PrintBlanksAnd(this.tkLayout, preConfig, writer);
            //var config = new BlankConfig(inlineBlank: 0, forceNewline: false);
            //context.PrintCommentsBetween(this.tkLayout, this.tkLeftParenthesis, config, writer);
            //context.PrintBlanksAnd(this.tkLeftParenthesis, config, writer);
            //context.PrintCommentsBetween(this.tkLeftParenthesis, this.layout_qualifier_id_list1, config, writer);
            //this.layout_qualifier_id_list1.FullFormat(config, writer, context);
            //context.PrintCommentsBetween(this.layout_qualifier_id_list1, this.tkRightParenthesis, config, writer);
            //context.PrintBlanksAnd(this.tkRightParenthesis, config, writer);
        }

        //public override void Format(TextWriter writer, FormatContext context) {
        //    writer.Write(this.tkLayout.value);
        //    writer.Write(this.tkLeftParenthesis.value);
        //    this.layout_qualifier_id_list1.Format(writer, context);
        //    writer.Write(this.tkRightParenthesis.value);
        //}

        //public override IEnumerable<string> YieldTokens(TextWriter writer, FormatContext context) {
        //    writer.Write(this.tkLayout.value); yield return this.tkLayout.value;
        //    writer.Write(this.tkLeftParenthesis.value); yield return this.tkLeftParenthesis.value;
        //    foreach (var item in this.layout_qualifier_id_list1.YieldTokens(writer, context)) {
        //        yield return item;
        //    }
        //    writer.Write(this.tkRightParenthesis.value); yield return this.tkRightParenthesis.value;
        //}
    }
}
