
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;


namespace CSharpGL
{
    /// <summary>
    /// uniform float variable;
    /// </summary>
    public class UniformFloat : UniformSingleVariable<float>
    {

        /// <summary>
        /// uniform float variable;
        /// </summary>
        /// <param name="varName"></param>
        public UniformFloat(string varName) : base(varName) { }

        /// <summary>
        /// uniform float variable;
        /// </summary>
        /// <param name="varName"></param>
        /// <param name="value"></param>
        public UniformFloat(string varName, float value) : base(varName, value) { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="program"></param>
        public override void SetUniform(ShaderProgram program)
        {
            this.Location = program.SetUniform(VarName, value);
        }
    }

}