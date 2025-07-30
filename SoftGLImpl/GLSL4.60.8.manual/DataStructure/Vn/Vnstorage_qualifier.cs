using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using bitzhuwei.Compiler;
using SoftGLImpl;

namespace bitzhuwei.GLSLFormat {
    partial class storage_qualifier_subroutine : Vnsingle_type_qualifier {

        // [159]: storage_qualifier : 'subroutine' '(' type_name_list ')' ;
        private readonly Token tkSubroutine;
        private readonly Token tkLeftParenthesis;
        private readonly Vntype_name_list type_name_list;
        private readonly Token tkRightParenthesis;

        public storage_qualifier_subroutine(Token tkSubroutine, Token tkLeftParenthesis,
            Vntype_name_list type_name_list, Token tkRightParenthesis) {
            this._tokenRange = new TokenRange(tkSubroutine, tkRightParenthesis);
            this.tkSubroutine = tkSubroutine;
            this.tkLeftParenthesis = tkLeftParenthesis;
            this.type_name_list = type_name_list;
            this.tkRightParenthesis = tkRightParenthesis;
        }

        private readonly TokenRange _tokenRange;
        public override TokenRange Scope => _tokenRange;

        public override string Name => this.tkSubroutine.value;
        public override void FullFormat(BlankConfig? preConfig, TextWriter writer, FormatContext context) {
            //[subroutine("a", "b")]
            if (preConfig != null) { context.PrintBlanksBefore(this.tkSubroutine, preConfig.Value, writer); }
            writer.Write("[");
            writer.Write(this.tkSubroutine.value);
            var config = new BlankConfig(inlineBlank: 0, forceNewline: false);
            context.PrintCommentsBetween(this.tkSubroutine, this.tkLeftParenthesis, config, writer);
            context.PrintBlanksAnd(this.tkLeftParenthesis, config, writer);
            context.PrintCommentsBetween(this.tkLeftParenthesis, this.type_name_list, config, writer);
            context.PrintBlanksAnd(this.type_name_list, config, writer);
            context.PrintCommentsBetween(this.type_name_list, this.tkRightParenthesis, config, writer);
            context.PrintBlanksAnd(this.tkRightParenthesis, config, writer);
            writer.Write("]");
            //original version
            //context.PrintBlanksAnd(this.tkSubroutine, preConfig, writer);
            //var config = new BlankConfig(inlineBlank: 0, forceNewline: false);
            //context.PrintCommentsBetween(this.tkSubroutine, this.tkLeftParenthesis, config, writer);
            //context.PrintBlanksAnd(this.tkLeftParenthesis, config, writer);
            //context.PrintCommentsBetween(this.tkLeftParenthesis, this.type_name_list, config, writer);
            //this.type_name_list.FullFormat(config, writer, context);
            //context.PrintCommentsBetween(this.type_name_list, this.tkRightParenthesis, config, writer);
            //context.PrintBlanksAnd(this.tkRightParenthesis, config, writer);
        }
        //public override void Format(TextWriter writer, FormatContext context) {
        //    // [157]: storage_qualifier : 'subroutine' '(' type_name_list ')' ;
        //    writer.Write(this.tkSubroutine.value);
        //    writer.Write(this.tkLeftParenthesis.value);
        //    this.type_name_list.Format(writer, context);
        //    writer.Write(this.tkRightParenthesis.value);
        //}

        //public override IEnumerable<string> YieldTokens(TextWriter writer, FormatContext context) {
        //    writer.Write(this.tkSubroutine.value); yield return this.tkSubroutine.value;
        //    writer.Write(this.tkLeftParenthesis.value); yield return this.tkLeftParenthesis.value;
        //    foreach (var item in this.type_name_list.YieldTokens(writer, context)) {
        //        yield return item;
        //    }
        //    writer.Write(this.tkRightParenthesis.value); yield return this.tkRightParenthesis.value;
        //}
    }
    /// <summary>
    /// Correspond to the Vn node storage_qualifier in the grammar(GLSL).
    /// </summary>
    partial class Vnstorage_qualifier : Vnsingle_type_qualifier {
        // [143]: storage_qualifier : 'const' ;
        // [144]: storage_qualifier : 'in' ;
        // [145]: storage_qualifier : 'out' ;
        // [146]: storage_qualifier : 'inout' ;
        // [147]: storage_qualifier : 'centroid' ;
        // [148]: storage_qualifier : 'patch' ;
        // [149]: storage_qualifier : 'sample' ;
        // [150]: storage_qualifier : 'uniform' ;
        // [151]: storage_qualifier : 'buffer' ;
        // [152]: storage_qualifier : 'shared' ;
        // [153]: storage_qualifier : 'coherent' ;
        // [154]: storage_qualifier : 'volatile' ;
        // [155]: storage_qualifier : 'restrict' ;
        // [156]: storage_qualifier : 'readonly' ;
        // [157]: storage_qualifier : 'writeonly' ;
        // [158]: storage_qualifier : 'subroutine' ;

        private readonly Token tkContent;

        public Vnstorage_qualifier(Token tkContent) {
            this._tokenRange = new TokenRange(tkContent);
            this.tkContent = tkContent;
        }
        //public static readonly storage_qualifier @const = new();
        //public static readonly storage_qualifier @inout = new();
        //public static readonly storage_qualifier @in = new();
        //public static readonly storage_qualifier @out = new();
        //public static readonly storage_qualifier @centroid = new();
        //public static readonly storage_qualifier @patch = new();
        //public static readonly storage_qualifier @sample = new();
        //public static readonly storage_qualifier @uniform = new();
        //public static readonly storage_qualifier @buffer = new();
        //public static readonly storage_qualifier @shared = new();
        //public static readonly storage_qualifier @coherent = new();
        //public static readonly storage_qualifier @volatile = new();
        //public static readonly storage_qualifier @restrict = new();
        //public static readonly storage_qualifier @readonly = new();
        //public static readonly storage_qualifier @writeonly = new();
        //public static readonly storage_qualifier @subroutine = new();

        private readonly TokenRange _tokenRange;

        public override TokenRange Scope => _tokenRange;


        public override string Name => this.tkContent.value;
        public override void FullFormat(BlankConfig? preConfig, TextWriter writer, FormatContext context) {
            if (preConfig != null) {
                context.PrintBlanksBefore(this.tkContent, preConfig.Value, writer);
            }

            writer.Write("[");
            var value = this.tkContent.value;
            if (false) { }
            else if (value == "in") { writer.Write("In"); }
            else if (value == "out") { writer.Write("Out"); }
            else { writer.Write(value); }
            writer.Write("]");
            if (value == "subroutine") { writer.Write("delegate"); }
            //context.PrintBlanksAnd(this.tkContent, preConfig, writer);
        }

        //public override void Format(TextWriter writer, FormatContext context) {
        //    writer.Write(this.tkContent.value);
        //    //if (false) { }
        //    //else if (this == @const) { writer.Write(nameof(@const)); }
        //    //else if (this == @inout) { writer.Write(nameof(@inout)); }
        //    //else if (this == @in) { writer.Write(nameof(@in)); }
        //    //else if (this == @out) { writer.Write(nameof(@out)); }
        //    //else if (this == @centroid) { writer.Write(nameof(@centroid)); }
        //    //else if (this == @patch) { writer.Write(nameof(@patch)); }
        //    //else if (this == @sample) { writer.Write(nameof(@sample)); }
        //    //else if (this == @uniform) { writer.Write(nameof(@uniform)); }
        //    //else if (this == @buffer) { writer.Write(nameof(@buffer)); }
        //    //else if (this == @shared) { writer.Write(nameof(@shared)); }
        //    //else if (this == @coherent) { writer.Write(nameof(@coherent)); }
        //    //else if (this == @volatile) { writer.Write(nameof(@volatile)); }
        //    //else if (this == @restrict) { writer.Write(nameof(@restrict)); }
        //    //else if (this == @readonly) { writer.Write(nameof(@readonly)); }
        //    //else if (this == @writeonly) { writer.Write(nameof(@writeonly)); }
        //    //else if (this == @subroutine) { writer.Write(nameof(@subroutine)); }
        //    //else { throw new NotImplementedException(); }
        //}

        //public override IEnumerable<string> YieldTokens(TextWriter writer, FormatContext context) {
        //    writer.Write(this.tkContent.value); yield return this.tkContent.value;
        //    //if (false) { }
        //    //else if (this == @const) { writer.Write(nameof(@const)); yield return nameof(@const); }
        //    //else if (this == @inout) { writer.Write(nameof(@inout)); yield return nameof(@inout); }
        //    //else if (this == @in) { writer.Write(nameof(@in)); yield return nameof(@in); }
        //    //else if (this == @out) { writer.Write(nameof(@out)); yield return nameof(@out); }
        //    //else if (this == @centroid) { writer.Write(nameof(@centroid)); yield return nameof(@centroid); }
        //    //else if (this == @patch) { writer.Write(nameof(@patch)); yield return nameof(@patch); }
        //    //else if (this == @sample) { writer.Write(nameof(@sample)); yield return nameof(@sample); }
        //    //else if (this == @uniform) { writer.Write(nameof(@uniform)); yield return nameof(@uniform); }
        //    //else if (this == @buffer) { writer.Write(nameof(@buffer)); yield return nameof(@buffer); }
        //    //else if (this == @shared) { writer.Write(nameof(@shared)); yield return nameof(@shared); }
        //    //else if (this == @coherent) { writer.Write(nameof(@coherent)); yield return nameof(@coherent); }
        //    //else if (this == @volatile) { writer.Write(nameof(@volatile)); yield return nameof(@volatile); }
        //    //else if (this == @restrict) { writer.Write(nameof(@restrict)); yield return nameof(@restrict); }
        //    //else if (this == @readonly) { writer.Write(nameof(@readonly)); yield return nameof(@readonly); }
        //    //else if (this == @writeonly) { writer.Write(nameof(@writeonly)); yield return nameof(@writeonly); }
        //    //else if (this == @subroutine) { writer.Write(nameof(@subroutine)); yield return nameof(@subroutine); }
        //    //else { throw new NotImplementedException(); }
        //}
    }
}
