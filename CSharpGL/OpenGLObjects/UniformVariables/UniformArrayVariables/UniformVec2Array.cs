
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;


namespace CSharpGL
{
    /// <summary>
    /// uniform vec2 variable[10];
    /// </summary>
    public class UniformVec2Array : UniformArrayVariable<vec2>
    {

        /// <summary>
        /// uniform vec2 variable[10];
        /// </summary>
        /// <param name="varName"></param>
        public UniformVec2Array(string varName) : base(varName) { }
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
