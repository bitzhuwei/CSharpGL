using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;


namespace CSharpGL
{
    // TODO: No Uniform Array Variable types are tested yet.
    /// <summary>
    /// shader中的一个数组类型的uniform变量。
    /// 例如：uniform vec3 positions[10];
    /// </summary>
    public abstract class UniformArrayVariable : UniformVariable
    {

        /// <summary>
        /// shader中的一个数组类型的uniform变量。
        /// </summary>
        /// <param name="varName"></param>
        public UniformArrayVariable(string varName) : base(varName) { }

        protected abstract Array GetValue();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            Array array = this.GetValue();
            if (array != null)
            {
                return string.Format("{0} {1}: [{2}]", this.GetType().Name, this.VarName, this.GetValue().PrintArray("; "));
            }
            else
            {
                return string.Format("{0} {1}: []", this.GetType().Name, this.VarName);
            }
        }
    }

}
