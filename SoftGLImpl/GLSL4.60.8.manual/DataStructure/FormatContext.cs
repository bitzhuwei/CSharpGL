using System;
using System.Data;
using System.Text;
using bitzhuwei.Compiler;

namespace bitzhuwei.GLSLFormat {
    /// <summary>
    /// Correspond to the Vn node additive_expression in the grammar(GLSL).
    /// </summary>
    public class FormatContext {

        /// <summary>
        /// replace '(', ')' in "uniform float values[] = float[](1.0, 1.0, 1.0);"
        /// </summary>
        public bool inInitArray = false;

        public readonly IReadOnlyList<Token> tokens;

        private readonly int tabUnit;
        private int tabCount;

        private int nextStructId = 0;
        public int NextId() {
            var result = nextStructId;
            nextStructId++;
            return result;
        }

        public void IncreaseTab() {
            this.tabCount++;
        }
        public void DecreaseTab() {
            this.tabCount--;
        }

        public int Tab => this.tabUnit * this.tabCount;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tokens"></param>
        /// <param name="tabUnit">how many space-chars is a tab?</param>
        /// <param name="tabCount">how many tabs?</param>
        public FormatContext(IReadOnlyList<Token> tokens, int tabUnit = 4, int tabCount = 0) {
            this.tabUnit = tabUnit;
            this.tabCount = tabCount;
            this.tokens = tokens;
        }

        public void PrintTab(TextWriter writer) {
            PrintBlanks(this.Tab, writer);
        }

        //TODO: use enum instead of bool as return type
        public LastComment PrintCommentsBetween(Token previous, Token next, BlankConfig config, TextWriter writer) {
            //var start = Algo.IndexOf(this.tokens, previous) + 1;
            var start = previous.index + 1;
            //var end = Algo.IndexOf(this.tokens, next) - 1;
            var end = next.index - 1;
            return PrintCommentsBetween(start, end, config, writer);
        }
        public LastComment PrintCommentsBetween(Token previous, IFullFormat next, BlankConfig config, TextWriter writer) {
            //var start = Algo.IndexOf(this.tokens, previous) + 1;
            var start = previous.index + 1;
            var end = next.Scope.start - 1;
            return PrintCommentsBetween(start, end, config, writer);
        }
        public LastComment PrintCommentsBetween(IFullFormat previous, Token next, BlankConfig config, TextWriter writer) {
            var start = previous.Scope.end + 1;
            //var end = Algo.IndexOf(this.tokens, next) - 1;
            var end = next.index - 1;
            return PrintCommentsBetween(start, end, config, writer);
        }
        public LastComment PrintCommentsBetween(IFullFormat previous, IFullFormat next, BlankConfig config, TextWriter writer) {
            var start = previous.Scope.end + 1;
            var end = next.Scope.start - 1;
            return PrintCommentsBetween(start, end, config, writer);
        }
        public LastComment PrintCommentsBefore(IFullFormat formatter, BlankConfig config, TextWriter writer) {
            var end = formatter.Scope.start - 1;
            return PrintCommentsBefore(end, config, writer);
        }
        public LastComment PrintCommentsBefore(Token token, BlankConfig config, TextWriter writer) {
            var end = token.index - 1;
            return PrintCommentsBefore(end, config, writer);
        }
        public LastComment PrintCommentsBefore(int end, BlankConfig config, TextWriter writer) {
            var start = end;
            while (0 <= start) {
                var token = this.tokens[start];
                if (token.kind == CompilerGLSL.st.blockComment块
                 || token.kind == CompilerGLSL.st.inlineComment行) {
                    start--;
                }
                else { break; }
            }
            start++;
            return PrintCommentsBetween(start, end, config, writer);
        }

        public enum LastComment {
            /// <summary>
            /// no commenet printed at all.
            /// </summary>
            None,
            /// <summary>
            /// the last printed comment is a inline comment.
            /// </summary>
            InlineComment,
            /// <summary>
            /// the last printed comment is a block comment.
            /// </summary>
            BlockComment,
        }
        /// <summary>
        /// print comment tokens(with blanks before them) from <paramref name="start"/> to <paramref name="end"/>.
        /// <para>both tokens[<paramref name="start"/>] and tokens[<paramref name="end"/>] are included.</para>
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="writer"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public LastComment PrintCommentsBetween(int start, int end, BlankConfig config, TextWriter writer) {
            var lastComment = LastComment.None;
            if (start <= end) {
                config.inlineBlank = -1;
                for (int i = start; i <= end; i++) {
                    var token = tokens[i];
                    if (false) { }
                    else if (token.kind == CompilerGLSL.st.blockComment块) {
                        PrintBlanksBefore(token, config, writer);
                        writer.Write(token.value);
                        lastComment = LastComment.BlockComment;
                    }
                    else if (token.kind == CompilerGLSL.st.inlineComment行) {
                        PrintBlanksBefore(token, config, writer);
                        writer.Write(token.value.TrimEnd());
                        lastComment = LastComment.InlineComment;
                    }
                    else {
                        throw new Exception("Algorithm error: this should never happen!");
                    }
                }
            }
            return lastComment;
        }

        /// <summary>
        /// print ' ' or \n\r between <paramref name="token"/> and its previous token. and then print the <paramref name="token"/>
        /// </summary>
        /// <param name="token"></param>
        /// <param name="config">if null, it means to print this <paramref name="formatter"/> directly(without any pre-space-char)</param>
        /// <param name="writer"></param>
        public void PrintBlanksAnd(Token token, BlankConfig? config, TextWriter writer) {
            if (config != null) {
                PrintBlanksBefore(token, config.Value, writer);
            }

            writer.Write(token.value);
        }
        /// <summary>
        /// print ' ' or \n\r between <paramref name="formatter"/> and its previous token. and then print the <paramref name="formatter"/>
        /// </summary>
        /// <param name="formatter"></param>
        /// <param name="config">if null, it means to print this <paramref name="formatter"/> directly(without any pre-space-char)</param>
        /// <param name="writer"></param>
        public void PrintBlanksAnd(IFullFormat formatter, BlankConfig? config, TextWriter writer) {
            formatter.FullFormat(config, writer, this);
        }
        /// <summary>
        /// print blanks before <paramref name="formatter"/> according to <paramref name="config"/>
        /// </summary>
        /// <param name="token"></param>
        /// <param name="config"></param>
        /// <param name="writer"></param>
        public void PrintBlanksBefore(IFullFormat formatter, BlankConfig config, TextWriter writer) {
            var token = this.tokens[formatter.Scope.start];
            PrintBlanksBefore(token, config, writer);
        }

        /// <summary>
        /// print blanks before <paramref name="token"/> according to <paramref name="config"/>
        /// </summary>
        /// <param name="token"></param>
        /// <param name="config"></param>
        /// <param name="writer"></param>
        public void PrintBlanksBefore(Token token, BlankConfig config, TextWriter writer) {
            var blank = 0; var newlines = 0;
            // keep original newlines.
            if (token.index > 0) {
                var previous = this.tokens[token.index - 1];
                newlines = token.start.line - previous.end.line;
            }
            else {
                newlines = token.start.line - 1; // start.line starts from 1, thus -1 here.
            }

            // deal with things like '{' statement_list '}'
            // force to put a newline after '{' if '}' is not in the same line with '{'
            if (newlines == 0) { if (config.forceNewline) { newlines = 1; } }

            if (newlines == 0) { // if not need newlines, then we need blanks.
                if (config.inlineBlank >= 0) { // format according to command.
                    blank = config.inlineBlank;
                }
                else { // there is no command.
                    if (token.index > 0) { // keep original blanks unchanged.
                        var previous = this.tokens[token.index - 1];
                        blank = token.start.index - previous.end.index - 1;
                    }
                }
            }

            if (newlines > 0) {
                PrintNewlines(newlines, writer);
                this.PrintTab(writer);
            }
            else {
                PrintBlanks(blank, writer);
            }
        }

        private static readonly Dictionary<int, string> newlineDict = new();
        private static void PrintNewlines(int count, TextWriter writer) {
            if (count <= 0) { return; }
            if (!newlineDict.TryGetValue(count, out var s)) {
                var builder = new StringBuilder();
                for (var i = 0; i < count; i++) { builder.Append(Environment.NewLine); }
                s = builder.ToString();
                newlineDict.Add(count, s);
            }
            writer.Write(s);
        }

        private static readonly Dictionary<int, string> blankDict = new();
        private static void PrintBlanks(int count, TextWriter writer) {
            if (count <= 0) { return; }
            if (!blankDict.TryGetValue(count, out var s)) {
                s = new string(' ', count);
                blankDict.Add(count, s);
            }
            writer.Write(s);
        }

        public override string ToString() {
            return $"tab: {tabUnit * tabCount}, {tokens.Count} tokens";
        }
    }
}

