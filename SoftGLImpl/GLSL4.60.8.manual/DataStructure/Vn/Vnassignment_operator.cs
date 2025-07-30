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
    /// Correspond to the Vn node assignment_operator in the grammar(GLSL).
    /// </summary>
    partial class Vnassignment_operator : IFullFormat {
        // [74] assignment_operator : '=' ;
        // [75] assignment_operator : '*=' ;
        // [76] assignment_operator : '/=' ;
        // [77] assignment_operator : '%=' ;
        // [78] assignment_operator : '+=' ;
        // [79] assignment_operator : '-=' ;
        // [80] assignment_operator : '<<=' ;
        // [81] assignment_operator : '>>=' ;
        // [82] assignment_operator : '&=' ;
        // [83] assignment_operator : '^=' ;
        // [84] assignment_operator : '|=' ;
        private readonly Token tkContent;
        public Vnassignment_operator(Token tkContent) {
            this._tokenRange = new TokenRange(tkContent);
            this.tkContent = tkContent;
        }
        private readonly TokenRange _tokenRange;


        public TokenRange Scope => _tokenRange;


        public void FullFormat(BlankConfig? preConfig, TextWriter writer, FormatContext context) {
            context.PrintBlanksAnd(this.tkContent, preConfig, writer);
        }


        //public void Format(TextWriter writer, FormatContext context) {
        //    writer.Write(this.tkContent.value);
        //}

        //public IEnumerable<string> YieldTokens(TextWriter writer, FormatContext context) {
        //    writer.Write(this.tkContent.value); yield return this.tkContent.value;
        //}


        //public static readonly assignment_operator @equal = new("="); // '=' ;
        //public static readonly assignment_operator @multiplyEqual = new("*="); // '*=' ;
        //public static readonly assignment_operator @slashEqual = new("/="); // '/=' ;
        //public static readonly assignment_operator @percentEqual = new("%="); // '%=' ;
        //public static readonly assignment_operator @plusEqual = new("+="); // '+=' ;
        //public static readonly assignment_operator @minusEqual = new("-="); // '-=' ;
        //public static readonly assignment_operator @shiftLeft = new("<<="); // '<<=' ;
        //public static readonly assignment_operator @shiftRight = new(">>="); // '>>=' ;
        //public static readonly assignment_operator @andEqual = new("&="); // '&=' ;
        //public static readonly assignment_operator @xorEqual = new("^="); // '^=' ;
        //public static readonly assignment_operator @orEqual = new("|="); // '|=' ;
    }
}
