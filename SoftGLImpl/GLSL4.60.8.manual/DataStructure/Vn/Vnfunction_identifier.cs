using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using bitzhuwei.Compiler;

namespace bitzhuwei.GLSLFormat {
    partial class function_identifier_type_specifier : Vnfunction_identifier {
        // [30]: function_identifier : type_specifier ;

        private Vntype_specifier type_specifier0;

        public function_identifier_type_specifier(Vntype_specifier type_specifier0) {
            this._tokenRange = new TokenRange(type_specifier0);
            this.type_specifier0 = type_specifier0;
        }

        private readonly TokenRange _tokenRange;


        public override TokenRange Scope => _tokenRange;


        public override void FullFormat(BlankConfig? preConfig, TextWriter writer, FormatContext context) {
            this.type_specifier0.FullFormat(preConfig, writer, context);
        }

        //public override void Format(TextWriter writer, FormatContext context) {
        //    this.type_specifier0.Format(writer, context);
        //}

        //public override IEnumerable<string> YieldTokens(TextWriter writer, FormatContext context) {
        //    foreach (var item in this.type_specifier0.YieldTokens(writer, context)) {
        //        yield return item;
        //    }
        //}
    }
    partial class function_identifier_postfix_expression : Vnfunction_identifier {
        // [31]: function_identifier : postfix_expression ;

        private Vnpostfix_expression postfix_expression0;

        public function_identifier_postfix_expression(Vnpostfix_expression postfix_expression0) {
            this._tokenRange = new TokenRange(postfix_expression0);
            this.postfix_expression0 = postfix_expression0;
        }

        private readonly TokenRange _tokenRange;


        public override TokenRange Scope => _tokenRange;


        public override void FullFormat(BlankConfig? preConfig, TextWriter writer, FormatContext context) {
            this.postfix_expression0.FullFormat(preConfig, writer, context);
        }

        //public override void Format(TextWriter writer, FormatContext context) {
        //    this.postfix_expression0.Format(writer, context);
        //}

        //public override IEnumerable<string> YieldTokens(TextWriter writer, FormatContext context) {
        //    foreach (var item in this.postfix_expression0.YieldTokens(writer, context)) {
        //        yield return item;
        //    }
        //}
    }

    /// <summary>
    /// Correspond to the Vn node function_identifier in the grammar(GLSL).
    /// </summary>
    abstract partial class Vnfunction_identifier : IFullFormat {

        //public abstract void Format(TextWriter writer, FormatContext context);
        //public abstract IEnumerable<string> YieldTokens(TextWriter writer, FormatContext context);
        public abstract TokenRange Scope { get; }
        public abstract void FullFormat(BlankConfig? preConfig, TextWriter writer, FormatContext context);
    }
}
