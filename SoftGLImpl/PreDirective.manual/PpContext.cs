
using bitzhuwei.Compiler;
using bitzhuwei.PreDirectiveFormat;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Diagnostics;
using System.Text;

namespace SoftGLImpl {
    /// <summary>
    /// preprocessor context.
    /// </summary>
    public partial class PpContext {
        /// <summary>
        /// #line lineNumber fileNumber
        /// </summary>
        public int currentLine = 0;// experiment shows it starts from 1
        /// <summary>
        /// #line lineNumber fileNumber
        /// </summary>
        public int currentFile = 0;

        /// <summary>
        /// #if #ifdef #ifndef #elif #else #endif
        /// </summary>
        public bool isActive = true;

        /// <summary>
        /// <see cref="PreDefine.name"/> -> <see cref="PreDefine"/>
        /// </summary>
        public readonly Dictionary<string, PreDefine> name2Define = new() {
            {"__LINE__", new PreDefine("__LINE__", hasParentheses: false) },
            {"__FILE__", new PreDefine("__FILE__", hasParentheses: false) },
            {"__VERSION__", new PreDefine("__VERSION__", hasParentheses: false) },
        };

        public List<IfElifsElseEnd> conditionalObjs = new();

        public List<string> errors = new();

        public List<string> pragmas = new();

        public List<string> extensions = new();

        /// <summary>
        /// #extension xxx : require/enable/warn/disable
        /// </summary>
        public readonly Dictionary<string, string> extension2State = new();

        public PreVersion version = new PreVersion("110", "");

    }
}
