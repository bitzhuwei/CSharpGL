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
    /// Correspond to the Vn node unary_operator in the grammar(GLSL).
    /// </summary>
    partial class Vnunary_operator : IFullFormat {
        // [36]: unary_operator : '+' ;
        // [37]: unary_operator : '-' ;
        // [38]: unary_operator : '!' ;
        // [39]: unary_operator : '~' ;

        private readonly Token tkContent;
        public Vnunary_operator(Token tkContent) {
            this._tokenRange = new TokenRange(tkContent);
            this.tkContent = tkContent;
        }
        ///// <summary>
        ///// +
        ///// </summary>
        //public static readonly unary_operator positive = new();//+
        ///// <summary>
        ///// -
        ///// </summary>
        //public static readonly unary_operator negtive = new();//-
        ///// <summary>
        ///// !
        ///// </summary>
        //public static readonly unary_operator truefalse = new();//!
        ///// <summary>
        ///// ~
        ///// </summary>
        //public static readonly unary_operator reverse = new();//~
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
        //    //if (false) { }
        //    //else if (this == positive) { writer.Write("+"); yield return "+"; }
        //    //else if (this == negtive) { writer.Write("-"); yield return "-"; }
        //    //else if (this == truefalse) { writer.Write("!"); yield return "!"; }
        //    //else if (this == reverse) { writer.Write("~"); yield return "~"; }
        //    //else { throw new NotImplementedException(); }
        //}
    }
}
