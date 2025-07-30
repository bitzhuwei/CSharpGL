﻿using System;

namespace CSharpGL {
    /// <summary>
    /// A uiform variable in shader.
    /// </summary>
    public abstract unsafe class UniformSingleVariable<T> : UniformSingleVariableBase where T : struct, IEquatable<T> {
        /// <summary>
        ///
        /// </summary>
        protected T value;

        /// <summary>
        /// Don't rename this property because its used in Renderer.GetVariable&lt;T&gt;(T value, string varNameInShader).
        /// </summary>
        [UniformValueAttribute]
        public T Value {
            get { return this.value; }
            set {
                if (!value.Equals(this.value)) {
                    this.value = value;
                    this.updated = true;
                }
            }
        }

        /// <summary>
        /// A uiform variable in shader.
        /// </summary>
        /// <param name="varName"></param>
        public UniformSingleVariable(string varName) : base(varName) { }

        /// <summary>
        /// A uiform variable in shader.
        /// </summary>
        /// <param name="varName"></param>
        /// <param name="value"></param>
        public UniformSingleVariable(string varName, T value) : base(varName) { this.Value = value; }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public override string ToString() {
            return string.Format("{0} {1}: [{2}]", this.GetType().Name, this.varName, this.value);
        }
    }
}