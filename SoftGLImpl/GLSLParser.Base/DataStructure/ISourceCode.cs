namespace bitzhuwei.Compiler {
    /// <summary>
    /// treat the source code as a single <see cref="string"/>
    /// </summary>
    public interface ISourceCode {

        public void Append(string lines);

        public int Length { get; }

        public char this[int index] { get; }

        public string Substring(int startIndex, int length);
    }
}