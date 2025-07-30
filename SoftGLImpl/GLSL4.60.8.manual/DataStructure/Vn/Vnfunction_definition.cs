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
    /// Correspond to the Vn node function_definition in the grammar(GLSL).
    /// </summary>
    partial class Vnfunction_definition : Vnexternal_declaration {
        // [5]: function_definition : function_prototype compound_statement ;

        private Vnfunction_prototype function_prototype1;
        private Vncompound_statement compound_statement0;

        public Vnfunction_definition(Vnfunction_prototype function_prototype1, Vncompound_statement compound_statement0) {
            this._tokenRange = new TokenRange(function_prototype1, compound_statement0);
            this.function_prototype1 = function_prototype1;
            this.compound_statement0 = compound_statement0;
        }
        private readonly TokenRange _tokenRange;


        public override TokenRange Scope => _tokenRange;


        public override void FullFormat(BlankConfig? preConfig, TextWriter writer, FormatContext context) {
            this.function_prototype1.FullFormat(preConfig, writer, context);
            var config = new BlankConfig(inlineBlank: 1, forceNewline: false);
            var lastComment = context.PrintCommentsBetween(this.function_prototype1, this.compound_statement0, config, writer);
            config.inlineBlank = lastComment != FormatContext.LastComment.None ? 0 : 1;
            this.compound_statement0.FullFormat(config, writer, context);
        }

        //public override void Format(TextWriter writer, FormatContext context) {
        //    this.function_prototype1.Format(writer, context);
        //    writer.Write(" ");
        //    this.compound_statement0.Format(writer, context);
        //    writer.WriteLine();
        //    context.PrintTab(writer);
        //}

        //public override IEnumerable<string> YieldTokens(TextWriter writer, FormatContext context) {
        //    foreach (var item in this.function_prototype1.YieldTokens(writer, context)) {
        //        yield return item;
        //    }
        //    writer.Write(" ");
        //    foreach (var item in this.compound_statement0.YieldTokens(writer, context)) {
        //        yield return item;
        //    }
        //    writer.WriteLine();
        //    context.PrintTab(writer);
        //}
    }
}
