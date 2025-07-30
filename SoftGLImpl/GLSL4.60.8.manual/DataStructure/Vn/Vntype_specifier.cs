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
    /// Correspond to the Vn node type_specifier in the grammar(GLSL).
    /// </summary>
    partial class Vntype_specifier : IFullFormat {
        // [162]: type_specifier : type_specifier_nonarray ;
        // [163]: type_specifier : type_specifier_nonarray array_specifier ;

        private Vntype_specifier_nonarray type_specifier_nonarray1;
        private Vnarray_specifier? array_specifier0;

        public Vntype_specifier(Vntype_specifier_nonarray type_specifier_nonarray1, Vnarray_specifier? array_specifier0) {
            if (array_specifier0 != null) { this._tokenRange = new TokenRange(type_specifier_nonarray1, array_specifier0); }
            else { this._tokenRange = new TokenRange(type_specifier_nonarray1); }
            this.type_specifier_nonarray1 = type_specifier_nonarray1;
            this.array_specifier0 = array_specifier0;
        }
        private readonly TokenRange _tokenRange;


        public TokenRange Scope => _tokenRange;

        public string? GetStructName() {
            if (this.type_specifier_nonarray1 is type_specifier_nonarray_struct_specifier obj) {
                return obj.GetStructName();
            }
            else { return null; }
        }

        internal string GetTypeName() {
            return this.type_specifier_nonarray1.GetTypeName();
        }

        internal bool IsVoid() {
            return this.type_specifier_nonarray1.GetTypeName() == "void";// && this.array_specifier0 == null;
        }
        public void FullFormat(BlankConfig? preConfig, TextWriter writer, FormatContext context) {
            this.type_specifier_nonarray1.FullFormat(preConfig, writer, context);
            if (this.array_specifier0 != null) {// this should never happen for struct
                var config = new BlankConfig(inlineBlank: 0, forceNewline: false);
                if (context.PrintCommentsBetween(this.type_specifier_nonarray1, this.array_specifier0, config, writer) == FormatContext.LastComment.InlineComment) {
                    writer.WriteLine(); context.PrintTab(writer);
                }
                writer.Write("[]");
                writer.Write("/*"); this.array_specifier0.FullFormat(config, writer, context); writer.Write("*/");
            }
        }


        //public void Format(TextWriter writer, FormatContext context) {
        //    this.type_specifier_nonarray1.Format(writer, context);
        //    if (this.array_specifier0 != null) {
        //        this.array_specifier0.Format(writer, context);
        //    }
        //}

        //public IEnumerable<string> YieldTokens(TextWriter writer, FormatContext context) {
        //    foreach (var item in this.type_specifier_nonarray1.YieldTokens(writer, context)) {
        //        yield return item;
        //    }
        //    if (this.array_specifier0 != null) {
        //        foreach (var item2 in this.array_specifier0.YieldTokens(writer, context)) {
        //            yield return item2;
        //        }
        //    }
        //}

    }
}
