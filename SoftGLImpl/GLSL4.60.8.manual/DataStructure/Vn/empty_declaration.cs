using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using bitzhuwei.Compiler;

namespace bitzhuwei.GLSLFormat {
    partial class empty_declaration : Vnexternal_declaration {
        // [4]: external_declaration : ';' ;

        private readonly Token tkSemicolon;
        public empty_declaration(Token tkSemicolon) {
            this._tokenRange = new TokenRange(tkSemicolon);
            this.tkSemicolon = tkSemicolon;
        }

        private readonly TokenRange _tokenRange;


        public override TokenRange Scope => _tokenRange;


        public override void FullFormat(BlankConfig? preConfig, TextWriter writer, FormatContext context) {
            context.PrintBlanksAnd(this.tkSemicolon, preConfig, writer);
        }

        //public override void Format(TextWriter writer, FormatContext context) {
        //    writer.Write(tkSemicolon.value);
        //}

        //public override IEnumerable<string> YieldTokens(TextWriter writer, FormatContext context) {
        //    writer.Write(tkSemicolon.value); yield return tkSemicolon.value;
        //}
    }
}
