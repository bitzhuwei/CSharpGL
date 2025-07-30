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
    /// Correspond to the Vn node condition in the grammar(GLSL).
    /// </summary>
    partial class condition_2 : Vncondition {
        // [327] condition : fully_specified_type 'identifier' '=' initializer ;

        private Vnfully_specified_type fully_specified_type3;
        private Token identifier2;
        private readonly Token tkEqual;
        private Vninitializer initializer0;

        public condition_2(Vnfully_specified_type fully_specified_type3, Token identifier2, Token tkEqual, Vninitializer initializer0) {
            this.fully_specified_type3 = fully_specified_type3;
            this.identifier2 = identifier2;
            this.tkEqual = tkEqual;
            this.initializer0 = initializer0;
            this._tokenRange = new TokenRange(fully_specified_type3, initializer0);
        }

        private readonly TokenRange _tokenRange;


        public override TokenRange Scope => _tokenRange;


        public override void FullFormat(BlankConfig? preConfig, TextWriter writer, FormatContext context) {
            this.fully_specified_type3.FullFormat(preConfig, writer, context);
            var config = new BlankConfig(inlineBlank: 1, forceNewline: false);
            context.PrintCommentsBetween(this.fully_specified_type3, this.identifier2, config, writer);
            context.PrintBlanksAnd(this.identifier2, config, writer);
            context.PrintCommentsBetween(this.identifier2, this.tkEqual, config, writer);
            context.PrintBlanksAnd(this.tkEqual, config, writer);
            context.PrintCommentsBetween(this.tkEqual, this.initializer0, config, writer);
            this.initializer0.FullFormat(config, writer, context);
        }

        //public override void Format(TextWriter writer, FormatContext context) {
        //    this.fully_specified_type3.Format(writer, context);
        //    writer.Write(" ");
        //    writer.Write(this.identifier2.value);
        //    writer.Write(" ");
        //    writer.Write(this.tkEqual.value);
        //    writer.Write(" ");
        //    this.initializer0.Format(writer, context);
        //}

        //public override IEnumerable<string> YieldTokens(TextWriter writer, FormatContext context) {
        //    foreach (var item in this.fully_specified_type3.YieldTokens(writer, context)) {
        //        yield return item;
        //    }
        //    writer.Write(" ");
        //    writer.Write(this.identifier2.value); yield return this.identifier2.value;
        //    writer.Write(" ");
        //    writer.Write(this.tkEqual.value); yield return this.tkEqual.value;
        //    writer.Write(" ");
        //    foreach (var item in this.initializer0.YieldTokens(writer, context)) {
        //        yield return item;
        //    }
        //}
    }
    /// <summary>
    /// Correspond to the Vn node condition in the grammar(GLSL).
    /// </summary>
    partial class condition_1 : Vncondition {
        // [326] condition : expression ;

        private Vnexpression expression0;

        public condition_1(Vnexpression expression0) {
            this._tokenRange = new TokenRange(expression0);
            this.expression0 = expression0;
        }

        private readonly TokenRange _tokenRange;


        public override TokenRange Scope => _tokenRange;


        public override void FullFormat(BlankConfig? preConfig, TextWriter writer, FormatContext context) {
            this.expression0.FullFormat(preConfig, writer, context);
        }

        //public override void Format(TextWriter writer, FormatContext context) {
        //    this.expression0.Format(writer, context);
        //}

        //public override IEnumerable<string> YieldTokens(TextWriter writer, FormatContext context) {
        //    foreach (var item in this.expression0.YieldTokens(writer, context)) {
        //        yield return item;
        //    }
        //}
    }
    /// <summary>
    /// Correspond to the Vn node condition in the grammar(GLSL).
    /// </summary>
    abstract partial class Vncondition : IFullFormat {

        //public abstract void Format(TextWriter writer, FormatContext context);
        //public abstract IEnumerable<string> YieldTokens(TextWriter writer, FormatContext context);
        public abstract TokenRange Scope { get; }
        public abstract void FullFormat(BlankConfig? preConfig, TextWriter writer, FormatContext context);
    }
}
