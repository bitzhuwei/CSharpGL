using System;

namespace bitzhuwei.Compiler {
    partial class TokenList {
        /// <summary>
        /// print the token list.
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="stArray"></param>
        public void Print(System.IO.TextWriter writer, IReadOnlyList<string>? stArray = null) {
            {
                writer.WriteLine($"{this.token2ErrorInfo.Count} errors:");
                var query = from item in this.token2ErrorInfo
                            orderby item.Key.start.index ascending
                            select item;
                foreach (var item in query) {
                    var token = item.Key; var errorInfo = item.Value;
                    token.Print(writer, stArray);
                    writer.WriteLine($" : {errorInfo.message}");
                }
            }
            {
                var count = this.Count;
                writer.WriteLine($"{count} tokens:");
                for (int i = 0; i < count; i++) {
                    var token = this[i];
                    token.Print(writer, stArray); writer.WriteLine();
                }
            }
        }
    }
}
