using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL
{
    /// <summary>
    /// shader中的一个uniform变量。
    /// </summary>
    public abstract class UniformSingleVariable : UniformVariable
    {

        /// <summary>
        /// shader中的一个uniform变量。
        /// </summary>
        /// <param name="varName"></param>
        public UniformSingleVariable(string varName) : base(varName) { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        internal abstract bool SetValue(ValueType value);

        internal abstract ValueType GetValue();

        public override string ToString()
        {
            return string.Format("{0}: {1}", this.VarName, this.GetValue());
        }

    }

}
