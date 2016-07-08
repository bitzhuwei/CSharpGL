using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;


namespace CSharpGL
{
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
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("{0}: {1}", this.GetType().Name, this.VarName);
        }

    }

}
