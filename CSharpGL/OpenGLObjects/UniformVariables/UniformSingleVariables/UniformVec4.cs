
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;


namespace CSharpGL
{
    public class UniformVec4 : UniformSingleVariable
    {

        private vec4 value;

        public vec4 Value
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

        public UniformVec4(string varName) : base(varName) { }

        public UniformVec4(string varName, vec4 value) : base(varName) { this.Value = value; }

        public override void SetUniform(ShaderProgram program)
        {
            this.Location = program.SetUniform(VarName, value.x, value.y, value.z, value.w);
        }

        internal override bool SetValue(ValueType value)
        {
#if DEBUG
            if (value.GetType() != typeof(vec4))
            {
                throw new ArgumentException(string.Format("[{0}] not match [{1}]'s value.",
                    value.GetType().Name, this.GetType().Name));
            }
#endif

            var v = (vec4)value;
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