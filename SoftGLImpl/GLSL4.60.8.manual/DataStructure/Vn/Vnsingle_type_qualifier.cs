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
    /// Correspond to the Vn node single_type_qualifier in the grammar(GLSL).
    /// </summary>
    abstract partial class Vnsingle_type_qualifier : IFullFormat {

        // [137]: single_type_qualifier : storage_qualifier ;
        // [138]: single_type_qualifier : layout_qualifier ;
        // [139]: single_type_qualifier : precision_qualifier ;
        // [140]: single_type_qualifier : interpolation_qualifier ;
        // [141]: single_type_qualifier : invariant_qualifier ;
        // [142]: single_type_qualifier : precise_qualifier ;

        public abstract string Name { get; }
        //public abstract void Format(TextWriter writer, FormatContext context);
        //public abstract IEnumerable<string> YieldTokens(TextWriter writer, FormatContext context);
        public abstract TokenRange Scope { get; }
        public abstract void FullFormat(BlankConfig? preConfig, TextWriter writer, FormatContext context);
    }
}
