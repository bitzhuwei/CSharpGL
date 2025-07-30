using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using bitzhuwei.Compiler;

namespace bitzhuwei.GLSLFormat {
    partial class parameter_declaration_parameter_declarator : Vnparameter_declaration {
        // [107]: parameter_declaration : type_qualifier parameter_declarator ;
        // [108]: parameter_declaration : parameter_declarator ;

        private readonly Vnparameter_declarator parameter_declarator0;
        public parameter_declaration_parameter_declarator(
            Vntype_qualifier? type_qualifier0, Vnparameter_declarator parameter_declarator0)
            : base(type_qualifier0) {
            if (type_qualifier0 != null) { this._tokenRange = new TokenRange(type_qualifier0, parameter_declarator0); }
            else { this._tokenRange = new TokenRange(parameter_declarator0); }
            this.parameter_declarator0 = parameter_declarator0;
        }
        private readonly TokenRange _tokenRange;


        public override TokenRange Scope => _tokenRange;


        public override void FullFormat(BlankConfig? preConfig, TextWriter writer, FormatContext context) {
            if (this.type_qualifier0 != null) {
                this.type_qualifier0.FullFormat(preConfig, writer, context);
                var config = new BlankConfig(inlineBlank: 1, forceNewline: false);
                context.PrintCommentsBetween(this.type_qualifier0, this.parameter_declarator0, config, writer);
                this.parameter_declarator0.FullFormat(config, writer, context);
            }
            else {
                this.parameter_declarator0.FullFormat(preConfig, writer, context);
            }
        }

        //public override void Format(TextWriter writer, FormatContext context) {
        //    if (this.type_qualifier0 != null) {
        //        this.type_qualifier0.Format(writer, context);
        //        writer.Write(" ");
        //    }
        //    this.parameter_declarator0.Format(writer, context);
        //}

        //public override IEnumerable<string> YieldTokens(TextWriter writer, FormatContext context) {
        //    if (this.type_qualifier0 != null) {
        //        foreach (var item in this.type_qualifier0.YieldTokens(writer, context)) {
        //            yield return item;
        //        }
        //        writer.Write(" ");
        //    }
        //    foreach (var item in this.parameter_declarator0.YieldTokens(writer, context)) {
        //        yield return item;
        //    }
        //}
    }

    partial class parameter_declaration_type_specifier : Vnparameter_declaration {
        // [109]: parameter_declaration : type_qualifier parameter_type_specifier ;
        // [110]: parameter_declaration : parameter_type_specifier ;

        private readonly Vnparameter_type_specifier type_specifier0;
        public parameter_declaration_type_specifier(
            Vntype_qualifier? type_qualifier0, Vnparameter_type_specifier type_specifier0)
            : base(type_qualifier0) {
            if (type_qualifier0 != null) { this._tokenRange = new TokenRange(type_qualifier0, type_specifier0); }
            else { this._tokenRange = new TokenRange(type_specifier0); }
            this.type_specifier0 = type_specifier0;
        }
        private readonly TokenRange _tokenRange;


        public override TokenRange Scope => _tokenRange;


        public override void FullFormat(BlankConfig? preConfig, TextWriter writer, FormatContext context) {
            if (this.type_qualifier0 != null) {
                this.type_qualifier0.FullFormat(preConfig, writer, context);
                var config = new BlankConfig(inlineBlank: 1, forceNewline: false);
                context.PrintCommentsBetween(this.type_qualifier0, this.type_specifier0, config, writer);
                this.type_specifier0.FullFormat(config, writer, context);
            }
            else {
                if (this.type_specifier0.IsVoid()) {
                    if (preConfig != null) {
                        context.PrintBlanksBefore(this.type_specifier0, preConfig.Value, writer);
                    }
                    writer.Write("/*void*/");
                }
                else {
                    this.type_specifier0.FullFormat(preConfig, writer, context);
                }
            }
        }

        //public override void Format(TextWriter writer, FormatContext context) {
        //    if (this.type_qualifier0 != null) {
        //        this.type_qualifier0.Format(writer, context);
        //        writer.Write(" ");
        //    }
        //    this.type_specifier0.Format(writer, context);
        //}

        //public override IEnumerable<string> YieldTokens(TextWriter writer, FormatContext context) {
        //    if (this.type_qualifier0 != null) {
        //        foreach (var item in this.type_qualifier0.YieldTokens(writer, context)) {
        //            yield return item;
        //        }
        //        writer.Write(" ");
        //    }
        //    foreach (var item in this.type_specifier0.YieldTokens(writer, context)) {
        //        yield return item;
        //    }
        //}
    }

    /// <summary>
    /// Correspond to the Vn node parameter_declaration in the grammar(GLSL).
    /// </summary>
    abstract partial class Vnparameter_declaration : IFullFormat {
        protected readonly Vntype_qualifier? type_qualifier0;


        public Vnparameter_declaration(Vntype_qualifier? type_qualifier0) {
            this.type_qualifier0 = type_qualifier0;
        }

        //public abstract void Format(TextWriter writer, FormatContext context);
        //public abstract IEnumerable<string> YieldTokens(TextWriter writer, FormatContext context);
        public abstract TokenRange Scope { get; }
        public abstract void FullFormat(BlankConfig? preConfig, TextWriter writer, FormatContext context);
    }
}
