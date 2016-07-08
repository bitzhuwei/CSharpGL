
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;


namespace CSharpGL
{
    /// <summary>
    /// uniform mat4 variable[10];
    /// </summary>
    public class UniformMat4Array : UniformArrayVariable
    {

        private mat4[] value;

        /// <summary>
        /// 
        /// </summary>
        public mat4[] Value
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
        /// uniform mat4 variable[10];
        /// </summary>
        /// <param name="varName"></param>
        public UniformMat4Array(string varName) : base(varName) { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="program"></param>
        public override void SetUniform(ShaderProgram program)
        {
            this.Location = program.SetUniformMatrix4(VarName, this.value);
        }

    }
}
