using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using bitzhuwei.Compiler;
using static bitzhuwei.GLSLFormat.Vnunary_expression;

namespace bitzhuwei.GLSLFormat {
    /// <summary>
    /// Correspond to the Vn node postfix_expression in the grammar(GLSL).
    /// </summary>
    partial class Vnpostfix_expression : IFullFormat {
        // [14]: postfix_expression : primary_expression ;
        // [15]: postfix_expression : postfix_expression '[' integer_expression ']' ;
        // [16]: postfix_expression : function_call ;
        // [17]: postfix_expression : postfix_expression '.' 'identifier' ;
        // [18]: postfix_expression : postfix_expression '++' ;
        // [19]: postfix_expression : postfix_expression '--' ;

        //// use either primary_expression0 or function_call0
        //public primary_expression? primary_expression0;
        //public function_call? function_call0;
        private readonly IFullFormat first;
        private readonly List<IFullFormat> list = new();
        internal void Add(Token tkLeftBracket,
            Vninteger_expression integer_expression1, Token tkRightBracket) {
            var item = new array_(tkLeftBracket, integer_expression1, tkRightBracket);
            this.list.Add(item);
            this._tokenRange.end = tkRightBracket.index;
        }
        internal void Add(Token tkDot, Token tkIdentifier) {
            var item = new dot_x(tkDot, tkIdentifier);
            this.list.Add(item);
            this._tokenRange.end = tkIdentifier.index;
        }
        internal void Add(Token tkUnary) {
            var item = new unary_op(tkUnary);
            this.list.Add(item);
            this._tokenRange.end = tkUnary.index;
        }
        public Vnpostfix_expression(Vnprimary_expression primary_expression0) {
            this._tokenRange = new TokenRange(primary_expression0);
            this.first = primary_expression0;
            this._tokenRange.end = primary_expression0.Scope.end;
        }

        public Vnpostfix_expression(Vnfunction_call function_call0) {
            this._tokenRange = new TokenRange(function_call0);
            this.first = function_call0;
            this._tokenRange.end = function_call0.Scope.end;
        }

        //// integer_expression : [ {integer_expression} ]
        //// Token : .{Token.value}
        //// object addAdd : ++
        //// object minusMinus : --

        private readonly TokenRange _tokenRange;


        public TokenRange Scope => _tokenRange;


        public void FullFormat(BlankConfig? preConfig, TextWriter writer, FormatContext context) {
            {
                this.first.FullFormat(preConfig, writer, context);
            }
            var config = new BlankConfig(inlineBlank: 0, forceNewline: false);
            var first = true;
            for (var i = 0; i < this.list.Count; i++) {
                var exp = this.list[i];
                if (first) {
                    context.PrintCommentsBetween(this.first, exp, config, writer);
                    first = false;
                }
                else {
                    context.PrintCommentsBetween(this.list[i - 1], exp, config, writer);
                }
                if (i > 0 && exp is unary_op && this.list[i - 1] is unary_op) {
                    config.inlineBlank = 1;
                }
                else { config.inlineBlank = 0; }
                exp.FullFormat(config, writer, context);
            }
        }


        //public void Format(TextWriter writer, FormatContext context) {
        //    {
        //        this.first.Format(writer, context);
        //    }
        //    for (var i = 0; i < this.list.Count; i++) {
        //        var exp = this.list[i];
        //        exp.Format(writer, context);
        //        if (i + 1 < this.list.Count) { writer.Write(" "); }
        //    }
        //}

        //public IEnumerable<string> YieldTokens(TextWriter writer, FormatContext context) {
        //    {
        //        foreach (var item in this.first.YieldTokens(writer, context)) {
        //            yield return item;
        //        }
        //    }
        //    for (var i = 0; i < this.list.Count; i++) {
        //        var exp = this.list[i];
        //        foreach (var item in exp.YieldTokens(writer, context)) {
        //            yield return item;
        //            if (i + 1 < this.list.Count) { writer.Write(" "); }
        //        }
        //    }
        //}


        class array_ : IFullFormat {
            private Token tkLeftBracket;
            private Vninteger_expression integer_expression1;
            private Token tkRightBracket;

            public array_(Token tkLeftBracket,
                Vninteger_expression integer_Expression1,
                Token tkRightBracket) {
                this._tokenRange = new TokenRange(tkLeftBracket, tkRightBracket);
                this.tkLeftBracket = tkLeftBracket;
                this.integer_expression1 = integer_Expression1;
                this.tkRightBracket = tkRightBracket;
            }

            private TokenRange _tokenRange;
            public TokenRange Scope => _tokenRange;


            public void FullFormat(BlankConfig? preConfig, TextWriter writer, FormatContext context) {
                context.PrintBlanksAnd(this.tkLeftBracket, preConfig, writer);
                var config = new BlankConfig(inlineBlank: 0, forceNewline: false);
                context.PrintCommentsBetween(this.tkLeftBracket, this.integer_expression1, config, writer);
                this.integer_expression1.FullFormat(config, writer, context);
                context.PrintCommentsBetween(this.integer_expression1, this.tkRightBracket, config, writer);
                context.PrintBlanksAnd(this.tkRightBracket, config, writer);
            }
            //public void Format(TextWriter writer, FormatContext context) {
            //    writer.Write(this.tkLeftBracket.value);
            //    this.integer_expression1.Format(writer, context);
            //    writer.Write(this.tkRightBracket.value);
            //}

            //public IEnumerable<string> YieldTokens(TextWriter writer, FormatContext context) {
            //    writer.Write(this.tkLeftBracket.value); yield return this.tkLeftBracket.value;
            //    this.integer_expression1.Format(writer, context);
            //    foreach (var item in this.integer_expression1.YieldTokens(writer, context)) {
            //        yield return item;
            //    }
            //    writer.Write(this.tkRightBracket.value); yield return this.tkRightBracket.value;
            //}
        }
        class dot_x : IFullFormat {
            private Token tkDot;
            private Token tkIdentifier;

            public dot_x(Token tkDot, Token tkIdentifier) {
                this.tkDot = tkDot;
                this.tkIdentifier = tkIdentifier;
                this._tokenRange = new TokenRange(tkDot, tkIdentifier);
            }

            private TokenRange _tokenRange;
            public TokenRange Scope => _tokenRange;


            public void FullFormat(BlankConfig? preConfig, TextWriter writer, FormatContext context) {
                context.PrintBlanksAnd(this.tkDot, preConfig, writer);
                var config = new BlankConfig(inlineBlank: 0, forceNewline: false);
                context.PrintCommentsBetween(this.tkDot, this.tkIdentifier, config, writer);
                context.PrintBlanksAnd(this.tkIdentifier, config, writer);
            }
            //public void Format(TextWriter writer, FormatContext context) {
            //    writer.Write(this.tkDot.value);
            //    writer.Write(this.tkIdentifier.value);
            //}

            //public IEnumerable<string> YieldTokens(TextWriter writer, FormatContext context) {
            //    writer.Write(this.tkDot.value); yield return this.tkDot.value;
            //    writer.Write(this.tkIdentifier.value); yield return this.tkIdentifier.value;
            //}
        }
        class unary_op : IFullFormat {
            private Token tkUnary;

            public unary_op(Token tkUnary) {
                this.tkUnary = tkUnary;
                this._tokenRange = new TokenRange(tkUnary);
            }

            private TokenRange _tokenRange;
            public TokenRange Scope => _tokenRange;



            public void FullFormat(BlankConfig? preConfig, TextWriter writer, FormatContext context) {
                context.PrintBlanksAnd(this.tkUnary, preConfig, writer);
            }
            //public void Format(TextWriter writer, FormatContext context) {
            //    writer.Write(this.tkUnary.value);
            //}

            //public IEnumerable<string> YieldTokens(TextWriter writer, FormatContext context) {
            //    writer.Write(this.tkUnary.value); yield return this.tkUnary.value;
            //}
        }
    }
}
