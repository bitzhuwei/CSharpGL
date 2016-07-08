
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;


namespace CSharpGL
{
    /// <summary>
    /// uniform mat2 variable[10];
    /// </summary>
    public class UniformMat2Array : UniformArrayVariable
    {

        private mat2[] value;
        /// <summary>
        /// 
        /// </summary>
        public mat2[] Value
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
        /// uniform mat2 variable[10];
        /// </summary>
        /// <param name="varName"></param>
        public UniformMat2Array(string varName) : base(varName) { }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="program"></param>
        public override void SetUniform(ShaderProgram program)
        {
            this.Location = program.SetUniformMatrix2(VarName, this.value);
        }

    }
}
