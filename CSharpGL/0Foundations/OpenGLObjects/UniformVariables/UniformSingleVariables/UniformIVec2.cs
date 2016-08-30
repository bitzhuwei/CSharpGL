
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;


namespace CSharpGL
{
    /// <summary>
    /// uniform ivec2 variable;
    /// </summary>
    public class UniformIVec2 : UniformSingleVariable<ivec2>
    {

        /// <summary>
        /// uniform ivec2 variable;
        /// </summary>
        /// <param name="varName"></param>
        public UniformIVec2(string varName) : base(varName) { }
        /// <summary>
        /// uniform ivec2 variable;
        /// </summary>
        /// <param name="varName"></param>
        /// <param name="value"></param>
        public UniformIVec2(string varName, ivec2 value) : base(varName, value) { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="program"></param>
        public override void SetUniform(ShaderProgram program)
        {
            this.Location = program.SetUniform(VarName, value.x, value.y);
        }
    }
}
