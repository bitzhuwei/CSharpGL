using System;

namespace bitzhuwei.Compiler {
    public class TokenErrorInfo {
        public readonly Token token;
        public readonly string message;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="token"></param>
        /// <param name="message"></param>
        public TokenErrorInfo(Token token, string message) {
            ArgumentNullException.ThrowIfNull(token);
            ArgumentNullException.ThrowIfNull(message);

            this.token = token;
            this.message = message;
        }

        public override string ToString() {
            //return string.Format("{0}|{1}", token, message);
            return $"{token.ToString()}|{message}";
        }
    }
}
