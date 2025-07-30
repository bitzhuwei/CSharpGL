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
    /// Correspond to the Vn node parameter_type_specifier in the grammar(GLSL).
    /// </summary>
    partial class Vnparameter_type_specifier : IFullFormat {
        // [111]: parameter_type_specifier : type_specifier ;
        private Vntype_specifier type_specifier0;

        public Vnparameter_type_specifier(Vntype_specifier type_specifier0) {
            this._tokenRange = new TokenRange(type_specifier0);
            this.type_specifier0 = type_specifier0;
        }
        private readonly TokenRange _tokenRange;


        public TokenRange Scope => _tokenRange;


        public bool IsVoid() { return this.type_specifier0.IsVoid(); }

        public void FullFormat(BlankConfig? preConfig, TextWriter writer, FormatContext context) {
            this.type_specifier0.FullFormat(preConfig, writer, context);
        }


        //public void Format(TextWriter writer, FormatContext context) {
        //    this.type_specifier0.Format(writer, context);
        //}

        //public IEnumerable<string> YieldTokens(TextWriter writer, FormatContext context) {
        //    foreach (var item in this.type_specifier0.YieldTokens(writer, context)) {
        //        yield return item;
        //    }
        //}
    }
}
