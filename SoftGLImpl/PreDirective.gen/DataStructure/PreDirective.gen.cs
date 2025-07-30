using System;
using bitzhuwei.Compiler;

namespace bitzhuwei.PreDirectiveFormat {
    /// <summary>
    /// extracted info from syntax tree(<see cref="LRNode"/>).
    /// </summary>
    public partial class PreDirective {
        private readonly VnPreDirective @final;
        internal PreDirective(VnPreDirective @final) {
            this.@final = @final;
            this._scope = new TokenRange(@final);
        }
        private readonly TokenRange _scope;
        public TokenRange Scope => _scope;
        public void FullFormat(BlankConfig? preConfig, TextWriter writer, FormatContext context) {
            {
                var start = 0;
                var end = this.final.Scope.start - 1;
                var config = new BlankConfig(inlineBlank: 1, forceNewline: false);
                context.PrintCommentsBetween(start, end, config, writer);
            }
            context.PrintBlanksAnd(this.@final, preConfig, writer);
            {
                var start = this.final.Scope.end + 1;
                var end = context.tokens.Count - 1;
                var config = new BlankConfig(inlineBlank: 1, forceNewline: false);
                context.PrintCommentsBetween(start, end, config, writer);
            }
        }



    }
}
