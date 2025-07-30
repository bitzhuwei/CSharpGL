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
    /// Correspond to the Vn node simple_statement in the grammar(GLSL).
    /// </summary>
    abstract partial class Vnsimple_statement : Vnstatement {
        // [310]: simple_statement : declaration_statement ;
        // [311]: simple_statement : expression_statement ;
        // [312]: simple_statement : selection_statement ;
        // [313]: simple_statement : switch_statement ;
        // [314]: simple_statement : case_label ;
        // [315]: simple_statement : iteration_statement ;
        // [316]: simple_statement : jump_statement ;

    }
}
