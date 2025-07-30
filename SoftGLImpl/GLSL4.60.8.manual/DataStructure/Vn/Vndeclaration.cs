using bitzhuwei.Compiler;
using Microsoft.VisualBasic;
using System.Diagnostics;

namespace bitzhuwei.GLSLFormat {
    partial class declaration_identifiers : Vndeclaration {
        // [94] declaration : type_qualifier ';' ;

        // [95] declaration : type_qualifier 'identifier' ';' ;
        // [96] declaration : type_qualifier 'identifier' identifier_list ';' ;

        private readonly Vntype_qualifier type_qualifier3;
        private readonly Token? identifier;
        private readonly Vnidentifier_list? identifierList;
        private readonly Token tkSemicolon;

        public declaration_identifiers(Vntype_qualifier type_qualifier3,
            Token? identifier, Vnidentifier_list? identifier_list1, Token tkSemicolon) {
            this._tokenRange = new TokenRange(type_qualifier3, tkSemicolon);
            this.type_qualifier3 = type_qualifier3;
            this.identifier = identifier;
            this.identifierList = identifier_list1;
            this.tkSemicolon = tkSemicolon;
        }
        private readonly TokenRange _tokenRange;


        public override TokenRange Scope => _tokenRange;


        public override void FullFormat(BlankConfig? preConfig, TextWriter writer, FormatContext context) {
            this.type_qualifier3.FullFormat(preConfig, writer, context);
            if (this.identifier != null) {
                {
                    var config = new BlankConfig(inlineBlank: 1, forceNewline: false);
                    var lastComment = context.PrintCommentsBetween(this.type_qualifier3, this.identifier, config, writer);
                    config.inlineBlank = lastComment != FormatContext.LastComment.None ? 0 : 1;
                    context.PrintBlanksAnd(this.identifier, config, writer);
                }
                if (this.identifierList != null) {
                    // [96] declaration : type_qualifier 'identifier' identifier_list ';' ;
                    var config = new BlankConfig(inlineBlank: 1, forceNewline: false);
                    var lastComment = context.PrintCommentsBetween(this.identifier, this.identifierList, config, writer);
                    config.inlineBlank = lastComment != FormatContext.LastComment.None ? 0 : 1;
                    this.identifierList.FullFormat(config, writer, context);
                    config.inlineBlank = 0;
                    context.PrintCommentsBetween(this.identifierList, this.tkSemicolon, config, writer);
                }
                else {
                    // [95] declaration : type_qualifier 'identifier' ';' ;
                    var config = new BlankConfig(inlineBlank: 0, forceNewline: false);
                    context.PrintCommentsBetween(this.identifier, this.tkSemicolon, config, writer);
                }
                {
                    var config = new BlankConfig(inlineBlank: 0, forceNewline: false);
                    context.PrintBlanksAnd(this.tkSemicolon, config, writer);
                }
            }
            else {
                // [94] declaration : type_qualifier ';' ;
                writer.Write($" static int {this.type_qualifier3.LastQualifierName()}Desc");
                var config = new BlankConfig(inlineBlank: 0, forceNewline: false);
                context.PrintCommentsBetween(this.type_qualifier3, this.tkSemicolon, config, writer);
                context.PrintBlanksAnd(this.tkSemicolon, config, writer);
            }

        }

        //public override void Format(TextWriter writer, FormatContext context) {
        //    this.type_qualifier3.Format(writer, context);
        //    writer.Write(" ");
        //    if (this.identifier != null) { writer.Write(this.identifier.value); }
        //    if (this.identifierList != null) {
        //        writer.Write(" ");
        //        this.identifierList.Format(writer, context);
        //    }
        //    writer.Write(this.tkSemicolon.value);
        //}

        //public override IEnumerable<string> YieldTokens(TextWriter writer, FormatContext context) {
        //    foreach (var item in this.type_qualifier3.YieldTokens(writer, context)) {
        //        yield return item;
        //    }
        //    writer.Write(" ");
        //    if (this.identifier != null) {
        //        writer.Write(this.identifier.value); yield return this.identifier.value;
        //    }
        //    if (this.identifierList != null) {
        //        writer.Write(" ");
        //        foreach (var item in this.identifierList.YieldTokens(writer, context)) {
        //            yield return item;
        //        }
        //    }
        //    writer.Write(this.tkSemicolon.value); yield return this.tkSemicolon.value;
        //}
    }

    partial class declaration_type_qualifier : Vndeclaration {
        // [91] declaration : type_qualifier 'identifier' '{' struct_declaration_list '}' ';' ;
        // [92] declaration : type_qualifier 'identifier' '{' struct_declaration_list '}' 'identifier' ';' ;
        // [93] declaration : type_qualifier 'identifier' '{' struct_declaration_list '}' 'identifier' array_specifier ';' ;

        private readonly Vntype_qualifier type_qualifier5;
        private readonly Token pre_identifier;
        private readonly Token tkLeftBrace;
        private readonly Vnstruct_declaration_list struct_declaration_list2;
        private readonly Token tkRightBrace;
        private readonly Token? post_identifier;
        private readonly Vnarray_specifier? array_specifier1;
        private readonly Token tkSemicolon;

        public declaration_type_qualifier(
            Vntype_qualifier type_qualifier5, Token pre_identifier,
            Token tkLeftBrace, Vnstruct_declaration_list struct_declaration_list2, Token tkRightBrace,
            Token? post_identifier, Vnarray_specifier? array_specifier1, Token tkSemicolon) {
            this._tokenRange = new TokenRange(type_qualifier5, tkSemicolon);
            this.type_qualifier5 = type_qualifier5;
            this.pre_identifier = pre_identifier;
            this.tkLeftBrace = tkLeftBrace;
            this.struct_declaration_list2 = struct_declaration_list2;
            this.tkRightBrace = tkRightBrace;
            this.post_identifier = post_identifier;
            this.array_specifier1 = array_specifier1;
            this.tkSemicolon = tkSemicolon;
        }
        private readonly TokenRange _tokenRange;


        public override TokenRange Scope => _tokenRange;


        public override void FullFormat(BlankConfig? preConfig, TextWriter writer, FormatContext context) {
            this.type_qualifier5.FullFormat(preConfig, writer, context);
            var config = new BlankConfig(inlineBlank: 1, forceNewline: false);
            if (context.PrintCommentsBetween(this.type_qualifier5, this.pre_identifier, config, writer) == FormatContext.LastComment.InlineComment) {
                writer.WriteLine(); context.PrintTab(writer);
            }
            writer.Write(" struct");
            context.PrintBlanksAnd(this.pre_identifier, config, writer); if (this.post_identifier == null) { writer.Write("字"); }
            context.PrintCommentsBetween(this.pre_identifier, this.tkLeftBrace, config, writer);
            context.PrintBlanksAnd(this.tkLeftBrace, config, writer);
            context.PrintCommentsBetween(this.tkLeftBrace, this.struct_declaration_list2, config, writer);
            var newlines = this.tkRightBrace.start.line > this.tkLeftBrace.end.line;
            if (newlines) { context.IncreaseTab(); }
            this.struct_declaration_list2.FullFormat(config, writer, context);
            context.PrintCommentsBetween(this.struct_declaration_list2, this.tkRightBrace, config, writer);
            if (newlines) { context.DecreaseTab(); }
            context.PrintBlanksAnd(this.tkRightBrace, config, writer);

            if (this.post_identifier != null) {
                if (this.array_specifier1 != null) {
                    // [93] declaration : type_qualifier 'identifier' '{' struct_declaration_list '}' 'identifier' array_specifier ';' ;
                    if (context.PrintCommentsBetween(this.tkRightBrace, this.post_identifier, config, writer) == FormatContext.LastComment.InlineComment) {
                        writer.WriteLine(); context.PrintTab(writer);
                    }
                    else { writer.Write(" "); }
                    // struct-name[] v = new struct-name[3];
                    writer.Write(this.pre_identifier.value); writer.Write("[] ");
                    writer.Write(this.post_identifier.value); writer.Write(" = new ");
                    writer.Write(this.pre_identifier.value);
                    context.PrintBlanksAnd(this.array_specifier1, config, writer); writer.Write(";");
                }
                else {
                    // [92] declaration : type_qualifier 'identifier' '{' struct_declaration_list '}' 'identifier' ';' ;
                    if (context.PrintCommentsBetween(this.tkRightBrace, this.post_identifier, config, writer) == FormatContext.LastComment.InlineComment) {
                        writer.WriteLine(); context.PrintTab(writer);
                    }
                    else { writer.Write(" "); }
                    // struct-name v;
                    writer.Write(this.pre_identifier.value); writer.Write(" ");
                    writer.Write(this.post_identifier.value); writer.Write(";");
                }
            }
            else {
                // [91] declaration : type_qualifier 'identifier' '{' struct_declaration_list '}' ';' ;
                if (context.PrintCommentsBetween(this.tkRightBrace, this.tkSemicolon, config, writer) == FormatContext.LastComment.InlineComment) {
                    writer.WriteLine(); context.PrintTab(writer);
                }
                else { writer.Write(" "); }
                // struct-name v;
                writer.Write(this.pre_identifier.value); writer.Write("字"); writer.Write(" ");
                writer.Write(this.pre_identifier.value); writer.Write(";");
            }

            if (this.post_identifier != null) {
                context.PrintCommentsBetween(this.tkRightBrace, this.post_identifier, config, writer);
                context.PrintBlanksAnd(this.post_identifier, config, writer);
            }

            context.PrintBlanksBefore(this.tkSemicolon, config, writer);
            // should not print the last ';'

            //original version
            //this.type_qualifier5.FullFormat(preConfig, writer, context);
            //var config = new BlankConfig(inlineBlank: 1, forceNewline: false);
            //context.PrintCommentsBetween(this.type_qualifier5, this.pre_identifier, config, writer);
            //context.PrintBlanksAnd(this.pre_identifier, config, writer);
            //context.PrintCommentsBetween(this.pre_identifier, this.tkLeftBrace, config, writer);
            //context.PrintBlanksAnd(this.tkLeftBrace, config, writer);
            //context.PrintCommentsBetween(this.tkLeftBrace, this.struct_declaration_list2, config, writer);
            //var newlines = this.tkRightBrace.start.line > this.tkLeftBrace.end.line;
            //if (newlines) { context.IncreaseTab(); }
            //this.struct_declaration_list2.FullFormat(config, writer, context);
            //context.PrintCommentsBetween(this.struct_declaration_list2, this.tkRightBrace, config, writer);
            //if (newlines) { context.DecreaseTab(); }
            //context.PrintBlanksAnd(this.tkRightBrace, config, writer);

            //if (this.post_identifier != null) {
            //    context.PrintCommentsBetween(this.tkRightBrace, this.post_identifier, config, writer);
            //    context.PrintBlanksAnd(this.post_identifier, config, writer);
            //}

            //config.inlineBlank = 0;
            //if (this.array_specifier1 != null) {
            //    if (this.post_identifier != null) {
            //        context.PrintCommentsBetween(this.post_identifier, this.array_specifier1, config, writer);
            //    }
            //    else { throw new NotImplementedException(); }
            //    config.inlineBlank = 0;
            //    this.array_specifier1.FullFormat(config, writer, context);
            //}

            //if (this.array_specifier1 != null) {
            //    context.PrintCommentsBetween(this.array_specifier1, this.tkSemicolon, config, writer);
            //}
            //else if (this.post_identifier != null) {
            //    context.PrintCommentsBetween(this.post_identifier, this.tkSemicolon, config, writer);
            //}
            //else if (this.tkRightBrace != null) {
            //    context.PrintCommentsBetween(this.tkRightBrace, this.tkSemicolon, config, writer);
            //}
            //else { throw new NotImplementedException(); }
            //context.PrintBlanksAnd(this.tkSemicolon, config, writer);
        }

        //public override void Format(TextWriter writer, FormatContext context) {
        //    this.type_qualifier5.Format(writer, context);
        //    writer.Write(" ");
        //    writer.Write(this.pre_identifier.value);
        //    writer.Write(" ");
        //    writer.Write(this.tkLeftBrace.value);
        //    this.struct_declaration_list2.Format(writer, context);
        //    writer.Write(this.tkRightBrace.value);

        //    if (this.post_identifier != null) {
        //        writer.Write(" ");
        //        writer.Write(this.post_identifier.value);
        //    }

        //    if (this.array_specifier1 != null) {
        //        this.array_specifier1.Format(writer, context);
        //    }

        //    writer.Write(this.tkSemicolon.value);
        //}

        //public override IEnumerable<string> YieldTokens(TextWriter writer, FormatContext context) {
        //    foreach (var item in this.type_qualifier5.YieldTokens(writer, context)) {
        //        yield return item;
        //    }
        //    writer.Write(" ");
        //    writer.Write(this.pre_identifier.value); yield return this.pre_identifier.value;
        //    writer.Write(" ");
        //    writer.Write(this.tkLeftBrace.value); yield return this.tkLeftBrace.value;
        //    foreach (var item in this.struct_declaration_list2.YieldTokens(writer, context)) {
        //        yield return item;
        //    }
        //    writer.Write(this.tkRightBrace.value); yield return this.tkRightBrace.value;

        //    if (this.post_identifier != null) {
        //        writer.Write(" ");
        //        writer.Write(this.post_identifier.value); yield return this.post_identifier.value;
        //    }

        //    if (this.array_specifier1 != null) {
        //        foreach (var item in this.array_specifier1.YieldTokens(writer, context)) {
        //            yield return item;
        //        }
        //    }

        //    writer.Write(this.tkSemicolon.value); yield return this.tkSemicolon.value;
        //}
    }

    partial class declaration_precision : Vndeclaration {
        // [90] declaration : 'precision' precision_qualifier type_specifier ';' ;

        private readonly Token tkPrecision;
        private readonly Vnprecision_qualifier precision_qualifier2;
        private readonly Vntype_specifier type_specifier1;
        private readonly Token tkSemicolon;

        public declaration_precision(Token tkPrecision,
            Vnprecision_qualifier precision_qualifier2,
            Vntype_specifier type_specifier1, Token tkSemicolon) {
            this._tokenRange = new TokenRange(tkPrecision, tkSemicolon);
            this.tkPrecision = tkPrecision;
            this.precision_qualifier2 = precision_qualifier2;
            this.type_specifier1 = type_specifier1;
            this.tkSemicolon = tkSemicolon;
        }
        private readonly TokenRange _tokenRange;


        public override TokenRange Scope => _tokenRange;


        public override void FullFormat(BlankConfig? preConfig, TextWriter writer, FormatContext context) {
            //context.PrintBlanksAnd(this.tkPrecision, preConfig, writer);
            if (preConfig != null) {
                context.PrintBlanksBefore(this.tkPrecision, preConfig.Value, writer);
            }
            writer.Write("/*"); writer.Write(this.tkPrecision.value); writer.Write("*/");
            var config = new BlankConfig(inlineBlank: 1, forceNewline: false);
            context.PrintCommentsBetween(this.tkPrecision, this.precision_qualifier2, config, writer);
            this.precision_qualifier2.FullFormat(config, writer, context);
            context.PrintCommentsBetween(this.precision_qualifier2, this.type_specifier1, config, writer);
            this.type_specifier1.FullFormat(config, writer, context);
            writer.Write($" uselessVar{context.NextId()}");
            config.inlineBlank = 0;
            context.PrintCommentsBetween(this.type_specifier1, this.tkSemicolon, config, writer);
            context.PrintBlanksAnd(this.tkSemicolon, config, writer);
        }

        //public override void Format(TextWriter writer, FormatContext context) {
        //    writer.Write(this.tkPrecision.value);
        //    writer.Write(" ");
        //    this.precision_qualifier2.Format(writer, context);
        //    writer.Write(" ");
        //    this.type_specifier1.Format(writer, context);
        //    writer.Write(this.tkSemicolon.value);
        //}

        //public override IEnumerable<string> YieldTokens(TextWriter writer, FormatContext context) {
        //    writer.Write(this.tkPrecision.value); yield return this.tkPrecision.value;
        //    writer.Write(" ");
        //    foreach (var item in this.precision_qualifier2.YieldTokens(writer, context)) {
        //        yield return item;
        //    }
        //    writer.Write(" ");
        //    foreach (var item in this.type_specifier1.YieldTokens(writer, context)) {
        //        yield return item;
        //    }
        //    writer.Write(this.tkSemicolon.value); yield return this.tkPrecision.value;
        //}
    }

    partial class declaration_init_declarator_list : Vndeclaration {
        // [89] declaration : init_declarator_list ';' ;

        private readonly Vninit_declarator_list init_declarator_list1;
        private readonly Token tkSemicolon;

        public declaration_init_declarator_list(
            Vninit_declarator_list init_declarator_list1, Token tkSemicolon) {
            this._tokenRange = new TokenRange(init_declarator_list1, tkSemicolon);
            this.init_declarator_list1 = init_declarator_list1;
            this.tkSemicolon = tkSemicolon;
        }
        private readonly TokenRange _tokenRange;


        public override TokenRange Scope => _tokenRange;


        public override void FullFormat(BlankConfig? preConfig, TextWriter writer, FormatContext context) {
            this.init_declarator_list1.FullFormat(preConfig, writer, context);
            var config = new BlankConfig(inlineBlank: 0, forceNewline: false);
            context.PrintCommentsBetween(this.init_declarator_list1, this.tkSemicolon, config, writer);
            //context.PrintBlanksAnd(this.tkSemicolon, config, writer);
            context.PrintBlanksBefore(this.tkSemicolon, config, writer);
        }

        //public override void Format(TextWriter writer, FormatContext context) {
        //    this.init_declarator_list1.Format(writer, context);
        //    writer.Write(this.tkSemicolon.value);
        //}

        //public override IEnumerable<string> YieldTokens(TextWriter writer, FormatContext context) {
        //    foreach (var item in this.init_declarator_list1.YieldTokens(writer, context)) {
        //        yield return item;
        //    }
        //    writer.Write(this.tkSemicolon.value); yield return this.tkSemicolon.value;
        //}
    }

    partial class declaration_function_prototype : Vndeclaration {
        // [88] declaration : function_prototype ';' ;

        private readonly Vnfunction_prototype function_prototype1;
        private readonly Token tkSemicolon;

        public declaration_function_prototype(
            Vnfunction_prototype function_prototype1, Token tkSemicolon) {
            this._tokenRange = new TokenRange(function_prototype1, tkSemicolon);
            this.function_prototype1 = function_prototype1;
            this.tkSemicolon = tkSemicolon;
        }

        private readonly TokenRange _tokenRange;


        public override TokenRange Scope => _tokenRange;


        public override void FullFormat(BlankConfig? preConfig, TextWriter writer, FormatContext context) {
            this.function_prototype1.FullFormat(preConfig, writer, context);
            var config = new BlankConfig(inlineBlank: 0, forceNewline: false);
            context.PrintCommentsBetween(this.function_prototype1, this.tkSemicolon, config, writer);
            context.PrintBlanksAnd(this.tkSemicolon, config, writer);
        }

        //public override void Format(TextWriter writer, FormatContext context) {
        //    this.function_prototype1.Format(writer, context);
        //    writer.Write(this.tkSemicolon.value);
        //}

        //public override IEnumerable<string> YieldTokens(TextWriter writer, FormatContext context) {
        //    foreach (var item in this.function_prototype1.YieldTokens(writer, context)) {
        //        yield return item;
        //    }
        //    writer.Write(this.tkSemicolon.value); yield return this.tkSemicolon.value;
        //}
    }
    /// <summary>
    /// Correspond to the Vn node declaration in the grammar(GLSL).
    /// </summary>
    abstract partial class Vndeclaration : Vnexternal_declaration {
    }
}
