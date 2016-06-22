
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;


namespace CSharpGL
{
    public class UniformVec2Array : UniformArrayVariable
    {

        private vec2[] value;

        public vec2[] Value
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

        public UniformVec2Array(string varName) : base(varName) { }

        public override void SetUniform(ShaderProgram program)
        {
            this.Location = program.SetUniform(VarName, value);
        }

    }
}
