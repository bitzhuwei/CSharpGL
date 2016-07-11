
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;


namespace CSharpGL
{
    /// <summary>
    /// uniform float variable[10];
    /// </summary>
    public class UniformFloatArray : UniformArrayVariable
    {

        private float[] value;
        /// <summary>
        /// 
        /// </summary>
        public float[] Value
        {
            get { return this.value; }
            set
            {
                this.value = value;
                this.Updated = true;
            }
        }

        /// <summary>
        /// uniform float variable[10];
        /// </summary>
        /// <param name="varName"></param>
        public UniformFloatArray(string varName) : base(varName) { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="program"></param>
        public override void SetUniform(ShaderProgram program)
        {
            this.Location = program.SetUniform(VarName, value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("{0} {1}: {2}", this.GetType().Name, this.VarName, this.value.PrintArray(", "));
        }
    }

}