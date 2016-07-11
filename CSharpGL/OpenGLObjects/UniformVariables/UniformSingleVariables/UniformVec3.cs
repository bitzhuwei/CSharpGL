
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;


namespace CSharpGL
{
    /// <summary>
    /// uniform vec3 variable;
    /// </summary>
    public class UniformVec3 : UniformSingleVariable<vec3>
    {

        private vec3 value;

        /// <summary>
        /// 
        /// </summary>
        public vec3 Value
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
        /// uniform vec3 variable;
        /// </summary>
        /// <param name="varName"></param>
        public UniformVec3(string varName) : base(varName) { }

        /// <summary>
        /// uniform vec3 variable;
        /// </summary>
        /// <param name="varName"></param>
        /// <param name="value"></param>
        public UniformVec3(string varName, vec3 value) : base(varName, value) { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="program"></param>
        public override void SetUniform(ShaderProgram program)
        {
            this.Location = program.SetUniform(VarName, value.x, value.y, value.z);
        }
    }

}
