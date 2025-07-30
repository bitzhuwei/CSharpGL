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
    //struct SomeStruct { mat4 model; mat4 view; mat4 projection; }  va[3], vb ;
    // =>
    //struct SomeStruct { mat4 model; mat4 view; mat4 projection; }
    //SomeStruct[] va = new SomeStruct[3]; SomeStruct vb;

    /// <summary>
    /// Correspond to the Vn node struct_declaration in the grammar(GLSL).
    /// </summary>
    partial class Vnstruct_declaration : IFullFormat {
        // [296]: struct_declaration : type_specifier struct_declarator_list ';' ;
        // [297]: struct_declaration : type_qualifier type_specifier struct_declarator_list ';' ;

        private Vntype_qualifier? type_qualifier3;
        private Vntype_specifier type_specifier2;
        private Vnstruct_declarator_list struct_declarator_list1;
        private Token tkSemicolon0;

        public Vnstruct_declaration(Vntype_qualifier? type_qualifier3,
            Vntype_specifier type_specifier2, Vnstruct_declarator_list struct_declarator_list1, Token tkSemicolon) {
            if (type_qualifier3 != null) { this._tokenRange = new TokenRange(type_qualifier3, tkSemicolon); }
            else { this._tokenRange = new TokenRange(type_specifier2, tkSemicolon); }
            this.type_qualifier3 = type_qualifier3;
            this.type_specifier2 = type_specifier2;
            this.struct_declarator_list1 = struct_declarator_list1;
            this.tkSemicolon0 = tkSemicolon;
        }
        private readonly TokenRange _tokenRange;


        public TokenRange Scope => _tokenRange;


        public void FullFormat(BlankConfig? preConfig, TextWriter writer, FormatContext context) {
            if (this.type_qualifier3 != null) {
                this.type_qualifier3.FullFormat(preConfig, writer, context);
            }

            var config = new BlankConfig(inlineBlank: 1, forceNewline: false);
            if (this.type_qualifier3 != null) {
                context.PrintCommentsBetween(this.type_qualifier3, this.type_specifier2, config, writer);
                this.type_specifier2.FullFormat(config, writer, context);
            }
            else {
                this.type_specifier2.FullFormat(preConfig, writer, context);
            }
            context.PrintCommentsBetween(this.type_specifier2, this.struct_declarator_list1, config, writer);

            var structName = this.type_specifier2.GetStructName();
            if (structName != null) { // this is a struct
                FormatStruct(structName, this.struct_declarator_list1.first, config, writer, context);
                foreach (var item in this.struct_declarator_list1.list1) {
                    writer.Write(" ");
                    FormatStruct(structName, item, config, writer, context);
                }
            }
            else {
                //this.struct_declarator_list1.FullFormat(config, writer, context);
                context.PrintBlanksAnd(this.struct_declarator_list1, config, writer);
            }

            // dump blanks(if any) before ';' so that we are prepared for next coming Vnxxx nodes.
            config.inlineBlank = 0;
            context.PrintBlanksAnd(this.tkSemicolon0, config, writer);

            //original version
            //var config = new BlankConfig(inlineBlank: 1, forceNewline: false);
            //if (this.type_qualifier3 != null) {
            //    context.PrintCommentsBetween(this.type_qualifier3, this.type_specifier2, config, writer);
            //    this.type_specifier2.FullFormat(config, writer, context);
            //}
            //else {
            //    this.type_specifier2.FullFormat(preConfig, writer, context);
            //}

            //context.PrintCommentsBetween(this.type_specifier2, this.struct_declarator_list1, config, writer);
            //this.struct_declarator_list1.FullFormat(config, writer, context);
            //config.inlineBlank = 0;
            //context.PrintBlanksAnd(this.tkSemicolon0, config, writer);
        }

        private void FormatStruct(string structName, Vnstruct_declarator structDeclarator, BlankConfig config, TextWriter writer, FormatContext context) {
            {// SomeStruct
                context.PrintBlanksBefore(structDeclarator, config, writer);
                writer.Write(structName);
            }
            if (structDeclarator.array_specifier0 != null) { // []
                context.PrintCommentsBefore(structDeclarator.array_specifier0, config, writer);
                writer.Write("[]");
            }
            writer.Write(" ");
            {// va
                var lastComment = context.PrintCommentsBefore(structDeclarator.identifier1, config, writer);
                if (lastComment == FormatContext.LastComment.InlineComment) { writer.WriteLine(); context.PrintTab(writer); }
                writer.Write(structDeclarator.identifier1.value);
            }
            if (structDeclarator.array_specifier0 != null) { // []
                writer.Write($" = new {structName}");
                BlankConfig? noBlanks = null;
                context.PrintBlanksAnd(structDeclarator.array_specifier0, noBlanks, writer);
            }
            writer.Write(";");
        }


        //public void Format(TextWriter writer, FormatContext context) {
        //    if (this.type_qualifier3 != null) {
        //        this.type_qualifier3.Format(writer, context); writer.Write(" ");
        //    }
        //    this.type_specifier2.Format(writer, context); writer.Write(" ");
        //    this.struct_declarator_list1.Format(writer, context);
        //}

        //public IEnumerable<string> YieldTokens(TextWriter writer, FormatContext context) {
        //    if (this.type_qualifier3 != null) {
        //        foreach (var item in this.type_qualifier3.YieldTokens(writer, context)) {
        //            yield return item;
        //        }
        //        writer.Write(" ");
        //    }
        //    foreach (var item in this.type_specifier2.YieldTokens(writer, context)) {
        //        yield return item;
        //    }
        //    writer.Write(" ");
        //    foreach (var item in this.struct_declarator_list1.YieldTokens(writer, context)) {
        //        yield return item;
        //    }
        //}
    }
}
