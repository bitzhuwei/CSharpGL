
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;


namespace CSharpGL
{
    /// <summary>
    /// 由于未知的原因，shader对bool没反应，所以内部用float的1.0f和0.0f代替bool的true和false。
    /// </summary>
    public class UniformBoolArray : UniformArrayVariable
    {

        private bool[] value;

        public bool[] Value
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

        public UniformBoolArray(string varName) : base(varName) { }

        public override void SetUniform(ShaderProgram program)
        {
            this.Location = program.SetUniform(VarName, value);
        }

    }

}