
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGL
{
    public class UniformMat2 : UniformSingleVariable
    {

        private mat2 value;

        public mat2 Value
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

        public UniformMat2(string varName) : base(varName) { }

        public override void SetUniform(ShaderProgram program)
        {
            program.SetUniformMatrix2(VarName, this.value.to_array());
        }

        internal override bool SetValue(ValueType value)
        {
            if (value.GetType() != typeof(mat2))
            {
                throw new ArgumentException(string.Format("[{0}] not match [{1}]'s value.",
                    value.GetType().Name, this.GetType().Name));
            }

            var v = (mat2)value;
            if (v != this.value)
            {
                this.value = v;
                this.Updated = true;
                return true;
            }
            else
            {
                return false;
            }
        }

        internal override ValueType GetValue()
        {
            return value;
        }
    }
}
