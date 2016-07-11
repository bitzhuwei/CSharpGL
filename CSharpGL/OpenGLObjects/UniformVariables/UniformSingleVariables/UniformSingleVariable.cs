using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;


namespace CSharpGL
{
    /// <summary>
    /// shader中的一个uniform变量。
    /// </summary>
    public abstract class UniformSingleVariable<T> : UniformSingleVariableBase where T : struct, IEquatable<T>
    {

        /// <summary>
        /// 
        /// </summary>
        protected T value;
        /// <summary>
        /// Don't rename this property because its used in Renderer.GetVariable&lt;T&gt;(T value, string varNameInShader).
        /// </summary>
        public T Value
        {
            get { return this.value; }
            set
            {
                if (!value.Equals(this.value))
                {
                    this.value = value;
                    this.Updated = true;
                }
            }
        }

        /// <summary>
        /// shader中的一个uniform变量。
        /// </summary>
        /// <param name="varName"></param>
        public UniformSingleVariable(string varName) : base(varName) { }

        /// <summary>
        /// shader中的一个uniform变量。
        /// </summary>
        /// <param name="varName"></param>
        /// <param name="value"></param>
        public UniformSingleVariable(string varName, T value) : base(varName) { this.Value = value; }

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="value"></param>
        //internal abstract bool SetValue(T value);

        //internal abstract T GetValue();
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("{0} {1}: [{2}]", this.GetType().Name, this.VarName, this.value);
        }

    }

}
