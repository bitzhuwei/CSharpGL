
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;


namespace CSharpGL
{
    /// <summary>
    /// uniform mat3 variable;
    /// </summary>
    public class UniformMat3 : UniformSingleVariable<mat3>
    {

        /// <summary>
        /// uniform mat3 variable;
        /// </summary>
        /// <param name="varName"></param>
        public UniformMat3(string varName) : base(varName) { }
        /// <summary>
        /// uniform mat3 variable;
        /// </summary>
        /// <param name="varName"></param>
        /// <param name="value"></param>
        public UniformMat3(string varName, mat3 value) : base(varName, value) { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="program"></param>
        public override void SetUniform(ShaderProgram program)
        {
            this.Location = program.SetUniformMatrix3(VarName, this.value.ToArray());
        }
    }

}
