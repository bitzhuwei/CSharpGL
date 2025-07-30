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
    /// Correspond to the Vn node layout_qualifier_id in the grammar(GLSL).
    /// </summary>
    partial class Vnlayout_qualifier_id : IFullFormat {
        // [131]: layout_qualifier_id : 'identifier' ;
        // [132]: layout_qualifier_id : 'identifier' '=' constant_expression ;
        // [133]: layout_qualifier_id : 'shared' ;

        private Token identifier2;
        private readonly Token? tkEqual;
        private Vnconstant_expression? constant_expression0;

        public Vnlayout_qualifier_id(Token identifier2, Token? tkEqual, Vnconstant_expression? constant_expression0) {
            if (constant_expression0 != null) { this._tokenRange = new TokenRange(identifier2, constant_expression0); }
            else if (tkEqual != null) { this._tokenRange = new TokenRange(identifier2, tkEqual); }
            else { this._tokenRange = new TokenRange(identifier2); }
            this.identifier2 = identifier2;
            this.tkEqual = tkEqual;
            this.constant_expression0 = constant_expression0;
        }
        private readonly TokenRange _tokenRange;


        public TokenRange Scope => _tokenRange;

        public bool IsSelfValue() {
            return this.tkEqual == null && constant_expression0 == null;
        }

        public void FullFormat(BlankConfig? preConfig, TextWriter writer, FormatContext context) {
            context.PrintBlanksAnd(this.identifier2, preConfig, writer);
            if (this.tkEqual != null && constant_expression0 != null) {
                var config = new BlankConfig(inlineBlank: 1, forceNewline: false);
                context.PrintCommentsBetween(this.identifier2, this.tkEqual, config, writer);
                context.PrintBlanksAnd(this.tkEqual, config, writer);
                context.PrintCommentsBetween(this.tkEqual, this.constant_expression0, config, writer);
                constant_expression0.FullFormat(config, writer, context);
            }
            else if (this.tkEqual == null && constant_expression0 == null) { }
            else {
                throw new Exception("Algorithm error: this should never happen!");
            }
        }


        //public void Format(TextWriter writer, FormatContext context) {
        //    writer.Write(this.identifier2.value);
        //    if (this.tkEqual != null && constant_expression0 != null) {
        //        writer.Write(this.tkEqual.value);
        //        constant_expression0.Format(writer, context);
        //    }
        //    else if (this.tkEqual == null && constant_expression0 == null) { }
        //    else {
        //        throw new Exception("Algorithm error: this should never happen!");
        //    }
        //}

        //public IEnumerable<string> YieldTokens(TextWriter writer, FormatContext context) {
        //    writer.Write(this.identifier2.value); yield return this.identifier2.value;
        //    if (this.tkEqual != null && constant_expression0 != null) {
        //        writer.Write(this.tkEqual.value); yield return this.tkEqual.value;
        //        foreach (var item in this.constant_expression0.YieldTokens(writer, context)) {
        //            yield return item;
        //        }
        //    }
        //    else if (this.tkEqual == null && constant_expression0 == null) { }
        //    else {
        //        throw new Exception("Algorithm error: this should never happen!");
        //    }
        //}
    }
}
