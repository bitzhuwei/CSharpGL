using bitzhuwei.Compiler;

namespace SoftGLImpl {
    /// <summary>
    /// #define(param-list) ...
    /// #define minus2(a, b) ((a) - (b) - (b))
    /// #define minus2(a, b)
    /// #define hello() doSomething
    /// #define hello()
    /// #define hello () doSomething
    /// #define hello
    /// #define PI 3.1415
    /// </summary>
    public class PreDefine {
        public readonly string name;

        /// <summary>
        /// #define hello() => true
        /// <para>#define hello () => false</para>
        /// </summary>
        public readonly bool hasParentheses;
        /// <summary>
        /// formal-param -> index in param-list
        /// if <see cref="PreDefine.hasParentheses"/> is false, then this list is empty.
        /// if it's true, it may still be empty.
        /// </summary>
        public readonly Dictionary<string, int> formalParam2Index = new();
        /// <summary>
        /// tokens(...) in
        /// <para>#define(param-list) ...</para>
        /// </summary>
        public readonly List<Token> postTokens = new();

        public PreDefine(string name, bool hasParentheses) {
            this.name = name;
            this.hasParentheses = hasParentheses;
        }

        public override string ToString() {
            return $"#{name} ..";
        }
    }
}