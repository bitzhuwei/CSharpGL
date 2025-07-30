﻿namespace CSharpGL {
    /// <summary>
    /// A uiform variable in shader.
    /// </summary>
    public abstract unsafe class UniformSingleVariableBase : UniformVariable {
        /// <summary>
        /// A uiform variable in shader.
        /// </summary>
        /// <param name="varName"></param>
        public UniformSingleVariableBase(string varName) : base(varName) { }
    }
}