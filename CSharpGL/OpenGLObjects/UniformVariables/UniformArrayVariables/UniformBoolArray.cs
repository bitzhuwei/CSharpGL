
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;


namespace CSharpGL
{
    /// <summary>
    /// 由于未知的原因，shader对bool没反应，所以内部用float的1.0f和0.0f代替bool的true和false。
    /// uniform bool variable[10];
    /// </summary>
    public class UniformBoolArray : UniformArrayVariable<bool>
    {

        /// <summary>
        /// uniform bool variable[10];
        /// </summary>
        /// <param name="varName"></param>
        public UniformBoolArray(string varName) : base(varName) { }
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