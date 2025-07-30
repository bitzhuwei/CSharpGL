using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using bitzhuwei.Compiler;

namespace bitzhuwei.GLSLFormat {
    //partial class conditional_expression_bac : conditional_expression {
    //    private logical_or_expression logical_or_expression4;
    //    private expression expression2;
    //    private assignment_expression assignment_expression0;

    //    public conditional_expression_bac(logical_or_expression logical_or_expression4, expression expression2, assignment_expression assignment_expression0) {
    //        this.logical_or_expression4 = logical_or_expression4;
    //        this.expression2 = expression2;
    //        this.assignment_expression0 = assignment_expression0;
    //    }

    //    public override void Format(TextWriter writer, FormatContext context) {
    //        this.logical_or_expression4.Format(writer, context);
    //        this.expression2.Format(writer, context);
    //        this.assignment_expression0.Format(writer, context);
    //    }
    //}
    /// <summary>
    /// Correspond to the Vn node conditional_expression in the grammar(GLSL).
    /// </summary>
    partial class Vnconditional_expression : IFullFormat {
        // [70] conditional_expression : logical_or_expression ;
        // [71] conditional_expression : logical_or_expression '?' expression ':' assignment_expression ;

        private Vnlogical_or_expression logical_or_expression4;
        private readonly Token? tkQuestion;
        private Vnexpression? expression2;
        private readonly Token? tkColon;
        private Vnassignment_expression? assignment_expression0;

        public Vnconditional_expression(Vnlogical_or_expression logical_or_expression4,
            Token? tkQuestion,
            Vnexpression? expression2,
            Token? tkColon,
            Vnassignment_expression? assignment_expression0) {
            if (assignment_expression0 != null) { this._tokenRange = new TokenRange(logical_or_expression4, assignment_expression0); }
            else { this._tokenRange = new TokenRange(logical_or_expression4); }
            this.logical_or_expression4 = logical_or_expression4;
            this.tkQuestion = tkQuestion;
            this.expression2 = expression2;
            this.tkColon = tkColon;
            this.assignment_expression0 = assignment_expression0;
        }

        private readonly TokenRange _tokenRange;


        public TokenRange Scope => _tokenRange;


        public void FullFormat(BlankConfig? preConfig, TextWriter writer, FormatContext context) {
            this.logical_or_expression4.FullFormat(preConfig, writer, context);
            var config = new BlankConfig(inlineBlank: 1, forceNewline: false);
            if (this.tkQuestion != null) {
                context.PrintCommentsBetween(this.logical_or_expression4, this.tkQuestion, config, writer);
                context.PrintBlanksAnd(this.tkQuestion, config, writer);
            }
            if (this.tkQuestion != null && this.expression2 != null) {
                context.PrintCommentsBetween(this.tkQuestion, this.expression2, config, writer);
                this.expression2.FullFormat(config, writer, context);
            }
            if (this.expression2 != null && this.tkColon != null) {
                context.PrintCommentsBetween(this.expression2, this.tkColon, config, writer);
                context.PrintBlanksAnd(this.tkColon, config, writer);
            }
            if (this.tkColon != null && this.assignment_expression0 != null) {
                context.PrintCommentsBetween(this.tkColon, this.assignment_expression0, config, writer);
                this.assignment_expression0.FullFormat(config, writer, context);
            }
        }


        //public void Format(TextWriter writer, FormatContext context) {
        //    this.logical_or_expression4.Format(writer, context);
        //    if (this.expression2 != null) {
        //        writer.Write(" ? ");
        //        this.expression2.Format(writer, context);
        //    }
        //    if (this.assignment_expression0 != null) {
        //        writer.Write(" : ");
        //        this.assignment_expression0.Format(writer, context);
        //    }
        //}

        //public IEnumerable<string> YieldTokens(TextWriter writer, FormatContext context) {
        //    foreach (var item in this.logical_or_expression4.YieldTokens(writer, context)) {
        //        yield return item;
        //    }
        //    if (this.expression2 != null) {
        //        writer.Write(" ? "); yield return " ? ";
        //        foreach (var item in this.expression2.YieldTokens(writer, context)) {
        //            yield return item;
        //        }
        //    }
        //    if (this.assignment_expression0 != null) {
        //        writer.Write(" : "); yield return " : ";
        //        foreach (var item in this.assignment_expression0.YieldTokens(writer, context)) {
        //            yield return item;
        //        }
        //    }
        //}
    }
}
