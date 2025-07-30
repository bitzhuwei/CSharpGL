using System.Text;

namespace bitzhuwei.Compiler {
    /// <summary>
    /// 1/more lines of string that consist of a complete source code(compiling-unit).
    /// </summary>
    public class SourceCode : ISourceCode {
        private readonly StringBuilder builder = new();

        public SourceCode() { }

        public SourceCode(string codeSegment) {
            this.Append(codeSegment);
        }

        public void Append(string codeSegment) {
            this.builder.Append(codeSegment);
        }
        public int Length => this.builder.Length;

        public char this[int index] => this.builder[index];

        public string Substring(int startIndex, int length) {
            // this is why it's dummy
            var builder = new StringBuilder();
            for (int i = 0; i < length; i++) {
                builder.Append(this.builder[startIndex + i]);
            }
            return builder.ToString();
        }
    }

}