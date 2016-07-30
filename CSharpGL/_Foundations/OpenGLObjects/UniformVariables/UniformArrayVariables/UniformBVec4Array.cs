
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;


namespace CSharpGL
{
    /// <summary>
    /// uniform bvec4 variable[10];
    /// </summary>
    public class UniformBVec4Array : UniformArrayVariable<bvec4>
    {

        /// <summary>
        /// uniform bvec4 variable[10];
        /// </summary>
        /// <param name="varName"></param>
        /// <param name="length"></param>
        public UniformBVec4Array(string varName, int length) : base(varName, length) { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="program"></param>
        public override void SetUniform(ShaderProgram program)
        {
            this.Location = program.SetUniform(VarName, this.Value.Array);
        }

    }
}