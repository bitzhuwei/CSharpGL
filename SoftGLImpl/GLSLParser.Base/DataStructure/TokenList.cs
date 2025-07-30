using System;
using System.Text;

namespace bitzhuwei.Compiler {
    /// <summary>
    /// Result of lexical analyze.
    /// </summary>
    public partial class TokenList : List<Token> {
        public readonly ISourceCode sourceCode;

        public readonly Dictionary<Token, TokenErrorInfo> token2ErrorInfo = new();

        public bool Error => this.token2ErrorInfo.Count > 0;

        /// <summary>
        /// Result of lexical analyzing.
        /// </summary>
        /// <param name="sourceCode"></param>
        public TokenList(ISourceCode sourceCode) {
            ArgumentNullException.ThrowIfNull(sourceCode);

            this.sourceCode = sourceCode;
        }

        public override string ToString() {
            if (this.token2ErrorInfo.Count > 0) {
                var builder = new StringBuilder();
                builder.AppendLine($"{this.token2ErrorInfo.Count} errors:");
                foreach (var item in this.token2ErrorInfo) {
                    builder.AppendLine(item.Value.ToString());
                }
                return builder.ToString();
            }
            else {
                return $"{this.Count} tokens";
            }
        }
    }
}
