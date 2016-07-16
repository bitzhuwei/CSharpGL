
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;


namespace CSharpGL
{
    /// <summary>
    /// uniform mat2 variable;
    /// </summary>
    public class UniformMat2 : UniformSingleVariable<mat2>
    {

        /// <summary>
        /// uniform mat2 variable;
        /// </summary>
        /// <param name="varName"></param>
        public UniformMat2(string varName) : base(varName) { }
        /// <summary>
        /// uniform mat2 variable;
        /// </summary>
        /// <param name="varName"></param>
        /// <param name="value"></param>
        public UniformMat2(string varName, mat2 value) : base(varName, value) { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="program"></param>
        public override void SetUniform(ShaderProgram program)
        {
            this.Location = program.SetUniformMatrix2(VarName, this.value.ToArray());
        }

    }
}
