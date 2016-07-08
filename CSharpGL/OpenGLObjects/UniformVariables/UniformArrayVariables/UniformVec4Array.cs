
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;


namespace CSharpGL
{
    /// <summary>
    /// uniform vec4 variable[10];
    /// </summary>
    public class UniformVec4Array : UniformArrayVariable
    {

        private vec4[] value;

        /// <summary>
        /// 
        /// </summary>
        public vec4[] Value
        {
            get { return this.value; }
            set
            {
                if (this.value != value)
                {
                    this.value = value;
                    this.Updated = true;
                }
            }
        }

        /// <summary>
        /// uniform vec4 variable[10];
        /// </summary>
        /// <param name="varName"></param>
        public UniformVec4Array(string varName) : base(varName) { }

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