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
    /// Correspond to the Vn node struct_specifier in the grammar(GLSL).
    /// </summary>
    partial class Vnstruct_specifier : IFullFormat {

        // [292]: struct_specifier : 'struct' 'identifier' '{' struct_declaration_list '}' ;
        // [293]: struct_specifier : 'struct' '{' struct_declaration_list '}' ;

        private readonly Token tkStruct;
        private Token? type_name3;
        private readonly Token tkLeftBrace;
        private Vnstruct_declaration_list struct_declaration_list1;
        private readonly Token tkRightBrace;

        public readonly string structName;

        public Vnstruct_specifier(Token tkStruct, Token type_name3, Token tkLeftBrace,
            Vnstruct_declaration_list struct_declaration_list1, Token tkRightBrace) {
            this._tokenRange = new TokenRange(tkStruct, tkRightBrace);
            this.tkStruct = tkStruct;
            this.type_name3 = type_name3;
            this.tkLeftBrace = tkLeftBrace;
            this.struct_declaration_list1 = struct_declaration_list1;
            this.tkRightBrace = tkRightBrace;
            this.structName = type_name3.value;
        }
        public Vnstruct_specifier(Token tkStruct, int nextId, Token tkLeftBrace,
          Vnstruct_declaration_list struct_declaration_list1, Token tkRightBrace) {
            this._tokenRange = new TokenRange(tkStruct, tkRightBrace);
            this.tkStruct = tkStruct;
            this.type_name3 = null;
            this.tkLeftBrace = tkLeftBrace;
            this.struct_declaration_list1 = struct_declaration_list1;
            this.tkRightBrace = tkRightBrace;
            this.structName = $"struct第{nextId}";
        }
        private readonly TokenRange _tokenRange;


        public TokenRange Scope => _tokenRange;


        public void FullFormat(BlankConfig? preConfig, TextWriter writer, FormatContext context) {
            context.PrintBlanksAnd(this.tkStruct, preConfig, writer);
            var config = new BlankConfig(inlineBlank: 1, forceNewline: false);

            if (this.type_name3 != null) {
                context.PrintCommentsBetween(this.tkStruct, this.type_name3, config, writer);
                context.PrintBlanksAnd(this.type_name3, config, writer);
            }

            if (this.type_name3 != null) {
                context.PrintCommentsBetween(this.type_name3, this.tkLeftBrace, config, writer);
            }
            else {
                context.PrintCommentsBetween(this.tkStruct, this.tkLeftBrace, config, writer);
            }
            context.PrintBlanksAnd(this.tkLeftBrace, config, writer);

            context.IncreaseTab();
            context.PrintCommentsBetween(this.tkLeftBrace, this.struct_declaration_list1, config, writer);
            this.struct_declaration_list1.FullFormat(config, writer, context);
            context.PrintCommentsBetween(this.struct_declaration_list1, this.tkRightBrace, config, writer);
            context.DecreaseTab();
            context.PrintBlanksAnd(this.tkRightBrace, config, writer);
        }


        //public void Format(TextWriter writer, FormatContext context) {
        //    writer.Write(this.tkStruct.value);

        //    if (this.type_name3 != null) {
        //        writer.Write(" ");
        //        writer.Write(this.type_name3.value);
        //    }

        //    if (this.type_name3 != null) {
        //        writer.Write(" ");
        //    }
        //    else {
        //        writer.Write(" ");
        //    }
        //    writer.Write(this.tkLeftBrace.value);

        //    writer.WriteLine();
        //    context.IncreaseTab();
        //    context.PrintTab(writer);
        //    this.struct_declaration_list1.Format(writer, context);

        //    writer.WriteLine();
        //    context.DecreaseTab();
        //    context.PrintTab(writer);
        //    writer.Write(this.tkRightBrace.value);
        //}

        //public IEnumerable<string> YieldTokens(TextWriter writer, FormatContext context) {
        //    writer.Write(this.tkStruct.value); yield return this.tkStruct.value;

        //    if (this.type_name3 != null) {
        //        writer.Write(" ");
        //        writer.Write(this.type_name3.value); yield return this.type_name3.value;
        //    }

        //    if (this.type_name3 != null) {
        //        writer.Write(" ");
        //    }
        //    else {
        //        writer.Write(" ");
        //    }
        //    writer.Write(this.tkLeftBrace.value); yield return this.tkLeftBrace.value;

        //    writer.WriteLine();
        //    context.IncreaseTab();
        //    context.PrintTab(writer);
        //    foreach (var item in this.struct_declaration_list1.YieldTokens(writer, context)) {
        //        yield return item;
        //    }

        //    writer.WriteLine();
        //    context.DecreaseTab();
        //    context.PrintTab(writer);
        //    writer.Write(this.tkRightBrace.value); yield return this.tkRightBrace.value;
        //}
    }
}
