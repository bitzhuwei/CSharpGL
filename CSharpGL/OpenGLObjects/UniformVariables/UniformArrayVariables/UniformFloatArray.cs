
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;


namespace CSharpGL
{
    public class UniformFloatArray : UniformArrayVariable
    {

        private float[] value;

        public float[] Value
        {
            get { return this.value; }
            set
            {
                this.value = value;
                this.Updated = true;
            }
        }

        public UniformFloatArray(string varName) : base(varName) { }

        public override void SetUniform(ShaderProgram program)
        {
            this.Location = program.SetUniform(VarName, value);
        }

    }

}