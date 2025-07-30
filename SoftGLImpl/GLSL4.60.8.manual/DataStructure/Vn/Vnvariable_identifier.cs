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
    /// Correspond to the Vn node variable_identifier in the grammar(GLSL).
    /// </summary>
    partial class Vnvariable_identifier : IFullFormat {
        // [6]: variable_identifier : 'identifier' ;
        // optimized (no in use)
        private readonly Token tkIdentifier;

        public Vnvariable_identifier(Token tkIdentifier) {
            this._tokenRange = new TokenRange(tkIdentifier);
            this.tkIdentifier = tkIdentifier;
        }
        private readonly TokenRange _tokenRange;


        public TokenRange Scope => _tokenRange;


        public void FullFormat(BlankConfig? preConfig, TextWriter writer, FormatContext context) {
            context.PrintBlanksAnd(this.tkIdentifier, preConfig, writer);
        }


        //public void Format(TextWriter writer, FormatContext context) {
        //    writer.Write(this.tkIdentifier.value);
        //}

        //public IEnumerable<string> YieldTokens(TextWriter writer, FormatContext context) {
        //    writer.Write(this.tkIdentifier.value); yield return this.tkIdentifier.value;
        //}
    }
}
