using System;

namespace bitzhuwei.Compiler {
    /// <summary>
    /// It's an internal bag. You can find anything you need for syntax parse.
    /// </summary>
    internal partial class BCFLRParseContext {
        internal readonly LRParseContext context;
        ///// <summary>
        ///// we should parse the next tokens[nextTokenId]
        ///// </summary>
        //internal int nextTokenId = 0;
        /// <summary>
        /// It's an internal context. You can find anything you need for syntax parse.
        /// </summary>
        /// <param name="context"></param>
        internal BCFLRParseContext(LRParseContext context) {
            ArgumentNullException.ThrowIfNull(context);
            this.context = context;
        }

        public override string ToString() {
            return $"{context}";
        }

    }

}
