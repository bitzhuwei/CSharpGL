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
    /// Correspond to the Vn node single_declaration in the grammar(GLSL).
    /// </summary>
    partial class Vnsingle_declaration : IFullFormat {
        // [117]: single_declaration : fully_specified_type ;
        // [118]: single_declaration : fully_specified_type 'identifier' ;
        // [119]: single_declaration : fully_specified_type 'identifier' array_specifier ;
        // [120]: single_declaration : fully_specified_type 'identifier' array_specifier '=' initializer ;
        // [121]: single_declaration : fully_specified_type 'identifier' '=' initializer ;

        private Vnfully_specified_type fully_specified_type3;
        private Token? tkIdentifier;
        private Vnarray_specifier? array_specifier2;
        private Token? tkEqual;
        private Vninitializer? initializer0;

        public Vnsingle_declaration(
            Vnfully_specified_type fully_specified_type3, Token? identifier2,
            Vnarray_specifier? array_specifier2, Token? tkEqual, Vninitializer? initializer0) {
            if (initializer0 != null) { this._tokenRange = new TokenRange(fully_specified_type3, initializer0); }
            else if (tkEqual != null) { this._tokenRange = new TokenRange(fully_specified_type3, tkEqual); }
            else if (array_specifier2 != null) { this._tokenRange = new TokenRange(fully_specified_type3, array_specifier2); }
            else if (identifier2 != null) { this._tokenRange = new TokenRange(fully_specified_type3, identifier2); }
            else { this._tokenRange = new TokenRange(fully_specified_type3); }
            this.fully_specified_type3 = fully_specified_type3;
            this.tkIdentifier = identifier2;
            this.array_specifier2 = array_specifier2;
            this.tkEqual = tkEqual;
            this.initializer0 = initializer0;
        }

        private readonly TokenRange _tokenRange;


        public TokenRange Scope => _tokenRange;

        internal string GetTypeName() {
            return this.fully_specified_type3.GetTypeName();
        }

        public void FullFormat(BlankConfig? preConfig, TextWriter writer, FormatContext context) {
            this.fully_specified_type3.FullFormat(preConfig, writer, context);
            if (this.tkIdentifier != null) {
                var structName = this.fully_specified_type3.GetStructName();
                var config = new BlankConfig(inlineBlank: 1, forceNewline: false);
                if (this.array_specifier2 != null) {
                    if (this.tkEqual != null && this.initializer0 != null) {
                        // [120]: single_declaration : fully_specified_type 'identifier' array_specifier '=' initializer ;
                        if (context.PrintCommentsBetween(this.fully_specified_type3, this.tkIdentifier, config, writer) == FormatContext.LastComment.InlineComment) {
                            writer.WriteLine(); context.PrintTab(writer);
                        }
                        if (structName != null) { writer.Write(structName); }
                        writer.Write("[]");
                        context.PrintBlanksAnd(this.tkIdentifier, config, writer);
                        writer.Write("/*"); context.PrintBlanksAnd(this.array_specifier2, config, writer); writer.Write(" */");
                        context.PrintCommentsBetween(this.array_specifier2, this.tkEqual, config, writer);
                        context.PrintBlanksAnd(this.tkEqual, config, writer);
                        context.PrintCommentsBetween(this.tkEqual, this.initializer0, config, writer);
                        context.PrintBlanksAnd(this.initializer0, config, writer);
                    }
                    else {
                        // [119]: single_declaration : fully_specified_type 'identifier' array_specifier ;
                        if (context.PrintCommentsBetween(this.fully_specified_type3, this.tkIdentifier, config, writer) == FormatContext.LastComment.InlineComment) {
                            writer.WriteLine(); context.PrintTab(writer);
                        }
                        if (structName != null) { writer.Write(structName); }
                        writer.Write("[]");
                        context.PrintBlanksAnd(this.tkIdentifier, config, writer);
                        writer.Write("/*"); context.PrintBlanksAnd(this.array_specifier2, config, writer); writer.Write(" */");
                    }
                }
                else {
                    if (this.tkEqual != null && this.initializer0 != null) {
                        // [121]: single_declaration : fully_specified_type 'identifier' '=' initializer ;
                        if (context.PrintCommentsBetween(this.fully_specified_type3, this.tkIdentifier, config, writer) == FormatContext.LastComment.InlineComment) {
                            writer.WriteLine(); context.PrintTab(writer);
                        }
                        if (structName != null) { writer.Write(structName); }
                        context.PrintBlanksAnd(this.tkIdentifier, config, writer);
                        context.PrintCommentsBetween(this.tkIdentifier, this.tkEqual, config, writer);
                        context.PrintBlanksAnd(this.tkEqual, config, writer);
                        context.PrintCommentsBetween(this.tkEqual, this.initializer0, config, writer);
                        context.PrintBlanksAnd(this.initializer0, config, writer);
                    }
                    else {
                        // [118]: single_declaration : fully_specified_type 'identifier' ;
                        if (context.PrintCommentsBetween(this.fully_specified_type3, this.tkIdentifier, config, writer) == FormatContext.LastComment.InlineComment) {
                            writer.WriteLine(); context.PrintTab(writer);
                        }
                        if (structName != null) { writer.Write(structName); }
                        context.PrintBlanksAnd(this.tkIdentifier, config, writer);
                    }
                }
            }
            else { // [117]: single_declaration : fully_specified_type ;
                // nothing to do.
            }

            //original version
            //this.fully_specified_type3.FullFormat(preConfig, writer, context);
            //if (this.tkIdentifier != null) {
            //    var config = new BlankConfig(inlineBlank: 1, forceNewline: false);
            //    context.PrintCommentsBetween(this.fully_specified_type3, this.tkIdentifier, config, writer);
            //    context.PrintBlanksAnd(this.tkIdentifier, config, writer);
            //}
            //if (this.tkIdentifier != null && this.array_specifier2 != null) {
            //    var config = new BlankConfig(inlineBlank: 1, forceNewline: false);
            //    context.PrintCommentsBetween(this.tkIdentifier, this.array_specifier2, config, writer);
            //    config.inlineBlank = 0;
            //    this.array_specifier2.FullFormat(config, writer, context);
            //}
            //if (this.tkEqual != null && this.initializer0 != null) {
            //    var config = new BlankConfig(inlineBlank: 1, forceNewline: false);
            //    if (this.array_specifier2 != null) {
            //        context.PrintCommentsBetween(this.array_specifier2, this.tkEqual, config, writer);
            //    }
            //    else if (this.tkIdentifier != null) {
            //        context.PrintCommentsBetween(this.tkIdentifier, this.tkEqual, config, writer);
            //    }
            //    else { throw new NotImplementedException(); }
            //    context.PrintBlanksAnd(this.tkEqual, config, writer);
            //    context.PrintCommentsBetween(this.tkEqual, this.initializer0, config, writer);
            //    this.initializer0.FullFormat(config, writer, context);
            //}
        }


        //public void Format(TextWriter writer, FormatContext context) {
        //    this.fully_specified_type3.Format(writer, context);
        //    if (this.tkIdentifier != null) {
        //        writer.Write(" ");
        //        writer.Write(this.tkIdentifier.value);
        //    }
        //    if (this.tkIdentifier != null && this.array_specifier2 != null) {
        //        this.array_specifier2.Format(writer, context);
        //    }
        //    if (this.tkEqual != null && this.initializer0 != null) {
        //        writer.Write(" ");
        //        writer.Write(this.tkEqual.value);
        //        writer.Write(" ");
        //        this.initializer0.Format(writer, context);
        //    }
        //}

        //public IEnumerable<string> YieldTokens(TextWriter writer, FormatContext context) {
        //    foreach (var item in this.fully_specified_type3.YieldTokens(writer, context)) {
        //        yield return item;
        //    }
        //    if (this.tkIdentifier != null) {
        //        writer.Write(" ");
        //        writer.Write(this.tkIdentifier.value); yield return this.tkIdentifier.value;
        //    }
        //    if (this.tkIdentifier != null && this.array_specifier2 != null) {
        //        foreach (var item in this.array_specifier2.YieldTokens(writer, context)) {
        //            yield return item;
        //        }
        //    }
        //    if (this.tkEqual != null && this.initializer0 != null) {
        //        writer.Write(" ");
        //        writer.Write(this.tkEqual.value); yield return this.tkEqual.value;
        //        writer.Write(" ");
        //        foreach (var item in this.initializer0.YieldTokens(writer, context)) {
        //            yield return item;
        //        }
        //    }
        //}

    }
}
