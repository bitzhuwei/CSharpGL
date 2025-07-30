using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using bitzhuwei.Compiler;
using Microsoft.CodeAnalysis.FlowAnalysis;

namespace bitzhuwei.GLSLFormat {
    /// <summary>
    /// Correspond to the Vn node init_declarator_list in the grammar(GLSL).
    /// </summary>
    partial class Vninit_declarator_list : IFullFormat {
        // [112]: init_declarator_list : single_declaration ;
        // [113]: init_declarator_list : init_declarator_list ',' 'identifier' ;
        // [114]: init_declarator_list : init_declarator_list ',' 'identifier' array_specifier ;
        // [115]: init_declarator_list : init_declarator_list ',' 'identifier' array_specifier '=' initializer ;
        // [116]: init_declarator_list : init_declarator_list ',' 'identifier' '=' initializer ;

        //void aaa() {
        //    int a, b;
        //    // TODO: how to deal with this ? 
        //    // int c, d[3]
        //    int c; int[] d = new int[3];

        //}
        private readonly Vnsingle_declaration first;
        /// <summary>
        /// ','
        /// </summary>
        private readonly List<Token> list0 = new();
        /// <summary>
        /// 'identifier'
        /// </summary>
        private readonly List<Token> list1 = new();
        /// <summary>
        /// array_specifier
        /// </summary>
        private readonly List<Vnarray_specifier?> list2 = new();
        /// <summary>
        /// '='
        /// </summary>
        private readonly List<Token?> list3 = new();
        /// <summary>
        /// initializer
        /// </summary>
        private readonly List<Vninitializer?> list4 = new();
        internal void Add(Token r4, Token r3, Vnarray_specifier? r2, Token? r1, Vninitializer? r0) {
            this.list0.Add(r4);
            this.list1.Add(r3);
            this.list2.Add(r2);
            this.list3.Add(r1);
            this.list4.Add(r0);
            if (r0 != null) { this._tokenRange.end = r0.Scope.end; }
            else if (r1 != null) { this._tokenRange.end = r1.index; }
            else if (r2 != null) { this._tokenRange.end = r2.Scope.end; }
            else { this._tokenRange.end = r3.index; }
        }

        public Vninit_declarator_list(Vnsingle_declaration single_declaration0) {
            this._tokenRange = new TokenRange(single_declaration0);
            this.first = single_declaration0;
        }

        //internal void Add(init_declarator_list_item item) {
        //    this.items.Add(item);
        //}
        private readonly TokenRange _tokenRange;


        public TokenRange Scope => _tokenRange;


        public void FullFormat(BlankConfig? preConfig, TextWriter writer, FormatContext context) {
            // [115]: init_declarator_list : init_declarator_list ',' 'identifier' array_specifier '=' initializer ;
            // 1. add type for each identifier
            // 2. transform ',' to ';'
            // 3. add ';' for the last identifier
            {
                this.first.FullFormat(preConfig, writer, context);
                if (this.list0.Count > 0) {
                    var config = new BlankConfig(inlineBlank: 0, forceNewline: false);
                    context.PrintCommentsBetween(this.first, this.list0[0], config, writer);
                }
            }
            var typeName = this.first.GetTypeName();
            var first = true;
            for (var i = 0; i < this.list0.Count; i++) {
                var tkComma = this.list0[i];
                var identifier = this.list1[i];
                var array_specifier = this.list2[i];
                var equal = this.list3[i];
                var initializer = this.list4[i];
                var config = new BlankConfig(inlineBlank: 0, forceNewline: false);
                if (first) {
                    context.PrintCommentsBetween(this.first, tkComma, config, writer);
                    first = false;
                }
                else if (this.list4[i - 1] != null) {
                    context.PrintCommentsBetween(this.list4[i - 1], tkComma, config, writer);
                }
                else if (this.list3[i - 1] != null) {
                    context.PrintCommentsBetween(this.list3[i - 1], tkComma, config, writer);
                }
                else if (this.list2[i - 1] != null) {
                    context.PrintCommentsBetween(this.list2[i - 1], tkComma, config, writer);
                }
                else if (this.list1[i - 1] != null) {
                    context.PrintCommentsBetween(this.list1[i - 1], tkComma, config, writer);
                }
                else if (this.list0[i - 1] != null) {
                    context.PrintCommentsBetween(this.list0[i - 1], tkComma, config, writer);
                }
                else {
                    throw new Exception("Algorithm error: this should never happen!");
                }
                //context.PrintBlanksAnd(tkComma, config, writer);
                context.PrintBlanksBefore(tkComma, config, writer); writer.Write(";");
                config.inlineBlank = 1;
                context.PrintCommentsBetween(tkComma, identifier, config, writer);
                //context.PrintBlanksAnd(identifier, config, writer);
                context.PrintBlanksBefore(identifier, config, writer);
                writer.Write(typeName); if (array_specifier != null) { writer.Write("[]"); }
                writer.Write(" "); writer.Write(identifier.value);
                if (array_specifier != null) {
                    writer.Write(" = new "); writer.Write(typeName);
                    config.inlineBlank = 0;
                    context.PrintCommentsBetween(identifier, array_specifier, config, writer);
                    array_specifier.FullFormat(config, writer, context);
                }
                if (equal != null && initializer != null) {
                    config.inlineBlank = 1;
                    if (array_specifier != null) {
                        context.PrintCommentsBetween(array_specifier, equal, config, writer);
                    }
                    else {
                        context.PrintCommentsBetween(identifier, equal, config, writer);
                    }
                    context.PrintBlanksAnd(equal, config, writer);
                    config.inlineBlank = 1;
                    if (equal != null) {
                        context.PrintCommentsBetween(equal, initializer, config, writer);
                    }
                    //throw new Exception("Algorithm error: this should never happen!");
                    initializer.FullFormat(config, writer, context);
                }
            }
            writer.Write(";");// ; for the last identifier
            // original version
            //{
            //    this.first.FullFormat(preConfig, writer, context);
            //    if (this.list0.Count > 0) {
            //        var config = new BlankConfig(inlineBlank: 0, forceNewline: false);
            //        context.PrintCommentsBetween(this.first, this.list0[0], config, writer);
            //    }
            //}
            //var first = true;
            //for (var i = 0; i < this.list0.Count; i++) {
            //    var tkComma = this.list0[i];
            //    var identifier = this.list1[i];
            //    var array_specifier2 = this.list2[i];
            //    var equal = this.list3[i];
            //    var initializer4 = this.list4[i];
            //    var config = new BlankConfig(inlineBlank: 0, forceNewline: false);
            //    if (first) {
            //        context.PrintCommentsBetween(this.first, tkComma, config, writer);
            //        first = false;
            //    }
            //    else if (this.list4[i - 1] != null) {
            //        context.PrintCommentsBetween(this.list4[i - 1], tkComma, config, writer);
            //    }
            //    else if (this.list3[i - 1] != null) {
            //        context.PrintCommentsBetween(this.list3[i - 1], tkComma, config, writer);
            //    }
            //    else if (this.list2[i - 1] != null) {
            //        context.PrintCommentsBetween(this.list2[i - 1], tkComma, config, writer);
            //    }
            //    else if (this.list1[i - 1] != null) {
            //        context.PrintCommentsBetween(this.list1[i - 1], tkComma, config, writer);
            //    }
            //    else if (this.list0[i - 1] != null) {
            //        context.PrintCommentsBetween(this.list0[i - 1], tkComma, config, writer);
            //    }
            //    else {
            //        throw new Exception("Algorithm error: this should never happen!");
            //    }
            //    context.PrintBlanksAnd(tkComma, config, writer);
            //    config.inlineBlank = 1;
            //    context.PrintCommentsBetween(tkComma, identifier, config, writer);
            //    context.PrintBlanksAnd(identifier, config, writer);
            //    if (array_specifier2 != null) {
            //        config.inlineBlank = 0;
            //        context.PrintCommentsBetween(identifier, array_specifier2, config, writer);
            //        array_specifier2.FullFormat(config, writer, context);
            //    }
            //    if (equal != null) {
            //        config.inlineBlank = 1;
            //        if (array_specifier2 != null) {
            //            context.PrintCommentsBetween(array_specifier2, equal, config, writer);
            //        }
            //        else {
            //            context.PrintCommentsBetween(identifier, equal, config, writer);
            //        }
            //        context.PrintBlanksAnd(equal, config, writer);
            //    }
            //    if (initializer4 != null) {
            //        config.inlineBlank = 1;
            //        if (equal != null) {
            //            context.PrintCommentsBetween(equal, initializer4, config, writer);
            //        }
            //        throw new Exception("Algorithm error: this should never happen!");
            //        initializer4.FullFormat(config, writer, context);
            //    }
            //}
        }


        //public void Format(TextWriter writer, FormatContext context) {
        //    {
        //        this.first.Format(writer, context);
        //    }
        //    for (var i = 0; i < this.list0.Count; i++) {
        //        var tkComma = this.list0[i];
        //        var identifier = this.list1[i];
        //        var array_specifier2 = this.list2[i];
        //        var equal = this.list3[i];
        //        var initializer4 = this.list4[i];
        //        writer.Write(tkComma.value); writer.Write(" ");
        //        writer.Write(identifier.value);
        //        if (array_specifier2 != null) {
        //            array_specifier2.Format(writer, context);
        //        }
        //        if (equal != null) {
        //            writer.Write(" "); writer.Write(equal.value); writer.Write(" ");
        //        }
        //        if (initializer4 != null) {
        //            initializer4.Format(writer, context);
        //        }
        //    }
        //}

        //public IEnumerable<string> YieldTokens(TextWriter writer, FormatContext context) {
        //    {
        //        foreach (var item in this.first.YieldTokens(writer, context)) {
        //            yield return item;
        //        }
        //    }
        //    for (var i = 0; i < this.list0.Count; i++) {
        //        var tkComma = this.list0[i];
        //        var identifier = this.list1[i];
        //        var array_specifier2 = this.list2[i];
        //        var equal = this.list3[i];
        //        var initializer4 = this.list4[i];
        //        writer.Write(tkComma.value); writer.Write(" ");
        //        yield return tkComma.value;
        //        writer.Write(identifier.value);
        //        yield return identifier.value;
        //        if (array_specifier2 != null) {
        //            foreach (var item in array_specifier2.YieldTokens(writer, context)) {
        //                yield return item;
        //            }
        //        }
        //        if (equal != null) {
        //            writer.Write(" "); writer.Write(equal.value); writer.Write(" ");
        //            yield return equal.value;
        //        }
        //        if (initializer4 != null) {
        //            foreach (var item in initializer4.YieldTokens(writer, context)) {
        //                yield return item;
        //            }
        //        }
        //    }
        //}
    }
}
