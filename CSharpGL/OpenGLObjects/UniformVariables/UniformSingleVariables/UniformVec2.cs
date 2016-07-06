
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;


namespace CSharpGL
{
    public class UniformVec2 : UniformSingleVariable
    {

        private vec2 value;

        public vec2 Value
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

        public UniformVec2(string varName) : base(varName) { }

        public UniformVec2(string varName, vec2 value) : base(varName) { this.Value = value; }

        public override void SetUniform(ShaderProgram program)
        {
            this.Location = program.SetUniform(VarName, value.x, value.y);
        }

        internal override bool SetValue(ValueType value)
        {
#if DEBUG
            if (value.GetType() != typeof(vec2))
            {
                throw new ArgumentException(string.Format("[{0}] not match [{1}]'s value.",
                    value.GetType().Name, this.GetType().Name));
            }
#endif

            var v = (vec2)value;
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
