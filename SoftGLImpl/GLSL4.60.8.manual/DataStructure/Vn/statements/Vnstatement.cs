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
    /// Correspond to the Vn node statement in the grammar(GLSL).
    /// </summary>
    abstract partial class Vnstatement : IFullFormat {

        // [308]: statement : compound_statement ;
        // [309]: statement : simple_statement ;

        //public abstract void Format(TextWriter writer, FormatContext context);

        //public abstract IEnumerable<string> YieldTokens(TextWriter writer, FormatContext context);
        public abstract TokenRange Scope { get; }
        public abstract void FullFormat(BlankConfig? preConfig, TextWriter writer, FormatContext context);
    }
}
