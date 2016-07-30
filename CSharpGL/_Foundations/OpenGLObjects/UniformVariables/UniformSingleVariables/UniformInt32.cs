
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;


namespace CSharpGL
{
    /// <summary>
    /// uniform int variable;
    /// </summary>
    public class UniformInt32 : UniformSingleVariable<int>
    {

        /// <summary>
        /// uniform int variable;
        /// </summary>
        /// <param name="varName"></param>
        public UniformInt32(string varName) : base(varName) { }

        /// <summary>
        /// uniform int variable;
        /// </summary>
        /// <param name="varName"></param>
        /// <param name="value"></param>
        public UniformInt32(string varName, int value) : base(varName, value) { }
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