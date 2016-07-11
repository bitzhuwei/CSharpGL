
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;


namespace CSharpGL
{
    /// <summary>
    /// 由于未知的原因，shader对bool没反应，所以内部用float的1.0f和0.0f代替bool的true和false。
    /// uniform bool variable;
    /// </summary>
    public class UniformBool : UniformSingleVariable<bool>
    {

        /// <summary>
        /// uniform bool variable;
        /// </summary>
        /// <param name="varName"></param>
        public UniformBool(string varName) : base(varName) { }

        /// <summary>
        /// uniform bool variable;
        /// </summary>
        /// <param name="varName"></param>
        /// <param name="value"></param>
        public UniformBool(string varName, bool value) : base(varName, value) { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="program"></param>
        public override void SetUniform(ShaderProgram program)
        {
            this.Location = program.SetUniform(VarName, value ? 1 : 0);
        }

    }

}