
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;


namespace CSharpGL
{
    public class UniformVec4Array : UniformArrayVariable
    {

        private vec4[] value;

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

        public UniformVec4Array(string varName) : base(varName) { }

        public override void SetUniform(ShaderProgram program)
        {
            this.Location = program.SetUniform(VarName, value);
        }

    }
}