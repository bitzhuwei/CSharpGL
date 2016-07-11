
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;


namespace CSharpGL
{
    /// <summary>
    /// uniform float variable[10];
    /// </summary>
    public class UniformFloatArray : UniformArrayVariable<float>
    {

        /// <summary>
        /// uniform float variable[10];
        /// </summary>
        /// <param name="varName"></param>
        public UniformFloatArray(string varName) : base(varName) { }

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