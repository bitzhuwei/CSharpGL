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
    /// Correspond to the Vn node initializer in the grammar(GLSL).
    /// </summary>
    partial class Vninitializer : IFullFormat {
        // [302]: initializer : assignment_expression ;
        // [303]: initializer : '{' initializer_list '}' ;
        // [304]: initializer : '{' initializer_list ',' '}' ;

        // only one field is valid.
        private Vnassignment_expression? assignment_expression0;
        private Tuple<Token, Vninitializer_list, Token?, Token>? initializer_listTuple;
        public Vninitializer(Vnassignment_expression assignment_expression0) {
            this._tokenRange = new TokenRange(assignment_expression0);
            this.assignment_expression0 = assignment_expression0;
        }
        public Vninitializer(Token tkLeftBrace, Vninitializer_list initializer_list1, Token? tkComma, Token tkRightBrace) {
            this._tokenRange = new TokenRange(tkLeftBrace, tkRightBrace);
            this.initializer_listTuple = new Tuple<Token, Vninitializer_list, Token?, Token>(
                tkLeftBrace, initializer_list1, tkComma, tkRightBrace);
        }
        private readonly TokenRange _tokenRange;


        public TokenRange Scope => _tokenRange;


        public void FullFormat(BlankConfig? preConfig, TextWriter writer, FormatContext context) {
            if (this.assignment_expression0 != null) {
                //this.assignment_expression0.FullFormat(preConfig, writer, context);
                if (preConfig != null) {
                    context.PrintBlanksBefore(this.assignment_expression0, preConfig.Value, writer);
                }
                context.inInitArray = true;
                context.PrintBlanksAnd(this.assignment_expression0, null, writer);
                context.inInitArray = false;
            }
            else if (this.initializer_listTuple != null) {
                var tkLeftBrace = this.initializer_listTuple.Item1;
                var init = this.initializer_listTuple.Item2;
                var tkComma = this.initializer_listTuple.Item3;
                var tkRightBrace = this.initializer_listTuple.Item4;
                context.PrintBlanksAnd(tkLeftBrace, preConfig, writer);
                var config = new BlankConfig(inlineBlank: 1, forceNewline: false);
                context.PrintCommentsBetween(tkLeftBrace, init, config, writer);
                var config2 = new BlankConfig(inlineBlank: 1,
                    forceNewline: tkRightBrace.start.line > tkLeftBrace.end.line);
                init.FullFormat(config2, writer, context);
                if (tkComma != null) {
                    config.inlineBlank = 0;
                    context.PrintCommentsBetween(init, tkComma, config, writer);
                    context.PrintBlanksAnd(tkComma, config, writer);
                }

                config.inlineBlank = 1;
                if (tkComma != null) {
                    context.PrintCommentsBetween(tkComma, tkRightBrace, config, writer);
                }
                else {
                    context.PrintCommentsBetween(init, tkRightBrace, config, writer);
                }
                context.PrintBlanksAnd(tkRightBrace, config, writer);
            }
            else { throw new NotImplementedException(); }
        }


        //public void Format(TextWriter writer, FormatContext context) {
        //    if (this.assignment_expression0 != null) {
        //        this.assignment_expression0.Format(writer, context);
        //    }
        //    else if (this.initializer_listTuple != null) {
        //        var tkLeftBrace = this.initializer_listTuple.Item1;
        //        var init = this.initializer_listTuple.Item2;
        //        var tkComma = this.initializer_listTuple.Item3;
        //        var tkRightBrace = this.initializer_listTuple.Item4;
        //        writer.Write(tkLeftBrace.value);
        //        writer.Write(" ");
        //        init.Format(writer, context);
        //        if (tkComma != null) {
        //            writer.Write(tkComma.value);
        //        }
        //        writer.Write(" ");
        //        writer.Write(tkRightBrace.value);
        //    }
        //    else { throw new NotImplementedException(); }
        //}

        //public IEnumerable<string> YieldTokens(TextWriter writer, FormatContext context) {
        //    if (this.assignment_expression0 != null) {
        //        foreach (var item in this.assignment_expression0.YieldTokens(writer, context)) {
        //            yield return item;
        //        }
        //    }
        //    else if (this.initializer_listTuple != null) {
        //        var tkLeftBrace = this.initializer_listTuple.Item1;
        //        var init = this.initializer_listTuple.Item2;
        //        var tkComma = this.initializer_listTuple.Item3;
        //        var tkRightBrace = this.initializer_listTuple.Item4;
        //        writer.Write(tkLeftBrace.value); yield return tkLeftBrace.value;
        //        writer.Write(" ");
        //        foreach (var item in init.YieldTokens(writer, context)) {
        //            yield return item;
        //        }
        //        if (tkComma != null) {
        //            writer.Write(tkComma.value); yield return tkComma.value;
        //        }
        //        writer.Write(" ");
        //        writer.Write(tkRightBrace.value); yield return tkRightBrace.value;
        //    }
        //    else { throw new NotImplementedException(); }
        //}
    }

    //partial class simple_initializer : initializer {
    //    private assignment_expression assignment_expression0;

    //    public simple_initializer(assignment_expression assignment_expression0) {
    //        this.assignment_expression0 = assignment_expression0;
    //    }
    //}

    //partial class list_initializer : initializer {
    //    private initializer_list initializer_list1;

    //    public list_initializer(initializer_list initializer_list1) {
    //        this.initializer_list1 = initializer_list1;
    //    }
    //}

}
