
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;


namespace CSharpGL
{
    /// <summary>
    /// uniform uvec2 variable;
    /// </summary>
    public class UniformUVec2 : UniformSingleVariable<uvec2>
    {

        /// <summary>
        /// uniform uvec2 variable;
        /// </summary>
        /// <param name="varName"></param>
        public UniformUVec2(string varName) : base(varName) { }
        /// <summary>
        /// uniform uvec2 variable;
        /// </summary>
        /// <param name="varName"></param>
        /// <param name="value"></param>
        public UniformUVec2(string varName, uvec2 value) : base(varName, value) { }

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
