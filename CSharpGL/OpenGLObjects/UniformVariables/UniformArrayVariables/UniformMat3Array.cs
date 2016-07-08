
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;


namespace CSharpGL
{
    /// <summary>
    /// uniform mat3 variable[10];
    /// </summary>
    public class UniformMat3Array : UniformArrayVariable
    {

        private mat3[] value;
        /// <summary>
        /// 
        /// </summary>
        public mat3[] Value
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
        /// uniform mat3 variable[10];
        /// </summary>
        /// <param name="varName"></param>
        public UniformMat3Array(string varName) : base(varName) { }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="program"></param>
        public override void SetUniform(ShaderProgram program)
        {
            this.Location = program.SetUniformMatrix3(VarName, this.value);
        }

    }

}
