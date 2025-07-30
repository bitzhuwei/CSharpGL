using System;

namespace bitzhuwei.Compiler {
    /// <summary>
    /// It's an internal bag. You can find anything you need for extracting.
    /// </summary>
    /// <typeparam name="T">Extracted Type</typeparam>
    public class TContext<T> where T : class {
        /// <summary>
        /// final result of extracting.
        /// </summary>
        public T? result;

        /// <summary>
        /// syntax tree from syntax parse.
        /// </summary>
        public readonly LRNode rootNode;
        /// <summary>
        /// token list from lexical analyzing.
        /// </summary>
        public readonly IReadOnlyList<Token> tokens;
        /// <summary>
        /// original source code.
        /// </summary>
        public readonly ISourceCode sourceCode;
        /// <summary>
        /// push children from left to right, then pop them(from right to left) to parent node,
        /// so that I can construct object in upper node and for the upper node.
        /// <para>works in post-order traversing environment.</para>
        /// </summary>
        public readonly Stack<object> rightStack = new();
        // TODO: I don't know if there's any difference between Stack and Stack<object>.
        //public readonly Stack rightStack = new();

        /// <summary>
        /// use this dict to pass user defined data.
        /// </summary>
        public readonly Dictionary<string, object> tagDict = new();

        /// <summary>
        /// It's an internal bag. You can find anything you need for extracting.
        /// </summary>
        /// <param name="rootNode">syntax tree from syntax parse.</param>
        /// <param name="tokens">token list from lexical analyze.</param>
        /// <param name="tokens">original source code.</param>
        /// <param name="tag">add <paramref name="tag"/>,<paramref name="obj"/> to <see cref="TContext{T}.tagDict"/></param>
        /// <param name="obj">add <paramref name="tag"/>,<paramref name="obj"/> to <see cref="TContext{T}.tagDict"/></param>
        internal TContext(LRNode rootNode, IReadOnlyList<Token> tokens, ISourceCode sourceCode, string? tag, object? obj) {
            this.rootNode = rootNode;
            this.tokens = tokens;
            this.sourceCode = sourceCode;
            if (tag != null && obj != null) {
                this.tagDict.Add(tag, obj);
            }
        }
    }


}