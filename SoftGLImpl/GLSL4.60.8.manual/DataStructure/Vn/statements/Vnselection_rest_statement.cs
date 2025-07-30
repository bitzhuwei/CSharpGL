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
    /// Correspond to the Vn node selection_rest_statement in the grammar(GLSL).
    /// </summary>
    partial class Vnselection_rest_statement : IFullFormat {
        // [324]: selection_rest_statement : statement 'else' statement ;
        // [325]: selection_rest_statement : statement ;

        private Vnstatement ifStatement;
        private readonly Token? tkElse;
        private Vnstatement? elseStatement;

        public Vnselection_rest_statement(Vnstatement ifStatement, Token? tkElse, Vnstatement? elseStatement) {
            if (elseStatement != null) { this._tokenRange = new TokenRange(ifStatement, elseStatement); }
            else if (tkElse != null) { this._tokenRange = new TokenRange(ifStatement, tkElse); }
            else { this._tokenRange = new TokenRange(ifStatement); }
            this.ifStatement = ifStatement;
            this.tkElse = tkElse;
            this.elseStatement = elseStatement;
        }
        private readonly TokenRange _tokenRange;


        public TokenRange Scope => _tokenRange;


        public void FullFormat(BlankConfig? preConfig, TextWriter writer, FormatContext context) {
            this.ifStatement.FullFormat(preConfig, writer, context);
            if (this.tkElse != null && this.elseStatement != null) {
                var config = new BlankConfig(inlineBlank: 1, forceNewline: false);
                context.PrintCommentsBetween(this.ifStatement, this.tkElse, config, writer);
                config.forceNewline = true;
                context.PrintBlanksAnd(this.tkElse, config, writer);
                context.PrintCommentsBetween(this.tkElse, this.elseStatement, config, writer);
                config.forceNewline = false;
                this.elseStatement.FullFormat(config, writer, context);
            }
            else if (this.tkElse == null && this.elseStatement == null) { }
            else { throw new NotImplementedException(); }
        }


        //public void Format(TextWriter writer, FormatContext context) {
        //    this.ifStatement.Format(writer, context);
        //    if (this.tkElse != null && this.elseStatement != null) {
        //        writer.WriteLine();
        //        context.PrintTab(writer);
        //        writer.Write(this.tkElse.value);
        //        writer.Write(" ");
        //        this.elseStatement.Format(writer, context);
        //    }
        //    else if (this.tkElse == null && this.elseStatement == null) { }
        //    else { throw new NotImplementedException(); }
        //}

        //public IEnumerable<string> YieldTokens(TextWriter writer, FormatContext context) {
        //    foreach (var item in this.ifStatement.YieldTokens(writer, context)) {
        //        yield return item;
        //    }
        //    if (this.tkElse != null && this.elseStatement != null) {
        //        writer.WriteLine();
        //        context.PrintTab(writer);
        //        writer.Write(this.tkElse.value); yield return this.tkElse.value;
        //        writer.Write(" ");
        //        foreach (var item in this.elseStatement.YieldTokens(writer, context)) {
        //            yield return item;
        //        }
        //    }
        //    else if (this.tkElse == null && this.elseStatement == null) { }
        //    else { throw new NotImplementedException(); }
        //}
    }
}
