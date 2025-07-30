using System.Text;

namespace bitzhuwei.Compiler {
    /// <summary>
    /// 1/more lines of string that consist of a complete source code(compiling-unit).
    /// </summary>
    public class SingleString : ISourceCode {
        private readonly string sourceCode;

        public SingleString() {
            this.sourceCode = "";
        }

        public SingleString(string sourceCode) {
            this.sourceCode = sourceCode;
        }

        public void Append(string lines) {
            throw new Exception($"{nameof(SingleString)} no support {nameof(Append)}");
        }

        public int Length => this.sourceCode.Length;

        public char this[int index] => this.sourceCode[index];

        public string Substring(int startIndex, int length) {
            return this.sourceCode.Substring(startIndex, length);
        }

        public string Substring(int startIndex) {
            return this.sourceCode.Substring(startIndex);
        }

        public override string ToString() {
            return this.sourceCode;
        }

    }

}