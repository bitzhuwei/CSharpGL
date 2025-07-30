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
    /// Correspond to the Vn node primary_expression in the grammar(GLSL).
    /// </summary>
    partial class Vnprimary_expression : IFullFormat {
        // [7]: primary_expression : variable_identifier ;
        // [8]: primary_expression : 'intConstant' ;
        // [9]: primary_expression : 'uintConstant' ;
        // [10]: primary_expression : 'floatConstant' ;
        // [11]: primary_expression : 'boolConstant' ;
        // [12]: primary_expression : 'doubleConstant' ;
        // [13]: primary_expression : '(' expression ')' ;

        //public enum EType {
        //    variable_identifier, // Token
        //    intConstant, // Token
        //    uintConstant, // Token
        //    floatConstant, // Token
        //    boolConstant, // Token
        //    doubleConstant, // Token
        //    expression, // '(' expression ')'
        //}

        //private EType type;
        //private Token? token;
        //private expression? expression1;
        private readonly Token? token;
        private readonly IFullFormat? formatter;

        public Vnprimary_expression(Token token) {
            this._tokenRange = new TokenRange(token);
            this.token = token;
        }

        public Vnprimary_expression(Vnvariable_identifier formatter) {
            this._tokenRange = new TokenRange(formatter);
            this.formatter = formatter;
        }
        public Vnprimary_expression(Token tkLeftParenthesis, Vnexpression exp1, Token tkRightParenthesis) {
            this._tokenRange = new TokenRange(tkLeftParenthesis, tkRightParenthesis);
            this.formatter = new ParenthesisExp(tkLeftParenthesis, exp1, tkRightParenthesis);
        }


        private readonly TokenRange _tokenRange;


        public TokenRange Scope => _tokenRange;


        public void FullFormat(BlankConfig? preConfig, TextWriter writer, FormatContext context) {
            if (this.token != null) {
                context.PrintBlanksAnd(this.token, preConfig, writer);
            }
            else if (this.formatter != null) {
                this.formatter.FullFormat(preConfig, writer, context);
            }
            else { throw new NotImplementedException(); }
        }


        //public void Format(TextWriter writer, FormatContext context) {
        //    if (this.token != null) {
        //        writer.Write(this.token.value);
        //    }
        //    else if (this.formatter != null) {
        //        this.formatter.Format(writer, context);
        //    }
        //    else { throw new NotImplementedException(); }
        //}

        //public IEnumerable<string> YieldTokens(TextWriter writer, FormatContext context) {
        //    if (this.token != null) {
        //        writer.Write(this.token.value); yield return this.token.value;
        //    }
        //    else if (this.formatter != null) {
        //        foreach (var item in this.formatter.YieldTokens(writer, context)) {
        //            yield return item;
        //        }
        //    }
        //    else { throw new NotImplementedException(); }
        //}

        class ParenthesisExp : IFullFormat {
            private Token tkLeftParenthesis;
            private Vnexpression exp1;
            private Token tkRightParenthesis;

            public ParenthesisExp(Token tkLeftParenthesis, Vnexpression exp1, Token tkRightParenthesis) {
                this._tokenRange = new TokenRange(tkLeftParenthesis, tkRightParenthesis);
                this.tkLeftParenthesis = tkLeftParenthesis;
                this.exp1 = exp1;
                this.tkRightParenthesis = tkRightParenthesis;
            }

            private readonly TokenRange _tokenRange;
            public TokenRange Scope => _tokenRange;


            public void FullFormat(BlankConfig? preConfig, TextWriter writer, FormatContext context) {
                context.PrintBlanksAnd(this.tkLeftParenthesis, preConfig, writer);
                var config = new BlankConfig(inlineBlank: 0, forceNewline: false);
                context.PrintCommentsBetween(this.tkLeftParenthesis, this.exp1, config, writer);
                this.exp1.FullFormat(config, writer, context);
                context.PrintCommentsBetween(this.exp1, this.tkRightParenthesis, config, writer);
                context.PrintBlanksAnd(this.tkRightParenthesis, config, writer);
            }
            //public void Format(TextWriter writer, FormatContext context) {
            //    writer.Write(this.tkLeftParenthesis.value);
            //    this.exp1.Format(writer, context);
            //    writer.Write(this.tkRightParenthesis.value);
            //}

            //public IEnumerable<string> YieldTokens(TextWriter writer, FormatContext context) {
            //    writer.Write(this.tkLeftParenthesis.value); yield return this.tkLeftParenthesis.value;
            //    this.exp1.Format(writer, context);
            //    foreach (var item in this.exp1.YieldTokens(writer, context)) {
            //        yield return item;
            //    }
            //    writer.Write(this.tkRightParenthesis.value); yield return this.tkRightParenthesis.value;
            //}
        }
    }
}
